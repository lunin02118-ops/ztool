<#
.SYNOPSIS
  Re-points runtime paths in ZTool.settings to an install folder.

.DESCRIPTION
  The BOM export opens the template via the ABSOLUTE path stored in each
  <bomname> (the binary resolves a relative path against the process working
  directory, which under SolidWorks is ...\Documents - so a relative path
  fails). This script rewrites every <bomname> and <bompath> in a ZTool.settings
  file so they point at "<Folder>\Шаблоны спецификации\bom_шаблон.xlsx".

  The material database path has the same constraint. This script also rewrites
  <materialpath> to "<Folder>\SolidWorksTemplates\MyMaterials.sldmat" and enables
  <usematerialcolor>true</usematerialcolor>, restoring the default material
  library/color behavior without embedding a developer-machine path.

.PARAMETER Folder
  The ZTool install root that contains the "Шаблоны спецификации" subfolder
  with bom_шаблон.xlsx and the "SolidWorksTemplates" subfolder with MyMaterials.sldmat.
  Example: D:\ztool-pr8-test

.PARAMETER Settings
  Path to ZTool.settings (defaults to .\ZTool.settings).

.EXAMPLE
  .\set_bom_template_path.ps1 -Folder "D:\ztool-pr8-test"
  .\set_bom_template_path.ps1 -Folder "D:\ZTool" -Settings "D:\ZTool\ZTool.settings"
#>
param(
    [Parameter(Mandatory = $true)] [string] $Folder,
    [string] $Settings = ".\ZTool.settings"
)

$ErrorActionPreference = "Stop"

if (-not (Test-Path $Settings)) { throw "Settings file not found: $Settings" }

$tplDir  = Join-Path $Folder "Шаблоны спецификации"
$tplFile = Join-Path $tplDir "bom_шаблон.xlsx"
$matDir  = Join-Path $Folder "SolidWorksTemplates"
$matFile = Join-Path $matDir "MyMaterials.sldmat"

if (-not (Test-Path $tplFile)) {
    Write-Warning "Template not found at $tplFile - path will still be written, copy the template there."
}
if (-not (Test-Path $matFile)) {
    Write-Warning "Material library not found at $matFile - path will still be written, copy SolidWorksTemplates there."
}

# UTF-8 without BOM, preserve content
$xml = [System.IO.File]::ReadAllText($Settings, [System.Text.Encoding]::UTF8)

$escDir  = [System.Security.SecurityElement]::Escape($tplDir)
$escFile = [System.Security.SecurityElement]::Escape($tplFile)
$escMat  = [System.Security.SecurityElement]::Escape($matFile)

$xml = [regex]::Replace($xml, '<bomname>.*?</bomname>', { param($m) "<bomname>$escFile</bomname>" }, 'Singleline')
$xml = [regex]::Replace($xml, '<bompath\s*/>',          { param($m) "<bompath>$escDir</bompath>" })
$xml = [regex]::Replace($xml, '<bompath>.*?</bompath>', { param($m) "<bompath>$escDir</bompath>" }, 'Singleline')
$xml = [regex]::Replace($xml, '<materialpath\s*/>',          { param($m) "<materialpath>$escMat</materialpath>" })
$xml = [regex]::Replace($xml, '<materialpath>.*?</materialpath>', { param($m) "<materialpath>$escMat</materialpath>" }, 'Singleline')
$xml = [regex]::Replace($xml, '<usematerialcolor>.*?</usematerialcolor>', { param($m) "<usematerialcolor>true</usematerialcolor>" }, 'Singleline')

$enc = New-Object System.Text.UTF8Encoding($false)
[System.IO.File]::WriteAllText($Settings, $xml, $enc)

Write-Host "OK: BOM template path set to $tplFile in $Settings"
Write-Host "OK: material library path set to $matFile in $Settings"
