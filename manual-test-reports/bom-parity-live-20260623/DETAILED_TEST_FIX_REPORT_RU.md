# SWTools 1.1.6: отчёт оценки рефакторинга и BOM/export parity

Дата: 2026-06-23

Ветка: `codex/fix-bom-property-parity`

Статус: `PASS/WARN`, без заявки на production GO.

## 1. Главная цель проверки

Главная цель этой итерации - оценить рефакторинг SWTools: проверить, что
from-source/refactored runtime повторяет старое рабочее поведение, не теряет
интеграцию с SolidWorks, не ломает BOM export, не возвращает vendor-localization
debt в финальный RU runtime и может быть принят как база для дальнейшего релиза.

Это не был простой smoke-test экспорта. Проверка должна была ответить на вопросы:

- можно ли доверять собранным из исходников `SWTools.exe` и `SWTools.dll`;
- не потеряна ли совместимость EXE <-> SolidWorks add-in;
- сохранилась ли функциональность, которая раньше работала в старом vendor/build;
- какие регрессы внес refactoring/from-source перенос;
- какие проблемы нужно закрыть gates, чтобы они не возвращались перед релизом.

Итоговая оценка рефакторинга:

- `PASS` по базовой загрузке, S7 и BOM modes 1-6.
- `WARN` по фильтр-режимам 7/8 из-за неполной RU-фикстуры (`Тип` пустой).
- `NO-GO` для production release, пока не закрыты strict 7/8 на RU-фикстуре и
  accepted-hash release decision.

## 2. Проверяемый функциональный путь

Проверить и довести до воспроизводимого состояния цепочку:

- сборка `SWTools.exe` и `SWTools.dll` из исходников;
- загрузка add-in в SolidWorks 2025;
- подключение к открытой сборке `TestModel\0614-A00.SLDASM`;
- заполнение таблицы SWTools из SolidWorks;
- экспорт BOM во все 8 режимов;
- корректность русских свойств, сопоставления столбцов и расчетных полей;
- отсутствие возврата к китайским именам/значениям в итоговом runtime-профиле.

## 3. Критерии оценки рефакторинга

Критерии, по которым оценивался refactoring/from-source перенос:

1. Runtime identity:
   - запускается именно тестовый `SWTools.exe`;
   - SolidWorks загружает именно тестовый `SWTools.dll`;
   - path/hash зафиксированы в evidence.

2. EXE <-> add-in compatibility:
   - add-in грузится в SolidWorks;
   - `Подключить SW` возвращает компоненты модели;
   - таблица заполняется, а не дает "0 поз.".

3. Feature parity по BOM:
   - 8 режимов доступны;
   - режимы 1-6 экспортируют строки, массу, количество, путь, габариты и эскизы;
   - режимы 7/8 честно проверяют rule/filter semantics, а не маскируют проблему.

4. Source-level configuration parity:
   - русские `propname` согласованы с template defined names;
   - calculated columns не затираются пустыми пользовательскими свойствами;
   - скрытые mappings не теряются после сохранения формы сопоставления.

5. Localization/rebrand parity:
   - итоговый runtime не возвращает `ZTool` там, где должен быть `SWTools`;
   - production RU settings не содержит legacy Han aliases или mixed rules;
   - vendor-specific behavior используется только как reference, не как финальное решение.

6. Release gates:
   - сборка, warning baseline, package verify и secret scan дают воспроизводимый результат;
   - accepted hash promotion отделен от dry-run проверки.

## 4. Использованные артефакты

Live-tested package:

`D:\Development\ztool\_local_artifacts\releases\1.1.6-bom-parity-filterfix-20260623-215405\SWTools-1.1.6-bom-parity-filterfix`

RU-only dry-run package после финальной чистки legacy filter tokens:

`D:\Development\ztool\_local_artifacts\releases\1.1.6-bom-parity-ru-only-20260623-231218\SWTools-1.1.6-bom-parity-ru-only`

Основные hashes RU-only dry-run package:

- `runtime\SWTools.exe`: `9863dc5d58a46e1e3915da2b7ec19e55c4b3ac9ac27d60516b32624027618071`
- `runtime\SWTools.dll`: `1d3403f46b264a8b38536a170ec26d22ce0958f295a0c7d68b34462841bc61a3`

Evidence folder:

