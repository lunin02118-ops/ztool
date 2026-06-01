<#
.SYNOPSIS
  Produce the shipped ZTool.settings profile with a complete, clean section set.

.DESCRIPTION
  The runtime config (ZTool.CConfigDO) is XML-serialized. A profile that omits a
  List<> member deserializes that member as an EMPTY list, so the Save-options
  dialog (FrmSaveOption) then falls back to its WinForms designer defaults. One
  of those defaults is CheckBox6 (= code.Updatereferencebool) = True, which makes
  the dialog auto-fill the "reference update" folder (TextBox1) from the currently
  opened model's directory and persist it on save. That stale absolute path then
  drives the "Сохранить в папку" column on subsequent saves.

  This script ships all five previously-missing sections explicitly:
    savetoswcfg, Dropdownlist, namemappinglist, fillsettings, fillcolumncfg
  so the distribution never relies on volatile designer defaults:
    * savetoswcfg  -> vendor designer defaults EXCEPT CheckBox6=False (ref-update
                      off) and TextBox1 empty (no foreign/stale save path).
    * the other 4  -> present but empty (a fresh install carries no foreign data).

  SWver=0 (version-independent ProgID) and the localized Russian column set are
  taken from the existing base profile and preserved unchanged.

.EXAMPLE
  ./gen_dist_profile.ps1
#>
param(
    [string]$BaseExe  = (Join-Path $PSScriptRoot '..\..\ZTool.base.exe'),
    [string]$InProfile  = (Join-Path $PSScriptRoot '..\dist\ZTool.settings'),
    [string]$OutProfile = (Join-Path $PSScriptRoot '..\dist\ZTool.settings')
)

$ErrorActionPreference = 'Stop'
if (-not (Test-Path $BaseExe))   { throw "base exe not found: $BaseExe" }
if (-not (Test-Path $InProfile)) { throw "base profile not found: $InProfile" }

# CConfigDO + its element types live in the intact (non-publicized) assembly.
# The publicized DLL must NOT be used here: its public backing fields (_SWver,
# _propname, ...) would be serialized alongside the properties and duplicate
# every element.
$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path $BaseExe))
$t   = $asm.GetType('ZTool.CConfigDO')
$ser = New-Object System.Xml.Serialization.XmlSerializer($t)

$fs  = [System.IO.File]::OpenText((Resolve-Path $InProfile))
$cfg = $ser.Deserialize($fs); $fs.Close()

# savetoswcfg: "<ControlName>`n<value>" pairs (matches FrmSaveOption.FindctlToSave)
$listStr = [System.Collections.Generic.List[string]]
$sts = [Activator]::CreateInstance($listStr)
$pairs = @(
    'ComboBox1|0','ComboBox2|0','ComboBox3|0','ComboBox4|0',
    'CheckBox1|False','CheckBox2|False','CheckBox3|True','CheckBox4|False',
    'CheckBox6|False','CheckBox7|True','CheckBox8|True','CheckBox9|False','CheckBox10|False',
    'RadioButton1|False','RadioButton2|True','RadioButton3|False',
    'TextBox1|'
)
foreach ($p in $pairs) { $kv = $p.Split('|'); $sts.Add($kv[0] + "`n" + $kv[1]) }
$t.GetProperty('savetoswcfg').SetValue($cfg, $sts)

# the remaining four sections: present but empty (non-null), no foreign data
$t.GetProperty('Dropdownlist').SetValue($cfg, [Activator]::CreateInstance($listStr))
$t.GetProperty('fillcolumncfg').SetValue($cfg, [Activator]::CreateInstance($listStr))
$tNm = $asm.GetType('ZTool.columnnamemapping')
$tFs = $asm.GetType('ZTool.fillsetting')
$t.GetProperty('namemappinglist').SetValue($cfg, [Activator]::CreateInstance([System.Collections.Generic.List`1].MakeGenericType($tNm)))
$t.GetProperty('fillsettings').SetValue($cfg, [Activator]::CreateInstance([System.Collections.Generic.List`1].MakeGenericType($tFs)))

$sw = New-Object System.IO.StreamWriter($OutProfile, $false, (New-Object System.Text.UTF8Encoding($false)))
$ser.Serialize($sw, $cfg); $sw.Close()
Write-Host "wrote $OutProfile" -ForegroundColor Green

# round-trip sanity check
$fs2 = [System.IO.File]::OpenText($OutProfile)
$chk = $ser.Deserialize($fs2); $fs2.Close()
foreach ($m in 'savetoswcfg','Dropdownlist','namemappinglist','fillsettings','fillcolumncfg') {
    $v = $t.GetProperty($m).GetValue($chk)
    if ($null -eq $v) { throw "section $m deserialized as NULL" }
    Write-Host ("  {0}: count={1}" -f $m, $v.Count)
}
