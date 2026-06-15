# Production readiness audit follow-up

## Scope

Follow-up for `ZTOOL_PROD_READINESS_AUDIT_2026-06-12_RU.md` blockers:

- B-1: management CLI ignored `ZTOOL_*` env for DB/key locations.
- B-2: `wrong_password` / invalid code / invalid machine attempts were only
  visible in SQLite `audit_log`, so the documented fail2ban example could not
  work from journald.

## Changes

- CLI commands now use `ServerConfig.from_env()` through `_config_from_args()`,
  with command-line flags as explicit overrides:
  `add-code`, `list-codes`, `list-activations`, `purge-invalid`,
  `cleanup-pending`, `offline-activate`, `keygen`.
- `keygen` can write to explicit `ZTOOL_PUBLIC_KEY_FILE` /
  `ZTOOL_PRIVATE_KEY_FILE` locations when `--dir` is not provided.
- The server emits redacted warning logs for perimeter controls:
  `security event ip=<client> action=<...> result=wrong_password`,
  `result=invalid_code`, `result=invalid_machine_code`.
- The logs include SHA256 prefixes for code/machine values, not plaintext
  passwords or full hardware fingerprints.
- Abuse/fail2ban documentation now matches the actual emitted log lines.

## Checks

```text
python -m pytest -q license-server\tests\test_ops_cli.py license-server\tests\test_integration.py --color=no
17 passed

python -m pytest -q license-server --color=no
112 passed, 2 skipped

python -m ruff check license-server
All checks passed!

python -m bandit -q -c license-server\pyproject.toml -r license-server\ztool_license_server
PASS

python tools\secret_scan.py
Secret scan OK

git diff --check
PASS

git diff --check origin/main...HEAD
PASS
```

## Residual work

B-3 remains outside this code change: collect green GitHub Actions, build a
release package and fill `docs/release/PRODUCTION_READINESS_REPORT_RU.md` with
real package hashes, verifier output, activation/transfer evidence, BOM 8/8
evidence and backup/restore evidence.
