# RSA private key compromise runbook

Private key сервера подписывает license blobs. Если он скомпрометирован,
атакующий может выпускать валидные лицензии для клиента, который содержит
соответствующий public key.

## Как обнаружить

- Private key появился в git, chat attachment, CI artifact, backup без ACL.
- Неожиданные успешные активации в `audit_log`.
- Несовпадение release manifest / server env с ожидаемым key path.
- Подозрительный SSH login/operator action на VPS.

## Немедленные действия

1. Ограничить входящий TCP 58000 firewall-правилом или остановить service:

```bash
sudo systemctl stop ztool-license-server
```

2. Снять backup БД и логов:

```bash
sudo deploy/backup/sqlite-backup.sh
journalctl -u ztool-license-server --since "24 hours ago" > incident-journal.log
```

3. Убрать старый private key из активного env/path, но сохранить forensic copy в
   закрытом incident vault.

## Ротация ключа

1. Сгенерировать новую keypair:

```bash
python -m ztool_license_server.cli keygen --dir /secure/new-key
```

2. Встроить новый public key в клиентскую сборку через предусмотренный rekey /
   build pipeline.
3. Собрать новый `ZTool.exe`, проверить `ZTool.manifest.json`, локализацию,
   SolidWorks smoke, online activation/transfer.
4. Задеплоить новый private key на сервер:

```bash
sudo install -o ztool -g root -m 0400 private_key.txt /etc/ztool-license-server/private_key.txt
sudo install -o root -g ztool -m 0640 public_key.txt /etc/ztool-license-server/public_key.txt

sudo -u ztool test -r /etc/ztool-license-server/private_key.txt
sudo -u ztool test -r /etc/ztool-license-server/public_key.txt

sudo systemctl restart ztool-license-server
```

5. Запустить healthcheck после restart:

```bash
sudo -u ztool bash -lc 'set -a; source /etc/ztool-license-server/ztool-license-server.env; set +a; /opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli healthcheck'
```

## Клиентская миграция

- Старые клиенты с прежним public key не смогут проверять лицензии, подписанные
  новым private key.
- Нужен release notice и controlled rollout нового клиента.
- Для клиентов, которые нельзя обновить сразу, нужен временный compatibility
  window со старым keypair только если риск принят письменно.

## После ротации

- Проверить `audit_log` на подозрительные активации.
- Ревокнуть/перевыпустить затронутые license codes.
- Ротировать SSH/API tokens, если компромисс мог затронуть VPS или GitHub.
- Удалить старый key из backups, где это допустимо политикой хранения.
- Зафиксировать postmortem и обновить risk register.
