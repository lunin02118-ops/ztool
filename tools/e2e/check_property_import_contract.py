#!/usr/bin/env python3
"""Guard the native SW Document Manager property import control-flow.

The "Задать имя свойства -> Импорт... -> Получить из файла/папки" paths must
match the original native design: read document-level and configuration-level
custom property names through SolidWorks Document Manager only.

Do not hide SWDM license/environment failures by opening the model through the
live SolidWorks API. "Получить из открытых в SolidWorks компонентов" is a
separate explicit command and may use SolidWorks; file/folder import must not.
"""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[2]
MYSWDM = REPO_ROOT / "client-src" / "ZTool" / "MySWDM.cs"
FRMSETPROPNAME = REPO_ROOT / "client-src" / "ZTool" / "Frmsetpropname.cs"


def extract_method(source: str, signature: str) -> str:
    start = source.find(signature)
    if start < 0:
        raise AssertionError(f"method not found: {signature}")
    brace = source.find("{", start)
    if brace < 0:
        raise AssertionError(f"method body not found: {signature}")
    depth = 0
    for pos in range(brace, len(source)):
        char = source[pos]
        if char == "{":
            depth += 1
        elif char == "}":
            depth -= 1
            if depth == 0:
                return source[start : pos + 1]
    raise AssertionError(f"unterminated method body: {signature}")


def assert_configuration_properties_are_not_gated(method: str, name: str) -> None:
    doc_idx = method.find("swDMDocument.GetCustomPropertyNames()")
    cfg_idx = method.find("swDMDocument.ConfigurationManager")
    if doc_idx < 0:
        raise AssertionError(f"{name}: document property scan is missing")
    if cfg_idx < 0:
        raise AssertionError(f"{name}: configuration property scan is missing")
    if cfg_idx < doc_idx:
        raise AssertionError(f"{name}: configuration scan must follow document scan")

    between = method[doc_idx:cfg_idx]
    forbidden_patterns = [
        r"if\s*\(\s*Information\.IsNothing\s*\(\s*RuntimeHelpers\.GetObjectValue\s*\(\s*objectValue\s*\)\s*\)\s*\)\s*\{\s*continue\s*;",
        r"if\s*\(\s*Information\.IsNothing\s*\(\s*RuntimeHelpers\.GetObjectValue\s*\(\s*objectValue\s*\)\s*\)\s*\)\s*\{\s*return\s+list\s*;",
    ]
    for pattern in forbidden_patterns:
        if re.search(pattern, between, flags=re.DOTALL):
            raise AssertionError(
                f"{name}: document-level empty properties must not skip configuration properties"
            )

    cfg_names_idx = method.find("configurationManager.GetConfigurationNames()", cfg_idx)
    if cfg_names_idx < 0:
        raise AssertionError(f"{name}: configuration names are not enumerated")
    cfg_tail = method[cfg_names_idx:]
    if "swDMConfiguration.GetCustomPropertyNames()" not in cfg_tail:
        raise AssertionError(f"{name}: configuration custom property names are not read")


def assert_file_folder_import_is_native_only(method: str, name: str) -> None:
    required_tokens = [
        "swDocMgr",
        ".GetDocument(",
        "SwDmDocumentOpenError result",
        "RecordDocumentManagerOpenError",
        "swDMDocument.GetCustomPropertyNames()",
        "configurationManager.GetConfigurationNames()",
        "swDMConfiguration.GetCustomPropertyNames()",
        "swDMDocument.CloseDoc()",
        "logopathlist.WriteLog",
    ]
    for token in required_tokens:
        if token not in method:
            raise AssertionError(f"{name}: native SWDM import contract is missing {token!r}")

    forbidden_tokens = [
        "TryAddSolidWorksOpenDocumentPropertyNames",
        "OpenSolidWorksDocumentForPropertyImport",
        "FindSolidWorksOpenDocumentByPath",
        "AddPropertyNamesFromModelDoc",
        "OpenDoc6",
        "GetOpenDocumentByName",
        "GetFirstDocument",
        "CustomPropertyManager",
        "code.RunSW",
        "code.swApp",
    ]
    for token in forbidden_tokens:
        if token in method:
            raise AssertionError(f"{name}: file/folder import must not use live SolidWorks fallback {token!r}")


