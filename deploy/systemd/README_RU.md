# SWTools license-server: systemd deployment

Пример рассчитан на Linux VPS. Пути можно менять, но лучше держать один
стандартный layout:

- `/opt/swtools-license-server/app` - checkout/release приложения.
- `/opt/swtools-license-server/.venv` - Python virtualenv.
- `/etc/swtools-license-server/` - env и RSA key files.
- `/var/lib/swtools-license-server/licenses.db` - SQLite БД.
- `/var/backups/swtools-license-server/` - DB backups.

## Установка

```bash
sudo useradd --system --home /nonexistent --shell /usr/sbin/nologin swtools
sudo mkdir -p /opt/swtools-license-server/app /etc/swtools-license-server \
  /var/lib/swtools-license-server /var/log/swtools-license-server \
  /var/backups/swtools-license-server
sudo chown root:swtools /etc/swtools-license-server
sudo chown -R swtools:swtools /var/lib/swtools-license-server /var/log/swtools-license-server
sudo chmod 0750 /etc/swtools-license-server
```

Скопировать код в `/opt/swtools-license-server/app`, затем:

```bash
cd /opt/swtools-license-server/app/license-server
sudo python3 -m venv /opt/swtools-license-server/.venv
sudo /opt/swtools-license-server/.venv/bin/python -m pip install -U pip
sudo /opt/swtools-license-server/.venv/bin/python -m pip install -e .
```

Скопировать ключи и env:

```bash
sudo cp deploy/systemd/swtools-license-server.env.example \
  /etc/swtools-license-server/swtools-license-server.env
sudo cp private_key.txt public_key.txt /etc/swtools-license-server/
sudo chown root:swtools /etc/swtools-license-server/public_key.txt \
  /etc/swtools-license-server/swtools-license-server.env
sudo chown swtools:root /etc/swtools-license-server/private_key.txt
sudo chmod 0640 /etc/swtools-license-server/public_key.txt
sudo chmod 0640 /etc/swtools-license-server/swtools-license-server.env
sudo chmod 0400 /etc/swtools-license-server/private_key.txt
sudo -u swtools test -r /etc/swtools-license-server/private_key.txt
sudo -u swtools test -r /etc/swtools-license-server/public_key.txt
```

Если это fresh install, сначала создайте/мигрируйте БД любой безопасной CLI
операцией, например добавлением первого кода:

```bash
sudo -u swtools bash -lc 'set -a; source /etc/swtools-license-server/swtools-license-server.env; set +a; \
  /opt/swtools-license-server/.venv/bin/python -m swtools_license_server.cli list-codes'
```

Проверка:

```bash
sudo -u swtools bash -lc 'set -a; source /etc/swtools-license-server/swtools-license-server.env; set +a; \
  /opt/swtools-license-server/.venv/bin/python -m swtools_license_server.cli healthcheck'
```

Установка unit:

```bash
sudo cp deploy/systemd/swtools-license-server.service /etc/systemd/system/
sudo systemctl daemon-reload
sudo systemctl enable --now swtools-license-server
sudo systemctl status swtools-license-server
```

## Операции

```bash
journalctl -u swtools-license-server -f
sudo systemctl restart swtools-license-server
sudo systemctl stop swtools-license-server
```

Перед обновлением бинарей/кода сделать backup БД:

```bash
sudo deploy/backup/sqlite-backup.sh
```
