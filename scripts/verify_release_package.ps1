<#
.SYNOPSIS
  Verify a SWTools release package before manual acceptance testing.

.DESCRIPTION
  Checks manifest/SHA256SUMS consistency, expected runtime artifact hashes and
  absence of private keys, databases, dumps, local logs or build caches.
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageRoot,

    [string]$ExpectedClientExeSha256,
    [string]$ExpectedAddinDllSha256,
    [string]$ExpectedRibbonSha256,
    [string]$ExpectedExpandableGridViewSha256,
    [string]$ExpectedZToolRsaSha256,

    [switch]$RequireSolidWorksTools,
    [switch]$AllowDirtyManifest
)

$ErrorActionPreference = 'Stop'

# Single source of truth for accepted runtime hashes: scripts/expected_release_hashes.json.
# The fallback literals below must mirror that file; they only apply if it is missing.
function Get-ExpectedHashes {
    $fallback = [ordered]@{
        client_exe_sha256             = '41d14ac6014e1bcb3409f4d266536f71922b030806800e60c040a049872f91c5'
        addin_dll_sha256              = '7f931ba366997f23c1d9d0f713948ba5d07e09e767ec6754a81460f238adf84d'
        ribbon_dll_sha256             = '57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e'
        expandable_grid_view_sha256   = '89ec31d68a132c02f725903d52d5c5c7c422a2aa997a8a8444685a4374cefcc0'
        ztool_rsa_dll_sha256          = '274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90'
    }
    $path = Join-Path $PSScriptRoot 'expected_release_hashes.json'
    if (Test-Path -LiteralPath $path) {
        $json = Get-Content -LiteralPath $path -Encoding UTF8 -Raw | ConvertFrom-Json
        return [ordered]@{
            client_exe_sha256             = if ($json.client_exe_sha256) { [string]$json.client_exe_sha256 } else { $fallback.client_exe_sha256 }
            addin_dll_sha256              = if ($json.addin_dll_sha256) { [string]$json.addin_dll_sha256 } else { $fallback.addin_dll_sha256 }
            ribbon_dll_sha256             = if ($json.ribbon_dll_sha256) { [string]$json.ribbon_dll_sha256 } else { $fallback.ribbon_dll_sha256 }
            expandable_grid_view_sha256   = if ($json.expandable_grid_view_sha256) { [string]$json.expandable_grid_view_sha256 } else { $fallback.expandable_grid_view_sha256 }
            ztool_rsa_dll_sha256          = if ($json.ztool_rsa_dll_sha256) { [string]$json.ztool_rsa_dll_sha256 } else { $fallback.ztool_rsa_dll_sha256 }
        }
    }
    return $fallback
}

$expectedHashes = Get-ExpectedHashes
if (-not $ExpectedClientExeSha256) { $ExpectedClientExeSha256 = $expectedHashes.client_exe_sha256 }
if (-not $ExpectedAddinDllSha256) { $ExpectedAddinDllSha256 = $expectedHashes.addin_dll_sha256 }
if (-not $ExpectedRibbonSha256) { $ExpectedRibbonSha256 = $expectedHashes.ribbon_dll_sha256 }
if (-not $ExpectedExpandableGridViewSha256) { $ExpectedExpandableGridViewSha256 = $expectedHashes.expandable_grid_view_sha256 }
if (-not $ExpectedZToolRsaSha256) { $ExpectedZToolRsaSha256 = $expectedHashes.ztool_rsa_dll_sha256 }

