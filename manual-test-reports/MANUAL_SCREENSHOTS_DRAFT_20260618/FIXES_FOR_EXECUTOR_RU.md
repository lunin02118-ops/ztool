# Инструкция исполнителю — правки RU-скриншотов мануала

Дата: 2026-06-19
Относится к: `manual-test-reports/MANUAL_SCREENSHOTS_DRAFT_20260618/`

Гейт сравнения усилен (`tools/chm-i18n/compare_manual_screenshots.py`): добавлен
детект **дублей контента** и в allowlist внесена нейтральная иконка
`basic/material-library.files/image004.jpg`. Раньше гейт проверял только
геометрию (пропорции/площадь), поэтому один и тот же кадр, вставленный в разные
разделы мануала, проходил как **PASS**. Теперь это ловится.

## Новый честный статус гейта

| | было (geometry-only) | стало (с детектом дублей) |
|---|---|---|
| PASS | 49 | **38** |
| WARN | 2 | **1** |
| FAIL | 17 | **29** |

Из 29 FAIL: **23** — дубли контента (один кадр на несколько разных оригиналов),
**6** — геометрия (неверная обрезка/пропорции). Цель перед финальной пересборкой
`help_ru.chm`: **FAIL = 0** (WARN допустим только с письменным обоснованием).

Как перепрогнать локально после правок:

```
python tools/chm-i18n/compare_manual_screenshots.py \
  --original <папка_китайских_оригиналов> \
  --candidate manual-test-reports/MANUAL_SCREENSHOTS_DRAFT_20260618/clean-screenshots \
  --out manual-test-reports/MANUAL_SCREENSHOTS_DRAFT_20260618/frame-compare
```

(без `--no-fail` гейт вернёт ненулевой код, пока есть FAIL).

---

## 1. Дубли контента — переснять разными кадрами (23 файла, 10 групп)

Внутри каждой группы сейчас лежит **байт-в-байт один и тот же** RU-кадр, а в
китайском оригинале это **разные** экраны. Нужно снять для каждого слота свой
правильный кадр. Если оригиналы в группе на самом деле показывают одну и ту же
сцену (бывает) — подтвердите это вручную по контакт-листам; тогда дубль
допустим, но это надо явно зафиксировать.

| Группа | Файлы (сейчас одинаковые) | Что должно быть на каждом (по оригиналу) |
|---|---|---|
| A | `activation.files/image001.png`, `image003.png` | разные шаги активации — снять оба отдельно |
| B | `activation.files/image007.png`, `installation.files/image002.png` | image007 = пункт меню «Регистрация»; installation/image002 = шаг установки |
| C | `advanced/bom-template.files/image005.png`, `image010.png` | image005 = свой шаг BOM-шаблона; image010 = диалог «Экспорт выполнен / Открыть файл?» |
| D ⚠NEW | `advanced/bom-template.files/image007.png`, `advanced/thumbnails.files/image003.png`, `basic/connect-sw.files/image006.png` | три разных экрана: лента «Спецификация» (bom007), эскизы (thumbnails003), список файлов connect-sw (006) |
| E ⚠NEW | `advanced/dropdown.files/image002.png`, `image003.png` | два разных состояния выпадающего списка |
| F ⚠NEW | `basic/material-library.files/image005.png`, `image007.png` | два разных экрана библиотеки материалов |
| G | `basic/material-library.files/image006.gif`, `image008.gif` | два разных кадра (анимация/состояние) |
| H ⚠NEW | `basic/property-names.files/image004.jpg`, `basic/save-to-sw.files/image006.jpg` | два разных экрана (свойства vs сохранение в SW) |
| I | `basic/save-to-sw.files/image003.png`, `image009.png`, `image011.png` | три разных окна: параметры сохранения, завершение сохранения, уведомление о несохранённых |
| J | `basic/save-to-sw.files/image004.gif`, `image010.gif`, `image012.gif` | gif-аналоги группы I — три разных кадра |

⚠NEW = группы, которых **не было** в вашем списке досъёмки
(`SCREENSHOTS_CAPTURE_STATUS_RU.md`) — раньше они молча проходили как PASS.

## 2. Геометрия — перекадрировать/переснять под пропорции оригинала (6 файлов)

| Файл | Проблема |
|---|---|
| `activation.files/image002.jpg` | aspect_delta=0.41 — обрезано не как оригинал; плюс см. п.3 (контакты/QR) |
| `advanced/bom-template.files/image002.png` | aspect_delta=0.20, area_ratio=0.16 — кадр сильно меньше/уже |
| `advanced/thumbnails.files/image002.png` | aspect_delta=0.23 |
| `basic/connect-sw.files/image003.png` | aspect_delta=0.51, area_ratio=0.10 — кадр в ~10× меньше площади |
| `basic/save-to-sw.files/image007.png` | aspect_delta=0.62, area_ratio=0.16 |
| `basic/save-to-sw.files/image014.gif` | aspect_delta=0.40 |

WARN (1, не блокер, но желательно поправить): `advanced/bom-template.files/image009.png` — area_ratio=0.21.

## 3. Загрязнение кадров — снимать чисто (проверить ВСЕ полноэкранные)

- `basic/connect-sw.files/image004.png` — в текущем кадре виден **рабочий стол
  Windows (панель задач)** и **боковая панель чата Codex** («Reply to Codex»).
  В мануал такое попадать не должно.
- `activation.files/image002.jpg` — в кадре видны реальные контакты/QR — убрать.
- На ряде кадров виден путь разработчика `D:\Development\ztool\TestModel\...` в
  заголовке окна/проводнике — снимать так, чтобы служебные пути не попадали, либо
  из нейтрального расположения.

Требование: окно приложения без посторонних панелей, без панели задач, без
сторонних оверлеев; только нужный диалог/окно ZTool/SolidWorks/Excel.

## 4. Проверка расчётных свойств BOM (Col_Weight / Col_bound)

Патч `PatchBomCalculatedColumnMapping` (коммит `5cae389`) включает в
сопоставление шаблона **две** расчётные колонки — «Масса ед._кг» (`Col_Weight`)
и «Габаритные размеры» (`Col_bound`). CI это **не** проверяет (только компиляция).
Нужна приёмка на живом SW 2025:

1. Открыть диалог сопоставления (`Frmmapping`) → убедиться, что в списке **видны**
   `Col_Weight` и `Col_bound` (помимо обычных `PropVal_*`), и их можно сопоставить
   с именами шаблона.
2. Выполнить экспорт BOM на `TestModel/0614-A00.SLDASM`.
3. В получившемся `.xlsx`: колонка **J «Масса ед. кг»** и колонка **P
   «Габаритные размеры»** заполнены, и попали под именованные диапазоны шаблона
   (а не под «сырые» невалидные заголовки).
4. Приложить `.xlsx` как evidence.

Если масса/габариты пустые или не подхватили имена шаблона — патч не отработал,
вернуть на доработку.

## 5. Формат сдачи

- Перезаписать каждый исправленный файл **под тем же именем/путём** в
  `clean-screenshots/`.
- Перепрогнать гейт (п. выше) → добиться **FAIL = 0**.
- Приложить обновлённые `frame-compare/manual_screenshot_compare.{md,json}` и
  контакт-лист.
- Для п.4 — приложить `.xlsx`.
- Прислать архивом или пушем в `pr35-update`.
