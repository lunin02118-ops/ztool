# Phase 03 implementation report — DB state model

## Scope

Phase 03 делает SQLite storage предсказуемым для production: versioned schema,
idempotent migrations, SQLite PRAGMA, transaction helper, корректный
`device_limit` и hash-пароли вместо plaintext для новых/мигрированных кодов.

Эта ветка сделана поверх Phase 02 (`hardening/02-protocol-hardening` / PR #14),
который сам stacked поверх Phase 01. Перед финальным merge нужно последовательно
слить/перенацелить #13 -> #14 -> этот PR.

## Changed files

- `license-server/ztool_license_server/db.py`
- `license-server/ztool_license_server/server.py`
- `license-server/ztool_license_server/cli.py`
- `license-server/tests/test_db.py`
- `license-server/tests/test_db_migrations.py`
- `license-server/tests/test_db_transactions.py`
- `license-server/tests/test_device_limit.py`
- `license-server/README.md`
- `docs/production/RISK_REGISTER_RU.md`

## Behavior changes

- Добавлена таблица `schema_version`, `LATEST_SCHEMA_VERSION = 4`.
- Миграции:
  - `001_initial_existing_schema`;
  - `002_password_hash_columns`;
  - `003_pending_activation_transfer`;
  - `004_indexes_constraints`.
- SQLite PRAGMA:
  - `foreign_keys = ON`;
  - `journal_mode = WAL`;
  - `busy_timeout = 5000`;
  - `synchronous = NORMAL`.
- Добавлен `LicenseDB.transaction()` с nested-call support.
- `apply_register` и `apply_remove` теперь оборачивают validate/check/mutate/audit
  в одну транзакцию.
- `add_license_code()` хранит пароль как `pbkdf2_sha256`.
- Старые plaintext password мигрируют в hash и очищают поле `password`.
- `device_limit` теперь реально означает число разных активных машин:
  - limit `1` сохраняет старое поведение;
  - limit `2` позволяет две разные машины;
  - повторная активация той же машины идемпотентна.
- CLI `list-activations` больше не печатает первые символы machine fingerprint,
  только короткий SHA-256.

## Backward compatibility

- Старые БД с plaintext `password` мигрируют при первом открытии.
- Поле `password` остаётся в схеме для миграционной совместимости, но новые
  значения туда не пишутся.
- Default `device_limit = 1`, поэтому текущая production policy не меняется,
  если явно не выдать код с большим лимитом.
- Wire protocol и license blob не менялись.

## Commands run

```powershell
cd D:\Development\ztool\repo-main\license-server
python -m pytest -q

cd D:\Development\ztool\repo-main
git diff --check
```

## Test results

- `python -m pytest -q`: `92 passed, 2 skipped`
- `git diff --check`: PASS; только Windows warning о будущей замене LF на CRLF.

## Security notes

- `R-006` mitigated at schema/transaction level; full pending activation/transfer
  semantics remain Phase 04.
- `R-007` mitigated: `device_limit` now matches CLI/schema behavior.
- Plaintext passwords are not written for new codes.

## Rollback plan

Откатить PR Phase 03. БД, уже открытая новой версией, будет иметь дополнительные
columns/tables/indexes; старый код должен продолжить читать базовые поля, но
plaintext-пароли после миграции уже очищены. Для полного rollback нужен backup
БД до миграции.

## Known limitations

- Pending activation/transfer tables созданы, но stateful semantics и TTL
  реализуются в Phase 04.
- Password hash iterations зафиксированы в коде (`200000`); policy/rotation
  можно уточнить в Phase 09.
