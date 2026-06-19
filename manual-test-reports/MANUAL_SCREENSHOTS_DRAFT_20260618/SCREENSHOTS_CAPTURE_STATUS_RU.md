# ZTool manual screenshots — статус пересъёмки RU

Дата: 2026-06-18

## Сводка

- Всего изображений в source: 68
- Отличаются от китайского backup: 65
- Оставлены без изменений: 3 (нейтральные иконки/стрелки без текста)
- Визуально пригодные/условно пригодные RU-кадры: 48
- Требуют досъёмки перед финальной пересборкой CHM: 29 FAIL-кадров по
  усиленному gate PR #40

> Обновление 2026-06-19: гейт усилен детектом дублей контента. Актуальный
> статус: **PASS 38 / WARN 1 / FAIL 29** (23 дубля контента + 6 геометрия).
> Полный список правок — см. `FIXES_FOR_EXECUTOR_RU.md` рядом. Ряд дублей
> (группы bom007/thumb003/connect006, dropdown002/003, matlib005/007,
> propnames004/saves006, activation001/003) раньше молча проходил как PASS.
> Актуальный PDF/MD/CSV/JSON для исполнителя пересобраны в
> `retake-checklist/` и содержат все 29 FAIL-кадров. Старый список 20 кадров
> больше не является полным выпускным gate.

## Артефакты

- Рабочая папка: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\source-from-help_ru-chm`
- Бэкап китайских оригиналов: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\source-backup-before-ru`
- Контрольный лист всех кадров: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\ru-current-all-contact-sheet.jpg`
- Сводка hash/размеров: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\ru-change-summary.json`
- Лог нормализации: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\ru-normalization-log.json`

## Нужно доснять/заменить

Актуальный полный список для исполнителя находится в:

- `retake-checklist/manual_screenshot_retake_checklist.pdf` — PDF с оригиналом слева и текущим RU-кадром справа;
- `retake-checklist/manual_screenshot_retake_list.md|csv|json` — тот же список в текстовом и машинно-читаемом виде;
- `FIXES_FOR_EXECUTOR_RU.md` — группировка дублей, геометрии, загрязнений кадров и BOM-gate.

Рабочий gate перед финальным `help_ru.chm`: `FAIL = 0`; текущий статус — `29 FAIL`.
Старый ручной список 20 кадров больше не является достаточным.

## Оставлены как допустимые нейтральные иконки

- `basic/connect-sw.files/image005.png`
- `basic/material-library.files/image003.png`
- `basic/material-library.files/image004.jpg`

## Примечание

Пакет ниже является черновым RU-пакетом для проверки верстки и объема замены. Для финального `help_ru.chm` нужно закрыть список досъёмки выше.
