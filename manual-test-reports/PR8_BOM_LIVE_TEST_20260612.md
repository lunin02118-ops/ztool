# PR #8 BOM live test report

Дата: 2026-06-12  
Машина: Windows, SolidWorks Premium 2025 SP3.0  
Ветка: `devin/1781201882-bom-templates`  
HEAD: `3e84cc4d0dc3888302aa9124b3db92190f64b585`

## Проверенная сборка

Runtime-папка: `D:\ztool-pr8-test`

| Артефакт | SHA256 |
| --- | --- |
| `ZTool.exe` | `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8` |
| `ZTool.dll` | `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961` |
| `Шаблоны спецификации\bom_шаблон.xlsx` | `6A6722555A880BD2B41E16252B0515BF3CAB733DE0296873286D0F388E755796` |

`ZTool.settings` и папка `Шаблоны спецификации` скопированы из чистого checkout PR #8.
Путь шаблона перенацелен скриптом:

```powershell
client-core\tools\set_bom_template_path.ps1 -Folder "D:\ztool-pr8-test" -Settings "D:\ztool-pr8-test\ZTool.settings"
```

## Pre-flight

Команда:

```powershell
$env:PYTHONIOENCODING='utf-8'
python client-core\tools\check_bom_template.py "D:\ztool-pr8-test\ZTool.settings"
```

Результат: `PASS`.

Подтверждено:

- 6 BOM-пресетов найдены.
- Шаблон открывается.
- Лист: `图纸明细1`.
- Defined names в шаблоне: `图号`, `序号`, `材质`, `版本`, `磁盘文件名`, `类型`, `统计数量`, `缩略图`, `表面处理`, `路径`, `重量`, `零件名称`.
- 8/8 mapping names из `namemappinglist` найдены в шаблоне.

Замечание по методике: в `Шаблоны спецификации/МЕТОДИКА_ТЕСТИРОВАНИЯ_BOM.md` в таблице указаны сокращённые анкеры (`零名`, `图`, `材`, `统数` и т.д.), но фактический шаблон и pre-flight используют полные имена (`零件名称`, `图号`, `材质`, `统计数量` и т.д.). Это дефект документации, не блокирует pre-flight.

## Запуск SolidWorks / ZTool

Прямой запуск `SLDWORKS.exe` из PowerShell воспроизводит ошибку SolidWorks:

```text
Не удалось загрузить Microsoft .NET Framework.
```

Для теста использован корректный интерактивный запуск через desktop shell / ярлык SolidWorks. После этого SolidWorks стартовал нормально.

Открытая модель:

```text
D:\ztool-pr8-test\TestModel\0614-A00.SLDASM
```

Заголовок SolidWorks:

```text
SOLIDWORKS Premium 2025 SP3.0 - [0614-A00.SLDASM]
```

`ZTool.exe` запущен из `D:\ztool-pr8-test`; hash процесса совпадает с проверенным `8EAF413F...26F37C8`.

## Лицензия

Регистрация выполнена штатно через UI ZTool, без ручной записи в реестр.

Результат UI:

```text
Регистрация выполнена
```

После перезапуска ZTool окно `Действующая лицензия не обнаружена!` больше не появляется.

Важное наблюдение по UI: после программной записи текста в поля регистрации кнопка `Активация онлайн` оставалась disabled, пока значения не были введены через реальный keyboard input. Это похоже на зависимость формы от событий `TextChanged`.

## Чтение SolidWorks

Команда UI: `Главная` -> `Подключить SW`.

Результат:

```text
Подключение завершено, затрачено 0,2 сек, всего 29 поз.
```

Таблица ZTool содержит 29 строк (`Строка 0` ... `Строка 28`). Значит чтение сборки из SolidWorks работает.

## Экспорт BOM

Папка результата:

```text
D:\ztool-pr8-test\bom-exports
```

Все 6 пресетов создали `.xlsx` без ошибок `Недопустимый шаблон` и без ошибки отсутствия `ICSharpCode.SharpZipLib.dll`.

| # | Пресет | Файл | Размер | UI-результат |
| --- | --- | --- | ---: | --- |
| 1 | Экспорт сводной спецификации | `preset-01-summary.xlsx` | 12683 | `Экспорт выполнен! Открыть?` |
| 2 | Экспорт иерархической спецификации | `preset-02-hierarchy.xlsx` | 12768 | `Экспорт выполнен! Открыть?` |
| 3 | Экспорт спецификации верхнего уровня | `preset-03-top-level.xlsx` | 11985 | `Экспорт выполнен! Открыть?` |
| 4 | Экспорт сводной спецификации деталей | `preset-04-parts-summary.xlsx` | 12561 | `Экспорт выполнен! Открыть?` |
| 5 | Экспорт сводной спецификации (с эскизами) | `preset-05-summary-images.xlsx` | 12683 | `Экспорт выполнен! Открыть?` |
| 6 | Экспорт иерархической спецификации (с эскизами) | `preset-06-hierarchy-images.xlsx` | 12768 | `Экспорт выполнен! Открыть?` |

## Фактическое содержимое Excel

Проверка через `openpyxl`:

- Все файлы открываются.
- Лист во всех файлах: `图纸明细1`.
- В строке 6 есть только шапка шаблона:
  - `A6 = № п/п`
  - `C6 = Наименование`
  - `D6 = Обозначение`
  - `G6 = Кол-во`
  - `M6 = Эскиз`
  - `N6 = Материал`
  - `O6 = Путь`
- Начиная со строки 7 нет ни одной заполненной ячейки с данными модели.
- Поиск по значениям модели (`0614`, `P00`, `RGOS`, `WLM`) во всех 6 файлах вернул 0 совпадений.
- В image-пресетах количество изображений в листе: `0`.

Итог по BOM: `FAIL`. Экспорт создаёт файл и показывает успех, но сохраняет только шаблон, без строк данных.

## Дополнительная диагностика

Проверено без изменения кода и без коммита:

1. В runtime-профиле временно отключены `ExportToBom_ByFilter1` и все `<ByFilter>true</ByFilter>`.
2. ZTool перезапущен.
3. SolidWorks подключён повторно: `29 поз.`
4. Экспорт `Экспорт сводной спецификации` создан как `diagnostic-summary-nofilter.xlsx`.
5. Результат тот же: только шаблон, `nonempty_after_row6 = 0`.

После диагностики оригинальный PR #8 `ZTool.settings` восстановлен.

Также проверен `Режим 2` в UI:

- файл `diagnostic-summary-mode2.xlsx` создан;
- результат тот же: только шаблон, `nonempty_after_row6 = 0`.

Вывод: причина не в `ByFilter` и не в переключателе `Режим 1/Режим 2`. Данные есть в ZTool-таблице после чтения SW, но не передаются в Excel при BOM export.

## Повторный прогон с demo-cn профилем

После коммита PR #8 `73972206dfebb0978472ab480f9616a68eb53588` выполнен
дополнительный прогон с `client-core/tools/ZTool.demo-cn.settings`.

Профиль подменён штатно:

```powershell
Copy-Item client-core\tools\ZTool.demo-cn.settings D:\ztool-pr8-test\ZTool.settings
client-core\tools\set_bom_template_path.ps1 -Folder "D:\ztool-pr8-test" -Settings "D:\ztool-pr8-test\ZTool.settings"
```

Pre-flight demo-cn: `PASS`.

Подтверждено:

- `propname` переключены на китайские свойства demo-модели: `设`, `零名`, `图`, `材`, `类`, `版`, `数`, `表处`, `设日`, `重`.
- `namemappinglist` по-прежнему указывает на полные defined names шаблона:
  `零件名称`, `图号`, `材质`, `类型`, `版本`, `统计数量`, `表面处理`, `重量`.
- После перезапуска ZTool заголовки таблицы реально стали китайскими:
  `设`, `零名`, `图`, `材`, `类`, `版`, `数`, `表处`, `设日`, `重`.
- Чтение SW снова успешно:

```text
Подключение завершено, затрачено 0,2 сек, всего 29 поз.
```

Экспорт `Экспорт сводной спецификации` с demo-cn профилем:

| Файл | Размер | Результат проверки |
| --- | ---: | --- |
| `0614-A00-20260612-2141.xlsx` | 16473 | `nonempty_after_row6 = 0` |
| `0614-A00-20260612-2143.xlsx` | 16473 | `nonempty_after_row6 = 0` |

Дополнительно выполнен диагностический demo-cn прогон с временным
`ByFilter=false`:

| Файл | Размер | Результат проверки |
| --- | ---: | --- |
| `demo-cn-summary-nofilter-20260612.xlsx` | 12683 | `nonempty_after_row6 = 0` |

Вывод по demo-cn: гипотеза "пусто только из-за русских имён свойств на
китайской demo-модели" не подтвердилась. Даже когда заголовки ZTool совпадают
с китайскими свойствами модели и чтение SW даёт `29 поз.`, экспорт Excel
по-прежнему сохраняет только шаблон, без строк данных и без авто-нумерации.

## Скриншот таблицы ZTool после demo-cn чтения

Дополнительно снят скрин самой таблицы ZTool после подключения SW на
`ZTool.demo-cn.settings`.

Ключевой факт по таблице:

- строк в ZTool: `29`;
- служебные колонки заполнены: `Номер`, `Имя файла на диске`, `Сохранить в папку`,
  `Материал`, `Номер детали в спецификации`, `Подсчитанное количество`, `Путь`,
  `Конфигурация`, `Масса ед._кг`, `Габаритные размеры`, `Уровень`,
  `Время создания`, `Время сохранения`;
- demo-cn prop-колонки `设`, `零名`, `图`, `材`, `类`, `版`, `数`, `表处`, `设日`,
  `重` в видимых строках пустые.

Это отделяет два сценария:

- исходный список компонентов и служебные данные в ZTool есть;
- пользовательские свойства demo-модели в тех колонках, которые настроены для
  BOM (`零名`, `图`, `材`, `类`, `版`, `数`, `表处`, `重`), в таблицу не попали.

