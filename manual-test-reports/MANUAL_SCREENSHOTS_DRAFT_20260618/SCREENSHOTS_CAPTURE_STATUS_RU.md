# ZTool manual screenshots — статус пересъёмки RU

Дата: 2026-06-18

## Сводка

- Всего изображений в source: 68
- Отличаются от китайского backup: 65
- Оставлены без изменений: 3 (нейтральные иконки/стрелки без текста)
- Визуально пригодные/условно пригодные RU-кадры: 48
- Требуют досъёмки перед финальной пересборкой CHM: 20

> Обновление 2026-06-19: гейт усилен детектом дублей контента. Актуальный
> статус: **PASS 38 / WARN 1 / FAIL 29** (23 дубля контента + 6 геометрия).
> Полный список правок — см. `FIXES_FOR_EXECUTOR_RU.md` рядом. Ряд дублей
> (группы bom007/thumb003/connect006, dropdown002/003, matlib005/007,
> propnames004/saves006, activation001/003) раньше молча проходил как PASS.

## Артефакты

- Рабочая папка: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\source-from-help_ru-chm`
- Бэкап китайских оригиналов: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\source-backup-before-ru`
- Контрольный лист всех кадров: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\ru-current-all-contact-sheet.jpg`
- Сводка hash/размеров: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\ru-change-summary.json`
- Лог нормализации: `D:\Development\ztool\_local_artifacts\scratch\manual-screenshots-20260617\ru-normalization-log.json`

## Нужно доснять/заменить

- `activation.files/image002.jpg` — перекадрировать окно no-license: текущий кадр взят из evidence, но обрезан неидеально и содержит реальные контакты/QR
- `activation.files/image007.png` — нужен фактический пункт меню Регистрация; текущий кадр показывает меню Файл без нужного пункта
- `activation.files/image008.gif` — то же: нужен фактический пункт Регистрация
- `advanced/bom-template.files/image001.png` — нужен русский Excel: Диспетчер имен на BOM-шаблоне
- `advanced/bom-template.files/image003.png` — нужен русский Excel: Создание имени
- `advanced/bom-template.files/image010.png` — нужен реальный диалог Экспорт выполнен / Открыть файл?
- `advanced/dropdown.files/image004.png` — нужен реальный выпадающий список в ячейке с RU-именами
- `advanced/dropdown.files/image005.png` — нужен реальный выпадающий список Тип: Механообработка / Листовой металл / Покупное
- `basic/connect-sw.files/image002.png` — нужен родной диалог SolidWorks Свойства конфигурации на русском
- `basic/connect-sw.files/image004.png` — нужно окно Список файлов для чтения в режиме чтения из файла
- `basic/material-library.files/image009.png` — нужен SolidWorks: Параметры системы / Расположение файлов / база материалов
- `basic/material-library.files/image010.gif` — дубликат предыдущего SolidWorks-кадра
- `basic/save-to-sw.files/image009.png` — нужно реальное окно завершения сохранения, текущий кадр временно показывает параметры сохранения
- `basic/save-to-sw.files/image010.gif` — дубликат: нужно реальное окно завершения сохранения
- `basic/save-to-sw.files/image011.png` — нужно реальное уведомление о несохранённых элементах
- `basic/save-to-sw.files/image012.gif` — дубликат уведомления о несохранённых элементах
- `basic/save-to-sw.files/image015.png` — нужен значок ошибки в строке после Save to SW
- `basic/save-to-sw.files/image016.gif` — нужна подсказка ошибки по Дата проектирования
- `installation.files/image003.png` — нужно окно Проверить обновления / новая версия
- `installation.files/image004.png` — нужен диалог Загрузка завершена / Установить обновление?

## Оставлены как допустимые нейтральные иконки

- `basic/connect-sw.files/image005.png`
- `basic/material-library.files/image003.png`
- `basic/material-library.files/image004.jpg`

## Примечание

Пакет ниже является черновым RU-пакетом для проверки верстки и объема замены. Для финального `help_ru.chm` нужно закрыть список досъёмки выше.
