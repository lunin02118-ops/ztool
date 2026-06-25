<#
.SYNOPSIS
  Release-grade SWTools E2E wrapper for the self-hosted SolidWorks runner.

.DESCRIPTION
  Runs the existing source-build/S7/S8/branding orchestrator with strict release
  assertions and optionally validates the full visual-localization manifest.
  This script never sets production_go_allowed=true; final GO belongs to the
  release dossier / owner approval layer.
#>
param(
    [string]$SolidWorksExe = '',
    [string]$SolidWorksDir = '',
    [string]$SolidWorksToolsDll = '',
    [string]$TestAssembly = '',
    [string]$OutputDir = '',
    [string]$VisualManifest = '',

    [int]$ExpectedMinRows = 29,
    [int]$ExpectedMinColumns = 30,
    [int]$ExpectedBomModeCount = 8,

    [switch]$RequireVisualFullProfile,
    [switch]$AllowWarn,
    [switch]$AllowMissingSolidWorksTools
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

function Get-RepoRoot {
    $root = (& git rev-parse --show-toplevel 2>$null)
    if (-not $root) {
        throw 'Cannot resolve repository root. Run from inside the repo checkout.'
    }
    return [System.IO.Path]::GetFullPath($root.Trim())
}

function New-ReportDir {
    param([string]$Path)
    if ($Path) {
        $resolved = [System.IO.Path]::GetFullPath($Path)
    }
    else {
        $stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
        $resolved = Join-Path (Join-Path (Get-RepoRoot) '_local_artifacts\reports') "release-e2e-solidworks-$stamp"
    }
    New-Item -ItemType Directory -Force -Path $resolved | Out-Null
    New-Item -ItemType Directory -Force -Path (Join-Path $resolved 'logs') | Out-Null
    return $resolved
}

function Normalize-E2EEnvironment {
    $windir = $env:WINDIR
    if (-not $windir) { $windir = $env:SystemRoot }
    if (-not $windir) { $windir = 'C:\Windows' }
    $env:WINDIR = $windir
    $env:SystemRoot = $windir
    if (-not $env:ComSpec) { $env:ComSpec = Join-Path $windir 'System32\cmd.exe' }
}

function Invoke-LoggedCommand {
    param(
        [string]$Name,
        [string]$FilePath,
        [string[]]$Arguments,
        [string]$LogPath
    )
    $parent = Split-Path -Parent $LogPath
    if ($parent) { New-Item -ItemType Directory -Force -Path $parent | Out-Null }
    $output = & $FilePath @Arguments 2>&1
    $exitCode = $LASTEXITCODE
    $output | Set-Content -LiteralPath $LogPath -Encoding UTF8
    if ($exitCode -ne 0) {
        throw "$Name failed with exit code $exitCode; see $LogPath"
    }
}

function Read-JsonFile {
    param([string]$Path)
    return Get-Content -LiteralPath $Path -Encoding UTF8 -Raw | ConvertFrom-Json
}

$repoRoot = Get-RepoRoot
Normalize-E2EEnvironment
$OutputDir = New-ReportDir -Path $OutputDir

$e2eResultPath = Join-Path $OutputDir 'e2e-result.json'
$wrapperResultPath = Join-Path $OutputDir 'release-e2e-solidworks-result.json'

$result = [ordered]@{
    status = 'FAIL'
    production_go_allowed = $false
    created_utc = [DateTimeOffset]::UtcNow.ToString('o')
    output_dir = $OutputDir
    e2e_result_json = $e2eResultPath
    visual_manifest = $VisualManifest
    require_visual_full_profile = [bool]$RequireVisualFullProfile
    stages = @()
    errors = @()
}

try {
    $orchestratorArgs = @(
        '-NoProfile', '-ExecutionPolicy', 'Bypass',
        '-File', (Join-Path $repoRoot 'scripts\e2e\Invoke-SWToolsE2E.ps1'),
        '-BuildFromSource',
        '-RunS7',
        '-RunS8',
        '-RunBrandingVersion',
        '-RequireSolidWorks',
        '-RequireStrictBomFilters',
        '-PrepareStrictBomFixture',
        '-ForceStrictBomFixture',
        '-ExpectedMinRows', ([string]$ExpectedMinRows),
        '-ExpectedMinColumns', ([string]$ExpectedMinColumns),
        '-ExpectedBomModeCount', ([string]$ExpectedBomModeCount),
        '-OutputDir', $OutputDir
    )
    if ($SolidWorksExe) { $orchestratorArgs += @('-SolidWorksExe', $SolidWorksExe) }
    if ($SolidWorksDir) { $orchestratorArgs += @('-SolidWorksDir', $SolidWorksDir) }
    if ($SolidWorksToolsDll) { $orchestratorArgs += @('-SolidWorksToolsDll', $SolidWorksToolsDll) }
    if ($TestAssembly) { $orchestratorArgs += @('-TestAssembly', $TestAssembly) }
    if ($AllowMissingSolidWorksTools) { $orchestratorArgs += '-AllowMissingSolidWorksTools' }

    Invoke-LoggedCommand `
        -Name 'release e2e orchestrator' `
        -FilePath 'pwsh' `
        -Arguments $orchestratorArgs `
        -LogPath (Join-Path $OutputDir 'logs\release-e2e-orchestrator.log')
    $result.stages += [ordered]@{ name = 'release-e2e-orchestrator'; status = 'PASS' }

    $assertArgs = @(
        (Join-Path $repoRoot 'tools\e2e\assert_e2e_result.py'),
        $e2eResultPath,
        '--require-stage-pass', '00-doctor',
        '--require-stage-pass', '01-resolve-build-source-inputs',
        '--require-stage-pass', '02-build-package',
        '--require-stage-pass', '03-verify-package',
        '--require-stage-pass', '04-runtime-identity',
        '--require-stage-pass', '05-preflight-register',
        '--require-stage-pass', '06-prepare-strict-bom-fixture',
        '--require-stage-pass', '07-s7-connect',
        '--require-stage-pass', '08-s8-bom-export',
        '--require-stage-pass', '09-excel-validation',
        '--require-stage-pass', '10-branding-version',
        '--require-stage-pass', '12-finalize',
        '--require-s7-min-rows', ([string]$ExpectedMinRows),
        '--require-s7-min-columns', ([string]$ExpectedMinColumns),
        '--require-s7-model-ready',
        '--require-s8-mode-count', ([string]$ExpectedBomModeCount),
        '--require-s8-all-pass',
        '--require-s8-strict-filters',
        '--require-branding-version'
    )
    if ($AllowWarn) { $assertArgs += '--allow-warn' }

    Invoke-LoggedCommand `
        -Name 'release e2e result assertion' `
        -FilePath 'python' `
        -Arguments $assertArgs `
        -LogPath (Join-Path $OutputDir 'logs\release-e2e-assert.log')
    $result.stages += [ordered]@{ name = 'release-e2e-assert'; status = 'PASS' }

    if ($RequireVisualFullProfile) {
        if (-not $VisualManifest) {
            throw '-RequireVisualFullProfile requires -VisualManifest pointing at the cumulative L-01..L-15 manifest.'
        }
        if (-not (Test-Path -LiteralPath $VisualManifest -PathType Leaf)) {
            throw "Visual manifest not found: $VisualManifest"
        }
        $visualArgs = @(
            (Join-Path $repoRoot 'tools\e2e\assert_visual_localization_manifest.py'),
            $VisualManifest,
            '--allow-warn',
            '--require-surface-file', (Join-Path $repoRoot 'docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json'),
            '--require-profile-surfaces-captured',
            '--require-runtime-match',
            '--require-opener-evidence'
        )
        Invoke-LoggedCommand `
            -Name 'visual localization full-profile assertion' `
            -FilePath 'python' `
            -Arguments $visualArgs `
            -LogPath (Join-Path $OutputDir 'logs\visual-localization-assert.log')
        $result.stages += [ordered]@{ name = 'visual-localization-full-profile'; status = 'PASS' }
    }
    else {
        $result.stages += [ordered]@{ name = 'visual-localization-full-profile'; status = 'SKIP'; summary = 'RequireVisualFullProfile not set' }
    }

    $e2eResult = Read-JsonFile -Path $e2eResultPath
    $result.status = 'PASS'
    $result.e2e_status = $e2eResult.status
    $result.e2e_production_go_allowed = [bool]$e2eResult.production_go_allowed
    $result.production_go_allowed = $false
}
catch {
    $result.errors += $_.Exception.Message
    $result.status = 'FAIL'
    $result.production_go_allowed = $false
    $result | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath $wrapperResultPath -Encoding UTF8
    throw
}

$result | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath $wrapperResultPath -Encoding UTF8
Write-Host "Release E2E result: $wrapperResultPath"
