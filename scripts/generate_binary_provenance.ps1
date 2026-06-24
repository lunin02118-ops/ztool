<#
.SYNOPSIS
  Generate a binary provenance markdown and JSON report for tracked SWTools
  runtime artifacts.
#>
param(
    [string]$OutputPath = "",
    [string]$JsonOutput = "artifacts\binary-provenance.json"
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $OutputPath) {
    $OutputPath = Join-Path $repoRoot 'docs\audit\BINARY_PROVENANCE_RU.md'
}
$jsonPath = if ([System.IO.Path]::IsPathRooted($JsonOutput)) { $JsonOutput } else { Join-Path $repoRoot $JsonOutput }
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $OutputPath) | Out-Null
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $jsonPath) | Out-Null

function Get-Sha256OrStatus([string]$RelativePath) {
    $path = Join-Path $repoRoot $RelativePath
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) { return 'not present' }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $path).Hash.ToLowerInvariant()
}

$expected = Get-Content -LiteralPath (Join-Path $repoRoot 'scripts\expected_release_hashes.json') -Raw -Encoding UTF8 | ConvertFrom-Json
$items = @(
    [ordered]@{ Artifact='Setup installer'; Path='releases/1.1.6/SWTools-1.1.6-Setup.exe'; Role='installer'; Origin='generated release artifact'; Expected=$expected.setup_sha256; Notes='Exact release installer.' },
    [ordered]@{ Artifact='Client EXE'; Path='SWTools.exe'; Role='loose client binary'; Origin='historical/non-authoritative'; Expected=$expected.client_exe_sha256; Notes='Must not be used as release source unless hash matches accepted package.' },
    [ordered]@{ Artifact='Add-in DLL'; Path='SWTools.dll'; Role='loose add-in binary'; Origin='historical/non-authoritative'; Expected=$expected.addin_dll_sha256; Notes='Must not be used as release source unless hash matches accepted package.' },
    [ordered]@{ Artifact='Base EXE'; Path='SWTools-base.exe'; Role='legacy base input'; Origin='patched legacy input'; Expected=''; Notes='Lineage diagnostic only.' },
    [ordered]@{ Artifact='Ribbon runtime'; Path='Ribbon.dll'; Role='runtime dependency'; Origin='bundled third-party'; Expected=$expected.ribbon_dll_sha256; Notes='License/origin review required.' },
    [ordered]@{ Artifact='Expandable grid runtime'; Path='ExpandableGridView.dll'; Role='runtime dependency'; Origin='bundled third-party'; Expected=$expected.expandable_grid_view_sha256; Notes='License/origin review required.' },
    [ordered]@{ Artifact='RSA helper'; Path='client-core/ref/ZTool_rsa.dll'; Role='runtime dependency'; Origin='bundled legacy runtime'; Expected=$expected.ztool_rsa_dll_sha256; Notes='Distribution rights tied to runtime approval.' },
    [ordered]@{ Artifact='Russian help'; Path='help_ru.chm'; Role='user help'; Origin='generated/packaged asset'; Expected=''; Notes='Brand evidence captured; final CHM source/toolchain evidence still required.' },
    [ordered]@{ Artifact='Runtime settings'; Path='SWTools.settings'; Role='config'; Origin='repository asset'; Expected=''; Notes='Path-patched during package build.' }
)

$rows = @()
foreach ($item in $items) {
    $actual = Get-Sha256OrStatus $item.Path
    $status = 'INFO'
    if ($actual -eq 'not present') {
        $status = 'BLOCKED'
    } elseif ($item.Expected) {
        $status = if ($actual -eq ([string]$item.Expected).ToLowerInvariant()) { 'PASS' } else { 'WARN' }
    }
    $rows += [ordered]@{
        artifact = $item.Artifact
        path = $item.Path
        role = $item.Role
        origin = $item.Origin
        expected_sha256 = $item.Expected
        actual_sha256 = $actual
        status = $status
        notes = $item.Notes
    }
}

$lines = @(
    '# Binary provenance matrix',
    '',
    "Generated: $((Get-Date).ToUniversalTime().ToString('yyyy-MM-ddTHH:mm:ssZ'))",
    '',
    '| Artifact | Current path | Role | Origin class | Expected SHA256 | Actual SHA256 | Status | Notes |',
    '|---|---|---|---|---|---|---|---|'
)
foreach ($row in $rows) {
    $tick = [char]96
    $artifact = $row['artifact']
    $path = $row['path']
    $role = $row['role']
    $origin = $row['origin']
    $expectedSha = $row['expected_sha256']
    $actualSha = $row['actual_sha256']
    $status = $row['status']
    $notes = $row['notes']
    $lines += "| $artifact | $tick$path$tick | $role | $origin | $tick$expectedSha$tick | $tick$actualSha$tick | $status | $notes |"
}
$lines += ''
$lines += 'Loose root binaries are non-authoritative unless their hashes match `scripts/expected_release_hashes.json`.'

$lines -join "`r`n" | Set-Content -LiteralPath $OutputPath -Encoding UTF8
$rows | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $jsonPath -Encoding UTF8
Write-Host "binary provenance markdown: $OutputPath"
Write-Host "binary provenance json: $jsonPath"