`manual-test-reports\bom-parity-live-20260623\`

Ключевые evidence-файлы:

- `s7-connect-readback-filterfix-final.json`
- `s8-export-run-ru-filterfix.json`
- `validator-filterfix-final.txt`
- `run_s8_live_export.ps1`
- `REPORT_RU.md`

## 5. Итог live-проверки

### S7: подключение SolidWorks

Результат: `PASS`.

Доказательство:

- UIA GridPattern readback: `rowCount=29`, `columnCount=40`.
- Runtime path/hash соответствовал тестовому пакету.
- Таблица SWTools заполнилась компонентами открытой сборки.

Evidence:

`manual-test-reports\bom-parity-live-20260623\s7-connect-readback-filterfix-final.json`

### S8: экспорт BOM, 8 режимов

Результат: `PASS/WARN`.

Из `validator-filterfix-final.txt`:

| Режим | Назначение | Статус | Строк |
|---|---|---:|---:|
| 1 | Сводная спецификация | PASS | 29 |
| 2 | Иерархическая спецификация | PASS | 32 |
| 3 | Верхний уровень | PASS | 6 |
| 4 | Только детали | PASS | 25 |
| 5 | Сводная + эскизы | PASS | 29 |
| 6 | Иерархическая + эскизы | PASS | 32 |
| 7 | Обрабатываемые детали | WARN | 0 |
| 8 | Покупные изделия | WARN | 0 |

Причина `WARN` по 7/8:

- Runtime RU profile читает свойство `Тип`.
- В текущей live-фикстуре `Тип` пустой.
- Фильтры 7/8 поэтому корректно возвращают 0 строк.
- Это не crash и не поломка экспорта, но это не `FULL PASS` для фильтр-режимов.

Решение по политике:

- Не добавлять `Тип/类型` alias в runtime.
- Не добавлять `机加`/`外购` и другие legacy Han values в production `SWTools.settings`.
- Для strict PASS режимов 7/8 нужна RU-фикстура, где `Тип` заполнен русскими значениями: `Мех.обработка`, `Листовая`, `Литьё`, `Сварка`, `Покупное`, `Стандартное`.

## 6. Регрессы рефакторинга и исправленные ошибки

### F-01. Add-in загружался, но S7 давал пустую таблицу / 0 позиций

Симптом:

- SolidWorks add-in стартовал, но запросы EXE -> add-in не приводили к заполнению таблицы.
- В live-проверке это выглядело как успешное действие без данных.

Причина:

- В SolidWorks-hosted add-in не подгружалась runtime-зависимость `System.Resources.Extensions`.
- Исключение в старом пути было плохо диагностируемым и приводило к ложной картине "таблица просто пустая".

Исправлено:

- `client-src\ZTool.csproj`: версия `System.Resources.Extensions` согласована с runtime identity.
- `client-src-addin\ZTool.SwAddin.csproj`: та же зависимость для add-in.
- `client-src-addin\ZTool\PMPHandler.cs`: добавлен `AssemblyResolve`, который ищет зависимости рядом с add-in DLL.
- `scripts\verify_release_package.ps1`: добавлена проверка identity `runtime\System.Resources.Extensions.dll = Version=4.0.0.0`.

Доказательство:

- S7 после исправления: `rowCount=29`, `columnCount=40`.
- Package verify подтверждает runtime dependency identity.

### F-02. BOM экспорт оставлял пользовательские свойства пустыми

Симптом:

- В Excel после экспорта были заполнены расчетные/служебные поля, но пользовательские свойства вроде `Наименование`, `Обозначение`, `Материал`, `Тип`, `Версия` не попадали в шаблон.

Причина:

- Runtime profile и template anchors были частично рассинхронизированы.
- Остались старые/неактуальные имена `Номер чертежа`, `Имя детали`.
- Часть mappings могла теряться после сохранения формы сопоставления.

Исправлено:

- `client-src\ZTool\CConfigDO.cs`: default `propname` приведен к RU-набору:
  `Разработал`, `Наименование`, `Обозначение`, `Материал`, `Тип`, `Версия`, `Обработка поверхности`, `Дата разработки`, `Масса`.
- `client-src\ZTool\CConfigMng.cs`: добавлено восстановление обязательных стандартных mappings.
- `client-src\ZTool\Frmmapping.cs`: при сохранении сопоставления сохраняются hidden mappings, чтобы расчетные и обязательные anchors не терялись.
- `SWTools.settings` и `client-core\dist\SWTools.settings`: `Номер чертежа`/`Имя детали` заменены на `Обозначение`/`Наименование`.

Доказательство:

- `python client-core\tools\check_bom_template.py SWTools.settings`: PASS.
- `python client-core\tools\check_bom_template.py client-core\dist\SWTools.settings`: PASS.

### F-03. Расчетные поля BOM могли не попадать в Excel

Симптом:

- Пользовательские свойства и расчетные поля пересекались по логике mapping.
- Был риск, что пустые custom-property columns затрут расчетные значения.

Причина:

- `Col_Weight` и `Col_bound` не были жестко закреплены как calculated mappings.

Исправлено:

- `CConfigMng.cs`: обязательные mappings:
  - `Col_Weight` -> `МассаЕдКг`
  - `Col_bound` -> `ГабаритныеРазмеры`
- `check_bom_template.py`: добавлена проверка calculated mappings и проверка пересечения template cells.

Доказательство:

- Validator по режимам 1-6: масса и габариты заполнены во всех строках данных.
- `check_bom_template.py`: anchors `МассаЕдКг`, `ГабаритныеРазмеры` найдены и согласованы.

### F-04. Фильтр-режимы 7/8 могли экспортировать неверный набор строк

Симптом:

- Режимы "Обрабатываемые детали" и "Покупные изделия" ранее могли экспортировать неотфильтрованный BOM или 0 строк без понятной диагностики.

Причина:

- `CustomFilter.FilterByRule()` ожидает точный separator: `TAB + |@#$%|`.
- Старые rule strings могли использовать неправильный separator.
- Операторы должны быть русскими строками (`Содержит`, `Равно`, `Не равно`), а не legacy literals.

