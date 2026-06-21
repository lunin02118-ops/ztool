<#
.SYNOPSIS
  Prepare a clean, reproducible environment for a live SolidWorks/SWTools test run.

.DESCRIPTION
  Automates the manual pre-flight that the executor previously had to run by hand
  (see docs/release/FULL_TEST_METHODOLOGY_RU.md sections 2.1 / 2.2). It addresses
  the three failure modes that break SWTools testing from an automation/agent shell:

    1. Broken launch environment. When SolidWorks/SWTools are started from a shell
       whose WINDIR/SystemRoot are empty, SolidWorks throws a false
       "Failed to load Microsoft .NET Framework" error or hangs on the splash,
       even though launching via the desktop shortcut works. This script
       normalizes WINDIR/SystemRoot/ComSpec and verifies RegAsm is reachable.

    2. Dirty registry / wrong DLL / stale CommandManager tab. Stale RegAsm CodeBase,
       SolidWorks AddIn keys, HKCU\SOFTWARE\SWTools or a legacy ZTool/SWTools
       CommandManager cache from a previous test can make SolidWorks load a
       different SWTools.dll/SWTools.exe or show the old tab. This script backs
       up the affected registry branches, reports stale SWTools references,
       (optionally) re-registers the current runtime SWTools.dll via RegAsm
       /codebase, cleans CommandManager tabs, and verifies the live CodeBase
       points at the runtime folder.

    3. Wrong artifact under test. Optionally verifies the SHA256 of the runtime
       SWTools.exe / SWTools.dll against the accepted hashes so a run cannot silently
       use the wrong binary.

  The script is idempotent and read-mostly: it only writes to the registry when
  -Register (RegAsm + CommandManager cleanup) or -CleanLicenseState is passed,
  and always takes a backup first. It does NOT launch SolidWorks or drive the UI; window normalization and
  object-based UI automation remain in FULL_TEST_METHODOLOGY_RU.md section 2.2.

.PARAMETER RuntimeDir
  Folder that contains the SWTools.exe / SWTools.dll under test (e.g. the release
  package 'runtime' folder, or client-core\dist).

.PARAMETER ReportDir
  Folder where registry backups and the preflight report JSON are written.
  Defaults to manual-test-reports\preflight-<timestamp>.

.PARAMETER Register
  Re-register RuntimeDir\SWTools.dll via RegAsm /codebase (writes registry).

.PARAMETER CleanLicenseState
  Also delete SWTools license-state keys. Only needed for clean-license scenarios;
  do NOT use for ordinary BOM/color/export runs. Writes registry.

.PARAMETER ExpectedExeSha256
  Optional expected SHA256 of RuntimeDir\SWTools.exe. Default is loaded from
  scripts/expected_release_hashes.json (single source of truth, shared with
  verify_release_package.ps1).

.PARAMETER ExpectedDllSha256
  Optional expected SHA256 of RuntimeDir\SWTools.dll (default = accepted hash).

.EXAMPLE
  # Inspect-only pre-flight (no registry writes), verify hashes:
  powershell -NoProfile -ExecutionPolicy Bypass -File scripts\sw_test_preflight.ps1 -RuntimeDir .\runtime

.EXAMPLE
  # Full pre-flight: re-register the current DLL and verify CodeBase:
  powershell -NoProfile -ExecutionPolicy Bypass -File scripts\sw_test_preflight.ps1 -RuntimeDir .\runtime -Register
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$RuntimeDir,

    [string]$ReportDir,

    [switch]$Register,

    [switch]$CleanLicenseState,

    [string]$ExpectedExeSha256,
    [string]$ExpectedDllSha256
)

$ErrorActionPreference = 'Stop'

# Single source of truth for accepted runtime hashes: scripts/expected_release_hashes.json.
# The fallback literals below must mirror that file; they only apply if it is missing.
function Get-ExpectedHashes {
    $fallback = [ordered]@{
        client_exe_sha256 = '3a90a13ce358a99411f922ca3bffff44d79c75aacc7ea2b70cc55edc63c72e0a'
        addin_dll_sha256  = '1828b2904d1266aebb531302e222d07ac87ba1c292966937be6a0b73ad254705'
    }
    $path = Join-Path $PSScriptRoot 'expected_release_hashes.json'
    if (Test-Path -LiteralPath $path) {
        $json = Get-Content -LiteralPath $path -Encoding UTF8 -Raw | ConvertFrom-Json
        return [ordered]@{
            client_exe_sha256 = if ($json.client_exe_sha256) { [string]$json.client_exe_sha256 } else { $fallback.client_exe_sha256 }
            addin_dll_sha256  = if ($json.addin_dll_sha256)  { [string]$json.addin_dll_sha256 }  else { $fallback.addin_dll_sha256 }
        }
    }
    return $fallback
}

