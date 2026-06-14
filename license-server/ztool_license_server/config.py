"""Server configuration."""

import os
from dataclasses import dataclass
from typing import Optional


def _env_bool(name: str, default: bool = False) -> bool:
    """Read a boolean environment variable."""
    value = os.getenv(name)
    if value is None:
        return default
    return value.strip().lower() in {"1", "true", "yes", "y", "on"}


@dataclass
class ServerConfig:
    """License server configuration."""

    # Network
    host: str = "0.0.0.0"
    port: int = 58000

    # Keys directory
    keys_dir: str = os.path.join(os.path.dirname(__file__), '..', 'keys')
    private_key_file: Optional[str] = None
    public_key_file: Optional[str] = None

    # Database
    db_path: str = os.path.join(os.path.dirname(__file__), '..', 'licenses.db')

    # License defaults
    default_device_limit: int = 1  # One machine per license code (transfer to move it)
    trial_duration_seconds: int = 1800  # 30 minutes trial

    # Client product version, used to derive the rg() transport passphrase
    # (SR.getver("今天。。。") = version + " (x64)"/" (x86)"). Must match the
    # version of the (re-keyed) client this server issues licenses for.
    client_version: str = "1.0"

    # Logging
    log_level: str = "INFO"
    runtime_env: str = "development"
    allow_debug_logging: bool = False

    @classmethod
    def from_env(cls) -> 'ServerConfig':
        """Load configuration from environment variables."""
        return cls(
            host=os.getenv('ZTOOL_HOST', '0.0.0.0'),
            port=int(os.getenv('ZTOOL_PORT', '58000')),
            keys_dir=os.getenv('ZTOOL_KEYS_DIR', cls.keys_dir),
            private_key_file=os.getenv('ZTOOL_PRIVATE_KEY_FILE'),
            public_key_file=os.getenv('ZTOOL_PUBLIC_KEY_FILE'),
            db_path=os.getenv('ZTOOL_DB_PATH', cls.db_path),
            default_device_limit=int(os.getenv('ZTOOL_DEVICE_LIMIT', '1')),
            log_level=os.getenv('ZTOOL_LOG_LEVEL', 'INFO'),
            runtime_env=os.getenv('ZTOOL_RUNTIME_ENV', os.getenv('ZTOOL_ENV', 'development')),
            allow_debug_logging=_env_bool('ZTOOL_ALLOW_DEBUG_LOGGING'),
            client_version=os.getenv('ZTOOL_CLIENT_VERSION', cls.client_version),
        )
