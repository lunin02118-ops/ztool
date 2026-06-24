# Отчет #90: cumulative visual localization capture

Дата: 2026-06-25  
Ветка: `codex/e2e-visual-localization-capture-full`  
Базовый main: `cc043bf` (merge #89)  
Коммит test-tooling: `4f1131a`

## Статус

Production GO: **NO-GO**.  
Visual FULL PASS: **NO-GO**.

Цель #90 изменилась по фактическому результату проверки: полный L-01..L-15
capture не может быть принят, потому что найден реальный visual blocker в help:
видимый старый бренд `ZTool`.

## Что изменено

- `scripts/swtools_visual_localization_capture.py` получил накопительный режим:
  - `--surface-id` для съёмки конкретной surface;
  - `--merge-manifest` для добавления нового кадра в уже существующий manifest;
  - защита от merge между разными `expected-runtime-dir`;
  - сохранение предыдущего `CAPTURED` кадра, если повторная попытка surface не нашла окно.
- Профиль `docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json` получил глобальный `forbidden_text: ["ZTool"]`.
- Capture и validator теперь валят manifest, если в видимом UI-тексте есть forbidden text.
- Self-test расширен:
  - incomplete profile still fails;
  - cumulative merge preserves already captured evidence;
  - forbidden `ZTool` text is rejected.
- Методика обновлена: полный visual evidence собирается последовательно, а не попыткой держать все modal dialogs открытыми одновременно.

Product/runtime source не менялся.

## Static checks

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

## Live S7 evidence

Первый live attempt был корректно заблокирован package gate:

- причина: `manifest git.dirty=true`;
- вывод: live package нельзя проверять из грязной ветки.

После коммита test-tooling выполнен clean S7 run:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource -RunS7 -RequireSolidWorks `
  -SolidWorksExe 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe' `
  -SolidWorksToolsDll 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll' `
  -TestAssembly 'D:\Development\ztool\_local_artifacts\worktrees\pr90-visual-localization-capture-full\TestModel\0614-A00.SLDASM' `
  -ExpectedMinRows 29 -ExpectedMinColumns 30 `
  -OutputDir _local_artifacts\reports\localization-full-capture\e2e-s7-02
```

Результат:

- E2E status: `PASS_WITH_WARN`.
- `production_go_allowed=false`.
- S7 row count: `29`.
- S7 column count: `40`.
- `model_ready_gate.status=PASS`.

Assert:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\localization-full-capture\e2e-s7-02\e2e-result.json `
  --allow-warn `
  --require-stage-pass 05-preflight-register `
  --require-stage-pass 07-s7-connect `
  --require-s7-model-ready `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30
```

Результат: PASS.

## Visual capture evidence

### Captured baseline surfaces

Команда:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-full-capture\visual-L01-L13-L15 `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --surface-id L-01 --surface-id L-13 --surface-id L-15 `
  --expected-runtime-dir _local_artifacts\reports\localization-full-capture\e2e-s7-02\package\SWTools-1.1.6\runtime
```

Результат:

- `status=PASS`.
- Captured: `L-01`, `L-13`, `L-15`.
- Blocking Han: `0`.
- Runtime mismatch: `0`.

### Help surface L-12

Runtime package содержит файл `runtime\help.CHM`; отдельного `help_ru.chm` рядом с runtime нет.

Команда:

```powershell
Start-Process _local_artifacts\reports\localization-full-capture\e2e-s7-02\package\SWTools-1.1.6\runtime\help.CHM

python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-full-capture\visual-L12-forbidden `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --surface-id L-12 `
  --merge-manifest _local_artifacts\reports\localization-full-capture\visual-L01-L13-L15\visual-localization-manifest.json `
  --expected-runtime-dir _local_artifacts\reports\localization-full-capture\e2e-s7-02\package\SWTools-1.1.6\runtime
```

Результат:

- Exit code: `1`.
- Manifest status: `FAIL`.
- Captured count: `4`.
- `forbidden_text_surface_ids=["L-12"]`.
- Window title: `ZTool — Руководство пользователя`.

Validator:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-full-capture\visual-L12-forbidden\visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-runtime-match
```

Результат: expected FAIL (`manifest status is FAIL`).

## Не засчитано

- `L-03` BOM export menu не был снят в этом run: trial SWTools window успело закрыться до попытки раскрытия меню. Это не засчитывается как дефект product runtime; это ограничение live automation timing/trial state.
- `L-02`, `L-03`, `L-04`, `L-05`, `L-06`, `L-07`, `L-08`, `L-09`, `L-10`, `L-11`, `L-14` остаются missing в итоговом visual evidence.

## Вывод

#90 закрывает не visual FULL PASS, а следующий обязательный слой качества:

- полный visual profile теперь можно собирать по кадрам;
- неполный набор кадров не может стать FULL PASS;
- old-brand `ZTool` теперь machine blocker;
- live S7 перед capture подтвержден на реальном SolidWorks;
- найден реальный blocker в `help.CHM`: заголовок `ZTool — Руководство пользователя`.

Следующая работа:

1. Исправить help branding/provenance: `ZTool` -> `SWTools` в CHM title/content.
2. Подготовить opener harness или активированное/длинное live session состояние для последовательной съёмки `L-02..L-11` и `L-14`.
3. Дособрать cumulative manifest до 15/15.
4. Прогнать strict full-profile validator до PASS.
5. Перед production GO выполнить ручной visual owner/auditor review.
