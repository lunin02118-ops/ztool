# Localization manual evidence

Этот каталог предназначен для curated summary reports. Сырые скриншоты,
видео, логи, временные HTML/JSON и большие evidence packs хранить в
`_local_artifacts\reports\localization-sprint-h\` до финального отбора.

## Перед production GO / visual FULL PASS

Пользовательский аудит обязателен. Минимальный набор кадров:

```text
L-01-main-window.png
L-02-license-dialogs.png
L-03-bom-menu-8-modes.png
L-04-frmexportbom.png
L-05-frmmapping.png
L-06-filter-rules.png
L-07-options-tabs.png
L-08-save-options.png
L-09-filling-tabs.png
L-10-units.png
L-11-context-menus.png
L-12-help-ru.png
L-13-solidworks-addin.png
L-14-installer-ui.png
L-15-material-color-flows.png
```

## Формат итогового отчёта

```text
Build/hash:
Operator:
Date:
Automated localization scan:
Screenshots reviewed:
Findings:
Decision: PASS / FAIL / PASS WITH EXCEPTIONS
```

Не коммитить private keys, license codes, server endpoints, customer data or
private approvals in screenshots.

## Automated capture helper

For live S7/S8/branding builds, collect curated screenshot evidence with:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-YYYYMMDD-HHMM `
  --expected-runtime-dir <runtime-dir>
```

Для полного L-01..L-15 пакета:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full-YYYYMMDD-HHMM `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --expected-runtime-dir <runtime-dir> `
  --require-all-captured
```

Для модальных окон используйте накопительный режим: откройте конкретный диалог,
снимите одну surface через `--surface-id`, затем добавляйте следующий кадр через
`--merge-manifest`. Итоговый manifest проверяется тем же strict full-profile
validator, поэтому частичный набор кадров не может стать FULL PASS.

Then validate the manifest:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-YYYYMMDD-HHMM\visual-localization-manifest.json `
  --allow-warn `
  --require-surface L-01 `
  --require-surface L-13 `
  --require-runtime-match
```

Strict full-profile validation:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-full-YYYYMMDD-HHMM\visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-profile-surfaces-captured `
  --require-runtime-match
```

The helper does not replace owner visual review. It proves screenshot identity,
runtime identity and absence of blocking Han in captured UIA text. Host
SolidWorks Han in `record_only` surfaces remains warning evidence for manual
review.

## Help entry points H-01..H-03

После #92 route-contract проверяется машинно, но live visual evidence по
кнопкам справки собирается отдельно:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\help-entry-visual\H-01 `
  --surface-file docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json `
  --surface-id H-01

python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\help-entry-visual\H-03\visual-localization-manifest.json `
  --require-surface-file docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json `
  --require-profile-surfaces-captured
```

H-01/H-02/H-03 должны быть открыты именно через Help-кнопки соответствующих
runtime-форм. Прямое открытие `help.CHM` закрывает только H-04/L-12.
