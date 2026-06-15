# Abuse and rate-limit policy

Текущий протокол raw TCP. На этой стадии rate limiting держится на perimeter
controls: firewall/fail2ban/journal monitoring. In-process limiter можно
добавить отдельным PR, если abuse станет реальной проблемой.

Важно: часть событий, например `wrong_password` и invalid machine/code, может
попадать в DB `audit_log`, а не напрямую в journald. Для таких событий нужен
отдельный journal/exporter rule или периодический DB-based detector, иначе
пример fail2ban ниже будет ловить только те случаи, которые реально пишутся в
application logs.

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
            ^.*wrong_password.*<HOST>.*$
            ^.*invalid machine code.*<HOST>.*$
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
