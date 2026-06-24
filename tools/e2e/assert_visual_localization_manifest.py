#!/usr/bin/env python3
"""Validate SWTools visual-localization capture manifest."""

from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path


VALID_STATUSES = {"PASS", "PASS_WITH_WARN", "FAIL"}


def fail(message: str) -> int:
    print(f"Visual localization assertion failed: {message}", file=sys.stderr)
    return 1


def assert_screenshot(surface_id: str, surface: dict) -> str | None:
    screenshot = surface.get("screenshot")
    if not isinstance(screenshot, dict):
        return f"{surface_id}: screenshot evidence missing"
    if not screenshot.get("path") or not screenshot.get("sha256"):
        return f"{surface_id}: screenshot path/SHA missing"
    width = screenshot.get("width")
    height = screenshot.get("height")
    if not isinstance(width, int) or width <= 0:
        return f"{surface_id}: screenshot width invalid: {width!r}"
    if not isinstance(height, int) or height <= 0:
        return f"{surface_id}: screenshot height invalid: {height!r}"
    return None


def load_surface_ids(path: Path) -> list[str]:
    data = json.loads(path.read_text(encoding="utf-8"))
    ids: list[str] = []
    for item in data.get("surfaces", []):
        surface_id = str(item.get("id", "")).strip()
        if surface_id:
            ids.append(surface_id)
    return ids


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("manifest_json", type=Path)
    parser.add_argument("--allow-warn", action="store_true")
    parser.add_argument("--allow-production-go", action="store_true")
    parser.add_argument("--require-surface", action="append", default=[])
    parser.add_argument(
        "--require-surface-file",
        type=Path,
        help="Require every surface id from a JSON surface profile to be present in the manifest.",
    )
    parser.add_argument(
        "--require-profile-surfaces-captured",
        action="store_true",
        help="With --require-surface-file, require every profile surface to be CAPTURED.",
    )
    parser.add_argument(
        "--require-runtime-match",
        action="store_true",
        help="Fail if captured SWTools surfaces do not prove expected runtime path match.",
    )
    parser.add_argument(
        "--fail-on-recorded-han",
        action="store_true",
        help="Also fail on record_only Han surfaces such as the host SolidWorks frame.",
    )
    args = parser.parse_args()

    if not args.manifest_json.is_file():
        return fail(f"missing manifest JSON: {args.manifest_json}")

    data = json.loads(args.manifest_json.read_text(encoding="utf-8"))
    status = data.get("status")
    if status not in VALID_STATUSES:
        return fail(f"invalid status: {status!r}")
    if status == "FAIL":
        return fail("manifest status is FAIL")
    if status == "PASS_WITH_WARN" and not args.allow_warn:
        return fail("manifest status is PASS_WITH_WARN but --allow-warn was not passed")
    if data.get("production_go_allowed") and not args.allow_production_go:
        return fail("production_go_allowed=true is not accepted by this assertion")

    surfaces = data.get("surfaces")
    if not isinstance(surfaces, list):
        return fail("surfaces must be a list")
    by_id = {surface.get("id"): surface for surface in surfaces if isinstance(surface, dict)}
    if len(by_id) != len(surfaces):
        return fail("surface ids must be unique and every surface must have an id")

    required_surface_ids = list(args.require_surface)
    if args.require_surface_file:
        profile_ids = load_surface_ids(args.require_surface_file)
        if not profile_ids:
            return fail(f"surface profile has no surface ids: {args.require_surface_file}")
        missing_profile = sorted(set(profile_ids) - set(by_id))
        if missing_profile:
            return fail(f"profile surface ids missing from manifest: {missing_profile!r}")
        required_surface_ids.extend(profile_ids if args.require_profile_surfaces_captured else [])

    for surface in surfaces:
        surface_id = surface.get("id")
        if surface.get("status") != "CAPTURED":
            continue
        han = surface.get("visible_han_texts") or []
        if han and (args.fail_on_recorded_han or surface.get("han_policy", "fail") != "record_only"):
            return fail(f"{surface_id}: visible Han text detected: {han!r}")
        forbidden = surface.get("forbidden_texts") or []
        if forbidden:
            return fail(f"{surface_id}: forbidden visible text detected: {forbidden!r}")
        error = assert_screenshot(str(surface_id), surface)
        if error:
            return fail(error)
        if args.require_runtime_match and surface.get("process") == "SWTools.exe":
            if surface.get("runtime_path_match") is not True:
                return fail(f"{surface_id}: SWTools runtime path was not proven to match expected runtime")

    for surface_id in required_surface_ids:
        surface = by_id.get(surface_id)
        if surface is None:
            return fail(f"required surface missing from manifest: {surface_id}")
        if surface.get("status") != "CAPTURED":
            return fail(f"required surface was not captured: {surface_id} ({surface.get('status')!r})")
        han = surface.get("visible_han_texts") or []
        if han and (args.fail_on_recorded_han or surface.get("han_policy", "fail") != "record_only"):
            return fail(f"required surface has visible Han text: {surface_id}: {han!r}")
        forbidden = surface.get("forbidden_texts") or []
        if forbidden:
            return fail(f"required surface has forbidden visible text: {surface_id}: {forbidden!r}")
        error = assert_screenshot(surface_id, surface)
        if error:
            return fail(error)

    print(
        "Visual localization assertion PASS: "
        f"status={status}, surfaces={len(surfaces)}, required={len(args.require_surface)}"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
