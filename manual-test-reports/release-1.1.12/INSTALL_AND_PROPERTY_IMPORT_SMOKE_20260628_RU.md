# SWTools 1.1.12: установка и smoke импорта свойств

Дата: 2026-06-28

Статус: MANUAL TEST BUILD READY / PRODUCTION GO: NO-GO.

## 1. Почему предыдущий ручной тест не совпадал с фиксом

На скриншоте пользователя была запущена старая установленная сборка:

- `SWTools 1.1.11+9588cd3.clean(x64)`

Исправление импорта свойств и регрессионный gate находятся в более новом коде. Чтобы исключить путаницу одинаковых версий, ручная тестовая сборка поднята до:

- `SWTools 1.1.12+8073383.clean(x64)`

## 2. Установленная сборка

Commit: `8073383`

Installer:

- `D:\Development\ztool\_local_artifacts\worktrees\p4-next-20260626\releases\1.1.12\manual-test-20260628-174733\SWTools-1.1.12-Setup.exe`
- SHA256: `d4c0fc4a766bc8e14e57534f22beb149cff2a621bd359042e2be678b7294457c`

Installed runtime:

- `C:\Program Files\SWTools`
- `SWTools.exe` ProductVersion: `1.1.12+8073383.clean`
- `SWTools.dll` ProductVersion: `1.1.12+8073383.clean`
- `SWTools.exe` SHA256: `5610d9ddf857220e9c35f7645634adb26c0e51fb603e0f97dd03a3afa762dee5`
- `SWTools.dll` SHA256: `5b7cf969e7d3588ad52415b8a1a35d1713ef5dc09a9605abdfcc53eb42cefd0a`

Runtime identity gate:

- PASS
- Evidence: `_local_artifacts\reports\installed-runtime-1.1.12-20260628-174959\identity.json`

## 3. Package checks

Source-built package:

- `releases\1.1.12\manual-test-20260628-174733\package\SWTools-1.1.12`

Verification:

- PASS when checked against this build's actual SHA256 values.
- Strict accepted-hash gate intentionally remains not promoted: `scripts\expected_release_hashes.json` still represents the previous accepted runtime, not this manual test build.

## 4. Property import smoke

Runtime used by probe:

- `C:\Program Files\SWTools\SWTools.exe`

Live SolidWorks file:

- `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`

Results:

- Import from file: PASS, 46 property names.
- Import from folder: PASS, 78 property names from first 3 SolidWorks files.
- Import from open components: not accepted in this run; SolidWorks was opened on a single part / later assembly loading stayed in `splash`, so this scenario still needs a separate run on a fully loaded assembly.

Required names observed in file/folder paths include:

- `Разработал`
- `Наименование`
- `Обозначение`
- `Масса`
- `Раздел`
- `Проект_ФБ`
- `Number`
- `Description`

Evidence:

- `_local_artifacts\reports\installed-property-import-1.1.12-20260628-175132\property-import-live.json`

## 5. Manual test instructions

Use only the installed build whose window title starts with:

- `SWTools 1.1.12+8073383.clean(x64)`

Do not use the old installed/manual build:

- `SWTools 1.1.11+9588cd3.clean(x64)`

Manual checks still required:

1. `Задать имя свойства` -> `Импорт...` -> `Получить из файла` on `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`.
2. `Задать имя свойства` -> `Импорт...` -> `Получить из папки` on `D:\1602.00.000 Шнек`.
3. `Задать имя свойства` -> `Импорт...` -> `Получить из открытых в SolidWorks компонентов` after opening a fully loaded assembly.
4. Confirm no visible legacy branding appears in the tested dialogs.

## 6. Remaining release blockers

This build is for manual testing only. Production remains NO-GO until:

- full live S7/S8 on the exact final package;
- strict BOM filters;
- licensing/activation;
- full visual L-01..L-15;
- signing/final dossier;
- accepted hash promotion;
- explicit owner GO.
