# SWTools 1.1.13: rename calculated BOM columns

Дата: 2026-06-28
Ветка: `codex/p4-production-blockers-20260626`
Базовый commit перед фиксом: `7ff9e03`

## Цель

Переименовать видимые расчетные колонки:

- `Масса ед._кг` -> `Масса`;
- `Габаритные размеры` -> `Габарит`.

При этом сохранить внутренние Excel-якоря шаблона, чтобы экспорт спецификации
не потерял совместимость:

- `Масса` -> `МассаЕдКг`;
- `Габарит` -> `ГабаритныеРазмеры`.

## Изменения

- Обновлены дефолтные настройки колонок в `CConfigMng.cs`, `SWTools.settings`
  и `client-core/dist/SWTools.settings`.
- Обновлены ресурсы главной таблицы `Frmmain.resx`.
- Обновлен шаблон `Шаблоны спецификации/bom_шаблон.xlsx`: строка заголовков
  теперь содержит `Масса` и `Габарит`, named ranges оставлены прежними.
- Обновлены BOM-check scripts и S8 E2E labels.
- Добавлен regression gate `tools/e2e/check_calculated_column_labels.py`.
- `release-acceptance.yml` теперь проверяет контракт расчетных колонок.

## Локальные проверки

PASS:

- `dotnet build client-src/ZTool.csproj -c Release --no-incremental`;
- `dotnet build client-src-addin/ZTool.SwAddin.csproj -c Release --no-incremental`;
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

`_local_artifacts/reports/calculated-columns-live-20260628-230141`

Итог:

- общий статус: `PASS_WITH_WARN`;
- причина warning: `SLDWORKS.exe` уже был открыт до запуска doctor;
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
- значения в расчетных колонках заполнены.

## Артефакты

Runtime:

`_local_artifacts/reports/calculated-columns-live-20260628-230141/package/SWTools-1.1.13/runtime`

SHA256:

- `SWTools.exe`: `45727c454d69c7e80b8bc82764244f06622cf051bd9a06d39e46dd034ebdfbc5`;
- `SWTools.dll`: `a515298545de8f49568415a07c582df9fd3db20fcdd0479b91e864ea68434df5`.

Installer:

`_local_artifacts/reports/calculated-columns-live-20260628-230141/SWTools-1.1.13-Setup.exe`

SHA256:

`e565dd7745fb5f76ad8c34bfef00051ca816407bbf1724bb7166f565dec0b7d3`

## Граница приемки

Этот отчет подтверждает переименование расчетных колонок и live export S7/S8
на текущем source-built package.

Это не финальный production GO. Остаются общие релизные блокеры:

- финальная подпись Authenticode;
- accepted hashes promotion;
- полный visual localization acceptance;
- owner/auditor final GO.
