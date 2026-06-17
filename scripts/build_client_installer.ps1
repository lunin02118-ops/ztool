<#
.SYNOPSIS
  Build a production Windows client installer for a packaged ZTool runtime.

.DESCRIPTION
  Creates a normal NSIS Setup.exe for the client runtime from an existing
  release package. The installer copies runtime files to Program Files,
  registers ZTool.dll with 64-bit RegAsm, configures the SolidWorks add-in,
  creates Start Menu shortcuts and writes an uninstall entry.

  The installer intentionally does not embed, create or remove license keys.

.EXAMPLE
  ./scripts/build_client_installer.ps1 `
    -PackageRoot ./release/ZTool-1.0.0-20260617-135653
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageRoot,

    [string]$OutputDir,

    [string]$ProductVersion,

    [string]$PackageName,

    [string]$MakensisPath = "C:\Program Files (x86)\NSIS\makensis.exe"
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

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$root = (Resolve-Path -LiteralPath $PackageRoot).Path
$runtimeDir = Join-Path $root 'runtime'
$manifestPath = Join-Path $root 'manifest.json'
$templatePath = Join-Path $repoRoot 'installer\windows-client\ZToolClient.nsi.in'

if (-not (Test-Path -LiteralPath $runtimeDir -PathType Container)) { Fail "runtime directory missing: $runtimeDir" }
if (-not (Test-Path -LiteralPath $manifestPath -PathType Leaf)) { Fail "manifest missing: $manifestPath" }
if (-not (Test-Path -LiteralPath $templatePath -PathType Leaf)) { Fail "NSIS template missing: $templatePath" }
if (-not (Test-Path -LiteralPath $MakensisPath -PathType Leaf)) { Fail "makensis not found: $MakensisPath" }

$manifest = Get-Content -LiteralPath $manifestPath -Encoding UTF8 -Raw | ConvertFrom-Json
if (-not $PackageName) {
    $PackageName = if ($manifest.package) { [string]$manifest.package } else { Split-Path -Leaf $root }
}
if (-not $ProductVersion) {
    $ProductVersion = if ($manifest.version) { [string]$manifest.version } else { '1.0.0' }
}
if (-not $OutputDir) {
    $OutputDir = Join-Path (Split-Path -Parent $root) 'client-installer'
}

$runtimeExe = Join-Path $runtimeDir 'ZTool.exe'
$runtimeDll = Join-Path $runtimeDir 'ZTool.dll'
if (-not (Test-Path -LiteralPath $runtimeExe -PathType Leaf)) { Fail "ZTool.exe missing: $runtimeExe" }
if (-not (Test-Path -LiteralPath $runtimeDll -PathType Leaf)) { Fail "ZTool.dll missing: $runtimeDll" }

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
$buildOutput | Set-Content -LiteralPath $logPath -Encoding UTF8
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
        ztool_exe_sha256 = Get-Sha256 $runtimeExe
        ztool_dll_sha256 = Get-Sha256 $runtimeDll
    }
    installer_behavior = [ordered]@{
        install_dir = '%ProgramFiles%\ZTool'
        requires_admin = $true
        requires_64_bit_windows = $true
        registers_com_with_regasm = $true
        configures_solidworks_addin = $true
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
