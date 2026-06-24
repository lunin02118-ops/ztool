# Visual localization live capture report

Дата: 2026-06-24
Ветка: `codex/e2e-visual-localization`
Commit: `8e370981441ed4916c4b5170d8ea25b31bdf6e4e`

## Verdict

`PARTIAL PASS / VISUAL FULL PASS PENDING`

Production GO: `NO-GO`.

Этот отчёт не заявляет `FULL PASS`. Он фиксирует новый machine-readable capture
слой для L-01/L-13 и отдельный live blocker S7 automation.

## Scope

Добавлено:

- `scripts/swtools_visual_localization_capture.py`
- `tools/e2e/assert_visual_localization_manifest.py`
- negative fixtures/self-test для Han/runtime/missing required surface
- `docs/localization/VISUAL_LOCALIZATION_CAPTURE_RU.md`

Product/runtime source не менялся.

## Static checks

```powershell
python -m py_compile scripts\swtools_visual_localization_capture.py `
  tools\e2e\assert_visual_localization_manifest.py `
  tools\e2e\selftest_assert_visual_localization_manifest.py

python tools\e2e\selftest_assert_visual_localization_manifest.py
python tools\secret_scan.py
git diff --check
```

Result: `PASS`.

## Runtime identity

E2E output:

```text
_local_artifacts\reports\e2e\visual-localization-20260624-06\
```

Important evidence:

```text
git.dirty=false
runtime_dir=_local_artifacts\reports\e2e\visual-localization-20260624-06\package\SWTools-1.1.6\runtime
SWTools.exe SHA256=0FE068924D8BE1F137F7BB109E5224B59022D110F2BEA977DEC0A797FFE11E0B
SWTools.dll SHA256=3CA9BCC8043B287D9595C80EFBDE1E35954F1C9A6F829B1762DAEBBB959866E7
```

Package/build/preflight reached live stage, but S7 did not pass.

## S7 live blocker

Command:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource -RunS7 -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly "D:\Development\ztool\_local_artifacts\worktrees\pr87-visual-localization\TestModel\0614-A00.SLDASM" `
  -ExpectedMinRows 29 -ExpectedMinColumns 30 `
  -OutputDir _local_artifacts\reports\e2e\visual-localization-20260624-06
```

Result: `FAIL`.

Blocking dialog captured by `scripts/swtools_s7_live_smoke.py`:

```text
owner=SolidWorks
class=#32770
text contains:
Открытие компонентов
Обновление сборки
Загружается файл: ...\TestModel\PArt-017.SLDASM
```

This is an automation/live-environment blocker before S7 row evidence. It is not
counted as S7 PASS.

## Visual capture evidence

Capture output:

```text
_local_artifacts\reports\localization-visual-20260624-05\
```

Commands:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-20260624-05 `
  --expected-runtime-dir _local_artifacts\reports\e2e\visual-localization-20260624-06\package\SWTools-1.1.6\runtime

python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-20260624-05\visual-localization-manifest.json `
  --allow-warn `
  --require-surface L-01 `
  --require-surface L-13 `
  --require-runtime-match
```

Result: `PASS_WITH_WARN`.

Captured surfaces:

| ID | Status | Runtime match | Han policy | Han result | Screenshot SHA256 |
|---|---|---:|---|---|---|
| L-01 Main window | CAPTURED | true | fail | none | `BE3B2AE815B599E9498F33F6251326AFE7B0A8C67C2CBF02C6669170009CF817` |
| L-13 SolidWorks add-in host | CAPTURED | n/a | record_only | `历史记录` recorded from host FeatureManager tree | `F0B003EED989149CA635EB5BB79F526DEE15EC15924643148D1AFEA73D9D0DA0` |

Machine assertion passed because L-01 has no blocking Han and matches the exact
runtime dir. L-13 host Han is preserved as warning evidence for manual review,
not hidden as a pass.

## Remaining visual work

Pending owner/auditor review for full L-01..L-15 checklist:

```text
L-02 License dialogs
L-03 BOM menu all 8 modes
L-04 Frmexportbom
L-05 Frmmapping
L-06 FrmFilterrules / user rule editor
L-07 FrmOptions all tabs
L-08 FrmSaveOption
L-09 FrmFilling
L-10 FrmSWUnit
L-11 Context menus
L-12 help_ru.chm
L-14 Installer UI
L-15 Material/color mixed-key flows
```

## Conclusion

#87 adds the missing visual capture/manifest gate and proves it on the SW
machine for current commit `8e37098`. It does not close production visual
acceptance. Current blockers remain:

- S7 live automation is blocked before row evidence by SolidWorks modal state.
- L-13 host SolidWorks Han `历史记录` requires owner review / host-scope decision.
- Full localization screenshots L-01..L-15 are not complete.
