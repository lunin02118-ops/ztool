#!/usr/bin/env python3
"""Live smoke for the SWTools BOM column mapping dialog.

This is a manual-machine gate. It proves the path:

SolidWorks model -> add-in launches the expected SWTools.exe -> "Подключить SW"
fills rows -> "Спецификация" tab -> "Сопоставление заголовков столбцов" opens
without the duplicate-name modal.

The test uses UI Automation Invoke/Select only. A coordinate click is not a PASS.
"""

from __future__ import annotations

import argparse
import json
import sys
import time
from pathlib import Path
from typing import Any

from swtools_s7_live_smoke import (
    Application,
    call_or_value,
    ensure_model_open,
    find_runtime_process,
    get_solidworks,
    invoke_connect,
    invoke_text,
    normalize_env,
    parse_row_count,
    parse_status,
    process_command_line,
    psutil,
    restore_window,
    sha256,
    visible_texts,
)


def norm(text: str) -> str:
    return " ".join((text or "").split())


def latest_runtime_process(runtime_dir: Path) -> psutil.Process | None:
    runtime = str(runtime_dir.resolve()).lower()
    candidates: list[psutil.Process] = []
    for proc in psutil.process_iter(["pid", "name", "exe", "create_time"]):
        try:
            if (proc.info.get("name") or "").lower() != "swtools.exe":
                continue
            exe = (proc.info.get("exe") or "").lower()
            if exe.startswith(runtime):
                candidates.append(proc)
        except (psutil.NoSuchProcess, psutil.AccessDenied):
            continue
    candidates.sort(key=lambda p: p.info.get("create_time", 0), reverse=True)
    return candidates[0] if candidates else None


def invoke_contains(app: Any, text: str, timeout: float) -> bool:
    target = norm(text)
    deadline = time.time() + timeout
    while time.time() < deadline:
        for win in app.windows():
            for child in win.descendants():
                try:
                    child_text = norm(child.window_text())
                    if target not in child_text:
                        continue
                    try:
                        child.select()
                        return True
                    except Exception:
                        child.invoke()
                        return True
                except Exception:
                    continue
        time.sleep(0.2)
    return False


def window_text_inventory(app: Any) -> list[str]:
    texts: list[str] = []
    for win in app.windows():
        try:
            texts.append(norm(win.window_text()))
        except Exception:
            pass
        try:
            texts.extend(norm(t) for t in visible_texts(win))
        except Exception:
            pass
    return [t for t in texts if t]


