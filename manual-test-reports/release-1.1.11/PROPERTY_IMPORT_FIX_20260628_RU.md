# Property Import Regression Fix — 2026-06-28

Status: FIXED FOR AUDIT / PRODUCTION GO: NO-GO

## Problem

Окно `Задать имя свойства -> Импорт... -> Получить из файла` могло оставить только базовый список свойств:

- `Разработал`;
- `Наименование`;
- `Обозначение`;
- `Материал`;
- `Тип`;
- `Версия`;
- `Обработка поверхности`;
- `Дата разработки`;
- `Масса`.

При этом выбранная SolidWorks-деталь содержала дополнительные свойства, например `Проект_ФБ`, `Number`, `RenameSWP`, `Description`, `Раздел` и другие. Пользовательский сценарий импорта из файла фактически не переносил полный список имён свойств.

## Root Cause

`MySWDM.GetPropertyNames1()` и `MySWDM.GetPropertyNames2()` полагались на `SwDocumentMgr.GetDocument(...)`.

Если Document Manager не открывал выбранный файл или возвращал пустой набор имён, код мог завершить обработку без диагностируемого fallback. В результате импорт выглядел успешным с точки зрения UI, но дополнительные имена свойств не появлялись.

## Fix

В `client-src/ZTool/MySWDM.cs` добавлен fallback:

1. Сначала сохраняется старый путь через SolidWorks Document Manager.
2. Если Document Manager не дал имена свойств, код подключается к текущему SolidWorks через штатный `code.RunSW(..., startnew:false)`.
3. Код ищет уже открытый документ по нормализованному пути.
4. Если файл выбран, но не открыт, код открывает его через `OpenDoc6(..., Silent)` только для чтения имён свойств.
5. Имена собираются из document-level и configuration-level `CustomPropertyManager.GetNames()`.
6. Документ закрывается только если fallback открыл его сам.

## Regression Gates

Обновлён `tools/e2e/check_property_import_contract.py`.

Теперь gate проверяет:

- `GetPropertyNames1()` и `GetPropertyNames2()` не возвращают пустой список молча после сбоя Document Manager;
- fallback использует `code.RunSW`;
- fallback умеет искать открытый документ через `GetOpenDocumentByName` / `GetFirstDocument` / `GetPathName`;
- fallback умеет открывать выбранный файл через `OpenDoc6`;
- fallback читает `GetConfigurationNames`, `CustomPropertyManager`, `GetNames`;
- fallback закрывает только временно открытый документ через `CloseDoc`.

## Live Evidence

Проверка выполнена через .NET Framework reflection-runner с подключением к реальному процессу SolidWorks через `SolidWorksMacro.RunSW_ByID`.

Test file:

`D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`

Evidence file:

`_local_artifacts\reports\property-import-live-20260628\reflection-solidworksmacro-attach-fallback.txt`

Observed result:

- attach to SLDWORKS PID: PASS;
- fallback result: PASS;
- imported property-name count: 46;
- confirmed names: `Проект_ФБ`, `Number`, `RenameSWP`, `Description`, `Раздел`, `Масса`.

Note: `Материал` was not returned by this specific live fallback as a property name, but it is already present in the default property-name grid and therefore does not block the original regression fix.

## Checks

- `dotnet build client-src\ZTool.csproj -c Release --no-incremental`: PASS.
- `python tools\e2e\check_property_import_contract.py --self-test`: PASS.
- `python tools\e2e\check_property_import_contract.py`: PASS.
- `pwsh -NoProfile -File scripts\check_client_src_warnings.ps1`: PASS.
- `python tools\check_visible_brand_boundary.py`: PASS.
- `python tools\check_source_string_invariants.py`: PASS.
- `python tools\secret_scan.py`: PASS.
- `git diff --check`: PASS.
- `pwsh -NoProfile -File scripts\check_license_policy.ps1`: PASS with existing review-required legal warnings.

## Remaining

Перед production GO всё ещё нужен ручной UI-прогон установленного пакета:

1. Открыть `Задать имя свойства`.
2. Нажать `Импорт... -> Получить из файла`.
3. Выбрать `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`.
4. Подтвердить, что в таблице появились дополнительные свойства, включая `Проект_ФБ`, `Number`, `RenameSWP`, `Description`, `Раздел`.

Production GO остаётся `NO-GO` до полного release dossier, signing, accepted hash decision и owner approval.
