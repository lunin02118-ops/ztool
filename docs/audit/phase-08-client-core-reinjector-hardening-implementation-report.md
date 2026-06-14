# Phase 08 implementation report — client-core/reinjector hardening

## Scope

Phase 08 делает client-core build менее хрупким и более проверяемым:

- фиксирует SHA256 входов сборки;
- добавляет fail-closed проверку входов в `build.ps1`;
- пишет `client-core/out/ZTool.manifest.json`;
- сохраняет/документирует `PublicKeyToken` policy;
- отключает fuzzy method matching в Reinjector по умолчанию.

Эта ветка rebased/retargeted на `main` после merge Phase 07 / PR #19.

## Changed files

- `client-core/build-inputs.json` — expected SHA256 для build inputs.
- `client-core/build.ps1` — input hash gate, `-AllowUnknownInputs`, output
  manifest.
- `client-core/tools/Reinjector/Program.cs` — strict signature matching by
  default, explicit `--allow-fuzzy-match`, fail-closed missing target handling,
  assembly-ref verification.
- `docs/client-core/BINARY_BUILD_POLICY_RU.md` — binary build policy,
  PublicKeyToken notes, exact-read placement.
- `.gitattributes` — stable EOL for Python/YAML and `translations.tsv`.
- `docs/INDEX.md` — link to client-core policy.
- `docs/production/RISK_REGISTER_RU.md` — Phase 08 status.
- `docs/audit/phase-08-client-core-reinjector-hardening-implementation-report.md`
  — this report.

## Behavior changes

- `client-core/build.ps1` now fails before build if known inputs do not match
  `client-core/build-inputs.json`.
- Experimental/custom inputs require `-AllowUnknownInputs`.
- Successful build writes `client-core/out/ZTool.manifest.json` with:
  - git commit/branch/dirty;
  - input hashes;
  - output hash;
  - `PublicKeyToken`;
  - Win32 file/product versions;
  - Reinjector verify result.
- Reinjector no longer falls back to first overload on signature mismatch unless
  `--allow-fuzzy-match` is explicitly passed.
- Reinjector now returns non-zero and does not write output if a selected target
  type/method is missing.
- `TCPClient.ReadExact` is not added as a new method; exact-read logic stays
  inside existing `TCPClient.getreceive()`, so strict Reinjector can replace it
  without method-add support.

## Backward compatibility

- Runtime code and wire protocol are unchanged.
- The generated `ZTool.exe` still preserves `PublicKeyToken=f08fc7047657204e`.
- Existing normal `.\build.ps1` usage still works for committed inputs.

## Tests run

```powershell
cd D:\Development\ztool\repo-main\client-core
$env:DOTNET_ROOT='D:\Development\ztool\.dotnet'
$env:PATH='D:\Development\ztool\.dotnet;' + $env:PATH
.\build.ps1
# build log checked: no `no target type` / `no target method`

cd D:\Development\ztool\repo-main
python client-core\tools\localization_scan.py `
  --exe client-core\out\ZTool.exe `
  --translations client-core\tools\Localizer\translations.tsv `
  --whitelist-dir localization `
  --report $env:TEMP\ztool-phase08-localization-report.json `
  --fail-on-unclassified
python tools\secret_scan.py
git diff --check
git diff --check origin/main...HEAD

dotnet run -c Release --project client-core\tools\Reinjector -- `
  --verify client-core\out\ZTool.exe

rg -n "ReadExact" client-core\src client-core\tools\Reinjector

$badOut = Join-Path $env:TEMP 'ztool-reinjector-negative.exe'
dotnet run -c Release --project client-core\tools\Reinjector -- `
  client-core\ref\ZTool_rsa.dll `
  client-core\bin\Release\net48\ZTool.Core.dll `
  $badOut
echo $LASTEXITCODE
# expected: 1, and `$badOut` is not created
```

## Test results

- `.\build.ps1`: PASS.
  - input hash gate passed.
  - normal build printed no `no target type` / `no target method`.
  - Reinjector verify: `dangling typerefs = 0`.
  - output manifest written to `client-core/out/ZTool.manifest.json`.
  - output SHA256: `6920d2c8e424562c5ebba7750ae129a77e4c732cadb0299e772d4b38698ed5f2`.
  - output PublicKeyToken: `f08fc7047657204e`.
  - file/product version: `1.0.0`.
- `localization_scan.py`: PASS.
  - `han_entries`: `74`.
  - `unclassified_han`: `0`.
  - translation diagnostics: `0 errors`, `0 warnings`.
- `python tools\secret_scan.py`: `Secret scan OK`.
- `git diff --check`: PASS; Git printed LF-to-CRLF warnings for the touched
  report/policy docs, no whitespace errors.
- `git diff --check origin/main...HEAD`: PASS.
- explicit `Reinjector --verify`: PASS; `dangling typerefs = 0`.
- `rg -n "ReadExact" client-core\src client-core\tools\Reinjector`: no matches.
- negative Reinjector test with a target DLL missing all selected ZTool types:
  PASS; printed `no target type ...`, returned exit code `1`, and
  `NEGATIVE_OUTPUT_EXISTS=False`.

## Manual checks

No SolidWorks manual smoke was run. Runtime binary logic was not intentionally
changed, but any release candidate produced by this build still needs the
standard SolidWorks smoke from the release gate.

## Security notes

- Build no longer silently accepts unknown binary inputs.
- Manifest records exact output hash and `PublicKeyToken`.
- `translations.tsv` EOL is pinned to CRLF so Windows build hash is stable.

## Migration notes

None.

## Rollback plan

Revert this PR. Runtime behavior and DB schema are unchanged.

## Known limitations

- Output manifest is generated but not committed; release packaging in Phase 10
  will collect it as artifact evidence.
