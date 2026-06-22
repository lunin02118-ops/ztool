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

Статус: **PASS** после замены stale release exe.

Факты:
- Release runtime `releases\1.1.6\package\SWTools-1.1.6\runtime\SWTools.exe` сначала имел корректную версию `1.1.6`, но старый SHA256 `3a90a13ce358a99411f922ca3bffff44d79c75aacc7ea2b70cc55edc63c72e0a` и не содержал прошитый IPC handshake token `9EF1CBF0BCFAD9F118EA30863B1874`.
- На stale exe штатный handler `_ConnectSW_ExecuteEvent` стабильно давал `Подключение завершено, затрачено 0,1 сек, всего 0 поз.`
- После замены exe на from-source сборку `1.1.6` SHA256 `f418c7d81a735c309b4fb0709c8bd81333d95cfab9c7468aa2329add0a364e09` `sw_test_preflight.ps1` проходит без override по `expected_release_hashes.json`.
- Живой прогон: SolidWorks 2025, `TestModel\0614-A00.SLDASM`, `LoadAddIn=0`, `GetAddInObject('ZTool.SwAddin')=True`, запуск через `openZtool(0)`.
- Результат после `Подключить SW`: UIA `rows=29 cols=40`; статус bar `Подключение завершено, затрачено 0,2 сек.`
- Доказательства: `_local_artifacts\test-runs\release-1.1.6-ab-20260622\evidence\b328-after-connect.png`.

## Дополнительные замечания

- При регистрации bare output `client-src-addin\bin\Release\net48\ZTool.dll` кнопка SolidWorks пыталась открыть `ZTool.exe` из той же папки и падала, потому что `ZTool.exe` там отсутствует. Для живого теста нужен coherent runtime: `ZTool.dll`, `ZTool.exe` и runtime DLL в одной папке.
- Заголовок from-source/release exe после фикса: `SWTools 1.1.6(x64)`.
- `RegisterFunction` from-source add-in пишет `Title=ZTool`, `Description=ZTool高效辅助工具` и default `0`; установленный runtime использует `SWTools` и default `1`. Это надо сверить до production merge.

## Решение

S7 закрыт на `0614-A00.SLDASM`. Перед production-ready merge остаются S8/L3-L5.

Допускается мержить только после повторного живого прогона:
- 8 режимов BOM проходят;
- L3-L5 лицензирования проходят против боевого сервера;
- версия UI соответствует release version.
