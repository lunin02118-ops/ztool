"""Build the Russian BOM Excel template from an explicit Chinese source.

Translates ONLY shared-string header text of ``BOM表模板/bom模板.xlsx`` and
writes ``Шаблоны спецификации/bom_шаблон.xlsx``. Other workbook parts
(worksheets, styles, column widths, merged cells, drawings, line breaks) are
copied unchanged so layout/behavior stays compatible with the original.
"""

from __future__ import annotations

import argparse
import hashlib
import os
import re
import sys
import zipfile
from pathlib import Path


DEFAULT_SRC = Path("BOM表模板") / "bom模板.xlsx"
DEFAULT_OUT = Path("Шаблоны спецификации") / "bom_шаблон.xlsx"
EXPECTED_SHARED_STRINGS = 25

# Ordered Russian replacements for the 25 unique shared strings (uniqueCount=25).
# Index matches the order of <t> elements in xl/sharedStrings.xml.
RU = [
    "Наименование",            # 0  名称
    "Обозначение",             # 1  图号
    "Версия",                  # 2  版本
    "Ед. изм.",                # 3  单位
    "Кол-во",                  # 4  数量
    "Примечание",              # 5  备注
    "Код материала",           # 6  物料编码
    "Обработка поверхности",   # 7  表面处理
    "Масса",                   # 8  单重
    "Имя файла",               # 9  磁盘文件名
    "Эскиз",                   # 10 缩略图
    "Тип\r\nобработки",        # 11 加工\r\n类型  (keep line break)
    "Материал",                # 12 材质
    "Спецификация",            # 13 物料清单
    "Путь",                    # 14 路径
    "№\r\nп/п",                # 15 序\r\n号      (keep line break)
    "Обозначение изделия: XXX",  # 16 设备编号：XXX
    "Наименование изделия: XXX", # 17 设备名称：XXX
    "Номер таблицы:",          # 18 表格编号：
    "Утвердил:",               # 19 批准：
    "Проверил:",               # 20 审核：
    "Составил:",               # 21 编制：
    "Дата:",                   # 22 日期：
    "Модель изделия: XXX",     # 23 设备型号：XXX
    "Версия:",                 # 24 版本：
]


def xml_escape(value: str) -> str:
    return value.replace("&", "&amp;").replace("<", "&lt;").replace(">", "&gt;")


def sha256_file(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def validate_source(path: Path) -> None:
    if not path.exists():
        raise FileNotFoundError(f"BOM template source not found: {path}")
    if not path.is_file():
        raise ValueError(f"BOM template source is not a file: {path}")
    if path.suffix.lower() != ".xlsx":
        raise ValueError(f"BOM template source must be .xlsx: {path}")


def localize_shared_strings(xml: str) -> str:
    counter = {"i": 0}

    def repl(match: re.Match[str]) -> str:
        idx = counter["i"]
        counter["i"] += 1
        if idx >= len(RU):
            return match.group(0)
        open_tag = match.group(1)  # the <t ...> opening tag, attrs preserved
        return open_tag + xml_escape(RU[idx]) + "</t>"

    new_xml, replaced = re.subn(r"(<t\b[^>]*>).*?</t>", repl, xml, flags=re.S)
    if replaced != EXPECTED_SHARED_STRINGS:
        raise ValueError(
            f"expected {EXPECTED_SHARED_STRINGS} shared string <t> elements, got {replaced}"
        )
    if counter["i"] != len(RU):
        raise ValueError(f"replacement count mismatch: {counter['i']} != {len(RU)}")
    return new_xml


def build_template(src: Path, out: Path) -> None:
    validate_source(src)
    out.parent.mkdir(parents=True, exist_ok=True)

    with zipfile.ZipFile(src, "r") as zin:
        names = set(zin.namelist())
        if "xl/sharedStrings.xml" not in names:
            raise ValueError(f"source workbook has no xl/sharedStrings.xml: {src}")
        with zipfile.ZipFile(out, "w", zipfile.ZIP_DEFLATED) as zout:
            for item in zin.infolist():
                data = zin.read(item.filename)
                if item.filename == "xl/sharedStrings.xml":
                    xml = data.decode("utf-8")
                    data = localize_shared_strings(xml).encode("utf-8")
                # Preserve original metadata (date, external attrs, compress type).
                zi = zipfile.ZipInfo(item.filename, date_time=item.date_time)
                zi.compress_type = item.compress_type
                zi.external_attr = item.external_attr
                zi.internal_attr = item.internal_attr
                zi.create_system = item.create_system
                zout.writestr(zi, data)

    print(f"source: {src}")
    print(f"source_sha256: {sha256_file(src)}")
    print(f"wrote: {out}")
    print(f"output_sha256: {sha256_file(out)}")


def main() -> int:
    try:
        sys.stdout.reconfigure(encoding="utf-8")
    except Exception:
        pass

    parser = argparse.ArgumentParser(description="Build Russian BOM Excel template")
    parser.add_argument("--src", type=Path, default=DEFAULT_SRC, help="Explicit source .xlsx")
    parser.add_argument("--out", type=Path, default=DEFAULT_OUT, help="Output .xlsx")
    args = parser.parse_args()

    # Keep relative paths stable from repository root, regardless of caller cwd.
    repo_root = Path(__file__).resolve().parent
    src = args.src if args.src.is_absolute() else repo_root / args.src
    out = args.out if args.out.is_absolute() else repo_root / args.out

    build_template(src, out)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
