# Save mechanics contract audit — 2026-06-28

Status: PARTIAL PASS / live destructive save matrix still required before Production GO.

## Scope

Проверена механика сохранения свойств из окна `Параметры сохранения` до обработчика add-in:

1. UI фиксирует настройки пользователя и вызывает save pipeline.
2. Main window отправляет IPC-пакеты options / units / rows / execute.
3. Add-in пишет свойства через `CustomPropertyManager`, сохраняет документ через `Save3`, при необходимости переименовывает файлы и обновляет ссылки.

Runtime behavior этим commit не менялся. Добавлен machine-readable regression gate.
Gate не вводит новую механику сохранения: он фиксирует восстановленный контракт исходного китайского клиента и должен ловить только отклонения от него.

## Trace

1. `FrmSaveOption.Save_Click`
   - вызывает `DGV1.EndEdit()`;
   - сохраняет настройки формы;
   - маппит все пользовательские опции в `code.*`;
   - выставляет `SaveOptions`: `0 = все`, `1 = только изменённые`, `2 = только несохранённые/ошибочные`;
   - при включённых единицах вызывает `SetSWUnit()`;
   - запускает `Frmmain.SaveToSW()`.

2. `Frmmain.SaveToSW`
   - отправляет save options message `31`;
   - отправляет units message `32`;
   - собирает список строк и отправляет row payload message `33`;
   - запускает final execute message `34`.

3. `Frmmain.sendsavelist`
   - сохраняет строки в порядке отображаемых номеров;
   - пропускает read-only элементы при включённой опции;
   - в режиме “только изменённые” отправляет только изменённые детали и верхнюю сборку только если есть изменённые строки;
   - в режиме “только с ошибками” отправляет ошибочные дочерние строки; верхняя сборка остаётся final row;
   - применяет пользовательский фильтр к дочерним строкам;
   - передаёт материал, цвет, summary поля, dynamic `PropVal_*`, row number, `End`, `IsChanged`, old/new path.

4. Add-in save handler
   - принимает options packet в `f_225..f_239`;
   - для SW2022+ использует current save handler, для legacy — legacy handler;
   - открывает детали, сборки и чертежи по типу файла;
   - пишет document/config custom properties;
   - поддерживает пустые значения, удаление пустых значений, удаление лишних свойств, удаление из других scopes;
   - пишет material/color/summary/unit;
   - выполняет rename/reference update;
   - вызывает `SetSaveFlag()` и `Save3`;
   - закрывает только временно открытые документы.

## Baseline comparison

- Client save row selection/payload compared against recovered original-client baseline `b4540a5`.
- Add-in save handler compared against recovered original add-in baseline `cb56a4d`.
- Найденные отличия по save mechanics: локализация сообщений и IPC handle timeout hardening. Property placement/delete/save/rename/reference-update flow сохранён.

## Automated gate

Added:

- `tools/e2e/check_save_to_sw_contract.py`

It verifies:

- form option mapping;
- save options `0/1/2`;
- reference-update folder normalization;
- old-file move modes;
- IPC message ids `31/32/33/34`;
- row selection matrix for assembly/detail rows;
- read-only/filter/changed/failed behavior;
- row payload fields and encoding;
- add-in options receiver;
- part/assembly/drawing open path;
- custom property write/delete/keep-empty behavior;
- material/color/summary/unit writes;
- rename/reference-update path;
- `Save3` and temporary document close;
- row progress/result callbacks.

Local result:

```text
python tools\e2e\check_save_to_sw_contract.py --self-test
save-to-sw contract: PASS

python tools\e2e\check_save_to_sw_contract.py
save-to-sw contract: PASS
```

The gate is wired into `.github/workflows/release-acceptance.yml`.

## Not Production Evidence Yet

Перед Production GO всё ещё нужен live destructive run on copied CAD fixture:

- Save all: assembly + parts;
- Save changed only: changed child rows + top assembly final row;
- Save failed only: rows with errors;
- empty value delete vs keep empty value;
- delete extra properties in selected scopes;
- rename to new folder;
- overwrite disabled/enabled;
- read-only skip;
- reference update with/without subfolders;
- copied fixture read-back in SolidWorks custom properties after save.

До такого live evidence этот audit закрывает только static/contract regression, не финальный пользовательский PASS.
