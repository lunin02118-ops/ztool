# R2 Visual Opener Harness Report

Date: 2026-06-25

Status: PROFILE/GATE READY

Production GO: NO-GO

Visual FULL PASS: NO-GO

## Scope

Этот PR добавляет проверяемый object-driven contract для открытия кадров
визуальной локализации L-01..L-15.

Runtime/application behavior не менялся.

## Что закрыто

- Добавлен профиль `docs/localization/VISUAL_LOCALIZATION_OPENERS_L01_L15.json`.
- Для каждого L-кадра задано, каким объектным действием его открывать.
- Координатные клики и screen-coordinate поля запрещены profile gate.
- Capture manifest может включать opener evidence рядом с каждым кадром.
- Strict manifest assertion может требовать `--require-opener-evidence`.

## Машинные gates

- `tools/e2e/check_visual_opener_profile.py --self-test`
- `tools/e2e/check_visual_opener_profile.py docs/localization/VISUAL_LOCALIZATION_OPENERS_L01_L15.json --surface-file docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json`
- `tools/e2e/selftest_assert_visual_localization_manifest.py`
- `scripts/swtools_visual_localization_capture.py --opener-file ...`

## Что остаётся

- Реальный full capture L-01..L-15 ещё не выполнен.
- Pixel/visual review owner/auditor ещё не выполнен.
- Production GO нельзя ставить до full visual PASS, signing, финального dossier и accepted hashes decision.
