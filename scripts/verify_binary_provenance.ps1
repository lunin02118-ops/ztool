<#
.SYNOPSIS
  Verify that accepted hashes are documented and loose root binaries are not
  accidentally treated as release-authoritative artifacts.
#>
param(
    [string]$ProvenancePath = "",
    [switch]$RequireReleasePackage
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $ProvenancePath) {
    $ProvenancePath = Join-Path $repoRoot 'docs\audit\BINARY_PROVENANCE_RU.md'
}

if (-not (Test-Path -LiteralPath $ProvenancePath -PathType Leaf)) {
    throw "binary provenance document missing: $ProvenancePath"
}

$expected = Get-Content -LiteralPath (Join-Path $repoRoot 'scripts\expected_release_hashes.json') -Raw -Encoding UTF8 | ConvertFrom-Json
$doc = Get-Content -LiteralPath $ProvenancePath -Raw -Encoding UTF8

foreach ($hash in @($expected.setup_sha256, $expected.client_exe_sha256, $expected.addin_dll_sha256, $expected.ribbon_dll_sha256, $expected.expandable_grid_view_sha256, $expected.ztool_rsa_dll_sha256)) {
    if ([string]::IsNullOrWhiteSpace([string]$hash)) { throw 'expected hash is blank' }
    if ($doc -notmatch [regex]::Escape([string]$hash)) {
        throw "expected hash is not documented in provenance: $hash"
    }
}

function Get-Sha([string]$RelativePath) {
    $path = Join-Path $repoRoot $RelativePath
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) { return $null }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $path).Hash.ToLowerInvariant()
}

$rootExe = Get-Sha 'SWTools.exe'
$rootDll = Get-Sha 'SWTools.dll'
if ($rootExe -and $rootExe -ne ([string]$expected.client_exe_sha256).ToLowerInvariant()) {
    if ($doc -notmatch 'non-authoritative|не считается|historical') {
        throw 'root SWTools.exe differs from expected hash but provenance does not mark loose binaries as non-authoritative'
    }
    Write-Warning "root SWTools.exe differs from accepted hash; documented as non-authoritative"
}
if ($rootDll -and $rootDll -ne ([string]$expected.addin_dll_sha256).ToLowerInvariant()) {
    if ($doc -notmatch 'non-authoritative|не считается|historical') {
        throw 'root SWTools.dll differs from expected hash but provenance does not mark loose binaries as non-authoritative'
    }
    Write-Warning "root SWTools.dll differs from accepted hash; documented as non-authoritative"
}

$packageRuntime = Join-Path $repoRoot 'releases\1.1.6\package\SWTools-1.1.6\runtime'
if (Test-Path -LiteralPath $packageRuntime -PathType Container) {
    $runtimeExe = Get-FileHash -Algorithm SHA256 -LiteralPath (Join-Path $packageRuntime 'SWTools.exe')
    $runtimeDll = Get-FileHash -Algorithm SHA256 -LiteralPath (Join-Path $packageRuntime 'SWTools.dll')
    if ($runtimeExe.Hash.ToLowerInvariant() -ne ([string]$expected.client_exe_sha256).ToLowerInvariant()) {
        throw 'release package runtime SWTools.exe hash mismatch'
    }
    if ($runtimeDll.Hash.ToLowerInvariant() -ne ([string]$expected.addin_dll_sha256).ToLowerInvariant()) {
        throw 'release package runtime SWTools.dll hash mismatch'
    }
} elseif ($RequireReleasePackage) {
    throw "release package runtime missing: $packageRuntime"
} else {
    Write-Warning "release package runtime missing; exact package verification is blocked outside prepared release workspace"
}

Write-Host 'binary provenance verification: PASS' -ForegroundColor Green
