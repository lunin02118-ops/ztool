<#
.SYNOPSIS
  Validate the SWTools third-party inventory against the repository license
  policy. The gate fails on prohibited or malformed entries; review-required
  entries must carry an explicit exception id and remain P4 blockers.
#>
param(
    [string]$InventoryPath = ""
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
if (-not $InventoryPath) {
    $InventoryPath = Join-Path $repoRoot 'docs\compliance\third_party_inventory.json'
}

if (-not (Test-Path -LiteralPath $InventoryPath -PathType Leaf)) {
    throw "inventory not found: $InventoryPath"
}

$inventory = Get-Content -LiteralPath $InventoryPath -Raw -Encoding UTF8 | ConvertFrom-Json
$denylisted = @(
    'GPL-1.0-only', 'GPL-2.0-only', 'GPL-3.0-only',
    'LGPL-2.0-only', 'LGPL-2.1-only', 'LGPL-3.0-only',
    'AGPL-1.0-only', 'AGPL-3.0-only',
    'SSPL-1.0', 'BUSL-1.1'
)

$errors = New-Object System.Collections.Generic.List[string]
$warnings = New-Object System.Collections.Generic.List[string]

foreach ($item in $inventory.items) {
    $name = [string]$item.name
    if ([string]::IsNullOrWhiteSpace($name)) { $errors.Add('inventory item has empty name'); continue }
    foreach ($field in @('origin_class', 'license', 'status')) {
        if ([string]::IsNullOrWhiteSpace([string]$item.$field)) {
            $errors.Add("${name}: missing $field")
        }
    }
    if (-not $item.paths -or @($item.paths).Count -eq 0) {
        $errors.Add("${name}: missing paths")
    }

    $license = [string]$item.license
    $status = [string]$item.status
    $exception = [string]$item.exception_id

    if ($status -eq 'prohibited') {
        $errors.Add("${name}: status is prohibited")
    }

    if ($denylisted -contains $license -and [string]::IsNullOrWhiteSpace($exception)) {
        $errors.Add("${name}: denylisted license $license requires explicit exception_id")
    }

    if ($status -eq 'review_required') {
        if ([string]::IsNullOrWhiteSpace($exception)) {
            $errors.Add("${name}: review_required item must have exception_id")
        } else {
            $warnings.Add("${name}: review required ($license), exception=$exception")
        }
    }

    if ($license -eq 'UNKNOWN' -and $status -ne 'review_required') {
        $errors.Add("${name}: UNKNOWN license must be review_required")
    }
}

foreach ($warning in $warnings) {
    Write-Warning $warning
}

if ($errors.Count -gt 0) {
    foreach ($err in $errors) { Write-Error $err }
    throw "license policy check failed: $($errors.Count) error(s)"
}

Write-Host "license policy check: PASS ($($inventory.items.Count) item(s), $($warnings.Count) review-required blocker(s))" -ForegroundColor Green
