# P4 Audit Delta — поправки к P4-плану по итогам Deep Audit

**Дата:** 2026-06-23  
**Статус:** audit delta + P4-plan correction (только документация/политики).  
**Связанные документы:** `docs/audit/DEEP_AUDIT_ADDENDUM_RU.md`, `docs/production/ZTOOL_P4_PERFECTION_PLAN_RU.md`, `docs/production/RISK_REGISTER_RU.md`.

> **Важно:** этот документ и весь PR не меняют application runtime/source code — только план, политики и реестр рисков.

---

## Scope этого PR (бывш. «PR #71»)

PR является **audit delta + P4-plan correction PR**, а не «legal docs PR».

- [x] Update P4 plan according to Deep Audit delta.
- [x] Convert legal/IP from “pending approval” to “external non-public approval attestation”.
- [x] Explicitly forbid committing legal documents.
- [x] Add missing delta sprints: repo hygiene, BinaryFormatter containment, localization architecture debt, signing final gate.
- [x] Update risk register classification.
- [x] Do not change application runtime/source code.

---

## 1. Legal/IP: изменить модель, не публиковать документы

Deep Audit изначально ставил legal/IP как главный риск (deobfuscation, publicize, patch/reinject, rekey, rebrand, replacement license-server tooling). Корректная модель:

```text
Rights resolved externally.
Repo contains only redacted attestation/status.
No legal documents in Git.
P4 blocker exists only if release owner cannot confirm external approval
or release scope exceeds approval.
```

Реализация: `docs/compliance/LEGAL_APPROVAL_STATUS_RU.md` переведён из `BLOCKED / PENDING APPROVAL` в `EXTERNALLY APPROVED (non-public attestation)` для покрытого scope. Юр-документы в Git запрещены (P4-план §3.1).

## 2. Delta-спринты (ранее не выделены)

| Спринт | Цель | Acceptance |
|--------|------|------------|
| **L — Repo hygiene closure** | loose-бинари/CAD → LFS/artifact storage; вынос `client-rekey/*.txt` из трекинга | clean clone без secrets/крупных бинарей; secret-scan PASS |
| **M — BinaryFormatter containment** | зафиксировать allow-list биндер (`SafeListBinder`/`VTBinder`) как явный gate | `BinderInject --verify` в CI; нет регресса desearialization |
| **N — Localization architecture debt** | уход от IL-патча строк к ресурсной/satellite i18n | локализация без ручного скриншот-гейта |
| **O — Signing final gate** | Authenticode-подпись артефактов вместо опоры только на SHA256-пины | подпись проверяется в release-acceptance |

## 3. Классификация рисков

Обновлена в `docs/production/RISK_REGISTER_RU.md` (раздел «Deep Audit delta»): R-DA-LEGAL, R-DA-DISTR, R-DA-ITEXT, R-DA-SECRETS, R-DA-HYGIENE, R-DA-BINFMT, R-DA-LOC, R-DA-SIGN.

## 4. Осторожно с third-party inventory

`docs/compliance/third_party_inventory.json` и `scripts/check_license_policy.ps1` в этом PR **не изменяются**. При будущих правках **нельзя** делать поле `externally_approved` универсальной отмычкой для всех third-party DLL: external approval покрывает только ZTool/SWTools runtime, но не iText/Ribbon/ExpandableGridView/NPOI — их лицензии оцениваются отдельно.
