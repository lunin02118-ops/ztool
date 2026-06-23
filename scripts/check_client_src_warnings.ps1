param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release',

    [string]$BaselinePath = (Join-Path $PSScriptRoot '..\docs\audit\CLIENT_SRC_WARNING_BASELINE_RU.md'),

    [string]$SolidWorksToolsPath,

    [string]$LogDir = (Join-Path ([System.IO.Path]::GetTempPath()) ("swtools-client-src-warnings-" + (Get-Date -Format 'yyyyMMdd-HHmmss'))),

    [switch]$SkipBuild
)

$ErrorActionPreference = 'Stop'

function Fail([string]$Message) {
    Write-Error $Message
    exit 1
}

function Read-WarningBaseline([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        Fail "warning baseline missing: $Path"
    }

    $text = Get-Content -LiteralPath $Path -Encoding UTF8 -Raw
    $match = [regex]::Match(
        $text,
        '(?s)<!-- CLIENT_SRC_WARNING_BASELINE_JSON_START -->\s*(?<json>.*?)\s*<!-- CLIENT_SRC_WARNING_BASELINE_JSON_END -->'
    )
    if (-not $match.Success) {
        Fail "machine-readable warning baseline block not found in: $Path"
    }

    return ($match.Groups['json'].Value | ConvertFrom-Json)
}

function Invoke-LoggedDotNetBuild([string]$Name, [string[]]$Arguments, [string]$LogPath) {
    Write-Host "build: $Name" -ForegroundColor Cyan
    Write-Host "dotnet $($Arguments -join ' ')" -ForegroundColor DarkGray

    $output = & dotnet @Arguments 2>&1
    $exitCode = $LASTEXITCODE
    $lines = @($output | ForEach-Object { [string]$_ })
    [System.IO.File]::WriteAllText(
        $LogPath,
        ($lines -join [Environment]::NewLine),
        [System.Text.UTF8Encoding]::new($false)
    )

    if ($exitCode -ne 0) {
        Fail "$Name build failed with exit code $exitCode; log: $LogPath"
    }
}

