# Legal/IP approval status

Дата: 2026-06-23

## Статус

`EXTERNALLY_CONFIRMED / NON_PUBLIC_EVIDENCE`

Права и разрешения по SWTools/ZTool подтверждены вне репозитория. В Git хранится
только redacted attestation: статус, scope, custody model и blocker policy. Сами
исходные legal documents, contracts, scans, emails, commercial terms, private
approvals, license keys и endpoint secrets **не коммитятся**.

## Covered scope

Внешнее подтверждение покрывает текущий P4 scope:

- modification recovered/decompiled/source runtime;
- rebrand `ZTool` -> `SWTools`;
- rekey and license-server migration;
- packaging into release package / NSIS installer;
- distribution of the packaged SWTools runtime in the approved release channel.

## Evidence custody

| Item | Policy |
|---|---|
| Source legal evidence | Stored outside Git in approved private custody. |
| Repository evidence | Redacted attestation only. |
| Public repo contents | No contracts, scans, private emails, signatures, commercial terms, license keys or endpoint secrets. |
| Audit request | Refer to external custody owner; do not upload originals to GitHub. |

## P4 impact

Legal/IP is no longer an automatic P4 blocker while the external approval can be
confirmed and the release stays inside the covered scope above.

Blocker conditions:

1. external approval cannot be confirmed by the responsible owner;
2. release scope exceeds the covered scope;
3. repository receives non-redacted legal/private evidence;
4. third-party dependency obligations require notices/remediation not present in
   the release package.

## Known high-risk items

| Item | Status | Required action |
|---|---|---|
| SWTools/ZTool runtime | Externally confirmed for current scope | Keep redacted attestation only; re-confirm if scope changes. |
| `ZTool_rsa.dll` / rekey lineage | Covered by current migration/rekey scope | Keep provenance/hash evidence; no private key material in Git. |
| `itextsharp.dll` | Compliance reviewed via inventory/policy gate | Keep notices/exception evidence redacted; replace or re-confirm if license posture changes. |
| `Ribbon.dll`, `ExpandableGridView.dll` | Covered by binary provenance + inventory process | Keep origin/license notes current. |

## Distribution scope

Distribution is permitted only within the externally confirmed scope. Public,
marketplace, OEM, reseller or substantially different commercial distribution
requires a new external confirmation before release GO.
