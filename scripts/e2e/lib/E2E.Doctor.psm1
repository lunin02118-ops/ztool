Set-StrictMode -Version Latest

function New-DoctorCheck {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,
        [ValidateSet('PASS', 'WARN', 'FAIL')]
        [string]$Status,
        [string]$Message = '',
        [object]$Details = $null
    )
    $check = [ordered]@{
        name = $Name
        status = $Status
        message = $Message
    }
    if ($null -ne $Details) { $check.details = $Details }
    return $check
}

function Test-CommandAvailable {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Command,
        [switch]$Required
    )
    $cmd = Get-Command $Command -ErrorAction SilentlyContinue
    if ($cmd) {
        return New-DoctorCheck -Name $Command -Status PASS -Message $cmd.Source
    }
    $status = if ($Required) { 'FAIL' } else { 'WARN' }
    return New-DoctorCheck -Name $Command -Status $status -Message "$Command not found"
}

function Test-PathCheck {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,
        [string]$Path,
        [switch]$Required
    )
    if (-not $Path) {
        $status = if ($Required) { 'FAIL' } else { 'WARN' }
        return New-DoctorCheck -Name $Name -Status $status -Message 'path not provided'
    }
    if (Test-Path -LiteralPath $Path) {
        return New-DoctorCheck -Name $Name -Status PASS -Message ([System.IO.Path]::GetFullPath($Path))
    }
    $status = if ($Required) { 'FAIL' } else { 'WARN' }
    return New-DoctorCheck -Name $Name -Status $status -Message "missing: $Path"
}

function Test-PythonModules {
    param(
        [switch]$Required
    )
    $python = Get-Command python -ErrorAction SilentlyContinue
    if (-not $python) {
        $status = if ($Required) { 'FAIL' } else { 'WARN' }
        return New-DoctorCheck -Name 'python-uia-modules' -Status $status -Message 'python not found'
    }
    $code = "import win32com.client, pywinauto, psutil; print('ok')"
    $output = & python -c $code 2>&1
    if ($LASTEXITCODE -eq 0) {
        return New-DoctorCheck -Name 'python-uia-modules' -Status PASS -Message 'win32com.client, pywinauto, psutil'
    }
    $status = if ($Required) { 'FAIL' } else { 'WARN' }
    return New-DoctorCheck -Name 'python-uia-modules' -Status $status -Message (($output | Out-String).Trim())
}

function Get-ProcessSnapshot {
    $items = @()
    foreach ($name in @('SLDWORKS.exe', 'SWTools.exe')) {
        Get-CimInstance Win32_Process -Filter "Name='$name'" -ErrorAction SilentlyContinue | ForEach-Object {
            $items += [ordered]@{
                name = $_.Name
                process_id = $_.ProcessId
                executable_path = $_.ExecutablePath
                command_line = $_.CommandLine
            }
        }
    }
    return $items
}

function Get-SWToolsAddinRegistrySnapshot {
    $guid = '{59959DFA-3229-4B86-852E-52ABF2BDB8C0}'
    function Get-PropValue([object]$Object, [string]$Name) {
        $prop = $Object.PSObject.Properties[$Name]
        if ($prop) { return $prop.Value }
        return $null
    }
    $paths = @(
        "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\SolidWorks\AddIns\$guid",
        "Registry::HKEY_CURRENT_USER\SOFTWARE\SolidWorks\AddInsStartup\$guid"
    )
    $items = @()
    foreach ($path in $paths) {
        if (Test-Path -LiteralPath $path) {
            $props = Get-ItemProperty -LiteralPath $path
            $items += [ordered]@{
                path = $path
                title = Get-PropValue $props 'Title'
                description = Get-PropValue $props 'Description'
                codebase = Get-PropValue $props 'CodeBase'
                load_at_startup = Get-PropValue $props 'LoadAtStartup'
                default = Get-PropValue $props '(default)'
            }
        }
        else {
            $items += [ordered]@{ path = $path; missing = $true }
        }
    }
    return $items
}

