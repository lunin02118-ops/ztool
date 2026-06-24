<#
.SYNOPSIS
  Static guards for source-built SWTools release inputs.
#>
param(
    [string]$Version = ''
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $Version) { $Version = (Get-Content -LiteralPath (Join-Path $repoRoot 'VERSION') -Encoding UTF8 -Raw).Trim() }

function Read-Text([string]$Path) {
    return Get-Content -LiteralPath (Join-Path $repoRoot $Path) -Encoding UTF8 -Raw
}

function Assert-Contains([string]$Text, [string]$Needle, [string]$Label) {
    if (-not $Text.Contains($Needle)) { throw "guard failed: $Label" }
}

function Assert-NotContains([string]$Text, [string]$Needle, [string]$Label) {
    if ($Text.Contains($Needle)) { throw "guard failed: $Label" }
}

$clientCsproj = Read-Text 'client-src\ZTool.csproj'
$addinCsproj = Read-Text 'client-src-addin\ZTool.SwAddin.csproj'
$clientAssembly = Read-Text 'client-src\Properties\AssemblyInfo.cs'
$addinAssembly = Read-Text 'client-src-addin\Properties\AssemblyInfo.cs'
$targets = Read-Text 'Directory.Build.targets'
$buildPackage = Read-Text 'scripts\build_release_package.ps1'
$swAddin = Read-Text 'client-src-addin\ZTool\SwAddin.cs'

Assert-Contains $clientCsproj '<AssemblyName>ZTool</AssemblyName>' 'client internal AssemblyName remains compatibility ZTool'
Assert-Contains $addinCsproj '<AssemblyName>ZTool</AssemblyName>' 'addin internal AssemblyName remains compatibility ZTool'
Assert-Contains $clientCsproj 'SWTools$(TargetExt)' 'client emits SWTools.exe copy'
Assert-Contains $addinCsproj 'SWTools$(TargetExt)' 'addin emits SWTools.dll copy'

Assert-Contains $targets 'System.Reflection.AssemblyProduct(&quot;$(SWToolsProductName)&quot;)' 'version/product metadata generated centrally'
Assert-Contains $targets 'System.Reflection.AssemblyFileVersion(&quot;$(SWToolsFileVersion)&quot;)' 'file version generated centrally'
Assert-NotContains $clientAssembly 'AssemblyCompany("ZTool")' 'client AssemblyInfo must not hard-code ZTool company'
Assert-NotContains $addinAssembly 'AssemblyProduct("ZTool")' 'addin AssemblyInfo must not hard-code ZTool product'

Assert-Contains $buildPackage '[switch]$UseAcceptedRuntimeSnapshot' 'package builder exposes explicit accepted snapshot mode'
Assert-Contains $buildPackage 'client-src\bin\Release\net48\SWTools.exe' 'package builder defaults to source-built client'
Assert-Contains $buildPackage 'client-src-addin\bin\Release\net48\SWTools.dll' 'package builder defaults to source-built addin'
Assert-Contains $buildPackage 'points to legacy root runtime artifact' 'package builder forbids silent legacy root inputs'
Assert-Contains $buildPackage 'release-inputs.json' 'package builder emits release-inputs provenance'

Assert-Contains $swAddin '[SwAddin(Description = "SWTools SolidWorks Add-in", Title = "SWTools", LoadAtStartup = true)]' 'source add-in attribute rebranded'
Assert-Contains $swAddin 'registryKey.SetValue(null, 1, RegistryValueKind.DWord)' 'source add-in registration enables load'
Assert-Contains $swAddin 'registryKey.SetValue("Title", "SWTools")' 'source add-in registration title is SWTools'

Write-Host "release source guards: PASS ($Version)" -ForegroundColor Green
