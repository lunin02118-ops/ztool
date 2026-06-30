# Release Stack Policy

Дата: 2026-06-30

Статус: **актуально после #106**

Цель: не повторять mixed-scope #105. Каждый PR release stack должен иметь один
понятный scope, своё evidence и честный статус Production GO.

## One PR = One Scope

Запрещено смешивать в одном PR:

- version bump;
- runtime/source fix;
- visual layout/localization;
- live SolidWorks E2E;
- property import/save/reload;
- licensing lifecycle;
- installer/signing;
- release dossier;
- accepted hash promotion.

Если PR начинает включать несколько направлений, его нужно split/rebase before
review, а не дотягивать как release gate.

## Evidence rules

- Evidence должно соответствовать exact PR head или exact immutable package.
- Evidence до последнего runtime/source fix не является final proof.
- PR body обязан соответствовать diff.
- Reports должны явно говорить, что закрыто и что не закрыто.
- Production GO нельзя заявлять, пока остаётся хотя бы один P0 blocker.

## Merge rules

1. Красный required CI блокирует merge.
2. Stale evidence блокирует production acceptance.
3. New runtime/source change требует свежие gates для затронутого пути.
4. Visual FULL PASS требует full L-01..L-15 capture, а не только schema/profile.
5. Signing PASS требует production Authenticode без `-AllowUnsigned`.
6. Accepted hashes обновляются только отдельным final PR после owner approval.

## Current recommended stack

| Layer | Scope | Allowed |
|-------|-------|---------|
| Build hygiene | Version/package/installer guards | build scripts, reports, no runtime behavior |
| Exact-head live E2E | S7/S8/strict/branding runtime evidence | E2E scripts/reports only |
| Property E2E | Import/save/reload scenario | E2E scripts/reports only |
| Licensing E2E | no-license/activation/revoke/repeat | E2E scripts/reports only |
| Visual acceptance | L-01..L-15 screenshots/contact sheet | visual scripts/reports only |
| Signing/dossier | Authenticode, final provenance, accepted hashes | release docs/scripts, owner approval |

## Auditor checklist

Перед approve аудитор проверяет:

- scope is single-purpose;
- PR body matches changed files;
- evidence is exact-head;
- no Production GO claim unless final criteria are closed;
- all required gates for this layer are green.
