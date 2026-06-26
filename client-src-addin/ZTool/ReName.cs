using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;
using ZTool.CustomFileBorser;
using stdole;

namespace ZTool;

[DesignerGenerated]
public class ReName : Form
{
	[CompilerGenerated]
	internal class Type_32
	{
		public string f_347;

		public Type_32(Type_32 P_0)
		{
			if (P_0 != null)
			{
				f_347 = P_0.f_347;
			}
		}

		[CompilerGenerated]
		public bool m_150(string P_0)
		{
			return P_0.Equals(f_347, StringComparison.CurrentCultureIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class Type_33
	{
		public string f_348;

		public Type_33(Type_33 P_0)
		{
			if (P_0 != null)
			{
				f_348 = P_0.f_348;
			}
		}

		[CompilerGenerated]
		public bool m_151(string P_0)
		{
			return P_0.Equals(f_348, StringComparison.CurrentCultureIgnoreCase);
		}
	}

	private IContainer f_264;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel f_265;

	[AccessedThroughProperty("OK_Button")]
	private Button f_266;

	[AccessedThroughProperty("Cancel_Button")]
	private Button f_267;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox f_268;

	[AccessedThroughProperty("Label2")]
	private Label f_269;

	[AccessedThroughProperty("Label1")]
	private Label f_270;

	[AccessedThroughProperty("Button3")]
	private Button f_271;

	[AccessedThroughProperty("Button2")]
	private Button f_272;

	[AccessedThroughProperty("Button1")]
	private Button f_273;

	[AccessedThroughProperty("pathname")]
	private ComboBox f_274;

	[AccessedThroughProperty("filename")]
	private ComboBox f_275;

	[AccessedThroughProperty("Button6")]
	private Button f_276;

	[AccessedThroughProperty("Button8")]
	private Button f_277;

	[AccessedThroughProperty("Button7")]
	private Button f_278;

	[AccessedThroughProperty("Label3")]
	private Label f_279;

	[AccessedThroughProperty("Label4")]
	private Label f_280;

	[AccessedThroughProperty("TabPage3")]
	private TabPage f_281;

	[AccessedThroughProperty("Panel2")]
	private Panel f_282;

	[AccessedThroughProperty("ListBox1")]
	private ListBox f_283;

	[AccessedThroughProperty("Panel1")]
	private Panel f_284;

	[AccessedThroughProperty("Button4")]
	private Button f_285;

	[AccessedThroughProperty("Button5")]
	private Button f_286;

	[AccessedThroughProperty("TabPage2")]
	private TabPage f_287;

	[AccessedThroughProperty("DGV1")]
	private DataGridView f_288;

	[AccessedThroughProperty("TabPage1")]
	private TabPage f_289;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox f_290;

	[AccessedThroughProperty("RadioButton3")]
	private RadioButton f_291;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton f_292;

	[AccessedThroughProperty("RadioButton5")]
	private RadioButton f_293;

	[AccessedThroughProperty("RadioButton4")]
	private RadioButton f_294;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton f_295;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox f_296;

	[AccessedThroughProperty("CopyDrw")]
	private Label f_297;

	[AccessedThroughProperty("CheckBox3")]
	private CheckBox f_298;

	[AccessedThroughProperty("CheckBox2")]
	private CheckBox f_299;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox f_300;

	[AccessedThroughProperty("TabControl1")]
	private TabControl f_301;

	[AccessedThroughProperty("TabPage4")]
	private TabPage f_302;

	[AccessedThroughProperty("CListBox1")]
	private CheckedListBox f_303;

	[AccessedThroughProperty("Panel3")]
	private Panel f_304;

	[AccessedThroughProperty("Button9")]
	private Button f_305;

	[AccessedThroughProperty("Button10")]
	private Button f_306;

	[AccessedThroughProperty("Column4")]
	private DataGridViewCheckBoxColumn f_307;

	[AccessedThroughProperty("Column1")]
	private DataGridViewTextBoxColumn f_308;

	[AccessedThroughProperty("Column2")]
	private DataGridViewTextBoxColumn f_309;

	[AccessedThroughProperty("Column3")]
	private DataGridViewTextBoxColumn f_310;

	[AccessedThroughProperty("fromdisk")]
	private ToolStripMenuItem f_311;

	[AccessedThroughProperty("sameassel")]
	private ToolStripMenuItem f_312;

	[AccessedThroughProperty("Savemenu")]
	private ContextMenuStrip f_313;

	[AccessedThroughProperty("lockpath")]
	private CheckBox f_314;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel f_315;

	[AccessedThroughProperty("RadioButton6")]
	private RadioButton f_316;

	internal int f_317;

	internal SldWorks f_318;

	internal ModelDoc2 f_319;

	private SelectionMgr f_320;

	private ModelDoc2 f_321;

	private object f_322;

	private string f_323;

	private string f_324;

	internal string f_325;

	internal bool f_326;

	private Component2[] f_327;

	internal bool f_328;

	internal const string f_329 = "[\\S*]+[A-Za-z0-9]";

	internal const string f_330 = "((?<=\\s)[A-Za-z0-9\\u4e00-\\u9fa5]+$)|([A-Za-z0-9\\u4e00-\\u9fa5]+(?=\\]$|\\】$|\\)$|\\）$))|([\\u4e00-\\u9fa5][A-Za-z0-9\\u4e00-\\u9fa5]+$)";

	internal const string f_331 = "([A-HJ-NP-Z][0-9])(?=_|\\s|\\[|\\【|\\（|\\(|\\.+|[\\u4e00-\\u9fa5]|$)";

	internal const string f_332 = "$Обозначение$";

	internal const string f_333 = "$Наименование$";

	internal const string f_334 = "$Версия$";

	private string f_335;

	private string f_336;

	private string f_337;

	private string f_338;

	private string f_339;

	private string f_340;

	private bool f_341;

	private bool f_342;

	private bool f_343;

	private preview f_344;

	private double f_345;

	private bool f_346;

	internal virtual TableLayoutPanel p_53
	{
		get
		{
			return f_265;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_265 = value;
		}
	}

	internal virtual Button p_54
	{
		get
		{
			return f_266;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_117;
			if (f_266 != null)
			{
				f_266.Click -= value2;
			}
			f_266 = value;
			if (f_266 != null)
			{
				f_266.Click += value2;
			}
		}
	}

	internal virtual Button p_55
	{
		get
		{
			return f_267;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_118;
			if (f_267 != null)
			{
				f_267.Click -= value2;
			}
			f_267 = value;
			if (f_267 != null)
			{
				f_267.Click += value2;
			}
		}
	}

	internal virtual GroupBox p_56
	{
		get
		{
			return f_268;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_268 = value;
		}
	}

	internal virtual Label p_57
	{
		get
		{
			return f_269;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_269 = value;
		}
	}

	internal virtual Label p_58
	{
		get
		{
			return f_270;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_270 = value;
		}
	}

	internal virtual Button p_59
	{
		get
		{
			return f_271;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_128;
			if (f_271 != null)
			{
				f_271.Click -= value2;
			}
			f_271 = value;
			if (f_271 != null)
			{
				f_271.Click += value2;
			}
		}
	}

	internal virtual Button p_60
	{
		get
		{
			return f_272;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_127;
			if (f_272 != null)
			{
				f_272.Click -= value2;
			}
			f_272 = value;
			if (f_272 != null)
			{
				f_272.Click += value2;
			}
		}
	}

	internal virtual Button p_61
	{
		get
		{
			return f_273;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_126;
			if (f_273 != null)
			{
				f_273.Click -= value2;
			}
			f_273 = value;
			if (f_273 != null)
			{
				f_273.Click += value2;
			}
		}
	}

	internal virtual ComboBox p_62
	{
		get
		{
			return f_274;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_138;
			EventHandler value3 = m_137;
			MouseEventHandler value4 = m_129;
			if (f_274 != null)
			{
				f_274.TextChanged -= value2;
				f_274.DropDown -= value3;
				f_274.MouseDoubleClick -= value4;
			}
			f_274 = value;
			if (f_274 != null)
			{
				f_274.TextChanged += value2;
				f_274.DropDown += value3;
				f_274.MouseDoubleClick += value4;
			}
		}
	}

	internal virtual ComboBox p_63
	{
		get
		{
			return f_275;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_124;
			DrawItemEventHandler value3 = m_123;
			EventHandler value4 = m_122;
			EventHandler value5 = m_136;
			if (f_275 != null)
			{
				f_275.TextChanged -= value2;
				f_275.DrawItem -= value3;
				f_275.DropDownClosed -= value4;
				f_275.DropDown -= value5;
			}
			f_275 = value;
			if (f_275 != null)
			{
				f_275.TextChanged += value2;
				f_275.DrawItem += value3;
				f_275.DropDownClosed += value4;
				f_275.DropDown += value5;
			}
		}
	}

	internal virtual Button p_64
	{
		get
		{
			return f_276;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_141;
			if (f_276 != null)
			{
				f_276.Click -= value2;
			}
			f_276 = value;
			if (f_276 != null)
			{
				f_276.Click += value2;
			}
		}
	}

	internal virtual Button p_65
	{
		get
		{
			return f_277;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_143;
			if (f_277 != null)
			{
				f_277.Click -= value2;
			}
			f_277 = value;
			if (f_277 != null)
			{
				f_277.Click += value2;
			}
		}
	}

	internal virtual Button p_66
	{
		get
		{
			return f_278;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_142;
			if (f_278 != null)
			{
				f_278.Click -= value2;
			}
			f_278 = value;
			if (f_278 != null)
			{
				f_278.Click += value2;
			}
		}
	}

	internal virtual Label p_67
	{
		get
		{
			return f_279;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_279 = value;
		}
	}

	internal virtual Label p_68
	{
		get
		{
			return f_280;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = m_140;
			EventHandler value3 = m_139;
			if (f_280 != null)
			{
				f_280.MouseMove -= value2;
				f_280.Click -= value3;
			}
			f_280 = value;
			if (f_280 != null)
			{
				f_280.MouseMove += value2;
				f_280.Click += value3;
			}
		}
	}

	internal virtual TabPage p_69
	{
		get
		{
			return f_281;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_281 = value;
		}
	}

	internal virtual Panel p_70
	{
		get
		{
			return f_282;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_282 = value;
		}
	}

	internal virtual ListBox p_71
	{
		get
		{
			return f_283;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_283 = value;
		}
	}

	internal virtual Panel p_72
	{
		get
		{
			return f_284;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_284 = value;
		}
	}

	internal virtual Button p_73
	{
		get
		{
			return f_285;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_131;
			if (f_285 != null)
			{
				f_285.Click -= value2;
			}
			f_285 = value;
			if (f_285 != null)
			{
				f_285.Click += value2;
			}
		}
	}

	internal virtual Button p_74
	{
		get
		{
			return f_286;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_133;
			if (f_286 != null)
			{
				f_286.Click -= value2;
			}
			f_286 = value;
			if (f_286 != null)
			{
				f_286.Click += value2;
			}
		}
	}

	internal virtual TabPage p_75
	{
		get
		{
			return f_287;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_287 = value;
		}
	}

	internal virtual DataGridView p_76
	{
		get
		{
			return f_288;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DataGridViewCellEventHandler value2 = m_125;
			if (f_288 != null)
			{
				f_288.CellValueChanged -= value2;
			}
			f_288 = value;
			if (f_288 != null)
			{
				f_288.CellValueChanged += value2;
			}
		}
	}

	internal virtual TabPage p_77
	{
		get
		{
			return f_289;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_289 = value;
		}
	}

	internal virtual GroupBox p_78
	{
		get
		{
			return f_290;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_290 = value;
		}
	}

	internal virtual RadioButton p_79
	{
		get
		{
			return f_291;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_147;
			if (f_291 != null)
			{
				f_291.CheckedChanged -= value2;
			}
			f_291 = value;
			if (f_291 != null)
			{
				f_291.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton p_80
	{
		get
		{
			return f_292;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_147;
			if (f_292 != null)
			{
				f_292.CheckedChanged -= value2;
			}
			f_292 = value;
			if (f_292 != null)
			{
				f_292.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton p_81
	{
		get
		{
			return f_293;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_144;
			if (f_293 != null)
			{
				f_293.CheckedChanged -= value2;
			}
			f_293 = value;
			if (f_293 != null)
			{
				f_293.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton p_82
	{
		get
		{
			return f_294;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_146;
			if (f_294 != null)
			{
				f_294.CheckedChanged -= value2;
			}
			f_294 = value;
			if (f_294 != null)
			{
				f_294.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton p_83
	{
		get
		{
			return f_295;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_145;
			if (f_295 != null)
			{
				f_295.CheckedChanged -= value2;
			}
			f_295 = value;
			if (f_295 != null)
			{
				f_295.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox p_84
	{
		get
		{
			return f_296;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_296 = value;
		}
	}

	internal virtual Label p_85
	{
		get
		{
			return f_297;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = m_135;
			EventHandler value3 = m_134;
			if (f_297 != null)
			{
				f_297.MouseMove -= value2;
				f_297.Click -= value3;
			}
			f_297 = value;
			if (f_297 != null)
			{
				f_297.MouseMove += value2;
				f_297.Click += value3;
			}
		}
	}

	internal virtual CheckBox p_86
	{
		get
		{
			return f_298;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_298 = value;
		}
	}

	internal virtual CheckBox p_87
	{
		get
		{
			return f_299;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_299 = value;
		}
	}

	internal virtual CheckBox p_88
	{
		get
		{
			return f_300;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_300 = value;
		}
	}

	internal virtual TabControl p_89
	{
		get
		{
			return f_301;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_301 = value;
		}
	}

	internal virtual TabPage p_90
	{
		get
		{
			return f_302;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_302 = value;
		}
	}

	internal virtual CheckedListBox p_91
	{
		get
		{
			return f_303;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_303 = value;
		}
	}

	internal virtual Panel p_92
	{
		get
		{
			return f_304;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_304 = value;
		}
	}

	internal virtual Button p_93
	{
		get
		{
			return f_305;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_149;
			if (f_305 != null)
			{
				f_305.Click -= value2;
			}
			f_305 = value;
			if (f_305 != null)
			{
				f_305.Click += value2;
			}
		}
	}

	internal virtual Button p_94
	{
		get
		{
			return f_306;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_148;
			if (f_306 != null)
			{
				f_306.Click -= value2;
			}
			f_306 = value;
			if (f_306 != null)
			{
				f_306.Click += value2;
			}
		}
	}

	internal virtual DataGridViewCheckBoxColumn p_95
	{
		get
		{
			return f_307;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_307 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn p_96
	{
		get
		{
			return f_308;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_308 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn p_97
	{
		get
		{
			return f_309;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_309 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn p_98
	{
		get
		{
			return f_310;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_310 = value;
		}
	}

	internal virtual ToolStripMenuItem p_99
	{
		get
		{
			return f_311;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_129;
			if (f_311 != null)
			{
				f_311.Click -= value2;
			}
			f_311 = value;
			if (f_311 != null)
			{
				f_311.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem p_100
	{
		get
		{
			return f_312;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_130;
			if (f_312 != null)
			{
				f_312.Click -= value2;
			}
			f_312 = value;
			if (f_312 != null)
			{
				f_312.Click += value2;
			}
		}
	}

	internal virtual ContextMenuStrip p_101
	{
		get
		{
			return f_313;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_313 = value;
		}
	}

	internal virtual CheckBox p_102
	{
		get
		{
			return f_314;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_314 = value;
		}
	}

	internal virtual TableLayoutPanel p_103
	{
		get
		{
			return f_315;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_315 = value;
		}
	}

	internal virtual RadioButton p_104
	{
		get
		{
			return f_316;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_145;
			if (f_316 != null)
			{
				f_316.CheckedChanged -= value2;
			}
			f_316 = value;
			if (f_316 != null)
			{
				f_316.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_264 != null)
			{
				f_264.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_116()
	{
		f_264 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ReName));
		p_53 = new TableLayoutPanel();
		p_54 = new Button();
		p_55 = new Button();
		p_56 = new GroupBox();
		p_103 = new TableLayoutPanel();
		p_102 = new CheckBox();
		p_62 = new ComboBox();
		p_65 = new Button();
		p_66 = new Button();
		p_64 = new Button();
		p_63 = new ComboBox();
		p_59 = new Button();
		p_60 = new Button();
		p_61 = new Button();
		p_57 = new Label();
		p_58 = new Label();
		p_67 = new Label();
		p_68 = new Label();
		p_69 = new TabPage();
		p_70 = new Panel();
		p_71 = new ListBox();
		p_72 = new Panel();
		p_73 = new Button();
		p_74 = new Button();
		p_75 = new TabPage();
		p_76 = new DataGridView();
		p_95 = new DataGridViewCheckBoxColumn();
		p_96 = new DataGridViewTextBoxColumn();
		p_97 = new DataGridViewTextBoxColumn();
		p_98 = new DataGridViewTextBoxColumn();
		p_77 = new TabPage();
		p_78 = new GroupBox();
		p_79 = new RadioButton();
		p_80 = new RadioButton();
		p_81 = new RadioButton();
		p_82 = new RadioButton();
		p_104 = new RadioButton();
		p_83 = new RadioButton();
		p_84 = new GroupBox();
		p_85 = new Label();
		p_86 = new CheckBox();
		p_87 = new CheckBox();
		p_88 = new CheckBox();
		p_89 = new TabControl();
		p_90 = new TabPage();
		p_91 = new CheckedListBox();
		p_92 = new Panel();
		p_93 = new Button();
		p_94 = new Button();
		p_99 = new ToolStripMenuItem();
		p_100 = new ToolStripMenuItem();
		p_101 = new ContextMenuStrip(f_264);
		p_53.SuspendLayout();
		p_56.SuspendLayout();
		p_103.SuspendLayout();
		p_69.SuspendLayout();
		p_70.SuspendLayout();
		p_72.SuspendLayout();
		p_75.SuspendLayout();
		((ISupportInitialize)p_76).BeginInit();
		p_77.SuspendLayout();
		p_78.SuspendLayout();
		p_84.SuspendLayout();
		p_89.SuspendLayout();
		p_90.SuspendLayout();
		p_92.SuspendLayout();
		p_101.SuspendLayout();
		SuspendLayout();
		p_53.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		p_53.AutoSize = true;
		p_53.ColumnCount = 2;
		p_53.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		p_53.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		p_53.Controls.Add(p_54, 0, 0);
		p_53.Controls.Add(p_55, 1, 0);
		TableLayoutPanel tableLayoutPanel = p_53;
		Point location = new Point(280, 287);
		tableLayoutPanel.Location = location;
		TableLayoutPanel tableLayoutPanel2 = p_53;
		Padding margin = new Padding(3, 4, 3, 4);
		tableLayoutPanel2.Margin = margin;
		p_53.Name = "TableLayoutPanel1";
		p_53.RowCount = 1;
		p_53.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel tableLayoutPanel3 = p_53;
		Size size = new Size(198, 35);
		tableLayoutPanel3.Size = size;
		p_53.TabIndex = 1;
		p_54.Anchor = AnchorStyles.None;
		p_54.AutoSize = true;
		Button button = p_54;
		location = new Point(10, 4);
		button.Location = location;
		Button button2 = p_54;
		margin = new Padding(3, 4, 3, 4);
		button2.Margin = margin;
		p_54.Name = "OK_Button";
		Button button3 = p_54;
		size = new Size(78, 27);
		button3.Size = size;
		p_54.TabIndex = 0;
		p_54.Text = "ОК";
		p_55.Anchor = AnchorStyles.None;
		p_55.AutoSize = true;
		p_55.DialogResult = DialogResult.Cancel;
		Button button4 = p_55;
		location = new Point(109, 4);
		button4.Location = location;
		Button button5 = p_55;
		margin = new Padding(3, 4, 3, 4);
		button5.Margin = margin;
		p_55.Name = "Cancel_Button";
		Button button6 = p_55;
		size = new Size(78, 27);
		button6.Size = size;
		p_55.TabIndex = 1;
		p_55.Text = "Отмена";
		p_56.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		p_56.Controls.Add(p_103);
		p_56.Controls.Add(p_65);
		p_56.Controls.Add(p_66);
		p_56.Controls.Add(p_64);
		p_56.Controls.Add(p_63);
		p_56.Controls.Add(p_59);
		p_56.Controls.Add(p_60);
		p_56.Controls.Add(p_61);
		p_56.Controls.Add(p_57);
		p_56.Controls.Add(p_58);
		p_56.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		GroupBox groupBox = p_56;
		location = new Point(6, 6);
		groupBox.Location = location;
		GroupBox groupBox2 = p_56;
		margin = new Padding(3, 4, 3, 4);
		groupBox2.Margin = margin;
		p_56.Name = "GroupBox1";
		GroupBox groupBox3 = p_56;
		margin = new Padding(3, 4, 3, 4);
		groupBox3.Padding = margin;
		GroupBox groupBox4 = p_56;
		size = new Size(473, 123);
		groupBox4.Size = size;
		p_56.TabIndex = 2;
		p_56.TabStop = false;
		p_56.Text = "Путь";
		p_103.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		p_103.ColumnCount = 2;
		p_103.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		p_103.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		p_103.Controls.Add(p_102, 1, 0);
		p_103.Controls.Add(p_62, 0, 0);
		TableLayoutPanel tableLayoutPanel4 = p_103;
		location = new Point(90, 18);
		tableLayoutPanel4.Location = location;
		p_103.Name = "TableLayoutPanel2";
		p_103.RowCount = 1;
		p_103.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel tableLayoutPanel5 = p_103;
		size = new Size(382, 32);
		tableLayoutPanel5.Size = size;
		p_103.TabIndex = 5;
		p_102.Anchor = AnchorStyles.None;
		CheckBox checkBox = p_102;
		location = new Point(325, 6);
		checkBox.Location = location;
		CheckBox checkBox2 = p_102;
		margin = new Padding(3, 4, 3, 4);
		checkBox2.Margin = margin;
		p_102.Name = "lockpath";
		CheckBox checkBox3 = p_102;
		size = new Size(53, 20);
		checkBox3.Size = size;
		p_102.TabIndex = 2;
		p_102.Text = "Заблокировать";
		p_102.UseVisualStyleBackColor = true;
		p_62.Dock = DockStyle.Fill;
		p_62.FormattingEnabled = true;
		ComboBox comboBox = p_62;
		location = new Point(3, 4);
		comboBox.Location = location;
		ComboBox comboBox2 = p_62;
		margin = new Padding(3, 4, 3, 4);
		comboBox2.Margin = margin;
		p_62.Name = "pathname";
		p_62.RightToLeft = RightToLeft.No;
		ComboBox comboBox3 = p_62;
		size = new Size(316, 25);
		comboBox3.Size = size;
		p_62.TabIndex = 3;
		p_65.BackgroundImage = Type_26.p_47;
		p_65.BackgroundImageLayout = ImageLayout.Center;
		p_65.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Button button7 = p_65;
		location = new Point(431, 92);
		button7.Location = location;
		Button button8 = p_65;
		margin = new Padding(3, 4, 3, 4);
		button8.Margin = margin;
		p_65.Name = "Button8";
		Button button9 = p_65;
		size = new Size(30, 24);
		button9.Size = size;
		p_65.TabIndex = 4;
		p_65.UseVisualStyleBackColor = true;
		p_66.BackgroundImage = Type_26.p_47;
		p_66.BackgroundImageLayout = ImageLayout.Center;
		p_66.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Button button10 = p_66;
		location = new Point(261, 92);
		button10.Location = location;
		Button button11 = p_66;
		margin = new Padding(3, 4, 3, 4);
		button11.Margin = margin;
		p_66.Name = "Button7";
		Button button12 = p_66;
		size = new Size(30, 24);
		button12.Size = size;
		p_66.TabIndex = 4;
		p_66.UseVisualStyleBackColor = true;
		p_64.BackgroundImage = Type_26.p_47;
		p_64.BackgroundImageLayout = ImageLayout.Center;
		p_64.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Button button13 = p_64;
		location = new Point(95, 92);
		button13.Location = location;
		Button button14 = p_64;
		margin = new Padding(3, 4, 3, 4);
		button14.Margin = margin;
		p_64.Name = "Button6";
		Button button15 = p_64;
		size = new Size(30, 24);
		button15.Size = size;
		p_64.TabIndex = 4;
		p_64.UseVisualStyleBackColor = true;
		p_63.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		p_63.FormattingEnabled = true;
		ComboBox comboBox4 = p_63;
		location = new Point(92, 56);
		comboBox4.Location = location;
		ComboBox comboBox5 = p_63;
		margin = new Padding(3, 4, 3, 4);
		comboBox5.Margin = margin;
		p_63.Name = "filename";
		ComboBox comboBox6 = p_63;
		size = new Size(369, 25);
		comboBox6.Size = size;
		p_63.TabIndex = 3;
		Button button16 = p_59;
		location = new Point(343, 92);
		button16.Location = location;
		p_59.Name = "Button3";
		Button button17 = p_59;
		size = new Size(90, 24);
		button17.Size = size;
		p_59.TabIndex = 2;
		p_59.Text = "Указать путь...";
		p_59.UseVisualStyleBackColor = true;
		Button button18 = p_60;
		location = new Point(173, 92);
		button18.Location = location;
		p_60.Name = "Button2";
		Button button19 = p_60;
		size = new Size(90, 24);
		button19.Size = size;
		p_60.TabIndex = 2;
		p_60.Text = "Исходный путь";
		p_60.UseVisualStyleBackColor = true;
		Button button20 = p_61;
		location = new Point(7, 92);
		button20.Location = location;
		p_61.Name = "Button1";
		Button button21 = p_61;
		size = new Size(90, 24);
		button21.Size = size;
		p_61.TabIndex = 2;
		p_61.Text = "Как у сборки";
		p_61.UseVisualStyleBackColor = true;
		p_57.AutoSize = true;
		Label label = p_57;
		location = new Point(7, 60);
		label.Location = location;
		p_57.Name = "Label2";
		Label label2 = p_57;
		size = new Size(80, 17);
		label2.Size = size;
		p_57.TabIndex = 0;
		p_57.Text = "Сохранить с именем:";
		p_58.AutoSize = true;
		p_58.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Label label3 = p_58;
		location = new Point(7, 26);
		label3.Location = location;
		p_58.Name = "Label1";
		Label label4 = p_58;
		size = new Size(80, 17);
		label4.Size = size;
		p_58.TabIndex = 0;
		p_58.Text = "Сохранить по пути:";
		p_67.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		p_67.AutoSize = true;
		p_67.ForeColor = Color.Lime;
		Label label5 = p_67;
		location = new Point(93, 301);
		label5.Location = location;
		p_67.Name = "Label3";
		Label label6 = p_67;
		size = new Size(0, 17);
		label6.Size = size;
		p_67.TabIndex = 4;
		p_67.Tag = "";
		p_68.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		p_68.AutoSize = true;
		p_68.Font = new Font("Segoe UI", 9f, FontStyle.Italic, GraphicsUnit.Point, 204);
		p_68.ForeColor = Color.Blue;
		Label label7 = p_68;
		location = new Point(7, 298);
		label7.Location = location;
		p_68.Name = "Label4";
		Label label8 = p_68;
		size = new Size(56, 17);
		label8.Size = size;
		p_68.TabIndex = 4;
		p_68.Text = "Просмотр журнала";
		p_69.BackColor = Color.Transparent;
		p_69.Controls.Add(p_70);
		p_69.Controls.Add(p_72);
		TabPage tabPage = p_69;
		location = new Point(4, 26);
		tabPage.Location = location;
		p_69.Name = "TabPage3";
		TabPage tabPage2 = p_69;
		size = new Size(465, 116);
		tabPage2.Size = size;
		p_69.TabIndex = 2;
		p_69.Text = "Частые пути";
		p_69.UseVisualStyleBackColor = true;
		p_70.Controls.Add(p_71);
		p_70.Dock = DockStyle.Fill;
		Panel panel = p_70;
		location = new Point(0, 0);
		panel.Location = location;
		p_70.Name = "Panel2";
		Panel panel2 = p_70;
		size = new Size(398, 116);
		panel2.Size = size;
		p_70.TabIndex = 3;
		p_71.Dock = DockStyle.Fill;
		p_71.FormattingEnabled = true;
		p_71.ItemHeight = 17;
		ListBox listBox = p_71;
		location = new Point(0, 0);
		listBox.Location = location;
		ListBox listBox2 = p_71;
		margin = new Padding(3, 4, 3, 4);
		listBox2.Margin = margin;
		p_71.Name = "ListBox1";
		p_71.ScrollAlwaysVisible = true;
		p_71.SelectionMode = SelectionMode.MultiSimple;
		ListBox listBox3 = p_71;
		size = new Size(398, 116);
		listBox3.Size = size;
		p_71.TabIndex = 0;
		p_72.Controls.Add(p_73);
		p_72.Controls.Add(p_74);
		p_72.Dock = DockStyle.Right;
		Panel panel3 = p_72;
		location = new Point(398, 0);
		panel3.Location = location;
		p_72.Name = "Panel1";
		Panel panel4 = p_72;
		size = new Size(67, 116);
		panel4.Size = size;
		p_72.TabIndex = 2;
		p_73.AutoSize = true;
		Button button22 = p_73;
		location = new Point(8, 8);
		button22.Location = location;
		Button button23 = p_73;
		margin = new Padding(3, 4, 3, 4);
		button23.Margin = margin;
		p_73.Name = "Button4";
		Button button24 = p_73;
		size = new Size(50, 27);
		button24.Size = size;
		p_73.TabIndex = 1;
		p_73.Text = "Добавить";
		p_73.UseVisualStyleBackColor = true;
		p_74.AutoSize = true;
		Button button25 = p_74;
		location = new Point(8, 43);
		button25.Location = location;
		Button button26 = p_74;
		margin = new Padding(3, 4, 3, 4);
		button26.Margin = margin;
		p_74.Name = "Button5";
		Button button27 = p_74;
		size = new Size(50, 27);
		button27.Size = size;
		p_74.TabIndex = 1;
		p_74.Text = "Удалить";
		p_74.UseVisualStyleBackColor = true;
		p_75.BackColor = Color.Transparent;
		p_75.Controls.Add(p_76);
		TabPage tabPage3 = p_75;
		location = new Point(4, 26);
		tabPage3.Location = location;
		p_75.Name = "TabPage2";
		TabPage tabPage4 = p_75;
		margin = new Padding(3);
		tabPage4.Padding = margin;
		TabPage tabPage5 = p_75;
		size = new Size(465, 116);
		tabPage5.Size = size;
		p_75.TabIndex = 1;
		p_75.Text = "Разделение имени файла";
		p_75.UseVisualStyleBackColor = true;
		p_76.AllowUserToAddRows = false;
		p_76.AllowUserToDeleteRows = false;
		p_76.AllowUserToResizeRows = false;
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		p_76.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		p_76.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		p_76.BackgroundColor = Color.White;
		p_76.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		p_76.Columns.AddRange(p_95, p_96, p_97, p_98);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.NullValue = "\"\"";
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		p_76.DefaultCellStyle = dataGridViewCellStyle2;
		p_76.Dock = DockStyle.Fill;
		DataGridView dataGridView = p_76;
		location = new Point(3, 3);
		dataGridView.Location = location;
		p_76.MultiSelect = false;
		p_76.Name = "DGV1";
		p_76.RowHeadersVisible = false;
		p_76.RowTemplate.Height = 23;
		p_76.ScrollBars = ScrollBars.Both;
		DataGridView dataGridView2 = p_76;
		size = new Size(459, 110);
		dataGridView2.Size = size;
		p_76.TabIndex = 0;
		p_95.HeaderText = "";
		p_95.Name = "Column4";
		p_95.Resizable = DataGridViewTriState.False;
		p_95.Width = 25;
		dataGridViewCellStyle3.NullValue = "\"\"";
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		p_96.DefaultCellStyle = dataGridViewCellStyle3;
		p_96.HeaderText = "Имя свойства";
		p_96.MinimumWidth = 70;
		p_96.Name = "Column1";
		p_96.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewCellStyle4.NullValue = "\"\"";
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
		p_97.DefaultCellStyle = dataGridViewCellStyle4;
		p_97.HeaderText = "Значение свойства";
		p_97.MinimumWidth = 70;
		p_97.Name = "Column2";
		p_97.SortMode = DataGridViewColumnSortMode.NotSortable;
		p_97.Width = 200;
		p_98.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle5.NullValue = "\"\"";
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		p_98.DefaultCellStyle = dataGridViewCellStyle5;
		p_98.HeaderText = "Регулярное выражение";
		p_98.MinimumWidth = 100;
		p_98.Name = "Column3";
		p_98.SortMode = DataGridViewColumnSortMode.NotSortable;
		p_77.BackColor = Color.Transparent;
		p_77.Controls.Add(p_78);
		p_77.Controls.Add(p_84);
		TabPage tabPage6 = p_77;
		location = new Point(4, 26);
		tabPage6.Location = location;
		p_77.Name = "TabPage1";
		TabPage tabPage7 = p_77;
		margin = new Padding(3);
		tabPage7.Padding = margin;
		TabPage tabPage8 = p_77;
		size = new Size(465, 116);
		tabPage8.Size = size;
		p_77.TabIndex = 0;
		p_77.Text = "Основная операция";
		p_77.UseVisualStyleBackColor = true;
		p_78.Controls.Add(p_79);
		p_78.Controls.Add(p_80);
		p_78.Controls.Add(p_81);
		p_78.Controls.Add(p_82);
		p_78.Controls.Add(p_104);
		p_78.Controls.Add(p_83);
		GroupBox groupBox5 = p_78;
		location = new Point(232, 6);
		groupBox5.Location = location;
		p_78.Name = "GroupBox3";
		GroupBox groupBox6 = p_78;
		size = new Size(225, 106);
		groupBox6.Size = size;
		p_78.TabIndex = 1;
		p_78.TabStop = false;
		p_78.Text = "Операция";
		p_79.AutoSize = true;
		RadioButton radioButton = p_79;
		location = new Point(7, 76);
		radioButton.Location = location;
		p_79.Name = "RadioButton3";
		RadioButton radioButton2 = p_79;
		size = new Size(122, 21);
		radioButton2.Size = size;
		p_79.TabIndex = 0;
		p_79.Text = "Сохранить копию и открыть";
		p_79.UseVisualStyleBackColor = true;
		p_80.AutoSize = true;
		RadioButton radioButton3 = p_80;
		location = new Point(7, 48);
		radioButton3.Location = location;
		p_80.Name = "RadioButton2";
		RadioButton radioButton4 = p_80;
		size = new Size(122, 21);
		radioButton4.Size = size;
		p_80.TabIndex = 0;
		p_80.Text = "Сохранить копию и продолжить";
		p_80.UseVisualStyleBackColor = true;
		p_81.AutoSize = true;
		RadioButton radioButton5 = p_81;
		location = new Point(138, 76);
		radioButton5.Location = location;
		p_81.Name = "RadioButton5";
		RadioButton radioButton6 = p_81;
		size = new Size(50, 21);
		radioButton6.Size = size;
		p_81.TabIndex = 0;
		p_81.Text = "Заменить";
		p_81.UseVisualStyleBackColor = true;
		p_82.AutoSize = true;
		RadioButton radioButton7 = p_82;
		location = new Point(138, 48);
		radioButton7.Location = location;
		p_82.Name = "RadioButton4";
		RadioButton radioButton8 = p_82;
		size = new Size(74, 21);
		radioButton8.Size = size;
		p_82.TabIndex = 0;
		p_82.Text = "Сделать независимым";
		p_82.UseVisualStyleBackColor = true;
		p_104.AutoSize = true;
		RadioButton radioButton9 = p_104;
		location = new Point(138, 20);
		radioButton9.Location = location;
		p_104.Name = "RadioButton6";
		RadioButton radioButton10 = p_104;
		size = new Size(74, 21);
		radioButton10.Size = size;
		p_104.TabIndex = 0;
		p_104.Text = "Прямое переименование";
		p_104.UseVisualStyleBackColor = true;
		p_83.AutoSize = true;
		p_83.Checked = true;
		RadioButton radioButton11 = p_83;
		location = new Point(7, 20);
		radioButton11.Location = location;
		p_83.Name = "RadioButton1";
		RadioButton radioButton12 = p_83;
		size = new Size(62, 21);
		radioButton12.Size = size;
		p_83.TabIndex = 0;
		p_83.TabStop = true;
		p_83.Text = "Сохранить как";
		p_83.UseVisualStyleBackColor = true;
		p_84.Controls.Add(p_85);
		p_84.Controls.Add(p_86);
		p_84.Controls.Add(p_87);
		p_84.Controls.Add(p_88);
		GroupBox groupBox7 = p_84;
		location = new Point(6, 6);
		groupBox7.Location = location;
		p_84.Name = "GroupBox2";
		GroupBox groupBox8 = p_84;
		size = new Size(219, 106);
		groupBox8.Size = size;
		p_84.TabIndex = 0;
		p_84.TabStop = false;
		p_84.Text = "Выбор типа";
		p_85.AutoSize = true;
		p_85.Font = new Font("Segoe UI", 9f, FontStyle.Italic, GraphicsUnit.Point, 204);
		p_85.ForeColor = Color.Blue;
		p_85.Image = Type_26.p_48;
		p_85.ImageAlign = ContentAlignment.MiddleLeft;
		Label label9 = p_85;
		location = new Point(115, 48);
		label9.Location = location;
		p_85.Name = "CopyDrw";
		Label label10 = p_85;
		size = new Size(88, 17);
		label10.Size = size;
		p_85.TabIndex = 1;
		p_85.Text = "     Копировать чертёж";
		p_85.TextAlign = ContentAlignment.MiddleRight;
		p_85.Visible = false;
		p_86.AutoSize = true;
		CheckBox checkBox4 = p_86;
		location = new Point(7, 76);
		checkBox4.Location = location;
		p_86.Name = "CheckBox3";
		CheckBox checkBox5 = p_86;
		size = new Size(99, 21);
		checkBox5.Size = size;
		p_86.TabIndex = 0;
		p_86.Text = "Автосохранение сборки";
		p_86.UseVisualStyleBackColor = true;
		p_87.AutoSize = true;
		CheckBox checkBox6 = p_87;
		location = new Point(7, 48);
		checkBox6.Location = location;
		p_87.Name = "CheckBox2";
		CheckBox checkBox7 = p_87;
		size = new Size(87, 21);
		checkBox7.Size = size;
		p_87.TabIndex = 0;
		p_87.Text = "Включая чертежи";
		p_87.UseVisualStyleBackColor = true;
		p_88.AutoSize = true;
		CheckBox checkBox8 = p_88;
		location = new Point(7, 20);
		checkBox8.Location = location;
		p_88.Name = "CheckBox1";
		CheckBox checkBox9 = p_88;
		size = new Size(147, 21);
		checkBox9.Size = size;
		p_88.TabIndex = 0;
		p_88.Text = "Удалить исходные детали и чертежи";
		p_88.UseVisualStyleBackColor = true;
		p_89.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		p_89.Controls.Add(p_77);
		p_89.Controls.Add(p_75);
		p_89.Controls.Add(p_69);
		p_89.Controls.Add(p_90);
		p_89.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		p_89.HotTrack = true;
		TabControl tabControl = p_89;
		location = new Point(6, 136);
		tabControl.Location = location;
		p_89.Name = "TabControl1";
		p_89.SelectedIndex = 0;
		TabControl tabControl2 = p_89;
		size = new Size(473, 146);
		tabControl2.Size = size;
		p_89.TabIndex = 3;
		p_90.Controls.Add(p_91);
		p_90.Controls.Add(p_92);
		TabPage tabPage9 = p_90;
		location = new Point(4, 26);
		tabPage9.Location = location;
		p_90.Name = "TabPage4";
		TabPage tabPage10 = p_90;
		size = new Size(465, 116);
		tabPage10.Size = size;
		p_90.TabIndex = 3;
		p_90.Text = "Обновить папку ссылок";
		p_90.UseVisualStyleBackColor = true;
		p_91.Dock = DockStyle.Fill;
		p_91.FormattingEnabled = true;
		CheckedListBox checkedListBox = p_91;
		location = new Point(0, 0);
		checkedListBox.Location = location;
		p_91.Name = "CListBox1";
		CheckedListBox checkedListBox2 = p_91;
		size = new Size(392, 116);
		checkedListBox2.Size = size;
		p_91.TabIndex = 5;
		p_92.Controls.Add(p_93);
		p_92.Controls.Add(p_94);
		p_92.Dock = DockStyle.Right;
		Panel panel5 = p_92;
		location = new Point(392, 0);
		panel5.Location = location;
		p_92.Name = "Panel3";
		Panel panel6 = p_92;
		size = new Size(73, 116);
		panel6.Size = size;
		p_92.TabIndex = 4;
		Button button28 = p_93;
		location = new Point(8, 8);
		button28.Location = location;
		Button button29 = p_93;
		margin = new Padding(3, 4, 3, 4);
		button29.Margin = margin;
		p_93.Name = "Button9";
		Button button30 = p_93;
		size = new Size(50, 24);
		button30.Size = size;
		p_93.TabIndex = 1;
		p_93.Text = "Добавить";
		p_93.UseVisualStyleBackColor = true;
		Button button31 = p_94;
		location = new Point(8, 40);
		button31.Location = location;
		Button button32 = p_94;
		margin = new Padding(3, 4, 3, 4);
		button32.Margin = margin;
		p_94.Name = "Button10";
		Button button33 = p_94;
		size = new Size(50, 24);
		button33.Size = size;
		p_94.TabIndex = 1;
		p_94.Text = "Удалить";
		p_94.UseVisualStyleBackColor = true;
		p_99.Name = "fromdisk";
		ToolStripMenuItem toolStripMenuItem = p_99;
		size = new Size(172, 22);
		toolStripMenuItem.Size = size;
		p_99.Text = "Выбрать с диска";
		p_100.Name = "sameassel";
		ToolStripMenuItem toolStripMenuItem2 = p_100;
		size = new Size(172, 22);
		toolStripMenuItem2.Size = size;
		p_100.Text = "В папке выбранной детали";
		p_101.Items.AddRange(new ToolStripItem[2] { p_99, p_100 });
		p_101.Name = "Savemenu";
		ContextMenuStrip contextMenuStrip = p_101;
		size = new Size(173, 48);
		contextMenuStrip.Size = size;
		AcceptButton = p_54;
		SizeF sizeF = new SizeF(96f, 96f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Dpi;
		BackColor = SystemColors.Control;
		CancelButton = p_55;
		size = new Size(760, 430);
		ClientSize = size;
		Controls.Add(p_68);
		Controls.Add(p_67);
		Controls.Add(p_89);
		Controls.Add(p_56);
		Controls.Add(p_53);
		Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		KeyPreview = true;
		margin = new Padding(3, 4, 3, 4);
		Margin = margin;
		FormBorderStyle = FormBorderStyle.Sizable;
		MaximizeBox = true;
		MinimizeBox = false;
		MaximumSize = Size.Empty;
		SizeGripStyle = SizeGripStyle.Show;
		size = new Size(760, 460);
		MinimumSize = size;
		Name = "ReName";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = " ";
		p_53.ResumeLayout(performLayout: false);
		p_53.PerformLayout();
		p_56.ResumeLayout(performLayout: false);
		p_56.PerformLayout();
		p_103.ResumeLayout(performLayout: false);
		p_69.ResumeLayout(performLayout: false);
		p_70.ResumeLayout(performLayout: false);
		p_72.ResumeLayout(performLayout: false);
		p_72.PerformLayout();
		p_75.ResumeLayout(performLayout: false);
		((ISupportInitialize)p_76).EndInit();
		p_77.ResumeLayout(performLayout: false);
		p_78.ResumeLayout(performLayout: false);
		p_78.PerformLayout();
		p_84.ResumeLayout(performLayout: false);
		p_84.PerformLayout();
		p_89.ResumeLayout(performLayout: false);
		p_90.ResumeLayout(performLayout: false);
		p_92.ResumeLayout(performLayout: false);
		p_101.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public ReName()
	{
		base.FormClosed += m_119;
		base.KeyUp += m_120;
		base.Load += m_121;
		f_344 = new preview();
		f_346 = false;
		Type_16.m_52();
		m_116();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			f_345 = graphics.DpiX / 96f;
		}
		ConfigureResponsiveLayout();
		checked
		{
			int num = p_76.ColumnCount - 1;
			for (int i = 0; i <= num; i++)
			{
				p_76.Columns[i].MinimumWidth = (int)Math.Round((double)p_76.Columns[i].MinimumWidth * f_345);
				p_76.Columns[i].Width = (int)Math.Round((double)p_76.Columns[i].Width * f_345);
			}
		}
	}

	private int Dpi(int value)
	{
		return (int)Math.Round((double)value * f_345);
	}

	private void ConfigureResponsiveLayout()
	{
		Font font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		ApplyFont(this, font);
		p_68.Font = new Font("Segoe UI", 9f, FontStyle.Italic, GraphicsUnit.Point, 204);
		p_85.Font = new Font("Segoe UI", 9f, FontStyle.Italic, GraphicsUnit.Point, 204);
		FormBorderStyle = FormBorderStyle.Sizable;
		MaximizeBox = true;
		MaximumSize = Size.Empty;
		MinimumSize = new Size(Dpi(760), Dpi(460));
		SizeGripStyle = SizeGripStyle.Show;
		if (ClientSize.Width < Dpi(760) || ClientSize.Height < Dpi(430))
		{
			ClientSize = new Size(Math.Max(ClientSize.Width, Dpi(760)), Math.Max(ClientSize.Height, Dpi(430)));
		}
		base.Resize += m_ResponsiveResize;
		ApplyResponsiveLayout();
	}

	private void ApplyFont(Control control, Font font)
	{
		control.Font = font;
		foreach (Control control2 in control.Controls)
		{
			ApplyFont(control2, font);
		}
	}

	private void m_ResponsiveResize(object P_0, EventArgs P_1)
	{
		ApplyResponsiveLayout();
	}

	private void ApplyResponsiveLayout()
	{
		if (p_56 == null || p_89 == null)
		{
			return;
		}
		int num = Dpi(8);
		int num2 = Dpi(132);
		int num3 = Dpi(30);
		int num4 = Dpi(130);
		p_56.SetBounds(num, num, ClientSize.Width - num * 2, Dpi(130));
		p_58.SetBounds(num, Dpi(28), num4, Dpi(22));
		p_57.SetBounds(num, Dpi(62), num4, Dpi(22));
		int num5 = num + num4;
		p_103.SetBounds(num5, Dpi(18), p_56.Width - num5 - num, Dpi(32));
		p_103.ColumnStyles.Clear();
		p_103.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		p_103.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(145)));
		p_102.Anchor = AnchorStyles.Left;
		p_102.AutoSize = true;
		p_62.Dock = DockStyle.Fill;
		p_63.SetBounds(num5, Dpi(58), p_56.Width - num5 - num, Dpi(25));
		int num6 = Dpi(94);
		p_61.SetBounds(num, num6, num2, Dpi(28));
		p_64.SetBounds(p_61.Right + Dpi(4), num6, num3, Dpi(28));
		p_60.SetBounds(p_64.Right + Dpi(26), num6, Dpi(140), Dpi(28));
		p_66.SetBounds(p_60.Right + Dpi(4), num6, num3, Dpi(28));
		p_59.SetBounds(p_66.Right + Dpi(26), num6, Dpi(130), Dpi(28));
		p_65.SetBounds(p_59.Right + Dpi(4), num6, num3, Dpi(28));
		int num7 = p_56.Bottom + Dpi(8);
		p_89.SetBounds(num, num7, ClientSize.Width - num * 2, Math.Max(Dpi(180), ClientSize.Height - num7 - Dpi(58)));
		p_72.Width = Dpi(96);
		p_92.Width = Dpi(96);
		p_73.SetBounds(Dpi(8), Dpi(8), Dpi(80), Dpi(28));
		p_74.SetBounds(Dpi(8), Dpi(44), Dpi(80), Dpi(28));
		p_93.SetBounds(Dpi(8), Dpi(8), Dpi(80), Dpi(28));
		p_94.SetBounds(Dpi(8), Dpi(44), Dpi(80), Dpi(28));
		p_76.ScrollBars = ScrollBars.Both;
		p_96.Width = Dpi(155);
		p_97.Width = Dpi(190);
		p_98.MinimumWidth = Dpi(260);
		p_84.SetBounds(Dpi(8), Dpi(8), Dpi(270), Dpi(118));
		p_78.SetBounds(Dpi(292), Dpi(8), Math.Max(Dpi(430), p_77.ClientSize.Width - Dpi(304)), Dpi(118));
		p_88.AutoSize = false;
		p_88.Size = new Size(Dpi(245), Dpi(24));
		p_87.AutoSize = false;
		p_87.Size = new Size(Dpi(220), Dpi(24));
		p_86.AutoSize = false;
		p_86.Size = new Size(Dpi(230), Dpi(24));
		p_83.AutoSize = false;
		p_83.Size = new Size(Dpi(190), Dpi(24));
		p_80.AutoSize = false;
		p_80.Size = new Size(Dpi(260), Dpi(24));
		p_79.AutoSize = false;
		p_79.Size = new Size(Dpi(250), Dpi(24));
		p_104.AutoSize = false;
		p_104.Size = new Size(Dpi(210), Dpi(24));
		p_82.AutoSize = false;
		p_82.Size = new Size(Dpi(210), Dpi(24));
		p_81.AutoSize = false;
		p_81.Size = new Size(Dpi(150), Dpi(24));
		p_68.SetBounds(num, ClientSize.Height - Dpi(32), Dpi(170), Dpi(22));
		p_67.SetBounds(Dpi(180), ClientSize.Height - Dpi(32), ClientSize.Width - Dpi(410), Dpi(22));
		p_53.SetBounds(ClientSize.Width - Dpi(212), ClientSize.Height - Dpi(40), Dpi(204), Dpi(36));
		p_54.Size = new Size(Dpi(86), Dpi(28));
		p_55.Size = new Size(Dpi(86), Dpi(28));
	}

	private string NormalizeRenameFieldName(string value, string fallback)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return fallback;
		}
		string text = value.Trim();
		switch (text)
		{
		case "$\u56fe\u53f7$":
		case "%\u56fe\u53f7%":
			return "$Обозначение$";
		case "$\u96f6\u4ef6\u540d\u79f0$":
		case "%\u96f6\u4ef6\u540d\u79f0%":
			return "$Наименование$";
		case "$\u7248\u672c$":
		case "%\u7248\u672c%":
			return "$Версия$";
		default:
			return text;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void m_117(object P_0, EventArgs P_1)
	{
		string text = null;
		string text2 = null;
		string[] array = null;
		string[] array2 = null;
		if (Operators.CompareString(p_63.Text, "", TextCompare: false) == 0)
		{
			return;
		}
		checked
		{
			try
			{
				f_346 = f_321.GetSaveFlag();
				if (Operators.ConditionalCompareObjectEqual(p_76[0, 0].Value, true, TextCompare: false))
				{
					AddProp(f_321, Convert.ToString(RuntimeHelpers.GetObjectValue(p_76[1, 0].Value)), Convert.ToString(RuntimeHelpers.GetObjectValue(p_76[2, 0].Value)));
				}
				if (Operators.ConditionalCompareObjectEqual(p_76[0, 1].Value, true, TextCompare: false))
				{
					AddProp(f_321, Convert.ToString(RuntimeHelpers.GetObjectValue(p_76[1, 1].Value)), Convert.ToString(RuntimeHelpers.GetObjectValue(p_76[2, 1].Value)));
				}
				if (Operators.ConditionalCompareObjectEqual(p_76[0, 2].Value, true, TextCompare: false))
				{
					AddProp(f_321, Convert.ToString(RuntimeHelpers.GetObjectValue(p_76[1, 2].Value)), Convert.ToString(RuntimeHelpers.GetObjectValue(p_76[2, 2].Value)));
				}
				string fullName = p_62.Text;
				if (!Directory.Exists(p_62.Text) & !p_81.Checked)
				{
					if (MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Путь \"" + p_62.Text + "\" не существует, создать?", "Запрос", MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						return;
					}
					fullName = Directory.CreateDirectory(p_62.Text).FullName;
				}
				text = Path.Combine(fullName, p_63.Text + Type_16.m_53(p_62.Tag.ToString(), 5));
				text2 = Convert.ToString(RuntimeHelpers.GetObjectValue(p_62.Tag));
				if (!Directory.Exists(Type_16.f_62))
				{
					Directory.CreateDirectory(Type_16.f_62);
				}
				bool flag = false;
				if (p_83.Checked && !f_328)
				{
					if (!RenameParts(f_321, text, text2, p_87.Checked, p_88.Checked, 4))
					{
						return;
					}
					f_318.CloseDoc(text2);
					p_62.Tag = text;
					p_67.Text = "Обновление ссылок, подождите...";
					p_67.Refresh();
					Updatereference2(f_321, text, text2);
					if (f_326)
					{
						if (p_86.Checked)
						{
							f_319.Save();
						}
						else
						{
							f_319.SetSaveFlag();
						}
					}
					f_319.ForceRebuild3(TopOnly: true);
					Type_19.m_79(DateTime.Now.ToString("G") + "\nТип операции: Сохранить как\nИсходное имя:" + text2 + "\nНовое имя:" + text, Type_16.f_63);
					Type_19.m_79("**************************************************", Type_16.f_63);
				}
				else if (p_83.Checked && f_328)
				{
					if (!RenameParts(f_321, text, text2, p_87.Checked, p_88.Checked, 4))
					{
						return;
					}
					f_328 = false;
				}
				else if (p_104.Checked && !f_328)
				{
					if (!ReName2(f_321, text, text2, p_87.Checked, p_88.Checked))
					{
						return;
					}
					p_62.Tag = text;
					p_67.Text = "Обновление ссылок, подождите...";
					p_67.Refresh();
					Updatereference2(f_321, text, text2);
					if (f_326)
					{
						if (p_86.Checked)
						{
							f_319.Save();
						}
						else
						{
							f_319.SetSaveFlag();
						}
					}
					f_319.ForceRebuild3(TopOnly: true);
					Type_19.m_79(DateTime.Now.ToString("G") + "\nТип операции: Переименование\nИсходное имя:" + text2 + "\nНовое имя:" + text, Type_16.f_63);
					Type_19.m_79("**************************************************", Type_16.f_63);
				}
				else if (p_80.Checked)
				{
					if (!RenameParts(f_321, text, text2, p_87.Checked, DelOld: false, 2))
					{
						return;
					}
					Type_19.m_79(DateTime.Now.ToString("G") + "\nТип операции: Сохранить копию\nИсходный файл:" + text2 + "\nНовый файл:" + text, Type_16.f_63);
					Type_19.m_79("**************************************************", Type_16.f_63);
					f_318.CloseDoc(text);
				}
				else if (p_79.Checked)
				{
					if (IsOpen(text))
					{
						MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Файл с именем \"" + Type_16.m_53(text, 4) + "\" уже открыт, измените имя на другое", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (!RenameParts(f_321, text, text2, p_87.Checked, DelOld: false, 2))
					{
						return;
					}
					object objectValue = RuntimeHelpers.GetObjectValue(f_318.OpenDoc(text, f_321.GetType()));
					f_318.ActivateDoc(text);
					Type_19.m_79(DateTime.Now.ToString("G") + "\nТип операции: Сохранить копию и открыть\nИсходный файл:" + text2 + "\nНовый файл:" + text, Type_16.f_63);
					Type_19.m_79("**************************************************", Type_16.f_63);
				}
				else if (p_82.Checked)
				{
					if (!RenameParts(f_321, text, text2, p_87.Checked, DelOld: false, 2))
					{
						return;
					}
					f_319.ClearSelection2(All: true);
					List<string> list = new List<string>();
					int num = Information.UBound(f_327);
					for (int i = 0; i <= num; i++)
					{
						f_319.Extension.SelectByID2(f_327[i].GetSelectByIDString(), "COMPONENT", 0.0, 0.0, 0.0, Append: true, 0, null, 0);
						list.Add(f_327[i].GetPathName());
					}
					ModelDoc2 instance = f_319;
					object[] array3 = new object[4] { text, "", false, true };
					object[] arguments = array3;
					bool[] array4 = new bool[4] { true, false, false, false };
					object value = NewLateBinding.LateGet(instance, null, "ReplaceComponents", arguments, null, null, array4);
					if (array4[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
					}
					if (Conversions.ToBoolean(value))
					{
						int num2 = Information.UBound(f_327);
						for (int i = 0; i <= num2; i++)
						{
							Type_19.m_79(DateTime.Now.ToString("G") + "\nТип операции: Сделать независимым\nНезависимые элементы:" + f_327[i].GetSelectByIDString() + "\nИсходное имя:" + list[i] + "\nНовое имя:" + text, Type_16.f_63);
							Type_19.m_79("**************************************************", Type_16.f_63);
							f_318.CloseDoc(f_327[i].GetPathName());
						}
						f_327 = new Component2[1];
						if (f_326)
						{
							if (p_86.Checked)
							{
								f_319.Save();
							}
							else
							{
								f_319.SetSaveFlag();
							}
						}
						f_319.ForceRebuild3(TopOnly: true);
					}
				}
				else if (p_81.Checked)
				{
					ModelDoc2 modelDoc = (ModelDoc2)f_318.ActiveDoc;
					if (modelDoc == null)
					{
						return;
					}
					modelDoc.Save();
					if (Operators.CompareString(FileSystem.Dir(text), "", TextCompare: false) == 0)
					{
						MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), text + "не существует", "Информация", MessageBoxButtons.OK);
						return;
					}
					if (modelDoc.GetType() != 2)
					{
						MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Выберите в сборке детали для замены, можно несколько", "Информация", MessageBoxButtons.OK);
						return;
					}
					SelectionMgr selectionMgr = (SelectionMgr)modelDoc.SelectionManager;
					if (selectionMgr.GetSelectedObjectCount() < 1)
					{
						MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Выберите детали для замены (можно несколько)", "Информация", MessageBoxButtons.OK);
						return;
					}
					int selectedObjectCount = selectionMgr.GetSelectedObjectCount2(-1);
					object[] array6;
					bool[] array4;
					if (selectedObjectCount >= 1)
					{
						array = new string[selectedObjectCount - 1 + 1];
						array2 = new string[selectedObjectCount - 1 + 1];
						int num3 = selectedObjectCount;
						for (int i = 1; i <= num3; i++)
						{
							string[] array5 = array;
							int num4 = i - 1;
							SelectionMgr instance2 = selectionMgr;
							array6 = new object[2] { i, -1 };
							object[] arguments2 = array6;
							array4 = new bool[2] { true, false };
							object instance3 = NewLateBinding.LateGet(instance2, null, "GetSelectedObjectsComponent4", arguments2, null, null, array4);
							if (array4[0])
							{
								i = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[0]), typeof(int));
							}
							array5[num4] = Conversions.ToString(NewLateBinding.LateGet(instance3, null, "GetPathName", new object[0], null, null, null));
							string[] array7 = array2;
							int num5 = i - 1;
							SelectionMgr instance4 = selectionMgr;
							array6 = new object[2] { i, -1 };
							object[] arguments3 = array6;
							array4 = new bool[2] { true, false };
							object instance5 = NewLateBinding.LateGet(instance4, null, "GetSelectedObjectsComponent4", arguments3, null, null, array4);
							if (array4[0])
							{
								i = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[0]), typeof(int));
							}
							array7[num5] = Conversions.ToString(NewLateBinding.LateGet(instance5, null, "GetSelectByIDString", new object[0], null, null, null));
						}
						if ((selectedObjectCount == 1) & (Operators.CompareString(array[0], text, TextCompare: false) == 0))
						{
							MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Выберите детали для замены, можно несколько", "Информация", MessageBoxButtons.OK);
							return;
						}
					}
					bool flag2 = false;
					if (MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Заменить все экземпляры", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						flag2 = true;
					}
					modelDoc.ClearSelection2(All: true);
					int num6 = Information.UBound(array2);
					for (int i = 0; i <= num6; i++)
					{
						modelDoc.Extension.SelectByID2(array2[i], "COMPONENT", 0.0, 0.0, 0.0, Append: true, 0, null, 0);
					}
					ModelDoc2 instance6 = modelDoc;
					array6 = new object[4] { text, "", flag2, true };
					object[] arguments4 = array6;
					array4 = new bool[4] { true, false, true, false };
					object value2 = NewLateBinding.LateGet(instance6, null, "ReplaceComponents", arguments4, null, null, array4);
					if (array4[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[0]), typeof(string));
					}
					if (array4[2])
					{
						flag2 = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[2]), typeof(bool));
					}
					if (Conversions.ToBoolean(value2))
					{
						if (MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Нажмите \"Y\" для подтверждения и сохранения\nНажмите \"N\" для отмены", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							int num7 = Information.UBound(array);
							for (int i = 0; i <= num7; i++)
							{
								Type_19.m_79(DateTime.Now.ToString("G") + "\nТип операции: Замена\nЗаменяемые элементы:" + f_327[i].GetSelectByIDString() + "\nИсходный файл:" + array[i] + "\nЗаменить на:" + text, Type_16.f_63);
								Type_19.m_79("**************************************************", Type_16.f_63);
								f_318.CloseDoc(array[i]);
							}
							modelDoc.Save();
						}
						else
						{
							string pathName = modelDoc.GetPathName();
							if (File.Exists(pathName))
							{
								modelDoc.ReloadOrReplace(ReadOnly: false, pathName, DiscardChanges: true);
							}
						}
						modelDoc.ForceRebuild3(TopOnly: true);
					}
				}
				Close();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					SelectionMgr selectionMgr = null;
					ModelDoc2 modelDoc = null;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	private void m_118(object P_0, EventArgs P_1)
	{
		Close();
	}

	private void m_119(object P_0, FormClosedEventArgs P_1)
	{
		checked
		{
			try
			{
				f_319 = null;
				f_321 = null;
				f_318 = null;
				SwAddin.f_379 = null;
				Rectangle workingArea = Screen.GetWorkingArea(this);
				if ((double)Left + (double)Width * 0.25 < (double)workingArea.Width && (double)Top + (double)Height * 0.25 < (double)workingArea.Height && (double)Left + (double)Width * 0.75 > 0.0 && (double)Top + (double)Height * 0.75 > 0.0)
				{
					Type_16.m_62("ReName", "Left", Conversions.ToString(Left));
					Type_16.m_62("ReName", "Top", Conversions.ToString(Top));
				}
				Type_16.m_62("ReName", "deloldswdocs", p_88.Checked.ToString());
				Type_16.m_62("ReName", "withslddrw", p_87.Checked.ToString());
				Type_16.m_62("ReName", "SaveTopAsm", p_86.Checked.ToString());
				Type_16.m_62("ReName", "lockpath", p_102.Checked.ToString());
				Type_16.m_62("ReName", "lastpath", p_62.Text);
				if (p_83.Checked)
				{
					Type_16.m_62("ReName", "savetype", Conversions.ToString(1));
				}
				else if (p_80.Checked)
				{
					Type_16.m_62("ReName", "savetype", Conversions.ToString(2));
				}
				else if (p_79.Checked)
				{
					Type_16.m_62("ReName", "savetype", Conversions.ToString(3));
				}
				else if (p_82.Checked)
				{
					Type_16.m_62("ReName", "savetype", Conversions.ToString(4));
				}
				else if (p_81.Checked)
				{
					Type_16.m_62("ReName", "savetype", Conversions.ToString(5));
				}
				else if (p_104.Checked)
				{
					Type_16.m_62("ReName", "savetype", Conversions.ToString(6));
				}
				if (p_76.ColumnCount >= 4 && p_76.RowCount >= 3)
				{
					Type_16.m_62("ReName", "FieldName1", Conversions.ToString(p_76[1, 0].Value));
					Type_16.m_62("ReName", "FieldName2", Conversions.ToString(p_76[1, 1].Value));
					Type_16.m_62("ReName", "FieldName3", Conversions.ToString(p_76[1, 2].Value));
					Type_16.m_62("ReName", "RegxPattern1", Conversions.ToString(p_76[3, 0].Value));
					Type_16.m_62("ReName", "RegxPattern2", Conversions.ToString(p_76[3, 1].Value));
					Type_16.m_62("ReName", "RegxPattern3", Conversions.ToString(p_76[3, 2].Value));
					Type_16.m_62("ReName", "ckb1", Conversions.ToString(p_76[0, 0].Value));
					Type_16.m_62("ReName", "ckb2", Conversions.ToString(p_76[0, 1].Value));
					Type_16.m_62("ReName", "ckb3", Conversions.ToString(p_76[0, 2].Value));
				}
				StringBuilder stringBuilder = new StringBuilder();
				int num = p_71.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					stringBuilder.AppendLine(p_71.Items[i].ToString());
				}
				Type_16.m_62("ReName", "pathname", stringBuilder.ToString().Trim());
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка22", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			f_343 = false;
		}
	}

	private void m_120(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyData == Keys.Escape)
		{
			Close();
		}
	}

	private void m_121(object P_0, EventArgs P_1)
	{
		bool data = GetData();
		bool flag = default(bool);
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		try
		{
			f_335 = NormalizeRenameFieldName(Type_16.m_63("ReName", "FieldName1"), "$Обозначение$");
			f_336 = NormalizeRenameFieldName(Type_16.m_63("ReName", "FieldName2"), "$Наименование$");
			f_337 = NormalizeRenameFieldName(Type_16.m_63("ReName", "FieldName3"), "$Версия$");
			f_338 = Type_16.m_63("ReName", "RegxPattern1");
			f_338 = Conversions.ToString(Interaction.IIf(Operators.CompareString(f_338, "", TextCompare: false) != 0, f_338, "[\\S*]+[A-Za-z0-9]"));
			f_339 = Type_16.m_63("ReName", "RegxPattern2");
			f_339 = Conversions.ToString(Interaction.IIf(Operators.CompareString(f_339, "", TextCompare: false) != 0, f_339, "((?<=\\s)[A-Za-z0-9\\u4e00-\\u9fa5]+$)|([A-Za-z0-9\\u4e00-\\u9fa5]+(?=\\]$|\\】$|\\)$|\\）$))|([\\u4e00-\\u9fa5][A-Za-z0-9\\u4e00-\\u9fa5]+$)"));
			f_340 = Type_16.m_63("ReName", "RegxPattern3");
			f_340 = Conversions.ToString(Interaction.IIf(Operators.CompareString(f_340, "", TextCompare: false) != 0, f_340, "([A-HJ-NP-Z][0-9])(?=_|\\s|\\[|\\【|\\（|\\(|\\.+|[\\u4e00-\\u9fa5]|$)"));
			flag = Type_16.m_58(Type_16.m_63("ReName", "ckb1"));
			flag2 = Type_16.m_58(Type_16.m_63("ReName", "ckb2"));
			flag3 = Type_16.m_58(Type_16.m_63("ReName", "ckb3"));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			DataGridView dataGridView = p_76;
			dataGridView.RowCount = 3;
			dataGridView.Rows[0].Cells[0].Value = flag;
			dataGridView.Rows[1].Cells[0].Value = flag2;
			dataGridView.Rows[2].Cells[0].Value = flag3;
			dataGridView.Rows[0].Cells[1].Value = f_335;
			dataGridView.Rows[0].Cells[1].ToolTipText = "$ИмяСвойства$ — свойство файла\n%ИмяСвойства% — свойство конфигурации";
			dataGridView.Rows[1].Cells[1].Value = f_336;
			dataGridView.Rows[1].Cells[1].ToolTipText = "$ИмяСвойства$ — свойство файла\n%ИмяСвойства% — свойство конфигурации";
			dataGridView.Rows[2].Cells[1].Value = f_337;
			dataGridView.Rows[2].Cells[1].ToolTipText = "$ИмяСвойства$ — свойство файла\n%ИмяСвойства% — свойство конфигурации";
			dataGridView.Rows[0].Cells[3].Value = f_338;
			dataGridView.Rows[1].Cells[3].Value = f_339;
			dataGridView.Rows[2].Cells[3].Value = f_340;
			dataGridView.Rows[0].Cells[2].Value = Regex.Match(p_63.Text, f_338).ToString();
			dataGridView.Rows[1].Cells[2].Value = Regex.Match(p_63.Text, f_339).ToString();
			dataGridView.Rows[2].Cells[2].Value = Regex.Match(p_63.Text, f_340).ToString();
			dataGridView.Rows[0].Cells[2].Tag = Regex.Match(Convert.ToString(RuntimeHelpers.GetObjectValue(p_63.Tag)), f_338).ToString();
			dataGridView.Rows[1].Cells[2].Tag = Regex.Match(Convert.ToString(RuntimeHelpers.GetObjectValue(p_63.Tag)), f_339).ToString();
			dataGridView.Rows[2].Cells[2].Tag = Regex.Match(Convert.ToString(RuntimeHelpers.GetObjectValue(p_63.Tag)), f_340).ToString();
			dataGridView.ClearSelection();
			dataGridView = null;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		checked
		{
			try
			{
				p_88.Checked = Type_16.m_58(Type_16.m_63("ReName", "deloldswdocs"));
				p_87.Checked = Type_16.m_58(Type_16.m_63("ReName", "withslddrw"));
				p_86.Checked = Type_16.m_58(Type_16.m_63("ReName", "SaveTopAsm"));
				if (Type_16.m_58(Type_16.m_63("ReName", "lockpath")))
				{
					p_102.Checked = true;
					p_62.Text = Type_16.m_63("ReName", "lastpath");
				}
				string left = Type_16.m_63("ReName", "savetype");
				if (Operators.CompareString(left, Conversions.ToString(1), TextCompare: false) == 0)
				{
					if (p_83.Enabled)
					{
						p_83.Checked = true;
					}
				}
				else if (Operators.CompareString(left, Conversions.ToString(2), TextCompare: false) == 0)
				{
					if (p_80.Enabled)
					{
						p_80.Checked = true;
					}
				}
				else if (Operators.CompareString(left, Conversions.ToString(3), TextCompare: false) == 0)
				{
					if (p_79.Enabled)
					{
						p_79.Checked = true;
					}
				}
				else if (Operators.CompareString(left, Conversions.ToString(4), TextCompare: false) == 0)
				{
					if (p_82.Enabled)
					{
						p_82.Checked = true;
					}
				}
				else if (Operators.CompareString(left, Conversions.ToString(5), TextCompare: false) == 0)
				{
					if (p_81.Enabled)
					{
						p_81.Checked = true;
					}
				}
				else if (Operators.CompareString(left, Conversions.ToString(6), TextCompare: false) == 0 && p_104.Enabled)
				{
					p_104.Checked = true;
				}
				Left = (int)Math.Round(Conversion.Val(Type_16.m_63("ReName", "Left")));
				Top = (int)Math.Round(Conversion.Val(Type_16.m_63("ReName", "Top")));
				StartPosition = FormStartPosition.Manual;
				Rectangle workingArea = Screen.GetWorkingArea(this);
				if ((double)Left + (double)Width * 0.25 > (double)workingArea.Width || (double)Top + (double)Height * 0.25 > (double)workingArea.Height || (double)Left + (double)Width * 0.75 < 0.0 || (double)Top + (double)Height * 0.75 < 0.0)
				{
					Left = 0;
					Top = 0;
				}
				p_71.Items.Clear();
				string text = Type_16.m_63("ReName", "pathname");
				if (Operators.CompareString(text, "", TextCompare: false) != 0)
				{
					p_71.Items.AddRange(Strings.Split(text, "\r\n"));
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				MessageBox.Show(ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				p_63.DrawMode = DrawMode.OwnerDrawFixed;
				ToolTip toolTip = new ToolTip();
				toolTip.SetToolTip(p_85, "Перед операцией выберите в сборке связываемую деталь, иначе выбор будет с диска");
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ProjectData.ClearProjectError();
			}
			f_341 = false;
			f_342 = false;
			f_343 = true;
			if (!data)
			{
				MessageBox.Show("Не удалось получить детали!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Close();
			}
		}
	}

	private void m_122(object P_0, EventArgs P_1)
	{
		f_344.Hide();
	}

	private void m_123(object P_0, DrawItemEventArgs P_1)
	{
		try
		{
			ComboBox comboBox = P_0 as ComboBox;
			string text = comboBox.Items[P_1.Index].ToString();
			string filePathName = Path.Combine(p_62.Text, text + Type_16.m_53(p_62.Tag.ToString(), 5));
			string path = Path.Combine(p_62.Text, text + ".slddrw");
			Brush brush = Brushes.Black;
			if (P_1.Index < 0)
			{
				return;
			}
			if ((P_1.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				brush = Brushes.White;
				string activeConfigurationName = f_318.GetActiveConfigurationName(filePathName);
				IPictureDisp pictureDisp = (IPictureDisp)f_318.GetPreviewBitmap(filePathName, activeConfigurationName);
				if (!Information.IsNothing(pictureDisp))
				{
					f_344.p_50.Text = filePathName;
					f_344.p_52.Visible = File.Exists(path);
					IntPtr hbitmap = new IntPtr(pictureDisp.Handle);
					Image image = Image.FromHbitmap(hbitmap);
					image = Type_19.m_76(image, 381);
					image = Type_19.m_77((Bitmap)image, 0.75);
					f_344.p_51.Image = image;
					Type_16.m_51(f_344.Handle, checked(Left + Width), Top, f_344.Width, f_344.Height, true);
					Type_16.m_50(f_344.Handle, 8);
					pictureDisp = null;
				}
				else
				{
					f_344.Hide();
				}
			}
			P_1.DrawBackground();
			P_1.Graphics.DrawString(text, new Font("Segoe UI", 9f, comboBox.Font.Style), brush, P_1.Bounds.X, P_1.Bounds.Y);
			P_1.DrawFocusRectangle();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void m_124(object P_0, EventArgs P_1)
	{
		if (!f_343)
		{
			return;
		}
		try
		{
			f_338 = p_76[3, 0].Value.ToString();
			f_339 = p_76[3, 1].Value.ToString();
			f_340 = p_76[3, 2].Value.ToString();
			p_76[2, 0].Value = Regex.Match(p_63.Text, f_338).ToString();
			p_76[2, 1].Value = Regex.Match(p_63.Text, f_339).ToString();
			p_76[2, 2].Value = Regex.Match(p_63.Text, f_340).ToString();
			p_76[2, 0].Tag = Regex.Match(Conversions.ToString(p_63.Tag), f_338).ToString();
			p_76[2, 1].Tag = Regex.Match(Conversions.ToString(p_63.Tag), f_339).ToString();
			p_76[2, 2].Tag = Regex.Match(Conversions.ToString(p_63.Tag), f_340).ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void m_125(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (!f_343)
		{
			return;
		}
		try
		{
			if ((P_1.ColumnIndex == 3) & (P_1.RowIndex >= 0))
			{
				f_338 = p_76[3, 0].Value.ToString();
				f_339 = p_76[3, 1].Value.ToString();
				f_340 = p_76[3, 2].Value.ToString();
				p_76[2, 0].Value = Regex.Match(p_63.Text, f_338).ToString();
				p_76[2, 1].Value = Regex.Match(p_63.Text, f_339).ToString();
				p_76[2, 2].Value = Regex.Match(p_63.Text, f_340).ToString();
				p_76[2, 0].Tag = Regex.Match(Conversions.ToString(p_63.Tag), f_338).ToString();
				p_76[2, 1].Tag = Regex.Match(Conversions.ToString(p_63.Tag), f_339).ToString();
				p_76[2, 2].Tag = Regex.Match(Conversions.ToString(p_63.Tag), f_340).ToString();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void m_126(object P_0, EventArgs P_1)
	{
		p_62.Text = Type_16.m_53(Conversions.ToString(Tag));
	}

	private void m_127(object P_0, EventArgs P_1)
	{
		p_62.Text = Type_16.m_53(Conversions.ToString(p_62.Tag));
	}

	private void m_128(object P_0, EventArgs P_1)
	{
		p_101.Show(p_59, 0, p_59.Height);
	}

	private void m_129(object P_0, EventArgs P_1)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(Type_16.m_60(f_318.GetProcessID())) == DialogResult.OK)
		{
			p_62.Text = fileBorser.DirectoryPath;
		}
	}

	private void m_130(object P_0, EventArgs P_1)
	{
		ModelDoc2 modelDoc = (ModelDoc2)f_318.ActiveDoc;
		if (modelDoc == null)
		{
			return;
		}
		SelectionMgr selectionMgr = (SelectionMgr)modelDoc.SelectionManager;
		if (selectionMgr == null)
		{
			return;
		}
		if (modelDoc.GetType() != 2)
		{
			MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Выберите детали в сборке", "Информация", MessageBoxButtons.OK);
			return;
		}
		if (modelDoc.GetType() == 2)
		{
			if (selectionMgr.GetSelectedObjectCount() < 1)
			{
				MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Выберите детали в сборке", "Информация", MessageBoxButtons.OK);
				return;
			}
			Component2 component = (Component2)NewLateBinding.LateGet(selectionMgr, null, "GetSelectedObjectsComponent4", new object[2] { 1, -1 }, null, null, null);
			if (!Information.IsNothing(component))
			{
				p_62.Text = Type_16.m_53(component.GetPathName());
				component = null;
			}
		}
		else if (modelDoc.GetType() == 1)
		{
			p_62.Text = Type_16.m_53(modelDoc.GetPathName());
		}
		modelDoc = null;
		selectionMgr = null;
	}

	private void m_131(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				string text = "";
				FileBorser fileBorser = new FileBorser();
				if (fileBorser.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				text = fileBorser.DirectoryPath;
				if (!text.EndsWith("\\"))
				{
					text += "\\";
				}
				bool flag = false;
				int num = p_71.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (string.Compare(Conversions.ToString(p_71.Items[i]), text, ignoreCase: true) == 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag & Directory.Exists(text))
				{
					p_71.Items.Add(text);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_132(object P_0, EventArgs P_1)
	{
		try
		{
			string text = "";
			FileBorser fileBorser = new FileBorser();
			if (fileBorser.ShowDialog(this) == DialogResult.OK)
			{
				text = fileBorser.DirectoryPath;
				if (!text.EndsWith("\\"))
				{
					text += "\\";
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void m_133(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				int num = p_71.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i < p_71.Items.Count && p_71.GetSelected(i))
					{
						p_71.Items.RemoveAt(i);
						i--;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_134(object P_0, EventArgs P_1)
	{
		string text = "";
		try
		{
			string text2 = p_62.Tag.ToString();
			string text3 = Type_16.m_53(text2, 3) + ".SLDDRW";
			ModelDoc2 modelDoc = (ModelDoc2)f_318.ActiveDoc;
			if (modelDoc == null)
			{
				return;
			}
			if (modelDoc.GetType() == 2)
			{
				SelectionMgr instance = (SelectionMgr)modelDoc.SelectionManager;
				Component2 component = (Component2)NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", new object[2] { 1, -1 }, null, null, null);
				if (component != null)
				{
					text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(component.GetPathName(), p_62.Tag, TextCompare: false), "", component.GetPathName()));
				}
			}
			if (!File.Exists(text) | (Operators.CompareString(text, "", TextCompare: false) == 0))
			{
				string ConfigName = "";
				string DisplayName = "";
				string fileFilter = "Деталь (*.sldprt)|*.sldprt|Сборка (*.sldasm)|*.sldasm|";
				text = f_318.GetOpenFileName("Выберите детали для связывания", "", fileFilter, out var _, out ConfigName, out DisplayName);
			}
			if (!File.Exists(text) | (Operators.CompareString(text, "", TextCompare: false) == 0))
			{
				return;
			}
			string text4 = text;
			string text5 = Type_16.m_53(text4, 3) + ".SLDDRW";
			if (!(File.Exists(text3) & (string.Compare(text3, text4, ignoreCase: true) != 0) & File.Exists(text4)) || MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Копировать чертёж\n\"" + text3 + "\"\nи с деталью\n\"" + text + "\"\nсвязать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No || (File.Exists(text5) && MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Чертёж\n\"" + text5 + "\"\nуже существует!\nПерезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
			{
				return;
			}
			File.Copy(text3, text5, overwrite: true);
			if (f_318.ReplaceReferencedDocument(text5, text2, text4))
			{
				if (MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Копирование успешно!\nОткрыть папку?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Interaction.Shell("explorer.exe /select, " + text5, AppWinStyle.NormalFocus);
				}
			}
			else
			{
				File.Delete(text5);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			try
			{
				Component2 component = null;
				p_85.Visible = false;
				p_85.Visible = true;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_135(object P_0, MouseEventArgs P_1)
	{
		p_85.Cursor = Cursors.Hand;
	}

	private void m_136(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				if (!f_342 | f_341)
				{
					string text = Type_16.m_53(Conversions.ToString(p_62.Tag), 5);
					List<string> list = new List<string>();
					Type_16.m_54(list, p_62.Text, "*" + text, false);
					string text2 = p_63.Text;
					p_63.Items.Clear();
					p_63.Text = text2;
					int num = list.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						p_63.Items.Add(Type_16.m_53(list[i], 1));
					}
					f_342 = true;
					f_341 = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_137(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				object objectValue = RuntimeHelpers.GetObjectValue(f_318.GetRecentFiles());
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					int num = Information.UBound((Array)objectValue);
					Type_32 type_ = default(Type_32);
					for (int i = 0; i <= num; i += 2)
					{
						type_ = new Type_32(type_);
						string text = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null));
						type_.f_347 = Type_16.m_53(text);
						if (!list.Exists(type_.m_150))
						{
							list.Add(type_.f_347);
						}
					}
				}
				int num2 = p_71.Items.Count - 1;
				Type_33 type_2 = default(Type_33);
				for (int i = 0; i <= num2; i++)
				{
					type_2 = new Type_33(type_2);
					type_2.f_348 = Conversions.ToString(p_71.Items[i]);
					type_2.f_348 = Conversions.ToString(Interaction.IIf(type_2.f_348.EndsWith("\\"), type_2.f_348, type_2.f_348 + "\\"));
					if (list.Exists(type_2.m_151))
					{
						list.Remove(type_2.f_348);
					}
					list.Add(type_2.f_348);
				}
				string text2 = p_62.Text;
				p_62.Items.Clear();
				p_62.Text = text2;
				int num3 = list.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					p_62.Items.Add(list[i]);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_138(object P_0, EventArgs P_1)
	{
		f_341 = true;
		addreferencelist(p_62.Text);
	}

	private void m_139(object P_0, EventArgs P_1)
	{
		Process.Start("NotePad.exe", Type_16.f_63);
		p_68.Visible = false;
		p_68.Visible = true;
	}

	private void m_140(object P_0, MouseEventArgs P_1)
	{
		p_68.Cursor = Cursors.Hand;
	}

	private void m_141(object P_0, EventArgs P_1)
	{
		try
		{
			if (!Type_16.m_57(Type_16.m_53(Tag.ToString())))
			{
				MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Папка не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void m_142(object P_0, EventArgs P_1)
	{
		try
		{
			if (!Type_16.m_57(Type_16.m_53(p_62.Tag.ToString())))
			{
				MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Папка не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void m_143(object P_0, EventArgs P_1)
	{
		try
		{
			if (!Type_16.m_57(p_62.Text))
			{
				MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Папка не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void m_144(object P_0, EventArgs P_1)
	{
		p_88.Enabled = false;
		p_87.Enabled = false;
		p_86.Enabled = false;
		p_85.Visible = p_85.Enabled;
	}

	private void m_145(object P_0, EventArgs P_1)
	{
		p_88.Enabled = true;
		p_87.Enabled = p_85.Enabled;
		p_86.Enabled = f_326;
		p_85.Visible = p_85.Enabled;
	}

	private void m_146(object P_0, EventArgs P_1)
	{
		p_88.Enabled = false;
		p_87.Enabled = p_85.Enabled;
		p_86.Enabled = f_326;
		p_85.Visible = p_85.Enabled;
	}

	private void m_147(object P_0, EventArgs P_1)
	{
		p_88.Enabled = false;
		p_87.Enabled = p_85.Enabled;
		p_86.Enabled = false;
		p_85.Visible = p_85.Enabled;
	}

	private void m_148(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				int num = p_91.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i < p_91.Items.Count && p_91.GetSelected(i))
					{
						p_91.Items.RemoveAt(i);
						i--;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_149(object P_0, EventArgs P_1)
	{
		try
		{
			string text = "";
			FileBorser fileBorser = new FileBorser();
			if (fileBorser.ShowDialog(Type_16.m_60(f_318.GetProcessID())) == DialogResult.OK)
			{
				text = fileBorser.DirectoryPath;
				if (!text.EndsWith("\\"))
				{
					text += "\\";
				}
				addreferencelist(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public bool GetData()
	{
		checked
		{
			try
			{
				string text = "";
				f_326 = false;
				f_319 = (ModelDoc2)f_318.ActiveDoc;
				if (f_319 != null)
				{
					if (f_319.GetType() == 2)
					{
						f_320 = (SelectionMgr)f_319.SelectionManager;
						if (f_320.GetSelectedObjectCount2(-1) < 1)
						{
							f_321 = f_319;
							f_325 = Conversions.ToString(NewLateBinding.LateGet(f_321.GetActiveConfiguration(), null, "Name", new object[0], null, null, null));
						}
						else
						{
							int selectedObjectCount = f_320.GetSelectedObjectCount2(-1);
							f_327 = new Component2[selectedObjectCount - 1 + 1];
							int num = selectedObjectCount;
							for (int i = 1; i <= num; i++)
							{
								Component2[] array = f_327;
								int num2 = i - 1;
								SelectionMgr instance = f_320;
								object[] array2 = new object[2] { i, -1 };
								bool[] array3 = new bool[2] { true, false };
								object obj = NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", array2, null, null, array3);
								if (array3[0])
								{
									i = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(int));
								}
								array[num2] = (Component2)obj;
							}
							if (!Information.IsNothing(f_327[0]))
							{
								f_326 = true;
								int num3 = f_327[0].SetSuppression2(3);
								f_319.ClearSelection2(All: true);
								int num4 = selectedObjectCount;
								for (int i = 1; i <= num4; i++)
								{
									f_319.Extension.SelectByID2(f_327[i - 1].GetSelectByIDString(), "COMPONENT", 0.0, 0.0, 0.0, Append: true, 0, null, 0);
								}
								f_321 = (ModelDoc2)f_327[0].GetModelDoc2();
								f_325 = f_327[0].ReferencedConfiguration;
							}
							else
							{
								f_321 = f_319;
								f_325 = Conversions.ToString(NewLateBinding.LateGet(f_321.GetActiveConfiguration(), null, "Name", new object[0], null, null, null));
							}
						}
						text = ".SLDASM";
					}
					else if (f_319.GetType() == 1)
					{
						f_321 = f_319;
						f_325 = Conversions.ToString(NewLateBinding.LateGet(f_321.GetActiveConfiguration(), null, "Name", new object[0], null, null, null));
						text = ".SLDPRT";
					}
				}
				f_320 = null;
				if (!Information.IsNothing(f_321))
				{
					if (Operators.CompareString(f_321.GetPathName(), "", TextCompare: false) == 0)
					{
						f_328 = true;
					}
					string text2 = f_318.GetCurrentWorkingDirectory() + f_321.GetTitle();
					if (!text2.EndsWith(text, StringComparison.OrdinalIgnoreCase))
					{
						text2 += text;
					}
					f_323 = Conversions.ToString(Interaction.IIf(Operators.CompareString(f_321.GetPathName(), "", TextCompare: false) != 0, f_321.GetPathName(), text2));
					f_324 = Conversions.ToString(Interaction.IIf(Operators.CompareString(f_319.GetPathName(), "", TextCompare: false) != 0, f_319.GetPathName(), f_318.GetCurrentWorkingDirectory() + f_321.GetTitle() + text));
					if (File.Exists(Type_16.m_53(f_323, 3) + ".SLDDRW"))
					{
						p_87.Enabled = true;
						p_85.Visible = true;
						p_85.Enabled = true;
					}
					else
					{
						p_87.Enabled = false;
						p_85.Visible = false;
						p_85.Enabled = false;
					}
					if (!f_326)
					{
						p_83.Checked = true;
					}
					p_82.Enabled = f_326;
					p_86.Enabled = f_326;
					Tag = f_324;
					p_62.Text = Type_16.m_53(f_323);
					p_62.Tag = f_323;
					p_62.SelectionStart = p_62.Text.Length;
					p_63.Text = Type_16.m_53(f_323, 1);
					p_63.Tag = Type_16.m_53(f_323, 1);
					p_63.SelectionStart = p_63.Text.Length;
					Text = Type_16.m_53(f_323, 4);
					addreferencelist(Type_16.m_53(f_323));
					return true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			return false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool RenameParts(object htPart, string NewPathName, string OldPathName, bool WithDrw, bool DelOld, int Options)
	{
		string text = "";
		string text2 = "";
		try
		{
			if ((string.Compare(NewPathName, OldPathName, ignoreCase: true) == 0) & !f_328)
			{
				return false;
			}
			int num = 1;
			if (File.Exists(NewPathName) && MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "\"" + NewPathName + "\" уже существует, перезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return false;
			}
			if (IsOpen(OldPathName, NewPathName))
			{
				MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Файл с именем \"" + Type_16.m_53(NewPathName, 4) + "\" уже открыт, измените имя на другое", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			NewPathName = Type_16.m_53(NewPathName, 3) + Strings.UCase(Type_16.m_53(NewPathName, 5));
			object[] array = new object[3] { NewPathName, 0, Options };
			bool[] array2 = new bool[3] { true, false, true };
			object value = NewLateBinding.LateGet(htPart, null, "SaveAs3", array, null, null, array2);
			if (array2[0])
			{
				NewPathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			if (array2[2])
			{
				Options = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(int));
			}
			num = Conversions.ToInteger(value);
			if (Options == 2 && f_346)
			{
				if (MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Исходный файл \"" + OldPathName + "\" изменён, сохранить?\nY - сохранить, N - отменить", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					f_321.Save();
				}
				else
				{
					f_321.ReloadOrReplace(ReadOnly: false, OldPathName, DiscardChanges: true);
				}
			}
			if (num != 0)
			{
				return false;
			}
			if (WithDrw)
			{
				text = Type_16.m_53(OldPathName, 3) + ".SLDDRW";
				if (Operators.CompareString(FileSystem.Dir(text), "", TextCompare: false) != 0)
				{
					text2 = Type_16.m_53(NewPathName, 3) + ".SLDDRW";
					File.Copy(text, text2, overwrite: true);
					f_318.CloseDoc(text);
					if (File.Exists(text2))
					{
						File.SetAttributes(text2, FileAttributes.Normal);
					}
					f_318.ReplaceReferencedDocument(text2, OldPathName, NewPathName);
				}
			}
			if (DelOld & !f_328)
			{
				Type_16.m_55(OldPathName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool ReName2(object htPart, string NewPathName, string OldPathName, bool WithDrw, bool DelOld)
	{
		string text = "";
		string text2 = "";
		try
		{
			if ((string.Compare(NewPathName, OldPathName, ignoreCase: true) == 0) & !f_328)
			{
				return false;
			}
			int num = 1;
			if (File.Exists(NewPathName) && MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "\"" + NewPathName + "\" уже существует, перезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return false;
			}
			if (IsOpen(OldPathName, NewPathName))
			{
				MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Файл с именем \"" + Type_16.m_53(NewPathName, 4) + "\" уже открыт, измените имя на другое", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			NewPathName = Type_16.m_53(NewPathName, 3) + Strings.UCase(Type_16.m_53(NewPathName, 5));
			File.Copy(OldPathName, NewPathName, overwrite: true);
			if (f_346)
			{
				if (MessageBox.Show(Type_16.m_60(f_318.GetProcessID()), "Исходный файл \"" + OldPathName + "\" изменён, сохранить?\nY - сохранить, N - отменить", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					f_321.Save();
				}
				else
				{
					f_321.ReloadOrReplace(ReadOnly: false, OldPathName, DiscardChanges: true);
				}
			}
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(htPart, null, "ForceReleaseLocks", new object[0], null, null, null), 1, TextCompare: false))
			{
				object[] array = new object[3] { false, NewPathName, true };
				bool[] array2 = new bool[3] { false, true, false };
				object value = NewLateBinding.LateGet(htPart, null, "ReloadOrReplace", array, null, null, array2);
				if (array2[1])
				{
					NewPathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				}
				num = Conversions.ToInteger(value);
			}
			if (num != 0)
			{
				return false;
			}
			if (WithDrw)
			{
				text = Type_16.m_53(OldPathName, 3) + ".SLDDRW";
				if (Operators.CompareString(FileSystem.Dir(text), "", TextCompare: false) != 0)
				{
					text2 = Type_16.m_53(NewPathName, 3) + ".SLDDRW";
					File.Copy(text, text2, overwrite: true);
					f_318.CloseDoc(text);
					if (File.Exists(text2))
					{
						File.SetAttributes(text2, FileAttributes.Normal);
					}
					f_318.ReplaceReferencedDocument(text2, OldPathName, NewPathName);
				}
			}
			if (DelOld & !f_328)
			{
				Type_16.m_55(OldPathName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return true;
	}

	public void Updatereference(object htPart, string NewPathName, string OldPathName)
	{
		object obj = null;
		object obj2 = null;
		AssemblyDoc assemblyDoc = null;
		object obj3 = null;
		List<string> list = new List<string>();
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = "";
		checked
		{
			if (NewPathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				try
				{
					obj2 = RuntimeHelpers.GetObjectValue(f_318.GetDocuments());
					int num = Information.UBound((Array)obj2);
					for (int i = 0; i <= num; i++)
					{
						ModelDoc2 modelDoc = (ModelDoc2)NewLateBinding.LateIndexGet(obj2, new object[1] { i }, null);
						if (!Information.IsNothing(modelDoc))
						{
							string pathName = modelDoc.GetPathName();
							list.Add(pathName);
						}
					}
					int num2 = list.Count - 1;
					int Errors = default(int);
					int Warnings = default(int);
					for (int j = 0; j <= num2; j++)
					{
						string text = list[j];
						if (!text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
						ModelDoc2 modelDoc2 = (ModelDoc2)f_318.GetOpenDocumentByName(text);
						if (Information.IsNothing(modelDoc2))
						{
							continue;
						}
						int num3 = 0;
						ModelDocExtension extension = modelDoc2.Extension;
						if (!Information.IsNothing(extension))
						{
							num3 = extension.ListExternalFileReferencesCount();
							extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
						}
						if (num3 < 1)
						{
							continue;
						}
						bool flag = false;
						int num4 = num3 - 1;
						for (int k = 0; k <= num4; k++)
						{
							string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null));
							if (text2.Equals(OldPathName, StringComparison.OrdinalIgnoreCase))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						if (modelDoc2.GetSaveFlag())
						{
							modelDoc2.Save3(1, ref Errors, ref Warnings);
						}
						f_318.CloseDoc(text);
						int num5 = list.Count - 1;
						for (int l = 0; l <= num5; l++)
						{
							string text3 = list[l];
							if (!text3.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							assemblyDoc = (AssemblyDoc)f_318.GetOpenDocumentByName(text3);
							if (Information.IsNothing(assemblyDoc))
							{
								continue;
							}
							obj = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(true));
							if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
							{
								continue;
							}
							int num6 = Information.UBound((Array)obj);
							for (int m = 0; m <= num6; m++)
							{
								Component2 component = (Component2)NewLateBinding.LateIndexGet(obj, new object[1] { m }, null);
								if (!Information.IsNothing(component) && component.GetPathName().Equals(text, StringComparison.OrdinalIgnoreCase))
								{
									component.SetSuppression2(1);
								}
							}
							ModelDoc2 expression = (ModelDoc2)f_318.GetOpenDocumentByName(text);
							if (Information.IsNothing(expression))
							{
								break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					ProjectData.ClearProjectError();
				}
				obj3 = RuntimeHelpers.GetObjectValue(f_318.GetDocumentDependencies2(NewPathName, Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj3)))
				{
					try
					{
						int num7 = Information.UBound((Array)obj3);
						for (int n = 0; n <= num7; n += 2)
						{
							string pathName = Conversions.ToString(NewLateBinding.LateIndexGet(obj3, new object[1] { n + 1 }, null));
							if (pathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
							{
								f_318.ReplaceReferencedDocument(pathName, OldPathName, NewPathName);
							}
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						MessageBox.Show(this, ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ProjectData.ClearProjectError();
					}
				}
			}
			try
			{
				List<string> list2 = new List<string>();
				int num8 = p_91.CheckedItems.Count - 1;
				for (int num9 = 0; num9 <= num8; num9++)
				{
					string text4 = Conversions.ToString(p_91.Items[num9]);
					Type_16.m_54(list2, text4, "*.SLDASM");
				}
				if (list2.Count > 0)
				{
					int num10 = list2.Count - 1;
					for (int num11 = 0; num11 <= num10; num11++)
					{
						f_318.ReplaceReferencedDocument(list2[num11], OldPathName, NewPathName);
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				MessageBox.Show(this, ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Updatereference2(object htPart, string NewPathName, string OldPathName)
	{
		object obj = null;
		checked
		{
			if (NewPathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				obj = RuntimeHelpers.GetObjectValue(f_318.GetDocumentDependencies2(NewPathName, Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
				{
					try
					{
						int num = Information.UBound((Array)obj);
						int Errors = default(int);
						int Warnings = default(int);
						for (int i = 0; i <= num; i += 2)
						{
							string text = Conversions.ToString(NewLateBinding.LateIndexGet(obj, new object[1] { i + 1 }, null));
							if (!text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							ModelDoc2 modelDoc = (ModelDoc2)f_318.GetOpenDocumentByName(text);
							if (!Information.IsNothing(modelDoc))
							{
								if (modelDoc.GetSaveFlag())
								{
									modelDoc.Save3(1, ref Errors, ref Warnings);
								}
								if (modelDoc.ForceReleaseLocks() == 1)
								{
									f_318.ReplaceReferencedDocument(text, OldPathName, NewPathName);
									modelDoc.ReloadOrReplace(ReadOnly: false, text, DiscardChanges: true);
								}
							}
							else
							{
								f_318.ReplaceReferencedDocument(text, OldPathName, NewPathName);
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ProjectData.ClearProjectError();
					}
				}
			}
			try
			{
				List<string> list = new List<string>();
				int num2 = p_91.CheckedItems.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					string text2 = Conversions.ToString(p_91.Items[j]);
					Type_16.m_54(list, text2, "*.SLDASM");
				}
				if (list.Count > 0)
				{
					int num3 = list.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						f_318.ReplaceReferencedDocument(list[k], OldPathName, NewPathName);
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(this, ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Updatereference3(object htPart, string NewPathName, string OldPathName)
	{
		object obj = null;
		List<string> list = new List<string>();
		bool flag = false;
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = "";
		checked
		{
			try
			{
				int num = p_91.CheckedItems.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = Conversions.ToString(p_91.Items[i]);
					Type_16.m_54(list, text, "*.SLDASM");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			if (NewPathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				obj = RuntimeHelpers.GetObjectValue(f_318.GetDocumentDependencies2(NewPathName, Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
				{
					try
					{
						int num2 = Information.UBound((Array)obj);
						int Errors = default(int);
						int Warnings = default(int);
						for (int j = 0; j <= num2; j += 2)
						{
							string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(obj, new object[1] { j + 1 }, null));
							list.Remove(text2);
							if (!text2.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							ModelDoc2 modelDoc = (ModelDoc2)f_318.GetOpenDocumentByName(text2);
							if (!Information.IsNothing(modelDoc))
							{
								int num3 = 0;
								ModelDocExtension extension = modelDoc.Extension;
								if (!Information.IsNothing(extension))
								{
									num3 = extension.ListExternalFileReferencesCount();
									extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
								}
								if (num3 < 1)
								{
									continue;
								}
								bool flag2 = false;
								int num4 = num3 - 1;
								for (int k = 0; k <= num4; k++)
								{
									string value = Conversions.ToString(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null));
									if (OldPathName.Equals(value, StringComparison.OrdinalIgnoreCase))
									{
										flag2 = true;
										break;
									}
								}
								if (flag2)
								{
									if (modelDoc.GetSaveFlag())
									{
										modelDoc.Save3(1, ref Errors, ref Warnings);
									}
									if (modelDoc.ForceReleaseLocks() == 1)
									{
										f_318.ReplaceReferencedDocument(text2, OldPathName, NewPathName);
										modelDoc.ReloadOrReplace(ReadOnly: false, text2, DiscardChanges: true);
									}
								}
							}
							else
							{
								f_318.ReplaceReferencedDocument(text2, OldPathName, NewPathName);
							}
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						MessageBox.Show(this, ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ProjectData.ClearProjectError();
					}
				}
			}
			try
			{
				if (list.Count > 0)
				{
					int num5 = list.Count - 1;
					for (int l = 0; l <= num5; l++)
					{
						f_318.ReplaceReferencedDocument(list[l], OldPathName, NewPathName);
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				MessageBox.Show(this, ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool IsOpen(string OldPathName, string NewPathName)
	{
		bool result = false;
		try
		{
			ModelDoc2 openDocument = f_318.GetOpenDocument(Type_16.m_53(NewPathName, 4));
			if (!Information.IsNothing(openDocument))
			{
				string pathName = openDocument.GetPathName();
				if (!pathName.Trim().Equals(OldPathName, StringComparison.OrdinalIgnoreCase))
				{
					result = Type_16.m_53(pathName, 4).Equals(Type_16.m_53(NewPathName, 4), StringComparison.OrdinalIgnoreCase);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsOpen(string NewPathName)
	{
		bool result = false;
		try
		{
			ModelDoc2 openDocument = f_318.GetOpenDocument(Type_16.m_53(NewPathName, 4));
			if (!Information.IsNothing(openDocument))
			{
				string pathName = openDocument.GetPathName();
				result = Type_16.m_53(pathName, 4).Equals(Type_16.m_53(NewPathName, 4), StringComparison.OrdinalIgnoreCase);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool AddProp(object swModel, string FieldName, string FieldValue)
	{
		bool result = false;
		object obj = null;
		checked
		{
			try
			{
				if (Operators.CompareString(FieldValue, "", TextCompare: false) == 0)
				{
					return false;
				}
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(swModel)))
				{
					return false;
				}
				ModelDocExtension modelDocExtension = (ModelDocExtension)NewLateBinding.LateGet(swModel, null, "Extension", new object[0], null, null, null);
				CustomPropertyManager customPropertyManager;
				if ((Operators.CompareString(Strings.Right(FieldName, 1), "$", TextCompare: false) == 0) & (Operators.CompareString(Strings.Left(FieldName, 1), "$", TextCompare: false) == 0))
				{
					FieldName = Strings.Mid(FieldName, 2, Strings.Len(FieldName) - 2);
					customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager("");
					obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swModel, null, "GetConfigurationNames", new object[0], null, null, null));
				}
				else
				{
					if (!((Operators.CompareString(Strings.Right(FieldName, 1), "%", TextCompare: false) == 0) & (Operators.CompareString(Strings.Left(FieldName, 1), "%", TextCompare: false) == 0)))
					{
						return false;
					}
					FieldName = Strings.Mid(FieldName, 2, Strings.Len(FieldName) - 2);
					customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(f_325);
					obj = new object[1];
					NewLateBinding.LateIndexSet(obj, new object[2] { 0, "" }, null);
				}
				if (Type_19.m_78(customPropertyManager, FieldName, Conversions.ToString(30), FieldValue) == 0)
				{
					result = true;
					foreach (object item in (IEnumerable)obj)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(Conversions.ToString(objectValue));
						int num = customPropertyManager.Delete(FieldName);
					}
				}
				NewLateBinding.LateCall(swModel, null, "SetSaveFlag", new object[0], null, null, null, IgnoreReturn: true);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public void addreferencelist(string pathname)
	{
		if (!Directory.Exists(pathname))
		{
			return;
		}
		checked
		{
			try
			{
				bool flag = false;
				int num = p_91.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i < p_91.Items.Count)
					{
						if (Strings.InStr(pathname, p_91.Items[i].ToString(), CompareMethod.Text) >= 1)
						{
							Console.WriteLine(Strings.InStr(pathname, p_91.Items[i].ToString(), CompareMethod.Text));
							flag = true;
							break;
						}
						if (Strings.InStr(p_91.Items[i].ToString(), pathname, CompareMethod.Text) >= 1)
						{
							Console.WriteLine(Conversions.ToString(Strings.InStr(pathname, p_91.Items[i].ToString(), CompareMethod.Text)) + "\n" + Conversions.ToString(2));
							p_91.Items.RemoveAt(i);
							i--;
						}
					}
				}
				if (!flag)
				{
					p_91.Items.Add(pathname, isChecked: true);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK);
				ProjectData.ClearProjectError();
			}
		}
	}
}
