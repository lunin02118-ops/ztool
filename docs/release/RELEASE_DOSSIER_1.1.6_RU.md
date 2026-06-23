# Release dossier 1.1.6

Дата: 2026-06-23
Статус: `DRAFT / NO-GO`

Этот dossier является каркасом финального P4 release evidence. Он не является
разрешением на production release.

## Current stack

| Layer | Status |
|---|---|
| #72 Deep Audit delta / Legal-IP model | Open, user audit required before merge. |
| #74 Sprint H localization whitelist governance | Open, user visual audit required before merge. |
| #75 Sprint L/M repo hygiene + BinaryFormatter containment | Open, user audit required before merge. |
| Sprint N signing/release dossier | This PR, draft only. |

## Required final evidence

| Evidence | Status |
|---|---|
| Exact source commit | Pending after reviewed stack merge. |
| Exact release package path | Pending final build. |
| SHA256SUMS / manifest | Pending final build. |
| Binary provenance | Pending final build from final commit. |
| SBOM / license notices | Pending final build. |
| Authenticode production verification without `-AllowUnsigned` | Pending signing or formal exception. |
| Clean install smoke | Pending. |
| SolidWorks S7/S8 live acceptance | Pending. |
| Licensing L3-L5 live acceptance | Pending. |
| Localization visual audit | Pending user screenshots. |
| Repo hygiene gate | PASS in Sprint L/M draft; re-run on final commit. |
| BinaryFormatter surface gate | PASS in Sprint L/M draft; re-run on final commit. |
| Secret scan | Re-run on final commit. |

## Production verification commands

These commands must be run on the final release commit/package:

```powershell
python tools\secret_scan.py
git diff --check
pwsh -NoProfile -File scripts\check_repo_hygiene.ps1
pwsh -NoProfile -File scripts\check_binaryformatter_surface.ps1
pwsh -NoProfile -File scripts\generate_sbom.ps1 -OutputDir artifacts
pwsh -NoProfile -File scripts\check_license_policy.ps1
pwsh -NoProfile -File scripts\generate_binary_provenance.ps1 `
  -OutputPath artifacts\binary-provenance.md `
  -JsonOutput artifacts\binary-provenance.json
pwsh -NoProfile -File scripts\verify_binary_provenance.ps1 `
  -ProvenancePath artifacts\binary-provenance.md
pwsh -NoProfile -File scripts\verify_release_package.ps1 -RequireSolidWorksTools
pwsh -NoProfile -File scripts\verify_authenticode.ps1 -Path <final artifacts>
```

Important: the production Authenticode command above intentionally does not use
`-AllowUnsigned`.

## Manual audit gate

Before merge/release:

```text
[ ] User reviewed #72.
[ ] User reviewed Sprint H visual localization evidence.
[ ] User reviewed Sprint L/M deletion of client-rekey tracked inputs.
[ ] User reviewed final signing/release dossier.
[ ] No merge without explicit user approval.
```

## Current decision

`NO-GO`

Reasons:

- reviewed stack is not merged;
- visual localization audit is pending;
- final signed package is not built;
- SolidWorks/licensing live acceptance is pending;
- production Authenticode verification has not passed.
