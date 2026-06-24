#!/usr/bin/env python3
"""Self-tests for visual-localization manifest assertions."""

from __future__ import annotations

import subprocess
import sys
import tempfile
import json
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


def merge_capture_self_test(repo_root: Path, fixtures: Path, assert_script: Path) -> str | None:
    capture_script = repo_root / "scripts" / "swtools_visual_localization_capture.py"
    profile = fixtures / "visual-localization-profile-two-surfaces.json"
    with tempfile.TemporaryDirectory(prefix="swtools-visual-merge-") as tmp:
        tmp_dir = Path(tmp)
        screenshot = tmp_dir / "L-01.png"
        try:
            from PIL import Image
        except Exception as exc:  # pragma: no cover - live dependency guard
            return f"Cannot import PIL for visual merge self-test: {exc}"
        Image.new("RGB", (2, 2), "white").save(screenshot)
        previous = tmp_dir / "previous.json"
        previous.write_text(
            json.dumps(
                {
                    "status": "PASS",
                    "production_go_allowed": False,
                    "expected_runtime_dir": None,
                    "summary": {"surface_count": 1, "captured_count": 1},
                    "surfaces": [
                        {
                            "id": "L-01",
                            "title": "Main window",
                            "process": "SWTools.exe",
                            "process_names": ["swtools.exe"],
                            "window_contains": "SWTools",
                            "text_contains": [],
                            "required": True,
                            "notes": "fixture",
                            "han_policy": "fail",
                            "status": "CAPTURED",
                            "runtime_path_match": True,
                            "visible_han_texts": [],
                            "screenshot": {
                                "path": str(screenshot),
                                "sha256": "fixture",
                                "width": 2,
                                "height": 2,
                            },
                        }
                    ],
                },
                ensure_ascii=False,
                indent=2,
            ),
            encoding="utf-8",
        )
        output = tmp_dir / "out"
        completed = subprocess.run(
            [
                sys.executable,
                str(capture_script),
                "--output-dir",
                str(output),
                "--surface-file",
                str(profile),
                "--surface-id",
                "L-02",
                "--merge-manifest",
                str(previous),
            ],
            text=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
        )
        if completed.returncode != 0:
            return f"Merge capture self-test command failed:\n{completed.stdout}\n{completed.stderr}"
        manifest = json.loads((output / "visual-localization-manifest.json").read_text(encoding="utf-8"))
        by_id = {item["id"]: item for item in manifest["surfaces"]}
        if by_id.get("L-01", {}).get("status") != "CAPTURED":
            return "Merge capture self-test did not preserve captured L-01"
        if by_id.get("L-02", {}).get("status") != "MISSING":
            return "Merge capture self-test did not record missing L-02"
        if manifest.get("summary", {}).get("surface_count") != 2:
            return "Merge capture self-test did not keep full profile surface count"
        forbidden_manifest = tmp_dir / "forbidden.json"
        forbidden_manifest.write_text(
            json.dumps(
                {
                    "status": "PASS",
                    "production_go_allowed": False,
                    "surfaces": [
                        {
                            "id": "L-01",
                            "status": "CAPTURED",
                            "process": "SWTools.exe",
                            "han_policy": "fail",
                            "runtime_path_match": True,
                            "visible_han_texts": [],
                            "forbidden_texts": ["ZTool — Руководство пользователя"],
                            "screenshot": {
                                "path": str(screenshot),
                                "sha256": "fixture",
                                "width": 2,
                                "height": 2,
                            },
                        }
                    ],
                },
                ensure_ascii=False,
                indent=2,
            ),
            encoding="utf-8",
        )
        error = expect_fail(
            [
                sys.executable,
                str(assert_script),
                str(forbidden_manifest),
                "--allow-warn",
                "--require-surface",
                "L-01",
            ],
            ["forbidden", "ZTool"],
        )
        if error:
            return error
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
    error = merge_capture_self_test(repo_root, fixtures, assert_script)
    if error:
        print(error, file=sys.stderr)
        return 1
    print("Visual localization assertion self-test PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
