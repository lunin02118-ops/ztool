# ZTool — decompiled C# (RE reference)

Read-only reverse-engineering reference. **Not a buildable project, not for
redistribution.** These sources are produced by decompiling the binaries that
are already committed in this repository, to let us patch ZTool against the
*real* program logic (e.g. `Frmmain.AddRibbon`) instead of guessing from raw IL.

## Provenance

| Folder | Source binary | SHA256 (committed binary) |
|---|---|---|
| `ZTool.exe/` | `ZTool.exe` (client app — contains `Frmmain`, the ribbon) | `c7ab14910003d1f23e330b29d2e53f2b2bff8ada6bb29d27d80dc37786fcf37f` |
| `ZTool.dll/` | `ZTool.dll` (SolidWorks add-in — `ZTool.SwAddin`) | `d053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9` |
| `Ribbon.dll/` | `Ribbon.dll` (RibbonLib — Windows Ribbon Framework wrapper) | `57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e` |

- Decompiler: **ILSpy `ilspycmd` 10.1.0.8386** (`ICSharpCode.Decompiler 10.1.0.8386`).
- Command: `ilspycmd <assembly> -p -o <out> -r <repo-root>`.
- Generated: 2026-06-19.

## Scope / pruning

- Only `*.cs` is committed (no extracted resource `.dll`/`.png`/`.resx`/`.ribbon`,
  no generated `.csproj`).
- The auto-generated `SolidWorks.Interop.*` COM interop stubs are **excluded**
  (they are third-party SDK signatures, not ZTool code, and only add noise).
- Decompiled output is approximate: VB-style helpers (`Operators`, `Conversions`,
  `ProjectData`), `checked {}` blocks and compiler-generated names appear because
  the app is VB.NET + obfuscated. Treat it as a faithful map of the logic, not as
  the original source.

## Legal

ZTool is reverse-engineered under the signed RE authorization recorded in
`docs/legal/`. This decompiled reference is for our own maintenance/localization
work on the licensed copy only and must not be redistributed.

## Useful entry points

- `ZTool.exe/ZTool/Frmmain.cs` — main window + ribbon. `AddRibbon()` builds every
  ribbon control with its CommandID; `_cmdButtonHidecol` (cmd `1033`) is the
  show/hide-columns gallery (see `re/SHOW_HIDE_COLUMNS_STAYOPEN_RU.md`).
- `ZTool.dll/ZTool/SwAddin.cs` — SolidWorks add-in entry / CommandManager.
- `Ribbon.dll/RibbonLib.Controls/*` — the ribbon control wrappers
  (`RibbonDropDownGallery`, `RibbonCheckBox`, …).
