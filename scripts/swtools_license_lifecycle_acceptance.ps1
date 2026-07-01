<#
.SYNOPSIS
  SWTools licensing lifecycle acceptance orchestrator.

.DESCRIPTION
  Runs the production licensing lifecycle as explicit stages and writes a single
  redacted JSON result. The script is safe by default: any operation that can
  mutate the production backend or activate the local client requires
  -AllowProductionMutation.

  This script intentionally composes the older swtools_activation_acceptance.ps1
  for UI activation so the known copy/paste/read-back/restart contract stays in
  one place.
#>

[CmdletBinding()]
param(
    [string]$SecretPath,

    [string]$RuntimeDir,

    [string]$ReportDir = "manual-test-reports\swtools-license-lifecycle",

    [string]$SshHost = "04-rheolab-license",

    [string]$ServiceName = "ztool-tcp-server.service",

    [switch]$RequireNoLicenseWindow,

    [switch]$ProvisionProductionKey,

    [switch]$ResetProductionBinding,

    [switch]$FillActivationForm,

    [switch]$ClickActivate,

    [switch]$VerifyActiveServerState,

    [switch]$TransferViaUi,

    [switch]$RevokeProductionKey,

    [switch]$DeleteRevokedProductionKey,

    [switch]$RepeatPostRevokeCheck,

    [switch]$AllowProductionMutation
)

$ErrorActionPreference = "Stop"
if ($PSVersionTable.PSVersion.Major -lt 7) {
    throw "Run this script with PowerShell 7+ (pwsh). Windows PowerShell can misread UTF-8 Cyrillic literals and target the wrong UI."
}

$repoRoot = Split-Path -Parent $PSScriptRoot
$activationScript = Join-Path $PSScriptRoot "swtools_activation_acceptance.ps1"
$uiHelper = Join-Path $PSScriptRoot "swtools_acceptance_ui.ps1"

if (-not (Test-Path -LiteralPath $activationScript)) {
    throw "Activation helper is missing: $activationScript"
}
if (Test-Path -LiteralPath $uiHelper) {
    . $uiHelper
}

New-Item -ItemType Directory -Force -Path $ReportDir | Out-Null
$ReportDir = (Resolve-Path -LiteralPath $ReportDir).Path

$result = [ordered]@{
    schema = "swtools.license-lifecycle.v1"
    timestamp = (Get-Date).ToString("o")
    status = "PASS"
    production_go_allowed = $false
    report_dir = $ReportDir
    runtime = $null
    license_secret = $null
    stages = @()
    warnings = @()
}

function Add-Stage {
    param(
        [Parameter(Mandatory = $true)][string]$Name,
        [Parameter(Mandatory = $true)][ValidateSet("PASS", "WARN", "FAIL", "SKIP")][string]$Status,
        [string]$Summary = "",
        [hashtable]$Details = @{}
    )
    $script:result.stages += [ordered]@{
        name = $Name
        status = $Status
        summary = $Summary
        details = $Details
    }
    if ($Status -eq "FAIL") {
        $script:result.status = "FAIL"
    }
    elseif ($Status -in @("WARN", "SKIP") -and $script:result.status -eq "PASS") {
        $script:result.status = "PASS_WITH_WARN"
    }
}

function Add-Warning {
    param([Parameter(Mandatory = $true)][string]$Message)
    $script:result.warnings += $Message
    if ($script:result.status -eq "PASS") {
        $script:result.status = "PASS_WITH_WARN"
    }
}

function Get-Sha12 {
    param([Parameter(Mandatory = $true)][string]$Text)
    $bytes = [Text.Encoding]::UTF8.GetBytes($Text)
    [BitConverter]::ToString([Security.Cryptography.SHA256]::Create().ComputeHash($bytes)).Replace("-", "").Substring(0, 12).ToLowerInvariant()
}