Последний проверенный экспорт:

| Файл | Размер | Результат проверки |
| --- | ---: | --- |
| `0614-A00-20260612-2301.xlsx` | 15782 | `nonempty_after_row6 = 0`, совпадений по `0614/WLM/RGOS/SUS/6061/HNT` нет |

Локальные артефакты для передачи:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-table-demo-cn-leftmost-no-preview.png
D:\ztool-pr8-test\manual-artifacts\ztool-table-demo-cn-service-cols-no-preview.png
D:\ztool-pr8-test\manual-artifacts\latest-demo-cn-export-0614-A00-20260612-2301.xlsx
D:\ztool-pr8-test\manual-artifacts\ztool-demo-cn-table-evidence-20260612.zip
```

## Приоритетные находки

1. **P1: BOM export пишет пустой шаблон.**  
   Чтение SW успешно (`29 поз.`), все 6 экспортов создают файлы и показывают `Экспорт выполнен`, но строки данных в Excel отсутствуют, изображения тоже отсутствуют.

2. **P2: Документация BOM содержит устаревшие/неверные имена анкеров.**  
   Методика указывает сокращённые китайские имена, а реальный шаблон использует полные defined names.

3. **P2: UI регистрации зависит от keyboard input.**  
   При установке текста в поля через UI Automation кнопка `Активация онлайн` не включается; после реального клавиатурного ввода тех же значений включается и регистрация проходит.

4. **P2: SolidWorks нельзя запускать прямым `SLDWORKS.exe` из PowerShell в этой сессии.**  
   Такой запуск даёт `Не удалось загрузить Microsoft .NET Framework`. Через desktop shell / ярлык SolidWorks стартует и работает.

## Повторный прогон с `ZTool.demo-cn-fixed.settings` от 2026-06-13

Цель: проверить конфиг, где `propname` совпадают с реальными полными
именами свойств demo-модели (`设计`, `零件名称`, `图号`, `材料`, `类型`,
`版本`, `表面处理`, `设计日期`, `重量`), а не с сокращёнными
`设/零名/图/材/...`.

Подготовка:

```text
runtime: D:\ztool-pr8-test
repo branch: devin/1781201882-bom-templates
repo commit before local report update: 5b33fd2
ZTool.exe: 8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8
ZTool.dll: EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
ZTool.settings after path rewrite: BCA7AB581871943E72FC88B03C9588D8F38FA2E2C4A9652EE4563630D7710B79
template path: D:\ztool-pr8-test\Шаблоны спецификации\bom_шаблон.xlsx
```

Pre-flight:

- первый запуск в обычной Windows-консоли упал на выводе китайских символов:
  `UnicodeEncodeError: 'charmap' codec can't encode characters`;
- повторный запуск с `PYTHONIOENCODING=utf-8` прошёл успешно:
  `RESULT: PASS - settings/template are consistent for export`.

Live-прогон:

- SolidWorks 2025 открыт через desktop shortcut;
- через COM открыт файл `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`;
- запущен именно `D:\ztool-pr8-test\ZTool.exe`, SHA256 совпадает с ожидаемым;
- после `Подключить SW` таблица ZTool заполнилась данными, включая
  целевые китайские prop-колонки (`零件名称`, `图号`, `材料`, `类型`,
  `版本`, `表面处理`, `重量`).

Экспорт:

| Файл | Размер | Проверка |
| --- | ---: | --- |
| `D:\ztool-pr8-test\bom-exports\0614-A00-20260613-0019.xlsx` | 13685 | данные записаны |

Проверка через `openpyxl`:

```text
sheet: 图纸明细1
max_row: 107
max_col: 19
nonempty data rows in checked range: 32
data rows: 7..38
```

Заполненные колонки:

| Колонка | Заголовок | Пример значения |
| --- | --- | --- |
| C | `Наименование` | `支架`, `连杆`, `夹爪平台` |
| D | `Обозначение` | `0614-P001`, `0614-A00` |
| E | `Версия` | `A` |
| H | `Тип обработки` | `机加`, `组件`, `外购` |
| I | `Обработка поверхности` | `本色阳极` там, где свойство заполнено |
| J | `Масса` | `0.1619`, `0.9898` |
| N | `Материал` | `6061`, `SUS304` там, где свойство заполнено |

Остаточные проблемы:

1. **P1/P2: служебные колонки `№ п/п` и `Кол-во` пустые.**  
   В экспортированном файле `A7:A38` и `G7:G38` пустые, хотя строки данных
   вставлены и пользовательские свойства записаны.

2. **P2: при работе после подключения один раз появился диалог ZTool:**

```text
Не удается выполнить исходящий вызов, так как приложение обрабатывает входящий синхронный вызов.
(Исключение из HRESULT: 0x8001010D)
(RPC_E_CANTCALLOUT_ININPUTSYNCCALL)
```

После закрытия диалога и паузы экспорт всё же выполнился.

Вывод: дефект "Excel содержит только пустой шаблон" для demo-cn-fixed профиля
исправлен. Экспорт строк и custom-свойств работает. BOM пока нельзя закрывать
полностью из-за пустых служебных колонок `№ п/п`/`Кол-во` и RPC-диалога.

Локальные артефакты:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-demo-cn-fixed-after-connect.png
D:\ztool-pr8-test\manual-artifacts\ztool-demo-cn-fixed-spec-tab-after-wait.png
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0019.xlsx
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0019-analysis.json
```

## Повторный прогон commit `7983769` от 2026-06-13

Цель: проверить патч для служебных колонок `Номер`/`Количество`.

Подготовка:

```text
repo branch: devin/1781201882-bom-templates
repo commit: 7983769
runtime: D:\ztool-pr8-test
ZTool.exe: D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
replaced files:
  D:\ztool-pr8-test\ZTool.exe
  D:\ztool-pr8-test\ZTool.settings
  D:\ztool-pr8-test\Шаблоны спецификации\bom_шаблон.xlsx
```

Pre-flight:

```text
RESULT: PASS - settings/template are consistent for export.
Col_Number   header='Номер'      anchor OK
Col_Quantity header='Количество' anchor OK
```

Live-прогон:

- SolidWorks 2025 открыт через desktop shortcut;
- через COM открыт `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`;
- запущен именно `D:\ztool-pr8-test\ZTool.exe`, SHA256 совпадает с
  `D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833`;
- после `Подключить SW` таблица ZTool показывает заполненные служебные
  колонки `Номер` и `Колич...` / `Количество`:
  видимые значения `1, 2, 3...` и количества `1, 6, 3, 12...`.

Экспорт:

| Файл | Размер | Результат |
| --- | ---: | --- |
| `D:\ztool-pr8-test\bom-exports\0614-A00-20260613-0020.xlsx` | 17698 | строки данных есть, но `№ п/п` и `Кол-во` пустые |

Проверка через `openpyxl`:

```text
sheet: 图纸明细1
max_row: 104
max_col: 19
nonempty data rows: 29
headers:
  A6 = №\nп/п
  G6 = Кол-во
```

Фактические значения:

```text
A7:A35 = пусто
G7:G35 = пусто
```

При этом остальные данные продолжают писаться, например:

```text
C7 = 夹爪平台, D7 = 0614-A00, E7 = A, H7 = 组件, J7 = 0.9898
C21 = 支架, D21 = 0614-P001, E21 = A, H21 = 机加, I21 = 本色阳极, J21 = 0.1619, N21 = 6061
```

Вывод по commit `7983769`: патч довёл `Количество` до таблицы ZTool и
pre-flight, но не довёл до записи в Excel. Дефект экспорта служебных колонок
`№ п/п` и `Кол-во` остаётся открытым. В этом прогоне RPC-диалог не повторился.

Локальные артефакты:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-7983769-after-connect.png
D:\ztool-pr8-test\manual-artifacts\ztool-7983769-after-summary-export.png
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0020.xlsx
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0020-analysis.json
```

### Корректировка по свежим файлам `0927/0928`

После предыдущей записи появились свежие экспорты из того же runtime:

| Файл | Размер | Результат |
| --- | ---: | --- |
| `D:\ztool-pr8-test\bom-exports\0614-A00-20260613-0927.xlsx` | 12054 | `№ п/п`, `Кол-во`, `Путь` записаны |
| `D:\ztool-pr8-test\bom-exports\0614-A00-20260613-0928.xlsx` | 12054 | `№ п/п`, `Кол-во`, `Путь` записаны |

Проверка через `openpyxl` для обоих файлов:

```text
nonempty data rows: 29
A7:A16 = 1,2,3,4,5,6,7,8,9,10
G7:G16 = 1,1,6,6,1,1,3,1,1,1
O7:O9 = D:\ztool-pr8-test\TestModel\0614-A00.SLDASM,
        D:\ztool-pr8-test\TestModel\0614-A01.SLDASM,
        D:\ztool-pr8-test\TestModel\DBTS3-12-4.SLDPRT
```

При этом custom-колонки (`Наименование`, `Обозначение`, `Версия`,
`Тип обработки`, `Материал`) в `0927/0928` пустые. Это объясняется текущим
runtime-профилем из commit `7983769`: в `D:\ztool-pr8-test\ZTool.settings`
используются русские `propname` (`Имя детали`, `Номер чертежа`, `Материал`,
`Тип`, `Версия`), а тестовая demo-модель `0614-A00` содержит китайские
свойства (`零件名称`, `图号`, `材料`, `类型`, `版本`).

Итоговая корректировка статуса commit `7983769`:

- `№ п/п` / `Кол-во` / `Путь`: **PASS** на свежих файлах `0927/0928`;
- custom-колонки на китайской demo-модели с русским production-профилем:
  **ожидаемо пустые**;
- для полного demo-green нужен отдельный прогон `7983769` + demo-cn-fixed
  profile, где `propname` совпадают с китайскими свойствами модели.

Локальные артефакты корректировки:

