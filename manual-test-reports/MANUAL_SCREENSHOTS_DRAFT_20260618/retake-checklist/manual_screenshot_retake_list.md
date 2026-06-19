# Manual Screenshot Retake List

Эти 20 кадров требуют ручной досъёмки перед финальной сборкой `help_ru.chm`.

| # | Файл | Compare | Причина |
|---:|---|---|---|
| 1 | `activation.files/image002.jpg` | FAIL (aspect_delta=0.412) | перекадрировать окно no-license: текущий кадр взят из evidence, но обрезан неидеально и содержит реальные контакты/QR |
| 2 | `activation.files/image007.png` | PASS (-) | нужен фактический пункт меню Регистрация; текущий кадр показывает меню Файл без нужного пункта |
| 3 | `activation.files/image008.gif` | PASS (-) | то же: нужен фактический пункт Регистрация |
| 4 | `advanced/bom-template.files/image001.png` | PASS (-) | нужен русский Excel: Диспетчер имен на BOM-шаблоне |
| 5 | `advanced/bom-template.files/image003.png` | PASS (-) | нужен русский Excel: Создание имени |
| 6 | `advanced/bom-template.files/image010.png` | PASS (-) | нужен реальный диалог Экспорт выполнен / Открыть файл? |
| 7 | `advanced/dropdown.files/image004.png` | PASS (-) | нужен реальный выпадающий список в ячейке с RU-именами |
| 8 | `advanced/dropdown.files/image005.png` | PASS (-) | нужен реальный выпадающий список Тип: Механообработка / Листовой металл / Покупное |
| 9 | `basic/connect-sw.files/image002.png` | PASS (-) | нужен родной диалог SolidWorks Свойства конфигурации на русском |
| 10 | `basic/connect-sw.files/image004.png` | PASS (-) | нужно окно Список файлов для чтения в режиме чтения из файла |
| 11 | `basic/material-library.files/image009.png` | PASS (-) | нужен SolidWorks: Параметры системы / Расположение файлов / база материалов |
| 12 | `basic/material-library.files/image010.gif` | PASS (-) | дубликат предыдущего SolidWorks-кадра |
| 13 | `basic/save-to-sw.files/image009.png` | PASS (-) | нужно реальное окно завершения сохранения, текущий кадр временно показывает параметры сохранения |
| 14 | `basic/save-to-sw.files/image010.gif` | WARN (area_ratio=4.91) | дубликат: нужно реальное окно завершения сохранения |
| 15 | `basic/save-to-sw.files/image011.png` | FAIL (aspect_delta=0.334) | нужно реальное уведомление о несохранённых элементах |
| 16 | `basic/save-to-sw.files/image012.gif` | FAIL (aspect_delta=0.333; area_ratio=7.76) | дубликат уведомления о несохранённых элементах |
| 17 | `basic/save-to-sw.files/image015.png` | PASS (-) | нужен значок ошибки в строке после Save to SW |
| 18 | `basic/save-to-sw.files/image016.gif` | PASS (-) | нужна подсказка ошибки по Дата проектирования |
| 19 | `installation.files/image003.png` | PASS (-) | нужно окно Проверить обновления / новая версия |
| 20 | `installation.files/image004.png` | PASS (-) | нужен диалог Загрузка завершена / Установить обновление? |
