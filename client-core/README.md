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
./build.ps1 -Publicize      # also regenerate ref/ZTool.public.dll from ../ZTool.base.exe first
./build.ps1 -BaseExe 'C:\path\ZTool.base.exe' -OutExe 'C:\path\out\ZTool.exe'
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
dotnet run -c Release --project tools/Publicizer -- ..\ZTool.base.exe ref\ZTool.public.dll

# 2. compile the core
dotnet build -c Release ZTool.Core.csproj

# 3. reinject (default types: SR,SecurityCenter,TCPClient,GetRegistrycreatedtime)
dotnet run -c Release --project tools/Reinjector -- \
    ..\ZTool.base.exe bin\Release\net48\ZTool.Core.dll out\ZTool.exe

# verify / inspect
dotnet run -c Release --project tools/Reinjector -- --verify out\ZTool.exe
dotnet run -c Release --project tools/Reinjector -- --list   ..\ZTool.base.exe bin\Release\net48\ZTool.Core.dll out\ZTool.exe
dotnet run -c Release --project tools/Reinjector -- --dumpil bin\Release\net48\ZTool.Core.dll SR GetMNum
```

Reinjector flags: `--types A,B,C` (limit types), `--methods m1,m2` (limit methods),
`--exclude m1,m2`, `--list` (list candidate methods, no write), `--verify <exe>`,
`--dumpil <asm> <Type> <Method>`, `--rawhex <asm> <Type> <Method>`.

## Default runtime profile (`dist/ZTool.settings`) — SolidWorks version targeting

The client picks which SolidWorks it connects to from `<SWver>` in `ZTool.settings`. The
standalone licensing UI does **not** need SolidWorks, but the "Проба"/connect path builds a COM
ProgID from this value, so a wrong default makes the client report
*"Указана неверная версия SolidWorks, задайте её заново"* on a machine whose SolidWorks does not
match.

Mapping (from `FrmOptions` + `RunSW` in the exe — `num = 19 + SWver`, ProgID
`SldWorks.Application.<num>`):

| `<SWver>` | dropdown label | ProgID | SolidWorks |
|-----------|----------------|--------|------------|
| `0`  | «Настройки по умолчанию» | `SldWorks.Application` (version-independent) | **whatever is installed (latest)** |
| `12` | 2023 | `SldWorks.Application.31` | SW 2023 |
| `13` | 2024 | `SldWorks.Application.32` | SW 2024 |
| `14` | 2025 | `SldWorks.Application.33` | SW 2025 |

**Ship `dist/ZTool.settings` (which carries `<SWver>0</SWver>`) in the runtime folder / demo zip.**
`SWver=0` uses the version-independent `SldWorks.Application` ProgID, so the client connects to
whatever SolidWorks is installed — it works out of the box on SW 2025 **and** on any other version,
which is what a redistributable demo needs. (The old vendor profile shipped `SWver=12` = SW 2023,
hence the connection error on SW 2025. Pinning a single year — e.g. `14` for SW 2025 — also works
but breaks on machines running a different release, so `0` is preferred for distribution.)

## Profile completeness (`dist/ZTool.settings`) — property saving

`ZTool.CConfigDO` is XML-serialized, and a profile that **omits** a `List<>` member deserializes
that member as an **empty** list. For the Save-options dialog (`FrmSaveOption`) that means it falls
back to its WinForms *designer* defaults — and the designer default `CheckBox6 = True`
(= `code.Updatereferencebool`) makes the dialog auto-fill its "reference update" folder (`TextBox1`)
from the **currently opened model's directory** and then persist that absolute path on save. On a
machine that opened a model under e.g. `D:\…\测试模型`, that stale path is what later drove the
*"Сохранить в папку"* column, so re-saving went to a foreign/non-existent directory instead of the
user's chosen one.

The shipped profile therefore declares **all five** sections explicitly so the distribution never
depends on volatile designer defaults:

| section | shipped value | why |
|---------|---------------|-----|
| `savetoswcfg`    | vendor designer defaults **except** `CheckBox6=False` and `TextBox1` empty | ref-update off + no stale/foreign save path |
| `Dropdownlist`   | empty | a fresh install carries no foreign dropdown data |
| `namemappinglist`| empty | no foreign column→property mappings |
| `fillsettings`   | empty | no foreign auto-fill rules |
| `fillcolumncfg`  | empty | drops the vendor `datasource` xls path |

Regenerate reproducibly (idempotent) with `tools/gen_dist_profile.ps1`, which serializes via the
intact (non-publicized) `CConfigDO` type — the publicized DLL must not be used, as its public
backing fields (`_SWver`, …) would duplicate every element.

## Scope / limitations

- **GUI stays in the binary.** Only the four licensing classes are source-editable; forms and
  resources are left untouched in the exe.
- The exe reports version **1.0** and talks to **185.112.102.122:58000** with our server key
  (these come from the already-rekeyed base `ZTool.base.exe`).

### Base vs. deliverable (repo layout)

To keep the distribution unambiguous for audits, the build **input** and the build **output**
are separate files at the repo root:

| file | what it is | version / signing |
|------|------------|-------------------|
| `../ZTool.base.exe` | pristine rekeyed **build input** (publicize + reinject target) | Win32 `3.8.4`, strong-named (vendor PKT) |
| `../ZTool.exe`      | **final deliverable** produced by `build.ps1` (= `out/ZTool.exe`) | Win32 `1.0.0`, RU-localized, MAX QR, auto-update off, **strong-name stripped** |

Run / redistribute `../ZTool.exe` together with `dist/ZTool.settings` (`<SWver>0</SWver>`) and the
runtime DLLs. Never run `ZTool.base.exe` directly — it is only the un-localized 3.8.4 input.
- Activation binds **one key to one machine**; moving a key needs the in-client "перенос лицензии".
- A cloud VM with a zeroed hardware UUID will show *"это устройство не соответствует условиям
  регистрации"* — that is the genuine hardware-binding check, not a build problem.
