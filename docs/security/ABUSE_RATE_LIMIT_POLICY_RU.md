# Abuse and rate-limit policy

Текущий протокол raw TCP. На этой стадии rate limiting держится на perimeter
controls: firewall/fail2ban/journal monitoring. In-process limiter можно
добавить отдельным PR, если abuse станет реальной проблемой.

События `wrong_password`, `invalid_code` и `invalid_machine_code` пишутся и в
DB `audit_log`, и в application logs как redacted `security event ip=...`.
Поэтому fail2ban/journald может ловить онлайн-перебор без доступа к SQLite.

## Что считать abuse

- Больше 10 `wrong_password` за 10 минут с одного IP.
- Больше 10 invalid code / invalid machine за 10 минут с одного IP.
- Больше 20 `Protocol error` за 10 минут с одного IP.
- Резкий рост `register_confirm` rejected после успешных `apply_register`.
- Резкий рост `remove_confirm` rejected после успешных `apply_remove`.

## fail2ban пример

Filter `/etc/fail2ban/filter.d/ztool-license-server.conf`:

```ini
[Definition]
failregex = ^.*Protocol error from \('<HOST>', .*\):.*$
            ^.*security event ip=<HOST> .*result=wrong_password.*$
            ^.*security event ip=<HOST> .*result=invalid_code.*$
            ^.*security event ip=<HOST> .*result=invalid_machine_code.*$
ignoreregex =
```

Jail `/etc/fail2ban/jail.d/ztool-license-server.local`:

```ini
[ztool-license-server]
enabled = true
backend = systemd
journalmatch = _SYSTEMD_UNIT=ztool-license-server.service
filter = ztool-license-server
port = 58000
protocol = tcp
maxretry = 10
findtime = 600
bantime = 3600
```

Применить:

```bash
sudo systemctl restart fail2ban
sudo fail2ban-client status ztool-license-server
```

## Разблокировка легитимного клиента

```bash
sudo fail2ban-client set ztool-license-server unbanip <CLIENT_IP>
```

Перед разблокировкой проверить:

- IP действительно принадлежит клиенту.
- Нет массовых invalid attempts с того же адреса.
- Код лицензии активен и не превышает device limit.

## Операционная реакция

1. Снять последние логи:

```bash
journalctl -u ztool-license-server --since "30 minutes ago"
```

2. Проверить DB health:

```bash
python -m ztool_license_server.cli healthcheck
```

3. Если abuse продолжается, временно ограничить TCP 58000 по IP/CIDR через UFW.
