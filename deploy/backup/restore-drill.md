# SQLite restore drill

Цель drill - доказать, что backup не просто создаётся, а реально
восстанавливается и проходит healthcheck.

## Перед restore

1. Остановить сервис:

```bash
sudo systemctl stop swtools-license-server
```

2. Сохранить текущий файл БД:

```bash
sudo cp /var/lib/swtools-license-server/licenses.db \
  /var/lib/swtools-license-server/licenses.db.before-restore
```

3. Проверить backup:

```bash
/opt/swtools-license-server/.venv/bin/python -m swtools_license_server.cli \
  verify-backup /var/backups/swtools-license-server/licenses-YYYYMMDDTHHMMSSZ.db
```

## Restore

```bash
sudo install -o swtools -g swtools -m 0640 \
  /var/backups/swtools-license-server/licenses-YYYYMMDDTHHMMSSZ.db \
  /var/lib/swtools-license-server/licenses.db
```

## Проверка

```bash
sudo -u swtools /opt/swtools-license-server/.venv/bin/python -m swtools_license_server.cli \
  --db /var/lib/swtools-license-server/licenses.db verify-backup /var/lib/swtools-license-server/licenses.db
sudo -u swtools /opt/swtools-license-server/.venv/bin/python -m swtools_license_server.cli \
  --db /var/lib/swtools-license-server/licenses.db healthcheck
sudo systemctl start swtools-license-server
sudo systemctl status swtools-license-server
```

## Важно

- Backup БД не заменяет backup RSA private key.
- Потеря private key делает уже выданные лицензии/клиентскую связку
  операционно непригодной без миграции ключа и клиента.
- Restore drill нужно прогонять после каждой миграции схемы и перед release.
