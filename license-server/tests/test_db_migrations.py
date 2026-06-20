"""Schema migration tests for LicenseDB."""

import sqlite3

from swtools_license_server.db import LATEST_SCHEMA_VERSION, LicenseDB


def test_fresh_db_migrates_to_latest_schema(tmp_path):
    db_path = tmp_path / "fresh.db"
    db = LicenseDB(str(db_path))
    try:
        assert db.get_schema_version() == LATEST_SCHEMA_VERSION
        tables = {
            row["name"]
            for row in db._conn.execute(
                "SELECT name FROM sqlite_master WHERE type = 'table'"
            ).fetchall()
        }
        assert "schema_version" in tables
        assert "license_codes" in tables
        assert "activations" in tables
        assert "audit_log" in tables
        assert "pending_activations" in tables
        assert "pending_transfers" in tables
        transfer_columns = {
            row["name"]
            for row in db._conn.execute("PRAGMA table_info(pending_transfers)").fetchall()
        }
        assert "transfer_branches_hash" in transfer_columns
        assert "transfer_blob_hash" in transfer_columns
    finally:
        db.close()

    db2 = LicenseDB(str(db_path))
    try:
        rows = db2._conn.execute("SELECT version FROM schema_version").fetchall()
        assert len(rows) == LATEST_SCHEMA_VERSION
        assert db2.get_schema_version() == LATEST_SCHEMA_VERSION
    finally:
        db2.close()


def test_existing_plaintext_password_db_migrates_to_hash(tmp_path):
    db_path = tmp_path / "legacy.db"
    conn = sqlite3.connect(str(db_path))
    conn.executescript("""
        CREATE TABLE license_codes (
            code TEXT PRIMARY KEY,
            password TEXT,
            device_limit INTEGER DEFAULT 1,
            expires_at TEXT,
            created_at TEXT DEFAULT (datetime('now')),
            is_active INTEGER DEFAULT 1,
            note TEXT
        );
        CREATE TABLE activations (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            code TEXT NOT NULL,
            machine_code TEXT NOT NULL,
            activated_at TEXT DEFAULT (datetime('now')),
            is_active INTEGER DEFAULT 1,
            FOREIGN KEY (code) REFERENCES license_codes(code),
            UNIQUE(code, machine_code)
        );
        CREATE TABLE audit_log (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            timestamp TEXT DEFAULT (datetime('now')),
            action TEXT NOT NULL,
            code TEXT,
            machine_code TEXT,
            result TEXT,
            details TEXT
        );
    """)
    conn.execute(
        "INSERT INTO license_codes (code, password, device_limit) VALUES (?, ?, 1)",
        ("LEGAC-Y0000-PASSW-ORD00-00001", "LegacyPass123"),
    )
    conn.commit()
    conn.close()

    db = LicenseDB(str(db_path))
    try:
        row = db._conn.execute(
            "SELECT password, password_hash, password_salt, password_algo FROM license_codes WHERE code = ?",
            ("LEGAC-Y0000-PASSW-ORD00-00001",),
        ).fetchone()
        assert row["password"] == ""
        assert row["password_hash"]
        assert row["password_salt"]
        assert row["password_algo"] == "pbkdf2_sha256"
        assert db.check_password("LEGAC-Y0000-PASSW-ORD00-00001", "LegacyPass123")
    finally:
        db.close()


def test_sqlite_pragmas_are_enabled(tmp_path):
    db = LicenseDB(str(tmp_path / "pragmas.db"))
    try:
        assert db._conn.execute("PRAGMA foreign_keys").fetchone()[0] == 1
        assert db._conn.execute("PRAGMA busy_timeout").fetchone()[0] == 5000
        assert db._conn.execute("PRAGMA journal_mode").fetchone()[0].lower() == "wal"
    finally:
        db.close()
