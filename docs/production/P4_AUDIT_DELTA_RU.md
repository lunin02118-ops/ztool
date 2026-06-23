# P4 Deep Audit delta

Дата: 2026-06-23
База: `main` после merge #68, #69, #70 и #71.

## Цель документа

Зафиксировать изменение P4-плана после Deep Audit и текущего состояния стека
production-hardening. Этот документ не меняет application source/runtime behavior
и не содержит private legal evidence.

## Deep Audit delta

| Область | До корректировки | После корректировки |
|---|---|---|
| Legal/IP | Блокер формулировался как необходимость получить approval внутри процесса репозитория. | Права подтверждаются вне Git; в репозитории хранится только redacted attestation. |
| Evidence custody | Не было жёстко отделено от Git. | Legal docs, contracts, scans, emails, commercial terms, private approvals, keys и endpoint secrets запрещены к коммиту. |
| Release signing | `-AllowUnsigned` мог выглядеть как допустимый режим проверки. | `-AllowUnsigned` явно только CI evidence mode; production GO требует Valid signatures или formal exception. |
| Repo hygiene | Локальные релизы/evidence/secrets были отдельным operational риском. | Добавлен Sprint L: repo hygiene and artifact custody. |
| BinaryFormatter | Legacy десериализация была скрытым техническим риском. | Добавлен Sprint M: BinaryFormatter containment. |
| Localization | Whitelist/gate не закрывали architecture debt между source/runtime/help/installer/add-in. | Sprint H расширен до localization architecture debt. |
| Final dossier | Release dossier был общим финальным шагом. | Добавлен Sprint N: final signing/release dossier. |

## Что уже закрыто #68/#69/#70/#71

| PR | Закрытая часть P4 |
|---|---|
| #68 | License-server hardening layer: abuse/rate-limit, prod config, protocol hardening, journal/security events. |
| #69 | Release-hardening layer: installer/package gates, signing evidence mode, binary provenance, forbidden files, SBOM/license evidence. |
| #70 | Source-build governance: source warning baseline, source-native migration transparency, build evidence. |
| #71 | Warning baseline strengthened to exact warning identities, so file/line/code drift is caught instead of only warning-count drift. |

## Remaining sprints

| Sprint | Цель | Почему остался |
|---|---|---|
| H | Localization architecture debt + visual localization report. | Нужно отделить user-facing Han от internal/source/runtime/help debt и подтвердить визуально. |
| L | Repo hygiene and artifact custody. | Нужно доказать чистоту tracked files, `_local_artifacts`, release/evidence/secrets policy и отсутствие приватных материалов. |
| M | BinaryFormatter containment. | Нужно инвентаризировать call sites, data sources и allowed-type policy без слома совместимости. |
| N | Final signing and release dossier. | Нужно финально подписать/зафиксировать исключения, собрать hashes/SBOM/evidence и принять GO/NO-GO. |

## Updated PR order

```text
#71: Warning identity baseline follow-up — merged
#72: Deep Audit delta and P4 plan correction
#73: Sprint H localization architecture debt + visual localization report
#74: Sprint L repo hygiene + Sprint M BinaryFormatter containment
#75: Sprint N signing/release dossier and final GO/NO-GO
```

## Acceptance mapping

```text
[x] План учитывает Deep Audit.
[x] Legal/IP отражён как externally resolved, not published in Git.
[x] No confidential legal evidence committed.
[x] Remaining technical P4 blockers preserved.
[x] Future work order updated: #71 -> #72 -> #73 -> #74 -> #75.
```
