# Отчёт: SWTools 1.1.6, чистая установка и боевая активация

Дата: 2026-06-22
Статус: **L2 PASS / полный SolidWorks+BOM прогон не закрыт этим отчётом**
Ветка: `codex/full-acceptance-1.1.6`
Коммит пакета: `52e0f13388c6`
Evidence: `manual-test-reports/2026-06-22-swtools-live-ui-activation/`

## Окружение

| Параметр | Значение |
|---|---|
| Установщик | `releases/1.1.6/SWTools-1.1.6-Setup.exe` |
| Setup SHA256 | `29ffc4749c93c6c64e6da783c5cb65ddde96cdc4133d350d68879f240d43deae` |
| Runtime exe | `C:\Program Files\SWTools\SWTools.exe` |
| Runtime exe SHA256 | `3a90a13ce358a99411f922ca3bffff44d79c75aacc7ea2b70cc55edc63c72e0a` |
| Runtime title после активации | `SWTools 1.1.6(x64)` |
| Сервер лицензий | `ztool-tcp-server.service`, backend `mysql` |
| Версия сервера для license blob | `ZTOOL_CLIENT_VERSION=1.1.6`, `SWTOOLS_CLIENT_VERSION=1.1.6` |

## Что проверено

| Блок | Статус | Доказательство |
|---|---|---|
| Установленный runtime стартует | PASS | `post-preflight-active-process.json`, `02-after-preflight-active-main.png` |
| Package verification | PASS | `verify_release_package.ps1 -RequireSolidWorksTools` |
| `client-src` build | PASS with existing warnings | `dotnet build client-src/ZTool.csproj -c Release` |
| Source string invariants | PASS | `check_source_string_invariants.py --self-test`, `--root client-src` |
| CJK filenames | PASS | `check_no_cjk_filenames.py` |
| BOM template preflight | PASS | `check_bom_template.py SWTools.settings`, `client-core/dist/SWTools.settings` |
| BOM export assert self-test | PASS | `bom_export_assert.py --self-test` |
| License server tests | PASS | `117 passed, 2 skipped` |
| Secret scan | PASS | `Secret scan OK` |
| `git diff --check` | PASS | без ошибок |
| Installed runtime preflight | PASS | `preflight-report.json` |

## Боевая активация L2

| Шаг | Результат |
|---|---|
| Clean license state | Выполнено отдельным preflight с `-CleanLicenseState`; HKCU/HKLM ветки лицензии очищались и проверялись до активации. |
| Установка 1.1.6 | Установщик поставлен в `C:\Program Files\SWTools`; runtime-зависимости рядом с exe, старт без падения `System.Resources.Extensions`. |
| Ввод ключа | PASS: `EM_REPLACESEL` + `WM_GETTEXT` readback, без `SetWindowText`; все 5 сегментов и пароль совпали по длине/значению. |
| Серверная версия | PASS: process env содержит обе переменные версии `1.1.6`; это обязательное условие перед L2. |
| Прямой protocol decrypt | PASS: ответ `13` расшифрован под `client_version=1.1.6`, получено 4 branch payload. |
| UI success | PASS: окно показало `Регистрация выполнена`. |
| Restart после активации | PASS: старый PID `19272` завершился, новый процесс `21240` стартовал как `SWTools 1.1.6(x64)`. |
| Server state | PASS: `current_activations=1`, `machine_bound=true`, `is_active=1`, `is_revoked=0`, recent log `activate/accepted`. |
| Проверка после preflight | PASS: после preflight без очистки клиент снова стартовал активированным, PID `8048`, title `SWTools 1.1.6(x64)`. |

## Найденная причина сбоя

Первый боевой UI-прогон не был успешной активацией, хотя сервер писал `accepted`: клиент показывал
«Ошибка сохранения сведений о регистрации», а HKLM license-blob ветки не появлялись.

Причина: production-сервис шифровал license blob под старую версию клиента. В старом deployment
используется `ZTOOL_CLIENT_VERSION`; новая переменная `SWTOOLS_CLIENT_VERSION` сама по себе не
достаточна. На сервере выставлены обе переменные:

```text
ZTOOL_CLIENT_VERSION=1.1.6
SWTOOLS_CLIENT_VERSION=1.1.6
```

После restart сервиса прямой protocol decrypt стал валидным, а UI-активация прошла с restart.

## Что зафиксировано в методике

- Перед L2 обязательно сверять `ZTOOL_CLIENT_VERSION`/`SWTOOLS_CLIENT_VERSION` с `ProductVersion`
  установленного `SWTools.exe`.
- Состояние `server accepted`, но клиент показывает ошибку сохранения регистрации, теперь
  считается **FAIL**, а не частичным успехом.
- Скрипт `swtools_activation_acceptance.ps1` теперь падает на Windows PowerShell ниже 7, чтобы
  кириллица в UI-локаторах не ломалась из-за кодировки.
- `ClickActivate` теперь требует не только success modal, но и доказательство restart:
  старый PID ушёл, новый процесс появился.

## Остаток

Этот отчёт закрывает упаковку и L2 онлайн-активацию на боевом сервере. Он **не закрывает** полный
живой SolidWorks-прогон: L3-L5, S7 BOM export, S8 parity и S10 должны идти отдельным проходом по
`docs/release/EXECUTOR_TEST_TASKING_RU.md` после текущего merge.