$expectedHashes = Get-ExpectedHashes
if (-not $ExpectedExeSha256) { $ExpectedExeSha256 = $expectedHashes.client_exe_sha256 }
if (-not $ExpectedDllSha256) { $ExpectedDllSha256 = $expectedHashes.addin_dll_sha256 }
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
$addinGuid = '{59959DFA-3229-4B86-852E-52ABF2BDB8C0}'

$script:Warnings = @()
$script:Steps = @()

function Step([string]$Message) {
    Write-Host "[preflight] $Message"
    $script:Steps += $Message
}

function Warn([string]$Message) {
    Write-Warning $Message
    $script:Warnings += $Message
}

function Fail([string]$Message) {
    throw "sw test preflight failed: $Message"
}

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Invoke-Checked([string]$What) {
    if ($LASTEXITCODE -ne 0) { Fail "$What failed (exit $LASTEXITCODE)" }
}

# reg.exe writes to stderr and returns a non-zero exit code for absent keys,
# which would otherwise terminate the script under ErrorActionPreference=Stop.
# These helpers run reg.exe tolerantly and return its stdout (if any).
function Invoke-Reg([string[]]$RegArgs) {
    $prev = $ErrorActionPreference
    $ErrorActionPreference = 'Continue'
    try {
        $out = & reg @RegArgs 2>$null
        return $out
    }
    finally {
        $ErrorActionPreference = $prev
    }
}

function Get-RegistryPathNeedles([string]$Path) {
    $resolved = (Resolve-Path -LiteralPath $Path).Path
    $uri = ([Uri]$resolved).AbsoluteUri
    return @(
        $resolved,
        ($resolved -replace '\\', '/'),
        $uri,
        [Uri]::UnescapeDataString($uri)
    ) | ForEach-Object { $_.ToLowerInvariant() } | Select-Object -Unique
}

function Test-RegistryLineReferencesPath([string]$Line, [string[]]$Needles) {
    $normalized = ($Line -replace '\\', '/').ToLowerInvariant()
    foreach ($needle in $Needles) {
        if ($normalized.Contains(($needle -replace '\\', '/'))) {
            return $true
        }
    }
    return $false
}

# --- 1. Normalize the launch environment ----------------------------------
Step "normalizing process environment (WINDIR/SystemRoot/ComSpec)"
if (-not $env:WINDIR) { $env:WINDIR = 'C:\Windows' }
if (-not $env:SystemRoot) { $env:SystemRoot = $env:WINDIR }
if (-not $env:ComSpec) { $env:ComSpec = Join-Path $env:WINDIR 'system32\cmd.exe' }

$regAsm = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe'
if (-not (Test-Path -LiteralPath $regAsm)) {
    Fail "broken launch environment: RegAsm not found at $regAsm (check WINDIR=$($env:WINDIR)). SolidWorks would likely show a false '.NET Framework failed to load' error from this shell."
}
Step "RegAsm available: $regAsm"

# --- 2. Resolve and verify the artifacts under test ------------------------
$runtime = (Resolve-Path -LiteralPath $RuntimeDir).Path
$exePath = Join-Path $runtime 'SWTools.exe'
$dllPath = Join-Path $runtime 'SWTools.dll'
if (-not (Test-Path -LiteralPath $exePath)) { Fail "SWTools.exe not found in $runtime" }
if (-not (Test-Path -LiteralPath $dllPath)) { Fail "SWTools.dll not found in $runtime" }
$runtimeNeedles = Get-RegistryPathNeedles $runtime
$dllPathNeedles = Get-RegistryPathNeedles $dllPath

$exeHash = Get-Sha256 $exePath
$dllHash = Get-Sha256 $dllPath
Step "runtime SWTools.exe sha256 = $exeHash"
Step "runtime SWTools.dll sha256 = $dllHash"

