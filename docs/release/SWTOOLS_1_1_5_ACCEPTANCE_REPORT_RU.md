# SWTools 1.1.5 acceptance report

Дата: 2026-06-21
Ветка: `codex/release-1.1.5-acceptance`
Пакет: `releases/1.1.5/SWTools-1.1.5-Setup.exe`

## Артефакты

- Installer SHA256: `db63a8f430a3359049492fbc283caad19daceda3543fe12eb9dacb41d7342034`
- Installed `SWTools.exe` SHA256: `2a13274060efca1b4c2c8aa66abd91a9a1ab963cb2eb9d69631e19e8d3d63a56`
- FileVersion/ProductVersion: `1.1.5`
- Runtime path after clean install: `C:\Program Files\SWTools\SWTools.exe`
- Expected hashes source of truth: `scripts/expected_release_hashes.json`, version `1.1.5`

## Clean install and licensing

Статус: PASS.

- Старая установка и локальное license-state очищены перед установкой.
- Установщик `SWTools-1.1.5-Setup.exe` поставил приложение в `C:\Program Files\SWTools`.
- Проверена работа без лицензии: приложение открывает registration/trial gate.
- Один и тот же production test-key использован для всего прогона.
- Полный ключ/пароль не попали в отчёт; фиксируются только mask/hash/length:
  - code mask: `DNBG...K953`
  - code SHA12: `41bae9af8041`
  - code segment lengths: `8,5,5,5,9`
  - password length: `12`
  - password SHA12: `0e10c16663ac`
- Root cause предыдущего отказа активации: ключ был создан в stale SQLite, а production service реально работает с `ZTOOL_DB_BACKEND=mysql`.
- Ключ добавлен в фактический MySQL backend production-сервиса через runtime env `/proc/<MainPID>/environ`.
- После онлайн-активации серверное состояние:
  - `current_activations=1`
  - `max_activations=1`
  - `machine_bound=true`
  - `is_active=1`
  - `is_revoked=0`
  - last activation log: `success=1`, `error_message=accepted`
- После `Регистрация выполнена` старый PID завершился, новый SWTools PID стартовал автоматически.
- Локально после рестарта: `HKCU:\SOFTWARE\SWTools\sn` существует, длина `36`; старый бренд `HKCU:\SOFTWARE\ZTool` отсутствует.

Безопасные локальные evidence-файлы:

- `manual-test-reports\2026-06-21-clean-install-1.1.5\160-remote-add-mysql-license-redacted.out.log`
- `manual-test-reports\2026-06-21-clean-install-1.1.5\162-after-success-ok-restart-check.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.5\163-local-registry-after-activation-redacted.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.5\165-remote-mysql-activation-state-redacted.out.log`

Скриншоты/дампы с полным ключом остаются только локальными секретными артефактами и не коммитятся.

## SolidWorks live smoke

Статус: PASS для подключения и загрузки таблицы.

- SolidWorks 2025 открыт с `TestModel\0614-A00.SLDASM`.
- SWTools запущен из установленного runtime и подключён к SolidWorks.
- После `Подключить SW` UIA read-back показывает `29` строк (`0..28`) в `DataGridView`.
- Найдены ключевые заголовки, включая расчётные/служебные свойства:
  - `Масса`
  - `Количество`
  - `Конфигурация`
  - `Материал`
  - `Наименование`
  - `Обозначение`
  - `Обработка поверхности`
  - `Дата разработки`
  - `Номер детали в спецификации`

Evidence:

- `manual-test-reports\2026-06-21-clean-install-1.1.5\168-swtools-after-connect-local.png`
- `manual-test-reports\2026-06-21-clean-install-1.1.5\170-swtools-uia-grid-summary.json`

## BOM/Excel export status

Статус: PARTIAL, не выдаётся за полный PASS.

- Offline BOM self-test прошёл.
- Live grid после подключения содержит расчётные колонки, нужные для последующего Excel export.
- Полный live export в Excel с выбором режима `_ExportBom` и `SaveFileDialog` в этом прогоне не закрыт отдельным объектным скриптом. Нужен следующий gate: выбрать BOM mode через UIA/Win32 locator, сохранить `.xlsx` в report dir, затем прочитать Excel и сверить `Масса`, `Количество`, `Габаритные размеры`/прочие расчётные свойства.

## Автоматизация, добавленная после успешной активации

Добавлен `scripts\swtools_activation_acceptance.ps1`.

Что делает script:

- читает один локальный test-key secret;
- выводит только mask/SHA12/length;
- при `-ProvisionProductionKey` добавляет ключ в фактический production backend, выбранный `ztool-tcp-server.service`;
- заполняет registration form через `EM_REPLACESEL` и проверяет `WM_GETTEXT`;
- не использует `SetWindowText` для activation gate;
- при `-ClickActivate` нажимает онлайн-активацию, фиксирует restart и server-side состояние.

Рекомендуемый запуск:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass `
  -File scripts\swtools_activation_acceptance.ps1 `
  -SecretPath _local_artifacts\secrets\licenses\swtools-1.1.5-clean-install-license-*.txt `
  -ReportDir manual-test-reports\2026-06-21-clean-install-1.1.5 `
  -ProvisionProductionKey `
  -ClickActivate
```

## Gates

Пройдено до live stage и повторено после финальных doc/script правок:

- `dotnet build client-src`
- `client-core build`
- source string invariant
- no CJK filenames
- BOM export self-test
- `python -m pytest license-server`
- `python tools\secret_scan.py`
- `scripts\verify_release_package.ps1 -PackageRoot releases\1.1.5\package\SWTools-1.1.5 -RequireSolidWorksTools`
- PowerShell parse для `scripts\swtools_activation_acceptance.ps1`
- `git diff --check`
