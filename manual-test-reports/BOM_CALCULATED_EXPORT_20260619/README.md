# BOM calculated export live test - 2026-06-19

Scope: PR #39 calculated BOM export fields on the live SolidWorks 2025 test
machine. Test model: `TestModel/0614-A00.SLDASM`.

## Environment

- Preflight: `preflight-report.json` = PASS.
- Launch path: SolidWorks opened by `.SLDASM` association, ZTool opened through
  `SwAddin.openZtool(0)`.
- Runtime under test:
  `D:\Development\ztool\releases\1.1.0-alfa\package\ZTool-1.1.0-alfa\runtime`.
- ZTool.exe SHA256:
  `C7AB14910003D1F23E330B29D2E53F2B2BFF8ADA6BB29D27D80DC37786FCF37F`.
- Connected assembly status: `Подключение завершено, затрачено 0,2 сек, всего 29 поз.`

## Failure Reproduced

Exported mode: `Экспорт сводной спецификации`.

File: `bom-exports/01_summary_calculated_0614-A00_20260619.xlsx`.

Validator result: FAIL.

- Rows: 29.
- `№ п/п`: 29/29.
- `Кол-во`: 29/29.
- `Масса ед. кг`: 0/29.
- `Путь`: 29/29.
- `Габаритные размеры`: 29/29.

Readback evidence:

- `validator-before-fix.txt`.
- `excel-readback-before-fix.json`.
- `solidworks-mass-probe.json` confirms SolidWorks exposes mass for the active
  assembly (`0.2148001010119693` kg), so the failure was export mapping, not SW
  mass calculation.

## Root Cause

The template contains old Chinese defined name `重量` and the new Russian
calculated anchor `МассаЕдКг` on the same Excel cell `J6`.

`ZTool.settings` mapped:

- `PropVal_8` / `Масса` -> `重量`.
- `Col_Weight` / `Масса ед._кг` -> `МассаЕдКг`.

On the RU test model the custom property `Масса` is empty, so the property
column could overwrite the calculated mass column in the same Excel cell. Bounds
worked because `Col_bound` had no competing property mapping.

## Fix

- Removed the Excel anchor from `PropVal_8`; it remains a user property column
  but no longer owns the mass output cell.
- Kept `Col_Weight -> МассаЕдКг` as the only owner of the calculated mass cell.
- Added `check_bom_template.py` validation for overlapping defined-name
  destinations, so a future property/calculated-column collision fails before
  release testing.

## Retest

ZTool was restarted from the same SolidWorks add-in callback after updating the
runtime `ZTool.settings`, then the same export mode was run again by UIA/Win32
object locators.

File: `bom-exports-after-fix/01_summary_after_fix_0614-A00_20260619-090810.xlsx`.

Validator result: PASS.

- Rows: 29.
- `№ п/п`: 29/29.
- `Кол-во`: 29/29.
- `Масса ед. кг`: 29/29.
- `Путь`: 29/29.
- `Габаритные размеры`: 29/29.

Readback sample:

- Row 7 mass: `0,2148`.
- Row 7 bounds: `206,9x111,5x225,3`.
- Non-empty mass cells: 29.
- Non-empty bounds cells: 29.

Evidence:

- `validator-after-fix.txt`.
- `excel-readback-after-fix.json`.
- `export-after-fix-save-result.json`.
- `uia-evidence-summary-after-fix.json`.

Residual note: custom-property columns are empty on this Chinese demo model with
the Russian config; that is expected and not part of this calculated-column
gate.
