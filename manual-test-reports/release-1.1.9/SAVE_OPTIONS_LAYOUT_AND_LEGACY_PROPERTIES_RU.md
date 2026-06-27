# SWTools 1.1.9: параметры сохранения и legacy-свойства

Дата: 2026-06-28
Статус: pre-release fix / Production GO: NO-GO

## Что исправлено

- Окно `Параметры сохранения` переведено на гибкую верстку:
  - `FormBorderStyle.Sizable`;
  - минимальный размер окна `900x520`;
  - `Segoe UI`;
  - кнопки в нижней панели расширены и не обрезают русский текст;
  - группы настроек пересчитываются при изменении размера окна.
- Для выпадающего фильтра типа документа добавлена нормализация пробелов вокруг значения `零件`, чтобы оно стабильно отображалось пользователю как `Деталь`.
- Добавлен CI-gate `tools/e2e/check_frmsaveoption_layout.py`, который запрещает возврат фиксированного маленького окна, китайских UI-шрифтов и обрезанных кнопок.

## Что намеренно не менялось

Скрытая автоочистка legacy-свойств в add-in не добавлялась.

Причина: в оригинальной логике удаление лишних свойств управляется настройками пользователя в окне сохранения:

- `и удалить лишние свойства`;
- выбранная область сохранения свойств;
- режим сохранения в конфигурации / настраиваемые свойства.

Китайские свойства, видимые в SolidWorks после сохранения, являются уже существующими legacy-свойствами модели/fixture. Их нужно удалять только через явную настройку, а не скрытым безусловным кодом в `PMPHandler`.

## Проверки

- `dotnet build client-src\ZTool.csproj -c Release --no-incremental`
- `dotnet build client-src-addin\ZTool.SwAddin.csproj -c Release --no-incremental`
- `python tools\e2e\check_frmsaveoption_layout.py --self-test`
- `python tools\e2e\check_frmsaveoption_layout.py`
- `python tools\e2e\check_document_kind_filter_mapping.py --self-test`
- `python tools\e2e\check_document_kind_filter_mapping.py`
- `python tools\e2e\check_frmoptions_layout.py`
- `python tools\e2e\check_frmexportbom_layout.py`
- `python tools\check_source_string_invariants.py --root client-src --root client-src-addin`
- `python tools\check_visible_brand_boundary.py`
- `pwsh -NoProfile -File scripts\check_client_src_warnings.ps1`
- `python tools\secret_scan.py`
- `git diff --check`

## Ручная проверка пользователем

1. Открыть деталь/сборку с legacy-свойствами.
2. Открыть `Параметры сохранения`.
3. Убедиться, что весь текст и все кнопки читаемы при минимальном размере окна.
4. Включить `и удалить лишние свойства`.
5. Выбрать нужную область сохранения свойств.
6. Сохранить.
7. Проверить в SolidWorks, что лишние legacy-свойства удалены согласно выбранным настройкам, а не безусловно.
