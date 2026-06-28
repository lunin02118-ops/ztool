# Исправление сохранения вычисленных свойств, 2026-06-29

## Статус

PARTIAL PASS / CODE CONTRACT PASS.

Production GO: NO-GO.

## Проблема

В таблице SWTools `Материал`, `Масса` и `Габарит` отображаются как native/calculated данные:

- `Col_Material` приходит из SolidWorks material API и используется для `NewMaterial`;
- `Col_Weight` приходит из add-in как `weight`;
- `Col_bound` приходит из add-in как `Boundarysize`.

До исправления `sendsavelist()` отправлял в add-in только пользовательские колонки `PropVal_*`. Поэтому:

- `Масса` могла уходить в модель как буквальная строка `SW-Mass@...`, а не вычисленное значение из таблицы;
- `Материал` мог уходить как буквальная `SW-Material@...`, если значение свойства было формульным/неразрешённым;
- `Габарит` вообще не записывался в свойства, если он был только вычисленной колонкой `Col_bound`, без отдельного пользовательского `PropVal_Габарит`.

## Сверка с оригинальным механизмом

Механизм записи add-in не менялся.

Оригинальный контракт сохранения остаётся тем же:

- клиент отправляет строки через WM_COPYDATA message id `33`;
- пользовательские свойства идут как payload `PropName`;
- add-in пишет свойства через `CustomPropertyManager.Add3`;
- материал детали пишется нативно через `SetMaterialPropertyName2`;
- цвет материала пишется через `MaterialPropertyValues`.

Исправление сделано только на стороне подготовки payload в `Frmmain.sendsavelist()`:

- специальные свойства `Материал`, `Масса`, `Габарит` перед отправкой нормализуются из native/calculated колонок;
- если `Габарит` есть как вычисленная колонка `Col_bound`, но отсутствует как `PropVal_*`, он добавляется в тот же оригинальный `PropName` payload;
- дубликаты не создаются: если пользовательская колонка свойства уже есть, синтетический calculated payload для этого имени не добавляется.

## Изменённые файлы

- `client-src/ZTool/Frmmain.cs`
- `tools/e2e/check_save_to_sw_contract.py`

## Автоматические проверки

Выполнено:

- `python tools\e2e\check_save_to_sw_contract.py --self-test` — PASS
- `python tools\e2e\check_save_to_sw_contract.py` — PASS
- `dotnet build client-src\ZTool.csproj -c Release --no-incremental` — PASS, только известные warnings
- `python tools\e2e\check_calculated_column_labels.py` — PASS
- `python tools\e2e\check_property_import_contract.py` — PASS
- `pwsh -NoProfile -File scripts\check_client_src_warnings.ps1` — PASS
- `python tools\secret_scan.py` — PASS
- `git diff --check` — PASS

## Что покрыто тестом

`check_save_to_sw_contract.py` теперь дополнительно защищает:

- `Материал` берётся из `Col_Material`, если свойство пустое или содержит нерешённую `SW-Material` / `SW-Материал`;
- `Масса` берётся из `Col_Weight`, если свойство пустое или содержит нерешённую `SW-Mass` / `SW-Масса`;
- `Габарит` берётся из `Col_bound`, если свойство пустое;
- `Материал`, `Масса`, `Габарит` отправляются через исходный `PropName` payload;
- `Габарит` добавляется из calculated column только если нет уже настроенной пользовательской колонки свойства;
- запись add-in остаётся через исходный native SolidWorks path.

## Что ещё не закрыто

Не выполнен destructive live-save test на копии CAD-файлов через UI `Сохранить всё` / `Сохранить только изменённые`.

Для production evidence нужен отдельный live-прогон на копии модели:

1. Подготовить fixture-копию CAD в `_local_artifacts`.
2. Открыть сборку в SolidWorks.
3. Подключить SWTools.
4. Проверить наличие значений `Материал`, `Масса`, `Габарит` в таблице.
5. Запустить сохранение свойств.
6. Открыть свойства деталей/сборки в SolidWorks и подтвердить read-back:
   - `Материал` записан как нормальное значение материала, не как `SW-Material@...`;
   - `Масса` записана как вычисленное числовое значение из таблицы, не как `SW-Mass@...`;
   - `Габарит` записан как строка габарита из `Col_bound`;
   - лишние свойства не созданы дважды.

До такого live read-back статус остаётся NO-GO для production release.
