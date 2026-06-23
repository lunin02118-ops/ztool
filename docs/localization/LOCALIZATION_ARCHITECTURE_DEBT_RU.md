# Localization architecture debt

Дата: 2026-06-23
Scope: Sprint H / P4 localization closure.

## Статус

`PARTIAL PASS / USER VISUAL AUDIT REQUIRED`

Автоматический gate на текущем `SWTools.exe` проходит:

```text
han_entries: 78
unclassified_han: 0
translation diagnostics: 0 errors, 0 warnings
categories:
  protocol_key: 35 occurrences
  font_name: 27 occurrences
  known_remaining: 16 occurrences
```

Это доказывает только machine-readable классификацию Han-строк в runtime. Это
не заменяет визуальный аудит окон, help и installer.

## P1: architecture map

Authoritative inputs:

- `client-core/tools/Localizer/translations.tsv` — таблица переводов;
- `localization/whitelist_protocol_keys.txt` — точные protocol/crypto keys;
- `localization/whitelist_font_names.txt` — имена шрифтов;
- `localization/whitelist_technical_logs.txt` — diagnostic/log tokens;
- `localization/whitelist_known_chinese_remaining.txt` — legacy internal debt;
- `client-core/tools/localization_scan.py` — machine-readable gate;
- `docs/localization/UI_SCREENSHOT_CHECKLIST_RU.md` — ручной visual gate.

Runtime surfaces:

- main `SWTools.exe` WinForms UI;
- binary/runtime resources;
- SolidWorks add-in UI;
- `help_ru.chm`;
- NSIS installer UI;
- release docs/screenshots.

Out of scope for this PR:

- application source/runtime behavior changes;
- translating semantic protocol keys;
- changing help routing without full producer/consumer parity;
- claiming visual FULL PASS without user screenshots.

## P2: concrete trace

Путь проверки:

```text
SWTools.exe
  -> Localizer --scan / --scanres
  -> localization_scan.py
  -> translations.tsv lookup
  -> exact whitelist lookup
  -> JSON report
  -> fail if diagnostics errors or unclassified_han > 0
```

Source of truth: `localization_scan.py` report plus exact whitelist files.

Error paths:

- Han string without translation and without exact whitelist entry -> blocker;
- translated protocol/font key -> blocker;
- duplicate translation source -> blocker;
- visible Han found by manual screenshot audit -> blocker even if scan category is
  `known_remaining`.

## P3: design decision

Не переименовывать internal semantic keys по одному месту. Пример: `零件`
является mixed literal: он уже глобально переводится через `translations.tsv`
для user-facing контекстов, но отдельные runtime-контексты в `Frmmain`
используют тот же source literal как material/color part-kind key. Source-level
cleanup этого ключа можно делать только отдельным PR, где producer и consumer
меняются вместе и закрываются parity test. Half-rename ломает material/color
flows и уже приводил к регрессиям.

Sprint H поэтому разделяет:

- user-facing strings -> translate/fix immediately;
- protocol/crypto keys -> exact whitelist only;
- font names -> exact whitelist only;
- internal legacy component/resource/help-path names -> architecture debt until
  source-level migration.

## Current known remaining Han

| Entry | Layer | Context | Decision |
|---|---|---|---|
| `零件` | mixed UI/runtime semantic key | `Frmmain` material/color flows plus user-facing file/type contexts | Global UI translation already exists; internal semantic contexts remain architecture debt until producer/consumer parity test exists. |
| `工具箱.png` | resource name | `toolbox::InitializeComponent` | Internal resource asset name; not user-facing caption. |
| `平铺ToolStripMenuItem`, `小图标ToolStripMenuItem`, `列表ToolStripMenuItem`, `列表ToolStripMenuItem1` | WinForms component names | `toolbox` | Internal control names; captions must be verified visually. |
| `在solidworks中打开ToolStripMenuItem`, `在文件夹中打开ToolStripMenuItem`, `修改ToolStripMenuItem` | WinForms component names | `FrmReplacePartslist` | Internal control names; visible context menu captions require screenshot audit. |
| `/进阶操作/BOM表模板制作和导出.htm`, `/进阶操作/缩略图显示及操作.htm`, `/基本操作/保存数据到SolidWorks.htm` | help routing paths | help buttons | Internal legacy CHM paths; `help_ru.chm` visible content requires manual check. |

## Required manual evidence before production GO / visual FULL PASS

Manual audit must confirm:

```text
[ ] No visible Han in main UI/ribbon/table.
[ ] No visible Han in registration/license forms.
[ ] No visible Han in BOM forms and mapping dialogs.
[ ] No visible Han in context menus for known `ToolStripMenuItem` debt.
[ ] `help_ru.chm` opens and shows Russian content from help buttons.
[ ] Installer UI has no Han.
[ ] No critical clipping/overlap on resizable dialogs.
[ ] Material/color actions still work after localized `零件` UI strings are present.
```

Until those screenshots are reviewed by the user, R-011 remains P1 partial.
