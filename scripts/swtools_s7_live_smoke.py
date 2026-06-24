#!/usr/bin/env python3
"""Live SolidWorks S7 smoke for SWTools source-built runtime.

This is a manual-machine gate.  It proves the full path:

SolidWorks model -> ZTool.SwAddin.openZtool(0) -> SWTools.exe -> UIA Invoke
"Демо" (if shown) -> UIA Invoke "Подключить SW" -> grid rows.

No coordinate click is accepted.  If UIA Invoke is unavailable, the test fails
instead of pretending the command was tested.
"""

from __future__ import annotations

import argparse
import hashlib
import importlib
import json
import os
import re
import sys
import time
from pathlib import Path
from typing import Any


def require_module(name: str) -> Any:
    try:
        return importlib.import_module(name)
    except Exception as exc:  # pragma: no cover - live environment guard
        raise SystemExit(f"Missing Python module '{name}': {exc}") from exc


win32com = require_module("win32com.client")
win32gui = require_module("win32gui")
win32con = require_module("win32con")
win32process = require_module("win32process")
psutil = require_module("psutil")
Application = require_module("pywinauto.application").Application


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest().upper()


def normalize_env() -> None:
    windir = os.environ.get("WINDIR") or os.environ.get("SystemRoot") or r"C:\Windows"
    os.environ["WINDIR"] = windir
    os.environ["SystemRoot"] = windir
    os.environ.setdefault("ComSpec", str(Path(windir) / "System32" / "cmd.exe"))


def call_or_value(obj: Any, name: str, *args: Any) -> Any:
    value = getattr(obj, name)
    if callable(value):
        return value(*args)
    if args:
        raise TypeError(f"{name} is exposed as a COM property, not a method")
    return value


def get_solidworks(timeout: float) -> Any:
    deadline = time.time() + timeout
    last_error: str | None = None
    while time.time() < deadline:
        try:
            return win32com.GetActiveObject("SldWorks.Application")
        except Exception as exc:
            last_error = str(exc)
            time.sleep(1.0)
    raise RuntimeError(f"SolidWorks COM object not available: {last_error}")


def get_or_start_solidworks(model_path: Path, timeout: float) -> Any:
    try:
        return get_solidworks(timeout=5.0)
    except RuntimeError:
        os.startfile(str(model_path))
        return get_solidworks(timeout)


def ensure_model_open(sw: Any, model_path: Path, timeout: float) -> str:
    model_norm = str(model_path.resolve()).lower()
    try:
        active = sw.ActiveDoc
        if active is not None:
            path = str(call_or_value(active, "GetPathName"))
            if path.lower() == model_norm:
                return path
    except Exception:
        pass

    errors: list[str] = []
    opened = False
    for doc_type in (2, 1):  # swDocASSEMBLY, swDocPART without importing SolidWorks constants.
        try:
            open_errors = 0
            open_warnings = 0
            doc = sw.OpenDoc6(str(model_path), doc_type, 0, "", open_errors, open_warnings)
            if doc is not None:
                opened = True
                break
        except Exception as exc:
            errors.append(str(exc))
    if not opened:
        os.startfile(str(model_path))
    deadline = time.time() + timeout
    while time.time() < deadline:
        try:
            active = sw.ActiveDoc
            if active is not None:
                path = str(call_or_value(active, "GetPathName"))
                if path.lower() == model_norm:
                    return path
        except Exception:
            pass
        time.sleep(1.0)
    raise RuntimeError(f"Active SolidWorks document is not the target model: {model_path}; open errors={errors}")


def find_runtime_process(runtime_dir: Path, started_after: float) -> psutil.Process | None:
    runtime = str(runtime_dir.resolve()).lower()
    candidates: list[psutil.Process] = []
    for proc in psutil.process_iter(["pid", "name", "exe", "create_time"]):
        try:
            if (proc.info.get("name") or "").lower() != "swtools.exe":
                continue
            exe = (proc.info.get("exe") or "").lower()
            if exe.startswith(runtime) and proc.info.get("create_time", 0) >= started_after - 2:
                candidates.append(proc)
        except (psutil.NoSuchProcess, psutil.AccessDenied):
            continue
    candidates.sort(key=lambda p: p.info.get("create_time", 0), reverse=True)
    return candidates[0] if candidates else None


def process_command_line(pid: int) -> str:
    try:
        return " ".join(psutil.Process(pid).cmdline())
    except Exception:
        return ""


def restore_window(hwnd: int) -> None:
    if win32gui.IsIconic(hwnd):
        win32gui.ShowWindow(hwnd, win32con.SW_RESTORE)
    else:
        win32gui.ShowWindow(hwnd, win32con.SW_SHOWNORMAL)
    try:
        win32gui.SetForegroundWindow(hwnd)
    except Exception:
        pass


def visible_texts(win: Any) -> list[str]:
    result: list[str] = []
    for child in win.descendants():
        try:
            text = child.window_text()
        except Exception:
            continue
        if text:
            result.append(text)
    return result


def parse_status(texts: list[str]) -> str:
    candidates = [t for t in texts if "Подключение" in t or "Получение данных" in t or "поз" in t]
    return candidates[-1] if candidates else ""


def parse_row_count(status: str, texts: list[str]) -> int:
    match = re.search(r"всего\s+(\d+)(?:/\d+)?\s+поз", status, re.IGNORECASE)
    if match:
        return int(match.group(1))
    part_like = {t for t in texts if re.match(r"^(?:PArt|Part|0614-A00)", t)}
    return len(part_like)


