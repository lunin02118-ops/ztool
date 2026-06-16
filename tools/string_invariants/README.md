# Internal-string invariants (Phase 11, recommendation #2)

Why this exists: the material/colour bug
(`docs/audit/refactor-production-readiness-gap-audit-2026-06-16_RU.md`) happened
because strings in the client binaries were classified **by language**, not **by
role**. The Chinese literal `零件` is a *semantic key* (`Col_Extname.Tag`,
compared at runtime in several `Frmmain` methods), yet localization treated it as
translatable UI text and replaced it with `Деталь`, breaking "random colour" and
manual painting. `localization_scan.py` flags unclassified Han but cannot tell a
visible label from a semantic key.

`tools/check_string_invariants.py` adds that missing distinction and enforces two
invariants against the actual shipped binaries (`ZTool.exe`, `ZTool.dll`):

1. **Allow-list.** Every Han string still present in a localized binary's `#US`
   heap (extracted by `tools/dotnet_strings.py`, a dependency-free ECMA-335
   parser) must be classified here with a role and note. A **new, unclassified**
   Han string fails the gate — that is a new untranslated UI string or corrupted
   localization slipping in.

2. **Required keys.** The semantic vendor keys the runtime compares against must
   still be present (byte-level UTF-16LE). Translating or dropping one of them is
   exactly the regression that broke colours.

## Files

- `allowed_han.tsv` — `string<TAB>role<TAB>note`. `\n` in the string column means
  a literal newline. A note starting with `REVIEW` keeps the gate green but
  reprints the entry in a REVIEW section for a human to confirm it is an internal
  key / font / path and not a missed translation.
  Roles: `control-name`, `font`, `placeholder-token`, `image-name`, `help-path`,
  `sample-text`, `visible-text`.
- `required_keys.tsv` — `binary<TAB>key<TAB>note`. Keys that MUST remain.

## Usage

```
python tools/check_string_invariants.py            # gate against repo binaries
python tools/check_string_invariants.py --self-test
```

Exit 0 = invariants hold (some REVIEW items may need human confirmation),
exit 1 = a violation (unclassified Han string, or a required key missing).

## Maintenance

When the localized binaries are rebuilt:

1. Run the gate. If it fails on an UNCLASSIFIED string, decide its role:
   - genuinely internal (control name / font / placeholder / image / path) →
     add it to `allowed_han.tsv` with the right role;
   - actually a visible label that should have been translated → it is a real
     localization bug: fix the translation, do **not** allow-list it.
2. If a required key goes MISSING, that is a regression — investigate before
   allow-listing anything.

The current build leaves 10 REVIEW items (3 help-topic paths, 6 vendor
sample/easter-egg strings, 1 untranslated tooltip in `ZTool.dll`). These are
candidates for a follow-up localization pass; they are surfaced, not hidden.
