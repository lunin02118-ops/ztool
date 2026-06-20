using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmFilling : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__77
	{
		public string _0024VB_0024Local_findstr3;

		[DebuggerNonUserCode]
		public _Closure_0024__77()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__77(_Closure_0024__77 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_findstr3 = other._0024VB_0024Local_findstr3;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__134(string s1)
		{
			return s1.Equals(_0024VB_0024Local_findstr3, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__78
	{
		public string _0024VB_0024Local_findstr3;

		[DebuggerNonUserCode]
		public _Closure_0024__78()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__78(_Closure_0024__78 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_findstr3 = other._0024VB_0024Local_findstr3;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__135(string s1)
		{
			return s1.Equals(_0024VB_0024Local_findstr3, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__79
	{
		public string _0024VB_0024Local_name;

		[DebuggerNonUserCode]
		public _Closure_0024__79(_Closure_0024__79 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_name = other._0024VB_0024Local_name;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__79()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__136(string s)
		{
			return s.Equals(_0024VB_0024Local_name, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__80
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__80()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__80(_Closure_0024__80 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__137(fillsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__81
	{
		public string _0024VB_0024Local_RuleName;

		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__81()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__81(_Closure_0024__81 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_RuleName = other._0024VB_0024Local_RuleName;
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__138(fillsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_RuleName, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__139(fillsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__82
	{
		public string _0024VB_0024Local_RuleName;

		[DebuggerNonUserCode]
		public _Closure_0024__82(_Closure_0024__82 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_RuleName = other._0024VB_0024Local_RuleName;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__82()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__140(fillsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_RuleName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__83
	{
		[CompilerGenerated]
		internal class _Closure_0024__84
		{
			public string _0024VB_0024Local_name;

			[DebuggerNonUserCode]
			public _Closure_0024__84(_Closure_0024__84 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_name = other._0024VB_0024Local_name;
				}
			}

			[DebuggerNonUserCode]
			public _Closure_0024__84()
			{
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__142(string s)
			{
				return s.Equals(_0024VB_0024Local_name, StringComparison.OrdinalIgnoreCase);
			}
		}

		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__83()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__83(_Closure_0024__83 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__141(fillsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__85
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__85()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__85(_Closure_0024__85 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__143(fillsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Undo_Button")]
	private Button _Undo_Button;

	[AccessedThroughProperty("TabControl1")]
	private TabControl _TabControl1;

	[AccessedThroughProperty("TabPage1")]
	private TabPage _TabPage1;

	[AccessedThroughProperty("TabPage2")]
	private TabPage _TabPage2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("NumericUpDown1")]
	private NumericUpDown _NumericUpDown1;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("TextBox2")]
	private TextBox _TextBox2;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("GroupBox5")]
	private GroupBox _GroupBox5;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("add")]
	private Button _add;

	[AccessedThroughProperty("edit")]
	private Button _edit;

	[AccessedThroughProperty("del")]
	private Button _del;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("RuleList")]
	private CheckedListBox _RuleList;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("TextBox3")]
	private TextBox _TextBox3;

	[AccessedThroughProperty("Label9")]
	private Label _Label9;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	[AccessedThroughProperty("fillsettinglist")]
	private ListBox _fillsettinglist;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("TabPage3")]
	private TabPage _TabPage3;

	[AccessedThroughProperty("datasource")]
	private TextBox _datasource;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Label11")]
	private Label _Label11;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("srownumer")]
	private NumericUpDown _srownumer;

	[AccessedThroughProperty("rcolnumer1")]
	private NumericUpDown _rcolnumer1;

	[AccessedThroughProperty("Label12")]
	private Label _Label12;

	[AccessedThroughProperty("Label10")]
	private Label _Label10;

	[AccessedThroughProperty("ComboBox4")]
	private ComboBox _ComboBox4;

	[AccessedThroughProperty("ComboBox3")]
	private ComboBox _ComboBox3;

	[AccessedThroughProperty("rcolnumer2")]
	private NumericUpDown _rcolnumer2;

	[AccessedThroughProperty("Label14")]
	private Label _Label14;

	[AccessedThroughProperty("Label13")]
	private Label _Label13;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Label15")]
	private Label _Label15;

	[AccessedThroughProperty("datacount")]
	private Label _datacount;

	[AccessedThroughProperty("GroupBox6")]
	private GroupBox _GroupBox6;

	[AccessedThroughProperty("TabPage4")]
	private TabPage _TabPage4;

	[AccessedThroughProperty("DGV1")]
	private DataGridView _DGV1;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("name_list")]
	private ToolStripComboBox _name_list;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("Label16")]
	private Label _Label16;

	[AccessedThroughProperty("delcolumn")]
	private ToolStripDropDownButton _delcolumn;

	[AccessedThroughProperty("adddata")]
	private ToolStripButton _adddata;

	[AccessedThroughProperty("addcolumn")]
	private ToolStripButton _addcolumn;

	[AccessedThroughProperty("openmenu")]
	private ContextMenuStrip _openmenu;

	[AccessedThroughProperty("open_browse")]
	private ToolStripMenuItem _open_browse;

	[AccessedThroughProperty("open_excel")]
	private ToolStripMenuItem _open_excel;

	[AccessedThroughProperty("open_folder")]
	private ToolStripMenuItem _open_folder;

	private List<int> ColList;

	private List<DataGridViewCell> CellArr;

	private List<string> CellValArr;

	private List<Color> CellColorArr;

	private List<DataGridViewRow> RowArr;

	private List<bool> Ismodifylist;

	private List<string> vallist;

	private ContextMenuStrip menu1;

	private List<int> ColList2;

	private List<int> ColList3;

	private List<int> ColList4;

	private double dpixRatio;

	public Hashtable hb;

	private DataTable dt;

	private double formwidth;

	private double formheight;

	private bool changeing;

	private Color mLinearColor1;

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

	internal virtual ComboBox ComboBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox1 = value;
		}
	}

	internal virtual TableLayoutPanel TableLayoutPanel2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel2 = value;
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

	internal virtual Button Undo_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Undo_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Undo_Button_Click;
			if (_Undo_Button != null)
			{
				_Undo_Button.Click -= value2;
			}
			_Undo_Button = value;
			if (_Undo_Button != null)
			{
				_Undo_Button.Click += value2;
			}
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
			TabControlEventHandler value2 = TabControl1_Selected;
			if (_TabControl1 != null)
			{
				_TabControl1.Selected -= value2;
			}
			_TabControl1 = value;
			if (_TabControl1 != null)
			{
				_TabControl1.Selected += value2;
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
			_TextBox1 = value;
		}
	}

	internal virtual NumericUpDown NumericUpDown1
	{
		[DebuggerNonUserCode]
		get
		{
			return _NumericUpDown1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_NumericUpDown1 = value;
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

	internal virtual TextBox TextBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox2 = value;
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

	private Label Label5
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

	internal virtual Button add
	{
		[DebuggerNonUserCode]
		get
		{
			return _add;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = add_Click;
			if (_add != null)
			{
				_add.Click -= value2;
			}
			_add = value;
			if (_add != null)
			{
				_add.Click += value2;
			}
		}
	}

	internal virtual Button edit
	{
		[DebuggerNonUserCode]
		get
		{
			return _edit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = edit_Click;
			if (_edit != null)
			{
				_edit.Click -= value2;
			}
			_edit = value;
			if (_edit != null)
			{
				_edit.Click += value2;
			}
		}
	}

	internal virtual Button del
	{
		[DebuggerNonUserCode]
		get
		{
			return _del;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = del_Click;
			if (_del != null)
			{
				_del.Click -= value2;
			}
			_del = value;
			if (_del != null)
			{
				_del.Click += value2;
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

	internal virtual CheckedListBox RuleList
	{
		[DebuggerNonUserCode]
		get
		{
			return _RuleList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RuleList_SelectedIndexChanged;
			if (_RuleList != null)
			{
				_RuleList.SelectedIndexChanged -= value2;
			}
			_RuleList = value;
			if (_RuleList != null)
			{
				_RuleList.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual LinkLabel LinkLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _LinkLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = LinkLabel1_LinkClicked;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.LinkClicked -= value2;
			}
			_LinkLabel1 = value;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.LinkClicked += value2;
			}
		}
	}

	internal virtual TextBox TextBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TextBox3_TextChanged;
			if (_TextBox3 != null)
			{
				_TextBox3.TextChanged -= value2;
			}
			_TextBox3 = value;
			if (_TextBox3 != null)
			{
				_TextBox3.TextChanged += value2;
			}
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

	internal virtual ComboBox ComboBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ComboBox2_SelectedIndexChanged;
			if (_ComboBox2 != null)
			{
				_ComboBox2.SelectedIndexChanged -= value2;
			}
			_ComboBox2 = value;
			if (_ComboBox2 != null)
			{
				_ComboBox2.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ListBox fillsettinglist
	{
		[DebuggerNonUserCode]
		get
		{
			return _fillsettinglist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = fillsettinglist_SelectedIndexChanged;
			if (_fillsettinglist != null)
			{
				_fillsettinglist.SelectedIndexChanged -= value2;
			}
			_fillsettinglist = value;
			if (_fillsettinglist != null)
			{
				_fillsettinglist.SelectedIndexChanged += value2;
			}
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

	internal virtual TextBox datasource
	{
		[DebuggerNonUserCode]
		get
		{
			return _datasource;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_datasource = value;
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

	internal virtual NumericUpDown srownumer
	{
		[DebuggerNonUserCode]
		get
		{
			return _srownumer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = srownumer_ValueChanged;
			if (_srownumer != null)
			{
				_srownumer.ValueChanged -= value2;
			}
			_srownumer = value;
			if (_srownumer != null)
			{
				_srownumer.ValueChanged += value2;
			}
		}
	}

	internal virtual NumericUpDown rcolnumer1
	{
		[DebuggerNonUserCode]
		get
		{
			return _rcolnumer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_rcolnumer1 = value;
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

	internal virtual ComboBox ComboBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox4 = value;
		}
	}

	internal virtual ComboBox ComboBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox3 = value;
		}
	}

	internal virtual NumericUpDown rcolnumer2
	{
		[DebuggerNonUserCode]
		get
		{
			return _rcolnumer2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_rcolnumer2 = value;
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

	internal virtual Label datacount
	{
		[DebuggerNonUserCode]
		get
		{
			return _datacount;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_datacount = value;
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

	internal virtual DataGridView DGV1
	{
		[DebuggerNonUserCode]
		get
		{
			return _DGV1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = DGV1_Sorted;
			DataGridViewCellMouseEventHandler value3 = DGV1_CellMouseDoubleClick;
			DataGridViewDataErrorEventHandler value4 = DGV1_DataError;
			DataGridViewCellPaintingEventHandler value5 = DGV1_CellPainting;
			if (_DGV1 != null)
			{
				_DGV1.Sorted -= value2;
				_DGV1.CellMouseDoubleClick -= value3;
				_DGV1.DataError -= value4;
				_DGV1.CellPainting -= value5;
			}
			_DGV1 = value;
			if (_DGV1 != null)
			{
				_DGV1.Sorted += value2;
				_DGV1.CellMouseDoubleClick += value3;
				_DGV1.DataError += value4;
				_DGV1.CellPainting += value5;
			}
		}
	}

	internal virtual ToolStrip ToolStrip1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStrip1 = value;
		}
	}

	internal virtual ToolStripComboBox name_list
	{
		[DebuggerNonUserCode]
		get
		{
			return _name_list;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = name_list_Click;
			if (_name_list != null)
			{
				_name_list.DropDown -= value2;
			}
			_name_list = value;
			if (_name_list != null)
			{
				_name_list.DropDown += value2;
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

	internal virtual ToolStripDropDownButton delcolumn
	{
		[DebuggerNonUserCode]
		get
		{
			return _delcolumn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addcolumn_MouseEnter;
			ToolStripItemClickedEventHandler value3 = delcolumn_DropDownItemClicked;
			EventHandler value4 = delcolumn_DropDownOpening;
			if (_delcolumn != null)
			{
				_delcolumn.MouseEnter -= value2;
				_delcolumn.DropDownItemClicked -= value3;
				_delcolumn.DropDownOpening -= value4;
			}
			_delcolumn = value;
			if (_delcolumn != null)
			{
				_delcolumn.MouseEnter += value2;
				_delcolumn.DropDownItemClicked += value3;
				_delcolumn.DropDownOpening += value4;
			}
		}
	}

	internal virtual ToolStripButton adddata
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddata;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addcolumn_MouseEnter;
			EventHandler value3 = adddata_Click;
			if (_adddata != null)
			{
				_adddata.MouseEnter -= value2;
				_adddata.Click -= value3;
			}
			_adddata = value;
			if (_adddata != null)
			{
				_adddata.MouseEnter += value2;
				_adddata.Click += value3;
			}
		}
	}

	internal virtual ToolStripButton addcolumn
	{
		[DebuggerNonUserCode]
		get
		{
			return _addcolumn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addcolumn_MouseEnter;
			EventHandler value3 = addcolumn_Click;
			if (_addcolumn != null)
			{
				_addcolumn.MouseEnter -= value2;
				_addcolumn.Click -= value3;
			}
			_addcolumn = value;
			if (_addcolumn != null)
			{
				_addcolumn.MouseEnter += value2;
				_addcolumn.Click += value3;
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

	internal virtual ToolStripMenuItem open_excel
	{
		[DebuggerNonUserCode]
		get
		{
			return _open_excel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = open_excel_Click;
			if (_open_excel != null)
			{
				_open_excel.Click -= value2;
			}
			_open_excel = value;
			if (_open_excel != null)
			{
				_open_excel.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem open_folder
	{
		[DebuggerNonUserCode]
		get
		{
			return _open_folder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = open_folder_Click;
			if (_open_folder != null)
			{
				_open_folder.Click -= value2;
			}
			_open_folder = value;
			if (_open_folder != null)
			{
				_open_folder.Click += value2;
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.FrmFilling));
		this.Label1 = new System.Windows.Forms.Label();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Undo_Button = new System.Windows.Forms.Button();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.TextBox3 = new System.Windows.Forms.TextBox();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.RuleList = new System.Windows.Forms.CheckedListBox();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.add = new System.Windows.Forms.Button();
		this.edit = new System.Windows.Forms.Button();
		this.del = new System.Windows.Forms.Button();
		this.fillsettinglist = new System.Windows.Forms.ListBox();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.GroupBox6 = new System.Windows.Forms.GroupBox();
		this.ComboBox4 = new System.Windows.Forms.ComboBox();
		this.Label10 = new System.Windows.Forms.Label();
		this.ComboBox3 = new System.Windows.Forms.ComboBox();
		this.Label12 = new System.Windows.Forms.Label();
		this.rcolnumer2 = new System.Windows.Forms.NumericUpDown();
		this.Label13 = new System.Windows.Forms.Label();
		this.rcolnumer1 = new System.Windows.Forms.NumericUpDown();
		this.Label14 = new System.Windows.Forms.Label();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.datacount = new System.Windows.Forms.Label();
		this.Label15 = new System.Windows.Forms.Label();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.openmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.open_browse = new System.Windows.Forms.ToolStripMenuItem();
		this.open_excel = new System.Windows.Forms.ToolStripMenuItem();
		this.open_folder = new System.Windows.Forms.ToolStripMenuItem();
		this.srownumer = new System.Windows.Forms.NumericUpDown();
		this.Label11 = new System.Windows.Forms.Label();
		this.datasource = new System.Windows.Forms.TextBox();
		this.TabPage4 = new System.Windows.Forms.TabPage();
		this.DGV1 = new System.Windows.Forms.DataGridView();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Label16 = new System.Windows.Forms.Label();
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.name_list = new System.Windows.Forms.ToolStripComboBox();
		this.addcolumn = new System.Windows.Forms.ToolStripButton();
		this.delcolumn = new System.Windows.Forms.ToolStripDropDownButton();
		this.adddata = new System.Windows.Forms.ToolStripButton();
		this.TableLayoutPanel2.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).BeginInit();
		this.TabPage2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox5.SuspendLayout();
		this.TableLayoutPanel1.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.GroupBox6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.rcolnumer2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.rcolnumer1).BeginInit();
		this.GroupBox4.SuspendLayout();
		this.openmenu.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.srownumer).BeginInit();
		this.TabPage4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		this.Panel1.SuspendLayout();
		this.ToolStrip1.SuspendLayout();
		this.SuspendLayout();
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label = this.Label1;
		System.Drawing.Point location = new System.Drawing.Point(9, 8);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		System.Drawing.Size size = new System.Drawing.Size(104, 17);
		label2.Size = size;
		this.Label1.TabIndex = 6;
		this.Label1.Text = "Выберите столбцы для заполнения:";
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox1;
		location = new System.Drawing.Point(9, 30);
		comboBox.Location = location;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox1;
		size = new System.Drawing.Size(196, 25);
		comboBox2.Size = size;
		this.ComboBox1.TabIndex = 4;
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel2.AutoSize = true;
		this.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
		this.TableLayoutPanel2.ColumnCount = 2;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99751f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00249f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel2.Controls.Add(this.OK_Button, 1, 0);
		this.TableLayoutPanel2.Controls.Add(this.Undo_Button, 0, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel2;
		location = new System.Drawing.Point(232, 332);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(189, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel2.TabIndex = 3;
		this.TableLayoutPanel2.TabStop = true;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(108, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "ОК";
		this.Undo_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Undo_Button.AutoSize = true;
		System.Windows.Forms.Button undo_Button = this.Undo_Button;
		location = new System.Drawing.Point(13, 3);
		undo_Button.Location = location;
		this.Undo_Button.Name = "Undo_Button";
		System.Windows.Forms.Button undo_Button2 = this.Undo_Button;
		size = new System.Drawing.Size(67, 27);
		undo_Button2.Size = size;
		this.Undo_Button.TabIndex = 3;
		this.Undo_Button.Text = "Отменить";
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Controls.Add(this.TabPage4);
		this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TabControl tabControl = this.TabControl1;
		size = new System.Drawing.Size(72, 22);
		tabControl.ItemSize = size;
		System.Windows.Forms.TabControl tabControl2 = this.TabControl1;
		location = new System.Drawing.Point(0, 0);
		tabControl2.Location = location;
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		System.Windows.Forms.TabControl tabControl3 = this.TabControl1;
		size = new System.Drawing.Size(433, 330);
		tabControl3.Size = size;
		this.TabControl1.TabIndex = 7;
		this.TabPage1.BackColor = System.Drawing.Color.White;
		this.TabPage1.Controls.Add(this.ComboBox1);
		this.TabPage1.Controls.Add(this.TextBox1);
		this.TabPage1.Controls.Add(this.GroupBox1);
		this.TabPage1.Controls.Add(this.Label1);
		this.TabPage1.Controls.Add(this.Button1);
		this.TabPage1.Controls.Add(this.NumericUpDown1);
		this.TabPage1.Controls.Add(this.Label6);
		this.TabPage1.Controls.Add(this.Label3);
		System.Windows.Forms.TabPage tabPage = this.TabPage1;
		location = new System.Drawing.Point(4, 26);
		tabPage.Location = location;
		this.TabPage1.Name = "TabPage1";
		System.Windows.Forms.TabPage tabPage2 = this.TabPage1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(3);
		tabPage2.Padding = padding;
		System.Windows.Forms.TabPage tabPage3 = this.TabPage1;
		size = new System.Drawing.Size(425, 300);
		tabPage3.Size = size;
		this.TabPage1.TabIndex = 1;
		this.TabPage1.Text = "Пользовательское заполнение";
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(8, 88);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		textBox2.Margin = padding;
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		size = new System.Drawing.Size(296, 66);
		textBox3.Size = size;
		this.TextBox1.TabIndex = 13;
		this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
		this.GroupBox1.Controls.Add(this.TextBox2);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.Label8);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(8, 168);
		groupBox.Location = location;
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox2.Margin = padding;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox3.Padding = padding;
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox1;
		size = new System.Drawing.Size(408, 120);
		groupBox4.Size = size;
		this.GroupBox1.TabIndex = 34;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Инструкция";
		this.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox4 = this.TextBox2;
		location = new System.Drawing.Point(21, 48);
		textBox4.Location = location;
		System.Windows.Forms.TextBox textBox5 = this.TextBox2;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		textBox5.Margin = padding;
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.TextBox2;
		size = new System.Drawing.Size(171, 23);
		textBox6.Size = size;
		this.TextBox2.TabIndex = 16;
		this.TextBox2.Text = "$图号$-$零件名称$-{001}";
		this.Label4.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label4;
		location = new System.Drawing.Point(19, 24);
		label3.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label4 = this.Label4;
		size = new System.Drawing.Size(44, 17);
		label4.Size = size;
		this.Label4.TabIndex = 15;
		this.Label4.Text = "Пример:";
		this.Label5.AutoSize = true;
		this.Label5.BackColor = System.Drawing.Color.Transparent;
		this.Label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Label5.ForeColor = System.Drawing.Color.DarkOrange;
		System.Windows.Forms.Label label5 = this.Label5;
		location = new System.Drawing.Point(208, 16);
		label5.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label6 = this.Label5;
		size = new System.Drawing.Size(177, 85);
		label6.Size = size;
		this.Label5.TabIndex = 15;
		this.Label5.Text = "Описание:\r\n{ } — начальное значение инкремента;\r\n$属性名称$ — значение свойства\r\n%属性名称% — выражение свойства\r\n<列标题> — значение из другого столбца\r\n";
		this.Label7.AutoSize = true;
		this.Label7.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label7 = this.Label7;
		location = new System.Drawing.Point(64, 80);
		label7.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label8 = this.Label7;
		size = new System.Drawing.Size(109, 17);
		label8.Size = size;
		this.Label7.TabIndex = 15;
		this.Label7.Text = "ID001-轴承座-001";
		this.Label8.AutoSize = true;
		System.Windows.Forms.Label label9 = this.Label8;
		location = new System.Drawing.Point(20, 80);
		label9.Location = location;
		this.Label8.Name = "Label8";
		System.Windows.Forms.Label label10 = this.Label8;
		size = new System.Drawing.Size(44, 17);
		label10.Size = size;
		this.Label8.TabIndex = 15;
		this.Label8.Text = "Результат:";
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(321, 128);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(88, 27);
		button2.Size = size;
		this.Button1.TabIndex = 33;
		this.Button1.Text = "Вставить ссылку....";
		this.Button1.UseVisualStyleBackColor = true;
		System.Windows.Forms.NumericUpDown numericUpDown = this.NumericUpDown1;
		location = new System.Drawing.Point(322, 88);
		numericUpDown.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown2 = this.NumericUpDown1;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		numericUpDown2.Margin = padding;
		System.Windows.Forms.NumericUpDown numericUpDown3 = this.NumericUpDown1;
		decimal maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		numericUpDown3.Maximum = maximum;
		maximum = (this.NumericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.NumericUpDown1.Name = "NumericUpDown1";
		System.Windows.Forms.NumericUpDown numericUpDown4 = this.NumericUpDown1;
		size = new System.Drawing.Size(65, 23);
		numericUpDown4.Size = size;
		this.NumericUpDown1.TabIndex = 30;
		maximum = (this.NumericUpDown1.Value = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.Label6.AutoSize = true;
		System.Windows.Forms.Label label11 = this.Label6;
		location = new System.Drawing.Point(320, 68);
		label11.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label12 = this.Label6;
		size = new System.Drawing.Size(44, 17);
		label12.Size = size;
		this.Label6.TabIndex = 28;
		this.Label6.Text = "Инкремент:";
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label13 = this.Label3;
		location = new System.Drawing.Point(8, 64);
		label13.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label14 = this.Label3;
		size = new System.Drawing.Size(68, 17);
		label14.Size = size;
		this.Label3.TabIndex = 29;
		this.Label3.Text = "Содержимое заполнения:";
		this.TabPage2.BackColor = System.Drawing.Color.White;
		this.TabPage2.Controls.Add(this.GroupBox3);
		this.TabPage2.Controls.Add(this.GroupBox2);
		this.TabPage2.Controls.Add(this.GroupBox5);
		System.Windows.Forms.TabPage tabPage4 = this.TabPage2;
		location = new System.Drawing.Point(4, 26);
		tabPage4.Location = location;
		this.TabPage2.Name = "TabPage2";
		System.Windows.Forms.TabPage tabPage5 = this.TabPage2;
		size = new System.Drawing.Size(425, 300);
		tabPage5.Size = size;
		this.TabPage2.TabIndex = 2;
		this.TabPage2.Text = "Заполнение по правилу";
		this.GroupBox3.Controls.Add(this.TextBox3);
		this.GroupBox3.Controls.Add(this.ComboBox2);
		this.GroupBox3.Controls.Add(this.Label9);
		this.GroupBox3.Controls.Add(this.Label2);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox3;
		location = new System.Drawing.Point(208, 192);
		groupBox5.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox3;
		size = new System.Drawing.Size(208, 144);
		groupBox6.Size = size;
		this.GroupBox3.TabIndex = 8;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Заполнять элементы, удовлетворяющие пользовательскому правилу";
		System.Windows.Forms.TextBox textBox7 = this.TextBox3;
		location = new System.Drawing.Point(8, 104);
		textBox7.Location = location;
		this.TextBox3.Name = "TextBox3";
		System.Windows.Forms.TextBox textBox8 = this.TextBox3;
		size = new System.Drawing.Size(192, 23);
		textBox8.Size = size;
		this.TextBox3.TabIndex = 50;
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox3 = this.ComboBox2;
		location = new System.Drawing.Point(8, 48);
		comboBox3.Location = location;
		this.ComboBox2.Name = "ComboBox2";
		System.Windows.Forms.ComboBox comboBox4 = this.ComboBox2;
		size = new System.Drawing.Size(152, 25);
		comboBox4.Size = size;
		this.ComboBox2.TabIndex = 48;
		this.Label9.AutoSize = true;
		this.Label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label15 = this.Label9;
		location = new System.Drawing.Point(8, 84);
		label15.Location = location;
		this.Label9.Name = "Label9";
		System.Windows.Forms.Label label16 = this.Label9;
		size = new System.Drawing.Size(68, 17);
		label16.Size = size;
		this.Label9.TabIndex = 49;
		this.Label9.Text = "Содержимое заполнения:";
		this.Label2.AutoSize = true;
		this.Label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label17 = this.Label2;
		location = new System.Drawing.Point(8, 28);
		label17.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label18 = this.Label2;
		size = new System.Drawing.Size(104, 17);
		label18.Size = size;
		this.Label2.TabIndex = 49;
		this.Label2.Text = "Выберите столбцы для заполнения:";
		this.GroupBox2.Controls.Add(this.RuleList);
		this.GroupBox2.Controls.Add(this.LinkLabel1);
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox2;
		location = new System.Drawing.Point(208, 6);
		groupBox7.Location = location;
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox2;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox8.Margin = padding;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox9 = this.GroupBox2;
		padding = new System.Windows.Forms.Padding(6, 4, 6, 3);
		groupBox9.Padding = padding;
		System.Windows.Forms.GroupBox groupBox10 = this.GroupBox2;
		size = new System.Drawing.Size(208, 178);
		groupBox10.Size = size;
		this.GroupBox2.TabIndex = 47;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Пользовательское правило";
		this.RuleList.CheckOnClick = true;
		this.RuleList.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.CheckedListBox ruleList = this.RuleList;
		location = new System.Drawing.Point(6, 20);
		ruleList.Location = location;
		System.Windows.Forms.CheckedListBox ruleList2 = this.RuleList;
		padding = new System.Windows.Forms.Padding(0);
		ruleList2.Margin = padding;
		this.RuleList.Name = "RuleList";
		this.RuleList.ScrollAlwaysVisible = true;
		System.Windows.Forms.CheckedListBox ruleList3 = this.RuleList;
		size = new System.Drawing.Size(196, 138);
		ruleList3.Size = size;
		this.RuleList.TabIndex = 17;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.LinkLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(6, 158);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(56, 17);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 44;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Создать правило";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.GroupBox5.Controls.Add(this.TableLayoutPanel1);
		this.GroupBox5.Controls.Add(this.fillsettinglist);
		System.Windows.Forms.GroupBox groupBox11 = this.GroupBox5;
		location = new System.Drawing.Point(4, 6);
		groupBox11.Location = location;
		this.GroupBox5.Name = "GroupBox5";
		System.Windows.Forms.GroupBox groupBox12 = this.GroupBox5;
		padding = new System.Windows.Forms.Padding(6);
		groupBox12.Padding = padding;
		System.Windows.Forms.GroupBox groupBox13 = this.GroupBox5;
		size = new System.Drawing.Size(188, 330);
		groupBox13.Size = size;
		this.GroupBox5.TabIndex = 46;
		this.GroupBox5.TabStop = false;
		this.GroupBox5.Text = "Схема заполнения";
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel1.Controls.Add(this.add, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.edit, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.del, 2, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel1;
		location = new System.Drawing.Point(3, 292);
		tableLayoutPanel3.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = this.TableLayoutPanel1;
		size = new System.Drawing.Size(178, 33);
		tableLayoutPanel4.Size = size;
		this.TableLayoutPanel1.TabIndex = 27;
		this.add.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button3 = this.add;
		location = new System.Drawing.Point(7, 3);
		button3.Location = location;
		this.add.Name = "add";
		System.Windows.Forms.Button button4 = this.add;
		size = new System.Drawing.Size(45, 27);
		button4.Size = size;
		this.add.TabIndex = 0;
		this.add.Text = "Добавить";
		this.add.UseVisualStyleBackColor = true;
		this.edit.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button5 = this.edit;
		location = new System.Drawing.Point(62, 3);
		button5.Location = location;
		this.edit.Name = "edit";
		System.Windows.Forms.Button button6 = this.edit;
		size = new System.Drawing.Size(53, 27);
		button6.Size = size;
		this.edit.TabIndex = 0;
		this.edit.Text = "Переименовать";
		this.edit.UseVisualStyleBackColor = true;
		this.del.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button7 = this.del;
		location = new System.Drawing.Point(125, 3);
		button7.Location = location;
		this.del.Name = "del";
		System.Windows.Forms.Button button8 = this.del;
		size = new System.Drawing.Size(45, 27);
		button8.Size = size;
		this.del.TabIndex = 0;
		this.del.Text = "Удалить";
		this.del.UseVisualStyleBackColor = true;
		this.fillsettinglist.Dock = System.Windows.Forms.DockStyle.Top;
		this.fillsettinglist.FormattingEnabled = true;
		this.fillsettinglist.ItemHeight = 17;
		System.Windows.Forms.ListBox listBox = this.fillsettinglist;
		location = new System.Drawing.Point(6, 22);
		listBox.Location = location;
		this.fillsettinglist.Name = "fillsettinglist";
		System.Windows.Forms.ListBox listBox2 = this.fillsettinglist;
		size = new System.Drawing.Size(176, 259);
		listBox2.Size = size;
		this.fillsettinglist.TabIndex = 45;
		this.TabPage3.BackColor = System.Drawing.Color.White;
		this.TabPage3.Controls.Add(this.GroupBox6);
		this.TabPage3.Controls.Add(this.GroupBox4);
		System.Windows.Forms.TabPage tabPage6 = this.TabPage3;
		location = new System.Drawing.Point(4, 26);
		tabPage6.Location = location;
		this.TabPage3.Name = "TabPage3";
		System.Windows.Forms.TabPage tabPage7 = this.TabPage3;
		padding = new System.Windows.Forms.Padding(8, 10, 8, 10);
		tabPage7.Padding = padding;
		System.Windows.Forms.TabPage tabPage8 = this.TabPage3;
		size = new System.Drawing.Size(425, 300);
		tabPage8.Size = size;
		this.TabPage3.TabIndex = 3;
		this.TabPage3.Text = "Заполнение поиском";
		this.GroupBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox6.Controls.Add(this.ComboBox4);
		this.GroupBox6.Controls.Add(this.Label10);
		this.GroupBox6.Controls.Add(this.ComboBox3);
		this.GroupBox6.Controls.Add(this.Label12);
		this.GroupBox6.Controls.Add(this.rcolnumer2);
		this.GroupBox6.Controls.Add(this.Label13);
		this.GroupBox6.Controls.Add(this.rcolnumer1);
		this.GroupBox6.Controls.Add(this.Label14);
		System.Windows.Forms.GroupBox groupBox14 = this.GroupBox6;
		location = new System.Drawing.Point(8, 120);
		groupBox14.Location = location;
		this.GroupBox6.Name = "GroupBox6";
		System.Windows.Forms.GroupBox groupBox15 = this.GroupBox6;
		padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
		groupBox15.Padding = padding;
		System.Windows.Forms.GroupBox groupBox16 = this.GroupBox6;
		size = new System.Drawing.Size(408, 112);
		groupBox16.Size = size;
		this.GroupBox6.TabIndex = 50;
		this.GroupBox6.TabStop = false;
		this.GroupBox6.Text = "Заполнение поиском";
		this.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox4.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox5 = this.ComboBox4;
		location = new System.Drawing.Point(192, 68);
		comboBox5.Location = location;
		this.ComboBox4.Name = "ComboBox4";
		System.Windows.Forms.ComboBox comboBox6 = this.ComboBox4;
		size = new System.Drawing.Size(200, 25);
		comboBox6.Size = size;
		this.ComboBox4.TabIndex = 49;
		this.Label10.AutoSize = true;
		System.Windows.Forms.Label label19 = this.Label10;
		location = new System.Drawing.Point(8, 32);
		label19.Location = location;
		this.Label10.Name = "Label10";
		System.Windows.Forms.Label label20 = this.Label10;
		size = new System.Drawing.Size(32, 17);
		label20.Size = size;
		this.Label10.TabIndex = 1;
		this.Label10.Text = "Из";
		this.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox3.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox7 = this.ComboBox3;
		location = new System.Drawing.Point(192, 28);
		comboBox7.Location = location;
		this.ComboBox3.Name = "ComboBox3";
		System.Windows.Forms.ComboBox comboBox8 = this.ComboBox3;
		size = new System.Drawing.Size(200, 25);
		comboBox8.Size = size;
		this.ComboBox3.TabIndex = 49;
		this.Label12.AutoSize = true;
		System.Windows.Forms.Label label21 = this.Label12;
		location = new System.Drawing.Point(130, 32);
		label21.Location = location;
		this.Label12.Name = "Label12";
		System.Windows.Forms.Label label22 = this.Label12;
		size = new System.Drawing.Size(44, 17);
		label22.Size = size;
		this.Label12.TabIndex = 1;
		this.Label12.Text = "-го столбца искать";
		System.Windows.Forms.NumericUpDown numericUpDown5 = this.rcolnumer2;
		location = new System.Drawing.Point(48, 69);
		numericUpDown5.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown6 = this.rcolnumer2;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		numericUpDown6.Margin = padding;
		maximum = (this.rcolnumer2.Maximum = new decimal(new int[4] { 65536, 0, 0, 0 }));
		maximum = (this.rcolnumer2.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.rcolnumer2.Name = "rcolnumer2";
		System.Windows.Forms.NumericUpDown numericUpDown7 = this.rcolnumer2;
		size = new System.Drawing.Size(65, 23);
		numericUpDown7.Size = size;
		this.rcolnumer2.TabIndex = 45;
		maximum = (this.rcolnumer2.Value = new decimal(new int[4] { 2, 0, 0, 0 }));
		this.Label13.AutoSize = true;
		System.Windows.Forms.Label label23 = this.Label13;
		location = new System.Drawing.Point(8, 72);
		label23.Location = location;
		this.Label13.Name = "Label13";
		System.Windows.Forms.Label label24 = this.Label13;
		size = new System.Drawing.Size(32, 17);
		label24.Size = size;
		this.Label13.TabIndex = 1;
		this.Label13.Text = "-й столбец";
		System.Windows.Forms.NumericUpDown numericUpDown8 = this.rcolnumer1;
		location = new System.Drawing.Point(48, 29);
		numericUpDown8.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown9 = this.rcolnumer1;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		numericUpDown9.Margin = padding;
		maximum = (this.rcolnumer1.Maximum = new decimal(new int[4] { 65536, 0, 0, 0 }));
		maximum = (this.rcolnumer1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.rcolnumer1.Name = "rcolnumer1";
		System.Windows.Forms.NumericUpDown numericUpDown10 = this.rcolnumer1;
		size = new System.Drawing.Size(65, 23);
		numericUpDown10.Size = size;
		this.rcolnumer1.TabIndex = 45;
		maximum = (this.rcolnumer1.Value = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.Label14.AutoSize = true;
		System.Windows.Forms.Label label25 = this.Label14;
		location = new System.Drawing.Point(118, 72);
		label25.Location = location;
		this.Label14.Name = "Label14";
		System.Windows.Forms.Label label26 = this.Label14;
		size = new System.Drawing.Size(68, 17);
		label26.Size = size;
		this.Label14.TabIndex = 1;
		this.Label14.Text = "записать данные в";
		this.GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox4.Controls.Add(this.datacount);
		this.GroupBox4.Controls.Add(this.Label15);
		this.GroupBox4.Controls.Add(this.Button2);
		this.GroupBox4.Controls.Add(this.Button3);
		this.GroupBox4.Controls.Add(this.srownumer);
		this.GroupBox4.Controls.Add(this.Label11);
		this.GroupBox4.Controls.Add(this.datasource);
		System.Windows.Forms.GroupBox groupBox17 = this.GroupBox4;
		location = new System.Drawing.Point(8, 10);
		groupBox17.Location = location;
		System.Windows.Forms.GroupBox groupBox18 = this.GroupBox4;
		padding = new System.Windows.Forms.Padding(9);
		groupBox18.Margin = padding;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox19 = this.GroupBox4;
		size = new System.Drawing.Size(408, 102);
		groupBox19.Size = size;
		this.GroupBox4.TabIndex = 46;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Источник данных";
		this.datacount.AutoSize = true;
		this.datacount.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label27 = this.datacount;
		location = new System.Drawing.Point(320, 67);
		label27.Location = location;
		this.datacount.Name = "datacount";
		System.Windows.Forms.Label label28 = this.datacount;
		size = new System.Drawing.Size(15, 17);
		label28.Size = size;
		this.datacount.TabIndex = 47;
		this.datacount.Text = "0";
		this.Label15.AutoSize = true;
		System.Windows.Forms.Label label29 = this.Label15;
		location = new System.Drawing.Point(240, 67);
		label29.Location = location;
		this.Label15.Name = "Label15";
		System.Windows.Forms.Label label30 = this.Label15;
		size = new System.Drawing.Size(80, 17);
		label30.Size = size;
		this.Label15.TabIndex = 47;
		this.Label15.Text = "Объём кэшируемых данных:";
		this.Button2.AutoSize = true;
		System.Windows.Forms.Button button9 = this.Button2;
		location = new System.Drawing.Point(160, 62);
		button9.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button10 = this.Button2;
		size = new System.Drawing.Size(66, 27);
		button10.Size = size;
		this.Button2.TabIndex = 46;
		this.Button2.Text = "Обновить данные";
		this.Button2.UseVisualStyleBackColor = true;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button3.AutoSize = true;
		this.Button3.ContextMenuStrip = this.openmenu;
		System.Windows.Forms.Button button11 = this.Button3;
		location = new System.Drawing.Point(367, 24);
		button11.Location = location;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button12 = this.Button3;
		size = new System.Drawing.Size(33, 27);
		button12.Size = size;
		this.Button3.TabIndex = 44;
		this.Button3.Text = "...";
		this.Button3.UseVisualStyleBackColor = true;
		this.openmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.open_browse, this.open_excel, this.open_folder });
		this.openmenu.Name = "Savemenu";
		this.openmenu.ShowImageMargin = false;
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.openmenu;
		size = new System.Drawing.Size(165, 70);
		contextMenuStrip.Size = size;
		this.open_browse.Name = "open_browse";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.open_browse;
		size = new System.Drawing.Size(164, 22);
		toolStripMenuItem.Size = size;
		this.open_browse.Text = "Обзор источника данных Excel";
		this.open_excel.Name = "open_excel";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.open_excel;
		size = new System.Drawing.Size(164, 22);
		toolStripMenuItem2.Size = size;
		this.open_excel.Text = "Открыть текущий источник данных Excel";
		this.open_folder.Name = "open_folder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.open_folder;
		size = new System.Drawing.Size(164, 22);
		toolStripMenuItem3.Size = size;
		this.open_folder.Text = "Открыть текущую папку";
		System.Windows.Forms.NumericUpDown numericUpDown11 = this.srownumer;
		location = new System.Drawing.Point(64, 64);
		numericUpDown11.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown12 = this.srownumer;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		numericUpDown12.Margin = padding;
		maximum = (this.srownumer.Maximum = new decimal(new int[4] { 65536, 0, 0, 0 }));
		maximum = (this.srownumer.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.srownumer.Name = "srownumer";
		System.Windows.Forms.NumericUpDown numericUpDown13 = this.srownumer;
		size = new System.Drawing.Size(65, 23);
		numericUpDown13.Size = size;
		this.srownumer.TabIndex = 45;
		maximum = (this.srownumer.Value = new decimal(new int[4] { 2, 0, 0, 0 }));
		this.Label11.AutoSize = true;
		System.Windows.Forms.Label label31 = this.Label11;
		location = new System.Drawing.Point(8, 67);
		label31.Location = location;
		this.Label11.Name = "Label11";
		System.Windows.Forms.Label label32 = this.Label11;
		size = new System.Drawing.Size(56, 17);
		label32.Size = size;
		this.Label11.TabIndex = 1;
		this.Label11.Text = "Начальная строка:";
		System.Windows.Forms.TextBox textBox9 = this.datasource;
		location = new System.Drawing.Point(12, 26);
		textBox9.Location = location;
		this.datasource.Name = "datasource";
		System.Windows.Forms.TextBox textBox10 = this.datasource;
		size = new System.Drawing.Size(350, 23);
		textBox10.Size = size;
		this.datasource.TabIndex = 0;
		this.TabPage4.BackColor = System.Drawing.Color.White;
		this.TabPage4.Controls.Add(this.DGV1);
		this.TabPage4.Controls.Add(this.Panel1);
		this.TabPage4.Controls.Add(this.ToolStrip1);
		System.Windows.Forms.TabPage tabPage9 = this.TabPage4;
		location = new System.Drawing.Point(4, 26);
		tabPage9.Location = location;
		this.TabPage4.Name = "TabPage4";
		System.Windows.Forms.TabPage tabPage10 = this.TabPage4;
		size = new System.Drawing.Size(425, 300);
		tabPage10.Size = size;
		this.TabPage4.TabIndex = 4;
		this.TabPage4.Text = "Связанное заполнение";
		this.DGV1.AllowUserToResizeColumns = false;
		this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
		this.DGV1.BackgroundColor = System.Drawing.Color.White;
		this.DGV1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DGV1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.DataGridView dGV = this.DGV1;
		location = new System.Drawing.Point(0, 31);
		dGV.Location = location;
		System.Windows.Forms.DataGridView dGV2 = this.DGV1;
		padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		dGV2.Margin = padding;
		this.DGV1.Name = "DGV1";
		this.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		System.Windows.Forms.DataGridView dGV3 = this.DGV1;
		size = new System.Drawing.Size(425, 241);
		dGV3.Size = size;
		this.DGV1.TabIndex = 2;
		this.Panel1.Controls.Add(this.Label16);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(0, 272);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		padding = new System.Windows.Forms.Padding(6);
		panel2.Padding = padding;
		System.Windows.Forms.Panel panel3 = this.Panel1;
		size = new System.Drawing.Size(425, 28);
		panel3.Size = size;
		this.Panel1.TabIndex = 4;
		this.Label16.AutoSize = true;
		this.Label16.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label16.ForeColor = System.Drawing.Color.Green;
		System.Windows.Forms.Label label33 = this.Label16;
		location = new System.Drawing.Point(6, 6);
		label33.Location = location;
		this.Label16.Name = "Label16";
		System.Windows.Forms.Label label34 = this.Label16;
		size = new System.Drawing.Size(290, 17);
		label34.Size = size;
		this.Label16.TabIndex = 4;
		this.Label16.Text = "Двойной щелчок по строке — записать в главное окно; нажмите Del для удаления выбранной строки.";
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.name_list, this.addcolumn, this.delcolumn, this.adddata });
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
		toolStrip2.Padding = padding;
		System.Windows.Forms.ToolStrip toolStrip3 = this.ToolStrip1;
		size = new System.Drawing.Size(425, 31);
		toolStrip3.Size = size;
		this.ToolStrip1.TabIndex = 3;
		this.ToolStrip1.Text = "ToolStrip1";
		this.name_list.FlatStyle = System.Windows.Forms.FlatStyle.System;
		System.Windows.Forms.ToolStripComboBox toolStripComboBox = this.name_list;
		padding = new System.Windows.Forms.Padding(1, 0, 3, 0);
		toolStripComboBox.Margin = padding;
		this.name_list.Name = "name_list";
		System.Windows.Forms.ToolStripComboBox toolStripComboBox2 = this.name_list;
		size = new System.Drawing.Size(200, 25);
		toolStripComboBox2.Size = size;
		this.addcolumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.addcolumn.Image = (System.Drawing.Image)resources.GetObject("addcolumn.Image");
		this.addcolumn.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton = this.addcolumn;
		padding = new System.Windows.Forms.Padding(3, 1, 3, 2);
		toolStripButton.Margin = padding;
		this.addcolumn.Name = "addcolumn";
		System.Windows.Forms.ToolStripButton toolStripButton2 = this.addcolumn;
		size = new System.Drawing.Size(48, 22);
		toolStripButton2.Size = size;
		this.addcolumn.Text = "Добавить столбец";
		this.delcolumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.delcolumn.Image = (System.Drawing.Image)resources.GetObject("delcolumn.Image");
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton = this.delcolumn;
		padding = new System.Windows.Forms.Padding(3, 1, 3, 2);
		toolStripDropDownButton.Margin = padding;
		this.delcolumn.Name = "delcolumn";
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2 = this.delcolumn;
		size = new System.Drawing.Size(57, 22);
		toolStripDropDownButton2.Size = size;
		this.delcolumn.Text = "Удалить столбец";
		this.adddata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.adddata.Image = (System.Drawing.Image)resources.GetObject("adddata.Image");
		this.adddata.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton3 = this.adddata;
		padding = new System.Windows.Forms.Padding(3, 1, 0, 2);
		toolStripButton3.Margin = padding;
		this.adddata.Name = "adddata";
		System.Windows.Forms.ToolStripButton toolStripButton4 = this.adddata;
		size = new System.Drawing.Size(84, 22);
		toolStripButton4.Size = size;
		this.adddata.Text = "Импорт из главного окна";
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(433, 368);
		this.ClientSize = size;
		this.Controls.Add(this.TableLayoutPanel2);
		this.Controls.Add(this.TabControl1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmFilling";
		this.ShowIcon = false;
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Столбец заполнения";
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).EndInit();
		this.TabPage2.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.GroupBox5.ResumeLayout(false);
		this.GroupBox5.PerformLayout();
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		this.GroupBox6.ResumeLayout(false);
		this.GroupBox6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.rcolnumer2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.rcolnumer1).EndInit();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.openmenu.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.srownumer).EndInit();
		this.TabPage4.ResumeLayout(false);
		this.TabPage4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmFilling()
	{
		base.Activated += FrmFilling_Activated;
		base.FormClosed += FrmFilling_FormClosed;
		base.KeyPress += FrmFilling_KeyPress;
		base.Load += FrmFilling_Load;
		base.MouseEnter += FrmFilling_MouseEnter;
		base.ResizeEnd += FrmFilling_Resize;
		__ENCAddToList(this);
		ColList = new List<int>();
		CellArr = new List<DataGridViewCell>();
		CellValArr = new List<string>();
		CellColorArr = new List<Color>();
		RowArr = new List<DataGridViewRow>();
		Ismodifylist = new List<bool>();
		vallist = new List<string>();
		menu1 = new ContextMenuStrip();
		ColList2 = new List<int>();
		ColList3 = new List<int>();
		ColList4 = new List<int>();
		dpixRatio = 1.0;
		hb = new Hashtable();
		dt = new DataTable();
		changeing = false;
		mLinearColor1 = Color.FromArgb(240, 240, 240);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			TextBox1.Height = (int)Math.Round(66.0 * dpixRatio);
			fillsettinglist.Height = (int)Math.Round(270.0 * dpixRatio);
			ToolStrip1.Height = (int)Math.Round((double)ToolStrip1.Height * dpixRatio);
			name_list.Width = (int)Math.Round((double)name_list.Width * dpixRatio);
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		if (TabControl1.SelectedIndex == 0)
		{
			fill1();
		}
		else if (TabControl1.SelectedIndex == 1)
		{
			fill2();
		}
		else if (TabControl1.SelectedIndex == 2)
		{
			fill3();
		}
	}

	public void fill1()
	{
		checked
		{
			try
			{
				string text = TextBox1.Text;
				int num = code.downlist.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					text = text.Replace(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("[", NewLateBinding.LateIndexGet(code.downlist, new object[1] { num2 }, null)), "]")), code.GetdownlistValue(Conversions.ToString(NewLateBinding.LateIndexGet(code.downlist, new object[1] { num2 }, null))));
					num2++;
				}
				int num5 = 0;
				int num6 = 0;
				int columnIndex = ColList[ComboBox1.SelectedIndex];
				RowArr.Clear();
				Ismodifylist.Clear();
				int num7 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num8 = 0;
				while (true)
				{
					int num9 = num8;
					int num4 = num7;
					if (num9 > num4)
					{
						break;
					}
					if (MyProject.Forms.Frmmain.DGV1.Rows[num8].Visible)
					{
						RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num8]);
						Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num8].Tag));
						string text2 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[columnIndex, num8].Value);
						string text3 = text;
						if (Operators.CompareString(text3, "", TextCompare: false) != 0)
						{
							int num10 = MyProject.Forms.Frmmain.DGV1.Columns.Count - 1;
							int num11 = 0;
							while (true)
							{
								int num12 = num11;
								num4 = num10;
								if (num12 > num4)
								{
									break;
								}
								if (MyProject.Forms.Frmmain.DGV1.Columns[num11].Name.Contains("PropVal_"))
								{
									string find = "%" + MyProject.Forms.Frmmain.DGV1.Columns[num11].HeaderText + "%";
									text3 = Strings.Replace(text3, find, Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num11, num8].Value));
								}
								else if (MyProject.Forms.Frmmain.DGV1.Columns[num11].Name.Contains("PropResolvedVal_"))
								{
									string find2 = "$" + MyProject.Forms.Frmmain.DGV1.Columns[num11].HeaderText + "$";
									text3 = Strings.Replace(text3, find2, Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num11, num8].Value));
								}
								else
								{
									_Closure_0024__77 closure_0024__ = new _Closure_0024__77();
									closure_0024__._0024VB_0024Local_findstr3 = "<" + MyProject.Forms.Frmmain.DGV1.Columns[num11].HeaderText + ">";
									if (vallist.Exists(closure_0024__._Lambda_0024__134))
									{
										text3 = Strings.Replace(text3, closure_0024__._0024VB_0024Local_findstr3, Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num11, num8].Value));
									}
								}
								num11++;
							}
							string text4 = code.MidStrEx(text3, "{", "}");
							if (Versioned.IsNumeric(text4))
							{
								text3 = Strings.Replace(text3, "{" + text4 + "}", (Conversions.ToDouble(text4) + (double)num5).ToString().PadLeft(text4.Length, '0'));
							}
						}
						if (!text2.Equals(text3, StringComparison.OrdinalIgnoreCase))
						{
							if (num6 == 0)
							{
								CellArr.Clear();
								CellValArr.Clear();
								CellColorArr.Clear();
							}
							num6++;
							CellArr.Add(MyProject.Forms.Frmmain.DGV1[columnIndex, num8]);
							CellValArr.Add(text2);
							CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[columnIndex, num8].Style.ForeColor);
							MyProject.Forms.Frmmain.DGV1[columnIndex, num8].Value = text3;
						}
						num5 = Convert.ToInt32(decimal.Add(new decimal(num5), NumericUpDown1.Value));
					}
					num8++;
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

	public void fill2()
	{
		RowArr.Clear();
		Ismodifylist.Clear();
		int num = 0;
		checked
		{
			int num2 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (MyProject.Forms.Frmmain.DGV1.Rows[num3].Visible)
				{
					RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num3]);
					Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num3].Tag));
					int num6 = CConfigMng.Config.fillsettings.Count - 1;
					int num7 = 0;
					while (true)
					{
						int num8 = num7;
						num5 = num6;
						if (num8 > num5)
						{
							break;
						}
						fillsetting fillsetting2 = CConfigMng.Config.fillsettings[num7];
						CustomFilter customFilter = new CustomFilter(fillsetting2.RulesList);
						if (((customFilter.FilterByRule(num3) && fillsetting2.colindex >= 0 && fillsetting2.colindex <= MyProject.Forms.Frmmain.DGV1.ColumnCount - 1) ? true : false) && ((!MyProject.Forms.Frmmain.DGV1[fillsetting2.colindex, num3].ReadOnly && fillsetting2.colindex != MyProject.Forms.Frmmain.Col_FileName.Index) ? true : false))
						{
							string text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[fillsetting2.colindex, num3].Value);
							string text2 = fillsetting2.fillcontent;
							int num9 = code.downlist.Length - 1;
							int num10 = 0;
							while (true)
							{
								int num11 = num10;
								num5 = num9;
								if (num11 > num5)
								{
									break;
								}
								text2 = text2.Replace(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("[", NewLateBinding.LateIndexGet(code.downlist, new object[1] { num10 }, null)), "]")), code.GetdownlistValue(Conversions.ToString(NewLateBinding.LateIndexGet(code.downlist, new object[1] { num10 }, null))));
								num10++;
							}
							if (Operators.CompareString(text2, "", TextCompare: false) != 0)
							{
								int num12 = MyProject.Forms.Frmmain.DGV1.Columns.Count - 1;
								int num13 = 0;
								while (true)
								{
									int num14 = num13;
									num5 = num12;
									if (num14 > num5)
									{
										break;
									}
									if (MyProject.Forms.Frmmain.DGV1.Columns[num13].Name.Contains("PropVal_"))
									{
										string find = "%" + MyProject.Forms.Frmmain.DGV1.Columns[num13].HeaderText + "%";
										text2 = Strings.Replace(text2, find, Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num13, num3].Value));
									}
									else if (MyProject.Forms.Frmmain.DGV1.Columns[num13].Name.Contains("PropResolvedVal_"))
									{
										string find2 = "$" + MyProject.Forms.Frmmain.DGV1.Columns[num13].HeaderText + "$";
										text2 = Strings.Replace(text2, find2, Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num13, num3].Value));
									}
									else
									{
										_Closure_0024__78 closure_0024__ = new _Closure_0024__78();
										closure_0024__._0024VB_0024Local_findstr3 = "<" + MyProject.Forms.Frmmain.DGV1.Columns[num13].HeaderText + ">";
										if (vallist.Exists(closure_0024__._Lambda_0024__135))
										{
											text2 = Strings.Replace(text2, closure_0024__._0024VB_0024Local_findstr3, Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num13, num3].Value));
										}
									}
									num13++;
								}
							}
							if (!text.Equals(text2, StringComparison.OrdinalIgnoreCase))
							{
								if (num == 0)
								{
									CellArr.Clear();
									CellValArr.Clear();
									CellColorArr.Clear();
								}
								num++;
								CellArr.Add(MyProject.Forms.Frmmain.DGV1[fillsetting2.colindex, num3]);
								CellValArr.Add(text);
								CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[fillsetting2.colindex, num3].Style.ForeColor);
								MyProject.Forms.Frmmain.DGV1[fillsetting2.colindex, num3].Value = text2;
							}
						}
						num7++;
					}
				}
				num3++;
			}
		}
	}

	private void FrmFilling_Activated(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				ComboBox1.Items.Clear();
				ColList.Clear();
				int num = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (MyProject.Forms.Frmmain.DGV1.Columns[num2].Visible)
					{
						string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
						if (!MyProject.Forms.Frmmain.DGV1.Columns[num2].ReadOnly & (num2 != MyProject.Forms.Frmmain.Col_FileName.Index))
						{
							ComboBox1.Items.Add(headerText);
							ColList.Add(num2);
						}
					}
					num2++;
				}
				string headerText2 = MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.DGV1.CurrentCell.ColumnIndex].HeaderText;
				ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(headerText2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			RuleList.Items.Clear();
			int num5 = CConfigMng.Config.FilterRulesList.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				string name = CConfigMng.Config.FilterRulesList[num6].name;
				if (!RuleList.Items.Contains(name))
				{
					RuleList.Items.Add(name, isChecked: false);
				}
				num6++;
			}
			fillsettinglist_SelectedIndexChanged(null, null);
		}
	}

	private void Undo_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = CellArr.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				CellArr[num2].Value = CellValArr[num2];
				CellArr[num2].Style.ForeColor = CellColorArr[num2];
				num2++;
			}
			int num5 = RowArr.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 <= num4)
				{
					RowArr[num6].Tag = Ismodifylist[num6].ToString();
					num6++;
					continue;
				}
				break;
			}
		}
	}

	private void FrmFilling_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			CConfigMng.Config.relatedfilldata = code.SerializeObject(dt);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		Savecfg();
	}

	private void FrmFilling_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void FrmFilling_Load(object sender, EventArgs e)
	{
		menu1 = createmenu();
		ComboBox2.Items.Clear();
		ColList2.Clear();
		checked
		{
			int num = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
				if ((!MyProject.Forms.Frmmain.DGV1.Columns[num2].ReadOnly && num2 != MyProject.Forms.Frmmain.Col_FileName.Index) ? true : false)
				{
					ComboBox2.Items.Add(headerText);
					ColList2.Add(num2);
				}
				num2++;
			}
			List<string> list = new List<string>();
			fillsettinglist.Items.Clear();
			int num5 = CConfigMng.Config.fillsettings.Count - 1;
			int num6 = 0;
			_Closure_0024__79 closure_0024__ = default(_Closure_0024__79);
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__79(closure_0024__);
				closure_0024__._0024VB_0024Local_name = CConfigMng.Config.fillsettings[num6].name;
				if (!list.Exists(closure_0024__._Lambda_0024__136))
				{
					list.Add(closure_0024__._0024VB_0024Local_name);
					fillsettinglist.Items.Add(closure_0024__._0024VB_0024Local_name);
				}
				num6++;
			}
			TabControl tabControl = TabControl1;
			Size itemSize = new Size((int)Math.Round(72.0 * dpixRatio), (int)Math.Round(22.0 * dpixRatio));
			tabControl.ItemSize = itemSize;
			srownumer_ValueChanged(null, null);
			ComboBox3.Items.Clear();
			ComboBox4.Items.Clear();
			int num8 = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
			int num9 = 0;
			while (true)
			{
				int num10 = num9;
				int num4 = num8;
				if (num10 > num4)
				{
					break;
				}
				string text = MyProject.Forms.Frmmain.DGV1.Columns[num9].HeaderText;
				string name = MyProject.Forms.Frmmain.DGV1.Columns[num9].Name;
				if ((!MyProject.Forms.Frmmain.DGV1.Columns[num9].ReadOnly && num9 != MyProject.Forms.Frmmain.Col_FileName.Index) ? true : false)
				{
					ComboBox4.Items.Add(text);
					ColList4.Add(num9);
				}
				if (name.Contains("PropVal_"))
				{
					text += " (выражение)";
				}
				else if (name.Contains("PropResolvedVal_"))
				{
					text += " (属性值)";
				}
				if ((Operators.CompareString(text, "", TextCompare: false) != 0 && Operators.CompareString(name, MyProject.Forms.Frmmain.Col_Preview.Name, TextCompare: false) != 0) ? true : false)
				{
					ComboBox3.Items.Add(text);
					ColList3.Add(num9);
				}
				num9++;
			}
			try
			{
				Loadcfg();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			try
			{
				MyProject.Forms.Frmmain.DoubleBuffer(DGV1);
				dt = (DataTable)code.DeserializeObject(CConfigMng.Config.relatedfilldata);
				DGV1.DataSource = dt;
				DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				DGV1.AutoResizeColumns();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void FrmFilling_MouseEnter(object sender, EventArgs e)
	{
		Focus();
	}

	private void FrmFilling_Resize(object sender, EventArgs e)
	{
		if (TabControl1.SelectedIndex == 3)
		{
			formwidth = (double)Width / dpixRatio;
			formheight = (double)Height / dpixRatio;
		}
	}

	private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
	{
		Font font;
		Brush brush;
		Brush brush2;
		if (e.Index == TabControl1.SelectedIndex)
		{
			font = new Font(e.Font, FontStyle.Bold);
			brush = new SolidBrush(Color.Black);
			brush2 = new SolidBrush(Color.White);
		}
		else
		{
			font = e.Font;
			brush = new SolidBrush(Control.DefaultBackColor);
			brush2 = new SolidBrush(Color.Black);
		}
		string s = TabControl1.TabPages[e.Index].Text;
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		Rectangle tabRect = TabControl1.GetTabRect(e.Index);
		e.Graphics.FillRectangle(brush, tabRect);
		e.Graphics.DrawString(s, font, brush2, tabRect, stringFormat);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		menu1 = createmenu();
		menu1.Show(Button1, Button1.Width, 0);
	}

	public ContextMenuStrip createmenu()
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		contextMenuStrip.ShowImageMargin = false;
		contextMenuStrip.Items.Clear();
		vallist.Clear();
		contextMenuStrip.AutoSize = true;
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("表格列");
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("SW属性");
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("自定义属性");
		checked
		{
			try
			{
				if (MyProject.Forms.Frmmain.DGV1.ColumnCount > 0)
				{
					int num = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							if ((num2 != MyProject.Forms.Frmmain.Col_Preview.Index && num2 != MyProject.Forms.Frmmain.Col_Checkbox.Index && num2 != MyProject.Forms.Frmmain.Col_Extname.Index && num2 != MyProject.Forms.Frmmain.Col_Drw.Index && num2 != MyProject.Forms.Frmmain.Col_CreationTime.Index && num2 != MyProject.Forms.Frmmain.Col_SaveTime.Index && num2 != MyProject.Forms.Frmmain.Col_Path.Index && num2 != MyProject.Forms.Frmmain.Col_NewFolder.Index) || 1 == 0)
							{
								string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
								headerText = (MyProject.Forms.Frmmain.DGV1.Columns[num2].Name.Contains("PropVal_") ? (headerText + " (属性表达式)") : ((!MyProject.Forms.Frmmain.DGV1.Columns[num2].Name.Contains("PropResolvedVal_")) ? ("<" + headerText + ">") : (headerText + " (属性值)")));
								toolStripMenuItem.DropDownItems.Add(headerText);
								vallist.Add(headerText);
							}
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
			try
			{
				int num5 = code.downlist.Length - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 <= num4)
					{
						NewLateBinding.LateCall(toolStripMenuItem2.DropDownItems, null, "Add", new object[1] { Operators.ConcatenateObject(Operators.ConcatenateObject("[", NewLateBinding.LateIndexGet(code.downlist, new object[1] { num6 }, null)), "]") }, null, null, null, IgnoreReturn: true);
						num6++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			try
			{
				int index = ColList[ComboBox1.SelectedIndex];
				if (CConfigMng.Config.Dropdownlist.Count > 0)
				{
					int num8 = CConfigMng.Config.Dropdownlist.Count - 1;
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						int num4 = num8;
						if (num10 > num4)
						{
							break;
						}
						string[] array = Strings.Split(CConfigMng.Config.Dropdownlist[num9], "\n");
						if (array.Length > 1 && ((Operators.CompareString(array[0], MyProject.Forms.Frmmain.DGV1.Columns[index].HeaderText, TextCompare: false) == 0 && Operators.CompareString(array[1], "", TextCompare: false) != 0) ? true : false))
						{
							int num11 = array.Length - 1;
							int num12 = 1;
							while (true)
							{
								int num13 = num12;
								num4 = num11;
								if (num13 <= num4)
								{
									toolStripMenuItem3.DropDownItems.Add(array[num12]);
									num12++;
									continue;
								}
								break;
							}
							break;
						}
						num9++;
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ProjectData.ClearProjectError();
			}
			int num14 = toolStripMenuItem.DropDownItems.Count - 1;
			int num15 = 0;
			while (true)
			{
				int num16 = num15;
				int num4 = num14;
				if (num16 > num4)
				{
					break;
				}
				toolStripMenuItem.DropDownItems[num15].Click += menuItems_click;
				num15++;
			}
			int num17 = toolStripMenuItem2.DropDownItems.Count - 1;
			int num18 = 0;
			while (true)
			{
				int num19 = num18;
				int num4 = num17;
				if (num19 > num4)
				{
					break;
				}
				toolStripMenuItem2.DropDownItems[num18].Click += menuItems_click;
				num18++;
			}
			int num20 = toolStripMenuItem3.DropDownItems.Count - 1;
			int num21 = 0;
			while (true)
			{
				int num22 = num21;
				int num4 = num20;
				if (num22 > num4)
				{
					break;
				}
				toolStripMenuItem3.DropDownItems[num21].Click += menuItems_click;
				num21++;
			}
			if (toolStripMenuItem.DropDownItems.Count > 0)
			{
				contextMenuStrip.Items.Add(toolStripMenuItem);
			}
			if (toolStripMenuItem2.DropDownItems.Count > 0)
			{
				contextMenuStrip.Items.Add(toolStripMenuItem2);
			}
			if (toolStripMenuItem3.DropDownItems.Count > 0)
			{
				contextMenuStrip.Items.Add(toolStripMenuItem3);
			}
			return contextMenuStrip;
		}
	}

	private void menuItems_click(object sender, EventArgs e)
	{
		try
		{
			string text = TextBox1.Text;
			string text2 = ((ToolStripMenuItem)sender).Text;
			if (text2.EndsWith(" (属性表达式)"))
			{
				text2 = text2.Substring(0, text2.LastIndexOf(" (属性表达式)"));
				text2 = "%" + text2 + "%";
			}
			else if (text2.EndsWith(" (属性值)"))
			{
				text2 = text2.Substring(0, text2.LastIndexOf(" (属性值)"));
				text2 = "$" + text2 + "$";
			}
			TextBox1.Focus();
			int selectionStart = TextBox1.SelectionStart;
			if (TextBox1.SelectionLength > 0)
			{
				text = Strings.Replace(text, TextBox1.SelectedText, text2);
			}
			else
			{
				text = text.Insert(selectionStart, text2);
				TextBox1.Text = text;
			}
			TextBox1.SelectionStart = checked(selectionStart + text2.Length);
			TextBox1.SelectionLength = 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public fillsetting createfillsetting(string str)
	{
		fillsetting fillsetting2 = new fillsetting();
		fillsetting2.name = str;
		if (ComboBox2.SelectedIndex >= 0)
		{
			fillsetting2.colindex = ColList2[ComboBox2.SelectedIndex];
		}
		else
		{
			fillsetting2.colindex = -1;
		}
		fillsetting2.fillcontent = TextBox3.Text;
		checked
		{
			int num = RuleList.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				try
				{
					if (RuleList.GetItemChecked(num2))
					{
						fillsetting2.RulesList.Add(RuleList.Items[num2].ToString());
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				num2++;
			}
			return fillsetting2;
		}
	}

	private void add_Click(object sender, EventArgs e)
	{
		_Closure_0024__80 closure_0024__ = new _Closure_0024__80();
		closure_0024__._0024VB_0024Local_str = Interaction.InputBox("输入方案名称");
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		int num = CConfigMng.Config.fillsettings.FindIndex(closure_0024__._Lambda_0024__137);
		if (num >= 0)
		{
			MessageBox.Show(this, "Имя «" + closure_0024__._0024VB_0024Local_str + "» уже существует, выберите другое имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		fillsettinglist.Items.Add(closure_0024__._0024VB_0024Local_str);
		CConfigMng.Config.fillsettings.Add(createfillsetting(closure_0024__._0024VB_0024Local_str));
		CConfigMng.SaveConfig();
		try
		{
			fillsettinglist.ClearSelected();
			fillsettinglist.SetSelected(checked(fillsettinglist.Items.Count - 1), value: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void edit_Click(object sender, EventArgs e)
	{
		_Closure_0024__81 closure_0024__ = new _Closure_0024__81();
		if (fillsettinglist.SelectedItems.Count < 1)
		{
			return;
		}
		if (fillsettinglist.SelectedItems.Count > 1)
		{
			MessageBox.Show(this, "Можно выбрать только один элемент", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		closure_0024__._0024VB_0024Local_RuleName = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(fillsettinglist.SelectedItem)))
		{
			closure_0024__._0024VB_0024Local_RuleName = fillsettinglist.SelectedItem.ToString();
		}
		int num = CConfigMng.Config.fillsettings.FindIndex(closure_0024__._Lambda_0024__138);
		if (num < 0)
		{
			return;
		}
		closure_0024__._0024VB_0024Local_str = Interaction.InputBox("输入规则名称", "", closure_0024__._0024VB_0024Local_RuleName);
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) != 0 && Operators.CompareString(closure_0024__._0024VB_0024Local_str, closure_0024__._0024VB_0024Local_RuleName, TextCompare: false) != 0 && 0 == 0)
		{
			int num2 = CConfigMng.Config.fillsettings.FindIndex(closure_0024__._Lambda_0024__139);
			if (num2 < 0)
			{
				fillsetting fillsetting2 = CConfigMng.Config.fillsettings[num];
				fillsetting2.name = closure_0024__._0024VB_0024Local_str;
				CConfigMng.Config.fillsettings[num] = fillsetting2;
				fillsettinglist.Items[fillsettinglist.SelectedIndex] = closure_0024__._0024VB_0024Local_str;
			}
			else
			{
				MessageBox.Show(this, "Имя «" + closure_0024__._0024VB_0024Local_str + "» уже существует, выберите другое имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private void del_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = fillsettinglist.SelectedItems.Count - 1;
			_Closure_0024__82 closure_0024__ = default(_Closure_0024__82);
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 >= num3)
				{
					closure_0024__ = new _Closure_0024__82(closure_0024__);
					closure_0024__._0024VB_0024Local_RuleName = Conversions.ToString(fillsettinglist.SelectedItems[num]);
					int num4 = CConfigMng.Config.fillsettings.FindIndex(closure_0024__._Lambda_0024__140);
					if (num4 >= 0)
					{
						CConfigMng.Config.fillsettings.RemoveAt(num4);
						fillsettinglist.Items.Remove(closure_0024__._0024VB_0024Local_RuleName);
					}
					num += -1;
					continue;
				}
				break;
			}
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		if (!MyProject.Forms.FrmFilterrules.Visible)
		{
			MyProject.Forms.FrmFilterrules.Show(this);
		}
	}

	private void fillsettinglist_SelectedIndexChanged(object sender, EventArgs e)
	{
		_Closure_0024__83 closure_0024__ = new _Closure_0024__83();
		changeing = true;
		closure_0024__._0024VB_0024Local_str = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(fillsettinglist.SelectedItem)))
		{
			closure_0024__._0024VB_0024Local_str = fillsettinglist.SelectedItem.ToString();
		}
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		int num = CConfigMng.Config.fillsettings.FindIndex(closure_0024__._Lambda_0024__141);
		if (num < 0)
		{
			return;
		}
		fillsetting fillsetting2 = CConfigMng.Config.fillsettings[num];
		try
		{
			ComboBox2.Text = MyProject.Forms.Frmmain.DGV1.Columns[fillsetting2.colindex].HeaderText;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		TextBox3.Text = fillsetting2.fillcontent;
		checked
		{
			int num2 = RuleList.Items.Count - 1;
			int num3 = 0;
			_Closure_0024__83._Closure_0024__84 closure_0024__2 = default(_Closure_0024__83._Closure_0024__84);
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				closure_0024__2 = new _Closure_0024__83._Closure_0024__84(closure_0024__2);
				closure_0024__2._0024VB_0024Local_name = Conversions.ToString(RuleList.Items[num3]);
				int num6 = fillsetting2.RulesList.FindIndex(closure_0024__2._Lambda_0024__142);
				if (num6 >= 0)
				{
					RuleList.SetItemChecked(num3, value: true);
				}
				else
				{
					RuleList.SetItemChecked(num3, value: false);
				}
				num3++;
			}
			changeing = false;
		}
	}

	private void TextBox3_TextChanged(object sender, EventArgs e)
	{
		if (!changeing)
		{
			updatefillsetting();
		}
	}

	private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!changeing)
		{
			updatefillsetting();
		}
	}

	private void RuleList_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!changeing)
		{
			updatefillsetting();
		}
	}

	public void updatefillsetting()
	{
		_Closure_0024__85 closure_0024__ = new _Closure_0024__85();
		closure_0024__._0024VB_0024Local_str = "";
		bool flag = true;
		checked
		{
			int num = fillsettinglist.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (fillsettinglist.GetSelected(num2))
				{
					closure_0024__._0024VB_0024Local_str = fillsettinglist.Items[num2].ToString();
					break;
				}
				num2++;
			}
			if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) != 0)
			{
				int num5 = CConfigMng.Config.fillsettings.FindIndex(closure_0024__._Lambda_0024__143);
				if (num5 >= 0)
				{
					CConfigMng.Config.fillsettings[num5] = createfillsetting(closure_0024__._0024VB_0024Local_str);
					CConfigMng.SaveConfig();
				}
			}
		}
	}

	private void TabControl1_Selected(object sender, TabControlEventArgs e)
	{
		checked
		{
			if (e.TabPageIndex == 0 || e.TabPageIndex == 2)
			{
				TableLayoutPanel2.Visible = true;
				FormBorderStyle = FormBorderStyle.FixedDialog;
				TabControl1.Dock = DockStyle.Top;
				Size size = new Size((int)Math.Round(439.0 * dpixRatio), (int)Math.Round(397.0 * dpixRatio));
				Size = size;
				TabControl1.Height = (int)Math.Round((double)Height - 67.0 * dpixRatio);
			}
			else if (e.TabPageIndex == 1)
			{
				TableLayoutPanel2.Visible = true;
				FormBorderStyle = FormBorderStyle.FixedDialog;
				TabControl1.Dock = DockStyle.Top;
				Size size = new Size((int)Math.Round(439.0 * dpixRatio), (int)Math.Round(443.0 * dpixRatio));
				Size = size;
				TabControl1.Height = (int)Math.Round((double)Height - 67.0 * dpixRatio);
			}
			else if (e.TabPageIndex == 3)
			{
				TableLayoutPanel2.Visible = false;
				FormBorderStyle = FormBorderStyle.Sizable;
				TabControl1.Dock = DockStyle.Fill;
				Size size = new Size(Conversions.ToInteger(Interaction.IIf(formwidth == 0.0, 560.0 * dpixRatio, formwidth * dpixRatio)), Conversions.ToInteger(Interaction.IIf(formheight == 0.0, 397.0 * dpixRatio, formheight * dpixRatio)));
				Size = size;
			}
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		openmenu.Show(Button3, 0, Button3.Height);
	}

	private void open_browse_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		openFileDialog.Filter = "Excel 文件（*.xls;*.xlsx）|*.xls;*.xlsx";
		if (openFileDialog.ShowDialog() != DialogResult.Cancel)
		{
			datasource.Text = openFileDialog.FileName;
		}
	}

	private void open_excel_Click(object sender, EventArgs e)
	{
		if (File.Exists(datasource.Text))
		{
			Process.Start(datasource.Text);
		}
		else
		{
			MessageBox.Show(" файл не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void open_folder_Click(object sender, EventArgs e)
	{
		if (Directory.Exists(code.SplitStr(datasource.Text)))
		{
			code.OpenFolderWithEX(code.SplitStr(datasource.Text));
		}
		else
		{
			MessageBox.Show(" путь не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		getdata(@bool: true);
		Cursor = Cursors.Default;
	}

	private void srownumer_ValueChanged(object sender, EventArgs e)
	{
		int num = Convert.ToInt32(decimal.Add(decimal.Subtract(new decimal(code.xlsdata.count), srownumer.Value), 1m));
		datacount.Text = Conversions.ToString(Interaction.IIf(num > 0, num, 0));
	}

	public void fill3()
	{
		if (ComboBox3.SelectedIndex == -1 || ComboBox4.SelectedIndex == -1)
		{
			return;
		}
		Cursor = Cursors.WaitCursor;
		getdata();
		checked
		{
			try
			{
				int num = Convert.ToInt32(srownumer.Value);
				int num2 = Convert.ToInt32(rcolnumer1.Value);
				int num3 = Convert.ToInt32(rcolnumer2.Value);
				if (code.xlsdata.count >= num)
				{
					hb.Clear();
					int count = code.xlsdata.count;
					int num4 = num;
					while (true)
					{
						int num5 = num4;
						int num6 = count;
						if (num5 <= num6)
						{
							string text = Conversions.ToString(NewLateBinding.LateIndexGet(code.xlsdata.data, new object[2] { num4, num2 }, null));
							string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(code.xlsdata.data, new object[2] { num4, num3 }, null));
							if ((Operators.CompareString(text, "", TextCompare: false) != 0 && Operators.CompareString(text2, "", TextCompare: false) != 0) ? true : false)
							{
								hb[text] = text2;
							}
							num4++;
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
			Cursor = Cursors.Default;
			if (hb.Count < 1)
			{
				return;
			}
			int num7 = 0;
			int num8 = 0;
			int num9 = ColList3[ComboBox3.SelectedIndex];
			int num10 = ColList4[ComboBox4.SelectedIndex];
			if ((num9 < 0 || num9 > MyProject.Forms.Frmmain.DGV1.ColumnCount - 1 || num10 < 0 || num10 > MyProject.Forms.Frmmain.DGV1.ColumnCount - 1) ? true : false)
			{
				return;
			}
			int num11 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
			int num12 = 0;
			while (true)
			{
				int num13 = num12;
				int num6 = num11;
				if (num13 > num6)
				{
					break;
				}
				if (MyProject.Forms.Frmmain.DGV1.Rows[num12].Visible)
				{
					string key = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num9, num12].Value);
					string text3 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num10, num12].Value);
					if (hb.ContainsKey(key))
					{
						num8++;
						if (!text3.Equals(Convert.ToString(RuntimeHelpers.GetObjectValue(hb[key])), StringComparison.OrdinalIgnoreCase))
						{
							if (num7 == 0)
							{
								CellArr.Clear();
								CellValArr.Clear();
								CellColorArr.Clear();
							}
							num7++;
							CellArr.Add(MyProject.Forms.Frmmain.DGV1[num10, num12]);
							CellValArr.Add(text3);
							CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[num10, num12].Style.ForeColor);
							MyProject.Forms.Frmmain.DGV1[num10, num12].Value = RuntimeHelpers.GetObjectValue(hb[key]);
						}
					}
				}
				num12++;
			}
			if (num8 > 0)
			{
				MessageBox.Show(this, "匹配 " + Conversions.ToString(num8) + " 项，填写 " + Conversions.ToString(num7) + " поз.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(this, "Совпадений не найдено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	public void getdata(bool @bool = false)
	{
		string text = datasource.Text;
		if (!File.Exists(text))
		{
			MessageBox.Show(this, "Источник данных не существует, сначала задайте файл источника", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		int num = Convert.ToInt32(srownumer.Value);
		if ((!@bool && code.xlsdata.count != 0 && code.xlsdata.xlspath.Equals(text, StringComparison.OrdinalIgnoreCase)) || 1 == 0)
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		object objectValue2 = RuntimeHelpers.GetObjectValue(new object());
		object objectValue3 = RuntimeHelpers.GetObjectValue(new object());
		try
		{
			objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application"));
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				MessageBox.Show(this, "Не удалось запустить Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			NewLateBinding.LateSet(objectValue, null, "Visible", new object[1] { false }, null, null);
			object instance = NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Application", new object[0], null, null, null), null, "Workbooks", new object[0], null, null, null);
			object[] array = new object[1] { text };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(instance, null, "Open", arguments, null, null, array2);
			if (array2[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			objectValue2 = RuntimeHelpers.GetObjectValue(obj);
			objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "ActiveSheet", new object[0], null, null, null));
			object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, null, "UsedRange", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
			{
				code.xlsdata = default(code.myxlsdata);
				code.xlsdata.data = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, null, "UsedRange", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				code.xlsdata.count = Information.UBound((Array)code.xlsdata.data);
				code.xlsdata.xlspath = text;
				int num2 = checked(code.xlsdata.count - num + 1);
				datacount.Text = Conversions.ToString(Interaction.IIf(num2 > 0, num2, 0));
			}
			else
			{
				MessageBox.Show(this, "Недопустимый источник данных!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			try
			{
				NewLateBinding.LateCall(objectValue2, null, "Close", new object[1] { false }, null, null, null, IgnoreReturn: true);
				NewLateBinding.LateCall(objectValue, null, "Quit", new object[0], null, null, null, IgnoreReturn: true);
				code.killxlapp(RuntimeHelpers.GetObjectValue(objectValue));
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void DGV1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
	{
		Rectangle rect = checked(new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1));
		SolidBrush solidBrush = new SolidBrush(mLinearColor1);
		try
		{
			if ((e.RowIndex == -1) | (e.ColumnIndex == -1))
			{
				e.Graphics.FillRectangle(solidBrush, rect);
				e.PaintContent(e.CellBounds);
				ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.RaisedOuter);
				e.Handled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		finally
		{
			rect = default(Rectangle);
			solidBrush?.Dispose();
		}
	}

	private void DGV1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		e.Cancel = true;
	}

	private void addcolumn_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(name_list.Text, "", TextCompare: false) == 0)
		{
			return;
		}
		foreach (DataColumn column in dt.Columns)
		{
			if (column.ColumnName.Equals(name_list.Text, StringComparison.OrdinalIgnoreCase))
			{
				MessageBox.Show(name_list.Text + " уже существует!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
		}
		dt.Columns.Add(name_list.Text, typeof(string));
		DGV1.DataSource = dt;
		name_list.Text = "";
	}

	private void delcolumn_DropDownOpening(object sender, EventArgs e)
	{
		delcolumn.DropDownItems.Clear();
		foreach (DataColumn column in dt.Columns)
		{
			delcolumn.DropDownItems.Add(column.ColumnName, Resources.del);
		}
	}

	private void delcolumn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		dt.Columns.Remove(e.ClickedItem.Text);
	}

	private void name_list_Click(object sender, EventArgs e)
	{
		name_list.Items.Clear();
		foreach (DataGridViewColumn column in MyProject.Forms.Frmmain.DGV1.Columns)
		{
			if (column.Name.Contains("PropVal_") && !dt.Columns.Contains(column.HeaderText))
			{
				name_list.Items.Add(column.HeaderText);
			}
		}
	}

	private void adddata_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				if (dt.Columns.Count < 1)
				{
					MessageBox.Show("Сначала добавьте столбец", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				DGV1.EndEdit();
				MyProject.Forms.Frmmain.DGV1.EndEdit();
				DataGridViewRow currentRow = MyProject.Forms.Frmmain.DGV1.CurrentRow;
				if (Information.IsNothing(currentRow))
				{
					return;
				}
				int index = currentRow.Index;
				DataRow dataRow = dt.NewRow();
				foreach (DataColumn column in dt.Columns)
				{
					dataRow[column.ColumnName] = null;
					foreach (DataGridViewColumn column2 in MyProject.Forms.Frmmain.DGV1.Columns)
					{
						if ((column.ColumnName.Equals(column2.HeaderText, StringComparison.OrdinalIgnoreCase) && column2.Name.Contains("PropVal_")) ? true : false)
						{
							dataRow[column.ColumnName] = RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[column2.Index, index].Value);
							break;
						}
					}
				}
				string text = "";
				object[] itemArray = dataRow.ItemArray;
				for (int i = 0; i < itemArray.Length; i++)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(itemArray[i]);
					text += Convert.ToString(RuntimeHelpers.GetObjectValue(objectValue));
				}
				if (Operators.CompareString(text, "", TextCompare: false) == 0)
				{
					return;
				}
				bool flag = false;
				foreach (DataRow row in dt.Rows)
				{
					string text2 = "";
					object[] itemArray2 = row.ItemArray;
					for (int j = 0; j < itemArray2.Length; j++)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(itemArray2[j]);
						text2 += Convert.ToString(RuntimeHelpers.GetObjectValue(objectValue2));
					}
					if (text.Equals(text2, StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					dt.Rows.Add(dataRow);
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

	private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		checked
		{
			try
			{
				if (e.RowIndex > dt.Rows.Count - 1 || e.RowIndex < 0)
				{
					return;
				}
				DGV1.EndEdit();
				MyProject.Forms.Frmmain.Focus();
				DataGridViewCell currentCell = MyProject.Forms.Frmmain.DGV1.CurrentCell;
				if (Information.IsNothing(currentCell))
				{
					return;
				}
				int rowIndex = currentCell.RowIndex;
				int columnIndex = currentCell.ColumnIndex;
				foreach (DataGridViewColumn column in MyProject.Forms.Frmmain.DGV1.Columns)
				{
					foreach (DataColumn column2 in dt.Columns)
					{
						if (column.HeaderText.Equals(column2.ColumnName, StringComparison.OrdinalIgnoreCase))
						{
							string value = Convert.ToString(RuntimeHelpers.GetObjectValue(dt.Rows[e.RowIndex][column2.ColumnName]));
							MyProject.Forms.Frmmain.DGV1[column.Index, rowIndex].Value = value;
							break;
						}
					}
				}
				if (rowIndex >= MyProject.Forms.Frmmain.DGV1.RowCount - 1)
				{
					return;
				}
				int num = rowIndex + 1;
				int num2 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num3 = num;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 <= num5)
					{
						if (MyProject.Forms.Frmmain.DGV1[columnIndex, num3].Visible)
						{
							MyProject.Forms.Frmmain.DGV1.CurrentCell = null;
							MyProject.Forms.Frmmain.DGV1.CurrentCell = MyProject.Forms.Frmmain.DGV1[columnIndex, num3];
							break;
						}
						num3++;
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

	private void addcolumn_MouseEnter(object sender, EventArgs e)
	{
		ToolStrip1.Focus();
		NewLateBinding.LateCall(sender, null, "Select", new object[0], null, null, null, IgnoreReturn: true);
	}

	private void DGV1_Sorted(object sender, EventArgs e)
	{
		string sort = DGV1.SortedColumn.Name + ((DGV1.SortOrder == SortOrder.Ascending) ? " ASC" : " DESC");
		dt.DefaultView.Sort = sort;
		dt = dt.DefaultView.ToTable();
	}

	private void Savecfg()
	{
		CConfigMng.Config.fillcolumncfg.Clear();
		foreach (Control control in TabPage3.Controls)
		{
			FindctlToSave(control);
		}
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control ctl)
	{
		if (ctl is CheckBox)
		{
			CConfigMng.Config.fillcolumncfg.Add(ctl.Name + "\n" + Conversions.ToString(((CheckBox)ctl).Checked));
		}
		else if ((ctl is TextBox && !(ctl.Parent is NumericUpDown)) ? true : false)
		{
			CConfigMng.Config.fillcolumncfg.Add(ctl.Name + "\n" + ((TextBox)ctl).Text);
		}
		else if (ctl is ComboBox)
		{
			CConfigMng.Config.fillcolumncfg.Add(ctl.Name + "\n" + Conversions.ToString(((ComboBox)ctl).SelectedIndex));
		}
		else if (ctl is RadioButton)
		{
			CConfigMng.Config.fillcolumncfg.Add(ctl.Name + "\n" + Conversions.ToString(((RadioButton)ctl).Checked));
		}
		else if (ctl is NumericUpDown)
		{
			CConfigMng.Config.fillcolumncfg.Add(ctl.Name + "\n" + Conversions.ToString(((NumericUpDown)ctl).Value));
		}
		if (!ctl.HasChildren)
		{
			return;
		}
		foreach (Control control in ctl.Controls)
		{
			FindctlToSave(control);
		}
	}

	private void Loadcfg()
	{
		foreach (Control control in TabPage3.Controls)
		{
			FindctlToLoad(control);
		}
	}

	private void FindctlToLoad(Control ctl)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string[] array = default(string[]);
		int num5 = default(int);
		int num6 = default(int);
		IEnumerator enumerator = default(IEnumerator);
		Control ctl2 = default(Control);
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
					case 642:
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
								goto IL_0026;
							case 4:
								goto IL_0046;
							case 6:
							case 7:
								goto IL_0060;
							case 8:
								goto IL_007e;
							case 9:
								goto IL_0090;
							case 11:
								goto IL_00ad;
							case 12:
								goto IL_00c0;
							case 14:
								goto IL_00d8;
							case 15:
								goto IL_00eb;
							case 17:
								goto IL_010b;
							case 18:
								goto IL_011e;
							case 20:
								goto IL_0138;
							case 21:
								goto IL_014b;
							case 5:
							case 10:
							case 13:
							case 16:
							case 19:
							case 22:
							case 23:
							case 24:
								goto IL_016b;
							case 25:
								goto IL_017f;
							case 26:
								goto IL_018f;
							case 27:
								goto IL_01af;
							case 28:
								goto IL_01bb;
							default:
								goto end_IL_0001;
							case 29:
							case 30:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_00eb:
						num2 = 15;
						((ComboBox)ctl).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_016b;
						IL_010b:
						num2 = 17;
						if (ctl is RadioButton)
						{
							goto IL_011e;
						}
						goto IL_0138;
						IL_00d8:
						num2 = 14;
						if (ctl is ComboBox)
						{
							goto IL_00eb;
						}
						goto IL_010b;
						IL_011e:
						num2 = 18;
						((RadioButton)ctl).Checked = code.Cbool1(array[1]);
						goto IL_016b;
						IL_000a:
						num2 = 2;
						num5 = CConfigMng.Config.fillcolumncfg.Count - 1;
						num6 = 0;
						goto IL_0174;
						IL_0174:
						num7 = num6;
						num8 = num5;
						if (num7 <= num8)
						{
							goto IL_0026;
						}
						goto IL_017f;
						IL_017f:
						num2 = 25;
						if (!ctl.HasChildren)
						{
							goto end_IL_0001_2;
						}
						goto IL_018f;
						IL_018f:
						num2 = 26;
						enumerator = ctl.Controls.GetEnumerator();
						goto IL_01c0;
						IL_01c0:
						if (enumerator.MoveNext())
						{
							ctl2 = (Control)enumerator.Current;
							goto IL_01af;
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto end_IL_0001_2;
						IL_0138:
						num2 = 20;
						if (ctl is NumericUpDown)
						{
							goto IL_014b;
						}
						goto IL_016b;
						IL_016b:
						num2 = 24;
						num6++;
						goto IL_0174;
						IL_014b:
						num2 = 21;
						((NumericUpDown)ctl).Value = new decimal(Conversion.Val(array[1]));
						goto IL_016b;
						IL_01af:
						num2 = 27;
						FindctlToLoad(ctl2);
						goto IL_01bb;
						IL_01bb:
						num2 = 28;
						goto IL_01c0;
						IL_0026:
						num2 = 3;
						array = Strings.Split(CConfigMng.Config.fillcolumncfg[num6], "\n");
						goto IL_0046;
						IL_0046:
						num2 = 4;
						if (array.Count() == 2)
						{
							goto IL_0060;
						}
						goto IL_016b;
						IL_0060:
						num2 = 7;
						if (Operators.CompareString(ctl.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_007e;
						}
						goto IL_016b;
						IL_007e:
						num2 = 8;
						if (ctl is CheckBox)
						{
							goto IL_0090;
						}
						goto IL_00ad;
						IL_0090:
						num2 = 9;
						((CheckBox)ctl).Checked = code.Cbool1(array[1]);
						goto IL_016b;
						IL_00ad:
						num2 = 11;
						if (ctl is TextBox)
						{
							goto IL_00c0;
						}
						goto IL_00d8;
						IL_00c0:
						num2 = 12;
						((TextBox)ctl).Text = array[1];
						goto IL_016b;
						end_IL_0001:
						break;
					}
				}
			}
			catch (Exception obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 642;
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
}
