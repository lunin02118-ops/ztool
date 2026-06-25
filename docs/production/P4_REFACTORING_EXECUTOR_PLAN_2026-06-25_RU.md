# P4 refactoring executor plan — 2026-06-25

Статус: стартовый архитектурный план для исполнителя.
Роль этого документа: зафиксировать последовательность PR, acceptance gates и границы ответственности между аудитором/архитектором и исполнителем.

## 1. Цель

Довести текущий `main` до release-ready состояния:

```text
Production release = source-built + reproducible + fully gated
Visible brand = SWTools only
Internal compatibility identity = ZTool allowed only by documented policy
Manual checks = не release gate, только optional owner/auditor review после machine PASS
```

## 2. Current assumptions

- `client-src` builds the desktop EXE from source.
- `client-src-addin` builds the SolidWorks add-in from source.
- Internal assembly identity may remain `ZTool` where required for compatibility.
- Public product identity must be `SWTools`.
- Live SolidWorks acceptance cannot run on GitHub-hosted runners; it must move to a self-hosted Windows/SolidWorks runner.

## 3. PR sequence

### PR R0 — Brand boundary baseline

Scope:

- add brand-boundary policy;
- define allowed internal `ZTool` compatibility zones;
- define visible/public `ZTool` as P0 production blocker;
- prepare data model for future brand-boundary gate.

Files expected:

```text
docs/architecture/BRAND_BOUNDARY_RU.md
tools/brand_boundary/allowed_internal_ztool.tsv
tools/check_visible_brand_boundary.py
```

Required checks:

```powershell
python tools/check_visible_brand_boundary.py --self-test
python tools/check_visible_brand_boundary.py
python tools/check_source_string_invariants.py --root client-src --root client-src-addin
python tools/secret_scan.py
git diff --check
```

Definition of done:

- documented internal exceptions exist;
- visible/public occurrences are fail-fast;
- source self-test covers allowed internal token, forbidden visible token and docs exception.

### PR R1 — Release-hardening must build source inputs itself

Scope:

- update `.github/workflows/release-hardening.yml`;
- call `scripts/resolve_release_inputs.ps1` inside the workflow;
- feed `build_release_package.ps1` from generated `release-inputs.json`;
- fail if package silently uses stale root binaries.

Required checks:

```powershell
pwsh -NoProfile -File scripts/check_release_source_guards.ps1
pwsh -NoProfile -File scripts/resolve_release_inputs.ps1 -OutputPath _local_artifacts/release-inputs.json
pwsh -NoProfile -File scripts/build_release_package.ps1 -OutputRoot _local_artifacts/package -ClientExe <json.client_exe.path> -AddinDll <json.addin_dll.path> -AllowMissingSolidWorksTools
pwsh -NoProfile -File scripts/verify_release_package.ps1 -PackageRoot <package-root> -ExpectedClientExeSha256 <actual> -ExpectedAddinDllSha256 <actual>
```

Definition of done:

- `release-hardening` is standalone;
- package provenance says `source-build-output`;
- no build step depends on pre-existing `bin/Release` state;
- no silent fallback to root `SWTools.exe` / `SWTools.dll`.

### PR R2 — Full visual opener harness

Scope:

- make visual capture object-driven for L-01..L-15;
- add deterministic openers for all supported surfaces;
- keep cumulative capture support;
- strict validator must fail incomplete profile.

Required command shape:

```powershell
python scripts/swtools_visual_localization_capture.py `
  --surface-file docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --expected-runtime-dir <runtime> `
  --output-dir <visual-report>

python tools/e2e/assert_visual_localization_manifest.py `
  <visual-report>/visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-profile-surfaces-captured `
  --require-runtime-match
```

Definition of done:

- profile surfaces captured = 15/15;
- forbidden visible text = 0;
- visible Han/CJK = 0 except documented record-only host surfaces;
- screenshots have path, SHA256, width, height;
- runtime path match proven for SWTools process surfaces.

