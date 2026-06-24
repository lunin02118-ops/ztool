# План автоматизации E2E, настройки среды разработки и рефакторинга сборки

Дата: 2026-06-24  
Scope: следующий слой после #79/#80 — убрать ручное E2E и сделать воспроизводимую dev/release среду для SWTools/SolidWorks.

## 1. Проблема

Текущая проблема не в одном баге, а в слабом контракте среды сборки и E2E:

```text
[ ] сборка может случайно брать historical/root SWTools.exe / SWTools.dll;
[ ] версия может не отражать фактическую новую сборку;
[ ] SolidWorks может грузить stale CodeBase / старую DLL;
[ ] “Подключить SW” может ломаться только в live-среде;
[ ] старые иконки могут оставаться из embedded resources или CommandManager cache;
[ ] BOM 1-6 может проходить, а modes 7/8 оставаться WARN;
[ ] ручные evidence scripts не дают стабильный машинный PASS/FAIL.
```

Нужно перевести проект от ручных live-проверок к автоматизированному E2E harness, который сам строит, ставит, запускает SolidWorks, проверяет регистрацию/add-in/runtime identity, выполняет `Подключить SW`, экспортирует BOM и выдаёт machine-readable verdict.

## 2. Текущая база

### #79 — BOM/export parity fixes

#79 чинит BOM/export parity regressions и приносит live evidence:

```text
S7: PASS, rowCount=29, columnCount=40
S8 modes 1-6: PASS
S8 modes 7-8: WARN, текущая RU fixture имеет пустой Тип
Production GO: NO-GO
```

#79 можно принимать только как partial fix/evidence, не как production approval.

### #80 — source-built pipeline hardening

#80 закрывает главный build/source-of-truth риск:

```text
[OK] release package больше не должен молча брать root SWTools.exe/SWTools.dll;
[OK] source-built outputs становятся нормальным входом;
[OK] version metadata генерируется централизованно;
[OK] registry/CodeBase/runtime identity checks добавлены;
[OK] live S7 smoke через UIA подтверждает “Подключить SW”;
[OK] stale CodeBase на C:\Program Files\SWTools\SWTools.dll был пойман и исправлен.
```

#80 остаётся pipeline-hardening PR. Production GO не заявляется.

## 3. Целевое состояние

Одна команда должна выполнять полный E2E:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -InstallRoot D:\SWToolsDev\installed\current `
  -PackageRoot D:\SWToolsDev\packages\current `
  -SolidWorksExe $env:SOLIDWORKS_EXE `
  -SolidWorksToolsDll $env:SOLIDWORKS_TOOLS_DLL `
  -TestAssembly $env:SWTOOLS_TEST_MODEL `
  -OutputDir _local_artifacts\reports\e2e\current `
  -RequireBomModes 1,2,3,4,5,6,7,8
```

На выходе:

```text
e2e-result.json
e2e-summary.md
runtime-identity.json
registry.json
s7-connect.json
s8-bom-validation.json
version-stamp.json
branding-assets.json
screenshots/
```

Ручной труд должен остаться только для final owner approval и визуального review screenshots. Всё остальное должно давать deterministic machine-readable PASS/FAIL.

## 4. Среда разработки

### 4.1 Директории

Рекомендуемая локальная структура:

```text
D:\Development\ztool                         # основной repo
D:\Development\ztool-worktrees\pr-XX          # изолированные worktrees
D:\SWToolsDev\
  builds\
  packages\
  installed\
  reports\
  logs\
  manifests\
  secrets\
  temp\
```

Правила:

```text
[ ] dev runtime не ставить внутрь repo;
[ ] test package не запускать из root repo;
[ ] _local_artifacts/ не коммитить;
[ ] releases/ не коммитить;
[ ] private keys / signing certs / legal evidence не коммитить.
```

### 4.2 `.env.local.example.ps1`

Добавить шаблон:

```powershell
$env:SWTOOLS_DEV_ROOT = "D:\SWToolsDev"
$env:SWTOOLS_INSTALL_ROOT = "D:\SWToolsDev\installed"
$env:SWTOOLS_PACKAGE_ROOT = "D:\SWToolsDev\packages"
$env:SWTOOLS_REPORT_ROOT = "D:\SWToolsDev\reports"

