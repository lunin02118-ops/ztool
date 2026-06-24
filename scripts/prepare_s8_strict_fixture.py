#!/usr/bin/env python3
"""Prepare a deterministic RU SolidWorks fixture for strict S8 BOM filters.

The script copies the source TestModel directory to an ignored fixture folder,
opens the copied assembly in SolidWorks, writes Russian custom properties into
the copied assembly/components, verifies the read-back, and writes a manifest.

It intentionally never edits the tracked source model in-place.
"""

from __future__ import annotations

import argparse
import importlib
import json
import os
import shutil
import sys
import time
from datetime import datetime, timezone
from pathlib import Path
from typing import Any


def require_module(name: str) -> Any:
    try:
        return importlib.import_module(name)
    except Exception as exc:  # pragma: no cover - live environment guard
        raise SystemExit(f"Missing Python module '{name}': {exc}") from exc


win32com = require_module("win32com.client")
pythoncom = require_module("pythoncom")
from win32com.client import VARIANT  # noqa: E402


swDocPART = 1
swDocASSEMBLY = 2
swCustomInfoText = 30
swCustomPropertyReplaceValue = 2
swComponentFullyResolved = 3
swOpenDocOptions_Silent = 1
swSaveAsOptions_Silent = 1

PROCESSED_VALUES = ["Мех.обработка", "Листовая", "Литьё", "Сварка"]
PURCHASED_VALUES = ["Покупное", "Стандартное"]
ASSEMBLY_VALUE = "Сборка"

PURCHASED_STEMS = {
    # Loaded by 0614-A00 and selected to reproduce the historical strict
    # 18/6 fixture split: 18 processed parts and 6 purchased parts.
    "PArt-003",
    "PArt-009",
    "PArt-010",
    "PArt-020",
    "PArt-023",
    "PArt-024",
    # Standard hardware names kept for future TestModel variants.
    "DBTS10-12-15",
    "DBTS3-12-4",
    "HNT1-SUS-M3",
    "HNT1-SUS-M4",
    "MSSFS3-5",
    "NKJ3-5",
    "RGOS3-20",
    "WLM-0608-10",
    "WSSS8-3-1",
}

PROPERTY_NAMES = [
    "Разработал",
    "Наименование",
    "Обозначение",
    "Материал",
    "Тип",
    "Версия",
    "Обработка поверхности",
    "Дата разработки",
    "Масса",
]


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


def clean_copy(source_dir: Path, fixture_dir: Path, force: bool) -> None:
    if fixture_dir.exists():
        if not force:
            raise RuntimeError(f"fixture dir already exists; pass --force to replace: {fixture_dir}")
        shutil.rmtree(fixture_dir)
    fixture_dir.parent.mkdir(parents=True, exist_ok=True)
    shutil.copytree(source_dir, fixture_dir)


def wait_for_solidworks(timeout: float) -> Any:
    deadline = time.time() + timeout
    last_error = ""
    while time.time() < deadline:
        try:
            return win32com.GetActiveObject("SldWorks.Application")
        except Exception as exc:
            last_error = str(exc)
            time.sleep(1.0)
    raise RuntimeError(f"SolidWorks COM object not available: {last_error}")


def get_or_start_solidworks(assembly_path: Path, timeout: float) -> Any:
    try:
        return wait_for_solidworks(timeout=5.0)
    except RuntimeError:
        os.startfile(str(assembly_path))
        return wait_for_solidworks(timeout=timeout)


def open_assembly(sw: Any, assembly_path: Path, timeout: float) -> Any:
    model_norm = str(assembly_path.resolve()).lower()
    try:
        active = sw.ActiveDoc
        if active is not None and str(call_or_value(active, "GetPathName")).lower() == model_norm:
            return active
    except Exception:
        pass

    try:
        errors = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        warnings = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        doc = sw.OpenDoc6(str(assembly_path), swDocASSEMBLY, swOpenDocOptions_Silent, "", errors, warnings)
        if doc is not None:
            return doc
    except Exception:
        pass

    os.startfile(str(assembly_path))
    deadline = time.time() + timeout
    while time.time() < deadline:
        try:
            active = sw.ActiveDoc
            if active is not None and str(call_or_value(active, "GetPathName")).lower() == model_norm:
                return active
        except Exception:
            pass
        time.sleep(1.0)
    raise RuntimeError(f"copied fixture assembly did not become active: {assembly_path}")


def open_doc_by_path(sw: Any, doc_path: Path) -> Any | None:
    suffix = doc_path.suffix.lower()
    if suffix == ".sldasm":
        doc_type = swDocASSEMBLY
    elif suffix == ".sldprt":
        doc_type = swDocPART
    else:
        return None
    try:
        errors = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        warnings = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
        return sw.OpenDoc6(str(doc_path), doc_type, swOpenDocOptions_Silent, "", errors, warnings)
    except Exception:
        return None


def document_paths_from_assembly(sw: Any, asm: Any) -> dict[str, Any]:
    docs: dict[str, Any] = {}
    path = str(call_or_value(asm, "GetPathName"))
    if path:
        docs[path] = asm
    try:
        comps = asm.GetComponents(False)
    except Exception:
        comps = None
    for comp in comps or []:
        try:
            try:
                if bool(call_or_value(comp, "IsSuppressed")):
                    continue
            except Exception:
                pass
            comp_path = str(call_or_value(comp, "GetPathName"))
            if not comp_path:
                continue
            if comp_path in docs:
                continue
            model = open_doc_by_path(sw, Path(comp_path))
            if model is not None:
                docs[comp_path] = model
        except Exception:
            continue
    return docs


