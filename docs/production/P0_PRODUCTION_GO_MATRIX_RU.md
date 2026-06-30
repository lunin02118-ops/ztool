# P0 Production GO Matrix

Дата: 2026-06-29

Статус: Production GO: NO-GO

Назначение документа: единая P0-матрица оставшихся блокеров после merge #106.
Документ не является release dossier и не промоутит accepted hashes.

## Правила выполнения

Каждый P0 закрывается отдельным узким PR или явно ограниченным стеком PR.

Нельзя смешивать в одном PR:

- version bump;
- runtime/UI changes;
- visual L-01..L-15;
- live SolidWorks E2E;
- licensing lifecycle;
- signing;
- release dossier;
- accepted hash promotion.

Evidence считается валидным только если оно снято с exact current head или с
явно указанного immutable release package, собранного из exact current head.
Evidence со старых commit до #106 не является final proof.

## P0 blockers

| ID | Блокер | Что требуется для закрытия | Evidence | Статус |
|----|--------|----------------------------|----------|--------|
| P0-01 | Final live SolidWorks E2E on exact final build | Собрать final package из exact head, установить/запустить именно его, подтвердить runtime path/hash | `e2e-result.json`, runtime hashes, process path, report | OPEN |
| P0-02 | BOM 8/8 + strict filters on installed runtime | На установленном runtime пройти S7, S8 8/8, strict modes 7/8 с непустыми строками | S8 JSON, exported XLSX evidence, strict fixture manifest | OPEN |
| P0-03 | Full user-facing property import/save/reload scenario | UI-сценарий: import из файла, папки, открытых компонентов; save all/changed; reload CAD; read-back свойств | UIA/COM evidence, before/after property dump, read-back JSON | OPEN |
| P0-04 | Licensing lifecycle | no-license, activation, revoke/delete, repeat check на боевом сервере | server audit rows, client logs, redacted license evidence | OPEN |
| P0-05 | Full visual L-01..L-15 strict PASS | Все surfaces L-01..L-15 captured, forbidden text/Han gates PASS, owner visual review | cumulative visual manifest, screenshots/contact sheet, owner notes | OPEN |
| P0-06 | Authenticode signing | Подписаны `SWTools.exe`, `SWTools.dll`, installer; `-AllowUnsigned` не используется как production approval | Authenticode JSON, signature details, certificate metadata | OPEN |
| P0-07 | Accepted hash promotion | Зафиксировать final hashes только после P0-01..P0-06 PASS | updated accepted hashes, provenance, audit approval | OPEN |
| P0-08 | Final release dossier | Свести package, signing, live E2E, visual, licensing, hashes, risks | final release dossier PR | OPEN |
| P0-09 | Explicit owner GO | Явное решение владельца после аудита dossier | owner GO comment/record | OPEN |

## Recommended PR order

1. `release/build-hygiene`: guard rails only, no product behavior.
2. `release/exact-head-live-e2e`: P0-01 + P0-02, no signing/hash promotion.
3. `release/property-save-reload-e2e`: P0-03 only.
4. `release/licensing-lifecycle-e2e`: P0-04 only.
5. `release/visual-full-profile`: P0-05 only.
6. `release/signing-evidence`: P0-06 only.
7. `release/final-dossier`: P0-07 + P0-08, after prior PASS.
8. Owner decision: P0-09.

Production GO remains NO-GO until every P0 is PASS and owner GO is explicit.
