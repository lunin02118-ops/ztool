# Final acceptance test plan

Тесты выполняются только на release package с точным `manifest.json` и
`SHA256SUMS.txt`.

## Package pre-flight

- `scripts/verify_release_package.ps1 -PackageRoot <package> -RequireSolidWorksTools` PASS.
- `manifest.git.dirty=false`.
- `runtime/ZTool.exe` hash matches accepted release hash.
- `runtime/ZTool.dll` hash matches accepted release hash.
- `runtime/ZTool_rsa.dll` is present and hash matches accepted release hash.
- `runtime/SolidWorksTools.dll` is present.
- `runtime/SolidWorksTemplates/MyMaterials.sldmat` is present.
- `runtime/ZTool.settings` points `materialpath` at packaged
  `runtime/SolidWorksTemplates/MyMaterials.sldmat`.
- `runtime/ZTool.settings` has `usematerialcolor=true`.
- Package contains no private keys, DB files, dumps or local logs.

## Server

- Fresh install на staging VPS.
- Migration from previous DB backup.
- Key load через `ZTOOL_PRIVATE_KEY_FILE` / `ZTOOL_PUBLIC_KEY_FILE`.
- Database source of truth matches `ZTOOL_DB_BACKEND`. On production this is
  MySQL `license_keys`; stale SQLite files are not valid evidence.
- `python -m ztool_license_server.cli healthcheck` PASS.
- `backup` + `verify-backup` PASS.
- Valid online activation PASS.
- Invalid code rejected.
- Wrong password rejected.
- Expired code rejected.
- `device_limit` enforced.
- Transfer-out via real UI PASS.
- Replay confirm rejected.
- Malformed frame rejected.
- Oversized frame rejected.

## Client

- Clean Windows VM / clean test folder.
- Old registry/license traces cleared.
- `RegAsm ZTool.dll /codebase` PASS.
- Trial starts and closes only after object-located `Проба` action
  (`AutomationElement` or Win32 `HWND`/text/class); coordinate clicks do not
  count as evidence.
- Activation dialog RU.
- Online activation button is invoked by object locator (`Активация онлайн`,
  `HWND`/text/class, async post); coordinate clicks do not count as evidence.
- Activation code format is verified as `8-5-5-5-9` segments. Full code/password
  are never written to logs; only mask, length and SHA12 are allowed.
- Activation field input is manual copy/paste or UIA `ValuePattern.SetValue`
  with read-back. Native `SetWindowText` / `GetWindowText` does not count because
  it can leave managed WinForms `TextBox.Text` stale.
- Online activation succeeds and server audit shows the expected license row.
- Success `OK` closes the activation dialog, old PID exits, new PID starts, and
  the restarted app remains licensed without showing the registration dialog.
- Transfer via UI succeeds.
- Reactivation after transfer succeeds.
- Invalid code message RU.
- Wrong password message RU.
- Server unavailable message RU.

## SolidWorks

- SOLIDWORKS 2025 smoke PASS.
- Optional SOLIDWORKS 2024/2023 smoke.
- ZTool ribbon visible.
- Icons visible.
- `Управление файлами` starts package `runtime/ZTool.exe`.
- `Подключить SW` reads expected rows.
- Read by BOM and read all modes checked.
- Default material library is available in ZTool settings.
- Material/color columns are populated as expected after `Подключить SW`.
- BOM export 8/8 modes PASS.
- Save/export basic smoke PASS.

## Localization

- `localization_scan.py` PASS: `unclassified_han=0`.
- UI screenshot checklist complete.
- BOM template RU formatting accepted.

## Ops

- systemd service starts.
- service restarts on failure.
- logs redacted.
- DEBUG disabled in production env.
- backup exists.
- restore drill completed.

## Go/No-Go

Go only if:

- all P0/P1 risks are closed or explicitly accepted;
- release package verifier PASS;
- rollback package/instructions are ready.
