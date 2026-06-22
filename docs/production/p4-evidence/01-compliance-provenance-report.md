# P4 Sprint A/B/C/D evidence report

Дата: 2026-06-22
Baseline: `docs/production/p4-evidence/00-baseline.md`

## Scope

Реализован первый исполнимый слой плана `docs/production/ZTOOL_P4_PERFECTION_PLAN_RU.md`:

- Sprint A: baseline evidence.
- Sprint B: legal/compliance templates, third-party inventory, SBOM generation, license policy gate.
- Sprint C: binary provenance matrix and verification gate.
- Sprint D: backend identity policy/check for SQLite/MySQL drift.

Application source code не менялся.

## Checks run

| Check | Result |
|---|---|
| `pwsh -NoProfile -File scripts/generate_sbom.ps1 -OutputDir artifacts` | PASS, generated CycloneDX + SPDX |
| `pwsh -NoProfile -File scripts/check_license_policy.ps1` | PASS with 5 review-required P4 blockers |
| `pwsh -NoProfile -File scripts/generate_binary_provenance.ps1 -OutputPath artifacts/binary-provenance.md -JsonOutput artifacts/binary-provenance.json` | PASS |
| `pwsh -NoProfile -File scripts/verify_binary_provenance.ps1` | PASS with warnings for non-authoritative root binaries and missing release package |
| `pwsh -NoProfile -File scripts/check_license_backend.ps1 -JsonOut artifacts/license-backend.json` | PASS, repo default backend `sqlite` |

## Findings closed

- P4 plan now has a baseline evidence file.
- Third-party/license risk is machine-readable and checked by CI.
- SBOM evidence can be generated without external syft/trivy dependency.
- Root `SWTools.exe`/`SWTools.dll` mismatch is documented as non-authoritative instead of implicit.
- Backend drift is fail-closed: repo supports SQLite only; MySQL production mode is blocked until adapter/config/tests are present.

## New findings / residual risks

| Risk | Status |
|---|---|
| Legal approval for modified ZTool/SWTools runtime | P4 BLOCKED |
| `itextsharp.dll` AGPL/commercial decision | P4 BLOCKED |
| `Ribbon.dll` / `ExpandableGridView.dll` origin/license unknown | P4 BLOCKED |
| Exact `releases/1.1.6` package absent in clean worktree | P4 BLOCKED for installer/package acceptance |
| Production MySQL mentioned in methodology but no MySQL adapter in repo | P4 BLOCKED until production backend is confirmed SQLite or MySQL support is added |
| `#65` source-of-truth closure not merged into this branch | P4 source closure pending |

## Rollback

Revert this PR. It adds docs, scripts and CI workflow only; runtime behavior, license protocol, client UI and DB schema are unchanged.

## Next sprint

After this PR:

1. Merge/stack after `#65` or rebase on it.
2. Re-run `scripts/generate_binary_provenance.ps1` on the from-source release path.
3. Prepare exact release package and run package/installer/signing checks.
4. Close legal/compliance blockers with real approvals or replacement decisions.
