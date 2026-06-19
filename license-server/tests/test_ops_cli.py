"""Tests for Phase 05 operational CLI commands."""

from types import SimpleNamespace

import pytest

from ztool_license_server.cli import (
    cmd_add_code,
    cmd_backup,
    cmd_delete_revoked_code,
    cmd_keygen,
    cmd_healthcheck,
    cmd_list_codes,
    cmd_verify_backup,
)
from ztool_license_server.crypto.keygen import generate_keypair, save_keypair
from ztool_license_server.db import LicenseDB


def _make_args(db_path, keys_dir=None, **kwargs):
    values = {
        "db": str(db_path),
        "keys_dir": str(keys_dir) if keys_dir else None,
        "private_key_file": None,
        "public_key_file": None,
    }
    values.update(kwargs)
    return SimpleNamespace(**values)


def _create_db(path):
    db = LicenseDB(str(path))
    db.add_license_code("OPS00-TEST0-CODE0-00000-00001")
    db.close()


def _create_keys(path):
    save_keypair(generate_keypair(), str(path))


def test_healthcheck_passes_with_valid_db_and_keys(tmp_path, monkeypatch, capsys):
    monkeypatch.setenv("ZTOOL_RUNTIME_ENV", "production")
    monkeypatch.setenv("ZTOOL_LOG_LEVEL", "INFO")
    db_path = tmp_path / "licenses.db"
    keys_dir = tmp_path / "keys"
    _create_db(db_path)
    _create_keys(keys_dir)

    cmd_healthcheck(_make_args(db_path, keys_dir))

    assert "HEALTHCHECK OK" in capsys.readouterr().out


def test_healthcheck_fails_without_creating_missing_db(tmp_path, capsys):
    db_path = tmp_path / "missing.db"
    keys_dir = tmp_path / "keys"
    _create_keys(keys_dir)

    with pytest.raises(SystemExit) as exc:
        cmd_healthcheck(_make_args(db_path, keys_dir))

    assert exc.value.code == 1
    assert not db_path.exists()
    assert "Database not found" in capsys.readouterr().err


def test_backup_and_verify_backup_round_trip(tmp_path, capsys):
    db_path = tmp_path / "licenses.db"
    backup_path = tmp_path / "backups" / "licenses-backup.db"
    _create_db(db_path)

    cmd_backup(_make_args(db_path, out=str(backup_path)))
    cmd_verify_backup(SimpleNamespace(path=str(backup_path)))

    out = capsys.readouterr().out
    assert "Backup written to:" in out
    assert "BACKUP OK" in out


def test_backup_requires_existing_source_db(tmp_path):
    db_path = tmp_path / "missing.db"
    backup_path = tmp_path / "backup.db"

    with pytest.raises(FileNotFoundError):
        cmd_backup(_make_args(db_path, out=str(backup_path)))

    assert not db_path.exists()
    assert not backup_path.exists()


def test_license_code_cli_uses_env_db_path(tmp_path, monkeypatch, capsys):
    env_db = tmp_path / "env" / "licenses.db"
    wrong_db = tmp_path / "cwd" / "licenses.db"
    wrong_db.parent.mkdir()
    monkeypatch.chdir(wrong_db.parent)
    monkeypatch.setenv("ZTOOL_DB_PATH", str(env_db))

    cmd_add_code(SimpleNamespace(
        db=None,
        code="ENV00-TEST0-CODE0-00000-00001",
        password="",
        limit=2,
        expires=None,
        note="env-db",
    ))
    cmd_list_codes(SimpleNamespace(db=None))

    out = capsys.readouterr().out
    assert "ENV00-TEST0-CODE0-00000-00001" in out
    assert env_db.exists()
    assert not wrong_db.exists()


def test_delete_revoked_code_cli_removes_revoked_license(tmp_path, capsys):
    db_path = tmp_path / "licenses.db"
    code = "OPS00-DEL00-REVOK-CODE0-00001"
    db = LicenseDB(str(db_path))
    db.add_license_code(code)
    db._conn.execute(
        "UPDATE license_codes SET is_active = 0 WHERE code = ?",
        (code,),
    )
    db._conn.commit()
    db.close()

    cmd_delete_revoked_code(_make_args(db_path, code=code))

    out = capsys.readouterr().out
    assert f"deleted revoked license code: {code}" in out
    db = LicenseDB(str(db_path))
    try:
        row = db._conn.execute(
            "SELECT code FROM license_codes WHERE code = ?",
            (code,),
        ).fetchone()
        assert row is None
    finally:
        db.close()


def test_delete_revoked_code_cli_rejects_active_license(tmp_path, capsys):
    db_path = tmp_path / "licenses.db"
    code = "OPS00-DEL00-ACTIV-CODE0-00001"
    db = LicenseDB(str(db_path))
    db.add_license_code(code)
    db.close()

    with pytest.raises(SystemExit) as exc:
        cmd_delete_revoked_code(_make_args(db_path, code=code))

    assert exc.value.code == 1
    assert "revoke it before deleting" in capsys.readouterr().err
    db = LicenseDB(str(db_path))
    try:
        row = db._conn.execute(
            "SELECT is_active FROM license_codes WHERE code = ?",
            (code,),
        ).fetchone()
        assert row["is_active"] == 1
    finally:
        db.close()


def test_keygen_uses_explicit_env_key_files(tmp_path, monkeypatch, capsys):
    public_key = tmp_path / "conf" / "public_key.txt"
    private_key = tmp_path / "secure" / "private_key.txt"
    monkeypatch.setenv("ZTOOL_PUBLIC_KEY_FILE", str(public_key))
    monkeypatch.setenv("ZTOOL_PRIVATE_KEY_FILE", str(private_key))

    cmd_keygen(SimpleNamespace(
        dir=None,
        keys_dir=None,
        public_key_file=None,
        private_key_file=None,
        write_debug_key_info=False,
    ))

    out = capsys.readouterr().out
    assert "Keys saved to explicit files" in out
    assert public_key.exists()
    assert private_key.exists()
    assert public_key.read_text(encoding="utf-8").strip()
    assert private_key.read_text(encoding="utf-8").strip()


def test_verify_backup_rejects_wrong_schema_version(tmp_path, capsys):
    bad_path = tmp_path / "bad.db"
    db = LicenseDB(str(bad_path))
    db._conn.execute("DELETE FROM schema_version")
    db._conn.execute(
        "INSERT INTO schema_version (version, name) VALUES (999, 'future')"
    )
    db._conn.commit()
    db.close()

    with pytest.raises(SystemExit) as exc:
        cmd_verify_backup(SimpleNamespace(path=str(bad_path)))

    assert exc.value.code == 1
    assert "schema version" in capsys.readouterr().err
