# Property Import / Save / Reload E2E — 2026-06-30

Статус: PASS для слоя #110.

Production GO: NO-GO.

## Scope

Проверялся только #110 слой:

- native SWDM import property names from file;
- native SWDM import property names from folder;
- import property names from currently open SolidWorks document/component;
- document-level property evidence;
- configuration-level property evidence;
- exact installed runtime launch;
- demo/license modal handling by object-driven UI action;
- no visible Han in SWTools-owned UI;
- no compatibility key leakage in machine-readable evidence;
- user-facing SWTools connect / SaveToSW / reload read-back.

Не проверялись и не менялись: licensing lifecycle, visual L-01..L-15, signing,
accepted hashes, final release dossier.

## Authoritative Evidence

Primary JSON:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun29-fresh-sw\property-import-save-reload-result.json`

Runtime:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-package-full\SWTools-1.1.6\runtime`

Source CAD:

`D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`

Folder source:

`D:\1602.00.000 Шнек`

Fixture CAD:

`D:\Development\ztool\_local_artifacts\worktrees\p0-property-import-save-reload-20260630\_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun29-fresh-sw\fixture\1602.00.003 Фланец.SLDPRT`

## Results

| Stage | Result | Evidence |
| --- | --- | --- |
| SWDM file import | PASS | 46 property names, 1 file, native SWDM key metadata only |
| SWDM folder import | PASS | 9 files scanned, 86 unique property names |
| Open-components import | PASS | 46 property names from active SolidWorks document/component |
| Document-level property evidence | PASS | 21 document properties from active model |
| Configuration-level property evidence | PASS | 29 configuration properties, active configuration `00` |
| Runtime pre-clean | PASS | stale exact-runtime SWTools processes closed before launch |
| Exact runtime launch | PASS | SWTools runtime launched from the selected package |
| Demo/license modal | PASS | object-driven `Демо` invoke; no screen coordinates |
| Visible Han check | PASS | `han_texts=[]` |
| Compatibility key leakage check | PASS | Evidence stores key SHA12/length/path metadata only; no raw key |
| SWTools connect | PASS | object-driven connect, grid evidence 1 row / 40 columns |
| Internal receiver before save | PASS | live receiver found before SaveToSW IPC |
| SaveToSW | PASS | dwData 31/33/34 sent with callback HWND; callbacks received |
| Reload read-back | PASS | saved values persisted after close/reopen |

## Saved Values

The test wrote two document-level properties through the SWTools SaveToSW path:

- `SWTOOLS_E2E_SAVE_RELOAD = PASS-20260701-150346`
- `SWTOOLS_E2E_Кириллица = Проверка сохранения 20260701-150346`

Read-back result:

- live document read-back: PASS;
- reloaded document read-back: PASS;
- active configuration before save: `00`;
- active configuration after reload: `00`;
- configuration-level evidence collected and present; these two E2E marker
  properties were intentionally written at document level for stable reload
  verification.

## Failure Regression Closed

Earlier #110 attempts were blocked by a license/demo modal and stale runtime
state. The current automation now:

- closes only exact-runtime stale `SWTools.exe` processes before launch;
- accepts the demo/license dialog using object-driven UI invoke on `Демо`;
- verifies the live internal receiver before save;
- sends SaveToSW IPC with a stable Unicode buffer and `SendMessageTimeoutW`;
- records machine-readable JSON evidence for every step.

No fixed screen coordinates are used.

## Commands

```powershell
python scripts\swtools_property_import_save_reload_live.py `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT" `
  --folder "D:\1602.00.000 Шнек" `
  --runtime-dir "_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-package-full\SWTools-1.1.6\runtime" `
  --output-dir "_local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun29-fresh-sw" `
  --solidworks-timeout 240 `
  --save-callback-timeout 45

python tools\e2e\assert_property_import_save_reload.py `
  _local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun29-fresh-sw\property-import-save-reload-result.json
```

## Local Gates

Passed:

- `python -m py_compile scripts\swtools_property_import_save_reload_live.py tools\e2e\assert_property_import_save_reload.py`
- `python tools\e2e\assert_property_import_save_reload.py --self-test`
- `python tools\e2e\assert_property_import_save_reload.py _local_artifacts\reports\p0-property-import-save-reload-20260630-751e4fe-rerun29-fresh-sw\property-import-save-reload-result.json`
- `python tools\e2e\check_property_import_contract.py --self-test`
- `python tools\e2e\check_property_import_contract.py`
- `dotnet build client-src\<legacy client project>.csproj -c Release --no-incremental`
- `python tools\check_source_string_invariants.py --root client-src --root client-src-addin`
- `python tools\check_visible_brand_boundary.py`
- `python tools\secret_scan.py`
- `git diff --check`

## Not Closed

Still out of #110 scope:

- licensing lifecycle;
- full visual L-01..L-15 strict PASS;
- Authenticode signing;
- accepted hash promotion;
- final release dossier;
- explicit owner GO.

Production GO remains NO-GO.
