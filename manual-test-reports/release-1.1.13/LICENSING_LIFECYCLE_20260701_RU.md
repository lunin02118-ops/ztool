# SWTools 1.1.13 - production licensing lifecycle evidence

Дата: 2026-07-02
Статус: PASS
Production GO: NO-GO

## Scope

Этот отчет фиксирует полный автоматизированный P0-прогон production license
server для установленного SWTools 1.1.13.

Проверено:
- production key создан/обновлен на production server;
- binding production key сброшен перед тестом;
- no-license UI видим при старте без действующей локальной лицензии;
- окно регистрации открывается из no-license UI объектным нажатием кнопки
  `Регистрация`;
- онлайн-активация на production server проходит;
- server state после активации: лицензия активна и привязана к текущей машине;
- перенос лицензии выполнен через пользовательский UI регистрации;
- после переноса сервер освободил binding;
- после переноса локальная регистрация больше не проходит `IsReg1`/`IsReg2`;
- production key отозван на сервере;
- отозванный production key физически удален;
- свежий запуск клиента после revoke/delete снова блокируется no-license UI;
- raw license code/password не записаны в отчет.

Не закрыто этим отчетом:
- visual L-01..L-15;
- signing/final release dossier;
- accepted hashes promotion;
- explicit owner Production GO.

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

Raw key and password are stored only in local
`_local_artifacts\secrets\licenses\...` and are not committed.

## Automated Run

Evidence root:

`_local_artifacts\reports\p0-license-lifecycle-20260702-full-run-3`

Machine-readable result:

`_local_artifacts\reports\p0-license-lifecycle-20260702-full-run-3\license-lifecycle-result.json`

Validator command:

```powershell
python tools\e2e\assert_license_lifecycle_result.py `
  _local_artifacts\reports\p0-license-lifecycle-20260702-full-run-3\license-lifecycle-result.json `
  --require-no-license `
  --require-activation `
  --require-transfer `
  --require-revoke `
  --require-delete `
  --require-repeat-check
```

Validator result:

```text
license lifecycle assertion PASS: status=PASS, production_go_allowed=False, stages=12
```

## Stage Results

| Stage | Status | Evidence |
| --- | --- | --- |
| 00-contract | PASS | production_go_allowed=false |
| 01-secret-shape | PASS | redacted code/password shape only |
| 02-no-license | PASS | no-license UI visible before activation |
| 02b-open-registration | PASS | `Регистрация` button clicked by text/HWND, no coordinates |
| 03-server-provision | PASS | production key created/updated |
| 03b-server-reset-binding | PASS | production key binding reset |
| 04-activation | PASS | activation + restart confirmed |
| 05-server-active-state | PASS | current_activations=1, machine_bound=true |
| 05b-transfer-ui | PASS | success modal seen, server released, local unregistered |
| 06-revoke | PASS | is_revoked=1, is_active=0 |
| 07-delete-revoked | PASS | deleted=true, exists_after=false |
| 08-repeat-check | PASS | fresh client start blocked by no-license UI |

## UI And Server Evidence

Activation and transfer were executed through the SWTools UI, not through a
direct local-state write.

Input method:
- registration window opened by `BM_CLICK` on the `Регистрация` button found by
  Win32 text/HWND;
- activation/transfer fields filled by `EM_REPLACESEL`;
- `WM_GETTEXT` read-back;
- `SetWindowText` is not used;
- no fixed screen coordinates.

Server lifecycle:
- provision/reset was executed against the configured production MySQL backend;
- activation created a bound license state;
- transfer released binding through UI;
- revoke set `is_revoked=1` and `is_active=0`;
- delete removed the revoked key after revoke.

Key evidence files:
- `no-license-window-tree.txt`
- `registration-opened-window-tree.txt`
- `activation-form-readback-redacted.json`
- `activation-restart-redacted.json`
- `activation-server-state-redacted.out.log`
- `transfer-registration-before-fill-tree.txt`
- `transfer-form-readback-redacted.json`
- `transfer-after-click-window-tree.txt`
- `lifecycle-revoke-redacted.out.log`
- `lifecycle-delete-revoked-redacted.out.log`
- `repeat-check-window-tree.txt`

## Notes For Auditor

This report closes the P0 licensing lifecycle automation layer for SWTools
1.1.13: no-license, activation, server active state, transfer, revoke, delete
revoked key and repeat blocked client check.

This report is not a Production GO. Production remains NO-GO until visual
L-01..L-15, signing/final dossier, accepted hashes and explicit owner GO are
completed and accepted.
