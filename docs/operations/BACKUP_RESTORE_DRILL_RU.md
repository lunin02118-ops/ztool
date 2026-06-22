# Backup / restore drill

Дата: 2026-06-23

## Objective

Prove that the production SQLite license DB can be backed up, verified and
restored without raw-copying a hot DB.

## Backup

```bash
python -m swtools_license_server.cli --db "$SWTOOLS_DB_PATH" \
  backup --out "/var/backups/swtools-license-server/licenses-$(date +%Y%m%d-%H%M%S).db"
```

## Verify backup

```bash
python -m swtools_license_server.cli verify-backup \
  "/var/backups/swtools-license-server/licenses-YYYYMMDD-HHMMSS.db"
```

Expected result:

```text
BACKUP OK
```

## Restore drill

1. Stop license-server service.
2. Move current DB aside, never overwrite it directly.
3. Copy verified backup into `SWTOOLS_DB_PATH`.
4. Set DB owner/permissions according to deploy runbook.
5. Run `healthcheck`.
6. Start service.
7. Run activation smoke with a test key.
8. Record before/after DB hash, backup path, operator and timestamp.

## Acceptance

| Gate | Result |
|---|---|
| Backup created by SQLite backup API | Required |
| `verify-backup` PASS | Required |
| `healthcheck` PASS after restore | Required |
| Activation smoke PASS | Required |
| No private keys or DB backups committed | Required |

## Frequency

Run before every production release and after any schema migration.
