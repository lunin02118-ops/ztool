"""Tests for production-safe logging helper branches."""

import logging

import pytest

from swtools_license_server.logging_utils import (
    assert_safe_log_config,
    configure_logging,
    normalize_log_level,
    normalize_runtime_env,
    parse_bool,
    payload_summary,
    redact_path,
    redact_secret,
)


def test_parse_bool_variants():
    assert parse_bool(None, default=True) is True
    assert parse_bool(True) is True
    assert parse_bool(False) is False
    assert parse_bool("yes") is True
    assert parse_bool("off") is False


def test_runtime_env_and_log_level_normalization():
    assert normalize_runtime_env(None) == "development"
    assert normalize_runtime_env("prod") == "production"
    assert normalize_runtime_env("TESTING") == "test"
    assert normalize_log_level("INFO") == logging.INFO
    assert normalize_log_level(logging.WARNING) == logging.WARNING
    with pytest.raises(ValueError, match="Invalid log level"):
        normalize_log_level("LOUD")


def test_production_debug_fails_closed_unless_explicitly_allowed():
    with pytest.raises(ValueError, match="DEBUG logging is disabled"):
        assert_safe_log_config("DEBUG", "production")

    assert_safe_log_config("DEBUG", "production", allow_debug_logging=True)
    assert configure_logging("INFO", "production") == logging.INFO


def test_redaction_and_payload_summary_helpers():
    size, digest = payload_summary("payload")
    assert size == len("payload")
    assert len(digest) == 16
    assert redact_secret("") == "<empty>"
    assert redact_secret("abc") == "***"
    assert redact_secret("abcdef", visible=2) == "ab...<redacted:6>"
    assert redact_path("") == "<unset>"
    assert redact_path(r"C:\secret\private_key.txt").endswith("private_key.txt")
