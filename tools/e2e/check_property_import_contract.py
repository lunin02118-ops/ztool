#!/usr/bin/env python3
"""Guard the SW document property import control-flow.

The "Задать имя свойства -> Импорт... -> Получить из файла/папки" path must
collect both document-level and configuration-level custom property names. A
previous regression returned early when document-level names were absent, so
configuration-only properties silently disappeared from the import result.
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


def check_source(path: Path = MYSWDM) -> None:
    source = path.read_text(encoding="utf-8-sig")
    methods = {
        "GetPropertyNames1": "internal List<string> GetPropertyNames1()",
        "GetPropertyNames2": "internal List<string> GetPropertyNames2()",
    }
    for name, signature in methods.items():
        method = extract_method(source, signature)
        assert_configuration_properties_are_not_gated(method, name)


def self_test() -> None:
    bad = """
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
    }
    """
    try:
        assert_configuration_properties_are_not_gated(bad, "bad")
    except AssertionError:
        pass
    else:
        raise AssertionError("self-test failed: early continue was accepted")

    good = """
    internal List<string> GetPropertyNames1()
    {
        object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
        if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
        {
            foreach (object item in (IEnumerable)objectValue) { }
        }
        SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
        object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
        objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
    }
    """
    assert_configuration_properties_are_not_gated(good, "good")


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
