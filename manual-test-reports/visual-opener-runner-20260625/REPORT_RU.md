# Visual opener runner evidence 2026-06-25

Status: TOOLING PASS / FULL VISUAL PROFILE PENDING

Production GO: NO-GO

Visual FULL PASS: NO-GO

## Scope

Этот отчёт фиксирует следующий слой после `release-e2e-solidworks`: добавлен
исполняемый runner для object-driven opening L-01..L-15 surfaces перед
`swtools_visual_localization_capture.py`.

Runner не меняет runtime/product behavior. Он нужен, чтобы visual evidence не
собирался кликами по координатам и чтобы невозможность открыть surface была
машинным `FAIL`, а не ручной догадкой.

## Изменения

- Добавлен `scripts/swtools_visual_opener_capture.py`.
- Runner читает `docs/localization/VISUAL_LOCALIZATION_OPENERS_L01_L15.json`.
- Поддержаны object-driven action types:
  - `e2e_stage` as external precondition evidence;
  - `uia_invoke` / `win32_invoke`;
  - `ribbon_command`;
  - `wait_window`;
  - `help_button`;
  - `solidworks_com`;
  - `installer_launch`;
  - `context_menu` through focused UIA element and `Shift+F10`, without screen coordinates.
- Runner вызывает `scripts/swtools_visual_localization_capture.py` после каждой
  surface and merges cumulative manifests.
- `release-acceptance.yml` запускает runner self-test.
- `docs/localization/VISUAL_LOCALIZATION_CAPTURE_RU.md` обновлён командой runner.

## Checks

```text
python -m py_compile scripts\swtools_visual_opener_capture.py
python scripts\swtools_visual_opener_capture.py --self-test
```

Result:

```text
Visual opener capture runner self-test PASS
```

## Live L-13 evidence

Machine: local Windows/SolidWorks 2025 host.

Command:

```powershell
python scripts\swtools_visual_opener_capture.py `
  --output-dir D:\Development\ztool\_local_artifacts\reports\visual-opener-runner-20260625-L13-pass `
  --surface-id L-13 `
  --timeout 20
```

Result:

```text
status: PASS
production_go_allowed: false
surface: L-13 SolidWorks add-in host
SolidWorks PID: 8068
addin_progid: ZTool.SwAddin
addin_available: true
expected_tab_text: SWTools
expected_tab_visible: true
capture_returncode: 0
visible_han_texts: []
forbidden_texts: []
screenshot_sha256: EC571AF8B388C69E010C71EE2EFA2D39B27A89C9D108AF360356E7D6CFF1A18C
```

Manifest assertion:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  D:\Development\ztool\_local_artifacts\reports\visual-opener-runner-20260625-L13-pass\L-13\visual-localization-manifest.json `
  --allow-warn `
  --require-surface L-13 `
  --require-opener-evidence
```

```text
Visual localization assertion PASS: status=PASS, surfaces=1, required=1
```

Raw evidence is intentionally kept outside Git:

```text
D:\Development\ztool\_local_artifacts\reports\visual-opener-runner-20260625-L13-pass\
```

## Known pending work

- Full L-01..L-15 cumulative visual manifest is still pending.
- L-01 requires a clean S7-prepared SWTools runtime session. A quick attempt in
  the already-open SolidWorks session was not used as evidence because the
  active model path did not match the requested test model and SolidWorks COM
  returned open errors. This is a setup mismatch, not a product PASS.
- Help entry H-01..H-03 live visual capture remains separate.
- Owner/auditor visual review remains required after strict machine manifest
  PASS.

## Acceptance state

- Runner self-test: PASS.
- L-13 object-driven live capture: PASS.
- Full visual profile L-01..L-15: PENDING.
- Production GO: NO-GO.
