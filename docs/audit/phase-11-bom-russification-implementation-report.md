# Phase 11 implementation report — BOM export russification, mapping UI, binder fix

## Scope

Фаза 11 убирает китайский из BOM-экспорта «начисто» и закрывает три связанных
UX/стабильностных дефекта, выявленных при подготовке к приёмке на SolidWorks 2025:

1. **Полный перевод BOM-маппинга на русский.** Шаблон спецификации и
   `SWTools.settings` опирались на китайские defined names / `mappingname`
   (исторически два рассинхронизированных набора). Теперь это единый русский
   набор anchors; китайский удалён полностью, включая legacy-токены в правилах
   фильтра (`机加`, `外购`).
2. **Окно «Сопоставление» (Frmmapping)** показывало только две расчётные
   колонки (`Col_Weight`, `Col_bound`). Расширено на все служебные/расчётные
   колонки `Col_*`.
3. **Кнопка «Импорт…» (Frmsetpropname)** имела `AnchorStyles.None` и уплывала к
   центру на resizable-форме. Зафиксирована в левый-нижний угол.
4. **Десериализация конфигурации** падала `System.Object из ZTool…` на «Импорт».
   `VTBinder` доработан, чтобы толерантно резолвить embedded assembly identity.

Приёмочная проверка на живой SolidWorks 2025 выполняется отдельным агентом по
ТЗ `docs/audit/phase-11-bom-export-acceptance-TZ_RU.md`.

## Changed files

- `Шаблоны спецификации/bom_шаблон.xlsx` — `xl/workbook.xml`: китайские defined
  names удалены, оставлен единый русский набор anchors на тех же ячейках
  (`Номер→A6 … Габарит→P6`); print-ranges не тронуты. Остальные части
  книги (листы, стили, ширины, merged cells) копируются байт-в-байт.
- `SWTools.settings` — `namemappinglist`: все `mappingname` переведены на русские
  токены (совпадают с defined names шаблона); из правил `FilterRulesList`
  (`$Тип$ Содержит …`) убраны китайские токены `机加`/`外购`, остались русские
  значения.
- `client-core/tools/Localizer/Program.cs` —
  `PatchBomCalculatedColumnMapping` обобщён: в «Сопоставление» попадает любая
  колонка с `Name`, начинающимся на `Col_`, кроме нерелевантных
  `Col_Checkbox`/`Col_NewFolder` (через `String.StartsWith` + явные исключения);
  в `ControlLayoutPatches` добавлен `Frmsetpropname.Button1` с `anchor=6`
  (`Bottom|Left`).
- `client-core/tools/BinderInject/donor/VTBinder.cs` — `BindToType` сначала
  пробует `Type.GetType(aqn, ResolveAssembly, ResolveType, false)`; новые
  резолверы — **instance**-методы (чтобы Roslyn не сгенерировал cached-delegate
  тип `<>O`, который бы оставил dangling-ссылку на донор-сборку), при промахе —
  старый fallback без регрессий.
- `client-core/tools/russify_bom_defined_names.py` — идемпотентный инструмент,
  которым переведён шаблон (single source of truth для русских anchors; не-op на
  уже русифицированной книге).
- `docs/production/RISK_REGISTER_RU.md` — добавлен R-015.
- `docs/audit/phase-11-bom-export-acceptance-TZ_RU.md` — ТЗ приёмки на SW 2025.
- `docs/audit/phase-11-bom-russification-implementation-report.md` — этот отчёт.

## Behavior changes

- BOM-экспорт резолвит anchor по `workbook.GetName(<mappingname|HeaderText>)`:
  токены в settings и defined names в шаблоне теперь идентичные русские, поэтому
  экспорт пишет в те же ячейки, что и раньше, но без китайских идентификаторов.
- В «Сопоставлении» пользователь видит и может вручную сопоставить все
  расчётные/служебные `Col_*` колонки, а не только две.
- Кнопка «Импорт…» остаётся в левом-нижнем углу при ресайзе диалога.
- Конфигурации с `DataTable`/`Font`/`Color`-блобами, записанными другим
  runtime/версией, десериализуются вместо `SerializationException`.

## Backward compatibility

- Целевые ячейки экспорта не изменились (A6…P6 на листе «Спецификация»).
- Сигнатуры методов и бизнес-логика экспорта не менялись — Localizer патчит
  только allow-list отображения и anchor контролов.
- `VTBinder` на промахе возвращает прежний результат, поведение для уже
  работавших блобов не меняется.

## Tests run

