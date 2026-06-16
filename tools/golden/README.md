# Golden fixtures for the BOM export asserter (Tier 2)

`tools/bom_export_assert.py` checks an **exported** ZTool BOM workbook against a
golden spec, without SolidWorks. This folder holds:

- `example_bom.xlsx` + `example_bom.golden.json` — a small synthetic example that
  documents the format and is exercised by the `release-acceptance` CI workflow.
  It is **not** a real export; it only proves the asserter and schema work.

## How the two tiers fit together

1. **Trigger (needs SolidWorks, manual or UI-automation):** open
   `TestModel/0614-A00.SLDASM`, run a ZTool BOM export for the mode under test,
   save the produced `.xlsx`.
2. **Verify (deterministic, no SolidWorks — this script):**
   ```
   python tools/bom_export_assert.py <exported.xlsx> tools/golden/<mode>.golden.json
   ```
   It asserts headers/order, data-row count, the computed `Количество` column
   (numbers > 0 and the expected total), per-row cell values, and per-row cell
   **fill RGB** (objective replacement for the manual eyedropper used for the
   material/paint colors, COL-*).

## Capturing a real golden for 0614-A00

On the SolidWorks machine, once an export is confirmed correct (ideally compared
A/B against the original build):

1. Export the mode (e.g. BOM-01 "Сводная спецификация") to `bom01.xlsx`.
2. Read back the structure to seed a golden, then trim to the stable fields:
   ```
   python - <<'PY'
   import openpyxl
   wb = openpyxl.load_workbook("bom01.xlsx", data_only=True)
   ws = wb[wb.sheetnames[0]]
   print([c.value for c in ws[1]])          # headers -> expected_headers
   print(ws.max_row - 1)                     # data rows -> expected_row_count
   PY
   ```
3. Write `tools/golden/bom01.golden.json` (see schema in the script header). Add
   a few high-value `rows` entries: at least one per material/paint color you want
   to lock down, with `fill_column` + `fill_rgb` captured from the good export.
4. Commit the golden (the `.xlsx` export itself need not be committed; the golden
   JSON is the contract). One golden per BOM mode you want gated.

Keep goldens small and intentional: lock the **structure** (headers, counts,
quantity totals) and the **color contract** (material/paint RGB), not every cell.
