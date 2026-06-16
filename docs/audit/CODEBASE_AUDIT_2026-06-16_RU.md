# Глубокий аудит кодовой базы ZTool

- Дата: 2026-06-16
- Аудитор: Devin (роль — аудитор; исполнение правок выполняет отдельный агент на машине с SolidWorks 2025)
- База аудита: `main` @ `91fc2b5` (`docs(audit): record client production readiness gap`)
- Правовое основание работ: `docs/legal/ztool_license_agreement_signed.pdf`
  (Lic. agreement Lee Chan / z-tool.cn → V. Lunin, 2026-05-30; Art. 2.3 — реверс-инжиниринг,
  Art. 3 — замена сервера лицензий и перевыпуск ключей).

> Этот документ — независимый сводный аудит. Он не заменяет, а дополняет существующие
> внутренние отчёты (`AUDIT_ru.md`, `docs/audit/refactor-production-readiness-gap-audit-2026-06-16_RU.md`,
> `docs/production/*`). Цель — единая картина качества, рисков и готовности к продакшену,
> с привязкой находок к файлам и строкам, и вход для `REFACTORING_PLAN_2026-06-16_RU.md`.

---

## 0. Executive summary (RU)

ZTool — это **гибридный проект** из трёх слоёв с очень разной зрелостью:

1. **Сервер лицензий (Python, `license-server/`)** — зрелый, современный, хорошо
   протестированный код (async, конфиг через env, hardening протокола/БД, 112 тестов,
   ~80% покрытия). Это единственный слой, который близок к «нормальному поддерживаемому
   исходному коду».
2. **Клиент (`client-core/`, `client-rekey/`, IL-патчеры)** — НЕ исходный код приложения,
   а **декомпилированный/бинарно-пересобираемый гибрид**: горстка классов в C#, остальное —
   патчи IL/ресурсов поверх чужого `ZTool.exe`/`ZTool.dll`. Поддерживаемость ограничена,
   поведение завязано на строки, metadata-токены, обфускацию и реестр SolidWorks.
3. **Активы локализации/BOM/шаблоны/макросы** — рабочие, но с временными заглушками,
   захардкоженными путями и ручными процедурами вместо автоматических гейтов.

**Главный вывод:** инфраструктурная часть (сервер, CI, упаковка, безопасность) —
release-candidate-ready. Клиентская часть **не доказана** на семантический паритет с
оригиналом внутри SolidWorks: ключевой гейт (Phase 11 — string-invariants + registry
preflight + живой parity-тест) написан, но **не влит в `main`** (ветка
`origin/devin/1781595783-phase11-string-registry-gates`). Поэтому статус корректно
формулировать как **«hardening merged, client production acceptance not complete»**.

**Топ-блокеры до продакшена** (детали в §6 и в плане рефакторинга):
- B1. Гигантский memory-dump в Git LFS (3.1 ГБ) **ломает чистый clone** (LFS budget exceeded).
- B2. Клиент не имеет автоматического доказательства паритета (цвета/материалы/BOM/чтение).
- B3. Phase 11 гейты не в `main`; несколько готовых веток/PR не слиты.
- B4. Локализация классифицирует строки по языку, а не по роли → риск перевода ключей
  (баг с `零件`/«Деталь» уже случался).
- B5. Захардкоженные абсолютные пути (`D:\ZTool\...`) и временные заглушки в шаблонах/макросах.
- B6. Стратегия языков (команды EN / UI RU+EN) ещё не реализована: EN-локаль есть только
  как reference-YAML, англоязычной сборки нет; правовой основы на распространение EN-версии
  третьим лицам пока нет (Art. 2.2).

## 0b. Executive summary (EN)

