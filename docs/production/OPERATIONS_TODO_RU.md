# Operations TODO

Практический список работ для production эксплуатации. Это не инструкция по
деплою, а backlog, который должен быть закрыт фазами hardening.

## Secrets and keys

- Вынести production private key из репозитория и release package.
- Описать key generation, rotation, revoke и emergency compromise flow.
- Проверить права на key-файлы на VPS.
- Убрать `keypair_info.json` из production defaults.

## License server deployment

- Зафиксировать production layout:
  - `/opt/ztool-license-server/app`
  - `/etc/ztool-license-server/server.env`
  - `/var/lib/ztool-license-server/ztool_licenses.db`
  - `/var/backups/ztool-license-server/`
- Добавить systemd unit.
- Добавить healthcheck.
- Добавить backup/restore procedure.
- Добавить журналирование audit events без секретов.

## Database

- Ввести migrations.
- Включить WAL/busy_timeout/foreign keys.
- Проверить transaction boundaries вокруг activation/transfer.
- Добавить rollback/restore drill.

## Monitoring

- Логировать события:
  - activation requested/confirmed;
  - transfer requested/confirmed;
  - invalid code/password;
  - protocol parse reject;
  - rate limit.
- Добавить минимальные метрики или structured log counters.
- Настроить alert на рост отказов/исключений.

## Release package

- Собирать пакет только из manifest.
- Включать SHA256SUMS.
- Не включать private keys, DB, dumps, local logs.
- Проверять, что root/runtime artifacts совпадают с live-tested hashes.

## Manual operations

- Держать отдельную Windows/SolidWorks smoke-машину.
- Для каждого client/reinjector/localization изменения прогонять smoke:
  - add-in loads;
  - ribbon RU;
  - `Управление файлами`;
  - `Подключить SW`;
  - BOM 8/8;
  - activation/transfer, если затронута лицензия.
