"""Build the Russian BOM Excel template from the original Chinese one.

Translates ONLY the shared-string header text of BOM表模板/bom模板.xlsx and
writes Шаблоны спецификации/bom_шаблон.xlsx. Every other part of the workbook
(worksheets, styles, column widths, merged cells, drawings, line breaks) is
copied byte-for-byte so the layout/behaviour stays identical to the original.
"""
import glob
import re
import zipfile

SRC = [p for p in glob.glob("BOM*/**", recursive=True) if p.lower().endswith(".xlsx")][0]
OUT_DIR = "Шаблоны спецификации"
OUT = OUT_DIR + "/bom_шаблон.xlsx"

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


def xml_escape(s: str) -> str:
    return s.replace("&", "&amp;").replace("<", "&lt;").replace(">", "&gt;")


def localize_shared_strings(xml: str) -> str:
    it = iter(range(len(RU)))
    counter = {"i": 0}

    def repl(m):
        idx = counter["i"]
        counter["i"] += 1
        if idx >= len(RU):
            return m.group(0)
        open_tag = m.group(1)  # the <t ...> opening tag, attrs preserved
        return open_tag + xml_escape(RU[idx]) + "</t>"

    new_xml, n = re.subn(r"(<t\b[^>]*>).*?</t>", repl, xml, flags=re.S)
    assert n == len(RU), f"expected {len(RU)} <t> elements, replaced {n}"
    assert counter["i"] == len(RU)
    return new_xml


def main():
    import os
    os.makedirs(OUT_DIR, exist_ok=True)
    zin = zipfile.ZipFile(SRC, "r")
    with zipfile.ZipFile(OUT, "w", zipfile.ZIP_DEFLATED) as zout:
        for item in zin.infolist():
            data = zin.read(item.filename)
            if item.filename == "xl/sharedStrings.xml":
                xml = data.decode("utf-8")
                data = localize_shared_strings(xml).encode("utf-8")
            # preserve original metadata (date, external attrs, compress type)
            zi = zipfile.ZipInfo(item.filename, date_time=item.date_time)
            zi.compress_type = item.compress_type
            zi.external_attr = item.external_attr
            zi.internal_attr = item.internal_attr
            zi.create_system = item.create_system
            zout.writestr(zi, data)
    zin.close()
    print("wrote", OUT)


if __name__ == "__main__":
    main()
