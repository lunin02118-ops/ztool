# Data retention and privacy policy

## Что хранится

SQLite DB хранит:

- license code;
- password hash/salt/algo, если у кода задан пароль;
- device limit, expiry, active flag, note;
- machine fingerprint для activation;
- pending activation/transfer state;
- audit log: action, code, machine_code, result, details, timestamp.

Application logs не должны хранить plaintext protocol payload. Phase 01
логирует payload length/hash вместо тела.

## Зачем это хранится

- Проверка валидности кода и срока действия.
- Enforce `device_limit`.
- Привязка лицензии к устройству.
- Перенос лицензии.
- Аудит спорных активаций и расследование abuse.

## Retention

Рекомендуемая политика:

- Active license codes and activations: пока действует договор/лицензия.
- Pending activation/transfer rows: TTL 10 минут, cleanup job ежедневно.
- Audit log: 180 дней по умолчанию, дольше только если требуется поддержкой.
- Backups DB: 30 дней hot backups, archive по отдельной политике.
- Incident evidence: до закрытия incident/postmortem.

## Удаление клиентских данных

1. Снять backup перед изменениями.
2. Найти code/machine:

```sql
SELECT * FROM activations WHERE code = '<CODE>';
SELECT * FROM audit_log WHERE code = '<CODE>';
```

3. Для удаления customer data:

```sql
UPDATE activations SET machine_code = '<deleted>' WHERE code = '<CODE>';
UPDATE audit_log SET machine_code = '<deleted>', details = '<deleted>' WHERE code = '<CODE>';
```

4. Если license code должен быть полностью отозван:

```sql
UPDATE license_codes SET is_active = 0, note = 'revoked/deleted' WHERE code = '<CODE>';
UPDATE activations SET is_active = 0 WHERE code = '<CODE>';
```

Для штатного физического удаления уже отозванного ключа используйте CLI после
backup:

```powershell
python -m ztool_license_server.cli --db <licenses.db> delete-revoked-code <CODE>
```

Команда удаляет только `is_active = 0` license code, связанные `activations`,
`pending_activations` и `pending_transfers`. Активный ключ команда не удаляет;
`audit_log` сохраняется для истории поддержки.

Не удаляйте строки физически без причины: audit trail помогает поддержке и
расследованиям. Если требуется полное удаление по юридической причине, сначала
экспортируйте anonymized incident note.

## Logs redaction

Запрещено писать в application logs:

- private key;
- decrypted protocol payload;
- full machine fingerprint;
- license password;
- raw license blob.

Разрешено:

- action/result;
- short SHA/hash;
- payload byte length;
- non-sensitive error class;
- redacted path basename для key files.