def config_scopes(model: Any) -> list[str]:
    scopes = [""]
    try:
        names = model.GetConfigurationNames()
        if names:
            scopes.extend([str(name) for name in names])
    except Exception:
        pass
    return list(dict.fromkeys(scopes))


def get_raw_value(cpm: Any, name: str) -> str:
    val_out = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_BSTR, "")
    resolved = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_BSTR, "")
    was_resolved = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_BOOL, False)
    try:
        cpm.Get5(name, False, val_out, resolved, was_resolved)
    except Exception:
        return ""
    return str(val_out.value or resolved.value or "")


def set_prop(cpm: Any, name: str, value: str) -> None:
    cpm.Add3(name, swCustomInfoText, value, swCustomPropertyReplaceValue)


def classify_type_value(model: Any, path: Path) -> str:
    doc_type = int(call_or_value(model, "GetType"))
    if doc_type == swDocASSEMBLY:
        return ASSEMBLY_VALUE
    if path.stem in PURCHASED_STEMS:
        return PURCHASED_VALUES[0]
    return PROCESSED_VALUES[0]


def property_values(model: Any, path: Path, type_value: str) -> dict[str, str]:
    file_name = path.name
    stem = path.stem
    is_part = int(call_or_value(model, "GetType")) == swDocPART
    return {
        "Разработал": "",
        "Наименование": stem,
        "Обозначение": stem,
        "Материал": f"SW-Material@{file_name}" if is_part else "",
        "Тип": type_value,
        "Версия": "",
        "Обработка поверхности": "",
        "Дата разработки": "",
        "Масса": f"SW-Mass@{file_name}",
    }


def write_and_verify_document(model: Any, path: Path) -> dict[str, Any]:
    type_value = classify_type_value(model, path)
    values = property_values(model, path, type_value)
    scopes = config_scopes(model)
    written = 0
    verification: list[dict[str, str]] = []
    for scope in scopes:
        cpm = model.Extension.CustomPropertyManager(scope)
        for name, value in values.items():
            set_prop(cpm, name, value)
            written += 1
        actual_type = get_raw_value(cpm, "Тип")
        verification.append({"scope": scope or "<doc>", "expected_type": type_value, "actual_type": actual_type})
        if actual_type != type_value:
            raise RuntimeError(f"{path.name}: Тип read-back mismatch in scope {scope!r}: {actual_type!r} != {type_value!r}")
    errors = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
    warnings = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
    model.Save3(swSaveAsOptions_Silent, errors, warnings)
    return {
        "path": str(path),
        "type": type_value,
        "scopes": scopes,
        "properties_written": written,
        "verification": verification,
        "save_errors": int(errors.value),
        "save_warnings": int(warnings.value),
    }


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--source-assembly", required=True, type=Path)
    parser.add_argument("--fixture-dir", required=True, type=Path)
    parser.add_argument("--manifest", required=True, type=Path)
    parser.add_argument("--force", action="store_true")
    parser.add_argument("--timeout", type=float, default=120.0)
    args = parser.parse_args()

    normalize_env()
    source_assembly = args.source_assembly.resolve()
    if not source_assembly.is_file():
        raise SystemExit(f"source assembly not found: {source_assembly}")
    source_dir = source_assembly.parent
    fixture_dir = args.fixture_dir.resolve()
    clean_copy(source_dir, fixture_dir, force=args.force)
    fixture_assembly = fixture_dir / source_assembly.name
    if not fixture_assembly.is_file():
        raise SystemExit(f"fixture assembly copy not found: {fixture_assembly}")

    sw = get_or_start_solidworks(fixture_assembly, timeout=args.timeout)
    asm = open_assembly(sw, fixture_assembly, timeout=args.timeout)
    docs = document_paths_from_assembly(sw, asm)
    if len(docs) < 2:
        raise RuntimeError("fixture assembly has no resolved component documents")

    fixture_prefix = str(fixture_dir).lower()
    prepared: list[dict[str, Any]] = []
    type_counts: dict[str, int] = {}
    for doc_path, model in sorted(docs.items(), key=lambda item: item[0].lower()):
        resolved = Path(doc_path).resolve()
        if not str(resolved).lower().startswith(fixture_prefix):
            raise RuntimeError(
                "SolidWorks resolved a component outside the copied fixture; "
                f"refusing to edit tracked/source CAD: {resolved}"
            )
        entry = write_and_verify_document(model, resolved)
        prepared.append(entry)
        type_counts[entry["type"]] = type_counts.get(entry["type"], 0) + 1

    manifest = {
        "schema_version": "1.0",
        "generated_at": datetime.now(timezone.utc).isoformat(),
        "source_assembly": str(source_assembly),
        "fixture_dir": str(fixture_dir),
        "assembly_path": str(fixture_assembly),
        "required_properties": PROPERTY_NAMES,
        "type_values": {
            "processed": PROCESSED_VALUES,
            "purchased": PURCHASED_VALUES,
            "assembly": [ASSEMBLY_VALUE],
        },
        "expected_modes": {
            "7": {"min_rows": 1, "values": PROCESSED_VALUES},
            "8": {"min_rows": 1, "values": PURCHASED_VALUES},
        },
        "type_counts_by_document": type_counts,
        "documents": prepared,
    }
    args.manifest.parent.mkdir(parents=True, exist_ok=True)
    args.manifest.write_text(json.dumps(manifest, ensure_ascii=False, indent=2), encoding="utf-8")
    print(json.dumps(manifest, ensure_ascii=False, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
