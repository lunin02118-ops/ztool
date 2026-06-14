# ZTool license server monitoring

На этой фазе метрики считаются log/audit-derived: сервер уже пишет audit rows в
SQLite и безопасные application logs без plaintext payload. До отдельного
Prometheus endpoint минимальный набор снимается SQL-запросами и journal parser.

## Audit event mapping

| Target event | Current source |
| --- | --- |
| `activation.apply.accepted` | `audit_log.action='apply_register' AND result='pending'` |
| `activation.apply.rejected` | `audit_log.action='apply_register' AND result IN ('rejected','wrong_password','error')` |
| `activation.confirm.accepted` | `audit_log.action='register' AND result='success'` |
| `activation.confirm.rejected` | `audit_log.action='register' AND result IN ('rejected','error')` |
| `transfer.apply.accepted` | `audit_log.action='apply_remove' AND result='pending'` |
| `transfer.apply.rejected` | `audit_log.action='apply_remove' AND result IN ('rejected','wrong_password','error')` |
| `transfer.confirm.accepted` | `audit_log.action='remove_confirm' AND result='confirmed'` |
| `transfer.confirm.rejected` | `audit_log.action='remove_confirm' AND result IN ('rejected','error')` |
| `security.wrong_password` | `audit_log.result='wrong_password'` |
| `security.invalid_machine` | `audit_log.details LIKE '%invalid machine code%'` |
| `protocol.invalid_frame` | `journalctl` lines with `Protocol error` |

## Минимальные counters

- `ztool_activation_apply_total{result}`
- `ztool_activation_confirm_total{result}`
- `ztool_transfer_apply_total{result}`
- `ztool_transfer_confirm_total{result}`
- `ztool_invalid_frame_total{reason}`
- `ztool_wrong_password_total`
- `ztool_invalid_machine_total`
- `ztool_license_db_errors_total`

## SQL examples

```sql
SELECT action, result, COUNT(*) AS total
FROM audit_log
WHERE timestamp >= datetime('now', '-1 hour')
GROUP BY action, result
ORDER BY action, result;
```

```sql
SELECT COUNT(*) AS wrong_password_total
FROM audit_log
WHERE result = 'wrong_password'
  AND timestamp >= datetime('now', '-1 hour');
```

## Healthcheck

```bash
/opt/ztool-license-server/.venv/bin/python -m ztool_license_server.cli healthcheck
```

`HEALTHCHECK OK` - зелёный. Любой non-zero exit - аварийный сигнал.
