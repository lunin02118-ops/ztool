#!/usr/bin/env python3
"""Live SolidWorks S8 BOM export automation for SWTools.

This script attaches to the already opened source-built SWTools runtime after
S7 has populated the grid, drives the "Экспорт спецификации" ribbon menu through
UI Automation, saves one workbook per BOM mode, and validates the resulting
Excel files semantically.

No coordinate click is accepted as evidence.
"""

from __future__ import annotations

import argparse
import hashlib
import json
import os
import re
import sys
import time
from pathlib import Path
from typing import Any


def require_module(name: str) -> Any:
    try:
        return __import__(name)
    except Exception as exc:  # pragma: no cover - live environment guard
        raise SystemExit(f"Missing Python module '{name}': {exc}") from exc


psutil = require_module("psutil")
openpyxl = require_module("openpyxl")
pywinauto_application = require_module("pywinauto.application")
pywinauto_desktop = require_module("pywinauto")
pywinauto_findwindows = require_module("pywinauto.findwindows")
Application = pywinauto_application.Application
Desktop = pywinauto_desktop.Desktop
findwindows = pywinauto_findwindows


MODES = [
    (1, "Экспорт сводной спецификации", "01-summary"),
    (2, "Экспорт иерархической спецификации", "02-hierarchy"),
    (3, "Экспорт спецификации верхнего уровня", "03-top-level"),
    (4, "Экспорт сводной спецификации деталей", "04-parts-summary"),
    (5, "Экспорт сводной спецификации (с эскизами)", "05-summary-images"),
    (6, "Экспорт иерархической спецификации (с эскизами)", "06-hierarchy-images"),
    (7, "Обрабатываемые детали", "07-processed-filter"),
    (8, "Покупные изделия", "08-purchased-filter"),
]

DATA_START_ROW = 7
COL_NUM = 1
COL_QTY = 7
COL_WEIGHT = 10
COL_IMAGE = 13
COL_PATH = 15
COL_DIMS = 16
SIGNIFICANT_COLS = [COL_NUM, COL_QTY, COL_WEIGHT, COL_PATH, COL_DIMS, 3, 4, 5, 8, 9, 14]


def normalize_env() -> None:
    windir = os.environ.get("WINDIR") or os.environ.get("SystemRoot") or r"C:\Windows"
    os.environ["WINDIR"] = windir
    os.environ["SystemRoot"] = windir
    os.environ.setdefault("ComSpec", str(Path(windir) / "System32" / "cmd.exe"))


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest().upper()


def find_runtime_process(runtime_dir: Path) -> psutil.Process:
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
    if not candidates:
        raise RuntimeError(f"SWTools.exe is not running from runtime {runtime_dir}")
    return candidates[0]


def process_command_line(pid: int) -> str:
    try:
        return " ".join(psutil.Process(pid).cmdline())
    except Exception:
        return ""


def largest_window(app: Any) -> Any:
    windows = app.windows()
    if not windows:
        raise RuntimeError("SWTools has no UI windows")
    return max(windows, key=lambda w: w.rectangle().width() * w.rectangle().height())


def wrapper_process_id(root: Any) -> int | None:
    try:
        return int(root.process_id())
    except Exception:
        pass
    try:
        return int(root.element_info.process_id)
    except Exception:
        return None


def iter_search_roots(root: Any, include_desktop: bool) -> list[Any]:
    roots = [root]
    if include_desktop:
        pid = wrapper_process_id(root)
        try:
            if pid:
                roots.extend(Desktop(backend="uia").windows(process=pid))
            else:
                roots.extend(Desktop(backend="uia").windows())
        except Exception:
            pass
    return roots


def find_control_by_text(
    root: Any,
    text: str,
    control_types: set[str] | None = None,
    include_desktop: bool = False,
) -> tuple[Any | None, list[str]]:
    seen: list[str] = []
    for search_root in iter_search_roots(root, include_desktop=include_desktop):
        try:
            descendants = search_root.descendants()
        except Exception:
            continue
        for child in descendants:
            try:
                child_text = child.window_text().strip()
                control_type = child.element_info.control_type
            except Exception:
                continue
            if child_text:
                seen.append(child_text)
            if child_text != text:
                continue
            if control_types and control_type not in control_types:
                continue
            return child, seen
    return None, seen


