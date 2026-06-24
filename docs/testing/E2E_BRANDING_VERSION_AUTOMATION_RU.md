# E2E branding/version live gate

Статус: active E2E layer, not Production GO.

## Цель

Закрыть повторяющуюся проблему "собрали одно, запустили другое" для бренда,
версии и иконки SWTools.

Gate доказывает одновременно:

- `SWTools.exe` и `SWTools.dll` лежат в проверяемом `runtime`;
- file/product version начинается с `VERSION`;
- `ProductName == SWTools`;
- live process `SWTools.exe` запущен именно из этого `runtime`;
- live main window title начинается с `SWTools <VERSION>+<commit>.<clean|dirty>`;
- live window title не содержит `ZTool`;
- live window icon снят из реального окна;
- embedded EXE icon извлечён из `SWTools.exe`;
- SHA256 live window icon совпадает с SHA256 embedded EXE icon;
- evidence записано в JSON и PNG.

## Запуск

Обычный полный live-прогон после S7/S8:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource -RunS7 -RunS8 -RunBrandingVersion `
  -PrepareStrictBomFixture -ForceStrictBomFixture `
  -RequireSolidWorks `
  -SolidWorksExe 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe' `
  -SolidWorksToolsDll 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll' `
  -TestAssembly 'D:\Development\ztool\TestModel\0614-A00.SLDASM' `
  -ExpectedMinRows 29 -ExpectedMinColumns 30 `
  -ExpectedBomModeCount 8 `
  -RequireStrictBomFilters `
  -OutputDir _local_artifacts\reports\e2e\branding-version-live
```

Assert:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e\branding-version-live\e2e-result.json `
  --allow-warn `
  --require-stage-pass 07-s7-connect `
  --require-stage-pass 08-s8-bom-export `
  --require-stage-pass 09-excel-validation `
  --require-stage-pass 10-branding-version `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30 `
  --require-s8-mode-count 8 `
  --require-s8-all-pass `
  --require-s8-strict-filters `
  --require-branding-version
```

## Evidence

`scripts\swtools_branding_version_live.py` пишет:

- `branding-version-result.json`;
- `live-window-icon.png`;
- `embedded-exe-icon.png`.

PNG нужны для ручной визуальной проверки, JSON является машинным gate.
`icon_hash_match` обязан быть `true`; mismatch между live icon и embedded EXE
icon является blocker.

Offline negative check:

```powershell
python tools\e2e\selftest_assert_e2e_result.py
```

## Не является Production GO

Этот слой не утверждает финальный релиз. Он только закрывает live evidence для
бренда, версии и иконки. Production GO всё ещё требует signing, localization
screenshots, final release dossier, accepted hashes and owner approval.
