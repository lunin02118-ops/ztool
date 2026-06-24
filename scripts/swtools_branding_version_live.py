#!/usr/bin/env python3
"""Live SWTools branding/version evidence.

This is a live-machine gate: it validates the package runtime metadata and the
already running SWTools window produced by the SolidWorks add-in path. It does
not click coordinates and it does not launch a different runtime.
"""

from __future__ import annotations

import argparse
import hashlib
import importlib
import json
import os
import re
import subprocess
import sys
import time
from pathlib import Path
from typing import Any


def require_module(name: str) -> Any:
    try:
        return importlib.import_module(name)
    except Exception as exc:  # pragma: no cover - live environment guard
        raise SystemExit(f"Missing Python module '{name}': {exc}") from exc


psutil = require_module("psutil")
win32api = require_module("win32api")
win32con = require_module("win32con")
win32gui = require_module("win32gui")
win32process = require_module("win32process")
Desktop = require_module("pywinauto").Desktop
Image = require_module("PIL.Image")
win32ui = require_module("win32ui")


WM_GETICON = 0x007F
ICON_SMALL = 0
ICON_BIG = 1
ICON_SMALL2 = 2
GCLP_HICON = -14
GCLP_HICONSM = -34


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest().upper()


def read_version_file(repo_root: Path) -> str:
    return (repo_root / "VERSION").read_text(encoding="utf-8").strip()


def git_value(repo_root: Path, *args: str) -> str:
    completed = subprocess.run(
        ["git", "-C", str(repo_root), *args],
        check=True,
        text=True,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
    )
    return completed.stdout.strip()


def git_dirty(repo_root: Path) -> bool:
    return bool(git_value(repo_root, "status", "--porcelain"))


def file_version_info(path: Path) -> dict[str, str]:
    translations = win32api.GetFileVersionInfo(str(path), r"\VarFileInfo\Translation")
    if not translations:
        raise RuntimeError(f"Version translation table missing: {path}")
    lang, codepage = translations[0]
    prefix = rf"\StringFileInfo\{lang:04x}{codepage:04x}"

    def query(name: str) -> str:
        try:
            value = win32api.GetFileVersionInfo(str(path), f"{prefix}\\{name}")
        except Exception:
            return ""
        return str(value or "")

    fixed = win32api.GetFileVersionInfo(str(path), "\\")

    def fixed_version(prefix: str) -> str:
        ms = int(fixed.get(f"{prefix}MS", 0) or 0)
        ls = int(fixed.get(f"{prefix}LS", 0) or 0)
        if not ms and not ls:
            return ""
        return ".".join(
            str(x)
            for x in (
                (ms >> 16) & 0xFFFF,
                ms & 0xFFFF,
                (ls >> 16) & 0xFFFF,
                ls & 0xFFFF,
            )
        )

    return {
        "product_name": query("ProductName"),
        "product_version": query("ProductVersion"),
        "file_version": query("FileVersion"),
        "file_description": query("FileDescription"),
        "original_filename": query("OriginalFilename"),
        "internal_name": query("InternalName"),
        "fixed_file_version": fixed_version("FileVersion"),
        "fixed_product_version": fixed_version("ProductVersion"),
    }


def normalize(path: str | Path) -> str:
    return os.path.normcase(os.path.abspath(str(path)))


def process_command_line(pid: int) -> str:
    try:
        return " ".join(psutil.Process(pid).cmdline())
    except Exception:
        return ""


def find_runtime_process(runtime_dir: Path) -> psutil.Process:
    expected = normalize(runtime_dir / "SWTools.exe")
    matches: list[psutil.Process] = []
    for proc in psutil.process_iter(["pid", "name", "exe", "create_time"]):
        try:
            if (proc.info.get("name") or "").lower() != "swtools.exe":
                continue
            if normalize(proc.info.get("exe") or "") == expected:
                matches.append(proc)
        except (psutil.NoSuchProcess, psutil.AccessDenied):
            continue
    if not matches:
        raise RuntimeError(f"Running SWTools.exe from runtime not found: {expected}")
    matches.sort(key=lambda p: p.info.get("create_time") or 0, reverse=True)
    return matches[0]


def window_process_id(win: Any) -> int | None:
    try:
        return int(win.process_id())
    except Exception:
        pass
    try:
        return int(win.element_info.process_id)
    except Exception:
        return None


