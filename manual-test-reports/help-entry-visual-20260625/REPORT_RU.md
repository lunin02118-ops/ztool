# H-01..H-03 help entry visual profile report

Дата: 2026-06-25

## Статус

`PROFILE READY / LIVE CAPTURE PENDING / PRODUCTION GO: NO-GO / VISUAL FULL PASS: NO-GO`

Этот PR не заявляет, что H-01..H-03 уже визуально пройдены. Он добавляет
машинно-читаемый профиль и strict validation path для live capture из runtime UI.

## Что закрыто

- Добавлен профиль `docs/localization/HELP_ENTRY_VISUAL_SURFACES_H01_H03.json`.
- Каждая surface требует `hh.exe` с title/window text `SWTools`.
- Для каждой страницы задан уникальный русский marker:
  - H-01: `Создание шаблона спецификации BOM`, `Диспетчер имён`;
  - H-02: `Показ эскизов`, `ALT+Z`;
  - H-03: `Сохранение данных в SolidWorks`, `Сохранить в SW`.
- Глобально запрещён visible `ZTool`.
- `han_policy=fail` для всех H-01..H-03.
- `release-acceptance` теперь валидирует JSON-профили visual surfaces.

## Локальные проверки

```text
python tools\e2e\check_visual_surface_profile.py --self-test
python tools\e2e\check_visual_surface_profile.py docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json
python tools\chm-i18n\check_help_entry_routes.py --chm help_ru.chm
python tools\e2e\assert_visual_localization_manifest.py <synthetic H-01..H-03 manifest> --require-surface-file docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json --require-profile-surfaces-captured
python tools\secret_scan.py
git diff --check
YAML parse all .github/workflows/*.yml
```

Результат: PASS. Негативный synthetic manifest без `H-02` ожидаемо отклонён
validator-ом, то есть неполный набор help-entry кадров не может стать PASS.

## Как собирать evidence

1. Открыть нужную runtime-форму.
2. Нажать её Help-кнопку object-based способом.
3. Снять соответствующую surface через
   `scripts/swtools_visual_localization_capture.py --surface-file docs/localization/HELP_ENTRY_VISUAL_SURFACES_H01_H03.json`.
4. Повторить H-01, H-02, H-03 через `--merge-manifest`.
5. Проверить итог:

```powershell
python tools\e2e\assert_visual_localization_manifest.py `
  _local_artifacts\reports\help-entry-visual\H-03\visual-localization-manifest.json `
  --require-surface-file docs\localization\HELP_ENTRY_VISUAL_SURFACES_H01_H03.json `
  --require-profile-surfaces-captured
```

## Почему это нужно после #92

#92 доказал, что source routes H-01..H-03 указывают на существующие темы в
`help_ru.chm`. Этот профиль закрывает следующий слой: после реального клика по
Help-кнопке должна быть видна правильная русская страница, а не просто
существующий topic внутри CHM.

## Остаточный риск

- Live capture H-01..H-03 ещё нужно выполнить на SWTools runtime.
- Полный L-01..L-15 visual profile и owner/auditor visual review остаются
  обязательными перед production GO.