def invoke_by_text(root: Any, text: str, control_types: set[str] | None = None, timeout: float = 10.0) -> Any:
    deadline = time.time() + timeout
    last_seen: list[str] = []
    include_desktop = bool(control_types and "MenuItem" in control_types)
    while time.time() < deadline:
        child, seen = find_control_by_text(root, text, control_types, include_desktop=include_desktop)
        last_seen.extend(seen)
        if child is not None:
            invoke_error = ""
            try:
                child.set_focus()
            except Exception:
                pass
            try:
                child.invoke()
                return child
            except Exception as invoke_exc:
                invoke_error = str(invoke_exc)
            try:
                legacy = child.legacy_properties()
                default_action = legacy.get("DefaultAction") or legacy.get("DefaultActionName")
                if default_action:
                    child.iface_legacy_iaccessible.DoDefaultAction()
                    return child
            except Exception:
                pass
            try:
                child.select()
            except Exception as exc:
                raise RuntimeError(
                    f"Control {text!r} cannot be invoked/selected: invoke={invoke_error}; select={exc}"
                ) from exc
            return child
        time.sleep(0.2)
    sample = ", ".join(sorted(set(last_seen))[:40])
    raise RuntimeError(f"Cannot find UIA control {text!r}; seen: {sample}")


def ensure_spec_tab(main: Any) -> None:
    invoke_by_text(main, "Спецификация", {"TabItem"}, timeout=5.0)
    time.sleep(0.3)


def open_export_menu(main: Any) -> None:
    ensure_spec_tab(main)
    for child in main.descendants(control_type="SplitButton"):
        try:
            child_text = child.window_text().strip()
        except Exception:
            continue
        if child_text != "Экспорт спецификации":
            continue
        for action in ("expand", "invoke", "legacy"):
            try:
                child.set_focus()
            except Exception:
                pass
            try:
                if action == "expand":
                    child.expand()
                elif action == "invoke":
                    child.invoke()
                else:
                    child.iface_legacy_iaccessible.DoDefaultAction()
            except Exception:
                pass
            deadline = time.time() + 2.0
            while time.time() < deadline:
                found, _ = find_control_by_text(
                    main,
                    "Экспорт сводной спецификации",
                    {"MenuItem"},
                    include_desktop=True,
                )
                if found is not None:
                    return
                time.sleep(0.1)
        raise RuntimeError("SplitButton 'Экспорт спецификации' did not open its menu")
    raise RuntimeError("Cannot UIA-expand SplitButton 'Экспорт спецификации'")


def window_snapshot() -> list[dict[str, Any]]:
    snapshot: list[dict[str, Any]] = []
    for backend in ("uia", "win32"):
        try:
            windows = Desktop(backend=backend).windows()
        except Exception as exc:
            snapshot.append({"backend": backend, "error": str(exc)})
            continue
        for win in windows:
            try:
                title = win.window_text().strip()
                class_name = win.class_name()
                rect = win.rectangle()
            except Exception:
                continue
            if not title:
                continue
            snapshot.append(
                {
                    "backend": backend,
                    "title": title,
                    "class_name": class_name,
                    "rect": [rect.left, rect.top, rect.right, rect.bottom],
                }
            )
    return snapshot


def is_save_dialog(win: Any) -> bool:
    try:
        title = win.window_text().strip()
    except Exception:
        title = ""
    if "сохран" not in title.lower() and "save" not in title.lower():
        return False
    return True


