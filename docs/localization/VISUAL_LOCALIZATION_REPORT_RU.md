# Visual localization report

Дата: 2026-06-23
Scope: Sprint H / localization architecture debt.

## Verdict

`AUTOMATED LOCALIZATION SCAN PASS / VISUAL USER AUDIT PENDING`

Этот документ не заявляет `FULL PASS`. Перед merge/release нужен ручной аудит
пользователя по кадрам ниже.

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

## Manual PASS criteria

```text
[ ] Visible Han strings: none.
[ ] Critical clipping/overlap: none.
[ ] Dialog resize behavior: usable where content is long.
[ ] Context menus show Russian captions, not internal component names.
[ ] Help opens Russian pages.
[ ] Screenshots correspond to exact tested build/hash.
```

## Current risk

Automated scan is clean, but visual pass is not complete until screenshots are
reviewed. This keeps localization as P1 partial, not P4 closed.
