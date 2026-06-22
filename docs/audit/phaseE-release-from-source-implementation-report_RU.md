# Этап E: отчёт о переводе релиза на сборку из исходников

Дата: 2026-06-22

## Что изменено

- `scripts/build_release_package.ps1` по умолчанию собирает runtime из `client-src/` и `client-src-addin/`.
- Runtime-зависимости `Ribbon.dll`, `ExpandableGridView.dll`, `SWToolsARM.dll`, `ZTool_rsa.dll`, `ICSharpCode.SharpZipLib.dll`, `itextsharp.dll`, `NPOI*.dll` берутся из output каталога `client-src/bin/Release/net48`.
- `ZTool_rsa.dll` перед упаковкой сверяется с `client-core/ref/ZTool_rsa.dll`.
- Для релизных проектов отключены PDB/debug symbols (`DebugType=none`, `DebugSymbols=false`), иначе MVID и sha256 отличались между `D:\Development\ztool` и CI-путём `D:\a\ztool\ztool`.
- `AddinBrandPatch verify` дополнен проверками внутреннего имени сборки `ZTool`, COM GUID, `ISwAddin`, `ComRegisterFunction` и `ComUnregisterFunction`.
- Добавлен hash gate `scripts/assert_from_source_hashes.ps1`.
- `release-acceptance` теперь собирает EXE и add-in из исходников и сверяет их с `scripts/expected_release_hashes.json`.
- Большие деревья релизного пакета копируются только из tracked файлов git, чтобы локальные незатреканные заметки не попадали в поставку.

## Зафиксированные хеши

- `SWTools.exe`: `41d14ac6014e1bcb3409f4d266536f71922b030806800e60c040a049872f91c5`
- brand-patched `SWTools.dll`: `7f931ba366997f23c1d9d0f713948ba5d07e09e767ec6754a81460f238adf84d`
- `ZTool_rsa.dll`: `274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90`

`setup_sha256` остаётся per-release артефактом и не enforced в CI: NSIS-выход может зависеть от времени/сжатия. CI enforce делает EXE + add-in.

## Проверки

- `dotnet build client-src/ZTool.csproj -c Release -warnaserror:false -p:ContinuousIntegrationBuild=true` -> PASS.
- `dotnet build client-src-addin/sdk-shim/SolidWorksTools.Shim.csproj -c Release -p:ContinuousIntegrationBuild=true` -> PASS.
- `dotnet build client-src-addin/ZTool.SwAddin.csproj -c Release -warnaserror:false "-p:SolidWorksToolsPath=<shim>" -p:ContinuousIntegrationBuild=true` -> PASS.
- Два чистых from-source билда подряд дали одинаковые sha256 для EXE и patched DLL -> PASS.
- Cross-path проверка `D:\Development\ztool` vs `D:\a\ztool\ztool` дала одинаковые sha256 для EXE и patched DLL -> PASS.
- `pwsh -NoProfile -File scripts/assert_from_source_hashes.ps1` -> PASS.
- `pwsh -NoProfile -File scripts/build_release_package.ps1 -Version 1.1.6 -OutputRoot _local_artifacts/test-runs/phaseE-package -AllowMissingSolidWorksTools` -> PASS.
- `pwsh -NoProfile -File scripts/verify_release_package.ps1 -PackageRoot _local_artifacts/test-runs/phaseE-package/SWTools-1.1.6 -AllowDirtyManifest` -> PASS.
- `python tools/check_no_cjk_filenames.py` -> PASS.
- `python tools/check_source_string_invariants.py --self-test` -> PASS.
- `python tools/check_source_string_invariants.py --root client-src --root client-src-addin` -> PASS.
- `python tools/check_ipc_handshake_parity.py --self-test` -> PASS.
- `python tools/check_ipc_handshake_parity.py` -> PASS.
- `python client-core/tools/check_bom_template.py SWTools.settings` -> PASS.
- `python client-core/tools/check_bom_template.py client-core/dist/SWTools.settings` -> PASS.
- `python tools/bom_export_assert.py --self-test` -> PASS.
- `python tools/bom_export_assert.py tools/golden/example_bom.xlsx tools/golden/example_bom.golden.json` -> PASS.
- `python -m pytest license-server` -> `117 passed, 2 skipped`.
- `python tools/secret_scan.py` -> PASS.
- `git diff --check` -> PASS.

## Ограничение

Пакет в этом отчёте собран dry-run без боевого `SolidWorksTools.dll`. Production-прогон на SW-машине должен запускать тот же скрипт с `-SolidWorksToolsDll <путь к настоящему SolidWorksTools.dll>`.
