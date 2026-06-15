# Phase 09 implementation report — security threat model and policies

## Scope

Phase 09 документирует production security model и operational policies:

- threat model;
- RSA private key compromise runbook;
- abuse/rate-limit policy;
- data retention/privacy policy.

Эта ветка rebased/retargeted на `main` после merge Phase 08 / PR #20.

## Changed files

- `docs/security/THREAT_MODEL_RU.md` — assets, boundaries, attackers, threats,
  mitigations, residual risks, incident response.
- `docs/security/KEY_COMPROMISE_RUNBOOK_RU.md` — detection, shutdown, rotation,
  key readability checks for the `ztool` service user, client migration,
  DB/log audit.
- `docs/security/ABUSE_RATE_LIMIT_POLICY_RU.md` — thresholds, fail2ban example,
  DB-audit-vs-journal caveat, unban procedure.
- `docs/security/DATA_RETENTION_PRIVACY_RU.md` — stored data, retention,
  deletion/anonymization, log redaction.
- `docs/INDEX.md` — links to security docs.
- `docs/production/RISK_REGISTER_RU.md` — R-004 status.

## Behavior changes

None. Documentation-only phase.

## Backward compatibility

N/A. No runtime, protocol, DB or client changes.

## Tests run

```powershell
cd D:\Development\ztool\repo-main
python tools\secret_scan.py
git diff --check
git diff --check origin/main...HEAD
```

## Test results

- `python tools\secret_scan.py`: `Secret scan OK`.
- `git diff --check`: PASS; Git printed LF-to-CRLF warnings for the touched
  docs, no whitespace errors.
- `git diff --check origin/main...HEAD`: PASS.

## Manual checks

N/A. Docs-only.

## Security notes

- Residual legacy crypto risk is explicitly documented.
- Threat model does not claim modern cryptographic strength for legacy protocol.
- Key compromise runbook states that new server private key requires client
  public key migration.
- Key rotation deploy snippet uses service-readable permissions:
  `private_key.txt` as `ztool:root 0400`, `public_key.txt` as `root:ztool 0640`,
  followed by `sudo -u ztool test -r ...` checks and post-restart healthcheck.

## Migration notes

None.

## Rollback plan

Revert this PR. Runtime behavior and DB schema are unchanged.

## Known limitations

- Policies require operational adoption on the VPS; docs alone do not enforce
  fail2ban or key rotation.
