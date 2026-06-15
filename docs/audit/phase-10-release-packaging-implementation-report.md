# Phase 10 release packaging implementation report

## Scope

Phase 10 adds a reproducible release packaging entry point for the production
cut. It does not replace manual SolidWorks acceptance testing; it makes the
artifact boundary explicit before that testing starts.

## Changed files

- `scripts/build_release_package.ps1`
- `scripts/verify_release_package.ps1`
- `ZTool.exe`
- `ZTool.dll`
- `docs/release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md`
- `docs/release/PRODUCTION_READINESS_REPORT_RU.md`
- `docs/INDEX.md`
- `docs/production/RISK_REGISTER_RU.md`
- `docs/audit/phase-10-release-packaging-implementation-report.md`

## Behavior changes

`scripts/build_release_package.ps1` creates a release directory containing:

- `runtime/` with `ZTool.exe`, `ZTool.dll`, settings, help, BOM templates and
  runtime dependencies;
- `license-server/` without private keys, databases, local backups or cache
  folders;
- `deploy/` with systemd/Docker/backup/monitoring materials;
- `docs/` with production, security, release and audit documentation;
- `manifest.json` with source commit, branch, runtime inputs and payload file
  hashes;
- `SHA256SUMS.txt` with UTF-8 paths, including Cyrillic template paths.

The script fails closed when required runtime files are missing. For production
it requires `SolidWorksTools.dll`; for dry-runs only it accepts
`-AllowMissingSolidWorksTools`.

Root runtime artifacts are aligned with the live-tested recommended pair:

- `ZTool.exe` = `client-core/dist/ZTool_binderfix.exe`
  (`0BF4CB0B...9955864B`);
- `ZTool.dll` = `dumps/candidate-ru-20260609/ZTool_ru_candidate2_pmpguard2.dll`
  (`D0535425...0E492EB9`).

The packager now uses those root artifacts by default.

`scripts/verify_release_package.ps1` verifies a built package before manual
acceptance:

- `manifest.json` and `SHA256SUMS.txt` consistency;
- expected `runtime/ZTool.exe` / `runtime/ZTool.dll` hashes;
- optional required `runtime/SolidWorksTools.dll`;
- clean manifest state unless explicitly allowed;
- absence of private keys, DB files, dumps, logs and local build/test caches;
- full package file coverage by `SHA256SUMS.txt`;
- full payload file coverage by `manifest.files`.

The verifier is fail-closed for unaccounted files: a file present in the
package but missing from `SHA256SUMS.txt` fails verification, and a payload file
present in the package but missing from `manifest.files` also fails
verification. This prevents accidental or suspicious release-package drift from
passing the release gate.

## Backward compatibility

No runtime application behavior is changed. This phase only adds packaging and
release documentation.

## Tests run

Production-complete local package command:

```powershell
./scripts/build_release_package.ps1 `
  -Version 1.0.0-phase10-current `
  -OutputRoot $env:TEMP\ztool-release-phase10-current `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll"
```

Verification commands:

```powershell
python tools\secret_scan.py
git diff --check
git diff --check origin/main...HEAD
./scripts/verify_release_package.ps1 `
  -PackageRoot "$env:TEMP\ztool-release-phase10-current\ZTool-1.0.0-phase10-current-<timestamp>" `
  -RequireSolidWorksTools

Set-Content `
  -LiteralPath "$env:TEMP\ztool-release-phase10-current\ZTool-1.0.0-phase10-current-<timestamp>\runtime\extra.txt" `
  -Value "unexpected"
./scripts/verify_release_package.ps1 `
  -PackageRoot "$env:TEMP\ztool-release-phase10-current\ZTool-1.0.0-phase10-current-<timestamp>" `
  -RequireSolidWorksTools
```

Additional manual PowerShell checks verified:

- all paths in `SHA256SUMS.txt` resolve and match actual file hashes;
- package contains no private keys, DB files, dumps, logs, coverage data or
  `egg-info` folders;
- `runtime/ZTool.exe` and `runtime/ZTool.dll` match expected hashes.

## Test results

Output package:

```text
C:\Temp\ztool-release-phase10-current\ZTool-1.0.0-phase10-current-<timestamp>
```

Key runtime hashes:

| File | SHA256 |
| --- | --- |
| `runtime/ZTool.exe` | `0bf4cb0b4174d1ccdfee17373de7ea4965fc0a2e42f27393e0b2571d9955864b` |
| `runtime/ZTool.dll` | `d053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9` |

Results:

- `SHA256SUMS.txt` verified successfully, including Cyrillic paths.
- Package leak scan PASS.
- `verify_release_package.ps1 -RequireSolidWorksTools` PASS on full local
  package:
  `dirty=false`, `solidworks_tools_included=true`, `sha256sums_entries=99`,
  `manifest_files=98`.
- Negative extra-file test PASS: after adding `runtime/extra.txt`, verifier
  fails with `SHA256SUMS file set mismatch` before the package can pass the
  release gate.
- `python tools\secret_scan.py` PASS.
- `git diff --check` PASS; Git printed LF-to-CRLF warning for the touched
  report file, no whitespace errors.
- `git diff --check origin/main...HEAD` PASS.

## Manual checks

Not executed in this phase:

- SolidWorks ribbon/load smoke;
- online activation and transfer from real UI;
- BOM export 8/8 from the packaged runtime;
- staging VPS deploy and restore drill.

These are moved to the final checklist in
`docs/release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md`.

## Security notes

- Release package excludes private keys, DB files, backups, logs, dumps and
  local build/test caches.
- `SHA256SUMS.txt` is UTF-8 without BOM so Cyrillic paths are preserved and
  verifiable.
- `manifest.json` records runtime input paths and package payload hashes.

## Migration notes

For a production package, run from a clean checkout and pass the real
`SolidWorksTools.dll` path:

```powershell
./scripts/build_release_package.ps1 `
  -Version <release-version> `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll"
```

The generated package should then be copied to the acceptance machine and
tested by the final plan.

## Rollback plan

Packaging changes are additive. Rollback is to use the previously accepted
runtime folder/package and ignore the generated Phase 10 package.

For an installed runtime rollback:

- stop ZTool/SolidWorks;
- restore the previous runtime folder;
- re-register the previous `ZTool.dll` via `RegAsm`;
- restore previous server service/env/DB backup if the server package was also
  deployed.

## Known limitations

- Final Go/No-Go still requires the manual checklist in
  `docs/release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md`.
- R-009 is mitigated by aligning root runtime artifacts and making the packager
  use them by default. The final package must still be accepted from its own
  manifest on the SolidWorks test machine.
