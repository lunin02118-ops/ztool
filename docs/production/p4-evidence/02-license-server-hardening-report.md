# P4 Sprint E evidence report

Дата: 2026-06-23
Baseline: `docs/production/p4-evidence/00-baseline.md`

## Scope

Реализован следующий слой `docs/production/ZTOOL_P4_PERFECTION_PLAN_RU.md`:
Sprint E — license-server hardening.

Application client/source behavior не менялся.

## Changes

- Добавлен in-process fixed-window rate limiter до decrypt/DB path.
- Добавлены env/CLI настройки limiter.
- Добавлены tests для limiter, live TCP close-on-limit, logging helpers и CLI
  dispatcher.
- Включён coverage threshold `85`.
- Добавлены runtime `requirements.txt` и dev `constraints.txt`.
- Добавлены runtime `pip-audit` и OSV scanner gates по `requirements.txt`.
- Добавлены deploy checklist, backup/restore drill и legacy crypto risk
  acceptance.

## Checks run

| Check | Result |
|---|---|
| `python -m pip install -e ".[dev]" -c constraints.txt` | PASS |
| `ruff check .` | PASS |
| `python -m compileall swtools_license_server tests` | PASS |
| `bandit -q -r swtools_license_server -c pyproject.toml` | PASS |
| `pytest -q --cov=swtools_license_server --cov-report=term-missing --cov-fail-under=85` | PASS, 139 passed, 2 skipped, coverage 86.22% |
| `python -m pip_audit -r requirements.txt --strict --progress-spinner off` | PASS, no known vulnerabilities |
| `osv-scanner scan -L requirements.txt` | CI gate added via `go install github.com/google/osv-scanner/v2/cmd/osv-scanner@v2.2.4`; local CLI not installed |

## Findings closed

- License-server now has an in-process rate limit guard in addition to perimeter
  controls.
- Coverage threshold is enforceable and currently passes.
- Runtime dependency audit is reproducible from a lock file.
- Deploy/backup/legacy crypto operational decisions are documented.

## Residual risks

| Risk | Status |
|---|---|
| OSV scanner CLI is not installed in this local environment | Covered in GitHub Actions `license-server` workflow; local prepared-environment run still optional |
| Public internet exposure still requires firewall/fail2ban | Required operational control |
| Legacy crypto remains by compatibility design | Formally accepted in `docs/security/LEGACY_CRYPTO_RISK_ACCEPTANCE_RU.md` |

## Rollback

Revert this PR. Runtime client protocol and DB schema are unchanged; only
server-side pre-dispatch rate limiting, tests, CI gates and docs are added.

## Next sprint

Sprint F — CI/CD release-hardening gates: supply-chain workflow, release
hardening workflow, expected-hash/signing/package gates and branch protection
recommendations.
