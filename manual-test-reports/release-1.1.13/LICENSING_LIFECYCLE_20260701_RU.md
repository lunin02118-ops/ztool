# SWTools 1.1.13 - production licensing lifecycle evidence

Дата: 2026-07-01
Статус: PASS_WITH_WARN
Production GO: NO-GO

## Scope

Этот отчет фиксирует боевую проверку production license server для установленного SWTools 1.1.13.

Проверено:
- production key существует и имеет корректную форму;
- binding production key сброшен перед тестом;
- онлайн-активация на production server проходит;
- server state после активации: лицензия активна и привязана к текущей машине;
- перенос лицензии выполнен через пользовательский UI регистрации;
- после переноса сервер освободил binding;
- после переноса локальная регистрация больше не проходит `IsReg1`/`IsReg2`;
- raw license code/password не записаны в отчет.

Не закрыто этим отчетом:
- полный no-license UI gate;
- revoke/delete revoked key lifecycle в этом же автоматическом прогоне;
- final production release approval;
- accepted hashes promotion;
- signing/final release dossier.

## Runtime

- Runtime dir: `C:\Program Files\SWTools`
- `SWTools.exe` SHA256: `7891705ced7873aad69515e1eafe9a6b647faca4133ce73cbe0dde1a108f2bd8`
- `SWTools.dll` SHA256: `995b4472f1155e897bc109b6335bea87b0fd5f3a7ad61cbda29f543cfe9f948f`
- Server client version env: `1.1.13+8a63d30.clean`

## License Secret Evidence

- Code mask: `GYV6...34RL`
- Code SHA12: `4967f4b3c43e`
- Segment lengths: `8-5-5-5-9`
- Password length: `12`
- Password SHA12: `5b1946b514f6`

Raw key and password are stored only in local `_local_artifacts\secrets\licenses\...` and are not committed.

## Automated Run

Evidence root:

`_local_artifacts\reports\p0-license-lifecycle-20260701\transfer-script-rerun`

Machine-readable result:

`_local_artifacts\reports\p0-license-lifecycle-20260701\transfer-script-rerun\license-lifecycle-result.json`

Validator command:

```powershell
python tools\e2e\assert_license_lifecycle_result.py `
  _local_artifacts\reports\p0-license-lifecycle-20260701\transfer-script-rerun\license-lifecycle-result.json `
  --allow-warn `
  --require-activation `
  --require-transfer
```

Validator result:

```text
license lifecycle assertion PASS: status=PASS_WITH_WARN, production_go_allowed=False, stages=11
```

## Stage Results

| Stage | Status | Evidence |
| --- | --- | --- |
| 00-contract | PASS | production_go_allowed=false |
| 01-secret-shape | PASS | redacted code/password shape only |
| 02-no-license | SKIP | not requested in transfer-focused run |
| 03-server-provision | SKIP | key already provisioned |
| 03b-server-reset-binding | PASS | production key binding reset |
| 04-activation | PASS | activation + restart confirmed |
| 05-server-active-state | PASS | current_activations=1, machine_bound=true |
| 05b-transfer-ui | PASS | success modal seen, server released, local unregistered |
| 06-revoke | SKIP | not requested in this run |
| 07-delete-revoked | SKIP | not requested in this run |
| 08-repeat-check | SKIP | not requested in this run |

## Transfer Evidence

Transfer was executed through the registration UI, not through a direct database mutation.

Input method:
- `EM_REPLACESEL` for edit controls;
- `WM_GETTEXT` read-back;
- `SetWindowText` is not used;
- no fixed screen coordinates.

Transfer result:
- success modal: `Лицензия успешно перенесена`;
- server `current_activations=0`;
- server `machine_bound=false`;
- server `is_active=1`;
- server `is_revoked=0`;
- local registration after transfer: unregistered.

UI evidence files:
- `transfer-registration-before-fill-tree.txt`
- `transfer-form-readback-redacted.json`
- `transfer-after-click-window-tree.txt`

## Notes For Auditor

The production server currently uses the MySQL backend and the older direct deactivate transfer path. The tested behavior is accepted for this layer: activation binds the key, UI transfer releases the binding, and the local client becomes unregistered.

This report is not a Production GO. It is a focused licensing lifecycle evidence package for activation and transfer automation.