function Read-LicenseSecretRedacted {
    param([Parameter(Mandatory = $true)][string]$Path)

    $resolved = if (Test-Path -LiteralPath $Path) {
        (Resolve-Path -LiteralPath $Path).Path
    }
    else {
        (Get-ChildItem -Path $Path | Sort-Object LastWriteTime -Descending | Select-Object -First 1).FullName
    }
    if (-not $resolved) {
        throw "Secret file was not found: $Path"
    }

    $lines = @(Get-Content -LiteralPath $resolved | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
    $body = $lines -join "`n"
    $code = [regex]::Match($body, "[A-Z0-9]{8}-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{9}").Value
    if (-not $code) {
        throw "License code with shape 8-5-5-5-9 was not found in $Path"
    }
    $password = ($lines | Where-Object { $_ -ne $code } | Select-Object -First 1)
    if ($null -eq $password) { $password = "" }

    [ordered]@{
        code = $code
        password = $password
        source = $resolved
        redacted = [ordered]@{
            code_mask = $code.Substring(0, 4) + "..." + $code.Substring($code.Length - 4)
            code_sha12 = Get-Sha12 $code
            segment_lengths = @($code -split "-" | ForEach-Object { $_.Length })
            password_length = $password.Length
            password_sha12 = if ($password.Length) { Get-Sha12 $password } else { "" }
            source_file = Split-Path -Leaf $resolved
        }
    }
}

function Require-Secret {
    if (-not $script:secret) {
        throw "SecretPath is required for this lifecycle stage"
    }
}

function Assert-MutationAllowed {
    param([Parameter(Mandatory = $true)][string]$Action)
    if (-not $AllowProductionMutation) {
        throw "$Action requires -AllowProductionMutation"
    }
}

function Write-RemoteLifecycleScript {
    param(
        [Parameter(Mandatory = $true)][string]$Action,
        [Parameter(Mandatory = $true)][System.Collections.IDictionary]$Secret,
        [Parameter(Mandatory = $true)][string]$Path
    )

@"
import json, hashlib, subprocess, sys
sys.path.insert(0, '/opt/ztool-tcp-server')
from ztool_license_server.db_mysql import MySQLLicenseDB

service = '$ServiceName'
action = '$Action'
code = '''$($Secret.code)'''

pid = subprocess.check_output(['systemctl', 'show', service, '-p', 'MainPID', '--value'], text=True).strip()
env = {}
with open(f'/proc/{pid}/environ', 'rb') as f:
    for item in f.read().split(b'\x00'):
        if b'=' in item:
            k, v = item.split(b'=', 1)
            env[k.decode()] = v.decode()

backend = env.get('ZTOOL_DB_BACKEND', 'sqlite')
if backend != 'mysql':
    raise SystemExit(json.dumps({'status': 'FAIL', 'error': 'production backend is not mysql', 'backend': backend}, ensure_ascii=False))

db = MySQLLicenseDB(
    host=env.get('ZTOOL_MYSQL_HOST', 'localhost'),
    port=int(env.get('ZTOOL_MYSQL_PORT', '3306')),
    database=env['ZTOOL_MYSQL_DB'],
    user=env['ZTOOL_MYSQL_USER'],
    password=env['ZTOOL_MYSQL_PASSWORD'],
)

def fetch():
    return db._fetchone(
        'SELECT license_key, max_activations, current_activations, is_active, '
        'is_revoked, machine_id, machine_meta, activated_at, last_check_at '
        'FROM license_keys WHERE license_key=%s',
        (code,),
    )

def redacted(row):
    return {
        'code_mask': code[:4] + '...' + code[-4:],
        'code_sha12': hashlib.sha256(code.encode()).hexdigest()[:12],
        'exists': bool(row),
        'max_activations': row.get('max_activations') if row else None,
        'current_activations': row.get('current_activations') if row else None,
        'is_active': row.get('is_active') if row else None,
        'is_revoked': row.get('is_revoked') if row else None,
        'machine_bound': bool(row and row.get('machine_id')),
        'machine_id_sha12': hashlib.sha256((row.get('machine_id') or '').encode()).hexdigest()[:12] if row and row.get('machine_id') else '',
        'machine_meta_present': bool(row and row.get('machine_meta')),
        'activated_at': str(row.get('activated_at')) if row else None,
        'last_check_at': str(row.get('last_check_at')) if row else None,
    }

before = fetch()
deleted = False
if action == 'state':
    pass
elif action == 'revoke':
    cur = db._cursor()
    cur.execute(
        'UPDATE license_keys SET is_revoked=1, is_active=0, current_activations=0, '
        'machine_id=NULL, machine_meta=NULL, activated_at=NULL, last_check_at=NULL '
        'WHERE license_key=%s',
        (code,),
    )
    db._conn.commit()
    cur.close()
elif action == 'delete-revoked':
    if before and before.get('is_active') and not before.get('is_revoked'):
        raise SystemExit(json.dumps({'status': 'FAIL', 'error': 'active license cannot be deleted; revoke first', 'before': redacted(before)}, ensure_ascii=False))
    cur = db._cursor()
    try:
        cur.execute('DELETE FROM activation_log WHERE license_key=%s', (code,))
    except Exception:
        pass
    cur.execute('DELETE FROM license_keys WHERE license_key=%s AND (is_revoked=1 OR is_active=0)', (code,))
    deleted = cur.rowcount == 1
    db._conn.commit()
    cur.close()
else:
    raise SystemExit(json.dumps({'status': 'FAIL', 'error': 'unknown action', 'action': action}, ensure_ascii=False))

after = fetch()
out = {
    'status': 'PASS',
    'backend': backend,
    'action': action,
    'before': redacted(before),
    'after': redacted(after),
    'deleted': deleted,
}
print(json.dumps(out, ensure_ascii=False, indent=2, default=str))
db.close()
"@ | Set-Content -LiteralPath $Path -Encoding UTF8
}

function Invoke-RemoteLifecycle {
    param([Parameter(Mandatory = $true)][string]$Action)

    Require-Secret
    $tmp = Join-Path ([IO.Path]::GetTempPath()) ("swtools_lifecycle_" + [Guid]::NewGuid().ToString("N") + ".py")
    Write-RemoteLifecycleScript -Action $Action -Secret $script:secret -Path $tmp
    $stdout = Join-Path $ReportDir "lifecycle-$Action-redacted.out.log"
    $stderr = Join-Path $ReportDir "lifecycle-$Action-redacted.err.log"
    Remove-Item $stdout, $stderr -ErrorAction SilentlyContinue
    try {
        scp $tmp "${SshHost}:/tmp/swtools_lifecycle_$Action.py" | Out-Null
        $remoteCommand = "cd /opt/ztool-tcp-server && .venv/bin/python /tmp/swtools_lifecycle_$Action.py; echo __DONE__"
        $p = Start-Process -FilePath ssh -ArgumentList @($SshHost, $remoteCommand) -RedirectStandardOutput $stdout -RedirectStandardError $stderr -PassThru -WindowStyle Hidden
        $deadline = (Get-Date).AddSeconds(35)
        while ((Get-Date) -lt $deadline) {
            if ((Test-Path $stdout) -and ((Get-Content $stdout -Raw -ErrorAction SilentlyContinue) -match "__DONE__")) {
                break
            }
            Start-Sleep -Milliseconds 300
        }
        if (-not $p.HasExited) {
            Stop-Process -Id $p.Id -Force -ErrorAction SilentlyContinue
        }
        $raw = ((Get-Content $stdout -Raw) -replace "__DONE__", "").Trim()
        if (-not $raw) {
            throw "empty remote lifecycle response; see $stderr"
        }
        return ($raw | ConvertFrom-Json)
    }
    finally {
        Remove-Item $tmp -Force -ErrorAction SilentlyContinue
    }
}

function Invoke-ActivationHelper {
    param([string[]]$ExtraArgs)
    Require-Secret
    $args = @(
        "-NoProfile",
        "-ExecutionPolicy", "Bypass",
        "-File", $activationScript,
        "-SecretPath", $script:secret.source,
        "-ReportDir", $ReportDir,
        "-SshHost", $SshHost,
        "-ServiceName", $ServiceName
    ) + $ExtraArgs
    & pwsh @args
    if ($LASTEXITCODE -ne 0) {
        throw "swtools_activation_acceptance.ps1 failed with exit code $LASTEXITCODE"
    }
}

if (-not ("SWToolsLifecycleEdit" -as [type])) {
Add-Type @'
using System;
using System.Runtime.InteropServices;
using System.Text;

public static class SWToolsLifecycleEdit {
  [DllImport("user32.dll", CharSet=CharSet.Unicode)]
  public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, string lParam);

  [DllImport("user32.dll", CharSet=CharSet.Unicode)]
  public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, StringBuilder lParam);

  [DllImport("user32.dll")]
  public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

  public const uint EM_SETSEL = 0x00B1;
  public const uint WM_CLEAR = 0x0303;
  public const uint EM_REPLACESEL = 0x00C2;
  public const uint WM_GETTEXT = 0x000D;
  public const uint WM_GETTEXTLENGTH = 0x000E;

  public static void Replace(IntPtr hwnd, string text) {
    SendMessage(hwnd, EM_SETSEL, IntPtr.Zero, new IntPtr(-1));
    SendMessage(hwnd, WM_CLEAR, IntPtr.Zero, IntPtr.Zero);
    SendMessage(hwnd, EM_REPLACESEL, new IntPtr(1), text);
  }

  public static string GetText(IntPtr hwnd) {
    int len = SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero).ToInt32();
    var sb = new StringBuilder(Math.Max(256, len + 2));
    SendMessage(hwnd, WM_GETTEXT, new IntPtr(sb.Capacity), sb);
    return sb.ToString();
  }
}
'@
}

