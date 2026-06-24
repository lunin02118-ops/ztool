<#
.SYNOPSIS
  Verify SWTools version metadata on built release artifacts.
#>
param(
    [string]$Version = '',
    [string]$ClientExe = '',
    [string]$AddinDll = '',
    [string]$Installer = '',
    [string]$JsonOut = ''
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $Version) { $Version = (Get-Content -LiteralPath (Join-Path $repoRoot 'VERSION') -Encoding UTF8 -Raw).Trim() }
if (-not $ClientExe) { $ClientExe = Join-Path $repoRoot 'client-src\bin\Release\net48\SWTools.exe' }
if (-not $AddinDll) { $AddinDll = Join-Path $repoRoot 'client-src-addin\bin\Release\net48\SWTools.dll' }

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

function Check-Artifact([string]$Path, [string]$Kind) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) { throw "$Kind missing: $Path" }
    $info = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($Path)
    $errors = @()
    if ($info.ProductName -ne 'SWTools') { $errors += "ProductName='$($info.ProductName)'" }
    if (-not $info.ProductVersion -or -not $info.ProductVersion.StartsWith($Version, [System.StringComparison]::OrdinalIgnoreCase)) {
        $errors += "ProductVersion='$($info.ProductVersion)'"
    }
    if (-not $info.FileVersion -or -not $info.FileVersion.StartsWith("$Version.", [System.StringComparison]::OrdinalIgnoreCase)) {
        $errors += "FileVersion='$($info.FileVersion)'"
    }
    if ($errors.Count -gt 0) { throw "$Kind version stamp mismatch: $($errors -join ', ')" }
    return [ordered]@{
        path = [System.IO.Path]::GetFullPath($Path)
        sha256 = Get-Sha256 $Path
        product_name = $info.ProductName
        product_version = $info.ProductVersion
        file_version = $info.FileVersion
        original_filename = $info.OriginalFilename
    }
}

$result = [ordered]@{
    version = $Version
    checked_at = (Get-Date).ToUniversalTime().ToString('o')
    client_exe = Check-Artifact $ClientExe 'SWTools.exe'
    addin_dll = Check-Artifact $AddinDll 'SWTools.dll'
}

if ($Installer) {
    if (-not (Test-Path -LiteralPath $Installer -PathType Leaf)) { throw "installer missing: $Installer" }
    $result.installer = [ordered]@{
        path = [System.IO.Path]::GetFullPath($Installer)
        sha256 = Get-Sha256 $Installer
    }
}

if ($JsonOut) {
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $JsonOut) | Out-Null
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($JsonOut, ($result | ConvertTo-Json -Depth 6), $encoding)
}

Write-Host 'version stamp: PASS' -ForegroundColor Green