```text
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0927.xlsx
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0927-analysis.json
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0928.xlsx
D:\ztool-pr8-test\manual-artifacts\0614-A00-20260613-0928-analysis.json
```

## Проверка commit `c633622`: 8 русских режимов и FilterRulesList

Цель: проверить новый `ZTool.settings` с 8 режимами экспорта и правилами
фильтрации.

Подготовка:

```text
repo branch: devin/1781201882-bom-templates
repo commit: c633622
runtime: D:\ztool-pr8-test
copied: D:\Development\ztool\github-pr8-bom-templates\ZTool.settings -> D:\ztool-pr8-test\ZTool.settings
ZTool.settings after path rewrite: A1E3F3826B278A54C95FA17D0C74687627B660608A27D39FA85FAD8F96909A58
ZTool.exe: D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
```

Pre-flight:

```text
RESULT: PASS - settings/template are consistent for export.
Presets: 8 mode(s)
FilterRulesList: 5 rule(s) defined
RulesList -> FilterRulesList references: OK
```

Проверенные режимы в меню `Экспорт спецификации` после перезапуска ZTool:

1. `Экспорт сводной спецификации`
2. `Экспорт иерархической спецификации`
3. `Экспорт спецификации верхнего уровня`
4. `Экспорт сводной спецификации деталей`
5. `Экспорт сводной спецификации (с эскизами)`
6. `Экспорт иерархической спецификации (с эскизами)`
7. `Обрабатываемые детали`
8. `Покупные изделия`

Итог: состав меню и целостность фильтр-правил по commit `c633622` — **PASS**.
Функциональный прогон фильтр-режимов требует моделей с реальными значениями
свойства `Тип`, потому что текущие значения фильтров являются заглушками.

Локальный артефакт:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-c633622-export-menu.png
```

## Боевой прогон commit `ca1e8b3` от 2026-06-13

Цель: выполнить не "пустой" тест, а полный live-прогон: открыть сборку в
SolidWorks, заполнить свойства модели, сохранить файлы, прочитать сборку в
ZTool и экспортировать все 8 режимов.

Подготовка:

```text
repo branch: devin/1781201882-bom-templates
repo commit: ca1e8b3
runtime: D:\ztool-pr8-test
ZTool.exe: D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
ZTool.dll: EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
model: D:\ztool-pr8-test\TestModel\0614-A00.SLDASM
```

Действия перед экспортом:

- через SolidWorks COM открыт `0614-A00.SLDASM`;
- создан бэкап модели:
  `D:\ztool-pr8-test\TestModel.before-russian-props-20260613-135450`;
- в файлы сборки/деталей записаны русские custom properties и файлы
  сохранены через SolidWorks:
  `Разработал`, `Имя детали`, `Номер чертежа`, `Материал`, `Тип`, `Версия`,
  `Обработка поверхности`, `Дата разработки`, `Масса`;
- отчёт записи свойств:
  `D:\ztool-pr8-test\manual-artifacts\russian-properties-write-report.json`;
- после `Подключить SW` таблица ZTool заполнена 29 строками, включая
  `Имя детали`, `Номер чертежа`, `Материал`, `Тип`, `Версия`,
  `Обработка поверхности`, `Дата разработки`, `Масса`, `Количество`, `Путь`;
- скрин таблицы:
  `D:\ztool-pr8-test\manual-artifacts\ztool-after-reread-russian-props.png`.

Файлы полного прогона:

```text
D:\ztool-pr8-test\bom-exports\full-test
```

| # | Режим меню | Файл | Строки | № | Кол-во | Путь | Эскизы | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | ---: | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-20260613-1424.xlsx` | 29 | 29 | 29 | 29 | 0 | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-20260613-1435.xlsx` | 32 | 32 | 32 | 32 | 0 | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-20260613-1446.xlsx` | 6 | 6 | 6 | 6 | 0 | PASS |
| 4 | Экспорт сводной спецификации деталей | `04_parts_summary_0614-A00-20260613-1446.xlsx` | 25 | 25 | 25 | 25 | 0 | PASS |
| 5 | Экспорт сводной спецификации (с эскизами) | `05_summary_sketches_0614-A00-20260613-1447.xlsx` | 29 | 29 | 29 | 29 | 29 | PASS |
| 6 | Экспорт иерархической спецификации (с эскизами) | `06_hierarchy_sketches_0614-A00-20260613-1447.xlsx` | 32 | 32 | 32 | 32 | 32 | PASS |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-20260613-1448.xlsx` | 29 | 29 | 29 | 29 | 0 | FAIL: фильтр не применён |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-20260613-1448.xlsx` | 29 | 29 | 29 | 29 | 0 | FAIL: фильтр не применён |

Проверка содержимого через `openpyxl`:

```text
01 summary: rows=29, A=29, G=29, O=29, C=29
02 hierarchy: rows=32, A=32, G=32, O=32, C=32
03 top_level: rows=6, A=6, G=6, O=6, C=6
04 parts_summary: rows=25, A=25, G=25, O=25, C=25
05 summary_sketches: rows=29, A=29, G=29, O=29, C=29, images=29
06 hierarchy_sketches: rows=32, A=32, G=32, O=32, C=32, images=32
07 processed_filter: rows=29, A=29, G=29, O=29, C=29
08 purchased_filter: rows=29, A=29, G=29, O=29, C=29
```

Примеры данных из итогового Excel:

```text
C7 = 夹爪平台, D7 = 0614-A00, E7 = A, G7 = 1, H7 = 组件, J7 = 0.9898
C13 = 连杆, D13 = 0614-P003, G13 = 3, H13 = 机加, N13 = SUS304
C21 = 支架, D21 = 0614-P001, G21 = 1, H21 = 机加, I21 = 本色阳极, J21 = 0.1619, N21 = 6061
```

Отдельное замечание по `validate_bom_exports.py`: текущий валидатор показывает
`FAIL`, потому что считает форматированные пустые строки до `ws.max_row`
(`98/101/...` строк), а не фактические строки данных. Ручная проверка по
заполненным ключевым ячейкам показывает корректные строки. Это дефект
тестового валидатора, не самого экспорта.

Диагностика фильтров:

- исходные режимы `Обрабатываемые детали` и `Покупные изделия` выдали полный
  сводный список 29 строк;
- временно в runtime были подставлены точные значения demo-модели:
  `Обрабатываемые детали -> Тип contains 机加`,
  `Покупные изделия -> Тип contains 外购`;
- результат не изменился: оба файла снова содержали 29 строк со всеми типами:
  `机加 = 15`, `外购 = 9`, `组件 = 5`;
- дополнительный runtime-эксперимент с переключением флагов
  `ByRuler=false / ByFilter=true` также не изменил результат.

Вывод по фильтрам: в commit `ca1e8b3` пункты меню 7/8 создают Excel, но
правила `RulesList -> FilterRulesList` фактически не применяются при экспорте.
Это отдельный дефект PR #8.

Итог по боевому прогону:

- чтение SolidWorks после сохранённых свойств: **PASS**;
- экспорт режимов 1-6: **PASS**;
- эскизы в режимах 5-6: **PASS**;
- фильтрованные режимы 7-8: **FAIL**, экспортируют полный список вместо
  отфильтрованного;
- валидатор `validate_bom_exports.py`: **ложный FAIL**, требует исправления
  логики подсчёта строк данных.

## Перепроверка фильтров commit `fc7d801` от 2026-06-13

Цель: проверить фикс правил `FilterRulesList` для режимов 7-8.

Подготовка:

```text
repo branch: devin/1781201882-bom-templates
repo commit: fc7d801
runtime: D:\ztool-pr8-test
ZTool.exe: D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
ZTool.dll: EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
ZTool.settings after path rewrite: FCBE356C6E7B594B9CCA797B8936C88F32D638523BD00C6A7AD9A3C7171790AF
```

Проверка формата правил в runtime `ZTool.settings`:

```text
Обрабатываемые детали:
  $Тип$ <TAB>|@#$%| Содержит <TAB>|@#$%| 机加;Мех.обработка;Листовая;Литьё;Сварка

Покупные изделия:
  $Тип$ <TAB>|@#$%| Содержит <TAB>|@#$%| 外购;Покупное;Стандартное
```

Pre-flight:

```text
RESULT: PASS - settings/template are consistent for export.
[1c] Rule-string format (separator + operator): all rules OK
```

Live-прогон:

- SolidWorks оставлен открытым на `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`;
- ZTool перезапущен после замены `ZTool.settings`;
- `Подключить SW` прошёл успешно;
- экспортированы только режимы 7 и 8.

Файлы:

```text
D:\ztool-pr8-test\bom-exports\filter-retest-fc7d801
```

| # | Режим меню | Файл | Строки | Типы | Итог |
| --- | --- | --- | ---: | --- | --- |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-20260613-1545.xlsx` | 15 | `机加: 15` | PASS |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-20260613-1545.xlsx` | 9 | `外购: 9` | PASS |

Проверка через обновлённый `validate_bom_exports.py`:

```text
[PASS] 07_processed_filter_0614-A00-20260613-1545.xlsx
  Строк данных: 15
  № п/п: 15/15 | Кол-во: 15/15 | Путь: 15/15

[PASS] 08_purchased_filter_0614-A00-20260613-1545.xlsx
  Строк данных: 9
  № п/п: 9/9 | Кол-во: 9/9 | Путь: 9/9

ИТОГ: PASS
```

Примеры строк:

```text
mode 7:
  0614-P003, qty=3, Тип=机加
  0614-P004, qty=1, Тип=机加
  0614-P015, qty=1, Тип=机加

mode 8:
  DBTS3-12-4, qty=6, Тип=外购
  WSSS8-3-1, qty=6, Тип=外购
  HNT1-SUS-M4, qty=12, Тип=外购
```

Итог по `fc7d801`: дефект режимов 7-8 закрыт. Фильтры реально применяются
при BOM export, полный список 29 строк больше не выгружается.

## Перепроверка форматирования шаблона commit `dca7a84` от 2026-06-13

