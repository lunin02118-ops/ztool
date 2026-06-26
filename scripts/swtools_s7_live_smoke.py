#!/usr/bin/env python3
"""Live SolidWorks S7 smoke for SWTools source-built runtime.

This is a manual-machine gate.  It proves the full path:

SolidWorks model -> ZTool.SwAddin.openZtool(0) -> SWTools.exe ->
object-driven "Демо" (if shown) -> object-driven "Подключить SW" -> grid rows.

No coordinate click is accepted.  If UIA/legacy/Win32 object invocation is
unavailable, the test fails instead of pretending the command was tested.
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


def write_checkpoint(result_path: Path, result: dict[str, Any]) -> None:
    result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")


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


def receiver_windows(solidworks_pid: int) -> list[dict[str, Any]]:
    matches: list[dict[str, Any]] = []

    def enum_proc(hwnd: int, _: Any) -> bool:
        try:
            title = win32gui.GetWindowText(hwnd)
            if title != "Ztool_Receiver":
                return True
            _, pid = win32process.GetWindowThreadProcessId(hwnd)
            if int(pid) != int(solidworks_pid):
                return True
            matches.append(
                {
                    "hwnd": int(hwnd),
                    "process_id": int(pid),
                    "class_name": win32gui.GetClassName(hwnd),
                    "title": title,
                    "is_window": bool(win32gui.IsWindow(hwnd)),
                }
            )
        except Exception:
            pass
        return True

    try:
        win32gui.EnumWindows(enum_proc, None)
    except Exception:
        pass
    return matches


def restore_window(hwnd: int) -> None:
    if win32gui.IsIconic(hwnd):
        win32gui.ShowWindow(hwnd, win32con.SW_RESTORE)
    else:
        win32gui.ShowWindow(hwnd, win32con.SW_SHOWNORMAL)
    try:
        win32gui.SetForegroundWindow(hwnd)
    except Exception:
        pass


def top_window_handles_for_pid(process_id: int, include_hidden: bool = True) -> list[int]:
    handles: list[int] = []

    def enum_proc(hwnd: int, _: Any) -> bool:
        try:
            _, pid = win32process.GetWindowThreadProcessId(hwnd)
            if pid == process_id and (include_hidden or win32gui.IsWindowVisible(hwnd)):
                handles.append(hwnd)
        except Exception:
            pass
        return True

    win32gui.EnumWindows(enum_proc, None)
    return handles


def top_windows_for_pid(process_id: int) -> list[dict[str, Any]]:
    windows: list[dict[str, Any]] = []
    for hwnd in top_window_handles_for_pid(process_id):
        try:
            rect = win32gui.GetWindowRect(hwnd)
            windows.append(
                {
                    "hwnd": hwnd,
                    "visible": bool(win32gui.IsWindowVisible(hwnd)),
                    "class_name": win32gui.GetClassName(hwnd),
                    "title": win32gui.GetWindowText(hwnd),
                    "rectangle": {
                        "left": rect[0],
                        "top": rect[1],
                        "right": rect[2],
                        "bottom": rect[3],
                    },
                }
            )
        except Exception:
            continue
    return windows


def find_swtools_main_window(process_id: int) -> int | None:
    candidates: list[tuple[int, int]] = []
    fallback_candidates: list[tuple[int, int]] = []
    for item in top_windows_for_pid(process_id):
        title = str(item.get("title") or "")
        class_name = str(item.get("class_name") or "")
        rect = item.get("rectangle") or {}
        width = int(rect.get("right", 0)) - int(rect.get("left", 0))
        height = int(rect.get("bottom", 0)) - int(rect.get("top", 0))
        if "WindowsForms10.Window" not in class_name:
            continue
        area = width * height
        if area <= 100_000:
            continue
        if title.startswith("SWTools"):
            candidates.append((area, int(item["hwnd"])))
        elif title != "Параметры":
            fallback_candidates.append((area, int(item["hwnd"])))
    if not candidates:
        candidates = fallback_candidates
    if not candidates:
        return None
    return sorted(candidates, reverse=True)[0][1]


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
        windows: list[Any] = []
        for hwnd in top_window_handles_for_pid(process_id):
            try:
                windows.append(desktop.window(handle=hwnd))
            except Exception:
                continue
        return windows
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


def window_area(win: Any) -> int:
    try:
        rect = win.rectangle()
        return max(0, int(rect.width())) * max(0, int(rect.height()))
    except Exception:
        return 0


def hwnd_area(hwnd: int) -> int:
    try:
        left, top, right, bottom = win32gui.GetWindowRect(hwnd)
        return max(0, int(right - left)) * max(0, int(bottom - top))
    except Exception:
        return 0


def should_scan_for_license_hwnd(hwnd: int) -> bool:
    try:
        title = win32gui.GetWindowText(hwnd).strip()
        class_name = win32gui.GetClassName(hwnd)
    except Exception:
        return False
    if class_name in {"tooltips_class32", "GDI+ Hook Window Class", "IME", "ComboLBox", "MSCTFIME UI"}:
        return False
    if class_name.startswith(".NET-BroadcastEventWindow"):
        return False
    area = hwnd_area(hwnd)
    if title.startswith("SWTools") and area > 250_000:
        return False
    if class_name == "#32770":
        return True
    if "WindowsForms10.Window" in class_name and area <= 250_000:
        return True
    return False


def win32_child_texts(hwnd: int) -> list[dict[str, Any]]:
    texts: list[dict[str, Any]] = []

    def enum_child(child_hwnd: int, _: Any) -> bool:
        try:
            text = win32gui.GetWindowText(child_hwnd).strip()
            class_name = win32gui.GetClassName(child_hwnd)
            if text:
                texts.append({"hwnd": int(child_hwnd), "class_name": class_name, "text": text})
        except Exception:
            pass
        return True

    try:
        win32gui.EnumChildWindows(hwnd, enum_child, None)
    except Exception:
        pass
    return texts


def win32_dialog_texts(hwnd: int) -> list[str]:
    texts: list[str] = []
    try:
        title = win32gui.GetWindowText(hwnd).strip()
        if title:
            texts.append(title)
    except Exception:
        pass
    texts.extend(item["text"] for item in win32_child_texts(hwnd))
    return texts


def click_win32_dialog_button(hwnd: int, names: list[str]) -> str:
    expected = {normalize_button_text(name): name for name in names}
    for item in win32_child_texts(hwnd):
        text = normalize_button_text(str(item.get("text") or ""))
        class_name = str(item.get("class_name") or "")
        if text not in expected:
            continue
        if class_name != "Button" and "BUTTON" not in class_name.upper():
            continue
        button_hwnd = int(item["hwnd"])
        win32gui.PostMessage(button_hwnd, 0x00F5, 0, 0)  # BM_CLICK
        return expected[text]
    raise RuntimeError(f"Cannot find dialog button from {names!r}")


def should_scan_for_license_dialog(win: Any) -> bool:
    try:
        title = win.window_text().strip()
    except Exception:
        title = ""
    try:
        class_name = win.class_name()
    except Exception:
        class_name = ""
    if class_name in {"tooltips_class32", "GDI+ Hook Window Class", "IME"}:
        return False
    if class_name.startswith(".NET-BroadcastEventWindow"):
        return False
    area = window_area(win)
    # The main SWTools form can expose a very large WinForms descendants tree and
    # occasionally blocks automation traversal. License/trial prompts are small
    # top-level forms/dialogs, so never scan the main window here.
    if title.startswith("SWTools") and area > 250_000:
        return False
    if class_name == "#32770":
        return True
    if "WindowsForms10.Window" in class_name and area <= 250_000:
        return True
    return False


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
            for action in ("post", "invoke", "legacy", "send"):
                try:
                    if action == "send":
                        child.send_message(0x00F5, 0, 0)  # BM_CLICK
                    elif action == "post":
                        child.post_message(0x00F5, 0, 0)
                    elif action == "invoke":
                        child.invoke()
                    elif action == "legacy":
                        child.iface_invoke.Invoke()
                    return expected[text]
                except Exception:
                    continue
        time.sleep(0.05)
    raise RuntimeError(f"Cannot find dialog button from {names!r}")


def dismiss_license_dialog_win32(swtools_pid: int, timeout: float = 8.0) -> dict[str, Any]:
    deadline = time.time() + timeout
    last: dict[str, Any] = {"found": False, "dismissed": False, "text": ""}
    while time.time() < deadline:
        for hwnd in top_window_handles_for_pid(swtools_pid):
            if not should_scan_for_license_hwnd(hwnd):
                continue
            texts = win32_dialog_texts(hwnd)
            joined = "\n".join(texts)
            lowered = joined.lower()
            if "лицензия не обнаружена" not in lowered and "license" not in lowered:
                continue
            if "демо" not in lowered and "проба" not in lowered and "demo" not in lowered:
                continue
            try:
                title = win32gui.GetWindowText(hwnd).strip()
                class_name = win32gui.GetClassName(hwnd)
            except Exception:
                title = ""
                class_name = ""
            last = {
                "found": True,
                "dismissed": False,
                "backend": "win32-fast",
                "hwnd": int(hwnd),
                "title": title,
                "class_name": class_name,
                "process_id": swtools_pid,
                "text": joined[:2000],
            }
            button = click_win32_dialog_button(hwnd, ["Демо", "Проба", "Demo"])
            close_deadline = time.time() + 3.0
            while time.time() < close_deadline:
                still_open = False
                for check_hwnd in top_window_handles_for_pid(swtools_pid):
                    if not should_scan_for_license_hwnd(check_hwnd):
                        continue
                    check_text = "\n".join(win32_dialog_texts(check_hwnd)).lower()
                    if "лицензия не обнаружена" in check_text:
                        still_open = True
                        break
                if not still_open:
                    last.update({"dismissed": True, "button": button})
                    return last
                time.sleep(0.05)
            last.update({"button": button})
            return last
        time.sleep(0.05)
    return last


def dismiss_license_dialog(swtools_pid: int, timeout: float = 8.0) -> dict[str, Any]:
    return dismiss_license_dialog_win32(swtools_pid, timeout=timeout)


def blocking_dialog(swtools_pid: int | None, solidworks_pid: int) -> dict[str, Any] | None:
    owners: list[tuple[int, str]] = [(solidworks_pid, "SolidWorks")]
    if swtools_pid is not None:
        owners.append((swtools_pid, "SWTools"))
    for backend in ("win32", "uia"):
        for pid, owner in owners:
            if owner == "SolidWorks" and backend == "uia":
                continue
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


def summarize_dialog(dialog: dict[str, Any]) -> dict[str, Any]:
    return {
        "owner": dialog.get("owner"),
        "backend": dialog.get("backend"),
        "process_id": dialog.get("process_id"),
        "title": dialog.get("title"),
        "class_name": dialog.get("class_name"),
        "text": str(dialog.get("text") or "")[:800],
    }


def compact_text(text: str) -> str:
    return re.sub(r"\s+", " ", text).strip().lower()


def is_solidworks_transient_model_loading_dialog(dialog: dict[str, Any] | None) -> bool:
    if not dialog or dialog.get("owner") != "SolidWorks":
        return False
    text = compact_text(str(dialog.get("text") or ""))
    if not text:
        return False
    if "тайм-аут соединения" in text or "connection timeout" in text:
        return False
    exact_markers = (
        "загружается файл:",
        "loading file:",
        "обновление сборки",
        "updating assembly",
        "обновление графики",
        "updating graphics",
    )
    if any(marker in text for marker in exact_markers):
        return True
    word_groups = (
        ("открытие", "компонентов"),
        ("opening", "components"),
        ("процесс", "загруз"),
    )
    return any(all(word in text for word in group) for group in word_groups)


def active_model_path(sw: Any) -> str:
    try:
        active = sw.ActiveDoc
        if active is None:
            return ""
        return str(call_or_value(active, "GetPathName"))
    except Exception:
        return ""


def wait_for_solidworks_model_ready(
    sw: Any,
    model_path: Path,
    solidworks_pid: int,
    timeout: float,
    quiet_seconds: float = 1.5,
) -> dict[str, Any]:
    started = time.time()
    deadline = started + timeout
    model_norm = str(model_path.resolve()).lower()
    evidence: dict[str, Any] = {
        "status": "FAIL",
        "model": str(model_path),
        "timeout_seconds": timeout,
        "quiet_seconds": quiet_seconds,
        "transient_dialog_count": 0,
        "transient_dialogs": [],
        "polls": 0,
    }
    stable_since: float | None = None
    last_active = ""

    while time.time() < deadline:
        evidence["polls"] += 1
        last_active = active_model_path(sw)
        active_matches = last_active.lower() == model_norm
        blocker = blocking_dialog(None, solidworks_pid)
        if blocker:
            if is_solidworks_transient_model_loading_dialog(blocker):
                evidence["transient_dialog_count"] += 1
                samples = evidence["transient_dialogs"]
                if len(samples) < 8:
                    sample = summarize_dialog(blocker)
                    sample["seen_at_seconds"] = round(time.time() - started, 3)
                    samples.append(sample)
                stable_since = None
                time.sleep(0.25)
                continue
            evidence["blocking_dialog"] = summarize_dialog(blocker)
            evidence["active_model"] = last_active
            evidence["waited_seconds"] = round(time.time() - started, 3)
            return evidence

        if active_matches:
            if stable_since is None:
                stable_since = time.time()
            stable_for = time.time() - stable_since
            if stable_for >= quiet_seconds:
                evidence.update(
                    {
                        "status": "PASS",
                        "active_model": last_active,
                        "stable_for_seconds": round(stable_for, 3),
                        "waited_seconds": round(time.time() - started, 3),
                    }
                )
                return evidence
        else:
            stable_since = None
        time.sleep(0.25)

    evidence["active_model"] = last_active
    evidence["waited_seconds"] = round(time.time() - started, 3)
    evidence["error"] = "Timed out waiting for SolidWorks active model without transient loading dialogs"
    return evidence


def is_solidworks_connection_timeout_dialog(dialog: dict[str, Any] | None) -> bool:
    if not dialog or dialog.get("owner") != "SolidWorks":
        return False
    text = str(dialog.get("text") or "").lower()
    return "тайм-аут соединения" in text or "connection timeout" in text


def dismiss_solidworks_connection_timeout(solidworks_pid: int) -> dict[str, Any] | None:
    for backend in ("win32", "uia"):
        for win in desktop_windows(backend, process_id=solidworks_pid):
            texts = dialog_texts(win)
            joined = "\n".join(texts)
            lowered = joined.lower()
            if "тайм-аут соединения" not in lowered and "connection timeout" not in lowered:
                continue
            try:
                title = win.window_text().strip()
                class_name = win.class_name()
            except Exception:
                title = ""
                class_name = ""
            if class_name != "#32770" and title != "Информация":
                continue
            button = click_dialog_button(win, ["ОК", "OK"], timeout=0.8)
            return {
                "owner": "SolidWorks",
                "backend": backend,
                "process_id": solidworks_pid,
                "title": title,
                "class_name": class_name,
                "text": joined[:2000],
                "button": button,
            }
    return None


def record_dismissed_connection_timeout(result: dict[str, Any], dialog: dict[str, Any]) -> None:
    dismissed = result.setdefault("dismissed_connection_timeout_dialogs", [])
    if isinstance(dismissed, list):
        dismissed.append(dialog)


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
        try:
            windows = app.windows()
        except Exception:
            windows = [app]
        for win in windows:
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


def invoke_connect(main: Any) -> dict[str, Any]:
    restore_window(main.handle)
    main.set_focus()
    attempts: list[dict[str, Any]] = []
    for child in main.descendants(control_type="SplitButton"):
        try:
            if child.window_text().strip() != "Подключить SW":
                continue
            props = child.legacy_properties()
            if props.get("DefaultAction") != "Нажать":
                continue
            rect = child.rectangle()
            base = {
                "control_type": child.element_info.control_type,
                "default_action": props.get("DefaultAction"),
                "value": props.get("Value"),
                "rectangle": {
                    "left": rect.left,
                    "top": rect.top,
                    "right": rect.right,
                    "bottom": rect.bottom,
                },
            }
            for action in ("invoke", "legacy_invoke"):
                attempt = dict(base)
                attempt["action"] = action
                try:
                    if action == "invoke":
                        child.invoke()
                    else:
                        child.iface_invoke.Invoke()
                    attempt["status"] = "PASS"
                    attempts.append(attempt)
                    return {"status": "PASS", "attempts": attempts}
                except Exception as exc:
                    attempt["status"] = "FAIL"
                    attempt["error"] = str(exc)
                    attempts.append(attempt)
        except Exception:
            continue
    return {"status": "FAIL", "attempts": attempts, "error": "Cannot invoke top SplitButton 'Подключить SW'"}


def invoke_connect_async(main: Any) -> dict[str, Any]:
    state: dict[str, Any] = {"done": False, "error": ""}

    def worker() -> None:
        try:
            state["result"] = invoke_connect(main)
            if state["result"].get("status") != "PASS":
                raise RuntimeError(str(state["result"].get("error") or "connect invoke failed"))
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
        model_ready_gate = wait_for_solidworks_model_ready(sw, model, solidworks_pid, args.timeout)
        result["model_ready_gate"] = model_ready_gate
        if model_ready_gate.get("status") != "PASS":
            raise RuntimeError(f"SolidWorks model-ready gate failed: {model_ready_gate}")
        result["checks"].append("SolidWorks model-ready gate passed before openZtool")
        addin = call_or_value(sw, "GetAddInObject", "ZTool.SwAddin")
        if not addin:
            raise RuntimeError("SolidWorks returned no ZTool.SwAddin object")
        result["checks"].append("addin object ok")
        write_checkpoint(result_path, result)

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
                if is_solidworks_transient_model_loading_dialog(blocker):
                    late_transients = result.setdefault("late_transient_model_loading_dialogs", [])
                    if isinstance(late_transients, list) and len(late_transients) < 8:
                        late_transients.append(summarize_dialog(blocker))
                    time.sleep(0.25)
                    continue
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
        result["receiver_windows_after_launch"] = receiver_windows(solidworks_pid)
        if not result["receiver_windows_after_launch"]:
            raise RuntimeError("SolidWorks add-in receiver window Ztool_Receiver was not found after launch")
        result["swtools_windows_after_launch"] = top_windows_for_pid(proc.pid)
        main_hwnd = find_swtools_main_window(proc.pid)
        if main_hwnd is None:
            raise RuntimeError(f"SWTools main window was not found for process {proc.pid}")
        result["swtools_main_hwnd"] = main_hwnd
        restore_window(main_hwnd)
        write_checkpoint(result_path, result)

        license_result = dismiss_license_dialog(proc.pid, timeout=10.0)
        result["license_dialog"] = license_result
        if license_result.get("found") and not license_result.get("dismissed"):
            raise RuntimeError(f"License dialog was not dismissed: {license_result}")
        if license_result.get("dismissed"):
            result["checks"].append("trial dialog dismissed through object automation")
        else:
            result["checks"].append("license/trial dialog not shown; skipping demo button probe")
        main = Desktop(backend="uia").window(handle=main_hwnd)
        restore_window(main_hwnd)
        write_checkpoint(result_path, result)
        blocker = blocking_dialog(proc.pid, solidworks_pid)
        if blocker:
            if is_solidworks_connection_timeout_dialog(blocker):
                dismissed = dismiss_solidworks_connection_timeout(solidworks_pid)
                if dismissed:
                    result["dismissed_blocking_dialog"] = dismissed
                    blocker = None
            if blocker:
                result["blocking_dialog"] = blocker
                raise RuntimeError(f"Blocking dialog before connect: {blocker}")
        if result.get("dismissed_blocking_dialog"):
            result["checks"].append("SolidWorks connection timeout dialog dismissed after runtime launch")
        connect_state = invoke_connect_async(main)
        result["connect_invoke"] = dict(connect_state)
        result["checks"].append("connect invoked through UIA worker")
        write_checkpoint(result_path, result)

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
                if is_solidworks_connection_timeout_dialog(blocker):
                    dismissed = dismiss_solidworks_connection_timeout(solidworks_pid)
                    if dismissed:
                        record_dismissed_connection_timeout(result, dismissed)
                        continue
                result["blocking_dialog"] = blocker
                raise RuntimeError(f"Blocking dialog during S7 connect: {blocker}")
            dismiss_license_dialog(proc.pid, timeout=0.1)
            result["last_poll_at"] = round(time.time(), 3)
            write_checkpoint(result_path, result)
            last_texts = visible_texts(main)
            last_status = parse_status(last_texts)
            last_count = parse_row_count(last_status, last_texts)
            if "Подключение завершено" in last_status or last_count >= args.expected_min_rows:
                break

        result["status_text"] = last_status
        result["row_count"] = last_count
        result["receiver_windows_after_connect"] = receiver_windows(solidworks_pid)
        write_checkpoint(result_path, result)
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
    exit_code = run()
    sys.stdout.flush()
    sys.stderr.flush()
    os._exit(exit_code)
