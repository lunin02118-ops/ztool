# Production GO Criteria

Дата: 2026-06-30

Статус: **Production GO: NO-GO**

Этот документ определяет минимальные условия, без которых нельзя объявлять
production release SWTools.

## Обязательные условия GO

Production GO возможен только если все пункты ниже имеют PASS на exact final
head или на immutable release package, собранном из exact final head.

| ID | Gate | Минимальный PASS |
|----|------|------------------|
| G-01 | Required CI | Все required checks green. Красный required CI блокирует merge/release. |
| G-02 | Build/package identity | `VERSION`, package manifest, runtime title/version/path/hash согласованы. |
| G-03 | SolidWorks live E2E | S7 PASS, S8 8/8 PASS, strict filters PASS, semantic Excel PASS. |
| G-04 | Property import/save/reload | Import из файла/папки/открытых компонентов, save, reload, read-back PASS. |
| G-05 | Licensing lifecycle | No-license, activation, persistence, revoke/delete, repeat check PASS. |
| G-06 | Visual localization | L-01..L-15 strict PASS, no visible legacy brand/Han in SWTools-owned UI. |
| G-07 | Signing | Authenticode PASS без `-AllowUnsigned` для `SWTools.exe`, `SWTools.dll`, installer. |
| G-08 | Compliance | Secret scan, license policy, SBOM/provenance PASS. |
| G-09 | Accepted hashes | Hash promotion выполнен только после owner/auditor approval. |
| G-10 | Final dossier | Release dossier сводит exact evidence и остаточные риски. |
| G-11 | Owner GO | Явный owner GO зафиксирован после review dossier. |

## Что не считается GO

- Green static/preflight checks без live SolidWorks E2E.
- Visual profile/schema PASS без screenshots/contact sheet.
- Evidence со старого commit после нового runtime fix.
- CI evidence mode with `-AllowUnsigned`.
- Loose root binaries without exact package provenance.
- Accepted hashes без owner decision.

## Правило exact-head

Evidence привязано к commit/package identity. Если после evidence менялся runtime,
installer, build scripts, license flow, visual strings или acceptance scripts,
production evidence нужно переснять.

## Production status language

До выполнения всех критериев писать только:

- `Production GO: NO-GO`;
- `Visual FULL PASS: NO-GO`, если L-01..L-15 не закрыт;
- `Accepted hashes: pending owner decision`, если финальное решение не принято.
