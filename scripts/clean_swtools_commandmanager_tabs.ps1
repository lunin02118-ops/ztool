<#
.SYNOPSIS
  Remove stale SWTools CommandManager tabs (including anonymous "blank tab" clones)
  and Custom API Flyouts from the SolidWorks user profile.

.DESCRIPTION
  Addresses finding F-14 / refactoring-plan R1.1: SolidWorks persists SWTools
  CommandManager tabs in the per-user registry. Besides the obvious named SWTools
  tabs, it can keep an *anonymous* clone that has no ModuleName/RefName but still
  carries the SWTools button set (Tab Props = 0,1,1,-1; buttons include 2,59425 and
  41658..41675). A cleanup that searches only for "SWTools"/the add-in GUID misses
  this clone, which then shows up as a second, blank SWTools tab.

  This script is meant to be called by the installer/uninstaller (and is also a
  standalone pre-flight helper). It:
    1. Enumerates the targeted SolidWorks version(s) under HKCU.
    2. Backs up the affected registry branches (reg export) before any change.
    3. Finds named SWTools tabs AND anonymous SWTools clones under
       CommandManager\{AssyContext,PartContext,DrwContext}\Tab*.
    4. Finds Custom API Flyouts referencing SWTools / the add-in GUID.
    5. With -IncludeAddInsStartup, zeroes the AddInsStartup parent value + subkey
       (uninstall hygiene; stops auto-loading the old add-in).

  It is DRY-RUN by default: nothing is deleted/written unless -Apply is passed.
  It is idempotent and writes a JSON report.

.PARAMETER SwVersion
  Targeted SolidWorks profile, e.g. "SOLIDWORKS 2025". If omitted, every
  "SOLIDWORKS <year>" profile found under HKCU\SOFTWARE\SolidWorks is processed.

.PARAMETER AddinGuid
  SWTools add-in COM GUID. Default {59959DFA-3229-4B86-852E-52ABF2BDB8C0}.

.PARAMETER Apply
  Actually delete matching keys / write AddInsStartup zeros. Without it the
  script only reports what it would remove (dry run).

.PARAMETER IncludeAddInsStartup
  Also set the AddInsStartup parent value and subkey default to 0 for the
  targeted version(s) and the legacy non-versioned root. Use for uninstall.

.PARAMETER ReportDir
  Where to write the JSON report and registry backups. Defaults to
  manual-test-reports\cmgr-cleanup-<timestamp>.

.EXAMPLE
  # Dry run (default) against all detected SolidWorks profiles:
  powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_swtools_commandmanager_tabs.ps1

.EXAMPLE
  # Real cleanup for the live-test pre-flight (one version):
  powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_swtools_commandmanager_tabs.ps1 -SwVersion "SOLIDWORKS 2025" -Apply

.EXAMPLE
  # Full uninstall hygiene (tabs + flyouts + AddInsStartup zeros):
  powershell -NoProfile -ExecutionPolicy Bypass -File scripts\clean_swtools_commandmanager_tabs.ps1 -Apply -IncludeAddInsStartup
#>
param(
    [string]$SwVersion,

    [string]$AddinGuid = '{59959DFA-3229-4B86-852E-52ABF2BDB8C0}',

    [switch]$Apply,

    [switch]$IncludeAddInsStartup,

    [string]$ReportDir
)

$ErrorActionPreference = 'Stop'

$script:Steps = @()
$script:Warnings = @()
$script:Found = @()
$script:Removed = @()
$script:Backups = @()

function Step([string]$Message) {
    Write-Host "[cmgr-clean] $Message"
    $script:Steps += $Message
}

function Warn([string]$Message) {
    Write-Warning $Message
    $script:Warnings += $Message
}

# reg.exe writes to stderr and returns non-zero for absent keys; run it tolerantly.
function Invoke-Reg([string[]]$RegArgs) {
    $prev = $ErrorActionPreference
    $ErrorActionPreference = 'Continue'
    try { return & reg @RegArgs 2>$null }
    finally { $ErrorActionPreference = $prev }
}

$guidCore = $AddinGuid.Trim('{', '}')
# -match is case-insensitive by default; this catches the GUID or the literal name.
$guidRe = "$([regex]::Escape($guidCore))|SWTools"

