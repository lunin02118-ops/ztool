# P4 Sprint F evidence report

Дата: 2026-06-23
Baseline: `docs/production/p4-evidence/00-baseline.md`

## Scope

Реализован следующий слой `docs/production/ZTOOL_P4_PERFECTION_PLAN_RU.md`:
Sprint F — CI/CD release-hardening gates.

Client/SolidWorks runtime behavior не менялся.

## Changes

- Добавлен workflow `.github/workflows/release-hardening.yml`.
- Добавлен workflow `.github/workflows/supply-chain.yml`.
- Добавлен `scripts/verify_authenticode.ps1`.
- Добавлен `scripts/check_expected_release_hashes.ps1`.
- Добавлен `docs/production/BRANCH_PROTECTION_RU.md`.
- Release-hardening gate проверяет `scripts/expected_release_hashes.json`;
  loose root `SWTools.exe/SWTools.dll` mismatch фиксируется как WARN, потому что
  эти файлы уже задокументированы как `historical/non-authoritative`.
- Release-hardening gate собирает from-source client/add-in dry-run package,
  проверяет
  `manifest.json`, `SHA256SUMS.txt`, expected runtime hashes и forbidden files.
- Release-hardening gate собирает NSIS installer smoke и сохраняет setup hash,
  installer manifest/build log и Authenticode report как artifact.
- Supply-chain gate генерирует SBOM и проверяет license policy как отдельный
  artifact-producing workflow.

## Checks run locally

| Check | Result |
|---|---|
| Workflow YAML parse | PASS |
| `pwsh -NoProfile -File scripts/generate_sbom.ps1` | PASS |
| `pwsh -NoProfile -File scripts/check_license_policy.ps1` | PASS, 5 review-required items with explicit exception_id |
| `python tools/secret_scan.py` | PASS |
| `git diff --check` | PASS |
| `pwsh -NoProfile -File scripts/check_expected_release_hashes.ps1` | PASS, loose root exe/dll reported as WARN non-authoritative |
| `dotnet build client-src/ZTool.csproj -c Release -warnaserror:false` | PASS, warnings only |
| `dotnet build client-src-addin/sdk-shim/SolidWorksTools.Shim.csproj -c Release` | PASS |
| `dotnet build client-src-addin/ZTool.SwAddin.csproj -c Release -warnaserror:false` | PASS, warnings only |
| `pwsh -NoProfile -File scripts/build_release_package.ps1 -AllowMissingSolidWorksTools` | PASS, dry-run package only |
| `pwsh -NoProfile -File scripts/verify_release_package.ps1 -AllowDirtyManifest` | PASS, local tree dirty because this PR was uncommitted during test |
| `pwsh -NoProfile -File scripts/build_client_installer.ps1` | PASS |
| `pwsh -NoProfile -File scripts/verify_authenticode.ps1 -AllowUnsigned` | PASS, setup/exe/dll reported `NotSigned` |

Local dry-run artifacts were written outside the repo:
`C:\Temp\swtools-p4-f-release-20260623-074406`.

## Residual risks

| Risk | Status |
|---|---|
| CI package omits real `SolidWorksTools.dll` | Accepted for dry-run CI only; production package must pass with real DLL |
| CI permits unsigned artifacts with `-AllowUnsigned` | Only records current state; production signing remains release dossier gate |
| SolidWorks live acceptance cannot run on GitHub-hosted runners | Manual required gate remains unchanged |

## Next sprint

Sprint G — client/source build closure: warning baseline, source/runtime hash
documentation and source-level migration status.
