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
    [bool]$FromSource = $true,
    [string]$SolidWorksToolsDll = "",
    [switch]$AllowMissingSolidWorksTools
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path

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

function Invoke-FromSourceBuild {
    $clientProject = Join-Path $repoRoot 'client-src\ZTool.csproj'
    $shimProject = Join-Path $repoRoot 'client-src-addin\sdk-shim\SolidWorksTools.Shim.csproj'
    $addinProject = Join-Path $repoRoot 'client-src-addin\ZTool.SwAddin.csproj'
    $shimDll = Join-Path $repoRoot 'client-src-addin\sdk-shim\bin\Release\net48\SolidWorksTools.dll'

    Write-Host 'building release artifacts from source...' -ForegroundColor Cyan
    dotnet build $clientProject -c Release -warnaserror:false -p:ContinuousIntegrationBuild=true
    Invoke-Checked 'from-source client build'

    dotnet build $shimProject -c Release -p:ContinuousIntegrationBuild=true
    Invoke-Checked 'SolidWorksTools compile shim build'

    $solidWorksToolsForBuild = $shimDll
    if ($SolidWorksToolsDll) {
        $solidWorksToolsForBuild = (Resolve-Path -LiteralPath $SolidWorksToolsDll).Path
    }

    dotnet build $addinProject -c Release -warnaserror:false "-p:SolidWorksToolsPath=$solidWorksToolsForBuild" -p:ContinuousIntegrationBuild=true
    Invoke-Checked 'from-source add-in build'
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

function Copy-ClientBuildOutputFile([string]$ClientExePath, [string]$FileName) {
    $clientDir = Split-Path -Parent ([System.IO.Path]::GetFullPath($ClientExePath))
    return Copy-RequiredFile (Join-Path $clientDir $FileName) $runtimeDir
}

function Assert-ZToolRsaParity([string]$ClientExePath) {
    $clientDir = Split-Path -Parent ([System.IO.Path]::GetFullPath($ClientExePath))
    $fromSourceRsa = Join-Path $clientDir 'ZTool_rsa.dll'
    $referenceRsa = Join-Path $repoRoot 'client-core\ref\ZTool_rsa.dll'
    if (-not (Test-Path -LiteralPath $fromSourceRsa -PathType Leaf)) {
        throw "from-source ZTool_rsa.dll missing: $fromSourceRsa"
    }
    if (-not (Test-Path -LiteralPath $referenceRsa -PathType Leaf)) {
        throw "reference ZTool_rsa.dll missing: $referenceRsa"
    }
    $fromSourceHash = Get-Sha256 $fromSourceRsa
    $referenceHash = Get-Sha256 $referenceRsa
    if ($fromSourceHash -ne $referenceHash) {
        throw "ZTool_rsa.dll parity failed; from-source=$fromSourceHash reference=$referenceHash"
    }
}

function Test-ReleaseCopyExcluded([string]$RelativePath) {
    $parts = $RelativePath -split '[\\/]'
    foreach ($part in $parts) {
        if ($part -in @('__pycache__', '.pytest_cache', '.mypy_cache', '.ruff_cache', '.venv', 'venv', 'keys', 'data', 'backups', 'bin', 'obj')) {
            return $true
        }
        if ($part -like '*.egg-info') { return $true }
    }

    $name = Split-Path -Leaf $RelativePath
    foreach ($pattern in @('.coverage', '*.db', '*.db-*', '*.sqlite', '*.sqlite3', 'private_key.txt', 'keypair_info.json', '*.pem', '*.key', '*.log')) {
        if ($name -like $pattern) { return $true }
    }
    return $false
}

function Copy-GitTrackedTreeFiltered([string]$RelativeSource, [string]$Destination) {
    $source = Join-Path $repoRoot $RelativeSource
    if (-not (Test-Path -LiteralPath $source)) { throw "required directory missing: $source" }
    New-Item -ItemType Directory -Force -Path $Destination | Out-Null

    $files = git -C $repoRoot -c core.quotePath=false ls-files -- $RelativeSource
    if ($LASTEXITCODE -ne 0) { throw "git ls-files failed for $RelativeSource" }
    foreach ($file in $files) {
        if ([string]::IsNullOrWhiteSpace($file)) { continue }
        if (Test-ReleaseCopyExcluded $file) { continue }
        $sourceFile = Join-Path $repoRoot $file
        $relativeToTree = [System.IO.Path]::GetRelativePath($source, $sourceFile)
        $destinationFile = Join-Path $Destination $relativeToTree
        New-Item -ItemType Directory -Force -Path (Split-Path -Parent $destinationFile) | Out-Null
        Copy-Item -LiteralPath $sourceFile -Destination $destinationFile -Force
    }
}

if ($FromSource) {
    Invoke-FromSourceBuild
    if (-not $PSBoundParameters.ContainsKey('ClientExe')) {
        $ClientExe = Join-Path $repoRoot 'client-src\bin\Release\net48\SWTools.exe'
    }
    if (-not $PSBoundParameters.ContainsKey('AddinDll')) {
        $AddinDll = Join-Path $repoRoot 'client-src-addin\bin\Release\net48\SWTools.dll'
    }
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
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWTools.settings') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWTools Updater.exe') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'SWTools.bmp') $runtimeDir
$copied += Copy-RequiredFile (Join-Path $repoRoot 'help_ru.chm') $runtimeDir 'help.CHM'
Assert-ZToolRsaParity $ClientExe
foreach ($clientBuildFile in @(
    'SWToolsARM.dll',
    'Ribbon.dll',
    'ExpandableGridView.dll',
    'ZTool_rsa.dll',
    'ICSharpCode.SharpZipLib.dll',
    'itextsharp.dll',
    'NPOI.dll',
    'NPOI.OOXML.dll',
    'NPOI.OpenXml4Net.dll',
    'NPOI.OpenXmlFormats.dll'
)) {
    $copied += Copy-ClientBuildOutputFile $ClientExe $clientBuildFile
}
$swTools = Copy-OptionalSolidWorksTools
if ($swTools) { $copied += $swTools }

Copy-GitTrackedTreeFiltered $specTemplatesDirName (Join-Path $runtimeDir $specTemplatesDirName)
Copy-GitTrackedTreeFiltered 'SolidWorksTemplates' (Join-Path $runtimeDir 'SolidWorksTemplates')
& (Join-Path $repoRoot 'client-core\tools\set_bom_template_path.ps1') `
    -Folder $runtimeDir `
    -Settings (Join-Path $runtimeDir 'SWTools.settings')
Copy-GitTrackedTreeFiltered 'license-server' $serverDir
Copy-GitTrackedTreeFiltered 'deploy' (Join-Path $packageRoot 'deploy')
Copy-GitTrackedTreeFiltered 'docs' $docsDir

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