def wait_for_save_dialog(timeout: float) -> Any:
    deadline = time.time() + timeout
    last_snapshot: list[dict[str, Any]] = []
    while time.time() < deadline:
        for backend in ("uia", "win32"):
            try:
                windows = Desktop(backend=backend).windows()
            except Exception:
                windows = []
            for win in windows:
                if not is_save_dialog(win):
                    continue
                if backend == "uia":
                    return win
                try:
                    handle = win.handle
                    return Desktop(backend="uia").window(handle=handle)
                except Exception:
                    return win
            try:
                handles = findwindows.find_windows(title_re=r".*(Сохран|сохран|Save|save).*", top_level_only=False)
            except Exception:
                handles = []
            for handle in handles:
                try:
                    return Desktop(backend="uia").window(handle=handle)
                except Exception:
                    try:
                        return Desktop(backend=backend).window(handle=handle)
                    except Exception:
                        continue
        last_snapshot = window_snapshot()
        time.sleep(0.2)
    raise RuntimeError(f"Save dialog did not appear; windows={json.dumps(last_snapshot, ensure_ascii=False)}")


def set_save_dialog_path(dialog: Any, target: Path) -> None:
    edits = []
    for child in dialog.descendants(control_type="Edit"):
        try:
            rect = child.rectangle()
            text = child.window_text()
        except Exception:
            continue
        edits.append((rect.top, rect.left, text, child))
    if not edits:
        raise RuntimeError("Save dialog has no Edit controls")
    # File name edit is the lower wide edit box; it is more stable than relying
    # on localized labels or Windows shell implementation details.
    edit = sorted(edits, key=lambda x: (x[0], x[1]))[-1][3]
    try:
        edit.iface_value.SetValue(str(target))
    except Exception:
        edit.set_edit_text(str(target))


def click_dialog_button(dialog: Any, names: list[str], timeout: float = 10.0) -> str:
    deadline = time.time() + timeout
    while time.time() < deadline:
        for name in names:
            try:
                children = dialog.descendants(control_type="Button")
            except Exception:
                try:
                    children = dialog.descendants()
                except Exception:
                    children = []
            for child in children:
                try:
                    text = child.window_text().strip()
                    control_type = getattr(child.element_info, "control_type", "")
                    class_name = child.class_name()
                    is_button = control_type == "Button" or class_name == "Button"
                    if is_button and text == name:
                        child.invoke()
                        return name
                except Exception:
                    pass
                try:
                    if child.window_text().strip() == name:
                        child.iface_invoke.Invoke()
                        return name
                except Exception:
                    pass
                try:
                    if child.window_text().strip() == name:
                        child.send_message(0x00F5, 0, 0)  # BM_CLICK
                        return name
                except Exception:
                    continue
        time.sleep(0.2)
    raise RuntimeError(f"Cannot find dialog button from {names!r}")


def handle_overwrite_confirmation(timeout: float = 5.0) -> bool:
    deadline = time.time() + timeout
    while time.time() < deadline:
        for win in Desktop(backend="uia").windows():
            try:
                title = win.window_text()
            except Exception:
                continue
            if "Подтвердить сохранение" not in title and "Confirm" not in title:
                continue
            click_dialog_button(win, ["Да", "Yes"])
            return True
        time.sleep(0.2)
    return False


def dismiss_export_modal(timeout: float = 45.0) -> dict[str, str]:
    deadline = time.time() + timeout
    last_texts: list[str] = []
    while time.time() < deadline:
        for backend in ("uia", "win32"):
            try:
                windows = Desktop(backend=backend).windows()
            except Exception:
                windows = []
            for win in windows:
                try:
                    title = win.window_text().strip()
                except Exception:
                    continue
                texts: list[str] = []
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
                last_texts = texts
                joined = "\n".join(texts)
                is_export_done = (
                    "вопрос" in title.lower()
                    or "question" in title.lower()
                    or "Экспорт выполнен" in joined
                    or "Открыть?" in joined
                    or "open?" in joined.lower()
                )
                if is_export_done:
                    for button in ("Нет", "No", "OK", "ОК", "Да", "Yes"):
                        try:
                            click_dialog_button(win, [button], timeout=0.5)
                            evidence_text = "\n".join(
                                text for text in texts if text in {"Вопрос", "Да", "Нет", "Yes", "No"} or "Экспорт" in text or "Открыть" in text
                            )
                            if not evidence_text:
                                evidence_text = joined[:1000]
                            return {"title": title, "button": button, "text": evidence_text[:2000]}
                        except Exception:
                            continue
        time.sleep(0.2)
    return {"title": "", "button": "", "text": "\n".join(last_texts)}


