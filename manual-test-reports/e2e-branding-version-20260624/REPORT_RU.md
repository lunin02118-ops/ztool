# E2E branding/version live evidence - 2026-06-24

Статус: PASS для слоя #86, не Production GO.

## Контекст

- Branch: `codex/e2e-branding-version-live`
- Runtime-affecting commit tested: `464985c2110aff54b1a6ebac87f89cf2c864792c`
- Commits after `464985c` in this PR are report/documentation-only; no runtime,
  E2E script, package or installer logic changed after the accepted live run.
- Git state during accepted run: `clean`
- SolidWorks: `C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe`
- Test assembly: `TestModel\0614-A00.SLDASM`
- Evidence root: `_local_artifacts\reports\e2e\branding-version-live-20260624-09-clean`

## Команда

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource -RunS7 -RunS8 -RunBrandingVersion `
  -PrepareStrictBomFixture -ForceStrictBomFixture `
  -RequireSolidWorks `
  -SolidWorksExe 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe' `
  -SolidWorksToolsDll 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll' `
  -TestAssembly 'D:\Development\ztool\_local_artifacts\worktrees\pr86-branding-version-live\TestModel\0614-A00.SLDASM' `
  -ExpectedMinRows 29 -ExpectedMinColumns 30 `
  -ExpectedBomModeCount 8 `
  -RequireStrictBomFilters `
  -OutputDir _local_artifacts\reports\e2e\branding-version-live-20260624-09-clean
```

Assert:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e\branding-version-live-20260624-09-clean\e2e-result.json `
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

## Результат

- E2E status: `PASS`
- `production_go_allowed`: `false`
- S7: `PASS`, rows `29`, columns `40`
- S8: `PASS`, exported modes `8/8`
- Excel semantic validation: `PASS`
- Strict filter modes: `PASS`
- Branding/version: `PASS`

## Branding/version evidence

- Live title: `SWTools 1.1.6+464985c.clean(x64)     Пробный период... осталось127секунда`
- Expected title prefix: `SWTools 1.1.6+464985c.clean`
- Runtime process path:
  `_local_artifacts\reports\e2e\branding-version-live-20260624-09-clean\package\SWTools-1.1.6\runtime\SWTools.exe`
- ProductVersion: `1.1.6+464985c.clean`
- FileVersion: `1.1.6.374`
- `SWTools.exe` SHA256: recorded in `10-branding-version\branding-version-result.json`
- `SWTools.dll` SHA256: recorded in `10-branding-version\branding-version-result.json`
- Live window icon: `32x32`, SHA256 `FBCBEA469574936EB8B104AAC5521218DF0B49D9891A6F0BA3D0D8DD40DADF05`
- Embedded EXE icon: `32x32`, SHA256 `FBCBEA469574936EB8B104AAC5521218DF0B49D9891A6F0BA3D0D8DD40DADF05`
- `icon_hash_match`: `true`

## Negative validator check

Добавлен offline negative fixture:

- `tools\e2e\fixtures\branding-icon-mismatch-e2e-result.json`
- `tools\e2e\selftest_assert_e2e_result.py`

Проверка:

```powershell
python tools\e2e\selftest_assert_e2e_result.py
```

Результат: `E2E assertion self-test PASS: branding icon mismatch is rejected`.

## Дополнительно исправлено в E2E

Во время dirty-прогона S7 выявил старое зависание: SolidWorks показывал модальное окно
`Информация / Тайм-аут соединения`, а внешний E2E timeout убивал Python без JSON.

Теперь `scripts\swtools_s7_live_smoke.py` вызывает `openZtool(0)` в worker thread и
параллельно мониторит blocking dialogs по SolidWorks PID. При такой ошибке S7 быстро
пишет `s7-live-smoke-result.json` с `blocking_dialog`, вместо 180 секунд молчаливого
зависания.

Проверка fast-fail была выполнена на реальном зависшем состоянии:

- detected owner: `SolidWorks`
- title: `Информация`
- text: `Тайм-аут соединения`
- result: controlled `FAIL` with JSON evidence

## Ограничения

Этот отчет закрывает слой #86: live branding/version/icon evidence и защиту от
запуска не того runtime. Это не финальный релизный GO.

Production GO всё еще требует signing, visual localization acceptance, final release
dossier, accepted hash promotion and owner approval.
