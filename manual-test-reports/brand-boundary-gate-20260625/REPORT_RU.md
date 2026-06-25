# Отчёт: R1 brand-boundary gate и release-hardening input resolution

Дата: 2026-06-25
Ветка: `codex/p4-brand-boundary-gate`
База: `advisor/r0-refactor-architecture-start`

## Статус

- Production GO: NO-GO.
- Visual FULL PASS: NO-GO.
- Runtime/product behavior: не менялось.

## Что закрыто

1. Добавлен gate `tools/check_visible_brand_boundary.py`.
2. Добавлен baseline `tools/brand_boundary/allowed_internal_ztool.tsv`.
3. `release-acceptance.yml` запускает:
   - `python tools/check_visible_brand_boundary.py --self-test`;
   - `python tools/check_visible_brand_boundary.py`.
4. `release-hardening.yml` теперь явно вызывает `scripts/resolve_release_inputs.ps1` перед упаковкой и передаёт в `build_release_package.ps1` именно resolved source-built `SWTools.exe` / `SWTools.dll`.

## Смысл gate

Публичный бренд должен быть `SWTools`.

Legacy token `ZTool` допускается только как зафиксированная internal compatibility surface: assembly/resource/COM/protocol/source-layout/history. Любое новое или изменённое вхождение требует обновления allowlist и становится видимым для review.

## Локальные проверки

PASS:

```powershell
python tools\check_visible_brand_boundary.py --self-test
python tools\check_visible_brand_boundary.py
python tools\check_source_string_invariants.py --root client-src --root client-src-addin
python tools\secret_scan.py
git diff --check
```

PASS:

```powershell
pwsh -NoProfile -File scripts\check_client_src_warnings.ps1
pwsh -NoProfile -File scripts\check_expected_release_hashes.ps1 -ReportPath _local_artifacts\reports\brand-boundary-expected-release-hashes.json
```

PASS with expected dirty-manifest dry-run exception:

```powershell
pwsh -NoProfile -File scripts\resolve_release_inputs.ps1 -OutputPath _local_artifacts\reports\brand-boundary-release-hardening\release-inputs.json
pwsh -NoProfile -File scripts\build_release_package.ps1 -Version 1.1.6 -OutputRoot _local_artifacts\reports\brand-boundary-release-hardening\package -ClientExe <resolved> -AddinDll <resolved> -AllowMissingSolidWorksTools
pwsh -NoProfile -File scripts\verify_release_package.ps1 -PackageRoot _local_artifacts\reports\brand-boundary-release-hardening\package\SWTools-1.1.6 -ExpectedClientExeSha256 <actual> -ExpectedAddinDllSha256 <actual> -AllowDirtyManifest
```

PASS:

```powershell
pwsh -NoProfile -File scripts\build_client_installer.ps1 -PackageRoot _local_artifacts\reports\brand-boundary-release-hardening\package\SWTools-1.1.6 -OutputDir _local_artifacts\reports\brand-boundary-release-hardening\installer
```

Installer smoke SHA256:

```text
0481E9E6AEC89CBC23145C76C41D9AC9243AB8AA823472EDC2647A634EE7D616
```

YAML parse: PASS for all `.github/workflows/*.yml`.

## Остаточный риск

- `-AllowDirtyManifest` использовался только локально, потому что PR worktree содержит незакоммиченные изменения. Production verification must run from a clean exact commit without `-AllowDirtyManifest`.
- `SolidWorksTools.dll` в локальном dry-run package был пропущен через `-AllowMissingSolidWorksTools`; production package must include real `SolidWorksTools.dll`.
- Gate не заменяет visual L-01..L-15 acceptance. Он блокирует drift видимого legacy brand на tracked text/path surfaces и делает изменения явными для review.
