#!/usr/bin/env python3
"""Self-tests for visual-localization manifest assertions."""

from __future__ import annotations

import subprocess
import sys
from pathlib import Path


def expect_fail(command: list[str], expected_terms: list[str]) -> str | None:
    completed = subprocess.run(command, text=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
    if completed.returncode == 0:
        return f"Expected failure but command passed: {' '.join(command)}"
    combined = f"{completed.stdout}\n{completed.stderr}".lower()
    for term in expected_terms:
        if term.lower() not in combined:
            return f"Expected term {term!r} in assertion output, got:\n{combined}"
    return None


def main() -> int:
    repo_root = Path(__file__).resolve().parents[2]
    assert_script = repo_root / "tools" / "e2e" / "assert_visual_localization_manifest.py"
    fixtures = repo_root / "tools" / "e2e" / "fixtures"

    checks = [
        (
            [
                sys.executable,
                str(assert_script),
                str(fixtures / "visual-localization-han-manifest.json"),
                "--allow-warn",
                "--require-surface",
                "L-01",
            ],
            ["han"],
        ),
        (
            [
                sys.executable,
                str(assert_script),
                str(fixtures / "visual-localization-missing-required-manifest.json"),
                "--allow-warn",
                "--require-surface",
                "L-01",
            ],
            ["not captured", "L-01"],
        ),
        (
            [
                sys.executable,
                str(assert_script),
                str(fixtures / "visual-localization-runtime-mismatch-manifest.json"),
                "--allow-warn",
                "--require-runtime-match",
            ],
            ["runtime"],
        ),
        (
            [
                sys.executable,
                str(assert_script),
                str(fixtures / "visual-localization-han-manifest.json"),
                "--allow-warn",
                "--require-surface-file",
                str(fixtures / "visual-localization-profile-two-surfaces.json"),
                "--require-profile-surfaces-captured",
            ],
            ["profile", "L-02"],
        ),
    ]

    for command, expected_terms in checks:
        error = expect_fail(command, expected_terms)
        if error:
            print(error, file=sys.stderr)
            return 1
    print("Visual localization assertion self-test PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
