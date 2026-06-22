# Диагностика импорта свойств из файла

Дата: 2026-06-22

Проверяемый файл: `D:\1602.00.003 Фланец.SLDPRT`

Размер файла: `118492` байт

Дата изменения файла: `2026-06-16 17:47:35`

Live-контекст: `SOLIDWORKS Premium 2025 SP3.0 - [1602.00.003 Фланец.SLDPRT]`

## Вывод

Оригинальная китайская реализация `MySWDM.GetPropertyNames1()` сохранена как основной путь:

1. `OpenFileDialog`
2. `swDocMgr.GetDocument(...)`
3. `GetCustomPropertyNames()`
4. `ConfigurationManager.GetConfigurationNames()`
5. `GetConfigurationByName(...).GetCustomPropertyNames()`
6. `CloseDoc()`

Обработчик `Frmsetpropname.AddPropertyNamesFromfile_Click` работает как в оригинале: вызывает `MySWDM.GetPropertyNames1()`, добавляет только новые имена свойств в таблицу и ставит тип `Текст`.

Единственное отличие обработчика от оригинала по IL-diff - локализация строки типа:

```text
IL_0148: ldstr "Текст" =>
IL_0148: ldstr "文字"  <=
```

## Причина бага

На файле `D:\1602.00.003 Фланец.SLDPRT` оригинальный путь через SolidWorks Document Manager не открывает документ:

```text
swDocMgr_null=False
doc_null=True
open_error_int=5
open_error_name=swDmDocumentOpenErrorNoLicense
```

То есть китайский код на этом SW2025-файле до таблицы свойств не доходит: `GetDocument(...)` возвращает `null`.

## Исправление

В `client-core/src/MySWDM.cs` восстановлен оригинальный typed SwDM-алгоритм. Совместимый fallback включается только если оригинальный путь не вернул свойств. Fallback использует уже подключенный SolidWorks через `code.RunSW(false, false)` и читает имена свойств через `CustomPropertyManager.GetNames()`.

Контрольный прогон fallback на том же файле/открытом SolidWorks:

```text
RunSW=True
PROPERTY_COUNT=46
```

Первые импортированные имена: `Разработал`, `Наименование`, `Обозначение`, `Масса`, `Проект_ФБ`.

## Сверка IL с оригиналом

`MySWDM.GetPropertyNames1()`:

| Вызов | Оригинал | Текущая реализация |
| --- | ---: | ---: |
| `SwDMApplication::GetDocument` | 1 | 1 |
| `SwDMDocument::GetCustomPropertyNames` | 1 | 1 |
| `SwDMConfigurationMgr::GetConfigurationNames` | 1 | 1 |
| `SwDMConfigurationMgr::GetConfigurationByName` | 1 | 1 |
| `SwDMDocument::CloseDoc` | 1 | 1 |
| `ZTool.code::RunSW` | 0 | 1 |
| `OpenDoc6` | 0 | 1 |
| `CustomPropertyManager` | 0 | 1 |
| `GetNames` | 0 | 1 |

Вывод: оригинальные вызовы не удалены и не заменены; добавлены только fallback-вызовы после неуспешного результата SwDM.

`Frmsetpropname.AddPropertyNamesFromfile_Click`:

| Вызов | Оригинал | Текущая реализация |
| --- | ---: | ---: |
| `MySWDM::GetPropertyNames1` | 1 | 1 |
| `DataGridViewRowCollection::Add` | 1 | 1 |
| `DataGridViewCell::set_Value` | 2 | 2 |
| `MessageBox::Show` | 1 | 1 |
| `ldstr "Текст"` | 0 | 1 |

Вывод: поведение кнопки импорта по добавлению строк совпадает с оригиналом; отличие только в русской строке типа свойства.

## Сверка поведения на фикстуре

Оригинальный путь:

```text
swDocMgr_null=False
doc_null=True
open_error_int=5
open_error_name=swDmDocumentOpenErrorNoLicense
EXIT_CODE=31
```

Текущая реализация на той же фикстуре:

```text
RunSW=True
PROPERTY_COUNT=46
EXIT_CODE=0
```

Полный список считанных свойств сохранен в `behavior-patched-fallback.txt`.

## Проверяемые бинарники

```text
80418CDAA812CDFB3C10683EB0C1F664623BAB00C146C90ED33AAFA7806FD82C C:\Program Files\SWTools\SWTools.exe
80418CDAA812CDFB3C10683EB0C1F664623BAB00C146C90ED33AAFA7806FD82C D:\Development\ztool\client-core\out\SWTools.exe
C10CE334FDBBBC05B8186A6E657A22C1ED4ADD8BD638C59D65E5B6798CB4B18D D:\Development\ztool\SWTools-base.exe
```

## Ограничение проверки

Автоматизированный полный клик через `OpenFileDialog` не засчитан как evidence: стандартный Windows-диалог выбора файла не был стабильно управляем из shell-автоматизации. Вместо этого проверены две обязательные части:

1. IL-паритет обработчика кнопки импорта с оригиналом.
2. Фактическое поведение метода импорта на той же фикстуре и в том же live SolidWorks.

## Evidence

Локальные доказательства сохранены в:

`_local_artifacts/evidence/2026-06-22-property-import-parity/`

Ключевые файлы:

- `base-MySWDM-GetPropertyNames1.il.txt`
- `patched-MySWDM-GetPropertyNames1.il.txt`
- `base-Frmsetpropname-AddPropertyNamesFromfile_Click.il.txt`
- `patched-Frmsetpropname-AddPropertyNamesFromfile_Click.il.txt`
- `il-call-counts.txt`
- `handler-il-call-counts.txt`
- `handler-il-diff-head.txt`
- `behavior-original-swdm.txt`
- `behavior-patched-fallback.txt`
- `binary-hashes.txt`
