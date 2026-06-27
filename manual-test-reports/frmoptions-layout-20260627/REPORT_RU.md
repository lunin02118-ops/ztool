# FrmOptions layout fix — 2026-06-27

## Статус

PASS для целевого исправления. Production GO не заявляется.

## Что исправлено

- Окно `Параметры` (`client-src/ZTool/FrmOptions.cs`) переведено с fixed dialog на resizeable layout.
- Добавлен минимальный размер `760x540`, `SizeGrip`, `MaximizeBox`, `MinimizeBox`.
- Вкладки `Общие`, `Эскиз`, `Материал`, `Пользовательский список`, `Список макросов` получают responsive bounds после `InitializeComponent()` и при resize.
- Длинные checkbox/button/label тексты на `Общие`, `Эскиз`, `Пользовательский список` больше не зависят от узкой designer-разметки.
- Списки и multiline-поле на вкладке `Пользовательский список` растягиваются вместе с окном.
- Поле `Подсветка выбранных строк` больше не показывает системное имя `LightCyan`: пользователь видит `Светло-голубой`, а внутренний `ColorName` сохраняется для совместимости с `Color.FromName`.

## Regression gate

Добавлен `tools/e2e/check_frmoptions_layout.py` и подключён в `.github/workflows/release-acceptance.yml`.

Gate блокирует возврат:

- `FormBorderStyle.FixedDialog`;
- `MaximizeBox = false`;
- `MinimizeBox = false`;
- отсутствие `MinimumSize`;
- отсутствие responsive layout hook;
- узкие кнопки вкладки `Эскиз`;
- нерастягиваемые панели вкладки `Пользовательский список`.
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

Форма открылась с `width=760`, `height=540`, `MinimumSize=760x540`.

На `tab1-Общие.png` подтверждено русское значение цвета: `Светло-голубой`.

## Проверки

- `python tools/e2e/check_frmoptions_layout.py --self-test` — PASS.
- `python tools/e2e/check_frmoptions_layout.py` — PASS.
- Все existing layout gates (`FrmRename`, `FrmSetNewFolder`, `FrmReplacePartslist`, add-in `ReName`, `frm_copyswfile`) — PASS.
- `dotnet build client-src/ZTool.csproj -c Release --no-incremental -v minimal` — PASS, 123 известных warnings.
- `pwsh -NoProfile -File scripts/check_client_src_warnings.ps1` — PASS.
- `python tools/check_source_string_invariants.py --root client-src --root client-src-addin` — PASS.
- `python tools/check_visible_brand_boundary.py` — PASS.
- `python tools/secret_scan.py` — PASS.
- `git diff --check` — PASS.
- YAML parse для `.github/workflows/*.yml` — PASS.

## Остаточный риск

Полный release visual FULL PASS по L-01..L-15 этим исправлением не заявляется. Это точечный fix для окна `Параметры`.
