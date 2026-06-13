"""
Reformat bom_шаблон.xlsx for professional Russian appearance:
1. Rename sheet from 图明1 → Спецификация
2. Change all fonts from 宋 → Arial
3. Proper column widths
4. Proper row heights (especially for thumbnails)
5. Header formatting (bold, centered, borders)
6. Update defined names to reference new sheet name
7. Fix alignment and number formats
"""
import os
from openpyxl import load_workbook
from openpyxl.styles import Font, Alignment, Border, Side, PatternFill
from openpyxl.workbook.defined_name import DefinedName

# Resolve the template relative to the repo root so the script works no matter
# what the current working directory is.
_ROOT = os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))
TEMPLATE = os.path.join(_ROOT, "Шаблоны спецификации", "bom_шаблон.xlsx")
OUTPUT = TEMPLATE

OLD_SHEET = "图明1"
NEW_SHEET = "Спецификация"

# Re-run safe: also treat an already-renamed sheet as the source.
SONG = "宋"  # leftover vendor CJK font (SimSun) that must be purged everywhere

# Professional font
FONT_TITLE = Font(name="Arial", size=16, bold=True)
FONT_HEADER = Font(name="Arial", size=10, bold=True)
FONT_META = Font(name="Arial", size=10, bold=False)
FONT_DATA = Font(name="Arial", size=10, bold=False)

# Alignment
ALIGN_CENTER = Alignment(horizontal="center", vertical="center", wrap_text=True)
ALIGN_LEFT = Alignment(horizontal="left", vertical="center", wrap_text=False)
ALIGN_LEFT_WRAP = Alignment(horizontal="left", vertical="center", wrap_text=True)

# Border
THIN_BORDER = Border(
    left=Side(style="thin"),
    right=Side(style="thin"),
    top=Side(style="thin"),
    bottom=Side(style="thin"),
)

HEADER_FILL = PatternFill(start_color="D9E1F2", end_color="D9E1F2", fill_type="solid")

# Column widths (optimized for Russian text)
COL_WIDTHS = {
    "A": 5.5,    # № п/п
    "B": 12.0,   # Код материала
    "C": 18.0,   # Наименование
    "D": 16.0,   # Обозначение
    "E": 8.0,    # Версия
    "F": 7.0,    # Ед. изм.
    "G": 7.5,    # Кол-во
    "H": 10.0,   # Тип обработки
    "I": 18.0,   # Обработка поверхности
    "J": 8.0,    # Масса
    "K": 12.0,   # Примечание
    "L": 16.0,   # Имя файла
    "M": 12.0,   # Эскиз (for thumbnails)
    "N": 14.0,   # Материал
    "O": 35.0,   # Путь
}

# Data row height
DATA_ROW_HEIGHT = 20.0
# Thumbnail row height (for modes with images)
THUMBNAIL_ROW_HEIGHT = 50.0


