# Production readiness report

## Executive summary

TBD after final release package and manual acceptance tests.

## Scope

- ZTool runtime package.
- SOLIDWORKS add-in DLL.
- License server.
- Deployment/runbook/backup docs.

## Release artifacts and hashes

Fill from `release/<package>/manifest.json` and `SHA256SUMS.txt`.

| Artifact | SHA256 | Notes |
| --- | --- | --- |
| `runtime/ZTool.exe` | TBD | |
| `runtime/ZTool.dll` | TBD | |
| `runtime/ZTool.settings` | TBD | |
| `runtime/SW模板/MyMaterials.sldmat` | TBD | Default material library |
| `license-server` | TBD | |

## Package verifier

Command:

```powershell
scripts\verify_release_package.ps1 -PackageRoot "<package>" -RequireSolidWorksTools
```

Expected: `release package verification: PASS`.

Paste verifier JSON summary here:

```json
TBD
```

## Test evidence

Attach or link:

- server test output;
- healthcheck output;
- backup/restore drill result;
- SolidWorks screenshots;
- activation/transfer screenshots/logs;
- BOM export files/screenshots.
- Material library/color screenshot from ZTool table after `Подключить SW`.

## Security controls

- Private key outside repo/package.
- Production DEBUG disabled.
- Logs redacted.
- Build input hashes checked.
- Release manifest generated.
- Threat model/runbooks present.

## Operational controls

- systemd unit installed.
- backup schedule configured.
- restore drill completed.
- monitoring/alerts configured.
- firewall/fail2ban configured.

## Known residual risks

List open items from `docs/production/RISK_REGISTER_RU.md`.

## Rollback plan

- Stop service.
- Restore previous runtime folder.
- Restore previous DB backup if migration caused issue.
- Re-register previous `ZTool.dll` if needed.
- Re-enable previous service/env.

## Go/No-Go recommendation

TBD: `GO`, `NO-GO`, or `GO WITH ACCEPTED RISKS`.
