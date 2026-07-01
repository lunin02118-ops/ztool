#!/usr/bin/env python3
"""Assert SWTools property import/save/reload live evidence."""

from __future__ import annotations

import argparse
import json
import re
import tempfile
from pathlib import Path
from typing import Any


REQUIRED_STEPS = [
    "swdm_file_import",
    "swdm_folder_import",
    "open_components_import",
    "swtools_runtime_launch",
    "visible_han_check",
    "swtools_connect",
    "receiver_before_save",
    "save_reload",
]
ALLOWED_KEY_EVIDENCE_FIELDS = {"key_sha12", "key_file_sha12", "key_file_length", "key_file_path"}
SECRETISH_RE = re.compile(r"[A-Za-z0-9+/=]{80,}")


def load_json(path: Path) -> dict[str, Any]:
    return json.loads(path.read_text(encoding="utf-8"))


def walk_json(value: Any, path: str = "$") -> list[tuple[str, Any]]:
    items = [(path, value)]
    if isinstance(value, dict):
        for key, child in value.items():
            items.extend(walk_json(child, f"{path}.{key}"))
    elif isinstance(value, list):
        for index, child in enumerate(value):
            items.extend(walk_json(child, f"{path}[{index}]"))
    return items


def assert_no_key_leakage(data: dict[str, Any]) -> None:
    for path, value in walk_json(data):
        leaf = path.rsplit(".", 1)[-1]
        if "key" in leaf.lower() and leaf not in ALLOWED_KEY_EVIDENCE_FIELDS:
            raise AssertionError(f"unexpected key-related evidence field: {path}")
        if isinstance(value, str) and SECRETISH_RE.fullmatch(value.strip()):
            raise AssertionError(f"secret-like value leaked into evidence: {path}")


def assert_result(data: dict[str, Any]) -> None:
    if data.get("status") != "PASS":
        raise AssertionError(f"status is not PASS: {data.get('status')!r}")
    if data.get("production_go_allowed") is not False:
        raise AssertionError("property import/save/reload evidence must not allow Production GO")

    steps = data.get("steps")
    if not isinstance(steps, dict):
        raise AssertionError("missing steps object")
    for step in REQUIRED_STEPS:
        if step not in steps:
            raise AssertionError(f"missing step: {step}")
        if steps[step].get("status") != "PASS":
            raise AssertionError(f"{step} status is not PASS: {steps[step].get('status')!r}")

    for step in ("swdm_file_import", "swdm_folder_import", "open_components_import"):
        count = int(steps[step].get("property_count", 0))
        if count <= 0:
            raise AssertionError(f"{step} has no imported properties")

    open_components = steps["open_components_import"]
    if not open_components.get("active_configuration"):
        raise AssertionError("open_components_import has no active configuration evidence")
    if "document_property_count" not in open_components:
        raise AssertionError("open_components_import has no document-level property evidence")
    if "configuration_property_count" not in open_components:
        raise AssertionError("open_components_import has no configuration-level property evidence")

    if steps["swtools_runtime_launch"].get("status") != "PASS":
        raise AssertionError("SWTools runtime was not launched from expected runtime")
    if steps["visible_han_check"].get("status") != "PASS":
        raise AssertionError(f"visible Han check failed: {steps['visible_han_check']!r}")
    if steps["visible_han_check"].get("han_texts"):
        raise AssertionError(f"visible Han text leaked into SWTools UI: {steps['visible_han_check'].get('han_texts')!r}")
    connect = steps["swtools_connect"]
    if int(connect.get("column_count") or 0) < 8:
        raise AssertionError(f"swtools_connect has too few columns: {connect!r}")
    if int(connect.get("row_count") or 0) < 1:
        raise AssertionError(f"swtools_connect has no connected rows: {connect!r}")
    receiver_before_save = steps["receiver_before_save"]
    if receiver_before_save.get("status") != "PASS":
        raise AssertionError(f"receiver_before_save status is not PASS: {receiver_before_save.get('status')!r}")
    if not receiver_before_save.get("receiver"):
        raise AssertionError(f"receiver_before_save has no receiver evidence: {receiver_before_save!r}")

    save = steps["save_reload"]
    written = save.get("properties_written") or {}
    live_document = save.get("live_values_document") or {}
    live_configuration = save.get("live_values_configuration")
    reloaded_document = save.get("reloaded_values_document") or save.get("reloaded_values") or {}
    reloaded_configuration = save.get("reloaded_values_configuration")
    if not written:
        raise AssertionError("save_reload did not write any properties")
    if live_configuration is None:
        raise AssertionError("save_reload has no live configuration-level read-back evidence")
    if reloaded_configuration is None:
        raise AssertionError("save_reload has no reloaded configuration-level read-back evidence")
    if not save.get("active_configuration_before_save"):
        raise AssertionError("save_reload has no active configuration before save")
    if not save.get("active_configuration_after_reload"):
        raise AssertionError("save_reload has no active configuration after reload")
    for name, expected in written.items():
        live_entry = live_document.get(name) or {}
        live_actual = live_entry.get("value") or live_entry.get("resolved")
        if live_actual != expected:
            raise AssertionError(f"saved property {name!r} was not visible before reload: expected {expected!r}, got {live_actual!r}")
        entry = reloaded_document.get(name) or {}
        actual = entry.get("value") or entry.get("resolved")
        if actual != expected:
            raise AssertionError(f"saved property {name!r} was not reloaded: expected {expected!r}, got {actual!r}")

    assert_no_key_leakage(data)


