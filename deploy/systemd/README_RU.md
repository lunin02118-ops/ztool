# ZTool license-server: systemd deployment

Пример рассчитан на Linux VPS. Пути можно менять, но лучше держать один
стандартный layout:

- `/opt/ztool-license-server/app` - checkout/release приложения.
- `/opt/ztool-license-server/.venv` - Python virtualenv.
- `/etc/ztool-license-server/` - env и RSA key files.
- `/var/lib/ztool-license-server/licenses.db` - SQLite БД.
- `/var/backups/ztool-license-server/` - DB backups.

## Установка

```bash
sudo useradd --system --home /nonexistent --shell /usr/sbin/nologin ztool
sudo mkdir -p /opt/ztool-license-server/app /etc/ztool-license-server \
  /var/lib/ztool-license-server /var/log/ztool-license-server \
  /var/backups/ztool-license-server
sudo chown root:ztool /etc/ztool-license-server
sudo chown -R ztool:ztool /var/lib/ztool-license-server /var/log/ztool-license-server
sudo chmod 0750 /etc/ztool-license-server
```

Скопировать код в `/opt/ztool-license-server/app`, затем:

```bash
cd /opt/ztool-license-server/app/license-server
sudo python3 -m venv /opt/ztool-license-server/.venv
sudo /opt/ztool-license-server/.venv/bin/python -m pip install -U pip
sudo /opt/ztool-license-server/.venv/bin/python -m pip install -e .
```

Скопировать ключи и env:

```bash
sudo cp deploy/systemd/ztool-license-server.env.example \
  /etc/ztool-license-server/ztool-license-server.env
sudo cp private_key.txt public_key.txt /etc/ztool-license-server/
sudo chown root:ztool /etc/ztool-license-server/public_key.txt \
  /etc/ztool-license-server/ztool-license-server.env
sudo chown ztool:root /etc/ztool-license-server/private_key.txt
sudo chmod 0640 /etc/ztool-license-server/public_key.txt
sudo chmod 0640 /etc/ztool-license-server/ztool-license-server.env
sudo chmod 0400 /etc/ztool-license-server/private_key.txt
sudo -u ztool test -r /etc/ztool-license-server/private_key.txt
sudo -u ztool test -r /etc/ztool-license-server/public_key.txt
```

Если это fresh install, сначала создайте/мигрируйте БД любой безопасной CLI
операцией, например добавлением первого кода:

```bash
sudo -u ztool bash -lc 'set -a; source /etc/ztool-license-server/ztool-license-server.env; set +a; \
  /opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli list-codes'
```

Проверка:

```bash
sudo -u ztool bash -lc 'set -a; source /etc/ztool-license-server/ztool-license-server.env; set +a; \
  /opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli healthcheck'
```

Установка unit:

```bash
sudo cp deploy/systemd/ztool-license-server.service /etc/systemd/system/
sudo systemctl daemon-reload
sudo systemctl enable --now ztool-license-server
sudo systemctl status ztool-license-server
```

## Операции

```bash
journalctl -u ztool-license-server -f
sudo systemctl restart ztool-license-server
sudo systemctl stop ztool-license-server
```

Перед обновлением бинарей/кода сделать backup БД:

```bash
sudo deploy/backup/sqlite-backup.sh
```
