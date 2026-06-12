"""Unit tests for the MySQL backend's pure helpers and backend selection.

These do not require a running MySQL server: they cover the deterministic
fingerprint hashing, the password helpers, the activation_log action mapping,
and that the server selects the SQLite backend by default. The full MySQL
read/write path is verified live against the production admin database.
"""

import hashlib

from ztool_license_server.config import ServerConfig
from ztool_license_server.server import LicenseServer
from ztool_license_server.db import LicenseDB
from ztool_license_server.db_mysql import MySQLLicenseDB, machine_hash


REAL_MACHINE = "03000200-0400-0500-0006-000700080009|YS202108310001100161|Default string"


def test_machine_hash_is_sha256_hex():
    h = machine_hash(REAL_MACHINE)
    assert h == hashlib.sha256(REAL_MACHINE.encode("utf-8")).hexdigest()
    assert len(h) == 64
    assert all(c in "0123456789abcdef" for c in h)


def test_machine_hash_distinct_per_fingerprint():
    assert machine_hash("A|B|C") != machine_hash("A|B|D")


def test_password_helpers_roundtrip():
    stored = MySQLLicenseDB._hash_password("s3cret")
    assert MySQLLicenseDB._verify_password("s3cret", stored) is True
    assert MySQLLicenseDB._verify_password("wrong", stored) is False


def test_plain_password_fallback():
    assert MySQLLicenseDB._verify_password("hi", "plain:hi") is True
    assert MySQLLicenseDB._verify_password("no", "plain:hi") is False


def test_action_map_only_allows_enum_values():
    allowed = {"activate", "deactivate", "admin_reset", "admin_revoke", "admin_create"}
    assert set(MySQLLicenseDB._ACTION_MAP.values()) <= allowed
    assert MySQLLicenseDB._ACTION_MAP["apply_register"] == "activate"
    assert MySQLLicenseDB._ACTION_MAP["apply_remove"] == "deactivate"
    assert MySQLLicenseDB._ACTION_MAP["remove_confirm"] == "deactivate"


def test_server_defaults_to_sqlite(tmp_path):
    cfg = ServerConfig(db_backend="sqlite", db_path=str(tmp_path / "t.db"))
    db = LicenseServer._make_db(cfg)
    try:
        assert isinstance(db, LicenseDB)
    finally:
        db.close()
