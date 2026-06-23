# BinaryFormatter containment

Дата: 2026-06-23
Scope: Sprint M / legacy serialization containment.

## Verdict

`CONTAINED / SOURCE ACCEPTANCE FOLLOW-UP REQUIRED`

This PR does not replace `BinaryFormatter`. It inventories and gates the known
surface so new unclassified call sites fail before merge.

## Gate result

Command:

```powershell
pwsh -NoProfile -File scripts\check_binaryformatter_surface.ps1 `
  -JsonOut _local_artifacts\reports\p4-lm\binaryformatter_surface.json
```

Result:

```text
BinaryFormatter surface PASS
files_with_binaryformatter = 11
unclassified_files = 0
missing_expected_files = 0
```

## Inventory

| File | Surface | Data source | Containment |
|---|---|---|---|
| `client-src/ZTool/code.cs` | Main config binary helpers | Trusted local config/base64 blobs | `VTBinder` is set on deserialization. |
| `client-src/ZTool/FrmOutputlist.cs` | Clipboard list copy/paste | Windows clipboard MemoryStream | Release package must verify `SafeListBinder` wiring. |
| `client-src/ZTool/FrmPrintlist.cs` | Clipboard list copy/paste | Windows clipboard MemoryStream | Release package must verify `SafeListBinder` wiring. |
| `client-src/ZTool/FrmSetDrwlist.cs` | Clipboard list copy/paste | Windows clipboard MemoryStream | Release package must verify `SafeListBinder` wiring. |
| `client-src/ZTool/FrmSyncDrwName.cs` | Clipboard list copy/paste | Windows clipboard MemoryStream | Release package must verify `SafeListBinder` wiring. |
| `client-src/ZTool/VTBinder.cs` | Binder implementation | Type resolution helper | No deserialization entrypoint. |
| `client-src-addin/Type_16.cs` | Add-in legacy serialize helpers | Legacy add-in helper input | Needs source-level binder/migration decision before final source acceptance. |
| `client-core/tools/BinderInject/Program.cs` | Tooling injector | Build-time IL patch target | Verify mode checks binder wiring. |
| `client-core/tools/BinderInject/donor/SafeListBinder.cs` | Binder implementation | Allowed clipboard list types | Throws on disallowed type. |
| `client-core/tools/BinderInject/donor/VTBinder.cs` | Binder implementation | Config blob type resolution | Returns `null` on miss to avoid broad fallback changes. |
| `client-core/tools/Localizer/Program.cs` | Tooling comments/resource scan guard | Build-time localization resources | Does not deserialize BinaryFormatter payloads. |

## Security boundary

Current policy:

```text
[x] No network-facing BinaryFormatter usage identified.
[x] Clipboard BinaryFormatter path must be protected by SafeListBinder in packaged runtime.
[x] Config blob deserialization must use VTBinder or a stricter successor.
[x] New BinaryFormatter files fail `check_binaryformatter_surface.ps1`.
[ ] Source-native add-in helper `Type_16` still needs final source-acceptance decision.
```

## Follow-up

Do not mix serializer migration with unrelated UI/release changes. A future PR
may replace specific trusted-local blobs with a safer serializer only after:

1. fixture coverage for existing settings/config blobs;
2. original-vs-source parity test;
3. release note for compatibility impact;
4. rollback plan.