Цель: убедиться, что ZTool использует новый `bom_шаблон.xlsx`, а не старый
шаблон с `宋体`, распределённым выравниванием и областью печати `A1:K40`.

Подготовка:

```text
repo branch: devin/1781201882-bom-templates
repo commit: dca7a84
runtime: D:\ztool-pr8-test
template SHA256: EE07E50D72A20E476A04AAA8BC8D7D95BBAFD97BF6081CA66BDE11A89BE31BCC
```

Проверка runtime-шаблона после замены:

```text
sheet: Спецификация
A1.font = Arial
G7.font = Arial
print_area = 'Спецификация'!$A$1:$O$75
orientation = landscape
fitToWidth = 1
fitToHeight = 0
repeat_rows = $1:$6
```

До замены в `D:\ztool-pr8-test\Шаблоны спецификации\bom_шаблон.xlsx`
действительно лежал старый шаблон:

```text
sheet: 图纸明细1
G7.font = 宋体
print_area = '图纸明细1'!$A$1:$K$40
orientation = portrait
```

Live-прогон:

- SolidWorks открыт на `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`;
- ZTool перезапущен после замены шаблона;
- `Подключить SW` прошёл успешно;
- экспортирован режим `Экспорт сводной спецификации`.

Файл результата:

```text
D:\ztool-pr8-test\bom-exports\format-retest-dca7a84\01_summary_format_0614-A00-20260613-1641.xlsx
```

Проверка результата через `openpyxl`:

```text
sheet: Спецификация
data rows: 29 (A7:O35)
A7:O35 fonts: Arial = 435, 宋体 = 0
A7 = 1, font Arial
G7 = 1, font Arial
O7 = D:\ztool-pr8-test\TestModel\0614-A00.SLDASM, font Arial
print_area = 'Спецификация'!$A$1:$O$104
orientation = landscape
fitToWidth = 1
fitToHeight = 0
repeat_rows = $1:$6
```

Обновлённый валидатор:

```text
[PASS] 01_summary_format_0614-A00-20260613-1641.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29
ИТОГ: PASS
```

Итог по форматированию экспортированных данных: **PASS**.

Остаточное замечание: `openpyxl` всё ещё видит `宋体` в пустых незначимых
ячейках шаблона/выходного файла, например `B1:K3` и часть пустых ячеек
`72:75`. В зоне данных `A7:O35` и в ключевых заголовках `A1/A6/C6/G6`
`宋体` отсутствует. Это не влияет на текущий экспорт, но противоречит
утверждению "宋体 вычищен из всех ячеек"; при строгом требовании нулевого
остатка нужно дополнительно очистить стили пустых merged/нижних ячеек.

## Перепроверка полного вычищения CJK-шрифтов commit `82fe830` от 2026-06-13

Цель: проверить утверждение, что остаточный `宋体` удалён из шаблона полностью,
включая "теневые" merged-ячейки и `styles.xml`.

Подготовка:

```text
repo branch: devin/1781201882-bom-templates
repo commit: 82fe830
runtime: D:\ztool-pr8-test
runtime template: D:\ztool-pr8-test\Шаблоны спецификации\bom_шаблон.xlsx
template SHA256: 30D12D5E9C05CC06AE09099CA992AD0ABC8A7B3AACC099674F53E2E06F2858F9
ZTool.exe SHA256: D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
ZTool.dll SHA256: EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
```

Проверка шаблона без SolidWorks:

```text
raw styles.xml CJK font names: 0
raw styles.xml charset="134": 0
raw font names: Arial, Times New Roman
per-cell fonts: Arial = 1425
per-cell CJK font cells: 0
sheet: Спецификация
merged ranges: 14
defined names: 16
print_area = 'Спецификация'!$A$1:$O$75
orientation = landscape
fitToWidth = 1
fitToHeight = 0
repeat_rows = $1:$6
key cells B1/K3/C72/K75: Arial
pre-flight: PASS
```

Артефакт проверки:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-82fe830-template-font-analysis.json
```

Итог по самому шаблону: **PASS**. Остаточного `宋体`/CJK charset в шаблоне
не найдено.

Live-проверка через SolidWorks:

- SolidWorks запущен через `C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk`;
- открыта реальная тестовая сборка
  `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`;
- `OpenDoc6` вернул `True`, `errors=0`, `warnings=0`;
- активный документ в COM: `0614-A00.SLDASM`, тип `2` (assembly);
- `LoadAddIn(D:\ztool-pr8-test\ZTool.dll)` вернул `0`;
- `GetAddInObject('ZTool.SwAddin') = True`;
- запущенный процесс `ZTool.exe` идёт из `D:\ztool-pr8-test`.

При нажатии `Подключить SW` на чистой связке появляется ошибка в процессе
SolidWorks:

```text
Платформа Microsoft .NET Framework
Необрабатываемое исключение в компоненте приложения.
Ссылка на объект не указывает на экземпляр объекта.

System.NullReferenceException: Ссылка на объект не указывает на экземпляр объекта.
   в ZTool.PMPHandler.DefWndProc(Message& m)
   в System.Windows.Forms.Control.WndProc(Message& m)
   в System.Windows.Forms.Form.WndProc(Message& m)
   в System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, ...
```

После нажатия `Продолжить`/`ОК` таблица ZTool остаётся пустой:

```text
rows in ZTool table: 0
```

Скрин ошибки:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-82fe830-connect-nullref.png
```

Отдельная проверка автозагрузки add-in:

- `HKLM\SOFTWARE\SolidWorks\Addins\{59959dfa-3229-4b86-852e-52abf2bdb8c0}`
  содержит `(Default)=1`;
- `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959dfa-3229-4b86-852e-52abf2bdb8c0}`
  содержит `(Default)=1`;
- но ключ
  `HKLM\SOFTWARE\SolidWorks\SOLIDWORKS 2025\Addins\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}`
  с `(Default)=1` воспроизводит стартовую ошибку SolidWorks
  `Не удалось загрузить Microsoft .NET Framework`; значение возвращено в `0`.

Итог live-проверки `82fe830`: **BLOCKED/FAIL до экспорта**.
Шаблон действительно очищен, но новый live-export `.xlsx` на этом коммите
не удалось получить: чтение из SolidWorks падает в `ZTool.PMPHandler.DefWndProc`
до заполнения таблицы. Это отдельный блокер подключения/IPC, не проверка
форматирования Excel.

### Повторная live-проверка `82fe830` после чистого запуска SolidWorks

Повторный прогон показал, что предыдущий `NullReferenceException` был связан
с загрязнённой сессией/автозагрузочными следами ZTool в SolidWorks, а не с
шаблоном.

Что изменено в окружении перед повтором:

- SolidWorks запущен через Explorer/ShellExecute по ярлыку
  `C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk`; запуск через `cmd start`
  воспроизводил стартовый диалог `Не удалось загрузить Microsoft .NET Framework`;
- временно отключён автозапуск ZTool:
  `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959dfa-3229-4b86-852e-52abf2bdb8c0}=0`,
  `HKCU\SOFTWARE\SolidWorks\SOLIDWORKS 2025\AddInsStartup\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}=0`;
- временно отключён общий SolidWorks add-in key:
  `HKLM\SOFTWARE\SolidWorks\Addins\{59959dfa-3229-4b86-852e-52abf2bdb8c0}=0`;
- удалены stale UI-следы ZTool в `HKCU\...\User Interface\CommandManager` и
  `Custom API Toolbars/Flyouts`; backup сделан в
  `D:\ztool-pr8-test\manual-artifacts\registry-backups\20260613-202348-*.reg`.

После этого:

```text
SolidWorks: старт без .NET-диалога
OpenDoc6(D:\ztool-pr8-test\TestModel\0614-A00.SLDASM): True, errors=0, warnings=0
LoadAddIn(D:\ztool-pr8-test\ZTool.dll): 0
GetAddInObject('ZTool.SwAddin'): True
ZTool.exe: D:\ztool-pr8-test\ZTool.exe
Подключить SW: Подключение завершено, затрачено 0,3 сек, всего 29 поз.
```

