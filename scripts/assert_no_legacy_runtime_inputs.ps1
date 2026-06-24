<#
.SYNOPSIS
  Fail if release package inputs silently point at historical root runtime binaries.
#>
param(
    [string]$ReleaseInputsPath = '',
    [string]$ClientExe = '',
    [string]$AddinDll = '',
    [switch]$UseAcceptedRuntimeSnapshot
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path

function Get-FullPath([string]$Path) {
    return [System.IO.Path]::GetFullPath($Path)
}

function Test-IsSamePath([string]$A, [string]$B) {
    return [string]::Equals((Get-FullPath $A), (Get-FullPath $B), [System.StringComparison]::OrdinalIgnoreCase)
}

if ($ReleaseInputsPath) {
    $json = Get-Content -LiteralPath $ReleaseInputsPath -Encoding UTF8 -Raw | ConvertFrom-Json
    $ClientExe = $json.client_exe.path
    $AddinDll = $json.addin_dll.path
    $UseAcceptedRuntimeSnapshot = $json.input_mode -eq 'accepted-runtime-snapshot'
}

if (-not $ClientExe -or -not $AddinDll) {
    throw 'Pass -ReleaseInputsPath or both -ClientExe and -AddinDll.'
}

$legacyClient = Join-Path $repoRoot 'SWTools.exe'
$legacyAddin = Join-Path $repoRoot 'SWTools.dll'
$clientIsLegacy = Test-IsSamePath $ClientExe $legacyClient
$addinIsLegacy = Test-IsSamePath $AddinDll $legacyAddin

if (($clientIsLegacy -or $addinIsLegacy) -and -not $UseAcceptedRuntimeSnapshot) {
    throw "legacy root runtime input is forbidden without -UseAcceptedRuntimeSnapshot: ClientExe=$ClientExe AddinDll=$AddinDll"
}

if ($UseAcceptedRuntimeSnapshot -and (-not $clientIsLegacy -or -not $addinIsLegacy)) {
    throw "-UseAcceptedRuntimeSnapshot requires both root accepted artifacts. ClientExe=$ClientExe AddinDll=$AddinDll"
}

Write-Host 'legacy runtime input guard: PASS' -ForegroundColor Green