def find_main_window(pid: int) -> Any:
    candidates: list[Any] = []
    for backend in ("uia", "win32"):
        try:
            windows = Desktop(backend=backend).windows(process=pid)
        except Exception:
            continue
        for win in windows:
            try:
                title = win.window_text().strip()
                rect = win.rectangle()
            except Exception:
                continue
            if not title or "SWTools" not in title:
                continue
            area = max(0, rect.width()) * max(0, rect.height())
            candidates.append((area, backend, win))
    if not candidates:
        raise RuntimeError(f"SWTools main window not found for process {pid}")
    candidates.sort(key=lambda item: item[0], reverse=True)
    return candidates[0][2]


def get_class_long_ptr(hwnd: int, index: int) -> int:
    try:
        return int(win32gui.GetClassLong(hwnd, index))
    except Exception:
        return 0


def get_window_icon_handle(hwnd: int) -> tuple[int, str]:
    attempts = [
        ("WM_GETICON_BIG", lambda: win32gui.SendMessage(hwnd, WM_GETICON, ICON_BIG, 0)),
        ("WM_GETICON_SMALL2", lambda: win32gui.SendMessage(hwnd, WM_GETICON, ICON_SMALL2, 0)),
        ("WM_GETICON_SMALL", lambda: win32gui.SendMessage(hwnd, WM_GETICON, ICON_SMALL, 0)),
        ("GCLP_HICON", lambda: get_class_long_ptr(hwnd, GCLP_HICON)),
        ("GCLP_HICONSM", lambda: get_class_long_ptr(hwnd, GCLP_HICONSM)),
    ]
    for name, getter in attempts:
        try:
            handle = int(getter() or 0)
        except Exception:
            handle = 0
        if handle:
            return handle, name
    return 0, ""


def icon_handle_to_png(handle: int, output_path: Path) -> dict[str, Any]:
    info = win32gui.GetIconInfo(handle)
    color_bitmap = info[4]
    mask_bitmap = info[3]
    bmp = win32ui.CreateBitmapFromHandle(color_bitmap)
    bmp_info = bmp.GetInfo()
    width = int(bmp_info["bmWidth"])
    height = int(bmp_info["bmHeight"])
    bits = bmp.GetBitmapBits(True)
    image = Image.frombuffer("RGBA", (width, height), bits, "raw", "BGRA", 0, 1)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    image.save(output_path)
    data = output_path.read_bytes()
    try:
        win32gui.DeleteObject(color_bitmap)
    except Exception:
        pass
    try:
        win32gui.DeleteObject(mask_bitmap)
    except Exception:
        pass
    return {
        "path": str(output_path),
        "width": width,
        "height": height,
        "sha256": hashlib.sha256(data).hexdigest().upper(),
    }


def extract_exe_icon(exe: Path, output_path: Path) -> dict[str, Any]:
    large, small = win32gui.ExtractIconEx(str(exe), 0, 1)
    handle = 0
    source = ""
    if large:
        handle = int(large[0])
        source = "ExtractIconEx.large"
    elif small:
        handle = int(small[0])
        source = "ExtractIconEx.small"
    if not handle:
        raise RuntimeError(f"Cannot extract icon from {exe}")
    result = icon_handle_to_png(handle, output_path)
    result["source"] = source
    win32gui.DestroyIcon(handle)
    for extra in [*large[1:], *small]:
        try:
            win32gui.DestroyIcon(extra)
        except Exception:
            pass
    return result