Скрин после успешного подключения:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-82fe830-retry-after-connect.png
```

Экспортирован режим `Экспорт сводной спецификации`.

Файл результата:

```text
D:\ztool-pr8-test\bom-exports\format-retest-82fe830-retry\01_summary_82fe830_retry_0614-A00-20260613-2027.xlsx
```

Проверка результата:

```text
sheet: Спецификация
data rows: 29 (A7:O35)
№ п/п: 29/29
Кол-во: 29/29
Путь: 29/29
raw styles.xml CJK font names: 0
raw styles.xml charset="134": 0
per-cell fonts: Arial = 1976
per-cell CJK font cells: 0
print_area = 'Спецификация'!$A$1:$O$104
orientation = landscape
fitToWidth = 1
fitToHeight = 0
repeat_rows = $1:$6
sample: A7=1, C7=夹爪平台, D7=0614-A00, G7=1, O7=D:\ztool-pr8-test\TestModel\0614-A00.SLDASM
```

Артефакт анализа:

```text
D:\ztool-pr8-test\manual-artifacts\ztool-82fe830-retry-export-analysis.json
```

Валидатор:

```text
[PASS] 01_summary_82fe830_retry_0614-A00-20260613-2027.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29
ИТОГ: PASS
```

Итог повторной проверки `82fe830`: **PASS**.
Шаблон после полного purge CJK-шрифтов работает в live-export. Остаточный
риск относится к запуску/регистрации add-in: автозагрузочные ключи и stale
CommandManager UI-следы могут снова вызвать стартовый `.NET Framework` диалог
или `NullReferenceException` при `Подключить SW`.

### Полный live-прогон всех 8 режимов `82fe830` по методике

После успешного чистого запуска SolidWorks и подтверждения одиночного экспорта
выполнен полный прогон всех режимов из меню `Спецификация -> Экспорт
спецификации`.

Runtime:

```text
repo branch: devin/1781201882-bom-templates
template commit under test: 82fe830
runtime folder: D:\ztool-pr8-test
model: D:\ztool-pr8-test\TestModel\0614-A00.SLDASM
export folder: D:\ztool-pr8-test\bom-exports\full-test-82fe830-final
```

Проверенные runtime-хеши:

```text
ZTool.exe      D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
ZTool.dll      EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
ZTool.settings CA5729BAF69DDBEF3D73B479E3DBD0586E5395BC52484EC208A6E3BB67DE4A8A
bom_шаблон.xlsx 30D12D5E9C05CC06AE09099CA992AD0ABC8A7B3AACC099674F53E2E06F2858F9
```

Примечание: `ZTool.settings` в runtime нормализован под локальный путь
`D:\ztool-pr8-test`, поэтому его хеш отличается от чистого файла в репо.

Pre-flight:

```text
check_bom_template.py D:\ztool-pr8-test\ZTool.settings
RESULT: PASS - settings/template are consistent for export.
Col_Number / Col_Quantity / Col_Path / Col_Preview: anchor OK
Col_FileName: DEFERRED - не проверялся, переименование отложено отдельно
```

Подключение SolidWorks:

```text
SolidWorks: SOLIDWORKS Premium 2025 SP3.0 - [0614-A00.SLDASM]
ZTool: D:\ztool-pr8-test\ZTool.exe
Подключить SW: Подключение завершено, затрачено 0,3 сек, всего 29 поз.
```

Результат по 8 режимам:

| # | Режим | Файл | Строк | № п/п | Кол-во | Путь | Эскизы | Типы | CJK/charset134 | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | ---: | --- | --- | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-20260613-2204.xlsx` | 29 | 29/29 | 29/29 | 29/29 | 0 | `组件:5, 外购:9, 机加:15` | 0/0 | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-20260613-2231.xlsx` | 32 | 32/32 | 32/32 | 32/32 | 0 | `组件:5, 外购:12, 机加:15` | 0/0 | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-20260613-2224.xlsx` | 6 | 6/6 | 6/6 | 6/6 | 0 | `组件:5, 机加:1` | 0/0 | PASS |
| 4 | Экспорт сводной спецификации деталей | `04_parts_only_0614-A00-20260613-2222.xlsx` | 25 | 25/25 | 25/25 | 25/25 | 0 | `组件:1, 外购:9, 机加:15` | 0/0 | PASS |
| 5 | Экспорт сводной спецификации (с эскизами) | `05_summary_images_0614-A00-20260613-2224.xlsx` | 29 | 29/29 | 29/29 | 29/29 | 29 | `组件:5, 外购:9, 机加:15` | 0/0 | PASS |
| 6 | Экспорт иерархической спецификации (с эскизами) | `06_hierarchy_images_0614-A00-20260613-2226.xlsx` | 32 | 32/32 | 32/32 | 32/32 | 32 | `组件:5, 外购:12, 机加:15` | 0/0 | PASS |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-20260613-2226.xlsx` | 15 | 15/15 | 15/15 | 15/15 | 0 | `机加:15` | 0/0 | PASS |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-20260613-2227.xlsx` | 9 | 9/9 | 9/9 | 9/9 | 0 | `外购:9` | 0/0 | PASS |

Валидатор:

```text
Найдено файлов: 8
Ожидаемо: 8 (по одному на режим)

[PASS] 01_summary_0614-A00-20260613-2204.xlsx -> Режим 1
[PASS] 02_hierarchy_0614-A00-20260613-2231.xlsx -> Режим 2
[PASS] 03_top_level_0614-A00-20260613-2224.xlsx -> Режим 3
[PASS] 04_parts_only_0614-A00-20260613-2222.xlsx -> Режим 4
[PASS] 05_summary_images_0614-A00-20260613-2224.xlsx -> Режим 5
[PASS] 06_hierarchy_images_0614-A00-20260613-2226.xlsx -> Режим 6
[PASS] 07_processed_filter_0614-A00-20260613-2226.xlsx -> Режим 7
[PASS] 08_purchased_filter_0614-A00-20260613-2227.xlsx -> Режим 8

ПРОВЕРКА СОГЛАСОВАННОСТИ РЕЖИМОВ:
  - Режим 7 (Обрабатываемые детали): 15 из 29 строк - фильтр применён.
  - Режим 8 (Покупные изделия): 9 из 29 строк - фильтр применён.

ИТОГ: PASS - все файлы содержат данные в служебных колонках
```

Итог полного live-прогона `82fe830`: **PASS, 8/8 режимов**.
Проверены реальные `.xlsx`, созданные из открытой сборки SolidWorks:
служебные колонки `№ п/п`, `Кол-во`, `Путь` заполнены во всех режимах,
эскизы записаны в режимах 5-6, фильтры 7-8 применяются, остаточных
CJK-шрифтов/`charset="134"` в выходных файлах нет.

Остаточный риск не относится к BOM-экспорту: запуск SolidWorks через некоторые
shell-команды воспроизводил диалог `Не удалось загрузить Microsoft .NET
Framework`; рабочий запуск для теста был через Explorer/ShellExecute по ярлыку
`C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk`.

### Ретест защитного `PMPHandler.DefWndProc` guard commit `b193ee4`

Проверен новый кандидат DLL:

```text
repo commit: b193ee4
runtime DLL: D:\ztool-pr8-test\ZTool.dll
source DLL: dumps\candidate-ru-20260609\ZTool_ru_candidate2_pmpguard.dll
SHA256: 7CA18A535871D8C9F10C6C9BDDE8BD931F8BE2118B7B6590D12DEB8313036FD0
backup: D:\ztool-pr8-test\ZTool.dll.bak-before-pmpguard-20260613-225012
RegAsm: Types registered successfully
```

Проверка воспроизводимого патчера:

```text
D:\Development\ztool\.dotnet\dotnet.exe run --project client-core\tools\PmpGuardPatch\PmpGuardPatch.csproj -- verify ...
```

Результат: **FAIL воспроизводимости инструмента**. `PmpGuardPatch.csproj`
ссылается на локальный путь автора:

```text
C:\Users\Administrator\.dotnet\tools\.store\ilspycmd\8.2.0.7535\...\Mono.Cecil.dll
```

В чистом тестовом окружении `Mono.Cecil.dll` по этому пути отсутствует, сборка
падает с `CS0246: The type or namespace name "Mono" could not be found`.
Сам live-тест DLL продолжен, но `PmpGuardPatch verify` локально не
воспроизводится.

SolidWorks/add-in:

```text
SolidWorks launch: через Explorer/ShellExecute по C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk
OpenDoc6(D:\ztool-pr8-test\TestModel\0614-A00.SLDASM): True, errors=0
LoadAddIn(D:\ztool-pr8-test\ZTool.dll): 0 после Unload/Load
GetAddInObject('ZTool.SwAddin'): True
ActiveDoc: 0614-A00.SLDASM
```

Целевой init-race/`Подключить SW` тест:

1. Первый ранний клик `Подключить SW` не уронил процесс SolidWorks и не показал
   полный .NET stack trace, но показал пользовательский диалог ZTool/SW:

```text
Ошибка
Ссылка на объект не указывает на экземпляр объекта.
```

2. После чистого `UnloadAddIn`/`LoadAddIn` и повторного запуска `ZTool.exe`
   чтение прошло:

```text
Подключение завершено, затрачено 0,3 сек, всего 29 поз.
```

   Но одновременно снова появился модальный диалог процесса `SLDWORKS`:

```text
Ошибка
Ссылка на объект не указывает на экземпляр объекта.
```

3. Во время последующего экспорта этот же SW-owned диалог приходилось закрывать
   перед следующими режимами. То есть guard не устранил user-visible
   `NullReference` полностью: данные читаются и экспортируются, но ошибка
   остаётся видимой пользователю.

BOM regression test на pmpguard DLL:

```text
export folder: D:\ztool-pr8-test\bom-exports\full-test-b193ee4-pmpguard
validate_bom_exports.py: PASS
```

| # | Режим | Файл | Строк | № п/п | Кол-во | Путь | Эскизы | Типы | CJK/charset134 | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | ---: | --- | --- | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-20260613-2303.xlsx` | 29 | 29/29 | 29/29 | 29/29 | 0 | `组件:5, 外购:9, 机加:15` | 0/0 | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-20260613-2304.xlsx` | 32 | 32/32 | 32/32 | 32/32 | 0 | `组件:5, 外购:12, 机加:15` | 0/0 | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-20260613-2304.xlsx` | 6 | 6/6 | 6/6 | 6/6 | 0 | `组件:5, 机加:1` | 0/0 | PASS |
| 4 | Экспорт сводной спецификации деталей | `04_parts_only_0614-A00-20260613-2306.xlsx` | 25 | 25/25 | 25/25 | 25/25 | 0 | `组件:1, 外购:9, 机加:15` | 0/0 | PASS |
| 5 | Экспорт сводной спецификации (с эскизами) | `05_summary_images_0614-A00-20260613-2307.xlsx` | 29 | 29/29 | 29/29 | 29/29 | 29 | `组件:5, 外购:9, 机加:15` | 0/0 | PASS |
| 6 | Экспорт иерархической спецификации (с эскизами) | `06_hierarchy_images_0614-A00-20260613-2308.xlsx` | 32 | 32/32 | 32/32 | 32/32 | 32 | `组件:5, 外购:12, 机加:15` | 0/0 | PASS |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-20260613-2310.xlsx` | 15 | 15/15 | 15/15 | 15/15 | 0 | `机加:15` | 0/0 | PASS |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-20260613-2311.xlsx` | 9 | 9/9 | 9/9 | 9/9 | 0 | `外购:9` | 0/0 | PASS |

Итог `b193ee4`:

- BOM/export regression: **PASS, 8/8**.
- Add-in load: **PASS** после `UnloadAddIn`/`LoadAddIn`.
- Целевой guard-дефект: **FAIL/PARTIAL**. Полного падения процесса нет, но
  пользователь всё равно видит `Ошибка: Ссылка на объект не указывает на
  экземпляр объекта.` из процесса SolidWorks.