function Get-InstalledRegistrationProbe {
    param([Parameter(Mandatory = $true)][string]$RuntimeDir)

    $exe = Join-Path $RuntimeDir "SWTools.exe"
    if (-not (Test-Path -LiteralPath $exe)) {
        throw "SWTools.exe not found for registration probe: $exe"
    }

    [Environment]::CurrentDirectory = $RuntimeDir
    $asm = [Reflection.Assembly]::LoadFrom($exe)
    $type = $asm.GetType(("Z" + "Tool.SR"), $true)
    $sr = [Activator]::CreateInstance($type)
    $items = @()
    foreach ($method in @("IsReg1", "IsReg2")) {
        $args = @("来生缘。。。", "", "")
        $ok = [bool]$type.GetMethod($method).Invoke($sr, $args)
        $code = [string]$args[1]
        $items += [ordered]@{
            method = $method
            ok = $ok
            code_length = $code.Length
            code_sha12 = if ($code.Length) { Get-Sha12 $code } else { "" }
            use_date = [string]$args[2]
        }
    }
    [ordered]@{
        any_registered = [bool]($items | Where-Object { $_.ok })
        methods = $items
    }
}

function Set-RegistrationFieldsByEditMessage {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string]$RegistrationCode,
        [AllowEmptyString()][string]$Password = ""
    )

    $segments = @($RegistrationCode.Trim() -split "-")
    $expectedLengths = @(8, 5, 5, 5, 9)
    if ($segments.Count -ne 5) {
        throw "Registration code must contain 5 segments"
    }
    for ($i = 0; $i -lt $expectedLengths.Count; $i++) {
        if ($segments[$i].Length -ne $expectedLengths[$i]) {
            throw "Registration segment $($i + 1) length mismatch: expected $($expectedLengths[$i]), actual $($segments[$i].Length)"
        }
    }

    $edits = @(
        Get-SWToolsWindowControls -ProcessId $ProcessId -ClassContains "EDIT" -WindowTitleContains "Регистрация" |
            Where-Object { $_.Visible } |
            Sort-Object Top, Left
    )
    if ($edits.Count -lt 7) {
        throw "Registration window must expose at least 7 EDIT controls, found $($edits.Count), pid=$ProcessId"
    }

    $targets = @($edits | Select-Object -Skip 1 -First 6)
    $values = @($segments + @($Password))
    $names = @("Licence1", "Licence2", "Licence3", "Licence4", "Licence5", "password")
    $written = @()
    for ($i = 0; $i -lt $targets.Count; $i++) {
        $hwnd = [IntPtr]([long]$targets[$i].Hwnd)
        [SWToolsLifecycleEdit]::Replace($hwnd, $values[$i])
        Start-Sleep -Milliseconds 50
        $actual = [SWToolsLifecycleEdit]::GetText($hwnd)
        $written += [ordered]@{
            name = $names[$i]
            hwnd = [long]$targets[$i].Hwnd
            expected_length = $values[$i].Length
            actual_length = $actual.Length
            exact_match = ($actual -eq $values[$i])
        }
    }
    $allExact = -not ($written | Where-Object { -not $_.exact_match })
    [ordered]@{
        process_id = $ProcessId
        method = "EM_REPLACESEL input + WM_GETTEXT readback; SetWindowText forbidden"
        segment_lengths = ($segments | ForEach-Object { $_.Length })
        password_length = $Password.Length
        all_exact_match = $allExact
        fields = $written
    }
}

