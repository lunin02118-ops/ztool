# Phase 05 implementation report — ops, deploy, backup, observability

## Scope

Phase 05 делает license-server сопровождаемым в production:

- добавляет systemd/Docker deployment examples;
- добавляет healthcheck и SQLite backup/verify CLI;
- документирует backup/restore drill;
- фиксирует минимальные log/audit-derived metrics и alerts;
- описывает firewall/fail2ban периметр для raw TCP 58000.

Эта ветка rebased/retargeted на `main` после merge Phase 04 / PR #16.
Wire protocol и client runtime не менялись.

## Changed files

- `license-server/ztool_license_server/cli.py` — `healthcheck`,
  `backup`, `verify-backup`.
- `license-server/tests/test_ops_cli.py` — тесты ops CLI.
- `deploy/systemd/*` — unit, env example, runbook.
- `deploy/docker/*` — Dockerfile, compose, Docker runbook.
- `deploy/backup/*` — SQLite backup script и restore drill.
- `deploy/firewall/ufw-example.md` — UFW/fail2ban perimeter notes.
- `deploy/monitoring/*` — metrics mapping и alerts.
- `.gitattributes` — `*.sh text eol=lf` для deploy shell scripts.
- `license-server/README.md` — production ops commands.
- `docs/production/OPERATIONS_TODO_RU.md` — статус Phase 05.

## Behavior changes

- `python -m ztool_license_server.cli healthcheck` проверяет:
  - production-safe logging config;
  - public/private key load;
  - RSA keypair self-check;
  - наличие БД;
  - latest schema version;
  - write-lock через `BEGIN IMMEDIATE`;
  - SQLite `quick_check`.
- `backup --out <path>` делает backup через SQLite backup API.
- `verify-backup <path>` открывает backup read-only и проверяет integrity +
  schema version.
- `healthcheck` и `backup` fail-fast, если DB path ошибочный; они не создают
  пустую БД молча.

## Backward compatibility

- TCP protocol, result codes и license blob не изменялись.
- Existing DB migrations продолжают выполняться через `LicenseDB`.
- Новые CLI-команды дополняют существующие `add-code`, `list-codes`,
  `cleanup-pending`, `offline-activate`.

## Tests run

```powershell
cd D:\Development\ztool\repo-main\license-server
python -m pytest -q

cd D:\Development\ztool\repo-main
git diff --check
```

## Test results

- `python -m pytest -q`: `110 passed, 2 skipped in 9.44s`.
- `git diff --check`: PASS; only Windows LF-to-CRLF warnings for touched text
  files.

## Manual checks

SolidWorks/client manual smoke не требуется: фаза не меняет клиент, DLL,
реестр, license blob или wire protocol.

Production smoke before deploy:

- установить service на staging VPS;
- создать/мигрировать БД;
- положить key files в `/etc/ztool-license-server`;
- запустить `healthcheck`;
- сделать `backup` + `verify-backup`;
- стартовать systemd service;
- проверить `journalctl -u ztool-license-server -f`.

## Security notes

- Env example не содержит секретов.
- systemd unit запускается не от root (`User=ztool`) и использует
  `NoNewPrivileges`, `PrivateTmp`, `ProtectSystem=strict`, `ProtectHome=true`.
- Backup БД отделён от backup private key.
- Monitoring docs используют redacted application logs и DB audit rows; raw
  protocol payload не логируется.
- Встроенный application rate limit не добавлен в этой фазе: документирован
  firewall/fail2ban perimeter, чтобы не смешивать ops PR с runtime policy PR.

## Migration notes

- Новых DB migrations нет.
- Для production добавить env:
  - `ZTOOL_PRIVATE_KEY_FILE`
  - `ZTOOL_PUBLIC_KEY_FILE`
  - `ZTOOL_DB_PATH`
  - protocol limit envs from Phase 02
  - pending TTL envs from Phase 04

## Rollback plan

Откатить PR Phase 05. Runtime server state/DB schema не меняются, поэтому
rollback не требует migration rollback. Если service уже установлен на VPS,
вернуть предыдущий unit/env/runbook вручную или остановить новый service.

## Known limitations

- Metrics пока log/audit-derived; отдельный Prometheus endpoint отложен.
- Rate limiting пока на firewall/fail2ban уровне; встроенный лимитер отложен.
- Docker deployment является примером/staging вариантом; primary production
  runbook — systemd.
