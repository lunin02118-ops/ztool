# Visual localization report

Дата: 2026-06-23
Scope: Sprint H / localization architecture debt.

## Verdict

`AUTOMATED LOCALIZATION SCAN PASS / VISUAL USER AUDIT PENDING`

Этот документ не заявляет `FULL PASS`. Перед production GO / утверждением
visual FULL PASS нужен ручной аудит пользователя по кадрам ниже.

## Automated evidence

Command:

```powershell
python client-core\tools\localization_scan.py `
  --exe SWTools.exe `
  --translations client-core\tools\Localizer\translations.tsv `
  --whitelist-dir localization `
  --report _local_artifacts\reports\localization-sprint-h\localization_scan_SWTools_exact_whitelist.json `
  --fail-on-unclassified
```

Result:

```text
PASS
han_entries = 78
unclassified_han = 0
errors = 0
warnings = 0
```

Whitelist model is exact: protocol keys must be present in
`localization/whitelist_protocol_keys.txt`; suffix-based classification is no
longer accepted.

## Automated screenshot evidence layer

`scripts/swtools_visual_localization_capture.py` captures selected live windows,
records screenshot SHA256, process path, runtime path match and visible UIA text.
It is a guard against two recurring release mistakes:

- screenshot was taken from the wrong `SWTools.exe` runtime;
- whitelisted/internal Han text became visible in `SWTools.exe`;
- host SolidWorks Han was recorded for manual review instead of being hidden.

Validator:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-YYYYMMDD-HHMM\visual-localization-manifest.json `
  --allow-warn `
  --require-surface L-01 `
  --require-surface L-13 `
  --require-runtime-match
```

This layer can prove `CAPTURED + no blocking Han + expected runtime` for captured
surfaces. Host SolidWorks Han in `record_only` surfaces is preserved in manifest
as warning evidence. This still does not claim pixel-level layout quality or
visual FULL PASS.

Full L-01..L-15 profile:

```text
docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json
```

Release/owner evidence must validate the whole profile:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-full-YYYYMMDD-HHMM\visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-profile-surfaces-captured `
  --require-runtime-match
```

If any L-01..L-15 frame is missing, the manifest can be useful diagnostic
evidence, but it is not visual FULL PASS.

## Required screenshots for user audit

| ID | Surface | Required frame | Status |
|---|---|---|---|
| L-01 | Main window | `SWTools.exe` main ribbon + table with model loaded | Pending user audit |
| L-02 | License | registration/activation success and failure dialogs | Pending user audit |
| L-03 | BOM | export menu with all 8 modes visible | Pending user audit |
| L-04 | BOM | `Frmexportbom` template settings | Pending user audit |
| L-05 | BOM | `Frmmapping` column mapping | Pending user audit |
| L-06 | Rules | `FrmFilterrules` / user rule editor | Pending user audit |
| L-07 | Options | `FrmOptions` all tabs | Pending user audit |
| L-08 | Save | `FrmSaveOption` with long Russian labels | Pending user audit |
| L-09 | Filling | `FrmFilling` all tabs with text readable | Pending user audit |
| L-10 | Units | `FrmSWUnit` | Pending user audit |
| L-11 | Context menus | menu items previously backed by `*ToolStripMenuItem` internal Han names | Pending user audit |
| L-12 | Help | help buttons open `help_ru.chm` Russian content | Pending user audit |
| L-13 | SolidWorks add-in | SWTools tab/buttons in SolidWorks 2025 | Pending user audit |
| L-14 | Installer | install/uninstall UI | Pending user audit |
| L-15 | Material/color | actions that depend on mixed literal `零件`, including random color/material flows | Pending user audit |

## Manual PASS criteria

```text
[ ] Visible Han strings: none.
[ ] Critical clipping/overlap: none.
[ ] Dialog resize behavior: usable where content is long.
[ ] Context menus show Russian captions, not internal component names.
[ ] Help opens Russian pages.
[ ] Material/color commands still work with localized UI strings.
[ ] Screenshots correspond to exact tested build/hash.
```

## Current risk

Automated scan is clean, but visual pass is not complete until screenshots are
reviewed. This keeps localization as P1 partial, not P4 closed.