- `PmpGuardPatch verify`: **FAIL воспроизводимости** из-за hardcoded
  `Mono.Cecil.dll` path.

После ретеста тестовый runtime откатан на предыдущую стабильную DLL:

```text
D:\ztool-pr8-test\ZTool.dll
SHA256: EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
RegAsm: Types registered successfully
```

### Ретест `pmpguard2` / NullReference modal suppression commit `550216f`

Проверен следующий кандидат:

```text
repo commit: 550216f
runtime DLL during test: D:\ztool-pr8-test\ZTool.dll
source DLL: dumps\candidate-ru-20260609\ZTool_ru_candidate2_pmpguard2.dll
SHA256: D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9
backup: D:\ztool-pr8-test\ZTool.dll.bak-before-pmpguard2-20260613-233953
RegAsm: Types registered successfully
```

Проверка патчеров:

```text
D:\Development\ztool\.dotnet\dotnet.exe run --project client-core\tools\PmpGuardPatch\PmpGuardPatch.csproj -- dumps\candidate-ru-20260609\ZTool_ru_candidate2_pmpguard2.dll verify
VERIFY: PASS

D:\Development\ztool\.dotnet\dotnet.exe run --project client-core\tools\NullModalGuard\NullModalGuard.csproj -- dumps\candidate-ru-20260609\ZTool_ru_candidate2_pmpguard2.dll verify
sites=5 guarded=5
VERIFY: PASS
```

Ранее найденный дефект воспроизводимости `PmpGuardPatch` исправлен:
`PmpGuardPatch.csproj` теперь использует `PackageReference Mono.Cecil
0.11.5`, hardcoded `C:\Users\Administrator\...` path удалён. Важно по CLI:
оба инструмента ожидают DLL первым аргументом, режим `verify` вторым.

Live-сценарий 1: add-in загружен до открытия модели, затем открыт
`0614-A00.SLDASM`:

```text
LoadAddIn before OpenDoc: 2
OpenDoc6: True, errors=0, warnings=0
GetAddInObject('ZTool.SwAddin'): True
ActiveDoc: 0614-A00.SLDASM
```

Ранний и повторный `Подключить SW`:

```text
FIRST:  Подключение завершено, затрачено 0,1 сек, всего 0 поз.
SECOND: Подключение завершено, затрачено 0,0 сек, всего 0 поз.
modal dialogs: none
table rows/sample: 0
```

Live-сценарий 2: полностью свежий старт SolidWorks, сначала открыта модель,
затем загружен add-in:

```text
OpenDoc6: True, errors=0, warnings=0
LoadAddIn after OpenDoc: 2
GetAddInObject('ZTool.SwAddin'): True
ActiveDoc: 0614-A00.SLDASM
```

Повторная проверка `Подключить SW`:

```text
CLEAN_1: Подключение завершено, затрачено 0,1 сек, всего 0 поз.
CLEAN_2: Подключение завершено, затрачено 0,0 сек, всего 0 поз.
modal dialogs: none
table rows/sample: 0
```

Live-сценарий 3: явный `UnloadAddIn`/`LoadAddIn` при активной модели:

```text
UnloadAddIn: 0
LoadAddIn: 0
GetAddInObject('ZTool.SwAddin'): True
ActiveDoc: 0614-A00.SLDASM

RELOAD_CONTROL: Подключение завершено, затрачено 0,1 сек, всего 0 поз.
modal dialogs: none
table rows/sample: 0
```

Итог `550216f`:

- `NullReference` модалка действительно подавлена: **PASS**.
- Но чтение из SW регрессировало: **FAIL**, во всех проверенных порядках
  загрузки результат `0 поз.` вместо ожидаемых `29 поз.`.
- BOM regression 8 режимов на `pmpguard2` не подтверждался, потому что
  блокер возникает раньше: таблица ZTool пустая после `Подключить SW`.

После ретеста runtime откатан на предыдущую стабильную DLL:

```text
D:\ztool-pr8-test\ZTool.dll
SHA256: EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961
RegAsm: Types registered successfully
```

### Повторный корректный ретест `pmpguard2`: запуск ZTool через SolidWorks add-in

Предыдущий ретест `pmpguard2` запускал `D:\ztool-pr8-test\ZTool.exe`
напрямую. Это оказалось некорректным способом для приёмки: при запуске через
ленту SolidWorks add-in инициализирует связку иначе, и чтение работает.

Runtime снова переведён на `pmpguard2`:

```text
D:\ztool-pr8-test\ZTool.dll
SHA256: D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9
RegAsm: Types registered successfully
```

Процесс ZTool запущен именно кнопкой `Управление файлами` на ленте SolidWorks:

```text
Get-Process ZTool:
Path: D:\ztool-pr8-test\ZTool.exe
SHA256: D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833
```

Проверка `Подключить SW`:

```text
FIRST:  Подключение завершено, затрачено 0,2 сек, всего 29 поз.
SECOND: Подключение завершено, затрачено 0,2 сек, всего 29 поз.
modal dialogs: none
```

То есть целевой сценарий `pmpguard2` теперь проходит: модалка
`Ссылка на объект не указывает на экземпляр объекта.` не появляется, чтение
возвращает ожидаемые `29 поз.`.

BOM regression test:

```text
export folder: D:\ztool-pr8-test\bom-exports\full-test-550216f-pmpguard2-swlaunch
validate_bom_exports.py: PASS
```

| # | Режим | Файл | Строк | № п/п | Кол-во | Путь | Эскизы | Типы | CJK/charset134 | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | ---: | --- | --- | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-20260614-0004.xlsx` | 29 | 29/29 | 29/29 | 29/29 | 0 | `组件:5, 外购:9, 机加:15` | 0/0 | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-20260614-0013.xlsx` | 32 | 32/32 | 32/32 | 32/32 | 0 | `组件:5, 外购:12, 机加:15` | 0/0 | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-20260614-0015.xlsx` | 6 | 6/6 | 6/6 | 6/6 | 0 | `组件:5, 机加:1` | 0/0 | PASS |
| 4 | Экспорт сводной спецификации деталей | `04_parts_only_0614-A00-20260614-0016.xlsx` | 25 | 25/25 | 25/25 | 25/25 | 0 | `组件:1, 外购:9, 机加:15` | 0/0 | PASS |
| 5 | Экспорт сводной спецификации (с эскизами) | `05_summary_images_0614-A00-20260614-0017.xlsx` | 29 | 29/29 | 29/29 | 29/29 | 29 | `组件:5, 外购:9, 机加:15` | 0/0 | PASS |
| 6 | Экспорт иерархической спецификации (с эскизами) | `06_hierarchy_images_0614-A00-20260614-0018.xlsx` | 32 | 32/32 | 32/32 | 32/32 | 32 | `组件:5, 外购:12, 机加:15` | 0/0 | PASS |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-20260614-0020.xlsx` | 15 | 15/15 | 15/15 | 15/15 | 0 | `机加:15` | 0/0 | PASS |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-20260614-0021.xlsx` | 9 | 9/9 | 9/9 | 9/9 | 0 | `外购:9` | 0/0 | PASS |

Валидатор:

```text
Найдено файлов: 8
Ожидаемо: 8 (по одному на режим)
...
ИТОГ: PASS - все файлы содержат данные в служебных колонках
```

Итог корректного ретеста `550216f` через запуск из SolidWorks:

- Add-in / pmpguard2 DLL: **PASS**.
- `Подключить SW`: **PASS**, `29 поз.`, модалок нет.
- BOM/export regression: **PASS, 8/8**.
- Важное условие методики: ZTool нужно запускать через кнопку add-in в
  SolidWorks (`Управление файлами`), а не прямым стартом `ZTool.exe`.

### Ретест `350c8c5` / `ZTool_binderfix.exe`

Проверен новый exe с version-tolerant `SerializationBinder`:

```text
repo commit: 350c8c5
runtime EXE: D:\ztool-pr8-test\ZTool.exe
source EXE: client-core\dist\ZTool_binderfix.exe
SHA256: D5CAC49DC0A6A8D918DA63D310DB1A21E80572E6FAE4219D6F37ABB26F5614DB

runtime DLL: D:\ztool-pr8-test\ZTool.dll
SHA256: D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9
```

Проверка инъекции:

```text
BinderInject verify: PASS
ZTool.VTBinder present
ZTool.code::DeserializeBinary binder-wire sites=1
ZTool.code::DeserializeObject binder-wire sites=1
```

Важная поправка к методике запуска: первая попытка была некорректной
(`Start-Process` по `.lnk` + ранний COM/`LoadAddIn` во время splash). Она
воспроизвела стартовую модалку SolidWorks:

```text
Не удалось загрузить Microsoft .NET Framework.
```

и завершилась падением `SLDWORKS.exe`:

```text
Application Error, SLDWORKS.exe, ntdll.dll, exception 0xc0000374
```

Дальнейший ретест выполнен корректно: запуск SolidWorks через
`explorer.exe "C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk"`, ожидание полного
окна SolidWorks, открыта сборка `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`,
ZTool запущен именно кнопкой `Управление файлами` на ленте SolidWorks.

Подключение к SW:

```text
Get-Process ZTool:
Path: D:\ztool-pr8-test\ZTool.exe
SHA256: D5CAC49DC0A6A8D918DA63D310DB1A21E80572E6FAE4219D6F37ABB26F5614DB

Подключить SW:
Подключение завершено, затрачено 0,3 сек, всего 29 поз.
```

BOM export:

```text
export folder:
D:\ztool-pr8-test\bom-exports\full-test-350c8c5-binderfix-swlaunch
```

Результат до блокера:

| # | Режим | Файл | Строк | № п/п | Кол-во | Путь | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-binderfix.xlsx` | 29 | 29/29 | 29/29 | 29/29 | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-binderfix.xlsx` | 32 | 32/32 | 32/32 | 32/32 | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-binderfix.xlsx` | 6 | 6/6 | 6/6 | 6/6 | PASS |
| 4 | Экспорт сводной спецификации деталей | файл не создан | - | - | - | - | **FAIL: crash** |

Валидатор для созданных 3 файлов:

```text
Найдено файлов: 3
Ожидаемо: 8 (по одному на режим)
ВНИМАНИЕ: файлов меньше 8. Валидирую то, что есть.

[PASS] 01_summary_0614-A00-binderfix.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29

[PASS] 02_hierarchy_0614-A00-binderfix.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32

[PASS] 03_top_level_0614-A00-binderfix.xlsx
  Строк данных: 6
  № п/п: 6/6 | Кол-во: 6/6 | Путь: 6/6
```

Блокер:

При выборе `Экспорт сводной спецификации деталей` (`mode 4`) `ZTool.exe`
падает до появления Save dialog:

```text
Application Error
Faulting application: D:\ztool-pr8-test\ZTool.exe
Faulting module: C:\Windows\System32\ucrtbase.dll
Exception code: 0xc0000409
Offset: 0x000000000007286e
```

До этого был ещё один аналогичный crash в той же сессии после экспортов:

```text
14.06.2026 02:02:30  ZTool.exe  ucrtbase.dll  0xc0000409
14.06.2026 02:13:33  ZTool.exe  ucrtbase.dll  0xc0000409
14.06.2026 02:21:05  ZTool.exe  ucrtbase.dll  0xc0000409
```

Для последнего падения включён WER LocalDumps и сохранён полный dump:

```text
Dump: D:\ztool-pr8-test\manual-artifacts\dumps\ZTool.exe.19004.dmp
Size: 517791573 bytes
SHA256: 97BFCCF04BB5F9F15A27A334EA3BDDAC730344A552976AE405F4042580A8067A
```

Итог `350c8c5`: **FAIL**. Binderfix exe грузится, запускается из SolidWorks,
рукопожатие с add-in работает (`29 поз.`), первые 3 BOM-режима экспортируются
валидно, но полный прогон 8 режимов заблокирован падением `ZTool.exe` в
`ucrtbase.dll` на BOM-export (`0xc0000409`).

## Retest: commit 67d6292, binderfix PreserveAll

Проверен исправленный `ZTool_binderfix.exe`, собранный через
`MetadataFlags.PreserveAll`.

```text
repo commit: 67d6292
runtime EXE: D:\ztool-pr8-test\ZTool.exe
source EXE: client-core\dist\ZTool_binderfix.exe
SHA256: 7488A71F5C9353D44946816DF5BD7DD8D94D414C09D552536B9AC5921B82E7F3

runtime DLL: D:\ztool-pr8-test\ZTool.dll
SHA256: D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9
```

Проверка инъекции:

```text
BinderInject verify: PASS
ZTool.VTBinder present
ZTool.code::DeserializeBinary binder-wire sites=1
ZTool.code::DeserializeObject binder-wire sites=1
```

Метод запуска: SolidWorks запущен через
`explorer.exe "C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk"`, после полной
инициализации открыта сборка
`D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`, ZTool запущен только кнопкой
`Управление файлами` на ленте SolidWorks. Прямой запуск `ZTool.exe` не
использовался.

Подключение к SW:

```text
Get-Process ZTool:
Path: D:\ztool-pr8-test\ZTool.exe
SHA256: 7488A71F5C9353D44946816DF5BD7DD8D94D414C09D552536B9AC5921B82E7F3

Подключить SW:
Подключение завершено, затрачено 0,3 сек, всего 29 поз.
```

Pre-flight:

```text
RESULT: PASS - settings/template are consistent for export.
Presets: 8
FilterRulesList: 5
Service columns:
  Col_Number anchor OK
  Col_Quantity anchor OK
  Col_Path anchor OK
  Col_Preview anchor OK
```

BOM export:

```text
export folder:
D:\ztool-pr8-test\bom-exports\full-test-67d6292-binderfix-preserveall-swlaunch
```

Результат полного прогона:

| # | Режим | Файл | Строк | № п/п | Кол-во | Путь | Эскизы | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | --- | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-binderfix-preserveall.xlsx` | 29 | 29/29 | 29/29 | 29/29 | - | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-binderfix-preserveall.xlsx` | 32 | 32/32 | 32/32 | 32/32 | - | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-binderfix-preserveall.xlsx` | 6 | 6/6 | 6/6 | 6/6 | - | PASS |
| 4 | Экспорт сводной спецификации деталей | `04_parts_only_0614-A00-binderfix-preserveall.xlsx` | 25 | 25/25 | 25/25 | 25/25 | - | PASS |
| 5 | Экспорт сводной спецификации (с эскизами) | `05_summary_images_0614-A00-binderfix-preserveall.xlsx` | 29 | 29/29 | 29/29 | 29/29 | есть | PASS |
| 6 | Экспорт иерархической спецификации (с эскизами) | `06_hierarchy_images_0614-A00-binderfix-preserveall.xlsx` | 32 | 32/32 | 32/32 | 32/32 | есть | PASS |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-binderfix-preserveall.xlsx` | 15 | 15/15 | 15/15 | 15/15 | - | PASS |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-binderfix-preserveall.xlsx` | 9 | 9/9 | 9/9 | 9/9 | - | PASS |

Валидатор:

```text
Найдено файлов: 8
Ожидаемо: 8 (по одному на режим)

[PASS] 01_summary_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29

[PASS] 02_hierarchy_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32

[PASS] 03_top_level_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 6
  № п/п: 6/6 | Кол-во: 6/6 | Путь: 6/6

[PASS] 04_parts_only_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 25
  № п/п: 25/25 | Кол-во: 25/25 | Путь: 25/25

[PASS] 05_summary_images_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29
  Эскизы: ЕСТЬ

[PASS] 06_hierarchy_images_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32
  Эскизы: ЕСТЬ

[PASS] 07_processed_filter_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 15
  № п/п: 15/15 | Кол-во: 15/15 | Путь: 15/15

[PASS] 08_purchased_filter_0614-A00-binderfix-preserveall.xlsx
  Строк данных: 9
  № п/п: 9/9 | Кол-во: 9/9 | Путь: 9/9

ПРОВЕРКА СОГЛАСОВАННОСТИ РЕЖИМОВ:
  - Режим 7 (Обрабатываемые детали): 15 из 29 строк - фильтр применён.
  - Режим 8 (Покупные изделия): 9 из 29 строк - фильтр применён.

ИТОГ: PASS - все файлы содержат данные в служебных колонках
```

Проверка crash-регрессии:

```text
Mode 4: PASS, файл создан, ZTool.exe остался жив.
ZTool process after export: Responding=True
Application Error/.NET Runtime/WER по ZTool за время прогона: нет
Новых WER dump-файлов: нет
Старый dump ZTool.exe.19004.dmp относится к падению 350c8c5.
```

Итог `67d6292`: **PASS**. Падение `0xc0000409` на режиме 4 не
воспроизводится. Полный BOM-прогон 8/8 прошёл при корректном запуске ZTool из
ленты SolidWorks.

## Retest: commit 8be50ec, SafeListBinder clipboard allow-list

Проверен новый `ZTool_binderfix.exe`, содержащий оба binder-патча:
`VTBinder` для конфигов и `SafeListBinder` для clipboard paste.

```text
repo commit: 8be50ec
runtime EXE: D:\ztool-pr8-test\ZTool.exe
source EXE: client-core\dist\ZTool_binderfix.exe
SHA256: 4D8AA7EA82755D89DF978BDE29F8176143D0E9FF817F35789433E435A848CF56

runtime DLL: D:\ztool-pr8-test\ZTool.dll
SHA256: D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9
```

Проверка инъекции:

```text
BinderInject verify: PASS
type ZTool.VTBinder: present, BindToType override=yes
ZTool.code::DeserializeBinary: binder-wire sites=1
ZTool.code::DeserializeObject: binder-wire sites=1
type ZTool.SafeListBinder: present, BindToType override=yes
pasteitem_Click allow-list binder sites=4
```

Метод запуска: SolidWorks запущен через
`explorer.exe "C:\Users\Public\Desktop\SOLIDWORKS 2025.lnk"`, после полной
инициализации открыта сборка
`D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`, ZTool запущен только кнопкой
`Управление файлами` на ленте SolidWorks. Прямой запуск `ZTool.exe` не
использовался.

Подключение к SW:

```text
Get-Process ZTool:
Path: D:\ztool-pr8-test\ZTool.exe
SHA256: 4D8AA7EA82755D89DF978BDE29F8176143D0E9FF817F35789433E435A848CF56

Подключить SW:
Подключение завершено, затрачено 0,2 сек, всего 29 поз.
```

Pre-flight:

```text
RESULT: PASS - settings/template are consistent for export.
Presets: 8
FilterRulesList: 5
Service columns:
  Col_Number anchor OK
  Col_Quantity anchor OK
  Col_Path anchor OK
  Col_Preview anchor OK
```

BOM export:

```text
export folder:
D:\ztool-pr8-test\bom-exports\full-test-8be50ec-safelistbinder-swlaunch
```

Результат полного BOM-прогона:

