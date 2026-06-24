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
    [string]$ClientExe = "",
    [string]$AddinDll = "",
    [string]$SolidWorksToolsDll = "",
    [switch]$AllowMissingSolidWorksTools,
    [switch]$UseAcceptedRuntimeSnapshot
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

function Get-FullPath([string]$Path) {
    return [System.IO.Path]::GetFullPath($Path)
}

function Test-IsSubPath([string]$Path, [string]$Parent) {
    $full = Get-FullPath $Path
    $parentFull = (Get-FullPath $Parent).TrimEnd('\') + '\'
    return $full.StartsWith($parentFull, [System.StringComparison]::OrdinalIgnoreCase)
}

function Get-FileVersionInfoObject([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "required build input missing: $Path"
    }
    return [System.Diagnostics.FileVersionInfo]::GetVersionInfo((Get-FullPath $Path))
}

function Assert-ArtifactVersion([string]$Path, [string]$Kind) {
    $info = Get-FileVersionInfoObject $Path
    if ($info.ProductName -ne 'SWTools') {
        throw "$Kind ProductName mismatch for $Path; expected SWTools, got '$($info.ProductName)'"
    }
    if (-not $info.ProductVersion -or -not $info.ProductVersion.StartsWith($Version, [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "$Kind ProductVersion mismatch for $Path; expected prefix $Version, got '$($info.ProductVersion)'"
    }
    if (-not $info.FileVersion -or -not $info.FileVersion.StartsWith("$Version.", [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "$Kind FileVersion mismatch for $Path; expected prefix $Version., got '$($info.FileVersion)'"
    }
}

function Resolve-ReleaseInput([string]$Provided, [string]$SourceDefault, [string]$LegacyRoot, [string]$Kind, [string]$SourceParent) {
    $path = if ($Provided) { $Provided } elseif ($UseAcceptedRuntimeSnapshot) { $LegacyRoot } else { $SourceDefault }
    $full = Get-FullPath $path
    if (-not (Test-Path -LiteralPath $full -PathType Leaf)) {
        throw "$Kind input missing: $full. Build sources first or pass -UseAcceptedRuntimeSnapshot intentionally."
    }

    $isLegacyRoot = [string]::Equals($full, (Get-FullPath $LegacyRoot), [System.StringComparison]::OrdinalIgnoreCase)
    $isSourceOutput = Test-IsSubPath $full $SourceParent
    if ($isLegacyRoot -and -not $UseAcceptedRuntimeSnapshot) {
        throw "$Kind points to legacy root runtime artifact: $full. Use source build output or pass -UseAcceptedRuntimeSnapshot."
    }
    if (-not $UseAcceptedRuntimeSnapshot -and -not $isSourceOutput) {
        throw "$Kind must come from source build output under $SourceParent; got $full"
    }
    if ($UseAcceptedRuntimeSnapshot -and -not $isLegacyRoot) {
        throw "-UseAcceptedRuntimeSnapshot was passed, but $Kind is not the root accepted artifact: $full"
    }

    return $full
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

$ClientExe = Resolve-ReleaseInput `
    -Provided $ClientExe `
    -SourceDefault (Join-Path $repoRoot 'client-src\bin\Release\net48\SWTools.exe') `
    -LegacyRoot (Join-Path $repoRoot 'SWTools.exe') `
    -Kind 'ClientExe' `
    -SourceParent (Join-Path $repoRoot 'client-src\bin')
$AddinDll = Resolve-ReleaseInput `
    -Provided $AddinDll `
    -SourceDefault (Join-Path $repoRoot 'client-src-addin\bin\Release\net48\SWTools.dll') `
    -LegacyRoot (Join-Path $repoRoot 'SWTools.dll') `
    -Kind 'AddinDll' `
    -SourceParent (Join-Path $repoRoot 'client-src-addin\bin')
Assert-ArtifactVersion $ClientExe 'SWTools.exe'
Assert-ArtifactVersion $AddinDll 'SWTools.dll'

if (Test-Path -LiteralPath $packageRoot) { throw "package output already exists: $packageRoot" }
New-Item -ItemType Directory -Force -Path $runtimeDir, $serverDir, $docsDir | Out-Null

$clientVersionInfo = Get-FileVersionInfoObject $ClientExe
$addinVersionInfo = Get-FileVersionInfoObject $AddinDll
$inputMode = if ($UseAcceptedRuntimeSnapshot) { 'accepted-runtime-snapshot' } else { 'source-build-output' }
$releaseInputs = [ordered]@{
    input_mode = $inputMode
    version = $Version
    generated_at = (Get-Date).ToUniversalTime().ToString('o')
    git = [ordered]@{
        commit = (& git -C $repoRoot rev-parse HEAD 2>$null)
        branch = (& git -C $repoRoot rev-parse --abbrev-ref HEAD 2>$null)
        dirty = [bool](& git -C $repoRoot status --porcelain 2>$null)
    }
    client_exe = [ordered]@{
        path = $ClientExe
        repo_relative_path = [System.IO.Path]::GetRelativePath($repoRoot, $ClientExe).Replace('\', '/')
        sha256 = Get-Sha256 $ClientExe
        product_name = $clientVersionInfo.ProductName
        product_version = $clientVersionInfo.ProductVersion
        file_version = $clientVersionInfo.FileVersion
    }
    addin_dll = [ordered]@{
        path = $AddinDll
        repo_relative_path = [System.IO.Path]::GetRelativePath($repoRoot, $AddinDll).Replace('\', '/')
        sha256 = Get-Sha256 $AddinDll
        product_name = $addinVersionInfo.ProductName
        product_version = $addinVersionInfo.ProductVersion
        file_version = $addinVersionInfo.FileVersion
        brand_patch_applied_after_copy = $true
    }
}
Write-Utf8NoBom (Join-Path $packageRoot 'release-inputs.json') @(($releaseInputs | ConvertTo-Json -Depth 10))

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
        input_mode = $inputMode
        release_inputs_json = 'release-inputs.json'
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
