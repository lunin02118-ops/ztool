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
