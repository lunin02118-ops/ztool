"""Tests for Phase 01 secrets and logging hardening."""

import logging
import os

import pytest

from swtools_license_server.config import ServerConfig
from swtools_license_server.crypto.aes_security_center import encrypt_message_body
from swtools_license_server.crypto.keygen import generate_keypair, load_keypair, save_keypair
from swtools_license_server.key_provider import KeyProvider
from swtools_license_server.logging_utils import assert_safe_log_config
from swtools_license_server.server import LicenseServer


def test_config_reads_explicit_key_files_from_env(monkeypatch, tmp_path):
    private_key = tmp_path / "server-private.txt"
    public_key = tmp_path / "server-public.txt"

    monkeypatch.setenv("SWTOOLS_PRIVATE_KEY_FILE", str(private_key))
    monkeypatch.setenv("SWTOOLS_PUBLIC_KEY_FILE", str(public_key))
    monkeypatch.setenv("SWTOOLS_RUNTIME_ENV", "production")
    monkeypatch.setenv("SWTOOLS_LOG_LEVEL", "INFO")

    config = ServerConfig.from_env()

    assert config.private_key_file == str(private_key)
    assert config.public_key_file == str(public_key)
    assert config.runtime_env == "production"
    assert config.log_level == "INFO"


def test_key_provider_loads_explicit_key_files(tmp_path):
    kp = generate_keypair()
    private_key = tmp_path / "prod-private.key"
    public_key = tmp_path / "prod-public.key"
    private_key.write_text(kp["private_component_key"], encoding="utf-8")
    public_key.write_text(kp["public_component_key"], encoding="utf-8")

    provider = KeyProvider(
        keys_dir=str(tmp_path / "unused"),
        private_key_file=str(private_key),
        public_key_file=str(public_key),
    )

    assert provider.load_private_key() == kp["private_component_key"]
    assert provider.load_public_key() == kp["public_component_key"]


def test_key_provider_loads_legacy_keys_dir(tmp_path):
    kp = generate_keypair()
    keys_dir = tmp_path / "keys"
    save_keypair(kp, str(keys_dir))

    provider = KeyProvider(keys_dir=str(keys_dir))

    assert provider.load_private_key() == kp["private_component_key"]
    assert provider.load_public_key() == kp["public_component_key"]


def test_key_provider_rejects_broad_unix_private_key_permissions_in_production(tmp_path):
    if os.name == "nt":
        pytest.skip("Unix mode check is not meaningful on Windows")

    kp = generate_keypair()
    keys_dir = tmp_path / "keys"
    save_keypair(kp, str(keys_dir))
    private_key = keys_dir / "private_key.txt"
    private_key.chmod(0o644)

    provider = KeyProvider(keys_dir=str(keys_dir), runtime_env="production")

    with pytest.raises(PermissionError):
        provider.load_private_key()


def test_keygen_default_does_not_write_debug_key_info(tmp_path):
    kp = generate_keypair()
    keys_dir = tmp_path / "keys"

    save_keypair(kp, str(keys_dir))

    assert (keys_dir / "public_key.txt").exists()
    assert (keys_dir / "private_key.txt").exists()
    assert not (keys_dir / "keypair_info.json").exists()
    loaded = load_keypair(str(keys_dir))
    assert loaded["public_component_key"] == kp["public_component_key"]
    assert loaded["private_component_key"] == kp["private_component_key"]


def test_keygen_debug_key_info_is_opt_in(tmp_path):
    kp = generate_keypair()
    keys_dir = tmp_path / "keys"

    save_keypair(kp, str(keys_dir), write_debug_info=True)

    assert (keys_dir / "keypair_info.json").exists()
    loaded = load_keypair(str(keys_dir))
    assert loaded["d_hex"] == kp["d_hex"]


def test_production_debug_logging_is_rejected():
    with pytest.raises(ValueError, match="DEBUG logging is disabled"):
        assert_safe_log_config("DEBUG", "production", allow_debug_logging=False)


def test_production_debug_logging_requires_explicit_override():
    assert_safe_log_config("DEBUG", "production", allow_debug_logging=True)


@pytest.mark.asyncio
async def test_process_message_debug_log_does_not_include_plaintext(caplog, tmp_path):
    kp = generate_keypair()
    keys_dir = tmp_path / "keys"
    save_keypair(kp, str(keys_dir))
    config = ServerConfig(
        keys_dir=str(keys_dir),
        db_path=str(tmp_path / "licenses.db"),
        log_level="DEBUG",
        runtime_env="development",
    )
    server = LicenseServer(config)

    plaintext = "SECRET-CODE-12345\nSECRET-MACHINE-FINGERPRINT"
    sendtype = 999
    body = encrypt_message_body(plaintext, sendtype).encode("utf-8")

    with caplog.at_level(logging.DEBUG, logger="swtools_license_server.server"):
        await server._process_message(sendtype, body)

    assert "SECRET-CODE-12345" not in caplog.text
    assert "SECRET-MACHINE-FINGERPRINT" not in caplog.text
    assert "payload_sha256=" in caplog.text
    assert "payload_bytes=" in caplog.text
