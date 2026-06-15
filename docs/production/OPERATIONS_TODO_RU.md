# Operations TODO

Практический список работ для production эксплуатации. Это не инструкция по
деплою, а backlog, который должен быть закрыт фазами hardening.

## Secrets and keys

- Вынести production private key из репозитория и release package.
- Описать key generation, rotation, revoke и emergency compromise flow.
- Проверить права на key-файлы на VPS.
- Убрать `keypair_info.json` из production defaults.

## License server deployment

- [Phase 05] Зафиксировать production layout:
  - `/opt/ztool-license-server/app`
  - `/etc/ztool-license-server/ztool-license-server.env`
  - `/var/lib/ztool-license-server/licenses.db`
  - `/var/backups/ztool-license-server/`
- [Phase 05] Добавить systemd unit.
- [Phase 05] Добавить healthcheck.
- [Phase 05] Добавить backup/restore procedure.
- [Phase 01/05] Добавить журналирование audit events без секретов.

## Database

- Ввести migrations.
- Включить WAL/busy_timeout/foreign keys.
- Проверить transaction boundaries вокруг activation/transfer.
- Добавить rollback/restore drill.

## Monitoring

- [Phase 05] Документировать события:
  - activation requested/confirmed;
  - transfer requested/confirmed;
  - invalid code/password;
  - protocol parse reject;
  - rate limit.
- [Phase 05] Добавить минимальные log/audit-derived метрики.
- [Phase 05] Настроить alert на рост отказов/исключений.
- [Deferred] Встроенный rate limit в приложении. На Phase 05 закрыто
  firewall/fail2ban-документацией; серверный лимитер выносится в отдельный PR,
  чтобы не смешивать ops-деплой и изменение runtime-политики.

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
