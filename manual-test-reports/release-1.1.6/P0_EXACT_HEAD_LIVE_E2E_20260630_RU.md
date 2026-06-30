# P0 exact-head live SolidWorks E2E — 2026-06-30

Статус: **PASS для S7/S8/branding exact-head rehearsal**.

Production GO: **NO-GO**.

## Scope

Проверен узкий P0-слой: сборка source package из текущего commit, регистрация add-in, live SolidWorks S7, BOM S8 8/8 со strict filters, branding/version/icon gate.

Не входило в scope: licensing lifecycle, full visual L-01..L-15, Authenticode signing, accepted hash promotion, final release dossier, owner GO.

## Exact Head

- Branch: `codex/p0-exact-head-live-e2e-20260629`
- Commit: `c0fb388a6fbe6226f9403e427bdc160dcc43fbad`
- Product version in live window: `SWTools 1.1.6+c0fb388.clean(x64)`
- Git dirty in evidence: `false`

## Evidence

Report directory:

`_local_artifacts/reports/p0-exact-head-live-e2e-20260630-c0fb388`

Main result:

`_local_artifacts/reports/p0-exact-head-live-e2e-20260630-c0fb388/release-e2e-solidworks-result.json`

Preserved failed evidence:

`_local_artifacts/reports/p0-exact-head-live-e2e-20260630-d5b05f9/e2e-result.json`

`_local_artifacts/reports/p0-exact-head-live-e2e-20260630-d5b05f9/logs/07-s7-live-smoke.log`

Initial failure classification: **B INVOKE_HANG**. The failed run reached a ready SolidWorks model and had a receiver window, but the object-driven Ribbon UIA traversal/invoke path did not complete before the 180-second S7 timeout.

## Automated Result

- `release-e2e-orchestrator`: PASS
- `release-e2e-assert`: PASS
- `production_go_allowed`: `false`
- Visual full profile: SKIP (`RequireVisualFullProfile` not set)

## Runtime Identity

- Runtime path: `_local_artifacts/reports/p0-exact-head-live-e2e-20260630-c0fb388/package/SWTools-1.1.6/runtime`
- `SWTools.exe` SHA256: `067F9908D41DA2D99C3B25BAF2176076B65B7DBE133B3A1E1F1802CE4312AD39`
- `SWTools.dll` SHA256: `5A36BFFD6AA08B122EF08F5C158E00284118D4223D782B3556FB77D4BA3083C1`
- Runtime package: `SWTools-1.1.6`
- `SolidWorksTools.dll`: present

## Live Gates

### S7 Connect

- Status: PASS
- Rows: 29
- Row count source: `uia_grid_pattern`
- Columns: 40
- Connect action: `shortcut_ctrl_l`
- Connect source: `Frmmain_KeyDown Ctrl+L -> _ConnectSW_ExecuteEvent(null, null)`
- Status text: not required for PASS; grid evidence reported 29 rows / 40 columns.
- Model-ready gate: PASS
- Receiver window after launch: present.
- License dialog: absent.
- Blocking dialog: absent.
- Screen-coordinate click evidence: absent.

### S8 BOM Export

- Status: PASS
- Mode count: 8/8
- Strict filters: PASS
- Mode 7 rows: 18
- Mode 8 rows: 6
- Export modal handling: process-scoped; `modal_process_id == modal_expected_process_id`.

### Branding / Version / Icon

- Status: PASS
- Product version: `1.1.6+c0fb388.clean`
- File version: `1.1.6.449`
- Live title prefix: `SWTools 1.1.6+c0fb388.clean`
- Live window icon SHA equals embedded EXE icon SHA: PASS

## Harness Fix In This PR

The S7 live automation was failing before product code execution because UI automation could hang while traversing/invoking the large Ribbon/WinForms/SolidWorks window tree.

The harness now:

- invokes the existing product shortcut `Ctrl+L`, which is handled by `Frmmain_KeyDown` and calls `_ConnectSW_ExecuteEvent(null, null)`;
- keeps the connect action object-driven and non-coordinate;
- bounds UIA text/grid probes so evidence collection cannot hang after the product action completes;
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
