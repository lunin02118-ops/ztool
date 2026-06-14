# Текущий статус локализации

Статус этого документа относится к tooling/pipeline, а не к финальному
production package. Совпадение корневых runtime artifacts с live-tested
артефактами остаётся задачей Phase 10.

## Что проверяет Phase 07

- `translations.tsv` не содержит дублей источников.
- Protocol keys и font names не переводятся.
- Han-строки в собранном `ZTool.exe` либо переведены, либо классифицированы
  через whitelist.
- Сканер пишет JSON report с `summary.unclassified_han`.
- BOM template builder использует явный source path и пишет SHA256.

## Локальная проверка Phase 07

На локально собранном `client-core/out/ZTool.exe`:

- Han entries: `74`.
- `unclassified_han`: `0`.
- Translation table diagnostics: `0 errors`, `0 warnings`.

## Известные ограничения

- `localization/whitelist_known_chinese_remaining.txt` содержит legacy internal
  names/resource/help path strings. Они не должны становиться user-facing.
- Localizer всё ещё печатает warning о 12 translatable Chinese ldstr; Phase 07
  переводит это из “ручного warning” в machine-readable whitelist gate.
- Screenshot checklist остаётся ручным до отдельной UI automation/visual phase.
