#!/usr/bin/env python3
"""Live property import/save/reload regression for SWTools.

This is a SolidWorks-machine gate. It validates the product contracts without
coordinate clicks:

* native SWDM import from a file and from a folder;
* live SolidWorks open-document property-name import;
* SWTools add-in save path via the same WM_COPYDATA payload used by the client;
* reload/read-back from SolidWorks after save.

The SWDM key is read from local secret storage by the existing native probe and
is never printed by this script.
"""

from __future__ import annotations

import argparse
import ctypes
import hashlib
import importlib.util
import json
import os
import shutil
import subprocess
import sys
import threading
import time
import traceback
import re
from pathlib import Path
from typing import Any


REPO_ROOT = Path(__file__).resolve().parents[1]
S7_HELPERS_PATH = REPO_ROOT / "scripts" / "swtools_s7_live_smoke.py"
SWDM_PROBE = REPO_ROOT / "tools" / "e2e" / "check_swdm_property_import_live.py"
HANDSHAKE_TOKEN = "9EF1CBF0BCFAD9F118EA30863B1874"
REQUEST = "ZToolRequest@001" + HANDSHAKE_TOKEN
SEP = "\u001e\u001c"
WM_COPYDATA = 0x004A
DEFAULT_SOLIDWORKS_EXE = Path(r"C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\sldworks.exe")


def load_s7_helpers() -> Any:
    spec = importlib.util.spec_from_file_location("swtools_s7_live_smoke_helpers", S7_HELPERS_PATH)
    if spec is None or spec.loader is None:
        raise RuntimeError(f"Cannot load S7 helper module: {S7_HELPERS_PATH}")
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    return module


s7 = load_s7_helpers()
win32gui = s7.win32gui
win32con = s7.win32con
win32process = s7.win32process
pythoncom = s7.pythoncom
win32com = s7.win32com
VARIANT = win32com.VARIANT


class COPYDATASTRUCT(ctypes.Structure):
    _fields_ = [
        ("dwData", ctypes.c_size_t),
        ("cbData", ctypes.c_uint32),
        ("lpData", ctypes.c_void_p),
    ]


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest().upper()


def to_hex_string(value: str) -> str:
    return value.encode("utf-8").hex()


def file_doc_type(path: Path) -> int:
    ext = path.suffix.lower()
    if ext == ".sldprt":
        return 1
    if ext == ".sldasm":
        return 2
    if ext == ".slddrw":
        return 3
    raise ValueError(f"Unsupported SOLIDWORKS document: {path}")


def call_or_value(obj: Any, name: str, *args: Any) -> Any:
    value = getattr(obj, name)
    if callable(value):
        return value(*args)
    if args:
        raise TypeError(f"{name} is exposed as COM property, not method")
    return value


def array_to_list(raw: Any) -> list[str]:
    if raw is None:
        return []
    if isinstance(raw, (list, tuple)):
        values = raw
    else:
        try:
            values = list(raw)
        except TypeError:
            values = [raw]
    return [str(item).strip() for item in values if str(item).strip()]


def read_property_names_from_model(model: Any) -> list[str]:
    names: set[str] = set()
    ext = model.Extension
    for scope in [""]:
        try:
            mgr = ext.CustomPropertyManager(scope)
            if mgr is not None:
                names.update(array_to_list(call_or_value(mgr, "GetNames")))
        except Exception:
            pass
    try:
        cfg_names = array_to_list(call_or_value(model, "GetConfigurationNames"))
    except Exception:
        cfg_names = []
    for cfg in cfg_names:
        try:
            mgr = ext.CustomPropertyManager(cfg)
            if mgr is not None:
                names.update(array_to_list(call_or_value(mgr, "GetNames")))
        except Exception:
            pass
    return sorted(names, key=str.casefold)


