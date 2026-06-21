<#
.SYNOPSIS
  Build a SWTools release package with manifest and SHA256SUMS.

.DESCRIPTION
  This script packages the live-tested runtime artifacts without private keys,
  databases, dumps or local logs. For a production package pass
  -SolidWorksToolsDll; dry-runs can use -AllowMissingSolidWorksTools.
#>
param(
    [string]$Version = "",
    [string]$OutputRoot = "",
    [string]$ClientExe = (Join-Path $PSScriptRoot '..\SWTools.exe'),
    [string]$AddinDll = (Join-Path $PSScriptRoot '..\SWTools.dll'),
    [string]$SolidWorksToolsDll = "",
    [switch]$AllowMissingSolidWorksTools
)

$ErrorActionPreference = 'Stop'
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

function Get-ReleaseVersion {
    $versionPath = Join-Path $repoRoot 'VERSION'
    if (Test-Path -LiteralPath $versionPath -PathType Leaf) {
        $v = (Get-Content -LiteralPath $versionPath -Encoding UTF8 -Raw).Trim()
        if ($v) { return $v }
    }
    return '1.0.0'
}

if (-not $Version) { $Version = Get-ReleaseVersion }
if (-not $OutputRoot) { $OutputRoot = Join-Path $repoRoot "releases\$Version\package" }
$packageName = "SWTools-$Version"
$outputRootPath = [System.IO.Path]::GetFullPath($OutputRoot)
$packageRoot = Join-Path $outputRootPath $packageName
$runtimeDir = Join-Path $packageRoot 'runtime'
$serverDir = Join-Path $packageRoot 'license-server'
$docsDir = Join-Path $packageRoot 'docs'
$specTemplatesDirName = [System.Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('0KjQsNCx0LvQvtC90Ysg0YHQv9C10YbQuNGE0LjQutCw0YbQuNC4'))

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Invoke-Checked([string]$What) {
    if ($LASTEXITCODE -ne 0) { throw "$What failed (exit $LASTEXITCODE)" }
}

function Write-Utf8NoBom([string]$Path, [string[]]$Lines) {
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllLines($Path, $Lines, $encoding)
}

function Copy-RequiredFile([string]$Source, [string]$DestDir, [string]$DestName = "") {
    if (-not (Test-Path -LiteralPath $Source)) { throw "required file missing: $Source" }
    New-Item -ItemType Directory -Force -Path $DestDir | Out-Null
    $name = if ($DestName) { $DestName } else { Split-Path -Leaf $Source }
    $dest = Join-Path $DestDir $name
    Copy-Item -LiteralPath $Source -Destination $dest -Force
    return $dest
}

function Copy-OptionalSolidWorksTools {
    if ($SolidWorksToolsDll) {
        return Copy-RequiredFile $SolidWorksToolsDll $runtimeDir 'SolidWorksTools.dll'
    }
    if ($AllowMissingSolidWorksTools) {
        Write-Warning "SolidWorksTools.dll not provided; dry-run package is not production complete."
        return $null
    }
    throw "SolidWorksTools.dll is required for production package. Pass -SolidWorksToolsDll or -AllowMissingSolidWorksTools for dry-run."
}

function Copy-ClientRuntimeDependencies([string]$ClientExePath) {
    $clientDir = Split-Path -Parent ([System.IO.Path]::GetFullPath($ClientExePath))
    $deps = @(
        'System.Buffers.dll',
        'System.Memory.dll',
        'System.Numerics.Vectors.dll',
        'System.Resources.Extensions.dll',
        'System.Runtime.CompilerServices.Unsafe.dll'
    )

    $copiedDeps = @()
    foreach ($dep in $deps) {
        $source = Join-Path $clientDir $dep
        $copiedDeps += Copy-RequiredFile $source $runtimeDir
    }

    $configSource = Join-Path $clientDir 'ZTool.exe.config'
    if (Test-Path -LiteralPath $configSource -PathType Leaf) {
        $copiedDeps += Copy-RequiredFile $configSource $runtimeDir 'SWTools.exe.config'
    }
    else {
        throw "required client config missing: $configSource"
    }

    return $copiedDeps
}

function Copy-TreeFiltered([string]$Source, [string]$Destination) {
    if (-not (Test-Path -LiteralPath $Source)) { throw "required directory missing: $Source" }
    New-Item -ItemType Directory -Force -Path $Destination | Out-Null
    robocopy $Source $Destination /E /XD __pycache__ .pytest_cache .mypy_cache .ruff_cache .venv venv keys data backups bin obj *.egg-info /XF .coverage *.db *.db-* *.sqlite *.sqlite3 private_key.txt keypair_info.json *.pem *.key *.log | Out-Host
    if ($LASTEXITCODE -gt 7) { throw "robocopy failed from $Source to $Destination (exit $LASTEXITCODE)" }
    $global:LASTEXITCODE = 0
}

