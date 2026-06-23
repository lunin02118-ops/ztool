# P4 GO/NO-GO

Дата: 2026-06-23

## Current decision

`NO-GO`

## Why

P4 hardening work is progressing as a reviewed stack, but final production
release is not approved yet.

Blocking items:

- user audit required before merging #77/#75/#76;
- localization visual audit is pending;
- final release package and installer are not built from the reviewed final
  commit;
- Authenticode production verification without `-AllowUnsigned` is pending;
- SolidWorks S7/S8 and licensing L3-L5 live acceptance are pending;
- final release hashes/SBOM/binary provenance are pending.

## GO requirements

```text
[ ] Reviewed stack merged in order after user audit.
[ ] Final package built from exact merged commit.
[ ] SHA256SUMS and manifest generated.
[ ] SBOM/license notices generated and accepted.
[ ] Binary provenance verified against generated artifact.
[ ] Authenticode Valid or formal release exception recorded.
[ ] No production reliance on `-AllowUnsigned`.
[ ] Clean install smoke PASS.
[ ] SolidWorks S7/S8 PASS.
[ ] Licensing L3-L5 PASS.
[ ] Localization visual audit PASS.
[ ] Risk register has no open P0/P1 without mitigation/exception.
```

## Merge rule

No PR in the current P4 stack may be merged without explicit user audit and
approval.
