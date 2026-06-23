<#
.SYNOPSIS
  Verify accepted runtime artifacts against scripts/expected_release_hashes.json.

.DESCRIPTION
  This is the lightweight hash gate for the checked-in accepted runtime files.
  Full package verification is handled by verify_release_package.ps1 once a
  package has been built.
#>
param(
    [string]$ExpectedPath = "",
    [string]$ReportPath = "",

    [switch]$RequireLooseRootMatch
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $ExpectedPath) {
    $ExpectedPath = Join-Path $PSScriptRoot 'expected_release_hashes.json'
}

if (-not (Test-Path -LiteralPath $ExpectedPath -PathType Leaf)) {
    throw "expected hashes file not found: $ExpectedPath"
}

$expected = Get-Content -LiteralPath $ExpectedPath -Encoding UTF8 -Raw | ConvertFrom-Json

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Add-CheckResult(
    [System.Collections.Generic.List[object]]$Results,
    [string]$Name,
    [string]$RelativePath,
    [string]$ExpectedHash,
    [switch]$Optional,
    [switch]$WarnOnMismatch
) {
    $path = Join-Path $repoRoot $RelativePath
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) {
        $Results.Add([ordered]@{
            name = $Name
            path = $RelativePath
            expected_sha256 = $ExpectedHash
            actual_sha256 = $null
            status = if ($Optional) { 'SKIP_MISSING_OPTIONAL' } elseif ($WarnOnMismatch) { 'WARN_MISSING_NON_AUTHORITATIVE' } else { 'FAIL_MISSING' }
        })
        return
    }

    $actual = Get-Sha256 $path
    $status = 'PASS'
    if ($actual -ne $ExpectedHash.ToLowerInvariant()) {
        $status = if ($WarnOnMismatch) { 'WARN_HASH_MISMATCH_NON_AUTHORITATIVE' } else { 'FAIL_HASH_MISMATCH' }
    }
    $Results.Add([ordered]@{
        name = $Name
        path = $RelativePath
        expected_sha256 = $ExpectedHash
        actual_sha256 = $actual
        status = $status
    })
}

$results = New-Object System.Collections.Generic.List[object]
Add-CheckResult $results 'client_exe_loose_root' 'SWTools.exe' ([string]$expected.client_exe_sha256) -WarnOnMismatch:(-not $RequireLooseRootMatch)
Add-CheckResult $results 'addin_dll_loose_root' 'SWTools.dll' ([string]$expected.addin_dll_sha256) -WarnOnMismatch:(-not $RequireLooseRootMatch)
Add-CheckResult $results 'ribbon_dll' 'Ribbon.dll' ([string]$expected.ribbon_dll_sha256)
Add-CheckResult $results 'expandable_grid_view_dll' 'ExpandableGridView.dll' ([string]$expected.expandable_grid_view_sha256)
Add-CheckResult $results 'ztool_rsa_dll' 'client-core/ref/ZTool_rsa.dll' ([string]$expected.ztool_rsa_dll_sha256)

if ($expected.setup_sha256 -and $expected.version) {
    Add-CheckResult `
        -Results $results `
        -Name 'setup_exe' `
        -RelativePath ("releases/{0}/SWTools-{0}-Setup.exe" -f [string]$expected.version) `
        -ExpectedHash ([string]$expected.setup_sha256) `
        -Optional
}

if ($ReportPath) {
    $reportDir = Split-Path -Parent $ReportPath
    if ($reportDir) { New-Item -ItemType Directory -Force -Path $reportDir | Out-Null }
    [ordered]@{
        generated_at = (Get-Date).ToUniversalTime().ToString('o')
        expected_path = $ExpectedPath
        version = [string]$expected.version
        require_loose_root_match = [bool]$RequireLooseRootMatch
        note = 'Loose root SWTools.exe/SWTools.dll are historical/non-authoritative unless hashes match the accepted package.'
        results = $results
    } | ConvertTo-Json -Depth 6 | Set-Content -LiteralPath $ReportPath -Encoding UTF8
}

$failures = @($results | Where-Object { $_.status -like 'FAIL_*' })
foreach ($result in $results) {
    Write-Host ("expected hash {0}: {1} ({2})" -f $result.status, $result.path, $result.name)
}

if ($failures.Count -gt 0) {
    throw "expected release hash check failed: $($failures.Count) failure(s)"
}

Write-Host "expected release hash check: PASS" -ForegroundColor Green
