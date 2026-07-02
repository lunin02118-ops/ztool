#!/usr/bin/env python3
"""Execute object-driven visual openers and capture SWTools UI evidence.

This is a live-machine helper for the L-01..L-15 visual localization profile.
It deliberately refuses screen coordinates: every action must resolve a window
or control through process/title/text metadata from the opener profile.
"""

from __future__ import annotations

import argparse
import ctypes
import importlib
import json
import subprocess
import sys
import tempfile
import time
from pathlib import Path
from typing import Any


def require_module(name: str) -> Any:
    try:
        return importlib.import_module(name)
    except ImportError as exc:
        raise SystemExit(f"Missing Python module {name!r}. Install E2E deps first.") from exc


psutil = require_module("psutil")
pywinauto = require_module("pywinauto")
Desktop = pywinauto.Desktop
keyboard = require_module("pywinauto.keyboard")
win32gui = require_module("win32gui")

WM_LBUTTONDOWN = 0x0201
WM_LBUTTONUP = 0x0202
WM_RBUTTONDOWN = 0x0204
WM_RBUTTONUP = 0x0205
WM_CONTEXTMENU = 0x007B
BM_CLICK = 0x00F5
MK_LBUTTON = 0x0001
MK_RBUTTON = 0x0002
SW_MAXIMIZE = 3


def norm(text: str) -> str:
    return " ".join((text or "").split())


def load_json(path: Path) -> dict[str, Any]:
    return json.loads(path.read_text(encoding="utf-8"))


def process_names(locator: dict[str, Any]) -> set[str]:
    names: set[str] = set()
    if locator.get("process"):
        names.add(str(locator["process"]).lower())
    for value in locator.get("process_names", []) or []:
        names.add(str(value).lower())
    return {name for name in names if name}


def process_info(pid: int) -> dict[str, Any]:
    try:
        proc = psutil.Process(pid)
        return {
            "pid": pid,
            "name": proc.name(),
            "exe": proc.exe(),
            "cmdline": proc.cmdline(),
        }
    except Exception as exc:
        return {"pid": pid, "error": str(exc)}


def window_process_id(win: Any) -> int | None:
    try:
        return int(win.process_id())
    except Exception:
        pass
    try:
        return int(win.element_info.process_id)
    except Exception:
        return None


def window_title(win: Any) -> str:
    try:
        return norm(win.window_text())
    except Exception:
        return ""


def window_handle(win: Any) -> int | None:
    try:
        handle = int(win.handle)
        return handle if handle else None
    except Exception:
        return None


def window_visible(win: Any) -> bool:
    try:
        return bool(win.is_visible())
    except Exception:
        pass
    handle = window_handle(win)
    if handle is None:
        return True
    try:
        return bool(win32gui.IsWindowVisible(handle))
    except Exception:
        return True


def win32_child_texts(hwnd: int | None, limit: int = 400) -> list[str]:
    if hwnd is None:
        return []
    texts: list[str] = []

    def enum_child(child_hwnd: int, _: Any) -> bool:
        if len(texts) >= limit:
            return False
        try:
            text = norm(win32gui.GetWindowText(child_hwnd))
        except Exception:
            text = ""
        if text:
            texts.append(text)
        return True

    try:
        win32gui.EnumChildWindows(hwnd, enum_child, None)
    except Exception:
        return texts
    return texts


def control_handle(control: Any) -> int | None:
    try:
        handle = int(control.handle)
        return handle if handle else None
    except Exception:
        return None


def control_visible(control: Any) -> bool:
    try:
        if hasattr(control, "is_visible") and not control.is_visible():
            return False
    except Exception:
        pass
    try:
        rect = control.rectangle()
        if int(rect.width()) <= 0 or int(rect.height()) <= 0:
            return False
    except Exception:
        pass
    return True


