"""
SQLite database for license management.

Tables:
- license_codes: registration codes with limits and expiry
- activations: device bindings (machine_code → license_code)
- audit_log: all operations for traceability
"""

import sqlite3
import os
from datetime import datetime, timedelta
from typing import Optional, List, Tuple


class LicenseDB:
    """SQLite-based license storage."""

    def __init__(self, db_path: str):
        self.db_path = db_path
        os.makedirs(os.path.dirname(db_path), exist_ok=True)
        self._conn = sqlite3.connect(db_path)
        self._conn.row_factory = sqlite3.Row
        self._create_tables()

    def _create_tables(self):
        cur = self._conn.cursor()
        cur.executescript("""
            CREATE TABLE IF NOT EXISTS license_codes (
                code TEXT PRIMARY KEY,
                password TEXT,
                device_limit INTEGER DEFAULT 1,
                expires_at TEXT,
                created_at TEXT DEFAULT (datetime('now')),
                is_active INTEGER DEFAULT 1,
                note TEXT
            );

            CREATE TABLE IF NOT EXISTS activations (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                code TEXT NOT NULL,
                machine_code TEXT NOT NULL,
                activated_at TEXT DEFAULT (datetime('now')),
                is_active INTEGER DEFAULT 1,
                FOREIGN KEY (code) REFERENCES license_codes(code),
                UNIQUE(code, machine_code)
            );

            CREATE TABLE IF NOT EXISTS audit_log (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                timestamp TEXT DEFAULT (datetime('now')),
                action TEXT NOT NULL,
                code TEXT,
                machine_code TEXT,
                result TEXT,
                details TEXT
            );
        """)
        self._conn.commit()

    def add_license_code(self, code: str, password: str = "",
                         device_limit: int = 1,
                         expires_at: Optional[str] = None,
                         note: str = "") -> None:
        """Add a new license code to the database."""
        if expires_at is None:
            # Default: 1 year from now
            expires_at = (datetime.now() + timedelta(days=365)).isoformat()

        self._conn.execute(
            "INSERT OR REPLACE INTO license_codes (code, password, device_limit, expires_at, note) "
            "VALUES (?, ?, ?, ?, ?)",
            (code, password, device_limit, expires_at, note)
        )
        self._conn.commit()

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
            "SELECT password FROM license_codes WHERE code = ?", (code,)
        ).fetchone()

        if row is None:
            return False

        stored_pw = row['password']
        if not stored_pw:
            return True  # No password required
        return stored_pw == password

    def get_activation_count(self, code: str) -> int:
        """Get number of active activations for a code."""
        row = self._conn.execute(
            "SELECT COUNT(*) as cnt FROM activations WHERE code = ? AND is_active = 1",
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

        # One code is bound to exactly ONE machine. If any other machine still
        # holds this code, the user must transfer the license off it first
        # (apply_remove). A different hardware fingerprint is therefore rejected
        # until the existing seat is freed.
        if self.get_activation_count(code) >= 1:
            return False, "授权电脑数量已达上限"  # Device limit reached (1 per code)

        self._conn.execute(
            "INSERT OR REPLACE INTO activations (code, machine_code, is_active) VALUES (?, ?, 1)",
            (code, machine_code)
        )
        self._conn.commit()
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
        self._conn.commit()
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
            self._conn.commit()
        return len(bad_ids)

    def log_action(self, action: str, code: str = "", machine_code: str = "",
                   result: str = "", details: str = "") -> None:
        """Log an action to the audit log."""
        self._conn.execute(
            "INSERT INTO audit_log (action, code, machine_code, result, details) "
            "VALUES (?, ?, ?, ?, ?)",
            (action, code, machine_code, result, details)
        )
        self._conn.commit()

    def close(self):
        """Close the database connection."""
        self._conn.close()
