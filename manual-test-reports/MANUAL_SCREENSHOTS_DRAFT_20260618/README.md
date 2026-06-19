# ZTool manual screenshots draft

Дата подготовки: 2026-06-18/19.

Это черновой набор русских скриншотов для пересборки `help_ru.chm`.
Он сохранен в репозитории как проверяемый evidence-набор, а не как финальный
`FULL PASS`.

## Состав

- `clean-screenshots/` — чистовые RU-картинки с теми же относительными путями,
  что в распакованном CHM. Эти файлы можно накладывать поверх `_chm_build/`
  перед сборкой справки.
- `frame-compare/` — машинное покадровое сравнение с китайским backup:
  markdown, JSON и contact sheet.
- `contact-sheets/` — обзорные листы для ручной проверки всего набора.
- `retake-checklist/manual_screenshot_retake_checklist.pdf` — актуальная
  сравнительная таблица 29 FAIL-кадров после усиления gate в PR #40:
  оригинал слева, текущий RU-кадр справа, причина пересъемки сверху.
- `retake-checklist/manual_screenshot_retake_list.md|csv|json` — тот же список
  в текстовом и машинно-читаемом виде.
- `SCREENSHOTS_CAPTURE_STATUS_RU.md` — ручная сводка: какие кадры годятся,
  какие требуют досъемки.
- `ru-change-summary.json` и `ru-normalization-log.json` — hash/размеры и лог
  нормализации.

## Текущий статус

- Всего изображений: 68.
- Отличаются от китайского backup: 65.
- Оставлены без изменений: 3 нейтральных кадра/иконки.
- Frame compare после PR #40: 38 PASS, 1 WARN, 29 FAIL.
- Ручная досъемка перед финальным CHM: 29 FAIL-кадров из
  `retake-checklist/manual_screenshot_retake_list.*`.
- PDF для исполнителя: `retake-checklist/manual_screenshot_retake_checklist.pdf`

Итог: набор пригоден для ревью и промежуточной сборки справки, но финальную
пересборку `help_ru.chm` нельзя считать закрытой, пока не исправлены все
`FAIL` из `frame-compare/manual_screenshot_compare.md`, загрязнённые кадры из
`FIXES_FOR_EXECUTOR_RU.md` и BOM `.xlsx` evidence по `Col_Weight`/`Col_bound`.

## Как использовать для проверки

1. Распаковать/собрать русский CHM source через `tools/chm-i18n/build_ru.py`.
2. Наложить `clean-screenshots/` поверх соответствующих image-папок в
   `_chm_build/`.
3. Запустить сравнение:

```powershell
python tools\chm-i18n\compare_manual_screenshots.py `
  --original <source-backup-before-ru> `
  --candidate <_chm_build> `
  --out <manual-frame-compare>
```

4. Просмотреть `manual_screenshot_compare_contact_sheet.jpg` вручную.

## Важно

Кадры с лицензированием должны оставаться без реальных ключей/секретов. Если
кадр переснимается, проверять его не только по размеру, но и по смыслу: русский
интерфейс, правильная версия ZTool, без обрезанного текста и без случайных
локальных путей, не относящихся к релизу.
