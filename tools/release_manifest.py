#!/usr/bin/env python3
"""Generate a lightweight release manifest with hashes.

Phase 06 introduces the generator; Phase 10 will decide the final release
package layout and required artifact list.
"""

from __future__ import annotations

import argparse
import hashlib
import json
import platform
import re
import subprocess
from datetime import datetime, timezone
from pathlib import Path


DEFAULT_FILES = [
    "SWTools.exe",
    "SWTools.dll",
    "SWToolsARM.dll",
    "SWTools.settings",
    "license-server/pyproject.toml",
]


def sha256_file(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def git_output(root: Path, *args: str) -> str | None:
    try:
        result = subprocess.run(
            ["git", *args],
            cwd=root,
            check=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.DEVNULL,
            text=True,
        )
    except (OSError, subprocess.CalledProcessError):
        return None
    return result.stdout.strip()


def read_server_version(root: Path) -> str | None:
    pyproject = root / "license-server" / "pyproject.toml"
    if not pyproject.exists():
        return None
    match = re.search(r'^version\s*=\s*"([^"]+)"', pyproject.read_text(encoding="utf-8"), re.M)
    return match.group(1) if match else None


def build_manifest(root: Path, file_names: list[str]) -> dict:
    files = {}
    for name in file_names:
        path = root / name
        if not path.exists():
            files[name] = {"missing": True}
            continue
        files[name] = {
            "sha256": sha256_file(path),
            "size_bytes": path.stat().st_size,
        }

    return {
        "generated_at": datetime.now(timezone.utc).isoformat(),
        "git": {
            "commit": git_output(root, "rev-parse", "HEAD"),
            "branch": git_output(root, "rev-parse", "--abbrev-ref", "HEAD"),
            "dirty": bool(git_output(root, "status", "--porcelain")),
        },
        "files": files,
        "server": {
            "package_version": read_server_version(root),
            "python": platform.python_version(),
        },
    }


def main() -> int:
    parser = argparse.ArgumentParser(description="Generate SWTools release manifest")
    parser.add_argument("--root", default=".", help="Repository root")
    parser.add_argument("--output", default=None, help="Write JSON manifest to this path")
    parser.add_argument(
        "--file",
        action="append",
        dest="files",
        default=None,
        help="File to include, relative to root. Can be repeated.",
    )
    args = parser.parse_args()

    root = Path(args.root).resolve()
    manifest = build_manifest(root, args.files or DEFAULT_FILES)
    payload = json.dumps(manifest, indent=2, ensure_ascii=False)

    if args.output:
        output = Path(args.output)
        output.parent.mkdir(parents=True, exist_ok=True)
        output.write_text(payload + "\n", encoding="utf-8")
        print(f"Manifest written to: {output}")
    else:
        print(payload)

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
