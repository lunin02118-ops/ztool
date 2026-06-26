# PR #104 aggregate evidence report

Дата: 2026-06-26
PR: `#104`
Branch: `codex/p4-next-production-gates`
Runtime evidence commit: `c3cdf7be22661d22ecbb3475cc31c0b0154effde`
Base: `main`

## Статус

Implementation direction: **ready for audit re-check**.
Production GO: **NO-GO**.
Visual FULL PASS: **NO-GO**.

Этот отчёт заменяет разрозненные executor-комментарии по PR #104 и фиксирует полный scope как единый пакет. Ранее PR body описывал только первый S7/license слой и ошибочно утверждал `Product/runtime source unchanged`. Это больше не соответствует фактическому diff: PR #104 содержит runtime/source fixes, UI layout fixes, E2E/script changes, CI gates и documentation evidence.

## Commit stack

1. `85ce4d4` - `test(e2e): speed up S7 license dialog handling`
2. `857e89e` - `docs(test): add fast license E2E evidence`
3. `2412ab7` - `fix(ui): localize document kind filter values`
4. `3c521c6` - `test(ci): avoid visible legacy brand in filter gate`
5. `8d76ea3` - `fix(ui): make file-name rule dialog responsive`
6. `6469aae` - `fix(ui): mark grid paste edits for save`
7. `f327700` - `fix(ui): preserve batch conversion configurations`
8. `1f0c241` - `fix(ui): make new-folder dialog responsive`
9. `685739f` - `fix(ui): enforce replace-links dialog layout`
10. `04529fc` - `fix(ui): polish add-in rename dialog layout`
11. `85bc25c` - `fix(ui): polish backup copy dialog layout`
12. `6e1f7d9` - `docs(test): add PR104 aggregate evidence report`
13. `df8bd1f` - `docs(test): align PR104 evidence with brand boundary`
14. `c3cdf7b` - `fix(e2e): stabilize S7 receiver and S8 ribbon automation`

## Runtime/source surfaces

### Behavior fixes

- `scripts/swtools_s7_live_smoke.py`
  - Handles the embedded `Лицензия не обнаружена` panel in the main SWTools WinForms window with process-scoped UIA.
  - Keeps the legacy Win32 modal handler as fallback for real `#32770` dialogs.
  - Speeds up blocking-dialog detection by prefiltering real modal windows before reading text.
  - Adds heartbeat checkpoint fields while waiting for `openZtool`, so hangs are diagnosable.
  - Keeps `Подключить SW` object-driven; no hard-coded screen coordinates are accepted as release evidence.

- `client-src/ZTool/M_FindWindow.cs`
  - Searches top-level windows in the SolidWorks process before the old desktop child-window traversal.
  - Uses a 260-character title buffer instead of 50.
  - Root cause: live evidence showed `Ztool_Receiver` is a top-level hidden window in `SLDWORKS.exe`, so the old child-only search could miss it.

- `client-src/ZTool/code.cs`
  - Preserves a valid command-line `Receiver_hWnd` if the fallback window lookup returns zero.
  - Root cause: a valid receiver handle could be overwritten by zero, producing false `Надстройка не запущена!` / S7 empty-grid failures.
  - Also contains the earlier grid paste dirty-state fix:
    - single-cell clipboard text is no longer rejected;
    - trailing row separator is trimmed by assignment;
    - pasted text is normalized before assignment;
    - changed pasted rows are marked with `Rows[row].Tag = "true"` so `SaveToSW` can persist them.

- `scripts/swtools_s8_bom_live.py`
  - Activates the `Спецификация` ribbon tab only through discovered UIA objects.
  - Uses `invoke`, `select`, keyboard activation, then object-level `click_input()` on the discovered `TabItem` as last resort.
  - Does not use fixed screen coordinates.
  - Root cause: this Windows Ribbon build rejected UIA `SelectionItem.Select()` for the tab; object-level activation was needed before `Экспорт спецификации` became visible.

- `client-src/<client>/Frmmain.cs`
  - Localizes visible document-kind filter values for the grid filter surface.
  - Maps legacy/internal Han token `零件` to visible Russian `Деталь` and back when applying the filter.

- `client-src/<client>/FrmOutputlist.cs`
- `client-src/<client>/FrmPrintlist.cs`
  - Preserves and merges `Конфигурация детали` values when batch conversion/printing lists receive duplicate file rows.
  - Configured duplicates no longer collapse to blank configuration.
  - Plain duplicates no longer clear a known configuration.

### UI layout fixes

- `client-src/<client>/FrmRename.cs`
  - Makes the file-name rule dialog sizable/DPI-aware and prevents Russian labels/fields from clipping.

- `client-src/<client>/FrmSetNewFolder.cs`
  - Fixes `Сохранить в новую папку` layout: source/new path fields, browse button and action buttons remain readable with a minimum window size.

- `client-src/<client>/FrmReplacePartslist.cs`
  - Fixes `Заменить ссылочные файлы` layout: minimum width, split panels, bottom groups and path fields remain visible/readable.

- `client-src/<client>/frm_copyswfile.cs`
  - Fixes `Копировать резервную копию` layout: `Добавить префикс`, `Добавить суффикс`, path field, extra-extension field and OK/Cancel controls no longer overlap.
  - Replaces legacy CJK UI font with `Segoe UI`.

