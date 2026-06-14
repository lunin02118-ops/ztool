# Phase 07 implementation report — localization hardening

## Scope

Phase 07 превращает локализацию из ручного binary patch в проверяемый pipeline:

- добавлены whitelist policy и glossary;
- добавлен machine-readable localization scan report;
- добавлена валидация `translations.tsv`;
- Windows client-core CI дополняется localization scan gate и BOM template smoke;
- BOM template builder сделан deterministic: явный source, expected shared
  string count, SHA256 output.

Эта ветка rebased/retargeted на `main` после merge Phase 06 / PR #18.

## Changed files

- `client-core/tools/localization_scan.py` — JSON scan/validation gate.
- `.github/workflows/client-core-windows.yml` — localization scan после build,
  path triggers для localization/docs/template inputs и BOM template smoke.
- `localization/whitelist_*.txt` — protocol/font/log/known remaining whitelists.
- `docs/localization/*` — процесс, glossary, whitelist policy, screenshot
  checklist, current status.
- `build_ru_bom_template.py` — deterministic source/output CLI and SHA logging.
- `.gitattributes` — LF rules for Python/YAML scripts used by CI.
- `docs/production/RISK_REGISTER_RU.md` — Phase 07 status.
- `docs/audit/phase-07-localization-hardening-implementation-report.md` —
  этот отчёт.

## Behavior changes

- Runtime behavior не менялся.
- CI теперь может валить build, если после локализации есть Han-строка, которая
  не переведена и не whitelisted.
- BOM template build больше не выбирает первый `.xlsx` через glob.

## Backward compatibility

- `Localizer` binary patch logic не менялась.
- `translations.tsv` формат не менялся.
- Existing BOM template artifact не пересобирался и не заменялся в этой фазе.

## Tests run

```powershell
cd D:\Development\ztool\repo-main

$env:DOTNET_ROOT='D:\Development\ztool\.dotnet'
$env:PATH='D:\Development\ztool\.dotnet;' + $env:PATH

python client-core\tools\localization_scan.py `
  --exe client-core\out\ZTool.exe `
  --translations client-core\tools\Localizer\translations.tsv `
  --whitelist-dir localization `
  --report $env:TEMP\ztool-localization-exe-report.json `
  --fail-on-unclassified

python build_ru_bom_template.py --out $env:TEMP\bom_шаблон_phase07_test.xlsx
python -m py_compile client-core\tools\localization_scan.py build_ru_bom_template.py
python tools\secret_scan.py
git diff --check
git diff --check origin/main...HEAD

cd client-core
.\build.ps1
```

## Test results

- `localization_scan.py` on `client-core/out/ZTool.exe`: PASS.
  - `han_entries`: `74`
  - `unclassified_han`: `0`
  - translation diagnostics: `0 errors`, `0 warnings`
- `build_ru_bom_template.py --out $env:TEMP\bom_шаблон_phase07_test.xlsx`: PASS.
  - `source_sha256`: `51c4642ae9782b9efabfc2232c00879b302a1b38df5479a2bbe986794915fff8`
  - `output_sha256`: `6a6722555a880bd2b41e16252b0515bf3cab733de0296873286d0f388e755796`
- `python -m py_compile ...`: PASS.
- `python tools\secret_scan.py`: `Secret scan OK`.
- `git diff --check`: PASS; Git printed LF-to-CRLF warning for the touched
  report file, no whitespace errors.
- `git diff --check origin/main...HEAD`: PASS.
- `client-core/build.ps1`: PASS.
  - `BinderInject verify`: PASS.
  - `Reinjector --verify`: PASS; `dangling typerefs = 0`.

## Manual checks

No SolidWorks manual smoke required: runtime binary patch logic was not
changed. For release candidate, follow
`docs/localization/UI_SCREENSHOT_CHECKLIST_RU.md`.

## Security notes

- Whitelist policy forbids hiding user-facing strings as known remaining.
- Protocol keys remain un-translated.
- Font names remain un-translated.
- No private keys, DBs, dumps or license secrets added.

## Migration notes

None.

## Rollback plan

Revert this PR. Runtime behavior and DB schema are unchanged.

## Known limitations

- The scan gate depends on building/scanning `ZTool.exe`; Linux-only CI does not
  run this gate.
- Screenshot checklist is manual.
- Final artifact hash alignment remains Phase 10.