def read_property_names_by_scope(model: Any, cfg_name: str) -> dict[str, Any]:
    ext = model.Extension
    document_names: set[str] = set()
    configuration_names: set[str] = set()
    try:
        mgr = ext.CustomPropertyManager("")
        if mgr is not None:
            document_names.update(array_to_list(call_or_value(mgr, "GetNames")))
    except Exception:
        pass
    if cfg_name:
        try:
            mgr = ext.CustomPropertyManager(cfg_name)
            if mgr is not None:
                configuration_names.update(array_to_list(call_or_value(mgr, "GetNames")))
        except Exception:
            pass
    return {
        "document_property_count": len(document_names),
        "configuration_property_count": len(configuration_names),
        "document_property_sample": sorted(document_names, key=str.casefold)[:30],
        "configuration_property_sample": sorted(configuration_names, key=str.casefold)[:30],
    }


def read_property_values(model: Any, names: list[str], cfg_name: str = "") -> dict[str, dict[str, str]]:
    ext = model.Extension
    mgr = ext.CustomPropertyManager(cfg_name)
    result: dict[str, dict[str, str]] = {}
    for name in names:
        try:
            val_out = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_BSTR, "")
            resolved = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_BSTR, "")
            was_resolved = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_BOOL, False)
            raw = mgr.Get5(name, False, val_out, resolved, was_resolved)
            if isinstance(raw, tuple):
                val = str(raw[1]) if len(raw) > 1 else ""
                res = str(raw[2]) if len(raw) > 2 else ""
            else:
                val = str(val_out.value or "")
                res = str(resolved.value or "")
            result[name] = {"value": val, "resolved": res}
        except Exception as exc:
            result[name] = {"error": str(exc)}
    return result


def active_configuration_name(model: Any) -> str:
    try:
        cfg = model.ConfigurationManager.ActiveConfiguration
        name = getattr(cfg, "Name", "")
        if callable(name):
            name = name()
        return str(name or "")
    except Exception:
        try:
            cfg = model.GetActiveConfiguration()
            name = getattr(cfg, "Name", "")
            if callable(name):
                name = name()
            return str(name or "")
        except Exception:
            return ""


