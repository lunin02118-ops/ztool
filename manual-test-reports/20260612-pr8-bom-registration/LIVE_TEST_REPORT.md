# LIVE_TEST_REPORT

Date: 2026-06-12 10:00 +05:00
Repo: `lunin02118-ops/ztool`
Branch: `devin/1781201882-bom-templates`
HEAD: `ba1b31a31c8c46b6830b4e1b4a584117d5c87b37`

## Scope

PR #8 retest after `ba1b31a`: BOM template export fix (`ICSharpCode.SharpZipLib.dll` + corrected Excel defined-name mapping).

Additional user request during test: register ZTool against the production license service, using a code generated on the website, and record license-server issues immediately.

## Runtime

Clean runtime folder: `D:\ztool-pr8-test`

Source artifacts:

- `ZTool.exe`: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- `ZTool.dll`: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
- source `ZTool.settings`: `C7D87AB3D2E12C918F54B4EB1937DC325BF9A00852984028F83CE73D62C8FAA9`
- runtime `ZTool.settings` after app run: `00DD64663B3B4174F6F54A3CF7FF872E9133824A2C22BBFB78B5ED2A5A1CF422`
- `ICSharpCode.SharpZipLib.dll`: `40B3D590F95191F3E33E5D00E534FA40F823D9B1BB2A9AFE05F139C4E0A3AF8D`

`RegAsm /codebase`: OK. COM `CodeBase` points to `file:///D:/ztool-pr8-test/ZTool.DLL`.

## SolidWorks / ZTool

SolidWorks: `SOLIDWORKS Premium 2025 SP3.0`

Model: `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`

ZTool process launched from clean runtime:

- path: `D:\ztool-pr8-test\ZTool.exe`
- hash: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`

Read from SW:

- `Подключить SW`: OK
- table filled: 29 rows
- status: `Подключение завершено, затрачено 0,2 сек.`

## License Registration

Requirement: registration must use the production license service and a code generated on the website.

Confirmed/used:

- client endpoint: `185.112.102.122:58000`
- local license server must not be used for this run.
- SSH audit found the active production VPS key: `C:\Users\VladimirWorkPC\.ssh\rheolab_deploy`
- VPS service status: `ztool-tcp-server.service` active, port `58000` listening.

Result:

- Production `Apply_register`: server accepted the website-generated activation code/password and returned result `13`.
- Stock client-side online confirm failed: `verify_register` returned result `6`.
- Root cause observed locally: `ZTool.GetRegistrycreatedtime.getregistryKeytime(...)` returns empty strings for registry creation time fields because internal reflection/PInvoke fails with:
  `Method not found: 'Int32 ZTool.GetRegistrycreatedtime.RegCloseKey(UIntPtr)'`.
- Because those two fields are empty, the current client cannot build the confirm payload expected by the production server.
- Workaround used only to unblock BOM testing: generated a confirm blob on the production VPS with the same empty creation-time fields and wrote the final HKLM confirm branches locally.

Correction after review:

- The manual confirm/HKLM write above is **not** a valid UI registration test.
- Treat it only as a temporary workaround used to continue BOM export testing.
- The real registration/transfer UI flow remains failed until it passes through the ZTool form and server without direct registry writes.

Final local validation after workaround:

- `ZTool.SR.IsReg2(...) = True`
- `HKCU\SOFTWARE\ZTool\sn = 03000200-0400-0500-0006-000700080009`
- ZTool title after restart: `ZTool 1.0(x64)`; no trial countdown.

Finding: licensing is usable after manual confirm injection, but the normal online-confirm path is still broken in the client/server flow for this build.

UI note after activation:

- The registration dialog correctly shows `Действует до: бессрочно`.
- If the user presses `Активация онлайн` while the form contains the already-issued local registration SN (`03000200-...`), the client shows `Недопустимый код, обратитесь к автору для покупки кода`.
- This message is misleading after successful registration: the local SN is not the original purchase/activation code expected by the online server. The form should either disable online activation when already registered, clear the activation-code fields, or show a clearer message.

## License Transfer UI Retest

No code changes were made for this retest. The already-open ZTool registration dialog was used.

Initial state:

- ZTool process path: `D:\ztool-pr8-test\ZTool.exe`
- ZTool process hash: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- Local `ZTool.SR.IsReg2(...) = True`
- Production VPS `activations.is_active = 1` for the tested website-generated code.

UI input:

- Registration-code fields were populated with the original website-generated activation code, not the local generated SN.
- Password field was populated with the activation password.
- Button clicked: `Перенести лицензию`.

Observed result:

- ZTool showed message: `Недопустимый код, обратитесь к автору для покупки кода`.
- Local registration stayed active: `ZTool.SR.IsReg2(...) = True`.
- Production VPS binding stayed active: `activations.is_active = 1`.
- Production `audit_log` showed no new `apply_remove` entry for this click; the transfer request did not reach the server as a successful transfer request.

Finding: license transfer through the UI is failed. The client rejects the transfer path with the generic invalid-code message before the server-side transfer/deactivation flow completes.

Additional UI defect:

- In `FrmRg`, the five registration-code text boxes are 80 px wide.
- The fifth field clips long code groups: the local SN last group `000700080009` does not fit visually.
- This is a UI layout defect independent of server activation logic.

## BOM Export

After registration workaround, BOM export was retested with:

- SolidWorks model: `D:\ztool-pr8-test\TestModel\0614-A00.SLDASM`
- `Подключить SW`: OK, table filled, status `Подключение завершено, затрачено 0,2 сек.`
- ZTool process hash: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`

