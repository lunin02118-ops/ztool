<#
.SYNOPSIS
  Build the ZTool client entirely from source (no IL reinjection).

.DESCRIPTION
  Compiles client-src/ZTool.csproj into bin/Release/net48/ZTool.exe.
  This is the full-source build of the client (forms, BOM logic, SolidWorks
  interop, licensing). It is the canonical, editable source tree produced by
  decompiling the vendor base and applying the mechanical fixes documented in
  README.md.

  Requires the .NET SDK; targets net48 (the .NET Framework 4.8 reference pack is
  pulled in via Microsoft.NETFramework.ReferenceAssemblies at build time).
#>
param(
    [string]$Configuration = 'Release'
)
$ErrorActionPreference = 'Stop'
$here = Split-Path -Parent $MyInvocation.MyCommand.Path
dotnet build (Join-Path $here 'ZTool.csproj') -c $Configuration
Write-Host "Output: $(Join-Path $here "bin\$Configuration\net48\ZTool.exe")"
