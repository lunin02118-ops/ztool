# BinderInject — BinaryFormatter binders for ZTool.exe

Injects two `SerializationBinder`s into `ZTool.exe` in one pass:

1. **`VTBinder`** (version-tolerant) — makes the legacy config `BinaryFormatter`
   deserialization survive a runtime / framework-version change, without changing
   the stored data format.
2. **`SafeListBinder`** (allow-list) — hardens the clipboard copy/paste path so a
   poisoned clipboard can't turn paste into a deserialization-gadget RCE.

## Problem

`BinaryFormatter` writes the **full assembly identity** of every serialized type
into the stream — `Name, Version, Culture, PublicKeyToken`. A blob written under
one runtime fails to bind under another (e.g. SolidWorks 2025 pulls different
framework assembly versions): the embedded identity no longer matches a loadable
assembly, so `Deserialize` throws `SerializationException` / `TypeLoadException`.

Affected stored config (all read through `ZTool.code`):

| call | type | config field |
|------|------|--------------|
| `code.DeserializeBinary` | `System.Drawing.Font`  | `CConfigMng.Config.tfont` |
| `code.DeserializeBinary` | `System.Drawing.Color` | `CConfigMng.Config.tcolor` |
| `code.DeserializeObject` | `System.Data.DataTable` | `CConfigMng.Config.relatedfilldata` |

## Fix

Inject `ZTool.VTBinder : SerializationBinder` (compiled from `donor/VTBinder.cs`,
not hand-written IL) and set it as the formatter's `Binder` at the top of
`code.DeserializeBinary` and `code.DeserializeObject`:

```csharp
var bf = new BinaryFormatter();
bf.Binder = new VTBinder();   // <-- inserted
... bf.Deserialize(stream);
```

`VTBinder.BindToType` resolves a type by its **short assembly name** against the
assemblies actually loaded in the AppDomain, ignoring Version / Culture /
PublicKeyToken. On a miss it returns `null`, so the formatter falls back to its
default binding — i.e. never worse than before.

## Clipboard hardening (`SafeListBinder`)

`pasteitem_Click` (in `FrmOutputlist`, `FrmPrintlist`, `FrmSetDrwlist`,
`FrmSyncDrwName`) `BinaryFormatter`-deserializes data straight off the clipboard
(the private "audio stream" channel) and casts it to `List<string>`. The
clipboard is a shared, attacker-writable surface, so without a type guard a
poisoned payload would let `BinaryFormatter` instantiate arbitrary gadget types
(classic deserialization RCE on paste).

`SafeListBinder` (compiled from `donor/SafeListBinder.cs`) is wired the same way
(`bf.Binder = new SafeListBinder();` before `Deserialize`) at all four paste
sites. It permits **only** the types that make up a `List<string>` graph
(`System.Collections.Generic.List``1[[System.String,…]]`, `System.String`,
`System.String[]`) and **throws** on anything else. It must throw rather than
return `null`: a `null` return makes `BinaryFormatter` fall back to its default
assembly-qualified binding, which would resolve the very type we mean to block.
For allowed types it binds version-tolerantly (short assembly name), like
`VTBinder`. Normal copy/paste is unaffected because the only writer of that
clipboard channel is ZTool's own `copyitem_Click` (a `List<string>`).

## How it works

- `donor/Donor.csproj` (net48) compiles `VTBinder.cs` + `SafeListBinder.cs` to
  `ZBinderDonor.dll`. It **must** target net48 so the binder type references
  resolve to `mscorlib`, matching the target exe.
- `BinderInject` (dnlib) copies the compiled `VTBinder` and `SafeListBinder`
  types into `ZTool.exe` (cloning their method bodies, importing all framework
  refs) and inserts the three IL instructions that wire each binder into its
  target sites — `VTBinder` into the two config deserialization helpers,
  `SafeListBinder` into the four `pasteitem_Click` handlers.
- The output is written with `MetadataFlags.PreserveAll`. `ZTool.exe` is
  obfuscated and its code depends on metadata token / heap-offset identity. The
  default dnlib writer recompacts metadata and reassigns tokens, which silently
  broke an obfuscation-dependent path at runtime (BOM "сводная спецификация
  деталей" export crashed with a native fail-fast `0xc0000409` while most of the
  app still worked). Preserving all tokens/offsets and only appending the new
  binder rows keeps every existing path byte-identical.

## Usage

```
binderinject patch  <target ZTool.exe> <donor ZBinderDonor.dll> <out ZTool.exe>
binderinject verify <ZTool.exe>
```

Wired into `client-core/build.ps1` as step [5/6]; runs automatically on a full
rebuild.

## Verification done

- `binderinject verify` — VTBinder present + `BindToType` override + 1 wire site
  in each config helper; SafeListBinder present + `BindToType` override + 4
  `pasteitem_Click` wire sites. **PASS**
- Decompile round-trip — config helpers show `formatter.Binder = new VTBinder();`
  and all four `pasteitem_Click` show `binaryFormatter.Binder = new SafeListBinder();`
  before `Deserialize`; both binders decompile to the intended C#.
- Behavioural probe under .NET Framework 4.8 (VTBinder) — `BindToType` with
  deliberately **wrong** `Version=2.0.0.0` / bogus `PublicKeyToken` resolves
  `System.Drawing.Font` and `System.Data.DataTable` to the actually-loaded
  4.0.0.0 assemblies. **PASS**
- Behavioural probe under .NET Framework 4.8 (SafeListBinder) — an allowed
  `List<string>` round-trips; disallowed `System.Data.DataTable` and
  `System.Collections.Hashtable` payloads are **rejected** with
  `SerializationException` (never materialized). **PASS**
- Behavioural probe against the **patched exe itself** — `ZTool.SafeListBinder`
  is loaded out of `ZTool_binderfix.exe`, instantiated, and its
  `BindToType`→`IsAllowed` path exercised: allowed round-trip passes, gadget
  payload rejected. This is the exact path that previously threw
  `0x80131044`. **PASS**
- No `ZBinderDonor` assembly reference / string remains in the patched exe. **PASS**
- End-to-end round-trip through the patched `code.DeserializeBinary` /
  `code.DeserializeObject` for Font, Color and DataTable. **PASS** (no regression)

Artifact: `client-core/dist/ZTool_binderfix.exe`
SHA256 `7688ea399f3ea38672966043edbe5f3f0102048369706882f4a35eb009a5d8fd`
(base `ZTool.exe` = `d41639a3…2a4833`).

> The transplant must remap a binder's intra-type method calls (e.g.
> `SafeListBinder.BindToType` → `IsAllowed`) and self type-references onto the
> **injected** TypeDef. An earlier build left those pointing at the donor, so
> paste threw `Could not load file or assembly 'ZBinderDonor' … 0x80131044`.
> `CopyType` now clones method stubs first, then bodies with a `MethodDef` map.
>
> Earlier artifacts superseded by the hash above:
> `d5cac49d…5614db` (no `PreserveAll`, crashed BOM parts-summary export with
> `0xc0000409`), `7488a71f…b82e7f3` (VTBinder only), and
> `4d8aa7ea…a848cf56` (clipboard binder, but its `IsAllowed` call still bound to
> the donor assembly → paste failed with `0x80131044`).