$env:SOLIDWORKS_EXE = "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe"
$env:SOLIDWORKS_DIR = "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS"
$env:SOLIDWORKS_TOOLS_DLL = "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll"

$env:SWTOOLS_TEST_MODEL = "D:\Development\ztool\TestModel\0614-A00.SLDASM"
```

`.env.local.ps1` должен быть ignored.

### 4.3 Dev doctor

Добавить:

```text
scripts/dev/doctor.ps1
```

Он проверяет:

```text
[ ] PowerShell 7;
[ ] .NET SDK / MSBuild;
[ ] .NET Framework 4.8 Developer Pack;
[ ] Python 3.11+;
[ ] pywin32 / pywinauto;
[ ] NSIS;
[ ] Git;
[ ] SolidWorks installed;
[ ] SolidWorks COM доступен;
[ ] SolidWorksTools.dll найден;
[ ] desktop session interactive, не service/session 0;
[ ] DPI/resolution warnings;
[ ] нет stale SWTools.exe;
[ ] нет stale SLDWORKS.exe в clean mode.
```

Выход:

```text
_local_artifacts/reports/dev/doctor.json
```

## 5. Source-built release contract

### 5.1 Canonical release inputs

Штатные входы для package:

```text
client-src/bin/Release/net48/SWTools.exe
client-src-addin/bin/Release/net48/SWTools.dll
```

Historical root artifacts:

```text
SWTools.exe
SWTools.dll
```

допустимы только в explicit mode:

```powershell
-UseAcceptedRuntimeSnapshot
```

### 5.2 Guards

Обязательные scripts:

```text
scripts/resolve_release_inputs.ps1
scripts/assert_no_legacy_runtime_inputs.ps1
scripts/check_release_source_guards.ps1
scripts/check_version_stamp.ps1
```

Acceptance:

```text
[ ] package builder пишет release-inputs.json;
[ ] manifest.runtime.input_mode = source-build-output или accepted-runtime-snapshot;
[ ] production package не может silent fallback на root binaries;
[ ] ProductVersion/FileVersion у EXE/DLL совпадают с VERSION policy;
[ ] InformationalVersion содержит git SHA;
[ ] dirty build clearly marked.
```

## 6. Version stamping

Правило:

```text
VERSION = product version, например 1.1.6
FileVersion = VERSION.<buildNumber>
InformationalVersion = VERSION+<gitSha>.<clean|dirty>
```

Для release:

```text
dirty=false обязательно
```

Для dev:

```text
dirty=true разрешён, но production_go_allowed=false
```

Проверки:

```text
[ ] SWTools.exe ProductName = SWTools;
[ ] SWTools.dll ProductName = SWTools;
[ ] ProductVersion starts with VERSION;
[ ] FileVersion starts with VERSION.;
[ ] InformationalVersion contains git SHA;
[ ] package manifest commit matches git commit;
[ ] installer DisplayVersion matches package version.
```

## 7. SolidWorks registration/runtime identity

Добавить/поддерживать:

```text
scripts/dev/install_swtools_dev_addin.ps1
scripts/dev/uninstall_swtools_dev_addin.ps1
scripts/dev/clear_solidworks_command_cache.ps1
scripts/check_sw_addin_registration.ps1
scripts/check_swtools_runtime_identity.ps1
```

Проверять:

```text
[ ] HKLM\SOFTWARE\SolidWorks\AddIns\{GUID} default = 1;
[ ] HKLM title = SWTools;
[ ] HKLM description = SWTools SolidWorks Add-in;
[ ] HKCU\SOFTWARE\SolidWorks\AddInsStartup\{GUID} default = 1;
[ ] RegAsm CodeBase points to current runtime SWTools.dll;
[ ] loaded add-in DLL path/hash == package runtime;
[ ] SWTools.exe path/hash == package runtime;
[ ] SolidWorksTools.dll exists;
[ ] System.Resources.Extensions identity = Version=4.0.0.0;
[ ] no stale path to C:\Program Files\SWTools\SWTools.dll unless explicitly testing installed package.
```

## 8. E2E automation architecture

### 8.1 Main orchestrator

```text
scripts/e2e/Invoke-SWToolsE2E.ps1
```

Stages:

```text
00 doctor
01 resolve/build source inputs
02 build package
03 verify package
04 install/register add-in
05 verify registry/runtime identity
06 launch SolidWorks/open model
07 S7 Connect SW
08 S8 BOM export 1-8
09 semantic Excel validation
10 version/branding checks
11 collect evidence
12 assert final status
```

### 8.2 Machine-readable result

`e2e-result.json`:

```json
{
  "status": "PASS|PASS_WITH_WARN|FAIL",
  "production_go_allowed": false,
  "commit": "<sha>",
  "package": {
    "root": "<path>",
    "manifest_sha256": "<sha>",
    "dirty": false
  },
  "runtime_identity": {
    "swtools_exe_path_match": true,
    "swtools_dll_codebase_match": true,
    "system_resources_extensions_identity": "4.0.0.0",
    "solidworks_tools_present": true
  },
  "connect_sw": {
    "status": "PASS",
    "row_count": 29,
    "column_count": 40
  },
  "bom": {
    "mode_1": "PASS",
    "mode_2": "PASS",
    "mode_3": "PASS",
    "mode_4": "PASS",
    "mode_5": "PASS",
    "mode_6": "PASS",
    "mode_7": "WARN|PASS|FAIL",
    "mode_8": "WARN|PASS|FAIL"
  }
}
```

## 9. S7 automation: `Подключить SW`

S7 должен быть полностью автоматическим:

```text
[ ] открыть SolidWorks;
[ ] открыть TestModel\0614-A00.SLDASM;
[ ] получить add-in object;
[ ] вызвать openZtool(0);
[ ] найти SWTools.exe из текущего runtime;
[ ] через UIA Invoke закрыть trial/license gate, если есть;
[ ] через UIA Invoke нажать “Подключить SW”;
[ ] считать таблицу через UIA/GridPattern/text fallback;
[ ] assert rowCount >= 29;
[ ] assert columnCount >= 30;
[ ] записать process path/hash and add-in path/hash.
```

Правило:

```text
Координатный клик не считается acceptance. Если UIA Invoke недоступен — FAIL.
```

## 10. S8 BOM export automation

Нужно вынести ручной runner из `manual-test-reports` в reusable E2E stage:

```text
scripts/e2e/steps/08-export-bom.ps1
tools/e2e/compare_bom_excel.py
```

Режимы:

```text
1 summary
2 hierarchy
3 top-level
4 parts-only
5 summary with images
6 hierarchy with images
7 processed
8 purchased
```

Policies:

```text
Dev mode:
  modes 1-6 PASS, 7/8 WARN allowed, production_go_allowed=false.

