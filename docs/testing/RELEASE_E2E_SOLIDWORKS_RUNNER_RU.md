# Self-hosted SolidWorks release E2E

Status: workflow ready / live runner execution pending

Production GO: NO-GO

## Назначение

`release-e2e-solidworks.yml` запускается только вручную через
`workflow_dispatch` на runner с labels:

```text
self-hosted, windows, solidworks, swtools-release
```

GitHub-hosted runners не используются: живой S7/S8 требует SolidWorks,
COM-регистрацию add-in и интерактивный Windows desktop.

## Обязательные входы runner

Можно передать через workflow inputs или env runner:

```text
SOLIDWORKS_EXE
SOLIDWORKS_DIR
SOLIDWORKS_TOOLS_DLL
SWTOOLS_TEST_MODEL
```

`SWTOOLS_TEST_MODEL` должен указывать на `.SLDASM` fixture. Для release run
ожидается модель с минимально 29 строками и 30 колонками после S7.

## Что делает workflow

1. Собирает release inputs из source.
2. Собирает и проверяет package.
3. Регистрирует runtime add-in через preflight.
4. Готовит strict BOM fixture.
5. Прогоняет S7 live connect.
6. Прогоняет S8 BOM 8/8 со strict filters.
7. Проверяет branding/version/icon live evidence.
8. Проверяет cumulative visual manifest L-01..L-15, если включён
   `require_visual_full_profile`.
9. Загружает evidence artifact.

Wrapper:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsReleaseE2E.ps1 `
  -SolidWorksExe "$env:SOLIDWORKS_EXE" `
  -SolidWorksDir "$env:SOLIDWORKS_DIR" `
  -SolidWorksToolsDll "$env:SOLIDWORKS_TOOLS_DLL" `
  -TestAssembly "$env:SWTOOLS_TEST_MODEL" `
  -VisualManifest "<cumulative-visual-manifest>" `
  -RequireVisualFullProfile
```

## Visual manifest

`RequireVisualFullProfile=true` требует готовый cumulative manifest:

```text
visual-localization-manifest.json
```

Он должен пройти:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-profile-surfaces-captured `
  --require-runtime-match `
  --require-opener-evidence
```

Если manifest отсутствует, workflow обязан упасть. Это сделано намеренно:
нельзя выдать production-ready E2E без L-01..L-15 visual evidence.

## Machine acceptance

Workflow считается machine PASS только если:

- `release-e2e-solidworks-result.json.status = PASS`;
- `production_go_allowed = false`;
- S7/S8/branding assertions прошли;
- visual full-profile assertion прошёл, если включён `RequireVisualFullProfile`.

## Что это не доказывает

- Это не owner GO.
- Это не signing/final dossier.
- Это не accepted hash promotion.
- Это не ручной visual review, если он требуется аудитором поверх machine gates.
