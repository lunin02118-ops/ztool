# Evidence: SWTools 1.1.6 live activation

Папка содержит только redacted evidence. Полный регистрационный код, пароль и raw `.reg`
бэкапы сюда не помещались.

| Файл | Что подтверждает |
|---|---|
| `activation-secret-redacted.json` | Маска/SHA12 ключа, длины сегментов и пароля. |
| `activation-form-readback-redacted.json` | Ввод через `EM_REPLACESEL` и readback без `SetWindowText`. |
| `server-client-version-env-redacted.json` | Env production-сервиса: обе версии клиента равны `1.1.6`, backend `mysql`. |
| `python-direct-apply-1.1.6-after-reset.json` | Прямой protocol decrypt под `1.1.6`: response `13`, 4 branch payload. |
| `activation-restart-redacted.json` | UI success modal + старый PID завершён + новый SWTools процесс поднят. |
| `post-preflight-active-process.json` | После preflight без очистки лицензии клиент снова стартует активированным. |
| `preflight-report.json` | Preflight установленного runtime: hash/RegAsm/AddIn CodeBase/CommandManager cleanup. |
| `02-after-preflight-active-main.png` | Скрин активного `SWTools 1.1.6(x64)` после preflight. |
