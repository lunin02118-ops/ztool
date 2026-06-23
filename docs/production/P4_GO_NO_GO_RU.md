# P4 GO/NO-GO

Дата: 2026-06-23

## Current decision

`NO-GO`

## Current state

Reviewed P4 hardening stack has been merged into `main`:

```text
#77 — Sprint H localization architecture debt — merged
#75 — Sprint L/M repo hygiene + BinaryFormatter containment — merged
#76 — Sprint N signing/release dossier policy — merged
```

Current implementation stack: `none`.

Current phase: `final release rehearsal / production evidence`.

## Why still NO-GO

P4 hardening policy/gate layer is now present on `main`, but production release
is not approved yet.

Blocking items:

- final release package and installer are not built from the reviewed final
  commit;
- final SHA256SUMS / manifest / SBOM / binary provenance are pending;
- Authenticode production verification without `-AllowUnsigned` is pending;
- SolidWorks S7/S8 and licensing L3-L5 live acceptance are pending;
- localization visual audit screenshots/help/installer evidence are pending;
- stale PR triage for #61/#64/#65 is pending or must be explicitly deferred;
- final owner approval for production GO has not been recorded.

## GO requirements

```text
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
[ ] Owner explicitly approves production GO.
```

## Merge rule

Future release-evidence PRs may be merged only after explicit user audit and
approval. Documentation policy/gate merge does not imply production GO.
