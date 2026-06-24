Set-StrictMode -Version Latest

function Get-E2ERepoRoot {
    $root = Join-Path $PSScriptRoot '..\..\..'
    return (Resolve-Path -LiteralPath $root).Path
}

function New-E2EReportDir {
    param(
        [string]$OutputDir
    )
    $repoRoot = Get-E2ERepoRoot
    if (-not $OutputDir) {
        $stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
        $OutputDir = Join-Path $repoRoot "_local_artifacts\reports\e2e\$stamp"
    }
    $full = [System.IO.Path]::GetFullPath($OutputDir)
    New-Item -ItemType Directory -Force -Path $full | Out-Null
    return $full
}

function Get-E2EGitInfo {
    $repoRoot = Get-E2ERepoRoot
    $commit = (& git -C $repoRoot rev-parse HEAD 2>$null)
    $branch = (& git -C $repoRoot rev-parse --abbrev-ref HEAD 2>$null)
    $dirty = [bool](& git -C $repoRoot status --porcelain 2>$null)
    return [ordered]@{
        commit = ([string]$commit).Trim()
        branch = ([string]$branch).Trim()
        dirty = $dirty
    }
}

function New-E2EResult {
    param(
        [string]$OutputDir,
        [string]$Mode = 'foundation'
    )
    return [ordered]@{
        schema_version = '1.0'
        status = 'PASS'
        production_go_allowed = $false
        mode = $Mode
        generated_at = (Get-Date).ToUniversalTime().ToString('o')
        output_dir = $OutputDir
        git = Get-E2EGitInfo
        stages = @()
        warnings = @()
        errors = @()
        artifacts = [ordered]@{}
    }
}

function Add-E2EWarning {
    param(
        [Parameter(Mandatory = $true)]
        [System.Collections.IDictionary]$Result,
        [Parameter(Mandatory = $true)]
        [string]$Message
    )
    $Result.warnings = @($Result.warnings) + @($Message)
    if ($Result.status -eq 'PASS') {
        $Result.status = 'PASS_WITH_WARN'
    }
}

function Add-E2EError {
    param(
        [Parameter(Mandatory = $true)]
        [System.Collections.IDictionary]$Result,
        [Parameter(Mandatory = $true)]
        [string]$Message
    )
    $Result.errors = @($Result.errors) + @($Message)
    $Result.status = 'FAIL'
}

function Add-E2EStage {
    param(
        [Parameter(Mandatory = $true)]
        [System.Collections.IDictionary]$Result,
        [Parameter(Mandatory = $true)]
        [string]$Name,
        [ValidateSet('PASS', 'WARN', 'FAIL', 'SKIP')]
        [string]$Status,
        [string]$Summary = '',
        [object]$Details = $null
    )
    $stage = [ordered]@{
        name = $Name
        status = $Status
        summary = $Summary
    }
    if ($null -ne $Details) {
        $stage.details = $Details
    }
    $Result.stages = @($Result.stages) + @($stage)
    if ($Status -eq 'WARN') {
        Add-E2EWarning -Result $Result -Message "${Name}: $Summary"
    }
    elseif ($Status -eq 'SKIP') {
        Add-E2EWarning -Result $Result -Message "${Name}: skipped - $Summary"
    }
    elseif ($Status -eq 'FAIL') {
        Add-E2EError -Result $Result -Message "${Name}: $Summary"
    }
}

function Write-E2EJson {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path,
        [Parameter(Mandatory = $true)]
        [object]$Value
    )
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $Path) | Out-Null
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($Path, ($Value | ConvertTo-Json -Depth 20), $encoding)
}

function Write-E2ESummary {
    param(
        [Parameter(Mandatory = $true)]
        [System.Collections.IDictionary]$Result,
        [Parameter(Mandatory = $true)]
        [string]$Path
    )
    $lines = New-Object System.Collections.Generic.List[string]
    $lines.Add('# SWTools E2E summary')
    $lines.Add('')
    $lines.Add("Status: $($Result.status)")
    $lines.Add("Production GO allowed: $($Result.production_go_allowed)")
    $lines.Add("Commit: $($Result.git.commit)")
    $lines.Add("Branch: $($Result.git.branch)")
    $lines.Add("Dirty: $($Result.git.dirty)")
    $lines.Add('')
    $lines.Add('## Stages')
    foreach ($stage in $Result.stages) {
        $lines.Add("- $($stage.status) ``$($stage.name)``: $($stage.summary)")
    }
    if (@($Result.warnings).Count -gt 0) {
        $lines.Add('')
        $lines.Add('## Warnings')
        foreach ($warning in $Result.warnings) { $lines.Add("- $warning") }
    }
    if (@($Result.errors).Count -gt 0) {
        $lines.Add('')
        $lines.Add('## Errors')
        foreach ($err in $Result.errors) { $lines.Add("- $err") }
    }
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $Path) | Out-Null
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllLines($Path, $lines, $encoding)
}

function Get-E2EFileSha256 {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path
    )
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

function Invoke-E2ECommand {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,
        [Parameter(Mandatory = $true)]
        [string]$FilePath,
        [string[]]$Arguments = @(),
        [string]$LogPath = ''
    )
    $psi = New-Object System.Diagnostics.ProcessStartInfo
    $psi.FileName = $FilePath
    foreach ($arg in $Arguments) { [void]$psi.ArgumentList.Add($arg) }
    $psi.WorkingDirectory = Get-E2ERepoRoot
    $psi.UseShellExecute = $false
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    $psi.StandardOutputEncoding = [System.Text.Encoding]::UTF8
    $psi.StandardErrorEncoding = [System.Text.Encoding]::UTF8

    $proc = New-Object System.Diagnostics.Process
    $proc.StartInfo = $psi
    [void]$proc.Start()
    $stdout = $proc.StandardOutput.ReadToEnd()
    $stderr = $proc.StandardError.ReadToEnd()
    $proc.WaitForExit()

    if ($LogPath) {
        New-Item -ItemType Directory -Force -Path (Split-Path -Parent $LogPath) | Out-Null
        $encoding = New-Object System.Text.UTF8Encoding($false)
        [System.IO.File]::WriteAllText($LogPath, "COMMAND: $FilePath $($Arguments -join ' ')`n`nSTDOUT:`n$stdout`n`nSTDERR:`n$stderr", $encoding)
    }

    return [ordered]@{
        name = $Name
        file = $FilePath
        arguments = $Arguments
        exit_code = $proc.ExitCode
        stdout = $stdout
        stderr = $stderr
        log_path = $LogPath
    }
}

Export-ModuleMember -Function `
    Get-E2ERepoRoot, `
    New-E2EReportDir, `
    Get-E2EGitInfo, `
    New-E2EResult, `
    Add-E2EWarning, `
    Add-E2EError, `
    Add-E2EStage, `
    Write-E2EJson, `
    Write-E2ESummary, `
    Get-E2EFileSha256, `
    Invoke-E2ECommand
