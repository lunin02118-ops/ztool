# Manual clean install + activation prep — 2026-06-17

## Scope

- Package: `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\release\ZTool-1.0.0-20260617-135653`
- Client installer: `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\release\client-installer\ZTool-1.0.0-20260617-135653-Setup.exe`
- Production endpoint: `license.vizbuka.ru:58000`
- Runtime hashes:
  - `ZTool.exe`: `7688EA399F3EA38672966043EDBE5F3F0102048369706882F4A35EB009A5D8FD`
  - `ZTool.dll`: `D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9`
- Installer SHA256:
  - `05B376F3D412C178E6FD35D44635B398EDFB0304FA0A77A33870E4144C32C94B`

## Client installer

- Built a production Windows client installer with NSIS 3.11.
- Source runtime:
  - `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\release\ZTool-1.0.0-20260617-135653\runtime`
- Installer behavior:
  - installs to `%ProgramFiles%\ZTool`
  - copies runtime payload, SolidWorks templates, help and dependencies
  - registers `ZTool.dll` with 64-bit `RegAsm /codebase`
  - creates `HKLM\SOFTWARE\SolidWorks\Addins\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}`
  - enables `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}`
  - removes version-specific SolidWorks startup/add-in remnants for ZTool GUID
  - writes a normal Windows uninstall entry
  - preserves license state on uninstall
- Build manifest:
  - `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\release\client-installer\ZTool-1.0.0-20260617-135653-Setup.manifest.json`
- Generated NSIS script:
  - `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\release\client-installer\ZTool-1.0.0-20260617-135653-Setup.generated.nsi`

## Installer smoke

- Silent install target:
  - `D:\Development\ztool\_local_artifacts\scratch\install-smoke\ZToolInstallerSmoke`
- Install verification: PASS
  - `ZTool.exe`, `ZTool.dll`, `Uninstall.exe` present
  - COM `CodeBase` points at `D:\Development\ztool\_local_artifacts\scratch\install-smoke\ZToolInstallerSmoke`
  - SolidWorks global add-in key present
  - global `HKCU\SOFTWARE\SolidWorks\AddInsStartup` value enabled
  - version-specific `SOLIDWORKS 2025` ZTool add-in/startup remnants absent
- Silent uninstall verification: PASS
  - install directory removed
  - COM `CodeBase` removed
  - SolidWorks global add-in key removed
  - global and version-specific ZTool startup values/subkeys removed

## Local cleanup / install state

- Registry backup created before cleanup:
  - `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\manual-test-reports\MANUAL_CLEAN_ACTIVATION_20260617-201649\preflight-clean-install`
- Removed local license blobs:
  - `HKLM\SOFTWARE\SolURxxCfNU` absent
  - `HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ` absent
- Final local state after installer smoke/uninstall:
  - `HKCU\SOFTWARE\ZTool` absent
  - COM `CodeBase` for CLSID `{59959DFA-3229-4B86-852E-52ABF2BDB8C0}` absent
  - `HKLM\SOFTWARE\SolidWorks\Addins\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}` absent
  - global `HKCU\SOFTWARE\SolidWorks\AddInsStartup` ZTool value/subkey absent
  - version-specific `SOLIDWORKS 2025` ZTool startup value/subkey absent
  - `ZTool` and `SLDWORKS` processes absent
- Manual test should now start by running the client installer above.

## Clean-start control

- Started `runtime\ZTool.exe` after cleanup.
- Result: registration/no-license gate appeared; main window existed but was disabled.
- Screenshot:
  - `D:\Development\ztool\_local_artifacts\evidence\manual-clean-activation\ztool-manual-clean-before-activation.png`
- `ZTool` and `SLDWORKS` were closed after the control check.

## Server status

- Production TCP activation port is reachable:
  - `license.vizbuka.ru:58000` PASS
- Direct SSH from this workstation to `license.vizbuka.ru:22` timed out after earlier public-key failures.
- Management access was restored through jump host `01-cli-proxy-hermes`.
- Server host: `vm3776683.firstbyte.club`
- Service: `ztool-tcp-server.service` active.
- Backend: MySQL database `ztool_license`.

## Server reset

- MySQL backup created before mutation:
  - `/opt/ztool-tcp-server/backups/manual_clean_activation_20260617T153612Z/ztool_license_before_reset.sql`
- Previous production clean-install test rows removed:
  - `license_keys.id IN (39, 40)`
  - related `activation_log` rows for those ids
- Fresh manual activation key created:
  - `license_keys.id = 41`
  - masked key: `DPQP...WFGP`
  - key length: `36`
  - `license_type = ztool_perpetual`
  - `max_activations = 1`
  - `current_activations = 0`
  - `is_active = 1`
  - `is_revoked = 0`
- Key value was not recorded in this report. It was saved to:
  - server: `/opt/ztool-tcp-server/backups/manual_clean_activation_20260617T153612Z/new_manual_activation_key_id_41.txt`
  - local: `D:\Development\ztool\_local_artifacts\secrets\licenses\ztool-manual-activation-key-id-41.txt`
