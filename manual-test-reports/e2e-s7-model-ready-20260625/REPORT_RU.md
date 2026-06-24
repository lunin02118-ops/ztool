# E2E S7 model-ready live report

Дата: 2026-06-25

Branch/commit:

```text
codex/e2e-s7-model-ready
345548cd17994c22690eed220844518a76856ee0
```

Production GO: NO-GO.

## Цель

Закрыть live-регресс S7: `SWTools.exe` запускался через
`ZTool.SwAddin.openZtool(0)` пока SolidWorks ещё показывал штатное окно
загрузки компонентов/графики. Автоматизация считала это blocking modal и могла
падать до `Подключить SW`.

Фикс не меняет product/runtime source. Изменён только E2E слой:

```text
ensure_model_open -> model_ready_gate -> openZtool(0) -> SWTools.exe
```

## Что изменено

```text
[PASS] S7 smoke различает transient SolidWorks loading dialog и настоящий blocker.
[PASS] Transient dialog не закрывается тестом, а пережидается.
[PASS] Перед openZtool требуется стабильный интервал без transient dialog.
[PASS] model_ready_gate пишется в s7-live-smoke-result.json.
[PASS] orchestrator пробрасывает model_ready_gate в stages[07-s7-connect].details.
[PASS] assert_e2e_result.py получил --require-s7-model-ready.
[PASS] negative self-test отвергает S7 rows/columns без PASS model_ready_gate.
```

## Live S7 check

Команда:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly "D:\Development\ztool\_local_artifacts\worktrees\pr88-s7-model-ready\TestModel\0614-A00.SLDASM" `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -OutputDir _local_artifacts\reports\e2e-s7-model-ready\live-01
```

Результат:

```text
e2e status: PASS_WITH_WARN
production_go_allowed: false
S7 row_count: 29
S7 column_count: 40
status_text: Подключение завершено, затрачено 0,3 сек, всего 29 поз.
model_ready_gate.status: PASS
model_ready_gate.transient_dialog_count: 5
model_ready_gate.waited_seconds: 3.913
model_ready_gate.stable_for_seconds: 1.529
```

Ключевое evidence: gate увидел и переждал штатные SolidWorks окна
`Открытие компонентов`, `Обновление сборки`, `Обновление графики`,
`Загружается файл: ...\PArt-017.SLDASM` без закрытия этих окон.

Machine assertion:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e-s7-model-ready\live-01\e2e-result.json `
  --allow-warn `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 07-s7-connect `
  --require-s7-model-ready `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30
```

Результат:

```text
E2E assertion PASS: status=PASS_WITH_WARN, production_go_allowed=False, stages=11
```

## Full regression check

Команда:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RunS8 `
  -RunBrandingVersion `
  -RequireSolidWorks `
  -PrepareStrictBomFixture `
  -ForceStrictBomFixture `
  -RequireStrictBomFilters `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly "D:\Development\ztool\_local_artifacts\worktrees\pr88-s7-model-ready\TestModel\0614-A00.SLDASM" `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -ExpectedBomModeCount 8 `
  -OutputDir _local_artifacts\reports\e2e-s7-model-ready\live-full-01
```

Результат:

```text
e2e status: PASS
production_go_allowed: false
S7 row_count: 29
S7 column_count: 40
model_ready_gate.status: PASS
S8 mode_count: 8
S8 strict mode 7 rows: 18
S8 strict mode 8 rows: 6
branding title: SWTools 1.1.6+345548c.clean(x64)
icon_hash_match: true
```

Machine assertion:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e-s7-model-ready\live-full-01\e2e-result.json `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 07-s7-connect `
  --require-stage-pass 08-s8-bom-export `
  --require-stage-pass 09-excel-validation `
  --require-stage-pass 10-branding-version `
  --require-s7-model-ready `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30 `
  --require-s8-mode-count 8 `
  --require-s8-all-pass `
  --require-s8-strict-filters `
  --require-branding-version
```

Результат:

```text
E2E assertion PASS: status=PASS, production_go_allowed=False, stages=12
```

## Static checks

```text
[PASS] python -m py_compile scripts\swtools_s7_live_smoke.py tools\e2e\assert_e2e_result.py tools\e2e\selftest_assert_e2e_result.py
[PASS] PowerShell parser: scripts\e2e\Invoke-SWToolsE2E.ps1
[PASS] python tools\e2e\selftest_assert_e2e_result.py
[PASS] python tools\secret_scan.py
[PASS] git diff --check
```

## Evidence custody

Полные machine-readable артефакты не коммитятся:

```text
_local_artifacts\reports\e2e-s7-model-ready\live-01\e2e-result.json
_local_artifacts\reports\e2e-s7-model-ready\live-01\s7-live-smoke\s7-live-smoke-result.json
_local_artifacts\reports\e2e-s7-model-ready\live-full-01\e2e-result.json
_local_artifacts\reports\e2e-s7-model-ready\live-full-01\s7-live-smoke\s7-live-smoke-result.json
_local_artifacts\reports\e2e-s7-model-ready\live-full-01\s8-bom-export\s8-bom-result.json
_local_artifacts\reports\e2e-s7-model-ready\live-full-01\10-branding-version\branding-version-result.json
```

## Вывод

S7 live blocker закрыт на уровне E2E automation:

```text
[PASS] SolidWorks transient loading dialog no longer fails S7 before openZtool.
[PASS] No coordinate click / no forced close of transient loading dialog.
[PASS] S7 row/column evidence preserved.
[PASS] Full S7+S8 strict+branding regression remains green.
[NO-GO] Production release remains blocked by final release dossier, signing, visual localization acceptance and owner GO.
```
