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
  --expected-runtime-dir <runtime-dir> `
  --require-all-captured
```

Если окна нельзя держать открытыми одновременно (обычные modal WinForms
диалоги), кадры собираются накопительно. Сначала снимается первая открытая
surface, затем следующий прогон мержится в предыдущий manifest:

```powershell
python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full\L-04 `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --surface-id L-04 `
  --expected-runtime-dir <runtime-dir>

python scripts\swtools_visual_localization_capture.py `
  --output-dir _local_artifacts\reports\localization-visual-full\L-05 `
  --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json `
  --surface-id L-05 `
  --merge-manifest _local_artifacts\reports\localization-visual-full\L-04\visual-localization-manifest.json `
  --expected-runtime-dir <runtime-dir>
```

`--merge-manifest` разрешён только для того же `expected-runtime-dir`. Если
повторная попытка surface не нашла окно, но предыдущий manifest уже содержит
`CAPTURED`, предыдущий кадр сохраняется, а попытка записывается в
`last_attempt_status`. Это не даёт случайно потерять доказательство, но strict
validator всё равно требует, чтобы итоговая surface была `CAPTURED`.

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
  --require-runtime-match
```

`--allow-warn` разрешает частичный evidence-пакет только если нет blocking Han и
нет runtime mismatch. `PASS_WITH_WARN` не является production approval.

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
- `SWTools.exe` запущен не из ожидаемого runtime dir.
- Manifest имеет `production_go_allowed=true`.
- Для release evidence: обязательная surface отсутствует.
- Для full L-01..L-15 evidence: профильный кадр отсутствует или не `CAPTURED`.

## What this does not prove

- Нет pixel-level проверки clipping/overlap.
- Нет ручного подтверждения всех L-01..L-15 кадров.
- Нет автоматического решения по `record_only` host Han; auditor должен
  подтвердить, что это не SWTools UI.
- Нет production GO.

Финальный visual FULL PASS остаётся ручным owner/auditor gate по
`docs/localization/VISUAL_LOCALIZATION_REPORT_RU.md`.
