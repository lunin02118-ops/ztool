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
import threading
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
pythoncom = require_module("pythoncom")
psutil = require_module("psutil")
Application = require_module("pywinauto.application").Application
Desktop = require_module("pywinauto").Desktop


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


def window_process_id(win: Any) -> int | None:
    try:
        return int(win.process_id())
    except Exception:
        pass
    try:
        return int(win.element_info.process_id)
    except Exception:
        return None


def desktop_windows(backend: str, process_id: int | None = None) -> list[Any]:
    desktop = Desktop(backend=backend)
    if process_id is not None:
        try:
            return desktop.windows(process=process_id)
        except Exception:
            pass
    try:
        windows = desktop.windows()
    except Exception:
        return []
    if process_id is None:
        return windows
    return [win for win in windows if window_process_id(win) == process_id]


def dialog_texts(win: Any) -> list[str]:
    texts: list[str] = []
    try:
        title = win.window_text().strip()
        if title:
            texts.append(title)
    except Exception:
        pass
    try:
        children = win.descendants()
    except Exception:
        children = []
    for child in children:
        try:
            text = child.window_text().strip()
        except Exception:
            continue
        if text:
            texts.append(text)
    return texts


def normalize_button_text(text: str) -> str:
    return text.replace("&", "").strip()


def dialog_button_candidates(dialog: Any) -> list[Any]:
    candidates: list[Any] = []
    for method_name in ("children", "descendants"):
        method = getattr(dialog, method_name, None)
        if not method:
            continue
        for kwargs in ({"control_type": "Button"}, {}):
            try:
                candidates.extend(method(**kwargs))
            except Exception:
                continue
    seen: set[Any] = set()
    unique: list[Any] = []
    for child in candidates:
        handle = getattr(child, "handle", None)
        key = handle if handle else id(child)
        if key in seen:
            continue
        seen.add(key)
        unique.append(child)
    return unique


def click_dialog_button(dialog: Any, names: list[str], timeout: float = 1.0) -> str:
    deadline = time.time() + timeout
    expected = {normalize_button_text(name): name for name in names}
    while time.time() < deadline:
        for child in dialog_button_candidates(dialog):
            try:
                text = normalize_button_text(child.window_text())
                control_type = getattr(child.element_info, "control_type", "")
                class_name = child.class_name()
                is_button = (
                    control_type == "Button"
                    or control_type.endswith(".Button")
                    or class_name == "Button"
                    or "BUTTON" in class_name.upper()
                )
            except Exception:
                continue
            if not is_button or text not in expected:
                continue
            for action in ("post", "invoke", "legacy", "click_input", "send"):
                try:
                    if action == "send":
                        child.send_message(0x00F5, 0, 0)  # BM_CLICK
                    elif action == "post":
                        child.post_message(0x00F5, 0, 0)
                    elif action == "invoke":
                        child.invoke()
                    elif action == "legacy":
                        child.iface_invoke.Invoke()
                    else:
                        child.click_input()
                    return expected[text]
                except Exception:
                    continue
        time.sleep(0.05)
    raise RuntimeError(f"Cannot find dialog button from {names!r}")


def dismiss_license_dialog(swtools_pid: int, timeout: float = 8.0) -> dict[str, Any]:
    deadline = time.time() + timeout
    last: dict[str, Any] = {"found": False, "dismissed": False, "text": ""}
    while time.time() < deadline:
        for backend in ("win32", "uia"):
            for win in desktop_windows(backend, process_id=swtools_pid):
                texts = dialog_texts(win)
                joined = "\n".join(texts)
                lowered = joined.lower()
                if "лицензия не обнаружена" not in lowered and "license" not in lowered:
                    continue
                if "демо" not in lowered and "проба" not in lowered and "demo" not in lowered:
                    continue
                last = {
                    "found": True,
                    "dismissed": False,
                    "backend": backend,
                    "title": texts[0] if texts else "",
                    "process_id": window_process_id(win),
                    "text": joined[:2000],
                }
                button = click_dialog_button(win, ["Демо", "Проба", "Demo"], timeout=1.0)
                close_deadline = time.time() + 3.0
                while time.time() < close_deadline:
                    still_open = False
                    for check in desktop_windows(backend, process_id=swtools_pid):
                        check_text = "\n".join(dialog_texts(check)).lower()
                        if "лицензия не обнаружена" in check_text:
                            still_open = True
                            break
                    if not still_open:
                        last.update({"dismissed": True, "button": button})
                        return last
                    time.sleep(0.1)
                last.update({"button": button})
                return last
        time.sleep(0.1)
    return last


