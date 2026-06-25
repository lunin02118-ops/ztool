# help_ru.chm acceptance

Дата: 2026-06-23
Scope: Sprint H visual/manual gate.

## Статус

`PENDING USER VISUAL AUDIT`

`help_ru.chm` присутствует в репозитории, но P4 acceptance требует проверки
видимого содержимого из runtime-кнопок помощи. Для H-01..H-03 route keys должны
указывать на ASCII-топики, реально существующие в пересобранном `help_ru.chm`.
Возврат старых Han-путей (`/进阶操作/...`, `/基本操作/...`) является регрессом.

## Текущий machine evidence

Дата: 2026-06-25

| Check | Result |
|---|---|
| `tools/chm-i18n/check_chm_brand.py help_ru.chm` | PASS: `ZTool` not found in CHM binary/decompiled text, `SWTools` found |
| `tools/chm-i18n/check_help_entry_routes.py --chm help_ru.chm` | PASS: H-01..H-03 source routes point to existing `advanced/...` / `basic/...` CHM topics |
| `docs/localization/HELP_ENTRY_VISUAL_SURFACES_H01_H03.json` | Profile ready: H-01..H-03 require captured `hh.exe` pages with page-specific Russian text markers |
| Visual L-12 direct open | PASS: `hh.exe` window title `SWTools — Руководство пользователя`, no visible `ZTool`, no Han |

Это закрывает прямой blocker `ZTool` в заголовке справки, но не заменяет полный
ручной визуальный аудит всех help entry points H-01..H-03 и screenshots.

## Обязательная проверка

| ID | Entry point | Expected |
|---|---|---|
| H-01 | Help button in `Frmexportbom` | Opens Russian page for BOM template/export. |
| H-02 | Help button in `FrmPreview` | Opens Russian page for thumbnail/preview operations. |
| H-03 | Help button in `FrmSaveOption` | Opens Russian page for saving data to SolidWorks. |
| H-04 | Direct open `help_ru.chm` | Table of contents/search show Russian user-facing text. |

## Автоматизированный visual profile для H-01..H-03

После открытия соответствующей формы и нажатия её кнопки справки снимайте
текущую страницу `hh.exe` отдельным surface:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\help-entry-visual\H-01 `
  --surface-file docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json `
  --surface-id H-01
```

Следующие кадры добавляются через `--merge-manifest`, как в общем L-01..L-15
pipeline. Итоговый manifest проверяется строго:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\help-entry-visual\H-03\visual-localization-manifest.json `
  --require-surface-file docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json `
  --require-profile-surfaces-captured
```

## PASS criteria

```text
[ ] CHM opens without security/crash dialog.
[ ] Visible page title/body is Russian.
[ ] No visible Chinese user-facing text on checked pages.
[ ] Images/screenshots are not dirty dev captures.
[ ] H-01..H-03 do not use legacy Han route keys.
```

## Evidence location

Manual screenshots/logs should be stored outside source history while being
reviewed, for example:

```text
_local_artifacts\reports\localization-sprint-h\help\
```

Only curated report text should be committed.
