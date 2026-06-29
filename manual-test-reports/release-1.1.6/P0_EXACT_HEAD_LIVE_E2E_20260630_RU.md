# P0 exact-head live SolidWorks E2E — 2026-06-30

Статус: **PASS для S7/S8/branding exact-head rehearsal**.

Production GO: **NO-GO**.

## Scope

Проверен узкий P0-слой: сборка source package из текущего commit, регистрация add-in, live SolidWorks S7, BOM S8 8/8 со strict filters, branding/version/icon gate.

Не входило в scope: licensing lifecycle, full visual L-01..L-15, Authenticode signing, accepted hash promotion, final release dossier, owner GO.

## Exact Head

- Branch: `codex/p0-exact-head-live-e2e-20260629`
- Commit: `4868561010eabd602448acf6778e371f6537dc88`
- Product version in live window: `SWTools 1.1.6+4868561.clean(x64)`
- Git dirty in evidence: `false`

## Evidence

Report directory:

`_local_artifacts/reports/p0-exact-head-live-e2e-20260630-001911-win32-blocker-scan`

Main result:

`_local_artifacts/reports/p0-exact-head-live-e2e-20260630-001911-win32-blocker-scan/release-e2e-solidworks-result.json`

## Automated Result

- `release-e2e-orchestrator`: PASS
- `release-e2e-assert`: PASS
- `production_go_allowed`: `false`
- Visual full profile: SKIP (`RequireVisualFullProfile` not set)

## Runtime Identity

- `SWTools.exe` SHA256: `4E295D42B687DA52E9D1E358940A6CB7EA19BB1DC9DB2423D1EF7545A63CC068`
- `SWTools.dll` SHA256: `402E485AA1883396E6FA555223D69044520FFD13602CC7FDC0E1C20840D645DF`
- Runtime package: `SWTools-1.1.6`
- `SolidWorksTools.dll`: present

## Live Gates

### S7 Connect

- Status: PASS
- Rows: 29
- Columns: 40
- Status text: `Подключение завершено, затрачено 0,3 сек, всего 29 поз.`
- Model-ready gate: PASS

### S8 BOM Export

- Status: PASS
- Mode count: 8/8
- Strict filters: PASS
- Mode 7 rows: 18
- Mode 8 rows: 6
- Export modal handling: process-scoped; button `Нет`; `modal_process_id == modal_expected_process_id`

### Branding / Version / Icon

- Status: PASS
- Product version: `1.1.6+4868561.clean`
- File version: `1.1.6.446`
- Live title prefix: `SWTools 1.1.6+4868561.clean`
- Live window icon SHA equals embedded EXE icon SHA: PASS

## Harness Fix In This PR

The S7 live automation was failing before product code execution because UI automation could hang while probing large WinForms/SolidWorks window trees.

The harness now:

- opens SWTools using non-coordinate Win32 `BM_CLICK`/object actions where needed;
- checks blocking dialogs through PID-scoped Win32 top-level windows instead of broad UIA descendant traversal;
- keeps coordinate clicks out of production evidence.

No product runtime code was changed in this PR.

## Local Checks

- `python -m py_compile scripts\swtools_s7_live_smoke.py`: PASS
- `python tools\secret_scan.py`: PASS
- `python tools\check_visible_brand_boundary.py`: PASS
- `python tools\check_source_string_invariants.py --root client-src --root client-src-addin`: PASS
- `git diff --check`: PASS

## Remaining P0 Blockers

- Licensing lifecycle: no-license, activation, revoke/delete, repeat check.
- Full visual L-01..L-15 strict PASS.
- Authenticode signing for `SWTools.exe`, `SWTools.dll`, installer.
- Accepted hash promotion.
- Final release dossier.
- Explicit owner GO.

