#!/usr/bin/env python3
"""Guard the SW property-name import control flow.

The "Задать имя свойства -> Импорт... -> Получить из файла/папки" path must
collect both document-level and configuration-level custom property names.

Regression history:
- The original working SW2025 fix is commit 4cf4897 / 84902b6, then ported to
  client-src by de7bd3c.
- It tries SolidWorks Document Manager first.
- If SWDM cannot read a selected file on the installed SWDM runtime, the path
  must read the same file through the live SolidWorks ModelDoc custom property
  managers instead of returning an empty import list.

This script intentionally protects that previously accepted behavior. It is not
a license-key scanner and it must not be weakened back to a silent native-only
empty result.
"""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[2]
MYSWDM = REPO_ROOT / "client-src" / "ZTool" / "MySWDM.cs"


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


def assert_swdm_has_live_solidworks_parity_path(source: str, method: str, name: str) -> None:
    if "TryAddSolidWorksOpenDocumentPropertyNames" not in source:
        raise AssertionError("live SolidWorks parity helper is missing")
    if "AddPropertyNamesFromModelDoc" not in source:
        raise AssertionError("live ModelDoc property enumeration helper is missing")

    required_tokens = [
        "swDocMgr",
        ".GetDocument(",
        "SwDmDocumentOpenError result",
        "TryAddSolidWorksOpenDocumentPropertyNames(",
        "swDMDocument.GetCustomPropertyNames()",
        "configurationManager.GetConfigurationNames()",
        "swDMConfiguration.GetCustomPropertyNames()",
        "swDMDocument.CloseDoc()",
        "logopathlist.WriteLog",
    ]
    for token in required_tokens:
        if token not in method:
            raise AssertionError(f"{name}: property import contract is missing {token!r}")


def assert_live_parity_contract(source: str) -> None:
    parity = extract_method(
        source,
        "private static bool TryAddSolidWorksOpenDocumentPropertyNames(string fileName, List<string> list)",
    )
    model_doc = extract_method(
        source,
        "private static void AddPropertyNamesFromModelDoc(object modelDoc, List<string> list)",
    )
    finder = extract_method(
        source,
        "private static object FindSolidWorksOpenDocumentByPath(string fileName)",
    )
    opener = extract_method(
        source,
        "private static object OpenSolidWorksDocumentForPropertyImport(string fileName, out bool openedForImport)",
    )
    closer = extract_method(
        source,
        "private static void CloseSolidWorksDocumentOpenedForPropertyImport(object modelDoc, string fileName)",
    )

    required_parity_tokens = [
        "code.swApp",
        "code.RunSW",
        "OpenSolidWorksDocumentForPropertyImport",
        "AddPropertyNamesFromModelDoc",
        "CloseSolidWorksDocumentOpenedForPropertyImport",
    ]
    for token in required_parity_tokens:
        if token not in parity:
            raise AssertionError(f"live parity helper does not use {token}")

    required_finder_tokens = [
        "GetOpenDocumentByName",
        "GetFirstDocument",
        "GetPathName",
        "GetNext",
        "NormalizePathForCompare",
    ]
    for token in required_finder_tokens:
        if token not in finder:
            raise AssertionError(f"live document finder does not use {token}")

    required_opener_tokens = [
        "GetSolidWorksDocumentType",
        "OpenDoc6",
        "openedForImport = true",
    ]
    for token in required_opener_tokens:
        if token not in opener:
            raise AssertionError(f"live document opener does not use {token}")

    required_closer_tokens = [
        "GetTitle",
        "CloseDoc",
    ]
    for token in required_closer_tokens:
        if token not in closer:
            raise AssertionError(f"live document closer does not use {token}")

    required_model_tokens = [
        "GetConfigurationNames",
        "CustomPropertyManager",
        "GetNames",
        "AddPropertyNamesFromEnumerable",
    ]
    for token in required_model_tokens:
        if token not in model_doc:
            raise AssertionError(f"live ModelDoc helper does not use {token}")


def check_source(path: Path = MYSWDM) -> None:
    source = path.read_text(encoding="utf-8-sig")
    methods = {
        "GetPropertyNames1": "internal List<string> GetPropertyNames1()",
        "GetPropertyNames2": "internal List<string> GetPropertyNames2()",
    }
    for name, signature in methods.items():
        method = extract_method(source, signature)
        assert_configuration_properties_are_not_gated(method, name)
        assert_swdm_has_live_solidworks_parity_path(source, method, name)
    assert_live_parity_contract(source)


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

    no_parity_source = """
    private static void AddPropertyNamesFromModelDoc(object modelDoc, List<string> list) {}
    internal List<string> GetPropertyNames1()
    {
        SwDMDocument swDMDocument = swDocMgr.GetDocument(path, type, true, out result);
        logopathlist.WriteLog("failure");
        return list;
    }
    """
    no_parity_method = extract_method(no_parity_source, "internal List<string> GetPropertyNames1()")
    try:
        assert_swdm_has_live_solidworks_parity_path(no_parity_source, no_parity_method, "no_parity")
    except AssertionError:
        pass
    else:
        raise AssertionError("self-test failed: missing live parity path was accepted")

    good_parity_source = """
    private static bool TryAddSolidWorksOpenDocumentPropertyNames(string fileName, List<string> list)
    {
        object app = code.swApp;
        code.RunSW(HideWindow: false, startnew: false);
        bool openedForImport = false;
        object model = OpenSolidWorksDocumentForPropertyImport(fileName, out openedForImport);
        AddPropertyNamesFromModelDoc(model, list);
        CloseSolidWorksDocumentOpenedForPropertyImport(model, fileName);
        return true;
    }
    private static object FindSolidWorksOpenDocumentByPath(string fileName)
    {
        object model = code.swApp.GetOpenDocumentByName(fileName);
        model = app.GetFirstDocument();
        string path = model.GetPathName();
        model = model.GetNext();
        NormalizePathForCompare(path);
        return model;
    }
    private static object OpenSolidWorksDocumentForPropertyImport(string fileName, out bool openedForImport)
    {
        openedForImport = false;
        GetSolidWorksDocumentType(fileName);
        object model = code.swApp.OpenDoc6(fileName, 1, 1, "", 0, 0);
        openedForImport = true;
        return model;
    }
    private static void CloseSolidWorksDocumentOpenedForPropertyImport(object modelDoc, string fileName)
    {
        string title = modelDoc.GetTitle();
        code.swApp.CloseDoc(title);
    }
    private static void AddPropertyNamesFromModelDoc(object modelDoc, List<string> list)
    {
        modelDoc.GetConfigurationNames();
        object mgr = modelDoc.Extension.CustomPropertyManager("");
        object names = mgr.GetNames();
        AddPropertyNamesFromEnumerable(list, names);
    }
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
        TryAddSolidWorksOpenDocumentPropertyNames(path, list);
        logopathlist.WriteLog("failure");
        return list;
    }
    """
    good_parity_method = extract_method(good_parity_source, "internal List<string> GetPropertyNames1()")
    assert_configuration_properties_are_not_gated(good_parity_method, "good_parity")
    assert_swdm_has_live_solidworks_parity_path(
        good_parity_source, good_parity_method, "good_parity"
    )
    assert_live_parity_contract(good_parity_source)


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args(argv)
    if args.self_test:
        self_test()
    else:
        check_source()
    print("property import contract: PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
