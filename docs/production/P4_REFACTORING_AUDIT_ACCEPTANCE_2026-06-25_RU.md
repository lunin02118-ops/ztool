# P4 refactoring audit acceptance checklist — 2026-06-25

Статус: компактный checklist аудитора для refactoring / release-hardening PR.

## 1. Статусы аудита

Использовать только явные решения:

- `APPROVED FOR MERGE`;
- `REQUEST CHANGES`;
- `COMMENT / INFORMATIONAL`;
- `NO-GO FOR PRODUCTION`;
- `GO FOR PRODUCTION`.

`APPROVED FOR MERGE` не равно `GO FOR PRODUCTION`, если PR закрывает только часть цепочки.

## 2. Безусловные блокеры production GO

- Видимый legacy brand в UI, CHM, installer, screenshots, visual manifest или file metadata.
- Неполный L-01..L-15 visual profile при заявке на visual FULL PASS.
- S7/S8 без machine-readable JSON evidence.
- Release package без `release-inputs.json`, `manifest.json` или `SHA256SUMS.txt`.
- Release workflow использует готовые `bin/Release` outputs без source build/resolve step в том же workflow.
- Ручная проверка используется вместо обязательного automated gate.
- Новый runtime binary не отражён в SBOM/provenance/inventory.
- Full-from-source заявлен шире, чем фактически подтверждено.

## 3. Обязательные evidence sets

### Source/build

```powershell
pwsh -NoProfile -File scripts/check_release_source_guards.ps1
pwsh -NoProfile -File scripts/resolve_release_inputs.ps1 -OutputPath <out>/release-inputs.json
```

### Package

```powershell
pwsh -NoProfile -File scripts/build_release_package.ps1 ...
pwsh -NoProfile -File scripts/verify_release_package.ps1 ...
```

### Brand/localization

```powershell
python tools/check_source_string_invariants.py --root client-src --root client-src-addin
python tools/chm-i18n/check_chm_brand.py help_ru.chm
python tools/chm-i18n/check_help_entry_routes.py --chm help_ru.chm
python tools/check_visible_brand_boundary.py
```

### Live E2E

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts/e2e/Invoke-SWToolsE2E.ps1 -BuildFromSource -RunS7 -RunS8 -RunBrandingVersion -RequireSolidWorks ...
python tools/e2e/assert_e2e_result.py <e2e-result.json> --allow-warn --require-stage-pass 05-preflight-register --require-stage-pass 07-s7-connect --require-stage-pass 08-s8-bom-export --require-stage-pass 09-excel-validation --require-stage-pass 10-branding-version --require-s7-model-ready --require-s7-min-rows 29 --require-s7-min-columns 30
```

### Visual

```powershell
python tools/e2e/assert_visual_localization_manifest.py <manifest> --allow-warn --require-surface-file docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json --require-profile-surfaces-captured --require-runtime-match
```

## 4. Mandatory PR body template

```markdown
## Scope

## Changed files

## Compatibility boundary
- Internal legacy identity touched? yes/no
- Visible SWTools surfaces touched? yes/no
- COM / AssemblyName / registry identity touched? yes/no

## Commands run

## Machine-readable evidence

## Known limitations

## Rollback plan

## Production GO impact
- GO / NO-GO / not a release decision
```

## 5. Auditor rule

No PR in this track may weaken an existing gate unless it replaces it with an equivalent or stricter automated gate.

Production release may be approved only when the generated dossier proves the full chain:

```text
source inputs -> package -> installer -> SolidWorks live runtime -> BOM exports -> visual localization -> signing/provenance
```
