# UFW example for ZTool license server

Открывайте TCP 58000 только там, где это нужно клиентам. SSH желательно
оставить доступным только с административных IP.

```bash
sudo ufw default deny incoming
sudo ufw default allow outgoing

# SSH: замените на свой admin IP/CIDR.
sudo ufw allow from <ADMIN_IP>/32 to any port 22 proto tcp

# ZTool license TCP.
sudo ufw allow 58000/tcp

sudo ufw enable
sudo ufw status verbose
```

Минимальный abuse-control до появления встроенного rate limit:

- включить fail2ban по `journalctl -u ztool-license-server` для повторяющихся
  `security event ... result=wrong_password`, `security event ...
  result=invalid_code`, `security event ... result=invalid_machine_code`,
  `Protocol error`;
- ограничить доступ на 58000 по IP, если список клиентов известен;
- алертить резкий рост отказов, см. `deploy/monitoring/alerts.md`.
