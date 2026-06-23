param(
    [string]$JsonOut = "",
    [long]$LargeFileThresholdBytes = 10485760
)

$ErrorActionPreference = "Stop"

$repo = (git rev-parse --show-toplevel).Trim()
if (-not $repo) {
    throw "Not inside a git repository"
}

$tracked = git -C $repo ls-files

$prohibited = @(
    @{ Pattern = '^_local_artifacts/'; Reason = 'local scratch/evidence must not be tracked' },
    @{ Pattern = '^releases/'; Reason = 'release packages are generated artifacts' },
    @{ Pattern = '^client-rekey/.*\.txt$'; Reason = 'rekey input material belongs in _local_artifacts/secrets/client-rekey' },
    @{ Pattern = '^license-server/keys/private_key\.txt$'; Reason = 'private key material' },
    @{ Pattern = '^license-server/keys/keypair_info\.json$'; Reason = 'keypair metadata may expose private key custody' },
    @{ Pattern = '(^|/).*\.pfx$'; Reason = 'signing certificate material' },
    @{ Pattern = '(^|/).*\.pem$'; Reason = 'key/certificate material' },
    @{ Pattern = '(^|/).*\.key$'; Reason = 'key material' },
    @{ Pattern = '(^|/).*\.reg$'; Reason = 'registry exports are machine/license-state evidence' },
    @{ Pattern = '(^|/).*\.dmp$'; Reason = 'raw memory dumps are local diagnostics' },
    @{ Pattern = '(^|/).*\.dump$'; Reason = 'raw memory dumps are local diagnostics' },
    @{ Pattern = '^license-server/.*\.(db|sqlite|sqlite3)$'; Reason = 'runtime database state' }
)

$violations = @()
foreach ($path in $tracked) {
    $norm = $path -replace '\\', '/'
    foreach ($rule in $prohibited) {
        if ($norm -match $rule.Pattern) {
            $violations += [pscustomobject]@{
                path = $norm
                reason = $rule.Reason
            }
        }
    }
}

$legacyEvidence = @(
    $tracked |
        Where-Object {
            ($_ -replace '\\', '/') -match '^dumps/' -or
            ($_ -replace '\\', '/') -match '^manual-test-reports/.+\.(png|jpg|jpeg|mp4|zip|json|log)$'
        } |
        ForEach-Object { $_ -replace '\\', '/' }
)

$runtimeBinaryExtensions = @(".exe", ".dll")
$helpAssetExtensions = @(".chm", ".bmp")
$cadExtensions = @(".sldasm", ".sldprt", ".slddrw")

$largeOrBinaryTracked = @()
$runtimeBinaryTracked = @()
$helpAssetTracked = @()
$cadTracked = @()
$largeTracked = @()

foreach ($path in $tracked) {
    $norm = $path -replace '\\', '/'
    $fullPath = Join-Path $repo $path
    if (-not (Test-Path -LiteralPath $fullPath -PathType Leaf)) {
        continue
    }

    $item = Get-Item -LiteralPath $fullPath
    $extension = [System.IO.Path]::GetExtension($norm).ToLowerInvariant()
    $classes = @()

    if ($runtimeBinaryExtensions -contains $extension) {
        $classes += "runtime_binary"
    }
    if ($helpAssetExtensions -contains $extension) {
        $classes += "help_asset"
    }
    if ($cadExtensions -contains $extension) {
        $classes += "cad_fixture"
    }
    if ($item.Length -ge $LargeFileThresholdBytes) {
        $classes += "large_file"
    }

    if ($classes.Count -eq 0) {
        continue
    }

    $entry = [pscustomobject]@{
        path = $norm
        size_bytes = [int64]$item.Length
        classes = @($classes)
    }

    $largeOrBinaryTracked += $entry
    if ($classes -contains "runtime_binary") {
        $runtimeBinaryTracked += $entry
    }
    if ($classes -contains "help_asset") {
        $helpAssetTracked += $entry
    }
    if ($classes -contains "cad_fixture") {
        $cadTracked += $entry
    }
    if ($classes -contains "large_file") {
        $largeTracked += $entry
    }
}

$result = [pscustomobject]@{
    status = if ($violations.Count -eq 0) { "PASS" } else { "FAIL" }
    prohibited_tracked_count = $violations.Count
    prohibited_tracked = $violations
    legacy_tracked_evidence_count = $legacyEvidence.Count
    legacy_tracked_evidence_sample = @($legacyEvidence | Select-Object -First 25)
    large_or_binary_threshold_bytes = $LargeFileThresholdBytes
    large_or_binary_tracked_count = $largeOrBinaryTracked.Count
    large_or_binary_tracked_sample = @($largeOrBinaryTracked | Sort-Object path | Select-Object -First 25)
    runtime_binary_tracked_count = $runtimeBinaryTracked.Count
    help_asset_tracked_count = $helpAssetTracked.Count
    cad_tracked_count = $cadTracked.Count
    large_file_tracked_count = $largeTracked.Count
}

if ($JsonOut) {
    $outPath = Join-Path $repo $JsonOut
    $outDir = Split-Path -Parent $outPath
    if ($outDir) {
        New-Item -ItemType Directory -Force -Path $outDir | Out-Null
    }
    $result | ConvertTo-Json -Depth 8 | Set-Content -Path $outPath -Encoding utf8NoBOM
    Write-Host "repo hygiene report written to: $JsonOut"
}

if ($violations.Count -gt 0) {
    Write-Error ("Repo hygiene violations: " + ($violations | ForEach-Object { $_.path + " (" + $_.reason + ")" } | Out-String))
    exit 1
}

Write-Host ("Repo hygiene PASS. Legacy tracked evidence count: {0}; large/binary tracked count: {1}" -f $legacyEvidence.Count, $largeOrBinaryTracked.Count)
exit 0