- `client-src-addin/<addin>/ReName.cs`
  - Fixes add-in save/rename dialog layout.
  - Replaces visible legacy Han field names in saved-rule UI via compatibility mapping to Russian names.
  - Replaces Chinese tooltips with Russian guidance.

### Test/gate-only changes

- `.github/workflows/release-acceptance.yml`
  - Adds regression gates for document-kind filter mapping, file-name rule dialog layout, grid paste dirty-state, batch conversion configuration mapping, new-folder dialog layout, replace-links dialog layout, add-in rename dialog layout and backup-copy dialog layout.

- `tools/e2e/check_document_kind_filter_mapping.py`
- `tools/e2e/check_frmrename_layout.py`
- `tools/e2e/check_grid_paste_dirty_state.py`
- `tools/e2e/check_batch_convert_configuration_mapping.py`
- `tools/e2e/check_frmsetnewfolder_layout.py`
- `tools/e2e/check_frmreplacepartslist_layout.py`
- `tools/e2e/check_addin_rename_layout.py`
- `tools/e2e/check_frmcopyswfile_layout.py`
  - Static/self-test gates for the fixes above.

- `docs/audit/CLIENT_SRC_WARNING_BASELINE_RU.md`
  - Warning identity lines were updated after `code.cs` shifted existing decompiler warnings.
  - Warning budget/counts are unchanged: `client-src=123`, `client-src-addin=6`.

## Local checks

The following checks passed after the final `c3cdf7b` fix:

```powershell
python -m py_compile scripts\swtools_s7_live_smoke.py scripts\swtools_s8_bom_live.py
python tools\secret_scan.py
git diff --check
pwsh -NoProfile -File scripts\check_client_src_warnings.ps1
python tools\check_source_string_invariants.py --root client-src --root client-src-addin
python tools\check_visible_brand_boundary.py
dotnet build client-src-addin\ZTool.SwAddin.csproj -c Release -p:SolidWorksDir="C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS"
```

Result:

- `secret_scan`: PASS.
- `git diff --check`: PASS.
- warning baseline: PASS, `client-src=123`, `client-src-addin=6`.
- source string invariants: PASS.
- visible brand boundary: PASS.
- add-in build against real SolidWorks SDK path: PASS, only the 6 known `CS0414` warnings.

## Clean live release E2E evidence

Authoritative clean run:

- result dir: `D:\Development\ztool\_local_artifacts\worktrees\p4-next-20260626\_local_artifacts\reports\final-release-e2e-20260626-153805`
- wrapper result: `release-e2e-solidworks-result.json`
- foundation result: `e2e-result.json`
- commit: `c3cdf7be22661d22ecbb3475cc31c0b0154effde`
- dirty: `false`
- status: `PASS`
- `production_go_allowed`: `false`

Stages:

- `00-doctor`: PASS.
- `01-resolve-build-source-inputs`: PASS.
- `02-build-package`: PASS.
- `03-verify-package`: PASS.
- `04-runtime-identity`: PASS.
- `05-preflight-register`: PASS.
- `06-prepare-strict-bom-fixture`: PASS.
- `07-s7-connect`: PASS, `29` rows / `40` columns.
- `08-s8-bom-export`: PASS, `8/8` workbooks.
- `09-excel-validation`: PASS.
- `10-branding-version`: PASS.
- `12-finalize`: PASS.

S7 evidence:

- status text: `Подключение завершено, затрачено 0,3 сек, всего 29 поз.`
- SWTools SHA256: `5B1AEB4193DD0D68E1E88F8360489B2A4980E33DDD64000C850597ECD0290847`
- add-in SHA256: `B209339ACD2834B7E002DE8AEFDC74002DC7CA4068CE7E945FC5376B6DA63CCD`

S8 evidence:

| Mode | Rows | Images | Filter empty | Modal |
|---:|---:|---|---|---|
| 1 | 29 | no | no | `Нет`, PID scoped |
| 2 | 32 | no | no | `Нет`, PID scoped |
| 3 | 6 | no | no | `Нет`, PID scoped |
| 4 | 25 | no | no | `Нет`, PID scoped |
| 5 | 29 | yes | no | `Нет`, PID scoped |
| 6 | 32 | yes | no | `Нет`, PID scoped |
| 7 | 18 | no | no | `Нет`, PID scoped |
| 8 | 6 | no | no | `Нет`, PID scoped |

Branding/version evidence:

- title: `SWTools 1.1.6+c3cdf7b.clean(x64)`.
- product version: `1.1.6+c3cdf7b.clean`.
- file version: `1.1.6.438`.
- live icon hash equals embedded EXE icon hash: `true`.

Release wrapper boundary:

- `visual-localization-full-profile`: `SKIP`, because `-RequireVisualFullProfile` was not set.
- This clean E2E run proves S7/S8/strict BOM/branding only; it does not claim visual FULL PASS or production approval.

## GitHub CI

GitHub checks were green for the previous #104 head before the final receiver/S8 fix:

- `client-src` / `build`: SUCCESS.
- `client-src-addin` / `build`: SUCCESS.
- `release-acceptance` / `acceptance`: SUCCESS.
- `release-hardening` / `release-hardening`: SUCCESS.
- `secret-scan` / `secret-scan`: SUCCESS.

After pushing this report, GitHub CI must re-run on the final branch head and remain green before merge.

## Remaining blockers

- Full visual localization manifest `L-01..L-15` strict PASS.
- Owner/auditor visual review.
- Authenticode production signing and final release dossier.
- Accepted hash promotion decision.
- Owner Production GO.