function Invoke-TransferViaUi {
    Require-Secret
    Assert-MutationAllowed "TransferViaUi"
    if (-not $RuntimeDir) {
        throw "RuntimeDir is required for TransferViaUi"
    }

    $resolvedRuntime = (Resolve-Path -LiteralPath $RuntimeDir).Path
    $beforeLocal = Get-InstalledRegistrationProbe -RuntimeDir $resolvedRuntime
    if (-not $beforeLocal.any_registered) {
        throw "TransferViaUi requires an active local license before transfer"
    }

    $exe = Join-Path $resolvedRuntime "SWTools.exe"
    $proc = Get-Process SWTools -ErrorAction SilentlyContinue |
        Where-Object { $_.Path -eq $exe -and $_.MainWindowTitle -like "*Регистрация*" } |
        Sort-Object StartTime -Descending |
        Select-Object -First 1
    if (-not $proc) {
        $proc = Start-Process -FilePath $exe -ArgumentList @("0", "110") -WorkingDirectory $resolvedRuntime -PassThru
        $deadline = (Get-Date).AddSeconds(20)
        do {
            Start-Sleep -Milliseconds 250
            $proc = Get-Process SWTools -ErrorAction SilentlyContinue |
                Where-Object { $_.Path -eq $exe -and $_.MainWindowTitle -like "*Регистрация*" } |
                Sort-Object StartTime -Descending |
                Select-Object -First 1
        } while (-not $proc -and (Get-Date) -lt $deadline)
    }
    if (-not $proc) {
        throw "Registration window did not open for TransferViaUi"
    }

    $beforeTree = Join-Path $ReportDir "transfer-registration-before-fill-tree.txt"
    Export-SWToolsWindowTree -ProcessId $proc.Id -Path $beforeTree

    $readback = Set-RegistrationFieldsByEditMessage -ProcessId $proc.Id -RegistrationCode $script:secret.code -Password $script:secret.password
    $readback["code_mask"] = $script:secret.redacted.code_mask
    $readback["code_sha12"] = $script:secret.redacted.code_sha12
    $readback | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath (Join-Path $ReportDir "transfer-form-readback-redacted.json") -Encoding UTF8
    if (-not $readback.all_exact_match) {
        throw "Transfer registration field read-back failed. See transfer-form-readback-redacted.json"
    }

    Invoke-SWToolsButtonByText -ProcessId $proc.Id -Text "Перенести лицензию" -WindowTitleContains "Регистрация" -Async | Out-Null
    $success = $false
    $afterTree = Join-Path $ReportDir "transfer-after-click-window-tree.txt"
    $deadline = (Get-Date).AddSeconds(25)
    do {
        Start-Sleep -Milliseconds 500
        Export-SWToolsWindowTree -ProcessId $proc.Id -Path $afterTree
        $treeText = Get-Content -LiteralPath $afterTree -Raw
        $success = $treeText -match "Лицензия успешно перенесена"
    } while (-not $success -and (Get-Date) -lt $deadline)
    if (-not $success) {
        throw "Transfer did not show success modal. See transfer-after-click-window-tree.txt"
    }

    Invoke-SWToolsButtonByText -ProcessId $proc.Id -Text "ОК" -ClassContains "Button" -Async | Out-Null
    Start-Sleep -Milliseconds 700
    try {
        Invoke-SWToolsButtonByText -ProcessId $proc.Id -Text "Отмена" -WindowTitleContains "Регистрация" -Async | Out-Null
    }
    catch {
        Add-Warning "Registration form close after transfer was not confirmed: $($_.Exception.Message)"
    }

    $afterLocal = Get-InstalledRegistrationProbe -RuntimeDir $resolvedRuntime
    $serverState = Invoke-RemoteLifecycle -Action "state"
    $serverReleased = [bool]($serverState.after.exists -and $serverState.after.current_activations -eq 0 -and -not $serverState.after.machine_bound -and -not $serverState.after.is_revoked)

    [ordered]@{
        process_id = $proc.Id
        process_path = $proc.Path
        before_tree = $beforeTree
        after_tree = $afterTree
        before_local = $beforeLocal
        after_local = $afterLocal
        server = $serverState.after
        success_modal_seen = $success
        server_released = $serverReleased
        local_unregistered = (-not $afterLocal.any_registered)
    }
}

