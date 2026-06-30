#!/usr/bin/env python3
"""Verify build_client_installer.ps1 blocks stale package versions by default."""

from __future__ import annotations

import argparse
import json
import re
import shutil
import subprocess
import sys
import tempfile
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


def find_powershell() -> str | None:
    for candidate in ("pwsh", "powershell"):
        path = shutil.which(candidate)
        if path:
            return path
    return None


def find_repo_root(start: Path) -> Path:
    for candidate in (start.resolve().parent, *start.resolve().parents):
        if (
            (candidate / "VERSION").is_file()
            and (candidate / "scripts" / "build_client_installer.ps1").is_file()
        ):
            return candidate
    raise FileNotFoundError(f"could not find repo root above {start}")


def run_stale_package_negative(script_path: Path) -> list[str]:
    errors: list[str] = []
    shell = find_powershell()
    if not shell:
        return ["PowerShell executable not found; cannot run stale PackageRoot negative test"]

    try:
        repo_root = find_repo_root(script_path)
    except FileNotFoundError as exc:
        return [str(exc)]
    version_path = repo_root / "VERSION"
    if not version_path.is_file():
        return [f"VERSION file not found: {version_path}"]
    current_version = version_path.read_text(encoding="utf-8-sig").strip()
    stale_version = "0.0.0-stale"
    if stale_version == current_version:
        stale_version = "0.0.1-stale"

    with tempfile.TemporaryDirectory(prefix="swtools-stale-package-") as tmp:
        package_root = Path(tmp) / f"SWTools-{stale_version}"
        runtime_dir = package_root / "runtime"
        runtime_dir.mkdir(parents=True)
        manifest = {
            "version": stale_version,
            "package": f"SWTools-{stale_version}",
        }
        (package_root / "manifest.json").write_text(
            json.dumps(manifest, ensure_ascii=False, indent=2),
            encoding="utf-8",
        )

        command = [
            shell,
            "-NoProfile",
            "-ExecutionPolicy",
            "Bypass",
            "-File",
            str(script_path),
            "-PackageRoot",
            str(package_root),
            "-MakensisPath",
            shell,
        ]
        completed = subprocess.run(
            command,
            cwd=repo_root,
            text=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            timeout=30,
            check=False,
        )
        output = completed.stdout or ""
        if completed.returncode == 0:
            errors.append("stale PackageRoot negative test unexpectedly succeeded")
        if "non-current installer package blocked" not in output:
            errors.append("stale PackageRoot negative test did not report non-current package block")
        if current_version not in output:
            errors.append("stale PackageRoot negative test did not mention current VERSION")
        if str(runtime_dir / "SWTools.exe") in output:
            errors.append("stale PackageRoot test reached runtime file checks before version guard")

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
    if not errors:
        errors.extend(run_stale_package_negative(path))
    if errors:
        for error in errors:
            print(f"FAIL: {error}", file=sys.stderr)
        return 1
    print("client installer version guard: PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
