<#
.SYNOPSIS
  Prepare a clean, reproducible environment for a live SolidWorks/ZTool test run.

.DESCRIPTION
  Automates the manual pre-flight that the executor previously had to run by hand
  (see docs/release/FULL_TEST_METHODOLOGY_RU.md sections 2.1 / 2.2). It addresses
  the three failure modes that break ZTool testing from an automation/agent shell:

    1. Broken launch environment. When SolidWorks/ZTool are started from a shell
       whose WINDIR/SystemRoot are empty, SolidWorks throws a false
       "Failed to load Microsoft .NET Framework" error or hangs on the splash,
       even though launching via the desktop shortcut works. This script
       normalizes WINDIR/SystemRoot/ComSpec and verifies RegAsm is reachable.

    2. Dirty registry / wrong DLL. Stale RegAsm CodeBase, SolidWorks AddIn keys
       or HKCU\SOFTWARE\ZTool from a previous test can make SolidWorks load a
       different ZTool.dll/ZTool.exe than the one under test. This script backs
       up the affected registry branches, reports stale ZTool references,
       (optionally) re-registers the current runtime ZTool.dll via RegAsm
       /codebase, and verifies the live CodeBase points at the runtime folder.

    3. Wrong artifact under test. Optionally verifies the SHA256 of the runtime
       ZTool.exe / ZTool.dll against the accepted hashes so a run cannot silently
       use the wrong binary.

  The script is idempotent and read-mostly: it only writes to the registry when
  -Register (RegAsm) or -CleanLicenseState is passed, and always takes a backup
  first. It does NOT launch SolidWorks or drive the UI; window normalization and
  object-based UI automation remain in FULL_TEST_METHODOLOGY_RU.md section 2.2.

.PARAMETER RuntimeDir
  Folder that contains the ZTool.exe / ZTool.dll under test (e.g. the release
  package 'runtime' folder, or client-core\dist).

.PARAMETER ReportDir
  Folder where registry backups and the preflight report JSON are written.
  Defaults to manual-test-reports\preflight-<timestamp>.

.PARAMETER Register
  Re-register RuntimeDir\ZTool.dll via RegAsm /codebase (writes registry).

.PARAMETER CleanLicenseState
  Also delete ZTool license-state keys. Only needed for clean-license scenarios;
  do NOT use for ordinary BOM/color/export runs. Writes registry.

.PARAMETER ExpectedExeSha256
  Optional expected SHA256 of RuntimeDir\ZTool.exe. Default is loaded from
  scripts/expected_release_hashes.json (single source of truth, shared with
  verify_release_package.ps1).

.PARAMETER ExpectedDllSha256
  Optional expected SHA256 of RuntimeDir\ZTool.dll (default = accepted hash).

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
        client_exe_sha256 = 'fa9195400976e7996eb0a3ac853a369cc2718c4dc0f87eb3f77430d223bbd753'
        addin_dll_sha256  = 'd053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9'
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
$exePath = Join-Path $runtime 'ZTool.exe'
$dllPath = Join-Path $runtime 'ZTool.dll'
if (-not (Test-Path -LiteralPath $exePath)) { Fail "ZTool.exe not found in $runtime" }
if (-not (Test-Path -LiteralPath $dllPath)) { Fail "ZTool.dll not found in $runtime" }
$runtimeNeedles = Get-RegistryPathNeedles $runtime
$dllPathNeedles = Get-RegistryPathNeedles $dllPath

$exeHash = Get-Sha256 $exePath
$dllHash = Get-Sha256 $dllPath
Step "runtime ZTool.exe sha256 = $exeHash"
Step "runtime ZTool.dll sha256 = $dllHash"

if ($ExpectedExeSha256 -and $exeHash -ne $ExpectedExeSha256.ToLowerInvariant()) {
    Warn "ZTool.exe hash does not match expected ($ExpectedExeSha256). Confirm this is the intended build before trusting parity results."
}
if ($ExpectedDllSha256 -and $dllHash -ne $ExpectedDllSha256.ToLowerInvariant()) {
    Warn "ZTool.dll hash does not match expected ($ExpectedDllSha256). Confirm this is the intended build before trusting parity results."
}

# --- 3. Stop any running SolidWorks / ZTool --------------------------------
Step "stopping SLDWORKS/ZTool processes (if any)"
Get-Process SLDWORKS, ZTool -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue

# --- 4. Backup affected registry branches ----------------------------------
if (-not $ReportDir) {
    $stamp = Get-Date -Format yyyyMMdd-HHmmss
    $ReportDir = Join-Path 'manual-test-reports' "preflight-$stamp"
}
New-Item -ItemType Directory -Force -Path $ReportDir | Out-Null
$ReportDir = (Resolve-Path -LiteralPath $ReportDir).Path
Step "registry backup -> $ReportDir"

$backupTargets = @(
    @{ Key = 'HKCU\SOFTWARE\ZTool'; File = 'HKCU_ZTool.reg' },
    @{ Key = 'HKLM\SOFTWARE\SolidWorks'; File = 'HKLM_SolidWorks.reg' },
    @{ Key = 'HKCU\SOFTWARE\SolidWorks'; File = 'HKCU_SolidWorks.reg' },
    @{ Key = 'HKLM\SOFTWARE\Classes\ZTool.SwAddin'; File = 'HKLM_Classes_ZTool.SwAddin.reg' },
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

# --- 5. Detect stale ZTool references --------------------------------------
Step "scanning registry for stale ZTool CodeBase / AddIn references"
$classesHits = Invoke-Reg @('query', 'HKLM\SOFTWARE\Classes', '/f', 'ZTool', '/s', '/reg:64')
$codeBaseLines = $classesHits | Where-Object { $_ -match 'CodeBase' }
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

# --- 6. Optionally (re)register the current DLL ----------------------------
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

    Step "verifying CodeBase now points at the runtime DLL"
    $verify = Invoke-Reg @('query', 'HKLM\SOFTWARE\Classes', '/f', 'ZTool.dll', '/s', '/reg:64')
    $verifyCodeBaseLines = @($verify | Where-Object { $_ -match 'CodeBase' })
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

# --- 7. Optionally clean license state -------------------------------------
if ($CleanLicenseState) {
    Warn "CleanLicenseState requested: deleting ZTool license-state keys (clean-license scenario only)"
    foreach ($k in @('HKCU\SOFTWARE\ZTool', 'HKLM\SOFTWARE\SolURxxCfNU', 'HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ')) {
        Invoke-Reg @('delete', $k, '/f') | Out-Null
    }
}

# --- 8. Emit preflight report ----------------------------------------------
$status = if ($script:Warnings.Count -eq 0) { 'PASS' } else { 'PASS_WITH_WARNINGS' }
$report = [ordered]@{
    timestamp           = (Get-Date).ToString('o')
    status              = $status
    runtimeDir          = $runtime
    ztoolExe            = @{ path = $exePath; sha256 = $exeHash; expected = $ExpectedExeSha256.ToLowerInvariant() }
    ztoolDll            = @{ path = $dllPath; sha256 = $dllHash; expected = $ExpectedDllSha256.ToLowerInvariant() }
    registered          = [bool]$Register
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
Write-Host "[preflight] next: open TestModel\0614-A00.SLDASM via Explorer, maximize SolidWorks, start ZTool from the ribbon, then follow FULL_TEST_METHODOLOGY_RU.md sec 2.2."