if ($ExpectedExeSha256 -and $exeHash -ne $ExpectedExeSha256.ToLowerInvariant()) {
    Warn "SWTools.exe hash does not match expected ($ExpectedExeSha256). Confirm this is the intended build before trusting parity results."
}
if ($ExpectedDllSha256 -and $dllHash -ne $ExpectedDllSha256.ToLowerInvariant()) {
    Warn "SWTools.dll hash does not match expected ($ExpectedDllSha256). Confirm this is the intended build before trusting parity results."
}

$addinPatchProject = Join-Path $repoRoot 'client-core\tools\AddinBrandPatch\AddinBrandPatch.csproj'
Step "verifying SWTools.dll add-in brand metadata"
dotnet run -c Release --project $addinPatchProject -- $dllPath verify
Invoke-Checked 'addin brand verify'

# --- 3. Stop any running SolidWorks / SWTools --------------------------------
Step "stopping SLDWORKS/SWTools processes (if any)"
Get-Process SLDWORKS, SWTools -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue

# --- 4. Backup affected registry branches ----------------------------------
if (-not $ReportDir) {
    $stamp = Get-Date -Format yyyyMMdd-HHmmss
    $ReportDir = Join-Path 'manual-test-reports' "preflight-$stamp"
}
New-Item -ItemType Directory -Force -Path $ReportDir | Out-Null
$ReportDir = (Resolve-Path -LiteralPath $ReportDir).Path
Step "registry backup -> $ReportDir"

$backupTargets = @(
    @{ Key = 'HKCU\SOFTWARE\SWTools'; File = 'HKCU_SWTools.reg' },
    @{ Key = 'HKLM\SOFTWARE\SolidWorks'; File = 'HKLM_SolidWorks.reg' },
    @{ Key = 'HKCU\SOFTWARE\SolidWorks'; File = 'HKCU_SolidWorks.reg' },
    @{ Key = 'HKLM\SOFTWARE\Classes\SWTools.SwAddin'; File = 'HKLM_Classes_SWTools.SwAddin.reg' },
    # license-state keys that -CleanLicenseState (step 7) deletes; backed up here
    # so deletion is always preceded by a backup
    @{ Key = 'HKLM\SOFTWARE\SolURxxCfNU'; File = 'HKLM_SolURxxCfNU.reg' },
    @{ Key = 'HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ'; File = 'HKLM_Microsoft_MzORu8qE4HhZ.reg' }
)
foreach ($t in $backupTargets) {
    $out = Join-Path $ReportDir $t.File
    Invoke-Reg @('export', $t.Key, $out, '/y') | Out-Null
    # absent keys simply produce no file; that is fine for a backup
}

# --- 5. Clean/detect stale CommandManager tabs -------------------------------
$cmgrCleanupScript = Join-Path $PSScriptRoot 'clean_swtools_commandmanager_tabs.ps1'
$cmgrReportDir = Join-Path $ReportDir 'commandmanager-cleanup'
if (Test-Path -LiteralPath $cmgrCleanupScript -PathType Leaf) {
    if ($Register) {
        Step "cleaning stale SWTools/ZTool CommandManager tabs"
        powershell.exe -NoProfile -ExecutionPolicy Bypass -File $cmgrCleanupScript -Apply -ReportDir $cmgrReportDir
        Invoke-Checked 'CommandManager cleanup'
    }
    else {
        Step "dry-run scan for stale SWTools/ZTool CommandManager tabs"
        powershell.exe -NoProfile -ExecutionPolicy Bypass -File $cmgrCleanupScript -ReportDir $cmgrReportDir
        Invoke-Checked 'CommandManager cleanup dry-run'
    }
}
else {
    Warn "CommandManager cleanup script not found: $cmgrCleanupScript"
}

# --- 6. Detect stale SWTools references --------------------------------------
Step "scanning registry for stale SWTools CodeBase / AddIn references"
$classesHits = Invoke-Reg @('query', 'HKLM\SOFTWARE\Classes', '/f', 'SWTools', '/s', '/reg:64')
$codeBaseLines = @($classesHits | Where-Object { $_ -match 'CodeBase' } | Select-Object -Unique)
foreach ($line in $codeBaseLines) {
    if (-not (Test-RegistryLineReferencesPath $line $runtimeNeedles)) {
        if ($Register) {
            Step "stale CodeBase before RegAsm: $($line.Trim())"
        }
        else {
            Warn "registry CodeBase does not point at the runtime under test: $($line.Trim())"
        }
    }
}

