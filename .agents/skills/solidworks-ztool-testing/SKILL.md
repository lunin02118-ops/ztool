---
name: solidworks-ztool-testing
description: >-
  Run live SolidWorks/ZTool tests on the SW 2025 machine without the recurring
  launch failures. Use this whenever you need to test the ZTool add-in
  (BOM export, ESKD properties, colors/materials, licensing) in SolidWorks, or
  when SolidWorks shows "failed to load Microsoft .NET Framework", hangs on the
  splash, or loads the wrong ZTool.dll.
---

# SolidWorks / ZTool live testing

This skill captures the environment pitfalls that repeatedly broke ZTool testing
on the SW 2025 machine, and the fixed procedure. Authoritative methodology lives
in `docs/release/FULL_TEST_METHODOLOGY_RU.md` (§2.1 registry pre-flight,
§2.2 object-based UI protocol). This skill is the short operational checklist.

## Known failure modes (and root causes)

1. **Repo won't clone/pull.** `git clone` fails with
   `This repository exceeded its LFS budget` because a 3 GB memory dump was
   tracked in LFS. Mitigation: clone with `GIT_LFS_SKIP_SMUDGE=1`, or work on a
   branch where the dump has been removed from HEAD. The dump is not needed for
   functional testing.

2. **False ".NET Framework failed to load" / infinite splash.** When SolidWorks
   or ZTool is launched from an automation/agent shell whose `WINDIR` /
   `SystemRoot` are empty, SolidWorks throws a bogus
   "Failed to load Microsoft .NET Framework" error or hangs on the splash —
   even though launching via the desktop shortcut works. Fix: set
   `WINDIR` / `SystemRoot` / `ComSpec` before launching and confirm RegAsm is
   reachable.

3. **Wrong ZTool.dll loaded.** Stale `RegAsm CodeBase`, SolidWorks AddIn keys,
   or `HKCU\SOFTWARE\ZTool` from a previous test make SolidWorks load a
   different DLL than the one under test, producing misleading results. Fix:
   re-register the current `runtime\ZTool.dll` via `RegAsm /codebase` and verify
   the live `CodeBase` points at the runtime folder.

4. **Non-reproducible GUI automation.** Testing from floating windows / random
   screen coordinates is not reproducible and cannot pass an acceptance gate.
   Fix: drive controls by UIA/WinForms/SolidWorks COM locators, or by the Win32
   helper `scripts\ztool_acceptance_ui.ps1` (`pid` + class + visible text +
   `BM_CLICK`) when legacy WinForms controls are not exposed through UIA.

5. **False activation input from `SetWindowText`.** Native `SetWindowText` /
   `GetWindowText` can make WinForms edit boxes look correct while the managed
   `TextBox.Text` value sent to the license server remains stale. Fix: enter
   activation codes by manual copy/paste or UIA `ValuePattern.SetValue`, then
   prove it with UIA read-back plus server audit. Never count `SetWindowText` as
   activation evidence.

6. **Wrong license database checked.** Production `ztool-tcp-server.service` may
   use `ZTOOL_DB_BACKEND=mysql`; old SQLite files in the service directory can be
   stale. Fix: read/reset license rows through the configured backend, and do not
   deploy a local checkout over production until backend-specific adapters are
   accounted for.

7. **Secrets printed from service environment.** `systemctl show ... -p
   Environment` can expose DB passwords in logs. Fix: load service environment
   inside the reset/deploy script and print only redacted status, masks, lengths
   and hashes.

## Procedure

1. **Get a clean checkout** (if cloning): `GIT_LFS_SKIP_SMUDGE=1 git clone ...`.

2. **Clear stale ZTool CommandManager tabs** (prevents the blank/duplicate tab —
   see finding F-14). Dry-run first, then apply:

   ```powershell
   powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_ztool_commandmanager_tabs.ps1
   powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_ztool_commandmanager_tabs.ps1 -Apply
   ```

   - Removes named ZTool tabs AND anonymous clones (`Tab Props=0,1,1,-1` with the
     `2,59425` / `41658..41675` button set) plus ZTool `Custom API Flyouts`.
   - Backs up the SolidWorks HKCU branch before deleting; idempotent; writes JSON.
   - Add `-IncludeAddInsStartup` only for uninstall (zeroes AddInsStartup).

3. **Run the pre-flight gate** from the repo root:

   ```powershell
   powershell -NoProfile -ExecutionPolicy Bypass -File scripts\sw_test_preflight.ps1 -RuntimeDir .\runtime -Register
   ```

   - Normalizes the launch environment and verifies RegAsm.
   - Backs up the affected registry branches into a report folder.
   - Re-registers `runtime\ZTool.dll` and verifies `CodeBase`.
   - Verifies `ZTool.exe` / `ZTool.dll` SHA256 against accepted hashes.
   - Add `-CleanLicenseState` ONLY for clean-license scenarios (it deletes the
     license-state keys); do not use it for ordinary BOM/color/export runs.
   - Status must be `PASS` (or `PASS_WITH_WARNINGS` only if you accept the
     warnings) before continuing. Do not test from a failed pre-flight.

4. **Launch correctly.** Open `TestModel\0614-A00.SLDASM` via Explorer / the
   `.SLDASM` association — do NOT start `SldWorks.exe` standalone from a shell.
   Maximize SolidWorks, then start ZTool only from the SolidWorks ribbon
   ("Управление файлами"), and maximize the `ZTool 1.0(x64)` window.

5. **Confirm the right binary is running** before trusting any result:

   ```powershell
   Get-Process ZTool | Select-Object Id, Path, MainWindowTitle
   Get-FileHash (Get-Process ZTool).Path -Algorithm SHA256
   ```

   If the path is not the test runtime folder or the hash does not match the
   expected build, the test is invalid — fix registration/launch first.

6. **Follow `FULL_TEST_METHODOLOGY_RU.md`** for the actual A/B parity steps
   (29-row connect check, 8 BOM modes, colors/materials, ESKD properties), and
   save window-tree dumps, read-back JSON/TXT and screenshots of control points
   into the report folder. Coordinate clicks are diagnostic only and never count
   as passed evidence.

6. **For licensing gates**, verify the current code shape (`8-5-5-5-9`), enter
   the segments by copy/paste or UIA `ValuePattern`, redact the full key/password
   in evidence, and after `Регистрация выполнена` confirm old PID exit + new PID
   start. Seeing the success modal alone is not a pass.

## Do / don't

- DO take a registry backup before any registry change (the pre-flight does this).
- DO record the running ZTool.exe path + hash in the test report.
- DO use object locators (`AutomationElement`, WinForms control, SolidWorks COM,
  or `scripts\ztool_acceptance_ui.ps1`) for every gate action.
- DO treat production MySQL as the license source of truth when
  `ZTOOL_DB_BACKEND=mysql`.
- DO keep service environment output redacted; never paste DB passwords into
  evidence or chat.
- DON'T launch SolidWorks/ZTool from a shell with empty `WINDIR`.
- DON'T mark a UI action as passed when it only used hardcoded screen
  coordinates.
- DON'T fill activation fields with native `SetWindowText`; it can pass visual
  read-back while sending stale values.
- DON'T log full activation codes or license passwords; use mask, length and
  SHA12 only.
- DON'T mark `FULL PASS` from offline/pre-flight checks alone — a live SolidWorks
  run with the §15 journal filled in is required.
