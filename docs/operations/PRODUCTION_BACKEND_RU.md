# Production backend policy

Дата: 2026-06-22

## Repo-supported backend

Текущий код `license-server` в репозитории поддерживает только SQLite:

- `license-server/swtools_license_server/db.py` использует `sqlite3`;
- конфигурация читает `SWTOOLS_DB_PATH`;
- management CLI и tests работают через SQLite schema/migrations.

## Production drift blocker

`docs/release/FULL_TEST_METHODOLOGY_RU.md` фиксирует инцидент 2026-06-21: production service был заявлен как MySQL backend.

В этом репозитории MySQL adapter/config/tests отсутствуют. Поэтому любое acceptance/tooling окружение, где задано:

```text
SWTOOLS_DB_BACKEND=mysql
ZTOOL_DB_BACKEND=mysql
```

должно считаться `FAIL / P4 BLOCKED`, пока MySQL adapter не синхронизирован в репозиторий и не покрыт tests/docs.

## Required env for acceptance tooling

Для repo-supported SQLite mode:

```text
SWTOOLS_DB_BACKEND=sqlite
SWTOOLS_DB_PATH=<absolute path to licenses.db>
```

Если `SWTOOLS_DB_BACKEND` не задан, helper reports `sqlite` as repo default and warns that production acceptance must set it explicitly.

## Verification

```powershell
python scripts/check_license_backend.py
pwsh -NoProfile -File scripts/check_license_backend.ps1
```

Strict production check:

```powershell
$env:SWTOOLS_DB_BACKEND='sqlite'
$env:SWTOOLS_DB_PATH='D:\path\licenses.db'
python scripts/check_license_backend.py --require-env
```

## P4 decision

P4 GO requires one of:

1. production confirmed SQLite and release dossier records `SWTOOLS_DB_BACKEND=sqlite` + DB path/fingerprint; or
2. MySQL adapter/config/tests/docs added to repo and `check_license_backend.py` updated to validate MySQL explicitly.
