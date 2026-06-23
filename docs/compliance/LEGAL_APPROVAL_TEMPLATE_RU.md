# Redacted Legal/IP attestation template

Этот шаблон предназначен только для фиксации redacted статуса в репозитории.
Он не является договором и не должен содержать исходные legal documents.

## Запрещено коммитить

- contracts, source legal documents, scans, emails;
- private approvals, signatures, commercial terms;
- customer/payment terms;
- license keys, private keys, endpoint secrets;
- production URLs/secrets, если они не являются публичной документацией.

## Объект attestation

- Продукт: SWTools/ZTool.
- Версия релиза: `1.1.6` или актуальная версия из `VERSION`.
- Артефакты: `SWTools.exe`, `SWTools.dll`, `SWTools-base.exe`,
  `help_ru.chm`, bundled DLL/runtime assets, release package, installer.

## Redacted attestation

| Field | Value |
|---|---|
| Status | `EXTERNALLY_CONFIRMED / NON_PUBLIC_EVIDENCE` |
| External evidence custody owner | `<role/name outside Git>` |
| Evidence storage location | `<private system / not Git>` |
| Confirmed scope: modification | `<yes/no/redacted note>` |
| Confirmed scope: rebrand | `<yes/no/redacted note>` |
| Confirmed scope: rekey/license-server migration | `<yes/no/redacted note>` |
| Confirmed scope: packaging/installer | `<yes/no/redacted note>` |
| Confirmed scope: distribution channel | `<approved scope, no commercial terms>` |
| Required notices/obligations | `<redacted summary or link to public notice file>` |
| Scope expiry / renewal trigger | `<date/event/redacted>` |
| Attestation maintainer | `<repo-side maintainer>` |
| Last confirmation date | `<YYYY-MM-DD>` |

## Минимальное требование для P4

P4 GO может ссылаться на redacted attestation, если:

1. статус в `docs/compliance/LEGAL_APPROVAL_STATUS_RU.md` подтверждён;
2. release scope не выходит за covered scope;
3. все notices/SBOM/license obligations закрыты в публичных repo-safe docs;
4. исходные legal evidence остаются вне Git.

Если любой пункт не выполняется, P4 GO блокируется до внешнего подтверждения
или корректировки scope.