### PR R3 — Self-hosted SolidWorks release E2E

Scope:

- add `.github/workflows/release-e2e-solidworks.yml`;
- run only on `[self-hosted, windows, solidworks, swtools-release]`;
- wire source build, package verify, S7, S8, branding/version, help and visual gates.

Main invocation:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts/e2e/Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RunS8 `
  -RunBrandingVersion `
  -RequireSolidWorks `
  -RequireStrictBomFilters `
  -PrepareStrictBomFixture `
  -SolidWorksExe "$env:SOLIDWORKS_EXE" `
  -SolidWorksToolsDll "$env:SOLIDWORKS_TOOLS_DLL" `
  -TestAssembly "$env:SWTOOLS_TEST_MODEL" `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -OutputDir "$env:RUNNER_TEMP/swtools-e2e"
```

Definition of done:

- S7 PASS with required rows/columns;
- S8 PASS for all required BOM modes;
- branding/version PASS;
- visual strict PASS;
- workflow uploads full artifacts.

### PR R4 — Automated release dossier

Scope:

- add `scripts/build_release_dossier.ps1`;
- aggregate machine artifacts into JSON + Markdown dossier;
- compute machine GO/NO-GO.

Inputs:

```text
release-inputs.json
manifest.json
SHA256SUMS.txt
SBOM CycloneDX/SPDX
binary provenance
license policy report
authenticode report
E2E result
S7/S8 JSON
visual localization manifest
CHM brand/routes reports
installer manifest
```

Definition of done:

- release dossier generated without hand editing;
- GO is false unless all mandatory gates pass;
- dossier records exact commit, version, hashes and source input mode.

### PR R5 — Source-build boundary and runtime binary inventory

Scope:

- document exact build boundary;
- classify runtime DLLs as source-built, third-party, native, SDK or legacy compatibility dependency;
- define migration path for each non-source-built runtime component.

Files expected:

```text
docs/audit/SOURCE_BUILD_BOUNDARY_RU.md
docs/compliance/RUNTIME_BINARY_INVENTORY_RU.md
```

Definition of done:

- no claim of full-from-source beyond what is actually true;
- every runtime binary has origin, hash, license, source availability and migration decision;
- SBOM/provenance align with the inventory.

### PR R6 — Legacy reinject retirement from release path

Scope:

- keep legacy IL reinject/localizer as diagnostic only;
- remove it from production release path;
- create `legacy-diagnostics.yml` if still needed;
- update docs and release dossier language.

Definition of done:

- release path does not consume `client-core/out`;
- release package input mode is `source-build-output`;
- legacy reinject is not part of production GO.

## 4. Global production acceptance

Production GO is blocked unless all are true:

```text
client-src build PASS
client-src-addin build PASS
release-hardening PASS
release-e2e-solidworks PASS
S7 PASS
S8 8/8 PASS
visual L-01..L-15 strict PASS
CHM brand/routes PASS
visible ZTool = 0
visible Han = 0
release package input_mode = source-build-output
release dossier generated automatically
manual checks not required for GO
```

## 5. Auditor rules for executor

- Do not rename internal `AssemblyName` / namespace / COM identity in the same PR as release hardening.
- Do not claim visual FULL PASS until strict profile validator passes 15/15.
- Do not use root loose binaries as release inputs unless explicitly testing accepted runtime snapshot mode.
- Do not merge stale PRs that predate current main without extracting minimal changes.
- Every PR must include exact commands and machine-readable evidence.
- Manual screenshots may supplement evidence but cannot replace machine gates.

## 6. Initial next action for executor

Start with PR R0 + R1 as a small stack:

1. Implement `tools/check_visible_brand_boundary.py` with self-tests.
2. Add `tools/brand_boundary/allowed_internal_ztool.tsv`.
3. Add the gate to `release-acceptance.yml`.
4. Patch `release-hardening.yml` so it calls `resolve_release_inputs.ps1` before packaging.
5. Attach logs for the required commands.
