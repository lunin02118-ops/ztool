using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmOutputoptions : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__11
	{
		public string _0024VB_0024Local_cfg;

		[DebuggerNonUserCode]
		public _Closure_0024__11(_Closure_0024__11 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_cfg = other._0024VB_0024Local_cfg;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__11()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__19(string s)
		{
			return s.Equals(_0024VB_0024Local_cfg, StringComparison.CurrentCultureIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__12
	{
		public string _0024VB_0024Local_cfg;

		[DebuggerNonUserCode]
		public _Closure_0024__12(_Closure_0024__12 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_cfg = other._0024VB_0024Local_cfg;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__12()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__23(string s)
		{
			return s.Equals(_0024VB_0024Local_cfg, StringComparison.CurrentCultureIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("TabPage5")]
	private TabPage _TabPage5;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("forcurcfg")]
	private CheckBox _forcurcfg;

	[AccessedThroughProperty("HideSw1")]
	private CheckBox _HideSw1;

	[AccessedThroughProperty("GroupBox5")]
	private GroupBox _GroupBox5;

	[AccessedThroughProperty("exclude_AsWelded")]
	private CheckBox _exclude_AsWelded;

	[AccessedThroughProperty("exclude_AsMachined")]
	private CheckBox _exclude_AsMachined;

	[AccessedThroughProperty("exclude_SpeedPak")]
	private CheckBox _exclude_SpeedPak;

	[AccessedThroughProperty("exclude_IsDerived")]
	private CheckBox _exclude_IsDerived;

	[AccessedThroughProperty("exclude_SheetMetal")]
	private CheckBox _exclude_SheetMetal;

	[AccessedThroughProperty("TabPage3")]
	private TabPage _TabPage3;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("outputscale")]
	private CheckBox _outputscale;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("CADline")]
	private ComboBox _CADline;

	[AccessedThroughProperty("CADfont")]
	private ComboBox _CADfont;

	[AccessedThroughProperty("CADVer")]
	private ComboBox _CADVer;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("Image_dpi")]
	private ComboBox _Image_dpi;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("ImageType")]
	private ComboBox _ImageType;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("Multiplesheet_pdf")]
	private ComboBox _Multiplesheet_pdf;

	[AccessedThroughProperty("PDFline")]
	private CheckBox _PDFline;

	[AccessedThroughProperty("PDFfont")]
	private CheckBox _PDFfont;

	[AccessedThroughProperty("PDFcolor")]
	private CheckBox _PDFcolor;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("TabPage2")]
	private TabPage _TabPage2;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Browse")]
	private Button _Browse;

	[AccessedThroughProperty("folder")]
	private TextBox _folder;

	[AccessedThroughProperty("Thisfolder")]
	private RadioButton _Thisfolder;

	[AccessedThroughProperty("Originalfolder")]
	private RadioButton _Originalfolder;

	[AccessedThroughProperty("Out2D_type")]
	private GroupBox _Out2D_type;

	[AccessedThroughProperty("OUT_DetachedDraw")]
	private CheckBox _OUT_DetachedDraw;

	[AccessedThroughProperty("OUT_PDF")]
	private CheckBox _OUT_PDF;

	[AccessedThroughProperty("OUT_DXF")]
	private CheckBox _OUT_DXF;

	[AccessedThroughProperty("CheckBox6")]
	private CheckBox _CheckBox6;

	[AccessedThroughProperty("OUT_JPG")]
	private CheckBox _OUT_JPG;

	[AccessedThroughProperty("OUT_DWG")]
	private CheckBox _OUT_DWG;

	[AccessedThroughProperty("OUT_PNG")]
	private CheckBox _OUT_PNG;

	[AccessedThroughProperty("Out3D_type")]
	private GroupBox _Out3D_type;

	[AccessedThroughProperty("CheckBox4")]
	private CheckBox _CheckBox4;

	[AccessedThroughProperty("CheckBox3")]
	private CheckBox _CheckBox3;

	[AccessedThroughProperty("CheckBox2")]
	private CheckBox _CheckBox2;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[AccessedThroughProperty("OUT_IGS")]
	private CheckBox _OUT_IGS;

	[AccessedThroughProperty("CheckBox5")]
	private CheckBox _CheckBox5;

	[AccessedThroughProperty("OUT_STEP")]
	private CheckBox _OUT_STEP;

	[AccessedThroughProperty("OUT_3DPDF")]
	private CheckBox _OUT_3DPDF;

	[AccessedThroughProperty("CheckBox7")]
	private CheckBox _CheckBox7;

	[AccessedThroughProperty("OUT_JPG2")]
	private CheckBox _OUT_JPG2;

	[AccessedThroughProperty("OUT_PNG2")]
	private CheckBox _OUT_PNG2;

	[AccessedThroughProperty("TabControl1")]
	private TabControl _TabControl1;

	[AccessedThroughProperty("Multiplesheet_dwg")]
	private ComboBox _Multiplesheet_dwg;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("withoutcfgname")]
	private CheckBox _withoutcfgname;

	[AccessedThroughProperty("SetScalebyfirstview")]
	private CheckBox _SetScalebyfirstview;

	[AccessedThroughProperty("ExportAllSheetsToPaperSpace")]
	private CheckBox _ExportAllSheetsToPaperSpace;

	[AccessedThroughProperty("customname_3d")]
	private TextBox _customname_3d;

	[AccessedThroughProperty("customname_2d")]
	private TextBox _customname_2d;

	[AccessedThroughProperty("TabPage1")]
	private TabPage _TabPage1;

	[AccessedThroughProperty("text_y")]
	private NumericUpDown _text_y;

	[AccessedThroughProperty("Label13")]
	private Label _Label13;

	[AccessedThroughProperty("text_x")]
	private NumericUpDown _text_x;

	[AccessedThroughProperty("Label12")]
	private Label _Label12;

	[AccessedThroughProperty("watertext")]
	private TextBox _watertext;

	[AccessedThroughProperty("add_watertext")]
	private CheckBox _add_watertext;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("GroupBox8")]
	private GroupBox _GroupBox8;

	[AccessedThroughProperty("GroupBox9")]
	private GroupBox _GroupBox9;

	[AccessedThroughProperty("Label15")]
	private Label _Label15;

	[AccessedThroughProperty("Label11")]
	private Label _Label11;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Label16")]
	private Label _Label16;

	[AccessedThroughProperty("text_postion")]
	private ComboBox _text_postion;

	[AccessedThroughProperty("FontDialog1")]
	private FontDialog _FontDialog1;

	[AccessedThroughProperty("TabPage4")]
	private TabPage _TabPage4;

	[AccessedThroughProperty("custom_3d")]
	private CheckBox _custom_3d;

	[AccessedThroughProperty("custom_2d")]
	private CheckBox _custom_2d;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("add_waterimg")]
	private CheckBox _add_waterimg;

	[AccessedThroughProperty("Label20")]
	private Label _Label20;

	[AccessedThroughProperty("img_path")]
	private TextBox _img_path;

	[AccessedThroughProperty("GroupBox6")]
	private GroupBox _GroupBox6;

	[AccessedThroughProperty("Label9")]
	private Label _Label9;

	[AccessedThroughProperty("img_postion")]
	private ComboBox _img_postion;

	[AccessedThroughProperty("img_y")]
	private NumericUpDown _img_y;

	[AccessedThroughProperty("Label10")]
	private Label _Label10;

	[AccessedThroughProperty("Label17")]
	private Label _Label17;

	[AccessedThroughProperty("Label18")]
	private Label _Label18;

	[AccessedThroughProperty("Label19")]
	private Label _Label19;

	[AccessedThroughProperty("img_x")]
	private NumericUpDown _img_x;

	[AccessedThroughProperty("Label22")]
	private Label _Label22;

	[AccessedThroughProperty("img_transparency")]
	private NumericUpDown _img_transparency;

	[AccessedThroughProperty("Label21")]
	private Label _Label21;

	[AccessedThroughProperty("Label23")]
	private Label _Label23;

	[AccessedThroughProperty("img_angle")]
	private NumericUpDown _img_angle;

	[AccessedThroughProperty("Label24")]
	private Label _Label24;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	[AccessedThroughProperty("Button5")]
	private Button _Button5;

	[AccessedThroughProperty("Panel2")]
	private Panel _Panel2;

	[AccessedThroughProperty("exclude_unactive")]
	private CheckBox _exclude_unactive;

	[AccessedThroughProperty("Label14")]
	private Label _Label14;

	private string FilePathName;

	private string FilePath;

	private string SavePath;

	private string FileName;

	private int swFileTYpe;

	private int longstatus;

	private int longwarnings;

	private int Errors;

	private int Warnings;

	[AccessedThroughProperty("OutBgWorker")]
	private BackgroundWorker _OutBgWorker;

	private bool CallInProgress;

	private bool er;

	private List<string> filelist;

	private List<string> cfglist;

	private List<string> statuslist;

	private List<int> indexlist;

	private ContextMenuStrip menu1;

	private ContextMenuStrip menu2;

	private double dpixRatio;

	private TextBox tb;

	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel1 = value;
		}
	}

	internal virtual Button OK_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _OK_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OK_Button_Click;
			if (_OK_Button != null)
			{
				_OK_Button.Click -= value2;
			}
			_OK_Button = value;
			if (_OK_Button != null)
			{
				_OK_Button.Click += value2;
			}
		}
	}

	internal virtual Button Cancel_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Cancel_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Cancel_Button_Click;
			if (_Cancel_Button != null)
			{
				_Cancel_Button.Click -= value2;
			}
			_Cancel_Button = value;
			if (_Cancel_Button != null)
			{
				_Cancel_Button.Click += value2;
			}
		}
	}

	internal virtual TabPage TabPage5
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage5 = value;
		}
	}

	internal virtual Label Label6
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label6 = value;
		}
	}

	internal virtual CheckBox forcurcfg
	{
		[DebuggerNonUserCode]
		get
		{
			return _forcurcfg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_forcurcfg = value;
		}
	}

	internal virtual CheckBox HideSw1
	{
		[DebuggerNonUserCode]
		get
		{
			return _HideSw1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_HideSw1 = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox5 = value;
		}
	}

	internal virtual CheckBox exclude_AsWelded
	{
		[DebuggerNonUserCode]
		get
		{
			return _exclude_AsWelded;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_exclude_AsWelded = value;
		}
	}

	internal virtual CheckBox exclude_AsMachined
	{
		[DebuggerNonUserCode]
		get
		{
			return _exclude_AsMachined;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_exclude_AsMachined = value;
		}
	}

	internal virtual CheckBox exclude_SpeedPak
	{
		[DebuggerNonUserCode]
		get
		{
			return _exclude_SpeedPak;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_exclude_SpeedPak = value;
		}
	}

	internal virtual CheckBox exclude_IsDerived
	{
		[DebuggerNonUserCode]
		get
		{
			return _exclude_IsDerived;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_exclude_IsDerived = value;
		}
	}

	internal virtual CheckBox exclude_SheetMetal
	{
		[DebuggerNonUserCode]
		get
		{
			return _exclude_SheetMetal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_exclude_SheetMetal = value;
		}
	}

	internal virtual TabPage TabPage3
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage3 = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox3 = value;
		}
	}

	internal virtual CheckBox outputscale
	{
		[DebuggerNonUserCode]
		get
		{
			return _outputscale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_outputscale = value;
		}
	}

	internal virtual Label Label3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label3 = value;
		}
	}

	internal virtual Label Label2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label2 = value;
		}
	}

	internal virtual Label Label1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label1 = value;
		}
	}

	internal virtual ComboBox CADline
	{
		[DebuggerNonUserCode]
		get
		{
			return _CADline;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CADline = value;
		}
	}

	internal virtual ComboBox CADfont
	{
		[DebuggerNonUserCode]
		get
		{
			return _CADfont;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CADfont = value;
		}
	}

	internal virtual ComboBox CADVer
	{
		[DebuggerNonUserCode]
		get
		{
			return _CADVer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = CADVer_SelectedIndexChanged;
			if (_CADVer != null)
			{
				_CADVer.SelectedIndexChanged -= value2;
			}
			_CADVer = value;
			if (_CADVer != null)
			{
				_CADVer.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox2 = value;
		}
	}

	internal virtual RadioButton RadioButton2
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RadioButton1_CheckedChanged;
			if (_RadioButton2 != null)
			{
				_RadioButton2.CheckedChanged -= value2;
			}
			_RadioButton2 = value;
			if (_RadioButton2 != null)
			{
				_RadioButton2.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RadioButton1
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RadioButton1_CheckedChanged;
			if (_RadioButton1 != null)
			{
				_RadioButton1.CheckedChanged -= value2;
			}
			_RadioButton1 = value;
			if (_RadioButton1 != null)
			{
				_RadioButton1.CheckedChanged += value2;
			}
		}
	}

	internal virtual ComboBox Image_dpi
	{
		[DebuggerNonUserCode]
		get
		{
			return _Image_dpi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = CADVer_SelectedIndexChanged;
			if (_Image_dpi != null)
			{
				_Image_dpi.SelectedIndexChanged -= value2;
			}
			_Image_dpi = value;
			if (_Image_dpi != null)
			{
				_Image_dpi.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Label Label5
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label5 = value;
		}
	}

	internal virtual ComboBox ImageType
	{
		[DebuggerNonUserCode]
		get
		{
			return _ImageType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = CADVer_SelectedIndexChanged;
			if (_ImageType != null)
			{
				_ImageType.SelectedIndexChanged -= value2;
			}
			_ImageType = value;
			if (_ImageType != null)
			{
				_ImageType.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Label Label4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label4 = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox4 = value;
		}
	}

	internal virtual ComboBox Multiplesheet_pdf
	{
		[DebuggerNonUserCode]
		get
		{
			return _Multiplesheet_pdf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Multiplesheet_pdf = value;
		}
	}

	internal virtual CheckBox PDFline
	{
		[DebuggerNonUserCode]
		get
		{
			return _PDFline;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PDFline = value;
		}
	}

	internal virtual CheckBox PDFfont
	{
		[DebuggerNonUserCode]
		get
		{
			return _PDFfont;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PDFfont = value;
		}
	}

	internal virtual CheckBox PDFcolor
	{
		[DebuggerNonUserCode]
		get
		{
			return _PDFcolor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PDFcolor = value;
		}
	}

	internal virtual Label Label7
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label7 = value;
		}
	}

	internal virtual TabPage TabPage2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage2 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox1 = value;
		}
	}

	internal virtual Button Browse
	{
		[DebuggerNonUserCode]
		get
		{
			return _Browse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Browse_Click;
			if (_Browse != null)
			{
				_Browse.Click -= value2;
			}
			_Browse = value;
			if (_Browse != null)
			{
				_Browse.Click += value2;
			}
		}
	}

	internal virtual TextBox folder
	{
		[DebuggerNonUserCode]
		get
		{
			return _folder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_folder = value;
		}
	}

	internal virtual RadioButton Thisfolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _Thisfolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Originalfolder_CheckedChanged;
			if (_Thisfolder != null)
			{
				_Thisfolder.CheckedChanged -= value2;
			}
			_Thisfolder = value;
			if (_Thisfolder != null)
			{
				_Thisfolder.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton Originalfolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _Originalfolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Originalfolder_CheckedChanged;
			if (_Originalfolder != null)
			{
				_Originalfolder.CheckedChanged -= value2;
			}
			_Originalfolder = value;
			if (_Originalfolder != null)
			{
				_Originalfolder.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox Out2D_type
	{
		[DebuggerNonUserCode]
		get
		{
			return _Out2D_type;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Out2D_type = value;
		}
	}

	internal virtual CheckBox OUT_DetachedDraw
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_DetachedDraw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_DetachedDraw = value;
		}
	}

	internal virtual CheckBox OUT_PDF
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_PDF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_PDF = value;
		}
	}

	internal virtual CheckBox OUT_DXF
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_DXF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_DXF = value;
		}
	}

	internal virtual CheckBox CheckBox6
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox6 = value;
		}
	}

	internal virtual CheckBox OUT_JPG
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_JPG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_JPG = value;
		}
	}

	internal virtual CheckBox OUT_DWG
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_DWG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_DWG = value;
		}
	}

	internal virtual CheckBox OUT_PNG
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_PNG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_PNG = value;
		}
	}

	internal virtual GroupBox Out3D_type
	{
		[DebuggerNonUserCode]
		get
		{
			return _Out3D_type;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Out3D_type = value;
		}
	}

	internal virtual CheckBox CheckBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox4 = value;
		}
	}

	internal virtual CheckBox CheckBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox3 = value;
		}
	}

	internal virtual CheckBox CheckBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox2 = value;
		}
	}

	internal virtual CheckBox CheckBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox1 = value;
		}
	}

	internal virtual CheckBox OUT_IGS
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_IGS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_IGS = value;
		}
	}

	internal virtual CheckBox CheckBox5
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox5 = value;
		}
	}

	internal virtual CheckBox OUT_STEP
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_STEP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_STEP = value;
		}
	}

	internal virtual CheckBox OUT_3DPDF
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_3DPDF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_3DPDF = value;
		}
	}

	internal virtual CheckBox CheckBox7
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox7 = value;
		}
	}

	internal virtual CheckBox OUT_JPG2
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_JPG2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_JPG2 = value;
		}
	}

	internal virtual CheckBox OUT_PNG2
	{
		[DebuggerNonUserCode]
		get
		{
			return _OUT_PNG2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OUT_PNG2 = value;
		}
	}

	internal virtual TabControl TabControl1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabControl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabControl1 = value;
		}
	}

	internal virtual ComboBox Multiplesheet_dwg
	{
		[DebuggerNonUserCode]
		get
		{
			return _Multiplesheet_dwg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Multiplesheet_dwg = value;
		}
	}

	internal virtual Label Label8
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label8 = value;
		}
	}

	internal virtual CheckBox withoutcfgname
	{
		[DebuggerNonUserCode]
		get
		{
			return _withoutcfgname;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_withoutcfgname = value;
		}
	}

	internal virtual CheckBox SetScalebyfirstview
	{
		[DebuggerNonUserCode]
		get
		{
			return _SetScalebyfirstview;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_SetScalebyfirstview = value;
		}
	}

	internal virtual CheckBox ExportAllSheetsToPaperSpace
	{
		[DebuggerNonUserCode]
		get
		{
			return _ExportAllSheetsToPaperSpace;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ExportAllSheetsToPaperSpace = value;
		}
	}

	internal virtual TextBox customname_3d
	{
		[DebuggerNonUserCode]
		get
		{
			return _customname_3d;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = name_Prefix_TextChanged;
			if (_customname_3d != null)
			{
				_customname_3d.TextChanged -= value2;
			}
			_customname_3d = value;
			if (_customname_3d != null)
			{
				_customname_3d.TextChanged += value2;
			}
		}
	}

	internal virtual TextBox customname_2d
	{
		[DebuggerNonUserCode]
		get
		{
			return _customname_2d;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = name_Prefix_TextChanged;
			if (_customname_2d != null)
			{
				_customname_2d.TextChanged -= value2;
			}
			_customname_2d = value;
			if (_customname_2d != null)
			{
				_customname_2d.TextChanged += value2;
			}
		}
	}

	internal virtual TabPage TabPage1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage1 = value;
		}
	}

	internal virtual NumericUpDown text_y
	{
		[DebuggerNonUserCode]
		get
		{
			return _text_y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_text_y = value;
		}
	}

	internal virtual Label Label13
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual NumericUpDown text_x
	{
		[DebuggerNonUserCode]
		get
		{
			return _text_x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_text_x = value;
		}
	}

	internal virtual Label Label12
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label12 = value;
		}
	}

	internal virtual TextBox watertext
	{
		[DebuggerNonUserCode]
		get
		{
			return _watertext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = name_Prefix_TextChanged;
			if (_watertext != null)
			{
				_watertext.TextChanged -= value2;
			}
			_watertext = value;
			if (_watertext != null)
			{
				_watertext.TextChanged += value2;
			}
		}
	}

	internal virtual CheckBox add_watertext
	{
		[DebuggerNonUserCode]
		get
		{
			return _add_watertext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = add_watertext_CheckedChanged;
			if (_add_watertext != null)
			{
				_add_watertext.CheckedChanged -= value2;
			}
			_add_watertext = value;
			if (_add_watertext != null)
			{
				_add_watertext.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button Button1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button1_Click;
			if (_Button1 != null)
			{
				_Button1.Click -= value2;
			}
			_Button1 = value;
			if (_Button1 != null)
			{
				_Button1.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox8 = value;
		}
	}

	internal virtual GroupBox GroupBox9
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox9 = value;
		}
	}

	internal virtual Label Label15
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label15 = value;
		}
	}

	internal virtual Label Label11
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual Button Button2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button2_Click;
			if (_Button2 != null)
			{
				_Button2.Click -= value2;
			}
			_Button2 = value;
			if (_Button2 != null)
			{
				_Button2.Click += value2;
			}
		}
	}

	internal virtual Label Label16
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label16 = value;
		}
	}

	internal virtual ComboBox text_postion
	{
		[DebuggerNonUserCode]
		get
		{
			return _text_postion;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_text_postion = value;
		}
	}

	internal virtual FontDialog FontDialog1
	{
		[DebuggerNonUserCode]
		get
		{
			return _FontDialog1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_FontDialog1 = value;
		}
	}

	internal virtual TabPage TabPage4
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage4 = value;
		}
	}

	internal virtual CheckBox custom_3d
	{
		[DebuggerNonUserCode]
		get
		{
			return _custom_3d;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = add_suffix_CheckedChanged;
			if (_custom_3d != null)
			{
				_custom_3d.CheckedChanged -= value2;
			}
			_custom_3d = value;
			if (_custom_3d != null)
			{
				_custom_3d.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox custom_2d
	{
		[DebuggerNonUserCode]
		get
		{
			return _custom_2d;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = add_Prefix_CheckedChanged;
			if (_custom_2d != null)
			{
				_custom_2d.CheckedChanged -= value2;
			}
			_custom_2d = value;
			if (_custom_2d != null)
			{
				_custom_2d.CheckedChanged += value2;
			}
		}
	}

	internal virtual Panel Panel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel1 = value;
		}
	}

	internal virtual CheckBox add_waterimg
	{
		[DebuggerNonUserCode]
		get
		{
			return _add_waterimg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = add_waterimg_CheckedChanged;
			if (_add_waterimg != null)
			{
				_add_waterimg.CheckedChanged -= value2;
			}
			_add_waterimg = value;
			if (_add_waterimg != null)
			{
				_add_waterimg.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label Label20
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label20 = value;
		}
	}

	internal virtual TextBox img_path
	{
		[DebuggerNonUserCode]
		get
		{
			return _img_path;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_img_path = value;
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox6 = value;
		}
	}

	internal virtual Label Label9
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label9 = value;
		}
	}

	internal virtual ComboBox img_postion
	{
		[DebuggerNonUserCode]
		get
		{
			return _img_postion;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_img_postion = value;
		}
	}

	internal virtual NumericUpDown img_y
	{
		[DebuggerNonUserCode]
		get
		{
			return _img_y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_img_y = value;
		}
	}

	internal virtual Label Label10
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label10 = value;
		}
	}

	internal virtual Label Label17
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label17 = value;
		}
	}

	internal virtual Label Label18
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label18 = value;
		}
	}

	internal virtual Label Label19
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label19 = value;
		}
	}

	internal virtual NumericUpDown img_x
	{
		[DebuggerNonUserCode]
		get
		{
			return _img_x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_img_x = value;
		}
	}

	internal virtual Label Label22
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label22 = value;
		}
	}

	internal virtual NumericUpDown img_transparency
	{
		[DebuggerNonUserCode]
		get
		{
			return _img_transparency;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_img_transparency = value;
		}
	}

	internal virtual Label Label21
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label21 = value;
		}
	}

	internal virtual Label Label23
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label23 = value;
		}
	}

	internal virtual NumericUpDown img_angle
	{
		[DebuggerNonUserCode]
		get
		{
			return _img_angle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_img_angle = value;
		}
	}

	internal virtual Label Label24
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label24 = value;
		}
	}

	internal virtual Button Button3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button3_Click;
			if (_Button3 != null)
			{
				_Button3.Click -= value2;
			}
			_Button3 = value;
			if (_Button3 != null)
			{
				_Button3.Click += value2;
			}
		}
	}

	internal virtual Button Button4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button4_Click;
			if (_Button4 != null)
			{
				_Button4.Click -= value2;
			}
			_Button4 = value;
			if (_Button4 != null)
			{
				_Button4.Click += value2;
			}
		}
	}

	internal virtual Button Button5
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button5_Click;
			if (_Button5 != null)
			{
				_Button5.Click -= value2;
			}
			_Button5 = value;
			if (_Button5 != null)
			{
				_Button5.Click += value2;
			}
		}
	}

	internal virtual Panel Panel2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel2 = value;
		}
	}

	internal virtual CheckBox exclude_unactive
	{
		[DebuggerNonUserCode]
		get
		{
			return _exclude_unactive;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_exclude_unactive = value;
		}
	}

	internal virtual Label Label14
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label14 = value;
		}
	}

	public virtual BackgroundWorker OutBgWorker
	{
		[DebuggerNonUserCode]
		get
		{
			return _OutBgWorker;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DoWorkEventHandler value2 = OutBgWorker_DoWork;
			RunWorkerCompletedEventHandler value3 = OutBgWorker_RunWorkerCompleted;
			ProgressChangedEventHandler value4 = OutBgWorker_ProgressChanged;
			if (_OutBgWorker != null)
			{
				_OutBgWorker.DoWork -= value2;
				_OutBgWorker.RunWorkerCompleted -= value3;
				_OutBgWorker.ProgressChanged -= value4;
			}
			_OutBgWorker = value;
			if (_OutBgWorker != null)
			{
				_OutBgWorker.DoWork += value2;
				_OutBgWorker.RunWorkerCompleted += value3;
				_OutBgWorker.ProgressChanged += value4;
			}
		}
	}

	[DebuggerNonUserCode]
	private static void __ENCAddToList(object value)
	{
		checked
		{
			lock (__ENCList)
			{
				if (__ENCList.Count == __ENCList.Capacity)
				{
					int num = 0;
					int num2 = __ENCList.Count - 1;
					int num3 = 0;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						WeakReference weakReference = __ENCList[num3];
						if (weakReference.IsAlive)
						{
							if (num3 != num)
							{
								__ENCList[num] = __ENCList[num3];
							}
							num++;
						}
						num3++;
					}
					__ENCList.RemoveRange(num, __ENCList.Count - num);
					__ENCList.Capacity = __ENCList.Count;
				}
				__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if ((disposing && components != null) ? true : false)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.OK_Button = new System.Windows.Forms.Button();
		this.TabPage5 = new System.Windows.Forms.TabPage();
		this.Label6 = new System.Windows.Forms.Label();
		this.SetScalebyfirstview = new System.Windows.Forms.CheckBox();
		this.forcurcfg = new System.Windows.Forms.CheckBox();
		this.HideSw1 = new System.Windows.Forms.CheckBox();
		this.withoutcfgname = new System.Windows.Forms.CheckBox();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.exclude_unactive = new System.Windows.Forms.CheckBox();
		this.exclude_AsWelded = new System.Windows.Forms.CheckBox();
		this.exclude_AsMachined = new System.Windows.Forms.CheckBox();
		this.exclude_SpeedPak = new System.Windows.Forms.CheckBox();
		this.exclude_IsDerived = new System.Windows.Forms.CheckBox();
		this.exclude_SheetMetal = new System.Windows.Forms.CheckBox();
		this.customname_3d = new System.Windows.Forms.TextBox();
		this.customname_2d = new System.Windows.Forms.TextBox();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.ExportAllSheetsToPaperSpace = new System.Windows.Forms.CheckBox();
		this.Multiplesheet_dwg = new System.Windows.Forms.ComboBox();
		this.outputscale = new System.Windows.Forms.CheckBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.CADline = new System.Windows.Forms.ComboBox();
		this.CADfont = new System.Windows.Forms.ComboBox();
		this.CADVer = new System.Windows.Forms.ComboBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.Image_dpi = new System.Windows.Forms.ComboBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.ImageType = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.Multiplesheet_pdf = new System.Windows.Forms.ComboBox();
		this.PDFline = new System.Windows.Forms.CheckBox();
		this.PDFfont = new System.Windows.Forms.CheckBox();
		this.PDFcolor = new System.Windows.Forms.CheckBox();
		this.Label7 = new System.Windows.Forms.Label();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.Out2D_type = new System.Windows.Forms.GroupBox();
		this.OUT_DetachedDraw = new System.Windows.Forms.CheckBox();
		this.OUT_PDF = new System.Windows.Forms.CheckBox();
		this.OUT_DXF = new System.Windows.Forms.CheckBox();
		this.CheckBox6 = new System.Windows.Forms.CheckBox();
		this.OUT_JPG = new System.Windows.Forms.CheckBox();
		this.OUT_DWG = new System.Windows.Forms.CheckBox();
		this.OUT_PNG = new System.Windows.Forms.CheckBox();
		this.Out3D_type = new System.Windows.Forms.GroupBox();
		this.CheckBox4 = new System.Windows.Forms.CheckBox();
		this.CheckBox3 = new System.Windows.Forms.CheckBox();
		this.CheckBox2 = new System.Windows.Forms.CheckBox();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.OUT_IGS = new System.Windows.Forms.CheckBox();
		this.CheckBox5 = new System.Windows.Forms.CheckBox();
		this.OUT_STEP = new System.Windows.Forms.CheckBox();
		this.OUT_3DPDF = new System.Windows.Forms.CheckBox();
		this.CheckBox7 = new System.Windows.Forms.CheckBox();
		this.OUT_JPG2 = new System.Windows.Forms.CheckBox();
		this.OUT_PNG2 = new System.Windows.Forms.CheckBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Browse = new System.Windows.Forms.Button();
		this.folder = new System.Windows.Forms.TextBox();
		this.Thisfolder = new System.Windows.Forms.RadioButton();
		this.Originalfolder = new System.Windows.Forms.RadioButton();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.GroupBox9 = new System.Windows.Forms.GroupBox();
		this.Label14 = new System.Windows.Forms.Label();
		this.custom_3d = new System.Windows.Forms.CheckBox();
		this.Button4 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.custom_2d = new System.Windows.Forms.CheckBox();
		this.TabPage4 = new System.Windows.Forms.TabPage();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.GroupBox6 = new System.Windows.Forms.GroupBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.img_postion = new System.Windows.Forms.ComboBox();
		this.img_y = new System.Windows.Forms.NumericUpDown();
		this.Label10 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.Label18 = new System.Windows.Forms.Label();
		this.Label19 = new System.Windows.Forms.Label();
		this.img_x = new System.Windows.Forms.NumericUpDown();
		this.Label23 = new System.Windows.Forms.Label();
		this.Button2 = new System.Windows.Forms.Button();
		this.img_angle = new System.Windows.Forms.NumericUpDown();
		this.img_path = new System.Windows.Forms.TextBox();
		this.Label24 = new System.Windows.Forms.Label();
		this.Label20 = new System.Windows.Forms.Label();
		this.Label22 = new System.Windows.Forms.Label();
		this.Label21 = new System.Windows.Forms.Label();
		this.img_transparency = new System.Windows.Forms.NumericUpDown();
		this.add_waterimg = new System.Windows.Forms.CheckBox();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Button5 = new System.Windows.Forms.Button();
		this.GroupBox8 = new System.Windows.Forms.GroupBox();
		this.Label16 = new System.Windows.Forms.Label();
		this.text_postion = new System.Windows.Forms.ComboBox();
		this.text_y = new System.Windows.Forms.NumericUpDown();
		this.Label15 = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.Label13 = new System.Windows.Forms.Label();
		this.text_x = new System.Windows.Forms.NumericUpDown();
		this.Button1 = new System.Windows.Forms.Button();
		this.watertext = new System.Windows.Forms.TextBox();
		this.add_watertext = new System.Windows.Forms.CheckBox();
		this.FontDialog1 = new System.Windows.Forms.FontDialog();
		this.TableLayoutPanel1.SuspendLayout();
		this.TabPage5.SuspendLayout();
		this.GroupBox5.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.TabPage2.SuspendLayout();
		this.Out2D_type.SuspendLayout();
		this.Out3D_type.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.GroupBox9.SuspendLayout();
		this.TabPage4.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.GroupBox6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.img_y).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.img_x).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.img_angle).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.img_transparency).BeginInit();
		this.Panel1.SuspendLayout();
		this.GroupBox8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.text_y).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.text_x).BeginInit();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(258, 424);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(179, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(100, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		this.OK_Button.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(11, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "Старт";
		this.TabPage5.Controls.Add(this.Label6);
		this.TabPage5.Controls.Add(this.SetScalebyfirstview);
		this.TabPage5.Controls.Add(this.forcurcfg);
		this.TabPage5.Controls.Add(this.HideSw1);
		System.Windows.Forms.TabPage tabPage = this.TabPage5;
		location = new System.Drawing.Point(4, 26);
		tabPage.Location = location;
		this.TabPage5.Name = "TabPage5";
		System.Windows.Forms.TabPage tabPage2 = this.TabPage5;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(3);
		tabPage2.Padding = padding;
		System.Windows.Forms.TabPage tabPage3 = this.TabPage5;
		size = new System.Drawing.Size(441, 390);
		tabPage3.Size = size;
		this.TabPage5.TabIndex = 2;
		this.TabPage5.Text = "Прочее";
		this.TabPage5.UseVisualStyleBackColor = true;
		this.Label6.AutoSize = true;
		this.Label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.Label6.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label = this.Label6;
		location = new System.Drawing.Point(32, 120);
		label.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label2 = this.Label6;
		size = new System.Drawing.Size(379, 34);
		label2.Size = size;
		this.Label6.TabIndex = 18;
		this.Label6.Text = "Прим.: не действует при обновлении/сохранении и преобразовании 3D-моделей в jpg, png, 3D PDF, igs, step и stl\r\n";
		this.SetScalebyfirstview.AutoSize = true;
		this.SetScalebyfirstview.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.SetScalebyfirstview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.CheckBox setScalebyfirstview = this.SetScalebyfirstview;
		location = new System.Drawing.Point(16, 16);
		setScalebyfirstview.Location = location;
		this.SetScalebyfirstview.Name = "SetScalebyfirstview";
		System.Windows.Forms.CheckBox setScalebyfirstview2 = this.SetScalebyfirstview;
		size = new System.Drawing.Size(339, 38);
		setScalebyfirstview2.Size = size;
		this.SetScalebyfirstview.TabIndex = 17;
		this.SetScalebyfirstview.Text = "Выводить по масштабу первого вида чертежа (действует, только когда масштаб всех видов\r\nне равен масштабу листа)";
		this.SetScalebyfirstview.UseVisualStyleBackColor = true;
		this.forcurcfg.AutoSize = true;
		this.forcurcfg.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.forcurcfg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.CheckBox checkBox = this.forcurcfg;
		location = new System.Drawing.Point(16, 64);
		checkBox.Location = location;
		this.forcurcfg.Name = "forcurcfg";
		System.Windows.Forms.CheckBox checkBox2 = this.forcurcfg;
		size = new System.Drawing.Size(351, 21);
		checkBox2.Size = size;
		this.forcurcfg.TabIndex = 17;
		this.forcurcfg.Text = "Выполнять по конфигурации (только для импортированных из главного окна, выбранных элементов и чертежей)";
		this.forcurcfg.UseVisualStyleBackColor = true;
		this.HideSw1.AutoSize = true;
		this.HideSw1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.HideSw1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.CheckBox hideSw = this.HideSw1;
		location = new System.Drawing.Point(16, 96);
		hideSw.Location = location;
		this.HideSw1.Name = "HideSw1";
		System.Windows.Forms.CheckBox hideSw2 = this.HideSw1;
		size = new System.Drawing.Size(178, 21);
		hideSw2.Size = size;
		this.HideSw1.TabIndex = 16;
		this.HideSw1.Text = "Скрывать интерфейс SolidWorks во время работы";
		this.HideSw1.UseVisualStyleBackColor = true;
		this.withoutcfgname.AutoSize = true;
		this.withoutcfgname.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.withoutcfgname.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.CheckBox checkBox3 = this.withoutcfgname;
		location = new System.Drawing.Point(18, 136);
		checkBox3.Location = location;
		this.withoutcfgname.Name = "withoutcfgname";
		System.Windows.Forms.CheckBox checkBox4 = this.withoutcfgname;
		size = new System.Drawing.Size(195, 21);
		checkBox4.Size = size;
		this.withoutcfgname.TabIndex = 17;
		this.withoutcfgname.Text = "Не добавлять имя конфигурации при экспорте одной конфигурации";
		this.withoutcfgname.UseVisualStyleBackColor = true;
		this.GroupBox5.Controls.Add(this.exclude_unactive);
		this.GroupBox5.Controls.Add(this.exclude_AsWelded);
		this.GroupBox5.Controls.Add(this.exclude_AsMachined);
		this.GroupBox5.Controls.Add(this.exclude_SpeedPak);
		this.GroupBox5.Controls.Add(this.exclude_IsDerived);
		this.GroupBox5.Controls.Add(this.exclude_SheetMetal);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox5;
		location = new System.Drawing.Point(12, 240);
		groupBox.Location = location;
		this.GroupBox5.Name = "GroupBox5";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox5;
		size = new System.Drawing.Size(417, 83);
		groupBox2.Size = size;
		this.GroupBox5.TabIndex = 15;
		this.GroupBox5.TabStop = false;
		this.GroupBox5.Text = "Исключить из 3D-модели следующие конфигурации";
		this.exclude_unactive.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox5 = this.exclude_unactive;
		location = new System.Drawing.Point(270, 51);
		checkBox5.Location = location;
		this.exclude_unactive.Name = "exclude_unactive";
		System.Windows.Forms.CheckBox checkBox6 = this.exclude_unactive;
		size = new System.Drawing.Size(99, 21);
		checkBox6.Size = size;
		this.exclude_unactive.TabIndex = 2;
		this.exclude_unactive.Text = "Неактивные конфигурации";
		this.exclude_unactive.UseVisualStyleBackColor = true;
		this.exclude_AsWelded.AutoSize = true;
		this.exclude_AsWelded.Checked = true;
		this.exclude_AsWelded.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox7 = this.exclude_AsWelded;
		location = new System.Drawing.Point(152, 51);
		checkBox7.Location = location;
		this.exclude_AsWelded.Name = "exclude_AsWelded";
		System.Windows.Forms.CheckBox checkBox8 = this.exclude_AsWelded;
		size = new System.Drawing.Size(105, 21);
		checkBox8.Size = size;
		this.exclude_AsWelded.TabIndex = 2;
		this.exclude_AsWelded.Text = "Сварная деталь <по сварке>";
		this.exclude_AsWelded.UseVisualStyleBackColor = true;
		this.exclude_AsMachined.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox9 = this.exclude_AsMachined;
		location = new System.Drawing.Point(19, 51);
		checkBox9.Location = location;
		this.exclude_AsMachined.Name = "exclude_AsMachined";
		System.Windows.Forms.CheckBox checkBox10 = this.exclude_AsMachined;
		size = new System.Drawing.Size(105, 21);
		checkBox10.Size = size;
		this.exclude_AsMachined.TabIndex = 2;
		this.exclude_AsMachined.Text = "Сварная деталь <по обработке>";
		this.exclude_AsMachined.UseVisualStyleBackColor = true;
		this.exclude_SpeedPak.AutoSize = true;
		this.exclude_SpeedPak.Checked = true;
		this.exclude_SpeedPak.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox11 = this.exclude_SpeedPak;
		location = new System.Drawing.Point(270, 24);
		checkBox11.Location = location;
		this.exclude_SpeedPak.Name = "exclude_SpeedPak";
		System.Windows.Forms.CheckBox checkBox12 = this.exclude_SpeedPak;
		size = new System.Drawing.Size(109, 21);
		checkBox12.Size = size;
		this.exclude_SpeedPak.TabIndex = 2;
		this.exclude_SpeedPak.Text = "Конфигурация SpeedPak";
		this.exclude_SpeedPak.UseVisualStyleBackColor = true;
		this.exclude_IsDerived.AutoSize = true;
		this.exclude_IsDerived.Checked = true;
		this.exclude_IsDerived.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox13 = this.exclude_IsDerived;
		location = new System.Drawing.Point(152, 24);
		checkBox13.Location = location;
		this.exclude_IsDerived.Name = "exclude_IsDerived";
		System.Windows.Forms.CheckBox checkBox14 = this.exclude_IsDerived;
		size = new System.Drawing.Size(75, 21);
		checkBox14.Size = size;
		this.exclude_IsDerived.TabIndex = 2;
		this.exclude_IsDerived.Text = "Производная конфигурация";
		this.exclude_IsDerived.UseVisualStyleBackColor = true;
		this.exclude_SheetMetal.AutoSize = true;
		this.exclude_SheetMetal.Checked = true;
		this.exclude_SheetMetal.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox15 = this.exclude_SheetMetal;
		location = new System.Drawing.Point(19, 24);
		checkBox15.Location = location;
		this.exclude_SheetMetal.Name = "exclude_SheetMetal";
		System.Windows.Forms.CheckBox checkBox16 = this.exclude_SheetMetal;
		size = new System.Drawing.Size(99, 21);
		checkBox16.Size = size;
		this.exclude_SheetMetal.TabIndex = 2;
		this.exclude_SheetMetal.Text = "Конфигурация развёртки листового металла";
		this.exclude_SheetMetal.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox = this.customname_3d;
		location = new System.Drawing.Point(32, 104);
		textBox.Location = location;
		this.customname_3d.Name = "customname_3d";
		System.Windows.Forms.TextBox textBox2 = this.customname_3d;
		size = new System.Drawing.Size(304, 23);
		textBox2.Size = size;
		this.customname_3d.TabIndex = 21;
		System.Windows.Forms.TextBox textBox3 = this.customname_2d;
		location = new System.Drawing.Point(32, 48);
		textBox3.Location = location;
		this.customname_2d.Name = "customname_2d";
		System.Windows.Forms.TextBox textBox4 = this.customname_2d;
		size = new System.Drawing.Size(304, 23);
		textBox4.Size = size;
		this.customname_2d.TabIndex = 19;
		this.TabPage3.Controls.Add(this.GroupBox3);
		this.TabPage3.Controls.Add(this.GroupBox2);
		this.TabPage3.Controls.Add(this.GroupBox4);
		System.Windows.Forms.TabPage tabPage4 = this.TabPage3;
		location = new System.Drawing.Point(4, 26);
		tabPage4.Location = location;
		this.TabPage3.Name = "TabPage3";
		System.Windows.Forms.TabPage tabPage5 = this.TabPage3;
		padding = new System.Windows.Forms.Padding(3);
		tabPage5.Padding = padding;
		System.Windows.Forms.TabPage tabPage6 = this.TabPage3;
		size = new System.Drawing.Size(441, 390);
		tabPage6.Size = size;
		this.TabPage3.TabIndex = 1;
		this.TabPage3.Text = "Параметры вывода";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.GroupBox3.Controls.Add(this.ExportAllSheetsToPaperSpace);
		this.GroupBox3.Controls.Add(this.Multiplesheet_dwg);
		this.GroupBox3.Controls.Add(this.outputscale);
		this.GroupBox3.Controls.Add(this.Label3);
		this.GroupBox3.Controls.Add(this.Label2);
		this.GroupBox3.Controls.Add(this.Label8);
		this.GroupBox3.Controls.Add(this.Label1);
		this.GroupBox3.Controls.Add(this.CADline);
		this.GroupBox3.Controls.Add(this.CADfont);
		this.GroupBox3.Controls.Add(this.CADVer);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox3;
		location = new System.Drawing.Point(12, 12);
		groupBox3.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox3;
		size = new System.Drawing.Size(417, 156);
		groupBox4.Size = size;
		this.GroupBox3.TabIndex = 3;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Параметры вывода DXF/DWG";
		this.ExportAllSheetsToPaperSpace.AutoSize = true;
		this.ExportAllSheetsToPaperSpace.Checked = true;
		this.ExportAllSheetsToPaperSpace.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox exportAllSheetsToPaperSpace = this.ExportAllSheetsToPaperSpace;
		location = new System.Drawing.Point(16, 128);
		exportAllSheetsToPaperSpace.Location = location;
		this.ExportAllSheetsToPaperSpace.Name = "ExportAllSheetsToPaperSpace";
		System.Windows.Forms.CheckBox exportAllSheetsToPaperSpace2 = this.ExportAllSheetsToPaperSpace;
		size = new System.Drawing.Size(195, 21);
		exportAllSheetsToPaperSpace2.Size = size;
		this.ExportAllSheetsToPaperSpace.TabIndex = 4;
		this.ExportAllSheetsToPaperSpace.Text = "Выводить все листы чертежа в пространство листа";
		this.ExportAllSheetsToPaperSpace.UseVisualStyleBackColor = true;
		this.Multiplesheet_dwg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Multiplesheet_dwg.FormattingEnabled = true;
		this.Multiplesheet_dwg.Items.AddRange(new object[4] { "Вывести все листы в один файл", "Вывести каждый лист в отдельный файл", "Выводить только первую страницу", "Выводить только активный лист" });
		System.Windows.Forms.ComboBox multiplesheet_dwg = this.Multiplesheet_dwg;
		location = new System.Drawing.Point(112, 92);
		multiplesheet_dwg.Location = location;
		this.Multiplesheet_dwg.Name = "Multiplesheet_dwg";
		System.Windows.Forms.ComboBox multiplesheet_dwg2 = this.Multiplesheet_dwg;
		size = new System.Drawing.Size(232, 25);
		multiplesheet_dwg2.Size = size;
		this.Multiplesheet_dwg.TabIndex = 3;
		this.outputscale.AutoSize = true;
		this.outputscale.Checked = true;
		this.outputscale.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox17 = this.outputscale;
		location = new System.Drawing.Point(16, 61);
		checkBox17.Location = location;
		this.outputscale.Name = "outputscale";
		System.Windows.Forms.CheckBox checkBox18 = this.outputscale;
		size = new System.Drawing.Size(89, 21);
		checkBox18.Size = size;
		this.outputscale.TabIndex = 2;
		this.outputscale.Text = "Вывод в масштабе 1:1";
		this.outputscale.UseVisualStyleBackColor = true;
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label3;
		location = new System.Drawing.Point(171, 63);
		label3.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label4 = this.Label3;
		size = new System.Drawing.Size(68, 17);
		label4.Size = size;
		this.Label3.TabIndex = 1;
		this.Label3.Text = "Стиль линий:";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label2;
		location = new System.Drawing.Point(195, 33);
		label5.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label6 = this.Label2;
		size = new System.Drawing.Size(44, 17);
		label6.Size = size;
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Шрифт:";
		this.Label8.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label8;
		location = new System.Drawing.Point(16, 96);
		label7.Location = location;
		this.Label8.Name = "Label8";
		System.Windows.Forms.Label label8 = this.Label8;
		size = new System.Drawing.Size(92, 17);
		label8.Size = size;
		this.Label8.TabIndex = 1;
		this.Label8.Text = "Многолистовой чертёж:";
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label9 = this.Label1;
		location = new System.Drawing.Point(16, 33);
		label9.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label10 = this.Label1;
		size = new System.Drawing.Size(44, 17);
		label10.Size = size;
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Версия:";
		this.CADline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.CADline.FormattingEnabled = true;
		this.CADline.Items.AddRange(new object[2] { "Пользовательский стиль SolidWorks", "Стандартный стиль AutoCAD" });
		System.Windows.Forms.ComboBox cADline = this.CADline;
		location = new System.Drawing.Point(242, 59);
		cADline.Location = location;
		this.CADline.Name = "CADline";
		System.Windows.Forms.ComboBox cADline2 = this.CADline;
		size = new System.Drawing.Size(162, 25);
		cADline2.Size = size;
		this.CADline.TabIndex = 0;
		this.CADfont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.CADfont.FormattingEnabled = true;
		this.CADfont.Items.AddRange(new object[2] { "TrueType", "Только для стандарта AutoCAD" });
		System.Windows.Forms.ComboBox cADfont = this.CADfont;
		location = new System.Drawing.Point(242, 29);
		cADfont.Location = location;
		this.CADfont.Name = "CADfont";
		System.Windows.Forms.ComboBox cADfont2 = this.CADfont;
		size = new System.Drawing.Size(162, 25);
		cADfont2.Size = size;
		this.CADfont.TabIndex = 0;
		this.CADVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.CADVer.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.CADVer.FormattingEnabled = true;
		this.CADVer.Items.AddRange(new object[8] { "R12", "R13", "R14", "R2000-2002", "R2004-2006", "R2007-2009", "R2010", "R2013" });
		System.Windows.Forms.ComboBox cADVer = this.CADVer;
		location = new System.Drawing.Point(63, 29);
		cADVer.Location = location;
		this.CADVer.Name = "CADVer";
		System.Windows.Forms.ComboBox cADVer2 = this.CADVer;
		size = new System.Drawing.Size(97, 25);
		cADVer2.Size = size;
		this.CADVer.TabIndex = 0;
		this.GroupBox2.Controls.Add(this.RadioButton2);
		this.GroupBox2.Controls.Add(this.RadioButton1);
		this.GroupBox2.Controls.Add(this.Image_dpi);
		this.GroupBox2.Controls.Add(this.Label5);
		this.GroupBox2.Controls.Add(this.ImageType);
		this.GroupBox2.Controls.Add(this.Label4);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox2;
		location = new System.Drawing.Point(12, 296);
		groupBox5.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox2;
		size = new System.Drawing.Size(417, 90);
		groupBox6.Size = size;
		this.GroupBox2.TabIndex = 4;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Параметры вывода JPG/PNG";
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton2;
		location = new System.Drawing.Point(242, 57);
		radioButton.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton2;
		size = new System.Drawing.Size(74, 21);
		radioButton2.Size = size;
		this.RadioButton2.TabIndex = 3;
		this.RadioButton2.Text = "Захват печати";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton1;
		location = new System.Drawing.Point(242, 25);
		radioButton3.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton1;
		size = new System.Drawing.Size(74, 21);
		radioButton4.Size = size;
		this.RadioButton1.TabIndex = 3;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Захват экрана";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.Image_dpi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Image_dpi.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.Image_dpi.FormattingEnabled = true;
		this.Image_dpi.Items.AddRange(new object[15]
		{
			"50", "72", "100", "150", "200", "240", "300", "360", "400", "600",
			"720", "800", "1200", "1440", "2880"
		});
		System.Windows.Forms.ComboBox image_dpi = this.Image_dpi;
		location = new System.Drawing.Point(88, 55);
		image_dpi.Location = location;
		this.Image_dpi.Name = "Image_dpi";
		System.Windows.Forms.ComboBox image_dpi2 = this.Image_dpi;
		size = new System.Drawing.Size(97, 25);
		image_dpi2.Size = size;
		this.Image_dpi.TabIndex = 0;
		this.Label5.AutoSize = true;
		System.Windows.Forms.Label label11 = this.Label5;
		location = new System.Drawing.Point(16, 59);
		label11.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label12 = this.Label5;
		size = new System.Drawing.Size(40, 17);
		label12.Size = size;
		this.Label5.TabIndex = 1;
		this.Label5.Text = "DPI：";
		this.ImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ImageType.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.ImageType.FormattingEnabled = true;
		this.ImageType.Items.AddRange(new object[3] { "Чёрно-белый (двухуровневый)", "RGB (полный цвет)", "Оттенки серого" });
		System.Windows.Forms.ComboBox imageType = this.ImageType;
		location = new System.Drawing.Point(88, 23);
		imageType.Location = location;
		this.ImageType.Name = "ImageType";
		System.Windows.Forms.ComboBox imageType2 = this.ImageType;
		size = new System.Drawing.Size(97, 25);
		imageType2.Size = size;
		this.ImageType.TabIndex = 0;
		this.Label4.AutoSize = true;
		System.Windows.Forms.Label label13 = this.Label4;
		location = new System.Drawing.Point(16, 27);
		label13.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label14 = this.Label4;
		size = new System.Drawing.Size(68, 17);
		label14.Size = size;
		this.Label4.TabIndex = 1;
		this.Label4.Text = "Тип изображения:";
		this.GroupBox4.Controls.Add(this.Multiplesheet_pdf);
		this.GroupBox4.Controls.Add(this.PDFline);
		this.GroupBox4.Controls.Add(this.PDFfont);
		this.GroupBox4.Controls.Add(this.PDFcolor);
		this.GroupBox4.Controls.Add(this.Label7);
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox4;
		location = new System.Drawing.Point(12, 176);
		groupBox7.Location = location;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox4;
		size = new System.Drawing.Size(417, 112);
		groupBox8.Size = size;
		this.GroupBox4.TabIndex = 4;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Параметры вывода PDF";
		this.Multiplesheet_pdf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Multiplesheet_pdf.FormattingEnabled = true;
		this.Multiplesheet_pdf.Items.AddRange(new object[4] { "Вывести все листы в один файл", "Вывести каждый лист в отдельный файл", "Выводить только первую страницу", "Выводить только активный лист" });
		System.Windows.Forms.ComboBox multiplesheet_pdf = this.Multiplesheet_pdf;
		location = new System.Drawing.Point(112, 76);
		multiplesheet_pdf.Location = location;
		this.Multiplesheet_pdf.Name = "Multiplesheet_pdf";
		System.Windows.Forms.ComboBox multiplesheet_pdf2 = this.Multiplesheet_pdf;
		size = new System.Drawing.Size(232, 25);
		multiplesheet_pdf2.Size = size;
		this.Multiplesheet_pdf.TabIndex = 3;
		this.PDFline.AutoSize = true;
		this.PDFline.Checked = true;
		this.PDFline.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox pDFline = this.PDFline;
		location = new System.Drawing.Point(16, 50);
		pDFline.Location = location;
		this.PDFline.Name = "PDFline";
		System.Windows.Forms.CheckBox pDFline2 = this.PDFline;
		size = new System.Drawing.Size(251, 21);
		pDFline2.Size = size;
		this.PDFline.TabIndex = 2;
		this.PDFline.Text = "Использовать толщину линий принтера (Файл, Печать, Толщина линий)";
		this.PDFline.UseVisualStyleBackColor = true;
		this.PDFfont.AutoSize = true;
		this.PDFfont.Checked = true;
		this.PDFfont.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox pDFfont = this.PDFfont;
		location = new System.Drawing.Point(152, 24);
		pDFfont.Location = location;
		this.PDFfont.Name = "PDFfont";
		System.Windows.Forms.CheckBox pDFfont2 = this.PDFfont;
		size = new System.Drawing.Size(75, 21);
		pDFfont2.Size = size;
		this.PDFfont.TabIndex = 2;
		this.PDFfont.Text = "Внедрить шрифты";
		this.PDFfont.UseVisualStyleBackColor = true;
		this.PDFcolor.AutoSize = true;
		this.PDFcolor.Checked = true;
		this.PDFcolor.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox pDFcolor = this.PDFcolor;
		location = new System.Drawing.Point(16, 24);
		pDFcolor.Location = location;
		this.PDFcolor.Name = "PDFcolor";
		System.Windows.Forms.CheckBox pDFcolor2 = this.PDFcolor;
		size = new System.Drawing.Size(87, 21);
		pDFcolor2.Size = size;
		this.PDFcolor.TabIndex = 2;
		this.PDFcolor.Text = "Цветной вывод";
		this.PDFcolor.UseVisualStyleBackColor = true;
		this.Label7.AutoSize = true;
		System.Windows.Forms.Label label15 = this.Label7;
		location = new System.Drawing.Point(16, 80);
		label15.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label16 = this.Label7;
		size = new System.Drawing.Size(92, 17);
		label16.Size = size;
		this.Label7.TabIndex = 1;
		this.Label7.Text = "Многолистовой чертёж:";
		this.TabPage2.Controls.Add(this.Out2D_type);
		this.TabPage2.Controls.Add(this.Out3D_type);
		this.TabPage2.Controls.Add(this.GroupBox5);
		System.Windows.Forms.TabPage tabPage7 = this.TabPage2;
		location = new System.Drawing.Point(4, 26);
		tabPage7.Location = location;
		this.TabPage2.Name = "TabPage2";
		System.Windows.Forms.TabPage tabPage8 = this.TabPage2;
		padding = new System.Windows.Forms.Padding(3);
		tabPage8.Padding = padding;
		System.Windows.Forms.TabPage tabPage9 = this.TabPage2;
		size = new System.Drawing.Size(441, 390);
		tabPage9.Size = size;
		this.TabPage2.TabIndex = 0;
		this.TabPage2.Text = "Формат вывода";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.Out2D_type.Controls.Add(this.OUT_DetachedDraw);
		this.Out2D_type.Controls.Add(this.OUT_PDF);
		this.Out2D_type.Controls.Add(this.OUT_DXF);
		this.Out2D_type.Controls.Add(this.CheckBox6);
		this.Out2D_type.Controls.Add(this.OUT_JPG);
		this.Out2D_type.Controls.Add(this.OUT_DWG);
		this.Out2D_type.Controls.Add(this.OUT_PNG);
		this.Out2D_type.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		System.Windows.Forms.GroupBox out2D_type = this.Out2D_type;
		location = new System.Drawing.Point(12, 8);
		out2D_type.Location = location;
		this.Out2D_type.Name = "Out2D_type";
		System.Windows.Forms.GroupBox out2D_type2 = this.Out2D_type;
		size = new System.Drawing.Size(417, 80);
		out2D_type2.Size = size;
		this.Out2D_type.TabIndex = 2;
		this.Out2D_type.TabStop = false;
		this.Out2D_type.Text = "Преобразовать 2D-чертёж в";
		this.OUT_DetachedDraw.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_DetachedDraw = this.OUT_DetachedDraw;
		location = new System.Drawing.Point(229, 27);
		oUT_DetachedDraw.Location = location;
		this.OUT_DetachedDraw.Name = "OUT_DetachedDraw";
		System.Windows.Forms.CheckBox oUT_DetachedDraw2 = this.OUT_DetachedDraw;
		size = new System.Drawing.Size(146, 21);
		oUT_DetachedDraw2.Size = size;
		this.OUT_DetachedDraw.TabIndex = 2;
		this.OUT_DetachedDraw.Tag = ".SLDDRW";
		this.OUT_DetachedDraw.Text = "Раздельные чертежи (slddrw)";
		this.OUT_DetachedDraw.UseVisualStyleBackColor = true;
		this.OUT_PDF.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_PDF = this.OUT_PDF;
		location = new System.Drawing.Point(159, 27);
		oUT_PDF.Location = location;
		this.OUT_PDF.Name = "OUT_PDF";
		System.Windows.Forms.CheckBox oUT_PDF2 = this.OUT_PDF;
		size = new System.Drawing.Size(49, 21);
		oUT_PDF2.Size = size;
		this.OUT_PDF.TabIndex = 2;
		this.OUT_PDF.Tag = ".PDF";
		this.OUT_PDF.Text = "PDF";
		this.OUT_PDF.UseVisualStyleBackColor = true;
		this.OUT_DXF.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_DXF = this.OUT_DXF;
		location = new System.Drawing.Point(89, 27);
		oUT_DXF.Location = location;
		this.OUT_DXF.Name = "OUT_DXF";
		System.Windows.Forms.CheckBox oUT_DXF2 = this.OUT_DXF;
		size = new System.Drawing.Size(50, 21);
		oUT_DXF2.Size = size;
		this.OUT_DXF.TabIndex = 1;
		this.OUT_DXF.Tag = ".DXF";
		this.OUT_DXF.Text = "DXF";
		this.OUT_DXF.UseVisualStyleBackColor = true;
		this.CheckBox6.AutoSize = true;
		this.CheckBox6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.CheckBox checkBox19 = this.CheckBox6;
		location = new System.Drawing.Point(159, 52);
		checkBox19.Location = location;
		this.CheckBox6.Name = "CheckBox6";
		System.Windows.Forms.CheckBox checkBox20 = this.CheckBox6;
		size = new System.Drawing.Size(85, 21);
		checkBox20.Size = size;
		this.CheckBox6.TabIndex = 1;
		this.CheckBox6.Tag = ".save";
		this.CheckBox6.Text = "Обновить и сохранить";
		this.CheckBox6.UseMnemonic = false;
		this.CheckBox6.UseVisualStyleBackColor = true;
		this.OUT_JPG.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_JPG = this.OUT_JPG;
		location = new System.Drawing.Point(89, 52);
		oUT_JPG.Location = location;
		this.OUT_JPG.Name = "OUT_JPG";
		System.Windows.Forms.CheckBox oUT_JPG2 = this.OUT_JPG;
		size = new System.Drawing.Size(48, 21);
		oUT_JPG2.Size = size;
		this.OUT_JPG.TabIndex = 1;
		this.OUT_JPG.Tag = ".JPG";
		this.OUT_JPG.Text = "JPG";
		this.OUT_JPG.UseVisualStyleBackColor = true;
		this.OUT_DWG.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_DWG = this.OUT_DWG;
		location = new System.Drawing.Point(19, 27);
		oUT_DWG.Location = location;
		this.OUT_DWG.Name = "OUT_DWG";
		System.Windows.Forms.CheckBox oUT_DWG2 = this.OUT_DWG;
		size = new System.Drawing.Size(57, 21);
		oUT_DWG2.Size = size;
		this.OUT_DWG.TabIndex = 0;
		this.OUT_DWG.Tag = ".DWG";
		this.OUT_DWG.Text = "DWG";
		this.OUT_DWG.UseVisualStyleBackColor = true;
		this.OUT_PNG.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_PNG = this.OUT_PNG;
		location = new System.Drawing.Point(19, 52);
		oUT_PNG.Location = location;
		this.OUT_PNG.Name = "OUT_PNG";
		System.Windows.Forms.CheckBox oUT_PNG2 = this.OUT_PNG;
		size = new System.Drawing.Size(53, 21);
		oUT_PNG2.Size = size;
		this.OUT_PNG.TabIndex = 0;
		this.OUT_PNG.Tag = ".PNG";
		this.OUT_PNG.Text = "PNG";
		this.OUT_PNG.UseVisualStyleBackColor = true;
		this.Out3D_type.Controls.Add(this.CheckBox4);
		this.Out3D_type.Controls.Add(this.CheckBox3);
		this.Out3D_type.Controls.Add(this.CheckBox2);
		this.Out3D_type.Controls.Add(this.CheckBox1);
		this.Out3D_type.Controls.Add(this.OUT_IGS);
		this.Out3D_type.Controls.Add(this.CheckBox5);
		this.Out3D_type.Controls.Add(this.OUT_STEP);
		this.Out3D_type.Controls.Add(this.OUT_3DPDF);
		this.Out3D_type.Controls.Add(this.CheckBox7);
		this.Out3D_type.Controls.Add(this.OUT_JPG2);
		this.Out3D_type.Controls.Add(this.OUT_PNG2);
		this.Out3D_type.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		System.Windows.Forms.GroupBox out3D_type = this.Out3D_type;
		location = new System.Drawing.Point(12, 96);
		out3D_type.Location = location;
		this.Out3D_type.Name = "Out3D_type";
		System.Windows.Forms.GroupBox out3D_type2 = this.Out3D_type;
		size = new System.Drawing.Size(417, 137);
		out3D_type2.Size = size;
		this.Out3D_type.TabIndex = 2;
		this.Out3D_type.TabStop = false;
		this.Out3D_type.Text = "Преобразовать 3D-модель в";
		this.CheckBox4.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox21 = this.CheckBox4;
		location = new System.Drawing.Point(157, 55);
		checkBox21.Location = location;
		this.CheckBox4.Name = "CheckBox4";
		System.Windows.Forms.CheckBox checkBox22 = this.CheckBox4;
		size = new System.Drawing.Size(108, 21);
		checkBox22.Size = size;
		this.CheckBox4.TabIndex = 2;
		this.CheckBox4.Tag = ".x_b";
		this.CheckBox4.Text = "Parasolid(x_b)";
		this.CheckBox4.UseVisualStyleBackColor = true;
		this.CheckBox3.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox23 = this.CheckBox3;
		location = new System.Drawing.Point(19, 55);
		checkBox23.Location = location;
		this.CheckBox3.Name = "CheckBox3";
		System.Windows.Forms.CheckBox checkBox24 = this.CheckBox3;
		size = new System.Drawing.Size(104, 21);
		checkBox24.Size = size;
		this.CheckBox3.TabIndex = 2;
		this.CheckBox3.Tag = ".x_t";
		this.CheckBox3.Text = "Parasolid(x_t)";
		this.CheckBox3.UseVisualStyleBackColor = true;
		this.CheckBox2.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox25 = this.CheckBox2;
		location = new System.Drawing.Point(19, 82);
		checkBox25.Location = location;
		this.CheckBox2.Name = "CheckBox2";
		System.Windows.Forms.CheckBox checkBox26 = this.CheckBox2;
		size = new System.Drawing.Size(82, 21);
		checkBox26.Size = size;
		this.CheckBox2.TabIndex = 2;
		this.CheckBox2.Tag = ".sat";
		this.CheckBox2.Text = "ACIS(.sat)";
		this.CheckBox2.UseVisualStyleBackColor = true;
		this.CheckBox1.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox27 = this.CheckBox1;
		location = new System.Drawing.Point(299, 55);
		checkBox27.Location = location;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox28 = this.CheckBox1;
		size = new System.Drawing.Size(71, 21);
		checkBox28.Size = size;
		this.CheckBox1.TabIndex = 2;
		this.CheckBox1.Tag = ".stl";
		this.CheckBox1.Text = "STL(.stl)";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.OUT_IGS.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_IGS = this.OUT_IGS;
		location = new System.Drawing.Point(299, 27);
		oUT_IGS.Location = location;
		this.OUT_IGS.Name = "OUT_IGS";
		System.Windows.Forms.CheckBox oUT_IGS2 = this.OUT_IGS;
		size = new System.Drawing.Size(82, 21);
		oUT_IGS2.Size = size;
		this.OUT_IGS.TabIndex = 2;
		this.OUT_IGS.Tag = ".igs";
		this.OUT_IGS.Text = "IGES(.igs)";
		this.OUT_IGS.UseVisualStyleBackColor = true;
		this.CheckBox5.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox29 = this.CheckBox5;
		location = new System.Drawing.Point(157, 27);
		checkBox29.Location = location;
		this.CheckBox5.Name = "CheckBox5";
		System.Windows.Forms.CheckBox checkBox30 = this.CheckBox5;
		size = new System.Drawing.Size(131, 21);
		checkBox30.Size = size;
		this.CheckBox5.TabIndex = 2;
		this.CheckBox5.Tag = ".STEP";
		this.CheckBox5.Text = "STEP AP214(.step)";
		this.CheckBox5.UseVisualStyleBackColor = true;
		this.OUT_STEP.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_STEP = this.OUT_STEP;
		location = new System.Drawing.Point(19, 27);
		oUT_STEP.Location = location;
		this.OUT_STEP.Name = "OUT_STEP";
		System.Windows.Forms.CheckBox oUT_STEP2 = this.OUT_STEP;
		size = new System.Drawing.Size(131, 21);
		oUT_STEP2.Size = size;
		this.OUT_STEP.TabIndex = 2;
		this.OUT_STEP.Tag = ".step";
		this.OUT_STEP.Text = "STEP AP203(.step)";
		this.OUT_STEP.UseVisualStyleBackColor = true;
		this.OUT_3DPDF.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_3DPDF = this.OUT_3DPDF;
		location = new System.Drawing.Point(157, 82);
		oUT_3DPDF.Location = location;
		this.OUT_3DPDF.Name = "OUT_3DPDF";
		System.Windows.Forms.CheckBox oUT_3DPDF2 = this.OUT_3DPDF;
		size = new System.Drawing.Size(100, 21);
		oUT_3DPDF2.Size = size;
		this.OUT_3DPDF.TabIndex = 2;
		this.OUT_3DPDF.Tag = ".pdf";
		this.OUT_3DPDF.Text = "3D PDF(.pdf)";
		this.OUT_3DPDF.UseVisualStyleBackColor = true;
		this.CheckBox7.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox31 = this.CheckBox7;
		location = new System.Drawing.Point(299, 108);
		checkBox31.Location = location;
		this.CheckBox7.Name = "CheckBox7";
		System.Windows.Forms.CheckBox checkBox32 = this.CheckBox7;
		size = new System.Drawing.Size(85, 21);
		checkBox32.Size = size;
		this.CheckBox7.TabIndex = 1;
		this.CheckBox7.Tag = ".save";
		this.CheckBox7.Text = "Обновить и сохранить";
		this.CheckBox7.UseMnemonic = false;
		this.CheckBox7.UseVisualStyleBackColor = true;
		this.OUT_JPG2.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_JPG3 = this.OUT_JPG2;
		location = new System.Drawing.Point(299, 82);
		oUT_JPG3.Location = location;
		this.OUT_JPG2.Name = "OUT_JPG2";
		System.Windows.Forms.CheckBox oUT_JPG4 = this.OUT_JPG2;
		size = new System.Drawing.Size(85, 21);
		oUT_JPG4.Size = size;
		this.OUT_JPG2.TabIndex = 1;
		this.OUT_JPG2.Tag = ".jpg";
		this.OUT_JPG2.Text = "JEPG(.jpg)";
		this.OUT_JPG2.UseVisualStyleBackColor = true;
		this.OUT_PNG2.AutoSize = true;
		System.Windows.Forms.CheckBox oUT_PNG3 = this.OUT_PNG2;
		location = new System.Drawing.Point(19, 108);
		oUT_PNG3.Location = location;
		this.OUT_PNG2.Name = "OUT_PNG2";
		System.Windows.Forms.CheckBox oUT_PNG4 = this.OUT_PNG2;
		size = new System.Drawing.Size(219, 21);
		oUT_PNG4.Size = size;
		this.OUT_PNG2.TabIndex = 0;
		this.OUT_PNG2.Tag = ".png";
		this.OUT_PNG2.Text = "Portable Network Graphics(.png)";
		this.OUT_PNG2.UseVisualStyleBackColor = true;
		this.GroupBox1.Controls.Add(this.Browse);
		this.GroupBox1.Controls.Add(this.folder);
		this.GroupBox1.Controls.Add(this.Thisfolder);
		this.GroupBox1.Controls.Add(this.Originalfolder);
		this.GroupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		System.Windows.Forms.GroupBox groupBox9 = this.GroupBox1;
		location = new System.Drawing.Point(12, 8);
		groupBox9.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox10 = this.GroupBox1;
		size = new System.Drawing.Size(417, 112);
		groupBox10.Size = size;
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Папка вывода";
		System.Windows.Forms.Button browse = this.Browse;
		location = new System.Drawing.Point(349, 66);
		browse.Location = location;
		this.Browse.Name = "Browse";
		System.Windows.Forms.Button browse2 = this.Browse;
		size = new System.Drawing.Size(55, 24);
		browse2.Size = size;
		this.Browse.TabIndex = 3;
		this.Browse.Text = "Обзор";
		this.Browse.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox5 = this.folder;
		location = new System.Drawing.Point(35, 67);
		textBox5.Location = location;
		this.folder.Name = "folder";
		System.Windows.Forms.TextBox textBox6 = this.folder;
		size = new System.Drawing.Size(305, 23);
		textBox6.Size = size;
		this.folder.TabIndex = 2;
		this.Thisfolder.AutoSize = true;
		System.Windows.Forms.RadioButton thisfolder = this.Thisfolder;
		location = new System.Drawing.Point(18, 44);
		thisfolder.Location = location;
		this.Thisfolder.Name = "Thisfolder";
		System.Windows.Forms.RadioButton thisfolder2 = this.Thisfolder;
		size = new System.Drawing.Size(74, 21);
		thisfolder2.Size = size;
		this.Thisfolder.TabIndex = 1;
		this.Thisfolder.Text = "Эта папка";
		this.Thisfolder.UseVisualStyleBackColor = true;
		this.Originalfolder.AutoSize = true;
		this.Originalfolder.Checked = true;
		System.Windows.Forms.RadioButton originalfolder = this.Originalfolder;
		location = new System.Drawing.Point(18, 22);
		originalfolder.Location = location;
		this.Originalfolder.Name = "Originalfolder";
		System.Windows.Forms.RadioButton originalfolder2 = this.Originalfolder;
		size = new System.Drawing.Size(110, 21);
		originalfolder2.Size = size;
		this.Originalfolder.TabIndex = 0;
		this.Originalfolder.TabStop = true;
		this.Originalfolder.Text = "Та же папка, что и у оригинала";
		this.Originalfolder.UseVisualStyleBackColor = true;
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Controls.Add(this.TabPage4);
		this.TabControl1.Controls.Add(this.TabPage5);
		this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
		this.TabControl1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.TabControl tabControl = this.TabControl1;
		size = new System.Drawing.Size(48, 22);
		tabControl.ItemSize = size;
		System.Windows.Forms.TabControl tabControl2 = this.TabControl1;
		location = new System.Drawing.Point(0, 0);
		tabControl2.Location = location;
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		System.Windows.Forms.TabControl tabControl3 = this.TabControl1;
		size = new System.Drawing.Size(449, 420);
		tabControl3.Size = size;
		this.TabControl1.TabIndex = 5;
		this.TabPage1.Controls.Add(this.GroupBox1);
		this.TabPage1.Controls.Add(this.GroupBox9);
		System.Windows.Forms.TabPage tabPage10 = this.TabPage1;
		location = new System.Drawing.Point(4, 26);
		tabPage10.Location = location;
		this.TabPage1.Name = "TabPage1";
		System.Windows.Forms.TabPage tabPage11 = this.TabPage1;
		padding = new System.Windows.Forms.Padding(3);
		tabPage11.Padding = padding;
		System.Windows.Forms.TabPage tabPage12 = this.TabPage1;
		size = new System.Drawing.Size(441, 390);
		tabPage12.Size = size;
		this.TabPage1.TabIndex = 3;
		this.TabPage1.Text = "Путь вывода";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.GroupBox9.Controls.Add(this.Label14);
		this.GroupBox9.Controls.Add(this.custom_3d);
		this.GroupBox9.Controls.Add(this.Button4);
		this.GroupBox9.Controls.Add(this.Button3);
		this.GroupBox9.Controls.Add(this.custom_2d);
		this.GroupBox9.Controls.Add(this.withoutcfgname);
		this.GroupBox9.Controls.Add(this.customname_3d);
		this.GroupBox9.Controls.Add(this.customname_2d);
		System.Windows.Forms.GroupBox groupBox11 = this.GroupBox9;
		location = new System.Drawing.Point(12, 144);
		groupBox11.Location = location;
		this.GroupBox9.Name = "GroupBox9";
		System.Windows.Forms.GroupBox groupBox12 = this.GroupBox9;
		size = new System.Drawing.Size(417, 232);
		groupBox12.Size = size;
		this.GroupBox9.TabIndex = 25;
		this.GroupBox9.TabStop = false;
		this.GroupBox9.Text = "Настройка имени выходного файла";
		this.Label14.AutoSize = true;
		this.Label14.ForeColor = System.Drawing.Color.Green;
		System.Windows.Forms.Label label17 = this.Label14;
		location = new System.Drawing.Point(16, 168);
		label17.Location = location;
		this.Label14.Name = "Label14";
		System.Windows.Forms.Label label18 = this.Label14;
		size = new System.Drawing.Size(266, 34);
		label18.Size = size;
		this.Label14.TabIndex = 29;
		this.Label14.Text = "Рекомендуемые разделители: дефис «-», подчёркивание «_» и пробел.\r\nПри пустом значении свойства разделитель скрывается автоматически.";
		this.custom_3d.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox33 = this.custom_3d;
		location = new System.Drawing.Point(18, 80);
		checkBox33.Location = location;
		this.custom_3d.Name = "custom_3d";
		System.Windows.Forms.CheckBox checkBox34 = this.custom_3d;
		size = new System.Drawing.Size(151, 21);
		checkBox34.Size = size;
		this.custom_3d.TabIndex = 28;
		this.custom_3d.Text = "Пользовательское имя файла 3D-преобразования:";
		this.custom_3d.UseVisualStyleBackColor = true;
		System.Windows.Forms.Button button = this.Button4;
		location = new System.Drawing.Point(344, 103);
		button.Location = location;
		this.Button4.Name = "Button4";
		System.Windows.Forms.Button button2 = this.Button4;
		size = new System.Drawing.Size(64, 24);
		button2.Size = size;
		this.Button4.TabIndex = 3;
		this.Button4.Text = "Вставить...";
		this.Button4.UseVisualStyleBackColor = true;
		System.Windows.Forms.Button button3 = this.Button3;
		location = new System.Drawing.Point(344, 47);
		button3.Location = location;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button4 = this.Button3;
		size = new System.Drawing.Size(64, 24);
		button4.Size = size;
		this.Button3.TabIndex = 3;
		this.Button3.Text = "Вставить...";
		this.Button3.UseVisualStyleBackColor = true;
		this.custom_2d.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox35 = this.custom_2d;
		location = new System.Drawing.Point(18, 24);
		checkBox35.Location = location;
		this.custom_2d.Name = "custom_2d";
		System.Windows.Forms.CheckBox checkBox36 = this.custom_2d;
		size = new System.Drawing.Size(151, 21);
		checkBox36.Size = size;
		this.custom_2d.TabIndex = 27;
		this.custom_2d.Text = "Пользовательское имя файла 2D-преобразования:";
		this.custom_2d.UseVisualStyleBackColor = true;
		this.TabPage4.Controls.Add(this.Panel2);
		this.TabPage4.Controls.Add(this.add_waterimg);
		this.TabPage4.Controls.Add(this.Panel1);
		this.TabPage4.Controls.Add(this.add_watertext);
		System.Windows.Forms.TabPage tabPage13 = this.TabPage4;
		location = new System.Drawing.Point(4, 26);
		tabPage13.Location = location;
		this.TabPage4.Name = "TabPage4";
		System.Windows.Forms.TabPage tabPage14 = this.TabPage4;
		padding = new System.Windows.Forms.Padding(3);
		tabPage14.Padding = padding;
		System.Windows.Forms.TabPage tabPage15 = this.TabPage4;
		size = new System.Drawing.Size(441, 390);
		tabPage15.Size = size;
		this.TabPage4.TabIndex = 4;
		this.TabPage4.Text = "Водяной знак PDF";
		this.TabPage4.UseVisualStyleBackColor = true;
		this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel2.Controls.Add(this.GroupBox6);
		this.Panel2.Controls.Add(this.Label23);
		this.Panel2.Controls.Add(this.Button2);
		this.Panel2.Controls.Add(this.img_angle);
		this.Panel2.Controls.Add(this.img_path);
		this.Panel2.Controls.Add(this.Label24);
		this.Panel2.Controls.Add(this.Label20);
		this.Panel2.Controls.Add(this.Label22);
		this.Panel2.Controls.Add(this.Label21);
		this.Panel2.Controls.Add(this.img_transparency);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.Panel panel = this.Panel2;
		location = new System.Drawing.Point(3, 211);
		panel.Location = location;
		this.Panel2.Name = "Panel2";
		System.Windows.Forms.Panel panel2 = this.Panel2;
		size = new System.Drawing.Size(435, 171);
		panel2.Size = size;
		this.Panel2.TabIndex = 29;
		this.GroupBox6.Controls.Add(this.Label9);
		this.GroupBox6.Controls.Add(this.img_postion);
		this.GroupBox6.Controls.Add(this.img_y);
		this.GroupBox6.Controls.Add(this.Label10);
		this.GroupBox6.Controls.Add(this.Label17);
		this.GroupBox6.Controls.Add(this.Label18);
		this.GroupBox6.Controls.Add(this.Label19);
		this.GroupBox6.Controls.Add(this.img_x);
		System.Windows.Forms.GroupBox groupBox13 = this.GroupBox6;
		location = new System.Drawing.Point(8, 96);
		groupBox13.Location = location;
		this.GroupBox6.Name = "GroupBox6";
		System.Windows.Forms.GroupBox groupBox14 = this.GroupBox6;
		size = new System.Drawing.Size(417, 64);
		groupBox14.Size = size;
		this.GroupBox6.TabIndex = 29;
		this.GroupBox6.TabStop = false;
		this.GroupBox6.Text = "Положение изображения";
		this.Label9.AutoSize = true;
		System.Windows.Forms.Label label19 = this.Label9;
		location = new System.Drawing.Point(8, 32);
		label19.Location = location;
		this.Label9.Name = "Label9";
		System.Windows.Forms.Label label20 = this.Label9;
		size = new System.Drawing.Size(35, 17);
		label20.Size = size;
		this.Label9.TabIndex = 28;
		this.Label9.Text = "Начало координат:";
		this.img_postion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.img_postion.FormattingEnabled = true;
		this.img_postion.Items.AddRange(new object[4] { "Нижний левый угол", "Верхний левый угол", "Верхний правый угол", "Нижний правый угол" });
		System.Windows.Forms.ComboBox comboBox = this.img_postion;
		location = new System.Drawing.Point(48, 28);
		comboBox.Location = location;
		this.img_postion.Name = "img_postion";
		System.Windows.Forms.ComboBox comboBox2 = this.img_postion;
		size = new System.Drawing.Size(88, 25);
		comboBox2.Size = size;
		this.img_postion.TabIndex = 28;
		System.Windows.Forms.NumericUpDown numericUpDown = this.img_y;
		location = new System.Drawing.Point(312, 29);
		numericUpDown.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown2 = this.img_y;
		decimal maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		numericUpDown2.Maximum = maximum;
		this.img_y.Name = "img_y";
		System.Windows.Forms.NumericUpDown numericUpDown3 = this.img_y;
		size = new System.Drawing.Size(56, 23);
		numericUpDown3.Size = size;
		this.img_y.TabIndex = 22;
		maximum = (this.img_y.Value = new decimal(new int[4] { 65, 0, 0, 0 }));
		this.Label10.AutoSize = true;
		System.Windows.Forms.Label label21 = this.Label10;
		location = new System.Drawing.Point(368, 32);
		label21.Location = location;
		this.Label10.Name = "Label10";
		System.Windows.Forms.Label label22 = this.Label10;
		size = new System.Drawing.Size(30, 17);
		label22.Size = size;
		this.Label10.TabIndex = 21;
		this.Label10.Text = "mm";
		this.Label17.AutoSize = true;
		System.Windows.Forms.Label label23 = this.Label17;
		location = new System.Drawing.Point(248, 32);
		label23.Location = location;
		this.Label17.Name = "Label17";
		System.Windows.Forms.Label label24 = this.Label17;
		size = new System.Drawing.Size(30, 17);
		label24.Size = size;
		this.Label17.TabIndex = 21;
		this.Label17.Text = "mm";
		this.Label18.AutoSize = true;
		System.Windows.Forms.Label label25 = this.Label18;
		location = new System.Drawing.Point(168, 32);
		label25.Location = location;
		this.Label18.Name = "Label18";
		System.Windows.Forms.Label label26 = this.Label18;
		size = new System.Drawing.Size(19, 17);
		label26.Size = size;
		this.Label18.TabIndex = 21;
		this.Label18.Text = "X:";
		this.Label19.AutoSize = true;
		System.Windows.Forms.Label label27 = this.Label19;
		location = new System.Drawing.Point(288, 32);
		label27.Location = location;
		this.Label19.Name = "Label19";
		System.Windows.Forms.Label label28 = this.Label19;
		size = new System.Drawing.Size(18, 17);
		label28.Size = size;
		this.Label19.TabIndex = 23;
		this.Label19.Text = "Y:";
		System.Windows.Forms.NumericUpDown numericUpDown4 = this.img_x;
		location = new System.Drawing.Point(192, 29);
		numericUpDown4.Location = location;
		maximum = (this.img_x.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 }));
		this.img_x.Name = "img_x";
		System.Windows.Forms.NumericUpDown numericUpDown5 = this.img_x;
		size = new System.Drawing.Size(56, 23);
		numericUpDown5.Size = size;
		this.img_x.TabIndex = 2;
		maximum = (this.img_x.Value = new decimal(new int[4] { 15, 0, 0, 0 }));
		this.Label23.AutoSize = true;
		System.Windows.Forms.Label label29 = this.Label23;
		location = new System.Drawing.Point(264, 67);
		label29.Location = location;
		this.Label23.Name = "Label23";
		System.Windows.Forms.Label label30 = this.Label23;
		size = new System.Drawing.Size(13, 17);
		label30.Size = size;
		this.Label23.TabIndex = 38;
		this.Label23.Text = "°";
		this.Button2.AutoSize = true;
		System.Windows.Forms.Button button5 = this.Button2;
		location = new System.Drawing.Point(360, 28);
		button5.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button6 = this.Button2;
		size = new System.Drawing.Size(63, 27);
		button6.Size = size;
		this.Button2.TabIndex = 26;
		this.Button2.Text = "Обзор..";
		this.Button2.UseVisualStyleBackColor = true;
		System.Windows.Forms.NumericUpDown numericUpDown6 = this.img_angle;
		location = new System.Drawing.Point(208, 64);
		numericUpDown6.Location = location;
		maximum = (this.img_angle.Maximum = new decimal(new int[4] { 360, 0, 0, 0 }));
		this.img_angle.Name = "img_angle";
		System.Windows.Forms.NumericUpDown numericUpDown7 = this.img_angle;
		size = new System.Drawing.Size(56, 23);
		numericUpDown7.Size = size;
		this.img_angle.TabIndex = 37;
		System.Windows.Forms.TextBox textBox7 = this.img_path;
		location = new System.Drawing.Point(8, 30);
		textBox7.Location = location;
		this.img_path.Name = "img_path";
		this.img_path.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox8 = this.img_path;
		size = new System.Drawing.Size(344, 23);
		textBox8.Size = size;
		this.img_path.TabIndex = 30;
		this.Label24.AutoSize = true;
		System.Windows.Forms.Label label31 = this.Label24;
		location = new System.Drawing.Point(168, 67);
		label31.Location = location;
		this.Label24.Name = "Label24";
		System.Windows.Forms.Label label32 = this.Label24;
		size = new System.Drawing.Size(35, 17);
		label32.Size = size;
		this.Label24.TabIndex = 36;
		this.Label24.Text = "Угол:";
		this.Label20.AutoSize = true;
		System.Windows.Forms.Label label33 = this.Label20;
		location = new System.Drawing.Point(8, 8);
		label33.Location = location;
		this.Label20.Name = "Label20";
		System.Windows.Forms.Label label34 = this.Label20;
		size = new System.Drawing.Size(68, 17);
		label34.Size = size;
		this.Label20.TabIndex = 31;
		this.Label20.Text = "Путь к изображению:";
		this.Label22.AutoSize = true;
		System.Windows.Forms.Label label35 = this.Label22;
		location = new System.Drawing.Point(118, 67);
		label35.Location = location;
		this.Label22.Name = "Label22";
		System.Windows.Forms.Label label36 = this.Label22;
		size = new System.Drawing.Size(19, 17);
		label36.Size = size;
		this.Label22.TabIndex = 35;
		this.Label22.Text = "%";
		this.Label21.AutoSize = true;
		System.Windows.Forms.Label label37 = this.Label21;
		location = new System.Drawing.Point(8, 67);
		label37.Location = location;
		this.Label21.Name = "Label21";
		System.Windows.Forms.Label label38 = this.Label21;
		size = new System.Drawing.Size(47, 17);
		label38.Size = size;
		this.Label21.TabIndex = 33;
		this.Label21.Text = "Прозрачность:";
		System.Windows.Forms.NumericUpDown numericUpDown8 = this.img_transparency;
		location = new System.Drawing.Point(62, 64);
		numericUpDown8.Location = location;
		this.img_transparency.Name = "img_transparency";
		System.Windows.Forms.NumericUpDown numericUpDown9 = this.img_transparency;
		size = new System.Drawing.Size(56, 23);
		numericUpDown9.Size = size;
		this.img_transparency.TabIndex = 34;
		maximum = (this.img_transparency.Value = new decimal(new int[4] { 50, 0, 0, 0 }));
		this.add_waterimg.AutoSize = true;
		this.add_waterimg.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.CheckBox checkBox37 = this.add_waterimg;
		location = new System.Drawing.Point(3, 187);
		checkBox37.Location = location;
		this.add_waterimg.Name = "add_waterimg";
		System.Windows.Forms.CheckBox checkBox38 = this.add_waterimg;
		padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
		checkBox38.Padding = padding;
		System.Windows.Forms.CheckBox checkBox39 = this.add_waterimg;
		size = new System.Drawing.Size(435, 24);
		checkBox39.Size = size;
		this.add_waterimg.TabIndex = 28;
		this.add_waterimg.Text = "Добавлять графический водяной знак в PDF после конвертации чертежа";
		this.add_waterimg.UseVisualStyleBackColor = true;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Button5);
		this.Panel1.Controls.Add(this.GroupBox8);
		this.Panel1.Controls.Add(this.Button1);
		this.Panel1.Controls.Add(this.watertext);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.Panel panel3 = this.Panel1;
		location = new System.Drawing.Point(3, 27);
		panel3.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel4 = this.Panel1;
		size = new System.Drawing.Size(435, 160);
		panel4.Size = size;
		this.Panel1.TabIndex = 28;
		System.Windows.Forms.Button button7 = this.Button5;
		location = new System.Drawing.Point(340, 48);
		button7.Location = location;
		this.Button5.Name = "Button5";
		System.Windows.Forms.Button button8 = this.Button5;
		size = new System.Drawing.Size(64, 24);
		button8.Size = size;
		this.Button5.TabIndex = 39;
		this.Button5.Text = "Вставить...";
		this.Button5.UseVisualStyleBackColor = true;
		this.GroupBox8.Controls.Add(this.Label16);
		this.GroupBox8.Controls.Add(this.text_postion);
		this.GroupBox8.Controls.Add(this.text_y);
		this.GroupBox8.Controls.Add(this.Label15);
		this.GroupBox8.Controls.Add(this.Label11);
		this.GroupBox8.Controls.Add(this.Label12);
		this.GroupBox8.Controls.Add(this.Label13);
		this.GroupBox8.Controls.Add(this.text_x);
		System.Windows.Forms.GroupBox groupBox15 = this.GroupBox8;
		location = new System.Drawing.Point(8, 88);
		groupBox15.Location = location;
		this.GroupBox8.Name = "GroupBox8";
		System.Windows.Forms.GroupBox groupBox16 = this.GroupBox8;
		size = new System.Drawing.Size(417, 64);
		groupBox16.Size = size;
		this.GroupBox8.TabIndex = 27;
		this.GroupBox8.TabStop = false;
		this.GroupBox8.Text = "Положение текста";
		this.Label16.AutoSize = true;
		System.Windows.Forms.Label label39 = this.Label16;
		location = new System.Drawing.Point(8, 32);
		label39.Location = location;
		this.Label16.Name = "Label16";
		System.Windows.Forms.Label label40 = this.Label16;
		size = new System.Drawing.Size(35, 17);
		label40.Size = size;
		this.Label16.TabIndex = 28;
		this.Label16.Text = "Начало координат:";
		this.text_postion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.text_postion.FormattingEnabled = true;
		this.text_postion.Items.AddRange(new object[4] { "Нижний левый угол", "Верхний левый угол", "Верхний правый угол", "Нижний правый угол" });
		System.Windows.Forms.ComboBox comboBox3 = this.text_postion;
		location = new System.Drawing.Point(48, 28);
		comboBox3.Location = location;
		this.text_postion.Name = "text_postion";
		System.Windows.Forms.ComboBox comboBox4 = this.text_postion;
		size = new System.Drawing.Size(88, 25);
		comboBox4.Size = size;
		this.text_postion.TabIndex = 28;
		System.Windows.Forms.NumericUpDown numericUpDown10 = this.text_y;
		location = new System.Drawing.Point(312, 29);
		numericUpDown10.Location = location;
		maximum = (this.text_y.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 }));
		this.text_y.Name = "text_y";
		System.Windows.Forms.NumericUpDown numericUpDown11 = this.text_y;
		size = new System.Drawing.Size(56, 23);
		numericUpDown11.Size = size;
		this.text_y.TabIndex = 22;
		maximum = (this.text_y.Value = new decimal(new int[4] { 65, 0, 0, 0 }));
		this.Label15.AutoSize = true;
		System.Windows.Forms.Label label41 = this.Label15;
		location = new System.Drawing.Point(368, 32);
		label41.Location = location;
		this.Label15.Name = "Label15";
		System.Windows.Forms.Label label42 = this.Label15;
		size = new System.Drawing.Size(30, 17);
		label42.Size = size;
		this.Label15.TabIndex = 21;
		this.Label15.Text = "mm";
		this.Label11.AutoSize = true;
		System.Windows.Forms.Label label43 = this.Label11;
		location = new System.Drawing.Point(248, 32);
		label43.Location = location;
		this.Label11.Name = "Label11";
		System.Windows.Forms.Label label44 = this.Label11;
		size = new System.Drawing.Size(30, 17);
		label44.Size = size;
		this.Label11.TabIndex = 21;
		this.Label11.Text = "mm";
		this.Label12.AutoSize = true;
		System.Windows.Forms.Label label45 = this.Label12;
		location = new System.Drawing.Point(168, 32);
		label45.Location = location;
		this.Label12.Name = "Label12";
		System.Windows.Forms.Label label46 = this.Label12;
		size = new System.Drawing.Size(19, 17);
		label46.Size = size;
		this.Label12.TabIndex = 21;
		this.Label12.Text = "X:";
		this.Label13.AutoSize = true;
		System.Windows.Forms.Label label47 = this.Label13;
		location = new System.Drawing.Point(288, 32);
		label47.Location = location;
		this.Label13.Name = "Label13";
		System.Windows.Forms.Label label48 = this.Label13;
		size = new System.Drawing.Size(18, 17);
		label48.Size = size;
		this.Label13.TabIndex = 23;
		this.Label13.Text = "Y:";
		System.Windows.Forms.NumericUpDown numericUpDown12 = this.text_x;
		location = new System.Drawing.Point(192, 29);
		numericUpDown12.Location = location;
		maximum = (this.text_x.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 }));
		this.text_x.Name = "text_x";
		System.Windows.Forms.NumericUpDown numericUpDown13 = this.text_x;
		size = new System.Drawing.Size(56, 23);
		numericUpDown13.Size = size;
		this.text_x.TabIndex = 2;
		maximum = (this.text_x.Value = new decimal(new int[4] { 15, 0, 0, 0 }));
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button9 = this.Button1;
		location = new System.Drawing.Point(340, 8);
		button9.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button10 = this.Button1;
		size = new System.Drawing.Size(80, 27);
		button10.Size = size;
		this.Button1.TabIndex = 26;
		this.Button1.Text = "Шрифт";
		this.Button1.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox9 = this.watertext;
		location = new System.Drawing.Point(8, 8);
		textBox9.Location = location;
		this.watertext.Multiline = true;
		this.watertext.Name = "watertext";
		this.watertext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox10 = this.watertext;
		size = new System.Drawing.Size(324, 72);
		textBox10.Size = size;
		this.watertext.TabIndex = 23;
		this.add_watertext.AutoSize = true;
		this.add_watertext.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.CheckBox checkBox40 = this.add_watertext;
		location = new System.Drawing.Point(3, 3);
		checkBox40.Location = location;
		this.add_watertext.Name = "add_watertext";
		System.Windows.Forms.CheckBox checkBox41 = this.add_watertext;
		padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
		checkBox41.Padding = padding;
		System.Windows.Forms.CheckBox checkBox42 = this.add_watertext;
		size = new System.Drawing.Size(435, 24);
		checkBox42.Size = size;
		this.add_watertext.TabIndex = 25;
		this.add_watertext.Text = "Добавлять текстовый водяной знак в PDF после конвертации чертежа";
		this.add_watertext.UseVisualStyleBackColor = true;
		this.FontDialog1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FontDialog1.ShowColor = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(449, 461);
		this.ClientSize = size;
		this.Controls.Add(this.TabControl1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmOutputoptions";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Параметры";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.TabPage5.ResumeLayout(false);
		this.TabPage5.PerformLayout();
		this.GroupBox5.ResumeLayout(false);
		this.GroupBox5.PerformLayout();
		this.TabPage3.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.TabPage2.ResumeLayout(false);
		this.Out2D_type.ResumeLayout(false);
		this.Out2D_type.PerformLayout();
		this.Out3D_type.ResumeLayout(false);
		this.Out3D_type.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.GroupBox9.ResumeLayout(false);
		this.GroupBox9.PerformLayout();
		this.TabPage4.ResumeLayout(false);
		this.TabPage4.PerformLayout();
		this.Panel2.ResumeLayout(false);
		this.Panel2.PerformLayout();
		this.GroupBox6.ResumeLayout(false);
		this.GroupBox6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.img_y).EndInit();
		((System.ComponentModel.ISupportInitialize)this.img_x).EndInit();
		((System.ComponentModel.ISupportInitialize)this.img_angle).EndInit();
		((System.ComponentModel.ISupportInitialize)this.img_transparency).EndInit();
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.GroupBox8.ResumeLayout(false);
		this.GroupBox8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.text_y).EndInit();
		((System.ComponentModel.ISupportInitialize)this.text_x).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmOutputoptions()
	{
		base.FormClosed += FrmOutputoptions_FormClosed;
		base.Load += FrmOutputoptions_Load;
		__ENCAddToList(this);
		OutBgWorker = new BackgroundWorker();
		CallInProgress = false;
		er = false;
		filelist = new List<string>();
		cfglist = new List<string>();
		statuslist = new List<string>();
		indexlist = new List<int>();
		menu1 = new ContextMenuStrip();
		menu2 = new ContextMenuStrip();
		dpixRatio = 1.0;
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		TabControl tabControl = TabControl1;
		Size itemSize = checked(new Size((int)Math.Round(60.0 * dpixRatio), (int)Math.Round(22.0 * dpixRatio)));
		tabControl.ItemSize = itemSize;
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		bool flag = false;
		checked
		{
			try
			{
				Savecfg();
				FrmOutputlist frmOutputlist = (FrmOutputlist)Owner;
				if (frmOutputlist.ListView1.Items.Count == 0)
				{
					MessageBox.Show("В списке нет файлов", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Close();
					return;
				}
				if (Thisfolder.Checked)
				{
					if (Operators.CompareString(folder.Text, "", TextCompare: false) == 0)
					{
						MessageBox.Show("Укажите путь вывода", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					if (!Directory.Exists(folder.Text))
					{
						if (MessageBox.Show(this, "Путь \"" + folder.Text + "\" не существует, создать?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
						{
							return;
						}
						DirectoryInfo directoryInfo = Directory.CreateDirectory(folder.Text);
					}
				}
				bool flag2 = false;
				foreach (Control control3 in Out2D_type.Controls)
				{
					if (((CheckBox)control3).Checked)
					{
						flag2 = true;
					}
				}
				foreach (Control control4 in Out3D_type.Controls)
				{
					if (((CheckBox)control4).Checked)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					MessageBox.Show("Укажите формат вывода", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				Hide();
				ListViewVR listView = frmOutputlist.ListView1;
				int num = listView.Items.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (Operators.CompareString(listView.Items[num2].SubItems[4].Text, "✔", TextCompare: false) == 0)
					{
						MyProject.Forms.FrmAsk.ShowDialog(this);
						if (MyProject.Forms.FrmAsk.DialogResult == DialogResult.Yes)
						{
							flag = true;
						}
						else if (MyProject.Forms.FrmAsk.DialogResult == DialogResult.No)
						{
							flag = false;
						}
						break;
					}
					num2++;
				}
				listView = null;
				filelist.Clear();
				cfglist.Clear();
				statuslist.Clear();
				indexlist.Clear();
				ListViewVR listView2 = frmOutputlist.ListView1;
				int num5 = listView2.Items.Count - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					if (!flag)
					{
						listView2.Items[num6].SubItems[4].Text = " ";
					}
					indexlist.Add(num6);
					filelist.Add(listView2.Items[num6].SubItems[2].Text);
					cfglist.Add(listView2.Items[num6].SubItems[3].Text);
					statuslist.Add(listView2.Items[num6].SubItems[4].Text);
					num6++;
				}
				listView2 = null;
				if (filelist.Count == 0)
				{
					MessageBox.Show("Нет элементов для преобразования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				code.dgvdatalist.Clear();
				int num8 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num4 = num8;
					if (num10 > num4)
					{
						break;
					}
					code.dgvdata item = new code.dgvdata
					{
						pathname = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num9].Value),
						cfgname = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Cfg.Index, num9].Value),
						Quantity = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Quantity.Index, num9].Value)
					};
					code.dgvdatalist.Add(item);
					num9++;
				}
				outset();
				frmOutputlist.ToolStripStatusLabel1.Text = "Осталось " + Conversions.ToString(frmOutputlist.ListView1.Items.Count) + " файлов";
				frmOutputlist.ListView1.MultiSelect = false;
				frmOutputlist.ListView1.Items[indexlist[0]].Selected = true;
				frmOutputlist.ToolStripProgressBar1.Maximum = frmOutputlist.ListView1.Items.Count;
				frmOutputlist.ToolStripProgressBar1.Visible = true;
				frmOutputlist.addfiles.Enabled = false;
				frmOutputlist.clearall.Enabled = false;
				frmOutputlist.clearsel.Enabled = false;
				frmOutputlist.openinsw.Enabled = false;
				code.EnablePreview = false;
				frmOutputlist.Switch(1);
				OutBgWorker.WorkerSupportsCancellation = true;
				OutBgWorker.WorkerReportsProgress = true;
				OutBgWorker.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void OutBgWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		MyiTextSharp myiTextSharp = new MyiTextSharp();
		er = false;
		checked
		{
			try
			{
				if (!code.RunSW())
				{
					return;
				}
				object obj = null;
				int num = Convert.ToInt32(text_x.Value);
				int num2 = Convert.ToInt32(text_y.Value);
				int selectedIndex = text_postion.SelectedIndex;
				int num3 = Convert.ToInt32(img_x.Value);
				int num4 = Convert.ToInt32(img_y.Value);
				int selectedIndex2 = img_postion.SelectedIndex;
				string modelPicName = img_path.Text;
				float grayFill = Convert.ToSingle(img_transparency.Value);
				float degrees = Convert.ToSingle(img_angle.Value);
				int millisecondsTimeout = Conversions.ToInteger(Interaction.IIf(code.TMode, 2000, 5));
				int num5 = filelist.Count - 1;
				int num6 = 0;
				bool flag2 = default(bool);
				_Closure_0024__11 closure_0024__ = default(_Closure_0024__11);
				_Closure_0024__12 closure_0024__2 = default(_Closure_0024__12);
				while (true)
				{
					int num7 = num6;
					int num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					if (OutBgWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					if (Operators.CompareString(statuslist[num6], "✔", TextCompare: false) != 0)
					{
						Thread.Sleep(millisecondsTimeout);
						FilePathName = filelist[num6];
						FilePath = code.SplitStr(FilePathName);
						string text4 = code.SplitStr(FilePathName, 1);
						if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
						{
							swFileTYpe = 1;
						}
						else if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
						{
							swFileTYpe = 2;
						}
						else
						{
							if (!FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
							{
								goto IL_3278;
							}
							swFileTYpe = 3;
						}
						if (Thisfolder.Checked)
						{
							SavePath = folder.Text;
						}
						else
						{
							SavePath = FilePath;
						}
						SavePath = Directory.CreateDirectory(SavePath).FullName;
						if (Operators.CompareString(Strings.Right(SavePath, 1), "\\", TextCompare: false) != 0)
						{
							SavePath += "\\";
						}
						else
						{
							SavePath = SavePath;
						}
						CConfigMng.Config.OutSaveFolder = SavePath;
						List<string> list = new List<string>();
						List<string> list2 = new List<string>();
						foreach (Control control3 in Out3D_type.Controls)
						{
							string item = Conversions.ToString(((CheckBox)control3).Tag);
							if (((CheckBox)control3).Checked)
							{
								list2.Add(item);
							}
						}
						foreach (Control control4 in Out2D_type.Controls)
						{
							string item2 = Conversions.ToString(((CheckBox)control4).Tag);
							if (((CheckBox)control4).Checked)
							{
								list.Add(item2);
							}
						}
						string item3 = ".save";
						if (list.Contains(item3))
						{
							list.Remove(item3);
							list.Insert(0, item3);
						}
						if (list2.Contains(item3))
						{
							list2.Remove(item3);
							list2.Insert(0, item3);
						}
						if (((swFileTYpe == 3) & (list.Count < 1)) | ((swFileTYpe == 1) & (list2.Count < 1)) | ((swFileTYpe == 2) & (list2.Count < 1)))
						{
							goto IL_3278;
						}
						bool flag = false;
						if (list2.Exists(_Lambda_0024__18))
						{
							flag = true;
						}
						if (flag)
						{
							if (!code.RunSW())
							{
								return;
							}
						}
						else if (!code.RunSW(CConfigMng.Config.HideSw1))
						{
							return;
						}
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
						{
							obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetExportFileData", new object[1] { 1 }, null, null, null));
						}
						flag2 = false;
						bool flag3 = false;
						object obj2 = null;
						if (File.Exists(FilePathName))
						{
							NewLateBinding.LateCall(code.swApp, null, "SetCurrentWorkingDirectory", new object[1] { code.SplitStr(FilePathName) }, null, null, null, IgnoreReturn: true);
							object swApp = code.swApp;
							object[] array = new object[6] { FilePathName, swFileTYpe, 1, "", longstatus, longwarnings };
							object[] arguments = array;
							bool[] array2 = new bool[6] { true, true, false, false, true, true };
							object obj3 = NewLateBinding.LateGet(swApp, null, "OpenDoc6", arguments, null, null, array2);
							if (array2[0])
							{
								FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
							}
							if (array2[1])
							{
								swFileTYpe = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
							}
							if (array2[4])
							{
								longstatus = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[4]), typeof(int));
							}
							if (array2[5])
							{
								longwarnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[5]), typeof(int));
							}
							obj2 = RuntimeHelpers.GetObjectValue(obj3);
							if (flag)
							{
								object swApp2 = code.swApp;
								object[] array3 = new object[3] { FilePathName, true, Errors };
								object[] arguments2 = array3;
								array2 = new bool[3] { true, false, true };
								NewLateBinding.LateCall(swApp2, null, "ActivateDoc2", arguments2, null, null, array2, IgnoreReturn: true);
								if (array2[0])
								{
									FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
								}
								if (array2[2])
								{
									Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
								}
							}
						}
						object obj4 = null;
						if (obj2 != null)
						{
							obj4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, null, "Extension", new object[0], null, null, null));
						}
						if (obj4 != null)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj2);
							string text5 = "";
							if (swFileTYpe == 3)
							{
								NewLateBinding.LateSet(obj, null, "ExportAs3D", new object[1] { false }, null, null);
								object obj5 = null;
								obj5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetSheetNames", new object[0], null, null, null));
								int num9 = 1;
								string text6 = "";
								text6 = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "GetCurrentSheet", new object[0], null, null, null), null, "GetName", new object[0], null, null, null));
								List<string> list3 = new List<string>();
								int num10 = Information.UBound((Array)obj5);
								int num11 = 0;
								while (true)
								{
									int num12 = num11;
									num8 = num10;
									if (num12 > num8)
									{
										break;
									}
									object[] array4 = new object[1] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(obj5, new object[1] { num11 }, null)) };
									object[] arguments3 = array4;
									bool[] array2 = new bool[1] { true };
									NewLateBinding.LateCall(objectValue, null, "ActivateSheet", arguments3, null, null, array2, IgnoreReturn: true);
									if (array2[0])
									{
										NewLateBinding.LateIndexSetComplex(obj5, new object[2]
										{
											num11,
											RuntimeHelpers.GetObjectValue(array4[0])
										}, null, OptimisticSet: true, RValueBase: false);
									}
									object[] array = new object[1] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(obj5, new object[1] { num11 }, null)) };
									object[] arguments4 = array;
									array2 = new bool[1] { true };
									object obj6 = NewLateBinding.LateGet(objectValue, null, "Sheet", arguments4, null, null, array2);
									if (array2[0])
									{
										NewLateBinding.LateIndexSetComplex(obj5, new object[2]
										{
											num11,
											RuntimeHelpers.GetObjectValue(array[0])
										}, null, OptimisticSet: true, RValueBase: false);
									}
									object objectValue2 = RuntimeHelpers.GetObjectValue(obj6);
									if (SetScalebyfirstview.Checked || (forcurcfg.Checked ? true : false))
									{
										List<string> modelcfgfromdrw = code.GetModelcfgfromdrw(RuntimeHelpers.GetObjectValue(objectValue2), @bool: true);
										if ((forcurcfg.Checked && Operators.CompareString(cfglist[num6], "", TextCompare: false) != 0) ? true : false)
										{
											string[] array5 = Strings.Split(cfglist[num6], "|\n");
											if ((cfglist.Count >= 1 && modelcfgfromdrw.Count > 0) ? true : false)
											{
												closure_0024__ = new _Closure_0024__11(closure_0024__);
												closure_0024__._0024VB_0024Local_cfg = modelcfgfromdrw[0];
												if (!Array.Exists(array5, closure_0024__._Lambda_0024__19))
												{
													goto IL_0a71;
												}
											}
										}
									}
									list3.Add(Conversions.ToString(NewLateBinding.LateIndexGet(obj5, new object[1] { num11 }, null)));
									goto IL_0a71;
									IL_0a71:
									num11++;
								}
								int num13 = list3.Count - 1;
								int num14 = 0;
								while (true)
								{
									int num15 = num14;
									num8 = num13;
									if (num15 > num8)
									{
										break;
									}
									object[] array6 = new object[1];
									object[] array7 = array6;
									List<string> list4 = list3;
									List<string> list5 = list4;
									int index = num14;
									array7[0] = list5[index];
									object[] array4 = array6;
									object[] arguments5 = array4;
									bool[] array2 = new bool[1] { true };
									object obj7 = NewLateBinding.LateGet(objectValue, null, "Sheet", arguments5, null, null, array2);
									if (array2[0])
									{
										list4[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
									}
									object objectValue3 = RuntimeHelpers.GetObjectValue(obj7);
									string str = "";
									if (list3.Count > 1)
									{
										str = "(" + list3[num14] + ")";
										code.DeleteInvalidChars(ref str);
									}
									array6 = new object[1];
									object[] array8 = array6;
									list4 = list3;
									List<string> list6 = list4;
									index = num14;
									array8[0] = list6[index];
									array4 = array6;
									object[] arguments6 = array4;
									array2 = new bool[1] { true };
									NewLateBinding.LateCall(objectValue, null, "ActivateSheet", arguments6, null, null, array2, IgnoreReturn: true);
									if (array2[0])
									{
										list4[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
									}
									NewLateBinding.LateCall(obj2, null, "ViewZoomtofit2", new object[0], null, null, null, IgnoreReturn: true);
									string text7 = Conversions.ToString(Interaction.IIf(add_watertext.Checked, watertext.Text.Trim(), ""));
									string text8 = Conversions.ToString(Interaction.IIf(custom_2d.Checked, customname_2d.Text.Trim(), ""));
									if (text8.Length > 0 || text7.Length > 0)
									{
										Dictionary<string, string> dictionary = code.Getpropfromsheet(RuntimeHelpers.GetObjectValue(code.swApp), RuntimeHelpers.GetObjectValue(objectValue3));
										dictionary.Add("<ИмяФайла>", text4);
										MatchCollection matchCollection = Regex.Matches(text7, "(\\$).*?(\\$)");
										int num16 = matchCollection.Count - 1;
										int num17 = 0;
										while (true)
										{
											int num18 = num17;
											num8 = num16;
											if (num18 > num8)
											{
												break;
											}
											string value = matchCollection[num17].Value;
											if (!dictionary.ContainsKey(value))
											{
												dictionary.Add(value, "");
											}
											num17++;
										}
										matchCollection = Regex.Matches(text7, "(?=\\<).*?(?>\\>)");
										int num19 = matchCollection.Count - 1;
										int num20 = 0;
										while (true)
										{
											int num21 = num20;
											num8 = num19;
											if (num21 > num8)
											{
												break;
											}
											string value2 = matchCollection[num20].Value;
											if (!dictionary.ContainsKey(value2))
											{
												dictionary.Add(value2, "");
											}
											num20++;
										}
										matchCollection = Regex.Matches(customname_2d.Text, "(\\$).*?(\\$)");
										int num22 = matchCollection.Count - 1;
										int num23 = 0;
										while (true)
										{
											int num24 = num23;
											num8 = num22;
											if (num24 > num8)
											{
												break;
											}
											string value3 = matchCollection[num23].Value;
											if (!dictionary.ContainsKey(value3))
											{
												dictionary.Add(value3, "");
											}
											num23++;
										}
										matchCollection = Regex.Matches(customname_2d.Text, "(?=\\<).*?(?>\\>)");
										int num25 = matchCollection.Count - 1;
										int num26 = 0;
										while (true)
										{
											int num27 = num26;
											num8 = num25;
											if (num27 > num8)
											{
												break;
											}
											string value4 = matchCollection[num26].Value;
											if (!dictionary.ContainsKey(value4))
											{
												dictionary.Add(value4, "");
											}
											num26++;
										}
										int num28 = dictionary.Count - 1;
										int num29 = 0;
										while (true)
										{
											int num30 = num29;
											num8 = num28;
											if (num30 > num8)
											{
												break;
											}
											string key = dictionary.ElementAt(num29).Key;
											string value5 = dictionary.ElementAt(num29).Value;
											string text9 = Regex.Escape(key);
											Type typeFromHandle = typeof(Regex);
											array4 = new object[4]
											{
												text8,
												text9,
												RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(value5.Trim(), "", TextCompare: false) == 0, "\t|@#$%|", value5)),
												RegexOptions.IgnoreCase
											};
											object[] arguments7 = array4;
											array2 = new bool[4] { true, true, false, false };
											object obj8 = NewLateBinding.LateGet(null, typeFromHandle, "Replace", arguments7, null, null, array2);
											if (array2[0])
											{
												text8 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
											}
											if (array2[1])
											{
												text9 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[1]), typeof(string));
											}
											text8 = Conversions.ToString(obj8);
											Type typeFromHandle2 = typeof(Regex);
											array4 = new object[4]
											{
												text7,
												text9,
												RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(value5.Trim(), "", TextCompare: false) == 0, "\t|@#$%|", value5)),
												RegexOptions.IgnoreCase
											};
											object[] arguments8 = array4;
											array2 = new bool[4] { true, true, false, false };
											object obj9 = NewLateBinding.LateGet(null, typeFromHandle2, "Replace", arguments8, null, null, array2);
											if (array2[0])
											{
												text7 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
											}
											if (array2[1])
											{
												text9 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[1]), typeof(string));
											}
											text7 = Conversions.ToString(obj9);
											num29++;
										}
										int num31 = code.connstrlist.Length - 1;
										int num32 = 0;
										while (true)
										{
											int num33 = num32;
											num8 = num31;
											if (num33 > num8)
											{
												break;
											}
											text8 = text8.Replace(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateIndexGet(code.connstrlist, new object[1] { num32 }, null), "\t|@#$%|")), "");
											text8 = text8.Replace(Conversions.ToString(Operators.ConcatenateObject("\t|@#$%|", NewLateBinding.LateIndexGet(code.connstrlist, new object[1] { num32 }, null))), "");
											num32++;
										}
									}
									FileName = Conversions.ToString(Interaction.IIf(Operators.CompareString(text8.Trim(), "", TextCompare: false) == 0, text4, text8));
									code.DeleteInvalidChars(ref FileName);
									int num34 = list.Count - 1;
									int num35 = 0;
									while (true)
									{
										int num36 = num35;
										num8 = num34;
										if (num36 > num8)
										{
											break;
										}
										int num37 = 1;
										if (list[num35].EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
										{
											text = FilePathName;
											if (num9 == 1)
											{
												object instance = obj4;
												array4 = new object[6]
												{
													text,
													4,
													1,
													RuntimeHelpers.GetObjectValue(obj),
													Errors,
													Warnings
												};
												object[] arguments9 = array4;
												array2 = new bool[6] { true, false, false, true, true, true };
												object value6 = NewLateBinding.LateGet(instance, null, "SaveAs", arguments9, null, null, array2);
												if (array2[0])
												{
													text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
												}
												if (array2[3])
												{
													obj = RuntimeHelpers.GetObjectValue(array4[3]);
												}
												if (array2[4])
												{
													Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
												}
												if (array2[5])
												{
													Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
												}
												flag3 = Conversions.ToBoolean(value6);
												if (flag3)
												{
													text5 = text;
												}
											}
										}
										else if (list[num35].EndsWith(".save", StringComparison.Ordinal))
										{
											text = FilePathName;
											num37 = 5;
											if (num9 == 1)
											{
												object instance2 = obj2;
												array4 = new object[3] { num37, Errors, Warnings };
												object[] arguments10 = array4;
												array2 = new bool[3] { true, true, true };
												object value7 = NewLateBinding.LateGet(instance2, null, "Save3", arguments10, null, null, array2);
												if (array2[0])
												{
													num37 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(int));
												}
												if (array2[1])
												{
													Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[1]), typeof(int));
												}
												if (array2[2])
												{
													Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[2]), typeof(int));
												}
												flag3 = Conversions.ToBoolean(value7);
												NewLateBinding.LateCall(obj2, null, "ForceRebuild3", new object[1] { true }, null, null, null, IgnoreReturn: true);
											}
										}
										else if (list[num35].EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
										{
											text = SavePath + FileName + list[num35];
											if (Multiplesheet_pdf.SelectedIndex == 0)
											{
												text = SavePath + FileName + list[num35];
												if (num9 == 1)
												{
													text3 = text;
													NewLateBinding.LateCall(obj, null, "SetSheets", new object[2]
													{
														3,
														list3.ToArray()
													}, null, null, null, IgnoreReturn: true);
													object instance3 = obj4;
													array4 = new object[6]
													{
														text,
														0,
														1,
														RuntimeHelpers.GetObjectValue(obj),
														Errors,
														Warnings
													};
													object[] arguments11 = array4;
													array2 = new bool[6] { true, false, false, true, true, true };
													object value8 = NewLateBinding.LateGet(instance3, null, "SaveAs", arguments11, null, null, array2);
													if (array2[0])
													{
														text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
													}
													if (array2[3])
													{
														obj = RuntimeHelpers.GetObjectValue(array4[3]);
													}
													if (array2[4])
													{
														Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
													}
													if (array2[5])
													{
														Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
													}
													flag3 = Conversions.ToBoolean(value8);
												}
												if (File.Exists(text3))
												{
													if (add_watertext.Checked)
													{
														MyiTextSharp.PDFWatermarkText(text3, text7, selectedIndex, num2, num, FontDialog1.Font, FontDialog1.Color, num9);
													}
													if (add_waterimg.Checked)
													{
														MyiTextSharp.PDFWatermarkimage(text3, modelPicName, selectedIndex2, num4, num3, grayFill, degrees);
													}
												}
											}
											else if (Multiplesheet_pdf.SelectedIndex == 1)
											{
												text = SavePath + FileName + str + list[num35];
												NewLateBinding.LateCall(obj, null, "SetSheets", new object[2] { 2, "" }, null, null, null, IgnoreReturn: true);
												object instance4 = obj4;
												array4 = new object[6]
												{
													text,
													0,
													1,
													RuntimeHelpers.GetObjectValue(obj),
													Errors,
													Warnings
												};
												object[] arguments12 = array4;
												array2 = new bool[6] { true, false, false, true, true, true };
												object value9 = NewLateBinding.LateGet(instance4, null, "SaveAs", arguments12, null, null, array2);
												if (array2[0])
												{
													text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
												}
												if (array2[3])
												{
													obj = RuntimeHelpers.GetObjectValue(array4[3]);
												}
												if (array2[4])
												{
													Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
												}
												if (array2[5])
												{
													Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
												}
												flag3 = Conversions.ToBoolean(value9);
												if (File.Exists(text))
												{
													if (add_watertext.Checked)
													{
														MyiTextSharp.PDFWatermarkText(text, text7, selectedIndex, num2, num, FontDialog1.Font, FontDialog1.Color);
													}
													if (add_waterimg.Checked)
													{
														MyiTextSharp.PDFWatermarkimage(text, modelPicName, selectedIndex2, num4, num3, grayFill, degrees);
													}
												}
											}
											else if (Multiplesheet_pdf.SelectedIndex == 2)
											{
												if (num14 == 0)
												{
													text = SavePath + FileName + str + list[num35];
													NewLateBinding.LateCall(obj, null, "SetSheets", new object[2]
													{
														3,
														list3[num14].ToString()
													}, null, null, null, IgnoreReturn: true);
													object instance5 = obj4;
													array4 = new object[6]
													{
														text,
														0,
														1,
														RuntimeHelpers.GetObjectValue(obj),
														Errors,
														Warnings
													};
													object[] arguments13 = array4;
													array2 = new bool[6] { true, false, false, true, true, true };
													object value10 = NewLateBinding.LateGet(instance5, null, "SaveAs", arguments13, null, null, array2);
													if (array2[0])
													{
														text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
													}
													if (array2[3])
													{
														obj = RuntimeHelpers.GetObjectValue(array4[3]);
													}
													if (array2[4])
													{
														Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
													}
													if (array2[5])
													{
														Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
													}
													flag3 = Conversions.ToBoolean(value10);
													if (File.Exists(text))
													{
														if (add_watertext.Checked)
														{
															MyiTextSharp.PDFWatermarkText(text, text7, selectedIndex, num2, num, FontDialog1.Font, FontDialog1.Color);
														}
														if (add_waterimg.Checked)
														{
															MyiTextSharp.PDFWatermarkimage(text, modelPicName, selectedIndex2, num4, num3, grayFill, degrees);
														}
													}
												}
											}
											else if (Multiplesheet_pdf.SelectedIndex == 3 && text6.Equals(list3[num14].ToString(), StringComparison.OrdinalIgnoreCase))
											{
												text = SavePath + FileName + str + list[num35];
												NewLateBinding.LateCall(obj, null, "SetSheets", new object[2]
												{
													3,
													list3[num14].ToString()
												}, null, null, null, IgnoreReturn: true);
												object instance6 = obj4;
												array4 = new object[6]
												{
													text,
													0,
													1,
													RuntimeHelpers.GetObjectValue(obj),
													Errors,
													Warnings
												};
												object[] arguments14 = array4;
												array2 = new bool[6] { true, false, false, true, true, true };
												object value11 = NewLateBinding.LateGet(instance6, null, "SaveAs", arguments14, null, null, array2);
												if (array2[0])
												{
													text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
												}
												if (array2[3])
												{
													obj = RuntimeHelpers.GetObjectValue(array4[3]);
												}
												if (array2[4])
												{
													Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
												}
												if (array2[5])
												{
													Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
												}
												flag3 = Conversions.ToBoolean(value11);
												if (File.Exists(text))
												{
													if (add_watertext.Checked)
													{
														MyiTextSharp.PDFWatermarkText(text, text7, selectedIndex, num2, num, FontDialog1.Font, FontDialog1.Color);
													}
													if (add_waterimg.Checked)
													{
														MyiTextSharp.PDFWatermarkimage(text, modelPicName, selectedIndex2, num4, num3, grayFill, degrees);
													}
												}
											}
										}
										else if (list[num35].EndsWith(".dwg", StringComparison.OrdinalIgnoreCase) || (list[num35].EndsWith(".dxf", StringComparison.OrdinalIgnoreCase) ? true : false))
										{
											if (Multiplesheet_dwg.SelectedIndex == 0)
											{
												if (num9 == 1)
												{
													text = SavePath + FileName + list[num35];
													NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 253, 2 }, null, null, null, IgnoreReturn: true);
													object instance7 = obj4;
													array4 = new object[6]
													{
														text,
														0,
														1,
														RuntimeHelpers.GetObjectValue(obj),
														Errors,
														Warnings
													};
													object[] arguments15 = array4;
													array2 = new bool[6] { true, false, false, true, true, true };
													object value12 = NewLateBinding.LateGet(instance7, null, "SaveAs", arguments15, null, null, array2);
													if (array2[0])
													{
														text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
													}
													if (array2[3])
													{
														obj = RuntimeHelpers.GetObjectValue(array4[3]);
													}
													if (array2[4])
													{
														Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
													}
													if (array2[5])
													{
														Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
													}
													flag3 = Conversions.ToBoolean(value12);
												}
											}
											else if (Multiplesheet_dwg.SelectedIndex == 1)
											{
												NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 253, 0 }, null, null, null, IgnoreReturn: true);
												text = SavePath + FileName + str + list[num35];
												object instance8 = obj4;
												array4 = new object[6]
												{
													text,
													0,
													1,
													RuntimeHelpers.GetObjectValue(obj),
													Errors,
													Warnings
												};
												object[] arguments16 = array4;
												array2 = new bool[6] { true, false, false, true, true, true };
												object value13 = NewLateBinding.LateGet(instance8, null, "SaveAs", arguments16, null, null, array2);
												if (array2[0])
												{
													text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
												}
												if (array2[3])
												{
													obj = RuntimeHelpers.GetObjectValue(array4[3]);
												}
												if (array2[4])
												{
													Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
												}
												if (array2[5])
												{
													Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
												}
												flag3 = Conversions.ToBoolean(value13);
											}
											else if (Multiplesheet_dwg.SelectedIndex == 2)
											{
												if (num14 == 0)
												{
													NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 253, 0 }, null, null, null, IgnoreReturn: true);
													text = SavePath + FileName + str + list[num35];
													object instance9 = obj4;
													array4 = new object[6]
													{
														text,
														0,
														1,
														RuntimeHelpers.GetObjectValue(obj),
														Errors,
														Warnings
													};
													object[] arguments17 = array4;
													array2 = new bool[6] { true, false, false, true, true, true };
													object value14 = NewLateBinding.LateGet(instance9, null, "SaveAs", arguments17, null, null, array2);
													if (array2[0])
													{
														text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
													}
													if (array2[3])
													{
														obj = RuntimeHelpers.GetObjectValue(array4[3]);
													}
													if (array2[4])
													{
														Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
													}
													if (array2[5])
													{
														Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
													}
													flag3 = Conversions.ToBoolean(value14);
												}
											}
											else if (Multiplesheet_dwg.SelectedIndex == 3 && text6.Equals(list3[num14].ToString(), StringComparison.OrdinalIgnoreCase))
											{
												NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 253, 0 }, null, null, null, IgnoreReturn: true);
												text = SavePath + FileName + str + list[num35];
												object instance10 = obj4;
												array4 = new object[6]
												{
													text,
													0,
													1,
													RuntimeHelpers.GetObjectValue(obj),
													Errors,
													Warnings
												};
												object[] arguments18 = array4;
												array2 = new bool[6] { true, false, false, true, true, true };
												object value15 = NewLateBinding.LateGet(instance10, null, "SaveAs", arguments18, null, null, array2);
												if (array2[0])
												{
													text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
												}
												if (array2[3])
												{
													obj = RuntimeHelpers.GetObjectValue(array4[3]);
												}
												if (array2[4])
												{
													Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
												}
												if (array2[5])
												{
													Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
												}
												flag3 = Conversions.ToBoolean(value15);
											}
										}
										else
										{
											text = SavePath + FileName + str + list[num35];
											object instance11 = obj4;
											array4 = new object[6]
											{
												text,
												0,
												num37,
												RuntimeHelpers.GetObjectValue(obj),
												Errors,
												Warnings
											};
											object[] arguments19 = array4;
											array2 = new bool[6] { true, false, true, true, true, true };
											object value16 = NewLateBinding.LateGet(instance11, null, "SaveAs", arguments19, null, null, array2);
											if (array2[0])
											{
												text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
											}
											if (array2[2])
											{
												num37 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[2]), typeof(int));
											}
											if (array2[3])
											{
												obj = RuntimeHelpers.GetObjectValue(array4[3]);
											}
											if (array2[4])
											{
												Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
											}
											if (array2[5])
											{
												Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
											}
											flag3 = Conversions.ToBoolean(value16);
										}
										if (flag3)
										{
											flag2 = true;
										}
										num35++;
									}
									if ((!list.Exists(_Lambda_0024__20) && (!list.Exists(_Lambda_0024__21) || (Multiplesheet_pdf.SelectedIndex != 1 && Multiplesheet_pdf.SelectedIndex != 3 && (!add_watertext.Checked || Multiplesheet_pdf.SelectedIndex != 0))) && (!list.Exists(_Lambda_0024__22) || (Multiplesheet_dwg.SelectedIndex != 1 && Multiplesheet_dwg.SelectedIndex != 3))) || 1 == 0)
									{
										break;
									}
									num9++;
									num14++;
								}
							}
							else if ((swFileTYpe == 1) | (swFileTYpe == 2))
							{
								string value17 = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(obj2, null, "GetActiveConfiguration", new object[0], null, null, null), null, "name", new object[0], null, null, null));
								object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, null, "GetConfigurationNames", new object[0], null, null, null));
								List<string> list7 = new List<string>();
								int num38 = Information.UBound((Array)objectValue4);
								int num39 = 0;
								while (true)
								{
									int num40 = num39;
									num8 = num38;
									if (num40 > num8)
									{
										break;
									}
									closure_0024__2 = new _Closure_0024__12(closure_0024__2);
									closure_0024__2._0024VB_0024Local_cfg = Convert.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue4, new object[1] { num39 }, null)));
									if ((forcurcfg.Checked && Operators.CompareString(cfglist[num6], "", TextCompare: false) != 0) ? true : false)
									{
										string[] array9 = Strings.Split(cfglist[num6], "|\n");
										if (cfglist.Count >= 1 && !Array.Exists(array9, closure_0024__2._Lambda_0024__23))
										{
											goto IL_28e5;
										}
									}
									object instance12 = obj2;
									object[] array4 = new object[1] { closure_0024__2._0024VB_0024Local_cfg };
									object[] arguments20 = array4;
									bool[] array2 = new bool[1] { true };
									object obj10 = NewLateBinding.LateGet(instance12, null, "GetConfigurationByName", arguments20, null, null, array2);
									if (array2[0])
									{
										closure_0024__2._0024VB_0024Local_cfg = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
									}
									object objectValue5 = RuntimeHelpers.GetObjectValue(obj10);
									if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue5)) || !Conversions.ToBoolean(((Conversions.ToBoolean(exclude_IsDerived.Checked) && Conversions.ToBoolean(NewLateBinding.LateGet(objectValue5, null, "IsDerived", new object[0], null, null, null))) || Conversions.ToBoolean((exclude_AsMachined.Checked && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue5, null, "Type", new object[0], null, null, null), 1, TextCompare: false)) ? true : false) || Conversions.ToBoolean((exclude_AsWelded.Checked && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue5, null, "Type", new object[0], null, null, null), 2, TextCompare: false)) ? true : false) || Conversions.ToBoolean((exclude_SheetMetal.Checked && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue5, null, "Type", new object[0], null, null, null), 3, TextCompare: false)) ? true : false) || Conversions.ToBoolean((exclude_SpeedPak.Checked && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue5, null, "Type", new object[0], null, null, null), 4, TextCompare: false)) ? true : false) || Conversions.ToBoolean((exclude_unactive.Checked && !closure_0024__2._0024VB_0024Local_cfg.Equals(value17, StringComparison.OrdinalIgnoreCase)) ? true : false)) ? ((object)true) : ((object)false)))
									{
										list7.Add(Convert.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue4, new object[1] { num39 }, null))));
									}
									goto IL_28e5;
									IL_28e5:
									num39++;
								}
								int num41 = list7.Count - 1;
								int num42 = 0;
								while (true)
								{
									int num43 = num42;
									num8 = num41;
									if (num43 > num8)
									{
										break;
									}
									string text10 = "";
									text10 = (((!withoutcfgname.Checked || list7.Count != 1) && 0 == 0) ? ("(" + list7[num42] + ")") : "");
									object instance13 = obj2;
									object[] array6 = new object[1];
									object[] array10 = array6;
									List<string> list4 = list7;
									List<string> list8 = list4;
									int index = num42;
									array10[0] = list8[index];
									object[] array4 = array6;
									object[] arguments21 = array4;
									bool[] array2 = new bool[1] { true };
									NewLateBinding.LateCall(instance13, null, "ShowConfiguration2", arguments21, null, null, array2, IgnoreReturn: true);
									if (array2[0])
									{
										list4[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
									}
									NewLateBinding.LateCall(obj2, null, "ShowNamedView2", new object[2] { "", 7 }, null, null, null, IgnoreReturn: true);
									NewLateBinding.LateCall(obj2, null, "ViewZoomtofit2", new object[0], null, null, null, IgnoreReturn: true);
									string text11 = Conversions.ToString(Interaction.IIf(custom_3d.Checked, customname_3d.Text.Trim(), ""));
									if (text11.Length > 0)
									{
										Dictionary<string, string> dictionary2 = code.Getpropfrommodel(RuntimeHelpers.GetObjectValue(code.swApp), RuntimeHelpers.GetObjectValue(obj2), list7[num42]);
										MatchCollection matchCollection2 = Regex.Matches(text11, "(\\$).*?(\\$)");
										int num44 = matchCollection2.Count - 1;
										int num45 = 0;
										while (true)
										{
											int num46 = num45;
											num8 = num44;
											if (num46 > num8)
											{
												break;
											}
											string value18 = matchCollection2[num45].Value;
											if (!dictionary2.ContainsKey(value18))
											{
												dictionary2.Add(value18, "");
											}
											num45++;
										}
										matchCollection2 = Regex.Matches(text11, "(?=\\<).*?(?>\\>)");
										int num47 = matchCollection2.Count - 1;
										int num48 = 0;
										while (true)
										{
											int num49 = num48;
											num8 = num47;
											if (num49 > num8)
											{
												break;
											}
											string value19 = matchCollection2[num48].Value;
											if (!dictionary2.ContainsKey(value19))
											{
												dictionary2.Add(value19, "");
											}
											num48++;
										}
										if ((withoutcfgname.Checked && list7.Count == 1) ? true : false)
										{
											text11 = text11.Replace("<ИмяКонфигурации>", "\t|@#$%|");
										}
										int num50 = dictionary2.Count - 1;
										int num51 = 0;
										while (true)
										{
											int num52 = num51;
											num8 = num50;
											if (num52 > num8)
											{
												break;
											}
											string key2 = dictionary2.ElementAt(num51).Key;
											string value20 = dictionary2.ElementAt(num51).Value;
											text11 = Strings.Replace(text11, key2, Conversions.ToString(Interaction.IIf(Operators.CompareString(value20.Trim(), "", TextCompare: false) == 0, "\t|@#$%|", value20)), 1, -1, CompareMethod.Text);
											num51++;
										}
										int num53 = code.connstrlist.Length - 1;
										int num54 = 0;
										while (true)
										{
											int num55 = num54;
											num8 = num53;
											if (num55 > num8)
											{
												break;
											}
											text11 = text11.Replace(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateIndexGet(code.connstrlist, new object[1] { num54 }, null), "\t|@#$%|")), "");
											text11 = text11.Replace(Conversions.ToString(Operators.ConcatenateObject("\t|@#$%|", NewLateBinding.LateIndexGet(code.connstrlist, new object[1] { num54 }, null))), "");
											num54++;
										}
									}
									FileName = Conversions.ToString(Interaction.IIf(Operators.CompareString(text11.Trim(), "", TextCompare: false) == 0, text4 + text10, text11));
									code.DeleteInvalidChars(ref FileName);
									int num56 = list2.Count - 1;
									int num57 = 0;
									while (true)
									{
										int num58 = num57;
										num8 = num56;
										if (num58 > num8)
										{
											break;
										}
										int num59 = 1;
										if (list2[num57].EndsWith(".PDF", StringComparison.OrdinalIgnoreCase))
										{
											text2 = SavePath + FileName + "(3D)" + list2[num57];
											NewLateBinding.LateSet(obj, null, "ExportAs3D", new object[1] { true }, null, null);
										}
										else
										{
											text2 = SavePath + FileName + list2[num57];
											NewLateBinding.LateSet(obj, null, "ExportAs3D", new object[1] { false }, null, null);
										}
										if (list2[num57].EndsWith(".STEP", StringComparison.Ordinal))
										{
											NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 75, 214 }, null, null, null, IgnoreReturn: true);
										}
										else if (list2[num57].EndsWith(".step", StringComparison.Ordinal))
										{
											NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 75, 203 }, null, null, null, IgnoreReturn: true);
										}
										bool[] array11;
										if (list2[num57].EndsWith(".save", StringComparison.Ordinal))
										{
											num59 = 5;
											text2 = FilePathName;
											long num60 = Conversions.ToLong(NewLateBinding.LateGet(obj2, null, "GetLightSourceCount", new object[0], null, null, null));
											string text12 = "Light" + Conversions.ToString(num60 + 1);
											object instance14 = obj2;
											array4 = new object[3] { text12, 4, text12 };
											object[] arguments22 = array4;
											array2 = new bool[3] { true, false, true };
											object value21 = NewLateBinding.LateGet(instance14, null, "AddLightSource", arguments22, null, null, array2);
											if (array2[0])
											{
												text12 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
											}
											if (array2[2])
											{
												text12 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[2]), typeof(string));
											}
											if (Conversions.ToBoolean(value21))
											{
												object instance15 = obj2;
												object[] array3 = new object[1] { num60 };
												object[] arguments23 = array3;
												array11 = new bool[1] { true };
												NewLateBinding.LateCall(instance15, null, "DeleteLightSource", arguments23, null, null, array11, IgnoreReturn: true);
												if (array11[0])
												{
													num60 = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(long));
												}
											}
											NewLateBinding.LateCall(obj2, null, "EditRebuild3", new object[0], null, null, null, IgnoreReturn: true);
											NewLateBinding.LateCall(obj2, null, "ShowNamedView2", new object[2] { "", 7 }, null, null, null, IgnoreReturn: true);
											NewLateBinding.LateCall(obj2, null, "ViewZoomtofit2", new object[0], null, null, null, IgnoreReturn: true);
										}
										object instance16 = obj4;
										array4 = new object[6]
										{
											text2,
											0,
											num59,
											RuntimeHelpers.GetObjectValue(obj),
											Errors,
											Warnings
										};
										object[] arguments24 = array4;
										array11 = new bool[6] { true, false, true, true, true, true };
										object value22 = NewLateBinding.LateGet(instance16, null, "SaveAs", arguments24, null, null, array11);
										if (array11[0])
										{
											text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
										}
										if (array11[2])
										{
											num59 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[2]), typeof(int));
										}
										if (array11[3])
										{
											obj = RuntimeHelpers.GetObjectValue(array4[3]);
										}
										if (array11[4])
										{
											Errors = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[4]), typeof(int));
										}
										if (array11[5])
										{
											Warnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[5]), typeof(int));
										}
										if (Conversions.ToBoolean(value22))
										{
											flag2 = true;
										}
										num57++;
									}
									num42++;
								}
							}
							if (!string.IsNullOrEmpty(FilePathName))
							{
								object swApp3 = code.swApp;
								object[] array4 = new object[1] { FilePathName };
								object[] arguments25 = array4;
								bool[] array11 = new bool[1] { true };
								NewLateBinding.LateCall(swApp3, null, "CloseDoc", arguments25, null, null, array11, IgnoreReturn: true);
								if (array11[0])
								{
									FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
								}
							}
							if (!string.IsNullOrEmpty(text5))
							{
								object swApp4 = code.swApp;
								object[] array4 = new object[1] { text5 };
								object[] arguments26 = array4;
								bool[] array11 = new bool[1] { true };
								NewLateBinding.LateCall(swApp4, null, "CloseDoc", arguments26, null, null, array11, IgnoreReturn: true);
								if (array11[0])
								{
									text5 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
								}
							}
							obj2 = null;
						}
					}
					OutBgWorker.ReportProgress(num6, flag2);
					goto IL_3278;
					IL_3278:
					num6++;
				}
				code.swApp = null;
				obj = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				code.swApp = null;
				er = true;
				ProjectData.ClearProjectError();
			}
		}
	}

	public void outset()
	{
		try
		{
			if (!code.RunSW())
			{
				return;
			}
			if (OUT_DWG.Checked || (OUT_DXF.Checked ? true : false))
			{
				switch (CADVer.SelectedIndex)
				{
				case 0:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 0 }, null, null, null, IgnoreReturn: true);
					break;
				case 1:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 1 }, null, null, null, IgnoreReturn: true);
					break;
				case 2:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 2 }, null, null, null, IgnoreReturn: true);
					break;
				case 3:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 3 }, null, null, null, IgnoreReturn: true);
					break;
				case 4:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 4 }, null, null, null, IgnoreReturn: true);
					break;
				case 5:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 5 }, null, null, null, IgnoreReturn: true);
					break;
				case 6:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 6 }, null, null, null, IgnoreReturn: true);
					break;
				case 7:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 0, 7 }, null, null, null, IgnoreReturn: true);
					break;
				}
				switch (CADfont.SelectedIndex)
				{
				case 0:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 1, 1 }, null, null, null, IgnoreReturn: true);
					break;
				case 1:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 1, 0 }, null, null, null, IgnoreReturn: true);
					break;
				}
				switch (CADline.SelectedIndex)
				{
				case 0:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 135, 1 }, null, null, null, IgnoreReturn: true);
					break;
				case 1:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 135, 0 }, null, null, null, IgnoreReturn: true);
					break;
				}
				if (ExportAllSheetsToPaperSpace.Checked)
				{
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 484, true }, null, null, null, IgnoreReturn: true);
				}
				else
				{
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 484, false }, null, null, null, IgnoreReturn: true);
				}
				switch (outputscale.Checked)
				{
				case true:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 136, 1 }, null, null, null, IgnoreReturn: true);
					break;
				case false:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 136, 0 }, null, null, null, IgnoreReturn: true);
					break;
				}
			}
			if (OUT_PDF.Checked)
			{
				switch (PDFcolor.Checked)
				{
				case true:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 323, true }, null, null, null, IgnoreReturn: true);
					break;
				case false:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 323, false }, null, null, null, IgnoreReturn: true);
					break;
				}
				switch (PDFfont.Checked)
				{
				case true:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 324, true }, null, null, null, IgnoreReturn: true);
					break;
				case false:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 324, false }, null, null, null, IgnoreReturn: true);
					break;
				}
				switch (PDFline.Checked)
				{
				case true:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 327, true }, null, null, null, IgnoreReturn: true);
					break;
				case false:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 327, false }, null, null, null, IgnoreReturn: true);
					break;
				}
			}
			if (OUT_JPG.Checked | OUT_PNG.Checked | OUT_JPG2.Checked | OUT_PNG2.Checked)
			{
				NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 385, 1 }, null, null, null, IgnoreReturn: true);
				switch (ImageType.SelectedIndex)
				{
				case 0:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 7, 0 }, null, null, null, IgnoreReturn: true);
					break;
				case 1:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 7, 1 }, null, null, null, IgnoreReturn: true);
					break;
				case 2:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 7, 2 }, null, null, null, IgnoreReturn: true);
					break;
				}
				switch (RadioButton1.Checked)
				{
				case true:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 6, 0 }, null, null, null, IgnoreReturn: true);
					break;
				case false:
					NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceIntegerValue", new object[2] { 6, 1 }, null, null, null, IgnoreReturn: true);
					break;
				}
				object swApp = code.swApp;
				object[] array = new object[2] { 9, null };
				object[] array2 = array;
				ComboBox image_dpi = Image_dpi;
				array2[1] = image_dpi.Text;
				object[] array3 = array;
				bool[] array4 = new bool[2] { false, true };
				NewLateBinding.LateCall(swApp, null, "SetUserPreferenceIntegerValue", array3, null, null, array4, IgnoreReturn: true);
				if (array4[1])
				{
					image_dpi.Text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(string));
				}
			}
			code.swApp = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			code.swApp = null;
			ProjectData.ClearProjectError();
		}
	}

	private void OutBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		checked
		{
			try
			{
				if (!CallInProgress)
				{
					CallInProgress = true;
					if (Operators.ConditionalCompareObjectEqual(e.UserState, true, TextCompare: false))
					{
						MyProject.Forms.FrmOutputlist.ListView1.Items[indexlist[e.ProgressPercentage]].SubItems[4].Text = "✔";
						MyProject.Forms.FrmOutputlist.ListView1.Items[indexlist[e.ProgressPercentage]].SubItems[4].ForeColor = Color.Blue;
					}
					MyProject.Forms.FrmOutputlist.ListView1.Items[indexlist[e.ProgressPercentage]].Selected = true;
					MyProject.Forms.FrmOutputlist.ListView1.Items[indexlist[e.ProgressPercentage]].EnsureVisible();
					MyProject.Forms.FrmOutputlist.ToolStripProgressBar1.Value = e.ProgressPercentage + 1;
					MyProject.Forms.FrmOutputlist.ToolStripStatusLabel1.Text = "Осталось " + Conversions.ToString(MyProject.Forms.FrmOutputlist.ListView1.Items.Count - 1 - e.ProgressPercentage) + " файлов";
					CallInProgress = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void OutBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			code.RunSW();
			MyProject.Forms.FrmOutputlist.addfiles.Enabled = true;
			MyProject.Forms.FrmOutputlist.clearall.Enabled = true;
			MyProject.Forms.FrmOutputlist.clearsel.Enabled = true;
			MyProject.Forms.FrmOutputlist.openinsw.Enabled = true;
			code.EnablePreview = true;
			MyProject.Forms.FrmOutputlist.ListView1.MultiSelect = true;
			MyProject.Forms.FrmOutputlist.ToolStripProgressBar1.Visible = false;
			MyProject.Forms.FrmOutputlist.ToolStripProgressBar1.Value = 0;
			if (er)
			{
				er = false;
				MyProject.Forms.FrmOutputlist.Switch(4);
			}
			else if (!e.Cancelled)
			{
				MyProject.Forms.FrmOutputlist.Switch(2);
			}
			else
			{
				MyProject.Forms.FrmOutputlist.Switch(3);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmOutputoptions_FormClosed(object sender, FormClosedEventArgs e)
	{
		Savecfg();
	}

	private void FrmOutputoptions_Load(object sender, EventArgs e)
	{
		if (!Visible)
		{
			return;
		}
		CADVer.SelectedIndex = 5;
		CADfont.SelectedIndex = 0;
		CADline.SelectedIndex = 1;
		ImageType.SelectedIndex = 1;
		Image_dpi.SelectedIndex = 6;
		Multiplesheet_pdf.SelectedIndex = 0;
		Multiplesheet_dwg.SelectedIndex = 1;
		text_postion.SelectedIndex = 0;
		img_postion.SelectedIndex = 0;
		Loadcfg();
		customname_2d.Enabled = custom_2d.Checked;
		customname_3d.Enabled = custom_3d.Checked;
		Button3.Enabled = custom_2d.Checked;
		Button4.Enabled = custom_3d.Checked;
		Panel1.Enabled = add_watertext.Checked;
		Panel2.Enabled = add_waterimg.Checked;
		watertext.Multiline = true;
		watertext.Height = checked((int)Math.Round(72.0 * dpixRatio));
		if (Operators.CompareString(watertext.Text, "", TextCompare: false) == 0)
		{
			TextBoxWaterMark.SetWatermark(watertext, "$Номер$ $Название$ $Тип$");
		}
		if (Operators.CompareString(customname_2d.Text, "", TextCompare: false) == 0)
		{
			TextBoxWaterMark.SetWatermark(customname_2d, "$Тип$-<ИмяФайла>-<ТекущаяДата>");
		}
		if (Operators.CompareString(customname_3d.Text, "", TextCompare: false) == 0)
		{
			TextBoxWaterMark.SetWatermark(customname_3d, "$Тип$-<ИмяФайла>-<ТекущаяДата>");
		}
		menu1 = createmenu1();
		menu2 = createmenu2();
		try
		{
			FontDialog1.Font = (Font)code.DeserializeBinary(CConfigMng.Config.tfont);
			FontDialog fontDialog = FontDialog1;
			object obj = code.DeserializeBinary(CConfigMng.Config.tcolor);
			Color color = default(Color);
			fontDialog.Color = ((obj != null) ? ((Color)obj) : color);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Browse_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			folder.Text = fileBorser.DirectoryPath;
		}
	}

	private void Originalfolder_CheckedChanged(object sender, EventArgs e)
	{
		if (sender.Equals(Originalfolder))
		{
			folder.Enabled = !((RadioButton)sender).Checked;
			Browse.Enabled = !((RadioButton)sender).Checked;
		}
		else
		{
			folder.Enabled = ((RadioButton)sender).Checked;
			Browse.Enabled = ((RadioButton)sender).Checked;
		}
	}

	public long GetPaperSize(string wName)
	{
		return wName.ToUpper() switch
		{
			"A4" => 9L, 
			"A3" => 8L, 
			"A2" => 66L, 
			"A1" => 137L, 
			"A0" => 136L, 
			_ => 9L, 
		};
	}

	private void CADVer_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (CADVer.SelectedIndex == 0)
		{
			CADfont.SelectedIndex = 1;
			CADfont.Enabled = false;
		}
		else
		{
			CADfont.Enabled = true;
		}
	}

	private void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
		if (sender.Equals(RadioButton1))
		{
			Image_dpi.Enabled = !((RadioButton)sender).Checked;
			Image_dpi.Enabled = !((RadioButton)sender).Checked;
		}
		else
		{
			Image_dpi.Enabled = ((RadioButton)sender).Checked;
			Image_dpi.Enabled = ((RadioButton)sender).Checked;
		}
	}

	private void name_Prefix_TextChanged(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (Operators.CompareString(textBox.Text, "", TextCompare: false) == 0)
		{
			TextBoxWaterMark.SetWatermark(textBox, "$Номер$ $Название$ $Тип$");
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		FontDialog1.ShowColor = true;
		try
		{
			FontDialog1.Font = (Font)code.DeserializeBinary(CConfigMng.Config.tfont);
			FontDialog fontDialog = FontDialog1;
			object obj = code.DeserializeBinary(CConfigMng.Config.tcolor);
			Color color = default(Color);
			fontDialog.Color = ((obj != null) ? ((Color)obj) : color);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (FontDialog1.ShowDialog() == DialogResult.OK)
		{
			CConfigMng.Config.tfont = code.SerializeBinary(FontDialog1.Font);
			CConfigMng.Config.tcolor = code.SerializeBinary(FontDialog1.Color);
			CConfigMng.SaveConfig();
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Изображение");
		openFileDialog.Multiselect = false;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Изображения (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
		if (openFileDialog.ShowDialog() != DialogResult.Cancel)
		{
			img_path.Text = openFileDialog.FileName;
		}
	}

	private void add_Prefix_CheckedChanged(object sender, EventArgs e)
	{
		customname_2d.Enabled = custom_2d.Checked;
		Button3.Enabled = custom_2d.Checked;
	}

	private void add_suffix_CheckedChanged(object sender, EventArgs e)
	{
		customname_3d.Enabled = custom_3d.Checked;
		Button4.Enabled = custom_3d.Checked;
	}

	private void add_watertext_CheckedChanged(object sender, EventArgs e)
	{
		Panel1.Enabled = add_watertext.Checked;
	}

	private void add_waterimg_CheckedChanged(object sender, EventArgs e)
	{
		Panel2.Enabled = add_waterimg.Checked;
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		tb = customname_2d;
		menu2.Show(button, button.Width, 0);
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		tb = customname_3d;
		menu1.Show(button, button.Width, 0);
	}

	private void Button5_Click(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		tb = watertext;
		menu2.Show(button, button.Width, 0);
	}

	public ContextMenuStrip createmenu1()
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		contextMenuStrip.ShowImageMargin = false;
		contextMenuStrip.Items.Clear();
		contextMenuStrip.AutoSize = true;
		contextMenuStrip.Items.Add("<Заголовок>");
		contextMenuStrip.Items.Add("<Тема>");
		contextMenuStrip.Items.Add("<Автор>");
		contextMenuStrip.Items.Add("<КлючевыеСлова>");
		contextMenuStrip.Items.Add("<Примечание>");
		contextMenuStrip.Items.Add("<ИмяФайла>");
		contextMenuStrip.Items.Add("<ИмяПапки>");
		contextMenuStrip.Items.Add("<ИмяКонфигурации>");
		contextMenuStrip.Items.Add("<Материал>");
		contextMenuStrip.Items.Add("<Количество>");
		contextMenuStrip.Items.Add("<ТекущаяДата>");
		checked
		{
			try
			{
				int num = CConfigMng.Config.propname.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						contextMenuStrip.Items.Add(CConfigMng.Config.propname[num2]);
						num2++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			int num5 = contextMenuStrip.Items.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				contextMenuStrip.Items[num6].Click += menuItems_click;
				num6++;
			}
			return contextMenuStrip;
		}
	}

	public ContextMenuStrip createmenu2()
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		contextMenuStrip.ShowImageMargin = false;
		contextMenuStrip.Items.Clear();
		contextMenuStrip.AutoSize = true;
		contextMenuStrip.Items.Add("<Заголовок>");
		contextMenuStrip.Items.Add("<Тема>");
		contextMenuStrip.Items.Add("<Автор>");
		contextMenuStrip.Items.Add("<КлючевыеСлова>");
		contextMenuStrip.Items.Add("<Примечание>");
		contextMenuStrip.Items.Add("<ИмяФайлаМодели>");
		contextMenuStrip.Items.Add("<ИмяПапкиМодели>");
		contextMenuStrip.Items.Add("<ИмяКонфигурации>");
		contextMenuStrip.Items.Add("<Материал>");
		contextMenuStrip.Items.Add("<Количество>");
		contextMenuStrip.Items.Add("<ИмяФайла>");
		contextMenuStrip.Items.Add("<ТекущаяДата>");
		checked
		{
			try
			{
				int num = CConfigMng.Config.propname.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						contextMenuStrip.Items.Add(CConfigMng.Config.propname[num2]);
						num2++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			int num5 = contextMenuStrip.Items.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				contextMenuStrip.Items[num6].Click += menuItems_click;
				num6++;
			}
			return contextMenuStrip;
		}
	}

	private void menuItems_click(object sender, EventArgs e)
	{
		try
		{
			string text = tb.Text;
			string text2 = ((ToolStripMenuItem)sender).Text;
			if ((!text2.StartsWith("<") || !text2.EndsWith(">")) && 0 == 0)
			{
				text2 = "$" + text2 + "$";
			}
			tb.Focus();
			int selectionStart = tb.SelectionStart;
			if (tb.SelectionLength > 0)
			{
				text = Strings.Replace(text, tb.SelectedText, text2);
			}
			else
			{
				text = text.Insert(selectionStart, text2);
				tb.Text = text;
			}
			tb.SelectionStart = checked(selectionStart + text2.Length);
			tb.SelectionLength = 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Savecfg()
	{
		CConfigMng.Config.outcfg.Clear();
		foreach (Control control in Controls)
		{
			FindctlToSave(control);
		}
		CConfigMng.Config.HideSw1 = HideSw1.Checked;
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.outcfg.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if ((control is TextBox && !(control.Parent is NumericUpDown)) ? true : false)
			{
				CConfigMng.Config.outcfg.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.outcfg.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.outcfg.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			else if (control is NumericUpDown)
			{
				CConfigMng.Config.outcfg.Add(control.Name + "\n" + ((NumericUpDown)control).Value);
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		foreach (Control control in Controls)
		{
			FindctlToLoad(control);
		}
		HideSw1.Checked = CConfigMng.Config.HideSw1;
	}

	private void FindctlToLoad(Control parent)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Control control = default(Control);
		string[] array = default(string[]);
		IEnumerator enumerator = default(IEnumerator);
		int num5 = default(int);
		int num6 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					int num7;
					int num8;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000a;
					case 620:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_000a;
							case 3:
								goto IL_002a;
							case 4:
								goto IL_0047;
							case 5:
								goto IL_0067;
							case 6:
								goto IL_0085;
							case 7:
								goto IL_0097;
							case 9:
								goto IL_00b3;
							case 10:
								goto IL_00c6;
							case 12:
								goto IL_00ed;
							case 13:
								goto IL_0100;
							case 15:
								goto IL_0120;
							case 16:
								goto IL_0133;
							case 18:
								goto IL_014d;
							case 19:
								goto IL_0160;
							case 8:
							case 11:
							case 14:
							case 17:
							case 20:
							case 21:
							case 22:
								goto IL_0180;
							case 23:
								goto IL_0195;
							case 24:
								goto IL_01a5;
							case 25:
							case 26:
								goto IL_01b2;
							default:
								goto end_IL_0001;
							case 27:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_0100:
						num2 = 13;
						((ComboBox)control).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_0180;
						IL_0120:
						num2 = 15;
						if (control is RadioButton)
						{
							goto IL_0133;
						}
						goto IL_014d;
						IL_00ed:
						num2 = 12;
						if (control is ComboBox)
						{
							goto IL_0100;
						}
						goto IL_0120;
						IL_0133:
						num2 = 16;
						((RadioButton)control).Checked = code.Cbool1(array[1]);
						goto IL_0180;
						IL_000a:
						num2 = 2;
						enumerator = parent.Controls.GetEnumerator();
						goto IL_01b7;
						IL_01b7:
						if (enumerator.MoveNext())
						{
							control = (Control)enumerator.Current;
							goto IL_002a;
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto end_IL_0001_2;
						IL_014d:
						num2 = 18;
						if (control is NumericUpDown)
						{
							goto IL_0160;
						}
						goto IL_0180;
						IL_0180:
						num2 = 22;
						num5++;
						goto IL_0189;
						IL_0160:
						num2 = 19;
						((NumericUpDown)control).Value = new decimal(Conversion.Val(array[1]));
						goto IL_0180;
						IL_002a:
						num2 = 3;
						num6 = CConfigMng.Config.outcfg.Count - 1;
						num5 = 0;
						goto IL_0189;
						IL_0189:
						num7 = num5;
						num8 = num6;
						if (num7 <= num8)
						{
							goto IL_0047;
						}
						goto IL_0195;
						IL_0195:
						num2 = 23;
						if (control.HasChildren)
						{
							goto IL_01a5;
						}
						goto IL_01b2;
						IL_01a5:
						num2 = 24;
						FindctlToLoad(control);
						goto IL_01b2;
						IL_01b2:
						num2 = 26;
						goto IL_01b7;
						IL_0047:
						num2 = 4;
						array = Strings.Split(CConfigMng.Config.outcfg[num5], "\n", 2);
						goto IL_0067;
						IL_0067:
						num2 = 5;
						if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_0085;
						}
						goto IL_0180;
						IL_0085:
						num2 = 6;
						if (control is CheckBox)
						{
							goto IL_0097;
						}
						goto IL_00b3;
						IL_0097:
						num2 = 7;
						((CheckBox)control).Checked = code.Cbool1(array[1]);
						goto IL_0180;
						IL_00b3:
						num2 = 9;
						if (control is TextBox)
						{
							goto IL_00c6;
						}
						goto IL_00ed;
						IL_00c6:
						num2 = 10;
						((TextBox)control).Text = array[1].Replace("\n", "\r\n");
						goto IL_0180;
						end_IL_0001:
						break;
					}
				}
			}
			catch (Exception obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 620;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_2:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private static bool _Lambda_0024__18(string s)
	{
		return s.EndsWith(".step", StringComparison.OrdinalIgnoreCase) | s.EndsWith(".igs", StringComparison.OrdinalIgnoreCase) | s.EndsWith(".save", StringComparison.OrdinalIgnoreCase) | s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) | s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) | s.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) | s.EndsWith(".stl", StringComparison.OrdinalIgnoreCase);
	}

	[SpecialName]
	[CompilerGenerated]
	private static bool _Lambda_0024__20(string s)
	{
		return (s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)) ? true : false;
	}

	[SpecialName]
	[CompilerGenerated]
	private static bool _Lambda_0024__21(string s)
	{
		return s.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase);
	}

	[SpecialName]
	[CompilerGenerated]
	private static bool _Lambda_0024__22(string s)
	{
		return (s.EndsWith(".dwg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".dxf", StringComparison.OrdinalIgnoreCase)) ? true : false;
	}
}
