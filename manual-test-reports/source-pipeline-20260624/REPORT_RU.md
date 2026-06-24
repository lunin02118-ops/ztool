# SWTools source-built release pipeline hardening: отчёт

Дата: 2026-06-24

Ветка: `codex/p4-source-pipeline-hardening`

База: `codex/fix-bom-property-parity` / `bfad9d6`

Статус: `PASS` для build/source-of-truth gates и S7 live smoke. Production status: `NO-GO`.

## 1. Цель

Цель проверки и исправлений - устранить системную причину регрессов, когда
исправления делались в одном рабочем дереве, а сборка/запуск брались из другого
места или из старых root runtime binaries.

Проверяемый путь:

1. Собрать `SWTools.exe` и `SWTools.dll` из `client-src` / `client-src-addin`.
2. Запретить silent fallback на root `SWTools.exe` / `SWTools.dll`.
3. Проштамповать version metadata централизованно.
4. Упаковать runtime из source-built outputs.
5. Проверить RegAsm/CodeBase/AddInsStartup.
6. Проверить live `Подключить SW` на `TestModel\0614-A00.SLDASM`.

## 2. Найденная причина хаоса

Подтверждено кодом:

- `scripts/build_release_package.ps1` по умолчанию брал `..\SWTools.exe` и
  `..\SWTools.dll`, то есть historical root runtime artifacts.
- `client-src-addin\ZTool\SwAddin.cs` всё ещё содержал старые source-level
  `SwAddinAttribute Title=ZTool`, `Description=ZTool...` и default registration
  value `0`.
- `client-src-addin\Properties\AssemblyInfo.cs` оставался `Product=ZTool`,
  `FileVersion=1.8.3.0`.
- Версия package бралась из `VERSION`, но file metadata EXE/DLL не была связана
  с единым build stamp.

Практический эффект:

- можно было собрать package не из тех бинарников;
- можно было зарегистрировать/запустить runtime не из той папки;
- stale CodeBase мог продолжать указывать на `C:\Program Files\SWTools\SWTools.dll`;
- визуально приложение могло выглядеть новой версией, но фактически runtime
  provenance оставался смешанным.

## 3. Исправления

Добавлено:

- `Directory.Build.props`
- `Directory.Build.targets`
- `scripts\resolve_release_inputs.ps1`
- `scripts\assert_no_legacy_runtime_inputs.ps1`
- `scripts\check_release_source_guards.ps1`
- `scripts\check_version_stamp.ps1`
- `scripts\check_swtools_runtime_identity.ps1`
- `scripts\check_sw_addin_registration.ps1`
- `scripts\swtools_s7_live_smoke.py`

Изменено:

- `scripts\build_release_package.ps1`
  - default inputs теперь source-built:
    - `client-src\bin\Release\net48\SWTools.exe`
    - `client-src-addin\bin\Release\net48\SWTools.dll`
  - root runtime разрешается только через явный `-UseAcceptedRuntimeSnapshot`;
  - package пишет `release-inputs.json`;
  - manifest содержит `runtime.input_mode`.
- `scripts\verify_release_package.ps1`
  - проверяет `release-inputs.json`;
  - проверяет `runtime.input_mode`;
  - проверяет Product/FileVersion у runtime `SWTools.exe` и `SWTools.dll`.
- `client-src\Properties\AssemblyInfo.cs`
  - version/product/company/title metadata перенесены в generated source.
- `client-src-addin\Properties\AssemblyInfo.cs`
  - убраны старые `ZTool` product/version атрибуты.
- `client-src-addin\ZTool\SwAddin.cs`
  - source-level add-in title/description теперь `SWTools`;
  - registration default value теперь `1`;
  - manual registration title/description теперь `SWTools`.

Важно: internal `AssemblyName=ZTool` сохранён намеренно. Это compatibility
boundary для COM/add-in launcher. Внешнее имя shipped artifacts - `SWTools`.

## 4. Проверки

### Source/build gates

Команды:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_release_source_guards.ps1
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\resolve_release_inputs.ps1 -OutputPath _local_artifacts\reports\source-pipeline\release-inputs.json
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_version_stamp.ps1 -JsonOut _local_artifacts\reports\source-pipeline\version-stamp.json
```

Результат:

- `release source guards: PASS`
- `version stamp: PASS`
- `client-src` build: `123` known warnings, `0` errors
- `client-src-addin` build: `6` known warnings, `0` errors

Source-built inputs:

- `client-src/bin/Release/net48/SWTools.exe`
  - SHA256: `14C1F4EB659DFFB700683562F80F8728F684B6B7D84E141F04CAB0DFF769F302`
  - ProductVersion: `1.1.6+bfad9d6.dirty`
  - FileVersion: `1.1.6.348`
- `client-src-addin/bin/Release/net48/SWTools.dll`
  - SHA256: `D0BFCBB9857D6D7F6AA59D8FE61264E6E5F1B6D35D9991FCB1B26766EA0A3339`
  - ProductVersion: `1.1.6+bfad9d6.dirty`
  - FileVersion: `1.1.6.348`

### Package verify

Команды:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\assert_no_legacy_runtime_inputs.ps1 -ReleaseInputsPath _local_artifacts\reports\source-pipeline\release-inputs.json
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\build_release_package.ps1 -OutputRoot _local_artifacts\reports\source-pipeline\package-test -SolidWorksToolsDll "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll"
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\verify_release_package.ps1 -PackageRoot _local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6 -RequireSolidWorksTools -AllowDirtyManifest -ExpectedClientExeSha256 14C1F4EB659DFFB700683562F80F8728F684B6B7D84E141F04CAB0DFF769F302 -ExpectedAddinDllSha256 33BE726AFCB3A52EEF127AFDF471C9B0F47F6DC019722800D035D22A779C8AD2
```

