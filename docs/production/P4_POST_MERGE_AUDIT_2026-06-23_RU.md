# P4 post-merge audit — 2026-06-23

Дата: 2026-06-23
Scope: аудит текущего `main` после merge Sprint H/L/M/N stack.
Источник проверки: GitHub connector по `lunin02118-ops/ztool`, PR metadata, workflow metadata and repository files on `main`.

## 1. Connector-confirmed state

Подтверждено через GitHub connector:

| PR | Назначение | Статус | Merge commit |
|---|---|---|---|
| #77 | Sprint H localization architecture debt | merged | `d92c78593e88c29257e62c1634f3c33cb4a59465` |
| #75 | Sprint L/M repo hygiene + BinaryFormatter containment | merged | `b0ca1a1fe4622e0ac742e8d3b6c2db3dd36fcced` |
| #76 | Sprint N signing/release dossier policy | merged | `4978defca21f9b5925c707990bd9013e7ea69795` |

По PR head SHA:

- #75 `secret-scan` PASS;
- #76 `secret-scan` PASS;
- connector did not show a separate PR-triggered workflow run for merge commit `4978defc...`, so final P4 gates must be re-run on current `main` before release evidence.

## 2. Sprint H audit result

Verdict: `ACCEPTED AS ARCHITECTURE/GATE LAYER`.

What is confirmed on `main`:

- localization architecture debt is documented;
- exact whitelist model is documented;
- automated scan status is recorded as `han_entries=78`, `unclassified_han=0`, diagnostics `0 errors / 0 warnings`;
- visual FULL PASS is not claimed;
- manual visual audit remains required before production GO / visual FULL PASS.

Remaining before P4 GO:

- screenshots for main UI/ribbon/table;
- license/register dialogs;
- BOM/export/mapping/options/filling/unit forms;
- context menus for known internal `ToolStripMenuItem` debt;
- `help_ru.chm` Russian content from help buttons;
- installer UI;
- SolidWorks add-in UI;
- material/color scenarios that depend on mixed literal `零件`.

## 3. Sprint L audit result

Verdict: `ACCEPTED AS GATE/INVENTORY LAYER`.

What is confirmed on `main`:

```text
Repo hygiene PASS
prohibited_tracked_count = 0
legacy_tracked_evidence_count = 126
large_or_binary_tracked_count = 101
runtime_binary_tracked_count = 27
help_asset_tracked_count = 10
cad_tracked_count = 64
large_file_tracked_count = 0
```

The repo hygiene gate fails on new prohibited tracked artifacts:

- `_local_artifacts/`;
- `releases/`;
- `client-rekey/*.txt`;
- private/signing/key material;
- registry exports;
- raw dumps;
- runtime DB files.

Remaining before final cleanup:

- legacy evidence remains warning-only;
- runtime binaries, third-party DLLs, CHM/BMP assets and CAD/TestModel artifacts remain tracked pending separate LFS/artifact-storage decision;
- no history rewrite has been performed and must not be performed without explicit owner approval.

## 4. Sprint M audit result

Verdict: `ACCEPTED AS CONTAINMENT LAYER`.

What is confirmed on `main`:

```text
BinaryFormatter surface PASS
files_with_binaryformatter = 11
unclassified_files = 0
missing_expected_files = 0
```

Current security boundary:

- no network-facing BinaryFormatter usage identified;
- clipboard BinaryFormatter paths must be protected by `SafeListBinder` in packaged runtime;
- config blob deserialization must use `VTBinder` or a stricter successor;
- new BinaryFormatter files fail `check_binaryformatter_surface.ps1`.

Remaining before final source acceptance:

- source-native add-in helper `Type_16` requires final binder/migration decision;
- fixture regression tests for existing settings/config blobs;
- original-vs-source parity test;
- negative tests for disallowed clipboard/config payloads where feasible.

## 5. Sprint N audit result

Verdict: `ACCEPTED AS POLICY/DOSSIER SKELETON`.

What is confirmed on `main`:

- `-AllowUnsigned` is explicitly CI evidence only;
- production Authenticode verification must run without `-AllowUnsigned` unless a formal release exception is recorded;
- release dossier is `DRAFT / NO-GO`;
- production GO remains blocked until final package, signing, SolidWorks/licensing and localization evidence exist.

Remaining before P4 GO:

- final package built from exact merged commit;
- SHA256SUMS / manifest;
- SBOM/license notices;
- binary provenance;
- Authenticode production verification without `-AllowUnsigned`, or formal release exception;
- clean install smoke;
- SolidWorks S7/S8 live acceptance;
- licensing L3-L5 live acceptance;
- localization visual audit;
- no open P0/P1 without mitigation/exception.

## 6. Current defect found by audit

The implementation stack is merged, but several status documents still contained stale pre-merge wording such as:

- `user audit required before merging #75/#76`;
- `#75 open` / `#76 this PR`;
- current stack listed as `#75 -> #76`.

This PR updates those documents so the repository state is truthful after merge:

```text
#77/#75/#76 merged;
current implementation stack = none;
current phase = final release rehearsal / production evidence;
P4 decision = NO-GO until final evidence exists.
```

## 7. Legacy PR triage

Connector-confirmed open/stale PRs:

| PR | Status | Audit decision |
|---|---|---|
| #65 | open, mergeable, diverged behind current main | Do not merge as-is. Close as superseded or extract only missing source-release logic into a fresh PR after comparison with current `main`. |
| #64 | open, not mergeable, additive salvage artifacts | Close as stale or recreate a fresh minimal PR for `solidworks-registry-preflight.ps1` only if needed for live SolidWorks acceptance. |
| #61 | open, not mergeable, docs-only audit @1.1.5 | Close as superseded by Deep Audit delta and current P4 docs. |

## 8. Overall conclusion

```text
P4 hardening stack: merged and structurally good.
Production status: still NO-GO.
Immediate next step: final release rehearsal evidence on current main.
Do not merge stale PR #61/#64/#65 as-is.
```
