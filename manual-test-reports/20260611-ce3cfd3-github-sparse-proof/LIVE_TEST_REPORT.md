# ZTool GitHub sparse retest log

Source repo: `https://github.com/lunin02118-ops/ztool.git`
Branch: `integration/all-prs`
Commit: `ce3cfd36a9edaf19672d11a4fa345f69734d3e53`

## Source Proof

The runtime folder was prepared from a fresh GitHub sparse/partial clone:

- Sparse clone: `D:\Development\ztool\github-sparse-ce3cfd3-v2`
- Runtime folder: `D:\Development\ztool\manual-test-github-sparse-ce3cfd3`
- `ZTool.exe`: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- `ZTool-base.exe`: `C10CE334FDBBBC05B8186A6E657A22C1ED4ADD8BD638C59D65E5B6798CB4B18D`
- `ZTool.dll`: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
  - Copied from GitHub-tracked `dumps/candidate-ru-20260609/ZTool_ru_candidate2.dll`.
- `ZToolARM.dll`: `B04D303B9A8D1EF99D9140A9B843F65128616E2157B9196A724C50CF549C9FFD`
- `SolidWorksTools.dll`: `3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3`
  - External dependency, not tracked in repo; copied from the previous test environment.
- Test model: `TestModel_ASCII\0614-A00.SLDASM`
  - ASCII test copy, copied from the previous test environment.

## Registration

- Command: `Framework64\v4.0.30319\RegAsm.exe ZTool.dll /codebase`
- Result: `Types registered successfully`
- Status: PASS.

## Launch Proof

First minimal sparse run omitted `ZToolARM.dll`; the correct GitHub `ZTool.exe` started but reported:

- Error: `zToolARM.dll отсутствует`
- Evidence: `evidence_fresh_github_process_path_error.png`

After adding `ZToolARM.dll` from the same sparse clone:

- Actual launched process: `ZTool.exe`
- Actual path: `D:\Development\ztool\manual-test-github-sparse-ce3cfd3\ZTool.exe`
- Actual SHA256: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- `ZTool-base.exe` did not launch.
- Update popup `3.8.5`: not shown.
- License dialog appeared; `Проба` works.
- Evidence: `evidence_fresh_github_launch_ok.png`
- Status: PASS.

## License Dialog Forensics

The license window is not the update popup and not evidence of a wrong executable.
The active process is still the GitHub `ZTool.exe` from the runtime folder:

- Path: `D:\Development\ztool\manual-test-github-sparse-ce3cfd3\ZTool.exe`
- SHA256: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- Window: `ZTool 1.0(x64)`

IL trace:

- `Program.Main` verifies `ZToolARM.dll`, calls `SR.writeini()`, then starts `Application.Run(new MyapplicationContext())`.
- `MyapplicationContext::.ctor` with `StartType=0` opens `Frmmain`.
- `Frmmain_Load` starts `g_monitor()`.
- `g_monitor()` starts a 10 ms timer and routes to `Frmmain::tmr_Elapsed`.
- `tmr_Elapsed` calls `SR.IsReg2("来生缘。。。", ...)`.
- When `IsReg2=False` and `code.TMode=False`, it invokes `Frmmain::_Lambda$__100`.
- `_Lambda$__100` calls `lockbutton()`, enables the trial button, then opens `MyProject.Forms.FrmRverify.ShowDialog()`.

Runtime reflection results under Windows PowerShell 5.1 / .NET Framework:

- `SR.IsReg1("来生缘。。。") = True`
- `SR.IsReg2("来生缘。。。") = False`
- `code = 03000200-0400-0500-0006-000700080009`
- `use_date = 0`
- `SR.get_rgtime().Length = 0`
- `SR.get_rginfo().Length = 5791`

Registry state:

- `HKLM\Software\SolURxxCfNU\C4eHN4fjikBan`: present, `information` length 4144 bytes
- `HKLM\Software\SolURxxCfNU\HTwk2RCBDL`: present, `information` length 1406 bytes
- `HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ\Jlj4aG8uZBvW`: present, `F2S6qCdziIAm` length 4050 bytes
- `HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ\98CqyvBZcg`: present, `information` length 1446 bytes
- `HKCU\SOFTWARE\ZTool`: present, `AppDataPath` and `sn` present

Conclusion: the dialog comes from the normal `FrmRverify` licensing path.
The registry blobs still exist and the first license check passes, but the second check fails.
`IsReg2` derives two decryption keys from the registry-key timestamps of
`HKLM\Software\SolURxxCfNU\HTwk2RCBDL` and
`HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ\98CqyvBZcg`.
If those keys are deleted/recreated during cleanup, the stored blob bytes may remain present while
their timestamp-derived decrypt keys no longer match, so `IsReg2` returns `False` and the UI opens
`FrmRverify`.

## Read From SW

SolidWorks 2025 opened `0614-A00.SLDASM` through file association.

- Process under test: GitHub `ZTool.exe` from runtime folder above.
- Mode: `Чтение по спецификации`.
- Result: table populated; status `Подключение завершено, затрачено 0,2 сек.`
- Visible rows: at least rows `1..16` in the captured viewport; previous full-window run of the same commit showed `29`.
- Evidence: `evidence_fresh_github_read_by_spec.png`
- Status: PASS.

- Mode: `Читать всё`.
- Result: table remains populated; status `Подключение завершено, затрачено 0,2 сек.`
- Evidence: `evidence_fresh_github_read_all.png`
- Status: PASS.

## Final Status

- PASS: verified build really comes from GitHub commit `ce3cfd3`.
- PASS: process path and SHA256 confirm `ZTool.exe` `8EAF413F...`.
- PASS: launcher does not pick `ZTool-base.exe`.
- PASS: update popup `3.8.5` does not appear.
- PASS: read from SW is no longer `0` positions.
- INFO: license dialog source identified as `Frmmain::tmr_Elapsed -> SR.IsReg2(False) -> FrmRverify.ShowDialog()`.