# --- 1. Resolve targeted SolidWorks version(s) -----------------------------
$swRoot = 'HKCU:\SOFTWARE\SolidWorks'
if (-not (Test-Path -LiteralPath $swRoot)) {
    Warn "no SolidWorks profile under HKCU\SOFTWARE\SolidWorks; nothing to clean"
    $versions = @()
} elseif ($SwVersion) {
    $versions = @($SwVersion)
} else {
    $versions = @(
        Get-ChildItem -LiteralPath $swRoot -ErrorAction SilentlyContinue |
            Where-Object { $_.PSChildName -match '^SOLIDWORKS \d{4}$' } |
            ForEach-Object { $_.PSChildName }
    )
    if ($versions.Count -eq 0) {
        Warn "no 'SOLIDWORKS <year>' profiles found under HKCU\SOFTWARE\SolidWorks"
    }
}
Step "targeted SolidWorks versions: $([string]::Join(', ', $versions))"

# --- 2. Prepare report/backup directory ------------------------------------
$stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
if (-not $ReportDir) {
    $ReportDir = Join-Path (Join-Path (Get-Location) 'manual-test-reports') "cmgr-cleanup-$stamp"
}
New-Item -ItemType Directory -Force -Path $ReportDir | Out-Null
Step "report/backup dir: $ReportDir"

function Backup-RegBranch([string]$RegPath, [string]$Name) {
    # $RegPath in reg.exe syntax (HKCU\...), only export if it exists.
    $exists = Invoke-Reg @('query', $RegPath)
    if ($LASTEXITCODE -ne 0) { return }
    $out = Join-Path $ReportDir "$Name.reg"
    Invoke-Reg @('export', $RegPath, $out, '/y') | Out-Null
    if (Test-Path -LiteralPath $out) {
        $script:Backups += $out
        Step "backed up $RegPath -> $out"
    }
}

# Back up the whole SolidWorks HKCU branch once (covers CommandManager, flyouts,
# AddInsStartup for every version) before touching anything.
if ($versions.Count -gt 0 -or $IncludeAddInsStartup) {
    Backup-RegBranch 'HKCU\SOFTWARE\SolidWorks' 'HKCU_SolidWorks'
}

function Get-RegButtons($childPaths) {
    $buttons = @()
    foreach ($cp in $childPaths) {
        $props = Get-ItemProperty -LiteralPath $cp -ErrorAction SilentlyContinue
        if ($null -eq $props) { continue }
        $props.PSObject.Properties |
            Where-Object { $_.Name -like 'Btn*' } |
            ForEach-Object { $buttons += [string]$_.Value }
    }
    return , $buttons
}

# --- 3. CommandManager tabs (named + anonymous clones) ---------------------
foreach ($ver in $versions) {
    $cm = "HKCU:\SOFTWARE\SolidWorks\$ver\User Interface\CommandManager"
    if (-not (Test-Path -LiteralPath $cm)) { continue }

    foreach ($ctx in 'AssyContext', 'PartContext', 'DrwContext') {
        $ctxRoot = Join-Path $cm $ctx
        if (-not (Test-Path -LiteralPath $ctxRoot)) { continue }

        Get-ChildItem -LiteralPath $ctxRoot -ErrorAction SilentlyContinue |
            Where-Object { $_.PSChildName -match '^Tab\d+$' } |
            ForEach-Object {
                $tabPath = $_.PSPath
                $props = Get-ItemProperty -LiteralPath $tabPath -ErrorAction SilentlyContinue
                $children = @(Get-ChildItem -LiteralPath $tabPath -Recurse -ErrorAction SilentlyContinue |
                        ForEach-Object { $_.PSPath })
                $childText = ($children | ForEach-Object {
                        Get-ItemProperty -LiteralPath $_ -ErrorAction SilentlyContinue | Out-String
                    }) -join "`n"
                $text = (($props | Out-String), $childText) -join "`n"
                $buttons = Get-RegButtons $children
                $buttonText = $buttons -join ';'

                $isNamedSWTools = ($text -match $guidRe) -or
                    ($props.ModuleName -eq $AddinGuid) -or
                    ($props.RefName -eq 'SWTools') -or
                    ($props.'Tab Props' -like 'SWTools,*')

                $isAnonymousClone = (-not $props.ModuleName) -and
                    (-not $props.RefName) -and
                    ($props.'Tab Props' -eq '0,1,1,-1') -and
                    ($buttons -contains '2,59425') -and
                    ($buttonText -match '41658') -and
                    ($buttonText -match '41675')

                if ($isNamedSWTools -or $isAnonymousClone) {
                    $regPath = ($tabPath -replace '^Microsoft\.PowerShell\.Core\\Registry::', '')
                    $kind = if ($isNamedSWTools) { 'named-swtools' } else { 'anonymous-clone' }
                    $script:Found += [ordered]@{ type = 'commandmanager-tab'; kind = $kind; version = $ver; context = $ctx; key = $regPath }
                    Step "match ($kind): $regPath"
                    if ($Apply) {
                        Remove-Item -LiteralPath $tabPath -Recurse -Force
                        $script:Removed += $regPath
                        Step "removed: $regPath"
                    }
                }
            }
    }

    # --- 4. Custom API Flyouts -------------------------------------------------
    $flyouts = "HKCU:\SOFTWARE\SolidWorks\$ver\User Interface\Custom API Flyouts"
    if (Test-Path -LiteralPath $flyouts) {
        Get-ChildItem -LiteralPath $flyouts -ErrorAction SilentlyContinue |
            ForEach-Object {
                $foPath = $_.PSPath
                $self = Get-ItemProperty -LiteralPath $foPath -ErrorAction SilentlyContinue | Out-String
                $childText = (Get-ChildItem -LiteralPath $foPath -Recurse -ErrorAction SilentlyContinue |
                        ForEach-Object { Get-ItemProperty -LiteralPath $_.PSPath -ErrorAction SilentlyContinue | Out-String }) -join "`n"
                if ((($self, $childText) -join "`n") -match $guidRe) {
                    $regPath = ($foPath -replace '^Microsoft\.PowerShell\.Core\\Registry::', '')
                    $script:Found += [ordered]@{ type = 'custom-api-flyout'; kind = 'swtools-flyout'; version = $ver; context = 'Custom API Flyouts'; key = $regPath }
                    Step "match (swtools-flyout): $regPath"
                    if ($Apply) {
                        Remove-Item -LiteralPath $foPath -Recurse -Force
                        $script:Removed += $regPath
                        Step "removed: $regPath"
                    }
                }
            }
    }
}