Исправлено:

- `client-core\tools\fix_filter_rules.py`: генерация rule strings byte-perfect с реальным TAB separator и русскими операторами.
- `check_bom_template.py`: проверяет separator, operator и наличие свойства правила в `<propname>`.

Доказательство:

- `check_bom_template.py`: все rules валидируются как `OK`.
- Validator честно показывает WARN 7/8 из-за пустого `Тип`, а не из-за сломанной сериализации правила.

### F-05. В финальный профиль попали legacy Han values

Симптом:

- В промежуточной попытке для демонстрации фильтров были добавлены значения `机加`/`外购` рядом с русскими значениями.
- Пользователь справедливо указал, что в итоговом runtime такого быть не должно.

Причина:

- Был смешан тестовый shortcut для старой демо-фикстуры и production RU profile.

Исправлено:

- Production `SWTools.settings` и `client-core\dist\SWTools.settings` оставлены RU-only.
- В `fix_filter_rules.py` значения фильтра теперь только русские:
  - `Мех.обработка;Листовая;Литьё;Сварка`
  - `Покупное;Стандартное`
- В `check_bom_template.py` добавлен RU language guard: production settings падает, если в `propname` или `FilterRulesList` есть Han.
- `russify_demo_properties.py` обновлен: при миграции старой демо-фикстуры в `Тип` пишутся русские значения.

Доказательство:

- `rg` по production settings/source/tools на выбранные Han tokens: нет совпадений.
- `rg --text` по RU-only package `runtime\SWTools.settings` и `runtime\SWTools.dll`: нет совпадений.
- `check_bom_template.py`: PASS.

### F-06. Add-in rename defaults всё ещё ссылались на старые vendor placeholders

Симптом:

- В `client-src-addin\ZTool\ReName.cs` оставались defaults:
  `$图号$`, `$零件名称$`, `$版本$`.

Причина:

- Это был старый from-source участок add-in, не затронутый первичной BOM-настройкой.

Исправлено:

- `ReName.cs` defaults заменены на:
  - `$Обозначение$`
  - `$Наименование$`
  - `$Версия$`

Доказательство:

- Повторный `check_client_src_warnings.ps1`: PASS, warning baseline не изменился.
- Повторный `rg` по выбранным Han tokens в production source path: нет совпадений.

### F-07. Автоматизация S8 ломалась из-за UI-состояния, а не из-за экспорта

Симптом:

- Runner не всегда мог открыть Ribbon export menu или сохранить файл.
- `FrmPreview` перекрывал взаимодействие.
- `Показывать рядом` не всегда отдавал TogglePattern через UIA.

Причина:

- UI-state зависел от предыдущего действия; coordinate clicks не годятся как acceptance evidence.

Исправлено только в evidence tooling:

- `run_s8_live_export.ps1`: перед открытием меню отправляет `Esc`, чтобы закрыть `FrmPreview`.
- Добавлен fallback click для checkbox, если TogglePattern недоступен.

Доказательство:

- После правки runner сохранил 8 `.xlsx` файлов.
- Validator обработал все 8 файлов.

Ограничение:

- Это не product source/runtime change.
- Acceptance всё равно должен опираться на UIA/file validators/logs, а не на голые координаты.

### F-08. CN-baseline сравнение не удалось завершить из-за состояния SolidWorks COM

Симптом:

