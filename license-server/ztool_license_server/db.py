"""SQLite database for license management."""

import base64
import hashlib
import hmac
import os
import secrets
import sqlite3
from contextlib import contextmanager
from datetime import datetime, timedelta
from typing import Optional, Tuple


LATEST_SCHEMA_VERSION = 4
PASSWORD_ALGO = "pbkdf2_sha256"
PASSWORD_ITERATIONS = 200_000


class LicenseDB:
    """SQLite-based license storage."""

    def __init__(self, db_path: str):
        self.db_path = db_path
        db_dir = os.path.dirname(os.path.abspath(db_path))
        if db_dir:
            os.makedirs(db_dir, exist_ok=True)
        self._conn = sqlite3.connect(db_path)
        self._conn.row_factory = sqlite3.Row
        self._transaction_depth = 0
        self._configure_pragmas()
        self._migrate_schema()

    def _configure_pragmas(self) -> None:
        self._conn.execute("PRAGMA foreign_keys = ON")
        self._conn.execute("PRAGMA busy_timeout = 5000")
        self._conn.execute("PRAGMA synchronous = NORMAL")
        if self.db_path != ":memory:":
            self._conn.execute("PRAGMA journal_mode = WAL")

    @contextmanager
    def transaction(self):
        """Run DB changes atomically, supporting nested callers."""
        outer = self._transaction_depth == 0
        if outer:
            self._conn.execute("BEGIN IMMEDIATE")
        self._transaction_depth += 1
        try:
            yield
            self._transaction_depth -= 1
            if outer:
                self._conn.commit()
        except Exception:
            self._transaction_depth -= 1
            if outer:
                self._conn.rollback()
            raise

    def _commit_if_needed(self) -> None:
        if self._transaction_depth == 0:
            self._conn.commit()

    def _migrate_schema(self) -> None:
        self._conn.execute("""
            CREATE TABLE IF NOT EXISTS schema_version (
                version INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                applied_at TEXT DEFAULT (datetime('now'))
            )
        """)
        self._conn.commit()

        migrations = [
            (1, "initial_existing_schema", self._migration_001_initial_schema),
            (2, "password_hash_columns", self._migration_002_password_hash_columns),
            (3, "pending_activation_transfer", self._migration_003_pending_tables),
            (4, "indexes_constraints", self._migration_004_indexes),
        ]
        applied = {
            row["version"]
            for row in self._conn.execute("SELECT version FROM schema_version").fetchall()
        }
        for version, name, fn in migrations:
            if version in applied:
                continue
            with self.transaction():
                fn()
                self._conn.execute(
                    "INSERT INTO schema_version (version, name) VALUES (?, ?)",
                    (version, name),
                )

    def _migration_001_initial_schema(self) -> None:
        self._conn.execute("""
            CREATE TABLE IF NOT EXISTS license_codes (
                code TEXT PRIMARY KEY,
                password TEXT,
                device_limit INTEGER DEFAULT 1,
                expires_at TEXT,
                created_at TEXT DEFAULT (datetime('now')),
                is_active INTEGER DEFAULT 1,
                note TEXT
            )
        """)
        self._conn.execute("""
            CREATE TABLE IF NOT EXISTS activations (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                code TEXT NOT NULL,
                machine_code TEXT NOT NULL,
                activated_at TEXT DEFAULT (datetime('now')),
                is_active INTEGER DEFAULT 1,
                FOREIGN KEY (code) REFERENCES license_codes(code),
                UNIQUE(code, machine_code)
            )
        """)
        self._conn.execute("""
            CREATE TABLE IF NOT EXISTS audit_log (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                timestamp TEXT DEFAULT (datetime('now')),
                action TEXT NOT NULL,
                code TEXT,
                machine_code TEXT,
                result TEXT,
                details TEXT
            )
        """)

    def _migration_002_password_hash_columns(self) -> None:
        self._add_column_if_missing("license_codes", "password_hash", "TEXT")
        self._add_column_if_missing("license_codes", "password_salt", "TEXT")
        self._add_column_if_missing("license_codes", "password_algo", "TEXT")
        self._migrate_plaintext_passwords()

    def _migration_003_pending_tables(self) -> None:
        self._conn.execute("""
            CREATE TABLE IF NOT EXISTS pending_activations (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                code TEXT NOT NULL,
                machine_code TEXT NOT NULL,
                nonce TEXT NOT NULL,
                created_at TEXT DEFAULT (datetime('now')),
                expires_at TEXT,
                status TEXT DEFAULT 'pending',
                FOREIGN KEY (code) REFERENCES license_codes(code)
            )
        """)
        self._conn.execute("""
            CREATE TABLE IF NOT EXISTS pending_transfers (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                code TEXT NOT NULL,
                machine_code TEXT NOT NULL,
                nonce TEXT NOT NULL,
                created_at TEXT DEFAULT (datetime('now')),
                expires_at TEXT,
                status TEXT DEFAULT 'pending',
                FOREIGN KEY (code) REFERENCES license_codes(code)
            )
        """)

    def _migration_004_indexes(self) -> None:
        self._conn.execute("""
            CREATE INDEX IF NOT EXISTS idx_activations_code_active
                ON activations(code, is_active)
        """)
        self._conn.execute("""
            CREATE INDEX IF NOT EXISTS idx_activations_machine_active
                ON activations(machine_code, is_active)
        """)
        self._conn.execute("""
            CREATE INDEX IF NOT EXISTS idx_audit_timestamp
                ON audit_log(timestamp)
        """)
        self._conn.execute("""
            CREATE INDEX IF NOT EXISTS idx_pending_activations_code_status
                ON pending_activations(code, status)
        """)
        self._conn.execute("""
            CREATE INDEX IF NOT EXISTS idx_pending_transfers_code_status
                ON pending_transfers(code, status)
        """)

    def _add_column_if_missing(self, table: str, column: str, definition: str) -> None:
        columns = {
            row["name"]
            for row in self._conn.execute(f"PRAGMA table_info({table})").fetchall()
        }
        if column not in columns:
            self._conn.execute(f"ALTER TABLE {table} ADD COLUMN {column} {definition}")

    def _migrate_plaintext_passwords(self) -> None:
        rows = self._conn.execute("""
            SELECT code, password FROM license_codes
            WHERE COALESCE(password, '') != ''
              AND COALESCE(password_hash, '') = ''
        """).fetchall()
        for row in rows:
            password_hash, salt = self._hash_password(row["password"])
            self._conn.execute("""
                UPDATE license_codes
                SET password = '',
                    password_hash = ?,
                    password_salt = ?,
                    password_algo = ?
                WHERE code = ?
            """, (password_hash, salt, PASSWORD_ALGO, row["code"]))

    def get_schema_version(self) -> int:
        row = self._conn.execute(
            "SELECT MAX(version) AS version FROM schema_version"
        ).fetchone()
        return int(row["version"] or 0)

    @staticmethod
    def _hash_password(password: str, salt: Optional[str] = None) -> Tuple[str, str]:
        salt = salt or secrets.token_hex(16)
        digest = hashlib.pbkdf2_hmac(
            "sha256",
            password.encode("utf-8"),
            salt.encode("utf-8"),
            PASSWORD_ITERATIONS,
        )
        return base64.b64encode(digest).decode("ascii"), salt

    @staticmethod
    def _verify_password(password: str, password_hash: str, salt: str) -> bool:
        candidate_hash, _ = LicenseDB._hash_password(password, salt)
        return hmac.compare_digest(candidate_hash, password_hash)

    def add_license_code(self, code: str, password: str = "",
                         device_limit: int = 1,
                         expires_at: Optional[str] = None,
                         note: str = "") -> None:
        """Add a new license code to the database."""
        if expires_at is None:
            # Default: 1 year from now
            expires_at = (datetime.now() + timedelta(days=365)).isoformat()

        password_hash = ""
        password_salt = ""
        password_algo = ""
        if password:
            password_hash, password_salt = self._hash_password(password)
            password_algo = PASSWORD_ALGO

        self._conn.execute(
            "INSERT INTO license_codes "
            "(code, password, password_hash, password_salt, password_algo, "
            "device_limit, expires_at, is_active, note) "
            "VALUES (?, '', ?, ?, ?, ?, ?, 1, ?) "
            "ON CONFLICT(code) DO UPDATE SET "
            "password = '', "
            "password_hash = excluded.password_hash, "
            "password_salt = excluded.password_salt, "
            "password_algo = excluded.password_algo, "
            "device_limit = excluded.device_limit, "
            "expires_at = excluded.expires_at, "
            "note = excluded.note",
            (code, password_hash, password_salt, password_algo, device_limit, expires_at, note)
        )
        self._commit_if_needed()

    def validate_code(self, code: str) -> Tuple[bool, str]:
        """
        Validate a license code.

        Returns:
            (is_valid, error_message)
        """
        row = self._conn.execute(
            "SELECT * FROM license_codes WHERE code = ?", (code,)
        ).fetchone()

        if row is None:
            return False, "无效注册码"  # Invalid code

        if not row['is_active']:
            return False, "注册码已过期"  # Expired

        if row['expires_at']:
            exp = datetime.fromisoformat(row['expires_at'])
            if datetime.now() > exp:
                return False, "注册码已过期"  # Expired

        return True, ""

    def check_password(self, code: str, password: str) -> bool:
        """Check if the password matches for a code (if one is set)."""
        row = self._conn.execute(
            "SELECT password, password_hash, password_salt, password_algo FROM license_codes WHERE code = ?",
            (code,)
        ).fetchone()

        if row is None:
            return False

        stored_hash = row['password_hash']
        stored_salt = row['password_salt']
        stored_algo = row['password_algo']
        stored_pw = row['password']

        if stored_hash:
            if not stored_salt:
                return False
            if stored_algo and stored_algo != PASSWORD_ALGO:
                return False
            return self._verify_password(password, stored_hash, stored_salt)

        if not stored_pw:
            return True  # No password required
        ok = hmac.compare_digest(stored_pw, password)
        if ok:
            password_hash, salt = self._hash_password(password)
            self._conn.execute("""
                UPDATE license_codes
                SET password = '', password_hash = ?, password_salt = ?, password_algo = ?
                WHERE code = ?
            """, (password_hash, salt, PASSWORD_ALGO, code))
            self._commit_if_needed()
        return ok

    def get_activation_count(self, code: str) -> int:
        """Get number of active activations for a code."""
        row = self._conn.execute(
            "SELECT COUNT(DISTINCT machine_code) as cnt FROM activations WHERE code = ? AND is_active = 1",
            (code,)
        ).fetchone()
        return row['cnt']

    def get_device_limit(self, code: str) -> int:
        """Get device limit for a code."""
        row = self._conn.execute(
            "SELECT device_limit FROM license_codes WHERE code = ?", (code,)
        ).fetchone()
        return row['device_limit'] if row else 0

    def is_machine_activated(self, code: str, machine_code: str) -> bool:
        """Check if a specific machine is already activated with this code."""
        row = self._conn.execute(
            "SELECT id FROM activations WHERE code = ? AND machine_code = ? AND is_active = 1",
            (code, machine_code)
        ).fetchone()
        return row is not None

    def activate(self, code: str, machine_code: str) -> Tuple[bool, str]:
        """
        Activate a license for a machine.

        Returns:
            (success, error_message)
        """
        # Defense-in-depth: never bind a seat to an empty/blank fingerprint.
        # The protocol layer already rejects non-hardware machine codes, but a
        # blank binding here would defeat hardware-locking entirely and let any
        # machine reuse the seat.
        if not machine_code or not machine_code.strip():
            return False, "注册信息错误"  # Registration info error

        # Check if already activated on this machine
        if self.is_machine_activated(code, machine_code):
            return True, ""  # Already active — success

        device_limit = self.get_device_limit(code)
        if device_limit <= 0:
            return False, "授权电脑数量已达上限"

        if self.get_activation_count(code) >= device_limit:
            return False, "授权电脑数量已达上限"  # Device limit reached

        self._conn.execute(
            "INSERT OR REPLACE INTO activations (code, machine_code, is_active) VALUES (?, ?, 1)",
            (code, machine_code)
        )
        self._commit_if_needed()
        return True, ""

    def deactivate(self, code: str, machine_code: str) -> Tuple[bool, str]:
        """
        Deactivate (transfer out) a license from a machine.

        Returns:
            (success, error_message)
        """
        if not self.is_machine_activated(code, machine_code):
            return False, "无需转出"  # No transfer needed

        self._conn.execute(
            "UPDATE activations SET is_active = 0 WHERE code = ? AND machine_code = ?",
            (code, machine_code)
        )
        self._commit_if_needed()
        return True, ""

    def purge_invalid_activations(self) -> int:
        """Deactivate every active binding whose machine_code is not a genuine
        hardware fingerprint (empty or non-GUID).

        Such rows could only exist from before hardware-binding validation was
        added; they wrongly occupy a license seat. Returns the number purged.
        """
        from .machineid import is_valid_machine_code

        rows = self._conn.execute(
            "SELECT id, machine_code FROM activations WHERE is_active = 1"
        ).fetchall()
        bad_ids = [row['id'] for row in rows
                   if not is_valid_machine_code(row['machine_code'])]
        for bad_id in bad_ids:
            self._conn.execute(
                "UPDATE activations SET is_active = 0 WHERE id = ?", (bad_id,)
            )
        if bad_ids:
            self._commit_if_needed()
        return len(bad_ids)

    def log_action(self, action: str, code: str = "", machine_code: str = "",
                   result: str = "", details: str = "") -> None:
        """Log an action to the audit log."""
        self._conn.execute(
            "INSERT INTO audit_log (action, code, machine_code, result, details) "
            "VALUES (?, ?, ?, ?, ?)",
            (action, code, machine_code, result, details)
        )
        self._commit_if_needed()

    def close(self):
        """Close the database connection."""
        self._conn.close()
