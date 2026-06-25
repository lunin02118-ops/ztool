#!/usr/bin/env python3
"""Validate visual-localization surface profile JSON files."""

from __future__ import annotations

import argparse
import json
import sys
import tempfile
from pathlib import Path
from typing import Any


VALID_HAN_POLICIES = {"fail", "record_only"}
HELP_ENTRY_SCHEMA = "swtools.help-entry-visual-surfaces.v1"


def fail(message: str) -> int:
    print(f"Visual surface profile check failed: {message}", file=sys.stderr)
    return 1


def as_non_empty_string(value: Any) -> bool:
    return isinstance(value, str) and bool(value.strip())


def as_string_list(value: Any) -> bool:
    return isinstance(value, list) and all(isinstance(item, str) and item.strip() for item in value)


def validate_profile(path: Path) -> list[str]:
    errors: list[str] = []
    try:
        data = json.loads(path.read_text(encoding="utf-8"))
    except Exception as exc:
        return [f"{path}: cannot parse JSON: {exc}"]

    schema = data.get("schema")
    if not as_non_empty_string(schema):
        errors.append(f"{path}: schema must be a non-empty string")
    if not as_non_empty_string(data.get("version")):
        errors.append(f"{path}: version must be a non-empty string")
    if "forbidden_text" in data and not as_string_list(data["forbidden_text"]):
        errors.append(f"{path}: forbidden_text must be a list of non-empty strings")
    if schema == HELP_ENTRY_SCHEMA:
        forbidden_text = data.get("forbidden_text")
        if not isinstance(forbidden_text, list) or "ZTool" not in forbidden_text:
            errors.append(f"{path}: {HELP_ENTRY_SCHEMA} must forbid visible ZTool text")

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
            seen.add(surface_id)
        for key in ("title", "process", "window_contains", "notes"):
            if key in ("window_contains", "notes"):
                if not isinstance(surface.get(key, ""), str):
                    errors.append(f"{prefix}: {key} must be a string")
            elif not as_non_empty_string(surface.get(key)):
                errors.append(f"{prefix}: {key} must be a non-empty string")
        if not isinstance(surface.get("required"), bool):
            errors.append(f"{prefix}: required must be boolean")
        if surface.get("han_policy") not in VALID_HAN_POLICIES:
            errors.append(f"{prefix}: han_policy must be one of {sorted(VALID_HAN_POLICIES)}")
        for key in ("text_contains", "process_names", "forbidden_text"):
            if key in surface and not as_string_list(surface[key]):
                errors.append(f"{prefix}: {key} must be a list of non-empty strings")

        # Help-entry pages are validated by visible page-specific markers.
        if str(surface_id).startswith("H-"):
            if surface.get("process") != "hh.exe":
                errors.append(f"{prefix}: help entry process must be hh.exe")
            if surface.get("window_contains") != "SWTools":
                errors.append(f"{prefix}: help entry window_contains must be SWTools")
            if surface.get("required") is not True:
                errors.append(f"{prefix}: help entry required must be true")
            text_markers = surface.get("text_contains")
            if not isinstance(text_markers, list) or len(text_markers) < 2:
                errors.append(f"{prefix}: help entry must define at least two text_contains markers")
            route = surface.get("expected_route")
            if not as_non_empty_string(route) or not str(route).startswith("/"):
                errors.append(f"{prefix}: help entry expected_route must start with /")
            if surface.get("han_policy") != "fail":
                errors.append(f"{prefix}: help entry han_policy must be fail")

    return errors


def self_test() -> int:
    def write_profile(path: Path, overrides: dict[str, Any] | None = None) -> None:
        profile: dict[str, Any] = {
            "schema": HELP_ENTRY_SCHEMA,
            "version": "test",
            "forbidden_text": ["ZTool"],
            "surfaces": [
                {
                    "id": "H-01",
                    "title": "BOM help",
                    "process": "hh.exe",
                    "window_contains": "SWTools",
                    "text_contains": ["Создание шаблона", "Диспетчер имён"],
                    "required": True,
                    "han_policy": "fail",
                    "expected_route": "/advanced/bom-template.htm",
                    "notes": "fixture",
                }
            ],
        }
        for key, value in (overrides or {}).items():
            if key.startswith("surface."):
                profile["surfaces"][0][key.removeprefix("surface.")] = value
            elif key.startswith("delete_surface."):
                profile["surfaces"][0].pop(key.removeprefix("delete_surface."), None)
            else:
                profile[key] = value
        path.write_text(json.dumps(profile, ensure_ascii=False, indent=2), encoding="utf-8")

    with tempfile.TemporaryDirectory(prefix="swtools-visual-profile-") as temp:
        root = Path(temp)
        good = root / "good.json"
        write_profile(good)
        bad = root / "bad.json"
        write_profile(
            bad,
            {
                "schema": "bad",
                "delete_surface.window_contains": True,
                "surface.text_contains": ["only one marker"],
                "surface.han_policy": "record_only",
                "surface.expected_route": "advanced/bom-template.htm",
            },
        )
        good_errors = validate_profile(good)
        assert not good_errors, good_errors
        bad_errors = validate_profile(bad)
        assert bad_errors, "bad profile must fail"
        assert any("expected_route" in item for item in bad_errors), bad_errors
        assert any("text_contains" in item for item in bad_errors), bad_errors
        assert any("han_policy" in item for item in bad_errors), bad_errors
        assert any("window_contains" in item for item in bad_errors), bad_errors

        negative_cases = {
            "missing_window_contains": (
                {"delete_surface.window_contains": True},
                "window_contains must be SWTools",
            ),
            "empty_window_contains": (
                {"surface.window_contains": ""},
                "window_contains must be SWTools",
            ),
            "wrong_window_contains": (
                {"surface.window_contains": "Help"},
                "window_contains must be SWTools",
            ),
            "missing_ztool_forbidden": (
                {"forbidden_text": ["Z Tool"]},
                "must forbid visible ZTool text",
            ),
            "required_false": (
                {"surface.required": False},
                "required must be true",
            ),
        }
        for name, (overrides, expected_error) in negative_cases.items():
            candidate = root / f"{name}.json"
            write_profile(candidate, overrides)
            candidate_errors = validate_profile(candidate)
            assert candidate_errors, f"{name} must fail"
            assert any(expected_error in item for item in candidate_errors), (name, candidate_errors)
    print("Visual surface profile self-test PASS")
    return 0


def main() -> int:
    if hasattr(sys.stdout, "reconfigure"):
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    if hasattr(sys.stderr, "reconfigure"):
        sys.stderr.reconfigure(encoding="utf-8", errors="replace")

    parser = argparse.ArgumentParser()
    parser.add_argument("profiles", nargs="*", type=Path)
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return self_test()
    if not args.profiles:
        return fail("no profile files passed")

    errors: list[str] = []
    for path in args.profiles:
        if not path.is_file():
            errors.append(f"{path}: file not found")
            continue
        errors.extend(validate_profile(path))
    if errors:
        for error in errors:
            print(error, file=sys.stderr)
        return fail(f"{len(errors)} profile error(s)")
    print(f"Visual surface profile check PASS: profiles={len(args.profiles)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
