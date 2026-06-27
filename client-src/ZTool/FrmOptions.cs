using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmOptions : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__67
	{
		public string _0024VB_0024Local_mypath;

		[DebuggerNonUserCode]
		public _Closure_0024__67()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__67(_Closure_0024__67 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_mypath = other._0024VB_0024Local_mypath;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__122(string s)
		{
			return s.Equals(_0024VB_0024Local_mypath, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private sealed class ColorListItem
	{
		internal readonly string Name;

		private readonly string _displayName;

		internal ColorListItem(string name)
		{
			Name = name;
			_displayName = TranslateColorName(name);
		}

		public override string ToString()
		{
			return _displayName;
		}
	}

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("SwVer")]
	private ComboBox _SwVer;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("rowcolor")]
	private ComboBox _rowcolor;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("TabControl1")]
	private TabControl _TabControl1;

	[AccessedThroughProperty("TabPage1")]
	private TabPage _TabPage1;

	[AccessedThroughProperty("TabPage3")]
	private TabPage _TabPage3;

	[AccessedThroughProperty("GetAllconfigsbool")]
	private CheckBox _GetAllconfigsbool;

	[AccessedThroughProperty("DClick_OpenInSw")]
	private CheckBox _DClick_OpenInSw;

	[AccessedThroughProperty("TabPage4")]
	private TabPage _TabPage4;

	[AccessedThroughProperty("Label13")]
	private Label _Label13;

	[AccessedThroughProperty("Label14")]
	private Label _Label14;

	[AccessedThroughProperty("Label15")]
	private Label _Label15;

	[AccessedThroughProperty("ListBox1")]
	private ListBox _ListBox1;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("ReConnectClearFilter")]
	private CheckBox _ReConnectClearFilter;

	[AccessedThroughProperty("ExpandMaterialList")]
	private CheckBox _ExpandMaterialList;

	[AccessedThroughProperty("HideSw1")]
	private CheckBox _HideSw1;

	[AccessedThroughProperty("othermenu")]
	private Button _othermenu;

	[AccessedThroughProperty("Previewfortool")]
	private CheckBox _Previewfortool;

	[AccessedThroughProperty("RealTimeFilter")]
	private CheckBox _RealTimeFilter;

	[AccessedThroughProperty("TabPage2")]
	private TabPage _TabPage2;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("PreviewMode")]
	private ComboBox _PreviewMode;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Preview_Hotkey")]
	private TextBox _Preview_Hotkey;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("Panel2")]
	private Panel _Panel2;

	[AccessedThroughProperty("Thumbnail_Savetolocal")]
	private CheckBox _Thumbnail_Savetolocal;

	[AccessedThroughProperty("Button7")]
	private Button _Button7;

	[AccessedThroughProperty("TabPage5")]
	private TabPage _TabPage5;

	[AccessedThroughProperty("macrolist")]
	private ListBox _macrolist;

	[AccessedThroughProperty("Panel3")]
	private Panel _Panel3;

	[AccessedThroughProperty("Button8")]
	private Button _Button8;

	[AccessedThroughProperty("Button9")]
	private Button _Button9;

	[AccessedThroughProperty("Button11")]
	private Button _Button11;

	[AccessedThroughProperty("Button10")]
	private Button _Button10;

	[AccessedThroughProperty("checkupdata")]
	private CheckBox _checkupdata;

	[AccessedThroughProperty("menulist")]
	private ContextMenuStrip _menulist;

	[AccessedThroughProperty("menu1")]
	private ToolStripMenuItem _menu1;

	[AccessedThroughProperty("menu2")]
	private ToolStripMenuItem _menu2;

	[AccessedThroughProperty("menu3")]
	private ToolStripMenuItem _menu3;

	[AccessedThroughProperty("menu4")]
	private ToolStripMenuItem _menu4;

	[AccessedThroughProperty("menu5")]
	private ToolStripMenuItem _menu5;

	[AccessedThroughProperty("addtosw")]
	private Button _addtosw;

	[AccessedThroughProperty("materialpath")]
	private CustomComboBox2 _materialpath;

	[AccessedThroughProperty("open_browse")]
	private ToolStripMenuItem _open_browse;

	[AccessedThroughProperty("look_fromsw")]
	private ToolStripMenuItem _look_fromsw;

	[AccessedThroughProperty("openmenu")]
	private ContextMenuStrip _openmenu;

	[AccessedThroughProperty("usematerialcolor")]
	private CheckBox _usematerialcolor;

	[AccessedThroughProperty("Thumbnail_position")]
	private ComboBox _Thumbnail_position;

	private List<string> Preview_Hotkey_list;

	private List<string> ExcludePropList;

	private List<string> Dropdownlist;

	private string propname;

	private string Colheadtext;

	private double dpixRatio;

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

	internal virtual ComboBox SwVer
	{
		[DebuggerNonUserCode]
		get
		{
			return _SwVer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_SwVer = value;
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

	internal virtual ComboBox rowcolor
	{
		[DebuggerNonUserCode]
		get
		{
			return _rowcolor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DrawItemEventHandler value2 = rowcolor_DrawItem;
			if (_rowcolor != null)
			{
				_rowcolor.DrawItem -= value2;
			}
			_rowcolor = value;
			if (_rowcolor != null)
			{
				_rowcolor.DrawItem += value2;
			}
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

	internal virtual CheckBox GetAllconfigsbool
	{
		[DebuggerNonUserCode]
		get
		{
			return _GetAllconfigsbool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GetAllconfigsbool = value;
		}
	}

	internal virtual CheckBox DClick_OpenInSw
	{
		[DebuggerNonUserCode]
		get
		{
			return _DClick_OpenInSw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DClick_OpenInSw = value;
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

	internal virtual ListBox ListBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ListBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ListBox1_SelectedIndexChanged;
			if (_ListBox1 != null)
			{
				_ListBox1.SelectedIndexChanged -= value2;
			}
			_ListBox1 = value;
			if (_ListBox1 != null)
			{
				_ListBox1.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox TextBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TextBox1_TextChanged;
			if (_TextBox1 != null)
			{
				_TextBox1.TextChanged -= value2;
			}
			_TextBox1 = value;
			if (_TextBox1 != null)
			{
				_TextBox1.TextChanged += value2;
			}
		}
	}

	internal virtual CheckBox ReConnectClearFilter
	{
		[DebuggerNonUserCode]
		get
		{
			return _ReConnectClearFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ReConnectClearFilter = value;
		}
	}

	internal virtual CheckBox ExpandMaterialList
	{
		[DebuggerNonUserCode]
		get
		{
			return _ExpandMaterialList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ExpandMaterialList = value;
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

	internal virtual Button othermenu
	{
		[DebuggerNonUserCode]
		get
		{
			return _othermenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button2_Click;
			if (_othermenu != null)
			{
				_othermenu.Click -= value2;
			}
			_othermenu = value;
			if (_othermenu != null)
			{
				_othermenu.Click += value2;
			}
		}
	}

	internal virtual CheckBox Previewfortool
	{
		[DebuggerNonUserCode]
		get
		{
			return _Previewfortool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Previewfortool = value;
		}
	}

	internal virtual CheckBox RealTimeFilter
	{
		[DebuggerNonUserCode]
		get
		{
			return _RealTimeFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_RealTimeFilter = value;
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

	internal virtual ComboBox PreviewMode
	{
		[DebuggerNonUserCode]
		get
		{
			return _PreviewMode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PreviewMode = value;
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

	internal virtual TextBox Preview_Hotkey
	{
		[DebuggerNonUserCode]
		get
		{
			return _Preview_Hotkey;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = Preview_Hotkey_MouseDown;
			KeyEventHandler value3 = Preview_Hotkey_KeyDown;
			if (_Preview_Hotkey != null)
			{
				_Preview_Hotkey.MouseDown -= value2;
				_Preview_Hotkey.KeyDown -= value3;
			}
			_Preview_Hotkey = value;
			if (_Preview_Hotkey != null)
			{
				_Preview_Hotkey.MouseDown += value2;
				_Preview_Hotkey.KeyDown += value3;
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

	internal virtual CheckBox Thumbnail_Savetolocal
	{
		[DebuggerNonUserCode]
		get
		{
			return _Thumbnail_Savetolocal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Thumbnail_Savetolocal = value;
		}
	}

	internal virtual Button Button7
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button7_Click;
			if (_Button7 != null)
			{
				_Button7.Click -= value2;
			}
			_Button7 = value;
			if (_Button7 != null)
			{
				_Button7.Click += value2;
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

	internal virtual ListBox macrolist
	{
		[DebuggerNonUserCode]
		get
		{
			return _macrolist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_macrolist = value;
		}
	}

	internal virtual Panel Panel3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel3 = value;
		}
	}

	internal virtual Button Button8
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button8_Click;
			if (_Button8 != null)
			{
				_Button8.Click -= value2;
			}
			_Button8 = value;
			if (_Button8 != null)
			{
				_Button8.Click += value2;
			}
		}
	}

	internal virtual Button Button9
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button9_Click;
			if (_Button9 != null)
			{
				_Button9.Click -= value2;
			}
			_Button9 = value;
			if (_Button9 != null)
			{
				_Button9.Click += value2;
			}
		}
	}

	internal virtual Button Button11
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button11_Click;
			if (_Button11 != null)
			{
				_Button11.Click -= value2;
			}
			_Button11 = value;
			if (_Button11 != null)
			{
				_Button11.Click += value2;
			}
		}
	}

	internal virtual Button Button10
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button10_Click;
			if (_Button10 != null)
			{
				_Button10.Click -= value2;
			}
			_Button10 = value;
			if (_Button10 != null)
			{
				_Button10.Click += value2;
			}
		}
	}

	internal virtual CheckBox checkupdata
	{
		[DebuggerNonUserCode]
		get
		{
			return _checkupdata;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_checkupdata = value;
		}
	}

	internal virtual ContextMenuStrip menulist
	{
		[DebuggerNonUserCode]
		get
		{
			return _menulist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_menulist = value;
		}
	}

	internal virtual ToolStripMenuItem menu1
	{
		[DebuggerNonUserCode]
		get
		{
			return _menu1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = menu1_Click;
			if (_menu1 != null)
			{
				_menu1.Click -= value2;
			}
			_menu1 = value;
			if (_menu1 != null)
			{
				_menu1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem menu2
	{
		[DebuggerNonUserCode]
		get
		{
			return _menu2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = menu2_Click;
			if (_menu2 != null)
			{
				_menu2.Click -= value2;
			}
			_menu2 = value;
			if (_menu2 != null)
			{
				_menu2.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem menu3
	{
		[DebuggerNonUserCode]
		get
		{
			return _menu3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = menu3_Click;
			if (_menu3 != null)
			{
				_menu3.Click -= value2;
			}
			_menu3 = value;
			if (_menu3 != null)
			{
				_menu3.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem menu4
	{
		[DebuggerNonUserCode]
		get
		{
			return _menu4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = menu4_Click;
			if (_menu4 != null)
			{
				_menu4.Click -= value2;
			}
			_menu4 = value;
			if (_menu4 != null)
			{
				_menu4.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem menu5
	{
		[DebuggerNonUserCode]
		get
		{
			return _menu5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = menu5_Click;
			if (_menu5 != null)
			{
				_menu5.Click -= value2;
			}
			_menu5 = value;
			if (_menu5 != null)
			{
				_menu5.Click += value2;
			}
		}
	}

	internal virtual Button addtosw
	{
		[DebuggerNonUserCode]
		get
		{
			return _addtosw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addtosw_Click;
			if (_addtosw != null)
			{
				_addtosw.Click -= value2;
			}
			_addtosw = value;
			if (_addtosw != null)
			{
				_addtosw.Click += value2;
			}
		}
	}

	internal virtual CustomComboBox2 materialpath
	{
		[DebuggerNonUserCode]
		get
		{
			return _materialpath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_materialpath = value;
		}
	}

	internal virtual ToolStripMenuItem open_browse
	{
		[DebuggerNonUserCode]
		get
		{
			return _open_browse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = open_browse_Click;
			if (_open_browse != null)
			{
				_open_browse.Click -= value2;
			}
			_open_browse = value;
			if (_open_browse != null)
			{
				_open_browse.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem look_fromsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _look_fromsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = look_fromsw_Click;
			if (_look_fromsw != null)
			{
				_look_fromsw.Click -= value2;
			}
			_look_fromsw = value;
			if (_look_fromsw != null)
			{
				_look_fromsw.Click += value2;
			}
		}
	}

	internal virtual ContextMenuStrip openmenu
	{
		[DebuggerNonUserCode]
		get
		{
			return _openmenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_openmenu = value;
		}
	}

	internal virtual CheckBox usematerialcolor
	{
		[DebuggerNonUserCode]
		get
		{
			return _usematerialcolor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_usematerialcolor = value;
		}
	}

	internal virtual ComboBox Thumbnail_position
	{
		[DebuggerNonUserCode]
		get
		{
			return _Thumbnail_position;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Thumbnail_position = value;
		}
	}

	public FrmOptions()
	{
		base.FormClosed += FrmOptions_FormClosed;
		base.Load += FrmOptions_Load;
		__ENCAddToList(this);
		Preview_Hotkey_list = new List<string>();
		ExcludePropList = new List<string>();
		Dropdownlist = new List<string>();
		InitializeComponent();
		ConfigureResponsiveLayout();
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

	private int Dpi(int value)
	{
		double num = dpixRatio;
		if (num <= 0.0)
		{
			using (Graphics graphics = CreateGraphics())
			{
				num = graphics.DpiX / 96f;
			}
			dpixRatio = num;
		}
		return checked((int)Math.Round((double)value * num));
	}

	private void SetBoundsDpi(Control control, int x, int y, int width, int height)
	{
		if (control != null)
		{
			control.SetBounds(Dpi(x), Dpi(y), Math.Max(Dpi(1), Dpi(width)), Math.Max(Dpi(1), Dpi(height)));
		}
	}

	private void ConfigureResponsiveLayout()
	{
		SuspendLayout();
		ApplyFont(this, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204));
		FormBorderStyle = FormBorderStyle.Sizable;
		MaximizeBox = true;
		MinimizeBox = true;
		MinimumSize = new Size(Dpi(760), Dpi(540));
		SizeGripStyle = SizeGripStyle.Show;
		if (ClientSize.Width < Dpi(740) || ClientSize.Height < Dpi(500))
		{
			ClientSize = new Size(Math.Max(ClientSize.Width, Dpi(740)), Math.Max(ClientSize.Height, Dpi(500)));
		}
		foreach (TabPage tabPage in TabControl1.TabPages)
		{
			tabPage.AutoScroll = true;
			tabPage.Padding = new Padding(Dpi(12));
		}
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		TableLayoutPanel1.ColumnStyles.Clear();
		TableLayoutPanel1.RowStyles.Clear();
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(100)));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(100)));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, Dpi(34)));
		OK_Button.Dock = DockStyle.Fill;
		Cancel_Button.Dock = DockStyle.Fill;
		Panel1.BorderStyle = BorderStyle.FixedSingle;
		Panel2.BorderStyle = BorderStyle.FixedSingle;
		ListBox1.Dock = DockStyle.Fill;
		ListBox1.HorizontalScrollbar = true;
		TextBox1.Dock = DockStyle.Fill;
		TextBox1.Multiline = true;
		TextBox1.ScrollBars = ScrollBars.Vertical;
		macrolist.HorizontalScrollbar = true;
		base.Resize += FrmOptions_ResponsiveResize;
		ApplyResponsiveLayout();
		ResumeLayout(performLayout: true);
	}

	private void FrmOptions_ResponsiveResize(object sender, EventArgs e)
	{
		ApplyResponsiveLayout();
	}

	private void ApplyResponsiveLayout()
	{
		if (TabControl1 == null || TableLayoutPanel1 == null)
		{
			return;
		}
		SuspendLayout();
		SetBoundsDpi(TabControl1, 12, 12, Math.Max(520, (int)Math.Round((double)ClientSize.Width / Math.Max(1.0, dpixRatio)) - 24), Math.Max(360, (int)Math.Round((double)ClientSize.Height / Math.Max(1.0, dpixRatio)) - 76));
		SetBoundsDpi(TableLayoutPanel1, Math.Max(12, (int)Math.Round((double)ClientSize.Width / Math.Max(1.0, dpixRatio)) - 222), Math.Max(12, (int)Math.Round((double)ClientSize.Height / Math.Max(1.0, dpixRatio)) - 48), 210, 34);
		LayoutGeneralTab();
		LayoutSketchTab();
		LayoutMaterialTab();
		LayoutUserListTab();
		LayoutMacroTab();
		ResumeLayout(performLayout: true);
	}

	private void ApplyFont(Control control, Font font)
	{
		control.Font = font;
		foreach (Control control2 in control.Controls)
		{
			ApplyFont(control2, font);
		}
	}

	private void LayoutGeneralTab()
	{
		int num = Math.Max(620, (int)Math.Round((double)TabPage1.ClientSize.Width / Math.Max(1.0, dpixRatio)));
		SetBoundsDpi(Label3, 20, 24, 130, 24);
		SetBoundsDpi(rowcolor, 160, 22, 280, 26);
		SetBoundsDpi(Label1, 20, 64, 140, 24);
		SetBoundsDpi(SwVer, 160, 62, 280, 26);
		CheckBox[] array = new CheckBox[7] { GetAllconfigsbool, DClick_OpenInSw, ReConnectClearFilter, HideSw1, Previewfortool, RealTimeFilter, checkupdata };
		int num2 = 104;
		foreach (CheckBox checkBox in array)
		{
			checkBox.AutoSize = false;
			checkBox.TextAlign = ContentAlignment.MiddleLeft;
			SetBoundsDpi(checkBox, 20, num2, num - 50, 24);
			num2 += 30;
		}
		SetBoundsDpi(othermenu, 20, num2 + 4, 150, 30);
	}

	private void LayoutSketchTab()
	{
		int num = Math.Max(620, (int)Math.Round((double)TabPage2.ClientSize.Width / Math.Max(1.0, dpixRatio)));
		Label5.AutoSize = false;
		Label4.AutoSize = false;
		SetBoundsDpi(Label5, 20, 24, 150, 24);
		SetBoundsDpi(Preview_Hotkey, 180, 22, 300, 26);
		SetBoundsDpi(Label4, 20, 66, 190, 24);
		SetBoundsDpi(PreviewMode, 220, 64, Math.Min(360, num - 250), 26);
		Thumbnail_Savetolocal.AutoSize = false;
		SetBoundsDpi(Thumbnail_Savetolocal, 20, 108, 260, 24);
		SetBoundsDpi(Thumbnail_position, 290, 106, 220, 26);
		SetBoundsDpi(Button3, 20, 160, 240, 32);
		SetBoundsDpi(Button7, 280, 160, 260, 32);
	}

	private void LayoutMaterialTab()
	{
		int num = Math.Max(620, (int)Math.Round((double)TabPage3.ClientSize.Width / Math.Max(1.0, dpixRatio)));
		Label2.AutoSize = false;
		SetBoundsDpi(Label2, 20, 26, 140, 24);
		SetBoundsDpi(materialpath, 160, 24, Math.Max(260, num - 330), 26);
		SetBoundsDpi(Button1, Math.Max(470, num - 150), 23, 42, 28);
		ExpandMaterialList.AutoSize = false;
		usematerialcolor.AutoSize = false;
		SetBoundsDpi(ExpandMaterialList, 20, 70, num - 50, 24);
		SetBoundsDpi(usematerialcolor, 20, 102, num - 50, 24);
		SetBoundsDpi(addtosw, 20, 142, 190, 32);
	}

	private void LayoutUserListTab()
	{
		int num = Math.Max(620, (int)Math.Round((double)TabPage4.ClientSize.Width / Math.Max(1.0, dpixRatio)));
		int num2 = Math.Max(340, (int)Math.Round((double)TabPage4.ClientSize.Height / Math.Max(1.0, dpixRatio)));
		Label13.AutoSize = false;
		Label15.AutoSize = false;
		Label14.AutoSize = false;
		SetBoundsDpi(Label13, 20, 20, num - 40, 42);
		int num3 = Math.Max(250, (num - 60) / 2);
		int num4 = Math.Max(210, num - 40 - num3 - 20);
		SetBoundsDpi(Label15, 20, 74, num3, 24);
		SetBoundsDpi(Label14, 40 + num3, 74, num4, 24);
		SetBoundsDpi(Panel1, 20, 102, num3, Math.Max(190, num2 - 134));
		SetBoundsDpi(Panel2, 40 + num3, 102, num4, Math.Max(190, num2 - 134));
	}

	private void LayoutMacroTab()
	{
		int num = Math.Max(620, (int)Math.Round((double)TabPage5.ClientSize.Width / Math.Max(1.0, dpixRatio)));
		int num2 = Math.Max(340, (int)Math.Round((double)TabPage5.ClientSize.Height / Math.Max(1.0, dpixRatio)));
		SetBoundsDpi(macrolist, 20, 20, Math.Max(360, num - 170), Math.Max(260, num2 - 50));
		SetBoundsDpi(Panel3, Math.Max(400, num - 130), 20, 110, 180);
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.FrmOptions));
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.SwVer = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.openmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.open_browse = new System.Windows.Forms.ToolStripMenuItem();
		this.look_fromsw = new System.Windows.Forms.ToolStripMenuItem();
		this.rowcolor = new System.Windows.Forms.ComboBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.othermenu = new System.Windows.Forms.Button();
		this.checkupdata = new System.Windows.Forms.CheckBox();
		this.RealTimeFilter = new System.Windows.Forms.CheckBox();
		this.Previewfortool = new System.Windows.Forms.CheckBox();
		this.HideSw1 = new System.Windows.Forms.CheckBox();
		this.ReConnectClearFilter = new System.Windows.Forms.CheckBox();
		this.DClick_OpenInSw = new System.Windows.Forms.CheckBox();
		this.GetAllconfigsbool = new System.Windows.Forms.CheckBox();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.Thumbnail_position = new System.Windows.Forms.ComboBox();
		this.Thumbnail_Savetolocal = new System.Windows.Forms.CheckBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.PreviewMode = new System.Windows.Forms.ComboBox();
		this.Button7 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.Preview_Hotkey = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.materialpath = new ZTool.CustomComboBox2();
		this.usematerialcolor = new System.Windows.Forms.CheckBox();
		this.ExpandMaterialList = new System.Windows.Forms.CheckBox();
		this.addtosw = new System.Windows.Forms.Button();
		this.TabPage4 = new System.Windows.Forms.TabPage();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.ListBox1 = new System.Windows.Forms.ListBox();
		this.Label13 = new System.Windows.Forms.Label();
		this.Label14 = new System.Windows.Forms.Label();
		this.Label15 = new System.Windows.Forms.Label();
		this.TabPage5 = new System.Windows.Forms.TabPage();
		this.macrolist = new System.Windows.Forms.ListBox();
		this.Panel3 = new System.Windows.Forms.Panel();
		this.Button11 = new System.Windows.Forms.Button();
		this.Button10 = new System.Windows.Forms.Button();
		this.Button9 = new System.Windows.Forms.Button();
		this.Button8 = new System.Windows.Forms.Button();
		this.menulist = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.menu1 = new System.Windows.Forms.ToolStripMenuItem();
		this.menu2 = new System.Windows.Forms.ToolStripMenuItem();
		this.menu3 = new System.Windows.Forms.ToolStripMenuItem();
		this.menu4 = new System.Windows.Forms.ToolStripMenuItem();
		this.menu5 = new System.Windows.Forms.ToolStripMenuItem();
		this.TableLayoutPanel1.SuspendLayout();
		this.openmenu.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.TabPage2.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.TabPage4.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.TabPage5.SuspendLayout();
		this.Panel3.SuspendLayout();
		this.menulist.SuspendLayout();
		this.SuspendLayout();
		resources.ApplyResources(this.TableLayoutPanel1, "TableLayoutPanel1");
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		resources.ApplyResources(this.OK_Button, "OK_Button");
		this.OK_Button.Name = "OK_Button";
		resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Name = "Cancel_Button";
		this.SwVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.SwVer, "SwVer");
		this.SwVer.FormattingEnabled = true;
		this.SwVer.Items.AddRange(new object[20]
		{
			resources.GetString("SwVer.Items"),
			resources.GetString("SwVer.Items1"),
			resources.GetString("SwVer.Items2"),
			resources.GetString("SwVer.Items3"),
			resources.GetString("SwVer.Items4"),
			resources.GetString("SwVer.Items5"),
			resources.GetString("SwVer.Items6"),
			resources.GetString("SwVer.Items7"),
			resources.GetString("SwVer.Items8"),
			resources.GetString("SwVer.Items9"),
			resources.GetString("SwVer.Items10"),
			resources.GetString("SwVer.Items11"),
			resources.GetString("SwVer.Items12"),
			resources.GetString("SwVer.Items13"),
			resources.GetString("SwVer.Items14"),
			resources.GetString("SwVer.Items15"),
			resources.GetString("SwVer.Items16"),
			resources.GetString("SwVer.Items17"),
			resources.GetString("SwVer.Items18"),
			resources.GetString("SwVer.Items19")
		});
		this.SwVer.Name = "SwVer";
		resources.ApplyResources(this.Label1, "Label1");
		this.Label1.Name = "Label1";
		resources.ApplyResources(this.Label2, "Label2");
		this.Label2.Name = "Label2";
		resources.ApplyResources(this.Button1, "Button1");
		this.Button1.ContextMenuStrip = this.openmenu;
		this.Button1.Name = "Button1";
		this.Button1.UseVisualStyleBackColor = true;
		this.openmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.open_browse, this.look_fromsw });
		this.openmenu.Name = "Savemenu";
		this.openmenu.ShowImageMargin = false;
		resources.ApplyResources(this.openmenu, "openmenu");
		this.open_browse.Name = "open_browse";
		resources.ApplyResources(this.open_browse, "open_browse");
		this.look_fromsw.Name = "look_fromsw";
		resources.ApplyResources(this.look_fromsw, "look_fromsw");
		this.rowcolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.rowcolor, "rowcolor");
		this.rowcolor.ForeColor = System.Drawing.SystemColors.WindowText;
		this.rowcolor.FormattingEnabled = true;
		this.rowcolor.Name = "rowcolor";
		resources.ApplyResources(this.Label3, "Label3");
		this.Label3.Name = "Label3";
		resources.ApplyResources(this.TabControl1, "TabControl1");
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Controls.Add(this.TabPage4);
		this.TabControl1.Controls.Add(this.TabPage5);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabPage1.Controls.Add(this.othermenu);
		this.TabPage1.Controls.Add(this.checkupdata);
		this.TabPage1.Controls.Add(this.RealTimeFilter);
		this.TabPage1.Controls.Add(this.Previewfortool);
		this.TabPage1.Controls.Add(this.HideSw1);
		this.TabPage1.Controls.Add(this.ReConnectClearFilter);
		this.TabPage1.Controls.Add(this.DClick_OpenInSw);
		this.TabPage1.Controls.Add(this.GetAllconfigsbool);
		this.TabPage1.Controls.Add(this.SwVer);
		this.TabPage1.Controls.Add(this.Label1);
		this.TabPage1.Controls.Add(this.rowcolor);
		this.TabPage1.Controls.Add(this.Label3);
		resources.ApplyResources(this.TabPage1, "TabPage1");
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.othermenu, "othermenu");
		this.othermenu.Name = "othermenu";
		this.othermenu.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.checkupdata, "checkupdata");
		this.checkupdata.Name = "checkupdata";
		this.checkupdata.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.RealTimeFilter, "RealTimeFilter");
		this.RealTimeFilter.Name = "RealTimeFilter";
		this.RealTimeFilter.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Previewfortool, "Previewfortool");
		this.Previewfortool.Name = "Previewfortool";
		this.Previewfortool.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.HideSw1, "HideSw1");
		this.HideSw1.Name = "HideSw1";
		this.HideSw1.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.ReConnectClearFilter, "ReConnectClearFilter");
		this.ReConnectClearFilter.Name = "ReConnectClearFilter";
		this.ReConnectClearFilter.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.DClick_OpenInSw, "DClick_OpenInSw");
		this.DClick_OpenInSw.Name = "DClick_OpenInSw";
		this.DClick_OpenInSw.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.GetAllconfigsbool, "GetAllconfigsbool");
		this.GetAllconfigsbool.Name = "GetAllconfigsbool";
		this.GetAllconfigsbool.UseVisualStyleBackColor = true;
		this.TabPage2.Controls.Add(this.Thumbnail_position);
		this.TabPage2.Controls.Add(this.Thumbnail_Savetolocal);
		this.TabPage2.Controls.Add(this.Label4);
		this.TabPage2.Controls.Add(this.PreviewMode);
		this.TabPage2.Controls.Add(this.Button7);
		this.TabPage2.Controls.Add(this.Button3);
		this.TabPage2.Controls.Add(this.Preview_Hotkey);
		this.TabPage2.Controls.Add(this.Label5);
		resources.ApplyResources(this.TabPage2, "TabPage2");
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.Thumbnail_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Thumbnail_position.FormattingEnabled = true;
		this.Thumbnail_position.Items.AddRange(new object[2]
		{
			resources.GetString("Thumbnail_position.Items"),
			resources.GetString("Thumbnail_position.Items1")
		});
		resources.ApplyResources(this.Thumbnail_position, "Thumbnail_position");
		this.Thumbnail_position.Name = "Thumbnail_position";
		resources.ApplyResources(this.Thumbnail_Savetolocal, "Thumbnail_Savetolocal");
		this.Thumbnail_Savetolocal.Name = "Thumbnail_Savetolocal";
		this.Thumbnail_Savetolocal.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Label4, "Label4");
		this.Label4.Name = "Label4";
		this.PreviewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.PreviewMode, "PreviewMode");
		this.PreviewMode.FormattingEnabled = true;
		this.PreviewMode.Items.AddRange(new object[2]
		{
			resources.GetString("PreviewMode.Items"),
			resources.GetString("PreviewMode.Items1")
		});
		this.PreviewMode.Name = "PreviewMode";
		resources.ApplyResources(this.Button7, "Button7");
		this.Button7.Name = "Button7";
		this.Button7.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Button3, "Button3");
		this.Button3.Name = "Button3";
		this.Button3.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Preview_Hotkey, "Preview_Hotkey");
		this.Preview_Hotkey.Name = "Preview_Hotkey";
		resources.ApplyResources(this.Label5, "Label5");
		this.Label5.Name = "Label5";
		this.TabPage3.Controls.Add(this.materialpath);
		this.TabPage3.Controls.Add(this.usematerialcolor);
		this.TabPage3.Controls.Add(this.ExpandMaterialList);
		this.TabPage3.Controls.Add(this.addtosw);
		this.TabPage3.Controls.Add(this.Button1);
		this.TabPage3.Controls.Add(this.Label2);
		resources.ApplyResources(this.TabPage3, "TabPage3");
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.materialpath.FormattingEnabled = true;
		resources.ApplyResources(this.materialpath, "materialpath");
		this.materialpath.Name = "materialpath";
		resources.ApplyResources(this.usematerialcolor, "usematerialcolor");
		this.usematerialcolor.Checked = true;
		this.usematerialcolor.CheckState = System.Windows.Forms.CheckState.Checked;
		this.usematerialcolor.Name = "usematerialcolor";
		this.usematerialcolor.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.ExpandMaterialList, "ExpandMaterialList");
		this.ExpandMaterialList.Name = "ExpandMaterialList";
		this.ExpandMaterialList.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.addtosw, "addtosw");
		this.addtosw.Name = "addtosw";
		this.addtosw.UseVisualStyleBackColor = true;
		this.TabPage4.Controls.Add(this.Panel2);
		this.TabPage4.Controls.Add(this.Panel1);
		this.TabPage4.Controls.Add(this.Label13);
		this.TabPage4.Controls.Add(this.Label14);
		this.TabPage4.Controls.Add(this.Label15);
		resources.ApplyResources(this.TabPage4, "TabPage4");
		this.TabPage4.Name = "TabPage4";
		this.TabPage4.UseVisualStyleBackColor = true;
		this.Panel2.Controls.Add(this.TextBox1);
		resources.ApplyResources(this.Panel2, "Panel2");
		this.Panel2.Name = "Panel2";
		this.TextBox1.AcceptsReturn = true;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		resources.ApplyResources(this.TextBox1, "TextBox1");
		this.TextBox1.Name = "TextBox1";
		this.Panel1.Controls.Add(this.ListBox1);
		resources.ApplyResources(this.Panel1, "Panel1");
		this.Panel1.Name = "Panel1";
		resources.ApplyResources(this.ListBox1, "ListBox1");
		this.ListBox1.FormattingEnabled = true;
		this.ListBox1.Name = "ListBox1";
		resources.ApplyResources(this.Label13, "Label13");
		this.Label13.Name = "Label13";
		resources.ApplyResources(this.Label14, "Label14");
		this.Label14.Name = "Label14";
		resources.ApplyResources(this.Label15, "Label15");
		this.Label15.Name = "Label15";
		this.TabPage5.Controls.Add(this.macrolist);
		this.TabPage5.Controls.Add(this.Panel3);
		resources.ApplyResources(this.TabPage5, "TabPage5");
		this.TabPage5.Name = "TabPage5";
		this.TabPage5.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.macrolist, "macrolist");
		this.macrolist.FormattingEnabled = true;
		this.macrolist.Name = "macrolist";
		this.Panel3.Controls.Add(this.Button11);
		this.Panel3.Controls.Add(this.Button10);
		this.Panel3.Controls.Add(this.Button9);
		this.Panel3.Controls.Add(this.Button8);
		resources.ApplyResources(this.Panel3, "Panel3");
		this.Panel3.Name = "Panel3";
		resources.ApplyResources(this.Button11, "Button11");
		this.Button11.Name = "Button11";
		this.Button11.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Button10, "Button10");
		this.Button10.Name = "Button10";
		this.Button10.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Button9, "Button9");
		this.Button9.Name = "Button9";
		this.Button9.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.Button8, "Button8");
		this.Button8.Name = "Button8";
		this.Button8.UseVisualStyleBackColor = true;
		this.menulist.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.menu1, this.menu2, this.menu3, this.menu4, this.menu5 });
		this.menulist.Name = "Savemenu";
		this.menulist.ShowImageMargin = false;
		resources.ApplyResources(this.menulist, "menulist");
		this.menu1.Name = "menu1";
		resources.ApplyResources(this.menu1, "menu1");
		this.menu2.Name = "menu2";
		resources.ApplyResources(this.menu2, "menu2");
		this.menu3.Name = "menu3";
		resources.ApplyResources(this.menu3, "menu3");
		this.menu4.Name = "menu4";
		resources.ApplyResources(this.menu4, "menu4");
		this.menu5.Name = "menu5";
		resources.ApplyResources(this.menu5, "menu5");
		this.AcceptButton = this.OK_Button;
		resources.ApplyResources(this, "$this");
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		this.Controls.Add(this.TabControl1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.Name = "FrmOptions";
		this.ShowInTaskbar = false;
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.openmenu.ResumeLayout(false);
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage1.PerformLayout();
		this.TabPage2.ResumeLayout(false);
		this.TabPage2.PerformLayout();
		this.TabPage3.ResumeLayout(false);
		this.TabPage3.PerformLayout();
		this.TabPage4.ResumeLayout(false);
		this.TabPage4.PerformLayout();
		this.Panel2.ResumeLayout(false);
		this.Panel2.PerformLayout();
		this.Panel1.ResumeLayout(false);
		this.TabPage5.ResumeLayout(false);
		this.Panel3.ResumeLayout(false);
		this.Panel3.PerformLayout();
		this.menulist.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		CConfigMng.Config.SWver = SwVer.SelectedIndex;
		CConfigMng.Config.materialpath = materialpath.Text;
		CConfigMng.Config.ExpandMaterialList = ExpandMaterialList.Checked;
		CConfigMng.Config.usematerialcolor = usematerialcolor.Checked;
		CConfigMng.Config.rowcolor = rowcolor.SelectedIndex;
		checked
		{
			CConfigMng.Config.GetAllconfigsbool = (int)Math.Round(Conversion.Val(GetAllconfigsbool.Checked));
			CConfigMng.Config.RealTimeFilter = RealTimeFilter.Checked;
			try
			{
				CConfigMng.Config.Dropdownlist.Clear();
				if (Dropdownlist.Count >= 1)
				{
					int num = Dropdownlist.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							CConfigMng.Config.Dropdownlist.Add(Dropdownlist[num2].ToString());
							num2++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (Preview_Hotkey_list.Count >= 1)
			{
				CConfigMng.Config.Preview_Hotkey.Clear();
				int num5 = Preview_Hotkey_list.Count - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					CConfigMng.Config.Preview_Hotkey.Add(Preview_Hotkey_list[num6]);
					num6++;
				}
			}
			CConfigMng.Config.DClick_OpenInSw = DClick_OpenInSw.Checked;
			CConfigMng.Config.ReConnectClearFilter = unchecked(0 - (ReConnectClearFilter.Checked ? 1 : 0));
			CConfigMng.Config.HideSw1 = HideSw1.Checked;
			CConfigMng.Config.Previewfortool = Previewfortool.Checked;
			CConfigMng.Config.PreviewMode = PreviewMode.SelectedIndex;
			CConfigMng.Config.Thumbnail_Savetolocal = Thumbnail_Savetolocal.Checked;
			CConfigMng.Config.Thumbnail_position = Thumbnail_position.SelectedIndex;
			CConfigMng.Config.checkupdata = checkupdata.Checked;
			try
			{
				CConfigMng.Config.macrolist.Clear();
				if (macrolist.Items.Count >= 1)
				{
					int num8 = macrolist.Items.Count - 1;
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						int num4 = num8;
						if (num10 <= num4)
						{
							CConfigMng.Config.macrolist.Add(macrolist.Items[num9].ToString());
							num9++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			CConfigMng.SaveConfig();
			try
			{
				MyProject.Forms.Frmmain.RegHotKey();
				MyProject.Forms.Frmmain.ReadonlyRowMark();
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ProjectData.ClearProjectError();
			}
			Close();
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
		ExcludePropList.Clear();
	}

	private void FrmOptions_FormClosed(object sender, FormClosedEventArgs e)
	{
		ExcludePropList.Clear();
	}

	public void FrmOptions_Load(object sender, EventArgs e)
	{
		Button1.Text = char.ConvertFromUtf32(9660);
		Graphics graphics = Graphics.FromHwnd(Handle);
		dpixRatio = graphics.DpiX / 96f;
		filllistboxwithcolors(rowcolor);
		try
		{
			SwVer.SelectedIndex = CConfigMng.Config.SWver;
			if (SwVer.SelectedIndex < 0)
			{
				SwVer.SelectedIndex = 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			SwVer.SelectedIndex = 0;
			ProjectData.ClearProjectError();
		}
		try
		{
			rowcolor.SelectedIndex = CConfigMng.Config.rowcolor;
			if (rowcolor.SelectedIndex < 0)
			{
				rowcolor.SelectedIndex = 15;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			rowcolor.SelectedIndex = 15;
			ProjectData.ClearProjectError();
		}
		if (Microsoft.VisualBasic.FileIO.FileSystem.FileExists(CConfigMng.Config.materialpath))
		{
			materialpath.Text = CConfigMng.Config.materialpath;
		}
		try
		{
			ExpandMaterialList.Checked = CConfigMng.Config.ExpandMaterialList;
			usematerialcolor.Checked = CConfigMng.Config.usematerialcolor;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ProjectData.ClearProjectError();
		}
		try
		{
			GetAllconfigsbool.Checked = code.Cbool1(Conversions.ToString(CConfigMng.Config.GetAllconfigsbool));
			RealTimeFilter.Checked = CConfigMng.Config.RealTimeFilter;
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ProjectData.ClearProjectError();
		}
		checked
		{
			try
			{
				if (CConfigMng.Config.propname.Count > 0)
				{
					ListBox1.Items.Clear();
					int num = CConfigMng.Config.propname.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							string item = CConfigMng.Config.propname[num2];
							ListBox1.Items.Add(item);
							num2++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ListBox1.Items.Clear();
				ProjectData.ClearProjectError();
			}
			try
			{
				Dropdownlist.Clear();
				if (CConfigMng.Config.Dropdownlist.Count > 0)
				{
					int num5 = CConfigMng.Config.Dropdownlist.Count - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						bool flag = false;
						string[] array = Strings.Split(CConfigMng.Config.Dropdownlist[num6].ToString(), "\n");
						int num8 = Dropdownlist.Count - 1;
						int num9 = 0;
						while (true)
						{
							int num10 = num9;
							num4 = num8;
							if (num10 > num4)
							{
								break;
							}
							string[] array2 = Strings.Split(Dropdownlist[num9], "\n");
							if (Operators.CompareString(array[0].ToUpper(), array2[0].ToUpper(), TextCompare: false) == 0)
							{
								flag = true;
								break;
							}
							num9++;
						}
						if (!flag)
						{
							Dropdownlist.Add(CConfigMng.Config.Dropdownlist[num6].ToString());
						}
						num6++;
					}
				}
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				ProjectData.ClearProjectError();
			}
			Preview_Hotkey_list.Clear();
			Preview_Hotkey.ImeMode = ImeMode.Disable;
			Preview_Hotkey.Clear();
			try
			{
				int num11 = CConfigMng.Config.Preview_Hotkey.Count - 1;
				int num12 = 0;
				bool flag2 = default(bool);
				bool flag3 = default(bool);
				while (true)
				{
					int num13 = num12;
					int num4 = num11;
					if (num13 > num4)
					{
						break;
					}
					int num14 = (int)Math.Round(Conversion.Val(CConfigMng.Config.Preview_Hotkey[num12]));
					if (unchecked(num14 == 16 || num14 == 17 || num14 == 18))
					{
						if (!Preview_Hotkey.Text.Contains(code.KeyCodeToStr(num14)))
						{
							Preview_Hotkey.AppendText(code.KeyCodeToStr(num14) + "+");
							flag2 = true;
						}
					}
					else if ((Operators.CompareString(code.KeyCodeToStr(num14), "", TextCompare: false) != 0) & !Preview_Hotkey.Text.Contains(code.KeyCodeToStr(num14)))
					{
						Preview_Hotkey.AppendText(code.KeyCodeToStr(num14));
						flag3 = true;
					}
					num12++;
				}
				if (unchecked(flag2 && !flag3))
				{
					Preview_Hotkey.Clear();
				}
			}
			catch (Exception ex13)
			{
				ProjectData.SetProjectError(ex13);
				Exception ex14 = ex13;
				Preview_Hotkey.Clear();
				ProjectData.ClearProjectError();
			}
			try
			{
				DClick_OpenInSw.Checked = CConfigMng.Config.DClick_OpenInSw;
				ReConnectClearFilter.Checked = CConfigMng.Config.ReConnectClearFilter != 0;
				HideSw1.Checked = CConfigMng.Config.HideSw1;
				Previewfortool.Checked = CConfigMng.Config.Previewfortool;
			}
			catch (Exception ex15)
			{
				ProjectData.SetProjectError(ex15);
				Exception ex16 = ex15;
				ProjectData.ClearProjectError();
			}
			try
			{
				PreviewMode.SelectedIndex = CConfigMng.Config.PreviewMode;
				if (PreviewMode.SelectedIndex < 0)
				{
					PreviewMode.SelectedIndex = 0;
				}
			}
			catch (Exception ex17)
			{
				ProjectData.SetProjectError(ex17);
				Exception ex18 = ex17;
				PreviewMode.SelectedIndex = 0;
				ProjectData.ClearProjectError();
			}
			Thumbnail_Savetolocal.Checked = CConfigMng.Config.Thumbnail_Savetolocal;
			Thumbnail_position.SelectedIndex = CConfigMng.Config.Thumbnail_position;
			checkupdata.Checked = CConfigMng.Config.checkupdata;
			try
			{
				macrolist.Items.Clear();
				int num15 = CConfigMng.Config.macrolist.Count - 1;
				int num16 = 0;
				while (true)
				{
					int num17 = num16;
					int num4 = num15;
					if (num17 <= num4)
					{
						if (CConfigMng.Config.macrolist[num16].EndsWith(".swp", StringComparison.OrdinalIgnoreCase) | CConfigMng.Config.macrolist[num16].EndsWith(".swb", StringComparison.OrdinalIgnoreCase))
						{
							macrolist.Items.Add(CConfigMng.Config.macrolist[num16]);
						}
						num16++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex19)
			{
				ProjectData.SetProjectError(ex19);
				Exception ex20 = ex19;
				ProjectData.ClearProjectError();
			}
			try
			{
				othermenu.Text = "Прочее            " + char.ConvertFromUtf32(9660);
			}
			catch (Exception ex21)
			{
				ProjectData.SetProjectError(ex21);
				Exception ex22 = ex21;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void menu1_Click(object sender, EventArgs e)
	{
		MyProject.Forms.Frmmain.ResetCol();
		MyProject.Forms.Frmmain.insetpropcol();
		try
		{
			if (Conversions.ToDouble(MyProject.Forms.Frmmain._cmdButtonHidecol.Keytip) == 1.0)
			{
				MyProject.Forms.Frmmain._cmdButtonHidecol_ItemsSourceReady(null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void menu2_Click(object sender, EventArgs e)
	{
		ShortcutHelper shortcutHelper = new ShortcutHelper();
		shortcutHelper.CreateDesktopShortcut2(Application.ExecutablePath, "SWTools", "Эффективный помощник для SolidWorks\nПакетное переименование, редактирование свойств, печать, конвертация чертежей, создание спецификаций и т. д.");
	}

	private void menu3_Click(object sender, EventArgs e)
	{
		code.OpenFolderWithEX(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
	}

	private void menu4_Click(object sender, EventArgs e)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Restart();
		bool flag = code.RunSW();
		stopwatch.Stop();
		if (flag)
		{
			MessageBox.Show(Conversions.ToString(stopwatch.ElapsedMilliseconds) + "миллисекунда", "Общее время подключения к SolidWorks", MessageBoxButtons.OK, MessageBoxIcon.None);
		}
		else
		{
			MessageBox.Show("Не удалось подключиться к SolidWorks", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void menu5_Click(object sender, EventArgs e)
	{
		code.OpenFolderWithEX(logopathlist.logPath);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		look_fromsw.DropDownItems.Clear();
		openmenu.Show(Button1, 0, Button1.Height);
	}

	private void open_browse_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Шаблон SW");
		openFileDialog.Multiselect = false;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Файл базы материалов (*.sldmat)|*.sldmat";
		if (openFileDialog.ShowDialog() != DialogResult.Cancel)
		{
			materialpath.Text = openFileDialog.FileName;
		}
	}

	private void look_fromsw_Click(object sender, EventArgs e)
	{
		look_fromsw.DropDownItemClicked += mens2_click;
		look_fromsw.DropDownItems.Clear();
		List<string> list = code.getmateriallist();
		checked
		{
			int num = list.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (list[num2].Equals(CConfigMng.Config.materialpath, StringComparison.OrdinalIgnoreCase))
				{
					look_fromsw.DropDownItems.Add(list[num2]).Select();
				}
				else
				{
					look_fromsw.DropDownItems.Add(list[num2]);
				}
				num2++;
			}
			materialpath.Items.Clear();
			materialpath.Items.AddRange(code.getmateriallist().ToArray());
			openmenu.Show(Button1, 0, Button1.Height);
			look_fromsw.ShowDropDown();
		}
	}

	private void mens2_click(object sender, ToolStripItemClickedEventArgs e)
	{
		materialpath.Text = e.ClickedItem.Text;
	}

	private void addtosw_Click(object sender, EventArgs e)
	{
		if (!code.RunSW(HideWindow: false, startnew: false) && MessageBox.Show("SolidWorks не запущен, запустить сейчас?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
		{
			return;
		}
		if (!code.RunSW())
		{
			MessageBox.Show("Не удалось подключиться к SolidWorks", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else if (File.Exists(materialpath.Text))
		{
			_Closure_0024__67 closure_0024__ = new _Closure_0024__67();
			closure_0024__._0024VB_0024Local_mypath = code.SplitStr(materialpath.Text).TrimEnd('\\', '/');
			string text = Conversions.ToString(NewLateBinding.LateGet(code.swApp, null, "GetUserPreferenceStringValue", new object[1] { 28 }, null, null, null));
			List<string> list = text.Split(';').ToList();
			if (!list.Exists(closure_0024__._Lambda_0024__122))
			{
				text = text + ";" + closure_0024__._0024VB_0024Local_mypath;
				object swApp = code.swApp;
				object[] array = new object[2] { 28, text };
				bool[] array2 = new bool[2] { false, true };
				object value = NewLateBinding.LateGet(swApp, null, "SetUserPreferenceStringValue", array, null, null, array2);
				if (array2[1])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				}
				if (!Conversions.ToBoolean(value))
				{
					MessageBox.Show("Не удалось применить настройку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}
		else
		{
			MessageBox.Show("Файл библиотеки материалов не существует! Добавьте библиотеку заново.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void rowcolor_Click_1(object sender, EventArgs e)
	{
		ColorDialog colorDialog = new ColorDialog();
		if (colorDialog.ShowDialog() != DialogResult.Cancel)
		{
			rowcolor.BackColor = colorDialog.Color;
		}
	}

	private void rowcolor_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index >= 0)
		{
			e.DrawBackground();
			object item = rowcolor.Items[e.Index];
			string text = GetColorDisplayName(item);
			string colorName = GetColorName(item);
			Rectangle rect = checked(new Rectangle(e.Bounds.Left + Dpi(3), e.Bounds.Top + Dpi(3), Math.Max(Dpi(16), e.Bounds.Height - Dpi(6)), Math.Max(Dpi(16), e.Bounds.Height - Dpi(6))));
			using (SolidBrush brush = new SolidBrush(Color.FromName(colorName)))
			{
				e.Graphics.FillRectangle(brush, rect);
			}
			e.Graphics.DrawRectangle(Pens.Black, rect);
			Rectangle bounds = new Rectangle(rect.Right + Dpi(8), e.Bounds.Top, Math.Max(Dpi(60), e.Bounds.Right - rect.Right - Dpi(10)), e.Bounds.Height);
			Color foreColor = (((e.State & DrawItemState.Selected) != DrawItemState.None) ? SystemColors.HighlightText : rowcolor.ForeColor);
			TextRenderer.DrawText(e.Graphics, text, rowcolor.Font, bounds, foreColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
			e.DrawFocusRectangle();
		}
	}

	private void filllistboxwithcolors(ComboBox combox)
	{
		combox.DrawMode = DrawMode.OwnerDrawFixed;
		combox.DropDownStyle = ComboBoxStyle.DropDownList;
		combox.ItemHeight = checked((int)Math.Round(18.0 * dpixRatio));
		combox.BeginUpdate();
		combox.Items.Clear();
		PropertyInfo[] properties = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public);
		foreach (PropertyInfo propertyInfo in properties)
		{
			combox.Items.Add(new ColorListItem(propertyInfo.Name));
		}
		combox.EndUpdate();
	}

	internal string GetSelectedRowColorName()
	{
		return GetColorName(rowcolor.SelectedItem);
	}

	private static string GetColorName(object item)
	{
		if (item is ColorListItem colorListItem)
		{
			return colorListItem.Name;
		}
		return Conversions.ToString(item);
	}

	private static string GetColorDisplayName(object item)
	{
		if (item is ColorListItem colorListItem)
		{
			return colorListItem.ToString();
		}
		return TranslateColorName(Conversions.ToString(item));
	}

	private static string TranslateColorName(string name)
	{
		switch (name)
		{
		case "Transparent":
			return "Прозрачный";
		case "Black":
			return "Черный";
		case "DimGray":
			return "Темно-серый";
		case "Gray":
			return "Серый";
		case "DarkGray":
			return "Темно-серый";
		case "Silver":
			return "Серебристый";
		case "LightGray":
			return "Светло-серый";
		case "Gainsboro":
			return "Светло-серый";
		case "WhiteSmoke":
			return "Дымчато-белый";
		case "White":
			return "Белый";
		case "RosyBrown":
			return "Розово-коричневый";
		case "IndianRed":
			return "Индийский красный";
		case "Brown":
			return "Коричневый";
		case "Firebrick":
			return "Кирпичный";
		case "LightCoral":
			return "Светло-коралловый";
		case "Maroon":
			return "Бордовый";
		case "DarkRed":
			return "Темно-красный";
		case "Red":
			return "Красный";
		case "MistyRose":
			return "Бледно-розовый";
		case "Salmon":
			return "Лососевый";
		case "Tomato":
			return "Томатный";
		case "DarkSalmon":
			return "Темно-лососевый";
		case "Coral":
			return "Коралловый";
		case "OrangeRed":
			return "Оранжево-красный";
		case "LightSalmon":
			return "Светло-лососевый";
		case "Sienna":
			return "Сиена";
		case "SeaShell":
			return "Морская ракушка";
		case "Chocolate":
			return "Шоколадный";
		case "SaddleBrown":
			return "Темно-коричневый";
		case "SandyBrown":
			return "Песочно-коричневый";
		case "PeachPuff":
			return "Персиковый";
		case "Peru":
			return "Перу";
		case "Linen":
			return "Льняной";
		case "Bisque":
			return "Бисквитный";
		case "DarkOrange":
			return "Темно-оранжевый";
		case "BurlyWood":
			return "Светло-коричневый";
		case "Tan":
			return "Желто-коричневый";
		case "AntiqueWhite":
			return "Античный белый";
		case "NavajoWhite":
			return "Навахо";
		case "BlanchedAlmond":
			return "Бланшированный миндаль";
		case "PapayaWhip":
			return "Папайя";
		case "Moccasin":
			return "Мокасин";
		case "Orange":
			return "Оранжевый";
		case "Wheat":
			return "Пшеничный";
		case "OldLace":
			return "Старое кружево";
		case "FloralWhite":
			return "Цветочно-белый";
		case "DarkGoldenrod":
			return "Темно-золотистый";
		case "Goldenrod":
			return "Золотистый";
		case "Cornsilk":
			return "Кукурузный шелк";
		case "Gold":
			return "Золотой";
		case "LemonChiffon":
			return "Лимонный";
		case "Khaki":
			return "Хаки";
		case "PaleGoldenrod":
			return "Бледно-золотистый";
		case "DarkKhaki":
			return "Темный хаки";
		case "Ivory":
			return "Слоновая кость";
		case "Beige":
			return "Бежевый";
		case "LightYellow":
			return "Светло-желтый";
		case "LightGoldenrodYellow":
			return "Светло-золотистый";
		case "Olive":
			return "Оливковый";
		case "Yellow":
			return "Желтый";
		case "OliveDrab":
			return "Оливково-серый";
		case "YellowGreen":
			return "Желто-зеленый";
		case "DarkOliveGreen":
			return "Темно-оливковый";
		case "GreenYellow":
			return "Зелено-желтый";
		case "Chartreuse":
			return "Шартрез";
		case "LawnGreen":
			return "Газонный";
		case "DarkSeaGreen":
			return "Темный морской зеленый";
		case "ForestGreen":
			return "Лесной зеленый";
		case "LimeGreen":
			return "Лаймово-зеленый";
		case "LightGreen":
			return "Светло-зеленый";
		case "PaleGreen":
			return "Бледно-зеленый";
		case "DarkGreen":
			return "Темно-зеленый";
		case "Green":
			return "Зеленый";
		case "Lime":
			return "Лайм";
		case "Honeydew":
			return "Медовая роса";
		case "SeaGreen":
			return "Морской зеленый";
		case "MediumSeaGreen":
			return "Средний морской зеленый";
		case "SpringGreen":
			return "Весенний зеленый";
		case "MintCream":
			return "Мятно-кремовый";
		case "MediumSpringGreen":
			return "Средний весенний зеленый";
		case "MediumAquamarine":
			return "Средний аквамарин";
		case "Aquamarine":
			return "Аквамарин";
		case "Turquoise":
			return "Бирюзовый";
		case "LightSeaGreen":
			return "Светлый морской зеленый";
		case "MediumTurquoise":
			return "Средний бирюзовый";
		case "Azure":
			return "Лазурный";
		case "LightCyan":
			return "Светло-голубой";
		case "PaleTurquoise":
			return "Бледно-бирюзовый";
		case "DarkSlateGray":
			return "Темный серо-синий";
		case "Teal":
			return "Сине-зеленый";
		case "DarkCyan":
			return "Темно-голубой";
		case "Aqua":
			return "Аква";
		case "Cyan":
			return "Голубой";
		case "DarkTurquoise":
			return "Темно-бирюзовый";
		case "CadetBlue":
			return "Серо-синий";
		case "PowderBlue":
			return "Пудрово-голубой";
		case "LightBlue":
			return "Светло-синий";
		case "DeepSkyBlue":
			return "Глубокий небесный";
		case "SkyBlue":
			return "Небесно-голубой";
		case "LightSkyBlue":
			return "Светлый небесный";
		case "SteelBlue":
			return "Стальной синий";
		case "AliceBlue":
			return "Алиса";
		case "DodgerBlue":
			return "Ярко-синий";
		case "SlateGray":
			return "Сланцево-серый";
		case "LightSlateGray":
			return "Светлый сланцево-серый";
		case "LightSteelBlue":
			return "Светлый стальной";
		case "CornflowerBlue":
			return "Васильковый";
		case "RoyalBlue":
			return "Королевский синий";
		case "GhostWhite":
			return "Призрачно-белый";
		case "Lavender":
			return "Лавандовый";
		case "MidnightBlue":
			return "Полуночный синий";
		case "Navy":
			return "Темно-синий";
		case "DarkBlue":
			return "Темно-синий";
		case "MediumBlue":
			return "Средний синий";
		case "Blue":
			return "Синий";
		case "SlateBlue":
			return "Сланцево-синий";
		case "DarkSlateBlue":
			return "Темный сланцево-синий";
		case "MediumSlateBlue":
			return "Средний сланцево-синий";
		case "MediumPurple":
			return "Средний пурпурный";
		case "BlueViolet":
			return "Сине-фиолетовый";
		case "Indigo":
			return "Индиго";
		case "DarkOrchid":
			return "Темная орхидея";
		case "DarkViolet":
			return "Темно-фиолетовый";
		case "MediumOrchid":
			return "Средняя орхидея";
		case "Thistle":
			return "Чертополох";
		case "Plum":
			return "Сливовый";
		case "Violet":
			return "Фиолетовый";
		case "Purple":
			return "Пурпурный";
		case "DarkMagenta":
			return "Темная маджента";
		case "Fuchsia":
			return "Фуксия";
		case "Magenta":
			return "Маджента";
		case "Orchid":
			return "Орхидея";
		case "MediumVioletRed":
			return "Средний фиолетово-красный";
		case "DeepPink":
			return "Насыщенный розовый";
		case "HotPink":
			return "Ярко-розовый";
		case "LavenderBlush":
			return "Лавандовый румянец";
		case "PaleVioletRed":
			return "Бледный фиолетово-красный";
		case "Crimson":
			return "Малиновый";
		case "Pink":
			return "Розовый";
		case "LightPink":
			return "Светло-розовый";
		}
		return name;
	}

	private void Preview_Hotkey_KeyDown(object sender, KeyEventArgs e)
	{
		e.SuppressKeyPress = true;
		string text = "";
		Preview_Hotkey_list.Clear();
		if (e.Control)
		{
			text = code.KeyCodeToStr(17) + "+";
			Preview_Hotkey_list.Add(Conversions.ToString(17));
		}
		if (e.Shift)
		{
			text = text + code.KeyCodeToStr(16) + "+";
			Preview_Hotkey_list.Add(Conversions.ToString(16));
		}
		if (e.Alt)
		{
			text = text + code.KeyCodeToStr(18) + "+";
			Preview_Hotkey_list.Add(Conversions.ToString(18));
		}
		if ((e.KeyCode != Keys.ShiftKey) & (e.KeyCode != Keys.ControlKey) & (e.KeyCode != Keys.Menu))
		{
			Preview_Hotkey.Clear();
			if (Operators.CompareString(code.KeyCodeToStr((int)e.KeyCode), "", TextCompare: false) != 0)
			{
				Preview_Hotkey.SelectedText = text + code.KeyCodeToStr((int)e.KeyCode);
				Preview_Hotkey_list.Add(Conversions.ToString((int)e.KeyCode));
			}
		}
	}

	private void Preview_Hotkey_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.Clear();
			Preview_Hotkey.ContextMenuStrip = contextMenuStrip;
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (((int)msg.WParam == 9) & (Control.FromHandle(Preview_Hotkey.Handle) is TextBox))
		{
			Preview_Hotkey.Text = Keys.Tab.ToString();
			Preview_Hotkey_list.Clear();
			Preview_Hotkey_list.Add(Conversions.ToString(9));
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		bool flag = false;
		TextBox1.Enabled = true;
		checked
		{
			try
			{
				Colheadtext = ListBox1.SelectedItem.ToString();
				if (Dropdownlist.Count < 1)
				{
					return;
				}
				int num = Dropdownlist.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string[] array = Strings.Split(Dropdownlist[num2].ToString(), "\n");
					if (Operators.CompareString(array[0], Colheadtext, TextCompare: false) == 0)
					{
						flag = true;
						TextBox1.Clear();
						if (array.Length <= 1)
						{
							break;
						}
						int num5 = array.Length - 1;
						int num6 = 1;
						while (true)
						{
							int num7 = num6;
							num4 = num5;
							if (num7 <= num4)
							{
								if (num6 != array.Length - 1)
								{
									TextBox1.AppendText(array[num6].Trim('\n').Trim('\r') + Environment.NewLine);
								}
								else
								{
									TextBox1.AppendText(array[num6].Trim('\n').Trim('\r'));
								}
								num6++;
								continue;
							}
							break;
						}
						break;
					}
					num2++;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (!flag)
			{
				TextBox1.Clear();
			}
		}
	}

	private void TextBox1_TextChanged(object sender, EventArgs e)
	{
		bool flag = false;
		checked
		{
			int num = Dropdownlist.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string[] array = Strings.Split(Dropdownlist[num2].ToString(), "\n");
				if (Operators.CompareString(array[0], Colheadtext, TextCompare: false) == 0)
				{
					flag = true;
					break;
				}
				num2++;
			}
			if (flag)
			{
				Dropdownlist[num2] = Colheadtext + "\n" + TextBox1.Text;
			}
			else
			{
				Dropdownlist.Add(Colheadtext + "\n" + TextBox1.Text);
			}
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		menulist.Show(othermenu, 0, othermenu.Height);
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		FrmPreview frmPreview = MyProject.Forms.FrmPreview;
		Point location = new Point(0, 0);
		frmPreview.Location = location;
		CConfigDO config = CConfigMng.Config;
		location = new Point(0, 0);
		config.FrmPreviewLocation = location;
	}

	private void Button7_Click(object sender, EventArgs e)
	{
		if (!Directory.Exists(logopathlist.PreviewFolder))
		{
			logopathlist.PreviewFolder = Directory.CreateDirectory(logopathlist.PreviewFolder).FullName;
		}
		code.OpenFolderWithEX(logopathlist.PreviewFolder);
	}

	private void Button8_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Файл макроса SolidWorks (*.swb;*.swp)|*.swb;*.swp";
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string fileName = openFileDialog.FileName;
		bool flag = false;
		checked
		{
			int num = macrolist.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (string.Compare(macrolist.Items[num2].ToString(), fileName, ignoreCase: true) == 0)
				{
					flag = true;
					break;
				}
				num2++;
			}
			if (!flag & File.Exists(fileName))
			{
				macrolist.Items.Add(fileName);
			}
		}
	}

	private void Button9_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				int num = macrolist.Items.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						if (num2 < macrolist.Items.Count && macrolist.GetSelected(num2))
						{
							macrolist.Items.RemoveAt(num2);
							num2--;
						}
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
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void Button10_Click(object sender, EventArgs e)
	{
		int selectedIndex = macrolist.SelectedIndex;
		checked
		{
			if (selectedIndex > 0)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(macrolist.SelectedItem);
				macrolist.Items.RemoveAt(selectedIndex);
				macrolist.Items.Insert(selectedIndex, RuntimeHelpers.GetObjectValue(macrolist.Items[selectedIndex - 1]));
				macrolist.Items.RemoveAt(selectedIndex - 1);
				macrolist.Items.Insert(selectedIndex - 1, RuntimeHelpers.GetObjectValue(objectValue));
				macrolist.SelectedIndex = selectedIndex - 1;
			}
		}
	}

	private void Button11_Click(object sender, EventArgs e)
	{
		int selectedIndex = macrolist.SelectedIndex;
		checked
		{
			if ((selectedIndex < macrolist.Items.Count - 1 && selectedIndex >= 0) ? true : false)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(macrolist.SelectedItem);
				macrolist.Items.RemoveAt(selectedIndex);
				macrolist.Items.Insert(selectedIndex + 1, RuntimeHelpers.GetObjectValue(objectValue));
				macrolist.SelectedIndex = selectedIndex + 1;
			}
		}
	}
}
