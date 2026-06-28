# SWTools 1.1.13: rename calculated BOM columns

Дата: 2026-06-28
Ветка: `codex/p4-production-blockers-20260626`
Базовый commit перед фиксом: `7ff9e03`

## Цель

Переименовать видимые расчетные колонки:

- `Масса ед._кг` -> `Масса`;
- `Габаритные размеры` -> `Габарит`.

Сделать видимые заголовки и Excel-якоря полностью консистентными:

- `Масса` -> named range `Масса`;
- `Габарит` -> named range `Габарит`.

## Изменения

- Обновлены дефолтные настройки колонок в `CConfigMng.cs`, `SWTools.settings`
  и `client-core/dist/SWTools.settings`.
- Обновлены ресурсы главной таблицы `Frmmain.resx`.
- Обновлен шаблон `Шаблоны спецификации/bom_шаблон.xlsx`: строка заголовков
  теперь содержит `Масса` и `Габарит`, named ranges переименованы в `Масса` и `Габарит`.
- Обновлены BOM-check scripts и S8 E2E labels.
- Добавлен regression gate `tools/e2e/check_calculated_column_labels.py`.
- `release-acceptance.yml` теперь проверяет контракт расчетных колонок.

## Локальные проверки

PASS:

- source client build, Release, no incremental cache;
- source add-in build, Release, no incremental cache;
- `python tools/e2e/check_calculated_column_labels.py --self-test`;
- `python tools/e2e/check_calculated_column_labels.py`;
- `python client-core/tools/check_bom_template.py SWTools.settings`;
- `python client-core/tools/check_bom_template.py client-core/dist/SWTools.settings`;
- `python tools/check_visible_brand_boundary.py`;
- `python tools/secret_scan.py`;
- `git diff --check`;
- `pwsh -NoProfile -File scripts/check_client_src_warnings.ps1`.

Логи:

`_local_artifacts/reports/calculated-columns-rename-20260628-225834`

## Live SolidWorks E2E

Команда выполняла source build, package, preflight/RegAsm, live S7, live S8,
strict filters и branding/version/icon gate.

Отчет:

`_local_artifacts/reports/calculated-anchors-live-20260628-234505`

Итог:

- общий статус: `PASS`;
- `production_go_allowed`: `false`;
- `07-s7-connect`: PASS, 29 строк, 40 колонок;
- `08-s8-bom-export`: PASS, 8/8 Excel-файлов;
- `09-excel-validation`: PASS;
- `10-branding-version`: PASS.

## Проверка Excel-экспорта

Проверены все 8 экспортированных `.xlsx` из live S8:

| Режим | Файл | Строк | `Масса` | `Габарит` |
|---:|---|---:|---:|---:|
| 1 | `01-summary.xlsx` | 29 | 29 | 29 |
| 2 | `02-hierarchy.xlsx` | 32 | 32 | 32 |
| 3 | `03-top-level.xlsx` | 6 | 6 | 6 |
| 4 | `04-parts-summary.xlsx` | 25 | 25 | 25 |
| 5 | `05-summary-images.xlsx` | 29 | 29 | 29 |
| 6 | `06-hierarchy-images.xlsx` | 32 | 32 | 32 |
| 7 | `07-processed-filter.xlsx` | 18 | 18 | 18 |
| 8 | `08-purchased-filter.xlsx` | 6 | 6 | 6 |

Во всех файлах:

- заголовок `Масса` присутствует;
- заголовок `Габарит` присутствует;
- старый заголовок `Масса ед._кг` отсутствует;
- старый заголовок `Габаритные размеры` отсутствует;
- старый Excel anchor `МассаЕдКг` отсутствует;
- старый Excel anchor `ГабаритныеРазмеры` отсутствует;
- значения в расчетных колонках заполнены.

## Артефакты

Runtime:

`_local_artifacts/reports/calculated-anchors-live-20260628-234505/package/SWTools-1.1.13/runtime`

SHA256:

- `SWTools.exe`: `ca3e9fd721bcfafcf44b06c5f4b536a38a13461ef48dc6ffea79db45ed79ce61`;
- `SWTools.dll`: `898976f17be6014eb0571f9ff49f038ce67d9d81a05e42a6914ace1e02de74cf`.

Installer:

`_local_artifacts/reports/calculated-anchors-live-20260628-234505/SWTools-1.1.13-Setup.exe`

SHA256:

`7902de10eb0b0af414c59498da34f976308995a33f20eff00066c8f9016f9813`

## Граница приемки

Этот отчет подтверждает переименование расчетных колонок, Excel-якорей и live export S7/S8
на текущем source-built package.

Это не финальный production GO. Остаются общие релизные блокеры:

- финальная подпись Authenticode;
- accepted hashes promotion;
- полный visual localization acceptance;
- owner/auditor final GO.
