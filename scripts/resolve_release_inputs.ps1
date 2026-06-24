<#
.SYNOPSIS
  Build and record canonical source-built SWTools release inputs.
#>
param(
    [string]$Configuration = 'Release',
    [string]$SolidWorksDir = 'C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS',
    [string]$SolidWorksToolsPath = '',
    [string]$OutputPath = '',
    [switch]$SkipBuild
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

function Invoke-Checked([string]$What) {
    if ($LASTEXITCODE -ne 0) { throw "$What failed (exit $LASTEXITCODE)" }
}

function Get-VersionInfo([string]$Path) {
    $info = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($Path)
    return [ordered]@{
        product_name = $info.ProductName
        product_version = $info.ProductVersion
        file_version = $info.FileVersion
        original_filename = $info.OriginalFilename
    }
}

function Write-Utf8NoBom([string]$Path, [string]$Text) {
    $encoding = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($Path, $Text, $encoding)
}

$version = (Get-Content -LiteralPath (Join-Path $repoRoot 'VERSION') -Encoding UTF8 -Raw).Trim()
$shortSha = (& git -C $repoRoot rev-parse --short HEAD).Trim()
$commit = (& git -C $repoRoot rev-parse HEAD).Trim()
$branch = (& git -C $repoRoot rev-parse --abbrev-ref HEAD).Trim()
$dirty = [bool](& git -C $repoRoot status --porcelain)
$dirtySuffix = if ($dirty) { 'dirty' } else { 'clean' }
$buildNumber = (& git -C $repoRoot rev-list --count HEAD).Trim()
$msbuildVersionArgs = @(
    "-p:ReleaseBuildNumber=$buildNumber",
    "-p:SourceRevisionId=$shortSha",
    "-p:DirtySuffix=$dirtySuffix"
)

if (-not $OutputPath) {
    $OutputPath = Join-Path $repoRoot "_local_artifacts\reports\release-inputs-$version.json"
}

if (-not $SkipBuild) {
    dotnet build (Join-Path $repoRoot 'client-src\ZTool.csproj') -c $Configuration --no-incremental @msbuildVersionArgs
    Invoke-Checked 'client source build'

    if (-not $SolidWorksToolsPath) {
        $candidate1 = Join-Path $SolidWorksDir 'SolidWorksTools.dll'
        $candidate2 = Join-Path $SolidWorksDir 'api\redist\SolidWorksTools.dll'
        if (Test-Path -LiteralPath $candidate1 -PathType Leaf) {
            $SolidWorksToolsPath = $candidate1
        }
        elseif (Test-Path -LiteralPath $candidate2 -PathType Leaf) {
            $SolidWorksToolsPath = $candidate2
        }
        else {
            dotnet build (Join-Path $repoRoot 'client-src-addin\sdk-shim\SolidWorksTools.Shim.csproj') -c $Configuration --no-incremental
            Invoke-Checked 'SolidWorksTools SDK shim build'
            $SolidWorksToolsPath = Join-Path $repoRoot "client-src-addin\sdk-shim\bin\$Configuration\net48\SolidWorksTools.dll"
        }
    }

    dotnet build (Join-Path $repoRoot 'client-src-addin\ZTool.SwAddin.csproj') `
        -c $Configuration `
        --no-incremental `
        "-p:SolidWorksToolsPath=$SolidWorksToolsPath" `
        @msbuildVersionArgs
    Invoke-Checked 'SolidWorks add-in source build'
}

$clientExe = Join-Path $repoRoot "client-src\bin\$Configuration\net48\SWTools.exe"
$addinDll = Join-Path $repoRoot "client-src-addin\bin\$Configuration\net48\SWTools.dll"
foreach ($path in @($clientExe, $addinDll)) {
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) {
        throw "source-built release input missing: $path"
    }
}

$result = [ordered]@{
    input_mode = 'source-build-output'
    version = $version
    build_number = [int]$buildNumber
    source_revision_id = $shortSha
    dirty = $dirty
    generated_at = (Get-Date).ToUniversalTime().ToString('o')
    git = [ordered]@{
        commit = $commit
        branch = $branch
        dirty = $dirty
    }
    solidworks_tools_path = $SolidWorksToolsPath
    client_exe = [ordered]@{
        path = $clientExe
        repo_relative_path = [System.IO.Path]::GetRelativePath($repoRoot, $clientExe).Replace('\', '/')
        sha256 = Get-Sha256 $clientExe
        version_info = Get-VersionInfo $clientExe
    }
    addin_dll = [ordered]@{
        path = $addinDll
        repo_relative_path = [System.IO.Path]::GetRelativePath($repoRoot, $addinDll).Replace('\', '/')
        sha256 = Get-Sha256 $addinDll
        version_info = Get-VersionInfo $addinDll
    }
}

New-Item -ItemType Directory -Force -Path (Split-Path -Parent $OutputPath) | Out-Null
Write-Utf8NoBom $OutputPath (($result | ConvertTo-Json -Depth 8))
Write-Host "release inputs: $OutputPath" -ForegroundColor Green
Write-Host "client: $clientExe" -ForegroundColor Green
Write-Host "addin:  $addinDll" -ForegroundColor Green