def run_self_test() -> None:
    good = {
        "status": "PASS",
        "production_go_allowed": False,
        "steps": {
            "swdm_file_import": {"status": "PASS", "property_count": 3},
            "swdm_folder_import": {"status": "PASS", "property_count": 3},
            "open_components_import": {
                "status": "PASS",
                "property_count": 3,
                "active_configuration": "Default",
                "document_property_count": 2,
                "configuration_property_count": 1,
            },
            "swtools_runtime_launch": {"status": "PASS"},
            "visible_han_check": {"status": "PASS", "han_texts": []},
            "swtools_connect": {
                "status": "PASS",
                "row_count": 1,
                "column_count": 8,
                "receiver_windows_after_connect": [{"hwnd": 1}],
            },
            "receiver_before_save": {"status": "PASS", "receiver": {"hwnd": 1}},
            "save_reload": {
                "status": "PASS",
                "properties_written": {"A": "B"},
                "live_values_document": {"A": {"value": "B", "resolved": "B"}},
                "live_values_configuration": {"A": {"value": "", "resolved": ""}},
                "reloaded_values_document": {"A": {"value": "B", "resolved": "B"}},
                "reloaded_values_configuration": {"A": {"value": "", "resolved": ""}},
                "active_configuration_before_save": "Default",
                "active_configuration_after_reload": "Default",
            },
        },
    }
    assert_result(good)

    cases: list[tuple[str, dict[str, Any]]] = []
    bad_status = json.loads(json.dumps(good, ensure_ascii=False))
    bad_status["steps"]["swdm_file_import"]["status"] = "FAIL"
    cases.append(("bad step status", bad_status))
    bad_go = json.loads(json.dumps(good, ensure_ascii=False))
    bad_go["production_go_allowed"] = True
    cases.append(("production go allowed", bad_go))
    bad_readback = json.loads(json.dumps(good, ensure_ascii=False))
    bad_readback["steps"]["save_reload"]["reloaded_values_document"]["A"]["value"] = "C"
    cases.append(("bad readback", bad_readback))
    bad_han = json.loads(json.dumps(good, ensure_ascii=False))
    bad_han["steps"]["visible_han_check"]["han_texts"] = ["零件"]
    cases.append(("visible Han", bad_han))
    bad_connect = json.loads(json.dumps(good, ensure_ascii=False))
    bad_connect["steps"]["swtools_connect"]["row_count"] = 0
    cases.append(("missing SWTools connect rows", bad_connect))
    bad_receiver_before_save = json.loads(json.dumps(good, ensure_ascii=False))
    bad_receiver_before_save["steps"]["receiver_before_save"]["receiver"] = None
    cases.append(("missing receiver-before-save evidence", bad_receiver_before_save))
    bad_scope = json.loads(json.dumps(good, ensure_ascii=False))
    del bad_scope["steps"]["open_components_import"]["configuration_property_count"]
    cases.append(("missing configuration-level evidence", bad_scope))
    bad_key = json.loads(json.dumps(good, ensure_ascii=False))
    bad_key["steps"]["swdm_file_import"]["raw_key"] = "A" * 100
    cases.append(("raw key leakage", bad_key))

    for label, payload in cases:
        try:
            assert_result(payload)
        except AssertionError:
            continue
        raise AssertionError(f"negative self-test did not fail: {label}")

    with tempfile.TemporaryDirectory() as tmp:
        path = Path(tmp) / "result.json"
        path.write_text(json.dumps(good, ensure_ascii=False), encoding="utf-8")
        assert_result(load_json(path))


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("result", nargs="?", type=Path)
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        run_self_test()
        print("PASS: property import/save/reload assertion self-test")
        return 0
    if args.result is None:
        parser.error("result JSON is required unless --self-test is used")
    assert_result(load_json(args.result))
    print("PASS: property import/save/reload evidence accepted")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
