# Текущий аудит состояния проекта

Дата: 2026-06-17  
Ветка: `codex/fix-split-delete-summary-columns`  
База аудита перед фиксацией этого отчёта: `637a5f1034eb7cec46a03edc6fe5307b9de5da96`

## Вывод

Проект находится в состоянии **release-candidate / offline + live smoke + A/B UI
checked + strict BOM fixture checked + clean package checked**. Сервер
лицензирования, клиентский binary/IL pipeline, release package verifier,
SolidWorks/BOM smoke, строгий `BOM-07/08` fixture, A/B UI material-color gate и
live `REG-09` выглядят здоровыми. Clean production package gate закрыт
отдельным clean worktree с `manifest.git.dirty=false` и
`SolidWorksTools.dll=true`. Остаточные ограничения для абсолютного `FULL PASS`:
ribbon-launch original CN не заявлен как отдельный PASS, а fixture RU запускался
через COM callback add-in `openZtool(0)` из-за нестабильных координат ленты.
Excel cell-fill parity принят out of scope: для цветов достаточно
`COL-UI PASS`.

## Что проверено

GitHub:

- Для базового HEAD `637a5f1` GitHub connector не вернул commit statuses и
  workflow runs.
- Для текущего HEAD `ff6fcca` combined statuses всё ещё пустые, но GitHub
  Actions workflow runs есть и завершились успешно: `secret-scan`, `client-core-windows`.

Автоматические gates:

| Проверка | Результат |
| --- | --- |
| `git diff --check` | PASS |
| `python tools/secret_scan.py` | PASS |
| `python -m compileall -q license-server/ztool_license_server license-server/tests` | PASS |
| `python -m pytest -q license-server` | PASS: `112 passed, 2 skipped` |
| `python -m pytest -q --cov=ztool_license_server --cov-report=term-missing` | PASS: total coverage `80%`, `112 passed, 2 skipped` |
| `python -m pytest -q -W error::ResourceWarning license-server` | PASS: `112 passed, 2 skipped` |
| `python -m ruff check license-server` | PASS |
| `python -m bandit -q -r license-server/ztool_license_server -c license-server/pyproject.toml` | PASS |
| `dotnet --list-sdks` | PASS: `8.0.422`, `10.0.301`; в текущем Codex-процессе потребовалось временно добавить `C:\Program Files\dotnet` в `PATH`, machine `PATH` уже содержит этот путь |
| `powershell -NoProfile -ExecutionPolicy Bypass -File client-core/build.ps1` | PASS после обновления process `PATH`: output hash `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD` |
| `dotnet run -c Release --project client-core/tools/Reinjector -- --verify client-core/out/ZTool.exe` | PASS: `dangling typerefs = 0` |
| `dotnet run -c Release --project client-core/tools/BinderInject -- verify client-core/out/ZTool.exe` | PASS |
| `python client-core/tools/localization_scan.py --exe client-core/out/ZTool.exe ... --fail-on-unclassified` | PASS: `errors=0`, `warnings=0`, `unclassified_han=0` |
| `python client-core/tools/check_bom_template.py ZTool.settings` | PASS |
| `python client-core/tools/check_bom_template.py client-core/dist/ZTool.settings` | PASS |
| `python build_ru_bom_template.py --out ...` | PASS |
| Clean release package + `scripts/verify_release_package.ps1 -RequireSolidWorksTools -AllowDirtyManifest` | PASS: `release-audit-clean/ZTool-1.0.0-20260616-200601`, `solidworks_tools_included=true`, runtime/settings/templates OK |
| Clean production package from detached clean worktree + `verify_release_package.ps1 -RequireSolidWorksTools` | PASS: `manifest.git.dirty=false`, `SolidWorksTools.dll=true`, `SHA256SUMS`/manifest verified |
| `python client-core/tools/check_bom_template.py <clean-package>/runtime/ZTool.settings` | PASS: 8 BOM modes, material library path OK, `usematerialcolor=true` |
| `python client-core/tools/validate_bom_exports.py manual-test-reports/FULL_TEST_20260617-auto-attempt/bom-exports` | PASS/WARN: BOM-01…06 PASS, BOM-07/08 exported but filter result is 0 rows on model without matching `Тип` values |
| `python client-core/tools/validate_bom_exports.py manual-test-reports/FULL_TEST_20260617-bom-filter-fixture/bom-exports` | PASS: 8/8, строки `29/32/6/25/29/32/18/6` |
| strict `BOM-07/08` type check on fixture exports | PASS: `BOM-07` 18 строк, `Тип=Мех.обработка`, пустых `0`; `BOM-08` 6 строк, `Тип=Покупное`, пустых `0` |
| `python -m ruff check client-core/tools/validate_bom_exports.py` | PASS |
| `python -m py_compile client-core/tools/validate_bom_exports.py` | PASS |

