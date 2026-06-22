# Аудит: сборка из исходников и состояние source-recovery

Дата: 2026-06-22
Ветка аудита: ответвление от `main` @`7856acf` (v1.1.6, после merge PR #60)
Связанный фронт работ: PR #62 (Этап D — аддин из исходников)
Фокус: «довести до ума исходники и нормальную сборку приложения из исходников».

Это gap-аудит с локальной перепроверкой сборки, а не отчёт о живом прогоне на
SolidWorks. Живой статус — см. §6.

## 1. Вывод

Путь сборки **из исходников** доведён до рабочего состояния по всем компонентам
клиента и подтверждён локально на чистой машине (.NET SDK 10.0.301, net48
targeting pack):

- `client-src` (EXE) — собирается из исходников, бренд `SWTools`, версия `1.1.6`.
- `client-src-addin` (аддин SolidWorks, PR #62) — собирается из исходников в
  `ZTool.dll`, NoPIA соблюдён, COM-идентичность и регистрация сохранены 1:1.
- Все автоматические гейты (string-invariants, no-CJK, BOM-шаблон, license-server
  pytest, secret-scan) — PASS.
- CI PR #62 после фикса (`ReflectionOnly` → Windows PowerShell) — полностью зелёный.

Этим закрывается последний бинарный артефакт клиента: после merge PR #62 весь
клиент (EXE + аддин) собирается из читаемого C#. Остаются: переключение
релиза/инсталлятора на from-source (Этап E), живое подтверждение from-source
аддина на SolidWorks (S7/L3–L5) и косметическая чистка остаточного китайского.

## 2. Что перепроверено локально (все PASS)

| Проверка | Результат |
|---|---|
| `dotnet build client-src/ZTool.csproj -c Release` | PASS — 0 ошибок, 123 benign warning; `ProductName=SWTools`, `ProductVersion=1.1.6`, `FileVersion=1.1.6` |
| `client-src` runtime self-contained | PASS — `SWToolsARM.dll` копируется рядом с `ZTool.exe` (csproj `<Content>`), закрывает PREP-FAIL из отчёта #54 |
| `dotnet build client-src-addin/sdk-shim/SolidWorksTools.Shim.csproj -c Release` | PASS — 0/0 |
| `dotnet build client-src-addin/ZTool.SwAddin.csproj -c Release -p:SolidWorksToolsPath=<shim>` | PASS — 0 ошибок, 6 benign warning; выход `ZTool.dll` |
| NoPIA-проверка produced add-in (Windows PowerShell, `ReflectionOnlyLoadFrom`) | PASS — `Assembly=ZTool`, без ссылок `SolidWorks.Interop.*`, interop-DLL не скопированы |
| `dotnet build client-core/tools/Deobfuscator -c Release` + прогон по `SWTools.dll` | PASS — 957 переименований (types=38 methods=163 fields=401 props=120), 7 generic memberref repaired |
| `check_source_string_invariants.py --self-test` | PASS |
| `check_source_string_invariants.py` (client-src + client-src-addin) | PASS — 32 CJK-литерала зарегистрированы, 6 крипто-пассфраз присутствуют |
| `check_no_cjk_filenames.py` | PASS |
| `check_bom_template.py SWTools.settings` / `client-core/dist/SWTools.settings` | PASS |
| `bom_export_assert.py --self-test` | PASS |
| `pytest -q license-server` (после `pip install -e ".[dev]"`) | PASS — 117 passed, 2 skipped |
| `secret_scan.py` | PASS |

Окружение: на машине отсутствовал .NET SDK и NuGet-источник; установлены
`dotnet-sdk 10.0.301` + `netfx-4.8-devpack`, добавлен источник `nuget.org`.
Эти шаги внесены в blueprint окружения, чтобы from-source сборка была доступна
сразу в будущих сессиях.

## 3. Состояние аддина из исходников (Этап D, PR #62)

- **Вход деобфускатора** — принятый бинарь аддина `SWTools.dll` (внутреннее имя
  сборки `ZTool`), обфусцированный переименованием идентификаторов невидимыми
  Unicode-символами (bidi/zero-width). Строки и SolidWorks-коллбэки (`Menu0_0`,
  `openZtool`, `PMPEnable_3`) — валидные имена и не трогаются.
- **Деобфускатор** (`client-core/tools/Deobfuscator`, dnlib) переименовал 957
  идентификаторов. Нетривиальная часть — `MemberRef` к членам *generic*-типов
  (`Foo<Bar>.member`): их `Name` — отдельная строка, не обновляемая при
  переименовании `*Def`; инструмент проходит IL-операнды и чинит 7 таких ссылок.
- **Результат:** в восстановленном C# (`client-src-addin`, 33 `.cs`-файла) —
  **0** невидимых/format-идентификаторов (проверено сканом по Cf/Cc-категориям).
- **COM-идентичность сохранена 1:1:** `[Guid("59959DFA-3229-4B86-852E-52ABF2BDB8C0")]`
  совпадает с GUID регистрации принятого аддина (тот же ключ
  `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-…}`). В исходниках есть
  `ComRegisterFunction`/`ComUnregisterFunction` (запись `InprocServer32`,
  `ProgId`, `AddInsStartup`), `[SwAddin(...)]`, `[ComVisible(true)]` — значит
  собранный `ZTool.dll` регистрируется `RegAsm` и грузится SolidWorks так же,
  как принятый бинарь.
- **NoPIA:** `SolidWorks.Interop.*` подключены из NuGet с `EmbedInteropTypes`;
  в `ZTool.dll` нет ссылок на interop-сборки, фасадные COM-типы встроены и
  биндятся к установленному SolidWorks по GUID интерфейса. SDK-хелпер
  `SolidWorksTools.dll` — `Private=false` (не копируется/не шипуется).
- **CI compile-gate:** на раннерах SolidWorks нет, поэтому собран минимальный
  committed shim (`sdk-shim`, поверхность `SwAddinAttribute`/`BitmapHandler`);
  workflow собирает shim → аддин, проверяет NoPIA и гоняет string-invariants.

Замечание по версии сборки аддина: `AssemblyVersion=1.0.0.0`,
`AssemblyFileVersion=1.8.3.0`, бренд-строки `AssemblyProduct/Title/Company="ZTool"`.
Это воспроизводит исходный аддин; для паритета это не блокер (COM-идентичность
определяется GUID, а не версией), но при Этапе E стоит решить, выравнивать ли
file/product-версию аддина с EXE (`1.1.6`).

## 4. Найдено и исправлено в этом фронте (PR #62)

1. **CI client-src-addin падал** на шаге verify: `Assembly.ReflectionOnlyLoadFrom`
   недоступен под `pwsh` (.NET) на раннере. Шаг переведён на `shell: powershell`
   (Windows PowerShell, desktop .NET Framework). Подтверждено локально.
2. **Деобфускатор, `IsSerializable`** проверял `type.BaseType.FullName ==
   "...ISerializable"`, но `ISerializable` — интерфейс, а `BaseType` всегда
   базовый класс → проверка никогда не срабатывала (мёртвый код относительно
   заявленного намерения «беречь `[Serializable]` и `ISerializable`»). Исправлено
   обходом `TypeDef.Interfaces`. Прогон по `SWTools.dll` до/после фикса даёт
   **идентичный** результат (957: 38/163/401/120) → восстановленный исходник не
   меняется, регенерация не нужна.
3. **`release-acceptance.yml`** сканировал `client-src` **и** `client-src-addin`
   на string-invariants, но в `paths`-фильтре был только `client-src/**`. Добавлен
   `client-src-addin/**` в оба фильтра (`pull_request`/`push`), чтобы поломанный
   инвариант аддина ловился своим воркфлоу, а не блокировал чужой PR.

## 5. Дрейф «документация/бинари ↔ факт» (на `main` @1.1.6)

| Находка | Деталь | Приоритет |
|---|---|---|
| `README.md` версия | «release-candidate ветки **1.1.1**», тогда как `VERSION`=`1.1.6` | P2 — исправлено в этом PR (→ 1.1.6, ссылка на `expected_release_hashes.json`) |
| `README.md` хеш аддина | таблица указывает `SWTools.dll = D053542…92EB9` — это **старый** бинарь, а принятый 1.1.6 аддин — `1828b290…254705` | P2 — README переведён на single-source-of-truth (`scripts/expected_release_hashes.json`) |
| Корневые `SWTools.dll`/`SWTools.exe` | stale относительно принятого пакета 1.1.6: root `SWTools.dll`=`d053…92eb9`, `SWTools.exe`=`a57441…73ec5`; манифест 1.1.6 ожидает аддин `1828b290…`, exe `3a90a13c…` | P1 — задокументировано; **намеренно не подменяю** бинари (релиз-решение, Этап E их выводит из репо) |

Корень дрейфа — гибридная модель: принятый рантайм живёт в
`releases/1.1.6/SWTools-1.1.6-Setup.exe` (инсталлятор), а корневые loose-бинари
остались от ранних версий. Это аргумент в пользу скорейшего Этапа E
(релиз/инсталлятор из from-source, удаление loose-бинарей).

## 6. Живой статус (по существующим отчётам, не перепроверялось вживую)

- **L2 (онлайн-активация) — PASS** на 1.1.6 через инсталлятор
  (`swtools-live-activation-report_2026-06-22_RU.md`): ввод ключа, серверный
  `activate/accepted`, `machine_bound=true`, рестарт в `SWTools 1.1.6(x64)`.
  Зафиксировано обязательное условие: на сервере должны быть выставлены **обе**
  переменные версии `ZTOOL_CLIENT_VERSION=1.1.6` и `SWTOOLS_CLIENT_VERSION=1.1.6`.
- **From-source аддин на SolidWorks — НЕ закрыто.** Отчёт #54
  (`from-source-boevoy-acceptance-report_2026-06-21_RU.md`) фиксировал S7 FAIL
  (после `Подключить SW` таблица пустая, `PartHits=0`) — но он снят **до** того,
  как from-source аддин был зарегистрирован через `RegAsm`. После merge PR #62
  S7 нужно перепроверить именно с from-source `ZTool.dll`, зарегистрированным в
  SolidWorks (это и есть гипотеза причины пустой таблицы).
- **S5/S6/S8/S10 и L3–L5** — требуют живого стенда (SolidWorks + донгл/сервер),
  в этом окружении недоступны.

## 7. Рекомендации (приоритизировано)

1. **P0 — смержить PR #62** (CI зелёный): закрывает последний бинарный артефакт
   клиента, даёт from-source аддин.
2. **P1 — живой S7/L3–L5 на from-source аддине.** На машине с SolidWorks:
   `RegAsm client-src-addin/bin/Release/net48/ZTool.dll /codebase`, открыть
   `TestModel/0614-A00.SLDASM`, `Подключить SW`, проверить заполнение таблицы и
   8/8 BOM-экспорт; затем L3–L5 против боевого сервера.
3. **P1 — Этап E:** переключить пакет/инсталлятор на from-source EXE+аддин,
   удалить loose root-бинари и IL-реинжект (`Reinjector`/`Localizer`) после
   паритета 1:1. Это снимает источник дрейфа из §5.
4. **P2 — косметика локализации аддина:** `SwAddin.Description="ZTool高辅工"` и
   `Title="ZTool"` видны в менеджере надстроек SolidWorks; при ребренде заменить
   на `SWTools` + RU. Выполнять вместе с переименованием семантического ключа
   `零` (продьюсер в EXE `Frmmain`, консьюмер в аддине — менять обе стороны разом).
5. **P2 — шрифты:** заменить CJK-имена шрифтов (`微雅`/`华行`/`宋`/`楷`) на латинское
   семейство (напр. `Segoe UI`); они помечены `REVIEW` в allow-list.

## 8. Остаточные риски

| Риск | Статус |
|---|---|
| From-source аддин не подтверждён вживую на SolidWorks (S7) | Открыт; компилируется и регистрируется по исходникам, но live BOM не снят с from-source `ZTool.dll` |
| Loose root-бинари stale относительно принятого 1.1.6 | Открыт; закрывается Этапом E |
| Остаточный «несущий» китайский (крипто-пассфразы, ключ `零`, шрифты, Description аддина) | Контролируемо: крипто-пассфразы PERMANENT в `source_required_keys.tsv`; остальное помечено `REVIEW`, гейт не даёт вернуться видимому UI-китайскому |
| Версия/бренд аддина (`ZTool`, 1.0.0.0/1.8.3.0) vs EXE (`SWTools` 1.1.6) | Низкий; COM-идентичность по GUID, не по версии; решить при Этапе E |