# --- 5. AddInsStartup hygiene (uninstall) ----------------------------------
if ($IncludeAddInsStartup) {
    $startupRoots = @('HKCU\SOFTWARE\SolidWorks\AddInsStartup')
    foreach ($ver in $versions) {
        $startupRoots += "HKCU\SOFTWARE\SolidWorks\$ver\AddInsStartup"
    }
    foreach ($root in $startupRoots) {
        $val = Invoke-Reg @('query', $root, '/v', $AddinGuid)
        $hasValue = ($LASTEXITCODE -eq 0)
        if ($hasValue) {
            $script:Found += [ordered]@{ type = 'addins-startup'; kind = 'parent-value'; context = $root; key = "$root :: $AddinGuid" }
            Step "AddInsStartup value present: $root\$AddinGuid"
            if ($Apply) {
                Invoke-Reg @('add', $root, '/v', $AddinGuid, '/t', 'REG_DWORD', '/d', '0', '/f') | Out-Null
                Invoke-Reg @('add', "$root\$AddinGuid", '/ve', '/t', 'REG_DWORD', '/d', '0', '/f') | Out-Null
                $script:Removed += "$root\$AddinGuid := 0"
                Step "set AddInsStartup to 0: $root\$AddinGuid"
            }
        }
    }
}

# --- 6. Report -------------------------------------------------------------
$status = if (-not $Apply -and $Found.Count -gt 0) { 'DRY_RUN_MATCHES_FOUND' }
    elseif ($Found.Count -eq 0) { 'CLEAN' }
    else { 'APPLIED' }

$report = [ordered]@{
    timestamp            = (Get-Date).ToString('o')
    applied              = [bool]$Apply
    includeAddInsStartup = [bool]$IncludeAddInsStartup
    addinGuid            = $AddinGuid
    versions             = $versions
    status               = $status
    found                = $Found
    removed              = $Removed
    backups              = $Backups
    warnings             = $Warnings
    steps                = $Steps
}

$reportPath = Join-Path $ReportDir 'cmgr-cleanup-report.json'
$report | ConvertTo-Json -Depth 6 | Set-Content -LiteralPath $reportPath -Encoding UTF8
Step "report written: $reportPath"

if (-not $Apply -and $Found.Count -gt 0) {
    Write-Host "DRY RUN: $($Found.Count) SWTools CommandManager/flyout/startup match(es). Re-run with -Apply to remove." -ForegroundColor Yellow
} elseif ($Found.Count -eq 0) {
    Write-Host 'CommandManager cleanup: CLEAN (no SWTools tabs/flyouts found).' -ForegroundColor Green
} else {
    Write-Host "CommandManager cleanup: removed $($Removed.Count) item(s)." -ForegroundColor Green
}

$report | ConvertTo-Json -Depth 6
