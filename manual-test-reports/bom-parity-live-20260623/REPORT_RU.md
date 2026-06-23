# SWTools 1.1.6 BOM parity live test, 2026-06-23

## Runtime

- Package used for live S7/S8:
  `D:\Development\ztool\_local_artifacts\releases\1.1.6-bom-parity-filterfix-20260623-215405\SWTools-1.1.6-bom-parity-filterfix`
- Fresh verified package after gates:
  `D:\Development\ztool\_local_artifacts\releases\1.1.6-bom-parity-validated-20260623-2248\SWTools-1.1.6-bom-parity-validated`
- RU-only dry-run package after removing legacy filter tokens:
  `D:\Development\ztool\_local_artifacts\releases\1.1.6-bom-parity-ru-only-20260623-231218\SWTools-1.1.6-bom-parity-ru-only`
- `SWTools.exe` SHA256:
  `9863DC5D58A46E1E3915DA2B7EC19E55C4B3AC9AC27D60516B32624027618071`
- Packaged `SWTools.dll` SHA256:
  `667160B0E97D4A7FB7EAEEC0517757D6317C747F3AE0A1C13E76438810F8CFB4`
- RU-only dry-run package hashes:
  - `SWTools.exe`: `9863dc5d58a46e1e3915da2b7ec19e55c4b3ac9ac27d60516b32624027618071`
  - `SWTools.dll`: `1d3403f46b264a8b38536a170ec26d22ce0958f295a0c7d68b34462841bc61a3`

## S7: Connect SolidWorks

Result: PASS.

Evidence:

- `s7-connect-readback-filterfix-final.json`
- UIA GridPattern readback: `rowCount=29`, `columnCount=40`
- Runtime path/hash matched the package above.

## S8: BOM export, current RU profile

Result: PASS/WARN.

Evidence:

- Exported files: `bom-exports-ru-filterfix\`
- Export run log: `s8-export-run-ru-filterfix.json`
- Validator report: `validator-filterfix-final.txt`

Validator result:

- Mode 1 summary: PASS, 29 rows.
- Mode 2 hierarchy: PASS, 32 rows.
- Mode 3 top-level: PASS, 6 rows.
- Mode 4 parts-only: PASS, 25 rows.
- Mode 5 summary with images: PASS, 29 rows, images present.
- Mode 6 hierarchy with images: PASS, 32 rows, images present.
- Mode 7 processed parts: WARN, 0 rows.
- Mode 8 purchased parts: WARN, 0 rows.

Reason for WARN:

- Current RU profile reads property `Тип`.
- The old Chinese/demo profile reads property `类型`.
- In this fixture run, the displayed RU column `Тип` was empty, so filter modes 7/8 correctly had no matching rows.
- This is a fixture/profile parity issue, not an export crash.

Follow-up decision, 2026-06-23:

- Production `SWTools.settings` must stay RU-only.
- No `Тип/类型` alias and no `机加`/`外购` values are allowed in the final runtime profile.
- Modes 7/8 can be marked strict PASS only on a RU fixture where `Тип` is populated with Russian values.
- `client-core\tools\russify_demo_properties.py` was updated to write Russian `Тип` values when migrating the legacy demo fixture.

## Legacy vendor behavior comparison

Compared current settings with old vendor/demo profile:

- CN profile `propname`: `类型`
- CN filter rules: `$类型$ ... 机加` and `$类型$ ... 外购`
- RU profile `propname`: `Тип`
- RU filter rules: `$Тип$ ... Мех.обработка;Листовая;Литьё;Сварка`
  and `$Тип$ ... Покупное;Стандартное`

The old full PASS depends on the fixture having populated type values under the property name that the active profile reads.

CN-baseline live rerun was not completed because SolidWorks COM automation entered a broken state:

- `GetAddInObject('ZTool.SwAddin')` returned `TYPE_E_ELEMENTNOTFOUND`.
- Fresh `New-Object -ComObject SldWorks.Application` also failed on basic `Visible` with `TYPE_E_ELEMENTNOTFOUND`.
- This was captured after a successful earlier S7 and after re-running `sw_test_preflight.ps1 -Register`.

## Runner fix

The S8 runner was adjusted only as test evidence tooling:

- Close `FrmPreview` with `Esc` before opening the Ribbon export menu.
- Fall back to clicking the `Показывать рядом` checkbox when TogglePattern is unavailable.

Product source/runtime behavior was not changed by the runner fix.

## Gates

- `python client-core\tools\check_bom_template.py SWTools.settings`: PASS.
- `python client-core\tools\check_bom_template.py client-core\dist\SWTools.settings`: PASS.
- `pwsh scripts\check_client_src_warnings.ps1 ...`: PASS, warning baseline unchanged (`client-src=123`, `client-src-addin=6`).
- `python -m pytest license-server`: PASS, `139 passed, 2 skipped`.
- `python tools\secret_scan.py`: PASS.
- `git diff --check`: PASS, only line-ending warnings.
- `scripts\verify_release_package.ps1` on fresh package: PASS.
- `scripts\verify_release_package.ps1` on RU-only dry-run package: PASS with explicit current source-build hash overrides and `-AllowDirtyManifest`.
- Strict accepted-hash verification is intentionally still blocked until a release decision updates `scripts\expected_release_hashes.json`.
- `rg --text` on RU-only package `runtime\SWTools.settings` and `runtime\SWTools.dll` for selected legacy Han tokens: PASS, no matches.

## Status

No production GO claim.

Open item before release sign-off:

- Decide the intended parity policy for demo/test fixtures:
  provide a RU fixture where `Тип` is populated with Russian values
  (`Мех.обработка`, `Листовая`, `Литьё`, `Сварка`, `Покупное`, `Стандартное`)
  and rerun S8 modes 7/8 as strict PASS.
