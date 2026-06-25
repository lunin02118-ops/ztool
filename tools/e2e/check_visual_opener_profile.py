#!/usr/bin/env python3
"""Validate SWTools visual-localization opener profile.

The visual capture gate must not depend on ad-hoc screen coordinates. This
validator checks that each visual surface has an object-driven opener contract
and that no action/locator stores screen coordinates.
"""

from __future__ import annotations

import argparse
import json
import sys
import tempfile
from pathlib import Path
from typing import Any


SCHEMA = "swtools.visual-opener-profile.v1"
ALLOWED_ACTION_TYPES = {
    "e2e_stage",
    "solidworks_com",
    "uia_invoke",
    "win32_invoke",
    "ribbon_command",
    "menu_item",
    "context_menu",
    "help_button",
    "installer_launch",
    "wait_window",
}
COORDINATE_KEYS = {
    "x",
    "y",
    "xy",
    "point",
    "points",
    "left_click",
    "right_click",
    "screen_x",
    "screen_y",
    "screen_point",
    "coordinates",
    "coord",
    "coords",
    "mouse_x",
    "mouse_y",
}


def fail(message: str) -> int:
    print(f"Visual opener profile check failed: {message}", file=sys.stderr)
    return 1


def as_non_empty_string(value: Any) -> bool:
    return isinstance(value, str) and bool(value.strip())


def as_string_list(value: Any) -> bool:
    return isinstance(value, list) and all(isinstance(item, str) and item.strip() for item in value)


def load_surface_ids(path: Path) -> list[str]:
    data = json.loads(path.read_text(encoding="utf-8"))
    ids: list[str] = []
    for item in data.get("surfaces", []):
        surface_id = str(item.get("id", "")).strip()
        if surface_id:
            ids.append(surface_id)
    return ids


def find_coordinate_keys(value: Any, prefix: str = "$") -> list[str]:
    findings: list[str] = []
    if isinstance(value, dict):
        for key, child in value.items():
            child_prefix = f"{prefix}.{key}"
            if str(key).lower() in COORDINATE_KEYS:
                findings.append(child_prefix)
            findings.extend(find_coordinate_keys(child, child_prefix))
    elif isinstance(value, list):
        for index, child in enumerate(value):
            findings.extend(find_coordinate_keys(child, f"{prefix}[{index}]"))
    return findings


def validate_action(action: Any, prefix: str) -> list[str]:
    errors: list[str] = []
    if not isinstance(action, dict):
        return [f"{prefix}: action must be an object"]
    action_type = action.get("type")
    if action_type not in ALLOWED_ACTION_TYPES:
        errors.append(f"{prefix}: type must be one of {sorted(ALLOWED_ACTION_TYPES)}")
    if not as_non_empty_string(action.get("description")):
        errors.append(f"{prefix}: description must be a non-empty string")
    if action_type != "e2e_stage" and not isinstance(action.get("locator"), dict):
        errors.append(f"{prefix}: object-driven action must define locator object")
    if action_type == "e2e_stage" and not as_non_empty_string(action.get("stage")):
        errors.append(f"{prefix}: e2e_stage action must define stage")
    return errors


