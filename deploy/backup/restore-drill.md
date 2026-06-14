# SQLite restore drill

Цель drill - доказать, что backup не просто создаётся, а реально
восстанавливается и проходит healthcheck.

## Перед restore

1. Остановить сервис:

```bash
sudo systemctl stop ztool-license-server
```

2. Сохранить текущий файл БД:

```bash
sudo cp /var/lib/ztool-license-server/licenses.db \
  /var/lib/ztool-license-server/licenses.db.before-restore
```

3. Проверить backup:

```bash
/opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli \
  verify-backup /var/backups/ztool-license-server/licenses-YYYYMMDDTHHMMSSZ.db
```

## Restore

```bash
sudo install -o ztool -g ztool -m 0640 \
  /var/backups/ztool-license-server/licenses-YYYYMMDDTHHMMSSZ.db \
  /var/lib/ztool-license-server/licenses.db
```

## Проверка

```bash
sudo -u ztool /opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli \
  --db /var/lib/ztool-license-server/licenses.db verify-backup /var/lib/ztool-license-server/licenses.db
sudo -u ztool /opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli \
  --db /var/lib/ztool-license-server/licenses.db healthcheck
sudo systemctl start ztool-license-server
sudo systemctl status ztool-license-server
```

## Важно

- Backup БД не заменяет backup RSA private key.
- Потеря private key делает уже выданные лицензии/клиентскую связку
  операционно непригодной без миграции ключа и клиента.
- Restore drill нужно прогонять после каждой миграции схемы и перед release.
