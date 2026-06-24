# Whitelist policy

Whitelist разрешён только для строк, которые нельзя или не нужно переводить.

## Категории

- `protocol_key` - участвует в crypto/protocol derivation. Перевод ломает
  совместимость.
- `font_name` - имя шрифта. Перевод ломает font lookup/rendering.
- `technical_log` - diagnostic/log template, не user-facing UI.
- `known_remaining` - техническая/vendor строка, которая остаётся в бинаре,
  но не должна показываться пользователю в нормальном сценарии.

## Запрещено

- Whitelist user-facing кнопок, меню, ошибок и диалогов без отдельного решения.
- Добавлять широкие wildcard/regex. Whitelist хранит точные строки или
  минимальные точные substring для known legacy names.
- Классифицировать protocol keys по суффиксу или похожести. Protocol whitelist
  должен содержать точные значения.
- Использовать whitelist, чтобы скрыть отсутствие перевода.

## Known remaining на текущем build

- `零件` - mixed literal. It is translated globally for user-facing contexts,
  but internal `Frmmain` material/color contexts still depend on the same source
  literal (`Col_Extname.Tag`). Source-level cleanup requires producer/consumer
  parity tests, including `Случайный цвет`.
- `二维码` / `工具箱.png` - legacy resource names/vendor QR asset names.
- `*ToolStripMenuItem` с китайским prefix - internal WinForms component names,
  не captions.
- H-01..H-03 help routes больше не whitelist-долг: runtime source должен
  ссылаться на ASCII-топики `advanced/...` / `basic/...`, существующие в
  `help_ru.chm`; legacy Han paths считаются регрессом.
