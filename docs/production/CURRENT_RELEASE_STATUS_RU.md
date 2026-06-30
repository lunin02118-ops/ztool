# Текущий статус релиза после #106

Дата: 2026-06-30

Статус: **Production GO: NO-GO**

Этот документ фиксирует текущую release-базу после merge #106 и объясняет,
какие PR смотреть дальше. Он не является release dossier, не утверждает
accepted hashes и не заменяет live E2E/visual/signing evidence.

## База

- #106 merged в `main`: native SWDM property import engine восстановлен.
- #105 закрыт как superseded / split-required: PR был mixed-scope, содержал stale
  evidence и не годился как финальный production gate.
- #107 merged: installer stale package/version guard добавлен в release-hardening.
- Evidence до #106 нельзя использовать как final production proof.
- Final proof должен быть снят только с exact current head или с immutable
  release package, собранного из exact current head.

## Текущий открытый стек

| PR | Назначение | Scope | Production GO |
|----|------------|-------|---------------|
| #108 | P0 production matrix и release governance docs | docs/process only | NO-GO |
| #109 | Exact-head live SolidWorks E2E evidence | live E2E only | NO-GO |
| #110 | Property import/save/reload E2E | property E2E only | NO-GO |
| #111 | Licensing lifecycle E2E | licensing E2E only | NO-GO |

## Что закрыто

- Native SWDM import engine: CLOSED by #106.
- Mixed-scope #105 cleanup: CLOSED by closing #105 as superseded.
- Installer stale package/version guard: CLOSED by #107.
- P0 blockers are now tracked in `P0_PRODUCTION_GO_MATRIX_RU.md`.

## Что открыто

- Exact-head live SolidWorks S7/S8 on installed runtime.
- BOM 8/8 + strict filters on installed runtime.
- Full user-facing property import/save/reload.
- Licensing lifecycle: no-license, activation, revoke/delete, repeat check.
- Full visual L-01..L-15 strict PASS.
- Authenticode signing for `SWTools.exe`, `SWTools.dll`, installer.
- Accepted hash promotion.
- Final release dossier.
- Explicit owner GO.

## Source of truth

- Release blockers: `docs/production/P0_PRODUCTION_GO_MATRIX_RU.md`.
- GO rules: `docs/production/PRODUCTION_GO_CRITERIA_RU.md`.
- PR scope policy: `docs/production/RELEASE_STACK_POLICY_RU.md`.
- Accepted runtime hashes: `scripts/expected_release_hashes.json`.

Loose root binaries are historical/accepted snapshots and are not a production
source of truth. Source-built/package outputs with exact-head evidence are the
release source of truth for new production decisions.
