"""Key loading abstraction for the license server."""

from __future__ import annotations

import os
import stat
from dataclasses import dataclass
from typing import Optional

from .logging_utils import normalize_runtime_env, redact_path


@dataclass(frozen=True)
class KeyProvider:
    """Load the ZTool RSA ComponentKey pair from explicit files or legacy dir."""

    keys_dir: str
    private_key_file: Optional[str] = None
    public_key_file: Optional[str] = None
    runtime_env: str = "development"

    @classmethod
    def from_config(cls, config) -> "KeyProvider":
        return cls(
            keys_dir=config.keys_dir,
            private_key_file=config.private_key_file,
            public_key_file=config.public_key_file,
            runtime_env=config.runtime_env,
        )

    @property
    def private_key_path(self) -> str:
        return self.private_key_file or os.path.join(self.keys_dir, "private_key.txt")

    @property
    def public_key_path(self) -> str:
        return self.public_key_file or os.path.join(self.keys_dir, "public_key.txt")

    def load_private_key(self) -> str:
        """Load the private key and validate Unix permissions in production."""
        path = self.private_key_path
        self._validate_private_key_permissions(path)
        return self._read_required(path, "Private key")

    def load_public_key(self) -> str:
        """Load the public key."""
        return self._read_required(self.public_key_path, "Public key")

    def _read_required(self, path: str, label: str) -> str:
        if not os.path.exists(path):
            raise FileNotFoundError(f"{label} not found: {redact_path(path)}")
        with open(path, "r", encoding="utf-8") as f:
            value = f.read().strip()
        if not value:
            raise ValueError(f"{label} is empty: {redact_path(path)}")
        return value

    def _validate_private_key_permissions(self, path: str) -> None:
        if normalize_runtime_env(self.runtime_env) != "production":
            return
        if os.name == "nt" or not os.path.exists(path):
            return
        mode = stat.S_IMODE(os.stat(path).st_mode)
        if mode & (stat.S_IRWXG | stat.S_IRWXO):
            raise PermissionError(
                f"Private key permissions are too broad in production: {redact_path(path)} "
                "(expected 0600 or stricter)"
            )
