# P4 status update after stack merge

Дата: 2026-06-23

Этот документ фиксирует, что после merge #77/#75/#76 нужно обновить статусные документы. Он дополняет `P4_POST_MERGE_AUDIT_2026-06-23_RU.md` и `P4_NEXT_EXECUTOR_INSTRUCTIONS_RU.md`.

## Required document updates

Update `docs/production/P4_GO_NO_GO_RU.md`:

```text
Current decision: NO-GO.
Current stack: none; #77/#75/#76 are merged.
Current phase: final release rehearsal / production evidence.
Blocking items:
- final release package and installer are not built from the reviewed final commit;
- final hashes/SBOM/binary provenance are pending;
- Authenticode production verification without -AllowUnsigned is pending;
- SolidWorks S7/S8 and licensing L3-L5 live acceptance are pending;
- localization visual audit is pending;
- stale PR triage (#61/#64/#65) is pending or must be explicitly deferred.
```

Update `docs/release/RELEASE_DOSSIER_1.1.6_RU.md`:

```text
#72, #77, #75, #76: merged.
Current implementation stack: none.
Current decision: DRAFT / NO-GO.
Next phase: final release rehearsal.
```

Do not mark GO until final package/signing/SolidWorks/licensing/localization evidence exists and owner explicitly approves production release.
