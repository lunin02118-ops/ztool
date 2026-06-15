# Phase 04 implementation report — stateful activation and transfer

## Scope

Phase 04 связывает legacy protocol steps через серверное pending-состояние:

- `apply_register -> register_confirm`
- `apply_remove -> remove_confirm`

Цель: убрать blind confirm/replay и не освобождать/занимать seat до завершения
соответствующего confirm.

Эта ветка stacked поверх Phase 03 (`hardening/03-db-state-model` / PR #15).

## Changed files

- `license-server/ztool_license_server/config.py`
- `license-server/ztool_license_server/db.py`
- `license-server/ztool_license_server/server.py`
- `license-server/ztool_license_server/protocol/dispatcher.py`
- `license-server/ztool_license_server/cli.py`
- `license-server/tests/test_integration.py`
- `license-server/tests/test_activation_state.py`
- `license-server/tests/test_db_migrations.py`
- `license-server/tests/test_transfer_state.py`
- `license-server/README.md`
- `docs/production/PRODUCTION_HARDENING_PLAN_RU.md`
- `docs/production/RISK_REGISTER_RU.md`

## Behavior changes

Activation:

- `apply_register` now creates a pending activation, not an active seat.
- Pending activation is keyed by the SHA-256 hash of the 4 apply branches and
  `machine_hash`.
- `register_confirm` parses returned branches, finds matching pending state and
  activates the seat only then.
- Modified branches, expired pending and duplicate/replayed confirm are rejected.

Transfer:

- `apply_remove` no longer deactivates immediately.
- It creates pending transfer and returns `11 + transfer blob`.
- The transfer blob is intentionally non-empty because real client calls
  `SR.outrg(receive)` before sending `remove_confirm`.
- The server stores `transfer_branches_hash` and `transfer_blob_hash` for the
  issued transfer blob.
- `remove_confirm` parses the real `SR.get_rginfo()` payload, computes the hash
  of the returned transfer branches and deactivates only the matching pending
  transfer from the same client IP.
- `remove_confirm` without pending transfer returns `TRANSFER_FAILED` (`8`).

TTL:

- `ZTOOL_PENDING_ACTIVATION_TTL_SECONDS`, default `600`.
- `ZTOOL_PENDING_TRANSFER_TTL_SECONDS`, default `600`.
- CLI cleanup: `python -m ztool_license_server.cli cleanup-pending`.

## Compatibility

- Wire protocol frame format unchanged.
- Existing sendtypes/result-code flow unchanged for successful activation and
  transfer.
- `apply_remove` response is more compatible with real client than before:
  it now includes the transfer blob required by `outrg()`.
- `remove_confirm` no longer uses the most-recent/global pending fallback. The
  client already returns enough data through `SR.get_rginfo()` after `outrg()`,
  so binding is by transfer branch hash + client IP.

## Commands run

```powershell
cd D:\Development\ztool\repo-main\license-server
python -m pytest -q

cd D:\Development\ztool\repo-main
git diff --check
```

## Test results

- `python -m pytest -q`: `105 passed, 2 skipped`
- `git diff --check`: PASS; только Windows warning о будущей замене LF на CRLF.

## Security notes

- `R-001` mitigated: register confirm requires pending apply branch hash.
- `R-002` mitigated with legacy-compatible binding: transfer confirm must echo
  the issued transfer branches from the same client IP. Blind confirm, cross-IP
  confirm, modified branches and replay are rejected.

## Manual checks

Before production release:

- Real UI online activation PASS.
- Real UI transfer PASS.
- Confirm replay attempt rejected in server logs.

## Rollback plan

Откатить PR Phase 04. В БД останутся дополнительные pending rows/columns from
Phase 03/04; старый flow снова будет activate/deactivate earlier. Для полного
rollback production DB нужен backup до выката.

## Known limitations

- Manual real-client transfer smoke remains required before production rollout.
- Pending rows are expired lazily and через CLI `cleanup-pending`; отдельный
  фоновой job/runbook остаётся для Phase 05.
