# Phase 01 implementation report — secrets and logging

## Scope

Phase 01 закрывает первый production-hardening слой для сервера лицензий:
безопасная загрузка ключей, запрет небезопасного DEBUG в production и удаление
plaintext protocol payload из application logs.

## Changed files

- `license-server/ztool_license_server/config.py`
- `license-server/ztool_license_server/key_provider.py`
- `license-server/ztool_license_server/logging_utils.py`
- `license-server/ztool_license_server/server.py`
- `license-server/ztool_license_server/crypto/keygen.py`
- `license-server/ztool_license_server/cli.py`
- `license-server/tests/test_secrets_logging.py`
- `license-server/README.md`
- `docs/production/RISK_REGISTER_RU.md`

## Behavior changes

- Сервер поддерживает явные пути:
  - `ZTOOL_PRIVATE_KEY_FILE`
  - `ZTOOL_PUBLIC_KEY_FILE`
- Legacy `ZTOOL_KEYS_DIR` сохранён.
- При `ZTOOL_RUNTIME_ENV=production` и `ZTOOL_LOG_LEVEL=DEBUG` сервер падает
  на старте, если не задан `ZTOOL_ALLOW_DEBUG_LOGGING=1`.
- Debug-log больше не пишет расшифрованное тело запроса. Вместо него пишется
  только `payload_bytes` и короткий SHA-256 digest.
- `keygen` по умолчанию больше не пишет `keypair_info.json`.
- `keypair_info.json` доступен только через явный `--write-debug-key-info`.
- На Unix production-загрузка private key требует `0600` или более строгие
  права.

## Backward compatibility

- Старый layout `keys/public_key.txt` + `keys/private_key.txt` продолжает
  работать.
- Wire protocol, license blob, SQLite schema и клиентское поведение не менялись.
- `load_keypair()` теперь умеет читать пару ключей и без `keypair_info.json`.

## Commands run

```powershell
cd D:\Development\ztool\repo-main\license-server
python -m pytest -q
cd D:\Development\ztool\repo-main
git diff --check
```

## Test results

- `python -m pytest -q`: `74 passed, 2 skipped`
- `git diff --check`: PASS; только Windows warning о будущей замене LF на CRLF.

## Security notes

- `R-003` закрыт на уровне Phase 01 mitigation: plaintext payload больше не
  попадает в application logs, production DEBUG fail-closed.
- `R-004` закрыт частично: файловый key provider стал безопаснее, но полный
  lifecycle/runbook/rotation policy остаётся за Phase 09.

## Migration notes

Production рекомендуется запускать так:

```bash
ZTOOL_RUNTIME_ENV=production
ZTOOL_LOG_LEVEL=INFO
ZTOOL_PRIVATE_KEY_FILE=/etc/ztool-license/private_key.txt
ZTOOL_PUBLIC_KEY_FILE=/etc/ztool-license/public_key.txt
ZTOOL_DB_PATH=/var/lib/ztool-license-server/licenses.db
```

## Rollback plan

Откатить PR Phase 01. Legacy запуск через `ZTOOL_KEYS_DIR` не требует миграции,
поэтому откат не должен менять данные БД или формат ключей.

## Known limitations

- Windows ACL для private key пока не валидируется автоматически.
- Полный production key lifecycle, backup/rotation/runbook и deploy hardening
  остаются в Phase 05/09.
