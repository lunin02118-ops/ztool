<#
.SYNOPSIS
  Verify a ZTool release package before manual acceptance testing.

.DESCRIPTION
  Checks manifest/SHA256SUMS consistency, expected runtime artifact hashes and
  absence of private keys, databases, dumps, local logs or build caches.
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageRoot,

    [string]$ExpectedClientExeSha256 = "0bf4cb0b4174d1ccdfef17373de7ea4965fc0a2e42f27393e0b2571d9955864b",
    [string]$ExpectedAddinDllSha256 = "d053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9",

    [switch]$RequireSolidWorksTools,
    [switch]$AllowDirtyManifest
)

$ErrorActionPreference = 'Stop'

function Fail([string]$Message) {
    throw "release package verification failed: $Message"
}

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Assert-File([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        Fail "missing file: $Path"
    }
}

function Assert-Dir([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path -PathType Container)) {
        Fail "missing directory: $Path"
    }
}

function Assert-Hash([string]$Path, [string]$Expected) {
    $actual = Get-Sha256 $Path
    if ($actual -ne $Expected.ToLowerInvariant()) {
        Fail "hash mismatch for $Path; expected $Expected, got $actual"
    }
}

function Get-XmlText([xml]$Xml, [string]$ElementName) {
    $node = $Xml.SelectSingleNode("//$ElementName")
    if ($null -eq $node) { return $null }
    return $node.InnerText.Trim()
}

$root = (Resolve-Path -LiteralPath $PackageRoot).Path
$manifestPath = Join-Path $root 'manifest.json'
$sumsPath = Join-Path $root 'SHA256SUMS.txt'
$runtimeDir = Join-Path $root 'runtime'

Assert-Dir $runtimeDir
Assert-Dir (Join-Path $root 'license-server')
Assert-Dir (Join-Path $root 'deploy')
Assert-Dir (Join-Path $root 'docs')
Assert-File $manifestPath
Assert-File $sumsPath

$manifest = Get-Content -LiteralPath $manifestPath -Encoding UTF8 -Raw | ConvertFrom-Json
if (-not $manifest.package) { Fail 'manifest.package is empty' }
if (-not $manifest.git.commit) { Fail 'manifest.git.commit is empty' }
if (-not $manifest.git.branch) { Fail 'manifest.git.branch is empty' }
if ($manifest.git.dirty -and -not $AllowDirtyManifest) {
    Fail 'manifest git.dirty=true; rebuild from a clean checkout or pass -AllowDirtyManifest for dry-run inspection'
}

$forbidden = Get-ChildItem -Recurse -Force -LiteralPath $root | Where-Object {
    $_.Name -match 'private_key|keypair_info|\.db$|\.db-|\.sqlite$|\.sqlite3$|\.dmp$|\.dump$|\.log$|\.coverage$|egg-info|\.pem$|\.key$'
}
if ($forbidden) {
    $sample = ($forbidden | Select-Object -First 10 | ForEach-Object { $_.FullName }) -join '; '
    Fail "forbidden files found: $sample"
}

