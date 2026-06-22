<#
.SYNOPSIS
  Generate minimal CycloneDX and SPDX SBOM files from the repository compliance
  inventory. This intentionally has no external tool dependency so CI can always
  produce an SBOM evidence artifact; syft/trivy/osv can be layered on top later.
#>
param(
    [string]$InventoryPath = "",
    [string]$OutputDir = "artifacts"
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $InventoryPath) {
    $InventoryPath = Join-Path $repoRoot 'docs\compliance\third_party_inventory.json'
}
$outputRoot = if ([System.IO.Path]::IsPathRooted($OutputDir)) { $OutputDir } else { Join-Path $repoRoot $OutputDir }
New-Item -ItemType Directory -Force -Path $outputRoot | Out-Null

function Get-Sha256OrNull([string]$RelativePath) {
    $path = Join-Path $repoRoot $RelativePath
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) { return $null }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $path).Hash.ToLowerInvariant()
}

if (-not (Test-Path -LiteralPath $InventoryPath -PathType Leaf)) {
    throw "inventory not found: $InventoryPath"
}

$inventory = Get-Content -LiteralPath $InventoryPath -Raw -Encoding UTF8 | ConvertFrom-Json
$commit = (git -C $repoRoot rev-parse HEAD).Trim()
$created = (Get-Date).ToUniversalTime().ToString('yyyy-MM-ddTHH:mm:ssZ')

$components = @()
foreach ($item in $inventory.items) {
    $hashes = @()
    foreach ($relativePath in @($item.paths)) {
        $hash = Get-Sha256OrNull $relativePath
        if ($hash) {
            $hashes += [ordered]@{
                alg = 'SHA-256'
                content = $hash
            }
        }
    }

    $components += [ordered]@{
        type = if ($item.origin_class -like '*library*' -or $item.origin_class -like '*dependency*') { 'library' } else { 'file' }
        name = [string]$item.name
        version = 'unknown'
        licenses = @(@{ license = @{ id = [string]$item.license } })
        hashes = $hashes
        properties = @(
            @{ name = 'swtools:origin_class'; value = [string]$item.origin_class },
            @{ name = 'swtools:status'; value = [string]$item.status },
            @{ name = 'swtools:exception_id'; value = [string]$item.exception_id },
            @{ name = 'swtools:paths'; value = ((@($item.paths)) -join ';') }
        )
    }
}

$cycloneDx = [ordered]@{
    bomFormat = 'CycloneDX'
    specVersion = '1.5'
    serialNumber = "urn:uuid:$([Guid]::NewGuid())"
    version = 1
    metadata = [ordered]@{
        timestamp = $created
        component = [ordered]@{
            type = 'application'
            name = 'SWTools'
            version = (Get-Content -LiteralPath (Join-Path $repoRoot 'VERSION') -Raw).Trim()
            properties = @(@{ name = 'git:commit'; value = $commit })
        }
        tools = @(@{ vendor = 'SWTools repo'; name = 'scripts/generate_sbom.ps1'; version = '1' })
    }
    components = $components
}

$spdxPackages = @()
$spdxPackages += [ordered]@{
    SPDXID = 'SPDXRef-Package-SWTools'
    name = 'SWTools'
    downloadLocation = 'NOASSERTION'
    filesAnalyzed = $false
    licenseConcluded = 'NOASSERTION'
    licenseDeclared = 'NOASSERTION'
    copyrightText = 'NOASSERTION'
}
foreach ($item in $inventory.items) {
    $safeName = ([string]$item.name) -replace '[^A-Za-z0-9.-]', '-'
    $spdxPackages += [ordered]@{
        SPDXID = "SPDXRef-Package-$safeName"
        name = [string]$item.name
        downloadLocation = 'NOASSERTION'
        filesAnalyzed = $false
        licenseConcluded = [string]$item.license
        licenseDeclared = [string]$item.license
        copyrightText = 'NOASSERTION'
        comment = "origin_class=$($item.origin_class); status=$($item.status); exception_id=$($item.exception_id); paths=$((@($item.paths)) -join ';')"
    }
}

$spdx = [ordered]@{
    spdxVersion = 'SPDX-2.3'
    dataLicense = 'CC0-1.0'
    SPDXID = 'SPDXRef-DOCUMENT'
    name = 'SWTools-P4-SBOM'
    documentNamespace = "https://github.com/lunin02118-ops/ztool/sbom/$commit/$([Guid]::NewGuid())"
    creationInfo = [ordered]@{
        created = $created
        creators = @('Tool: scripts/generate_sbom.ps1')
    }
    packages = $spdxPackages
}

$cyclonePath = Join-Path $outputRoot 'sbom.cyclonedx.json'
$spdxPath = Join-Path $outputRoot 'sbom.spdx.json'
$cycloneDx | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $cyclonePath -Encoding UTF8
$spdx | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $spdxPath -Encoding UTF8

Write-Host "CycloneDX SBOM: $cyclonePath"
Write-Host "SPDX SBOM: $spdxPath"
Write-Host "components: $($components.Count)"
