# BinderInject — version-tolerant BinaryFormatter binder for ZTool.exe

Makes `ZTool.exe`'s legacy `BinaryFormatter` deserialization survive a runtime /
framework-version change, without changing the stored data format.

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

## How it works

- `donor/Donor.csproj` (net48) compiles `VTBinder.cs` to `ZBinderDonor.dll`. It
  **must** target net48 so the binder's type references resolve to `mscorlib`,
  matching the target exe.
- `BinderInject` (dnlib) copies the compiled `VTBinder` type into `ZTool.exe`
  (cloning its method bodies, importing all framework refs) and inserts the three
  IL instructions that wire the binder into the two deserialization helpers.

## Usage

```
binderinject patch  <target ZTool.exe> <donor ZBinderDonor.dll> <out ZTool.exe>
binderinject verify <ZTool.exe>
```

Wired into `client-core/build.ps1` as step [5/6]; runs automatically on a full
rebuild.

## Verification done

- `binderinject verify` — VTBinder present, `BindToType` override, 1 wire site in
  each of the two methods. **PASS**
- Decompile round-trip — both methods show `formatter.Binder = new VTBinder();`
  before `Deserialize`; `VTBinder` decompiles to the intended C#.
- Behavioural probe under .NET Framework 4.8 — `BindToType` with deliberately
  **wrong** `Version=2.0.0.0` / bogus `PublicKeyToken` resolves `System.Drawing.Font`
  and `System.Data.DataTable` to the actually-loaded 4.0.0.0 assemblies. **PASS**
- End-to-end round-trip through the patched `code.DeserializeBinary` /
  `code.DeserializeObject` for Font, Color and DataTable. **PASS** (no regression)

Artifact: `client-core/dist/ZTool_binderfix.exe`
SHA256 `d5cac49dc0a6a8d918da63d310db1a21e80572e6fae4219d6f37abb26f5614db`
(base `ZTool.exe` = `d41639a3…2a4833`).