Release mode:
  modes 1-8 PASS required. WARN is FAIL for production.
```

## 11. Semantic Excel validator

Не сравнивать XLSX побайтно. Проверять смысл:

```text
[ ] workbook opens;
[ ] expected sheets exist;
[ ] row count;
[ ] headers;
[ ] № п/п;
[ ] quantity;
[ ] mass;
[ ] path;
[ ] dimensions;
[ ] Наименование;
[ ] Обозначение;
[ ] Материал;
[ ] Тип;
[ ] images in modes 5/6;
[ ] mode 7 rows match processed type values;
[ ] mode 8 rows match purchased type values;
[ ] no visible Han in user-facing cells.
```

Mode 7 accepted values:

```text
Мех.обработка
Листовая
Литьё
Сварка
```

Mode 8 accepted values:

```text
Покупное
Стандартное
```

## 12. RU fixture policy

Нужен deterministic RU fixture:

```text
TestModel-RU/
  0614-A00-RU.SLDASM
  fixture-manifest.json
```

`fixture-manifest.json`:

```json
{
  "fixture": "0614-A00-RU",
  "required_properties": [
    "Наименование",
    "Обозначение",
    "Материал",
    "Тип",
    "Версия",
    "Масса"
  ],
  "type_values": {
    "processed": ["Мех.обработка", "Листовая", "Литьё", "Сварка"],
    "purchased": ["Покупное", "Стандартное"]
  },
  "expected_modes": {
    "7": { "min_rows": 1 },
    "8": { "min_rows": 1 }
  }
}
```

Production `SWTools.settings` must stay RU-only:

```text
[ ] no Тип/类型 alias;
[ ] no 机加 / 外购 in production runtime profile;
[ ] no vendor Han filter values.
```

## 13. Branding and icon pipeline

Separate PR, not mixed with S7/S8.

Canonical assets:

```text
assets/branding/swtools/
  app.ico
  addin_16.bmp
  addin_24.bmp
  addin_32.bmp
  toolbar_16.bmp
  toolbar_24.bmp
  toolbar_32.bmp
  flyout_16.png
  flyout_24.png
  flyout_32.png
