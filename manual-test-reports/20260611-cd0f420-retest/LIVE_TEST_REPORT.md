# ZTool live retest log

Commit: `cd0f420e18e4098c3a6039f0699a285bfa8413d3`
Root: `D:\Development\ztool\manual-test-final-cd0f420`
Source repo: `https://github.com/lunin02118-ops/ztool`, branch `integration/all-prs`

## Baseline

- Export source: clean `git archive` from commit `cd0f420e18e4098c3a6039f0699a285bfa8413d3`.
- `ZTool.dll`: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
  - Note: root repo `ZTool.dll` is still old `55EDDDA3...`; test uses tracked `dumps/candidate-ru-20260609/ZTool_ru_candidate2.dll` copied as `ZTool.dll`.
- `ZTool.exe`: `F48E7DDEA4BBBF41D133292CA3D818AE6FCBF7FA5100D4A4D756C789662D66A9`
- `ZTool-base.exe`: `E5EA6C4C2B395ADBB9F085F31B9A404D00AB0A1CDF5681BEED5ECB7AE7DE9CE5`
  - Note: file is now hyphenated, not `ZTool.base.exe`.
- `SolidWorksTools.dll`: `3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3`
  - Note: not tracked in repo; copied from previous test environment.
- Test model: `TestModel_ASCII\0614-A00.SLDASM`
  - Note: ASCII copy comes from previous test environment; repo tracks non-ASCII model folders.

## Methodology note

`МЕТОДИКА_ТЕСТА_ПРИЛОЖЕНИЯ.md` in commit `cd0f420` still lists old `ZTool.exe` hash `f6822e6c...`. This retest uses the newer hash from the fix request: `F48E7DDE...2D66A9`.

## Planned checks

- [ ] Launch SW through test assembly file association / medium user context.
- [ ] Register/load add-in from this test folder.
- [ ] Confirm `ZTool` ribbon is Russian and has icons.
- [ ] Click `Управление файлами`.
- [ ] Confirm actual launched process path and SHA256.
- [ ] Confirm update popup `3.8.5` does not appear.
- [ ] Test `Подключить SW` / reading by specification.
- [ ] Test `Читать всё`.
- [ ] Save screenshots/evidence.

## Results

## 2026-06-11

### Registration

- Command: `Framework64\v4.0.30319\RegAsm.exe ZTool.dll /codebase`
- Result: `Types registered successfully`
- Warning: `RA0000` about unsigned assembly with `/codebase`.
- Status: PASS for registration.

### SolidWorks launch / ribbon

- Launch mode: opened `TestModel_ASCII\0614-A00.SLDASM` through Explorer/file association.
- SolidWorks process: `sldworks.exe`, model window `0614-A00.SLDASM`.
- Ribbon: `ZTool` tab is visible, Russian labels and icons are visible.
- Evidence: `screen_after_no_ztool_process.png`.
- Status: PASS.

### Out-of-box launcher check

- Action: click `Управление файлами` in the clean `cd0f420` test folder.
- Actual launched process: `ZTool-base.exe`.
- Actual process path: `D:\Development\ztool\manual-test-final-cd0f420\ZTool-base.exe`.
- Actual SHA256: `E5EA6C4C2B395ADBB9F085F31B9A404D00AB0A1CDF5681BEED5ECB7AE7DE9CE5`.
- Window title: `ZTool: проверка обновлений`.
- Update popup shown: `Найдена новая версия! 3.8.5`.
- Evidence: `evidence_cd0f420_launches_ztool_base.png`.
- Status: FAIL.

Conclusion: renaming `ZTool.base.exe` to `ZTool-base.exe` is not enough. The add-in still selects and starts `ZTool-base.exe` before `ZTool.exe`.

### Controlled check: only patched `ZTool.exe`

- Modification in test folder only: moved `ZTool-base.exe` to `_launcher_backup\ZTool-base.exe`.
- Remaining launcher candidates in root:
  - `ZTool.exe`: `F48E7DDEA4BBBF41D133292CA3D818AE6FCBF7FA5100D4A4D756C789662D66A9`
  - `ZTool Updater.exe`: `F5BA0177D2BE9C3B4591913C3F32EF074D940DF0D2CA7EBC86B2C4DF2368C070`
- Action: click `Управление файлами` again.
- Actual launched process: `ZTool.exe`.
- Actual process path: `D:\Development\ztool\manual-test-final-cd0f420\ZTool.exe`.
- Actual SHA256: `F48E7DDEA4BBBF41D133292CA3D818AE6FCBF7FA5100D4A4D756C789662D66A9`.
- Update popup `3.8.5`: not shown in this controlled run.
- License dialog shown: `Действующая лицензия не обнаружена!`; trial button `Проба` works.
- Evidence: `evidence_cd0f420_only_ztool_exe_launched.png`, `screen_after_trial_click.png`.
- Status: PARTIAL PASS for launch; FAIL for package composition because manual removal was required.

### Read from SW

- Process under test: `ZTool.exe` with SHA256 `F48E7DDEA4BBBF41D133292CA3D818AE6FCBF7FA5100D4A4D756C789662D66A9`.
- Mode 1: `Чтение по спецификации`.
- Result: status `Подключение завершено, затрачено 0,0 сек.`, table remains empty.
- Positions: `0`.
- Evidence: `evidence_after_connect_sw_f48.png`.
- Mode 2: `Читать всё`.
- Result: status still `Подключение завершено, затрачено 0,0 сек.`, table remains empty.
- Positions: `0`.
- Evidence: `screen_connect_dropdown.png`, `evidence_after_read_all_f48.png`.
- Status: FAIL.

## Final status

- PASS: `ZTool.dll` registration.
- PASS: SolidWorks launches via model file association.
- PASS: Russian ribbon + icons.
- FAIL: out-of-box `cd0f420` still launches `ZTool-base.exe`, old hash `E5EA6C4C...`, and shows update popup `3.8.5`.
- PARTIAL PASS: if `ZTool-base.exe` is manually removed, patched `ZTool.exe` `F48E7DDE...` starts and trial mode works.
- FAIL: reading from SW remains `0` positions in both `Чтение по спецификации` and `Читать всё`.
- FAIL: repo methodology still documents the previous `ZTool.exe` hash `f6822e6c...` instead of current `F48E7DDE...`.
