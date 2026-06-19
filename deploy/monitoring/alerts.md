# SWTools license server alerts

Минимальные production alerts до появления полноценного metrics endpoint.

## Critical

- `systemd` service inactive/failed:

```bash
systemctl is-active --quiet swtools-license-server
```

- `healthcheck` не проходит:

```bash
/opt/swtools-license-server/.venv/bin/python -m swtools_license_server.cli healthcheck
```

- Backup старше 24 часов:

```bash
find /var/backups/swtools-license-server -name 'licenses-*.db' -mtime -1 | grep -q .
```

## Warning

- `wrong_password` больше 10 за 10 минут.
- `invalid machine code` больше 10 за 10 минут.
- `Protocol error` в journal больше 20 за 10 минут.
- `register_confirm` rejected растёт после успешных `apply_register`.
- `remove_confirm` rejected растёт после успешных `apply_remove`.

## Первичная реакция

1. Проверить `journalctl -u swtools-license-server -n 200`.
2. Проверить DB healthcheck и свободное место на диске.
3. При всплеске protocol errors включить firewall/fail2ban на источник.
4. При проблемах confirm/transfer не чистить БД вручную - сначала снять backup.
