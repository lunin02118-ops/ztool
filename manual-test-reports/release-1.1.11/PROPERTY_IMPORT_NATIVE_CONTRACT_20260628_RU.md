# SWTools 1.1.11: импорт имён свойств через native SolidWorks Document Manager

Дата: 2026-06-28  
Scope: `Задать имя свойства -> Импорт...`

## 1. Решение

Fallback через открытие файла в живом SolidWorks удалён.

Команды:

- `Получить из файла`
- `Получить из папки`

должны читать имена свойств только через `SolidWorks Document Manager`:

```text
SwDocumentMgr.SwDMClassFactory
  -> GetApplication(GetSWDMLicenseKey())
  -> SwDMApplication.GetDocument(...)
  -> SwDMDocument.GetCustomPropertyNames()
  -> SwDMConfiguration.GetCustomPropertyNames()
```

Команда `Получить из открытых в SolidWorks компонентов` остаётся отдельным явным SolidWorks-путём и не является fallback для файла/папки.

## 2. Что исправлено

1. Удалён аварийный путь из `MySWDM.cs`:
   - `OpenDoc6`;
   - поиск открытого документа через `GetOpenDocumentByName` / `GetFirstDocument`;
   - чтение через `CustomPropertyManager`;
   - закрытие временно открытого файла после fallback.

2. Если `SwDMApplication.GetDocument(...)` не возвращает документ, ошибка больше не проглатывается:
   - пишется в лог;
   - показывается пользователю в окне импорта;
   - причина остаётся native SWDM-причиной, например `swDmDocumentOpenErrorNoLicense`.

3. Регрессионный gate `tools/e2e/check_property_import_contract.py` переписан:
   - требует native SWDM path для файла и папки;
   - запрещает live SolidWorks fallback в `GetPropertyNames1()` и `GetPropertyNames2()`;
   - проверяет, что пустые document-level свойства не пропускают configuration-level свойства;
   - проверяет, что native SWDM failure виден пользователю.

## 3. Проверка ключей

Первичная проверка embedded-ключей в source/accepted runtime показала, что старый `key2022`
не открывает боевой SW2025-файл:

```text
swDmDocumentOpenErrorNoLicense
```

После этого ключ извлечён динамической RE-проверкой из рабочей оригинальной
китайской версии:

```text
D:\Development\Workspace\archives\_archive ztool\_vendor\ZTool-original
```

Проверка кандидатов выполнялась только локально; полный ключ не публикуется и
не коммитится. В evidence фиксируются только длина и SHA12:

```text
key_sha12=136fac075b44
key_file_length=1461
```

Для установленного/ручного клиента ключ подключён как локальный secret:

```text
C:\ProgramData\SWTools\swdm.key
```

`MySWDM.GetSWDMLicenseKey()` теперь сначала читает локальный secret source
(`SWTOOLS_SWDM_KEY`, `SWTOOLS_SWDM_KEY_FILE`, `%ProgramData%\SWTools\swdm.key`)
и только затем использует legacy embedded `key2022`. Native SWDM механизм не
меняется.

Ключи в отчёт не публикуются. В evidence фиксировались только длины и короткие SHA256-префиксы.

## 4. Live native probe

Боевой файл:

```text
D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT
```

Native SWDM probe через legacy embedded key возвращал:

```text
swDocMgr_null=False
doc_null=True
open_error_int=5
open_error_name=swDmDocumentOpenErrorNoLicense
```

Native SWDM probe через ключ, извлечённый из оригинальной рабочей версии:

```text
python tools\e2e\check_swdm_property_import_live.py `
  --key-file D:\Development\ztool\_local_artifacts\secrets\vendor-swdm-key-136fac075b44.txt `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT"
```

Результат:

```text
status=PASS
mode=file
file_count=1
property_count=46
key_sha12=136fac075b44
```

Папка:

```text
python tools\e2e\check_swdm_property_import_live.py `
  --key-file D:\Development\ztool\_local_artifacts\secrets\vendor-swdm-key-136fac075b44.txt `
  --folder "D:\1602.00.000 Шнек"
```

Результат:

```text
status=PASS
mode=folder
file_count=9
property_count=86
key_sha12=136fac075b44
```

## 5. Автоматизация

Прогнано:

```powershell
python tools\e2e\check_property_import_contract.py --self-test
python tools\e2e\check_property_import_contract.py
python tools\e2e\check_swdm_property_import_live.py --key-file <local-secret> --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT"
python tools\e2e\check_swdm_property_import_live.py --key-file <local-secret> --folder "D:\1602.00.000 Шнек"
```

Все PASS.

## 6. Что остаётся для полного E2E

Native file/folder import на уровне SWDM закрыт автоматическим live gate.
Остаётся UI-level E2E установленного клиента:

1. `Импорт... -> Получить из файла` на `1602.00.003 Фланец.SLDPRT`.
2. `Импорт... -> Получить из папки` на папке `D:\1602.00.000 Шнек`.
3. `Импорт... -> Получить из открытых в SolidWorks компонентов` на открытой сборке.
4. Проверка, что имена свойств появились в таблице `Задать имя свойства`.
5. Проверка, что при SWDM `NoLicense` UI показывает ошибку, а не пустой успешный импорт.

Production GO: NO-GO до UI-level E2E и полного release acceptance.
