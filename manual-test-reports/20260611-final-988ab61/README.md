# Manual ZTool test report, 2026-06-11

Tested repository commit: `988ab618beb609639cc69cdf299038f44363702b`.

Artifacts under test:

- `ZTool.dll`: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
- `ZTool.exe`: `F6822E6C6523B78A725A5BB024E281637E152CBA8F259788FC7C3032C318D378`

Result summary:

- PASS: SolidWorks 2025 starts in the correct medium/user context through the test assembly file association.
- PASS: The `ZTool` ribbon tab appears in SolidWorks.
- PASS: Ribbon labels are Russian and icons are visible.
- FAIL: Clicking `Управление файлами` launches `ZTool.base.exe`, not the patched `ZTool.exe`.
- FAIL: The launched `ZTool.base.exe` still shows the update popup `Найдена новая версия! 3.8.5`.
- FAIL: `Подключить SW` finishes, but the table stays empty (`0 поз.`).
- FAIL: Replacing `ZTool.base.exe` with patched `ZTool.exe` bytes makes `Управление файлами` stop opening a visible window/process.

Conclusion:

The final package still has a launcher-contract defect. The add-in/runtime must either launch the patched `ZTool.exe` directly or provide a patched compatible `ZTool.base.exe`; a simple file rename/copy is not sufficient.

Evidence:

- `LIVE_TEST_REPORT.md`
- `evidence_update_popup_3_8_5.png`
- `evidence_file_manager_no_launch_after_base_substitution.png`
- `sw_model_start_with_tab.png`
- `sw_after_restart_medium.png`