Результат:

- `legacy runtime input guard: PASS`
- `release package verification: PASS`
- package runtime `SWTools.exe` SHA256:
  `14C1F4EB659DFFB700683562F80F8728F684B6B7D84E141F04CAB0DFF769F302`
- package runtime `SWTools.dll` SHA256 после AddinBrandPatch:
  `33BE726AFCB3A52EEF127AFDF471C9B0F47F6DC019722800D035D22A779C8AD2`

### Runtime identity / registry

Команды:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_swtools_runtime_identity.ps1 -RuntimeDir _local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6\runtime
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\sw_test_preflight.ps1 -RuntimeDir _local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6\runtime -ReportDir _local_artifacts\reports\source-pipeline\preflight-package-runtime -Register
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_sw_addin_registration.ps1 -RuntimeDir _local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6\runtime
```

Результат:

- `runtime identity: PASS`
- `preflight status: PASS`
- `SolidWorks add-in registration: PASS`
- До RegAsm был stale CodeBase:
  `file:///C:/Program Files/SWTools/SWTools.dll`
- После RegAsm CodeBase указывает на текущий package runtime:
  `_local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6\runtime\SWTools.dll`
- `HKLM\SOFTWARE\SolidWorks\AddIns\{59959DFA-...}`:
  - default: `1`
  - title: `SWTools`
  - description: `SWTools SolidWorks Add-in`
- `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-...}`:
  - default: `1`

### Live S7

Команда:

```powershell
python scripts\swtools_s7_live_smoke.py --runtime-dir _local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6\runtime --model D:\Development\ztool\TestModel\0614-A00.SLDASM --report-dir _local_artifacts\reports\source-pipeline\s7-live-smoke-package-runtime --expected-min-rows 29
```

Результат:

- `status: PASS`
- `row_count: 29`
- `status_text: Подключение завершено, затрачено 0,3 сек, всего 29 поз.`
- SWTools path:
  `_local_artifacts\reports\source-pipeline\package-test\SWTools-1.1.6\runtime\SWTools.exe`
- Command line содержит SolidWorks PID.
- Действия:
  - `Демо` вызван через UIA Invoke;
  - `Подключить SW` вызван через UIA Invoke;
  - координатный клик не используется как acceptance.

### Общие gates

Команды:

```powershell
python tools\secret_scan.py
git diff --check
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_client_src_warnings.ps1
python client-core\tools\check_bom_template.py SWTools.settings
python client-core\tools\check_bom_template.py client-core\dist\SWTools.settings
python -m pytest license-server
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_repo_hygiene.ps1 -JsonOut _local_artifacts\reports\source-pipeline\repo_hygiene.json
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\check_binaryformatter_surface.ps1 -JsonOut _local_artifacts\reports\source-pipeline\binaryformatter_surface.json
```

Результат:

- `Secret scan OK`
- `git diff --check`: PASS
- warning baseline: PASS
- BOM template checks: PASS / PASS
- `license-server`: `139 passed, 2 skipped`
- repo hygiene: PASS
- BinaryFormatter surface: PASS

## 5. Иконка

Из package runtime `SWTools.exe` извлечён embedded associated icon:

`_local_artifacts\reports\source-pipeline\package-swtools-exe-icon.png`

Результат: embedded EXE icon - SWTools logo.

Вывод: чёрный старый значок в taskbar не приходит из текущего `SWTools.exe`
package resource. Вероятные причины:

- pinned/taskbar icon cache Windows;
- старый процесс, запущенный из другого runtime;
- SolidWorks CommandManager toolbar assets/cache.

В этом PR закрыт EXE/runtime provenance gate. Полный toolbar/icon asset pipeline
остаётся отдельной Phase D задачей: canonical `assets/branding/swtools/*`,
resource SHA verification и screenshot evidence после CommandManager cache clean.

## 6. Исправленная тестовая ошибка

Во время диагностики первая попытка `Подключить SW` не дала реакции, потому что
поверх главного окна висело модальное окно `Лицензия не обнаружена`. После
объектного UIA Invoke кнопки `Демо` команда `Подключить SW` выполнилась и
вернула 29 позиций.

Чтобы это не повторялось, добавлен `scripts\swtools_s7_live_smoke.py`: он
сначала закрывает trial/license gate через UIA Invoke, затем вызывает
`Подключить SW` через UIA Invoke и проверяет `row_count >= 29`.

## 7. Что осталось

Не закрыто этим PR:

- Production GO.
- Accepted hash promotion.
- Authenticode production signing без `-AllowUnsigned`.
- Strict BOM modes 7/8 на RU fixture с заполненным свойством `Тип`.
- Полный branding asset pipeline для SolidWorks toolbar/flyout icons.
- Полная SWTools-native identity migration вместо compatibility `AssemblyName=ZTool`.

Рекомендация по следующему стеку:

1. Branding/icon assets pipeline.
2. RU fixture для strict BOM 7/8.
3. Installer clean install smoke поверх нового source-of-truth package.
4. Только после этого final release promotion.
