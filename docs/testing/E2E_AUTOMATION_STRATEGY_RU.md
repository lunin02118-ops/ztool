# E2E automation strategy

Дата: 2026-06-24

Scope: первый исполняемый слой после плана `E2E_AUTOMATION_AND_DEV_ENV_PLAN_RU.md`.

## Цель

Перевести ручные проверки SWTools/SolidWorks в воспроизводимый harness, который пишет
машинно-читаемый результат:

```text
_local_artifacts/reports/e2e/<run>/e2e-result.json
_local_artifacts/reports/e2e/<run>/e2e-summary.md
```

`production_go_allowed` всегда остаётся `false` на этом слое. Финальный GO возможен
только отдельным release rehearsal с подписанием, live evidence и approval владельца.

## Команда foundation

Doctor-only запуск:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -DoctorOnly `
  -OutputDir _local_artifacts\reports\e2e\doctor
```

Проверка результата:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e\doctor\e2e-result.json `
  --allow-warn `
  --require-stage-pass 12-finalize
```

## Build/package режим

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -OutputDir _local_artifacts\reports\e2e\source-package
```

Этот режим связывает уже существующие gates:

```text
scripts\resolve_release_inputs.ps1
scripts\build_release_package.ps1
scripts\verify_release_package.ps1
scripts\check_swtools_runtime_identity.ps1
```

Пакет проверяется source-build hash values из текущего runtime. Accepted release hashes
не продвигаются и не меняются.

## Live S7 режим

Live S7 запускается только явно:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly D:\Development\ztool\TestModel\0614-A00.SLDASM
```

S7 использует `scripts\swtools_s7_live_smoke.py`: UIA Invoke обязателен,
координатный клик не считается acceptance. Начиная со слоя S7 automation,
live gate также требует `row_count >= 29` и `column_count >= 30`, а
`e2e-result.json` содержит path/hash evidence для `SWTools.exe` и `SWTools.dll`.

Подробно: `docs/testing/E2E_S7_AUTOMATION_RU.md`.

## Live S8 BOM режим

Live S8 запускается только после S7 в том же run:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RunS8 `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly D:\Development\ztool\TestModel\0614-A00.SLDASM `
  -ExpectedBomModeCount 8 `
  -OutputDir _local_artifacts\reports\e2e\s8-bom
```

S8 использует `scripts\swtools_s8_bom_live.py`: раскрывает
`Экспорт спецификации` через UIA, сохраняет 8 `.xlsx` через стандартный
SaveFileDialog, закрывает export modal и валидирует Excel через `openpyxl`.
Проверяются не только наличие файлов, но и семантика: строки, `№ п/п`,
`Кол-во`, `Масса`, `Путь`, `Габарит`, эскизы в режимах 5/6
и фильтры 7/8. Пустые результаты фильтров 7/8 записываются как evidence
`filter_empty`; `-RequireStrictBomFilters` применяется только на fixture, где
эти фильтры обязаны вернуть строки.

Подробно: `docs/testing/E2E_S8_BOM_AUTOMATION_RU.md`.

## Статусы

```text
PASS           Машинные проверки прошли.
PASS_WITH_WARN Проверки прошли, но есть предупреждения среды или live-gate не запускался.
FAIL           Любая обязательная проверка упала.
```

`PASS_WITH_WARN` не может быть production approval. Для release mode будущий Sprint S8
должен требовать BOM 1-8 PASS без WARN.

`tools\e2e\assert_e2e_result.py --require-stage` и
`--require-stage-pass` требуют, чтобы stage существовал и имел status `PASS`.
Ожидаемый `SKIP`/`WARN` допустим только через явную форму:

```powershell
python tools\e2e\assert_e2e_result.py result.json `
  --allow-warn `
  --require-stage-status 07-s7-connect=SKIP
```

## Что этот слой не закрывает

```text
[ ] не создаёт отдельную RU strict fixture beyond TestModel/0614-A00;
[ ] не чинит product runtime bugs;
[ ] не утверждает screenshots/localization FULL PASS;
[ ] не обновляет accepted release hashes;
[ ] не заменяет ручной owner approval.
```
