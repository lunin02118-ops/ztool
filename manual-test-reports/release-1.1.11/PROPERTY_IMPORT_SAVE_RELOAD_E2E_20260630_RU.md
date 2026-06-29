# Property Import / Save / Reload E2E — 2026-06-30

Статус: PASS как regression/evidence gate.

Production GO: NO-GO.

## Scope

Проверен узкий контракт, который ранее ломался:

- native SWDM import property names from file;
- native SWDM import property names from folder;
- import property names from currently open SolidWorks document/component;
- save custom properties through the SWTools add-in save IPC path;
- close/reopen fixture and read back saved properties through SolidWorks API.

Runtime/product code этим PR не менялся.

## Live Evidence

Evidence directory:

`D:\SWToolsE2E\p0-property-import-save-reload-20260630-012450`

Primary JSON:

`D:\SWToolsE2E\p0-property-import-save-reload-20260630-012450\property-import-save-reload-result.json`

Source CAD:

`D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`

Folder source:

`D:\1602.00.000 Шнек`

Fixture CAD:

`D:\SWToolsE2E\p0-property-import-save-reload-20260630-012450\fixture\1602.00.003 Фланец.SLDPRT`

## Results

| Stage | Result | Evidence |
| --- | --- | --- |
| SWDM file import | PASS | 46 property names, `swDmDocumentOpenErrorNone` |
| SWDM folder import | PASS | 9 files scanned, 86 unique property names |
| Open-components import | PASS | 46 property names from active SolidWorks document |
| Save/reload | PASS | `dwData=5` callback received; values match after reopen |

Saved and reloaded properties:

- `SWTOOLS_E2E_SAVE_RELOAD`
- `SWTOOLS_E2E_Кириллица`

The SWDM key was read only from local secret storage. The report stores no raw key.

## Automation

New live gate:

```powershell
python scripts\swtools_property_import_save_reload_live.py `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT" `
  --folder "D:\1602.00.000 Шнек" `
  --output-dir "D:\SWToolsE2E\p0-property-import-save-reload-20260630-012450"

python tools\e2e\assert_property_import_save_reload.py `
  "D:\SWToolsE2E\p0-property-import-save-reload-20260630-012450\property-import-save-reload-result.json"
```

The test is object/API/IPC-driven. It does not use coordinate clicks.

## Not Closed

This is not a production release proof. Still out of scope:

- full final installed-runtime release rehearsal;
- licensing lifecycle;
- full visual L-01..L-15 strict PASS;
- Authenticode signing;
- accepted hash promotion;
- final release dossier;
- explicit owner GO.
