# Аудит текущего состояния кодовой базы (фокус — восстановление исходников)

Дата: 2026-06-21
Ветка/коммит базы: `main` @ `733c05b3a28725ef9c69201cf8f48037dd95ed81` (после PR #58)
Версия репозитория (`VERSION`): `1.1.5`
Инструменты проверки в этой сессии: Windows Server 2022, .NET SDK `8.0.422`,
`ilspycmd 8.2`, Python `3.12`.

> Это post-factum gap-аудит (не implementation report). Он фиксирует **фактическое**
> состояние `main` на дату, перепроверяет автоматические гейты и уточняет, что
> именно осталось сделать по задаче «восстановление исходников».
> Отправная карта задачи — [`source-recovery-roadmap_RU.md`](source-recovery-roadmap_RU.md),
> детальный план путей A→E — [`from-source-roadmap_RU.md`](from-source-roadmap_RU.md).

## 1. Краткий вывод

- **from-source клиент (EXE) собирается из `client-src` начисто** (`dotnet build -c Release`
  → 0 ошибок, 123 предупреждения — это известные артефакты декомпиляции VB→C#).
  Бренд артефакта — `SWTools`.
- **Единственный оставшийся бинарный артефакт клиента — SolidWorks-аддин**
  (`SWTools.dll` / `ZTool.dll` + `Ribbon.dll`). Его декомпиляция в исходники — это
  **Этап D**, главный и последний крупный технический долг по восстановлению.
- Аддин **частично обфусцирован** — это делает Этап D заметно труднее, чем перенос EXE
  (см. §4). Де-обфусцированного референса аддина в репозитории **нет**.
- Все доступные **автоматические гейты проходят** (§3).
- Найдены **расхождения документации и бинарей с фактом** (§5): версия в README,
  статус фаз в `client-src/README.md`, и stale-бинари в корне репозитория относительно
  принятого релиза 1.1.5.
- Боевая приёмка (live) **не закрыта**: по отчёту от 2026-06-21 открыты S7 (пустая
  таблица BOM после «Подключить SW») и L2–L5 (лицензии). Именно это в дорожной карте
  держит Этап D «на паузе».

## 2. Объект и границы

Проверялось дерево `client-src` (from-source клиент), python-инструменты `tools/` и
`client-core/tools/`, конфиги BOM, сервер лицензий `license-server/`, корневые бинари
и release-манифест `scripts/expected_release_hashes.json`. Живой прогон в SolidWorks
**не выполнялся** (нет SolidWorks/донгла в окружении) — по нему опираемся на
[`from-source-boevoy-acceptance-report_2026-06-21_RU.md`](from-source-boevoy-acceptance-report_2026-06-21_RU.md).

## 3. Автоматические гейты (перепроверено)

| Проверка | Результат | Примечание |
|---|---|---|
| `dotnet build client-src/ZTool.csproj -c Release` | **PASS** | 0 ошибок, 123 benign warnings; `ProductName=SWTools` |
| `python tools/secret_scan.py` | **PASS** | `Secret scan OK` |
| `python tools/check_no_cjk_filenames.py` | **PASS** | нет CJK в именах tracked-путей |
| `python tools/check_source_string_invariants.py --self-test` | **PASS** | |
| `python tools/check_source_string_invariants.py --root client-src` | **PASS** | 32 CJK-литерала = 32 в allow-list; 6 крипто-пассфраз на месте; 26 помечены `REVIEW` |
| `python tools/bom_export_assert.py --self-test` | **PASS** | требует `openpyxl` |
| `python client-core/tools/check_bom_template.py SWTools.settings` | **PASS** | 8 режимов BOM согласованы |
| `python client-core/tools/check_bom_template.py client-core/dist/SWTools.settings` | **PASS** | dist идентичен root |
| `python -m pytest -q` (`license-server`) | **PASS** | `117 passed, 2 skipped` |

**Важная заметка по окружению (G-6):** `pytest` для `license-server` падает (30 fail:
`async def functions are not natively supported`), если ставить пакет без dev-экстры.
Корректная установка — `pip install -e ".[dev]"` (тянет `pytest-asyncio`). Это не баг
кода, а требование к окружению; стоит закодировать в blueprint/CI, чтобы будущие сессии
не принимали это за регрессию.

## 4. Состояние восстановления исходников

### 4.1 Что уже в исходниках
- `client-src/ZTool.csproj` (`Microsoft.NET.Sdk.WindowsDesktop`, `WinExe`, `net48`) —
  162 `.cs`-файла: формы, BOM-логика, SolidWorks-interop, **своё** лицензионное ядро
  (`SR`/`SecurityCenter`/`TCPClient`/`GetRegistrycreatedtime`), ребренд SWTools и RU-локализация.
- Сторонние сборки (`NPOI*`, `itextsharp`, `ExpandableGridView`, `SharpZipLib`, `zxing`,
  `Ribbon`, `ZTool_rsa`) подключены по `HintPath` и/или встроены как manifest-ресурсы.
- Нативная `SWToolsARM.dll` копируется рядом с exe из `csproj` (`Content`/`PreserveNewest`).

### 4.2 Что НЕ в исходниках (остаток)
- **SolidWorks-аддин** `SWTools.dll` (≈544 КБ) — классы `ZTool.SwAddin`, `PMPHandler`,
  `ReName`, `DocView`, `Page_randomcolor`, `Page_RepairReference`, `customdoc`, `settings`
  и др. Подключён к EXE как пребилт-артефакт.
- **`Ribbon.dll`** — пребилт, встроен как ресурс и подключён по `HintPath`.

### 4.3 Феасибилити Этапа D (декомпиляция аддина) — ключевой риск
- `ilspycmd -l c SWTools.dll` показывает, что аддин **частично обфусцирован**: публичная
  поверхность читаема (`SwAddin`, `PMPHandler`, `ReName`, `DocView`…), но **вложенные/
  helper/closure-классы и часть типов имеют нечитабельные/не-ASCII имена** (напр.
  `Class %MmwpnK4}NCL<m,Q6r@v`Ud'$`, множество `?????…`-имён).
- В отличие от EXE, **де-обфусцированного/публицированного референса аддина в репозитории
  нет**: `client-core/ref/ZTool.public.dll` (3 323 392 байта) совпадает по размеру с
  `SWTools-base.exe` — это **публицированный EXE**, а не аддин.
- Вывод: Этап D реалистичен, но дороже переноса EXE. Сначала нужен проход деобфускации
  (de4dot или эквивалент) и ручная чистка имён, затем — компилируемый csproj аддина
  по той же схеме, что и EXE (флаг ILSpy `-ds AnonymousMethods=false`).

## 5. Расхождения «документация/бинари ↔ факт» (находки)

1. **Версия в `README.md` устарела.** Раздел «Рекомендуемая связка для развёртывания»
   говорит «release-candidate ветки **1.1.1**», тогда как `VERSION` = `1.1.5` и
   `scripts/expected_release_hashes.json` = `1.1.5`.
2. **`client-src/README.md` отстаёт по статусу фаз.** Помечает Phase 3 (ребренд + RU)
   как `▢` (не сделано), хотя по дорожной карте это перенесено в исходники в PR #50
   (Phase 3b) и присутствует в дереве (`website=license.vizbuka.ru/swtools`,
   `email=lunin021189@gmail.com`, RU-строки форм).
3. **Stale-бинари в корне репозитория vs принятый релиз 1.1.5.** Хеши корневых файлов
   не совпадают с release-манифестом:

   | Файл (корень) | SHA256 (факт) | Ожидание `expected_release_hashes.json` (1.1.5) | Статус |
   |---|---|---|---|
   | `SWTools.exe` | `a574411…73ec5` | `2a13274…63a56` | **расходится** |
   | `SWTools.dll` (аддин) | `d053542…92eb9` | `1828b29…54705` | **расходится** |
   | `Ribbon.dll` | `57e0268…24e8e` | `57e0268…24e8e` | совпадает |
   | `ExpandableGridView.dll` | `89ec31d…efcc0` | `89ec31d…efcc0` | совпадает |

   То есть в корне лежат **более старые** `SWTools.exe`/`SWTools.dll`, а принятый
   набор 1.1.5 (exe `2a13274…`, аддин `1828b29…`) в корне не закоммичен. README при этом
   рекомендует корневой `SWTools.dll` `D053542…92EB9`. Это вводит в заблуждение и
   усложняет 1:1-сверку при Этапе D/E.
4. **Версионирование from-source артефакта.** Собранный `client-src` exe несёт
   `ProductVersion=1.0`/`FileVersion=1.0` (не `1.1.5`). `VERSION` в стамп сборки не
   попадает — стоит прокинуть версию в `AssemblyInfo`/csproj, иначе release-сверка по
   версии невозможна.
5. **Остаточные вендор-артефакты в ресурсах `client-src` (низкий приоритет/REVIEW).**
   - `ZTool.Resources.resx`: ресурс `DOGURL=https://item.taobao.com/item.htm?id=638150915723`
     (вендорская ссылка на Taobao). В коде **не потребляется** (нет читателя в `.cs`),
     т.е. «мёртвый», но всё ещё **поставляется** внутри сборки.
   - Имя шрифта `微软雅黑` в дизайнере `FrmAbout` (грид `TableLayoutPanel1` скрыт в
     `zt_AboutSetup`, поэтому в UI не всплывает) и `微雅`/`华行`/`宋`/`楷` по дереву
     (помечены `REVIEW` в инварианте строк).
   - Метки `Группа QQ` (`FrmAbout`/`FrmRverify`) — текст русифицирован, сам грид контактов
     скрыт; концепт вендор-контакта остаётся в исходниках.

   Видимый домен `www.z-tool.cn`/`mail@z-tool.cn` в `client-src` **отсутствует** (проверено
   `git grep`). Зафиксированный в отчёте 2026-06-21 S2-FAIL по `z-tool.cn` относится к
   артефакту на коммите `0f0d44c` и до исходниковой чистки на тестируемой сборке; текущий
   source-About показывает ребренд-контакты.

## 6. Боевая приёмка (live) — открыто

По [`from-source-boevoy-acceptance-report_2026-06-21_RU.md`](from-source-boevoy-acceptance-report_2026-06-21_RU.md):
локальные гейты 9/9 PASS, но:
- **S7 FAIL** — после «Подключить SW» статус «Подключение завершено», но таблица деталей
  пустая (`PartHits=0`) → BOM-экспорт невалиден.
- **L2–L5 NOT RUN**, **S5/S8/S10 NOT RUN** — нужны боевая активация, серверные логи/pcap,
  реальный донгл и сверка 1:1 с принятым exe.

Эти пункты в дорожной карте и держат Этап D «на паузе до результатов L1–L5».

## 7. Рекомендации (приоритизированный план «продолжить восстановление»)

1. **Срочно/дёшево (этот PR + следующие):**
   - Синхронизировать `README.md` (версия 1.1.1 → 1.1.5) и `client-src/README.md`
     (Phase 3 → done).
   - Прокинуть `VERSION` в стамп сборки from-source (`ProductVersion`/`FileVersion`).
   - Решить судьбу stale корневых `SWTools.exe`/`SWTools.dll`: либо обновить до принятого
     1.1.5 (`2a13274…`/`1828b29…`), либо явно задокументировать, что «истина» — release-пакет,
     а корневые бинари исторические.
   - Удалить мёртвый ресурс `DOGURL` (Taobao) из `ZTool.Resources.resx`.
2. **Этап D (главный остаток):** деобфускация + декомпиляция аддина (`SWTools.dll`,
   `Ribbon.dll`) в компилируемый csproj внутри `client-src`; разом переименовать
   семантический ключ `零` (`Col_Extname`) с консьюмером в аддине (корень бага «случайный цвет»).
   Предусловие по дорожной карте — закрытие боевого L1–L5; см. §6.
3. **Этап E:** переключить релиз/инсталлятор на from-source (exe **и** аддин), вывести
   IL-реинжект (`Reinjector`/`Localizer`/`BinderInject`) в архив после паритета 1:1.
4. **Остаточный китайский:** по мере владения исходниками заменять `REVIEW`-литералы
   (имена шрифтов и т.п.); 6 крипто-пассфраз остаются навсегда (`source_required_keys.tsv`).

## 8. Открытые риски

- **Аддин не в исходниках и обфусцирован** — главный технический долг; блокирует S7, BOM
  и полный паритет; требует отдельного прохода деобфускации.
- **L1–L5 не пройдены вживую** — лицензионный поток подтверждён только локально/частично.
- **Два пути сборки сосуществуют** (IL-реинжект и from-source) — до Этапа E легко перепутать
  источник; релиз пока завязан на IL-путь.
- **Stale корневые бинари** — риск ошибочной 1:1-сверки.
