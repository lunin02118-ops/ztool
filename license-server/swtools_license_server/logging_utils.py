"""Production-safe logging helpers for the license server."""

from __future__ import annotations

import hashlib
import logging
import os
from typing import Union


LOG_FORMAT = "%(asctime)s [%(levelname)s] %(name)s: %(message)s"


def parse_bool(value: Union[str, bool, None], default: bool = False) -> bool:
    """Parse a human-friendly boolean value."""
    if value is None:
        return default
    if isinstance(value, bool):
        return value
    return value.strip().lower() in {"1", "true", "yes", "y", "on"}


def normalize_runtime_env(runtime_env: str | None) -> str:
    """Normalize runtime env names used by the server."""
    value = (runtime_env or "development").strip().lower()
    if value in {"prod", "production"}:
        return "production"
    if value in {"test", "testing"}:
        return "test"
    return value or "development"


def normalize_log_level(log_level: str | int) -> int:
    """Return a stdlib logging level from a string/int value."""
    if isinstance(log_level, int):
        return log_level
    name = str(log_level).strip().upper()
    level = getattr(logging, name, None)
    if not isinstance(level, int):
        raise ValueError(f"Invalid log level: {log_level!r}")
    return level


def assert_safe_log_config(
    log_level: str | int,
    runtime_env: str | None,
    allow_debug_logging: bool = False,
) -> None:
    """Fail closed when production would emit DEBUG logs."""
    level = normalize_log_level(log_level)
    env = normalize_runtime_env(runtime_env)
    if env == "production" and level <= logging.DEBUG and not allow_debug_logging:
        raise ValueError(
            "DEBUG logging is disabled in production. "
            "Set SWTOOLS_ALLOW_DEBUG_LOGGING=1 only for a controlled emergency window."
        )


def configure_logging(
    log_level: str | int,
    runtime_env: str | None = "development",
    allow_debug_logging: bool = False,
) -> int:
    """Configure stdlib logging after validating production safety."""
    assert_safe_log_config(log_level, runtime_env, allow_debug_logging)
    level = normalize_log_level(log_level)
    logging.basicConfig(level=level, format=LOG_FORMAT)
    return level


def payload_summary(plaintext: str) -> tuple[int, str]:
    """Return non-reversible metadata for a decrypted protocol payload."""
    payload = plaintext.encode("utf-8", errors="replace")
    return len(payload), hashlib.sha256(payload).hexdigest()[:16]


def redact_secret(value: str | None, visible: int = 4) -> str:
    """Redact a secret-like value for diagnostic text."""
    if not value:
        return "<empty>"
    text = str(value)
    if len(text) <= visible:
        return "*" * len(text)
    return f"{text[:visible]}...<redacted:{len(text)}>"


def redact_path(path: str | None) -> str:
    """Keep only the filename in logs/errors that reference secret material."""
    if not path:
        return "<unset>"
    return os.path.join("...", os.path.basename(path))
