"""Fail-closed backend identity check for the SWTools license server."""

from __future__ import annotations

import argparse
import json
import os
from pathlib import Path


def _repo_root() -> Path:
    return Path(__file__).resolve().parents[1]


def _read(path: Path) -> str:
    return path.read_text(encoding="utf-8")


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--require-env", action="store_true")
    parser.add_argument("--json-out", default="")
    args = parser.parse_args()

    root = _repo_root()
    package_root = root / "license-server" / "swtools_license_server"
    db_py = _read(package_root / "db.py")
    config_py = _read(package_root / "config.py")

    code_uses_sqlite = "import sqlite3" in db_py and "sqlite3.connect" in db_py
    forbidden_markers = ["pymysql", "mysql.connector", "psycopg", "sqlalchemy.create_engine"]
    forbidden_found = [marker for marker in forbidden_markers if marker in db_py or marker in config_py]

    env_backend = (
        os.getenv("SWTOOLS_DB_BACKEND")
        or os.getenv("ZTOOL_DB_BACKEND")
        or ""
    ).strip().lower()
    env_db_path = (os.getenv("SWTOOLS_DB_PATH") or os.getenv("ZTOOL_DB_PATH") or "").strip()
    effective_backend = env_backend or "sqlite"

    errors: list[str] = []
    warnings: list[str] = []
    if not code_uses_sqlite:
        errors.append("license-server DB layer no longer has explicit sqlite3 usage; update backend policy")
    if forbidden_found:
        errors.append(f"unexpected DB adapter markers in repo code: {', '.join(forbidden_found)}")
    if effective_backend != "sqlite":
        errors.append(
            f"unsupported backend '{effective_backend}'; repo currently supports sqlite only"
        )
    if args.require_env and not env_backend:
        errors.append("SWTOOLS_DB_BACKEND/ZTOOL_DB_BACKEND must be set in strict acceptance mode")
    if args.require_env and not env_db_path:
        errors.append("SWTOOLS_DB_PATH/ZTOOL_DB_PATH must be set in strict acceptance mode")
    if not env_backend:
        warnings.append("backend env is not set; using repo default sqlite for CI/static check")

    result = {
        "repo_supported_backend": "sqlite",
        "effective_backend": effective_backend,
        "db_path_set": bool(env_db_path),
        "code_uses_sqlite": code_uses_sqlite,
        "unsupported_adapter_markers": forbidden_found,
        "warnings": warnings,
        "errors": errors,
    }

    if args.json_out:
        out = Path(args.json_out)
        if not out.is_absolute():
            out = root / out
        out.parent.mkdir(parents=True, exist_ok=True)
        out.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")

    for warning in warnings:
        print(f"WARNING: {warning}")
    if errors:
        for error in errors:
            print(f"ERROR: {error}")
        return 1

    print(f"license backend check: PASS (backend={effective_backend})")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
