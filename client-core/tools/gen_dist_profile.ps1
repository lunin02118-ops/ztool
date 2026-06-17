<#
.SYNOPSIS
  Produce the shipped ZTool.settings profile with a complete, clean section set.

.DESCRIPTION
  The runtime config (ZTool.CConfigDO) is XML-serialized. A profile that omits a
  List<> member deserializes that member as an EMPTY list, so the Save-options
  dialog (FrmSaveOption) then falls back to its WinForms designer defaults.

  CheckBox6 (= code.Updatereferencebool, label "Обновлять ссылки") is the
  MASTER SWITCH for "save/relocate to a new folder": the per-row "Сохранить в
  папку" target (Col_NewFolder / NewPathName) is only honored by the SW
  add-in when this flag is True. With it False the add-in saves in place and the
  target folder stays empty. Its companion folder field TextBox1 is irrelevant to
  persist because FrmSaveOption_Load ALWAYS recomputes it to the currently opened
  model's directory (Path.GetDirectoryName(DGV1.Tag)) right after Loadcfg().

  This script ships all previously-missing sections explicitly:
    savetoswcfg, Dropdownlist, fillsettings, fillcolumncfg, columnInfolist
  so the distribution never relies on volatile designer defaults:
    * savetoswcfg  -> vendor designer defaults: CheckBox6=True (ref-update ON, the
                      vendor default, so save-to-new-folder works out of the box)
                      and TextBox1 empty (recomputed on load; carries no path).
    * Dropdownlist, fillsettings, fillcolumncfg -> present but empty (a fresh
                      install carries no foreign data).
    * columnInfolist -> complete default grid layout with both property-column
                        views visible. Write flows must switch PropSwitch to the
                        editable PropVal_* view before saving to SolidWorks.
    * namemappinglist is intentionally preserved from the base profile: it maps
      PropVal_* columns to BOM template anchors and is release functionality,
      not user noise.

  SWver=0 (version-independent ProgID) and the localized Russian column set are
  taken from the existing base profile and preserved unchanged.

.EXAMPLE
  ./gen_dist_profile.ps1
#>
param(
    [string]$BaseExe  = (Join-Path $PSScriptRoot '..\..\ZTool-base.exe'),
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
    'CheckBox6|True','CheckBox7|True','CheckBox8|True','CheckBox9|False','CheckBox10|False',
    'RadioButton1|False','RadioButton2|True','RadioButton3|False',
    'TextBox1|'
)
foreach ($p in $pairs) { $kv = $p.Split('|'); $sts.Add($kv[0] + "`n" + $kv[1]) }
$t.GetProperty('savetoswcfg').SetValue($cfg, $sts)

# user-data sections: present but empty (non-null), no foreign data
$t.GetProperty('Dropdownlist').SetValue($cfg, [Activator]::CreateInstance($listStr))
$t.GetProperty('fillcolumncfg').SetValue($cfg, [Activator]::CreateInstance($listStr))
$tFs = $asm.GetType('ZTool.fillsetting')
$t.GetProperty('fillsettings').SetValue($cfg, [Activator]::CreateInstance([System.Collections.Generic.List`1].MakeGenericType($tFs)))

# Functional mapping section: preserve PropVal_* -> template anchors from the
# base profile. Only guard against a missing/null section.
$nmProp = $t.GetProperty('namemappinglist')
if ($null -eq $nmProp.GetValue($cfg)) {
    $tNm = $asm.GetType('ZTool.columnnamemapping')
    $nmProp.SetValue($cfg, [Activator]::CreateInstance([System.Collections.Generic.List`1].MakeGenericType($tNm)))
}

# columnInfolist: ship a deterministic grid layout. The vendor grid creates
# PropVal_i/PropResolvedVal_i pairs after the first 21 columns:
#   21,23,...,37 => editable PropVal_0..8 (must be visible for Save to SW)
#   22,24,...,38 => read-only PropResolvedVal_0..8. They are also made
#                   visible because the vendor PropSwitch can otherwise hide
#                   the raw columns during fresh-start grid construction.
$tCi = $asm.GetType('ZTool.ColumnInfo')
$listCi = [System.Collections.Generic.List`1].MakeGenericType($tCi)
$columns = [Activator]::CreateInstance($listCi)
$displayIndex = @{
    0=0; 1=1; 2=2; 3=3; 4=4; 5=5; 6=6; 7=8; 8=7; 9=27; 10=28; 11=29;
    12=30; 13=31; 14=32; 15=33; 16=34; 17=38; 18=37; 19=39; 20=35;
    21=9; 22=10; 23=11; 24=12; 25=13; 26=14; 27=15; 28=16; 29=17; 30=18;
    31=19; 32=20; 33=21; 34=22; 35=23; 36=24; 37=25; 38=26; 39=36
}
$width = @{
    0=68; 1=20; 2=22; 3=22; 4=45; 5=344; 6=440; 7=150; 8=140; 9=191; 10=140; 11=140
}
$visible = @{
    0=$false; 1=$false; 2=$true; 3=$true; 4=$true; 5=$true; 6=$false; 7=$true; 8=$true;
    9=$true; 10=$false; 11=$true; 12=$false; 13=$false; 14=$false; 15=$false; 16=$false;
    17=$false; 18=$false; 19=$false; 20=$false; 21=$true; 22=$true; 23=$true; 24=$true;
    25=$true; 26=$true; 27=$true; 28=$true; 29=$true; 30=$true; 31=$true; 32=$true;
    33=$true; 34=$true; 35=$true; 36=$true; 37=$true; 38=$true; 39=$false
}
foreach ($i in 0..39) {
    $ci = [Activator]::CreateInstance($tCi)
    $tCi.GetProperty('index').SetValue($ci, $i)
    $tCi.GetProperty('DisplayIndex').SetValue($ci, [int]$displayIndex[$i])
    $tCi.GetProperty('Width').SetValue($ci, [int]($(if ($width.ContainsKey($i)) { $width[$i] } else { 200 })))
    $tCi.GetProperty('Visible').SetValue($ci, [bool]$visible[$i])
    $columns.Add($ci)
}
$t.GetProperty('columnInfolist').SetValue($cfg, $columns)

$sw = New-Object System.IO.StreamWriter($OutProfile, $false, (New-Object System.Text.UTF8Encoding($false)))
$ser.Serialize($sw, $cfg); $sw.Close()
Write-Host "wrote $OutProfile" -ForegroundColor Green

# round-trip sanity check
$fs2 = [System.IO.File]::OpenText($OutProfile)
$chk = $ser.Deserialize($fs2); $fs2.Close()
foreach ($m in 'savetoswcfg','Dropdownlist','namemappinglist','fillsettings','fillcolumncfg','columnInfolist') {
    $v = $t.GetProperty($m).GetValue($chk)
    if ($null -eq $v) { throw "section $m deserialized as NULL" }
    Write-Host ("  {0}: count={1}" -f $m, $v.Count)
}
