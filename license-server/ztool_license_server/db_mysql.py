"""
MySQL-backed license storage for the ZTool TCP server.

This backend makes the TCP activation server share a single source of truth
with the PHP web admin panel (database ``ztool_license``). Keys created in the
admin panel are read here; activations / transfers performed over the TCP
protocol write straight back into the same ``license_keys`` table, so the admin
panel reflects the real machine binding, activation count and last-check time.

It implements the same public interface as :class:`ztool_license_server.db.LicenseDB`
so :class:`~ztool_license_server.server.LicenseServer` can use either backend
interchangeably (selected via configuration). The SQLite backend remains the
default and is what the unit tests exercise; this module is only imported when
the server is configured with ``db_backend == "mysql"``.

Schema mapping (admin ``license_keys`` table → TCP concepts):
- ``license_key``          ← registration code
- ``max_activations``      ← device limit
- ``current_activations``  ← active seat count
- ``machine_id``           ← sha256("UUID|disk|board") of the bound fingerprint
                             (64 hex chars, matching the panel's existing rows)
- ``machine_meta``         ← the raw "UUID|disk|board" fingerprint (for humans)
- ``activated_at`` / ``last_check_at`` ← timestamps shown in the panel
- ``transfer_password_hash`` ← optional password protecting the key

The single ``machine_id`` column means a key binds to exactly one machine at a
time (the floating model: transfer frees the slot). This matches every key the
admin panel issues (``max_activations`` defaults to 1).
"""

import hashlib
import logging
from datetime import datetime
from typing import Optional, Tuple

from .protocol.dispatcher import Status
from .machineid import is_valid_machine_code

logger = logging.getLogger(__name__)


def machine_hash(machine_code: str) -> str:
    """Stable 64-hex identifier for a raw "UUID|disk|board" fingerprint.

    The admin panel's ``machine_id`` column is ``VARCHAR(64)`` and its existing
    rows hold 64-character hex digests, so we store ``sha256`` of the raw
    fingerprint rather than the (up to ~70-char) raw string itself.
    """
    return hashlib.sha256(machine_code.encode("utf-8")).hexdigest()