def assert_no_fallback_helpers(source: str) -> None:
    forbidden_helpers = [
        "TryAddSolidWorksOpenDocumentPropertyNames",
        "OpenSolidWorksDocumentForPropertyImport",
        "FindSolidWorksOpenDocumentByPath",
        "AddPropertyNamesFromModelDoc",
    ]
    for token in forbidden_helpers:
        if token in source:
            raise AssertionError(f"MySWDM must not contain fallback helper {token!r}")


def assert_ui_surfaces_native_failure(frm_source: str) -> None:
    for name, signature in {
        "AddPropertyNamesFromfile_Click": "private void AddPropertyNamesFromfile_Click",
        "AddPropertyNamesFromFolder_Click": "private void AddPropertyNamesFromFolder_Click",
    }.items():
        method = extract_method(frm_source, signature)
        if "propertyNames.Count == 0" not in method or "MySWDM.err" not in method:
            raise AssertionError(f"{name}: native SWDM failure must be shown to the user")
        if "MessageBox.Show(MySWDM.err" not in method:
            raise AssertionError(f"{name}: must show SWDM error instead of silent empty import")


def check_source(path: Path = MYSWDM) -> None:
    source = path.read_text(encoding="utf-8-sig")
    assert_no_fallback_helpers(source)

    methods = {
        "GetPropertyNames1": "internal List<string> GetPropertyNames1()",
        "GetPropertyNames2": "internal List<string> GetPropertyNames2()",
    }
    for name, signature in methods.items():
        method = extract_method(source, signature)
        assert_configuration_properties_are_not_gated(method, name)
        assert_file_folder_import_is_native_only(method, name)

    frm_source = FRMSETPROPNAME.read_text(encoding="utf-8-sig")
    assert_ui_surfaces_native_failure(frm_source)


def self_test() -> None:
    early_continue = """
    internal List<string> GetPropertyNames1()
    {
        object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
        if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
        {
            continue;
        }
        SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
        object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
        objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
        swDMDocument.CloseDoc();
    }
    """
    try:
        assert_configuration_properties_are_not_gated(early_continue, "early_continue")
    except AssertionError:
        pass
    else:
        raise AssertionError("self-test failed: early continue was accepted")

    fallback = """
    internal List<string> GetPropertyNames1()
    {
        SwDMDocument swDMDocument = swDocMgr.GetDocument(path, type, true, out result);
        TryAddSolidWorksOpenDocumentPropertyNames(path, list);
        code.RunSW(false, false);
        OpenDoc6(path, 1, 1, "", 0, 0);
        object mgr = model.Extension.CustomPropertyManager("");
        return list;
    }
    """
    try:
        assert_file_folder_import_is_native_only(fallback, "fallback")
    except AssertionError:
        pass
    else:
        raise AssertionError("self-test failed: live fallback was accepted")

    no_diagnostics = """
    internal List<string> GetPropertyNames1()
    {
        SwDmDocumentOpenError result = 0;
        SwDMDocument swDMDocument = swDocMgr.GetDocument(path, type, true, out result);
        object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
        AddPropertyNamesFromEnumerable(list, objectValue);
        SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
        object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
        objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
        swDMDocument.CloseDoc();
        logopathlist.WriteLog("x");
    }
    """
    try:
        assert_file_folder_import_is_native_only(no_diagnostics, "no_diagnostics")
    except AssertionError:
        pass
    else:
        raise AssertionError("self-test failed: missing native diagnostics was accepted")

    good_native = """
    internal List<string> GetPropertyNames1()
    {
        SwDmDocumentOpenError result = 0;
        SwDMDocument swDMDocument = swDocMgr.GetDocument(path, type, true, out result);
        if (Information.IsNothing(swDMDocument))
        {
            RecordDocumentManagerOpenError("ctx", path, result);
            continue;
        }
        object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
        AddPropertyNamesFromEnumerable(list, objectValue);
        SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
        object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
        objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
        swDMDocument.CloseDoc();
        logopathlist.WriteLog("x");
    }
    """
    assert_configuration_properties_are_not_gated(good_native, "good_native")
    assert_file_folder_import_is_native_only(good_native, "good_native")


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args(argv)
    if args.self_test:
        self_test()
    else:
        check_source()
    print("property import native contract: PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