def wait_for_file(path: Path, timeout: float) -> None:
    deadline = time.time() + timeout
    last_size = -1
    stable_count = 0
    while time.time() < deadline:
        if path.is_file():
            size = path.stat().st_size
            if size > 0 and size == last_size:
                stable_count += 1
                if stable_count >= 2:
                    return
            else:
                stable_count = 0
                last_size = size
        time.sleep(0.5)
    raise RuntimeError(f"Exported file did not become stable: {path}")


def cell_nonempty(ws: Any, row: int, col: int) -> bool:
    value = ws.cell(row=row, column=col).value
    return value is not None and str(value).strip() != ""


def analyze_workbook(path: Path, mode_id: int) -> dict[str, Any]:
    wb = openpyxl.load_workbook(path, data_only=True)
    ws = wb.active
    result: dict[str, Any] = {
        "file": str(path),
        "sheet": ws.title,
        "mode_id": mode_id,
        "max_row": ws.max_row,
        "max_column": ws.max_column,
        "issues": [],
    }
    headers = [ws.cell(row=6, column=col).value for col in range(1, min(ws.max_column, 20) + 1)]
    result["headers_row_6"] = ["" if h is None else str(h).strip() for h in headers]

    last_data_row = DATA_START_ROW - 1
    for row in range(DATA_START_ROW, ws.max_row + 1):
        if any(cell_nonempty(ws, row, col) for col in SIGNIFICANT_COLS):
            last_data_row = row
    data_rows = max(0, last_data_row - DATA_START_ROW + 1)
    result["data_rows"] = data_rows
    result["last_data_row"] = last_data_row if data_rows else None

    counts = {
        "number": 0,
        "quantity": 0,
        "weight": 0,
        "path": 0,
        "dimensions": 0,
    }
    for row in range(DATA_START_ROW, last_data_row + 1):
        if cell_nonempty(ws, row, COL_NUM):
            counts["number"] += 1
        if cell_nonempty(ws, row, COL_QTY):
            counts["quantity"] += 1
        if cell_nonempty(ws, row, COL_WEIGHT):
            counts["weight"] += 1
        if cell_nonempty(ws, row, COL_PATH):
            counts["path"] += 1
        if cell_nonempty(ws, row, COL_DIMS):
            counts["dimensions"] += 1
    result["counts"] = counts
    result["has_images"] = bool(getattr(ws, "_images", []))

    if data_rows == 0 and mode_id not in (7, 8):
        result["issues"].append("no data rows")
    elif data_rows == 0:
        result["filter_empty"] = True
    else:
        for key, label in (
            ("number", "№ п/п"),
            ("quantity", "Кол-во"),
            ("weight", "Масса ед. кг"),
            ("path", "Путь"),
            ("dimensions", "Габаритные размеры"),
        ):
            if counts[key] < data_rows:
                result["issues"].append(f"{label} partially filled: {counts[key]}/{data_rows}")
    if mode_id in (5, 6) and not result["has_images"]:
        result["issues"].append("expected embedded images for sketch mode")
    wb.close()
    return result


def validate_cross_mode(modes: list[dict[str, Any]], strict_filters: bool) -> list[str]:
    issues: list[str] = []
    by_id = {m["mode_id"]: m for m in modes}
    if set(by_id) >= set(range(1, 9)):
        rows = {mid: by_id[mid]["analysis"]["data_rows"] for mid in range(1, 9)}
        if rows[3] >= rows[1]:
            issues.append(f"mode 3 top-level rows {rows[3]} must be less than mode 1 rows {rows[1]}")
        if rows[5] != rows[1]:
            issues.append(f"mode 5 rows {rows[5]} must match mode 1 rows {rows[1]}")
        if rows[6] != rows[2]:
            issues.append(f"mode 6 rows {rows[6]} must match mode 2 rows {rows[2]}")
        for mid in (7, 8):
            if rows[mid] == rows[1]:
                issues.append(f"mode {mid} filter rows equal summary rows; filter was not applied")
            if strict_filters and rows[mid] <= 0:
                issues.append(f"mode {mid} strict filter returned zero rows")
    return issues


