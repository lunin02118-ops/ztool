# Отчет #89: full visual localization profile gate

Дата: 2026-06-25  
Ветка: `codex/e2e-visual-localization-full`  
Базовый main: `b02945f` (merge #88)  
Коммит проверки: `36b1f6a`

## Статус

Production GO: **NO-GO**.

Этот PR не заявляет visual FULL PASS. Цель слоя #89 - зафиксировать полный машинно-читаемый профиль поверхностей L-01..L-15 и заблокировать ложный PASS, если часть окон не была реально открыта и снята.

## Что добавлено

- Полный профиль визуальной локализации: `docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json`.
- Поддержка `process_names` и `text_contains` в `scripts/swtools_visual_localization_capture.py`.
- Проверка полного профиля в `tools/e2e/assert_visual_localization_manifest.py`:
  - `--require-surface-file`;
  - `--require-profile-surfaces-captured`.
- Negative self-test: неполный manifest с профилем из двух поверхностей должен падать.
- Документация обновлена: capture methodology, visual report, manual-test reports index, docs index.

## Проверки

Статические проверки:

```powershell
python -m py_compile scripts\swtools_visual_localization_capture.py tools\e2e\assert_visual_localization_manifest.py tools\e2e\selftest_assert_visual_localization_manifest.py
python tools\e2e\selftest_assert_visual_localization_manifest.py
python tools\secret_scan.py
git diff --check
```

Результат:

- `py_compile`: PASS.
- `selftest_assert_visual_localization_manifest.py`: PASS.
- `secret_scan.py`: PASS.
- `git diff --check`: PASS.

## Live S7 Evidence

Первый полный E2E-прогон S7+S8+branding на этой ветке был остановлен orchestrator timeout: S7 subprocess не записал `s7-live-smoke-result.json` за 180 секунд. Этот прогон **не засчитывается** как full E2E PASS.

После очистки процессов выполнен отдельный S7 rerun:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource -RunS7 -RequireSolidWorks `
  -SolidWorksExe 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe' `
  -SolidWorksToolsDll 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll' `
  -TestAssembly 'D:\Development\ztool\_local_artifacts\worktrees\pr89-visual-localization-full\TestModel\0614-A00.SLDASM' `
  -ExpectedMinRows 29 -ExpectedMinColumns 30 `
  -OutputDir _local_artifacts\reports\localization-full\e2e-s7-rerun-01
```

Результат:

- E2E status: `PASS_WITH_WARN`.
- `production_go_allowed=false`.
- S7 row count: `29`.
- S7 column count: `40`.
- `model_ready_gate.status=PASS`.
- `transient_dialog_count=5`.
- `waited_seconds=4.593`.

Assert:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\localization-full\e2e-s7-rerun-01\e2e-result.json `
  --allow-warn `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 07-s7-connect `
  --require-s7-model-ready `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30
```

Результат: PASS.

## Visual Capture Evidence

Capture выполнен против runtime из успешного S7 rerun:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-full\visual-capture-02 `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --expected-runtime-dir _local_artifacts\reports\localization-full\e2e-s7-rerun-01\package\SWTools-1.1.6\runtime
```

Manifest:

- `status=PASS_WITH_WARN`.
- `production_go_allowed=false`.
- profile surfaces: `15`.
- captured surfaces: `3`.
- blocking Han: `0`.
- runtime mismatches: `0`.

Captured:

- `L-01` Main window.
- `L-13` SolidWorks host.
- `L-15` Material/color flows entry surface.

Missing required surfaces:

- `L-02` License dialogs.
- `L-03` BOM export menu.
- `L-04` BOM scheme dialog.
- `L-05` Mapping dialog.
- `L-06` User rule editor.
- `L-07` Options dialog.
- `L-08` Save options.
- `L-09` Filling dialog.
- `L-10` Units dialog.
- `L-11` Context menus.
- `L-12` Help window.
- `L-14` Installer UI.

Non-strict validation:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-full\visual-capture-02\visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-runtime-match
```

Результат: PASS.

Strict full-profile validation:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-full\visual-capture-02\visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-profile-surfaces-captured `
  --require-runtime-match
```

Результат: expected FAIL на `L-02`, потому что полный ручной visual FULL PASS еще не выполнен. Это правильное поведение gate: неполный набор кадров не может быть принят как полный визуальный проход.

## Вывод

#89 готовит надежную основу для полного visual localization acceptance:

- профиль L-01..L-15 находится в репозитории;
- capture проверяет ожидаемый процесс и runtime;
- blocking Han и runtime mismatch валятся в validator;
- полный профиль нельзя случайно засчитать, пока не сняты все поверхности;
- production approval не заявляется.

Оставшаяся работа перед production GO:

1. Открыть и снять все L-02..L-14 surfaces.
2. Прогнать strict full-profile validation до PASS.
3. Выполнить ручной visual review скриншотов.
4. После этого переходить к signing/final release dossier и accepted hashes decision.
