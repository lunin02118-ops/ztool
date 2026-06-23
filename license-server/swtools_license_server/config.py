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


def _env_int(name: str, default: int) -> int:
    value = os.getenv(name)
    return default if value is None else int(value)


def _env_float(name: str, default: float) -> float:
    value = os.getenv(name)
    return default if value is None else float(value)


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

    # Protocol limits
    max_body_size: int = 2 * 1024 * 1024
    max_frames_per_connection: int = 16
    read_timeout_seconds: float = 10.0
    idle_timeout_seconds: float = 30.0

    # In-process abuse/rate limiting. Perimeter firewall/fail2ban is still
    # required for public deployment; this protects CPU/DB inside the process.
    rate_limit_enabled: bool = True
    rate_limit_max_requests: int = 120
    rate_limit_window_seconds: float = 60.0
    rate_limit_max_keys: int = 10_000

    # Stateful activation/transfer
    pending_activation_ttl_seconds: int = 600
    pending_transfer_ttl_seconds: int = 600

    @classmethod
    def from_env(cls) -> 'ServerConfig':
        """Load configuration from environment variables."""
        return cls(
            host=os.getenv('SWTOOLS_HOST', '0.0.0.0'),
            port=int(os.getenv('SWTOOLS_PORT', '58000')),
            keys_dir=os.getenv('SWTOOLS_KEYS_DIR', cls.keys_dir),
            private_key_file=os.getenv('SWTOOLS_PRIVATE_KEY_FILE'),
            public_key_file=os.getenv('SWTOOLS_PUBLIC_KEY_FILE'),
            db_path=os.getenv('SWTOOLS_DB_PATH', cls.db_path),
            default_device_limit=int(os.getenv('SWTOOLS_DEVICE_LIMIT', '1')),
            log_level=os.getenv('SWTOOLS_LOG_LEVEL', 'INFO'),
            runtime_env=os.getenv('SWTOOLS_RUNTIME_ENV', os.getenv('SWTOOLS_ENV', 'development')),
            allow_debug_logging=_env_bool('SWTOOLS_ALLOW_DEBUG_LOGGING'),
            max_body_size=_env_int('SWTOOLS_MAX_BODY_SIZE', cls.max_body_size),
            max_frames_per_connection=_env_int(
                'SWTOOLS_MAX_FRAMES_PER_CONNECTION',
                cls.max_frames_per_connection,
            ),
            read_timeout_seconds=_env_float(
                'SWTOOLS_READ_TIMEOUT_SECONDS',
                cls.read_timeout_seconds,
            ),
            idle_timeout_seconds=_env_float(
                'SWTOOLS_IDLE_TIMEOUT_SECONDS',
                cls.idle_timeout_seconds,
            ),
            rate_limit_enabled=_env_bool(
                'SWTOOLS_RATE_LIMIT_ENABLED',
                cls.rate_limit_enabled,
            ),
            rate_limit_max_requests=_env_int(
                'SWTOOLS_RATE_LIMIT_MAX_REQUESTS',
                cls.rate_limit_max_requests,
            ),
            rate_limit_window_seconds=_env_float(
                'SWTOOLS_RATE_LIMIT_WINDOW_SECONDS',
                cls.rate_limit_window_seconds,
            ),
            rate_limit_max_keys=_env_int(
                'SWTOOLS_RATE_LIMIT_MAX_KEYS',
                cls.rate_limit_max_keys,
            ),
            pending_activation_ttl_seconds=_env_int(
                'SWTOOLS_PENDING_ACTIVATION_TTL_SECONDS',
                cls.pending_activation_ttl_seconds,
            ),
            pending_transfer_ttl_seconds=_env_int(
                'SWTOOLS_PENDING_TRANSFER_TTL_SECONDS',
                cls.pending_transfer_ttl_seconds,
            ),
            client_version=os.getenv('SWTOOLS_CLIENT_VERSION', cls.client_version),
        )
