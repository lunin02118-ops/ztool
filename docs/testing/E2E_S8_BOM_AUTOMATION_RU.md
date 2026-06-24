# E2E S8 BOM automation

Дата: 2026-06-24

Scope: автоматизация S8 `Экспорт спецификации` поверх уже доказанного S7.

## Цель

S8 должен доказывать полный live path:

```text
S7 connected grid -> UIA Expand "Экспорт спецификации"
-> UIA Invoke mode item 1..8 -> Windows SaveFileDialog
-> save one XLSX per mode -> dismiss export modal for the same SWTools PID
-> openpyxl semantic validation
```

Координатный клик не считается acceptance. Если меню, SaveFileDialog или modal
нельзя пройти через UIA/Win32 object locators, тест должен падать.
Если completion modal появился, он должен принадлежать тому же `SWTools.exe`
PID, который подтверждён в runtime evidence. Чужая похожая модалка не
закрывается и должна валить live test. Для вопроса `Экспорт выполнен! Открыть?`
допустимы только `Нет` / `No`; `Да` / `Yes` не являются fallback. Если `.xlsx`
уже стабилен, а completion modal не появился за короткое окно ожидания, тест
продолжает следующий режим и фиксирует `modal.dismissed=false`.

## Команда

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RunS8 `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly D:\Development\ztool\TestModel\0614-A00.SLDASM `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -ExpectedBomModeCount 8 `
  -OutputDir _local_artifacts\reports\e2e\s8-bom
```

Проверка результата:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e\s8-bom\e2e-result.json `
  --allow-warn `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 07-s7-connect `
  --require-stage-pass 08-s8-bom-export `
  --require-stage-pass 09-excel-validation `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30 `
  --require-s8-mode-count 8 `
  --require-s8-all-pass
```

Строгая проверка непустых фильтров 7/8 включается отдельно только на fixture,
где гарантированно есть `Обрабатываемые детали` и `Покупные изделия`:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RunS8 `
  -PrepareStrictBomFixture `
  -ForceStrictBomFixture `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly D:\Development\ztool\TestModel\0614-A00.SLDASM `
  -ExpectedBomModeCount 8 `
  -RequireStrictBomFilters `
  -OutputDir _local_artifacts\reports\e2e\s8-bom-strict
```

`-PrepareStrictBomFixture` копирует исходный `TestModel` в
`_local_artifacts\reports\e2e\s8-bom-strict\strict-fixture\TestModel-RU`,
пишет русские свойства через SolidWorks COM только в копию и переключает S7/S8
на полученный `fixture-manifest.json -> assembly_path`. Оригинальный
`TestModel` в репозитории не изменяется.

Проверка strict-result:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e\s8-bom-strict\e2e-result.json `
  --allow-warn `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 06-prepare-strict-bom-fixture `
  --require-stage-pass 07-s7-connect `
  --require-stage-pass 08-s8-bom-export `
  --require-stage-pass 09-excel-validation `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30 `
  --require-s8-mode-count 8 `
  --require-s8-all-pass `
  --require-s8-strict-filters
```

## Evidence

Live result должен содержать:

```text
artifacts.s8_report_dir
artifacts.s8_export_dir
artifacts.s8_bom_json
stages[08-s8-bom-export].details.export_dir
stages[08-s8-bom-export].details.mode_count
stages[08-s8-bom-export].details.modes[].file
stages[08-s8-bom-export].details.modes[].rows
stages[08-s8-bom-export].details.modes[].number
stages[08-s8-bom-export].details.modes[].quantity
stages[08-s8-bom-export].details.modes[].weight
stages[08-s8-bom-export].details.modes[].path
stages[08-s8-bom-export].details.modes[].dimensions
stages[08-s8-bom-export].details.modes[].has_images
stages[08-s8-bom-export].details.modes[].filter_empty
stages[08-s8-bom-export].details.modes[].modal_process_id
stages[08-s8-bom-export].details.modes[].modal_expected_process_id
stages[08-s8-bom-export].details.modes[].modal_button
stages[09-excel-validation].details.status
stages[09-excel-validation].details.issues
```

`scripts\swtools_s8_bom_live.py` также пишет подробный
`s8-bom-result.json`, включая SHA256 каждого `.xlsx`, modal PID/text/button и
семантический read-back workbook.

Process-scope self-test без SolidWorks:

```powershell
python scripts\swtools_s8_bom_live.py --self-test-process-scoped-modal
```

Этот тест создаёт похожую модалку в другом процессе и проверяет, что S8 helper
не закрывает её, а записывает как `ignored_foreign_modals`.

## Semantic checks

Для каждого режима проверяется:

```text
[ ] файл .xlsx создан и стабилен;
[ ] есть data rows ниже строки 6, кроме фильтр-режимов 7/8;
[ ] № п/п заполнен для каждой data row;
[ ] Кол-во заполнено для каждой data row;
[ ] Масса ед. кг заполнена для каждой data row;
[ ] Путь заполнен для каждой data row;
[ ] Габаритные размеры заполнены для каждой data row;
[ ] режимы 5/6 содержат embedded images;
[ ] режим 3 имеет меньше строк, чем режим 1;
[ ] режим 5 повторяет row count режима 1;
[ ] режим 6 повторяет row count режима 2;
[ ] режимы 7/8 не равны полной сводной спецификации;
[ ] при `-RequireStrictBomFilters` режимы 7/8 не пустые (`rows > 0`) и не
    помечены как `filter_empty`.
```

## Acceptance

```text
[ ] S7 уже PASS в том же E2E run;
[ ] runtime path/hash recorded;
[ ] 8/8 BOM modes exported through UIA;
[ ] if export completion modal appears, modal PID equals expected SWTools PID;
[ ] semantic Excel validation PASS;
[ ] empty filter result is recorded as `filter_empty`;
[ ] strict filters are recorded and enforced when required;
[ ] strict fixture manifest records copied assembly path and RU `Тип` values;
[ ] production_go_allowed=false.
```

## Не закрывает

```text
[ ] Authenticode production signing;
[ ] final accepted release hashes;
[ ] localization screenshot FULL PASS;
[ ] owner production GO.
```
