#!/usr/bin/env python3
"""Minimal repository secret scan for CI.

This is intentionally conservative and dependency-free. It catches committed
private key files, debug key metadata and common PEM/OpenSSH private key blocks.
It is not a replacement for a full scanner, but it gives the repository an
always-on baseline gate without sending code to a third-party service.
"""

from __future__ import annotations

import os
import re
import subprocess
import sys
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[1]
SENSITIVE_BASENAMES = {
    ".env",
    "private_key.txt",
    "keypair_info.json",
}
SENSITIVE_SUFFIXES = {
    ".pem",
    ".key",
    ".p12",
    ".pfx",
}
EXEMPT_BASENAMES = {
    ".env.example",
    "swtools-license-server.env.example",
}
BINARY_SUFFIXES = {
    ".bmp",
    ".chm",
    ".dll",
    ".dmp",
    ".exe",
    ".ico",
    ".jpg",
    ".jpeg",
    ".pdf",
    ".png",
    ".sldasm",
    ".slddrw",
    ".sldprt",
    ".xlsx",
    ".zip",
}
CONTENT_PATTERNS = [
    re.compile(r"-----BEGIN [A-Z0-9 ]*PRIVATE KEY-----"),
]


def tracked_files() -> list[Path]:
    result = subprocess.run(
        ["git", "ls-files", "-z"],
        cwd=REPO_ROOT,
        check=True,
        stdout=subprocess.PIPE,
    )
    names = result.stdout.decode("utf-8").split("\0")
    return [REPO_ROOT / name for name in names if name]


def is_binary_path(path: Path) -> bool:
    suffixes = {suffix.lower() for suffix in path.suffixes}
    return bool(suffixes & BINARY_SUFFIXES)


def scan_path(path: Path) -> list[str]:
    rel = path.relative_to(REPO_ROOT).as_posix()
    findings: list[str] = []
    name = path.name

    if name not in EXEMPT_BASENAMES:
        if name in SENSITIVE_BASENAMES or path.suffix.lower() in SENSITIVE_SUFFIXES:
            findings.append(f"{rel}: sensitive filename is tracked")

    if is_binary_path(path):
        return findings

    try:
        raw = path.read_bytes()
    except OSError as exc:
        findings.append(f"{rel}: cannot read file: {exc}")
        return findings

    if b"\x00" in raw[:4096]:
        return findings

    text = raw.decode("utf-8", errors="ignore")
    for pattern in CONTENT_PATTERNS:
        if pattern.search(text):
            findings.append(f"{rel}: content matches {pattern.pattern}")

    return findings


def main() -> int:
    findings: list[str] = []
    for path in tracked_files():
        if not path.is_file():
            continue
        findings.extend(scan_path(path))

    if findings:
        print("Secret scan failed:")
        for finding in findings:
            print(f"  - {finding}")
        return 1

    print("Secret scan OK")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
