# PR #104 aggregate evidence report

Дата: 2026-06-26  
PR: `#104`  
Branch: `codex/p4-next-production-gates`  
Implementation head: `85bc25c99a8004c8322be428923bae046646dc1c`  
Base: `main`

## Статус

Implementation direction: **acceptable for audit re-check**.  
Production GO: **NO-GO**.  
Visual FULL PASS: **NO-GO**.

Этот отчёт заменяет разрозненные executor-комментарии по PR #104 и фиксирует полный 11-коммитный scope как единый пакет. Ранее PR body описывал только первый S7/license слой и ошибочно утверждал `Product/runtime source unchanged`. Это больше не соответствует фактическому diff: PR #104 содержит runtime/source fixes, UI layout fixes, E2E/script changes, CI gates и documentation evidence.

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

## Runtime/source surfaces

### Behavior fixes

- `scripts/swtools_s7_live_smoke.py`
  - Fast process-scoped Win32 handling for trial/license dialog.
  - Keeps S7 connect object-driven; `Подключить SW` stays UIA/invoke path.
  - Adds faster license dialog close evidence without screen-coordinate dependency.

- `client-src/ZTool/Frmmain.cs`
  - Localizes visible document-kind filter values for the grid filter surface.
  - Maps legacy/internal Han token `零件` to visible Russian `Деталь` and back when applying the filter.

- `client-src/ZTool/code.cs`
  - Fixes clipboard paste path for grid edits:
    - single-cell clipboard text is no longer rejected;
    - trailing row separator is trimmed by assignment;
    - pasted text is normalized before assignment;
    - changed pasted rows are marked with `Rows[row].Tag = "true"` so `SaveToSW` can persist them.

- `client-src/ZTool/FrmOutputlist.cs`
- `client-src/ZTool/FrmPrintlist.cs`
  - Preserves and merges `Конфигурация детали` values when batch conversion/printing lists receive duplicate file rows.
  - Configured duplicates no longer collapse to blank configuration.
  - Plain duplicates no longer clear a known configuration.

### UI layout fixes

- `client-src/ZTool/FrmRename.cs`
  - Makes the file-name rule dialog sizable/DPI-aware and prevents Russian labels/fields from clipping.

- `client-src/ZTool/FrmSetNewFolder.cs`
  - Fixes `Сохранить в новую папку` layout: source/new path fields, browse button and action buttons remain readable with a minimum window size.

- `client-src/ZTool/FrmReplacePartslist.cs`
  - Fixes `Заменить ссылочные файлы` layout: minimum width, split panels, bottom groups and path fields remain visible/readable.

- `client-src/ZTool/frm_copyswfile.cs`
  - Fixes `Копировать резервную копию` layout: `Добавить префикс`, `Добавить суффикс`, path field, extra-extension field and OK/Cancel controls no longer overlap.
  - Replaces legacy CJK UI font with `Segoe UI`.

- `client-src-addin/ZTool/ReName.cs`
  - Fixes add-in save/rename dialog layout.
  - Replaces visible legacy Han field names in saved-rule UI via compatibility mapping to Russian names.
  - Replaces Chinese tooltips with Russian guidance.

### Test/gate-only changes

- `.github/workflows/release-acceptance.yml`
  - Adds regression gates for:
    - document-kind filter mapping;
    - file-name rule dialog layout;
    - grid paste dirty-state;
    - batch conversion configuration mapping;
    - new-folder dialog layout;
    - replace-links dialog layout;
    - add-in rename dialog layout;
    - backup-copy dialog layout.

- `tools/e2e/check_document_kind_filter_mapping.py`
- `tools/e2e/check_frmrename_layout.py`
- `tools/e2e/check_grid_paste_dirty_state.py`
- `tools/e2e/check_batch_convert_configuration_mapping.py`
- `tools/e2e/check_frmsetnewfolder_layout.py`
- `tools/e2e/check_frmreplacepartslist_layout.py`
- `tools/e2e/check_addin_rename_layout.py`
- `tools/e2e/check_frmcopyswfile_layout.py`
  - New static/self-test gates for the fixes above.

- `docs/audit/CLIENT_SRC_WARNING_BASELINE_RU.md`
  - Only expected line-number drift was updated where layout helper methods shifted warning coordinates.
  - Warning budget/counts are unchanged.

- `manual-test-reports/release-e2e-solidworks-20260626-fast-license/REPORT_RU.md`
  - Live S7/S8/branding evidence report for the fast-license layer.

## Local checks for implementation head `85bc25c`

The following checks were run locally during the PR #104 stack:

```powershell
dotnet build client-src\ZTool.csproj -c Release -warnaserror:false --no-incremental -v:minimal
dotnet build client-src-addin\ZTool.SwAddin.csproj -c Release -warnaserror:false --no-incremental
pwsh -NoProfile -File scripts\check_client_src_warnings.ps1
python tools\check_source_string_invariants.py --root client-src --root client-src-addin
python tools\check_visible_brand_boundary.py
python tools\secret_scan.py
git diff --check
```

New gate scripts were also run with both `--self-test` and repository checks where applicable:

```powershell
python tools\e2e\check_document_kind_filter_mapping.py --self-test
python tools\e2e\check_document_kind_filter_mapping.py
python tools\e2e\check_frmrename_layout.py --self-test
python tools\e2e\check_frmrename_layout.py
python tools\e2e\check_grid_paste_dirty_state.py --self-test
python tools\e2e\check_grid_paste_dirty_state.py
python tools\e2e\check_batch_convert_configuration_mapping.py --self-test
python tools\e2e\check_batch_convert_configuration_mapping.py
python tools\e2e\check_frmsetnewfolder_layout.py --self-test
python tools\e2e\check_frmsetnewfolder_layout.py
python tools\e2e\check_frmreplacepartslist_layout.py --self-test
python tools\e2e\check_frmreplacepartslist_layout.py
python tools\e2e\check_addin_rename_layout.py --self-test
python tools\e2e\check_addin_rename_layout.py
python tools\e2e\check_frmcopyswfile_layout.py --self-test
python tools\e2e\check_frmcopyswfile_layout.py
```

Workflow YAML parse:

```powershell
python - <<'PY'
from pathlib import Path
import yaml
for path in sorted(Path('.github/workflows').glob('*.yml')):
    with path.open('r', encoding='utf-8') as f:
        yaml.safe_load(f)
PY
```

## GitHub CI for implementation head `85bc25c`

GitHub checks passed:

- `client-src` / `build`: SUCCESS.
- `client-src-addin` / `build`: SUCCESS.
- `release-acceptance` / `acceptance`: SUCCESS.
- `release-hardening` / `release-hardening`: SUCCESS.
- `secret-scan` / `secret-scan`: SUCCESS.

## Live evidence boundary

Live release E2E evidence exists for the fast-license/S7/S8/branding scope:

- report: `manual-test-reports/release-e2e-solidworks-20260626-fast-license/REPORT_RU.md`;
- authoritative clean run path: `D:\SWToolsE2E\release-e2e-20260626-fast-license-clean`;
- S7: PASS, 29 rows / 40 columns;
- S8 strict: PASS, 8/8 exports, mode 7 rows = 18, mode 8 rows = 6;
- branding/version/icon: PASS.

This does **not** claim full visual localization acceptance.

## Remaining blockers

- Full visual localization manifest L-01..L-15 strict PASS.
- Owner/auditor visual review.
- Signing/final release dossier.
- Accepted hash decision.
- Owner Production GO.

