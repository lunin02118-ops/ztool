# SWTools 1.1.11: восстановление импорта имён свойств из файла/папки

Дата: 2026-06-28  
Scope: `Задать имя свойства -> Импорт...`

## 1. Что было сломано

Ручной тест показал расхождение:

- `Получить из открытых в SolidWorks компонентов` — работает;
- `Получить из файла` — не возвращал свойства на боевом SW2025-файле.

Причина регресса: после `c40d78a fix: enforce native property import contract` путь файла/папки был искусственно ограничен только `SolidWorks Document Manager`. На текущем окружении этот native SWDM-путь для файла:

```text
D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT
```

возвращает `swDmDocumentOpenErrorNoLicense`, хотя тот же файл уже открыт и свойства доступны через SolidWorks `ModelDoc`.

## 2. Что найдено в истории

Рабочее поведение уже фиксировалось раньше:

- `4cf4897 Fix property import fallback for SW2025 files`;
- `84902b6 Fix SWTools metadata and property-name regression`;
- `de7bd3c fix: restore property name import fallback`.

В этих фикcах файл/папка сначала пробуют `SolidWorks Document Manager`, а если он не отдаёт свойства для установленной SW2025-среды, используется тот же `ModelDoc`/`CustomPropertyManager` путь, который работает для открытых компонентов.

## 3. Что восстановлено

В исходном файле `MySWDM.cs` восстановлен previously accepted parity path:

```text
GetPropertyNames1 / GetPropertyNames2
  -> SwDMApplication.GetDocument(...)
  -> SwDMDocument.GetCustomPropertyNames()
  -> SwDMConfiguration.GetCustomPropertyNames()
  -> if no names / SWDM open failed:
       attach active SolidWorks
       find already opened document or OpenDoc6 selected file
       Extension.CustomPropertyManager("")
       Extension.CustomPropertyManager(configuration)
       GetNames()
       close only temporary document opened by this import
```

Это не новый произвольный обход. Это восстановление старого рабочего SW2025-поведения из истории проекта.

## 4. Регрессионные проверки

Обновлён gate:

```powershell
python tools\e2e\check_property_import_contract.py --self-test
python tools\e2e\check_property_import_contract.py
```

Gate теперь защищает:

- document-level имена свойств;
- configuration-level имена свойств;
- parity path через активный SolidWorks `ModelDoc`;
- запрет на silent empty result при SWDM failure.

Добавлен live-gate:

```powershell
python tools\e2e\swtools_property_import_live_probe.py `
  --runtime client-src\bin\Release\net48\SWTools.exe `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT" `
  --open-components `
  --json-out _local_artifacts\reports\property-import-live-20260628\property-import-file-open.json

python tools\e2e\swtools_property_import_live_probe.py `
  --runtime client-src\bin\Release\net48\SWTools.exe `
  --folder "D:\1602.00.000 Шнек" `
  --folder-max-files 3 `
  --json-out _local_artifacts\reports\property-import-live-20260628\property-import-folder.json
```

Важно: runtime в тесте именно `SWTools.exe`. Внутренний namespace/type остаётся только compatibility identity исходника.

## 5. Live result

Среда:

- SolidWorks 2025 открыт;
- активный файл: `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`;
- runtime: `client-src\bin\Release\net48\SWTools.exe`.

Результаты:

| Сценарий | Статус | Кол-во имён |
|---|---:|---:|
| `Получить из файла` core path | PASS | 46 |
| `Получить из открытых в SolidWorks компонентов` core path | PASS | 46 |
| `Получить из папки` core path, первые 3 SW-файла | PASS | 78 |

Ключевые имена, найденные в live evidence:

- `Разработал`;
- `Наименование`;
- `Обозначение`;
- `Масса`;
- `Раздел`;
- `Проект_ФБ`;
- `Number`;
- `Description`;
- `Материал_Таблица`;
- `Материал_ФБ`.

Evidence:

- `_local_artifacts\reports\property-import-live-20260628\property-import-file-open.json`;
- `_local_artifacts\reports\property-import-live-20260628\property-import-folder.json`.

## 6. Что ещё нужно проверить пользователю

Этот проход подтверждает core path и live COM/SolidWorks чтение. После сборки/установки нового пакета нужно вручную подтвердить UI-слой:

1. `Задать имя свойства -> Импорт... -> Получить из файла`.
2. Выбрать `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`.
3. Убедиться, что строки добавлены в таблицу.
4. Повторить `Получить из папки` на ограниченной тестовой папке.
5. Повторить `Получить из открытых в SolidWorks компонентов`.

Production GO: **NO-GO** до пересборки/установки текущего head и ручного UI-подтверждения.
