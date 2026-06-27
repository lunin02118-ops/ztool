# Frmexportbom layout fix - 2026-06-27

## Статус

PASS для целевого исправления окна `Настроить схему спецификации`. Production GO и Visual FULL PASS не заявляются.

## Что исправлено

- Окно `Настроить схему спецификации` переведено с fixed dialog на resizeable layout.
- Минимальный размер поднят до `1220x620`, чтобы в окне помещались список схем, путь шаблона, группы `Тип спецификации`, `Прочее`, `Пользовательское правило`, `Эскиз` и нижние кнопки.
- Основной шрифт формы и вложенных контролов нормализован на `Segoe UI 9`.
- Кнопки списка схем теперь используют всю ширину колонок: `Добавить`, `Переименовать`, `Удалить` не обрезаются.
- Длинные русские подписи radio/checkbox больше не зависят от узкой designer-разметки.
- Путь шаблона спецификации растягивается вместе с окном, кнопка `...` остаётся справа.
- Нижние кнопки `Справка`, `Применить`, `OK` имеют стабильную ширину и закреплены справа снизу.

## Regression gate

Добавлен `tools/e2e/check_frmexportbom_layout.py` и подключён в `.github/workflows/release-acceptance.yml`.

Gate блокирует возврат:

- `FormBorderStyle.FixedDialog`;
- `MaximizeBox = false`;
- `MinimizeBox = false`;
- прежних узких размеров групп `112x152`, `172x152`, `192x360`;
- прежних узких размеров кнопок `45x27` / `53x27`;
- отсутствия responsive layout hook;
- отсутствия `MinimumSize=1220x620`;
- отсутствия `AutoSize=false` для длинных русских подписей.

## Локальный visual evidence

Offscreen render собран из `client-src/bin/Release/net48/SWTools.exe`.

Локальная папка evidence:

`_local_artifacts/reports/frmexportbom-layout-render-20260627/`

Снято:

- `frmexportbom.png`
- `render-summary.json`

Render подтвердил:

- `width=1220`;
- `height=620`;
- `MinimumSize=1220x620`;
- кнопки `Добавить`, `Переименовать`, `Удалить` читаемы;
- группы `Тип спецификации`, `Прочее`, `Пользовательское правило`, `Эскиз` не накладываются друг на друга;
- путь шаблона спецификации читается в одну строку на минимальной ширине.

## Проверки

- `python tools/e2e/check_frmexportbom_layout.py --self-test` - PASS.
- `python tools/e2e/check_frmexportbom_layout.py` - PASS.
- `dotnet build` клиентского проекта `client-src` в Release - PASS, 123 известных warnings.
- `pwsh -NoProfile -File scripts/check_client_src_warnings.ps1` - PASS.
- `python tools/check_source_string_invariants.py --root client-src --root client-src-addin` - PASS.

## Остаточный риск

Это точечный layout fix для окна схемы спецификации. Полный visual profile L-01..L-15 и production signing остаются отдельными release blockers.