$actualFiles = @(Get-ChildItem -File -Recurse -LiteralPath $root | ForEach-Object {
    $_.FullName.Substring($root.Length + 1).Replace('\', '/')
} | Sort-Object)
$actualForSums = @($actualFiles | Where-Object { $_ -ne 'SHA256SUMS.txt' } | Sort-Object)
$sumsFiles = @()

$verifiedSums = 0
Get-Content -LiteralPath $sumsPath -Encoding UTF8 | ForEach-Object {
    if ($_ -notmatch '^([0-9a-fA-F]{64})  (.+)$') {
        if ($_.Trim().Length -gt 0) { Fail "invalid SHA256SUMS line: $_" }
        return
    }
    $expected = $Matches[1].ToLowerInvariant()
    $rel = $Matches[2]
    $filePath = Join-Path $root ($rel -replace '/', '\')
    Assert-File $filePath
    Assert-Hash $filePath $expected
    $script:sumsFiles += $rel
    $script:verifiedSums += 1
}
if ($verifiedSums -eq 0) { Fail 'SHA256SUMS has no entries' }

$sumsFilesSorted = @($sumsFiles | Sort-Object)
$sumsMismatch = @(Compare-Object $actualForSums $sumsFilesSorted)
if ($sumsMismatch.Count -gt 0) {
    $sample = ($sumsMismatch | Select-Object -First 10 | ForEach-Object {
        "$($_.SideIndicator) $($_.InputObject)"
    }) -join '; '
    Fail "SHA256SUMS file set mismatch: $sample"
}

$manifestFiles = @($manifest.files.PSObject.Properties)
if ($manifestFiles.Count -eq 0) { Fail 'manifest.files is empty' }
$actualForManifest = @($actualFiles | Where-Object {
    $_ -ne 'manifest.json' -and $_ -ne 'SHA256SUMS.txt'
} | Sort-Object)
$manifestFileNames = @($manifestFiles | ForEach-Object { $_.Name } | Sort-Object)
$manifestMismatch = @(Compare-Object $actualForManifest $manifestFileNames)
if ($manifestMismatch.Count -gt 0) {
    $sample = ($manifestMismatch | Select-Object -First 10 | ForEach-Object {
        "$($_.SideIndicator) $($_.InputObject)"
    }) -join '; '
    Fail "manifest file set mismatch: $sample"
}

foreach ($entry in $manifestFiles) {
    $rel = $entry.Name
    $filePath = Join-Path $root ($rel -replace '/', '\')
    Assert-File $filePath
    Assert-Hash $filePath $entry.Value.sha256
    $size = (Get-Item -LiteralPath $filePath).Length
    if ($size -ne [int64]$entry.Value.size_bytes) {
        Fail "size mismatch for $rel; expected $($entry.Value.size_bytes), got $size"
    }
}

$clientExe = Join-Path $runtimeDir 'ZTool.exe'
$addinDll = Join-Path $runtimeDir 'ZTool.dll'
$solidWorksTools = Join-Path $runtimeDir 'SolidWorksTools.dll'
$settingsPath = Join-Path $runtimeDir 'ZTool.settings'
$materialLibrary = Join-Path $runtimeDir 'SW模板\MyMaterials.sldmat'

Assert-Hash $clientExe $ExpectedClientExeSha256
Assert-Hash $addinDll $ExpectedAddinDllSha256
Assert-File $settingsPath
Assert-File $materialLibrary

[xml]$settingsXml = Get-Content -LiteralPath $settingsPath -Encoding UTF8 -Raw
$settingsMaterialPath = Get-XmlText $settingsXml 'materialpath'
$useMaterialColor = Get-XmlText $settingsXml 'usematerialcolor'
if ([string]::IsNullOrWhiteSpace($settingsMaterialPath)) {
    Fail 'runtime/ZTool.settings materialpath is empty'
}
if ($useMaterialColor -ne 'true') {
    Fail "runtime/ZTool.settings usematerialcolor must be true, got '$useMaterialColor'"
}
$resolvedMaterialPath = if ([System.IO.Path]::IsPathRooted($settingsMaterialPath)) {
    $settingsMaterialPath
} else {
    Join-Path $runtimeDir $settingsMaterialPath
}
Assert-File $resolvedMaterialPath
if ((Resolve-Path -LiteralPath $resolvedMaterialPath).Path -ne (Resolve-Path -LiteralPath $materialLibrary).Path) {
    Fail "runtime/ZTool.settings materialpath must point to runtime/SW模板/MyMaterials.sldmat, got $settingsMaterialPath"
}

if ($RequireSolidWorksTools) {
    Assert-File $solidWorksTools
    if (-not $manifest.runtime.solidworks_tools_included) {
        Fail 'SolidWorksTools.dll is present but manifest.runtime.solidworks_tools_included is false'
    }
}

$summary = [ordered]@{
    package = $manifest.package
    version = $manifest.version
    commit = $manifest.git.commit
    branch = $manifest.git.branch
    dirty = [bool]$manifest.git.dirty
    solidworks_tools_included = [bool]$manifest.runtime.solidworks_tools_included
    material_library = $settingsMaterialPath
    sha256sums_entries = $verifiedSums
    manifest_files = @($manifestFiles).Count
    runtime_ztool_exe = Get-Sha256 $clientExe
    runtime_ztool_dll = Get-Sha256 $addinDll
}

Write-Host 'release package verification: PASS' -ForegroundColor Green
$summary | ConvertTo-Json -Depth 4
