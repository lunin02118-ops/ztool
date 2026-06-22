<#
.SYNOPSIS
  Assert that from-source SWTools.exe and brand-patched SWTools.dll match the
  accepted hashes pinned in scripts/expected_release_hashes.json.
#>
param(
    [string]$ClientExe,
    [string]$AddinDll,
    [string]$ExpectedHashesJson
)

$ErrorActionPreference = 'Stop'

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $ClientExe) {
    $ClientExe = Join-Path $repoRoot 'client-src\bin\Release\net48\SWTools.exe'
}
if (-not $AddinDll) {
    $AddinDll = Join-Path $repoRoot 'client-src-addin\bin\Release\net48\SWTools.dll'
}
if (-not $ExpectedHashesJson) {
    $ExpectedHashesJson = Join-Path $PSScriptRoot 'expected_release_hashes.json'
}

function Fail([string]$Message) {
    throw "from-source hash gate failed: $Message"
}

function Get-Sha256([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        Fail "missing file: $Path"
    }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToLowerInvariant()
}

function Invoke-Checked([string]$What) {
    if ($LASTEXITCODE -ne 0) { Fail "$What failed (exit $LASTEXITCODE)" }
}

if (-not (Test-Path -LiteralPath $ExpectedHashesJson -PathType Leaf)) {
    Fail "expected hashes JSON missing: $ExpectedHashesJson"
}

$expected = Get-Content -LiteralPath $ExpectedHashesJson -Encoding UTF8 -Raw | ConvertFrom-Json
if (-not $expected.client_exe_sha256) { Fail 'expected client_exe_sha256 is empty' }
if (-not $expected.addin_dll_sha256) { Fail 'expected addin_dll_sha256 is empty' }

$addinPatchProject = Join-Path $repoRoot 'client-core\tools\AddinBrandPatch\AddinBrandPatch.csproj'
$tmpDir = Join-Path ([System.IO.Path]::GetTempPath()) ("swtools-addin-hash-" + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Force -Path $tmpDir | Out-Null
try {
    $patchedAddin = Join-Path $tmpDir 'SWTools.dll'
    dotnet run -c Release --project $addinPatchProject -- $AddinDll patch $patchedAddin
    Invoke-Checked 'addin brand patch'
    dotnet run -c Release --project $addinPatchProject -- $patchedAddin verify
    Invoke-Checked 'addin brand verify'

    $actualClient = Get-Sha256 $ClientExe
    $actualAddin = Get-Sha256 $patchedAddin
    $expectedClient = ([string]$expected.client_exe_sha256).ToLowerInvariant()
    $expectedAddin = ([string]$expected.addin_dll_sha256).ToLowerInvariant()

    Write-Host "from-source SWTools.exe sha256        = $actualClient"
    Write-Host "expected client_exe_sha256           = $expectedClient"
    Write-Host "from-source patched SWTools.dll sha256 = $actualAddin"
    Write-Host "expected addin_dll_sha256            = $expectedAddin"

    if ($actualClient -ne $expectedClient) {
        Fail "SWTools.exe hash mismatch; expected $expectedClient, got $actualClient"
    }
    if ($actualAddin -ne $expectedAddin) {
        Fail "SWTools.dll hash mismatch; expected $expectedAddin, got $actualAddin"
    }

    Write-Host 'from-source hash gate: PASS' -ForegroundColor Green
}
finally {
    Remove-Item -LiteralPath $tmpDir -Recurse -Force -ErrorAction SilentlyContinue
}
