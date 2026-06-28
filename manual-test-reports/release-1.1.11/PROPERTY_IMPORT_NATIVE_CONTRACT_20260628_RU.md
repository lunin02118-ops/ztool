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

Проверены ключи в:

- установленном `C:\Program Files\SWTools\SWTools.exe`;
- `D:\Development\ztool\SWTools-base.exe`;
- `D:\Development\ztool\SWTools.exe`;
- текущем source build.

Вывод: все используют тот же набор embedded SWDM keys и тот же native `GetSWDMLicenseKey()` путь через `key2022`. Отдельного “другого оригинального ключа” в найденных оригинальных/accepted бинарях нет.

Ключи в отчёт не публикуются. В evidence фиксировались только длины и короткие SHA256-префиксы.

## 4. Live native probe

Боевой файл:

```text
D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT
```

Native SWDM probe через текущий embedded key возвращает:

```text
swDocMgr_null=False
doc_null=True
open_error_int=5
open_error_name=swDmDocumentOpenErrorNoLicense
```

Это означает, что текущий ключ/окружение Document Manager не открывает этот SW2025-файл. Теперь это фиксируется как явная проблема ключа/окружения SWDM, а не маскируется чтением через запущенный SolidWorks.

## 5. Автоматизация

Прогнано:

```powershell
python tools\e2e\check_property_import_contract.py --self-test
python tools\e2e\check_property_import_contract.py
```

Оба PASS.

## 6. Что остаётся для полного E2E

Нужен production/live E2E после предоставления действующего SWDM ключа для SW2025:

1. `Импорт... -> Получить из файла` на `1602.00.003 Фланец.SLDPRT`.
2. `Импорт... -> Получить из папки` на папке `D:\1602.00.000 Шнек`.
3. `Импорт... -> Получить из открытых в SolidWorks компонентов` на открытой сборке.
4. Проверка, что имена свойств появились в таблице `Задать имя свойства`.
5. Проверка, что при SWDM `NoLicense` UI показывает ошибку, а не пустой успешный импорт.

Production GO: NO-GO до live E2E с действующим SWDM ключом.
