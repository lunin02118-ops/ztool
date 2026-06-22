# License server deploy checklist

Дата: 2026-06-23

## Preflight

| Check | Command / evidence |
|---|---|
| Runtime env is production | `SWTOOLS_RUNTIME_ENV=production` |
| Debug logging disabled | `SWTOOLS_LOG_LEVEL=INFO` or stricter; no `SWTOOLS_ALLOW_DEBUG_LOGGING=1` |
| Backend explicit | `SWTOOLS_DB_BACKEND=sqlite`; `SWTOOLS_DB_PATH=<absolute path>` |
| Key files explicit | `SWTOOLS_PRIVATE_KEY_FILE`, `SWTOOLS_PUBLIC_KEY_FILE` |
| Private key permissions | Unix: `0600` or stricter |
| Rate limit enabled | `SWTOOLS_RATE_LIMIT_ENABLED=1` |
| Perimeter control | firewall/fail2ban/VPN rule recorded |
| Dependency audit | `python -m pip_audit -r requirements.lock --strict --progress-spinner off` |
| DB backup exists | backup file path + `verify-backup` output |

## Deploy sequence

1. Stop service.
2. Create SQLite backup through CLI backup command.
3. Verify backup.
4. Deploy package/environment.
5. Run `healthcheck`.
6. Start service.
7. Run activation smoke against a dedicated test key.
8. Verify logs contain no plaintext payloads, private keys or full machine
   fingerprints.
9. Record key fingerprint, DB path, package hash and operator/date in release
   dossier.

## Post-deploy commands

```bash
python -m swtools_license_server.cli --db "$SWTOOLS_DB_PATH" \
  healthcheck \
  --private-key-file "$SWTOOLS_PRIVATE_KEY_FILE" \
  --public-key-file "$SWTOOLS_PUBLIC_KEY_FILE"

python -m swtools_license_server.cli --db "$SWTOOLS_DB_PATH" cleanup-pending
```

## Fail/rollback

Rollback is required if any of these fail:

- `healthcheck`;
- backup verification;
- dependency audit;
- activation smoke;
- logs reveal secrets/payloads;
- backend identity gate reports non-SQLite without repo MySQL adapter/tests.
