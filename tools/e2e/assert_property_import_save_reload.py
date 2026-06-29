#!/usr/bin/env python3
"""Assert SWTools property import/save/reload live evidence."""

from __future__ import annotations

import argparse
import json
import tempfile
from pathlib import Path
from typing import Any


REQUIRED_STEPS = [
    "swdm_file_import",
    "swdm_folder_import",
    "open_components_import",
    "save_reload",
]


def load_json(path: Path) -> dict[str, Any]:
    return json.loads(path.read_text(encoding="utf-8"))


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

    save = steps["save_reload"]
    written = save.get("properties_written") or {}
    reloaded = save.get("reloaded_values") or {}
    if not written:
        raise AssertionError("save_reload did not write any properties")
    for name, expected in written.items():
        entry = reloaded.get(name) or {}
        actual = entry.get("value") or entry.get("resolved")
        if actual != expected:
            raise AssertionError(f"saved property {name!r} was not reloaded: expected {expected!r}, got {actual!r}")

    callbacks = save.get("callback_messages") or []
    if not any(int(item.get("dwData", -1)) == 5 for item in callbacks):
        raise AssertionError("save_reload has no add-in completion callback dwData=5")


def run_self_test() -> None:
    good = {
        "status": "PASS",
        "production_go_allowed": False,
        "steps": {
            "swdm_file_import": {"status": "PASS", "property_count": 3},
            "swdm_folder_import": {"status": "PASS", "property_count": 3},
            "open_components_import": {"status": "PASS", "property_count": 3},
            "save_reload": {
                "status": "PASS",
                "properties_written": {"A": "B"},
                "reloaded_values": {"A": {"value": "B", "resolved": "B"}},
                "callback_messages": [{"dwData": 5, "text": "False\nold\nnew\n0\n"}],
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
    bad_readback["steps"]["save_reload"]["reloaded_values"]["A"]["value"] = "C"
    cases.append(("bad readback", bad_readback))
    bad_callback = json.loads(json.dumps(good, ensure_ascii=False))
    bad_callback["steps"]["save_reload"]["callback_messages"] = []
    cases.append(("missing callback", bad_callback))

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
