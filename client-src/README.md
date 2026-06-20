# ZTool client — full editable source (`client-src`)

This is the **complete client compiled from source** — forms, BOM logic,
SolidWorks interop, licensing — not the IL-reinjection pipeline in
[`../client-core`](../client-core). It is a faithful, editable C# reconstruction
of the vendor client that builds to a working `ZTool.exe` with **0 errors**.

```powershell
./build.ps1                       # -> bin/Release/net48/ZTool.exe
# or
dotnet build ZTool.csproj -c Release
```

## How this tree was produced (reproducible)

The original client is a **VB.NET** WinForms application. It was decompiled to a
compilable C# project with [ILSpy](https://github.com/icsharpcode/ILSpy)
(`ilspycmd` 10.x):

```powershell
ilspycmd -p -o <out> -ds AnonymousMethods=false <ZTool-base.exe>
```

The `-ds AnonymousMethods=false` flag is **essential**: it tells the decompiler
not to lift the VB compiler-generated closure classes (`_Closure$__NN`) back into
C# lambdas. The lifting transform mis-resolves nested VB closures and emits ~130
uncompilable references (`_Closure_0024__16 does not exist in
_Closure_0024__15`, `_Lambda_0024__NN` not found, …). With the flag off, the raw
closure classes are emitted verbatim and compile cleanly.

## Mechanical fixes applied to the raw decompiler output

All of these are standard VB→C# decompilation artifacts; none change behaviour.

| Fix | Why |
|-----|-----|
| `TargetFramework` `net40` → `net48` | runtime requires .NET Framework 4.8; `net40` is too old for `System.Resources.Extensions` |
| `LangVersion` `15.0` → `latest` | `15.0` is not a valid C# language version |
| add `System.Resources.Extensions` + `GenerateResourceUsePreserializedResources` | binary (non-string) `.resx` resources require it under the modern SDK |
| `code`, `mynpoi`, `ControlExtensions`, `TextBoxWaterMark`: `sealed class` → `static class` | they are VB `[StandardModule]` modules; extension methods must live in a static class (CS1106) |
| `DeleteInvalidChars` / `InsertRows`: drop `this` from the `ref` parameter | VB `ByRef` on a reference type decompiles to an illegal `ref this` extension (CS8337); callers already use plain `Class.Method(ref …)` syntax |
| `FrmAbout`: `sealed` → unsealed | VB `WithEvents` designer fields decompile to `virtual` properties, illegal in a sealed type (CS0549) |
| 7 `private virtual` WithEvents properties → `private` | `virtual` members cannot be `private` (CS0621) |
| `catch (object x) when (x is Exception …)` → `catch (Exception x) …` | VB `On Error` decompiles to a non-`Exception` catch, illegal in C# (CS0155) |
| `CConfigDO.CConfigDO()` method → `InitDefaults()` (+ caller in `CConfigMng`) | a method may not share its enclosing type's name (CS0542) |
| delete dead `ZTool.My/InternalXmlHelper.cs` | duplicate `AttributeValue` member (CS0102); the VB XML-literal helper is unused |
| add `NPOI.OpenXml4Net` / `NPOI.OpenXmlFormats` and `ZTool_rsa` references | transitively required types / dongle assembly (CS0012, CS0246) |

## Runtime notes

- External runtime DLLs (`NPOI*`, `itextsharp`, `Ribbon`, `ExpandableGridView`,
  …) live at the repo root and are referenced by `HintPath`. `ZTool_rsa.dll`
  comes from `../client-core/ref`. `ExpandableGridView`, `SharpZipLib`,
  `ZTool_rsa`, `zxing`, `Ribbon` are also embedded as manifest resources and
  resolved at runtime via `AppDomain.AssemblyResolve`.
- The dongle P/Invoke target `ZToolARM.dll` must be present next to the exe to
  get past `SR.Isme`.
- `Main` only shows UI when the vendor hardware-license check `SR.Isme` passes;
  with no license it exits cleanly (genuine vendor behaviour). The trial /
  registration flow and the SWTools rebrand currently live in the
  `client-core` reinjection layer; migrating them to this source tree is the
  next phase.

## Status / scope

- ✅ Phase 1: compiles from source with 0 errors; launches and runs the real
  vendor startup path without crashing.
- ▢ Phase 2: full runtime verification (trial UI, About, license server, core
  functions) once the licensing layer is wired in here.
- ▢ Phase 3: move the SWTools rebrand + window redesigns from IL patches in
  `client-core` into this source tree, and switch the build/installer over.

Warnings (~120) are benign decompiler artifacts (unreachable code after
`goto`/`return`, unused locals).