# --- 7. Optionally (re)register the current DLL ----------------------------
if ($Register) {
    Step "registering $dllPath via RegAsm /codebase"
    Push-Location $runtime
    try {
        & $regAsm $dllPath /codebase
        if ($LASTEXITCODE -ne 0) { Fail "RegAsm returned exit code $LASTEXITCODE" }
    }
    finally {
        Pop-Location
    }

    Step "configuring SolidWorks add-in enable/startup keys"
    Invoke-Reg @('add', "HKLM\SOFTWARE\SolidWorks\Addins\$addinGuid", '/ve', '/t', 'REG_DWORD', '/d', '1', '/f') | Out-Null
    Invoke-Reg @('add', "HKLM\SOFTWARE\SolidWorks\Addins\$addinGuid", '/v', 'Title', '/t', 'REG_SZ', '/d', 'SWTools', '/f') | Out-Null
    Invoke-Reg @('add', "HKLM\SOFTWARE\SolidWorks\Addins\$addinGuid", '/v', 'Description', '/t', 'REG_SZ', '/d', 'SWTools SolidWorks Add-in', '/f') | Out-Null
    Invoke-Reg @('add', 'HKCU\SOFTWARE\SolidWorks\AddInsStartup', '/v', $addinGuid, '/t', 'REG_DWORD', '/d', '1', '/f') | Out-Null
    Invoke-Reg @('add', "HKCU\SOFTWARE\SolidWorks\AddInsStartup\$addinGuid", '/ve', '/t', 'REG_DWORD', '/d', '1', '/f') | Out-Null

    Step "verifying CodeBase now points at the runtime DLL"
    $verify = Invoke-Reg @('query', 'HKLM\SOFTWARE\Classes', '/f', 'SWTools.dll', '/s', '/reg:64')
    $verifyCodeBaseLines = @($verify | Where-Object { $_ -match 'CodeBase' } | Select-Object -Unique)
    if (-not ($verifyCodeBaseLines | Where-Object { Test-RegistryLineReferencesPath $_ $dllPathNeedles })) {
        Fail "after RegAsm, no HKLM\SOFTWARE\Classes CodeBase references $dllPath; SolidWorks may still load a stale DLL"
    }
    $staleAfterRegister = @($verifyCodeBaseLines | Where-Object { -not (Test-RegistryLineReferencesPath $_ $runtimeNeedles) })
    if ($staleAfterRegister.Count -gt 0) {
        Fail "after RegAsm, stale HKLM\SOFTWARE\Classes CodeBase still exists: $($staleAfterRegister[0].Trim())"
    }
}
else {
    Step "skipping RegAsm registration (pass -Register to (re)register the runtime DLL)"
}

# --- 8. Optionally clean license state -------------------------------------
if ($CleanLicenseState) {
    Warn "CleanLicenseState requested: deleting SWTools license-state keys (clean-license scenario only)"
    foreach ($k in @('HKCU\SOFTWARE\SWTools', 'HKLM\SOFTWARE\SolURxxCfNU', 'HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ')) {
        Invoke-Reg @('delete', $k, '/f') | Out-Null
    }
}

# --- 9. Emit preflight report ----------------------------------------------
$status = if ($script:Warnings.Count -eq 0) { 'PASS' } else { 'PASS_WITH_WARNINGS' }
$report = [ordered]@{
    timestamp           = (Get-Date).ToString('o')
    status              = $status
    runtimeDir          = $runtime
    swtoolsExe            = @{ path = $exePath; sha256 = $exeHash; expected = $ExpectedExeSha256.ToLowerInvariant() }
    swtoolsDll            = @{ path = $dllPath; sha256 = $dllHash; expected = $ExpectedDllSha256.ToLowerInvariant() }
    registered          = [bool]$Register
    commandManagerCleanup = $cmgrReportDir
    licenseStateCleaned = [bool]$CleanLicenseState
    windir              = $env:WINDIR
    steps               = $script:Steps
    warnings            = $script:Warnings
}
$reportPath = Join-Path $ReportDir 'preflight-report.json'
$report | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $reportPath -Encoding UTF8

Write-Host ""
Write-Host "[preflight] status: $status"
Write-Host "[preflight] report: $reportPath"
if ($script:Warnings.Count -gt 0) {
    Write-Host "[preflight] warnings:"
    $script:Warnings | ForEach-Object { Write-Host "  - $_" }
}
Write-Host "[preflight] next: open TestModel\0614-A00.SLDASM via Explorer, maximize SolidWorks, start SWTools from the ribbon, then follow FULL_TEST_METHODOLOGY_RU.md sec 2.2."
