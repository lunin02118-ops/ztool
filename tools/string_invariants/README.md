# From-source string invariants (Этап C)

This is the **from-source reorientation of the legacy #29 string-invariants gate**.

## Why it changed

The legacy #29 gate read the ECMA-335 `#US` (user-string) heap of the *shipped binary*
and enforced two things on that binary: no untranslated/corrupted Han, and a fixed set
of vendor "required" Chinese keys must remain. That gate is tied to the **IL-reinjection
path** (`client-core` + `Localizer`), where the `#US` heap is exactly what the Localizer
rewrites.

The from-source path is different:

- The from-source `ZTool.exe` carries **no Chinese in its `#US` heap** — it has never gone
  through the Localizer; what the IL path injected/translated into `#US` we now author
  directly in source.
- Therefore the meaningful invariant for from-source is checked against the **source tree**
  (`client-src/**/*.cs`), not a compiled binary.

So this gate scans C# **string literals** (`"..."`). CJK *identifiers* (e.g. the Chinese
member names of the `Sendresult` enum in `TCPClient.cs`, or WinForms control `Name`s like
`列ToolStripMenuItem`) and CJK inside comments are intentionally **out of scope**: they are
internal, never surfaced as text (the licensing flow compares numeric codes and shows fully
Russian `MessageBox` text), and renaming them is cosmetic refactoring (Этап D).

## What it enforces

`check_source_string_invariants.py` over `client-src`:

1. **Allow-list** (`source_allowed_han.tsv`) — every distinct CJK-bearing string literal must
   be registered with a `role`. An unregistered CJK literal **fails** the gate. This is what
   catches an accidentally re-introduced visible-Chinese string (a localization regression).
2. **Required keys** (`source_required_keys.tsv`) — each vendor crypto passphrase must still
   be **present** in source. Dropping/translating one silently breaks the licensing handshake,
   so its removal **fails** the gate.

Entries whose `note` begins with `REVIEW` are **surfaced but not failed**: allowed for now,
flagged for human confirmation / planned replacement.

## Roles and the "Chinese stays vs. planned-replace" classification

| role | count | verdict |
|------|-------|---------|
| `crypto-passphrase` | 6 | **PERMANENT.** Vendor passphrases (`今天。。。`, `冰雨。。。`, `天意。。。`, `来生缘。。。`, `忘情水。。。`, `笨小孩。。。`) fed to `SR`/`code` crypto (`IsReg*/GetMNum/getver/HasShell/Isme/St2`). Changing the bytes breaks the RSA/handshake. Listed in `source_required_keys.tsv`. |
| `font` | 4 | Planned-replace. Font-family fragments (`微雅`/`华行`/`宋`/`楷`). Invisible as text; can be swapped to a Latin family in one pass. |
| `semantic-key` | 1 | Planned-replace **with the add-in (Этап D)**. `零` is the `Col_Extname.Tag` part-kind key for material/manual/random colour. We own producer+consumer, but the **add-in side still uses the same key**, so renaming must be done together to keep the contract — translating it half-way is exactly the regression that once broke colour logic. |
| `control-name` | 7 | Planned-replace (cosmetic). WinForms designer `Name`/`ApplyResources` keys; internal. |
| `help-path` | 3 | Review. CHM topic paths; must match the shipped help file. |
| `image-name` | 1 | Review. Embedded image resource name; internal. |
| `symbol-palette` | 2 | Review. Insertable special-character palette + a fullwidth-bracket parsing list; the CJK punctuation is intentionally offered to / matched for the user. |
| `format-fragment` | 7 | Review. Stray fullwidth punctuation inside format/regex strings (`；`, `）*`, `DPI：`, …). |
| `log-text` | 1 | Review. Residual Chinese fragment in an UnhandledException log line (low-visibility). |

The intent (per roadmap Этап C): **keep** the immutable crypto passphrases, **formalize** the
rest as "to be renamed to non-Chinese constants" without blocking the build today. As source
items are replaced, delete their allow-list rows; the gate then guarantees they don't creep
back.

## Run locally

```
python tools/check_source_string_invariants.py --self-test     # gate logic
python tools/check_source_string_invariants.py --root client-src
```

CI runs both in `.github/workflows/release-acceptance.yml`.
