# E2E strict S8 fixture live report

Дата: 2026-06-24
Ветка: `codex/e2e-strict-s8-fixture`
Проверенный commit: `79fdb358a28cbcfae89509cad781181991e98f5f`
Статус: `PASS_WITH_WARN`
Production GO: `NO-GO`

## Цель

Проверить, что после #84 строгий E2E-слой закрывает регрессию пустых режимов S8 7/8: fixture должна содержать русские значения свойства `Тип`, экспорт должен пройти по всем 8 режимам BOM, а режимы 7/8 должны вернуть строки.

## Команда

```powershell
$out='_local_artifacts\reports\e2e\s8-bom-strict-20260624-13-clean'
pwsh -NoProfile -File scripts\e2e\Invoke-SWToolsE2E.ps1 `
  -BuildFromSource -RunS7 -RunS8 `
  -PrepareStrictBomFixture -ForceStrictBomFixture `
  -RequireSolidWorks `
  -SolidWorksExe 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe' `
  -SolidWorksToolsDll 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorksTools.dll' `
  -TestAssembly 'D:\Development\ztool\_local_artifacts\worktrees\pr85-s8-strict-fixture\TestModel\0614-A00.SLDASM' `
  -ExpectedMinRows 29 -ExpectedMinColumns 30 `
  -ExpectedBomModeCount 8 `
  -RequireStrictBomFilters `
  -OutputDir $out
```

Evidence directory, not committed:
`_local_artifacts\reports\e2e\s8-bom-strict-20260624-13-clean`

## Fixture

Source `TestModel` was not modified. The strict fixture was copied into `_local_artifacts` and prepared there.

Written document counts:

| `Тип` value | Count |
| --- | ---: |
| `Сборка` | 5 |
| `Покупное` | 6 |
| `Мех.обработка` | 18 |

The fixture manifest verifies every written document property and reports `save_errors=0`, `save_warnings=0`.

## S7 result

| Check | Result |
| --- | --- |
| Runtime commit dirty flag | `false` |
| Runtime title | `SWTools 1.1.6+79fdb35.clean(x64)` |
| SolidWorks model | strict fixture `0614-A00.SLDASM` |
| License/trial dialog | dismissed through object automation, button `Демо` |
| Connect action | UIA worker, no coordinate click |
| Rows | 29 |
| Columns | 40 |
| Status text | `Подключение завершено, затрачено 0,3 сек, всего 29 поз.` |

Runtime hashes from S7 evidence:

| File | SHA-256 |
| --- | --- |
| `SWTools.exe` | `F75B1BBE9023D4D238F855EDC0BF9EF4B759DDEEBEAED58E8EE4350027FD58CC` |
| `SWTools.dll` | `BFBA77C44A7BC5200DD2DD0018EC2B674ECA6D1B67B59B7A3EFA4C5B28835E71` |

## S8 result

Strict filters: `true`
Issues: none

| Mode | Rows | Images | Export modal |
| ---: | ---: | --- | --- |
| 1 | 29 | no | button `Нет`, SWTools PID matched |
| 2 | 32 | no | button `Нет`, SWTools PID matched |
| 3 | 6 | no | button `Нет`, SWTools PID matched |
| 4 | 25 | no | button `Нет`, SWTools PID matched |
| 5 | 29 | yes | button `Нет`, SWTools PID matched |
| 6 | 32 | yes | button `Нет`, SWTools PID matched |
| 7 | 18 | no | button `Нет`, SWTools PID matched |
| 8 | 6 | no | button `Нет`, SWTools PID matched |

Acceptance for this PR:

- `mode 7 rows > 0`: PASS.
- `mode 8 rows > 0`: PASS.
- `-RequireStrictBomFilters`: PASS.
- `--require-s8-mode-count 8`: PASS.
- `--require-s8-all-pass`: PASS.

## Bugs found and fixed during live testing

1. Add-in IPC receiver could be missing after partial/dirty COM load. `openZtool()` called the receiver before the guarded block and could fail before SWTools received the request. Fixed by recreating the PMP receiver before sending.
2. S7 automation could hang on synchronous UIA `Invoke` for `Подключить SW`. Fixed by running the UIA invocation in a worker while the main test watches grid status and blocking dialogs.
3. License/trial dialog was not reliably dismissed because WinForms buttons exposed `System.Windows.Forms.Button`, not plain `Button`. Fixed button classification and object-level dialog handling.
4. Child E2E commands had no hard timeout. Fixed `Invoke-E2ECommand` with timeout, async stdout/stderr reads and process-tree kill.
5. S8 export completion modal handling was slow and could wait unnecessarily. Fixed process-scoped button handling, faster polling and stable-file detection.

## Residual risk

This is still not Production GO. The overall status is `PASS_WITH_WARN` because the live branding/version evidence stage is intentionally `SKIP` and remains a later E2E layer. Signing, localization screenshots, final release dossier and owner GO are still required.