Проверенные runtime-хеши:

| Файл | SHA256 |
| --- | --- |
| `ZTool.exe` | `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD` |
| `ZTool.dll` | `D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9` |
| root/dist `ZTool.settings` | `743FE534D381EAB0394EA6E6D885C5C8E1C79962B447C6A5E9989A002CF14FCE` |
| clean package `runtime/ZTool.settings` | `B1B2DC0635CCEDA8A15F0CC97E0B9AD64C68F7E8124AF735D8AB632C34701CE3` |
| live-run mutated `runtime/ZTool.settings` | `C1878CA67FBE471462BE72C10A263C42C0BB58E66CDA66538595BB1F02FB6806` |
| `client-core/dist/ZTool_binderfix.exe` | `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD` |
| `SolidWorksTools.dll` | `3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3` |

Живой SolidWorks-прогон:

- Отчёт и артефакты: `manual-test-reports/FULL_TEST_20260617-auto-attempt/`.
- Live-run package: `release-audit/ZTool-audit-swtools-20260616-193645/`.
- Clean verifier package after live run:
  `release-audit-clean/ZTool-1.0.0-20260616-200601/`, verifier PASS.
- `RegAsm runtime/ZTool.dll /codebase`: PASS; registry `CodeBase` указывает на
  текущий `runtime/ZTool.dll`.
- SolidWorks открыт через `TestModel/0614-A00.SLDASM`: `SOLIDWORKS Premium 2025
  SP3.0 - [0614-A00.SLDASM *]`.
- ZTool запущен из ленты SolidWorks; process path:
  `release-audit/ZTool-audit-swtools-20260616-193645/runtime/ZTool.exe`, hash
  `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD`.
- `Подключить SW`: PASS, UI status `Подключение завершено ... всего 29 поз.`,
  таблица содержит 29 строк.
- `REG-08`: smoke PASS; видимые заголовки таблицы не показывают служебные
  SummaryInfo-колонки по умолчанию.
- BOM export: 8 файлов созданы. BOM-01…06 валидированы как PASS:
  29/32/6/25/29/32 строк, BOM-05/06 содержат 29/32 эскиза. BOM-07/08 созданы,
  но фильтры вернули 0 строк; это классифицировано как WARN для демо-модели без
  совпадающего свойства `Тип`.
- Event Viewer: нет новых `ZTool`/`SolidWorks`/`.NET Runtime`/WER/Application
  Error событий с начала live-прогона; найденный `vivaldi.exe` crash не связан с
  ZTool.
- Первичный цветовой smoke: UI material cells окрашены, но экспортированные
  `.xlsx` не содержат non-default fills; строгий Excel fill parity принят out of
  scope для текущего релиза.
- Post-run verifier на live-run package ожидаемо упал по `runtime/ZTool.settings`:
  ZTool изменил settings во время работы. Вывод: release verifier нужно запускать
  на свежем/immutable пакете до live-прогона или пересобирать пакет после теста.

A/B + REG-09 live addendum:

- Отчёт и артефакты: `manual-test-reports/FULL_TEST_20260617-ab-reg09-color/`.
- A/original CN собран из initial commit
  `4190f18d17fbe5acf593e2679ff3a3fb28005784`:
  `ZTool.exe` `680A119C235113467992DE53E52A67368771843D13D0050E54149BF9688F7D7A`,
  `ZTool.dll` `55EDDDA3B580ABFF9A9FDC18F00807207DE9BB609CB007633BCD1F82BB957B6C`.
- A/original был запущен напрямую из `original-cn/runtime/ZTool.exe` после
  `RegAsm` original DLL; trial (`试用`) подключился к SolidWorks:
  `连接完成 ... 共29项`. Координатный ribbon-launch original не доведён до конца,
  поэтому A-side ribbon path не заявляется как PASS.
- B/RU runtime:
  `ZTool.exe` `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD`,
  `ZTool.dll` `D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9`.
  `Подключить SW`: 29 строк.
- `COL-UI`: PASS. Pixel gate `ab-material-rgb-compare.txt`:
  material x-bounds `(902,1050)` совпали, black RGB `(0,0,0)` совпал,
  black row-index pattern совпал на видимом пересечении A/B. Разное число
  видимых black cells объясняется настройками `rowheight`: original `48`,
  RU `25`.
- `COL-XLSX`: accepted out of scope. Предыдущий smoke показал отсутствие
  non-default fills в экспортированных `.xlsx`, но пользователь принял
  UI-only material parity как релизный критерий.
