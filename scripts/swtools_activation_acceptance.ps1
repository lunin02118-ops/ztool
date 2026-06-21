<#
.SYNOPSIS
  Production activation helper for the SWTools clean-install acceptance gate.

.DESCRIPTION
  Reads one local secret file, provisions the same key into the real production
  backend selected by ztool-tcp-server.service, fills the open registration form,
  invokes online activation, and records redacted evidence.

  The script intentionally never prints the full code/password. It also avoids
  SetWindowText: code fields are filled through EDIT EM_REPLACESEL and verified
  through WM_GETTEXT, then the result is trusted only after server-side audit.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$SecretPath,

    [string]$ReportDir = "manual-test-reports\swtools-activation",

    [string]$SshHost = "04-rheolab-license",

    [string]$ServiceName = "ztool-tcp-server.service",

    [switch]$ProvisionProductionKey,

    [switch]$ClickActivate
)

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
. (Join-Path $PSScriptRoot "swtools_acceptance_ui.ps1")

New-Item -ItemType Directory -Force -Path $ReportDir | Out-Null
$ReportDir = (Resolve-Path $ReportDir).Path

function Get-Sha12 {
    param([Parameter(Mandatory = $true)][string]$Text)
    $bytes = [Text.Encoding]::UTF8.GetBytes($Text)
    [BitConverter]::ToString([Security.Cryptography.SHA256]::Create().ComputeHash($bytes)).Replace("-", "").Substring(0, 12).ToLowerInvariant()
}

