# ZTool live test log

Commit: `988ab618beb609639cc69cdf299038f44363702b`
Root: `D:\Development\ztool\manual-test-final-988ab61`

## Baseline

- ZTool.dll SHA256: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
- ZTool.exe SHA256: `F6822E6C6523B78A725A5BB024E281637E152CBA8F259788FC7C3032C318D378`
- SolidWorksTools.dll SHA256: `3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3`
- ZTool.settings SHA256: `FA2A0FF616F315FF8FE6021D15DF981623C584DC2CF6698017472B987B096E39`

## Current status

- SW launch mode: medium-context via desktop shortcut / assembly file association
- Test model: `TestModel_ASCII\0614-A00.SLDASM`
- Current SW process: capture by user actions only

## Timeline

- [ ] Load add-in
- [ ] Open ZTool tab
- [ ] Open File Manager / launcher
- [ ] Confirm ZTool.exe hash from running process
- [ ] Test "Read by spec"
- [ ] Test "Read all"
- [ ] Record errors / screenshots

## Notes

- Do not restart SolidWorks from PowerShell elevated context.
- Record exact text of any error dialog.
- Save screenshots into this folder.

## 2026-06-11 16:16

### Launcher / update popup
- Actual launched process: `ZTool.base.exe`
- SHA256: `E5EA6C4C2B395ADBB9F085F31B9A404D00AB0A1CDF5681BEED5ECB7AE7DE9CE5`
- Parent: `sldworks.exe`
- CommandLine: `"D:\Development\ztool\manual-test-final-988ab61\ZTool.base.exe" 33 280 0 593356`
- Update popup shown: `ZTool: проверка обновлений` / `Найдена новая версия! 3.8.5`
- Status: FAIL (update popup still present)

## 2026-06-11 16:18

### File manager / SW connection
- Button pressed: `Подключить SW`
- Result: connected, but table still empty (`0 поз.`)
- Status bar text in ZTool: connection complete / 0 pos
- User-visible state: details/assemblies not loaded yet

## 2026-06-11 16:20

### Reading test
- User repeated connection/read action.
- Result: no reaction / table remains empty.
- Reading from SW: FAIL (`0 поз.`)
- Current suspected cause: launcher process is `ZTool.base.exe`, not patched `ZTool.exe`.

## 2026-06-11 16:22

### Controlled launcher-name substitution
- Cause under test: add-in launches `ZTool.base.exe`, while patched binary is `ZTool.exe`.
- Original `ZTool.base.exe` backed up as `ZTool.base.exe.orig-e5ea6c4c`.
- `ZTool.base.exe` replaced with patched `ZTool.exe` bytes.
- New `ZTool.base.exe` SHA256: `F6822E6C6523B78A725A5BB024E281637E152CBA8F259788FC7C3032C318D378`.
- This is a controlled test modification, not the raw repo state.

## 2026-06-11 16:46

### Full restart after launcher substitution
- User requested full restart after replacing ZTool.base.exe with patched bytes.
- Closing current ZTool/SolidWorks processes, then launching test assembly via medium context/file association.


## 2026-06-11 16:49

### Regression after launcher-name substitution
- Setup: `ZTool.base.exe` replaced by patched `ZTool.exe` bytes (`F6822E6C...`).
- User clicked ribbon button `Управление файлами` after full restart.
- Result: no window opened; no `ZTool.exe` / `ZTool.base.exe` process was running.
- Evidence screenshot: `evidence_file_manager_no_launch_after_base_substitution.png`.
- Status: FAIL. The patched `ZTool.exe` cannot simply be renamed to `ZTool.base.exe`; the add-in launcher path/name contract or exe startup expectations differ.

### Current known launcher states
- Original `ZTool.base.exe` (`E5EA6C4C...`): launches, but shows update popup `3.8.5` and reading stays `0 поз.`.
- Patched `ZTool.exe` bytes renamed to `ZTool.base.exe` (`F6822E6C...`): `Управление файлами` does not launch a visible window/process.
