<#
.SYNOPSIS
  Build the editable licensing core from C# source and reinject it into ZTool.exe.

.DESCRIPTION
  Pipeline:
    1. (optional) Publicize the base ZTool-base.exe -> ref/ZTool.public.dll  (compile-time reference)
    2. Compile src/*.cs                          -> bin/Release/net48/ZTool.Core.dll
    3. Reinject Core.dll method bodies into a fresh copy of ZTool.exe -> <OutExe>
    4. Localize remaining user-visible Chinese strings (forms) -> Russian
    5. Verify the output exe has no dangling references into our build scaffolding

.EXAMPLE
  # normal rebuild (ref/ZTool.public.dll is already committed)
  ./build.ps1

.EXAMPLE
  # also regenerate the publicized compile reference from the base exe
  ./build.ps1 -Publicize

.EXAMPLE
  ./build.ps1 -BaseExe 'C:\path\ZTool-base.exe' -OutExe 'C:\path\out\ZTool.exe'
#>
param(
    [string]$BaseExe = (Join-Path $PSScriptRoot '..\ZTool-base.exe'),
    [string]$OutExe  = (Join-Path $PSScriptRoot 'out\ZTool.exe'),
    [switch]$Publicize,
    [switch]$AllowUnknownInputs
)

$ErrorActionPreference = 'Stop'
$core = $PSScriptRoot

# PowerShell does NOT stop on a native command's non-zero exit code, so every
# `dotnet` invocation below is followed by an explicit check. Without this a
# failed compile is silently ignored and reinject runs against a stale DLL.
function Invoke-Checked([string]$What) {
    if ($LASTEXITCODE -ne 0) { throw "$What failed (exit $LASTEXITCODE)" }
}

if (-not (Test-Path $BaseExe)) { throw "base exe not found: $BaseExe" }

$repoRoot = Resolve-Path (Join-Path $core '..')

function Get-Sha256([string]$Path) {
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Get-RelativePathForManifest([string]$Path) {
    $resolved = (Resolve-Path -LiteralPath $Path).Path
    $root = $repoRoot.Path.TrimEnd('\') + '\'
    if ($resolved.StartsWith($root, [StringComparison]::OrdinalIgnoreCase)) {
        return $resolved.Substring($root.Length).Replace('\', '/')
    }
    return $resolved
}

function Get-ReleaseVersion {
    $versionPath = Join-Path $repoRoot 'VERSION'
    if (Test-Path -LiteralPath $versionPath -PathType Leaf) {
        $v = (Get-Content -LiteralPath $versionPath -Encoding UTF8 -Raw).Trim()
        if ($v) { return $v }
    }
    return '1.0.0'
}

function Assert-BuildInputs {
    $manifestPath = Join-Path $core 'build-inputs.json'
    if (-not (Test-Path $manifestPath)) { throw "build input manifest missing: $manifestPath" }
    $manifest = Get-Content -Raw -LiteralPath $manifestPath | ConvertFrom-Json
    foreach ($entry in $manifest.PSObject.Properties) {
        $rel = $entry.Name
        $expected = [string]$entry.Value.sha256
        $path = Join-Path $repoRoot $rel
        if (-not (Test-Path $path)) {
            $msg = "build input missing: $rel"
            if ($AllowUnknownInputs) { Write-Warning $msg; continue }
            throw $msg
        }
        $actual = Get-Sha256 $path
        if ($actual -ne $expected.ToLowerInvariant()) {
            $msg = "build input hash mismatch: $rel expected=$expected actual=$actual"
            if ($AllowUnknownInputs) { Write-Warning $msg; continue }
            throw $msg
        }
    }

    $defaultBase = (Resolve-Path (Join-Path $repoRoot 'ZTool-base.exe')).Path
    $actualBase = (Resolve-Path -LiteralPath $BaseExe).Path
    if (-not $actualBase.Equals($defaultBase, [StringComparison]::OrdinalIgnoreCase) -and -not $AllowUnknownInputs) {
        throw "custom BaseExe requires -AllowUnknownInputs: $BaseExe"
    }
}

function Get-PublicKeyTokenHex([string]$AssemblyPath) {
    try {
        $pkt = [System.Reflection.AssemblyName]::GetAssemblyName((Resolve-Path -LiteralPath $AssemblyPath).Path).GetPublicKeyToken()
        if ($null -eq $pkt -or $pkt.Length -eq 0) { return "" }
        return -join ($pkt | ForEach-Object { $_.ToString('x2') })
    } catch {
        return "<error: $($_.Exception.Message)>"
    }
}

function Write-OutputManifest([string]$VerifyOutput, [int]$ReinjectExitCode) {
    $manifestPath = Join-Path (Split-Path $OutExe) 'ZTool.manifest.json'
    $dangling = $null
    if ($VerifyOutput -match 'dangling typerefs = (?<n>\d+)') {
        $dangling = [int]$Matches['n']
    }
    $gitCommit = (& git -C $repoRoot rev-parse HEAD 2>$null)
    $gitBranch = (& git -C $repoRoot rev-parse --abbrev-ref HEAD 2>$null)
    $gitDirty = [bool](& git -C $repoRoot status --porcelain 2>$null)
    $versionInfo = (Get-Item -LiteralPath $OutExe).VersionInfo
    $releaseVersion = Get-ReleaseVersion

    $manifest = [ordered]@{
        generated_at = (Get-Date).ToUniversalTime().ToString('o')
        release_version = $releaseVersion
        git = [ordered]@{
            commit = $gitCommit
            branch = $gitBranch
            dirty = $gitDirty
        }
        inputs = [ordered]@{
            base_exe = [ordered]@{
                path = Get-RelativePathForManifest $BaseExe
                sha256 = Get-Sha256 $BaseExe
            }
            public_ref = [ordered]@{
                path = 'client-core/ref/ZTool.public.dll'
                sha256 = Get-Sha256 (Join-Path $core 'ref\ZTool.public.dll')
            }
            rsa_ref = [ordered]@{
                path = 'client-core/ref/ZTool_rsa.dll'
                sha256 = Get-Sha256 (Join-Path $core 'ref\ZTool_rsa.dll')
            }
            translations = [ordered]@{
                path = 'client-core/tools/Localizer/translations.tsv'
                sha256 = Get-Sha256 (Join-Path $core 'tools\Localizer\translations.tsv')
            }
        }
        output = [ordered]@{
            path = Get-RelativePathForManifest $OutExe
            sha256 = Get-Sha256 $OutExe
            public_key_token = Get-PublicKeyTokenHex $OutExe
            file_version = $versionInfo.FileVersion
            product_version = $versionInfo.ProductVersion
        }
        verification = [ordered]@{
            reinjector_exit_code = $ReinjectExitCode
            dangling_refs = $dangling
        }
    }

    $manifest | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $manifestPath -Encoding UTF8
    Write-Host "manifest -> $manifestPath" -ForegroundColor Green
}

Assert-BuildInputs

if ($Publicize) {
    Write-Host '== [1/5] publicize base exe -> ref/ZTool.public.dll ==' -ForegroundColor Cyan
    dotnet run -c Release --project (Join-Path $core 'tools\Publicizer') -- `
        $BaseExe (Join-Path $core 'ref\ZTool.public.dll')
    Invoke-Checked 'publicize'
} else {
    Write-Host '== [1/5] publicize skipped (using committed ref/ZTool.public.dll) ==' -ForegroundColor DarkGray
}

Write-Host '== [2/5] compile licensing core (src/*.cs -> ZTool.Core.dll) ==' -ForegroundColor Cyan
dotnet build -c Release (Join-Path $core 'ZTool.Core.csproj')
Invoke-Checked 'core compile'
$dll = Join-Path $core 'bin\Release\net48\ZTool.Core.dll'
if (-not (Test-Path $dll)) { throw "core build produced no dll: $dll" }

Write-Host '== [3/5] reinject method bodies into a fresh ZTool.exe ==' -ForegroundColor Cyan
New-Item -ItemType Directory -Force -Path (Split-Path $OutExe) | Out-Null
dotnet run -c Release --project (Join-Path $core 'tools\Reinjector') -- `
    $BaseExe $dll $OutExe
Invoke-Checked 'reinject'

Write-Host '== [4/6] localize user-visible Chinese strings (forms) -> Russian ==' -ForegroundColor Cyan
$locTmp = "$OutExe.loc.tmp"
$locTable = Join-Path $core 'tools\Localizer\translations.tsv'
$releaseVersion = Get-ReleaseVersion
dotnet run -c Release --project (Join-Path $core 'tools\Localizer') -- `
    $OutExe $locTmp $locTable $releaseVersion
Invoke-Checked 'localize'
Move-Item -Force $locTmp $OutExe

Write-Host '== [5/6] inject version-tolerant deserialization binder (PublicKeyToken-safe) ==' -ForegroundColor Cyan
# BinaryFormatter blobs embed each type's full assembly identity (Version+PublicKeyToken).
# code.DeserializeBinary/DeserializeObject get a SerializationBinder that binds by short
# assembly name against what is actually loaded, so stored config (Font/Color/DataTable)
# survives a runtime/version change instead of throwing SerializationException.
$donorDll = Join-Path $core 'tools\BinderInject\donor\bin\Release\net48\ZBinderDonor.dll'
dotnet build -c Release (Join-Path $core 'tools\BinderInject\donor\Donor.csproj')
Invoke-Checked 'binder donor compile'
if (-not (Test-Path $donorDll)) { throw "binder donor produced no dll: $donorDll" }
$binTmp = "$OutExe.binder.tmp"
dotnet run -c Release --project (Join-Path $core 'tools\BinderInject') -- `
    patch $OutExe $donorDll $binTmp
Invoke-Checked 'binder inject'
Move-Item -Force $binTmp $OutExe
dotnet run -c Release --project (Join-Path $core 'tools\BinderInject') -- verify $OutExe
Invoke-Checked 'binder verify'

Write-Host '== [6/6] verify output exe ==' -ForegroundColor Cyan
$verifyOutput = dotnet run -c Release --project (Join-Path $core 'tools\Reinjector') -- --verify $OutExe 2>&1
$verifyExit = $LASTEXITCODE
$verifyOutput | ForEach-Object { Write-Host $_ }
Invoke-Checked 'verify (dangling references found)'
Write-OutputManifest ($verifyOutput -join "`n") $verifyExit

Write-Host ""
Write-Host "DONE -> $OutExe" -ForegroundColor Green
Write-Host "Copy it over the ZTool.exe in a full runtime folder (with the other DLLs) to run." -ForegroundColor Green