def validate_profile(path: Path, surface_file: Path | None = None) -> list[str]:
    errors: list[str] = []
    try:
        data = json.loads(path.read_text(encoding="utf-8"))
    except Exception as exc:
        return [f"{path}: cannot parse JSON: {exc}"]

    if data.get("schema") != SCHEMA:
        errors.append(f"{path}: schema must be {SCHEMA}")
    if data.get("coordinate_policy") != "forbid_screen_coordinates":
        errors.append(f"{path}: coordinate_policy must be forbid_screen_coordinates")
    if not as_non_empty_string(data.get("version")):
        errors.append(f"{path}: version must be a non-empty string")

    coordinate_findings = find_coordinate_keys(data)
    if coordinate_findings:
        errors.append(f"{path}: coordinate-like keys are forbidden: {coordinate_findings!r}")

    surfaces = data.get("surfaces")
    if not isinstance(surfaces, list) or not surfaces:
        return [*errors, f"{path}: surfaces must be a non-empty list"]

    seen: set[str] = set()
    for index, surface in enumerate(surfaces):
        prefix = f"{path}: surfaces[{index}]"
        if not isinstance(surface, dict):
            errors.append(f"{prefix}: item must be an object")
            continue
        surface_id = surface.get("id")
        if not as_non_empty_string(surface_id):
            errors.append(f"{prefix}: id must be a non-empty string")
        elif surface_id in seen:
            errors.append(f"{prefix}: duplicate id {surface_id!r}")
        else:
            seen.add(str(surface_id))
        if surface.get("object_driven") is not True:
            errors.append(f"{prefix}: object_driven must be true")
        if not as_non_empty_string(surface.get("capture_after")):
            errors.append(f"{prefix}: capture_after must be a non-empty string")
        if "preconditions" in surface and not as_string_list(surface["preconditions"]):
            errors.append(f"{prefix}: preconditions must be a list of non-empty strings")
        actions = surface.get("actions")
        if not isinstance(actions, list) or not actions:
            errors.append(f"{prefix}: actions must be a non-empty list")
        else:
            for action_index, action in enumerate(actions):
                errors.extend(validate_action(action, f"{prefix}.actions[{action_index}]"))

    if surface_file is not None:
        expected = set(load_surface_ids(surface_file))
        actual = seen
        missing = sorted(expected - actual)
        extra = sorted(actual - expected)
        if missing:
            errors.append(f"{path}: opener profile missing surface ids from {surface_file}: {missing!r}")
        if extra:
            errors.append(f"{path}: opener profile has unknown surface ids: {extra!r}")

    return errors


def self_test() -> int:
    def write_profile(path: Path, data: dict[str, Any]) -> None:
        path.write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")

    base = {
        "schema": SCHEMA,
        "version": "test",
        "coordinate_policy": "forbid_screen_coordinates",
        "surfaces": [
            {
                "id": "L-01",
                "object_driven": True,
                "preconditions": ["S7 PASS"],
                "capture_after": "SWTools main grid is populated",
                "actions": [
                    {
                        "type": "e2e_stage",
                        "stage": "07-s7-connect",
                        "description": "Run S7 connect stage.",
                    }
                ],
            }
        ],
    }
    with tempfile.TemporaryDirectory(prefix="swtools-visual-openers-") as temp:
        root = Path(temp)
        good = root / "good.json"
        write_profile(good, base)
        assert not validate_profile(good), validate_profile(good)

        coordinate = json.loads(json.dumps(base))
        coordinate["surfaces"][0]["actions"][0]["x"] = 10
        coordinate_path = root / "coordinate.json"
        write_profile(coordinate_path, coordinate)
        coordinate_errors = validate_profile(coordinate_path)
        assert coordinate_errors and any("coordinate" in item for item in coordinate_errors), coordinate_errors

        no_actions = json.loads(json.dumps(base))
        no_actions["surfaces"][0]["actions"] = []
        no_actions_path = root / "no-actions.json"
        write_profile(no_actions_path, no_actions)
        action_errors = validate_profile(no_actions_path)
        assert action_errors and any("actions" in item for item in action_errors), action_errors

        weak = json.loads(json.dumps(base))
        weak["surfaces"][0]["object_driven"] = False
        weak_path = root / "weak.json"
        write_profile(weak_path, weak)
        weak_errors = validate_profile(weak_path)
        assert weak_errors and any("object_driven" in item for item in weak_errors), weak_errors
    print("Visual opener profile self-test PASS")
    return 0


def main() -> int:
    if hasattr(sys.stdout, "reconfigure"):
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    if hasattr(sys.stderr, "reconfigure"):
        sys.stderr.reconfigure(encoding="utf-8", errors="replace")

    parser = argparse.ArgumentParser()
    parser.add_argument("profile", nargs="?", type=Path)
    parser.add_argument("--surface-file", type=Path)
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return self_test()
    if args.profile is None:
        return fail("no opener profile passed")
    if not args.profile.is_file():
        return fail(f"profile file not found: {args.profile}")

    errors = validate_profile(args.profile, args.surface_file)
    if errors:
        for error in errors:
            print(error, file=sys.stderr)
        return fail(f"{len(errors)} opener profile error(s)")
    print(f"Visual opener profile check PASS: {args.profile}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
