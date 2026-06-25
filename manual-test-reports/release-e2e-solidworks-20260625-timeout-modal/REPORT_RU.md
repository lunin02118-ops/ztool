# Release E2E SolidWorks live run after S7 timeout-modal fix

Дата: 2026-06-25

## Статус

`CORE RELEASE E2E: PASS / PRODUCTION GO: NO-GO / VISUAL FULL PASS: NO-GO`

Проверка выполнена на реальной Windows/SolidWorks 2025 машине после merge
`#93 -> #96 -> #97 -> #98`.

Проверяемый commit: `532ad0d` (`codex/release-e2e-timeout-dialog-fix`), поверх
`origin/main` `309d5cd`.

## Почему потребовался fix-up

Первый live run с `origin/main` `309d5cd` прошёл сборку, package verification,
runtime identity, RegAsm/preflight и подготовку strict BOM fixture, но упал на S7:

```text
Blocking dialog during S7 connect:
SolidWorks / Информация / Тайм-аут соединения
```

Trace показал, что `SWTools.exe` уже был запущен из правильного runtime и с
правильной командной строкой, а dialog принадлежал SolidWorks PID. Такой timeout
может появиться асинхронно от `openZtool` после старта runtime и не должен сам
по себе считаться провалом S7, если таблица затем заполняется.

Изменение в `scripts/swtools_s7_live_smoke.py`: во время S7 connect dialog
`Тайм-аут соединения` закрывается object-based только для ожидаемого SolidWorks
PID, после чего тест продолжает ждать grid evidence. Если IPC действительно
сломана, gate всё равно падает по `row_count < 29` или `column_count < 30`.

## Команда

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsReleaseE2E.ps1 `
  -SolidWorksExe 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe' `
  -SolidWorksDir 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS' `
  -SolidWorksToolsDll 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\solidworkstools.dll' `
  -TestAssembly 'D:\Development\ztool\_local_artifacts\worktrees\release-e2e-main-20260625\TestModel\0614-A00.SLDASM' `
  -OutputDir 'D:\Development\ztool\_local_artifacts\reports\release-e2e-live-20260625-162846' `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -ExpectedBomModeCount 8
```

## Evidence

Локальный evidence каталог:

```text
D:\Development\ztool\_local_artifacts\reports\release-e2e-live-20260625-162846
```

Ключевые файлы:

```text
release-e2e-solidworks-result.json
e2e-result.json
s7-live-smoke\s7-live-smoke-result.json
s8-bom-export\s8-bom-result.json
10-branding-version\branding-version-result.json
```

## Результаты

```text
release-e2e-solidworks-result.json: PASS
production_go_allowed: false
visual-localization-full-profile: SKIP (RequireVisualFullProfile not set)
```

Stages:

```text
00-doctor: PASS
01-resolve-build-source-inputs: PASS
02-build-package: PASS
03-verify-package: PASS
04-runtime-identity: PASS
05-preflight-register: PASS
06-prepare-strict-bom-fixture: PASS
07-s7-connect: PASS
08-s8-bom-export: PASS
09-excel-validation: PASS
10-branding-version: PASS
12-finalize: PASS
```

S7:

```text
rows: 29
columns: 40
status: Подключение завершено, затрачено 0,3 сек, всего 29 поз.
model_ready_gate: PASS
```

S8 strict BOM:

```text
mode 1 rows: 29
mode 2 rows: 32
mode 3 rows: 6
mode 4 rows: 25
mode 5 rows: 29, images: true
mode 6 rows: 32, images: true
mode 7 rows: 18
mode 8 rows: 6
semantic Excel validation: PASS
strict filters: PASS
```

Branding/version/icon:

```text
title: SWTools 1.1.6+532ad0d.clean(x64)
ProductVersion: 1.1.6+532ad0d.clean
FileVersion: 1.1.6.407
live icon SHA == embedded EXE icon SHA: true
```

## Остаточные NO-GO

Этот прогон закрывает core release E2E layer, но не является production GO.

Остаётся:

```text
1. Full visual manifest L-01..L-15 strict PASS.
2. Owner/auditor visual review.
3. Signing/final release dossier.
4. Accepted hash decision.
5. Explicit owner GO.
```