function Read-LicenseSecret {
    param([Parameter(Mandatory = $true)][string]$Path)

    $resolved = if (Test-Path -LiteralPath $Path) {
        (Resolve-Path -LiteralPath $Path).Path
    } else {
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
    if ($null -eq $password) {
        $password = ""
    }

    [ordered]@{
        code = $code
        password = $password
        source = $resolved
        mask = $code.Substring(0, 4) + "..." + $code.Substring($code.Length - 4)
        sha12 = Get-Sha12 $code
        segment_lengths = @($code -split "-" | ForEach-Object { $_.Length })
        password_length = $password.Length
        password_sha12 = if ($password.Length) { Get-Sha12 $password } else { "" }
    }
}

function Invoke-RemotePython {
    param(
        [Parameter(Mandatory = $true)][string]$ScriptPath,
        [Parameter(Mandatory = $true)][string]$RemoteName,
        [Parameter(Mandatory = $true)][string]$StdoutName,
        [Parameter(Mandatory = $true)][string]$StderrName
    )

    $stdout = Join-Path $ReportDir $StdoutName
    $stderr = Join-Path $ReportDir $StderrName
    Remove-Item $stdout, $stderr -ErrorAction SilentlyContinue

    scp $ScriptPath "${SshHost}:/tmp/$RemoteName" | Out-Null
    $remoteCommand = "cd /opt/ztool-tcp-server && .venv/bin/python /tmp/$RemoteName; echo __DONE__"
    $p = Start-Process -FilePath ssh `
        -ArgumentList @($SshHost, $remoteCommand) `
        -RedirectStandardOutput $stdout `
        -RedirectStandardError $stderr `
        -PassThru `
        -WindowStyle Hidden

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

    ((Get-Content $stdout -Raw) -replace "__DONE__", "").Trim()
}

function Write-RemoteProvisionScript {
    param(
        [Parameter(Mandatory = $true)][System.Collections.IDictionary]$Secret,
        [Parameter(Mandatory = $true)][string]$Path
    )

@"
import os, sys, json, hashlib, subprocess
sys.path.insert(0, '/opt/ztool-tcp-server')
from ztool_license_server.db_mysql import MySQLLicenseDB

service = '$ServiceName'
pid = subprocess.check_output(['systemctl', 'show', service, '-p', 'MainPID', '--value'], text=True).strip()
env = {}
with open(f'/proc/{pid}/environ', 'rb') as f:
    for item in f.read().split(b'\x00'):
        if b'=' in item:
            k, v = item.split(b'=', 1)
            env[k.decode()] = v.decode()

code = '''$($Secret.code)'''
password = '''$($Secret.password)'''
backend = env.get('ZTOOL_DB_BACKEND', 'sqlite')
if backend != 'mysql':
    raise SystemExit(json.dumps({'error': 'production backend is not mysql', 'backend': backend}, ensure_ascii=False))

db = MySQLLicenseDB(
    host=env.get('ZTOOL_MYSQL_HOST', 'localhost'),
    port=int(env.get('ZTOOL_MYSQL_PORT', '3306')),
    database=env['ZTOOL_MYSQL_DB'],
    user=env['ZTOOL_MYSQL_USER'],
    password=env['ZTOOL_MYSQL_PASSWORD'],
)
db.add_license_code(
    code,
    password=password,
    device_limit=1,
    expires_at=None,
    note='SWTools clean-install production acceptance key'
)
row = db._fetchone(
    'SELECT license_key, max_activations, current_activations, is_active, '
    'is_revoked, machine_id, transfer_password_hash, notes '
    'FROM license_keys WHERE license_key=%s',
    (code,),
)
out = {
    'backend': backend,
    'mask': code[:4] + '...' + code[-4:],
    'sha12': hashlib.sha256(code.encode()).hexdigest()[:12],
    'segment_lengths': [len(x) for x in code.split('-')],
    'max_activations': row.get('max_activations') if row else None,
    'current_activations': row.get('current_activations') if row else None,
    'is_active': row.get('is_active') if row else None,
    'is_revoked': row.get('is_revoked') if row else None,
    'machine_bound': bool(row and row.get('machine_id')),
    'password_hash_present': bool(row and row.get('transfer_password_hash')),
    'password_check': db.check_password(code, password),
}
print(json.dumps(out, ensure_ascii=False, indent=2, default=str))
db.close()
"@ | Set-Content -LiteralPath $Path -Encoding UTF8
}

function Write-RemoteStateScript {
    param(
        [Parameter(Mandatory = $true)][System.Collections.IDictionary]$Secret,
        [Parameter(Mandatory = $true)][string]$Path
    )

@"
import os, sys, json, hashlib, subprocess
sys.path.insert(0, '/opt/ztool-tcp-server')
from ztool_license_server.db_mysql import MySQLLicenseDB

service = '$ServiceName'
pid = subprocess.check_output(['systemctl', 'show', service, '-p', 'MainPID', '--value'], text=True).strip()
env = {}
with open(f'/proc/{pid}/environ', 'rb') as f:
    for item in f.read().split(b'\x00'):
        if b'=' in item:
            k, v = item.split(b'=', 1)
            env[k.decode()] = v.decode()

code = '''$($Secret.code)'''
db = MySQLLicenseDB(
    host=env.get('ZTOOL_MYSQL_HOST', 'localhost'),
    port=int(env.get('ZTOOL_MYSQL_PORT', '3306')),
    database=env['ZTOOL_MYSQL_DB'],
    user=env['ZTOOL_MYSQL_USER'],
    password=env['ZTOOL_MYSQL_PASSWORD'],
)
row = db._fetchone(
    'SELECT current_activations, max_activations, machine_id, machine_meta, '
    'activated_at, last_check_at, is_active, is_revoked '
    'FROM license_keys WHERE license_key=%s',
    (code,),
)
logs = []
try:
    cur = db._cursor()
    cur.execute(
        'SELECT action, success, error_message, created_at '
        'FROM activation_log WHERE license_key=%s ORDER BY id DESC LIMIT 5',
        (code,),
    )
    logs = cur.fetchall()
    cur.close()
except Exception as e:
    logs = [{'error': repr(e)}]

out = {
    'code_mask': code[:4] + '...' + code[-4:],
    'code_sha12': hashlib.sha256(code.encode()).hexdigest()[:12],
    'current_activations': row.get('current_activations') if row else None,
    'max_activations': row.get('max_activations') if row else None,
    'machine_bound': bool(row and row.get('machine_id')),
    'machine_id_sha12': hashlib.sha256((row.get('machine_id') or '').encode()).hexdigest()[:12] if row and row.get('machine_id') else '',
    'machine_meta_present': bool(row and row.get('machine_meta')),
    'is_active': row.get('is_active') if row else None,
    'is_revoked': row.get('is_revoked') if row else None,
    'activated_at': str(row.get('activated_at')) if row else None,
    'last_check_at': str(row.get('last_check_at')) if row else None,
    'recent_log': logs,
}
print(json.dumps(out, ensure_ascii=False, indent=2, default=str))
db.close()
"@ | Set-Content -LiteralPath $Path -Encoding UTF8
}

if (-not ("SWToolsActivationEdit" -as [type])) {
Add-Type @'
using System;
using System.Runtime.InteropServices;
using System.Text;

public static class SWToolsActivationEdit {
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

$secret = Read-LicenseSecret -Path $SecretPath
    $summary = [ordered]@{
    code_mask = $secret.mask
    code_sha12 = $secret.sha12
    segment_lengths = $secret.segment_lengths
    password_length = $secret.password_length
    password_sha12 = $secret.password_sha12
    source_file = Split-Path -Leaf $secret.source
}
$summary | ConvertTo-Json -Depth 4 | Set-Content -LiteralPath (Join-Path $ReportDir "activation-secret-redacted.json") -Encoding UTF8

if ($ProvisionProductionKey) {
    $tmp = Join-Path ([IO.Path]::GetTempPath()) ("swtools_provision_" + [Guid]::NewGuid().ToString("N") + ".py")
    Write-RemoteProvisionScript -Secret $secret -Path $tmp
    $provision = Invoke-RemotePython -ScriptPath $tmp -RemoteName "swtools_provision_key.py" -StdoutName "activation-provision-mysql-redacted.out.log" -StderrName "activation-provision-mysql-redacted.err.log"
    Remove-Item $tmp -Force -ErrorAction SilentlyContinue
    $provision
}

$process = Get-Process SWTools -ErrorAction Stop | Sort-Object StartTime -Descending | Select-Object -First 1
$controls = @(
    Get-SWToolsWindowControls -ProcessId $process.Id -ClassContains "EDIT" -WindowTitleContains "Регистрация" |
        Where-Object { $_.Visible } |
        Sort-Object Top, Left
)
if ($controls.Count -lt 7) {
    throw "Open the SWTools registration window first; found $($controls.Count) EDIT controls."
}

$orderedEdits = @($controls | Sort-Object Top, Left)
# Registration form EDIT order is stable: device-info textbox, five code
# segments, then the optional transfer password. Avoid screen-coordinate gates.
$codeFields = @($orderedEdits | Select-Object -Skip 1 -First 5)
$passwordField = @($orderedEdits | Select-Object -Skip 6 -First 1)
if ($codeFields.Count -ne 5 -or -not $passwordField) {
    throw "Registration fields were not found: code=$($codeFields.Count), password=$([bool]$passwordField)."
}

$segments = @($secret.code -split "-")
$fields = @()
for ($i = 0; $i -lt 5; $i++) {
    [SWToolsActivationEdit]::Replace([IntPtr]([long]$codeFields[$i].Hwnd), $segments[$i])
    Start-Sleep -Milliseconds 50
    $actual = [SWToolsActivationEdit]::GetText([IntPtr]([long]$codeFields[$i].Hwnd))
    $fields += [ordered]@{
        index = $i + 1
        hwnd = [long]$codeFields[$i].Hwnd
        expected_length = $segments[$i].Length
        actual_length = $actual.Length
        exact_match = ($actual -eq $segments[$i])
    }
}
[SWToolsActivationEdit]::Replace([IntPtr]([long]$passwordField[0].Hwnd), $secret.password)
$passwordActual = [SWToolsActivationEdit]::GetText([IntPtr]([long]$passwordField[0].Hwnd))

$readback = [ordered]@{
    timestamp = (Get-Date).ToString("s")
    process_id = $process.Id
    process_path = $process.Path
    code_mask = $secret.mask
    code_sha12 = $secret.sha12
    method = "EM_REPLACESEL input + WM_GETTEXT readback; SetWindowText forbidden"
    fields = $fields
    password_length = $secret.password_length
    password_exact_match = ($passwordActual -eq $secret.password)
    all_exact_match = (-not ($fields | Where-Object { -not $_.exact_match })) -and ($passwordActual -eq $secret.password)
}
$readback | ConvertTo-Json -Depth 6 | Set-Content -LiteralPath (Join-Path $ReportDir "activation-form-readback-redacted.json") -Encoding UTF8
if (-not $readback.all_exact_match) {
    throw "Registration field read-back failed. See activation-form-readback-redacted.json"
}

if ($ClickActivate) {
    $oldPid = $process.Id
    Invoke-SWToolsButtonByText -ProcessId $oldPid -Text "Активация онлайн" -WindowTitleContains "Регистрация" -Async | Out-Null
    Start-Sleep -Seconds 8
    $treePath = Join-Path $ReportDir "activation-after-click-window-tree.txt"
    Export-SWToolsWindowTree -ProcessId $oldPid -Path $treePath
    $treeText = Get-Content -LiteralPath $treePath -Raw
    $successModal = $treeText -match "Регистрация выполнена"
    if ($successModal) {
        Invoke-SWToolsButtonByText -ProcessId $oldPid -Text "ОК" -ClassContains "Button" -Async | Out-Null
        Start-Sleep -Seconds 10
        $newProcesses = @(
            Get-Process SWTools -ErrorAction SilentlyContinue |
                Sort-Object StartTime -Descending |
                Select-Object Id, StartTime, MainWindowTitle, Path
        )
        [ordered]@{
            timestamp = (Get-Date).ToString("s")
            old_pid = $oldPid
            success_modal_seen = $true
            old_pid_still_running = [bool](Get-Process -Id $oldPid -ErrorAction SilentlyContinue)
            processes = $newProcesses
        } | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath (Join-Path $ReportDir "activation-restart-redacted.json") -Encoding UTF8
    }

    $stateTmp = Join-Path ([IO.Path]::GetTempPath()) ("swtools_state_" + [Guid]::NewGuid().ToString("N") + ".py")
    Write-RemoteStateScript -Secret $secret -Path $stateTmp
    $serverState = Invoke-RemotePython -ScriptPath $stateTmp -RemoteName "swtools_activation_state.py" -StdoutName "activation-server-state-redacted.out.log" -StderrName "activation-server-state-redacted.err.log"
    Remove-Item $stateTmp -Force -ErrorAction SilentlyContinue
    $serverState
}
