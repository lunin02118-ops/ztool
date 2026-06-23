param(
    [string]$JsonOut = ""
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

$result = [pscustomobject]@{
    status = if ($violations.Count -eq 0) { "PASS" } else { "FAIL" }
    prohibited_tracked_count = $violations.Count
    prohibited_tracked = $violations
    legacy_tracked_evidence_count = $legacyEvidence.Count
    legacy_tracked_evidence_sample = @($legacyEvidence | Select-Object -First 25)
}

if ($JsonOut) {
    $outPath = Join-Path $repo $JsonOut
    $outDir = Split-Path -Parent $outPath
    if ($outDir) {
        New-Item -ItemType Directory -Force -Path $outDir | Out-Null
    }
    $result | ConvertTo-Json -Depth 6 | Set-Content -Path $outPath -Encoding utf8NoBOM
    Write-Host "repo hygiene report written to: $JsonOut"
}

if ($violations.Count -gt 0) {
    Write-Error ("Repo hygiene violations: " + ($violations | ForEach-Object { $_.path + " (" + $_.reason + ")" } | Out-String))
    exit 1
}

Write-Host ("Repo hygiene PASS. Legacy tracked evidence count: {0}" -f $legacyEvidence.Count)
exit 0
