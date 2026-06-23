# help_ru.chm acceptance

Дата: 2026-06-23
Scope: Sprint H visual/manual gate.

## Статус

`PENDING USER VISUAL AUDIT`

`help_ru.chm` присутствует в репозитории, но P4 acceptance требует проверки
видимого содержимого из runtime-кнопок помощи. Наличие внутренних legacy paths с
Han (`/进阶操作/...`, `/基本操作/...`) не считается автоматическим FAIL, если они
используются только как route keys и открывают русские страницы.

## Обязательная проверка

| ID | Entry point | Expected |
|---|---|---|
| H-01 | Help button in `Frmexportbom` | Opens Russian page for BOM template/export. |
| H-02 | Help button in `FrmPreview` | Opens Russian page for thumbnail/preview operations. |
| H-03 | Help button in `FrmSaveOption` | Opens Russian page for saving data to SolidWorks. |
| H-04 | Direct open `help_ru.chm` | Table of contents/search show Russian user-facing text. |

## PASS criteria

```text
[ ] CHM opens without security/crash dialog.
[ ] Visible page title/body is Russian.
[ ] No visible Chinese user-facing text on checked pages.
[ ] Images/screenshots are not dirty dev captures.
[ ] If a legacy Han route fails to open a Russian page, it is a blocker.
```

## Evidence location

Manual screenshots/logs should be stored outside source history while being
reviewed, for example:

```text
_local_artifacts\reports\localization-sprint-h\help\
```

Only curated report text should be committed.
