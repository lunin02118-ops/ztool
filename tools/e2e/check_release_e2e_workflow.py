#!/usr/bin/env python3
"""Validate the self-hosted SolidWorks release E2E workflow contract."""

from __future__ import annotations

import argparse
import re
import sys
import tempfile
from pathlib import Path


REQUIRED_TOKENS = [
    "workflow_dispatch:",
    "runs-on: [self-hosted, windows, solidworks, swtools-release]",
    "scripts/e2e/Invoke-SWToolsReleaseE2E.ps1",
    "RequireVisualFullProfile",
    "release-e2e-solidworks-result.json",
    "production_go_allowed",
    "actions/upload-artifact@v4",
]


def fail(message: str) -> int:
    print(f"Release E2E workflow check failed: {message}", file=sys.stderr)
    return 1


def strip_comments(text: str) -> str:
    lines: list[str] = []
    for line in text.splitlines():
        stripped = line.strip()
        if stripped.startswith("#"):
            continue
        lines.append(line)
    return "\n".join(lines)


def validate_workflow(path: Path) -> list[str]:
    text = path.read_text(encoding="utf-8")
    no_comments = strip_comments(text)
    errors: list[str] = []
    for token in REQUIRED_TOKENS:
        if token not in no_comments:
            errors.append(f"{path}: required token missing: {token}")
    for forbidden in ("pull_request:", "push:"):
        if re.search(rf"(?m)^\s*{re.escape(forbidden)}", no_comments):
            errors.append(f"{path}: release E2E must be workflow_dispatch-only, found {forbidden}")
    if "windows-latest" in no_comments or "windows-202" in no_comments:
        errors.append(f"{path}: release E2E must not run on GitHub-hosted Windows runners")
    if re.search(r"(?im)production_go_allowed\s*[:=]\s*true\s*$", no_comments):
        errors.append(f"{path}: workflow must not assign production_go_allowed=true")
    return errors


def self_test() -> int:
    good = """
name: release-e2e-solidworks
on:
  workflow_dispatch:
jobs:
  release-e2e-solidworks:
    runs-on: [self-hosted, windows, solidworks, swtools-release]
    steps:
      - run: pwsh scripts/e2e/Invoke-SWToolsReleaseE2E.ps1 -RequireVisualFullProfile
      - run: Get-Content release-e2e-solidworks-result.json | Select-String production_go_allowed
      - uses: actions/upload-artifact@v4
"""
    bad_hosted = good.replace(
        "runs-on: [self-hosted, windows, solidworks, swtools-release]",
        "runs-on: windows-latest",
    )
    bad_trigger = good.replace("workflow_dispatch:", "pull_request:")
    bad_visual = good.replace("-RequireVisualFullProfile", "")
    with tempfile.TemporaryDirectory(prefix="swtools-release-e2e-workflow-") as temp:
        root = Path(temp)
        good_path = root / "good.yml"
        good_path.write_text(good, encoding="utf-8")
        assert not validate_workflow(good_path), validate_workflow(good_path)
        for name, content, expected in (
            ("bad_hosted.yml", bad_hosted, "self-hosted"),
            ("bad_trigger.yml", bad_trigger, "workflow_dispatch"),
            ("bad_visual.yml", bad_visual, "RequireVisualFullProfile"),
        ):
            path = root / name
            path.write_text(content, encoding="utf-8")
            errors = validate_workflow(path)
            assert errors and any(expected in error for error in errors), errors
    print("Release E2E workflow self-test PASS")
    return 0


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("workflow", nargs="?", type=Path)
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return self_test()
    if args.workflow is None:
        return fail("workflow path is required")
    if not args.workflow.is_file():
        return fail(f"workflow file not found: {args.workflow}")
    errors = validate_workflow(args.workflow)
    if errors:
        for error in errors:
            print(error, file=sys.stderr)
        return fail(f"{len(errors)} workflow contract error(s)")
    print(f"Release E2E workflow check PASS: {args.workflow}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
