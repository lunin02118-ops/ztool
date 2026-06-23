# Source-native migration status

Дата: 2026-06-23
Sprint: P4 / G — Client/source build closure

## Статус

From-source путь собирает оба клиентских компонента:

| Component | Source project | Output | Status |
|---|---|---|---|
| Client EXE | `client-src/ZTool.csproj` | `client-src/bin/Release/net48/ZTool.exe` + branded copy `SWTools.exe` | PASS |
| SolidWorks add-in | `client-src-addin/ZTool.SwAddin.csproj` | `client-src-addin/bin/Release/net48/ZTool.dll` + branded copy `SWTools.dll` | PASS with SDK shim in CI |
| SDK shim | `client-src-addin/sdk-shim/SolidWorksTools.Shim.csproj` | compile-only `SolidWorksTools.dll` | PASS; not shipped |

## Source build outputs checked in Sprint G

| Output | SHA256 | Version info |
|---|---|---|
| `client-src/bin/Release/net48/ZTool.exe` | `95dac7fde17fad8a2a1a0ce977be05c9fffb0fe52a709006d209bad968074407` | `ProductName=SWTools`, `ProductVersion=1.1.6`, `FileVersion=1.1.6`, `InternalName=ZTool.exe` |
| `client-src/bin/Release/net48/SWTools.exe` | `95dac7fde17fad8a2a1a0ce977be05c9fffb0fe52a709006d209bad968074407` | byte-identical branded filename copy |
| `client-src-addin/bin/Release/net48/ZTool.dll` | `b7c9292d289297692ef6e02e3345389e5e92713f394c753067dffdf1260948fa` | `ProductName=ZTool`, `ProductVersion=1.8.3.0`, `FileVersion=1.8.3.0`, `InternalName=ZTool.dll` |
| `client-src-addin/bin/Release/net48/SWTools.dll` | `b7c9292d289297692ef6e02e3345389e5e92713f394c753067dffdf1260948fa` | byte-identical branded filename copy |

Dry-run package check (`C:\Temp\swtools-p4-g-release-check`) additionally verified
that packaging applies `AddinBrandPatch` to the add-in before shipping:

| Package runtime output | SHA256 | Note |
|---|---|---|
| `runtime/SWTools.exe` | `95dac7fde17fad8a2a1a0ce977be05c9fffb0fe52a709006d209bad968074407` | same bytes as source EXE output |
| `runtime/SWTools.dll` | `e5a62b90a52fdf76697166dc800c2b4d48402ea63eb1aac59cddf15d8f874a76` | source add-in after `AddinBrandPatch` (`Title=SWTools`, `Description=SWTools SolidWorks Add-in`) |

## Difference vs accepted runtime

Accepted release hashes remain in `scripts/expected_release_hashes.json`:

| Artifact | Accepted hash | Sprint G source-build hash | Explanation |
|---|---|---|---|
| `SWTools.exe` | `f418c7d81a735c309b4fb0709c8bd81333d95cfab9c7468aa2329add0a364e09` | `95dac7fde17fad8a2a1a0ce977be05c9fffb0fe52a709006d209bad968074407` | Current source tree builds successfully and keeps `1.1.6` metadata, but release acceptance still pins the previously accepted runtime. Sprint F packages from source with computed hashes for dry-run evidence; promotion to accepted release hash is a separate release decision. |
| `SWTools.dll` | `5dbf9986a4fbce5e6ab8fa4269705732c6ba891d1b27988e60e10c191ae290c1` | source output `b7c9292d...`; package output after brand patch `e5a62b90...` | Add-in builds from recovered C# and preserves COM identity, then package applies the controlled brand patch. Assembly version metadata is still vendor-shaped until release promotion/metadata alignment. |

Root loose binaries remain historical/non-authoritative; see `docs/audit/BINARY_PROVENANCE_RU.md`.

## Gates added

`scripts/check_client_src_warnings.ps1`:

- builds `client-src`;
- builds `client-src-addin/sdk-shim`;
- builds `client-src-addin` against the shim unless a real `SolidWorksToolsPath` is provided;
- parses unique compiler warnings;
- compares totals and warning-code counts with `docs/audit/CLIENT_SRC_WARNING_BASELINE_RU.md`;
- fails on warning drift.

The gate is wired into `.github/workflows/release-hardening.yml`.

## Remaining work

1. Align add-in visible/assembly metadata (`ZTool`, `1.8.3.0`) only after live parity checks, because SolidWorks COM identity and runtime launch behavior must not drift accidentally.
2. Promote a from-source package to accepted hashes only through the release process.
3. Run live SolidWorks S7/S8 and licensing L3-L5 before final production GO.
