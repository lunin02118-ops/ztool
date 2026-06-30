<#
.SYNOPSIS
  Build a production Windows client installer for a packaged SWTools runtime.

.DESCRIPTION
  Creates a normal NSIS Setup.exe for the client runtime from an existing
  release package. The installer copies runtime files to Program Files,
  registers SWTools.dll with 64-bit RegAsm, configures the SolidWorks add-in,
  creates Start Menu shortcuts and writes an uninstall entry.

  The installer intentionally does not embed, create or remove license keys.

.EXAMPLE
  ./scripts/build_client_installer.ps1 `
    -PackageRoot ./releases/1.1.0-alfa/package/SWTools-1.1.0-alfa
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageRoot,

    [string]$OutputDir,

    [string]$ProductVersion,

    [string]$PackageName,

    [string]$MakensisPath = "C:\Program Files (x86)\NSIS\makensis.exe",

    [switch]$AllowNonCurrentVersion
)

$ErrorActionPreference = 'Stop'

function Fail([string]$Message) {
    throw "client installer build failed: $Message"
}

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function ConvertTo-NsisLiteral([string]$Value) {
    return $Value.Replace('$', '$$').Replace('"', '$\"')
}

function ConvertTo-Version4([string]$Version) {
    $numbers = @($Version -split '[^\d]+' | Where-Object { $_ -ne '' } | ForEach-Object { [int]$_ })
    if ($numbers.Count -eq 0) { $numbers = @(1, 0, 0) }
    while ($numbers.Count -lt 4) { $numbers += 0 }
    if ($numbers.Count -gt 4) { $numbers = $numbers[0..3] }
    return ($numbers -join '.')
}

function Get-CurrentRepoVersion {
    $versionPath = Join-Path $repoRoot 'VERSION'
    if (-not (Test-Path -LiteralPath $versionPath -PathType Leaf)) {
        Fail "VERSION file missing: $versionPath"
    }
    $version = (Get-Content -LiteralPath $versionPath -Encoding UTF8 -Raw).Trim()
    if (-not $version) { Fail "VERSION file is empty: $versionPath" }
    return $version
}

function Assert-CurrentPackageVersion([string]$CurrentVersion, [object]$Manifest, [string]$PackageRootPath, [string]$ResolvedProductVersion, [string]$ResolvedPackageName) {
    $manifestVersion = if ($Manifest.version) { [string]$Manifest.version } else { "" }
    if (-not $manifestVersion) {
        Fail "manifest.version is empty; cannot verify installer package version"
    }

    $packageLeaf = Split-Path -Leaf $PackageRootPath
    $expectedPackageName = "SWTools-$CurrentVersion"
    $messages = @()
    if ($manifestVersion -ne $CurrentVersion) {
        $messages += "manifest.version='$manifestVersion'"
    }
    if ($ResolvedProductVersion -ne $CurrentVersion) {
        $messages += "ProductVersion='$ResolvedProductVersion'"
    }
    if ($packageLeaf -ne $expectedPackageName) {
        $messages += "PackageRoot leaf='$packageLeaf'"
    }
    if ($ResolvedPackageName -ne $expectedPackageName) {
        $messages += "PackageName='$ResolvedPackageName'"
    }

    if ($messages.Count -gt 0) {
        Fail ("non-current installer package blocked; current VERSION is '$CurrentVersion', expected package '$expectedPackageName', got: " + ($messages -join ', ') + ". Pass -AllowNonCurrentVersion only for explicit historical rebuilds.")
    }
}

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$root = (Resolve-Path -LiteralPath $PackageRoot).Path
$runtimeDir = Join-Path $root 'runtime'
$manifestPath = Join-Path $root 'manifest.json'
$templatePath = Join-Path $repoRoot 'installer\windows-client\SWToolsClient.nsi.in'
$cmgrCleanupScript = Join-Path $repoRoot 'scripts\clean_swtools_commandmanager_tabs.ps1'
$setRuntimePathsScript = Join-Path $repoRoot 'client-core\tools\set_bom_template_path.ps1'

if (-not (Test-Path -LiteralPath $runtimeDir -PathType Container)) { Fail "runtime directory missing: $runtimeDir" }
if (-not (Test-Path -LiteralPath $manifestPath -PathType Leaf)) { Fail "manifest missing: $manifestPath" }
if (-not (Test-Path -LiteralPath $templatePath -PathType Leaf)) { Fail "NSIS template missing: $templatePath" }
if (-not (Test-Path -LiteralPath $cmgrCleanupScript -PathType Leaf)) { Fail "CommandManager cleanup script missing: $cmgrCleanupScript" }
if (-not (Test-Path -LiteralPath $setRuntimePathsScript -PathType Leaf)) { Fail "runtime path patch script missing: $setRuntimePathsScript" }
if (-not (Test-Path -LiteralPath $MakensisPath -PathType Leaf)) { Fail "makensis not found: $MakensisPath" }

$manifest = Get-Content -LiteralPath $manifestPath -Encoding UTF8 -Raw | ConvertFrom-Json
if (-not $PackageName) {
    $PackageName = if ($manifest.package) { [string]$manifest.package } else { Split-Path -Leaf $root }
}
if (-not $ProductVersion) {
    $ProductVersion = if ($manifest.version) { [string]$manifest.version } else { '1.0.0' }
}
if (-not $AllowNonCurrentVersion) {
    Assert-CurrentPackageVersion `
        -CurrentVersion (Get-CurrentRepoVersion) `
        -Manifest $manifest `
        -PackageRootPath $root `
        -ResolvedProductVersion $ProductVersion `
        -ResolvedPackageName $PackageName
} else {
    Write-Warning "Building installer for a non-current package is explicitly allowed by -AllowNonCurrentVersion."
}
if (-not $OutputDir) {
    $packageParent = Split-Path -Parent $root
    if ((Split-Path -Leaf $packageParent) -eq 'package') {
        $OutputDir = Split-Path -Parent $packageParent
    } else {
        $OutputDir = Join-Path $packageParent 'client-installer'
    }
}

