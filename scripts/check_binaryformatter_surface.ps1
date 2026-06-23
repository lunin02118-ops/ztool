param(
    [string]$JsonOut = ""
)

$ErrorActionPreference = "Stop"

$repo = (git rev-parse --show-toplevel).Trim()
if (-not $repo) {
    throw "Not inside a git repository"
}

$allowed = @{
    "client-src/ZTool/code.cs" = @{
        surface = "main config binary helpers"
        data_source = "trusted local config/base64 blobs"
        containment = "VTBinder is set on DeserializeBinary/DeserializeObject"
        owner = "Sprint M"
    }
    "client-src/ZTool/FrmOutputlist.cs" = @{
        surface = "clipboard copy/paste list"
        data_source = "Windows clipboard MemoryStream"
        containment = "release package must verify SafeListBinder wiring"
        owner = "Sprint M"
    }
    "client-src/ZTool/FrmPrintlist.cs" = @{
        surface = "clipboard copy/paste list"
        data_source = "Windows clipboard MemoryStream"
        containment = "release package must verify SafeListBinder wiring"
        owner = "Sprint M"
    }
    "client-src/ZTool/FrmSetDrwlist.cs" = @{
        surface = "clipboard copy/paste list"
        data_source = "Windows clipboard MemoryStream"
        containment = "release package must verify SafeListBinder wiring"
        owner = "Sprint M"
    }
    "client-src/ZTool/FrmSyncDrwName.cs" = @{
        surface = "clipboard copy/paste list"
        data_source = "Windows clipboard MemoryStream"
        containment = "release package must verify SafeListBinder wiring"
        owner = "Sprint M"
    }
    "client-src/ZTool/VTBinder.cs" = @{
        surface = "binder implementation"
        data_source = "type resolution helper"
        containment = "short-name version-tolerant binder; no deserialization entrypoint"
        owner = "Sprint M"
    }
    "client-src-addin/Type_16.cs" = @{
        surface = "addin legacy serialize helpers"
        data_source = "legacy add-in helper input; not network-facing by current trace"
        containment = "requires source-level binder/migration decision before final source acceptance"
        owner = "Sprint M"
    }
    "client-core/tools/BinderInject/Program.cs" = @{
        surface = "tooling injector"
        data_source = "build-time IL patch target"
        containment = "verify mode checks VTBinder/SafeListBinder wiring"
        owner = "Sprint M"
    }
    "client-core/tools/BinderInject/donor/SafeListBinder.cs" = @{
        surface = "binder implementation"
        data_source = "allowed clipboard list types"
        containment = "allow-list binder; throws on disallowed type"
        owner = "Sprint M"
    }
    "client-core/tools/BinderInject/donor/VTBinder.cs" = @{
        surface = "binder implementation"
        data_source = "config blob type resolution"
        containment = "version-tolerant binder; returns null on miss"
        owner = "Sprint M"
    }
    "client-core/tools/Localizer/Program.cs" = @{
        surface = "tooling comments/resource scan guard"
        data_source = "build-time localization resources"
        containment = "does not deserialize BinaryFormatter payloads"
        owner = "Sprint M"
    }
}

$scanRoots = @(
    "client-src",
    "client-src-addin",
    "client-core/tools/BinderInject",
    "client-core/tools/Localizer"
)

$hitsByFile = @{}
foreach ($rootRel in $scanRoots) {
    $root = Join-Path $repo $rootRel
    if (-not (Test-Path $root)) {
        continue
    }
    Get-ChildItem -Path $root -Recurse -File -Filter *.cs |
        ForEach-Object {
            $matches = Select-String -Path $_.FullName -Pattern "BinaryFormatter" -SimpleMatch
            if ($matches) {
                $rel = $_.FullName.Substring($repo.Length + 1).Replace('\', '/')
                $hitsByFile[$rel] = @($matches | ForEach-Object {
                    [pscustomobject]@{
                        line = $_.LineNumber
                        text = $_.Line.Trim()
                    }
                })
            }
        }
}

$unclassified = @()
foreach ($path in $hitsByFile.Keys) {
    if (-not $allowed.ContainsKey($path)) {
        $unclassified += $path
    }
}

$missing = @()
foreach ($path in $allowed.Keys) {
    if (-not $hitsByFile.ContainsKey($path)) {
        $missing += $path
    }
}

$inventory = @()
foreach ($path in ($hitsByFile.Keys | Sort-Object)) {
    $meta = $allowed[$path]
    $inventory += [pscustomobject]@{
        path = $path
        hit_count = $hitsByFile[$path].Count
        surface = if ($meta) { $meta.surface } else { "UNCLASSIFIED" }
        data_source = if ($meta) { $meta.data_source } else { "" }
        containment = if ($meta) { $meta.containment } else { "" }
        owner = if ($meta) { $meta.owner } else { "" }
        hits = $hitsByFile[$path]
    }
}

$result = [pscustomobject]@{
    status = if ($unclassified.Count -eq 0 -and $missing.Count -eq 0) { "PASS" } else { "FAIL" }
    files_with_binaryformatter = $hitsByFile.Count
    unclassified_files = @($unclassified | Sort-Object)
    missing_expected_files = @($missing | Sort-Object)
    inventory = $inventory
}

if ($JsonOut) {
    $outPath = Join-Path $repo $JsonOut
    $outDir = Split-Path -Parent $outPath
    if ($outDir) {
        New-Item -ItemType Directory -Force -Path $outDir | Out-Null
    }
    $result | ConvertTo-Json -Depth 8 | Set-Content -Path $outPath -Encoding utf8NoBOM
    Write-Host "BinaryFormatter surface report written to: $JsonOut"
}

if ($result.status -ne "PASS") {
    if ($unclassified.Count -gt 0) {
        Write-Error ("Unclassified BinaryFormatter files: " + ($unclassified -join ", "))
    }
    if ($missing.Count -gt 0) {
        Write-Error ("Expected BinaryFormatter files missing; update containment inventory: " + ($missing -join ", "))
    }
    exit 1
}

Write-Host ("BinaryFormatter surface PASS. Files: {0}" -f $hitsByFile.Count)
exit 0