class MySQLLicenseDB:
    """MySQL/MariaDB-backed license storage (shared with the web admin panel)."""

    # activation_log.action is an ENUM; map the TCP server's action labels onto
    # the allowed values so the panel's log stays consistent.
    _ACTION_MAP = {
        "apply_register": "activate",
        "register": "activate",
        "apply_remove": "deactivate",
        "remove_confirm": "deactivate",
    }

    def __init__(self, *, host: str, database: str, user: str, password: str,
                 charset: str = "utf8mb4", port: int = 3306):
        # Imported lazily so the rest of the package (and the test suite, which
        # uses the SQLite backend) does not depend on PyMySQL being installed.
        import pymysql

        self._pymysql = pymysql
        self._connect_kwargs = dict(
            host=host,
            port=port,
            user=user,
            password=password,
            database=database,
            charset=charset,
            autocommit=True,
            cursorclass=pymysql.cursors.DictCursor,
        )
        self._conn = pymysql.connect(**self._connect_kwargs)
        logger.info("MySQL license backend connected (db=%s)", database)

    # -- connection helpers ------------------------------------------------
    def _cursor(self):
        """Return a live cursor, transparently reconnecting if the link dropped."""
        try:
            self._conn.ping(reconnect=True)
        except Exception:
            self._conn = self._pymysql.connect(**self._connect_kwargs)
        return self._conn.cursor()

    def _fetchone(self, sql: str, params: tuple = ()):  # pragma: no cover - thin wrapper
        cur = self._cursor()
        try:
            cur.execute(sql, params)
            return cur.fetchone()
        finally:
            cur.close()

    def _execute(self, sql: str, params: tuple = ()):  # pragma: no cover - thin wrapper
        cur = self._cursor()
        try:
            cur.execute(sql, params)
            return cur.rowcount
        finally:
            cur.close()

    # -- key management (CLI parity) --------------------------------------
    def add_license_code(self, code: str, password: str = "",
                         device_limit: int = 1,
                         expires_at: Optional[str] = None,
                         note: str = "") -> None:
        """Create/replace a key. Keys are normally created in the admin panel;
        this exists for CLI parity. ``customer_name`` is NOT NULL in the schema.
        """
        pw_hash = ""
        if password:
            pw_hash = self._hash_password(password)
        self._execute(
            """
            INSERT INTO license_keys
                (license_key, customer_name, max_activations, expires_at,
                 transfer_password_hash, notes, is_active)
            VALUES (%s, %s, %s, %s, %s, %s, 1)
            ON DUPLICATE KEY UPDATE
                max_activations = VALUES(max_activations),
                expires_at = VALUES(expires_at),
                transfer_password_hash = VALUES(transfer_password_hash),
                notes = VALUES(notes)
            """,
            (code, note or "CLI", int(device_limit), expires_at, pw_hash, note),
        )

    # -- validation --------------------------------------------------------
    def validate_code(self, code: str) -> Tuple[bool, str]:
        row = self._fetchone(
            "SELECT is_active, is_revoked, expires_at FROM license_keys "
            "WHERE license_key = %s",
            (code,),
        )
        if row is None:
            return False, Status.INVALID_CODE
        if row.get("is_revoked"):
            return False, Status.INVALID_CODE
        if not row.get("is_active"):
            return False, Status.CODE_EXPIRED
        exp = row.get("expires_at")
        if exp is not None:
            # PyMySQL returns DATETIME as a datetime object.
            if isinstance(exp, str):
                try:
                    exp = datetime.fromisoformat(exp)
                except ValueError:
                    exp = None
            if isinstance(exp, datetime) and datetime.now() > exp:
                return False, Status.CODE_EXPIRED
        return True, ""

    def check_password(self, code: str, password: str) -> bool:
        row = self._fetchone(
            "SELECT transfer_password_hash FROM license_keys WHERE license_key = %s",
            (code,),
        )
        if row is None:
            return False
        stored = row.get("transfer_password_hash") or ""
        if not stored:
            return True  # No password required
        return self._verify_password(password, stored)

    # -- activation state --------------------------------------------------
    def get_activation_count(self, code: str) -> int:
        row = self._fetchone(
            "SELECT current_activations FROM license_keys WHERE license_key = %s",
            (code,),
        )
        return int(row["current_activations"]) if row else 0

    def get_device_limit(self, code: str) -> int:
        row = self._fetchone(
            "SELECT max_activations FROM license_keys WHERE license_key = %s",
            (code,),
        )
        return int(row["max_activations"]) if row else 0

    def is_machine_activated(self, code: str, machine_code: str) -> bool:
        mid = machine_hash(machine_code)
        row = self._fetchone(
            "SELECT id FROM license_keys "
            "WHERE license_key = %s AND machine_id = %s AND is_active = 1",
            (code, mid),
        )
        return row is not None

    def activate(self, code: str, machine_code: str) -> Tuple[bool, str]:
        # Defense-in-depth: never bind a seat to an empty/blank fingerprint.
        if not machine_code or not machine_code.strip():
            return False, Status.INFO_ERROR

        mid = machine_hash(machine_code)
        row = self._fetchone(
            "SELECT machine_id, current_activations, max_activations "
            "FROM license_keys WHERE license_key = %s",
            (code,),
        )
        if row is None:
            return False, Status.INVALID_CODE

        # Already bound to THIS machine -> idempotent success, refresh last check.
        if row.get("machine_id") == mid:
            self._execute(
                "UPDATE license_keys SET last_check_at = %s WHERE license_key = %s",
                (datetime.now(), code),
            )
            return True, ""

        current = int(row.get("current_activations") or 0)
        max_act = int(row.get("max_activations") or 1)
        bound_to_other = bool(row.get("machine_id"))
        # One free seat must remain. The single machine_id column means a key
        # already bound to a different machine is full until transferred out.
        if bound_to_other or current >= max_act:
            return False, Status.DEVICE_LIMIT

        self._execute(
            """
            UPDATE license_keys SET
                machine_id = %s,
                machine_meta = %s,
                machine_label = %s,
                current_activations = current_activations + 1,
                activated_at = COALESCE(activated_at, %s),
                last_check_at = %s,
                is_active = 1
            WHERE license_key = %s
            """,
            (mid, machine_code, machine_code[:255], datetime.now(),
             datetime.now(), code),
        )
        return True, ""

    def deactivate(self, code: str, machine_code: str) -> Tuple[bool, str]:
        if not self.is_machine_activated(code, machine_code):
            return False, Status.NO_TRANSFER_NEEDED
        self._execute(
            """
            UPDATE license_keys SET
                machine_id = NULL,
                machine_meta = NULL,
                machine_label = NULL,
                current_activations = GREATEST(current_activations - 1, 0),
                last_check_at = %s
            WHERE license_key = %s
            """,
            (datetime.now(), code),
        )
        return True, ""

    def purge_invalid_activations(self) -> int:
        """Clear any binding whose stored fingerprint is not a genuine hardware
        machine code. Returns the number of keys cleared."""
        rows = self._cursor()
        try:
            rows.execute(
                "SELECT id, machine_meta FROM license_keys "
                "WHERE machine_id IS NOT NULL"
            )
            found = rows.fetchall()
        finally:
            rows.close()
        bad = [r["id"] for r in found
               if not is_valid_machine_code(r.get("machine_meta") or "")]
        for bad_id in bad:
            self._execute(
                "UPDATE license_keys SET machine_id = NULL, machine_meta = NULL, "
                "machine_label = NULL, "
                "current_activations = GREATEST(current_activations - 1, 0) "
                "WHERE id = %s",
                (bad_id,),
            )
        return len(bad)

    # -- audit -------------------------------------------------------------
    def log_action(self, action: str, code: str = "", machine_code: str = "",
                   result: str = "", details: str = "") -> None:
        """Best-effort write into the panel's activation_log. Never raises:
        the audit trail must not break license issuance."""
        mapped = self._ACTION_MAP.get(action)
        if mapped is None:
            return
        # The admin panel's activation_log is keyed by license_key. Some protocol
        # events carry no code (e.g. register_confirm sends only registry
        # branches), so skip those rather than writing a noisy NULL-key row — the
        # meaningful activate/deactivate rows are written at apply_register /
        # apply_remove, which do carry the code.
        if not code:
            return
        success = 1 if result in ("accepted", "success", "confirmed", "") else 0
        msg = (details or result)[:255]
        mid = machine_hash(machine_code) if machine_code else None
        try:
            lic = self._fetchone(
                "SELECT id FROM license_keys WHERE license_key = %s", (code,)
            )
            self._execute(
                "INSERT INTO activation_log "
                "(license_id, license_key, machine_id, action, success, error_message) "
                "VALUES (%s, %s, %s, %s, %s, %s)",
                (lic["id"] if lic else None, code or None, mid, mapped, success,
                 msg or None),
            )
        except Exception as e:  # pragma: no cover - audit must never break flow
            logger.debug("activation_log insert skipped: %s", e)

    # -- password helpers --------------------------------------------------
    @staticmethod
    def _hash_password(password: str) -> str:
        try:
            import bcrypt
            return bcrypt.hashpw(password.encode("utf-8"), bcrypt.gensalt()).decode()
        except Exception:
            # No bcrypt available: store a marker the verifier understands.
            return "plain:" + password

    @staticmethod
    def _verify_password(password: str, stored: str) -> bool:
        if stored.startswith("plain:"):
            return password == stored[len("plain:"):]
        try:
            import bcrypt
            return bcrypt.checkpw(password.encode("utf-8"), stored.encode("utf-8"))
        except Exception:
            return False

    def close(self):
        try:
            self._conn.close()
        except Exception:
            pass
