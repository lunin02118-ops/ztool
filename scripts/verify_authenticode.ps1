<#
.SYNOPSIS
  Verify Authenticode signatures for release artifacts.

.DESCRIPTION
  Fails on invalid signatures. Unsigned files fail unless -AllowUnsigned is
  passed; CI uses that switch only to record the current unsigned state while
  production signing remains a release blocker.
#>
param(
    [Parameter(Mandatory = $true)]
    [string[]]$Path,

    [string]$ReportPath = "",

    [switch]$AllowUnsigned
)

$ErrorActionPreference = 'Stop'

function ConvertTo-RelativeDisplayPath([string]$ResolvedPath) {
    try {
        $repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
        if ($ResolvedPath.StartsWith($repoRoot, [System.StringComparison]::OrdinalIgnoreCase)) {
            return $ResolvedPath.Substring($repoRoot.Length + 1).Replace('\', '/')
        }
    } catch {
        # Keep absolute path when the file is outside the repo.
    }
    return $ResolvedPath
}

$results = @()
$errors = New-Object System.Collections.Generic.List[string]

foreach ($item in $Path) {
    if (-not (Test-Path -LiteralPath $item -PathType Leaf)) {
        throw "file not found for Authenticode verification: $item"
    }

    $resolved = (Resolve-Path -LiteralPath $item).Path
    $signature = Get-AuthenticodeSignature -LiteralPath $resolved
    $status = [string]$signature.Status
    $isValid = $status -eq 'Valid'
    $isUnsigned = $status -eq 'NotSigned'
    $accepted = $isValid -or ($AllowUnsigned -and $isUnsigned)

    $results += [ordered]@{
        path = ConvertTo-RelativeDisplayPath $resolved
        status = $status
        accepted = $accepted
        allow_unsigned = [bool]$AllowUnsigned
        status_message = [string]$signature.StatusMessage
        signer_subject = if ($signature.SignerCertificate) { [string]$signature.SignerCertificate.Subject } else { $null }
        signer_issuer = if ($signature.SignerCertificate) { [string]$signature.SignerCertificate.Issuer } else { $null }
        signer_thumbprint = if ($signature.SignerCertificate) { [string]$signature.SignerCertificate.Thumbprint } else { $null }
        timestamp_subject = if ($signature.TimeStamperCertificate) { [string]$signature.TimeStamperCertificate.Subject } else { $null }
    }

    if (-not $accepted) {
        $errors.Add("$resolved Authenticode status is $status")
    }
}

if ($ReportPath) {
    $reportDir = Split-Path -Parent $ReportPath
    if ($reportDir) { New-Item -ItemType Directory -Force -Path $reportDir | Out-Null }
    [ordered]@{
        generated_at = (Get-Date).ToUniversalTime().ToString('o')
        allow_unsigned = [bool]$AllowUnsigned
        files = $results
    } | ConvertTo-Json -Depth 6 | Set-Content -LiteralPath $ReportPath -Encoding UTF8
}

foreach ($result in $results) {
    Write-Host ("Authenticode {0}: {1}" -f $result.status, $result.path)
}

if ($errors.Count -gt 0) {
    foreach ($err in $errors) { Write-Error $err }
    throw "Authenticode verification failed: $($errors.Count) file(s)"
}

Write-Host "Authenticode verification: PASS ($($results.Count) file(s))" -ForegroundColor Green
