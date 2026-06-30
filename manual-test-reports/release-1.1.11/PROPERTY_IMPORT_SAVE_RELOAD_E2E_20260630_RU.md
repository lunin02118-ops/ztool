# Property Import / Save / Reload E2E — 2026-06-30

Статус: HOLD / PARTIAL PASS.

Production GO: NO-GO.

## Scope

Проверялся только #110 слой:

- native SWDM import property names from file;
- native SWDM import property names from folder;
- import property names from currently open SolidWorks document/component;
- exact installed runtime launch;
- no visible Han in SWTools-owned UI;
- no compatibility key leakage in machine-readable evidence;
- user-facing SWTools connect / SaveToSW / reload read-back.

Не проверялись и не менялись: licensing lifecycle, visual L-01..L-15, signing,
accepted hashes, final release dossier.

## Authoritative Evidence

Primary JSON:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun16-exe-start\property-import-save-reload-result.json`

Runtime:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-package-full\SWTools-1.1.6\runtime`

Source CAD:

`D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`

Folder source:

`D:\1602.00.000 Шнек`

Fixture CAD:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun16-exe-start\fixture\1602.00.003 Фланец.SLDPRT`

## Results

| Stage | Result | Evidence |
| --- | --- | --- |
| SWDM file import | PASS | 46 property names, 1 file, `swDmDocumentOpenErrorNone` |
| SWDM folder import | PASS | 9 files scanned, 86 unique property names |
| Open-components import | PASS | 46 property names from active SolidWorks document/component |
| Document-level property evidence | PASS | 21 document properties from active model |
| Configuration-level property evidence | PASS | 29 configuration properties, active configuration `00` |
| Exact runtime launch | PASS | Fresh SWTools runtime, `preexisting_runtime_process=false` |
| Visible Han check | PASS | `han_texts=[]` |
| Compatibility key leakage check | PASS | Evidence stores key SHA12/length/path metadata only; no raw key |
| SWTools connect | FAIL | SWTools modal: `Пробный период истёк! Программа закроется через 10 секунд!` |
| SaveToSW / reload read-back | NOT RUN | Blocked by expired trial/license modal before connected-grid state |

## Failure Classification

Failure class: `D LICENSE_OR_MODAL_BLOCK`.

The product import path is not the failing point in this run. Native property
import from file/folder and open SolidWorks component succeeded. The exact
runtime then launched correctly, but the user-facing SWTools workflow was
blocked by an expired trial modal before `Подключить SW` could populate the
grid.

The test intentionally does not provision, reset, or activate licensing in this
PR, because #110 scope explicitly excludes licensing lifecycle.

## Negative Direct-Save Probe

Additional diagnostic JSON:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-direct-save-after-license-block\direct-save-result.json`

Result: FAIL, as expected.

Directly sending a SaveToSW-like payload to `Ztool_Receiver` without a valid
live SWTools sender/connected UI state produced no persisted properties:
`save_options_result=0`, `result33=0`, `result34=0`, read-back empty. This
confirms the test cannot bypass the user-facing SWTools/license state and still
claim a valid SaveToSW pass.

## Commands

```powershell
python scripts\swtools_property_import_save_reload_live.py `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT" `
  --folder "D:\1602.00.000 Шнек" `
  --runtime-dir "_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-package-full\SWTools-1.1.6\runtime" `
  --output-dir "_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun16-exe-start" `
  --solidworks-timeout 240 `
  --save-callback-timeout 45
```

The live test is object/API/IPC-driven. It does not use fixed screen
coordinates.

## Not Closed

#110 is not ready for final PASS audit until a non-expired, valid SWTools
license/trial state is available as an external precondition or a separate
licensing PR closes that prerequisite.

Still open for #110:

- user-facing `Подключить SW` after exact runtime launch;
- edit imported value in SWTools grid;
- `SaveToSW`;
- close/reopen fixture;
- SolidWorks API read-back of persisted document/configuration values.

Still out of #110 scope:

- licensing lifecycle;
- full visual L-01..L-15 strict PASS;
- Authenticode signing;
- accepted hash promotion;
- final release dossier;
- explicit owner GO.
