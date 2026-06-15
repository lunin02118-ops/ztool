# Phase 06 implementation report — CI and test quality

## Scope

Phase 06 добавляет воспроизводимые CI-gates и минимальные quality/security
checks:

- GitHub Actions для license-server;
- GitHub Actions для Windows client-core build;
- GitHub Actions для secret scan;
- pytest markers и dev tooling;
- dependency-free secret scanner;
- lightweight release manifest generator.

Эта ветка rebased/retargeted на `main` после merge Phase 05 / PR #17.

## Changed files

- `.github/workflows/license-server.yml` — install, ruff, compileall, bandit,
  pytest+coverage.
- `.github/workflows/client-core-windows.yml` — Windows `client-core/build.ps1`
  and Reinjector verify.
- `.github/workflows/secret-scan.yml` — tracked-file secret scan.
- `license-server/pyproject.toml` — dev dependencies, pytest markers, ruff and
  bandit config.
- `tools/secret_scan.py` — local/CI secret scan for tracked private key files
  and private key blocks.
- `tools/release_manifest.py` — SHA256 manifest generator for release artifacts.
- `docs/production/RISK_REGISTER_RU.md` — Phase 06 status.
- `docs/audit/phase-06-ci-test-quality-implementation-report.md` — this report.

## Behavior changes

- Runtime server/client behavior is unchanged.
- CI now has gates for:
  - server tests;
  - critical Python lint;
  - Python compile check;
  - bandit scan with documented legacy-crypto skips;
  - coverage reporting;
  - client-core Windows build/verify;
  - committed secret scan;
  - repository tools compile/smoke checks.

## Backward compatibility

- No protocol changes.
- No DB migration.
- No client binary or server runtime logic changes.

## Tests run

```powershell
cd D:\Development\ztool\repo-main\license-server
python -m pip install -e ".[dev]"
ruff check .
python -m compileall ztool_license_server tests
$env:PYTHONIOENCODING='utf-8'; bandit -q -r ztool_license_server -c pyproject.toml
pytest -q --cov=ztool_license_server --cov-report=term-missing

cd D:\Development\ztool\repo-main
python -m py_compile tools\secret_scan.py tools\release_manifest.py
python tools\secret_scan.py
python tools\release_manifest.py --output /tmp/ztool-release-manifest-test.json
python tools\release_manifest.py --output $env:TEMP\ztool-release-manifest-test.json

cd D:\Development\ztool\repo-main\client-core
$env:DOTNET_ROOT='D:\Development\ztool\.dotnet'
$env:PATH='D:\Development\ztool\.dotnet;' + $env:PATH
.\build.ps1
```

## Test results

- `python -m pip install -e ".[dev]"`: PASS.
- `ruff check .`: PASS.
- `python -m compileall ztool_license_server tests`: PASS.
- `bandit -q -r ztool_license_server -c pyproject.toml`: PASS.
- `pytest -q --cov=ztool_license_server --cov-report=term-missing`:
  `110 passed, 2 skipped`, total coverage `78%`.
- `python -m py_compile tools\secret_scan.py tools\release_manifest.py`: PASS.
- `python tools\secret_scan.py`: `Secret scan OK`.
- `python tools\release_manifest.py --output /tmp/ztool-release-manifest-test.json`:
  PASS, manifest written.
- `python tools\release_manifest.py ...`: PASS, manifest written to temp.
- `client-core\build.ps1`: PASS with exit code 0.

Warnings observed:

- Existing tests emit `ResourceWarning: unclosed database`; not introduced by
  Phase 06, but now visible in coverage run.
- Localizer still reports 12 untranslated translatable Chinese strings; Phase
  07 owns localization gates.
- Reinjector verify prints `! no target method TCPClient::ReadExact` while
  returning success; Phase 08 owns reinjector strictness.

## Manual checks

N/A. This phase changes CI/tooling only. No SolidWorks/client runtime manual
smoke required.

## Security notes

- Secret scan is dependency-free and runs on tracked files only.
- Bandit skips are explicit for known legacy compatibility false positives:
  bind-all interface controlled by deployment firewall, legacy passphrase
  constants, weak legacy crypto primitives. Residual crypto risk remains for
  Phase 09 threat model.
- Workflows do not print secrets and do not require real license keys.

## Migration notes

None.

## Rollback plan

Revert this PR. Runtime behavior and DB schema are unchanged.

## Known limitations

- First GitHub-hosted CI run still needs to be observed after PR creation.
- Coverage is reported but not fail-under gated yet.
- Secret scanner is a baseline gate, not a full replacement for a dedicated
  enterprise secret scanning product.
- Client-core workflow depends on GitHub Windows image availability of .NET
  SDKs 8.0.x and 10.0.x.
