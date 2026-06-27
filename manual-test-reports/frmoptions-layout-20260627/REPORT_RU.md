# FrmOptions layout fix — 2026-06-27 / follow-up 2026-06-28

## Статус

PASS для целевого исправления. Production GO не заявляется.

## Что исправлено

- Окно `Параметры` (`client-src` module, `FrmOptions.cs`) переведено с fixed dialog на resizeable layout.
- Добавлен минимальный размер `900x560`, `SizeGrip`, `MaximizeBox`, `MinimizeBox`; рабочий client area при первом открытии не меньше `880x520`.
- Вкладки `Общие`, `Эскиз`, `Материал`, `Пользовательский список`, `Список макросов` получают responsive bounds после `InitializeComponent()` и при resize.
- Длинные checkbox/button/label тексты на `Общие`, `Эскиз`, `Пользовательский список`, `Список макросов` больше не зависят от узкой designer-разметки.
- На вкладке `Общие` увеличены подписи `Подсветка выбранных строк` и `Версия SolidWorks`, а combo box перенесён правее и расширяется.
- На вкладке `Список макросов` увеличена правая панель и кнопки `Добавить файл` / `Удалить выбранное`, чтобы текст не обрезался.
- Списки и multiline-поле на вкладке `Пользовательский список` растягиваются вместе с окном.
- Поле `Подсветка выбранных строк` больше не показывает системное имя `LightCyan`: пользователь видит `Светло-голубой`, а внутренний `ColorName` сохраняется для совместимости с `Color.FromName`.

## Regression gate

Добавлен `tools/e2e/check_frmoptions_layout.py` и подключён в `.github/workflows/release-acceptance.yml`.

Gate блокирует возврат:

- `FormBorderStyle.FixedDialog`;
- `MaximizeBox = false`;
- `MinimizeBox = false`;
- возврат старого минимального размера `760x540`;
- отсутствие responsive layout hook;
- узкие подписи/поля на вкладке `Общие`;
- узкие кнопки вкладки `Эскиз`;
- нерастягиваемые панели вкладки `Пользовательский список`.
- узкую правую панель и кнопки на вкладке `Список макросов`.
- возврат видимого `LightCyan` и старого применения цвета через `rowcolor.Text`.

## Локальный visual evidence

Offscreen render собран из `client-src/bin/Release/net48/SWTools.exe`.

Локальная папка evidence:

`_local_artifacts/reports/frmoptions-layout-render-20260627/`

Сняты вкладки:

- `tab1-Общие.png`
- `tab2-Эскиз.png`
- `tab3-Материал.png`
- `tab4-Пользовательский_список.png`
- `tab5-Список_макросов.png`

Первый проход открывал форму с `width=760`, `height=540`, `MinimumSize=760x540`.

Follow-up 2026-06-28 поднимает минимальный размер до `900x560`, потому что ручная проверка показала, что при старой ширине всё ещё обрезались:

- `Подсветка выбранных строк` на вкладке `Общие`;
- кнопки `Добавить файл` / `Удалить выбранное` на вкладке `Список макросов`.

На `tab1-Общие.png` подтверждено русское значение цвета: `Светло-голубой`.

## Проверки

- `python tools/e2e/check_frmoptions_layout.py --self-test` — PASS.
- `python tools/e2e/check_frmoptions_layout.py` — PASS.
- Все existing layout gates (`FrmRename`, `FrmSetNewFolder`, `FrmReplacePartslist`, add-in `ReName`, `frm_copyswfile`) — PASS.
- `dotnet build` клиентского проекта `client-src` в Release — PASS, 123 известных warnings.
- `pwsh -NoProfile -File scripts/check_client_src_warnings.ps1` — PASS.
- `python tools/check_source_string_invariants.py --root client-src --root client-src-addin` — PASS.
- `python tools/check_visible_brand_boundary.py` — PASS.
- `python tools/secret_scan.py` — PASS.
- `git diff --check` — PASS.
- YAML parse для `.github/workflows/*.yml` — PASS.

## Остаточный риск

Полный release visual FULL PASS по L-01..L-15 этим исправлением не заявляется. Это точечный fix для окна `Параметры`.
