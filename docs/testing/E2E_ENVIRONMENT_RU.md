# E2E development environment

Дата: 2026-06-24

## Локальные директории

Рабочая копия репозитория должна оставаться чистой. Runtime, пакеты и evidence
кладутся вне tracked source tree:

```text
D:\SWToolsDev\
  builds\
  packages\
  installed\
  reports\
  logs\
  temp\
```

Внутри репозитория допускается только ignored область:

```text
_local_artifacts\
```

Не коммитить:

```text
_local_artifacts/
releases/
raw dumps
private keys
signing certs
license keys
legal evidence
local logs
```

## Переменные среды

Пример локального профиля:

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

Локальный файл `.env.local.ps1` должен оставаться untracked/ignored.

## Doctor

Запуск:

```powershell
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 -DoctorOnly
```

Doctor проверяет:

```text
[ ] PowerShell;
[ ] git/dotnet/python;
[ ] Python UIA modules: win32com.client, pywinauto, psutil;
[ ] RegAsm x64;
[ ] SolidWorks exe / SolidWorksTools.dll / fixture path, если требуется live;
[ ] interactive desktop session;
[ ] WINDIR/SystemRoot/ComSpec;
[ ] stale SLDWORKS.exe / SWTools.exe;
[ ] SWTools add-in registry snapshot.
```

Для обычного foundation run отсутствие SolidWorks может быть `WARN`.
Для live acceptance запускать с `-RequireSolidWorks`; тогда отсутствие SolidWorks,
fixture или UIA dependencies становится `FAIL`.

## Нормальный запуск live-теста

Live acceptance не должен запускать модель простым shell association как единственное
доказательство. Допустимый путь:

```text
Explorer/UIA или SolidWorks COM открывает fixture;
SWTools запускается из проверенного runtime;
UIA Invoke нажимает "Подключить SW";
result JSON фиксирует row_count/path/hash.
```

Если UIA Invoke недоступен, gate должен падать, а не переходить на координатные клики.

## Минимальный acceptance для PR #82

```text
[ ] scripts\e2e\Invoke-SWToolsE2E.ps1 -DoctorOnly создаёт e2e-result.json;
[ ] tools\e2e\assert_e2e_result.py валидирует result;
[ ] no product runtime changes;
[ ] production_go_allowed=false;
[ ] _local_artifacts не попадает в git.
```
