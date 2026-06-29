#!/usr/bin/env python3
"""Verify build_client_installer.ps1 blocks stale package versions by default."""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path


REQUIRED_TOKENS = (
    "[switch]$AllowNonCurrentVersion",
    "function Get-CurrentRepoVersion",
    "function Assert-CurrentPackageVersion",
    "manifest.version",
    "ProductVersion",
    "PackageRoot leaf",
    "PackageName",
    "non-current installer package blocked",
)


def fail(message: str) -> int:
    print(f"FAIL: {message}", file=sys.stderr)
    return 1


def check_text(text: str) -> list[str]:
    errors: list[str] = []
    for token in REQUIRED_TOKENS:
        if token not in text:
            errors.append(f"missing required token: {token}")

    if not re.search(r"if\s*\(\s*-not\s+\$AllowNonCurrentVersion\s*\)\s*\{", text):
        errors.append("missing default guard branch for -not $AllowNonCurrentVersion")
    if "Assert-CurrentPackageVersion" not in text:
        errors.append("missing Assert-CurrentPackageVersion call")
    if "Pass -AllowNonCurrentVersion only for explicit historical rebuilds" not in text:
        errors.append("missing explicit operator guidance for historical rebuilds")
    if "Write-Warning" not in text or "AllowNonCurrentVersion" not in text:
        errors.append("missing warning path for explicit non-current rebuilds")

    return errors


def run_self_test() -> int:
    good = """
param([switch]$AllowNonCurrentVersion)
function Get-CurrentRepoVersion {}
function Assert-CurrentPackageVersion {
    $manifest.version
    $ProductVersion
    $x = "PackageRoot leaf"
    $y = "PackageName"
    throw "non-current installer package blocked. Pass -AllowNonCurrentVersion only for explicit historical rebuilds."
}
if (-not $AllowNonCurrentVersion) {
    Assert-CurrentPackageVersion -CurrentVersion $v
} else {
    Write-Warning "AllowNonCurrentVersion"
}
"""
    bad = good.replace("if (-not $AllowNonCurrentVersion)", "if ($false)")
    if check_text(good):
        return fail("self-test good fixture failed")
    if not check_text(bad):
        return fail("self-test bad fixture unexpectedly passed")
    print("self-test: PASS")
    return 0


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument(
        "script",
        nargs="?",
        default="scripts/build_client_installer.ps1",
        help="Path to build_client_installer.ps1",
    )
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args(argv)

    if args.self_test:
        return run_self_test()

    path = Path(args.script)
    if not path.is_file():
        return fail(f"script not found: {path}")
    text = path.read_text(encoding="utf-8-sig")
    errors = check_text(text)
    if errors:
        for error in errors:
            print(f"FAIL: {error}", file=sys.stderr)
        return 1
    print("client installer version guard: PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
