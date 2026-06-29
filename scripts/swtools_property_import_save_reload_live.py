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
from pathlib import Path
from typing import Any


REPO_ROOT = Path(__file__).resolve().parents[1]
S7_HELPERS_PATH = REPO_ROOT / "scripts" / "swtools_s7_live_smoke.py"
SWDM_PROBE = REPO_ROOT / "tools" / "e2e" / "check_swdm_property_import_live.py"
HANDSHAKE_TOKEN = "9EF1CBF0BCFAD9F118EA30863B1874"
REQUEST = "ZToolRequest@001" + HANDSHAKE_TOKEN
SEP = "\u001e\u001c"
WM_COPYDATA = 0x004A


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


def open_model(sw: Any, path: Path, timeout: float = 45.0) -> Any:
    path = path.resolve()
    try:
        sw.CloseDoc(path.name)
    except Exception:
        pass
    model = None
    try:
        errors = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        warnings = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        model = sw.OpenDoc6(str(path), file_doc_type(path), 1, "", errors, warnings)
    except Exception:
        model = None
    if model is None:
        deadline = time.time() + timeout
        os.startfile(str(path))
        while time.time() < deadline:
            active = sw.ActiveDoc
            if active is not None and str(call_or_value(active, "GetPathName")).lower() == str(path).lower():
                return active
            time.sleep(0.25)
        raise RuntimeError(f"SolidWorks did not open target model: {path}")
    return model


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
    result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")

    result["steps"]["swdm_file_import"] = run_swdm_probe("file", source_file, output_dir, expected_import_names)
    result["steps"]["swdm_folder_import"] = run_swdm_probe("folder", source_folder, output_dir, expected_import_names)

    pythoncom.CoInitialize()
    receiver: ReceiverWindow | None = None
    try:
        sw = s7.get_or_start_solidworks(fixture_file, timeout=args.solidworks_timeout)
        solidworks_pid = int(call_or_value(sw, "GetProcessID"))
        model = open_model(sw, fixture_file, timeout=args.solidworks_timeout)
        active_path = str(call_or_value(model, "GetPathName"))
        open_names = read_property_names_from_model(model)
        ensure_expected_names("open-components import", open_names, expected_import_names)
        result["steps"]["open_components_import"] = {
            "status": "PASS",
            "solidworks_pid": solidworks_pid,
            "active_path": active_path,
            "property_count": len(open_names),
            "sample": open_names[:30],
        }

        receiver_info = find_receiver_or_fail(solidworks_pid)
        receiver = ReceiverWindow().start()
        send_save_options(int(receiver_info["hwnd"]), receiver.hwnd)
        stamp = time.strftime("%Y%m%d-%H%M%S")
        save_properties = {
            "SWTOOLS_E2E_SAVE_RELOAD": f"PASS-{stamp}",
            "SWTOOLS_E2E_Кириллица": f"Проверка сохранения {stamp}",
        }
        send_result = save_via_addin(int(receiver_info["hwnd"]), receiver.hwnd, fixture_file, save_properties)
        time.sleep(1.0)

        live_values = read_property_values(model, list(save_properties))
        close_model(sw, fixture_file)
        reopened = open_model(sw, fixture_file, timeout=args.solidworks_timeout)
        reloaded_values = read_property_values(reopened, list(save_properties))
        close_model(sw, fixture_file)

        for name, expected in save_properties.items():
            actual = reloaded_values.get(name, {}).get("value") or reloaded_values.get(name, {}).get("resolved")
            if actual != expected:
                raise RuntimeError(f"Reload read-back mismatch for {name!r}: expected {expected!r}, got {actual!r}")

        result["steps"]["save_reload"] = {
            "status": "PASS",
            "receiver": receiver_info,
            "send_result": send_result,
            "callback_messages": receiver.messages,
            "properties_written": save_properties,
            "live_values": live_values,
            "reloaded_values": reloaded_values,
        }
    finally:
        if receiver is not None:
            receiver.stop()
        pythoncom.CoUninitialize()

    result["fixture_file_sha256_after"] = sha256(fixture_file)
    result["status"] = "PASS"
    result_path.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
    return result


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--file", type=Path, required=True, help="SOLIDWORKS part/assembly used for file import and save/reload fixture.")
    parser.add_argument("--folder", type=Path, required=True, help="Folder used for native SWDM folder import.")
    parser.add_argument("--output-dir", type=Path, required=True)
    parser.add_argument("--solidworks-timeout", type=float, default=60.0)
    parser.add_argument(
        "--expect-name",
        action="append",
        default=["Разработал", "Наименование", "Обозначение", "Масса", "Раздел"],
        help="Expected property name. Can be passed multiple times.",
    )
    args = parser.parse_args(argv)
    try:
        result = run(args)
        print(json.dumps(result, ensure_ascii=False, indent=2))
        return 0
    except Exception as exc:
        partial = {
            "status": "FAIL",
            "production_go_allowed": False,
            "error": str(exc),
            "traceback": traceback.format_exc(),
        }
        args.output_dir.mkdir(parents=True, exist_ok=True)
        (args.output_dir / "property-import-save-reload-result.json").write_text(
            json.dumps(partial, ensure_ascii=False, indent=2),
            encoding="utf-8",
        )
        print(str(exc), file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
