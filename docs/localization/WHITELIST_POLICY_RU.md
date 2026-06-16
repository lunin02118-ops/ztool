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
- Использовать whitelist, чтобы скрыть отсутствие перевода.

## Known remaining на текущем build

- `零件` - internal material/color part-kind key in `Frmmain`
  (`Col_Extname.Tag`). Перевод ломает команды цвета/материала, включая
  `Случайный цвет`.
- `二维码` / `工具箱.png` - legacy resource names/vendor QR asset names.
- `*ToolStripMenuItem` с китайским prefix - internal WinForms component names,
  не captions.
- `/进阶操作/...htm`, `/基本操作/...htm` - legacy help paths; пользовательский
  текст справки локализуется отдельно через `help_ru.chm`.