```powershell
$env:PATH = 'C:\dotnet;' + $env:PATH

# 1. Полный pipeline сборки клиента
cd client-core
.\build.ps1

# 2. CI-эквивалент: verify + localization scan + BOM template smoke
dotnet run -c Release --project tools\Reinjector -- --verify out\SWTools.exe
python tools\localization_scan.py `
  --exe out\SWTools.exe `
  --translations tools\Localizer\translations.tsv `
  --whitelist-dir ..\localization `
  --report out\localization-report.json `
  --fail-on-unclassified
cd ..
python build_ru_bom_template.py --out "$env:TEMP\bom_шаблон_phase11_test.xlsx"

# 3. Offline-валидатор консистентности settings/шаблон
python client-core\tools\check_bom_template.py SWTools.settings
```

## Test results

- `client-core\build.ps1`: PASS.
  - `[5/6] BinderInject verify`: PASS; `VTBinder` present, `BindToType override=yes`;
    `DeserializeBinary`/`DeserializeObject` wired (sites=1 each).
  - `[6/6] Reinjector --verify`: PASS; `dangling typerefs = 0`; в `AssemblyRefs`
    **нет** `ZBinderDonor` (cached-delegate тип `<>O` не утёк).
  - Localizer лог: `BOM mapping: enabled all calculated/service (Col_*) columns
    (edits=5)`; `Frmsetpropname resizable … control-edits=8` (патч `Button1`
    применён).
- `localization_scan.py` on `out\SWTools.exe`: PASS — `scan.han_entries=78`,
  `summary.unclassified_han=0`, translation diagnostics `0 errors`.
- `build_ru_bom_template.py`: PASS —
  `source_sha256=51c4642ae9782b9efabfc2232c00879b302a1b38df5479a2bbe986794915fff8`.
- `check_bom_template.py SWTools.settings`: `RESULT: PASS - settings/template are
  consistent for export.`
- CJK-скан затронутых артефактов: `SWTools.settings` и `bom_шаблон.xlsx` — 0 CJK;
  китайский остаётся только в build-инструментах (таблица переводов Localizer и
  список удаляемых имён в `russify_bom_defined_names.py`) — by design.

### Defined names шаблона (после русификации)

| Defined name | Ячейка | | Defined name | Ячейка |
|---|---|---|---|---|
| Номер | A6 | | Масса | J6 |
| Наименование | C6 | | ИмяФайла | L6 |
| Обозначение | D6 | | Эскиз | M6 |
| Версия | E6 | | Материал | N6 |
| ЕдИзм | F6 | | Путь | O6 |
| Количество | G6 | | Габарит | P6 |
| Тип | H6 | | _xlnm.Print_Area | A1:P75 |
| ОбработкаПоверхности | I6 | | _xlnm.Print_Titles | 1:6 |

## Manual checks

Требуется приёмочный SolidWorks 2025 smoke по
`docs/audit/phase-11-bom-export-acceptance-TZ_RU.md` (экспорт BOM на реальной
сборке, проверка заполнения всех русских колонок, поведение «Сопоставления» и
якоря «Импорт…», отсутствие ошибки десериализации на «Импорт»). Логика
binary-патча не требует пересборки для теста — достаточно подложить собранный
`SWTools.exe` в рабочую папку рантайма.

## Security notes

- Изменения только в локализации/маппинге и tolerant-binder; protocol-ключи,
  шрифты, RSA-материал не затронуты.
- `VTBinder` резолвит по короткому имени сборки/типу — не расширяет поверхность
  десериализации произвольными типами сверх того, что уже грузится в AppDomain;
  на промахе — прежний путь.
- Никаких ключей, дампов, БД или локальных секретов не добавлено.

## Migration / config changes

- Кастомные свойства деталей в SolidWorks должны использовать русские значения
  `Тип` (`Мех.обработка`/`Листовая`/`Литьё`/`Сварка`/`Покупное`/`Стандартное`),
  т.к. legacy-токены `机加`/`外购` из правил фильтра удалены.

## Rollback

Revert PR. Целевые ячейки экспорта и схема не менялись; откат возвращает прежние
китайские anchors и старое поведение «Сопоставления»/якоря/биндера.

## Audit checklist

```text
[x] Implementation report added under docs/audit/
[x] Risk register updated if needed (R-015)
[x] P0/P1 findings addressed or explicitly deferred (R-015 mitigated; SW smoke deferred to ТЗ)
[x] No private keys, DBs, dumps, tokens or local secrets committed
[ ] Runtime/client changes have manual verification (deferred to SW-2025 agent per ТЗ)
[ ] APPROVED FOR MERGE received before merge
```
