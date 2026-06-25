# Visual opener progress: L-03/L-04/L-05/L-06

Дата: 2026-06-25

Статус: `PARTIAL VISUAL EVIDENCE / PRODUCTION GO: NO-GO / VISUAL FULL PASS: NO-GO`

## Контекст

После merge #95 запущен clean release E2E из отдельного runtime-пути без `ztool`
в видимых help/runtime URL:

```text
D:\SWToolsE2E\release-e2e-20260625-231119
```

Результат:

- wrapper status: `PASS`;
- S7: `PASS`, `29` строк, `40` колонок;
- S8: `PASS`, `8/8`;
- strict filters: `PASS`;
- branding/version/icon: `PASS`;
- `production_go_allowed=false`.

## Исправления в visual opener

### L-03/L-04/L-05: явный переход на вкладку `Спецификация`

Причина сбоя:

- opener для L-03/L-04/L-05 предполагал, что вкладка `Спецификация` уже активна;
- после S7 активной оставалась вкладка `Главная`;
- runner не находил `Экспорт спецификации`, `Настроить схему спецификации` и
  `Сопоставление заголовков столбцов`.

Исправление:

- в `docs/localization/VISUAL_LOCALIZATION_OPENERS_L01_L15.json` добавлен
  object-driven шаг `uia_invoke` по вкладке `Спецификация` перед L-03/L-04/L-05.

### Legacy LinkLabel support

Для `Создать правило` в L-06 WinForms отдаёт control как:

```text
class: WindowsForms10.STATIC...
type: System.Windows.Forms.LinkLabel
```

Сверка с текущим decompiled/source flow подтвердила старую рабочую логику:
`Frmexportbom.LinkLabel1_LinkClicked` сразу открывает `FrmFilterrules`; промежуточного
prompt здесь быть не должно. У такого `LinkLabel` нет UIA Invoke/Expand/Select и
нет IAccessible default action; прямой `WM_LBUTTONDOWN/UP` по HWND тоже не вызывает
managed `LinkClicked`.

Runner теперь поддерживает object-located keyboard activation: control находится по
process/window/text/class, получает фокус, затем отправляется `{ENTER}`. Это не
screen coordinate click и соответствует живому WinForms-поведению LinkLabel.

## Live evidence

### L-03 BOM export menu

```text
D:\SWToolsE2E\visual-capture-20260625-232148-L03-retry
```

Результат:

- opener: `PASS`;
- action: `Спецификация` selected via UIA;
- action: `Экспорт спецификации` expanded;
- manifest assertion: `PASS`;
- screenshot: `L-03-BOM-export-menu.png`;
- visible legacy brand token: none;
- visible Han: none;
- runtime path match: true.

### L-04 BOM scheme dialog

```text
D:\SWToolsE2E\visual-capture-20260625-232610-L04
```

Результат:

- opener: `PASS`;
- dialog: `Настроить схему спецификации`;
- screenshot: `L-04-BOM-scheme-dialog.png`;
- visible legacy brand token: none;
- visible Han: none;
- runtime path match: true.

### L-05 column mapping dialog

```text
D:\SWToolsE2E\visual-capture-20260625-232610-L05
```

Результат:

- opener: `PASS`;
- dialog: `Сопоставление заголовков столбцов`;
- duplicate-name modal: not present;
- screenshot: `L-05-Column-mapping-dialog.png`;
- visible legacy brand token: none;
- visible Han: none;
- runtime path match: true.

### L-06 user rule editor

Успешный прогон после фикса:

```text
D:\SWToolsE2E\visual-capture-20260626-000705-L04-L06-key
```

Результат:

- opener: `PASS`;
- action: `Создать правило` activated via `keyboard:{ENTER}` after object lookup;
- dialog: `Пользовательское правило`;
- manifest assertion: `PASS_WITH_WARN` because only L-06 is required in this
  partial run;
- screenshot: `L-06-User-rule-editor.png`;
- visible legacy brand token: none;
- visible Han: none;
- runtime path match: true;
- screenshot SHA256: `09D64344363F746CD96C3FCA0391061916094430B4273037051E5B36862CF2B9`.

## Remaining blocker

L-06 automation blocker is closed. Full visual FULL PASS is still not claimed:
L-02 and L-07..L-15 need separate live capture/evidence and owner/auditor review.

## Проверки

```powershell
python -m py_compile scripts\swtools_visual_opener_capture.py
python scripts\swtools_visual_opener_capture.py --self-test
python tools\e2e\check_visual_opener_profile.py docs\localization\VISUAL_LOCALIZATION_OPENERS_L01_L15.json --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json
python tools\e2e\assert_visual_localization_manifest.py D:\SWToolsE2E\visual-capture-20260625-232148-L03-retry\L-03\visual-localization-manifest.json --allow-warn --require-surface L-03 --require-runtime-match --require-opener-evidence
python tools\e2e\assert_visual_localization_manifest.py D:\SWToolsE2E\visual-capture-20260626-000705-L04-L06-key\L-06\visual-localization-manifest.json --allow-warn --require-surface L-06 --require-runtime-match --require-opener-evidence
```

Результат: `PASS`.

## Вывод

Закрыт следующий automation regression layer:

- S7 live release E2E снова стабильно проходит;
- L-03/L-04/L-05 теперь открываются object-driven, без зависимости от активной вкладки;
- L-06 теперь открывается object-driven через WinForms LinkLabel focus + Enter;
- `Сопоставление заголовков столбцов` больше не падает на duplicate-name modal в этом сценарии.

Полный visual FULL PASS ещё не заявляется: L-02 и оставшиеся поверхности
L-07..L-15 требуют отдельного live evidence.
