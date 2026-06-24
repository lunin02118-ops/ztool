# E2E S7 automation

Дата: 2026-06-24

Scope: автоматизация S7 `Подключить SW` поверх E2E foundation.

## Цель

S7 должен доказывать полный live path:

```text
build/package -> sw_test_preflight -Register -> SolidWorks fixture
-> ZTool.SwAddin.openZtool(0) -> current package SWTools.exe
-> UIA Invoke "Подключить SW" -> WinForms grid -> row/column evidence
```

Координатный клик не считается acceptance. Если UIA Invoke недоступен, тест должен
падать.

## Команда

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource `
  -RunS7 `
  -RequireSolidWorks `
  -SolidWorksExe "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe" `
  -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll" `
  -TestAssembly D:\Development\ztool\TestModel\0614-A00.SLDASM `
  -ExpectedMinRows 29 `
  -ExpectedMinColumns 30 `
  -OutputDir _local_artifacts\reports\e2e\s7-live
```

Проверка результата:

```powershell
python tools\e2e\assert_e2e_result.py `
  _local_artifacts\reports\e2e\s7-live\e2e-result.json `
  --allow-warn `
  --require-stage-pass 07-s7-connect `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30
```

## Evidence

Live result должен содержать:

```text
artifacts.preflight_register_json
artifacts.s7_connect_json
stages[05-preflight-register].details.runtime_dir
stages[05-preflight-register].details.swtools_exe_sha256
stages[05-preflight-register].details.swtools_dll_sha256
stages[07-s7-connect].details.row_count
stages[07-s7-connect].details.column_count
stages[07-s7-connect].details.swtools_path
stages[07-s7-connect].details.swtools_sha256
stages[07-s7-connect].details.addin_sha256
stages[07-s7-connect].details.status_text
```

`scripts\swtools_s7_live_smoke.py` также пишет подробный
`s7-live-smoke-result.json`, включая:

```text
active_model
solidworks_pid
swtools_pid
swtools_command_line
grid_dimensions
visible_text_sample
```

## Acceptance

```text
[ ] runtime hashes match expected package runtime;
[ ] preflight/register stopped stale SLDWORKS/SWTools and registered current SWTools.dll;
[ ] registry CodeBase points to current runtime;
[ ] SolidWorks add-in object exists;
[ ] SWTools.exe launched from current runtime path;
[ ] SWTools command line includes SolidWorks PID;
[ ] "Подключить SW" invoked through UIA;
[ ] row_count >= 29;
[ ] column_count >= 30;
[ ] e2e-result.json records path/hash/row/column evidence;
[ ] production_go_allowed=false.
```

## Не закрывает

```text
[ ] BOM modes 1-8 export;
[ ] semantic Excel validation;
[ ] RU strict fixture for modes 7/8;
[ ] production GO.
```
