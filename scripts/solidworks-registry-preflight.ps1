<#
.SYNOPSIS
  SolidWorks add-in registry / launch preflight for ZTool acceptance testing.

.DESCRIPTION
  Phase 11 gate (docs/audit/refactor-production-readiness-gap-audit-2026-06-16_RU.md,
  recommendation #3). Before any manual / semi-automated SolidWorks acceptance run,
  this confirms the machine will load the EXACT add-in/exe we intend to test and not
  a stale Chinese build or a wrong path:

    * COM registration (CodeBase) of the add-in CLSID points inside -InstallRoot;
    * the registered ZTool.dll and the ZTool.exe in -InstallRoot match the accepted
      SHA256 bundle hashes (and their SHA256 are printed for the test report);
    * global + versioned HKLM Addins keys exist and have no CJK description;
    * global + versioned HKCU AddInsStartup keys exist and are enabled (=1);
    * no second ZTool.exe is registered/sitting at a different path;
    * the currently running ZTool.exe (if any) is the one under -InstallRoot.

  Designed to run on the operator's SolidWorks machine. On a machine without
  SolidWorks pass -AllowMissingSolidWorks to downgrade "SW keys absent" from a
  failure to a warning (e.g. for a syntax/dry inspection). CI does not execute
  this script; it only parses it for syntax.

.EXAMPLE
  pwsh scripts/solidworks-registry-preflight.ps1 -InstallRoot 'D:\ZTool'
#>
param(
    [string]$InstallRoot = 'D:\ZTool',

    [string]$AddinClsid = '{59959DFA-3229-4B86-852E-52ABF2BDB8C0}',
    [string]$SolidWorksVersionKey = 'SOLIDWORKS 2025',

    [string]$ExpectedClientExeSha256 = 'c578547138db061a29294260e5d0fac03f6d86ff1a00a7154f0f6dc0d2dd03a9',
    [string]$ExpectedAddinDllSha256 = 'd053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9',

    [switch]$AllowMissingSolidWorks
)

$ErrorActionPreference = 'Stop'
$script:Failures = @()

function Fail([string]$Message) { $script:Failures += $Message; Write-Host "  FAIL  $Message" }
function Warn([string]$Message) { Write-Host "  WARN  $Message" }
function Ok([string]$Message)   { Write-Host "  OK    $Message" }

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

# Returns $true if a string contains any CJK ideograph / CJK punctuation.
function Test-HasCjk([string]$Text) {
    if ([string]::IsNullOrEmpty($Text)) { return $false }
    foreach ($ch in $Text.ToCharArray()) {
        $cp = [int][char]$ch
        if (($cp -ge 0x3000 -and $cp -le 0x303F) -or
            ($cp -ge 0x3400 -and $cp -le 0x4DBF) -or
            ($cp -ge 0x4E00 -and $cp -le 0x9FFF) -or
            ($cp -ge 0xFF00 -and $cp -le 0xFFEF)) { return $true }
    }
    return $false
}

function Get-RegValue([string]$Path, [string]$Name) {
    if (-not (Test-Path -LiteralPath $Path)) { return $null }
    $item = Get-ItemProperty -LiteralPath $Path -ErrorAction SilentlyContinue
    if ($null -eq $item) { return $null }
    if ([string]::IsNullOrEmpty($Name)) { $Name = '(default)' }
    return $item.$Name
}

Write-Host "SolidWorks registry preflight"
Write-Host "  InstallRoot : $InstallRoot"
Write-Host "  AddinClsid  : $AddinClsid"
Write-Host "  SW versioned: $SolidWorksVersionKey"

# --- 1. Local bundle under InstallRoot ---------------------------------------
Write-Host "`n[1] Local bundle hashes (under InstallRoot)"
$exePath = Join-Path $InstallRoot 'ZTool.exe'
$dllPath = Join-Path $InstallRoot 'ZTool.dll'
foreach ($p in @($exePath, $dllPath)) {
    if (-not (Test-Path -LiteralPath $p -PathType Leaf)) { Fail "missing $p" }
}
if (Test-Path -LiteralPath $exePath) {
    $exeHash = Get-Sha256 $exePath
    Write-Host "  ZTool.exe SHA256 = $exeHash"
    if ($exeHash -ne $ExpectedClientExeSha256.ToLowerInvariant()) {
        Fail "ZTool.exe hash mismatch: expected $ExpectedClientExeSha256, got $exeHash"
    } else { Ok "ZTool.exe matches accepted bundle" }
}
if (Test-Path -LiteralPath $dllPath) {
    $dllHash = Get-Sha256 $dllPath
    Write-Host "  ZTool.dll SHA256 = $dllHash"
    if ($dllHash -ne $ExpectedAddinDllSha256.ToLowerInvariant()) {
        Fail "ZTool.dll hash mismatch: expected $ExpectedAddinDllSha256, got $dllHash"
    } else { Ok "ZTool.dll matches accepted bundle" }
}

# --- 2. COM CodeBase for the add-in CLSID ------------------------------------
Write-Host "`n[2] COM registration (CodeBase) for add-in CLSID"
$inproc = @(
    "HKLM:\SOFTWARE\Classes\CLSID\$AddinClsid\InprocServer32",
    "HKLM:\SOFTWARE\Wow6432Node\Classes\CLSID\$AddinClsid\InprocServer32"
)
$codeBaseFound = $false
foreach ($k in $inproc) {
    $cb = Get-RegValue $k 'CodeBase'
    if ($null -ne $cb) {
        $codeBaseFound = $true
        Write-Host "  $k`n    CodeBase = $cb"
        $cbPath = $cb -replace '^file:///', '' -replace '/', '\'
        if (-not (Test-Path -LiteralPath $cbPath -PathType Leaf)) {
            Fail "registered CodeBase points to a missing file: $cbPath"
        }
        else {
            $cbFull = (Resolve-Path -LiteralPath $cbPath).Path
            $rootFull = (Resolve-Path -LiteralPath $InstallRoot).Path
            if (-not $cbFull.StartsWith($rootFull, [System.StringComparison]::OrdinalIgnoreCase)) {
                Fail "registered add-in resolves OUTSIDE InstallRoot: $cbFull"
            } else { Ok "CodeBase resolves inside InstallRoot" }
            $cbHash = Get-Sha256 $cbFull
            if ($cbHash -ne $ExpectedAddinDllSha256.ToLowerInvariant()) {
                Fail "registered add-in DLL hash mismatch: got $cbHash at $cbFull"
            } else { Ok "registered add-in DLL matches accepted bundle" }
        }
    }
}
if (-not $codeBaseFound) {
    if ($AllowMissingSolidWorks) { Warn "add-in COM CodeBase not registered (SW not installed?)" }
    else { Fail "add-in COM CodeBase not registered for $AddinClsid" }
}

# --- 3. HKLM Addins (global + versioned) -------------------------------------
Write-Host "`n[3] HKLM SolidWorks Addins (description must not be CJK)"
$hklmAddins = @(
    "HKLM:\SOFTWARE\SolidWorks\Addins\$AddinClsid",
    "HKLM:\SOFTWARE\SolidWorks\$SolidWorksVersionKey\Addins\$AddinClsid"
)
foreach ($k in $hklmAddins) {
    if (Test-Path -LiteralPath $k) {
        $desc = Get-RegValue $k 'Description'
        $title = Get-RegValue $k 'Title'
        Write-Host "  $k  Title='$title' Description='$desc'"
        if ((Test-HasCjk $desc) -or (Test-HasCjk $title)) {
            Fail "CJK add-in description/title still registered at $k"
        } else { Ok "no CJK in add-in description" }
    }
    elseif ($AllowMissingSolidWorks) { Warn "missing $k (SW not installed?)" }
    else { Fail "missing HKLM Addins key: $k" }
}

# --- 4. HKCU AddInsStartup (global + versioned) ------------------------------
Write-Host "`n[4] HKCU AddInsStartup (must exist and be enabled =1)"
$hkcuStartup = @(
    "HKCU:\SOFTWARE\SolidWorks\AddInsStartup\$AddinClsid",
    "HKCU:\SOFTWARE\SolidWorks\$SolidWorksVersionKey\AddInsStartup\$AddinClsid"
)
$anyStartup = $false
foreach ($k in $hkcuStartup) {
    if (Test-Path -LiteralPath $k) {
        $anyStartup = $true
        $val = Get-RegValue $k ''
        Write-Host "  $k  (default)=$val"
        if ($val -ne 1) { Warn "AddInsStartup at $k is not enabled (=$val)" }
        else { Ok "AddInsStartup enabled" }
    }
}
if (-not $anyStartup) {
    if ($AllowMissingSolidWorks) { Warn "no AddInsStartup key (SW not installed / add-in never loaded)" }
    else { Fail "no HKCU AddInsStartup key for $AddinClsid" }
}

# --- 5. Stray ZTool.exe at a different path ----------------------------------
Write-Host "`n[5] Stray ZTool.exe / running process"
$running = @(Get-Process -Name 'ZTool' -ErrorAction SilentlyContinue)
if ($running.Count -eq 0) {
    Write-Host "  (no ZTool.exe currently running)"
} else {
    foreach ($p in $running) {
        $rp = $null
        try { $rp = $p.Path } catch { $rp = '<access denied>' }
        Write-Host "  running pid=$($p.Id) path=$rp"
        if ($rp -and (Test-Path -LiteralPath $InstallRoot)) {
            $rootFull = (Resolve-Path -LiteralPath $InstallRoot).Path
            if (-not $rp.StartsWith($rootFull, [System.StringComparison]::OrdinalIgnoreCase)) {
                Fail "a ZTool.exe is running from OUTSIDE InstallRoot: $rp"
            }
        }
    }
}

# --- result ------------------------------------------------------------------
Write-Host "`n======================================================================"
if ($script:Failures.Count -gt 0) {
    Write-Host "RESULT: FAIL - $($script:Failures.Count) preflight problem(s):"
    foreach ($f in $script:Failures) { Write-Host "  * $f" }
    exit 1
}
Write-Host "RESULT: PASS - registry/launch preflight clean."
exit 0