def control_click_point(width: int, height: int, locator: dict[str, Any] | None = None) -> tuple[int, int]:
    locator = locator or {}
    anchor = norm(str(locator.get("control_click_anchor", ""))).lower()
    if anchor == "left_text":
        margin = int(locator.get("control_click_margin", 8) or 8)
        x = max(1, min(width - 1, margin))
    else:
        x = max(1, min(width - 1, width // 2))
    y = max(1, min(height - 1, height // 2))
    return x, y


def win32_message_click(control: Any, locator: dict[str, Any] | None = None) -> bool:
    """Click an object-located WinForms control by HWND, not screen coords."""
    handle = control_handle(control)
    if handle is None:
        return False
    try:
        rect = control.rectangle()
        width = max(1, int(rect.width()))
        height = max(1, int(rect.height()))
    except Exception:
        width = 8
        height = 8
    x, y = control_click_point(width, height, locator)
    lparam = (y << 16) | (x & 0xFFFF)
    user32 = ctypes.windll.user32
    user32.SendMessageW(handle, WM_LBUTTONDOWN, MK_LBUTTON, lparam)
    user32.SendMessageW(handle, WM_LBUTTONUP, 0, lparam)
    return True


def win32_button_click(control: Any) -> bool:
    """Invoke an object-located WinForms button by HWND command message."""
    handle = control_handle(control)
    if handle is None:
        return False
    ctypes.windll.user32.SendMessageW(handle, BM_CLICK, 0, 0)
    return True


def win32_message_context_menu(control: Any, locator: dict[str, Any] | None = None) -> str | None:
    """Open a context menu on an object-located WinForms control by HWND."""
    handle = control_handle(control)
    if handle is None:
        return None
    try:
        rect = control.rectangle()
        width = max(1, int(rect.width()))
        height = max(1, int(rect.height()))
    except Exception:
        width = 8
        height = 8
    x, y = control_click_point(width, height, locator)
    client_lparam = (y << 16) | (x & 0xFFFF)
    user32 = ctypes.windll.user32

    class POINT(ctypes.Structure):
        _fields_ = [("x", ctypes.c_long), ("y", ctypes.c_long)]

    point = POINT(x, y)
    try:
        if user32.ClientToScreen(handle, ctypes.byref(point)):
            screen_lparam = (int(point.y) << 16) | (int(point.x) & 0xFFFF)
            user32.SendMessageW(handle, WM_CONTEXTMENU, handle, screen_lparam)
            return "win32_context_menu"
    except Exception:
        pass

    user32.SendMessageW(handle, WM_RBUTTONDOWN, MK_RBUTTON, client_lparam)
    user32.SendMessageW(handle, WM_RBUTTONUP, 0, client_lparam)
    return "win32_right_button_message"


def backend_peers(win: Any) -> list[Any]:
    peers = [win]
    handle = window_handle(win)
    if handle is None:
        return peers
    for backend in ("win32", "uia"):
        try:
            peer = Desktop(backend=backend).window(handle=handle)
        except Exception:
            continue
        peers.append(peer)
    return peers


def control_search_roots(win: Any, locator: dict[str, Any]) -> list[Any]:
    handle = window_handle(win)
    if handle is None or not locator.get("control_click_anchor"):
        return backend_peers(win)
    roots: list[Any] = []
    for backend in ("win32", "uia"):
        try:
            roots.append(Desktop(backend=backend).window(handle=handle))
        except Exception:
            continue
    roots.append(win)
    return roots


def visible_texts(win: Any, limit: int = 400) -> list[str]:
    texts: list[str] = []
    try:
        children = win.descendants()
    except Exception:
        children = []
    for child in children:
        if len(texts) >= limit:
            break
        try:
            text = norm(child.window_text())
        except Exception:
            continue
        if text:
            texts.append(text)
    handle = window_handle(win)
    for text in win32_child_texts(handle, limit=limit):
        if len(texts) >= limit:
            break
        if text:
            texts.append(text)
    return texts


def visible_texts_all_backends(win: Any, limit: int = 800) -> list[str]:
    texts: list[str] = []
    seen: set[str] = set()
    for peer in backend_peers(win):
        for text in [window_title(peer), *visible_texts(peer, limit=limit)]:
            if not text or text in seen:
                continue
            seen.add(text)
            texts.append(text)
            if len(texts) >= limit:
                return texts
    return texts


def pid_matches(pid: int | None, locator: dict[str, Any]) -> bool:
    wanted = process_names(locator)
    if not wanted:
        return True
    if pid is None:
        return False
    try:
        return psutil.Process(pid).name().lower() in wanted
    except Exception:
        return False


def locator_matches_window(win: Any, locator: dict[str, Any], include_text: bool = True) -> bool:
    if not window_visible(win):
        return False
    pid = window_process_id(win)
    if not pid_matches(pid, locator):
        return False
    title = window_title(win)
    window_contains = norm(str(locator.get("window_contains", "")))
    if window_contains and window_contains.lower() not in title.lower():
        return False
    text_contains = [norm(str(value)) for value in locator.get("text_contains", []) or [] if norm(str(value))]
    expected_window_text = norm(str(locator.get("expected_window_text", "")))
    if expected_window_text:
        text_contains.append(expected_window_text)
    if text_contains and include_text:
        haystack = "\n".join([title, *visible_texts(win)])
        if not all(value.lower() in haystack.lower() for value in text_contains):
            return False
    return True


def desktop_windows(backend: str, locator: dict[str, Any]) -> list[Any]:
    names = process_names(locator)
    pids: list[int] = []
    if names:
        for proc in psutil.process_iter(["pid", "name"]):
            try:
                if (proc.info.get("name") or "").lower() in names:
                    pids.append(int(proc.info["pid"]))
            except (psutil.NoSuchProcess, psutil.AccessDenied):
                continue
    desktop = Desktop(backend=backend)
    windows: list[Any] = []
    if pids:
        for pid in pids:
            try:
                windows.extend(desktop.windows(process=pid))
            except Exception:
                continue
    else:
        try:
            windows.extend(desktop.windows())
        except Exception:
            pass
    return windows


def wait_window(locator: dict[str, Any], timeout: float) -> Any:
    deadline = time.time() + timeout
    last_titles: list[str] = []
    while time.time() < deadline:
        for backend in ("uia", "win32"):
            for win in desktop_windows(backend, locator):
                title = window_title(win)
                if title:
                    last_titles.append(title)
                if locator_matches_window(win, locator):
                    return win
        time.sleep(0.2)
    sample = ", ".join(sorted(set(last_titles))[:30])
    raise RuntimeError(f"Window not found for locator {locator!r}; seen: {sample}")


def should_maximize_for_locator(locator: dict[str, Any]) -> bool:
    window_contains = norm(str(locator.get("window_contains", ""))).lower()
    return "swtools" in window_contains and "swtools.exe" in process_names(locator)


def maximize_window(win: Any) -> bool:
    try:
        win.maximize()
        return True
    except Exception:
        pass
    try:
        transform = win.iface_transform
        if transform.CurrentCanMaximize:
            transform.Maximize()
            return True
    except Exception:
        pass
    handle = window_handle(win)
    if handle is not None:
        try:
            ctypes.windll.user32.ShowWindow(handle, SW_MAXIMIZE)
            return True
        except Exception:
            pass
    return False


def control_text_candidates(locator: dict[str, Any]) -> list[str]:
    values: list[str] = []
    if locator.get("control_text"):
        values.append(str(locator["control_text"]))
    values.extend(str(value) for value in locator.get("control_text_any", []) or [])
    return [norm(value) for value in values if norm(value)]


def control_type_matches(child: Any, locator: dict[str, Any]) -> bool:
    wanted = {str(value) for value in locator.get("control_type_any", []) or [] if str(value).strip()}
    if not wanted:
        return True
    try:
        control_type = str(child.element_info.control_type)
    except Exception:
        control_type = ""
    return control_type in wanted


def control_type_name(child: Any) -> str:
    try:
        return str(child.element_info.control_type)
    except Exception:
        return ""


def find_control(root: Any, locator: dict[str, Any], timeout: float) -> Any:
    wanted_texts = control_text_candidates(locator)
    deadline = time.time() + timeout
    seen: list[str] = []
    while time.time() < deadline:
        for peer in control_search_roots(root, locator):
            try:
                descendants = peer.descendants()
            except Exception:
                descendants = []
            for child in descendants:
                if not control_visible(child):
                    continue
                try:
                    text = norm(child.window_text())
                except Exception:
                    continue
                if text:
                    seen.append(text)
                if wanted_texts and text not in wanted_texts:
                    continue
                if not wanted_texts and not control_type_matches(child, locator):
                    continue
                if wanted_texts and not control_type_matches(child, locator):
                    continue
                if locator.get("control_click_anchor") and control_handle(child) is None:
                    continue
                return child
        time.sleep(0.2)
    sample = ", ".join(sorted(set(seen))[:60])
    raise RuntimeError(f"Control not found for locator {locator!r}; seen: {sample}")


def invoke_control(control: Any, prefer_expand: bool = False, locator: dict[str, Any] | None = None) -> str:
    actions = ("expand", "invoke", "legacy", "select") if prefer_expand else ("invoke", "expand", "legacy", "select")
    errors: list[str] = []
    expects_menu = bool(locator and locator.get("expected_menu_text"))

    def expected_menu_opened() -> bool:
        if not expects_menu:
            return True
        try:
            wait_expected_menu(locator or {}, 0.8)
            return True
        except Exception as exc:
            errors.append(f"expected_menu: {exc}")
            return False

    try:
        control.set_focus()
    except Exception:
        pass
    key_activate = norm(str((locator or {}).get("control_key_activate", "")))
    if key_activate:
        keyboard.send_keys(key_activate)
        if expected_menu_opened():
            return f"keyboard:{key_activate}"
    if locator and locator.get("control_click_anchor"):
        if win32_message_click(control, locator) and expected_menu_opened():
            return f"win32_message_click:{locator.get('control_click_anchor')}"
        errors.append("win32_message_click: no HWND")
    if expects_menu:
        if win32_button_click(control) and expected_menu_opened():
            return "win32_button_click"
        if win32_message_click(control, locator) and expected_menu_opened():
            return "win32_message_click"
        errors.append("win32_menu_open_click: no HWND")
    for action in actions:
        try:
            if action == "invoke":
                control.invoke()
            elif action == "expand":
                control.expand()
            elif action == "legacy":
                control.iface_legacy_iaccessible.DoDefaultAction()
            else:
                control.select()
            if expected_menu_opened():
                return action
        except Exception as exc:
            errors.append(f"{action}: {exc}")
    keys = ("{RIGHT}", "{ENTER}", "{SPACE}") if locator and locator.get("expected_menu_text") else ("{ENTER}", "{SPACE}")
    for key in keys:
        try:
            control.set_focus()
            keyboard.send_keys(key)
            if expected_menu_opened():
                return f"keyboard:{key}"
        except Exception as exc:
            errors.append(f"keyboard {key}: {exc}")
    if win32_message_click(control, locator) and expected_menu_opened():
        return "win32_message_click"
    raise RuntimeError(f"Control cannot be invoked without coordinate click: {'; '.join(errors)}")


def wait_expected_menu(locator: dict[str, Any], timeout: float) -> list[str]:
    expected = [norm(str(value)) for value in locator.get("expected_menu_text", []) or [] if norm(str(value))]
    if not expected:
        return []
    deadline = time.time() + timeout
    last_texts: list[str] = []
    while time.time() < deadline:
        for backend in ("uia", "win32"):
            for win in desktop_windows(backend, locator):
                texts = [window_title(win), *visible_texts(win)]
                last_texts.extend(text for text in texts if text)
                haystack = "\n".join(texts).lower()
                if all(text.lower() in haystack for text in expected):
                    return expected
        time.sleep(0.2)
    sample = ", ".join(sorted(set(last_texts))[:80])
    raise RuntimeError(f"Expected menu text not visible: {expected!r}; seen: {sample}")


def find_control_across_windows(
    locator: dict[str, Any],
    timeout: float,
    control_text: str,
    control_types: list[str] | None = None,
) -> Any:
    """Find a transient menu/control across all visible windows for the target process."""
    transient_locator = dict(locator)
    transient_locator.pop("window_contains", None)
    transient_locator.pop("text_contains", None)
    transient_locator["control_text"] = control_text
    if control_types:
        transient_locator["control_type_any"] = control_types
    deadline = time.time() + timeout
    seen: list[str] = []
    while time.time() < deadline:
        for backend in ("uia", "win32"):
            for win in desktop_windows(backend, transient_locator):
                if not locator_matches_window(win, transient_locator, include_text=False):
                    continue
                try:
                    descendants = win.descendants()
                except Exception:
                    descendants = []
                for child in descendants:
                    child_type = control_type_name(child)
                    if child_type != "MenuItem" and not control_visible(child):
                        continue
                    text = norm(child.window_text())
                    if text:
                        seen.append(text)
                    if text != control_text:
                        continue
                    if not control_type_matches(child, transient_locator):
                        continue
                    return child
        time.sleep(0.1)
    sample = ", ".join(sorted(set(seen))[:80])
    raise RuntimeError(f"Transient control not found: {control_text!r}; seen: {sample}")


def execute_action(action: dict[str, Any], timeout: float, installer_path: Path | None = None) -> dict[str, Any]:
    action_type = str(action.get("type", ""))
    locator = action.get("locator") if isinstance(action.get("locator"), dict) else {}
    evidence: dict[str, Any] = {
        "type": action_type,
        "description": action.get("description", ""),
        "status": "FAIL",
    }
    if action_type == "e2e_stage":
        evidence.update({"status": "PASS", "stage": action.get("stage"), "note": "precondition stage is external"})
        return evidence
    if action_type == "solidworks_com":
        win = wait_window(locator, timeout)
        pid = window_process_id(win)
        addin_progid = norm(str(locator.get("addin_progid", "")))
        expected_tab_text = norm(str(locator.get("expected_tab_text", "")))
        addin_available = None
        if addin_progid:
            try:
                win32com_client = require_module("win32com.client")
                sw = win32com_client.GetActiveObject("SldWorks.Application")
                addin_available = bool(sw.GetAddInObject(addin_progid))
            except Exception as exc:
                raise RuntimeError(f"SolidWorks COM add-in check failed for {addin_progid!r}: {exc}") from exc
            if not addin_available:
                raise RuntimeError(f"SolidWorks add-in is not available through COM: {addin_progid!r}")
        tab_visible = None
        if expected_tab_text:
            haystack = "\n".join(visible_texts_all_backends(win)).lower()
            tab_visible = expected_tab_text.lower() in haystack
            if not tab_visible:
                raise RuntimeError(f"Expected SolidWorks tab text is not visible: {expected_tab_text!r}")
        evidence.update(
            {
                "status": "PASS",
                "window_title": window_title(win),
                "process_info": process_info(pid or -1),
                "addin_progid": addin_progid or None,
                "addin_available": addin_available,
                "expected_tab_text": expected_tab_text or None,
                "expected_tab_visible": tab_visible,
            }
        )
        return evidence
    if action_type == "installer_launch":
        if installer_path is None:
            raise RuntimeError("installer_launch requires --installer-path")
        proc = subprocess.Popen([str(installer_path)])
        evidence["launched_pid"] = proc.pid
        win = wait_window(locator, timeout)
        evidence.update({"status": "PASS", "window_title": window_title(win), "process_info": process_info(window_process_id(win) or -1)})
        return evidence
    if action_type in {"uia_invoke", "win32_invoke", "ribbon_command", "help_button", "menu_item"}:
        win = wait_window(locator, timeout)
        maximized = maximize_window(win) if should_maximize_for_locator(locator) else False
        control = find_control(win, locator, timeout)
        used_action = invoke_control(control, prefer_expand=action_type in {"ribbon_command", "menu_item"}, locator=locator)
        evidence.update(
            {
                "status": "PASS",
                "window_title": window_title(win),
                "process_info": process_info(window_process_id(win) or -1),
                "window_maximized": maximized,
                "invoke_action": used_action,
                "control_text": norm(control.window_text()),
            }
        )
        visible_menu = wait_expected_menu(locator, min(timeout, 5.0))
        submenu_text = norm(str(locator.get("submenu_control_text", "")))
        submenu_expected = [
            norm(str(value)) for value in locator.get("submenu_expected_menu_text", []) or [] if norm(str(value))
        ]
        if submenu_text and submenu_expected:
            submenu_locator = dict(locator)
            submenu_locator["expected_menu_text"] = submenu_expected
            submenu_errors: list[str] = []
            submenu_action = ""
            visible_submenu: list[str] = []
            for attempt in range(3):
                if attempt:
                    try:
                        keyboard.send_keys("{ESC}")
                    except Exception:
                        pass
                    time.sleep(0.2)
                    reopened = win32_button_click(control) or win32_message_click(control, locator)
                    if not reopened:
                        submenu_errors.append("reopen: no HWND action succeeded")
                        continue
                    try:
                        wait_expected_menu(locator, min(timeout, 3.0))
                    except Exception as exc:
                        submenu_errors.append(f"reopen expected menu: {exc}")
                        continue
                try:
                    submenu = find_control_across_windows(locator, min(timeout, 5.0), submenu_text, ["MenuItem"])
                    submenu_action = invoke_control(submenu, prefer_expand=True, locator=submenu_locator)
                    visible_submenu = wait_expected_menu(submenu_locator, min(timeout, 5.0))
                    break
                except Exception as exc:
                    submenu_errors.append(str(exc))
            else:
                raise RuntimeError(
                    f"Cannot open submenu {submenu_text!r} without coordinate click: {'; '.join(submenu_errors)}"
                )
            evidence.update(
                {
                    "submenu_control_text": submenu_text,
                    "submenu_invoke_action": submenu_action,
                    "submenu_expected_menu_text": visible_submenu,
                }
            )
        evidence["expected_menu_text"] = visible_menu
        return evidence
    if action_type == "context_menu":
        win = wait_window(locator, timeout)
        maximized = maximize_window(win) if should_maximize_for_locator(locator) else False
        control = find_control(win, locator, timeout)
        context_action = "keyboard:+{F10}"
        try:
            control.set_focus()
            keyboard.send_keys("+{F10}")
            visible = wait_expected_menu(locator, min(timeout, 3.0))
        except Exception as first_exc:
            fallback = win32_message_context_menu(control, locator)
            if fallback is None:
                raise RuntimeError(f"Cannot open context menu through object-located control: {first_exc}") from first_exc
            context_action = fallback
            visible = wait_expected_menu(locator, min(timeout, 5.0))
        evidence.update(
            {
                "status": "PASS",
                "window_title": window_title(win),
                "process_info": process_info(window_process_id(win) or -1),
                "control_text": norm(control.window_text()),
                "context_action": context_action,
                "window_maximized": maximized,
                "expected_menu_text": visible,
            }
        )
        return evidence
    if action_type == "wait_window":
        win = wait_window(locator, timeout)
        evidence.update({"status": "PASS", "window_title": window_title(win), "process_info": process_info(window_process_id(win) or -1)})
        return evidence
    raise RuntimeError(f"Unsupported visual opener action type: {action_type!r}")


def capture_surface(
    repo_root: Path,
    output_dir: Path,
    surface_file: Path,
    opener_file: Path,
    surface_id: str,
    expected_runtime_dir: Path | None,
    merge_manifest: Path | None,
) -> subprocess.CompletedProcess[str]:
    args = [
        sys.executable,
        str(repo_root / "scripts" / "swtools_visual_localization_capture.py"),
        "--output-dir",
        str(output_dir),
        "--surface-file",
        str(surface_file),
        "--opener-file",
        str(opener_file),
        "--surface-id",
        surface_id,
    ]
    if expected_runtime_dir is not None:
        args.extend(["--expected-runtime-dir", str(expected_runtime_dir)])
    if merge_manifest is not None:
        args.extend(["--merge-manifest", str(merge_manifest)])
    return subprocess.run(args, cwd=repo_root, text=True, encoding="utf-8", stdout=subprocess.PIPE, stderr=subprocess.PIPE)


def selected_openers(opener_file: Path, requested_ids: list[str] | None) -> list[dict[str, Any]]:
    data = load_json(opener_file)
    surfaces = data.get("surfaces", [])
    if not isinstance(surfaces, list):
        raise SystemExit(f"{opener_file}: surfaces must be a list")
    if not requested_ids:
        return [surface for surface in surfaces if isinstance(surface, dict)]
    by_id = {str(surface.get("id", "")): surface for surface in surfaces if isinstance(surface, dict)}
    missing = [surface_id for surface_id in requested_ids if surface_id not in by_id]
    if missing:
        raise SystemExit(f"Unknown opener surface id(s): {', '.join(missing)}")
    return [by_id[surface_id] for surface_id in requested_ids]


def self_test() -> int:
    assert control_click_point(120, 20, {}) == (60, 10)
    assert control_click_point(120, 20, {"control_click_anchor": "left_text"}) == (8, 10)
    assert control_click_point(5, 3, {"control_click_anchor": "left_text", "control_click_margin": 20}) == (4, 1)
    action = {"type": "e2e_stage", "stage": "07-s7-connect", "description": "external stage"}
    evidence = execute_action(action, timeout=0.1)
    assert evidence["status"] == "PASS"
    try:
        execute_action({"type": "coordinate_click", "description": "bad"}, timeout=0.1)
    except RuntimeError as exc:
        assert "Unsupported" in str(exc)
    else:
        raise AssertionError("unsupported action was not rejected")
    print("Visual opener capture runner self-test PASS")
    return 0


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    parser = argparse.ArgumentParser()
    parser.add_argument("--self-test", action="store_true")
    parser.add_argument("--output-dir", type=Path)
    parser.add_argument("--surface-file", type=Path, default=Path("docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json"))
    parser.add_argument("--opener-file", type=Path, default=Path("docs/localization/VISUAL_LOCALIZATION_OPENERS_L01_L15.json"))
    parser.add_argument("--surface-id", action="append", dest="surface_ids")
    parser.add_argument("--expected-runtime-dir", type=Path)
    parser.add_argument("--installer-path", type=Path)
    parser.add_argument(
        "--merge-manifest",
        type=Path,
        help="Continue from an existing visual-localization manifest from the same runtime.",
    )
    parser.add_argument("--timeout", type=float, default=10.0)
    args = parser.parse_args()

    if args.self_test:
        return self_test()
    if args.output_dir is None:
        raise SystemExit("--output-dir is required unless --self-test is used")

    repo_root = Path(__file__).resolve().parents[1]
    output_dir = args.output_dir.resolve()
    output_dir.mkdir(parents=True, exist_ok=True)
    surface_file = args.surface_file.resolve()
    opener_file = args.opener_file.resolve()
    expected_runtime_dir = args.expected_runtime_dir.resolve() if args.expected_runtime_dir else None
    installer_path = args.installer_path.resolve() if args.installer_path else None
    selected = selected_openers(opener_file, args.surface_ids)
    result: dict[str, Any] = {
        "status": "FAIL",
        "production_go_allowed": False,
        "surface_file": str(surface_file),
        "opener_file": str(opener_file),
        "expected_runtime_dir": str(expected_runtime_dir) if expected_runtime_dir else None,
        "surfaces": [],
    }
    result_path = output_dir / "visual-opener-capture-result.json"
    current_manifest: Path | None = args.merge_manifest.resolve() if args.merge_manifest else None
    try:
        for opener in selected:
            surface_id = str(opener.get("id", "")).strip()
            surface_dir = output_dir / surface_id
            surface_dir.mkdir(parents=True, exist_ok=True)
            surface_result: dict[str, Any] = {"id": surface_id, "status": "FAIL", "actions": []}
            for action in opener.get("actions", []) or []:
                action_evidence = execute_action(action, args.timeout, installer_path=installer_path)
                surface_result["actions"].append(action_evidence)
            capture = capture_surface(
                repo_root,
                surface_dir,
                surface_file,
                opener_file,
                surface_id,
                expected_runtime_dir,
                current_manifest,
            )
            surface_result["capture_returncode"] = capture.returncode
            surface_result["capture_stdout_tail"] = capture.stdout[-4000:]
            surface_result["capture_stderr_tail"] = capture.stderr[-4000:]
            candidate_manifest = surface_dir / "visual-localization-manifest.json"
            if capture.returncode != 0 and not candidate_manifest.exists():
                raise RuntimeError(f"{surface_id}: capture failed with {capture.returncode}: {capture.stderr[-1000:]}")
            current_manifest = candidate_manifest
            try:
                captured_manifest = load_json(current_manifest)
            except Exception as exc:
                raise RuntimeError(f"{surface_id}: cannot read capture manifest {current_manifest}: {exc}") from exc
            surface_result["capture_manifest_status"] = captured_manifest.get("status")
            captured_surface = next(
                (item for item in captured_manifest.get("surfaces", []) if item.get("id") == surface_id),
                None,
            )
            if not isinstance(captured_surface, dict) or captured_surface.get("status") != "CAPTURED":
                status = captured_surface.get("status") if isinstance(captured_surface, dict) else "missing"
                error = captured_surface.get("error") if isinstance(captured_surface, dict) else "surface not in manifest"
                raise RuntimeError(f"{surface_id}: capture did not produce CAPTURED evidence ({status}: {error})")
            if capture.returncode != 0:
                surface_result["capture_note"] = (
                    "Target surface was captured; merged manifest remains non-PASS because of "
                    "pre-existing evidence outside this opener."
                )
            surface_result["manifest"] = str(current_manifest)
            surface_result["status"] = "PASS"
            result["surfaces"].append(surface_result)
        result["status"] = "PASS"
        if current_manifest is not None:
            result["final_manifest"] = str(current_manifest)
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
