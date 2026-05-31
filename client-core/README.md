# ZTool licensing core — editable C# source + reinjection

This directory lets us **edit the ZTool licensing logic as normal C# source**, compile it,
and inject the recompiled method bodies back into the real `ZTool.exe` — instead of hand-patching
IL every time.

Only the licensing **core** is in source. The GUI, forms, resources and everything we do *not*
touch stay untouched inside the original `ZTool.exe`. We transplant just the bodies of the methods
we own; the exe stays byte-identical everywhere else.

## What is in source

`src/` contains the four classes that drive activation / hardware binding / transport:

| file | type | role |
|------|------|------|
| `src/SR.cs`                     | `ZTool.SR`                     | hardware fingerprint (`GetMNum`, disk/board/UUID), registry read/write, `IsReg1`/`IsReg2` license-blob validation |
| `src/SecurityCenter.cs`         | `ZTool.SecurityCenter`         | AES/DES helpers used by the blob format |
| `src/TCPClient.cs`              | `ZTool.TCPClient`              | server connection (`185.112.102.122:58000`), request/response handling, result-code dispatch |
| `src/GetRegistrycreatedtime.cs` | `ZTool.GetRegistrycreatedtime` | reads the registry-key creation time used as the `GD51` key seed |

Everything these classes reference but that we do **not** edit (`code`, `RSAHelper`, `CConfigMng`,
the WinForms, embedded resources, `ZTool_rsa`, …) is resolved against the original assembly, so we
never have to reconstruct it.

## How it works (3 pieces)

```
                 tools/Publicizer                 ZTool.Core.csproj                tools/Reinjector
 ZTool.exe  ───────────────────────►  ref/ZTool.public.dll  ──►  ZTool.Core.dll  ─────────────────────►  out/ZTool.exe
 (original)   promote all members              (compile-time              (our recompiled        transplant our method
              to public                         reference only)            method bodies)         bodies into a fresh
                                                                                                  copy of the original
```

1. **Publicizer** (`tools/Publicizer`, dnlib) — opens `ZTool.exe` and flips every type/member to
   `public`, writing `ref/ZTool.public.dll`. This is a **compile-time reference only** so our source
   can call originally-private members. It never ships.
2. **`ZTool.Core.csproj`** — compiles `src/*.cs` into `ZTool.Core.dll` against `ref/ZTool.public.dll`
   (assembly name `ZTool`, so our types line up 1:1 with the originals) plus `ref/ZTool_rsa.dll`.
   `CS0436` (our types intentionally duplicate the referenced ones) is silenced — source wins.
3. **Reinjector** (`tools/Reinjector`, dnlib) — for each method we own, clones the compiled IL body
   out of `ZTool.Core.dll` and writes it over the matching method in a fresh copy of `ZTool.exe`.
   References in the cloned bodies are remapped back onto the target exe's own types/members.

### The one subtlety the Reinjector handles

A call from our recompiled code to another ZTool type (e.g. `HardDisk.GetSerialNo`) is, inside
`ZTool.Core.dll`, a `MemberRef` into the external `ref` assembly. If you let a generic importer copy
it as-is it becomes a `MemberRef` whose parent is a **same-module `TypeDef`** in the target exe — and
the CLR JIT rejects that with `BadImageFormatException (0x8007000B)` the moment the method runs.

The Reinjector resolves every method/field operand whose declaring type is defined in the target exe
**directly to that type's own `MethodDef`/`FieldDef`**, producing a same-module def token — exactly
what the original compiler emitted. (See `RedirectMapper.ResolveMethodOperand` / `ResolveFieldOperand`
in `tools/Reinjector/Program.cs`.) Type operands and external refs (mscorlib, `System.Management`,
`Microsoft.VisualBasic`, `ZTool_rsa`, …) are imported normally.

## Prerequisites

- **.NET SDK** (for `dotnet build`/`dotnet run`; the two tools target a current SDK, the core targets `net48`).
- **.NET Framework 4.8** to *run* the resulting `ZTool.exe` (the `net48` targeting pack is pulled in at
  build time via the `Microsoft.NETFramework.ReferenceAssemblies` package).
- The committed `ref/ZTool.public.dll` and `ref/ZTool_rsa.dll` are derived from the in-repo `ZTool.exe`
  (publicized copy / extracted embedded resource) — present so the project builds out of the box.

## Build

From this directory:

```powershell
./build.ps1                 # compile core + reinject -> out/ZTool.exe
./build.ps1 -Publicize      # also regenerate ref/ZTool.public.dll from ../ZTool.exe first
./build.ps1 -BaseExe 'C:\path\ZTool.exe' -OutExe 'C:\path\out\ZTool.exe'
```

The script runs all four steps and finishes with a verification that the output exe has
**0 dangling references** into `ZTool.public` / `ZTool.Core`.

To run it: copy `out/ZTool.exe` over the `ZTool.exe` in a full runtime folder (the one that already
has `ZTool.dll`, `NPOI*.dll`, etc.) and launch it. SolidWorks is **not** needed for activation.

## Edit → compile → reinject round-trip

1. Edit a method in `src/*.cs`.
2. `./build.ps1`.
3. Run `out/ZTool.exe`.

This was verified end to end: changing the result-code-6 message in `TCPClient.SocketRecive`
(`"Ошибка в сведениях о регистрации"` → `… [from-source v1.0]"`), rebuilding and reinjecting produced
an exe that contains the new string (the base exe does not) and still launches normally. The marker
edit was reverted before commit.

## Manual tool invocation (what build.ps1 wraps)

```powershell
# 1. publicize (only when ZTool.exe changes)
dotnet run -c Release --project tools/Publicizer -- ..\ZTool.exe ref\ZTool.public.dll

# 2. compile the core
dotnet build -c Release ZTool.Core.csproj

# 3. reinject (default types: SR,SecurityCenter,TCPClient,GetRegistrycreatedtime)
dotnet run -c Release --project tools/Reinjector -- \
    ..\ZTool.exe bin\Release\net48\ZTool.Core.dll out\ZTool.exe

# verify / inspect
dotnet run -c Release --project tools/Reinjector -- --verify out\ZTool.exe
dotnet run -c Release --project tools/Reinjector -- --list   ..\ZTool.exe bin\Release\net48\ZTool.Core.dll out\ZTool.exe
dotnet run -c Release --project tools/Reinjector -- --dumpil bin\Release\net48\ZTool.Core.dll SR GetMNum
```

Reinjector flags: `--types A,B,C` (limit types), `--methods m1,m2` (limit methods),
`--exclude m1,m2`, `--list` (list candidate methods, no write), `--verify <exe>`,
`--dumpil <asm> <Type> <Method>`, `--rawhex <asm> <Type> <Method>`.

## Scope / limitations

- **GUI stays in the binary.** Only the four licensing classes are source-editable; forms and
  resources are left untouched in the exe.
- The exe reports version **1.0** and talks to **185.112.102.122:58000** with our server key
  (these come from the already-rekeyed base `ZTool.exe`).
- Activation binds **one key to one machine**; moving a key needs the in-client "перенос лицензии".
- A cloud VM with a zeroed hardware UUID will show *"это устройство не соответствует условиям
  регистрации"* — that is the genuine hardware-binding check, not a build problem.