def wait_rows(main: Any, expected_min_rows: int, timeout: float) -> tuple[int, str, list[str]]:
    deadline = time.time() + timeout
    last_status = ""
    last_count = 0
    last_texts: list[str] = []
    while time.time() < deadline:
        time.sleep(1.0)
        last_texts = visible_texts(main)
        last_status = parse_status(last_texts)
        last_count = parse_row_count(last_status, last_texts)
        if "Подключение завершено" in last_status or last_count >= expected_min_rows:
            break
    return last_count, last_status, last_texts


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    parser = argparse.ArgumentParser()
    parser.add_argument("--runtime-dir", required=True)
    parser.add_argument("--model", required=True)
    parser.add_argument("--report-dir", required=True)
    parser.add_argument("--expected-exe-sha256")
    parser.add_argument("--expected-dll-sha256")
    parser.add_argument("--expected-min-rows", type=int, default=29)
    parser.add_argument("--timeout", type=float, default=90.0)
    args = parser.parse_args()

    normalize_env()
    runtime_dir = Path(args.runtime_dir).resolve()
    model = Path(args.model).resolve()
    report_dir = Path(args.report_dir).resolve()
    report_dir.mkdir(parents=True, exist_ok=True)
    result_path = report_dir / "mapping-dialog-smoke-result.json"

    result: dict[str, Any] = {
        "status": "FAIL",
        "runtime_dir": str(runtime_dir),
        "model": str(model),
        "expected_min_rows": args.expected_min_rows,
        "checks": [],
    }

    try:
        exe = runtime_dir / "SWTools.exe"
        dll = runtime_dir / "SWTools.dll"
        exe_hash = sha256(exe)
        dll_hash = sha256(dll)
        result["exe_sha256"] = exe_hash
        result["dll_sha256"] = dll_hash
        if args.expected_exe_sha256 and exe_hash != args.expected_exe_sha256.upper():
            raise RuntimeError(f"SWTools.exe SHA mismatch: {exe_hash}")
        if args.expected_dll_sha256 and dll_hash != args.expected_dll_sha256.upper():
            raise RuntimeError(f"SWTools.dll SHA mismatch: {dll_hash}")
        result["checks"].append("runtime hashes ok")

        sw = get_solidworks(args.timeout)
        active_model = ensure_model_open(sw, model, args.timeout)
        result["active_model"] = active_model
        solidworks_pid = int(call_or_value(sw, "GetProcessID"))
        result["solidworks_pid"] = solidworks_pid
        addin = call_or_value(sw, "GetAddInObject", "ZTool.SwAddin")
        if not addin:
            raise RuntimeError("SolidWorks returned no ZTool.SwAddin object")
        result["checks"].append("addin object ok")

        started = time.time()
        addin.openZtool(0)
        proc = None
        deadline = time.time() + min(args.timeout, 20.0)
        while time.time() < deadline and proc is None:
            proc = find_runtime_process(runtime_dir, started)
            time.sleep(0.5)
        if proc is None:
            proc = latest_runtime_process(runtime_dir)
        if proc is None:
            raise RuntimeError(f"SWTools.exe is not running from runtime {runtime_dir}")
        result["swtools_pid"] = proc.pid
        result["swtools_path"] = proc.exe()
        result["swtools_command_line"] = process_command_line(proc.pid)
        result["checks"].append("runtime process ok")

        app = Application(backend="uia").connect(process=proc.pid)
        invoke_text(app, "Демо", timeout=8.0)
        main = max(app.windows(), key=lambda w: w.rectangle().width() * w.rectangle().height())
        restore_window(main.handle)
        main.set_focus()
        invoke_connect(main)
        result["checks"].append("connect invoked through UIA")

        row_count, status_text, text_sample = wait_rows(main, args.expected_min_rows, timeout=80.0)
        result["row_count"] = row_count
        result["status_text"] = status_text
        if row_count < args.expected_min_rows:
            raise RuntimeError(f"S7 returned {row_count} rows; expected at least {args.expected_min_rows}; status={status_text!r}")
        result["checks"].append("S7 rows ok")

        if not invoke_contains(app, "Спецификация", timeout=8.0):
            raise RuntimeError("Cannot UIA-select 'Спецификация' tab")
        if not invoke_contains(app, "Сопоставление заголовков столбцов", timeout=8.0):
            raise RuntimeError("Cannot UIA-invoke 'Сопоставление заголовков столбцов'")
        time.sleep(1.5)
        inventory = window_text_inventory(app)
        result["visible_text_sample"] = inventory[:300]

        duplicate_modal = any("Повторяющееся имя" in text for text in inventory)
        if duplicate_modal:
            invoke_text(app, "OK", timeout=2.0)
            raise RuntimeError("Frmmapping opened duplicate-name modal")

        mapping_dialog = any("Сопоставление заголовков столбцов" in text for text in inventory)
        if not mapping_dialog:
            raise RuntimeError("Frmmapping dialog did not open")
        result["checks"].append("mapping dialog opened without duplicate modal")

        invoke_text(app, "Отмена", timeout=3.0)
        result["status"] = "PASS"
        result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
        print(json.dumps(result, ensure_ascii=False, indent=2))
        return 0
    except Exception as exc:
        result["error"] = str(exc)
        result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
        print(str(exc), file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(run())