def main():
    wb = load_workbook(TEMPLATE)
    ws = wb.active

    # 1. Rename sheet
    ws.title = NEW_SHEET
    print(f"[1] Sheet renamed: {OLD_SHEET} → {NEW_SHEET}")

    # 1b. BULLETPROOF: purge the leftover CJK font (宋/SimSun) from EVERY cell in a
    # generous range. ZTool's exporter clones the style of whatever template row
    # sits at the data anchor when inserting data rows, so a single stray 宋 cell
    # in that path makes exported data render in SimSun. We normalise the whole
    # used range (plus margin) to Arial, preserving size/bold/italic/color.
    # Bound the scan to the EXISTING used range so we don't materialise new
    # (empty, bordered) rows/cols and bloat the template.
    max_row, max_col = ws.max_row, ws.max_column
    purged = 0
    for row in range(1, max_row + 1):
        for col in range(1, max_col + 1):
            cell = ws.cell(row=row, column=col)
            fn = cell.font
            if fn.name and fn.name != "Arial":
                cell.font = Font(
                    name="Arial",
                    size=fn.size or 10,
                    bold=fn.bold,
                    italic=fn.italic,
                    color=fn.color,
                )
                purged += 1
    print(f"[1b] Purged non-Arial font from {purged} cells (宋 → Arial)")

    # 2. Update all defined names to reference new sheet
    names_to_update = {}
    for name, defn in list(wb.defined_names.items()):
        old_ref = defn.attr_text
        if OLD_SHEET in old_ref:
            new_ref = old_ref.replace(OLD_SHEET, NEW_SHEET)
            names_to_update[name] = new_ref

    for name, new_ref in names_to_update.items():
        del wb.defined_names[name]
        new_defn = DefinedName(name=name, attr_text=new_ref)
        wb.defined_names.add(new_defn)
        print(f"  Updated name: {name} → {new_ref}")

    # 3. Set column widths
    for col, width in COL_WIDTHS.items():
        ws.column_dimensions[col].width = width
    print("[2] Column widths set")

    # 4. Format title row (row 1)
    for col in range(1, 16):
        cell = ws.cell(row=1, column=col)
        cell.font = FONT_TITLE
        cell.alignment = ALIGN_CENTER
    ws.row_dimensions[1].height = 28.0
    print("[3] Title row formatted")

    # 5. Format metadata rows (rows 2-5)
    for row in range(2, 6):
        ws.row_dimensions[row].height = 16.0
        for col in range(1, 16):
            cell = ws.cell(row=row, column=col)
            cell.font = FONT_META
            cell.alignment = ALIGN_LEFT
    print("[4] Metadata rows formatted")

    # 6. Format header row (row 6) — bold, centered, with borders and fill
    ws.row_dimensions[6].height = 30.0
    for col in range(1, 16):
        cell = ws.cell(row=6, column=col)
        cell.font = FONT_HEADER
        cell.alignment = ALIGN_CENTER
        cell.border = THIN_BORDER
        cell.fill = HEADER_FILL
    print("[5] Header row formatted (bold, borders, fill)")

    # 7. Format data rows (7 onwards) — borders, proper font, alignment
    for row in range(7, ws.max_row + 1):
        ws.row_dimensions[row].height = DATA_ROW_HEIGHT
        for col in range(1, 16):  # noqa: data columns A..O carry borders
            cell = ws.cell(row=row, column=col)
            cell.font = FONT_DATA
            cell.border = THIN_BORDER
            if col == 1:  # № п/п — center
                cell.alignment = ALIGN_CENTER
            elif col == 7:  # Кол-во — center
                cell.alignment = ALIGN_CENTER
            elif col == 10:  # Масса — center
                cell.alignment = ALIGN_CENTER
            elif col == 15:  # Путь — left, no wrap
                cell.alignment = ALIGN_LEFT
            else:
                cell.alignment = ALIGN_LEFT_WRAP
    print(f"[6] Data rows 7-{ws.max_row} formatted")

    # 8. Set thumbnail column (M) properties for image binding
    # Images in ZTool are inserted with anchor to the cell.
    # Row height needs to accommodate the image (64x48 default).
    # We'll set a reasonable default that works both with and without images.
    # When ZTool exports with images, it may adjust row heights dynamically.
    # M column width = 12 chars ≈ 86px (enough for 64px image + padding)
    ws.column_dimensions["M"].width = 12.0
    print("[7] Thumbnail column M configured")

    # 9. Freeze panes at row 7 (header stays visible when scrolling)
    ws.freeze_panes = "A7"
    print("[8] Freeze panes set at A7")

    # 9b. Page setup: the vendor template printed only A1:K40 (cut off columns
    # L..O and most rows). Make the printout professional: landscape, fit all
    # 15 columns to one page wide, repeat the title+header rows on every page.
    ws.print_area = "A1:O75"
    ws.page_setup.orientation = "landscape"
    ws.page_setup.fitToWidth = 1
    ws.page_setup.fitToHeight = 0
    ws.sheet_properties.pageSetUpPr.fitToPage = True
    ws.print_title_rows = "$1:$6"
    print("[9] Page setup: landscape, fit-to-width, print area A1:O75")

    # 10. Save
    wb.save(OUTPUT)
    print(f"\n[DONE] Saved: {OUTPUT}")
    print(f"  Sheet: {NEW_SHEET}")
    print(f"  Defined names preserved and updated")


if __name__ == "__main__":
    main()
