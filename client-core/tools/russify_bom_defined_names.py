#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Replace the legacy Chinese defined names (named ranges) in the shipped BOM
template with their canonical Russian equivalents.

The Russian BOM template (``Шаблоны спецификации/bom_шаблон.xlsx``) historically
carried two parallel sets of defined names anchoring the export cells:

  * the original abbreviated Chinese names copied from the upstream template
    (``零名``, ``图``, ``材`` ...), and
  * Russian aliases added later (``Номер``, ``Количество``, ``Путь`` ...).

The exporter resolves an anchor by ``workbook.GetName(<mappingname|HeaderText>)``,
so the defined name in the workbook must match the token used by ZTool. This
tool removes the Chinese set entirely and leaves a single, fully Russian set of
defined names anchoring the exact same cells, so the project no longer ships any
Chinese identifiers while keeping every export anchor working.

Only ``xl/workbook.xml`` is rewritten (the ``<definedNames>`` block); every other
part of the workbook (worksheets, styles, drawings, merged cells, print areas)
is copied byte-for-byte so layout/behavior is unchanged. The transform is
idempotent: running it on an already-russified workbook is a no-op.

Usage:
  python russify_bom_defined_names.py [path/to/bom_шаблон.xlsx]
Exit code 0 = workbook is (now) fully Russian, 1 = a problem was found.
"""
from __future__ import annotations

import re
import sys
import zipfile
from pathlib import Path

DEFAULT_TARGET = Path("Шаблоны спецификации") / "bom_шаблон.xlsx"
SHEET = "Спецификация"

# Canonical Russian defined names -> anchor cell on the spec sheet. This is the
# single source of truth for the export anchors; it must stay in sync with
# <namemappinglist> in SWTools.settings and SERVICE_HEADERS in
# check_bom_template.py.
ANCHORS = {
    "Номер": "A6",
    "Наименование": "C6",
    "Обозначение": "D6",
    "Версия": "E6",
    "ЕдИзм": "F6",
    "Количество": "G6",
    "Тип": "H6",
    "ОбработкаПоверхности": "I6",
    "Масса": "J6",
    "ИмяФайла": "L6",
    "Эскиз": "M6",
    "Материал": "N6",
    "Путь": "O6",
    "Габарит": "P6",
}

# Print ranges are kept verbatim (sheet-scoped helper names, not export anchors).
PRINT_NAMES = (
    '<definedName name="_xlnm.Print_Titles" localSheetId="0">'
    "'%s'!$1:$6</definedName>" % SHEET,
    '<definedName name="_xlnm.Print_Area" localSheetId="0">'
    "'%s'!$A$1:$P$75</definedName>" % SHEET,
)

# Legacy Chinese defined names that must not survive anywhere in the workbook.
CHINESE_NAMES = ["版", "表处", "材", "磁文名", "类", "零名",
                 "路", "缩图", "统数", "图", "序", "重"]


def build_defined_names_block() -> str:
    parts = ['<definedName name="%s">\'%s\'!$%s</definedName>'
             % (name, SHEET, cell[0] + "$" + cell[1:])
             for name, cell in ANCHORS.items()]
    parts.extend(PRINT_NAMES)
    return "<definedNames>" + "".join(parts) + "</definedNames>"


def russify_workbook_xml(xml: str) -> str:
    new_block = build_defined_names_block()
    if "<definedNames>" in xml:
        xml = re.sub(r"<definedNames>.*?</definedNames>", lambda _m: new_block,
                     xml, count=1, flags=re.S)
    else:  # no defined names at all - insert after </sheets>
        xml = xml.replace("</sheets>", "</sheets>" + new_block, 1)
    return xml


def assert_no_chinese(zf: zipfile.ZipFile) -> list[str]:
    """Return a list of (file -> chinese name) problems across the workbook."""
    problems = []
    for info in zf.infolist():
        if not info.filename.endswith(".xml"):
            continue
        txt = zf.read(info.filename).decode("utf-8", "replace")
        for name in CHINESE_NAMES:
            if name in txt:
                problems.append("%s still references %r" % (info.filename, name))
    return problems


def main() -> int:
    try:
        sys.stdout.reconfigure(encoding="utf-8")
    except Exception:
        pass

    repo_root = Path(__file__).resolve().parents[2]
    target = Path(sys.argv[1]) if len(sys.argv) > 1 else repo_root / DEFAULT_TARGET
    if not target.exists():
        sys.exit("BOM template not found: %s" % target)

    # Safety: the Chinese names must only live in workbook.xml definedNames; if a
    # worksheet formula referenced them, rewriting would break the workbook.
    with zipfile.ZipFile(target, "r") as zin:
        for info in zin.infolist():
            if not info.filename.endswith(".xml") or info.filename == "xl/workbook.xml":
                continue
            txt = zin.read(info.filename).decode("utf-8", "replace")
            stray = [n for n in CHINESE_NAMES if n in txt]
            if stray:
                sys.exit("ERROR: %s references Chinese name(s) %s outside "
                         "workbook.xml; aborting." % (info.filename, stray))
        members = zin.infolist()
        payload = {m.filename: zin.read(m.filename) for m in members}

    payload["xl/workbook.xml"] = russify_workbook_xml(
        payload["xl/workbook.xml"].decode("utf-8")).encode("utf-8")

    tmp = target.with_suffix(".xlsx.tmp")
    with zipfile.ZipFile(target, "r") as zin, \
            zipfile.ZipFile(tmp, "w", zipfile.ZIP_DEFLATED) as zout:
        for m in zin.infolist():
            zi = zipfile.ZipInfo(m.filename, date_time=m.date_time)
            zi.compress_type = m.compress_type
            zi.external_attr = m.external_attr
            zi.internal_attr = m.internal_attr
            zi.create_system = m.create_system
            zout.writestr(zi, payload[m.filename])
    tmp.replace(target)

    with zipfile.ZipFile(target, "r") as zf:
        problems = assert_no_chinese(zf)
        names = sorted(
            re.findall(r'<definedName name="([^"]+)"',
                       zf.read("xl/workbook.xml").decode("utf-8")))
    if problems:
        print("FAIL: Chinese identifiers remain:")
        for p in problems:
            print("  -", p)
        return 1
    print("wrote:", target)
    print("defined names (%d): %s" % (len(names), names))
    print("RESULT: PASS - workbook defined names are fully Russian.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
