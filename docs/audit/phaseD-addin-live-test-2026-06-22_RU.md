# Этап D: живой тест from-source add-in на SolidWorks 2025

Дата: 2026-06-22

Ветка: `devin/1782091728-phaseD-addin-source`

Стенд:
- SolidWorks: `SOLIDWORKS Premium 2025 SP3.0`
- Модель: `TestModel\0614-A00.SLDASM`
- Отчётные артефакты: `_local_artifacts\test-runs\pr62-live-20260622-093405\`

## Что проверено

- `client-src-addin\ZTool.SwAddin.csproj` собран против реального `C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll`.
- `RegAsm /codebase` для from-source `ZTool.dll` проходит после копирования реального `SolidWorksTools.dll` рядом с аддином.
- SolidWorks загружает from-source add-in: в дереве окон найден `Ztool_Receiver`, `CodeBase` указывает на тестовый runtime.
- `ZTool.exe` из from-source runtime запускается с IPC-аргументами SolidWorks PID + receiver hwnd.

## Исправлено в PR

- `SolidWorksTools.dll` теперь ищется сначала в корне установленного SolidWorks, затем в `api\redist`.
- Реальный `SolidWorksTools.dll` копируется рядом с `ZTool.dll`, потому что `RegAsm`/SolidWorks должны разрешать helper assembly из папки add-in.
- `sdk-shim/**` исключён из `None`/`Content`/`EmbeddedResource`, чтобы SDK shim не попадал в output вместо настоящего `SolidWorksTools.dll`.

## Живой S7

Статус: **FAIL, merge blocker**.

Факты:
- Штатный handler `_ConnectSW_ExecuteEvent` был вызван через `Ctrl+L` на runtime с `GetDataOption=0`.
- Результат в status bar: `Подключение завершено, затрачено 0,1 сек, всего 0 поз.`
- Ожидаемый критерий S7: таблица должна заполниться компонентами тестовой сборки, не нулём.
- Повтор с локальным `GetDataOption=1` не дал зачётного результата: второй процесс не обрабатывал `Ctrl+L`/Ribbon click устойчиво; UIA видел заголовки таблицы, но строк с компонентами не появилось.

## Дополнительные замечания

- При регистрации bare output `client-src-addin\bin\Release\net48\ZTool.dll` кнопка SolidWorks пыталась открыть `ZTool.exe` из той же папки и падала, потому что `ZTool.exe` там отсутствует. Для живого теста нужен coherent runtime: `ZTool.dll`, `ZTool.exe` и runtime DLL в одной папке.
- Заголовок from-source `ZTool.exe` остаётся `SWTools 1.0(x64)`, что не соответствует текущей версии релиза 1.1.6.
- `RegisterFunction` from-source add-in пишет `Title=ZTool`, `Description=ZTool高效辅助工具` и default `0`; установленный runtime использует `SWTools` и default `1`. Это надо сверить до production merge.

## Решение

PR #62 нельзя мержить как production-ready, пока S7 не даёт ненулевое заполнение таблицы на `0614-A00.SLDASM` и пока не закрыты S8/L3-L5.

Допускается мержить только после повторного живого прогона:
- `Подключить SW` заполняет таблицу компонентами;
- 8 режимов BOM проходят;
- L3-L5 лицензирования проходят против боевого сервера;
- версия UI соответствует release version.