function Get-WarningsFromLog([string]$LogPath, [string]$RepoRoot) {
    if (-not (Test-Path -LiteralPath $LogPath -PathType Leaf)) {
        Fail "build log missing: $LogPath"
    }

    $warnings = foreach ($line in Get-Content -LiteralPath $LogPath -Encoding UTF8) {
        if ($line -match '^(?<file>.+?\.cs)\((?<line>\d+),(?<column>\d+)\): warning (?<code>[A-Z]+\d+):') {
            $file = $Matches['file']
            if ($file.StartsWith($RepoRoot, [System.StringComparison]::OrdinalIgnoreCase)) {
                $file = $file.Substring($RepoRoot.Length).TrimStart('\', '/')
            }

            [pscustomobject]@{
                file = $file.Replace('\', '/')
                line = [int]$Matches['line']
                column = [int]$Matches['column']
                code = $Matches['code']
            }
        }
    }

    return @($warnings | Sort-Object file, line, column, code -Unique)
}

function ConvertTo-CodeCountMap($Warnings) {
    $map = [ordered]@{}
    foreach ($group in ($Warnings | Group-Object code | Sort-Object Name)) {
        $map[$group.Name] = [int]$group.Count
    }
    return $map
}

function Compare-CodeCounts([string]$Project, $Expected, $ActualMap) {
    $expectedMap = [ordered]@{}
    foreach ($property in $Expected.codes.PSObject.Properties) {
        $expectedMap[$property.Name] = [int]$property.Value
    }

    $allCodes = @($expectedMap.Keys + $ActualMap.Keys | Sort-Object -Unique)
    $errors = New-Object System.Collections.Generic.List[string]
    foreach ($code in $allCodes) {
        $expectedCount = if ($expectedMap.Contains($code)) { $expectedMap[$code] } else { 0 }
        $actualCount = if ($ActualMap.Contains($code)) { $ActualMap[$code] } else { 0 }
        if ($expectedCount -ne $actualCount) {
            $errors.Add("$Project ${code}: expected $expectedCount, actual $actualCount")
        }
    }

    return $errors
}

$repoRoot = (Resolve-Path -LiteralPath (Join-Path $PSScriptRoot '..')).Path
$resolvedBaselinePath = if ([System.IO.Path]::IsPathRooted($BaselinePath)) {
    $BaselinePath
} else {
    Join-Path $repoRoot ($BaselinePath -replace '^[.][\\/]', '')
}
$baseline = Read-WarningBaseline -Path $resolvedBaselinePath

Push-Location $repoRoot
try {

New-Item -ItemType Directory -Force -Path $LogDir | Out-Null
$resolvedLogDir = (Resolve-Path -LiteralPath $LogDir).Path

$clientLog = Join-Path $resolvedLogDir 'client-src-build.log'
$shimLog = Join-Path $resolvedLogDir 'client-src-addin-shim-build.log'
$addinLog = Join-Path $resolvedLogDir 'client-src-addin-build.log'

if (-not $SkipBuild) {
    Invoke-LoggedDotNetBuild `
        -Name 'client-src' `
        -Arguments @('build', 'client-src/ZTool.csproj', '-c', $Configuration, '-warnaserror:false', '--no-incremental', '-v:minimal') `
        -LogPath $clientLog

    if (-not $SolidWorksToolsPath) {
        Invoke-LoggedDotNetBuild `
            -Name 'client-src-addin sdk-shim' `
            -Arguments @('build', 'client-src-addin/sdk-shim/SolidWorksTools.Shim.csproj', '-c', $Configuration, '--no-incremental', '-v:minimal') `
            -LogPath $shimLog
        $SolidWorksToolsPath = (Resolve-Path -LiteralPath "client-src-addin/sdk-shim/bin/$Configuration/net48/SolidWorksTools.dll").Path
    }

    Invoke-LoggedDotNetBuild `
        -Name 'client-src-addin' `
        -Arguments @('build', 'client-src-addin/ZTool.SwAddin.csproj', '-c', $Configuration, '-warnaserror:false', '--no-incremental', "-p:SolidWorksToolsPath=$SolidWorksToolsPath", '-v:minimal') `
        -LogPath $addinLog
}

$actual = [ordered]@{
    'client-src' = Get-WarningsFromLog -LogPath $clientLog -RepoRoot $repoRoot
    'client-src-addin' = Get-WarningsFromLog -LogPath $addinLog -RepoRoot $repoRoot
}

$failures = New-Object System.Collections.Generic.List[string]
foreach ($projectProperty in $baseline.projects.PSObject.Properties) {
    $project = $projectProperty.Name
    if (-not $actual.Contains($project)) {
        $failures.Add("baseline project has no actual warning set: $project")
        continue
    }

    $expected = $projectProperty.Value
    $warnings = @($actual[$project])
    $actualMap = ConvertTo-CodeCountMap -Warnings $warnings

    Write-Host "$project warnings: $($warnings.Count)" -ForegroundColor Cyan
    foreach ($key in $actualMap.Keys) {
        Write-Host "  $key=$($actualMap[$key])"
    }

    if ([int]$expected.total -ne $warnings.Count) {
        $failures.Add("$project total: expected $($expected.total), actual $($warnings.Count)")
    }

    foreach ($failure in (Compare-CodeCounts -Project $project -Expected $expected -ActualMap $actualMap)) {
        $failures.Add($failure)
    }
}

if ($failures.Count -gt 0) {
    Write-Host "warning baseline drift:" -ForegroundColor Red
    foreach ($failure in $failures) {
        Write-Host "  - $failure" -ForegroundColor Red
    }
    Fail "client source warning baseline mismatch; update/fix warnings and then update $BaselinePath explicitly"
}

Write-Host "client source warning baseline: PASS (logs: $resolvedLogDir)" -ForegroundColor Green
} finally {
    Pop-Location
}
