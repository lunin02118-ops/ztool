using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class Frmexportbom : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__28
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__28()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__28(_Closure_0024__28 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__63(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__29
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__29()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__29(_Closure_0024__29 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__64(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__30
	{
		[CompilerGenerated]
		internal class _Closure_0024__31
		{
			public string _0024VB_0024Local_name;

			[DebuggerNonUserCode]
			public _Closure_0024__31(_Closure_0024__31 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_name = other._0024VB_0024Local_name;
				}
			}

			[DebuggerNonUserCode]
			public _Closure_0024__31()
			{
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__67(string s)
			{
				return s.Equals(_0024VB_0024Local_name, StringComparison.OrdinalIgnoreCase);
			}
		}

		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__30()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__30(_Closure_0024__30 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__66(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__32
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__32()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__32(_Closure_0024__32 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__68(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__33
	{
		public string _0024VB_0024Local_RuleName;

		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__33()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__33(_Closure_0024__33 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_RuleName = other._0024VB_0024Local_RuleName;
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__69(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_RuleName, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__70(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__34
	{
		public string _0024VB_0024Local_RuleName;

		[DebuggerNonUserCode]
		public _Closure_0024__34(_Closure_0024__34 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_RuleName = other._0024VB_0024Local_RuleName;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__34()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__71(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_RuleName, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("Apply_Button")]
	private Button _Apply_Button;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("ByRuler")]
	private CheckBox _ByRuler;

	[AccessedThroughProperty("ByFilter")]
	private CheckBox _ByFilter;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("ComboBox1")]
	private CustomComboBox2 _ComboBox1;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("lockratio")]
	private CheckBox _lockratio;

	[AccessedThroughProperty("insertimagebool")]
	private CheckBox _insertimagebool;

	[AccessedThroughProperty("image_height")]
	private NumericUpDown _image_height;

	[AccessedThroughProperty("image_width")]
	private NumericUpDown _image_width;

	[AccessedThroughProperty("Label9")]
	private Label _Label9;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("Propertylink")]
	private RadioButton _Propertylink;

	[AccessedThroughProperty("Propertyvalue")]
	private RadioButton _Propertyvalue;

	[AccessedThroughProperty("marknodrw")]
	private CheckBox _marknodrw;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("autocolumnwidth")]
	private CheckBox _autocolumnwidth;

	[AccessedThroughProperty("RuleList")]
	private CheckedListBox _RuleList;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("RadioButton3")]
	private RadioButton _RadioButton3;

	[AccessedThroughProperty("GroupBox5")]
	private GroupBox _GroupBox5;

	[AccessedThroughProperty("bomsettinglist")]
	private ListBox _bomsettinglist;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("add")]
	private Button _add;

	[AccessedThroughProperty("edit")]
	private Button _edit;

	[AccessedThroughProperty("del")]
	private Button _del;

	[AccessedThroughProperty("includetop")]
	private CheckBox _includetop;

	[AccessedThroughProperty("openmenu")]
	private ContextMenuStrip _openmenu;

	[AccessedThroughProperty("open_browse")]
	private ToolStripMenuItem _open_browse;

	[AccessedThroughProperty("open_excel")]
	private ToolStripMenuItem _open_excel;

	[AccessedThroughProperty("open_folder")]
	private ToolStripMenuItem _open_folder;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("RadioButton4")]
	private RadioButton _RadioButton4;

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

	internal virtual Button Apply_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Apply_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Apply_Button_Click;
			if (_Apply_Button != null)
			{
				_Apply_Button.Click -= value2;
			}
			_Apply_Button = value;
			if (_Apply_Button != null)
			{
				_Apply_Button.Click += value2;
			}
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

	internal virtual CheckBox ByRuler
	{
		[DebuggerNonUserCode]
		get
		{
			return _ByRuler;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ByRuler = value;
		}
	}

	internal virtual CheckBox ByFilter
	{
		[DebuggerNonUserCode]
		get
		{
			return _ByFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ByFilter = value;
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
			EventHandler value2 = RadioButton2_CheckedChanged;
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

	internal virtual CustomComboBox2 ComboBox1
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
			EventHandler value2 = ComboBox1_DropDown;
			if (_ComboBox1 != null)
			{
				_ComboBox1.DropDown -= value2;
			}
			_ComboBox1 = value;
			if (_ComboBox1 != null)
			{
				_ComboBox1.DropDown += value2;
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

	internal virtual CheckBox lockratio
	{
		[DebuggerNonUserCode]
		get
		{
			return _lockratio;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_lockratio = value;
		}
	}

	internal virtual CheckBox insertimagebool
	{
		[DebuggerNonUserCode]
		get
		{
			return _insertimagebool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_insertimagebool = value;
		}
	}

	internal virtual NumericUpDown image_height
	{
		[DebuggerNonUserCode]
		get
		{
			return _image_height;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = image_height_ValueChanged;
			if (_image_height != null)
			{
				_image_height.ValueChanged -= value2;
			}
			_image_height = value;
			if (_image_height != null)
			{
				_image_height.ValueChanged += value2;
			}
		}
	}

	internal virtual NumericUpDown image_width
	{
		[DebuggerNonUserCode]
		get
		{
			return _image_width;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = image_width_ValueChanged;
			if (_image_width != null)
			{
				_image_width.ValueChanged -= value2;
			}
			_image_width = value;
			if (_image_width != null)
			{
				_image_width.ValueChanged += value2;
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

	internal virtual RadioButton Propertylink
	{
		[DebuggerNonUserCode]
		get
		{
			return _Propertylink;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Propertylink = value;
		}
	}

	internal virtual RadioButton Propertyvalue
	{
		[DebuggerNonUserCode]
		get
		{
			return _Propertyvalue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Propertyvalue = value;
		}
	}

	internal virtual CheckBox marknodrw
	{
		[DebuggerNonUserCode]
		get
		{
			return _marknodrw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_marknodrw = value;
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

	internal virtual CheckBox autocolumnwidth
	{
		[DebuggerNonUserCode]
		get
		{
			return _autocolumnwidth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_autocolumnwidth = value;
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
			_RuleList = value;
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

	internal virtual RadioButton RadioButton3
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RadioButton2_CheckedChanged;
			if (_RadioButton3 != null)
			{
				_RadioButton3.CheckedChanged -= value2;
			}
			_RadioButton3 = value;
			if (_RadioButton3 != null)
			{
				_RadioButton3.CheckedChanged += value2;
			}
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

	internal virtual ListBox bomsettinglist
	{
		[DebuggerNonUserCode]
		get
		{
			return _bomsettinglist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = bomsettinglist_SelectedIndexChanged;
			if (_bomsettinglist != null)
			{
				_bomsettinglist.SelectedIndexChanged -= value2;
			}
			_bomsettinglist = value;
			if (_bomsettinglist != null)
			{
				_bomsettinglist.SelectedIndexChanged += value2;
			}
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

	internal virtual CheckBox includetop
	{
		[DebuggerNonUserCode]
		get
		{
			return _includetop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_includetop = value;
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

	internal virtual RadioButton RadioButton4
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RadioButton2_CheckedChanged;
			if (_RadioButton4 != null)
			{
				_RadioButton4.CheckedChanged -= value2;
			}
			_RadioButton4 = value;
			if (_RadioButton4 != null)
			{
				_RadioButton4.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	public Frmexportbom()
	{
		base.FormClosed += Frmexportbom_FormClosed;
		base.Load += Frmexportbom_Load;
		base.Activated += Frmexportbom_Activated;
		__ENCAddToList(this);
		InitializeComponent();
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
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button1 = new System.Windows.Forms.Button();
		this.Apply_Button = new System.Windows.Forms.Button();
		this.OK_Button = new System.Windows.Forms.Button();
		this.ByRuler = new System.Windows.Forms.CheckBox();
		this.ByFilter = new System.Windows.Forms.CheckBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.RuleList = new System.Windows.Forms.CheckedListBox();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.RadioButton3 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.lockratio = new System.Windows.Forms.CheckBox();
		this.insertimagebool = new System.Windows.Forms.CheckBox();
		this.image_height = new System.Windows.Forms.NumericUpDown();
		this.image_width = new System.Windows.Forms.NumericUpDown();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Propertylink = new System.Windows.Forms.RadioButton();
		this.Propertyvalue = new System.Windows.Forms.RadioButton();
		this.marknodrw = new System.Windows.Forms.CheckBox();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.includetop = new System.Windows.Forms.CheckBox();
		this.autocolumnwidth = new System.Windows.Forms.CheckBox();
		this.Button3 = new System.Windows.Forms.Button();
		this.openmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.open_browse = new System.Windows.Forms.ToolStripMenuItem();
		this.open_excel = new System.Windows.Forms.ToolStripMenuItem();
		this.open_folder = new System.Windows.Forms.ToolStripMenuItem();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.bomsettinglist = new System.Windows.Forms.ListBox();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.add = new System.Windows.Forms.Button();
		this.edit = new System.Windows.Forms.Button();
		this.del = new System.Windows.Forms.Button();
		this.ComboBox1 = new ZTool.CustomComboBox2();
		this.RadioButton4 = new System.Windows.Forms.RadioButton();
		this.TableLayoutPanel1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.image_height).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.image_width).BeginInit();
		this.GroupBox4.SuspendLayout();
		this.openmenu.SuspendLayout();
		this.GroupBox5.SuspendLayout();
		this.TableLayoutPanel2.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.Button1, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Apply_Button, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 2, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(448, 344);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(277, 32);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(22, 3);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(61, 26);
		button2.Size = size;
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Справка";
		this.Apply_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Apply_Button.AutoSize = true;
		System.Windows.Forms.Button apply_Button = this.Apply_Button;
		location = new System.Drawing.Point(114, 3);
		apply_Button.Location = location;
		this.Apply_Button.Name = "Apply_Button";
		System.Windows.Forms.Button apply_Button2 = this.Apply_Button;
		size = new System.Drawing.Size(67, 26);
		apply_Button2.Size = size;
		this.Apply_Button.TabIndex = 0;
		this.Apply_Button.Text = "Применить";
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(200, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 26);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "ОК";
		this.ByRuler.AutoSize = true;
		System.Windows.Forms.CheckBox byRuler = this.ByRuler;
		location = new System.Drawing.Point(528, 304);
		byRuler.Location = location;
		System.Windows.Forms.CheckBox byRuler2 = this.ByRuler;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		byRuler2.Margin = margin;
		this.ByRuler.Name = "ByRuler";
		System.Windows.Forms.CheckBox byRuler3 = this.ByRuler;
		size = new System.Drawing.Size(75, 21);
		byRuler3.Size = size;
		this.ByRuler.TabIndex = 33;
		this.ByRuler.Text = "Включить правило";
		this.ByRuler.UseVisualStyleBackColor = true;
		this.ByFilter.AutoSize = true;
		System.Windows.Forms.CheckBox byFilter = this.ByFilter;
		location = new System.Drawing.Point(616, 304);
		byFilter.Location = location;
		System.Windows.Forms.CheckBox byFilter2 = this.ByFilter;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		byFilter2.Margin = margin;
		this.ByFilter.Name = "ByFilter";
		System.Windows.Forms.CheckBox byFilter3 = this.ByFilter;
		size = new System.Drawing.Size(75, 21);
		byFilter3.Size = size;
		this.ByFilter.TabIndex = 32;
		this.ByFilter.Text = "Включить фильтр";
		this.ByFilter.UseVisualStyleBackColor = true;
		this.GroupBox2.Controls.Add(this.RuleList);
		this.GroupBox2.Controls.Add(this.LinkLabel1);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox2;
		location = new System.Drawing.Point(520, 48);
		groupBox.Location = location;
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox2.Margin = margin;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
		groupBox3.Padding = margin;
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(208, 216);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 35;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Пользовательское правило";
		this.RuleList.CheckOnClick = true;
		this.RuleList.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.CheckedListBox ruleList = this.RuleList;
		location = new System.Drawing.Point(3, 20);
		ruleList.Location = location;
		System.Windows.Forms.CheckedListBox ruleList2 = this.RuleList;
		margin = new System.Windows.Forms.Padding(0);
		ruleList2.Margin = margin;
		this.RuleList.Name = "RuleList";
		this.RuleList.ScrollAlwaysVisible = true;
		System.Windows.Forms.CheckedListBox ruleList3 = this.RuleList;
		size = new System.Drawing.Size(202, 176);
		ruleList3.Size = size;
		this.RuleList.TabIndex = 17;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.LinkLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(3, 196);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(56, 17);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 44;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Создать правило";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.GroupBox1.BackColor = System.Drawing.SystemColors.Control;
		this.GroupBox1.Controls.Add(this.RadioButton4);
		this.GroupBox1.Controls.Add(this.RadioButton3);
		this.GroupBox1.Controls.Add(this.RadioButton2);
		this.GroupBox1.Controls.Add(this.RadioButton1);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox1;
		location = new System.Drawing.Point(210, 48);
		groupBox5.Location = location;
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox6.Margin = margin;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox7.Padding = margin;
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox1;
		size = new System.Drawing.Size(112, 152);
		groupBox8.Size = size;
		this.GroupBox1.TabIndex = 30;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Тип спецификации";
		this.RadioButton3.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton3;
		location = new System.Drawing.Point(16, 88);
		radioButton.Location = location;
		this.RadioButton3.Name = "RadioButton3";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton3;
		size = new System.Drawing.Size(74, 21);
		radioButton2.Size = size;
		this.RadioButton3.TabIndex = 0;
		this.RadioButton3.TabStop = true;
		this.RadioButton3.Text = "Только верхний уровень";
		this.RadioButton3.UseVisualStyleBackColor = true;
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton2;
		location = new System.Drawing.Point(16, 56);
		radioButton3.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton2;
		size = new System.Drawing.Size(50, 21);
		radioButton4.Size = size;
		this.RadioButton2.TabIndex = 0;
		this.RadioButton2.TabStop = true;
		this.RadioButton2.Text = "Отступ";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton5 = this.RadioButton1;
		location = new System.Drawing.Point(16, 24);
		radioButton5.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton6 = this.RadioButton1;
		size = new System.Drawing.Size(50, 21);
		radioButton6.Size = size;
		this.RadioButton1.TabIndex = 0;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Сводка";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(208, 12);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(65, 17);
		label2.Size = size;
		this.Label1.TabIndex = 28;
		this.Label1.Text = "Шаблон спецификации:";
		this.GroupBox3.BackColor = System.Drawing.SystemColors.Control;
		this.GroupBox3.Controls.Add(this.lockratio);
		this.GroupBox3.Controls.Add(this.insertimagebool);
		this.GroupBox3.Controls.Add(this.image_height);
		this.GroupBox3.Controls.Add(this.image_width);
		this.GroupBox3.Controls.Add(this.Label9);
		this.GroupBox3.Controls.Add(this.Label8);
		this.GroupBox3.Controls.Add(this.Label7);
		System.Windows.Forms.GroupBox groupBox9 = this.GroupBox3;
		location = new System.Drawing.Point(210, 208);
		groupBox9.Location = location;
		System.Windows.Forms.GroupBox groupBox10 = this.GroupBox3;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox10.Margin = margin;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox11 = this.GroupBox3;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox11.Padding = margin;
		System.Windows.Forms.GroupBox groupBox12 = this.GroupBox3;
		size = new System.Drawing.Size(296, 136);
		groupBox12.Size = size;
		this.GroupBox3.TabIndex = 30;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Эскиз";
		this.lockratio.AutoSize = true;
		this.lockratio.Checked = true;
		this.lockratio.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox = this.lockratio;
		location = new System.Drawing.Point(16, 48);
		checkBox.Location = location;
		this.lockratio.Name = "lockratio";
		System.Windows.Forms.CheckBox checkBox2 = this.lockratio;
		size = new System.Drawing.Size(185, 21);
		checkBox2.Size = size;
		this.lockratio.TabIndex = 11;
		this.lockratio.Text = "Сохранять пропорции (исходное соотношение 4:3)";
		this.lockratio.UseVisualStyleBackColor = true;
		this.insertimagebool.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox3 = this.insertimagebool;
		location = new System.Drawing.Point(16, 24);
		checkBox3.Location = location;
		this.insertimagebool.Name = "insertimagebool";
		System.Windows.Forms.CheckBox checkBox4 = this.insertimagebool;
		size = new System.Drawing.Size(87, 21);
		checkBox4.Size = size;
		this.insertimagebool.TabIndex = 10;
		this.insertimagebool.Text = "Вставить эскиз";
		this.insertimagebool.UseVisualStyleBackColor = true;
		this.image_height.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.NumericUpDown numericUpDown = this.image_height;
		location = new System.Drawing.Point(200, 102);
		numericUpDown.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown2 = this.image_height;
		decimal maximum = new decimal(new int[4] { 256, 0, 0, 0 });
		numericUpDown2.Maximum = maximum;
		maximum = (this.image_height.Minimum = new decimal(new int[4] { 32, 0, 0, 0 }));
		this.image_height.Name = "image_height";
		System.Windows.Forms.NumericUpDown numericUpDown3 = this.image_height;
		size = new System.Drawing.Size(62, 23);
		numericUpDown3.Size = size;
		this.image_height.TabIndex = 14;
		maximum = (this.image_height.Value = new decimal(new int[4] { 48, 0, 0, 0 }));
		this.image_width.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.NumericUpDown numericUpDown4 = this.image_width;
		location = new System.Drawing.Point(67, 102);
		numericUpDown4.Location = location;
		maximum = (this.image_width.Maximum = new decimal(new int[4] { 256, 0, 0, 0 }));
		maximum = (this.image_width.Minimum = new decimal(new int[4] { 32, 0, 0, 0 }));
		this.image_width.Name = "image_width";
		System.Windows.Forms.NumericUpDown numericUpDown5 = this.image_width;
		size = new System.Drawing.Size(62, 23);
		numericUpDown5.Size = size;
		this.image_width.TabIndex = 12;
		maximum = (this.image_width.Value = new decimal(new int[4] { 64, 0, 0, 0 }));
		this.Label9.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label9;
		location = new System.Drawing.Point(153, 104);
		label3.Location = location;
		this.Label9.Name = "Label9";
		System.Windows.Forms.Label label4 = this.Label9;
		size = new System.Drawing.Size(44, 17);
		label4.Size = size;
		this.Label9.TabIndex = 13;
		this.Label9.Text = "Высота:";
		this.Label8.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label8;
		location = new System.Drawing.Point(16, 104);
		label5.Location = location;
		this.Label8.Name = "Label8";
		System.Windows.Forms.Label label6 = this.Label8;
		size = new System.Drawing.Size(44, 17);
		label6.Size = size;
		this.Label8.TabIndex = 15;
		this.Label8.Text = "Ширина:";
		this.Label7.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label7;
		location = new System.Drawing.Point(16, 80);
		label7.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label8 = this.Label7;
		size = new System.Drawing.Size(80, 17);
		label8.Size = size;
		this.Label7.TabIndex = 16;
		this.Label7.Text = "Размер эскиза:";
		this.Propertylink.AutoSize = true;
		System.Windows.Forms.RadioButton propertylink = this.Propertylink;
		location = new System.Drawing.Point(16, 48);
		propertylink.Location = location;
		this.Propertylink.Name = "Propertylink";
		System.Windows.Forms.RadioButton propertylink2 = this.Propertylink;
		size = new System.Drawing.Size(110, 21);
		propertylink2.Size = size;
		this.Propertylink.TabIndex = 38;
		this.Propertylink.Text = "Выводить выражения свойств";
		this.Propertylink.UseVisualStyleBackColor = true;
		this.Propertyvalue.AutoSize = true;
		this.Propertyvalue.Checked = true;
		System.Windows.Forms.RadioButton propertyvalue = this.Propertyvalue;
		location = new System.Drawing.Point(16, 24);
		propertyvalue.Location = location;
		this.Propertyvalue.Name = "Propertyvalue";
		System.Windows.Forms.RadioButton propertyvalue2 = this.Propertyvalue;
		size = new System.Drawing.Size(86, 21);
		propertyvalue2.Size = size;
		this.Propertyvalue.TabIndex = 37;
		this.Propertyvalue.TabStop = true;
		this.Propertyvalue.Text = "Выводить значения свойств";
		this.Propertyvalue.UseVisualStyleBackColor = true;
		this.marknodrw.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox5 = this.marknodrw;
		location = new System.Drawing.Point(16, 72);
		checkBox5.Location = location;
		this.marknodrw.Name = "marknodrw";
		System.Windows.Forms.CheckBox checkBox6 = this.marknodrw;
		size = new System.Drawing.Size(135, 21);
		checkBox6.Size = size;
		this.marknodrw.TabIndex = 39;
		this.marknodrw.Text = "Отмечать элементы без чертежей";
		this.marknodrw.UseVisualStyleBackColor = true;
		this.GroupBox4.BackColor = System.Drawing.SystemColors.Control;
		this.GroupBox4.Controls.Add(this.includetop);
		this.GroupBox4.Controls.Add(this.autocolumnwidth);
		this.GroupBox4.Controls.Add(this.marknodrw);
		this.GroupBox4.Controls.Add(this.Propertylink);
		this.GroupBox4.Controls.Add(this.Propertyvalue);
		System.Windows.Forms.GroupBox groupBox13 = this.GroupBox4;
		location = new System.Drawing.Point(334, 48);
		groupBox13.Location = location;
		System.Windows.Forms.GroupBox groupBox14 = this.GroupBox4;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox14.Margin = margin;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox15 = this.GroupBox4;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox15.Padding = margin;
		System.Windows.Forms.GroupBox groupBox16 = this.GroupBox4;
		size = new System.Drawing.Size(172, 152);
		groupBox16.Size = size;
		this.GroupBox4.TabIndex = 40;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Прочее";
		this.includetop.AutoSize = true;
		this.includetop.Checked = true;
		this.includetop.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox7 = this.includetop;
		location = new System.Drawing.Point(16, 120);
		checkBox7.Location = location;
		this.includetop.Name = "includetop";
		System.Windows.Forms.CheckBox checkBox8 = this.includetop;
		size = new System.Drawing.Size(87, 21);
		checkBox8.Size = size;
		this.includetop.TabIndex = 40;
		this.includetop.Text = "Включая самый верхний уровень";
		this.includetop.UseVisualStyleBackColor = true;
		this.autocolumnwidth.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox9 = this.autocolumnwidth;
		location = new System.Drawing.Point(16, 96);
		checkBox9.Location = location;
		this.autocolumnwidth.Name = "autocolumnwidth";
		System.Windows.Forms.CheckBox checkBox10 = this.autocolumnwidth;
		size = new System.Drawing.Size(75, 21);
		checkBox10.Size = size;
		this.autocolumnwidth.TabIndex = 39;
		this.autocolumnwidth.Text = "Автоширина столбцов";
		this.autocolumnwidth.UseVisualStyleBackColor = true;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button3.AutoSize = true;
		this.Button3.ContextMenuStrip = this.openmenu;
		System.Windows.Forms.Button button3 = this.Button3;
		location = new System.Drawing.Point(696, 7);
		button3.Location = location;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button4 = this.Button3;
		size = new System.Drawing.Size(32, 27);
		button4.Size = size;
		this.Button3.TabIndex = 43;
		this.Button3.Text = "...";
		this.Button3.UseVisualStyleBackColor = true;
		this.openmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.open_browse, this.open_excel, this.open_folder });
		this.openmenu.Name = "Savemenu";
		this.openmenu.ShowImageMargin = false;
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.openmenu;
		size = new System.Drawing.Size(153, 70);
		contextMenuStrip.Size = size;
		this.open_browse.Name = "open_browse";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.open_browse;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem.Size = size;
		this.open_browse.Text = "Обзор шаблона Excel";
		this.open_excel.Name = "open_excel";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.open_excel;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem2.Size = size;
		this.open_excel.Text = "Открыть текущий шаблон Excel";
		this.open_folder.Name = "open_folder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.open_folder;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem3.Size = size;
		this.open_folder.Text = "Открыть текущую папку";
		this.GroupBox5.Controls.Add(this.bomsettinglist);
		this.GroupBox5.Controls.Add(this.TableLayoutPanel2);
		System.Windows.Forms.GroupBox groupBox17 = this.GroupBox5;
		location = new System.Drawing.Point(8, 8);
		groupBox17.Location = location;
		this.GroupBox5.Name = "GroupBox5";
		System.Windows.Forms.GroupBox groupBox18 = this.GroupBox5;
		size = new System.Drawing.Size(192, 360);
		groupBox18.Size = size;
		this.GroupBox5.TabIndex = 45;
		this.GroupBox5.TabStop = false;
		this.GroupBox5.Text = "Схема спецификации";
		this.bomsettinglist.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.bomsettinglist.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.bomsettinglist.FormattingEnabled = true;
		this.bomsettinglist.IntegralHeight = false;
		this.bomsettinglist.ItemHeight = 17;
		System.Windows.Forms.ListBox listBox = this.bomsettinglist;
		location = new System.Drawing.Point(9, 20);
		listBox.Location = location;
		this.bomsettinglist.Name = "bomsettinglist";
		this.bomsettinglist.ScrollAlwaysVisible = true;
		this.bomsettinglist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
		System.Windows.Forms.ListBox listBox2 = this.bomsettinglist;
		size = new System.Drawing.Size(174, 289);
		listBox2.Size = size;
		this.bomsettinglist.TabIndex = 24;
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.TableLayoutPanel2.ColumnCount = 3;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.Controls.Add(this.add, 0, 0);
		this.TableLayoutPanel2.Controls.Add(this.edit, 1, 0);
		this.TableLayoutPanel2.Controls.Add(this.del, 2, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel2;
		location = new System.Drawing.Point(6, 318);
		tableLayoutPanel3.Location = location;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(178, 33);
		tableLayoutPanel4.Size = size;
		this.TableLayoutPanel2.TabIndex = 27;
		this.add.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button5 = this.add;
		location = new System.Drawing.Point(7, 3);
		button5.Location = location;
		this.add.Name = "add";
		System.Windows.Forms.Button button6 = this.add;
		size = new System.Drawing.Size(45, 27);
		button6.Size = size;
		this.add.TabIndex = 0;
		this.add.Text = "Добавить";
		this.add.UseVisualStyleBackColor = true;
		this.edit.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button7 = this.edit;
		location = new System.Drawing.Point(62, 3);
		button7.Location = location;
		this.edit.Name = "edit";
		System.Windows.Forms.Button button8 = this.edit;
		size = new System.Drawing.Size(53, 27);
		button8.Size = size;
		this.edit.TabIndex = 0;
		this.edit.Text = "Переименовать";
		this.edit.UseVisualStyleBackColor = true;
		this.del.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button9 = this.del;
		location = new System.Drawing.Point(125, 3);
		button9.Location = location;
		this.del.Name = "del";
		System.Windows.Forms.Button button10 = this.del;
		size = new System.Drawing.Size(45, 27);
		button10.Size = size;
		this.del.TabIndex = 0;
		this.del.Text = "Удалить";
		this.del.UseVisualStyleBackColor = true;
		this.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox1.FormattingEnabled = true;
		ZTool.CustomComboBox2 comboBox = this.ComboBox1;
		location = new System.Drawing.Point(272, 8);
		comboBox.Location = location;
		this.ComboBox1.Name = "ComboBox1";
		ZTool.CustomComboBox2 comboBox2 = this.ComboBox1;
		size = new System.Drawing.Size(424, 25);
		comboBox2.Size = size;
		this.ComboBox1.TabIndex = 36;
		this.RadioButton4.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton7 = this.RadioButton4;
		location = new System.Drawing.Point(16, 120);
		radioButton7.Location = location;
		this.RadioButton4.Name = "RadioButton4";
		System.Windows.Forms.RadioButton radioButton8 = this.RadioButton4;
		size = new System.Drawing.Size(74, 21);
		radioButton8.Size = size;
		this.RadioButton4.TabIndex = 0;
		this.RadioButton4.TabStop = true;
		this.RadioButton4.Text = "Только детали";
		this.RadioButton4.UseVisualStyleBackColor = true;
		this.AcceptButton = this.Apply_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.OK_Button;
		size = new System.Drawing.Size(737, 382);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox5);
		this.Controls.Add(this.Button3);
		this.Controls.Add(this.GroupBox4);
		this.Controls.Add(this.ComboBox1);
		this.Controls.Add(this.ByRuler);
		this.Controls.Add(this.ByFilter);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox3);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.Label1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "Frmexportbom";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Настроить схему спецификации";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.image_height).EndInit();
		((System.ComponentModel.ISupportInitialize)this.image_width).EndInit();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.openmenu.ResumeLayout(false);
		this.GroupBox5.ResumeLayout(false);
		this.TableLayoutPanel2.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void Apply_Button_Click(object sender, EventArgs e)
	{
		_Closure_0024__28 closure_0024__ = new _Closure_0024__28();
		closure_0024__._0024VB_0024Local_str = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(bomsettinglist.SelectedItem)))
		{
			closure_0024__._0024VB_0024Local_str = bomsettinglist.SelectedItem.ToString();
		}
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) != 0)
		{
			int num = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__63);
			if (num >= 0)
			{
				CConfigMng.Config.bomsettings[num] = createbomsetting(closure_0024__._0024VB_0024Local_str);
				CConfigMng.SaveConfig();
			}
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		_Closure_0024__29 closure_0024__ = new _Closure_0024__29();
		closure_0024__._0024VB_0024Local_str = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(bomsettinglist.SelectedItem)))
		{
			closure_0024__._0024VB_0024Local_str = bomsettinglist.SelectedItem.ToString();
		}
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) != 0)
		{
			int num = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__64);
			if (num >= 0)
			{
				CConfigMng.Config.bomsettings[num] = createbomsetting(closure_0024__._0024VB_0024Local_str);
			}
		}
		CConfigMng.SaveConfig();
		Close();
	}

	private void Frmexportbom_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			if (Conversions.ToDouble(MyProject.Forms.Frmmain._ExportBom.Keytip) == 1.0)
			{
				MyProject.Forms.Frmmain._ExportBom_ItemsSourceReady(null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Frmexportbom_Load(object sender, EventArgs e)
	{
		lookbompath();
		if (ComboBox1.Items.Count > 0)
		{
			ComboBox1.SelectedIndex = 0;
		}
		else
		{
			ComboBox1.SelectedIndex = -1;
		}
		List<string> list = CConfigMng.Config.bomsettings.Select(_Lambda_0024__65).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
		bomsettinglist.Items.Clear();
		checked
		{
			int num = list.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					bomsettinglist.Items.Add(list[num2]);
					if (num2 == 0)
					{
						bomsettinglist.SetSelected(num2, value: true);
					}
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void Frmexportbom_Activated(object sender, EventArgs e)
	{
		RuleList.Items.Clear();
		checked
		{
			int num = CConfigMng.Config.FilterRulesList.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					string name = CConfigMng.Config.FilterRulesList[num2].name;
					if (!RuleList.Items.Contains(name))
					{
						RuleList.Items.Add(name, isChecked: false);
					}
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void ComboBox1_DropDown(object sender, EventArgs e)
	{
		lookbompath();
	}

	public void lookbompath()
	{
		checked
		{
			try
			{
				string bompath = CConfigMng.Config.bompath;
				string pattern = "*.xls|*.xlsx";
				List<string> list = new List<string>();
				if (!Directory.Exists(bompath))
				{
					bompath = Application.StartupPath + "\\";
					code.SearchFiles(list, bompath, pattern);
				}
				else
				{
					code.SearchFiles(list, bompath, pattern, code.Cbool1(Conversions.ToString(CConfigMng.Config.bomsubfolder)));
				}
				if (Information.IsNothing(list))
				{
					return;
				}
				list = list.Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
				ComboBox1.Items.Clear();
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						ComboBox1.Items.Add(list[num2]);
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
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
			}
		}
	}

	public bomsetting createbomsetting(string str)
	{
		bomsetting bomsetting2 = new bomsetting();
		bomsetting2.name = str;
		bomsetting2.bomname = ComboBox1.Text;
		bomsetting2.lockratio = lockratio.Checked;
		bomsetting2.insertimagebool = insertimagebool.Checked;
		if (RadioButton1.Checked)
		{
			bomsetting2.type = 0;
		}
		else if (RadioButton2.Checked)
		{
			bomsetting2.type = 1;
		}
		else if (RadioButton3.Checked)
		{
			bomsetting2.type = 2;
		}
		else if (RadioButton4.Checked)
		{
			bomsetting2.type = 3;
		}
		bomsetting2.includetop = includetop.Checked;
		bomsetting2.marknodrw = marknodrw.Checked;
		bomsetting2.Propertyvalue = Propertyvalue.Checked;
		bomsetting2.image_height = Convert.ToInt32(image_height.Value);
		bomsetting2.image_width = Convert.ToInt32(image_width.Value);
		bomsetting2.autocolumnwidth = autocolumnwidth.Checked;
		bomsetting2.ByFilter = ByFilter.Checked;
		bomsetting2.ByRuler = ByRuler.Checked;
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
						bomsetting2.RulesList.Add(RuleList.Items[num2].ToString());
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
			return bomsetting2;
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		if (!MyProject.Forms.FrmFilterrules.Visible)
		{
			MyProject.Forms.FrmFilterrules.Show(this);
		}
	}

	private void bomsettinglist_SelectedIndexChanged(object sender, EventArgs e)
	{
		_Closure_0024__30 closure_0024__ = new _Closure_0024__30();
		closure_0024__._0024VB_0024Local_str = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(bomsettinglist.SelectedItem)))
		{
			closure_0024__._0024VB_0024Local_str = bomsettinglist.SelectedItem.ToString();
		}
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		int num = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__66);
		if (num < 0)
		{
			return;
		}
		bomsetting bomsetting2 = CConfigMng.Config.bomsettings[num];
		ComboBox1.Text = bomsetting2.bomname;
		lockratio.Checked = bomsetting2.lockratio;
		insertimagebool.Checked = bomsetting2.insertimagebool;
		if (bomsetting2.type == 0)
		{
			RadioButton1.Checked = true;
			RadioButton2.Checked = false;
			RadioButton3.Checked = false;
			RadioButton4.Checked = false;
		}
		else if (bomsetting2.type == 1)
		{
			RadioButton1.Checked = false;
			RadioButton2.Checked = true;
			RadioButton3.Checked = false;
			RadioButton4.Checked = false;
		}
		else if (bomsetting2.type == 2)
		{
			RadioButton1.Checked = false;
			RadioButton2.Checked = false;
			RadioButton3.Checked = true;
			RadioButton4.Checked = false;
		}
		else if (bomsetting2.type == 3)
		{
			RadioButton1.Checked = false;
			RadioButton2.Checked = false;
			RadioButton3.Checked = false;
			RadioButton4.Checked = true;
		}
		marknodrw.Checked = bomsetting2.marknodrw;
		Propertyvalue.Checked = bomsetting2.Propertyvalue;
		Propertylink.Checked = !bomsetting2.Propertyvalue;
		image_height.Value = new decimal(bomsetting2.image_height);
		image_width.Value = new decimal(bomsetting2.image_width);
		autocolumnwidth.Checked = bomsetting2.autocolumnwidth;
		ByFilter.Checked = bomsetting2.ByFilter;
		ByRuler.Checked = bomsetting2.ByRuler;
		includetop.Checked = bomsetting2.includetop;
		checked
		{
			int num2 = RuleList.Items.Count - 1;
			int num3 = 0;
			_Closure_0024__30._Closure_0024__31 closure_0024__2 = default(_Closure_0024__30._Closure_0024__31);
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 <= num5)
				{
					closure_0024__2 = new _Closure_0024__30._Closure_0024__31(closure_0024__2);
					closure_0024__2._0024VB_0024Local_name = Conversions.ToString(RuleList.Items[num3]);
					int num6 = bomsetting2.RulesList.FindIndex(closure_0024__2._Lambda_0024__67);
					if (num6 >= 0)
					{
						RuleList.SetItemChecked(num3, value: true);
					}
					else
					{
						RuleList.SetItemChecked(num3, value: false);
					}
					num3++;
					continue;
				}
				break;
			}
		}
	}

	private void add_Click(object sender, EventArgs e)
	{
		_Closure_0024__32 closure_0024__ = new _Closure_0024__32();
		closure_0024__._0024VB_0024Local_str = Interaction.InputBox("Введите имя схемы");
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		int num = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__68);
		if (num >= 0)
		{
			MessageBox.Show(this, "Имя «" + closure_0024__._0024VB_0024Local_str + "» уже существует, выберите другое имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		bomsettinglist.Items.Add(closure_0024__._0024VB_0024Local_str);
		CConfigMng.Config.bomsettings.Add(createbomsetting(closure_0024__._0024VB_0024Local_str));
		CConfigMng.SaveConfig();
		try
		{
			bomsettinglist.ClearSelected();
			bomsettinglist.SetSelected(checked(bomsettinglist.Items.Count - 1), value: true);
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
		_Closure_0024__33 closure_0024__ = new _Closure_0024__33();
		if (bomsettinglist.SelectedItems.Count < 1)
		{
			return;
		}
		if (bomsettinglist.SelectedItems.Count > 1)
		{
			MessageBox.Show(this, "Можно выбрать только один элемент", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		closure_0024__._0024VB_0024Local_RuleName = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(bomsettinglist.SelectedItem)))
		{
			closure_0024__._0024VB_0024Local_RuleName = bomsettinglist.SelectedItem.ToString();
		}
		int num = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__69);
		if (num < 0)
		{
			return;
		}
		closure_0024__._0024VB_0024Local_str = Interaction.InputBox("Введите имя правила", "", closure_0024__._0024VB_0024Local_RuleName);
		if (Operators.CompareString(closure_0024__._0024VB_0024Local_str.Trim(), "", TextCompare: false) != 0 && Operators.CompareString(closure_0024__._0024VB_0024Local_str, closure_0024__._0024VB_0024Local_RuleName, TextCompare: false) != 0 && 0 == 0)
		{
			int num2 = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__70);
			if (num2 < 0)
			{
				bomsetting bomsetting2 = CConfigMng.Config.bomsettings[num];
				bomsetting2.name = closure_0024__._0024VB_0024Local_str;
				CConfigMng.Config.bomsettings[num] = bomsetting2;
				bomsettinglist.Items[bomsettinglist.SelectedIndex] = closure_0024__._0024VB_0024Local_str;
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
			int num = bomsettinglist.SelectedItems.Count - 1;
			_Closure_0024__34 closure_0024__ = default(_Closure_0024__34);
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 >= num3)
				{
					closure_0024__ = new _Closure_0024__34(closure_0024__);
					closure_0024__._0024VB_0024Local_RuleName = Conversions.ToString(bomsettinglist.SelectedItems[num]);
					int num4 = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__71);
					if (num4 >= 0)
					{
						CConfigMng.Config.bomsettings.RemoveAt(num4);
						bomsettinglist.Items.Remove(closure_0024__._0024VB_0024Local_RuleName);
					}
					num += -1;
					continue;
				}
				break;
			}
		}
	}

	private void image_width_ValueChanged(object sender, EventArgs e)
	{
		if (lockratio.Checked)
		{
			image_height.Value = decimal.Divide(decimal.Multiply(image_width.Value, 3m), 4m);
		}
	}

	private void image_height_ValueChanged(object sender, EventArgs e)
	{
		if (lockratio.Checked)
		{
			image_width.Value = decimal.Divide(decimal.Multiply(image_height.Value, 4m), 3m);
		}
	}

	private void RadioButton2_CheckedChanged(object sender, EventArgs e)
	{
		RadioButton radioButton = (RadioButton)sender;
		if (radioButton.Checked)
		{
			ByRuler.Visible = false;
			ByFilter.Visible = false;
			ByRuler.Enabled = false;
			ByFilter.Enabled = false;
			GroupBox2.Visible = false;
		}
	}

	private void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
		RadioButton radioButton = (RadioButton)sender;
		if (radioButton.Checked)
		{
			ByRuler.Visible = true;
			ByFilter.Visible = true;
			ByRuler.Enabled = true;
			ByFilter.Enabled = true;
			GroupBox2.Visible = true;
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
		openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Шаблон спецификации");
		openFileDialog.Filter = "Файл шаблона спецификации (*.xls;*.xlsx)|*.xls;*.xlsx";
		if (openFileDialog.ShowDialog() != DialogResult.Cancel)
		{
			ComboBox1.Text = openFileDialog.FileName;
		}
	}

	private void open_excel_Click(object sender, EventArgs e)
	{
		if (File.Exists(ComboBox1.Text))
		{
			Process.Start(ComboBox1.Text);
		}
		else
		{
			MessageBox.Show(" файл не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void open_folder_Click(object sender, EventArgs e)
	{
		if (Directory.Exists(code.SplitStr(ComboBox1.Text)))
		{
			code.OpenFolderWithEX(code.SplitStr(ComboBox1.Text));
		}
		else
		{
			MessageBox.Show(" путь не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (File.Exists(code.helpfile))
			{
				Help.ShowHelp(this, code.helpfile, "/进阶操作/BOM表模板制作和导出.htm");
			}
			else
			{
				MessageBox.Show("Файл help.chm не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show("Ошибка при открытии файла справки:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private static string _Lambda_0024__65(bomsetting s)
	{
		return s.name;
	}
}
