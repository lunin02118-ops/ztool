"""
Server configuration.
"""

import os
import json
from dataclasses import dataclass, field
from typing import Optional


@dataclass
class ServerConfig:
    """License server configuration."""

    # Network
    host: str = "0.0.0.0"
    port: int = 58000

    # Keys directory
    keys_dir: str = os.path.join(os.path.dirname(__file__), '..', 'keys')

    # Database
    db_path: str = os.path.join(os.path.dirname(__file__), '..', 'licenses.db')

    # License defaults
    default_device_limit: int = 3  # Max PCs per license code
    trial_duration_seconds: int = 1800  # 30 minutes trial

    # Client product version, used to derive the rg() transport passphrase
    # (SR.getver("今天。。。") = version + " (x64)"/" (x86)"). Must match the
    # version of the (re-keyed) client this server issues licenses for.
    client_version: str = "5.0.0.0"

    # Logging
    log_level: str = "INFO"

    @classmethod
    def from_env(cls) -> 'ServerConfig':
        """Load configuration from environment variables."""
        return cls(
            host=os.getenv('ZTOOL_HOST', '0.0.0.0'),
            port=int(os.getenv('ZTOOL_PORT', '58000')),
            keys_dir=os.getenv('ZTOOL_KEYS_DIR', cls.keys_dir),
            db_path=os.getenv('ZTOOL_DB_PATH', cls.db_path),
            default_device_limit=int(os.getenv('ZTOOL_DEVICE_LIMIT', '3')),
            log_level=os.getenv('ZTOOL_LOG_LEVEL', 'INFO'),
            client_version=os.getenv('ZTOOL_CLIENT_VERSION', cls.client_version),
        )