- При попытке повторно прогнать old vendor/demo baseline:
  - `GetAddInObject('ZTool.SwAddin')` -> `TYPE_E_ELEMENTNOTFOUND`;
  - свежий `New-Object -ComObject SldWorks.Application` падал на `Visible` с `TYPE_E_ELEMENTNOTFOUND`.

Причина:

- SolidWorks COM automation вошёл в поврежденное/нерегистрируемое состояние после серии live-прогонов.
- Это не было доказано как product regression.

Статус:

- Не исправлялось как product bug.
- Зафиксировано как test-environment blocker для CN-baseline.
- RU-only production path проверен offline/package gates.

## 7. Выполненные проверки

Offline/static gates:

- `python client-core\tools\check_bom_template.py SWTools.settings`: PASS.
- `python client-core\tools\check_bom_template.py client-core\dist\SWTools.settings`: PASS.
- `python -m py_compile client-core\tools\fix_filter_rules.py client-core\tools\russify_demo_properties.py client-core\tools\check_bom_template.py`: PASS.
- `python tools\secret_scan.py`: PASS.
- `git diff --check`: PASS, только line-ending warnings.
- `rg` по production settings/source/tools на выбранные Han tokens: PASS, no matches.

Build/test gates:

- `pwsh scripts\check_client_src_warnings.ps1 -SolidWorksToolsPath "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll"`: PASS.
  - `client-src`: 123 warnings, baseline unchanged.
  - `client-src-addin`: 6 warnings, baseline unchanged.
- `python -m pytest license-server`: PASS, `139 passed, 2 skipped`.

Package gates:

- RU-only dry-run package build: PASS.
- `scripts\verify_release_package.ps1` on RU-only dry-run package: PASS with:
  - `-AllowDirtyManifest`
  - explicit current source-build hash overrides.
- `runtime/System.Resources.Extensions.dll identity is Version=4.0.0.0`: PASS.
- Addin brand verification: PASS.
- Package runtime selected Han token scan: PASS.

Accepted-hash gate:

- Strict accepted-hash verification is intentionally blocked.
- `scripts\expected_release_hashes.json` still points to accepted `1.1.6` hashes.
- New source-build package hashes must not be promoted without release decision and final acceptance.

## 8. Вывод по качеству рефакторинга

Рефакторинг прошел частичную приемку:

- Основная связка `SWTools.exe` + `SWTools.dll` + SolidWorks восстановлена.
- BOM export modes 1-6 подтверждены live-output файлами и validator report.
- Конфигурационные и template contracts стали лучше защищены preflight gates.
- Возврат к legacy Han/mixed runtime policy заблокирован проверкой.
- Package build/verify возможен, но пока только как dry-run source-build.

Рефакторинг пока нельзя считать полностью принятым для production:

- Фильтр-режимы 7/8 не получили strict PASS на RU-фикстуре.
- Accepted release hashes не обновлены и не должны обновляться без отдельного
  release decision.
- CN/vendor baseline comparison не завершен из-за COM/test-environment blocker.

Итого: refactoring direction подтвержден как рабочий, но release sign-off остается
заблокированным до закрытия live strict gates.

## 9. Что осталось до release sign-off

1. Подготовить или мигрировать RU test fixture:
   - заполнить `Тип` русскими значениями;
   - сохранить CAD-файлы только после бэкапа;
   - повторить S8 modes 7/8 как strict PASS.

2. Повторить live SolidWorks acceptance после восстановления/перезапуска COM-состояния:
   - preflight;
   - registration;
   - open `0614-A00.SLDASM` через file association;
   - confirm running runtime path/hash;
   - S7;
   - S8 all 8 modes.

3. После решения о релизном артефакте:
   - обновить `scripts\expected_release_hashes.json`;
   - пересобрать package из чистого дерева;
   - прогнать `verify_release_package.ps1` без `-AllowDirtyManifest` и без hash overrides.

4. Только после этого можно заявлять production GO.

## 10. Итог

Функционально устранены:

- пустая S7-таблица из-за add-in dependency/AssemblyResolve;
- рассинхрон `propname`/template mappings;
- потеря hidden/calculated mappings;
- неправильная сериализация filter rules;
- риск возврата legacy Han tokens в production RU profile;
- старые add-in rename placeholders;
- нестабильность S8 evidence runner.

Текущий статус честный:

- S7: `PASS`.
- S8 modes 1-6: `PASS`.
- S8 modes 7-8: `WARN`, потому что в live-фикстуре пустой `Тип`.
- Package/offline gates: `PASS` для dry-run source-build.
- Production GO: `NO-GO` до RU fixture strict PASS и accepted-hash release decision.
