# Отчёт по наряду PR #54: from-source SWTools acceptance

Дата: 2026-06-21
Статус: **FAIL found / live-приёмка остановлена на S7**
Коммит `main`: `0f0d44cc5e4c0380b173a9b2500b75f7ca3bbda3`
Evidence: `manual-test-reports/2026-06-21-boevoy-from-source/`

## Окружение

| Параметр | Значение |
|---|---|
| Объект теста | `client-src/bin/Release/net48/ZTool.exe`; для SW live — копия в `_local_artifacts/live-runtime/source-bin-with-addin-pr54-20260621/SWTools.exe` |
| ProductName | `SWTools` |
| ProductVersion | `1.0` |
| FileVersion | `1.0` |
| SHA256 exe | `1EA92513F7416168D60F168F8D9F323A7B1D8E89182873B4F31E7B786756B9E9` |
| Нативная DLL | `SWToolsARM.dll` вручную положена рядом с exe для прогона |
| Add-in DLL | `_local_artifacts/live-runtime/source-bin-with-addin-pr54-20260621/SWTools.dll`, SHA256 `1828B2904D1266AEBB531302E222D07AC87BA1C292966937BE6A0B73AD254705` |
| SolidWorks | `SOLIDWORKS 2025`, `33.3.0.0092` |
| MNum | не снят: L2-L5 не выполнялись |

## Гейты §2

Все локальные gates из `docs/release/EXECUTOR_TEST_TASKING_RU.md` выполнены.

| Gate | Статус | Evidence |
|---|---|---|
| `dotnet build client-src/ZTool.csproj -c Release` | PASS | `01-dotnet-build-client-src.log` |
| `check_source_string_invariants.py --self-test` | PASS | `02-source-string-self-test.log` |
| `check_source_string_invariants.py --root client-src` | PASS | `03-source-string-client-src.log` |
| `check_no_cjk_filenames.py` | PASS | `04-no-cjk-filenames.log` |
| `check_bom_template.py SWTools.settings` | PASS | `05-bom-template-root.log` |
| `check_bom_template.py client-core/dist/SWTools.settings` | PASS | `06-bom-template-dist.log` |
| `bom_export_assert.py --self-test` | PASS | `07-bom-export-self-test.log` |
| `pytest license-server -q` | PASS | `08-pytest-license-server.log` |
| `secret_scan.py` | PASS | `09-secret-scan.log` |

Сводка: `gates-summary.json`.

## Подготовка стенда

| Шаг | Статус | Evidence | Примечание |
|---|---|---|---|
| Бэкап `HKCU\SOFTWARE\SWTools` и `HKCU\SOFTWARE\ZTool` | PASS | `HKCU_SWTools_before.reg`, `HKCU_ZTool_before.reg` | raw `.reg` содержит machine/license state, не коммитить |
| Полное удаление обеих веток | PASS | `stage1-reg-after-clean-redacted.txt` | оба `reg query` вернули отсутствие ключей |
| Повторный контроль после standalone-запуска | PASS | `stage1-reg-after-standalone-redacted.txt` | появился только `SWTools\AppDataPath`, `sn` не создан, legacy `ZTool` не создан |
| Первый запуск до копирования `SWToolsARM.dll` | FAIL/PREP | `S1-standalone-first-launch-error.png` | `dotnet build client-src` не кладёт `SWToolsARM.dll` рядом с exe; без неё старт падает |
| Preflight source runtime для SolidWorks | PASS_WITH_WARNINGS | `11-sw-test-preflight-source-bin-register.log`, `preflight-live-source-bin-with-addin/preflight-report.json` | Warning ожидаемый: `-CleanLicenseState` удаляет license-state для чистого стенда |
| Открытие `TestModel/0614-A00.SLDASM` в SolidWorks | PASS | `SW-live-solidworks-uia-before-open.txt`, `SW-live-after-connect.png` | SolidWorks открыт через file association |
| Запуск через add-in callback `openZtool(0)` | PASS | `SW-live-open-helper3.log`, `SW-live-running-process.json` | Запущен `_local_artifacts/.../SWTools.exe`, SHA256 source exe `1EA925...B9E9` |

## Матрица S1-S10