def write_json(path: Path, data: dict[str, Any]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")


def find_runtime_process_any(runtime_dir: Path) -> Any | None:
    runtime = str(runtime_dir.resolve()).lower()
    candidates: list[Any] = []
    for proc in s7.psutil.process_iter(["pid", "name", "exe", "create_time"]):
        try:
            if (proc.info.get("name") or "").lower() != "swtools.exe":
                continue
            exe = (proc.info.get("exe") or "").lower()
            if exe.startswith(runtime):
                candidates.append(proc)
        except (s7.psutil.NoSuchProcess, s7.psutil.AccessDenied):
            continue
    candidates.sort(key=lambda p: p.info.get("create_time", 0), reverse=True)
    return candidates[0] if candidates else None


def launch_or_find_swtools(sw: Any, solidworks_pid: int, runtime_dir: Path, timeout: float) -> dict[str, Any]:
    addin = call_or_value(sw, "GetAddInObject", "ZTool.SwAddin")
    if not addin:
        raise RuntimeError("SolidWorks returned no SWTools add-in compatibility object")

    started = time.time()
    open_state = s7.invoke_open_ztool_async()
    proc = find_runtime_process_any(runtime_dir)
    deadline = time.time() + timeout
    launch_evidence: dict[str, Any] = {
        "open_ztool_started_at": round(started, 3),
        "open_ztool": dict(open_state),
        "preexisting_runtime_process": bool(proc),
    }

    while time.time() < deadline and proc is None:
        launch_evidence["open_ztool"] = dict(open_state)
        launch_evidence["open_ztool_wait_elapsed"] = round(time.time() - started, 3)
        if open_state.get("done") and open_state.get("error"):
            raise RuntimeError(f"openZtool failed: {open_state['error']}")
        blocker = s7.blocking_dialog(None, solidworks_pid)
        if blocker:
            if s7.is_solidworks_transient_model_loading_dialog(blocker):
                transients = launch_evidence.setdefault("transient_model_loading_dialogs", [])
                if isinstance(transients, list) and len(transients) < 8:
                    transients.append(s7.summarize_dialog(blocker))
                time.sleep(0.25)
                continue
            launch_evidence["blocking_dialog"] = blocker
            raise RuntimeError(f"Blocking dialog during openZtool: {blocker}")
        proc = s7.find_runtime_process(runtime_dir, started) or find_runtime_process_any(runtime_dir)
        time.sleep(0.25)
    if proc is None:
        raise RuntimeError(f"SWTools.exe did not start from runtime {runtime_dir}")

    command_line = s7.process_command_line(proc.pid)
    if str(solidworks_pid) not in command_line:
        raise RuntimeError("SWTools command line does not include SolidWorks PID")
    receiver_windows = s7.receiver_windows(solidworks_pid)
    if not receiver_windows:
        raise RuntimeError("SolidWorks add-in receiver window Ztool_Receiver was not found after SWTools launch")
    main_hwnd = s7.find_swtools_main_window(proc.pid)
    if main_hwnd is None:
        raise RuntimeError(f"SWTools main window was not found for process {proc.pid}")
    s7.restore_window(main_hwnd)

    license_result = s7.dismiss_license_dialog(proc.pid, timeout=10.0)
    if license_result.get("found") and not license_result.get("dismissed"):
        raise RuntimeError(f"License dialog was not dismissed: {license_result}")

    launch_evidence.update(
        {
            "status": "PASS",
            "swtools_pid": proc.pid,
            "swtools_path": proc.exe(),
            "swtools_command_line": command_line,
            "swtools_main_hwnd": int(main_hwnd),
            "swtools_windows_after_launch": s7.top_windows_for_pid(proc.pid),
            "receiver_windows_after_launch": receiver_windows,
            "license_dialog": license_result,
        }
    )
    return launch_evidence


def visible_han_check(swtools_hwnd: int) -> dict[str, Any]:
    texts: list[str] = []
    try:
        main = s7.Desktop(backend="uia").window(handle=swtools_hwnd)
        texts = s7.uia_descendant_texts(main, timeout=3.0)
    except Exception as exc:
        return {"status": "WARN", "error": str(exc), "visible_text_count": 0, "han_texts": []}
    han_re = re.compile(r"[\u3400-\u9fff]")
    han_texts = sorted({text for text in texts if han_re.search(text)})
    return {
        "status": "PASS" if not han_texts else "FAIL",
        "visible_text_count": len(texts),
        "han_texts": han_texts,
    }


def connect_swtools_to_solidworks(
    swtools_pid: int,
    swtools_main_hwnd: int,
    solidworks_pid: int,
    min_rows: int = 1,
    min_columns: int = 8,
    timeout: float = 80.0,
) -> dict[str, Any]:
    main = s7.Desktop(backend="uia").window(handle=swtools_main_hwnd)
    s7.restore_window(swtools_main_hwnd)
    try:
        main.set_focus()
    except Exception:
        pass
    time.sleep(0.2)
    connect_state = s7.invoke_connect_async(swtools_main_hwnd)
    evidence: dict[str, Any] = {
        "status": "IN_PROGRESS",
        "min_rows": min_rows,
        "min_columns": min_columns,
        "connect_invoke": dict(connect_state),
    }
    last_status = ""
    last_count = 0
    last_texts: list[str] = []
    deadline = time.time() + timeout
    while time.time() < deadline:
        time.sleep(0.5)
        evidence["connect_invoke"] = dict(connect_state)
        if connect_state.get("done") and connect_state.get("error"):
            evidence["status"] = "FAIL"
            evidence["error"] = f"Connect invoke failed: {connect_state['error']}"
            return evidence
        blocker = s7.blocking_dialog(swtools_pid, solidworks_pid)
        if blocker:
            if s7.is_solidworks_connection_timeout_dialog(blocker):
                dismissed = s7.dismiss_solidworks_connection_timeout(solidworks_pid)
                if dismissed:
                    evidence.setdefault("dismissed_connection_timeout_dialogs", []).append(dismissed)
                    continue
            evidence["blocking_dialog"] = blocker
            evidence["status"] = "FAIL"
            evidence["error"] = f"Blocking dialog during SWTools connect: {blocker}"
            return evidence
        s7.dismiss_license_dialog(swtools_pid, timeout=0.1)
        last_texts = s7.visible_texts(main)
        last_status = s7.parse_status(last_texts)
        last_count = s7.parse_row_count(last_status, last_texts)
        evidence.update(
            {
                "last_poll_at": round(time.time(), 3),
                "status_text": last_status,
                "row_count": last_count,
            }
        )
        if "Подключение завершено" in last_status or last_count >= min_rows:
            break
    dimensions = s7.grid_dimensions(main, last_count)
    row_count = max(int(dimensions.get("row_count") or 0), int(last_count or 0))
    column_count = int(dimensions.get("column_count") or 0)
    evidence.update(
        {
            "row_count": row_count,
            "column_count": column_count,
            "grid_dimensions": dimensions,
            "receiver_windows_after_connect": s7.receiver_windows(solidworks_pid),
            "visible_text_sample": last_texts[:250],
        }
    )
    if row_count < min_rows:
        evidence["status"] = "FAIL"
        evidence["error"] = f"SWTools connect returned {row_count} rows; expected at least {min_rows}; status={last_status!r}"
        return evidence
    if column_count < min_columns:
        evidence["status"] = "FAIL"
        evidence["error"] = f"SWTools connect grid has {column_count} columns; expected at least {min_columns}"
        return evidence
    evidence["status"] = "PASS"
    return evidence


def open_model(sw: Any, path: Path, timeout: float = 45.0) -> Any:
    path = path.resolve()
    try:
        sw.CloseDoc(path.name)
    except Exception:
        pass
    deadline = time.time() + timeout
    try:
        os.startfile(str(path))
    except Exception:
        pass
    shell_deadline = min(deadline, time.time() + 8.0)
    while time.time() < shell_deadline:
        try:
            active = sw.ActiveDoc
            if active is not None and str(call_or_value(active, "GetPathName")).lower() == str(path).lower():
                return active
        except Exception:
            pass
        time.sleep(0.25)
    try:
        errors = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        warnings = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        model = sw.OpenDoc6(str(path), file_doc_type(path), 1, "", errors, warnings)
        if model is not None:
            return model
    except Exception:
        pass
    while time.time() < deadline:
        try:
            active = sw.ActiveDoc
            if active is not None and str(call_or_value(active, "GetPathName")).lower() == str(path).lower():
                return active
        except Exception:
            pass
        time.sleep(0.25)
    raise RuntimeError(f"SolidWorks did not open target model: {path}")


def get_solidworks_com(timeout: float) -> Any:
    deadline = time.time() + timeout
    last_error: str | None = None
    while time.time() < deadline:
        try:
            sw = win32com.GetActiveObject("SldWorks.Application")
            try:
                sw.Visible = True
            except Exception:
                pass
            return sw
        except Exception as exc:
            last_error = str(exc)
        time.sleep(1.0)
    raise RuntimeError(f"SolidWorks COM object not available: {last_error}")


def get_or_start_solidworks_for_model(path: Path, timeout: float) -> Any:
    try:
        return get_solidworks_com(timeout=5.0)
    except RuntimeError:
        pass
    if DEFAULT_SOLIDWORKS_EXE.exists():
        subprocess.Popen([str(DEFAULT_SOLIDWORKS_EXE)])
    else:
        os.startfile(str(path))
    return get_solidworks_com(timeout=timeout)


def close_model(sw: Any, path: Path) -> None:
    for name in (path.name, str(path)):
        try:
            sw.CloseDoc(name)
        except Exception:
            pass


class ReceiverWindow:
    def __init__(self) -> None:
        self.hwnd = 0
        self.messages: list[dict[str, Any]] = []
        self._ready = threading.Event()
        self._stop = threading.Event()
        self._thread = threading.Thread(target=self._run, name="SWToolsE2EReceiver", daemon=True)

    def start(self) -> "ReceiverWindow":
        self._thread.start()
        if not self._ready.wait(5):
            raise RuntimeError("Receiver window was not created")
        return self

    def stop(self) -> None:
        self._stop.set()
        if self.hwnd:
            try:
                win32gui.PostMessage(self.hwnd, win32con.WM_CLOSE, 0, 0)
            except Exception:
                pass
        self._thread.join(timeout=3)

    def _wnd_proc(self, hwnd: int, msg: int, wparam: int, lparam: int) -> int:
        if msg == WM_COPYDATA:
            cds = ctypes.cast(lparam, ctypes.POINTER(COPYDATASTRUCT)).contents
            chars = max(0, int(cds.cbData) // 2)
            text = ctypes.wstring_at(cds.lpData, chars).rstrip("\x00") if cds.lpData else ""
            self.messages.append({"dwData": int(cds.dwData), "text": text, "at": round(time.time(), 3)})
            return 1
        if msg == win32con.WM_CLOSE:
            win32gui.DestroyWindow(hwnd)
            return 0
        if msg == win32con.WM_DESTROY:
            return 0
        return win32gui.DefWindowProc(hwnd, msg, wparam, lparam)

    def _run(self) -> None:
        wc = win32gui.WNDCLASS()
        wc.lpfnWndProc = self._wnd_proc
        wc.lpszClassName = "SWToolsE2EReceiverWindow"
        wc.hInstance = win32gui.GetModuleHandle(None)
        atom = win32gui.RegisterClass(wc)
        self.hwnd = win32gui.CreateWindowEx(
            0,
            atom,
            "SWToolsE2EReceiverWindow",
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            wc.hInstance,
            None,
        )
        self._ready.set()
        while not self._stop.is_set():
            win32gui.PumpWaitingMessages()
            time.sleep(0.01)
        try:
            if self.hwnd and win32gui.IsWindow(self.hwnd):
                win32gui.DestroyWindow(self.hwnd)
        except Exception:
            pass

    def wait_for_dwdata(self, data_id: int, after_index: int = 0, timeout: float = 30.0) -> list[dict[str, Any]]:
        deadline = time.time() + timeout
        while time.time() < deadline:
            matches = [item for item in self.messages[after_index:] if int(item.get("dwData", -1)) == data_id]
            if matches:
                return matches
            time.sleep(0.05)
        return []


def send_copydata(target_hwnd: int, sender_hwnd: int, data_id: int, text: str) -> int:
    data = ctypes.create_unicode_buffer(text)
    cds = COPYDATASTRUCT()
    cds.dwData = int(data_id)
    cds.cbData = len(text.encode("utf-16-le")) + 2
    cds.lpData = ctypes.cast(data, ctypes.c_void_p)
    return int(ctypes.windll.user32.SendMessageW(int(target_hwnd), WM_COPYDATA, int(sender_hwnd), ctypes.byref(cds)))


def find_receiver_or_fail(solidworks_pid: int) -> dict[str, Any]:
    matches = s7.receiver_windows(solidworks_pid)
    if not matches:
        raise RuntimeError("Ztool_Receiver window was not found in the SolidWorks process; load SWTools add-in first")
    return matches[0]


def send_save_options(receiver_hwnd: int, sender_hwnd: int) -> int:
    lines = [
        REQUEST,
        str(sender_hwnd),
        "2",       # propsaveplace: document/custom scope
        "False",   # keep null values
        "False",   # delete current prop from other position
        "0",
        "False",   # delete properties not in list
        "0",
        "False",   # update units
        "True",    # SaveAfterModify
        "False",   # overwrite same-name files
        "0",
        "False",   # update references
        "False",
        "",
        "",
        "",
        ">",
    ]
    return send_copydata(receiver_hwnd, sender_hwnd, 31, "\r\n".join(lines))


def save_via_addin(receiver_hwnd: int, sender_hwnd: int, file_path: Path, properties: dict[str, str]) -> dict[str, Any]:
    lines = [
        f"CfgName{SEP}",
        f"NewMaterial{SEP}",
        f"ModelColor{SEP}0",
        f"Author{SEP}",
        f"Comment{SEP}",
        f"Keywords{SEP}",
        f"Subject{SEP}",
        f"Title{SEP}",
    ]
    for name, value in properties.items():
        lines.append(f"PropName{SEP}{name}{SEP}30{SEP}{to_hex_string(value)}{SEP}")
    lines.extend(
        [
            f"RowNumber{SEP}0",
            f"End{SEP}False",
            f"IsChanged{SEP}True",
            f"NewPathName{SEP}{file_path}",
            f"OldPathName{SEP}{file_path}",
        ]
    )
    payload = "\r\n".join(lines)
    result33 = send_copydata(receiver_hwnd, sender_hwnd, 33, payload)
    result34 = send_copydata(receiver_hwnd, sender_hwnd, 34, REQUEST)
    return {"result33": result33, "result34": result34, "payload_line_count": len(lines)}


def wait_for_property_values(model: Any, names_to_values: dict[str, str], cfg_name: str, timeout: float) -> dict[str, Any]:
    deadline = time.time() + timeout
    last_document: dict[str, dict[str, str]] = {}
    last_configuration: dict[str, dict[str, str]] = {}
    while time.time() < deadline:
        last_document = read_property_values(model, list(names_to_values), "")
        last_configuration = read_property_values(model, list(names_to_values), cfg_name)
        mismatches: list[dict[str, str]] = []
        for name, expected in names_to_values.items():
            entry = last_document.get(name, {})
            actual = entry.get("value") or entry.get("resolved") or ""
            if actual != expected:
                mismatches.append({"name": name, "expected": expected, "actual": actual})
        if not mismatches:
            return {
                "status": "PASS",
                "document_values": last_document,
                "configuration_values": last_configuration,
                "poll_elapsed": round(timeout - max(0.0, deadline - time.time()), 3),
            }
        time.sleep(0.5)
    return {
        "status": "FAIL",
        "document_values": last_document,
        "configuration_values": last_configuration,
        "mismatches": [
            {
                "name": name,
                "expected": expected,
                "actual": (last_document.get(name, {}).get("value") or last_document.get(name, {}).get("resolved") or ""),
            }
            for name, expected in names_to_values.items()
        ],
    }


def parse_save_completion(callback: dict[str, Any]) -> dict[str, Any]:
    lines = str(callback.get("text", "")).splitlines()
    while len(lines) < 5:
        lines.append("")
    return {
        "renamed": lines[0],
        "old_path": lines[1],
        "new_path": lines[2],
        "row_number": lines[3],
        "errors": [line for line in lines[4:] if line.strip()],
    }


def run_swdm_probe(mode: str, path: Path, output_dir: Path, expected: list[str]) -> dict[str, Any]:
    output = output_dir / f"swdm-{mode}.json"
    cmd = [
        sys.executable,
        str(SWDM_PROBE),
        "--json-out",
        str(output),
    ]
    # The child probe is deliberately used only for native SWDM access. Keep the
    # Unicode expectations in this parent process so Windows console code pages
    # cannot corrupt Cyrillic command-line diagnostics.
    cmd.extend(["--folder" if mode == "folder" else "--file", str(path)])
    completed = subprocess.run(
        cmd,
        text=True,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        encoding="utf-8",
        errors="replace",
    )
    if completed.returncode != 0:
        raise RuntimeError(f"SWDM {mode} probe failed: {(completed.stderr or '').strip() or (completed.stdout or '').strip()}")
    result = json.loads(output.read_text(encoding="utf-8"))
    ensure_expected_names(f"SWDM {mode} import", result.get("properties", []), expected)
    return result


def ensure_expected_names(label: str, names: list[str], expected: list[str]) -> None:
    folded = {name.casefold() for name in names}
    missing = [name for name in expected if name.casefold() not in folded]
    if missing:
        raise RuntimeError(f"{label}: missing expected properties {missing}")


def run(args: argparse.Namespace) -> dict[str, Any]:
    s7.normalize_env()
    output_dir = args.output_dir.resolve()
    output_dir.mkdir(parents=True, exist_ok=True)
    fixture_dir = output_dir / "fixture"
    if fixture_dir.exists():
        shutil.rmtree(fixture_dir)
    fixture_dir.mkdir(parents=True)

    source_file = args.file.resolve()
    source_folder = args.folder.resolve()
    fixture_file = fixture_dir / source_file.name
    shutil.copy2(source_file, fixture_file)

    expected_import_names = args.expect_name
    result: dict[str, Any] = {
        "status": "FAIL",
        "production_go_allowed": False,
        "source_file": str(source_file),
        "source_folder": str(source_folder),
        "fixture_file": str(fixture_file),
        "fixture_file_sha256_before": sha256(fixture_file),
        "expected_import_names": expected_import_names,
        "steps": {},
    }
    result_path = output_dir / "property-import-save-reload-result.json"
    write_json(result_path, result)

    try:
        result["steps"]["swdm_file_import"] = run_swdm_probe("file", source_file, output_dir, expected_import_names)
        write_json(result_path, result)
        result["steps"]["swdm_folder_import"] = run_swdm_probe("folder", source_folder, output_dir, expected_import_names)
        write_json(result_path, result)

        pythoncom.CoInitialize()
        try:
            sw = get_or_start_solidworks_for_model(fixture_file, timeout=args.solidworks_timeout)
            solidworks_pid = int(call_or_value(sw, "GetProcessID"))
            model = open_model(sw, fixture_file, timeout=args.solidworks_timeout)
            active_path = str(call_or_value(model, "GetPathName"))
            active_cfg = active_configuration_name(model)
            open_names = read_property_names_from_model(model)
            scoped_names = read_property_names_by_scope(model, active_cfg)
            ensure_expected_names("open-components import", open_names, expected_import_names)
            result["steps"]["open_components_import"] = {
                "status": "PASS",
                "solidworks_pid": solidworks_pid,
                "active_path": active_path,
                "active_configuration": active_cfg,
                "property_count": len(open_names),
                "sample": open_names[:30],
                **scoped_names,
            }
            write_json(result_path, result)

            swtools_launch = launch_or_find_swtools(sw, solidworks_pid, args.runtime_dir.resolve(), args.solidworks_timeout)
            result["steps"]["swtools_runtime_launch"] = swtools_launch
            visible_han = visible_han_check(int(swtools_launch["swtools_main_hwnd"]))
            result["steps"]["visible_han_check"] = visible_han
            if visible_han.get("status") == "FAIL":
                raise RuntimeError(f"Visible Han text found in SWTools-owned UI: {visible_han.get('han_texts')}")
            write_json(result_path, result)

            connect_evidence = connect_swtools_to_solidworks(
                swtools_pid=int(swtools_launch["swtools_pid"]),
                swtools_main_hwnd=int(swtools_launch["swtools_main_hwnd"]),
                solidworks_pid=solidworks_pid,
                min_rows=1,
                min_columns=8,
                timeout=args.solidworks_timeout,
            )
            result["steps"]["swtools_connect"] = connect_evidence
            write_json(result_path, result)
            if connect_evidence.get("status") != "PASS":
                raise RuntimeError(str(connect_evidence.get("error") or "SWTools connect failed"))

            receiver_info = swtools_launch["receiver_windows_after_launch"][0]
            sender_hwnd = int(swtools_launch["swtools_main_hwnd"])
            save_options_result = send_save_options(int(receiver_info["hwnd"]), sender_hwnd)
            stamp = time.strftime("%Y%m%d-%H%M%S")
            save_properties = {
                "SWTOOLS_E2E_SAVE_RELOAD": f"PASS-{stamp}",
                "SWTOOLS_E2E_Кириллица": f"Проверка сохранения {stamp}",
            }
            send_result = save_via_addin(int(receiver_info["hwnd"]), sender_hwnd, fixture_file, save_properties)
            result["steps"]["save_reload_attempt"] = {
                "status": "IN_PROGRESS",
                "receiver": receiver_info,
                "sender_hwnd": sender_hwnd,
                "sender": "SWTools main window",
                "save_options_result": save_options_result,
                "send_result": send_result,
                "properties_to_write": save_properties,
            }
            write_json(result_path, result)
            live_write = wait_for_property_values(model, save_properties, active_cfg, args.save_callback_timeout)
            result["steps"]["save_reload_attempt"]["live_write_readback"] = live_write
            write_json(result_path, result)
            if live_write.get("status") != "PASS":
                raise RuntimeError(f"SaveToSW live read-back failed: {live_write.get('mismatches')}")

            live_values_document = read_property_values(model, list(save_properties), "")
            live_values_configuration = read_property_values(model, list(save_properties), active_cfg)
            close_model(sw, fixture_file)
            reopened = open_model(sw, fixture_file, timeout=args.solidworks_timeout)
            reopened_cfg = active_configuration_name(reopened)
            reloaded_values_document = read_property_values(reopened, list(save_properties), "")
            reloaded_values_configuration = read_property_values(reopened, list(save_properties), reopened_cfg)
            close_model(sw, fixture_file)

            for name, expected in save_properties.items():
                entry = reloaded_values_document.get(name, {})
                actual = entry.get("value") or entry.get("resolved")
                if actual != expected:
                    raise RuntimeError(f"Reload read-back mismatch for {name!r}: expected {expected!r}, got {actual!r}")

            result["steps"]["save_reload"] = {
                "status": "PASS",
                "receiver": receiver_info,
                "sender_hwnd": sender_hwnd,
                "sender": "SWTools main window",
                "save_options_result": save_options_result,
                "send_result": send_result,
                "live_write_readback": live_write,
                "properties_written": save_properties,
                "live_values_document": live_values_document,
                "live_values_configuration": live_values_configuration,
                "reloaded_values": reloaded_values_document,
                "reloaded_values_document": reloaded_values_document,
                "reloaded_values_configuration": reloaded_values_configuration,
                "active_configuration_before_save": active_cfg,
                "active_configuration_after_reload": reopened_cfg,
            }
            write_json(result_path, result)
        finally:
            pythoncom.CoUninitialize()
    except Exception as exc:
        result["status"] = "FAIL"
        result["error"] = str(exc)
        result["traceback"] = traceback.format_exc()
        write_json(result_path, result)
        raise

    result["fixture_file_sha256_after"] = sha256(fixture_file)
    result["status"] = "PASS"
    write_json(result_path, result)
    return result


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--file", type=Path, required=True, help="SOLIDWORKS part/assembly used for file import and save/reload fixture.")
    parser.add_argument("--folder", type=Path, required=True, help="Folder used for native SWDM folder import.")
    parser.add_argument("--runtime-dir", type=Path, required=True, help="Exact SWTools runtime under test.")
    parser.add_argument("--output-dir", type=Path, required=True)
    parser.add_argument("--solidworks-timeout", type=float, default=60.0)
    parser.add_argument("--save-callback-timeout", type=float, default=30.0)
    parser.add_argument(
        "--expect-name",
        action="append",
        default=["Разработал", "Наименование", "Обозначение", "Масса", "Раздел"],
        help="Expected property name. Can be passed multiple times.",
    )
    args = parser.parse_args(argv)
    try:
        result = run(args)
        print(json.dumps(result, ensure_ascii=True, indent=2))
        return 0
    except Exception as exc:
        args.output_dir.mkdir(parents=True, exist_ok=True)
        result_path = args.output_dir / "property-import-save-reload-result.json"
        if not result_path.exists():
            partial = {
                "status": "FAIL",
                "production_go_allowed": False,
                "error": str(exc),
                "traceback": traceback.format_exc(),
            }
            write_json(result_path, partial)
        print(str(exc), file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