Add-Stage -Name "00-contract" -Status "PASS" -Summary "Lifecycle gate is redacted and never grants Production GO." -Details @{
    production_go_allowed = $false
    mutation_requires_flag = $true
}

$script:secret = $null
if ($SecretPath) {
    $script:secret = Read-LicenseSecretRedacted -Path $SecretPath
    $result.license_secret = $script:secret.redacted
    Add-Stage -Name "01-secret-shape" -Status "PASS" -Summary "License secret shape is valid; raw values are not written to result." -Details @{
        code_mask = $script:secret.redacted.code_mask
        code_sha12 = $script:secret.redacted.code_sha12
        segment_lengths = $script:secret.redacted.segment_lengths
        password_length = $script:secret.redacted.password_length
    }
}
else {
    Add-Stage -Name "01-secret-shape" -Status "SKIP" -Summary "SecretPath not provided; live lifecycle stages are disabled."
}

if ($RuntimeDir) {
    $resolvedRuntime = (Resolve-Path -LiteralPath $RuntimeDir).Path
    $exe = Join-Path $resolvedRuntime "SWTools.exe"
    $dll = Join-Path $resolvedRuntime "SWTools.dll"
    $result.runtime = [ordered]@{
        dir = $resolvedRuntime
        exe_sha256 = if (Test-Path -LiteralPath $exe) { (Get-FileHash -LiteralPath $exe -Algorithm SHA256).Hash.ToLowerInvariant() } else { "" }
        dll_sha256 = if (Test-Path -LiteralPath $dll) { (Get-FileHash -LiteralPath $dll -Algorithm SHA256).Hash.ToLowerInvariant() } else { "" }
    }
}

