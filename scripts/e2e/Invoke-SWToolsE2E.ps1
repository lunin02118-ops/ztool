<#
.SYNOPSIS
  SWTools E2E foundation orchestrator.

.DESCRIPTION
  Produces machine-readable E2E evidence and optionally chains existing build,
  package, preflight and live S7 scripts. Foundation mode is intentionally
  conservative: production_go_allowed is always false and live SolidWorks steps
  only run when explicitly requested.
#>
param(
    [switch]$DoctorOnly,
    [switch]$BuildFromSource,
    [switch]$RunS7,
    [switch]$RunS8,
    [switch]$RunBrandingVersion,
    [switch]$RequireSolidWorks,

    [string]$InstallRoot = '',
    [string]$PackageRoot = '',
    [string]$RuntimeDir = '',
    [string]$SolidWorksExe = '',
    [string]$SolidWorksDir = '',
    [string]$SolidWorksToolsDll = '',
    [string]$TestAssembly = '',
    [string]$OutputDir = '',
    [string]$StrictFixtureDir = '',

    [int[]]$RequireBomModes = @(1, 2, 3, 4, 5, 6, 7, 8),
    [int]$ExpectedMinRows = 29,
    [int]$ExpectedMinColumns = 30,
    [int]$ExpectedBomModeCount = 8,
    [switch]$RequireStrictBomFilters,
    [switch]$PrepareStrictBomFixture,
    [switch]$ForceStrictBomFixture,
    [switch]$AllowDirtyManifest,
    [switch]$AllowMissingSolidWorksTools
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

$common = Join-Path $PSScriptRoot 'lib\E2E.Common.psm1'
$doctor = Join-Path $PSScriptRoot 'lib\E2E.Doctor.psm1'
Import-Module $common -Force
Import-Module $doctor -Force

function Normalize-E2EEnvironment {
    $windir = $env:WINDIR
    if (-not $windir) { $windir = $env:SystemRoot }
    if (-not $windir) { $windir = 'C:\Windows' }
    $env:WINDIR = $windir
    $env:SystemRoot = $windir
    if (-not $env:ComSpec) { $env:ComSpec = Join-Path $windir 'System32\cmd.exe' }
}

function Get-PwshCommand {
    $pwsh = Get-Command pwsh -ErrorAction SilentlyContinue
    if ($pwsh) { return $pwsh.Source }
    return (Get-Command powershell -ErrorAction Stop).Source
}

function Read-JsonFile {
    param([string]$Path)
    return Get-Content -LiteralPath $Path -Encoding UTF8 -Raw | ConvertFrom-Json
}

function Resolve-PackageRootFromOutput {
    param(
        [string]$OutputRoot,
        [string]$Version
    )
    return Join-Path ([System.IO.Path]::GetFullPath($OutputRoot)) "SWTools-$Version"
}

$repoRoot = Get-E2ERepoRoot
Normalize-E2EEnvironment
$OutputDir = New-E2EReportDir -OutputDir $OutputDir
$result = New-E2EResult -OutputDir $OutputDir -Mode 'foundation'
$result.parameters = [ordered]@{
    doctor_only = [bool]$DoctorOnly
    build_from_source = [bool]$BuildFromSource
    run_s7 = [bool]$RunS7
    run_s8 = [bool]$RunS8
    run_branding_version = [bool]$RunBrandingVersion
    require_solidworks = [bool]$RequireSolidWorks
    install_root = $InstallRoot
    package_root = $PackageRoot
    runtime_dir = $RuntimeDir
    solidworks_exe = $SolidWorksExe
    solidworks_dir = $SolidWorksDir
    solidworks_tools_dll = $SolidWorksToolsDll
    test_assembly = $TestAssembly
    strict_fixture_dir = $StrictFixtureDir
    prepare_strict_bom_fixture = [bool]$PrepareStrictBomFixture
    require_bom_modes = $RequireBomModes
    expected_min_rows = $ExpectedMinRows
    expected_min_columns = $ExpectedMinColumns
    expected_bom_mode_count = $ExpectedBomModeCount
    require_strict_bom_filters = [bool]$RequireStrictBomFilters
}

$resultPath = Join-Path $OutputDir 'e2e-result.json'
$summaryPath = Join-Path $OutputDir 'e2e-summary.md'

try {
    $doctorResult = Invoke-E2EDoctor `
        -SolidWorksExe $SolidWorksExe `
        -SolidWorksDir $SolidWorksDir `
        -SolidWorksToolsDll $SolidWorksToolsDll `
        -TestAssembly $TestAssembly `
        -RequireSolidWorks:$RequireSolidWorks
    Add-E2EStage -Result $result -Name '00-doctor' -Status $doctorResult.status -Summary 'environment doctor completed' -Details $doctorResult
    $result.artifacts.doctor_json = Join-Path $OutputDir 'doctor.json'
    Write-E2EJson -Path $result.artifacts.doctor_json -Value $doctorResult

    if ($DoctorOnly) {
        Add-E2EStage -Result $result -Name '12-finalize' -Status 'PASS' -Summary 'doctor-only run completed'
        Write-E2EJson -Path $resultPath -Value $result
        Write-E2ESummary -Result $result -Path $summaryPath
        Write-Host "E2E result: $resultPath"
        exit 0
    }

    $pwsh = Get-PwshCommand
    $releaseInputsPath = Join-Path $OutputDir 'release-inputs.json'
    $packageOutputRoot = if ($PackageRoot) { $PackageRoot } else { Join-Path $OutputDir 'package' }
    $version = (Get-Content -LiteralPath (Join-Path $repoRoot 'VERSION') -Encoding UTF8 -Raw).Trim()
    $runtimeClientHash = ''
    $runtimeAddinHash = ''

    if ($BuildFromSource) {
        $resolveArgs = @(
            '-NoProfile', '-File', (Join-Path $repoRoot 'scripts\resolve_release_inputs.ps1'),
            '-OutputPath', $releaseInputsPath
        )
        if ($SolidWorksDir) { $resolveArgs += @('-SolidWorksDir', $SolidWorksDir) }
        if ($SolidWorksToolsDll) { $resolveArgs += @('-SolidWorksToolsPath', $SolidWorksToolsDll) }
        $resolveLog = Join-Path $OutputDir 'logs\01-resolve-release-inputs.log'
        $resolve = Invoke-E2ECommand -Name 'resolve_release_inputs' -FilePath $pwsh -Arguments $resolveArgs -LogPath $resolveLog
        if ($resolve.exit_code -ne 0) { throw "resolve_release_inputs failed; see $resolveLog" }
        Add-E2EStage -Result $result -Name '01-resolve-build-source-inputs' -Status 'PASS' -Summary 'source inputs built/resolved' -Details @{ log = $resolveLog; output = $releaseInputsPath }
        $result.artifacts.release_inputs_json = $releaseInputsPath

        $releaseInputs = Read-JsonFile $releaseInputsPath
        $buildArgs = @(
            '-NoProfile', '-File', (Join-Path $repoRoot 'scripts\build_release_package.ps1'),
            '-OutputRoot', $packageOutputRoot,
            '-ClientExe', [string]$releaseInputs.client_exe.path,
            '-AddinDll', [string]$releaseInputs.addin_dll.path
        )
        if ($SolidWorksToolsDll) {
            $buildArgs += @('-SolidWorksToolsDll', $SolidWorksToolsDll)
        }
        elseif ($AllowMissingSolidWorksTools) {
            $buildArgs += '-AllowMissingSolidWorksTools'
        }
        $buildLog = Join-Path $OutputDir 'logs\02-build-package.log'
        $build = Invoke-E2ECommand -Name 'build_release_package' -FilePath $pwsh -Arguments $buildArgs -LogPath $buildLog
        if ($build.exit_code -ne 0) { throw "build_release_package failed; see $buildLog" }
        $packageDir = Resolve-PackageRootFromOutput -OutputRoot $packageOutputRoot -Version $version
        $RuntimeDir = Join-Path $packageDir 'runtime'
        Add-E2EStage -Result $result -Name '02-build-package' -Status 'PASS' -Summary 'release package built' -Details @{ log = $buildLog; package_root = $packageDir; runtime_dir = $RuntimeDir }
        $result.artifacts.package_root = $packageDir
        $result.artifacts.runtime_dir = $RuntimeDir

        $clientHash = (Get-E2EFileSha256 -Path (Join-Path $RuntimeDir 'SWTools.exe'))
        $addinHash = (Get-E2EFileSha256 -Path (Join-Path $RuntimeDir 'SWTools.dll'))
        $verifyArgs = @(
            '-NoProfile', '-File', (Join-Path $repoRoot 'scripts\verify_release_package.ps1'),
            '-PackageRoot', $packageDir,
            '-ExpectedClientExeSha256', $clientHash,
            '-ExpectedAddinDllSha256', $addinHash
        )
        if ($SolidWorksToolsDll) { $verifyArgs += '-RequireSolidWorksTools' }
        if ($AllowDirtyManifest) { $verifyArgs += '-AllowDirtyManifest' }
        $verifyLog = Join-Path $OutputDir 'logs\03-verify-package.log'
        $verify = Invoke-E2ECommand -Name 'verify_release_package' -FilePath $pwsh -Arguments $verifyArgs -LogPath $verifyLog
        if ($verify.exit_code -ne 0) { throw "verify_release_package failed; see $verifyLog" }
        Add-E2EStage -Result $result -Name '03-verify-package' -Status 'PASS' -Summary 'release package verified with source-build hashes' -Details @{ log = $verifyLog; client_sha256 = $clientHash; addin_sha256 = $addinHash }
    }
    elseif (-not $RuntimeDir) {
        Add-E2EStage -Result $result -Name '01-resolve-build-source-inputs' -Status 'SKIP' -Summary 'pass -BuildFromSource or -RuntimeDir to continue beyond doctor'
    }

    if ($RuntimeDir) {
        $runtimeClientHash = (Get-E2EFileSha256 -Path (Join-Path $RuntimeDir 'SWTools.exe'))
        $runtimeAddinHash = (Get-E2EFileSha256 -Path (Join-Path $RuntimeDir 'SWTools.dll'))
        $identityPath = Join-Path $OutputDir 'runtime-identity.json'
        $identityArgs = @(
            '-NoProfile', '-File', (Join-Path $repoRoot 'scripts\check_swtools_runtime_identity.ps1'),
            '-RuntimeDir', $RuntimeDir,
            '-JsonOut', $identityPath
        )
        $identityLog = Join-Path $OutputDir 'logs\04-runtime-identity.log'
        $identity = Invoke-E2ECommand -Name 'check_swtools_runtime_identity' -FilePath $pwsh -Arguments $identityArgs -LogPath $identityLog
        if ($identity.exit_code -ne 0) { throw "check_swtools_runtime_identity failed; see $identityLog" }
        Add-E2EStage -Result $result -Name '04-runtime-identity' -Status 'PASS' -Summary 'runtime identity verified' -Details @{ log = $identityLog; json = $identityPath }
        $result.artifacts.runtime_identity_json = $identityPath
    }

    if ($RunS8 -and -not $RunS7) {
        throw '-RunS8 requires -RunS7 so the BOM export starts from a proven connected SolidWorks grid'
    }

    if ($RunS7) {
        if (-not $RuntimeDir) { throw '-RunS7 requires -RuntimeDir or -BuildFromSource' }
        if (-not $TestAssembly -and $env:SWTOOLS_TEST_MODEL) { $TestAssembly = $env:SWTOOLS_TEST_MODEL }
        if (-not $TestAssembly) { throw '-RunS7 requires -TestAssembly or SWTOOLS_TEST_MODEL' }

        $preflightDir = Join-Path $OutputDir '05-preflight-register'
        $preflightArgs = @(
            '-NoProfile', '-File', (Join-Path $repoRoot 'scripts\sw_test_preflight.ps1'),
            '-RuntimeDir', $RuntimeDir,
            '-ReportDir', $preflightDir,
            '-Register',
            '-ExpectedExeSha256', $runtimeClientHash,
            '-ExpectedDllSha256', $runtimeAddinHash
        )
        $preflightLog = Join-Path $OutputDir 'logs\05-preflight-register.log'
        $preflight = Invoke-E2ECommand -Name 'sw_test_preflight' -FilePath $pwsh -Arguments $preflightArgs -LogPath $preflightLog
        if ($preflight.exit_code -ne 0) { throw "sw_test_preflight failed; see $preflightLog" }
        $preflightJson = Join-Path $preflightDir 'preflight-report.json'
        $preflightResult = Read-JsonFile $preflightJson
        Add-E2EStage -Result $result -Name '05-preflight-register' -Status 'PASS' -Summary "runtime registered for live S7: $($preflightResult.status)" -Details @{
            log = $preflightLog
            report_dir = $preflightDir
            result_json = $preflightJson
            status = $preflightResult.status
            runtime_dir = $preflightResult.runtimeDir
            swtools_exe_sha256 = $preflightResult.swtoolsExe.sha256
            swtools_dll_sha256 = $preflightResult.swtoolsDll.sha256
        }
        $result.artifacts.preflight_register_json = $preflightJson

        if ($PrepareStrictBomFixture) {
            if (-not $TestAssembly -and $env:SWTOOLS_TEST_MODEL) { $TestAssembly = $env:SWTOOLS_TEST_MODEL }
            if (-not $TestAssembly) { throw '-PrepareStrictBomFixture requires -TestAssembly or SWTOOLS_TEST_MODEL' }
            $fixtureDir = $StrictFixtureDir
            if (-not $fixtureDir) {
                $fixtureDir = Join-Path $OutputDir 'strict-fixture\TestModel-RU'
            }
            elseif (-not [System.IO.Path]::IsPathRooted($fixtureDir)) {
                $fixtureDir = Join-Path $repoRoot $fixtureDir
            }
            $fixtureManifest = Join-Path $fixtureDir 'fixture-manifest.json'
            $fixtureArgs = @(
                (Join-Path $repoRoot 'scripts\prepare_s8_strict_fixture.py'),
                '--source-assembly', $TestAssembly,
                '--fixture-dir', $fixtureDir,
                '--manifest', $fixtureManifest
            )
            if ($ForceStrictBomFixture) { $fixtureArgs += '--force' }
            $fixtureLog = Join-Path $OutputDir 'logs\06-prepare-strict-bom-fixture.log'
            $fixture = Invoke-E2ECommand -Name 'prepare_s8_strict_fixture' -FilePath 'python' -Arguments $fixtureArgs -LogPath $fixtureLog
            if ($fixture.exit_code -ne 0) { throw "prepare_s8_strict_fixture failed; see $fixtureLog" }
            $fixtureResult = Read-JsonFile $fixtureManifest
            $TestAssembly = [string]$fixtureResult.assembly_path
            Add-E2EStage -Result $result -Name '06-prepare-strict-bom-fixture' -Status 'PASS' -Summary "strict S8 fixture prepared: $TestAssembly" -Details @{
                log = $fixtureLog
                fixture_dir = $fixtureDir
                manifest = $fixtureManifest
                assembly_path = $fixtureResult.assembly_path
                type_counts_by_document = $fixtureResult.type_counts_by_document
                expected_modes = $fixtureResult.expected_modes
            }
            $result.artifacts.strict_fixture_manifest = $fixtureManifest
            $result.artifacts.strict_fixture_assembly = $TestAssembly
        }

        $s7Dir = Join-Path $OutputDir 's7-live-smoke'
        $s7Args = @(
            (Join-Path $repoRoot 'scripts\swtools_s7_live_smoke.py'),
            '--runtime-dir', $RuntimeDir,
            '--model', $TestAssembly,
            '--report-dir', $s7Dir,
            '--expected-min-rows', ([string]$ExpectedMinRows),
            '--expected-min-columns', ([string]$ExpectedMinColumns)
        )
        $s7Log = Join-Path $OutputDir 'logs\07-s7-live-smoke.log'
        $s7 = Invoke-E2ECommand -Name 'swtools_s7_live_smoke' -FilePath 'python' -Arguments $s7Args -LogPath $s7Log -TimeoutSeconds 180
        if ($s7.exit_code -ne 0) { throw "S7 live smoke failed; see $s7Log" }
        $s7Json = Join-Path $s7Dir 's7-live-smoke-result.json'
        $s7Result = Read-JsonFile $s7Json
        Add-E2EStage -Result $result -Name '07-s7-connect' -Status 'PASS' -Summary "S7 live smoke completed: rows=$($s7Result.row_count), columns=$($s7Result.column_count)" -Details @{
            log = $s7Log
            report_dir = $s7Dir
            result_json = $s7Json
            row_count = $s7Result.row_count
            column_count = $s7Result.column_count
            swtools_path = $s7Result.swtools_path
            swtools_sha256 = $s7Result.exe_sha256
            addin_sha256 = $s7Result.dll_sha256
            status_text = $s7Result.status_text
        }
        $result.artifacts.s7_report_dir = $s7Dir
        $result.artifacts.s7_connect_json = $s7Json
    }
    else {
        Add-E2EStage -Result $result -Name '07-s7-connect' -Status 'SKIP' -Summary 'live SolidWorks S7 not requested'
    }

    if ($RunS8) {
        if (-not $RuntimeDir) { throw '-RunS8 requires -RuntimeDir or -BuildFromSource' }
        $s8Dir = Join-Path $OutputDir 's8-bom-export'
        $s8ExportDir = Join-Path $s8Dir 'exports'
        $s8Args = @(
            (Join-Path $repoRoot 'scripts\swtools_s8_bom_live.py'),
            '--runtime-dir', $RuntimeDir,
            '--report-dir', $s8Dir,
            '--export-dir', $s8ExportDir,
            '--expected-exe-sha256', $runtimeClientHash,
            '--expected-dll-sha256', $runtimeAddinHash,
            '--expected-mode-count', ([string]$ExpectedBomModeCount),
            '--modes', ($RequireBomModes -join ',')
        )
        if ($RequireStrictBomFilters) { $s8Args += '--strict-filters' }
        $s8Log = Join-Path $OutputDir 'logs\08-s8-bom-export.log'
        $s8 = Invoke-E2ECommand -Name 'swtools_s8_bom_live' -FilePath 'python' -Arguments $s8Args -LogPath $s8Log -TimeoutSeconds 900
        if ($s8.exit_code -ne 0) { throw "S8 BOM export failed; see $s8Log" }
        $s8Json = Join-Path $s8Dir 's8-bom-result.json'
        $s8Result = Read-JsonFile $s8Json
        $modeSummaries = @($s8Result.modes | ForEach-Object {
            $analysisProps = @($_.analysis.PSObject.Properties.Name)
            $filterEmpty = $false
            if ($analysisProps -contains 'filter_empty') { $filterEmpty = [bool]$_.analysis.filter_empty }
            [ordered]@{
                mode_id = $_.mode_id
                file = $_.file
                size = $_.size
                rows = $_.analysis.data_rows
                number = $_.analysis.counts.number
                quantity = $_.analysis.counts.quantity
                weight = $_.analysis.counts.weight
                path = $_.analysis.counts.path
                dimensions = $_.analysis.counts.dimensions
                has_images = $_.analysis.has_images
                filter_empty = $filterEmpty
                modal_button = $_.modal.button
                modal_process_id = $_.modal.process_id
                modal_expected_process_id = $_.modal.expected_process_id
                modal_kind = $_.modal.kind
            }
        })
        Add-E2EStage -Result $result -Name '08-s8-bom-export' -Status 'PASS' -Summary "S8 exported $(@($s8Result.modes).Count) BOM workbook(s)" -Details @{
            log = $s8Log
            report_dir = $s8Dir
            export_dir = $s8ExportDir
            result_json = $s8Json
            mode_count = @($s8Result.modes).Count
            strict_filters = [bool]$RequireStrictBomFilters
            modes = $modeSummaries
        }
        Add-E2EStage -Result $result -Name '09-excel-validation' -Status 'PASS' -Summary 'semantic Excel BOM validation passed' -Details @{
            result_json = $s8Json
            status = $s8Result.status
            issues = @($s8Result.issues)
            mode_count = @($s8Result.modes).Count
            strict_filters = [bool]$RequireStrictBomFilters
        }
        $result.artifacts.s8_report_dir = $s8Dir
        $result.artifacts.s8_export_dir = $s8ExportDir
        $result.artifacts.s8_bom_json = $s8Json
    }
    else {
        Add-E2EStage -Result $result -Name '08-s8-bom-export' -Status 'SKIP' -Summary 'live BOM export automation not requested' -Details @{ require_bom_modes = $RequireBomModes }
        Add-E2EStage -Result $result -Name '09-excel-validation' -Status 'SKIP' -Summary 'semantic Excel validation not requested'
    }
    if ($RunBrandingVersion) {
        if (-not $RuntimeDir) { throw '-RunBrandingVersion requires -RuntimeDir or -BuildFromSource' }
        $brandDir = Join-Path $OutputDir '10-branding-version'
        $brandArgs = @(
            (Join-Path $repoRoot 'scripts\swtools_branding_version_live.py'),
            '--runtime-dir', $RuntimeDir,
            '--report-dir', $brandDir,
            '--repo-root', $repoRoot,
            '--expected-version', $version,
            '--expected-exe-sha256', $runtimeClientHash,
            '--expected-dll-sha256', $runtimeAddinHash
        )
        $brandLog = Join-Path $OutputDir 'logs\10-branding-version.log'
        $brand = Invoke-E2ECommand -Name 'swtools_branding_version_live' -FilePath 'python' -Arguments $brandArgs -LogPath $brandLog -TimeoutSeconds 120
        if ($brand.exit_code -ne 0) { throw "branding/version live evidence failed; see $brandLog" }
        $brandJson = Join-Path $brandDir 'branding-version-result.json'
        $brandResult = Read-JsonFile $brandJson
        Add-E2EStage -Result $result -Name '10-branding-version' -Status 'PASS' -Summary "branding/version live evidence completed: $($brandResult.live_process.window_title)" -Details @{
            log = $brandLog
            report_dir = $brandDir
            result_json = $brandJson
            window_title = $brandResult.live_process.window_title
            expected_title_prefix = $brandResult.live_process.window_title_expected_prefix
            swtools_path = $brandResult.live_process.path
            swtools_sha256 = $brandResult.swtools_exe.sha256
            addin_sha256 = $brandResult.swtools_dll.sha256
            product_version = $brandResult.swtools_exe.version_info.product_version
            file_version = $brandResult.swtools_exe.version_info.file_version
            icon_hash_match = $brandResult.icon_hash_match
            live_window_icon = $brandResult.live_process.window_icon
            embedded_exe_icon = $brandResult.embedded_exe_icon
        }
        $result.artifacts.branding_version_report_dir = $brandDir
        $result.artifacts.branding_version_json = $brandJson
    }
    else {
        Add-E2EStage -Result $result -Name '10-branding-version' -Status 'SKIP' -Summary 'branding/version live evidence not requested'
    }
    Add-E2EStage -Result $result -Name '12-finalize' -Status 'PASS' -Summary 'foundation orchestrator completed; production GO remains false'
    Write-E2EJson -Path $resultPath -Value $result
    Write-E2ESummary -Result $result -Path $summaryPath
    Write-Host "E2E result: $resultPath"
    if ($result.status -eq 'FAIL') { exit 1 }
    exit 0
}
catch {
    Add-E2EError -Result $result -Message $_.Exception.Message
    Write-E2EJson -Path $resultPath -Value $result
    Write-E2ESummary -Result $result -Path $summaryPath
    Write-Error $_
    exit 1
}