| # | Режим | Файл | Строк | № п/п | Кол-во | Путь | Эскизы | Итог |
| --- | --- | --- | ---: | ---: | ---: | ---: | --- | --- |
| 1 | Экспорт сводной спецификации | `01_summary_0614-A00-safelistbinder.xlsx` | 29 | 29/29 | 29/29 | 29/29 | - | PASS |
| 2 | Экспорт иерархической спецификации | `02_hierarchy_0614-A00-safelistbinder.xlsx` | 32 | 32/32 | 32/32 | 32/32 | - | PASS |
| 3 | Экспорт спецификации верхнего уровня | `03_top_level_0614-A00-safelistbinder.xlsx` | 6 | 6/6 | 6/6 | 6/6 | - | PASS |
| 4 | Экспорт сводной спецификации деталей | `04_parts_only_0614-A00-safelistbinder.xlsx` | 25 | 25/25 | 25/25 | 25/25 | - | PASS |
| 5 | Экспорт сводной спецификации (с эскизами) | `05_summary_images_0614-A00-safelistbinder.xlsx` | 29 | 29/29 | 29/29 | 29/29 | есть | PASS |
| 6 | Экспорт иерархической спецификации (с эскизами) | `06_hierarchy_images_0614-A00-safelistbinder.xlsx` | 32 | 32/32 | 32/32 | 32/32 | есть | PASS |
| 7 | Обрабатываемые детали | `07_processed_filter_0614-A00-safelistbinder.xlsx` | 15 | 15/15 | 15/15 | 15/15 | - | PASS |
| 8 | Покупные изделия | `08_purchased_filter_0614-A00-safelistbinder.xlsx` | 9 | 9/9 | 9/9 | 9/9 | - | PASS |

Валидатор:

```text
Найдено файлов: 8
Ожидаемо: 8 (по одному на режим)

[PASS] 01_summary_0614-A00-safelistbinder.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29

[PASS] 02_hierarchy_0614-A00-safelistbinder.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32

[PASS] 03_top_level_0614-A00-safelistbinder.xlsx
  Строк данных: 6
  № п/п: 6/6 | Кол-во: 6/6 | Путь: 6/6

[PASS] 04_parts_only_0614-A00-safelistbinder.xlsx
  Строк данных: 25
  № п/п: 25/25 | Кол-во: 25/25 | Путь: 25/25

[PASS] 05_summary_images_0614-A00-safelistbinder.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29
  Эскизы: ЕСТЬ

[PASS] 06_hierarchy_images_0614-A00-safelistbinder.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32
  Эскизы: ЕСТЬ

[PASS] 07_processed_filter_0614-A00-safelistbinder.xlsx
  Строк данных: 15
  № п/п: 15/15 | Кол-во: 15/15 | Путь: 15/15

[PASS] 08_purchased_filter_0614-A00-safelistbinder.xlsx
  Строк данных: 9
  № п/п: 9/9 | Кол-во: 9/9 | Путь: 9/9

ПРОВЕРКА СОГЛАСОВАННОСТИ РЕЖИМОВ:
  - Режим 7 (Обрабатываемые детали): 15 из 29 строк - фильтр применён.
  - Режим 8 (Покупные изделия): 9 из 29 строк - фильтр применён.

ИТОГ: PASS - все файлы содержат данные в служебных колонках
```

Проверка crash-регрессии:

```text
Mode 4: PASS, файл создан, ZTool.exe остался жив.
ZTool process after export: Responding=True
Application Error/.NET Runtime/WER по ZTool за время прогона: нет
Новых WER dump-файлов: нет
Старый dump ZTool.exe.19004.dmp относится к падению 350c8c5.
```

Clipboard copy/paste live-тест:

```text
Форма: FrmOutputlist / "Пакетное преобразование формата"
Открытие: ZTool -> Инструменты -> Пакетное преобразование форматов
Заполнение списка: Добавить файл -> загрузка открытых файлов из SolidWorks
Список до копирования: 32 файла

copyitem_Click:
  PASS - показано сообщение "Успешно скопировано 32 поз."

pasteitem_Click:
  FAIL - показано сообщение:
  "Не удалось загрузить файл или сборку 'ZBinderDonor, Version=0.0.0.0,
  Culture=neutral, PublicKeyToken=null' либо одну из их зависимостей.
  Требуется сборка со строгим именем. (Исключение из HRESULT: 0x80131044)"
```

Скрин ошибки:

```text
D:\ztool-pr8-test\manual-artifacts\screen-outputlist-after-paste-8be50ec.png
```

IL-диагностика причины:

```text
pasteitem_Click wire:
  FrmOutputlist/FrmPrintlist/FrmSetDrwlist/FrmSyncDrwName:
    newobj ZTool.SafeListBinder::.ctor()  SCOPE=ZTool.exe

Но внутри ZTool.SafeListBinder::BindToType:
  call ZTool.SafeListBinder::IsAllowed(System.String)
  SCOPE=ZBinderDonor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null

В ZTool.exe остался AssemblyRef:
  ZBinderDonor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
```

Вывод: инъекция `SafeListBinder` частичная. Точки `pasteitem_Click` указывают
на `ZTool.SafeListBinder`, но внутренний call `BindToType -> IsAllowed`
оставлен со scope donor-сборки. Поэтому обычная штатная вставка списка требует
`ZBinderDonor.dll` и падает без него. Это блокер для варианта A/E clipboard
allow-list.

Итог `8be50ec`: **PARTIAL**. BOM-регрессия не воспроизводится (`PASS, 8/8`),
но новая защита clipboard paste не прошла live-тест: `copyitem_Click` работает,
`pasteitem_Click` падает из-за утечки ссылки на `ZBinderDonor`.

## Retest: commit `edd5d0d` / SafeListBinder donor remap fix

Дата/время: `2026-06-14 12:22-12:50`.

Цель: перепроверить фикс утечки ссылок на donor-сборку `ZBinderDonor` после
провала `8be50ec`, не меняя метод запуска. ZTool запускался **только** из
SolidWorks add-in кнопкой `Управление файлами`; прямой запуск `ZTool.exe` не
использовался.

Runtime:

```text
Repo branch: devin/1781201882-bom-templates
Commit: edd5d0d

ZTool.exe:
  Path: D:\ztool-pr8-test\ZTool.exe
  SHA256: 0BF4CB0B4174D1CCDFEF17373DE7EA4965FC0A2E42F27393E0B2571D9955864B

ZTool.dll:
  Path: D:\ztool-pr8-test\ZTool.dll
  SHA256: D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9
```

BinderInject verify:

```text
type ZTool.VTBinder: present, BindToType override=yes
ZTool.code::DeserializeBinary: binder-wire sites=1
ZTool.code::DeserializeObject: binder-wire sites=1
type ZTool.SafeListBinder: present, BindToType override=yes
pasteitem_Click allow-list binder sites=4
VERIFY: PASS
```

Проверка отсутствия ссылок на donor-сборку:

```text
AssemblyRefs containing ZBinderDonor: 0
Instruction refs containing ZBinderDonor: 0
SafeListBinder internal call scope: ZTool.exe
```

Запуск и подключение:

```text
SolidWorks:
  C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe
  SOLIDWORKS Premium 2025 SP3.0 - [0614-A00.SLDASM]
  Responding=True

ZTool:
  D:\ztool-pr8-test\ZTool.exe
  SHA256: 0BF4CB0B4174D1CCDFEF17373DE7EA4965FC0A2E42F27393E0B2571D9955864B
  Запущен из ленты SolidWorks, не напрямую.

Подключить SW:
  PASS - "Подключение завершено, затрачено 0,2 сек", таблица содержит 29 поз.
```

Pre-flight:

```text
RESULT: PASS - settings/template are consistent for export.
```

BOM export:

```text
export folder:
D:\ztool-pr8-test\bom-exports\full-test-edd5d0d-safelistbinder-remap-swlaunch
```

Результат валидатора:

```text
[PASS] 01_summary_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29

[PASS] 02_hierarchy_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32

[PASS] 03_top_level_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 6
  № п/п: 6/6 | Кол-во: 6/6 | Путь: 6/6

[PASS] 04_parts_only_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 25
  № п/п: 25/25 | Кол-во: 25/25 | Путь: 25/25

[PASS] 05_summary_images_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 29
  № п/п: 29/29 | Кол-во: 29/29 | Путь: 29/29
  Эскизы: ЕСТЬ

[PASS] 06_hierarchy_images_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 32
  № п/п: 32/32 | Кол-во: 32/32 | Путь: 32/32
  Эскизы: ЕСТЬ

[PASS] 07_processed_filter_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 15
  № п/п: 15/15 | Кол-во: 15/15 | Путь: 15/15

[PASS] 08_purchased_filter_0614-A00-safelistbinder-remap.xlsx
  Строк данных: 9
  № п/п: 9/9 | Кол-во: 9/9 | Путь: 9/9

ПРОВЕРКА СОГЛАСОВАННОСТИ РЕЖИМОВ:
  - Режим 7 (Обрабатываемые детали): 15 из 29 строк - фильтр применён.
  - Режим 8 (Покупные изделия): 9 из 29 строк - фильтр применён.

ИТОГ: PASS - все файлы содержат данные в служебных колонках
```

Clipboard copy/paste live-тест:

```text
Форма: FrmOutputlist / "Пакетное преобразование формата"
Открытие: ZTool -> Инструменты -> Пакетное преобразование форматов
Заполнение списка: Добавить файл -> загрузка открытых файлов из SolidWorks
Список до копирования: 32 файла

copyitem_Click:
  PASS - показано сообщение "Успешно скопировано 32 поз."

pasteitem_Click:
  PASS - ошибка ZBinderDonor больше не появляется.
  Контрольный сценарий: очистка списка -> Вставить.
  После вставки список снова содержит 32 файла.
```

Скрины:

```text
D:\ztool-pr8-test\manual-artifacts\screen-after-connect-edd5d0d.png
D:\ztool-pr8-test\manual-artifacts\screen-outputlist-after-copy-edd5d0d.png
D:\ztool-pr8-test\manual-artifacts\screen-outputlist-after-clear-paste-edd5d0d.png
```

Проверка crash-регрессии:

```text
ZTool process after tests: Responding=True
Application Error/.NET Runtime/WER по ZTool/ZBinderDonor за последний час: нет
Новых WER dump-файлов: нет
CrashDumps directory does not exist
```

Итог `edd5d0d`: **PASS**. BOM-регрессия не воспроизводится (`PASS, 8/8`),
clipboard allow-list после remap фикса работает: `copyitem_Click` и
`pasteitem_Click` проходят без ошибки `ZBinderDonor`.