```

Scripts:

```text
scripts/sync_branding_assets.ps1
scripts/verify_branding_assets.ps1
```

Checks:

```text
[ ] extracted EXE icon == canonical;
[ ] embedded add-in toolbar/flyout resources == canonical;
[ ] old icon hash absent;
[ ] SolidWorks CommandManager cache cleared/invalidation documented;
[ ] screenshot evidence captured.
```

Note: logical resource names may remain `ZTool.*` until identity migration. Resource bytes must be canonical SWTools.

## 14. ZTool identity inventory

Do not blindly rename `AssemblyName=ZTool`.

Create:

```text
docs/development/ZTOOL_IDENTITY_INVENTORY_RU.md
scripts/check_ztool_identity_inventory.ps1
```

Classes:

```text
required_internal_identity
required_resource_logical_name
COM/registry compatibility
runtime lookup compatibility
user-facing legacy
removable legacy
unknown blocker
```

Acceptance:

```text
[ ] user-facing ZTool = 0;
[ ] all remaining ZTool identifiers classified;
[ ] unknown ZTool identifiers fail gate;
[ ] full SWTools-native identity migration only as separate PR.
```

## 15. Self-hosted SolidWorks runner

Full E2E needs self-hosted Windows/SolidWorks runner:

```text
labels: windows, solidworks, swtools-e2e
```

Runner requirements:

```text
[ ] Windows 10/11;
[ ] SolidWorks target version;
[ ] SolidWorks license;
[ ] interactive user session;
[ ] runner not service/session 0;
[ ] auto-login test user;
[ ] DPI 100%;
[ ] fixed resolution;
[ ] sleep/lock disabled;
[ ] VM snapshot restore between release runs.
```

Workflow:

```yaml
name: e2e-solidworks

on:
  workflow_dispatch:

jobs:
  e2e:
    runs-on: [self-hosted, windows, solidworks, swtools-e2e]
    steps:
      - uses: actions/checkout@v4
      - name: Doctor
        shell: pwsh
        run: pwsh -NoProfile -File scripts/dev/doctor.ps1
      - name: Run SWTools E2E
        shell: pwsh
        run: |
          pwsh -NoProfile -File scripts/e2e/Invoke-SWToolsE2E.ps1 `
            -BuildFromSource `
            -OutputDir _local_artifacts/reports/e2e/${{ github.run_number }}
      - name: Upload curated evidence
        uses: actions/upload-artifact@v4
        with:
          name: swtools-e2e-evidence
          path: _local_artifacts/reports/e2e/${{ github.run_number }}/curated/