function Fail([string]$Message) {
    throw "release package verification failed: $Message"
}

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Invoke-Checked([string]$What) {
    if ($LASTEXITCODE -ne 0) { Fail "$What failed (exit $LASTEXITCODE)" }
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
    Assert-File $Path
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

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
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

$clientExe = Join-Path $runtimeDir 'SWTools.exe'
$addinDll = Join-Path $runtimeDir 'SWTools.dll'
$solidWorksTools = Join-Path $runtimeDir 'SolidWorksTools.dll'
$ribbonDll = Join-Path $runtimeDir 'Ribbon.dll'
$expandableGridViewDll = Join-Path $runtimeDir 'ExpandableGridView.dll'
$ztoolRsaDll = Join-Path $runtimeDir 'ZTool_rsa.dll'
$settingsPath = Join-Path $runtimeDir 'SWTools.settings'
$materialLibrary = Join-Path $runtimeDir 'SolidWorksTemplates\MyMaterials.sldmat'
$clientConfigPath = Join-Path $runtimeDir 'SWTools.exe.config'
$clientRuntimeDependencies = @(
    'System.Buffers.dll',
    'System.Memory.dll',
    'System.Numerics.Vectors.dll',
    'System.Resources.Extensions.dll',
    'System.Runtime.CompilerServices.Unsafe.dll'
)

function Test-HasCjk {
    param([string] $Text)
    foreach ($ch in $Text.ToCharArray()) {
        $code = [int][char]$ch
        if (($code -ge 0x3400 -and $code -le 0x9FFF) -or
            ($code -ge 0xF900 -and $code -le 0xFAFF) -or
            ($code -ge 0x3040 -and $code -le 0x30FF)) {
            return $true
        }
    }
    return $false
}

Get-ChildItem -LiteralPath $root -Recurse -Force | ForEach-Object {
    $rel = $_.FullName.Substring($root.Length + 1).Replace('\', '/')
    if (Test-HasCjk $rel) {
        Fail "package path contains CJK characters: $rel"
    }
}

Assert-Hash $clientExe $ExpectedClientExeSha256
Assert-Hash $addinDll $ExpectedAddinDllSha256
$addinPatchProject = Join-Path $repoRoot 'client-core\tools\AddinBrandPatch\AddinBrandPatch.csproj'
dotnet run -c Release --project $addinPatchProject -- $addinDll verify
Invoke-Checked 'addin brand verify'
Assert-Hash $ribbonDll $ExpectedRibbonSha256
Assert-Hash $expandableGridViewDll $ExpectedExpandableGridViewSha256
Assert-Hash $ztoolRsaDll $ExpectedZToolRsaSha256
Assert-File $settingsPath
Assert-File $materialLibrary
Assert-File $clientConfigPath
foreach ($dep in $clientRuntimeDependencies) {
    Assert-File (Join-Path $runtimeDir $dep)
}

[xml]$clientConfigXml = Get-Content -LiteralPath $clientConfigPath -Encoding UTF8 -Raw
$resourceRedirect = $clientConfigXml.configuration.runtime.assemblyBinding.dependentAssembly | Where-Object {
    $_.assemblyIdentity.name -eq 'System.Resources.Extensions'
}
if (-not $resourceRedirect) {
    Fail 'runtime/SWTools.exe.config must contain a bindingRedirect for System.Resources.Extensions'
}

[xml]$settingsXml = Get-Content -LiteralPath $settingsPath -Encoding UTF8 -Raw
$settingsMaterialPath = Get-XmlText $settingsXml 'materialpath'
$useMaterialColor = Get-XmlText $settingsXml 'usematerialcolor'
if ([string]::IsNullOrWhiteSpace($settingsMaterialPath)) {
    Fail 'runtime/SWTools.settings materialpath is empty'
}
if ($useMaterialColor -ne 'true') {
    Fail "runtime/SWTools.settings usematerialcolor must be true, got '$useMaterialColor'"
}
$resolvedMaterialPath = if ([System.IO.Path]::IsPathRooted($settingsMaterialPath)) {
    $settingsMaterialPath
} else {
    Join-Path $runtimeDir $settingsMaterialPath
}
Assert-File $resolvedMaterialPath
if ((Resolve-Path -LiteralPath $resolvedMaterialPath).Path -ne (Resolve-Path -LiteralPath $materialLibrary).Path) {
    Fail "runtime/SWTools.settings materialpath must point to runtime/SolidWorksTemplates/MyMaterials.sldmat, got $settingsMaterialPath"
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
    runtime_swtools_exe = Get-Sha256 $clientExe
    runtime_swtools_dll = Get-Sha256 $addinDll
    runtime_ribbon_dll = Get-Sha256 $ribbonDll
    runtime_expandable_grid_dll = Get-Sha256 $expandableGridViewDll
    runtime_ztool_rsa_dll = Get-Sha256 $ztoolRsaDll
}

Write-Host 'release package verification: PASS' -ForegroundColor Green
$summary | ConvertTo-Json -Depth 4
