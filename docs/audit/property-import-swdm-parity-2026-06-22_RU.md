# Диагностика импорта свойств из файла

Дата: 2026-06-22

Проверяемый файл: `D:\1602.00.003 Фланец.SLDPRT`

## Вывод

Оригинальная китайская реализация `MySWDM.GetPropertyNames1()` сохранена как основной путь:

1. `OpenFileDialog`
2. `swDocMgr.GetDocument(...)`
3. `GetCustomPropertyNames()`
4. `ConfigurationManager.GetConfigurationNames()`
5. `GetConfigurationByName(...).GetCustomPropertyNames()`
6. `CloseDoc()`

Обработчик `Frmsetpropname.AddPropertyNamesFromfile_Click` работает как в оригинале: добавляет только новые имена свойств в таблицу и ставит тип `Текст`.

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

Контрольный прогон fallback на том же файле:

```text
RunSW=True
PROPERTY_COUNT=46
```

Первые импортированные имена: `Разработал`, `Наименование`, `Обозначение`, `Масса`, `Проект_ФБ`.

## Evidence

Локальные доказательства сохранены в:

`_local_artifacts/evidence/2026-06-22-import-flange/`
