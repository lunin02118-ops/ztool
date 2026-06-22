param(
    [switch]$RequireEnv,
    [string]$JsonOut = "artifacts\license-backend.json"
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
$argsList = @('scripts\check_license_backend.py', '--json-out', $JsonOut)
if ($RequireEnv) { $argsList += '--require-env' }
python @argsList
if ($LASTEXITCODE -ne 0) {
    throw "license backend check failed"
}