| ID | Статус | Evidence | Итог |
|---|---|---|---|
| S1. Ребренд и отсутствие китайского | PASS | `S1-standalone-uia.txt`, `S1-standalone-main.png`, `SW-live-S1-S3-L1-uia.txt`, `SW-live-S1-S3-L1.png`, `standalone-ui-summary.json` | Заголовок процесса `SWTools 1.0(x64)`, видимый текст RU, CJK не найден. Live-процесс запущен из SolidWorks callback. |
| S2. Окно «О программе» | **FAIL** | `S2-about-uia.txt`, `S2-about.png` | В UIA-дереве About остаётся `www.z-tool.cn`, что прямо запрещено ТЗ. |
| S3. «Лицензия не обнаружена» | PASS | `S1-standalone-uia.txt`, `S1-standalone-main.png`, `SW-live-S1-S3-L1-uia.txt`, `SW-live-S1-S3-L1.png` | На чистом реестре показан баннер, кнопки `Демо`/`Регистрация`/`Отмена`, email и ссылка сайта; live trial включён через UIA. |
| S4. Апдейт-чек отключён | PASS partial | `S4-update-menu-uia.txt`, `S4-after-update-click-uia.txt`, `S4-after-update-click.png` | При старте update-dialog не появился; пункт `Проверить обновления` нажат через UIA, нового окна приложения не появилось. Browser/process baseline до клика не снимался, поэтому network/browser часть не закрыта полностью. |
| S5. Активация/перенос против боевого сервера | NOT RUN | — | Не выполнялось: нужны серверный лог/pcap и полный L2-L5 прогон. |
| S6. Ярлык рабочего стола | NOT RUN | — | Не выполнялось: требуется установка через инсталлятор/пакет. |
| S7. Живой BOM-экспорт | **FAIL** | `SW-live-after-demo.png`, `SW-live-after-connect.png`, `SW-live-after-connect-uia.txt`, `SW-live-after-connect-summary.json` | `Подключить SW` вызван через UIA, статус показал «Подключение завершено», но таблица осталась пустой (`PartHits=0`), поэтому BOM-экспорт невалиден и дальше не выполнялся. |
| S8. Сверка 1:1 с боевым exe | NOT RUN | — | Не выполнялось. |
| S9. Имена каталогов и пути | PARTIAL | `_local_artifacts/live-runtime/source-bin-with-addin-pr54-20260621/` | Для live runtime вручную собраны `Шаблоны спецификации`/`SolidWorksTemplates`; инсталляторный сценарий не прогонялся. |
| S10. «Параметры печати» на RU Windows/SW | NOT RUN | — | Не выполнялось: требуется live SolidWorks. |

## Матрица L1-L5

| ID | Статус | Evidence | Итог |
|---|---|---|---|
| L1. Стартовая проверка лицензии на чистом стенде | PASS partial | `stage1-reg-after-clean-redacted.txt`, `S1-standalone-uia.txt`, `stage1-reg-after-standalone-redacted.txt`, `SW-live-S1-S3-L1-uia.txt` | На чистом стенде клиент показал «Лицензия не обнаружена»; `sn` не появился. Серверный `verify_register` на активированной лицензии не проверялся. |
| L2. Онлайн-активация | NOT RUN | — | Не выполнялось. |
| L3. Перенос/снятие лицензии | NOT RUN | — | Не выполнялось. |
| L4. Негативные сценарии | NOT RUN | — | Не выполнялось. |
| L5. Сверка протокола from-source vs боевой exe | NOT RUN | — | Не выполнялось. |

## Найденные проблемы

1. **S2 FAIL:** `FrmAbout` всё ещё содержит `www.z-tool.cn` в UIA-дереве. По ТЗ S2 старый домен, vendor-контакты и китайское должны отсутствовать.
2. **PREP FAIL:** чистый `dotnet build client-src/ZTool.csproj -c Release` не кладёт `SWToolsARM.dll` рядом с `ZTool.exe`. Для теста DLL была вручную скопирована из корня репо. Если from-source runtime должен быть самодостаточным после build, это надо исправить в проекте/скрипте сборки.
3. **S7 FAIL:** live-запуск через SolidWorks работает, trial включается, `Подключить SW` вызывается и пишет «Подключение завершено», но таблица деталей пустая. Это блокирует BOM-экспорт и 1:1 сверку.
4. **Live acceptance не закрыт:** S5/S8/S10 и L2-L5 требуют боевой активации, серверных логов/pcap и сравнения с боевым exe. После S7 FAIL дальнейшую BOM/сверку остановлено по правилу эскалации.

## Вывод

Локальные gates PR #54: **9/9 PASS**.
Чистый registry stage, SolidWorks preflight, callback-запуск и trial smoke: выполнены.
Полная приёмка: **FAIL** из-за S2 `z-tool.cn` и S7 пустой таблицы после подключения к SolidWorks.
