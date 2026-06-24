# E2E S7 live methodology report

Дата: 2026-06-24

Branch/commit:

```text
codex/e2e-automated-s7
e1b3300da6457cc65d490856075377994ecf48d6
dirty=false
```

Production GO: NO-GO.

## Цель

Проверить, что E2E S7 automation выполняет методику, а не только запускает
отдельный smoke script:

```text
source build -> package -> verify package -> runtime identity
-> sw_test_preflight -Register -> SolidWorks -> UIA Подключить SW
-> row/column evidence in e2e-result.json
```

## Команда

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly "D:\Development\ztool\TestModel\0614-A00.SLDASM" `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -OutputDir _local_artifacts\reports\e2e-s7\live-method-clean
```

## Результат

```text
e2e status: PASS_WITH_WARN
production_go_allowed: false
05-preflight-register: PASS
07-s7-connect: PASS
S7 row_count: 29
S7 column_count: 40
status_text: Подключение завершено, затрачено 0,4 сек, всего 29 поз.
```

Warnings ожидаемые для текущего слоя:

```text
08-s8-bom-export: SKIP
09-excel-validation: SKIP
10-branding-version: SKIP
```

S8/BOM/Excel validation закрываются следующим E2E layer и не считаются
production pass в этом PR.

## Runtime under test

```text
runtime:
D:\Development\ztool\_local_artifacts\worktrees\pr83-e2e-s7\_local_artifacts\reports\e2e-s7\live-method-clean\package\SWTools-1.1.6\runtime

SWTools.exe:
F11CE34FB4C50F01D72E95E98260F80F944EDC26014B4F0BDB1532F7E7486299

SWTools.dll:
D9B5000A2654CF881502E53D23C76CB6F3F85C2EF552D322C7490652439C7EDE
```

Accepted release hashes не продвигались. Это source-build live evidence, а не
release-promotion.

## Machine checks

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e-s7\live-method-clean\e2e-result.json `
  --allow-warn `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 07-s7-connect `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30
```

Результат:

```text
E2E assertion PASS: status=PASS_WITH_WARN, production_go_allowed=False, stages=11
```

## Evidence custody

Полные machine-readable артефакты лежат локально и не коммитятся:

```text
_local_artifacts\reports\e2e-s7\live-method-clean\e2e-result.json
_local_artifacts\reports\e2e-s7\live-method-clean\e2e-summary.md
_local_artifacts\reports\e2e-s7\live-method-clean\doctor.json
_local_artifacts\reports\e2e-s7\live-method-clean\release-inputs.json
_local_artifacts\reports\e2e-s7\live-method-clean\runtime-identity.json
_local_artifacts\reports\e2e-s7\live-method-clean\05-preflight-register\preflight-report.json
_local_artifacts\reports\e2e-s7\live-method-clean\s7-live-smoke\s7-live-smoke-result.json
```

## Вывод

Методический S7 live path подтверждён:

```text
[PASS] source build/package/verify
[PASS] runtime identity
[PASS] sw_test_preflight -Register
[PASS] current runtime registered before live test
[PASS] UIA Invoke "Подключить SW"
[PASS] row_count >= 29
[PASS] column_count >= 30
[NO-GO] production release, because S8/BOM/Excel/localization/signing remain out of scope
```
