using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[Serializable]
public class CConfigDO
{
	public int SWver
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string materialpath
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int rowcolor
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool colorselrow
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> propname
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int rowheight
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> proptype
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> outcfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> printcfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> Unitset
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ReadOnlyFolder
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> Preview_Hotkey
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string bompath
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public Size image_size
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool image_lockratio
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int insertimagebool
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int GetAllconfigsbool
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ExcludePropList
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int ExcludePropbool
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public Point FrmPreviewLocation
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool DClick_OpenInSw
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool RowFollowdisplay
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool DefaultDrw
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string ReNameRule
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool Excludevirtual
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool togetherConfig
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int GetDataOption
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> propshow
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> Dropdownlist
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> savetoswcfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string bomname
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool bomsubfolder
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ColIndex
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ColWidth
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> SetDrwCfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperA0
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperA1
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperA2
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperA3
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperA4V
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperA4H
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string DrawPaperOther
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool BomByVal
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ReNameByFilter
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ReNameByRule
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ReNameByCheck
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ReNameFilterarr
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> Colvisible
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int ReadOnlyFolderbool
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int ReConnectClearFilter
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int MenuStyle
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string MenuColor
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string MenuColor2
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<CustomRule> FilterRulesList
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ReNameFilterRule
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ExpandMaterialList
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string OutSaveFolder
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool HideSw1
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> SaveToSWFilterRule
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ExcludeLight
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int FrozenCol
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string QuickAccessToolbarini
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> ExportToBomFilterRule
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ExportToBom_ByFilter1
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ExportToBom_ByFilter2
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> Replacereferencecfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool Marknodrw
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool Excludebyruler
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool Previewfortool
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> regexlist
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> regexlist_split
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> needfillcolumns
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> SplitColumncfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool RealTimeFilter
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int PreviewMode
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int ptp
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string iad
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string ipt
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string iun
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string ipw
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool Thumbnail_Savetolocal
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int Thumbnail_position
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<bomsetting> bomsettings
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> K3code
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> macrolist
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool checkupdata
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool IsCollpased
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int Splitwidth
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> copyswfilecfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<columnnamemapping> namemappinglist
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool usenpoi
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int[] customcolors
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> frmsortcfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<fillsetting> fillsettings
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public byte[] tfont
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public byte[] tcolor
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<box> itemlist
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int filterindex
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int viewtype
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public Size mainformsize
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public Point mainformLocation
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int mainformWindowState
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool usematerialcolor
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int markrepeat
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<string> fillcolumncfg
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string relatedfilldata
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string version
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public List<ColumnInfo> columnInfolist
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public CConfigDO()
	{
		int sWver = 0;
		SWver = sWver;
		string text = "";
		materialpath = text;
		sWver = 66;
		rowcolor = sWver;
		bool flag = false;
		colorselrow = flag;
		sWver = 25;
		rowheight = sWver;
		text = "";
		bompath = text;
		Size size = new Size(64, 64);
		image_size = size;
		flag = true;
		image_lockratio = flag;
		sWver = 0;
		insertimagebool = sWver;
		sWver = 0;
		GetAllconfigsbool = sWver;
		sWver = 0;
		ExcludePropbool = sWver;
		Point frmPreviewLocation = new Point(0, 0);
		FrmPreviewLocation = frmPreviewLocation;
		flag = false;
		DClick_OpenInSw = flag;
		flag = true;
		RowFollowdisplay = flag;
		flag = false;
		DefaultDrw = flag;
		text = "";
		ReNameRule = text;
		flag = false;
		Excludevirtual = flag;
		flag = false;
		togetherConfig = flag;
		flag = false;
		bomsubfolder = flag;
		flag = true;
		BomByVal = flag;
		flag = false;
		ReNameByFilter = flag;
		flag = false;
		ReNameByRule = flag;
		flag = false;
		ReNameByCheck = flag;
		sWver = 0;
		ReadOnlyFolderbool = sWver;
		sWver = 0;
		ReConnectClearFilter = sWver;
		sWver = 2;
		MenuStyle = sWver;
		text = Conversions.ToString(2);
		MenuColor = text;
		text = Conversions.ToString(2);
		MenuColor2 = text;
		flag = false;
		ExpandMaterialList = flag;
		flag = false;
		HideSw1 = flag;
		flag = false;
		ExcludeLight = flag;
		sWver = 0;
		FrozenCol = sWver;
		flag = true;
		ExportToBom_ByFilter1 = flag;
		flag = false;
		ExportToBom_ByFilter2 = flag;
		flag = false;
		Marknodrw = flag;
		flag = true;
		Excludebyruler = flag;
		flag = true;
		Previewfortool = flag;
		flag = true;
		RealTimeFilter = flag;
		sWver = 0;
		PreviewMode = sWver;
		sWver = 0;
		ptp = sWver;
		text = Conversions.ToString(8080);
		ipt = text;
		flag = false;
		Thumbnail_Savetolocal = flag;
		sWver = 0;
		Thumbnail_position = sWver;
		flag = true;
		checkupdata = flag;
		flag = false;
		IsCollpased = flag;
		sWver = 300;
		Splitwidth = sWver;
		flag = true;
		usenpoi = flag;
		Size size2 = new Size(873, 621);
		mainformsize = size2;
		Point point = new Point(0, 0);
		mainformLocation = point;
		sWver = -1;
		markrepeat = sWver;
	}

	public void InitDefaults()
	{
		propname = new List<string> { "Разработал", "Наименование", "Обозначение", "Материал", "Тип", "Версия", "Обработка поверхности", "Дата разработки", "Масса" };
		proptype = new List<string> { "Текст", "Текст", "Текст", "Текст", "Текст", "Текст", "Текст", "Дата", "Текст" };
		Preview_Hotkey = new List<string>
		{
			Conversions.ToString(18),
			Conversions.ToString(90)
		};
		propshow = new List<string> { "1", "1", "1", "1", "1", "1", "1", "1", "1" };
		needfillcolumns = new List<string> { "Обозначение\n0", "Наименование\n1", "Версия\n2" };
		bomsettings = new List<bomsetting>
		{
			new bomsetting
			{
				name = "Экспорт сводной спецификации",
				type = 0
			},
			new bomsetting
			{
				name = "Экспорт иерархической спецификации",
				type = 1
			},
			new bomsetting
			{
				name = "Экспорт спецификации верхнего уровня",
				type = 2
			},
			new bomsetting
			{
				name = "Экспорт сводной спецификации деталей",
				type = 3
			}
		};
	}
}
