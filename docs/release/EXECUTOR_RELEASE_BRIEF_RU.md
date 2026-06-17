# ZTool — задание исполнителю: релиз текущей версии (чеклист R2)

Версия плана: REFACTORING_PLAN рев. 3.1, раздел **R**. Цель: отгрузить текущий
бинарный ZTool как продакшен-релиз для собственного использования.
Все команды — PowerShell, запускать **из корня репозитория**.

> Перед стартом смержить **PR #36** в `main`, иначе в клоне не будет
> `clean_ztool_commandmanager_tabs.ps1` и общего `expected_release_hashes.json`.

Обозначения: 🟢 без SolidWorks (сборочная машина) · 🟠 нужен SolidWorks 2025 (живой прогон).

---

## Часть A. Сборка и offline-проверки (🟢 сборочная машина)

### A0. Чистый клон (LFS-дамп убран в PR #34, но smudge безопаснее пропустить)
```powershell
$env:GIT_LFS_SKIP_SMUDGE = '1'
git clone https://github.com/lunin02118-ops/ztool.git
cd ztool
```
DoD: clone без ошибки `exceeded its LFS budget`; `git lfs ls-files` пуст.

### A1. Сборка клиента (из чистого дерева — для R1.2)
```powershell
git status --porcelain   # должно быть пусто
powershell -NoProfile -ExecutionPolicy Bypass -File client-core\build.ps1
```
DoD: `build.ps1` PASS; `Reinjector --verify` PASS (`dangling typerefs = 0`);
`BinderInject --verify` PASS; `localization_scan` PASS.

### A2. Offline-проверка BOM-шаблона
```powershell
python client-core\tools\check_bom_template.py ZTool.settings
python client-core\tools\check_bom_template.py client-core\dist\ZTool.settings
```
DoD: оба PASS; 8 BOM-пресетов на месте; `Тип` непустой (BOM-07/08).

### A3. Сборка релиз-пакета (production — с SolidWorksTools.dll)
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\build_release_package.ps1 `
  -Version 1.0.0 `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll"
# путь к SolidWorksTools.dll — из вашей установки SW 2025
```
Пакет появится в `release\ZTool-1.0.0-<stamp>\`.

### A4. Верификация пакета — БЕЗ `-AllowDirtyManifest` (это и есть R1.2)
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\verify_release_package.ps1 `
  -PackageRoot release\ZTool-1.0.0-<stamp> `
  -RequireSolidWorksTools
```
DoD: вывод `release package verification: PASS`. Ожидаемые хеши берутся из
`scripts\expected_release_hashes.json` (`ZTool.exe 7688EA39…`, `ZTool.dll D0535425…`).
Если хеши не сходятся — не продолжать: пересобрать (A1) или сверить билд.
**`-AllowDirtyManifest` НЕ использовать** — иначе R1.2 не закрыт.

---

## Часть B. Живой прогон в SolidWorks 2025 (🟠)

Авторитетная методика: `docs\release\FULL_TEST_METHODOLOGY_RU.md`
(§2.1 registry pre-flight, §2.2 протокол окна, §15 журнал прогона).

### B1. Чистка stale ZTool-вкладок (R1.1 / F-14) — ПЕРЕД pre-flight
```powershell
# сначала dry-run (ничего не удаляет, только показывает находки):
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_ztool_commandmanager_tabs.ps1
# затем применить:
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_ztool_commandmanager_tabs.ps1 -Apply
```
DoD: после запуска SW — ровно **одна** вкладка `ZTool`, без второй пустой.
JSON-отчёт (`...\cmgr-cleanup-report.json`) приложить к evidence.

### B2. Pre-flight гейт (окружение + реестр + регистрация DLL + хеши)
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File scripts\sw_test_preflight.ps1 `
  -RuntimeDir .\runtime -Register
```
DoD: статус `PASS` (или `PASS_WITH_WARNINGS`, если осознанно принимаете
предупреждения). `CodeBase` указывает на текущий `runtime\ZTool.dll`. JSON
приложить. Из неуспешного pre-flight тестировать нельзя.

### B3. Правильный запуск
- Открыть `TestModel\0614-A00.SLDASM` через Проводник / ассоциацию `.SLDASM`
  (НЕ запускать `SldWorks.exe` из shell с пустым `WINDIR`).
- Развернуть SolidWorks. ZTool запускать только с ленты SW («Управление файлами»).
- Подтвердить, что запущен нужный бинарь:
```powershell
Get-Process ZTool | Select-Object Id, Path, MainWindowTitle
Get-FileHash (Get-Process ZTool).Path -Algorithm SHA256   # = 7688EA39…
```

### B4. Функциональные проверки (приёмка)
1. Подключение к SW (контроль 29 строк подключения).
2. **8/8 режимов BOM реально экспортированы** в `.xlsx` (UI не автоматизирован;
   `client-core\tools\run_all_bom_exports.ps1` — чеклист и папки под прогон).
3. Цвета/материалы (`usematerialcolor=true`, библиотека `MyMaterials.sldmat`).
4. **PROP-WRITE-ZTOOL:** редактирование свойств доступно при
   `StatusStrip1 = «Выражение свойства»` → `FrmFilling.ComboBox1` содержит
   редактируемые колонки (`Наименование/Обозначение/Материал`). Подтвердить
   запись COM read-back из документа SW (как в commit `2f0c9a4`).
5. Регрессы: `REG-08` (служебные `Сводка_*` скрыты по умолчанию),
   `REG-09` (Delete в «Разделить столбец»).
DoD: все пункты зелёные, журнал §15 заполнен, скриншоты контрольных точек в отчёте.

---

## Часть C. Сервер лицензий и выпуск

### C1. Боевой деплой сервера лицензий (R1.4) 🟠
По `docs\` (env-конфиг, ключи, TLS/файрвол, бэкап БД, seat-limit).
DoD: клиент активируется против вашего сервера; отзыв/лимит мест работают.

### C2. Тег версии + архив 🟢
- `CHANGELOG` на версию `1.0.0`.
- `git tag v1.0.0` + push тега.
- Архив релиз-пакета во внешнее хранилище (GitHub Release asset).
- (Отдельно) залить 3 ГБ memory-dump во внешний архив и вписать адрес в
  `dumps\full-memory-20260609-081854\README.txt` (строка «Where to get it»).

---

## Что вернуть как evidence (вложить в `manual-test-reports\<run>\`)
- лог `client-core\build.ps1` + `--verify`;
- вывод/JSON `verify_release_package.ps1` (без `-AllowDirtyManifest`);
- JSON `cmgr-cleanup-report.json` (B1);
- JSON `sw_test_preflight` (B2);
- 8 экспортированных `.xlsx` + скриншоты;
- заполненный журнал §15 из методики;
- путь + SHA256 запущенного `ZTool.exe`.

## Чего НЕ делать
- Не помечать `FULL PASS` только по offline/pre-flight — нужен живой прогон.
- Не собирать финальный пакет с `-AllowDirtyManifest`.
- Не распространять ПО третьим лицам без письменного согласия Lee Chan (Art. 2.2);
  для собственного использования ограничений нет.
- Большие untracked артефакты/дампы целиком в репозиторий не коммитить — только
  маленькие evidence-файлы и отчёты.