- `REG-09`: PASS live. В `dgv_split`, `dgv_match`, `dgv2` строка удаляется,
  если выбрать row header и нажать `Delete`. Результаты:
  `reg09-live-delete-results.json`.
- Event Viewer для A/B/REG-09 окна: новых `Application Error`, `.NET Runtime`,
  WER или ZTool/SolidWorks application events нет.
- После REG-09 runtime `ZTool.settings` был восстановлен из clean package:
  `B1B2DC0635CCEDA8A15F0CC97E0B9AD64C68F7E8124AF735D8AB632C34701CE3`.

Strict `BOM-07/08` fixture addendum:

- Отчёт и артефакты:
  `manual-test-reports/FULL_TEST_20260617-bom-filter-fixture/`.
- Root cause пользовательской ошибки `.NET Framework` и двойной вкладки:
  stale parent-value
  `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}=1`
  автозагружал старую надстройку, хотя subkey выглядел чистым; cached
  CommandManager tabs дополнительно оставляли вторую вкладку ZTool/пустую
  вкладку. Parent-value и subkey в обеих HKCU ветках выставлены в `0`, stale
  tabs удалены после backup.
- SolidWorks открыт через file association на fixture
  `0614-A00.SLDASM`; стартовой `.NET Framework` modal после cleanup нет.
- Add-in load: `LoadAddIn` вернул `0`, но `GetAddInObject` вернул объект;
  ZTool открыт через callback `openZtool(0)` и подключился к SW. Таблица:
  `29` строк, процесс `runtime/ZTool.exe`, SHA256
  `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD`.
- Fixture custom properties записаны в 29 документов:
  `Мех.обработка=18`, `Покупное=6`, `Сборка=5`
  (`fixture-type-assignment.csv`).
- UI export 8 режимов: `BOM-01…08` созданы, размеры ненулевые; валидатор
  `ИТОГ: PASS`. Строки: `29/32/6/25/29/32/18/6`, эскизы есть в `BOM-05/06`.
- Строгий type gate:
  `bom-07-08-type-strict.txt` подтверждает `BOM-07` 18 строк только
  `Мех.обработка`, `BOM-08` 6 строк только `Покупное`, пустых `Тип` = `0`.
- Event Viewer для окна fixture-прогона: новых `Application Error`,
  `.NET Runtime`, WER или ZTool/SolidWorks событий нет.

Clean production package addendum:

- Clean package должен собираться из detached clean worktree текущего HEAD; перед
  сборкой `git status --short` в clean worktree обязан быть пустым.
- Verifier:
  `verify_release_package.ps1 -PackageRoot <pkg> -RequireSolidWorksTools` =
  `PASS`; `dirty=false`, `solidworks_tools_included=true`.
- Package contents должны проходить manifest/SHA256SUMS verification; forbidden
  private key/DB/dump/log files не допускаются.
- Runtime hashes должны совпадать с принятыми:
  `ZTool.exe=7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD`,
  `ZTool.dll=D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9`,
  `SolidWorksTools.dll=3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3`.
- BOM/settings pre-flight на package runtime: `PASS`, 8 режимов, material path
  указывает на package-local `SolidWorksTemplates/MyMaterials.sldmat`,
  `usematerialcolor=true`.
- Конкретный путь, manifest hash и `SHA256SUMS` hash фиксируются в
  `manual-test-reports/FULL_TEST_20260617-production-package/package-summary.json`
  для каждого финального build.

## Найдено и исправлено

1. `scripts/build_release_package.ps1` ломал `manifest.json` и `SHA256SUMS.txt`,
   если `-OutputRoot` передавался относительным путем. Симптом: verifier искал
   путь вида `...\udit-...` внутри пакета. Исправлено приведением `OutputRoot`
   к абсолютному пути до расчета `packageRoot`.

2. В `client-core/tools/Localizer/Program.cs` усилен IL-патч `SplitGrid_KeyDown`:
   поиск `DataGridView.EndEdit` теперь требует `paramCount: 0`, чтобы не выбрать
   перегруженный overload с параметром и не сгенерировать невалидный IL.

3. `client-core/tools/localization_scan.py` теперь завершает проверку читаемой
   ошибкой, если `dotnet` отсутствует или Localizer не запускается. До правки
   пользователь видел Python traceback.

4. `docs/release/FULL_TEST_METHODOLOGY_RU.md` уточнена: offline gates требуют
   именно `.NET SDK` (`dotnet --list-sdks`), одного runtime недостаточно.

5. `README.md` синхронизирован с текущей веткой: указан PR #33 hash для
   `ZTool.exe` и явно сказано, что production GO требует живой методики.

