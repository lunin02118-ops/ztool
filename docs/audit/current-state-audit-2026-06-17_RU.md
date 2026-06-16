# Текущий аудит состояния проекта

Дата: 2026-06-17  
Ветка: `codex/fix-split-delete-summary-columns`  
HEAD на момент аудита: `637a5f1034eb7cec46a03edc6fe5307b9de5da96`

## Вывод

Проект находится в состоянии **release-candidate / offline checked**, но не
`FULL PASS` и не production GO. Сервер лицензирования и offline release/BOM gates
выглядят здоровыми. Клиентский SolidWorks-паритет остается главным обязательным
ручным/полуавтоматическим гейтом: без живого прогона по
`docs/release/FULL_TEST_METHODOLOGY_RU.md` нельзя утверждать production-ready.

## Что проверено

GitHub:

- Для HEAD `637a5f1` GitHub connector не вернул commit statuses.
- Workflow runs для этого commit также отсутствуют.

Автоматические gates:

| Проверка | Результат |
| --- | --- |
| `git diff --check` | PASS |
| `python tools/secret_scan.py` | PASS |
| `python -m compileall -q license-server/ztool_license_server license-server/tests` | PASS |
| `python -m pytest -q license-server` | PASS: `112 passed, 2 skipped` |
| `python -m pytest -q --cov=ztool_license_server --cov-report=term-missing` | PASS: total coverage `80%`, `112 passed, 2 skipped` |
| `python -m ruff check license-server` | PASS |
| `python -m bandit -q -r license-server/ztool_license_server -c license-server/pyproject.toml` | PASS |
| `python client-core/tools/check_bom_template.py ZTool.settings` | PASS |
| `python client-core/tools/check_bom_template.py client-core/dist/ZTool.settings` | PASS |
| `python build_ru_bom_template.py --out ...` | PASS |
| Release dry-run package + `scripts/verify_release_package.ps1 -AllowDirtyManifest` | PASS после фикса `build_release_package.ps1` |

Проверенные runtime-хеши:

| Файл | SHA256 |
| --- | --- |
| `ZTool.exe` | `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD` |
| `ZTool.dll` | `D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9` |
| `ZTool.settings` | `743FE534D381EAB0394EA6E6D885C5C8E1C79962B447C6A5E9989A002CF14FCE` |
| `client-core/dist/ZTool_binderfix.exe` | `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD` |

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

## Блокеры и остаточные риски

| Риск | Статус |
| --- | --- |
| Нет живого SolidWorks-прогона по PR #33 | Блокирует `FULL PASS` |
| Локально установлен только .NET Runtime 6.0.22, SDK отсутствует | Блокирует `client-core/build.ps1`, `Reinjector`, `Localizer`, `localization_scan` |
| Release package dry-run был без `SolidWorksTools.dll` | Production verifier нужно запускать с `-RequireSolidWorksTools` и реальным DLL |
| `pytest --cov` показывает `ResourceWarning` по незакрытым SQLite connections в async/integration tests | Не валит CI, но это test hygiene debt |
| У HEAD нет GitHub status/workflow runs | Нет внешнего CI-доказательства для текущего commit |

## Текущая оценка

- **License server:** хорошо покрыт и проходит критичные gates; coverage 80%.
- **Release packaging:** после фикса относительного `OutputRoot` dry-run
  воспроизводимо проходит verifier.
- **BOM/settings offline:** PASS, включая runtime material library path в пакете.
- **Client binary pipeline:** архитектурно остается гибридным binary/IL pipeline;
  нужен .NET SDK и затем обязательный build/verify/localization scan.
- **Production readiness:** `NO-GO` до живого SolidWorks A/B прогона, проверки
  цветов/материалов, `REG-08`, `REG-09`, BOM 8/8 и Event Viewer/WER.

