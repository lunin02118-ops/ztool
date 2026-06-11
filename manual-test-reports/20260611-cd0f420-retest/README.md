# Manual ZTool retest, commit cd0f420

Tested repository commit: `cd0f420e18e4098c3a6039f0699a285bfa8413d3`.

Artifacts under test:

- `ZTool.dll`: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
- `ZTool.exe`: `F48E7DDEA4BBBF41D133292CA3D818AE6FCBF7FA5100D4A4D756C789662D66A9`

Result summary:

- PASS: SolidWorks 2025 opens the test assembly through file association.
- PASS: The `ZTool` ribbon tab is Russian and icons are visible.
- FAIL: The out-of-box folder still launches `ZTool-base.exe`, not `ZTool.exe`.
- FAIL: `ZTool-base.exe` has old hash `E5EA6C4C...` and still shows update popup `3.8.5`.
- PARTIAL PASS: after manually moving `ZTool-base.exe` out of the root folder, patched `ZTool.exe` `F48E7DDE...` launches and trial mode works.
- FAIL: SW reading still returns `0` positions in both `Чтение по спецификации` and `Читать всё`.
- FAIL: `МЕТОДИКА_ТЕСТА_ПРИЛОЖЕНИЯ.md` still documents old `ZTool.exe` hash `f6822e6c...`.

Conclusion:

Commit `cd0f420` does not close the launcher or SW-reading defects. The add-in/runtime still selects `ZTool-base.exe` when that file is present, and the patched `ZTool.exe` still reads `0` positions after a controlled launch.

Evidence and full timeline are in `LIVE_TEST_REPORT.md`.
