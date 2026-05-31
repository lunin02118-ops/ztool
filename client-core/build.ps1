<#
.SYNOPSIS
  Build the editable licensing core from C# source and reinject it into ZTool.exe.

.DESCRIPTION
  Pipeline:
    1. (optional) Publicize the base ZTool.exe  -> ref/ZTool.public.dll  (compile-time reference)
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
  ./build.ps1 -BaseExe 'C:\path\ZTool.exe' -OutExe 'C:\path\out\ZTool.exe'
#>
param(
    [string]$BaseExe = (Join-Path $PSScriptRoot '..\ZTool.exe'),
    [string]$OutExe  = (Join-Path $PSScriptRoot 'out\ZTool.exe'),
    [switch]$Publicize
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

Write-Host '== [4/5] localize user-visible Chinese strings (forms) -> Russian ==' -ForegroundColor Cyan
$locTmp = "$OutExe.loc.tmp"
$locTable = Join-Path $core 'tools\Localizer\translations.tsv'
dotnet run -c Release --project (Join-Path $core 'tools\Localizer') -- `
    $OutExe $locTmp $locTable
Invoke-Checked 'localize'
Move-Item -Force $locTmp $OutExe

Write-Host '== [5/5] verify output exe ==' -ForegroundColor Cyan
dotnet run -c Release --project (Join-Path $core 'tools\Reinjector') -- --verify $OutExe
Invoke-Checked 'verify (dangling references found)'

Write-Host ""
Write-Host "DONE -> $OutExe" -ForegroundColor Green
Write-Host "Copy it over the ZTool.exe in a full runtime folder (with the other DLLs) to run." -ForegroundColor Green