ZTool is a **hybrid** of three layers of very different maturity: a mature, well-tested
Python **license server**; a **decompiled/binary-reinjected client** (not real application
source); and working-but-rough **localization/BOM/template/macro** assets. Server +
infrastructure are release-candidate ready; the **client is not proven** for semantic parity
inside SolidWorks. The decisive gate (Phase 11) exists on a branch but is **not merged to
`main`**. Top blockers: a 3.1 GB memory dump in Git LFS that breaks clean clones; no automated
client parity proof; unmerged ready branches; localization classifying strings by language
rather than role; hard-coded absolute paths and placeholder values; and the EN/RU language
strategy not yet implemented (and third-party distribution of an EN build still needs the
Licensor's written consent per Art. 2.2).

---

## 1. Объём и методика аудита

Проверено:

- Структура репозитория, `.github/workflows/*`, `.gitattributes`, `.gitignore`.
- `license-server/` — код, тесты, конфиг; локальный прогон `pytest` с покрытием.
- `client-core/` — `README`, `build.ps1`, `src/*.cs`, инструменты (`Publicizer`, `Reinjector`,
  `Localizer`, `BinderInject`, `PmpGuardPatch`, `NullModalGuard`, `RenameAssembly`).
- `client-rekey/` — патчер и его входные данные.
- Локализация: `client-core/tools/Localizer/translations.tsv`, `localization/whitelist_*`,
  `locale/{ru,en}/bom_modes.yaml`.
- Работа со свойствами документов: `SolidWorksTemplates/*`, `tools/sw-macros/WriteRussianProps.vbs`.
- История PR (#1–#27 + hardening 00–10), незакрытые ветки, существующие планы/риск-регистры.

Не выполнялось (вне возможностей VM аудитора, передаётся исполнителю с SW 2025):
- запуск `ZTool.dll`/`ZTool.exe` внутри SolidWorks, живые parity-тесты, проверка реестра.

Воспроизведённые факты:
- `license-server`: `pip install -e ".[dev]"` → `pytest` = **112 passed, 2 skipped**, покрытие **80%**.
- Чистый `git clone` падает на smudge LFS: `This repository exceeded its LFS budget` (см. §6 B1).

---

## 2. Архитектура (как есть)

```
            ┌─────────────────────────── SolidWorks 2025 ───────────────────────────┐
            │  ZTool.dll (COM add-in, лента/PropertyManager, чтение сборок/BOM)        │
            │        │ IPC (WM_COPYDATA, рукопожатие "ZToolRequest@001"+Getpkt())      │
            │        ▼                                                                 │
            │  ZTool.exe (лаунчер: управление файлами, печать, PDF, экспорт BOM)       │
            └────────┬─────────────────────────────────────────────────────────────┘
                     │ TCP :58000  [type:10 LE][len:10 LE][AES body]
                     ▼
            license-server (Python, asyncio) ── SQLite (коды, привязки, лимиты, переносы)
                     │  подпись лицензии НАШИМ RSA-1024 private key
                     ▼
            client-rekey: в ZTool.exe вшит НАШ public key + наш адрес сервера
```

Сборка клиента (`client-core/README.md`):
`Publicizer` (все члены → public, ref-only) → компиляция `src/*.cs` в `ZTool.Core.dll`
→ `Reinjector` переносит IL-тела «наших» методов в свежую копию оригинального `ZTool.exe`.
Локализация и точечные фиксы — через `Localizer`/`BinderInject`/`PmpGuardPatch`/`NullModalGuard`.

**Следствие для поддержки:** в исходниках живут только `SR`, `SecurityCenter`, `TCPClient`,
`GetRegistrycreatedtime` (+ donor-байндеры). Всё остальное — vendor-бинарь, правится патчами.

---

## 3. Оценка по компонентам

### 3.1 license-server (Python) — зрелость: ВЫСОКАЯ

Плюсы:
- Чёткая модульность: `crypto/`, `protocol/`, `db.py`, `server.py`, `cli.py`, `config.py`,
  `key_provider.py`, `logging_utils.py`, `machineid.py`, `license_blob.py`.
- Production-hardening: env-конфиг, запрет DEBUG в production, лимиты TCP-кадров,
  fail-closed на malformed/oversized, redaction секретов в логах.
- БД: `PRAGMA foreign_keys/WAL/busy_timeout`, версионирование схемы, идемпотентные миграции,
  переход plaintext-паролей в `pbkdf2_sha256`, `device_limit`.
- Ops: healthcheck, backup через SQLite backup API, restore-drill, deploy (systemd/docker),
  monitoring/alerts.
- Тесты: 112 passed / 80% покрытия; протокол, лимиты, активация/перенос, миграции, secrets-logging.

Замечания (улучшения, не блокеры):
- Покрытие `server.py` 68%, `cli.py` 51%, `logging_utils.py` 59% — добить тестами «горячих» путей.
- `ruff` намеренно ограничен (`E9,F63,F7,F82`) — для продакшена расширить стиль-гейт постепенно.
- Слабая крипта (RSA-1024 без паддинга, DES, MD5) — **вынужденная совместимость** с vendor-форматом;
  риск задокументирован, но для англоязычного продакшена нужно явное приёмочное решение
  (см. `docs/security/THREAT_MODEL_RU.md`).

### 3.2 client-core / client-rekey (C# + IL-патч) — зрелость: НИЗКАЯ-СРЕДНЯЯ

Факты:
- `src/TCPClient.cs` и др. — **декомпилят** (артефакты `Microsoft.VisualBasic`,
  `ProjectData`, `Operators`, `Conversions`; китайские имена enum, напр.
  `client-core/src/TCPClient.cs:15-35`).
- Захардкоженные шифр-константы адреса/порта прямо в коде
  (`client-core/src/TCPClient.cs:50-52, 108-109`).
- Логи с китайскими литералами в коде (`client-core/src/TCPClient.cs:98,142`).
- `client-rekey` патчит готовую сборку: замена vendor public key ×18, адрес/порт ×2,
  версия → `1.0` (`client-rekey/README.md`).

Риски:
- Поведение зависит от строк/токенов/обфускации/реестра; обычные unit-тесты покрывают
  только реконструированные классы, не весь runtime.
- Любая правка vendor-методов вне `src/` — снова IL-патч, легко занести регресс.

### 3.3 IL-инструменты (`Publicizer`/`Reinjector`/`Localizer`/`BinderInject`/…) — зрелость: СРЕДНЯЯ

- Подход воспроизводимый и fail-closed (input-hash gate, `Reinjector --verify`,
  `dangling typerefs = 0` — см. `docs/client-core/BINARY_BUILD_POLICY_RU.md`).
- Но это **build-pipeline для патчей**, а не владение исходниками (см. §5).
- `BinderInject` (`SafeListBinder`/`VTBinder`) закрывает небезопасную десериализацию — хорошо.

### 3.4 Локализация — зрелость: СРЕДНЯЯ

- `translations.tsv` (382 строки) + whitelist'ы (`localization/whitelist_*`).
- **Системный дефект процесса:** строки классифицируются по языку (Han → перевести),
  а не по роли (UI-текст vs внутренний ключ/enum/tag). Это уже привело к багу `零件`→«Деталь»
  в логике цветов/материалов (`Frmmain`), см. gap-аудит §«Почему прошёл баг с цветами».
- `localization_scan.py` ловит неклассифицированные Han, но не отличает «видимый текст» от
  «семантического ключа».
- EN-слой существует только как reference (`locale/en/bom_modes.yaml`), активной EN-сборки нет.

### 3.5 Работа со свойствами документов / BOM — зрелость: СРЕДНЯЯ

- Имена свойств — ЕСКД на русском (`SolidWorksTemplates/properties.txt`,
  `template.prtprp`): `Наименование`, `Обозначение`, `Материал`, `Тип`, `Версия`,
  `Масса`, `Обработка поверхности`, `Бренд`, `Разработал`, `Дата разработки`, `Количество`.
- `<mappingname>` в `ZTool.settings` намеренно остаётся CN (Excel-anchor) — это корректно
  и задокументировано (`tools/sw-macros/README.md:10-12`).
- **Захардкожен абсолютный путь** `D:\ZTool\SolidWorksTemplates\*.txt` в `template.prtprp`
  (источники ComboBox) — ломает переносимость установки.
- **Временная заглушка** классификации `Тип` = `Мех.обработка`/`Сборка` в
  `tools/sw-macros/WriteRussianProps.vbs` (константы `T_PART`/`T_ASSEMBLY`) — фильтр-режимы
  BOM зависят от неё, реальная классификация (Покупное/Литьё/Сварка) не задана.

### 3.6 CI / релиз / упаковка — зрелость: СРЕДНЯЯ-ВЫСОКАЯ

- 3 workflow: `license-server.yml` (ruff/compile/bandit/pytest+cov),
  `client-core-windows.yml` (build+reinject verify + localization scan + BOM smoke),
  `secret-scan.yml` (tracked-secret scan + release manifest smoke).
- Упаковка: `manifest.json`, `SHA256SUMS.txt`, запрет лишних файлов, проверка
  `SolidWorksTools.dll`/`MyMaterials.sldmat`/`materialpath`.
- **Пробел:** нет CI-гейта на семантический паритет клиента (он принципиально требует SW),
  и нет registry-preflight как обязательного шага приёмки.

---

## 4. Состояние тестового покрытия

| Слой | Тип тестов | Состояние |
|------|-----------|-----------|
| license-server | unit + integration (pytest) | 112 passed / 2 skipped / **80%** покрытия |
| client-core | unit | только реконструированные классы; runtime не покрыт |
| client (SW) | ручные/полуручные | методики есть (`docs/release/FULL_TEST_METHODOLOGY_RU.md`), но не исполняемые гейты |
| BOM | smoke + ручные ретесты | 8/8 режимов подтверждены вручную (PR #8), нет автозапуска parity |

Главный разрыв: **ручные методики не превращены в исполняемые регрессии** (риск R-C6 из gap-аудита).

---

## 5. Почему это не «полноценный исходный код»

Подтверждается `client-core/README.md` и gap-аудитом: методы вне `src/` остаются vendor-бинарём;
формы/меню/часть логики и `ZTool.dll` правятся ресурсами/IL. Это поддерживаемый pipeline,
но не владение исходниками. Цель пользователя «полный исходный код с лёгкой поддержкой»
достижима только через **Вариант B** (реконструкция исходного клиента) — дорого и долго,
но это единственный честный путь к «обычной» поддерживаемости. Вариант A (строгий бинарный
pipeline + гейты) реалистичен для ближайшего релиза.

---

## 6. Реестр находок (severity)

Severity: **P0** — блокер продакшена/доступности; **P1** — высокий; **P2** — средний; **P3** — низкий.

| ID | Sev | Находка | Доказательство | Рекомендация |
|----|-----|---------|----------------|--------------|
| B1 | P0 | Memory-dump 3.1 ГБ в Git LFS ломает чистый clone (budget exceeded) | `dumps/full-memory-20260609-081854/*.dmp.part00{1,2}` (1.6+1.5 ГБ); `git clone` → smudge error | Убрать дампы из LFS/истории (`git filter-repo`/BFG), хранить вне Git (release asset/внешнее хранилище); оставить только README с инструкцией восстановления |
| B2 | P0 | Нет автоматического доказательства паритета клиента | gap-аудит §«Что не было закрыто»; нет parity-гейта в CI | Реализовать `client-semantic-parity` (Phase 11): чтение N позиций, BOM 8/8, материал/ручной/случайный цвет, save→reread, JSON+скрины |
| B3 | P1 | Готовые ветки/PR не слиты в `main` | `origin/devin/1781595783-phase11-string-registry-gates` (Phase 11), `…-release-acceptance-ci`, `…-fix-db-bare-path`, `docs-*` | Ревью и merge по порядку зависимостей; зафиксировать в плане |
| B4 | P1 | Локализация по языку, а не по роли (риск перевода ключей) | баг `零件`→«Деталь» в `Frmmain`; `localization_scan.py` не различает роль | `internal-string-invariants` тест: сравнение оригинал/локализ. по whitelisted internal keys, fail на новый перевод vendor-key |
| B5 | P2 | Захардкоженный путь `D:\ZTool\...` и заглушки `Тип` | `SolidWorksTemplates/template.prtprp` (Data Path); `tools/sw-macros/WriteRussianProps.vbs` (T_PART/T_ASSEMBLY) | Параметризовать путь установки (относительный/переменная); задать реальную классификацию `Тип` |
| B6 | P1 | EN/RU стратегия (команды EN, UI RU+EN) не реализована | только `locale/en/bom_modes.yaml` (reference), нет EN-сборки | См. §7 — спроектировать ресурсную модель; для распространения EN третьим лицам нужен Art. 2.2 consent |
| Q1 | P2 | Покрытие `server.py`/`cli.py`/`logging_utils.py` ниже 70% | прогон pytest --cov | Добить тесты горячих путей сервера и CLI |
| Q2 | P2 | `ruff` гейт намеренно узкий | `pyproject.toml` `select=["E9","F63","F7","F82"]` | Поэтапно расширять стиль-линт без «большого рефакторинга» |
| Q3 | P3 | Клиентский код — декомпилят с CN-идентификаторами/VB-артефактами | `client-core/src/*.cs` | В рамках Варианта B — переименование/очистка; иначе задокументировать как vendor-surface |
| S1 | P2 | Слабая крипта (RSA-1024 no-pad/DES/MD5) — vendor-совместимость | `crypto/*`, bandit skips в `pyproject.toml` | Зафиксировать как принятый риск + план миграции при возможности |
| H1 | P3 | Дублирующиеся/исторические доки и mojibake-имена в прошлом | `DOC_AUDIT_2026-06-14_RU.md` | Поддерживать `docs/INDEX.md` как единственный указатель |

Примечание по секретам: приватный RSA-ключ в репозитории **не найден**; `client-rekey/new_*.txt` —
это шифртекст/подпись (безопасно), `license-server/keys/` содержит только `public_key.txt`.

---

## 7. Стратегия языков: команды — EN, интерфейс — RU+EN

Цель пользователя: «команды на английском, интерфейс на русском и английском» (нативность +
будущая англоязычная аудитория). Рекомендация по реализации (детали — в плане рефакторинга):

1. **Разделить три класса строк** во всём клиенте и активах:
   - *internal keys / commands* — НЕ переводить, всегда стабильный инвариант (рекоменд. латиница/EN
     как канонический ключ): enum-значения, `Tag`, фильтр-операторы, протокол-ключи, anchor'ы Excel.
   - *visible UI text* — переводимо, поставляется ресурсами на RU и EN.
   - *technical logs* — отдельный whitelist (не пользовательский UI).
2. **Ресурсная модель локали:** взять за образец `locale/{ru,en}/bom_modes.yaml` и расширить до
   полного UI-словаря (RU + EN), а в бинаре/настройках использовать **стабильные ключи**, а не
   локализованный текст. Это снимает корень бага `零件` (роль вместо языка).
3. **Сборки:** один pipeline, два набора ресурсов (RU, EN). На ближайший релиз — RU как основной,
   EN как переключаемый. Активация EN — заменой ресурсных строк, без правки логики.
4. **Правовое:** распространение EN-версии третьим лицам = распространение по Art. 2.2 →
   требуется письменное согласие Lic. (Lee Chan) или расширение договора. Для собственного
   использования ограничений нет.

---

## 8. Рекомендация по статусу

- **Не объявлять `main` production-ready** только по hardening-фазам.
- Текущий честный статус: **«release-candidate infrastructure ready; client production
  acceptance not complete»**.
- Перед GO обязательны: B1 (доступность репо), B2+B3+B4 (паритет/гейты/merge), затем приёмка по
  `docs/release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md`.
- Разделять статусы: `hardening complete` → `client parity complete` → `production GO`.

Конкретные шаги, приоритеты, критерии приёмки и распределение «аудитор vs исполнитель на SW 2025» —
в `docs/audit/REFACTORING_PLAN_2026-06-16_RU.md`.