function Invoke-E2EDoctor {
    param(
        [string]$SolidWorksExe = '',
        [string]$SolidWorksDir = '',
        [string]$SolidWorksToolsDll = '',
        [string]$TestAssembly = '',
        [switch]$RequireSolidWorks
    )

    if (-not $SolidWorksDir -and $SolidWorksExe) {
        $SolidWorksDir = Split-Path -Parent $SolidWorksExe
    }
    if (-not $SolidWorksExe -and $env:SOLIDWORKS_EXE) { $SolidWorksExe = $env:SOLIDWORKS_EXE }
    if (-not $SolidWorksDir -and $env:SOLIDWORKS_DIR) { $SolidWorksDir = $env:SOLIDWORKS_DIR }
    if (-not $SolidWorksToolsDll -and $env:SOLIDWORKS_TOOLS_DLL) { $SolidWorksToolsDll = $env:SOLIDWORKS_TOOLS_DLL }
    if (-not $TestAssembly -and $env:SWTOOLS_TEST_MODEL) { $TestAssembly = $env:SWTOOLS_TEST_MODEL }
    if (-not $SolidWorksExe -and $SolidWorksDir) { $SolidWorksExe = Join-Path $SolidWorksDir 'SLDWORKS.exe' }
    if (-not $SolidWorksToolsDll -and $SolidWorksDir) { $SolidWorksToolsDll = Join-Path $SolidWorksDir 'SolidWorksTools.dll' }

    $checks = @()
    $checks += New-DoctorCheck -Name 'powershell' -Status PASS -Message $PSVersionTable.PSVersion.ToString() -Details @{ edition = $PSVersionTable.PSEdition }
    if ($PSVersionTable.PSVersion.Major -lt 7) {
        $checks += New-DoctorCheck -Name 'powershell-7-recommended' -Status WARN -Message 'PowerShell 7 is recommended for runner parity'
    }
    $checks += Test-CommandAvailable -Command git -Required
    $checks += Test-CommandAvailable -Command dotnet -Required
    $checks += Test-CommandAvailable -Command python -Required
    $checks += Test-CommandAvailable -Command makensis
    $checks += Test-PythonModules -Required:$RequireSolidWorks

    $regAsm = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe'
    $checks += Test-PathCheck -Name 'RegAsm x64' -Path $regAsm -Required

    $checks += Test-PathCheck -Name 'SolidWorks exe' -Path $SolidWorksExe -Required:$RequireSolidWorks
    $checks += Test-PathCheck -Name 'SolidWorksTools.dll' -Path $SolidWorksToolsDll -Required:$RequireSolidWorks
    $checks += Test-PathCheck -Name 'test assembly' -Path $TestAssembly -Required:$RequireSolidWorks

    if ([Environment]::UserInteractive) {
        $checks += New-DoctorCheck -Name 'interactive-session' -Status PASS -Message 'UserInteractive=true'
    }
    else {
        $status = if ($RequireSolidWorks) { 'FAIL' } else { 'WARN' }
        $checks += New-DoctorCheck -Name 'interactive-session' -Status $status -Message 'UserInteractive=false; live SolidWorks UIA cannot be accepted'
    }

    foreach ($name in @('WINDIR', 'SystemRoot', 'ComSpec')) {
        $value = [Environment]::GetEnvironmentVariable($name)
        if ($value) {
            $checks += New-DoctorCheck -Name "env:$name" -Status PASS -Message $value
        }
        else {
            $checks += New-DoctorCheck -Name "env:$name" -Status WARN -Message "$name is empty; shell-launched SolidWorks can fail"
        }
    }

    $processes = Get-ProcessSnapshot
    if (@($processes).Count -gt 0) {
        $checks += New-DoctorCheck -Name 'stale-processes' -Status WARN -Message 'SLDWORKS.exe or SWTools.exe already running' -Details $processes
    }
    else {
        $checks += New-DoctorCheck -Name 'stale-processes' -Status PASS -Message 'no SLDWORKS.exe/SWTools.exe running'
    }

    $registry = Get-SWToolsAddinRegistrySnapshot
    $checks += New-DoctorCheck -Name 'swtools-addin-registry-snapshot' -Status PASS -Message 'snapshot captured' -Details $registry

    $status = 'PASS'
    if ($checks | Where-Object { $_.status -eq 'FAIL' }) {
        $status = 'FAIL'
    }
    elseif ($checks | Where-Object { $_.status -eq 'WARN' }) {
        $status = 'WARN'
    }

    return [ordered]@{
        status = $status
        require_solidworks = [bool]$RequireSolidWorks
        solidworks_exe = $SolidWorksExe
        solidworks_tools_dll = $SolidWorksToolsDll
        test_assembly = $TestAssembly
        checks = $checks
    }
}

Export-ModuleMember -Function Invoke-E2EDoctor