def grid_dimensions(main: Any, fallback_rows: int) -> dict[str, Any]:
    candidates: list[dict[str, Any]] = []
    for child in main.descendants():
        try:
            control_type = child.element_info.control_type
            class_name = child.class_name()
            text = child.window_text()
        except Exception:
            continue
        if control_type not in {"DataGrid", "Table", "List"} and "DataGrid" not in class_name:
            continue
        item: dict[str, Any] = {
            "control_type": control_type,
            "class_name": class_name,
            "text": text,
        }
        try:
            iface_grid = child.iface_grid
            item["row_count"] = int(iface_grid.CurrentRowCount)
            item["column_count"] = int(iface_grid.CurrentColumnCount)
        except Exception as exc:
            item["grid_error"] = str(exc)
        try:
            rect = child.rectangle()
            item["rectangle"] = {
                "left": rect.left,
                "top": rect.top,
                "right": rect.right,
                "bottom": rect.bottom,
            }
        except Exception:
            pass
        candidates.append(item)

    ranked = sorted(
        candidates,
        key=lambda c: (
            int(c.get("row_count") or 0),
            int(c.get("column_count") or 0),
        ),
        reverse=True,
    )
    best = ranked[0] if ranked else {}
    row_count = int(best.get("row_count") or fallback_rows or 0)
    column_count = int(best.get("column_count") or 0)
    return {
        "row_count": row_count,
        "column_count": column_count,
        "candidates": ranked[:8],
    }


def invoke_text(app: Any, text: str, timeout: float) -> bool:
    deadline = time.time() + timeout
    while time.time() < deadline:
        for win in app.windows():
            for child in win.descendants():
                try:
                    if child.window_text().strip() != text:
                        continue
                    child.invoke()
                    return True
                except Exception:
                    continue
        time.sleep(0.2)
    return False


def invoke_connect(main: Any) -> None:
    restore_window(main.handle)
    main.set_focus()
    for child in main.descendants(control_type="SplitButton"):
        try:
            if child.window_text().strip() == "Подключить SW" and child.legacy_properties().get("DefaultAction") == "Нажать":
                child.invoke()
                return
        except Exception:
            continue
    raise RuntimeError("Cannot UIA-invoke top SplitButton 'Подключить SW'")


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    parser = argparse.ArgumentParser()
    parser.add_argument("--runtime-dir", required=True)
    parser.add_argument("--model", required=True)
    parser.add_argument("--report-dir", required=True)
    parser.add_argument("--expected-exe-sha256")
    parser.add_argument("--expected-dll-sha256")
    parser.add_argument("--expected-min-rows", type=int, default=29)
    parser.add_argument("--expected-min-columns", type=int, default=30)
    parser.add_argument("--timeout", type=float, default=90.0)
    args = parser.parse_args()

    normalize_env()
    runtime_dir = Path(args.runtime_dir).resolve()
    model = Path(args.model).resolve()
    report_dir = Path(args.report_dir).resolve()
    report_dir.mkdir(parents=True, exist_ok=True)
    result_path = report_dir / "s7-live-smoke-result.json"

    result: dict[str, Any] = {
        "status": "FAIL",
        "runtime_dir": str(runtime_dir),
        "model": str(model),
        "expected_min_rows": args.expected_min_rows,
        "expected_min_columns": args.expected_min_columns,
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

        sw = get_or_start_solidworks(model, args.timeout)
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
        deadline = time.time() + args.timeout
        while time.time() < deadline and proc is None:
            proc = find_runtime_process(runtime_dir, started)
            time.sleep(0.5)
        if proc is None:
            raise RuntimeError(f"SWTools.exe did not start from runtime {runtime_dir}")
        result["swtools_pid"] = proc.pid
        result["swtools_path"] = proc.exe()
        result["swtools_command_line"] = process_command_line(proc.pid)
        if str(solidworks_pid) not in result["swtools_command_line"]:
            raise RuntimeError("SWTools command line does not include SolidWorks PID")
        result["checks"].append("launcher command line ok")

        app = Application(backend="uia").connect(process=proc.pid)
        invoke_text(app, "Демо", timeout=8.0)
        main = max(app.windows(), key=lambda w: w.rectangle().width() * w.rectangle().height())
        invoke_connect(main)
        result["checks"].append("connect invoked through UIA")

        last_status = ""
        last_count = 0
        last_texts: list[str] = []
        deadline = time.time() + 80.0
        while time.time() < deadline:
            time.sleep(1.0)
            last_texts = visible_texts(main)
            last_status = parse_status(last_texts)
            last_count = parse_row_count(last_status, last_texts)
            if "Подключение завершено" in last_status or last_count >= args.expected_min_rows:
                break

        result["status_text"] = last_status
        result["row_count"] = last_count
        dimensions = grid_dimensions(main, last_count)
        result["column_count"] = dimensions["column_count"]
        result["grid_dimensions"] = dimensions
        result["visible_text_sample"] = last_texts[:250]
        if last_count < args.expected_min_rows:
            raise RuntimeError(f"S7 returned {last_count} rows; expected at least {args.expected_min_rows}; status={last_status!r}")
        if result["column_count"] < args.expected_min_columns:
            raise RuntimeError(
                f"S7 grid has {result['column_count']} columns; "
                f"expected at least {args.expected_min_columns}"
            )

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