def export_mode(app: Any, main: Any, mode_id: int, mode_name: str, target: Path, timeout: float) -> dict[str, Any]:
    open_export_menu(main)
    invoke_by_text(main, mode_name, {"MenuItem"}, timeout=8.0)
    dialog = wait_for_save_dialog(timeout=timeout)
    set_save_dialog_path(dialog, target)
    click_dialog_button(dialog, ["Сохранить", "Save"], timeout=8.0)
    handle_overwrite_confirmation(timeout=2.0)
    wait_for_file(target, timeout=timeout)
    modal = dismiss_export_modal(timeout=10.0)
    return {
        "mode_id": mode_id,
        "name": mode_name,
        "file": str(target),
        "size": target.stat().st_size,
        "sha256": sha256(target),
        "modal": modal,
    }


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    sys.stderr.reconfigure(encoding="utf-8", errors="replace")
    parser = argparse.ArgumentParser()
    parser.add_argument("--runtime-dir", required=True)
    parser.add_argument("--report-dir", required=True)
    parser.add_argument("--export-dir")
    parser.add_argument("--expected-exe-sha256")
    parser.add_argument("--expected-dll-sha256")
    parser.add_argument("--expected-mode-count", type=int, default=8)
    parser.add_argument("--modes", default="1,2,3,4,5,6,7,8")
    parser.add_argument("--strict-filters", action="store_true")
    parser.add_argument("--timeout", type=float, default=90.0)
    args = parser.parse_args()

    normalize_env()
    runtime_dir = Path(args.runtime_dir).resolve()
    report_dir = Path(args.report_dir).resolve()
    export_dir = Path(args.export_dir).resolve() if args.export_dir else report_dir / "exports"
    report_dir.mkdir(parents=True, exist_ok=True)
    export_dir.mkdir(parents=True, exist_ok=True)
    result_path = report_dir / "s8-bom-result.json"

    mode_ids = [int(part) for part in re.split(r"[,; ]+", args.modes.strip()) if part]
    selected_modes = [item for item in MODES if item[0] in mode_ids]
    result: dict[str, Any] = {
        "status": "FAIL",
        "runtime_dir": str(runtime_dir),
        "report_dir": str(report_dir),
        "export_dir": str(export_dir),
        "expected_mode_count": args.expected_mode_count,
        "strict_filters": bool(args.strict_filters),
        "modes": [],
        "issues": [],
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

        proc = find_runtime_process(runtime_dir)
        result["swtools_pid"] = proc.pid
        result["swtools_path"] = proc.exe()
        result["swtools_command_line"] = process_command_line(proc.pid)
        app = Application(backend="uia").connect(process=proc.pid)
        main = largest_window(app)

        for mode_id, mode_name, slug in selected_modes:
            target = export_dir / f"{slug}.xlsx"
            if target.exists():
                target.unlink()
            exported = export_mode(app, main, mode_id, mode_name, target, timeout=args.timeout)
            analysis = analyze_workbook(target, mode_id)
            exported["analysis"] = analysis
            result["modes"].append(exported)

        if len(result["modes"]) != args.expected_mode_count:
            result["issues"].append(
                f"exported mode count {len(result['modes'])} != expected {args.expected_mode_count}"
            )
        for mode in result["modes"]:
            for issue in mode["analysis"].get("issues", []):
                result["issues"].append(f"mode {mode['mode_id']}: {issue}")
        result["issues"].extend(validate_cross_mode(result["modes"], strict_filters=args.strict_filters))

        result["status"] = "PASS" if not result["issues"] else "FAIL"
        result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
        print(json.dumps(result, ensure_ascii=False, indent=2))
        return 0 if result["status"] == "PASS" else 1
    except Exception as exc:
        result["error"] = str(exc)
        result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
        print(str(exc), file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(run())
