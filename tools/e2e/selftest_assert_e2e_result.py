#!/usr/bin/env python3
"""Self-tests for E2E result assertions that do not require SolidWorks."""

from __future__ import annotations

import subprocess
import sys
from pathlib import Path


def main() -> int:
    repo_root = Path(__file__).resolve().parents[2]
    assert_script = repo_root / "tools" / "e2e" / "assert_e2e_result.py"
    mismatch_fixture = repo_root / "tools" / "e2e" / "fixtures" / "branding-icon-mismatch-e2e-result.json"
    completed = subprocess.run(
        [
            sys.executable,
            str(assert_script),
            str(mismatch_fixture),
            "--require-branding-version",
        ],
        text=True,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
    )
    if completed.returncode == 0:
        print("Expected branding icon mismatch fixture to fail, but assertion passed", file=sys.stderr)
        print(completed.stdout, file=sys.stderr)
        return 1
    combined = f"{completed.stdout}\n{completed.stderr}".lower()
    if "icon" not in combined or "mismatch" not in combined:
        print("Mismatch fixture failed for the wrong reason", file=sys.stderr)
        print(completed.stdout, file=sys.stderr)
        print(completed.stderr, file=sys.stderr)
        return 1
    print("E2E assertion self-test PASS: branding icon mismatch is rejected")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
