# Release E2E SolidWorks 2026-06-26: fast license dialog handling

Status: PASS for S7/S8/branding regression scope.
Production GO: NO-GO.
Visual FULL PASS: NO-GO.

## Scope

Проверялся регресс после #102/#103 на clean source-built runtime:

- сборка release package из текущего commit;
- регистрация runtime для SolidWorks;
- S7 live connect через `Подключить SW`;
- S8 BOM export 8/8 со strict filters;
- branding/version/icon live gate.

Полный visual profile L-01..L-15 в этом прогоне не закрывался.

## Root Cause

Первый clean release E2E на `main` после #103 завис на S7. Диагностика показала, что SWTools был запущен из правильного runtime, но automation долго обрабатывала окно "Лицензия не обнаружена".

Старый путь `dismiss_license_dialog()` использовал тяжелый pywinauto traversal по окну WinForms. На живой машине один вызов закрытия trial/license dialog занимал около 25 секунд, а в polling loop это превращалось в S7 timeout.

## Fix

В `scripts/swtools_s7_live_smoke.py` добавлена быстрая process-scoped Win32 обработка trial/license dialog:

- перебор top-level windows только нужного `SWTools.exe` PID;
- чтение child text через Win32 API;
- выбор кнопки `Демо` / `Demo` / `OK` по тексту child controls;
- закрытие через `BM_CLICK`, без screen coordinates;
- пропуск utility/tooltip windows и слишком маленьких окон.

Product/runtime source не менялся.

## Evidence

Authoritative clean release E2E:

`D:\SWToolsE2E\release-e2e-20260626-fast-license-clean`

Commit:

`85ce4d436edae287ad4fbe5829d5cbc76a45c500`

Runtime:

`D:\SWToolsE2E\release-e2e-20260626-fast-license-clean\package\SWTools-1.1.6\runtime`

Key result files:

- `release-e2e-solidworks-result.json`
- `e2e-result.json`
- `s7-live-smoke\s7-live-smoke-result.json`
- `s8-bom-export\s8-bom-result.json`
- `10-branding-version\branding-version-result.json`

## Result

Release E2E wrapper:

- status: PASS;
- production_go_allowed: false;
- visual-localization-full-profile: SKIP, because `RequireVisualFullProfile` was not set.

S7:

- status: PASS;
- rows: 29;
- columns: 40;
- license dialog backend: `win32-fast`;
- license dialog button: `Демо`;
- connect action: UIA `invoke`;
- status text: `Подключение завершено, затрачено 0,3 сек, всего 29 поз.`

S8:

- status: PASS;
- mode count: 8;
- strict filters: true;
- mode 7 rows: 18;
- mode 8 rows: 6;
- all export completion dialogs were dismissed with `Нет`;
- modal `process_id` matched expected SWTools PID.

Branding/version/icon:

- status: PASS;
- title: `SWTools 1.1.6+85ce4d4.clean(x64)`;
- product version: `1.1.6+85ce4d4.clean`;
- file version: `1.1.6.425`;
- runtime path match: true;
- live window icon SHA equals embedded EXE icon SHA.

## Checks

Local checks before opening PR:

- `python -m py_compile scripts\swtools_s7_live_smoke.py scripts\swtools_s8_bom_live.py scripts\swtools_branding_version_live.py scripts\swtools_visual_opener_capture.py tools\e2e\assert_e2e_result.py`
- `python tools\e2e\selftest_assert_e2e_result.py`
- `python scripts\swtools_visual_opener_capture.py --self-test`
- `python tools\secret_scan.py`
- `git diff --check`

## Remaining Blockers

- full visual localization manifest L-01..L-15 strict PASS;
- owner/auditor visual review;
- signing/final release dossier;
- accepted hash decision;
- owner production GO.