6. Установлены `.NET SDK 10.0.301` и `.NET SDK 8.0.422`; после этого закрыты
   `client-core/build.ps1`, `Reinjector`, `BinderInject` и `localization_scan`
   gates.

7. В `license-server/ztool_license_server/db.py` добавлен idempotent cleanup
   `LicenseDB.close()`/`__del__`, чтобы тестовые `LicenseServer` instances не
   оставляли открытые SQLite connections. Подтверждено прогоном с
   `-W error::ResourceWarning`.

8. `client-core/tools/validate_bom_exports.py` приведён в соответствие с
   методикой: пустые результаты фильтр-режимов `BOM-07`/`BOM-08` на демо-модели
   без совпадающего `Тип` теперь дают `WARN`, а не ложный export `FAIL`.

9. `client-core/tools/localization_scan.py` теперь принудительно переводит
   stdout/stderr в UTF-8-safe режим. На Windows cp1251 scan раньше мог падать
   `UnicodeEncodeError` при печати допустимых китайских строк из whitelist,
   хотя `unclassified_han=0`.

10. Найдена и устранена реальная причина повторной `.NET Framework` modal в
    SolidWorks: автозагрузка сидела не только в subkey, но и в parent-value
    `HKCU\SOFTWARE\SolidWorks\AddInsStartup`. Методика теперь требует проверять
    оба места и держать значения `0` перед live-прогоном.

11. Удалены stale cached CommandManager tabs ZTool в HKCU, из-за которых
    появлялась вторая вкладка, включая пустую вкладку, фактически ведущую в
    ZTool. Методика дополнена cleanup этого cache после backup.

## Блокеры и остаточные риски

| Риск | Статус |
| --- | --- |
| A/B-прогон против оригинальной китайской сборки | `COL-UI` A/B выполнен и PASS; caveat: original запускался напрямую из runtime, original ribbon-launch не заявлен как PASS |
| `COL-UI` цвета/материалы | PASS: live UI pixel gate против original CN совпал по RGB/x-bounds/row-index |
| `COL-XLSX` цвета/заливки Excel | Accepted out of scope: экспортированные `.xlsx` в smoke не содержали non-default fills, но это не release blocker после принятия UI-only material parity |
| `REG-09` split dialog | PASS live: `dgv_split`, `dgv_match`, `dgv2` удаляют строку через row header + `Delete` |
| BOM-07/08 фильтры | PASS strict fixture: `BOM-07` 18 строк только `Мех.обработка`, `BOM-08` 6 строк только `Покупное`, пустых `Тип` = 0 |
| Реестр SolidWorks/ZTool | Root cause найден и очищен; остаточный риск закрывается новым pre-flight parent-value + cached tabs cleanup |
| Live-run package мутируется приложением | `runtime/ZTool.settings` изменился после запуска ZTool; verifier PASS только на свежем/clean package |
| `dotnet --info` в текущей оболочке печатает SDK/runtime, но завершается ошибкой workload-info (`InstallerBase` `NullReferenceException`) | Не блокирует `dotnet build/run`, но лучше не использовать `dotnet --info` как gate; методика требует `dotnet --list-sdks` |
| Release package собран из dirty worktree | Закрыто: clean production package собран из отдельного clean worktree, verifier PASS без `-AllowDirtyManifest` |

## Текущая оценка

- **License server:** хорошо покрыт и проходит критичные gates; coverage 80%.
- **Release packaging:** clean production package с реальным
  `SolidWorksTools.dll` проходит verifier без `-AllowDirtyManifest`.
- **BOM/settings offline:** PASS, включая runtime material library path в пакете.
- **Client binary pipeline:** архитектурно остается гибридным binary/IL pipeline;
  локальные build/verify/localization gates теперь PASS после установки SDK.
- **SolidWorks/BOM smoke:** ZTool запускается/открывается через add-in path,
  читает 29 позиций, экспортирует 8/8 файлов; основной smoke даёт `PASS/WARN`
  на демо-модели без `Тип`, strict fixture даёт `PASS` для `BOM-07/08`.
- **A/B UI color/material:** `COL-UI PASS` против original CN; `COL-XLSX`
  принят out of scope и не блокирует релиз.
- **REG-09:** live PASS по трём grid.
- **Production readiness:** packaging blocker закрыт. Технический статус
  `release-candidate`: `COL-UI`, `REG-09`, strict `BOM-07/08`, clean package и
  offline gates закрыты; абсолютный `FULL PASS` остаётся ограничен только
  caveat по literal ribbon-click original/RU fixture, потому что фактический
  запуск RU fixture был через add-in callback `openZtool(0)`.
