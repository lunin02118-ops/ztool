# Visual opener progress: L-03/L-04/L-05

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

У такого элемента нет UIA Invoke/Expand/Select и нет IAccessible default action.
Runner теперь умеет fallback `win32_message_click`: control находится по
process/window/text/class, после чего мышиные сообщения отправляются в его HWND,
без экранных координат. Это всё ещё object-located действие, не screen coordinate click.

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
- visible `ZTool`: none;
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
- visible `ZTool`: none;
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
- visible `ZTool`: none;
- visible Han: none;
- runtime path match: true.

## Remaining blocker

### L-06 user rule editor

Attempt:

```text
D:\SWToolsE2E\visual-capture-20260625-233049-L04-L06
```

Результат:

- L-04 captured again: `PASS`;
- L-06: `FAIL`;
- after clicking `Создать правило`, expected window
  `Пользовательское правило` did not appear.

Наблюдение:

- WinForms exposes `Создать правило` as LinkLabel/static control;
- object-located `win32_message_click` is now implemented, but current live flow
  still does not reach the rule editor;
- no coordinate click was used or counted as evidence.

Следующий шаг:

1. Сверить фактический old/CN рабочий flow L-06: возможно, `Создать правило`
   сначала должен открыть prompt for rule name, then editor.
2. Зафиксировать that two-step flow in opener profile, or add a dedicated
   object-driven action for the intermediate prompt.
3. Повторить L-06 capture.

## Проверки

```powershell
python -m py_compile scripts\swtools_visual_opener_capture.py
python scripts\swtools_visual_opener_capture.py --self-test
python tools\e2e\check_visual_opener_profile.py docs\localization\VISUAL_LOCALIZATION_OPENERS_L01_L15.json --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json
python tools\e2e\assert_visual_localization_manifest.py D:\SWToolsE2E\visual-capture-20260625-232148-L03-retry\L-03\visual-localization-manifest.json --allow-warn --require-surface L-03 --require-runtime-match --require-opener-evidence
```

Результат: `PASS`.

## Вывод

Закрыт следующий automation regression layer:

- S7 live release E2E снова стабильно проходит;
- L-03/L-04/L-05 теперь открываются object-driven, без зависимости от активной вкладки;
- `Сопоставление заголовков столбцов` больше не падает на duplicate-name modal в этом сценарии.

Полный visual FULL PASS ещё не заявляется: L-06 и оставшиеся поверхности L-02,
L-07..L-15 требуют отдельного live evidence.