def blocking_dialog(swtools_pid: int | None, solidworks_pid: int) -> dict[str, Any] | None:
    owners: list[tuple[int, str]] = [(solidworks_pid, "SolidWorks")]
    if swtools_pid is not None:
        owners.append((swtools_pid, "SWTools"))
    for backend in ("win32", "uia"):
        for pid, owner in owners:
            for win in desktop_windows(backend, process_id=pid):
                try:
                    title = win.window_text().strip()
                    class_name = win.class_name()
                except Exception:
                    title = ""
                    class_name = ""
                texts = dialog_texts(win)
                joined = "\n".join(texts)
                lowered = joined.lower()
                if "лицензия не обнаружена" in lowered:
                    continue
                is_dialog = (
                    class_name == "#32770"
                    or title in {"Информация", "Ошибка", "Вопрос"}
                    or "тайм-аут соединения" in lowered
                    or "timeout" in lowered
                )
                if not is_dialog:
                    continue
                return {
                    "owner": owner,
                    "backend": backend,
                    "process_id": pid,
                    "title": title,
                    "class_name": class_name,
                    "text": joined[:2000],
                }
    return None


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


def invoke_connect_async(main: Any) -> dict[str, Any]:
    state: dict[str, Any] = {"done": False, "error": ""}

    def worker() -> None:
        try:
            invoke_connect(main)
        except Exception as exc:
            state["error"] = str(exc)
        finally:
            state["done"] = True

    thread = threading.Thread(target=worker, name="swtools-s7-connect-invoke", daemon=True)
    thread.start()
    return state


def invoke_open_ztool_async() -> dict[str, Any]:
    state: dict[str, Any] = {"done": False, "error": ""}

    def worker() -> None:
        pythoncom.CoInitialize()
        try:
            sw = win32com.GetActiveObject("SldWorks.Application")
            addin = call_or_value(sw, "GetAddInObject", "ZTool.SwAddin")
            if not addin:
                raise RuntimeError("SolidWorks returned no ZTool.SwAddin object")
            addin.openZtool(0)
        except Exception as exc:
            state["error"] = str(exc)
        finally:
            state["done"] = True
            pythoncom.CoUninitialize()

    thread = threading.Thread(target=worker, name="swtools-s7-open-ztool", daemon=True)
    thread.start()
    return state


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    sys.stderr.reconfigure(encoding="utf-8", errors="replace")
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
        open_state = invoke_open_ztool_async()
        result["open_ztool"] = dict(open_state)
        proc = None
        deadline = time.time() + args.timeout
        while time.time() < deadline and proc is None:
            result["open_ztool"] = dict(open_state)
            if open_state.get("done") and open_state.get("error"):
                raise RuntimeError(f"openZtool failed: {open_state['error']}")
            blocker = blocking_dialog(None, solidworks_pid)
            if blocker:
                result["blocking_dialog"] = blocker
                raise RuntimeError(f"Blocking dialog during openZtool: {blocker}")
            proc = find_runtime_process(runtime_dir, started)
            time.sleep(0.25)
        if proc is None:
            raise RuntimeError(f"SWTools.exe did not start from runtime {runtime_dir}")
        result["open_ztool"] = dict(open_state)
        result["swtools_pid"] = proc.pid
        result["swtools_path"] = proc.exe()
        result["swtools_command_line"] = process_command_line(proc.pid)
        if str(solidworks_pid) not in result["swtools_command_line"]:
            raise RuntimeError("SWTools command line does not include SolidWorks PID")
        result["checks"].append("launcher command line ok")

        app = Application(backend="uia").connect(process=proc.pid)
        license_result = dismiss_license_dialog(proc.pid, timeout=10.0)
        result["license_dialog"] = license_result
        if license_result.get("found") and not license_result.get("dismissed"):
            raise RuntimeError(f"License dialog was not dismissed: {license_result}")
        if license_result.get("dismissed"):
            result["checks"].append("trial dialog dismissed through object automation")
        else:
            invoke_text(app, "Демо", timeout=1.0)
        main = max(app.windows(), key=lambda w: w.rectangle().width() * w.rectangle().height())
        blocker = blocking_dialog(proc.pid, solidworks_pid)
        if blocker:
            result["blocking_dialog"] = blocker
            raise RuntimeError(f"Blocking dialog before connect: {blocker}")
        connect_state = invoke_connect_async(main)
        result["connect_invoke"] = dict(connect_state)
        result["checks"].append("connect invoked through UIA worker")

        last_status = ""
        last_count = 0
        last_texts: list[str] = []
        deadline = time.time() + 80.0
        while time.time() < deadline:
            time.sleep(0.5)
            result["connect_invoke"] = dict(connect_state)
            if connect_state.get("done") and connect_state.get("error"):
                raise RuntimeError(f"Connect UIA invoke failed: {connect_state['error']}")
            blocker = blocking_dialog(proc.pid, solidworks_pid)
            if blocker:
                result["blocking_dialog"] = blocker
                raise RuntimeError(f"Blocking dialog during S7 connect: {blocker}")
            dismiss_license_dialog(proc.pid, timeout=0.1)
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