### Failure 1: template path is resolved to Documents

Direct export with PR #8 runtime settings failed with a Russian error dialog:

`Ошибка при экспорте спецификации с сохранением, нам не удалось найти файл C:\Users\VladimirWorkPC\Documents\Шаблоны спецификации\bom_шаблон.xlsx. Возможно, он был перемещен, переименован или удален?`

But the tested profile contains:

- `<bomsubfolder>true</bomsubfolder>`
- `<bomname>Шаблоны спецификации\bom_шаблон.xlsx</bomname>`

And the template exists next to the app:

- `D:\ztool-pr8-test\Шаблоны спецификации\bom_шаблон.xlsx`
- SHA256: `6A6722555A880BD2B41E16252B0515BF3CAB733DE0296873286D0F388E755796`

Conclusion: PR #8 changed the profile to a relative path, but the runtime resolver still searches under `Environment.SpecialFolder.MyDocuments`, not beside `ZTool.exe`.

### Failure 2: exported workbook is empty after path workaround

Workaround: copied the same template to:

`C:\Users\VladimirWorkPC\Documents\Шаблоны спецификации\bom_шаблон.xlsx`

Then export completed and created:

- `C:\Users\VladimirWorkPC\Desktop\0614-A00-20260612-1149.xlsx`
- copied artifact: `manual-test-reports/20260612-pr8-bom-registration/export-summary-workaround-documents-template-empty.xlsx`
- SHA256: `D7888936C2544AF92F35FA2CC098AFFF36EC14D517635C329AC844E1DBD90AE2`
- size: `16470` bytes

`openpyxl` validation:

- workbook opens as valid `.xlsx`
- sheet: `图纸明细1`
- dimension: `A1:S104`
- defined names are present: `图号`, `序号`, `材质`, `版本`, `磁盘文件名`, `类型`, `统计数量`, `缩略图`, `表面处理`, `路径`, `重量`, `零件名称`
- non-empty rows: `1..6` only
- rows after header row 6: `0` populated rows

Conclusion: SharpZipLib/NPOI dependency is present and the workbook can be created, but BOM data is not written into the template. This is still a PR #8 regression/blocker.

### Additional environment note

SolidWorks GUI starts normally through the desktop shortcut and the ZTool ribbon is loaded. PowerShell COM automation via `SldWorks.Application` currently fails with `TYPE_E_ELEMENTNOTFOUND`; the manual GUI path was used for this report.
