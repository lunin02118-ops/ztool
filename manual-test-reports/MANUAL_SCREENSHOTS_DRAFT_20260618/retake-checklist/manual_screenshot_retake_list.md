# Manual Screenshot Retake List

Актуальный список после усиления `geometry-gate` в PR #40.

- Всего кадров: 68
- PASS: 38
- WARN: 1
- FAIL / переснять до финального CHM: 29

Финальный `help_ru.chm` нельзя закрывать, пока `FAIL != 0`.

| # | Файл | Issues | Что сделать | Размеры |
|---:|---|---|---|---|
| 1 | `activation.files/image001.png` | aspect_delta=0.272; duplicate_candidate_shares_content_with=activation.files/image003.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с activation.files/image003.png; перекадрировать под геометрию оригинала: aspect_delta=0.272 | 804x434 -> 620x460 |
| 2 | `activation.files/image002.jpg` | aspect_delta=0.412 | перекадрировать под геометрию оригинала: aspect_delta=0.412 | 804x434 -> 416x382 |
| 3 | `activation.files/image003.png` | duplicate_candidate_shares_content_with=activation.files/image001.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с activation.files/image001.png | 958x762 -> 620x460 |
| 4 | `activation.files/image007.png` | duplicate_candidate_shares_content_with=installation.files/image002.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с installation.files/image002.png | 128x77 -> 250x150 |
| 5 | `advanced/bom-template.files/image002.png` | aspect_delta=0.199; area_ratio=0.16 | перекадрировать под геометрию оригинала: aspect_delta=0.199, area_ratio=0.16 | 1415x1125 -> 514x510 |
| 6 | `advanced/bom-template.files/image005.png` | aspect_delta=0.183; area_ratio=0.18; duplicate_candidate_shares_content_with=advanced/bom-template.files/image010.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/bom-template.files/image010.png; перекадрировать под геометрию оригинала: aspect_delta=0.183, area_ratio=0.18 | 1718x1224 -> 795x463 |
| 7 | `advanced/bom-template.files/image007.png` | duplicate_candidate_shares_content_with=advanced/thumbnails.files/image003.png,basic/connect-sw.files/image006.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/thumbnails.files/image003.png,basic/connect-sw.files/image006.png | 863x688 -> 1085x765 |
| 8 | `advanced/bom-template.files/image010.png` | duplicate_candidate_shares_content_with=advanced/bom-template.files/image005.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/bom-template.files/image005.png | 470x316 -> 795x463 |
| 9 | `advanced/dropdown.files/image002.png` | duplicate_candidate_shares_content_with=advanced/dropdown.files/image003.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/dropdown.files/image003.png | 806x809 -> 507x474 |
| 10 | `advanced/dropdown.files/image003.png` | duplicate_candidate_shares_content_with=advanced/dropdown.files/image002.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/dropdown.files/image002.png | 810x812 -> 507x474 |
| 11 | `advanced/thumbnails.files/image002.png` | aspect_delta=0.227 | перекадрировать под геометрию оригинала: aspect_delta=0.227 | 800x802 -> 768x595 |
| 12 | `advanced/thumbnails.files/image003.png` | duplicate_candidate_shares_content_with=advanced/bom-template.files/image007.png,basic/connect-sw.files/image006.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/bom-template.files/image007.png,basic/connect-sw.files/image006.png | 1724x1234 -> 1085x765 |
| 13 | `basic/connect-sw.files/image003.png` | aspect_delta=0.505; area_ratio=0.10 | перекадрировать под геометрию оригинала: aspect_delta=0.505, area_ratio=0.10 | 562x862 -> 250x190 |
| 14 | `basic/connect-sw.files/image006.png` | duplicate_candidate_shares_content_with=advanced/bom-template.files/image007.png,advanced/thumbnails.files/image003.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с advanced/bom-template.files/image007.png,advanced/thumbnails.files/image003.png | 1741x1244 -> 1085x765 |
| 15 | `basic/material-library.files/image005.png` | duplicate_candidate_shares_content_with=basic/material-library.files/image007.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/material-library.files/image007.png | 1344x1140 -> 768x595 |
| 16 | `basic/material-library.files/image006.gif` | aspect_delta=0.156; duplicate_candidate_shares_content_with=basic/material-library.files/image008.gif | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/material-library.files/image008.gif; перекадрировать под геометрию оригинала: aspect_delta=0.156 | 905x831 -> 768x595 |
| 17 | `basic/material-library.files/image007.png` | aspect_delta=0.285; duplicate_candidate_shares_content_with=basic/material-library.files/image005.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/material-library.files/image005.png; перекадрировать под геометрию оригинала: aspect_delta=0.285 | 1477x818 -> 768x595 |
| 18 | `basic/material-library.files/image008.gif` | aspect_delta=0.285; duplicate_candidate_shares_content_with=basic/material-library.files/image006.gif | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/material-library.files/image006.gif; перекадрировать под геометрию оригинала: aspect_delta=0.285 | 1092x605 -> 768x595 |
| 19 | `basic/property-names.files/image004.jpg` | duplicate_candidate_shares_content_with=basic/save-to-sw.files/image006.jpg | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image006.jpg | 648x854 -> 342x455 |
| 20 | `basic/save-to-sw.files/image003.png` | aspect_delta=0.162; duplicate_candidate_shares_content_with=basic/save-to-sw.files/image009.png,basic/save-to-sw.files/image011.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image009.png,basic/save-to-sw.files/image011.png; перекадрировать под геометрию оригинала: aspect_delta=0.162 | 1163x661 -> 634x430 |
| 21 | `basic/save-to-sw.files/image004.gif` | aspect_delta=0.162; duplicate_candidate_shares_content_with=basic/save-to-sw.files/image010.gif,basic/save-to-sw.files/image012.gif | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image010.gif,basic/save-to-sw.files/image012.gif; перекадрировать под геометрию оригинала: aspect_delta=0.162 | 1063x604 -> 634x430 |
| 22 | `basic/save-to-sw.files/image006.jpg` | duplicate_candidate_shares_content_with=basic/property-names.files/image004.jpg | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/property-names.files/image004.jpg | 648x854 -> 342x455 |
| 23 | `basic/save-to-sw.files/image007.png` | aspect_delta=0.615; area_ratio=0.16 | перекадрировать под геометрию оригинала: aspect_delta=0.615, area_ratio=0.16 | 421x199 -> 275x50 |
| 24 | `basic/save-to-sw.files/image009.png` | duplicate_candidate_shares_content_with=basic/save-to-sw.files/image003.png,basic/save-to-sw.files/image011.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image003.png,basic/save-to-sw.files/image011.png | 512x329 -> 634x430 |
| 25 | `basic/save-to-sw.files/image010.gif` | area_ratio=4.91; duplicate_candidate_shares_content_with=basic/save-to-sw.files/image004.gif,basic/save-to-sw.files/image012.gif | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image004.gif,basic/save-to-sw.files/image012.gif; перекадрировать под геометрию оригинала: area_ratio=4.91 | 294x189 -> 634x430 |
| 26 | `basic/save-to-sw.files/image011.png` | aspect_delta=0.334; duplicate_candidate_shares_content_with=basic/save-to-sw.files/image003.png,basic/save-to-sw.files/image009.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image003.png,basic/save-to-sw.files/image009.png; перекадрировать под геометрию оригинала: aspect_delta=0.334 | 334x340 -> 634x430 |
| 27 | `basic/save-to-sw.files/image012.gif` | aspect_delta=0.333; area_ratio=7.76; duplicate_candidate_shares_content_with=basic/save-to-sw.files/image004.gif,basic/save-to-sw.files/image010.gif | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с basic/save-to-sw.files/image004.gif,basic/save-to-sw.files/image010.gif; перекадрировать под геометрию оригинала: aspect_delta=0.333, area_ratio=7.76 | 186x189 -> 634x430 |
| 28 | `basic/save-to-sw.files/image014.gif` | aspect_delta=0.397 | перекадрировать под геометрию оригинала: aspect_delta=0.397 | 386x120 -> 330x170 |
| 29 | `installation.files/image002.png` | aspect_delta=0.335; duplicate_candidate_shares_content_with=activation.files/image007.png | переснять уникальный кадр по оригиналу; текущий RU-кадр совпадает с activation.files/image007.png; перекадрировать под геометрию оригинала: aspect_delta=0.335 | 198x79 -> 250x150 |

Отдельно проверить загрязнение кадров: `basic/connect-sw.files/image004.png` (панель задач/Codex), `activation.files/image002.jpg` (контакты/QR), а также dev-пути `D:\Development\ztool\...` в заголовках/проводнике.

BOM gate: финальный CHM не закрывать без `.xlsx` evidence для `Col_Weight` / `Col_bound`, см. `FIXES_FOR_EXECUTOR_RU.md` п.4.
