"""CLI parser/dispatcher coverage for operational commands."""

from types import SimpleNamespace
import sys

import pytest

from swtools_license_server import cli


@pytest.mark.parametrize(
    ("argv", "handler_name"),
    [
        (["prog", "keygen"], "cmd_keygen"),
        (["prog", "add-code", "AAAAA-BBBBB-CCCCC-DDDDD-EEEEE"], "cmd_add_code"),
        (["prog", "list-codes"], "cmd_list_codes"),
        (["prog", "list-activations"], "cmd_list_activations"),
        (["prog", "purge-invalid"], "cmd_purge_invalid"),
        (["prog", "cleanup-pending"], "cmd_cleanup_pending"),
        (
            ["prog", "delete-revoked-code", "AAAAA-BBBBB-CCCCC-DDDDD-EEEEE"],
            "cmd_delete_revoked_code",
        ),
        (["prog", "healthcheck"], "cmd_healthcheck"),
        (["prog", "backup", "--out", "backup.db"], "cmd_backup"),
        (["prog", "verify-backup", "backup.db"], "cmd_verify_backup"),
        (
            [
                "prog",
                "offline-activate",
                "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA|DISK|BOARD",
            ],
            "cmd_offline_activate",
        ),
    ],
)
def test_main_dispatches_subcommands(monkeypatch, argv, handler_name):
    calls = []

    def fake_handler(args):
        calls.append((handler_name, args))

    monkeypatch.setattr(sys, "argv", argv)
    monkeypatch.setattr(cli, handler_name, fake_handler)

    cli.main()

    assert calls
    assert calls[0][0] == handler_name


def test_main_without_command_prints_help(monkeypatch, capsys):
    monkeypatch.setattr(sys, "argv", ["prog"])

    cli.main()

    assert "SWTools License Server CLI" in capsys.readouterr().out


def test_config_from_args_applies_explicit_key_files(monkeypatch, tmp_path):
    private_key = tmp_path / "private.key"
    public_key = tmp_path / "public.key"

    config = cli._config_from_args(
        SimpleNamespace(
            db=str(tmp_path / "licenses.db"),
            keys_dir=str(tmp_path / "keys"),
            private_key_file=str(private_key),
            public_key_file=str(public_key),
        )
    )

    assert config.db_path.endswith("licenses.db")
    assert config.keys_dir.endswith("keys")
    assert config.private_key_file == str(private_key)
    assert config.public_key_file == str(public_key)
