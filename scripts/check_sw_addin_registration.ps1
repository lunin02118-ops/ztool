<#
.SYNOPSIS
  Verify SolidWorks add-in registry points to the current SWTools runtime.
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$RuntimeDir,
    [string]$AddinGuid = '59959DFA-3229-4B86-852E-52ABF2BDB8C0',
    [string]$JsonOut = ''
)

$ErrorActionPreference = 'Stop'
$runtime = (Resolve-Path -LiteralPath $RuntimeDir).Path
$expectedDll = [System.IO.Path]::GetFullPath((Join-Path $runtime 'SWTools.dll'))

function Get-DefaultValue([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path)) { return $null }
    return (Get-Item -LiteralPath $Path).GetValue('')
}

function Get-Value([string]$Path, [string]$Name) {
    if (-not (Test-Path -LiteralPath $Path)) { return $null }
    return (Get-Item -LiteralPath $Path).GetValue($Name)
}

function Normalize-CodeBase([string]$Value) {
    if (-not $Value) { return '' }
    $text = $Value
    if ($text.StartsWith('file:///', [System.StringComparison]::OrdinalIgnoreCase)) {
        $uri = [System.Uri]$text
        return [System.IO.Path]::GetFullPath($uri.LocalPath)
    }
    return [System.IO.Path]::GetFullPath($text)
}

$hkLmAddin = "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\SolidWorks\AddIns\{$AddinGuid}"
$hkCuStartup = "Registry::HKEY_CURRENT_USER\SOFTWARE\SolidWorks\AddInsStartup\{$AddinGuid}"
$hkCrClsid = "Registry::HKEY_CLASSES_ROOT\CLSID\{$AddinGuid}\InprocServer32"

$codeBase = Normalize-CodeBase (Get-Value $hkCrClsid 'CodeBase')
$versionSubkeys = @()
if (Test-Path -LiteralPath $hkCrClsid) {
    Get-ChildItem -LiteralPath $hkCrClsid | ForEach-Object {
        $versionSubkeys += [ordered]@{
            name = $_.PSChildName
            code_base = Normalize-CodeBase ($_.GetValue('CodeBase'))
            assembly = $_.GetValue('Assembly')
        }
    }
}

$result = [ordered]@{
    addin_guid = $AddinGuid
    runtime_dir = $runtime
    expected_dll = $expectedDll
    checked_at = (Get-Date).ToUniversalTime().ToString('o')
    hklm_addin = [ordered]@{
        path = $hkLmAddin
        default = Get-DefaultValue $hkLmAddin
        title = Get-Value $hkLmAddin 'Title'
        description = Get-Value $hkLmAddin 'Description'
    }
    hkcu_startup = [ordered]@{
        path = $hkCuStartup
        default = Get-DefaultValue $hkCuStartup
    }
    hkcr_clsid = [ordered]@{
        path = $hkCrClsid
        code_base = $codeBase
        version_subkeys = $versionSubkeys
    }
}

if ($result.hklm_addin.default -ne 1) { throw "SolidWorks AddIns default must be 1, got '$($result.hklm_addin.default)'" }
if ($result.hklm_addin.title -ne 'SWTools') { throw "SolidWorks AddIns Title must be SWTools, got '$($result.hklm_addin.title)'" }
if ($result.hkcu_startup.default -ne 1) { throw "SolidWorks AddInsStartup default must be 1, got '$($result.hkcu_startup.default)'" }
if (-not $codeBase) { throw "RegAsm CodeBase missing under $hkCrClsid" }
if (-not [string]::Equals($codeBase, $expectedDll, [System.StringComparison]::OrdinalIgnoreCase)) {
    throw "RegAsm CodeBase mismatch: expected $expectedDll, got $codeBase"
}

if ($JsonOut) {
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $JsonOut) | Out-Null
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($JsonOut, ($result | ConvertTo-Json -Depth 8), $encoding)
}

Write-Host 'SolidWorks add-in registration: PASS' -ForegroundColor Green
