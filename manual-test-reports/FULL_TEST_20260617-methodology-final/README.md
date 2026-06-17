# FULL_TEST_20260617-methodology-final

Date: 2026-06-17

## Result

- Clean release package after live test:
  `D:\Development\ztool\release-production-clean\ZTool-1.0.0-20260617-104028`
- Live write package under test:
  `D:\Development\ztool\release-production-clean\ZTool-1.0.0-20260617-101224`
- Source commit: `f35fd062efbb4f6d64167caa4f1bbf0d9ea3e04e`
- Package manifest: `dirty=true` accepted with `-AllowDirtyManifest` because the
  methodology/profile fixes are still uncommitted in this working tree.
- `verify_release_package.ps1 -RequireSolidWorksTools -AllowDirtyManifest`: PASS
- `check_bom_template.py runtime\ZTool.settings`: PASS
- `RegAsm /codebase`: PASS during live write run, `CodeBase` pointed to
  `101224\runtime\ZTool.DLL`. After the run, package `101224` is intentionally
  treated as a live-mutated artifact because ZTool saved UI settings into
  `runtime\ZTool.settings`; clean release candidate is `104028`.
- `AddInsStartup` parent values and subkeys: `0`
- Final `CommandManager` suspicious tabs: `0`
- `PROP-WRITE-ZTOOL`: PASS on live package `101224`; COM read-back from
  SolidWorks document confirmed `Default/Наименование =
  PROP_WRITE_ZTOOL_101224_1537`.

## Blank Tab Root Cause

The repeated blank tab was not a .NET Framework failure and not only a stale
`AddInsStartup` value. SolidWorks also persisted anonymous CommandManager tabs:

- `AssyContext\Tab12`
- `DrwContext\Tab10`
- `PartContext\Tab21`

They had no `ModuleName` and no `RefName`, but had:

- `Tab Props = 0,1,1,-1`
- ZTool button set including `2,59425` and `41658..41675`

The old cleanup searched for `ZTool` / `59959DFA` and therefore missed them.
The methodology now treats this anonymous signature as a blocker.

## Live Evidence

- Before cleanup: `anonymous-ztool-tabs-before-clean.txt`
- Delete log: `blank-tab-cleanup-delete.txt`
- User confirmation screenshot: `screenshots\24-user-confirmed-single-ztool-tab.png`
- Earlier package live-load screenshot: `screenshots\25-after-080859-live-load-single-tab.png`
- Earlier package load result: `load-addin-080859.txt`
- Package `101224` property-column evidence:
  `prop-runbook-live\new-package-101224-visible-props-after-scroll.json`
- Package `101224` write/save evidence:
  `prop-runbook-live\new-package-101224-propswitch-raw-open-fill.json`,
  `prop-runbook-live\new-package-101224-fill-name-save-ui.json`,
  `prop-runbook-live\new-package-101224-save-changed-after-fill.json`,
  `prop-runbook-live\new-package-101224-fill-name-com-readback.txt`
- Clean package `104028` verifier/template evidence: command output recorded
  in this run; `verify_release_package.ps1 -RequireSolidWorksTools
  -AllowDirtyManifest` PASS and `check_bom_template.py runtime\ZTool.settings`
  PASS.

Expected visual result: exactly one `ZTool` tab, no blank adjacent tab.

## Computer Use

The user explicitly requested `@Компьютер`. The bundled Computer Use plugin was
attempted and failed in this session:

- official bootstrap failed on `@oai/sky` package exports mismatch;
- direct base-client bootstrap then failed because the current node_repl session
  had no privileged native pipe;
- diagnostic: `hasConfig=false`, `hasNativePipe=false`,
  `SKY_CUA_NATIVE_PIPE_DIRECTORY=null`.

Artifact: `computer-use-unavailable.txt`.

No Computer Use click/input actions were performed after the connector failure.

## Methodology Correction / PROP

The old live methodology depended on hardcoded UI coordinates and mixed two
different checks: reading/exporting properties and writing properties through
ZTool. This report corrects that:

- `PROP-READ-EXPORT`: PASS via strict fixture/BOM evidence. ZTool exported
  non-empty `Тип` values and `BOM-07/08` passed strict Excel read-back.
- `PROP-WRITE-ZTOOL`: PASS on package `101224`. The failed attempts were
  caused by testing the read-only `PropResolvedVal_*` view. The decisive guard is
  `StatusStrip1 = Выражение свойства`; only then `FrmFilling.ComboBox1` contains
  editable property columns (`Наименование`, `Обозначение`, `Материал`, ...).
  With `ComboBox1 = Наименование`, `TextBox1 =
  PROP_WRITE_ZTOOL_101224_1537`, `Save_Changed`, SolidWorks COM read-back
  returned the same marker from `PArt-021.SLDPRT` scope `Default`.

Artifacts:

- `prop-runbook-live\uia-visible-dataitems-dump.json`
- `prop-runbook-live\ui-setvalue-part017-number-cell.json`
- `prop-runbook-live\ui-keyboard-edit-part017-number-cell.json`
- `prop-runbook-live\ui-object-click-edit-part017-number-cell.json`
- `prop-runbook-live\fill-column-dialog-controls.json`
- `prop-runbook-live\fill-column-constant-attempt.json`
- `prop-runbook-live\prepare-russian-props-pywin32.csv`
- `prop-runbook-live\ztool-after-reread-prepped-props.json`
- `prop-runbook-live\new-package-101224-propswitch-raw-open-fill.json`
- `prop-runbook-live\new-package-101224-fill-name-save-ui.json`
- `prop-runbook-live\new-package-101224-save-changed-after-fill.json`
- `prop-runbook-live\new-package-101224-fill-name-com-readback.txt`

## Package Hashes

- `runtime\ZTool.exe`: `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD`
- `runtime\ZTool.dll`: `D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9`
- `runtime\SolidWorksTools.dll`: `3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3`
- `runtime\ZTool.settings`: `DD648DDA36296D7ED9DAA56CE72B28E94B8206093BF05DA404E81B6315F171B3`
- `manifest.json`: `0E799EFF99957D7E519826D7D83C4DD60327D53D21D601D676E73F9B66D27ED3`
- `SHA256SUMS.txt`: `1B33A3A65732A83004C9282CB801B81ABFA477D6FE4A165E15968ABAA44FBBD3`

## Related Gates Already Recorded In This Report

- `BOM-07/08` strict `Тип` gate: PASS, non-empty values.
- `client-core/build.ps1`: PASS.
- `Reinjector --verify`: PASS.
- `BinderInject --verify`: PASS.
- `localization_scan`: PASS.
- `pytest` license server: `112 passed, 2 skipped`.
- `ruff`: PASS.
- `bandit`: PASS with configured project settings.