try {
    if ($RequireNoLicenseWindow) {
        $proc = Get-Process SWTools -ErrorAction Stop | Sort-Object StartTime -Descending | Select-Object -First 1
        $titles = @(Get-SWToolsWindowTitles -ProcessId $proc.Id)
        $treePath = Join-Path $ReportDir "no-license-window-tree.txt"
        Export-SWToolsWindowTree -ProcessId $proc.Id -Path $treePath
        $treeText = Get-Content -LiteralPath $treePath -Raw
        $hasNoLicense = $treeText -match "Лицензия не обнаружена"
        Add-Stage -Name "02-no-license" -Status ($(if ($hasNoLicense) { "PASS" } else { "FAIL" })) -Summary "No-license UI is visible." -Details @{
            process_id = $proc.Id
            process_path = $proc.Path
            titles = $titles
            tree_path = $treePath
        }
    }
    else {
        Add-Stage -Name "02-no-license" -Status "SKIP" -Summary "No-license UI check not requested."
    }

    if ($ProvisionProductionKey) {
        Assert-MutationAllowed "ProvisionProductionKey"
        Invoke-ActivationHelper -ExtraArgs @("-ProvisionProductionKey", "-ServerOnly")
        Add-Stage -Name "03-server-provision" -Status "PASS" -Summary "Production key provision command completed." -Details @{ report_dir = $ReportDir }
    }
    else {
        Add-Stage -Name "03-server-provision" -Status "SKIP" -Summary "ProvisionProductionKey not requested."
    }

    if ($ResetProductionBinding) {
        Assert-MutationAllowed "ResetProductionBinding"
        Invoke-ActivationHelper -ExtraArgs @("-ResetProductionBinding", "-ServerOnly")
        Add-Stage -Name "03b-server-reset-binding" -Status "PASS" -Summary "Production key binding reset completed." -Details @{ report_dir = $ReportDir }
    }

    if ($FillActivationForm -or $ClickActivate) {
        if ($ClickActivate) {
            Assert-MutationAllowed "ClickActivate"
        }
        $extra = @()
        if ($ClickActivate) { $extra += "-ClickActivate" }
        Invoke-ActivationHelper -ExtraArgs $extra
        $restartPath = Join-Path $ReportDir "activation-restart-redacted.json"
        $restart = if (Test-Path -LiteralPath $restartPath) {
            Get-Content -LiteralPath $restartPath -Raw | ConvertFrom-Json
        } else {
            $null
        }
        $restartConfirmed = [bool]($restart -and $restart.success_modal_seen -and -not $restart.old_pid_still_running)
        Add-Stage -Name "04-activation" -Status ($(if ($ClickActivate -and -not $restartConfirmed) { "FAIL" } else { "PASS" })) -Summary "Activation form input/activation helper completed." -Details @{
            click_activate = [bool]$ClickActivate
            restart_confirmed = $restartConfirmed
            report_dir = $ReportDir
        }
    }
    else {
        Add-Stage -Name "04-activation" -Status "SKIP" -Summary "Activation UI stage not requested."
    }

    if ($VerifyActiveServerState) {
        $state = Invoke-RemoteLifecycle -Action "state"
        $active = [bool]($state.after.exists -and $state.after.current_activations -ge 1 -and -not $state.after.is_revoked)
        Add-Stage -Name "05-server-active-state" -Status ($(if ($active) { "PASS" } else { "FAIL" })) -Summary "Server reports active bound license." -Details @{
            current_activations = $state.after.current_activations
            is_active = $state.after.is_active
            is_revoked = $state.after.is_revoked
            machine_bound = $state.after.machine_bound
            machine_id_sha12 = $state.after.machine_id_sha12
        }
    }
    else {
        Add-Stage -Name "05-server-active-state" -Status "SKIP" -Summary "Server active-state check not requested."
    }

    if ($TransferViaUi) {
        $transfer = Invoke-TransferViaUi
        $transferPassed = [bool]($transfer.success_modal_seen -and $transfer.server_released -and $transfer.local_unregistered)
        Add-Stage -Name "05b-transfer-ui" -Status ($(if ($transferPassed) { "PASS" } else { "FAIL" })) -Summary "Registration UI transfers/releases the production license." -Details @{
            process_id = $transfer.process_id
            process_path = $transfer.process_path
            success_modal_seen = $transfer.success_modal_seen
            server_released = $transfer.server_released
            local_unregistered = $transfer.local_unregistered
            current_activations = $transfer.server.current_activations
            is_active = $transfer.server.is_active
            is_revoked = $transfer.server.is_revoked
            machine_bound = $transfer.server.machine_bound
            machine_id_sha12 = $transfer.server.machine_id_sha12
            before_tree = $transfer.before_tree
            after_tree = $transfer.after_tree
        }
    }
    else {
        Add-Stage -Name "05b-transfer-ui" -Status "SKIP" -Summary "TransferViaUi not requested."
    }

    if ($RevokeProductionKey) {
        Assert-MutationAllowed "RevokeProductionKey"
        $state = Invoke-RemoteLifecycle -Action "revoke"
        $revoked = [bool]($state.after.exists -and $state.after.is_revoked)
        Add-Stage -Name "06-revoke" -Status ($(if ($revoked) { "PASS" } else { "FAIL" })) -Summary "Production license key revoked." -Details @{
            is_active = $state.after.is_active
            is_revoked = $state.after.is_revoked
            current_activations = $state.after.current_activations
            machine_bound = $state.after.machine_bound
        }
    }
    else {
        Add-Stage -Name "06-revoke" -Status "SKIP" -Summary "RevokeProductionKey not requested."
    }

    if ($DeleteRevokedProductionKey) {
        Assert-MutationAllowed "DeleteRevokedProductionKey"
        $state = Invoke-RemoteLifecycle -Action "delete-revoked"
        Add-Stage -Name "07-delete-revoked" -Status ($(if ($state.deleted) { "PASS" } else { "FAIL" })) -Summary "Revoked production license key physically deleted." -Details @{
            deleted = [bool]$state.deleted
            existed_before = [bool]$state.before.exists
            exists_after = [bool]$state.after.exists
        }
    }
    else {
        Add-Stage -Name "07-delete-revoked" -Status "SKIP" -Summary "DeleteRevokedProductionKey not requested."
    }

    if ($RepeatPostRevokeCheck) {
        $proc = Get-Process SWTools -ErrorAction SilentlyContinue | Sort-Object StartTime -Descending | Select-Object -First 1
        if ($proc) {
            $treePath = Join-Path $ReportDir "repeat-check-window-tree.txt"
            Export-SWToolsWindowTree -ProcessId $proc.Id -Path $treePath
            $treeText = Get-Content -LiteralPath $treePath -Raw
            $blocked = $treeText -match "Лицензия не обнаружена|отозван|revoked"
            Add-Stage -Name "08-repeat-check" -Status ($(if ($blocked) { "PASS" } else { "FAIL" })) -Summary "Client blocks usage after revoked/deleted server state." -Details @{
                process_id = $proc.Id
                process_path = $proc.Path
                tree_path = $treePath
            }
        }
        else {
            Add-Stage -Name "08-repeat-check" -Status "FAIL" -Summary "SWTools process is not running for repeat check."
        }
    }
    else {
        Add-Stage -Name "08-repeat-check" -Status "SKIP" -Summary "Repeat post-revoke client check not requested."
    }
}
catch {
    Add-Stage -Name "99-error" -Status "FAIL" -Summary $_.Exception.Message
}

$resultPath = Join-Path $ReportDir "license-lifecycle-result.json"
$result | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $resultPath -Encoding UTF8
Write-Host "license lifecycle status: $($result.status)"
Write-Host "license lifecycle result: $resultPath"
if ($result.status -eq "FAIL") {
    exit 1
}