```

## 16. PR roadmap

### #81 — E2E automation plan

Current PR scope:

```text
docs/testing/E2E_AUTOMATION_AND_DEV_ENV_PLAN_RU.md
```

Acceptance:

```text
[ ] plan is recorded in repo;
[ ] no product runtime changes;
[ ] no scripts are claimed as implemented;
[ ] production GO is not claimed.
```

### #82 — E2E foundation

Files:

```text
docs/testing/E2E_AUTOMATION_STRATEGY_RU.md
docs/testing/E2E_ENVIRONMENT_RU.md
scripts/e2e/Invoke-SWToolsE2E.ps1
scripts/e2e/lib/E2E.Common.psm1
scripts/e2e/lib/E2E.Doctor.psm1
tools/e2e/assert_e2e_result.py
```

Acceptance:

```text
[ ] doctor works;
[ ] e2e-result.json can be produced;
[ ] no product runtime changes;
[ ] _local_artifacts not committed.
```

### #83 — Automated S7

Build on #80 `swtools_s7_live_smoke.py`.

Acceptance:

```text
[ ] launch/open SolidWorks test assembly;
[ ] launch current package SWTools.exe;
[ ] UIA Invoke “Подключить SW”;
[ ] rowCount >= 29;
[ ] columnCount >= 30;
[ ] path/hash evidence captured.
```

### #84 — Automated S8 + Excel semantic validation

Acceptance:

```text
[ ] modes 1-8 export automatically;
[ ] semantic Excel validation;
[ ] dev mode can PASS_WITH_WARN;
[ ] release mode fails on 7/8 WARN.
```

### #85 — RU fixture strict 7/8

Acceptance:

```text
[ ] Тип populated with Russian values;
[ ] mode 7 PASS;
[ ] mode 8 PASS;
[ ] no Тип/类型 alias;
[ ] no 机加/外购 in production settings.
```

### #86 — Branding/icon pipeline

Acceptance:

```text
[ ] canonical assets;
[ ] static resource hash check;
[ ] live screenshot evidence;
[ ] CommandManager cache cleanup.
```

### #87 — Self-hosted SolidWorks E2E workflow

Acceptance:

```text
[ ] workflow_dispatch;
[ ] self-hosted labels;
[ ] curated evidence upload;
[ ] no raw local evidence committed.
```

### #88 — Final release rehearsal evidence

Acceptance:

```text
[ ] final package exact commit;
[ ] signing report;
[ ] S7/S8 live PASS;
[ ] BOM 1-8 PASS;
[ ] localization screenshots;
[ ] release dossier updated;
[ ] GO/NO-GO updated;
[ ] owner approval recorded if GO.
```

## 17. Hard rules

```text
[ ] Не мержить #80 до #79.
[ ] Не заявлять production GO.
[ ] Не менять accepted release hashes без отдельного release-promotion PR.
[ ] Не использовать root SWTools.exe/SWTools.dll без explicit accepted snapshot mode.
[ ] Не добавлять vendor Han aliases в production SWTools.settings.
[ ] Не переименовывать AssemblyName=ZTool без separate identity migration plan.
[ ] Не коммитить _local_artifacts, releases, raw dumps, private keys, signing certs.
[ ] Не считать screenshots/manual reports заменой machine-readable e2e-result.json.
```

## 18. Definition of done

E2E automation считается готовой, когда:

```text
[ ] одна команда запускает full source package + install + SolidWorks + S7 + S8;
[ ] результат machine-readable;
[ ] при wrong CodeBase test fails;
[ ] при old root runtime input test fails;
[ ] при rowCount=0 test fails;
[ ] при mode 7/8 WARN production release fails;
[ ] при version mismatch test fails;
[ ] при old icon hash test fails;
[ ] curated evidence can be attached to release dossier;
[ ] production GO remains impossible without explicit owner approval.
```
