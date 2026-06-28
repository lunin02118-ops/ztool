# Исправление верстки: пользовательская сортировка

Дата: 2026-06-28

## Проблема

В окне `Пользовательская сортировка` русские подписи радиокнопок `По возрастанию` и `По убыванию` обрезались справа. Причина: форма осталась в старой фиксированной ширине, а радиокнопки были размещены в правой части `GroupBox` с шириной элемента `50px`.

## Изменение

- Форма `Frmcustomsort` переведена с `FixedDialog` на `Sizable`.
- Установлен минимальный размер `535x250`.
- Шрифт формы и выпадающих списков заменен на `Segoe UI`.
- `GroupBox1` и `GroupBox2` расширены и привязаны к правому краю.
- Радиокнопки сортировки получили достаточную ширину для русских подписей.
- Логика сортировки не менялась.

## Регрессионная защита

Добавлен gate:

```powershell
python tools\e2e\check_frmcustomsort_layout.py --self-test
python tools\e2e\check_frmcustomsort_layout.py
```

Gate блокирует возврат:

- `FormBorderStyle.FixedDialog`;
- `Microsoft YaHei UI`;
- старых узких размеров `50px` для радиокнопок;
- старой ширины формы и групп.

## Проверки

Прогнано:

```powershell
python tools\e2e\check_frmcustomsort_layout.py --self-test
python tools\e2e\check_frmcustomsort_layout.py
dotnet build client-src\<client-project>.csproj -c Release --no-incremental
pwsh -NoProfile -File scripts\check_client_src_warnings.ps1
python tools\check_visible_brand_boundary.py
python tools\secret_scan.py
git diff --check
```

Результат: PASS.

## Граница

Это точечный layout-fix. Production GO этим исправлением не заявляется.
