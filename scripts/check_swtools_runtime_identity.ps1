<#
.SYNOPSIS
  Verify installed/package runtime identity before live SolidWorks tests.
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$RuntimeDir,
    [string]$ExpectedVersion = '',
    [string]$ExpectedExeSha256 = '',
    [string]$ExpectedDllSha256 = '',
    [string]$JsonOut = ''
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $ExpectedVersion) { $ExpectedVersion = (Get-Content -LiteralPath (Join-Path $repoRoot 'VERSION') -Encoding UTF8 -Raw).Trim() }

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

function Check-File([string]$Path, [string]$Kind, [string]$ExpectedSha) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) { throw "$Kind missing: $Path" }
    $sha = Get-Sha256 $Path
    if ($ExpectedSha -and $sha -ne $ExpectedSha.ToUpperInvariant()) {
        throw "$Kind SHA mismatch: expected $ExpectedSha, got $sha"
    }
    $info = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($Path)
    if ($Kind -in @('SWTools.exe', 'SWTools.dll')) {
        if ($info.ProductName -ne 'SWTools') { throw "$Kind ProductName mismatch: '$($info.ProductName)'" }
        if (-not $info.ProductVersion -or -not $info.ProductVersion.StartsWith($ExpectedVersion, [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "$Kind ProductVersion mismatch: '$($info.ProductVersion)'"
        }
    }
    return [ordered]@{
        path = [System.IO.Path]::GetFullPath($Path)
        sha256 = $sha
        product_name = $info.ProductName
        product_version = $info.ProductVersion
        file_version = $info.FileVersion
    }
}

$runtime = (Resolve-Path -LiteralPath $RuntimeDir).Path
$exe = Join-Path $runtime 'SWTools.exe'
$dll = Join-Path $runtime 'SWTools.dll'
$resourceExt = Join-Path $runtime 'System.Resources.Extensions.dll'
$solidWorksTools = Join-Path $runtime 'SolidWorksTools.dll'

$result = [ordered]@{
    runtime_dir = $runtime
    expected_version = $ExpectedVersion
    checked_at = (Get-Date).ToUniversalTime().ToString('o')
    swtools_exe = Check-File $exe 'SWTools.exe' $ExpectedExeSha256
    swtools_dll = Check-File $dll 'SWTools.dll' $ExpectedDllSha256
    solidworks_tools_present = Test-Path -LiteralPath $solidWorksTools -PathType Leaf
    running_processes = @()
}

if (-not $result.solidworks_tools_present) {
    throw "SolidWorksTools.dll missing from runtime: $solidWorksTools"
}

if (-not (Test-Path -LiteralPath $resourceExt -PathType Leaf)) {
    throw "System.Resources.Extensions.dll missing from runtime: $resourceExt"
}
$resourceName = [System.Reflection.AssemblyName]::GetAssemblyName($resourceExt)
$result.system_resources_extensions = [ordered]@{
    path = $resourceExt
    full_name = $resourceName.FullName
    version = $resourceName.Version.ToString()
}
if ($resourceName.Version.ToString() -ne '4.0.0.0') {
    throw "System.Resources.Extensions assembly identity must be Version=4.0.0.0, got $($resourceName.FullName)"
}

Get-CimInstance Win32_Process -Filter "Name='SWTools.exe'" | ForEach-Object {
    $result.running_processes += [ordered]@{
        process_id = $_.ProcessId
        executable_path = $_.ExecutablePath
        command_line = $_.CommandLine
    }
}

if ($JsonOut) {
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $JsonOut) | Out-Null
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($JsonOut, ($result | ConvertTo-Json -Depth 8), $encoding)
}

Write-Host 'runtime identity: PASS' -ForegroundColor Green
