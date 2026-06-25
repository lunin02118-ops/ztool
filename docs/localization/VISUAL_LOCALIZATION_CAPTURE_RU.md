# Visual localization capture gate

Scope: E2E evidence layer after S7/S8/branding gates.

Этот слой не заменяет ручной visual FULL PASS. Он автоматически собирает
проверяемые кадры, process/runtime identity и UIA-текст, чтобы не принять
грязный или снятый не с того билда скриншот.

## Команда

После живого E2E-прогона, когда `SWTools.exe` и SolidWorks остаются открыты:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-YYYYMMDD-HHMM `
  --expected-runtime-dir <runtime-dir>
```

Для release/owner evidence, где L-01/L-13 должны быть сняты обязательно:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-YYYYMMDD-HHMM `
  --expected-runtime-dir <runtime-dir> `
  --require-all-captured
```

Для полного release evidence L-01..L-15 используется профиль из репозитория:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full-YYYYMMDD-HHMM `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --opener-file docs\localization\VISUAL_LOCALIZATION_OPENERS_L01_L15.json `
  --expected-runtime-dir <runtime-dir> `
  --require-all-captured
```

`VISUAL_LOCALIZATION_OPENERS_L01_L15.json` фиксирует object-driven способ
открытия каждого кадра. В нём запрещены координатные клики и любые
screen-coordinate поля. Если поведение расходится с ожидаемым, сначала
сверяется opener contract и фактический UI путь, а не подбираются координаты.

Если окна нельзя держать открытыми одновременно (обычные modal WinForms
диалоги), кадры собираются накопительно. Сначала снимается первая открытая
surface, затем следующий прогон мержится в предыдущий manifest:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full\L-04 `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --opener-file docs\localization\VISUAL_LOCALIZATION_OPENERS_L01_L15.json `
  --surface-id L-04 `
  --expected-runtime-dir <runtime-dir>

python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full\L-05 `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --opener-file docs\localization\VISUAL_LOCALIZATION_OPENERS_L01_L15.json `
  --surface-id L-05 `
  --merge-manifest _local_artifacts\reports\localization-visual-full\L-04\visual-localization-manifest.json `
  --expected-runtime-dir <runtime-dir>
```

`--merge-manifest` разрешён только для того же `expected-runtime-dir`. Если
повторная попытка surface не нашла окно, но предыдущий manifest уже содержит
`CAPTURED`, предыдущий кадр сохраняется, а попытка записывается в
`last_attempt_status`. Это не даёт случайно потерять доказательство, но strict
validator всё равно требует, чтобы итоговая surface была `CAPTURED`.

## Object-driven opener runner

Для повторяемой съёмки без координатных кликов используйте runner, который
читает `VISUAL_LOCALIZATION_OPENERS_L01_L15.json`, выполняет только
object-driven действия (`uia_invoke`, `ribbon_command`, `wait_window`,
`context_menu` через фокусированный UIA-элемент и `Shift+F10`) и после каждого
кадра запускает capture с cumulative merge:

```powershell
python scripts\swtools_visual_opener_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full-YYYYMMDD-HHMM `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --opener-file docs\localization\VISUAL_LOCALIZATION_OPENERS_L01_L15.json `
  --expected-runtime-dir <runtime-dir> `
  --surface-id L-04 `
  --surface-id L-06
```

Если действие нельзя выполнить через объект UIA/COM/процесс, runner должен
завершиться с `FAIL`; подбирать экранные координаты запрещено. Результат
runner (`visual-opener-capture-result.json`) является technical evidence о
способе открытия, но visual FULL PASS всё равно требует итоговый manifest,
strict validator и ручной owner/auditor review кадров.

Проверка manifest:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-YYYYMMDD-HHMM\visual-localization-manifest.json `
  --allow-warn `
  --require-surface L-01 `
  --require-surface L-13 `
  --require-runtime-match
```

Строгая проверка полного профиля:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\localization-visual-full-YYYYMMDD-HHMM\visual-localization-manifest.json `
  --allow-warn `
  --require-surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --require-profile-surfaces-captured `
  --require-runtime-match `
  --require-opener-evidence
```

Для отдельных help entry points H-01..H-03 используется профиль:

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

Каждая surface должна быть получена после нажатия Help-кнопки соответствующей
runtime-формы, а не прямым открытием `help.CHM`. Профиль требует уникальные
русские marker-фразы страницы, поэтому случайно открытая другая тема справки не
проходит strict validation.

Для H-01..H-03 профиль также требует `process=SWTools.exe` и
`class_name_contains=HH Parent`. Это отражает реальное runtime-поведение
HTML Help: Help-кнопки WinForms открывают страницу справки в окне класса
`HH Parent`, которое принадлежит процессу `SWTools.exe`. Прямое ручное
открытие CHM через оболочку может создать `hh.exe`, но такой кадр не считается
evidence для runtime entry point.

`--allow-warn` разрешает частичный evidence-пакет только если нет blocking Han и
нет runtime mismatch. Глобальный `forbidden_text` в профиле L-01..L-15 сейчас
запрещает visible `ZTool`: старый бренд в окне, help или installer является
machine FAIL. `PASS_WITH_WARN` не является production approval.

Default surface policy:

| Surface | Han policy | Reason |
|---|---|---|
| L-01 `SWTools.exe` | `fail` | Это основной пользовательский UI SWTools; видимый Han здесь blocker. |
| L-13 SolidWorks host | `record_only` | Whole-window capture может включать дерево модели/host UI SolidWorks, не принадлежащее SWTools. Такие Han строки записываются в manifest и проверяются вручную. |

## Output

```text
visual-localization-manifest.json
visual-localization-contact-sheet.jpg
screenshots\L-01-Main-window.png
screenshots\L-13-SolidWorks-add-in.png
```

Для полного L-01..L-15 capture manifest содержит каждый профильный кадр со
статусом `CAPTURED` или `MISSING`. Missing required surface является release
blocker.

Raw screenshots остаются в `_local_artifacts`. В Git коммитится только
curated summary/report без больших картинок и без приватных данных.

## Machine FAIL conditions

- Любая captured surface с `han_policy=fail` содержит видимые Han-символы в UIA text.
- Любая captured surface содержит forbidden visible text из профиля, например `ZTool`.
- `SWTools.exe` запущен не из ожидаемого runtime dir.
- Manifest имеет `production_go_allowed=true`.
- Для release evidence: обязательная surface отсутствует.
- Для full L-01..L-15 evidence: профильный кадр отсутствует или не `CAPTURED`.
- Для full L-01..L-15 evidence: отсутствует object-driven opener evidence.

## What this does not prove

- Нет pixel-level проверки clipping/overlap.
- Нет ручного подтверждения всех L-01..L-15 кадров.
- Нет автоматического решения по `record_only` host Han; auditor должен
  подтвердить, что это не SWTools UI.
- Нет production GO.

Финальный visual FULL PASS остаётся ручным owner/auditor gate по
`docs/localization/VISUAL_LOCALIZATION_REPORT_RU.md`.