def assert_no_legacy_brand(value: str, field: str) -> None:
    if "ZTool" in value:
        raise RuntimeError(f"Legacy brand leaked in {field}: {value!r}")


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    sys.stderr.reconfigure(encoding="utf-8", errors="replace")
    parser = argparse.ArgumentParser()
    parser.add_argument("--runtime-dir", required=True)
    parser.add_argument("--report-dir", required=True)
    parser.add_argument("--repo-root", default="")
    parser.add_argument("--expected-version", default="")
    parser.add_argument("--expected-exe-sha256", default="")
    parser.add_argument("--expected-dll-sha256", default="")
    parser.add_argument("--expected-commit-short", default="")
    parser.add_argument("--expected-clean-state", choices=["clean", "dirty"], default="")
    args = parser.parse_args()

    runtime_dir = Path(args.runtime_dir).resolve()
    report_dir = Path(args.report_dir).resolve()
    report_dir.mkdir(parents=True, exist_ok=True)
    result_path = report_dir / "branding-version-result.json"
    repo_root = Path(args.repo_root).resolve() if args.repo_root else Path(__file__).resolve().parents[1]
    expected_version = args.expected_version or read_version_file(repo_root)
    expected_commit_short = args.expected_commit_short or git_value(repo_root, "rev-parse", "--short", "HEAD")
    expected_clean_state = args.expected_clean_state or ("dirty" if git_dirty(repo_root) else "clean")

    result: dict[str, Any] = {
        "status": "FAIL",
        "runtime_dir": str(runtime_dir),
        "expected_version": expected_version,
        "expected_commit_short": expected_commit_short,
        "expected_clean_state": expected_clean_state,
        "checks": [],
    }

    try:
        exe = runtime_dir / "SWTools.exe"
        dll = runtime_dir / "SWTools.dll"
        if not exe.is_file():
            raise RuntimeError(f"SWTools.exe missing: {exe}")
        if not dll.is_file():
            raise RuntimeError(f"SWTools.dll missing: {dll}")
        exe_sha = sha256(exe)
        dll_sha = sha256(dll)
        if args.expected_exe_sha256 and exe_sha != args.expected_exe_sha256.upper():
            raise RuntimeError(f"SWTools.exe SHA mismatch: expected {args.expected_exe_sha256}, got {exe_sha}")
        if args.expected_dll_sha256 and dll_sha != args.expected_dll_sha256.upper():
            raise RuntimeError(f"SWTools.dll SHA mismatch: expected {args.expected_dll_sha256}, got {dll_sha}")

        exe_info = file_version_info(exe)
        dll_info = file_version_info(dll)
        for kind, info in (("SWTools.exe", exe_info), ("SWTools.dll", dll_info)):
            if info["product_name"] != "SWTools":
                raise RuntimeError(f"{kind} ProductName mismatch: {info['product_name']!r}")
            if not info["product_version"].startswith(expected_version):
                raise RuntimeError(f"{kind} ProductVersion mismatch: {info['product_version']!r}")
            if not info["file_version"].startswith(f"{expected_version}."):
                raise RuntimeError(f"{kind} FileVersion mismatch: {info['file_version']!r}")
            for field in ("product_name", "product_version", "file_version", "file_description"):
                assert_no_legacy_brand(info.get(field, ""), f"{kind}.{field}")
        result["checks"].append("runtime version metadata ok")

        proc = find_runtime_process(runtime_dir)
        process_path = Path(proc.exe()).resolve()
        command_line = process_command_line(proc.pid)
        window = find_main_window(proc.pid)
        hwnd = int(window.handle)
        window_title = window.window_text().strip()
        expected_title_prefix = f"SWTools {expected_version}+{expected_commit_short}.{expected_clean_state}"
        if not window_title.startswith(expected_title_prefix):
            raise RuntimeError(
                "Live window title mismatch: "
                f"expected prefix {expected_title_prefix!r}, got {window_title!r}"
            )
        if "(x64)" not in window_title:
            raise RuntimeError(f"Live window title must include '(x64)': {window_title!r}")
        assert_no_legacy_brand(window_title, "live.window_title")
        result["checks"].append("live window title ok")

        live_icon_handle, live_icon_source = get_window_icon_handle(hwnd)
        if not live_icon_handle:
            raise RuntimeError("Live SWTools window has no icon handle")
        live_icon = icon_handle_to_png(live_icon_handle, report_dir / "live-window-icon.png")
        live_icon["source"] = live_icon_source
        exe_icon = extract_exe_icon(exe, report_dir / "embedded-exe-icon.png")
        result["checks"].append("live and embedded icons captured")

        result.update(
            {
                "status": "PASS",
                "swtools_exe": {
                    "path": str(exe),
                    "sha256": exe_sha,
                    "version_info": exe_info,
                },
                "swtools_dll": {
                    "path": str(dll),
                    "sha256": dll_sha,
                    "version_info": dll_info,
                },
                "live_process": {
                    "process_id": proc.pid,
                    "path": str(process_path),
                    "path_matches_runtime": normalize(process_path) == normalize(exe),
                    "command_line": command_line,
                    "window_handle": hwnd,
                    "window_title": window_title,
                    "window_title_expected_prefix": expected_title_prefix,
                    "window_icon": live_icon,
                },
                "embedded_exe_icon": exe_icon,
            }
        )
        if not result["live_process"]["path_matches_runtime"]:
            raise RuntimeError(f"Live process path mismatch: {process_path} != {exe}")
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
