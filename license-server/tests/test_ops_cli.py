"""Tests for Phase 05 operational CLI commands."""

from types import SimpleNamespace

import pytest

from ztool_license_server.cli import cmd_backup, cmd_healthcheck, cmd_verify_backup
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