$runtimeExe = Join-Path $runtimeDir 'SWTools.exe'
$runtimeDll = Join-Path $runtimeDir 'SWTools.dll'
$runtimeRsaDll = Join-Path $runtimeDir 'ZTool_rsa.dll'
if (-not (Test-Path -LiteralPath $runtimeExe -PathType Leaf)) { Fail "SWTools.exe missing: $runtimeExe" }
if (-not (Test-Path -LiteralPath $runtimeDll -PathType Leaf)) { Fail "SWTools.dll missing: $runtimeDll" }
if (-not (Test-Path -LiteralPath $runtimeRsaDll -PathType Leaf)) { Fail "ZTool_rsa.dll missing: $runtimeRsaDll" }

New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null
$outputDirPath = (Resolve-Path -LiteralPath $OutputDir).Path
$setupPath = Join-Path $outputDirPath "$PackageName-Setup.exe"
$generatedNsiPath = Join-Path $outputDirPath "$PackageName-Setup.generated.nsi"
$buildManifestPath = Join-Path $outputDirPath "$PackageName-Setup.manifest.json"
$logPath = Join-Path $outputDirPath "$PackageName-Setup.build.log"

$template = Get-Content -LiteralPath $templatePath -Encoding UTF8 -Raw
$replacements = @{
    '@@PRODUCT_VERSION@@' = ConvertTo-NsisLiteral $ProductVersion
    '@@PRODUCT_VERSION_4@@' = ConvertTo-Version4 $ProductVersion
    '@@PACKAGE_NAME@@' = ConvertTo-NsisLiteral $PackageName
    '@@SOURCE_RUNTIME@@' = ConvertTo-NsisLiteral $runtimeDir
    '@@OUTPUT_SETUP@@' = ConvertTo-NsisLiteral $setupPath
    '@@CLEAN_CMGR_SCRIPT@@' = ConvertTo-NsisLiteral $cmgrCleanupScript
    '@@SET_RUNTIME_PATHS_SCRIPT@@' = ConvertTo-NsisLiteral $setRuntimePathsScript
}
$generated = $template
foreach ($key in $replacements.Keys) {
    $generated = $generated.Replace($key, $replacements[$key])
}

$utf8NoBom = New-Object System.Text.UTF8Encoding($false)
[System.IO.File]::WriteAllText($generatedNsiPath, $generated, $utf8NoBom)

if (Test-Path -LiteralPath $setupPath) {
    Remove-Item -LiteralPath $setupPath -Force
}

$buildOutput = & $MakensisPath /V2 $generatedNsiPath 2>&1
$buildExitCode = $LASTEXITCODE
[System.IO.File]::WriteAllText(
    $logPath,
    (($buildOutput | ForEach-Object { [string]$_ }) -join [Environment]::NewLine),
    [System.Text.UTF8Encoding]::new($false)
)
if ($buildExitCode -ne 0) {
    Fail "makensis failed with exit code $buildExitCode; log: $logPath"
}
if (-not (Test-Path -LiteralPath $setupPath -PathType Leaf)) {
    Fail "makensis reported success but setup was not created: $setupPath"
}

$runtimeFiles = @(Get-ChildItem -LiteralPath $runtimeDir -File -Recurse)
$installerManifest = [ordered]@{
    generated_at = (Get-Date).ToUniversalTime().ToString('o')
    source_package = $root
    package_name = $PackageName
    product_version = $ProductVersion
    setup = [ordered]@{
        path = $setupPath
        sha256 = Get-Sha256 $setupPath
        size_bytes = (Get-Item -LiteralPath $setupPath).Length
    }
    source_runtime = [ordered]@{
        path = $runtimeDir
        file_count = $runtimeFiles.Count
        total_size_bytes = ($runtimeFiles | Measure-Object -Property Length -Sum).Sum
        swtools_exe_sha256 = Get-Sha256 $runtimeExe
        swtools_dll_sha256 = Get-Sha256 $runtimeDll
        ztool_rsa_dll_sha256 = Get-Sha256 $runtimeRsaDll
    }
    installer_behavior = [ordered]@{
        install_dir = '%ProgramFiles%\SWTools'
        requires_admin = $true
        requires_64_bit_windows = $true
        registers_com_with_regasm = $true
        configures_solidworks_addin = $true
        patches_runtime_settings_paths_on_install = $true
        preserves_license_state_on_uninstall = $true
    }
    tooling = [ordered]@{
        makensis = $MakensisPath
        nsis_version = (& $MakensisPath /VERSION)
        generated_script = $generatedNsiPath
        build_log = $logPath
    }
}

$installerManifest | ConvertTo-Json -Depth 6 | Set-Content -LiteralPath $buildManifestPath -Encoding UTF8

Write-Host "client installer: $setupPath" -ForegroundColor Green
Write-Host "manifest: $buildManifestPath" -ForegroundColor Green
Write-Host "sha256: $($installerManifest.setup.sha256)" -ForegroundColor Green
