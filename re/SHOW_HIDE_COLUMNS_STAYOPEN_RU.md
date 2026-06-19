# «Скрыть/показать столбцы» — список должен оставаться открытым

Требование: при клике на пункт выпадающего списка «скрыть/показать столбцы» список
**не должен закрываться** — пользователь отмечает сразу несколько столбцов, а
список закрывается только по клику на саму кнопку (или мимо).

Документ основан на декомпиляции (`re/decompiled/`), а не на догадках по IL.

## 1. Что это за контрол (по факту из кода)

В `re/decompiled/ZTool.exe/ZTool/Frmmain.cs`:

- `AddRibbon()` создаёт кнопку:
  `_cmdButtonHidecol = new RibbonDropDownGallery(_Ribbon, 1033u);` — это **галерея
  Windows Ribbon Framework** (RibbonLib), CommandID **1033**.
- Пункты списка — это `RibbonCheckBox` с CommandID **`11000 + i`** (массив
  `buttons2`), по одному на столбец `DGV1`.
- Наполнение списка: `_cmdButtonHidecol_ItemsSourceReady(...)` (≈ строка 4388) —
  чистит `ItemsSource` и добавляет `GalleryCommandPropertySet { CommandType = Boolean }`
  для видимых столбцов.
- Обработчик клика по пункту: `button2_ExecuteEvent(...)` (≈ строка 4664) —
  переключает `DGV1.Columns[n].Visible = ribbonCheckBox.BooleanValue` и зовёт
  `SaveColumnInfo()`.

То же устройство у «закрепить столбец» — `_cmdButtonFreezecol` (cmd **1034**,
items `buttons3` = `12000+i`), но там выбор по смыслу **одиночный** (выбрал один
столбец — заморозил), поэтому закрытие после клика там корректно и менять не надо.

## 2. Почему список закрывается — и почему «оставить открытым» здесь невозможно

`RibbonDropDownGallery` — это обёртка над **нативным Windows Ribbon Framework**
(COM-компонент UIRibbon). Всплывающим списком галереи управляет сам фреймворк:
при вызове любого пункта (`ExecutionVerb.Execute`) **нативный UIRibbon закрывает
popup сам**.

В управляемом коде ручки для этого нет: `re/decompiled/Ribbon.dll/RibbonLib.Controls/RibbonDropDownGallery.cs`
не содержит ни одного свойства/метода управления открытием/закрытием popup
(только `ItemsSource`, `SelectedItem`, `Label`, `Image`, события `ItemsSourceReady`/
`ExecuteEvent`). Поэтому:

- **Нельзя** «запретить закрытие» галереи — это решает фреймворк, не наш код.
- **Нельзя** программно «снова открыть» галерею после клика — в UIRibbon нет API
  открыть popup из кода. Вариант «переоткрывать список в обработчике пункта»
  технически держится только на хаке (UIAutomation/SendKeys по кнопке ленты),
  даёт мигание и гонки фокуса — **не рекомендуется**.

Вывод: пока «скрыть столбцы» остаётся `RibbonDropDownGallery`, требование
невыполнимо. Нужно сменить сам тип контрола списка.

## 3. Рекомендация: заменить галерею на `ContextMenuStrip` c `AutoClose = false`

В ZTool **уже есть** этот паттерн: меню `Material_list` и `Filter_list` —
`ContextMenuStrip` (см. `Frmmain.cs`, объявления ≈ строки 457/460, и
`loadfrm()` ≈ строки 3162–3163, где им ставят `AutoClose`). Меню WinForms с
`AutoClose = false` остаётся открытым после кликов по пунктам и закрывается только
по явной команде или клику мимо — это ровно нужное поведение «гасим несколько
столбцов подряд».

План для cmd **1033** (только для «скрыть/показать», не трогая «закрепить»):

1. Сделать `_cmdButtonHidecol` обычной кнопкой (`RibbonButton`, cmd 1033),
   либо оставить как кнопку с собственным `ExecuteEvent` (без галереи).
2. По клику на кнопку строить и показывать `ContextMenuStrip`:
   - `AutoClose = false;`
   - на каждый подходящий столбец (та же фильтрация, что в
     `_cmdButtonHidecol_ItemsSourceReady`: пропустить `PropVal_*`/`PropResolvedVal_*`
     по состоянию `PropSwitch`, пропустить пустые заголовки и `Col_Preview`) —
     `ToolStripMenuItem { Text = HeaderText, CheckOnClick = true, Checked = Column.Visible }`;
   - в `ItemClicked`/`CheckedChanged` пункта выполнять то же, что
     `button2_ExecuteEvent`: `DGV1.Columns[n].Visible = item.Checked; SaveColumnInfo();`
     **без закрытия меню**.
   - закрытие: пункт-разделитель + «Готово» (`menu.Close()`), и/или клик мимо
     (при `AutoClose=false` ловится через `menu.Capture`/обработку
     `WM_*`/таймер фокуса — как сделано в существующих меню ZTool).
3. Показывать меню под кнопкой ленты: `menu.Show(cursorOrButtonScreenPoint)`.

Этот вариант не зависит от UIRibbon и поддерживает мульти-выбор «из коробки».

## 4. Как это вносить в репозиторий

Поведение меняется в **`ZTool.exe`**, исходник которого мы не пересобираем —
правки идут IL-патчем через `client-core/tools/Localizer/Program.cs` (dnlib),
как и остальные доработки. Замена галереи на `ContextMenuStrip` — это уже не
точечная подмена свойства, а инъекция новой логики показа меню; объём патча
заметный, и его **обязательно** проверять на живом ZTool в SolidWorks
(построение списка столбцов, мульти-тоггл без закрытия, сохранение
видимости/`SaveColumnInfo`, корректное закрытие). На этой машине (без живого SW)
поведение ленты не воспроизводится.

## 5. Точки в декомпиляции (быстрый доступ)

- `re/decompiled/ZTool.exe/ZTool/Frmmain.cs`
  - `AddRibbon()` — создание контролов и CommandID;
  - `_cmdButtonHidecol = new RibbonDropDownGallery(_Ribbon, 1033u)`;
  - `_cmdButtonHidecol_ItemsSourceReady(...)` — наполнение списка;
  - `button2_ExecuteEvent(...)` — переключение видимости столбца + `SaveColumnInfo()`;
  - `Material_list`/`Filter_list` (`ContextMenuStrip`, `AutoClose`) — образец
    «остающегося открытым» меню.
- `re/decompiled/Ribbon.dll/RibbonLib.Controls/RibbonDropDownGallery.cs` —
  подтверждение: управления popup в API нет.