if (Test-Path -LiteralPath $packageRoot) { throw "package output already exists: $packageRoot" }
New-Item -ItemType Directory -Force -Path $runtimeDir, $serverDir, $docsDir | Out-Null

$copied = @()
$copied += Copy-RequiredFile $ClientExe $runtimeDir 'SWTools.exe'
$copied += Copy-ClientRuntimeDependencies $ClientExe
$addinRuntimeDll = Copy-RequiredFile $AddinDll $runtimeDir 'SWTools.dll'
$addinPatchProject = Join-Path $repoRoot 'client-core\tools\AddinBrandPatch\AddinBrandPatch.csproj'
$addinPatchTmp = "$addinRuntimeDll.brand.tmp"
dotnet run -c Release --project $addinPatchProject -- $addinRuntimeDll patch $addinPatchTmp
Invoke-Checked 'addin brand patch'
Move-Item -Force $addinPatchTmp $addinRuntimeDll
dotnet run -c Release --project $addinPatchProject -- $addinRuntimeDll verify
Invoke-Checked 'addin brand verify'
$copied += $addinRuntimeDll
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWToolsARM.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWTools.settings') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWTools Updater.exe') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWTools.bmp') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'help_ru.chm') $runtimeDir 'help.CHM'
$copied += Copy-RequiredFile (Join-Path $repoRoot 'Ribbon.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'ExpandableGridView.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'client-core\ref\ZTool_rsa.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'ICSharpCode.SharpZipLib.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'itextsharp.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'NPOI.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'NPOI.OOXML.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'NPOI.OpenXml4Net.dll') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'NPOI.OpenXmlFormats.dll') $runtimeDir
$swTools = Copy-OptionalSolidWorksTools
if ($swTools) { $copied += $swTools }

Copy-TreeFiltered (Join-Path $repoRoot $specTemplatesDirName) (Join-Path $runtimeDir $specTemplatesDirName)
Copy-TreeFiltered (Join-Path $repoRoot 'SolidWorksTemplates') (Join-Path $runtimeDir 'SolidWorksTemplates')
& (Join-Path $repoRoot 'client-core\tools\set_bom_template_path.ps1') `
    -Folder $runtimeDir `
    -Settings (Join-Path $runtimeDir 'SWTools.settings')
Copy-TreeFiltered (Join-Path $repoRoot 'license-server') $serverDir
Copy-TreeFiltered (Join-Path $repoRoot 'deploy') (Join-Path $packageRoot 'deploy')
Copy-TreeFiltered (Join-Path $repoRoot 'docs') $docsDir

$files = @{}
Get-ChildItem -File -Recurse -LiteralPath $packageRoot | ForEach-Object {
    $rel = $_.FullName.Substring($packageRoot.Length + 1).Replace('\', '/')
    $files[$rel] = [ordered]@{
        sha256 = Get-Sha256 $_.FullName
        size_bytes = $_.Length
    }
}

$manifest = [ordered]@{
    package = $packageName
    version = $Version
    generated_at = (Get-Date).ToUniversalTime().ToString('o')
    git = [ordered]@{
        commit = (& git -C $repoRoot rev-parse HEAD 2>$null)
        branch = (& git -C $repoRoot rev-parse --abbrev-ref HEAD 2>$null)
        dirty = [bool](& git -C $repoRoot status --porcelain 2>$null)
    }
    runtime = [ordered]@{
        client_exe_source = $ClientExe
        addin_dll_source = $AddinDll
        addin_dll_brand_patched = $true
        solidworks_tools_included = [bool]$swTools
    }
    files = $files
}

$manifestPath = Join-Path $packageRoot 'manifest.json'
Write-Utf8NoBom $manifestPath @(($manifest | ConvertTo-Json -Depth 10))

$sumsPath = Join-Path $packageRoot 'SHA256SUMS.txt'
$sumLines = Get-ChildItem -File -Recurse -LiteralPath $packageRoot | Sort-Object FullName | ForEach-Object {
    $rel = $_.FullName.Substring($packageRoot.Length + 1).Replace('\', '/')
    "$(Get-Sha256 $_.FullName)  $rel"
}
Write-Utf8NoBom $sumsPath $sumLines

Write-Host "release package: $packageRoot" -ForegroundColor Green
Write-Host "manifest: $manifestPath" -ForegroundColor Green
Write-Host "sha256sums: $sumsPath" -ForegroundColor Green
