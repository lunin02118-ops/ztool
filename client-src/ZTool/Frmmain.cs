using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using AdvancedDataGridView;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using RibbonLib;
using RibbonLib.Controls;
using RibbonLib.Controls.Events;
using RibbonLib.Interop;
using ZTool.JDK;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class Frmmain : Form
{
	public struct obj_copy
	{
		public string drwname;

		public string modelname;
	}

	[CompilerGenerated]
	internal class _Closure_0024__39
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__39(_Closure_0024__39 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__39()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__83(string s)
		{
			return s.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__40
	{
		public string _0024VB_0024Local_label;

		[DebuggerNonUserCode]
		public _Closure_0024__40(_Closure_0024__40 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_label = other._0024VB_0024Local_label;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__40()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__84(string s)
		{
			return s.Equals(_0024VB_0024Local_label, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__41
	{
		public RibbonButton _0024VB_0024Local_rcb;

		[DebuggerNonUserCode]
		public _Closure_0024__41()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__41(_Closure_0024__41 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_rcb = other._0024VB_0024Local_rcb;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__85(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_rcb.Label, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__42
	{
		public string _0024VB_0024Local_Str;

		[DebuggerNonUserCode]
		public _Closure_0024__42()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__42(_Closure_0024__42 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_Str = other._0024VB_0024Local_Str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__86(Treenode s)
		{
			return _0024VB_0024Local_Str.Equals(s.PathName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__43
	{
		public string _0024VB_0024Local_Str;

		[DebuggerNonUserCode]
		public _Closure_0024__43()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__43(_Closure_0024__43 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_Str = other._0024VB_0024Local_Str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__87(Treenode s)
		{
			return _0024VB_0024Local_Str.Equals(s.PathName + "\n" + s.ConfigureName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__44
	{
		public string _0024VB_0024Local_val;

		[DebuggerNonUserCode]
		public _Closure_0024__44(_Closure_0024__44 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_val = other._0024VB_0024Local_val;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__44()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__92(string s)
		{
			return s.Equals(_0024VB_0024Local_val, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__45
	{
		public string _0024VB_0024Local_val;

		[DebuggerNonUserCode]
		public _Closure_0024__45(_Closure_0024__45 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_val = other._0024VB_0024Local_val;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__45()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__93(string s)
		{
			return s.Equals(_0024VB_0024Local_val, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__46
	{
		public string _0024VB_0024Local_val;

		[DebuggerNonUserCode]
		public _Closure_0024__46(_Closure_0024__46 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_val = other._0024VB_0024Local_val;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__46()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__94(string s)
		{
			return s.Equals(_0024VB_0024Local_val, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__47
	{
		public string _0024VB_0024Local_val;

		[DebuggerNonUserCode]
		public _Closure_0024__47()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__47(_Closure_0024__47 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_val = other._0024VB_0024Local_val;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__95(string s)
		{
			return s.Equals(_0024VB_0024Local_val, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__48
	{
		public string _0024VB_0024Local_result;

		[DebuggerNonUserCode]
		public _Closure_0024__48()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__48(_Closure_0024__48 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_result = other._0024VB_0024Local_result;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__96(string s)
		{
			return s.Equals(_0024VB_0024Local_result, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__49
	{
		public string _0024VB_0024Local_result;

		[DebuggerNonUserCode]
		public _Closure_0024__49()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__49(_Closure_0024__49 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_result = other._0024VB_0024Local_result;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__97(string s)
		{
			return s.Equals(_0024VB_0024Local_result, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__50
	{
		public int _0024VB_0024Local_findstr;

		[DebuggerNonUserCode]
		public _Closure_0024__50(_Closure_0024__50 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_findstr = other._0024VB_0024Local_findstr;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__50()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__99(ColumnInfo s)
		{
			return s.DisplayIndex == _0024VB_0024Local_findstr;
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__51
	{
		public string[] _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__51()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__51(_Closure_0024__51 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__103(string s)
		{
			return _0024VB_0024Local_str.ToList().IndexOf(s) > 3;
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__52
	{
		public string _0024VB_0024Local_val;

		public Frmmain _0024VB_0024Me;

		[DebuggerNonUserCode]
		public _Closure_0024__52(_Closure_0024__52 other)
		{
			if (other != null)
			{
				_0024VB_0024Me = other._0024VB_0024Me;
				_0024VB_0024Local_val = other._0024VB_0024Local_val;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__52()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__106(DataGridViewRow r)
		{
			return Convert.ToString(RuntimeHelpers.GetObjectValue(r.Cells[_0024VB_0024Me.Col_Number.Index].Value)).Equals(_0024VB_0024Local_val, StringComparison.CurrentCultureIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__53
	{
		[CompilerGenerated]
		internal class _Closure_0024__54
		{
			public string _0024VB_0024Local_colname;

			public _Closure_0024__53 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A36_2F;

			[DebuggerNonUserCode]
			public _Closure_0024__54()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__54(_Closure_0024__54 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_colname = other._0024VB_0024Local_colname;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__107(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A36_2F._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__108(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A36_2F._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name2.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}
		}

		public string _0024VB_0024Local_coltitle;

		[DebuggerNonUserCode]
		public _Closure_0024__53()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__53(_Closure_0024__53 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_coltitle = other._0024VB_0024Local_coltitle;
			}
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__55
	{
		[CompilerGenerated]
		internal class _Closure_0024__56
		{
			public List<string> _0024VB_0024Local_arr;

			[DebuggerNonUserCode]
			public _Closure_0024__56()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__56(_Closure_0024__56 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_arr = other._0024VB_0024Local_arr;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public int _Lambda_0024__109(Treenode s)
			{
				return _0024VB_0024Local_arr.IndexOf(s.PathName);
			}
		}

		[CompilerGenerated]
		internal class _Closure_0024__57
		{
			public string _0024VB_0024Local_colname;

			public _Closure_0024__55 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1AE0_4E;

			[DebuggerNonUserCode]
			public _Closure_0024__57()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__57(_Closure_0024__57 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_colname = other._0024VB_0024Local_colname;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__110(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1AE0_4E._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__111(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1AE0_4E._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name2.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}
		}

		public string _0024VB_0024Local_coltitle;

		[DebuggerNonUserCode]
		public _Closure_0024__55()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__55(_Closure_0024__55 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_coltitle = other._0024VB_0024Local_coltitle;
			}
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__58
	{
		[CompilerGenerated]
		internal class _Closure_0024__59
		{
			public string _0024VB_0024Local_colname;

			public _Closure_0024__58 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1BB6_2F;

			[DebuggerNonUserCode]
			public _Closure_0024__59()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__59(_Closure_0024__59 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_colname = other._0024VB_0024Local_colname;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__112(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1BB6_2F._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__113(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1BB6_2F._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name2.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}
		}

		public string _0024VB_0024Local_coltitle;

		[DebuggerNonUserCode]
		public _Closure_0024__58()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__58(_Closure_0024__58 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_coltitle = other._0024VB_0024Local_coltitle;
			}
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__60
	{
		[CompilerGenerated]
		internal class _Closure_0024__61
		{
			public List<string> _0024VB_0024Local_arr;

			[DebuggerNonUserCode]
			public _Closure_0024__61()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__61(_Closure_0024__61 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_arr = other._0024VB_0024Local_arr;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public int _Lambda_0024__114(Treenode s)
			{
				return _0024VB_0024Local_arr.IndexOf(s.PathName);
			}
		}

		[CompilerGenerated]
		internal class _Closure_0024__62
		{
			public string _0024VB_0024Local_colname;

			public _Closure_0024__60 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1C9C_4E;

			[DebuggerNonUserCode]
			public _Closure_0024__62()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__62(_Closure_0024__62 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_colname = other._0024VB_0024Local_colname;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__115(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1C9C_4E._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}

			[SpecialName]
			[CompilerGenerated]
			public bool _Lambda_0024__116(columnnamemapping s)
			{
				return (s.text.Equals(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1C9C_4E._0024VB_0024Local_coltitle, StringComparison.OrdinalIgnoreCase) && s.name2.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase)) ? true : false;
			}
		}

		public string _0024VB_0024Local_coltitle;

		[DebuggerNonUserCode]
		public _Closure_0024__60()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__60(_Closure_0024__60 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_coltitle = other._0024VB_0024Local_coltitle;
			}
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__63
	{
		public List<string> _0024VB_0024Local_arr;

		[DebuggerNonUserCode]
		public _Closure_0024__63()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__63(_Closure_0024__63 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_arr = other._0024VB_0024Local_arr;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public int _Lambda_0024__117(Treenode s)
		{
			return _0024VB_0024Local_arr.IndexOf(s.PathName);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__64
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__64(_Closure_0024__64 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__64()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__118(Treenode s)
		{
			return s.realpath.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("DGV1")]
	private DataGridViewEX _DGV1;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	[AccessedThroughProperty("Timer1")]
	private System.Windows.Forms.Timer _Timer1;

	[AccessedThroughProperty("_Ribbon")]
	private Ribbon __Ribbon;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("StatusLabel1")]
	private ToolStripStatusLabel _StatusLabel1;

	[AccessedThroughProperty("StatusLabel2")]
	private ToolStripStatusLabel _StatusLabel2;

	[AccessedThroughProperty("ToolStripProgressBar1")]
	private ToolStripProgressBar _ToolStripProgressBar1;

	[AccessedThroughProperty("PropSwitchLabel")]
	private ToolStripStatusLabel _PropSwitchLabel;

	[AccessedThroughProperty("TV1")]
	private MultiSelectTreeView _TV1;

	[AccessedThroughProperty("treecmsp1")]
	private ContextMenuStrip _treecmsp1;

	[AccessedThroughProperty("tree_ExpandAll")]
	private ToolStripMenuItem _tree_ExpandAll;

	[AccessedThroughProperty("tree_CollapseAll")]
	private ToolStripMenuItem _tree_CollapseAll;

	[AccessedThroughProperty("SplitContainerEx1")]
	private SplitContainerEx _SplitContainerEx1;

	[AccessedThroughProperty("tree_openinsw")]
	private ToolStripMenuItem _tree_openinsw;

	[AccessedThroughProperty("tree_showselnode1")]
	private ToolStripMenuItem _tree_showselnode1;

	[AccessedThroughProperty("tree_showselnode2")]
	private ToolStripMenuItem _tree_showselnode2;

	[AccessedThroughProperty("tree_selectinsw")]
	private ToolStripMenuItem _tree_selectinsw;

	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator _ToolStripSeparator1;

	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator _ToolStripSeparator2;

	[AccessedThroughProperty("tree_suppress")]
	private ToolStripMenuItem _tree_suppress;

	[AccessedThroughProperty("tree_unsuppress")]
	private ToolStripMenuItem _tree_unsuppress;

	[AccessedThroughProperty("tree_excludebom")]
	private ToolStripMenuItem _tree_excludebom;

	[AccessedThroughProperty("tree_unexcludebom")]
	private ToolStripMenuItem _tree_unexcludebom;

	[AccessedThroughProperty("ToolStripSeparator4")]
	private ToolStripSeparator _ToolStripSeparator4;

	[AccessedThroughProperty("tree_DisplayInBOM")]
	private ToolStripMenuItem _tree_DisplayInBOM;

	[AccessedThroughProperty("tree_DisplayInBOM_show")]
	private ToolStripMenuItem _tree_DisplayInBOM_show;

	[AccessedThroughProperty("tree_DisplayInBOM_hide")]
	private ToolStripMenuItem _tree_DisplayInBOM_hide;

	[AccessedThroughProperty("tree_DisplayInBOM_Promote")]
	private ToolStripMenuItem _tree_DisplayInBOM_Promote;

	[AccessedThroughProperty("Column1")]
	private TreeGridColumn _Column1;

	[AccessedThroughProperty("Column2")]
	private DataGridViewTextBoxColumn _Column2;

	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn1;

	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn2;

	[AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn3;

	[AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn4;

	[AccessedThroughProperty("DataGridViewTextBoxColumn5")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn5;

	[AccessedThroughProperty("DataGridViewTextBoxColumn6")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn6;

	[AccessedThroughProperty("DataGridViewTextBoxColumn7")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn7;

	[AccessedThroughProperty("DataGridViewTextBoxColumn8")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn8;

	[AccessedThroughProperty("DataGridViewTextBoxColumn9")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn9;

	[AccessedThroughProperty("DataGridViewTextBoxColumn10")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn10;

	[AccessedThroughProperty("DataGridViewTextBoxColumn11")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn11;

	[AccessedThroughProperty("DataGridViewTextBoxColumn12")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn12;

	[AccessedThroughProperty("DataGridViewTextBoxColumn13")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn13;

	[AccessedThroughProperty("DataGridViewTextBoxColumn14")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn14;

	[AccessedThroughProperty("DataGridViewTextBoxColumn15")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn15;

	[AccessedThroughProperty("DataGridViewTextBoxColumn16")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn16;

	[AccessedThroughProperty("DataGridViewTextBoxColumn17")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn17;

	[AccessedThroughProperty("Levelbom")]
	private ToolStripMenuItem _Levelbom;

	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator _ToolStripSeparator3;

	[AccessedThroughProperty("tree_hideselnode1")]
	private ToolStripMenuItem _tree_hideselnode1;

	[AccessedThroughProperty("tree_hideselnode2")]
	private ToolStripMenuItem _tree_hideselnode2;

	[AccessedThroughProperty("Col_Preview")]
	private DataGridViewImageColumn _Col_Preview;

	[AccessedThroughProperty("Col_Checkbox")]
	private DataGridViewCheckBoxColumn _Col_Checkbox;

	[AccessedThroughProperty("Col_Extname")]
	private DataGridViewImageColumn _Col_Extname;

	[AccessedThroughProperty("Col_Drw")]
	private DataGridViewImageColumn _Col_Drw;

	[AccessedThroughProperty("Col_Number")]
	private DataGridViewTextBoxColumn _Col_Number;

	[AccessedThroughProperty("Col_FileName")]
	private DataGridViewTextBoxColumn _Col_FileName;

	[AccessedThroughProperty("Col_NewFolder")]
	private DataGridViewTextBoxColumn _Col_NewFolder;

	[AccessedThroughProperty("Col_Material")]
	private DataGridViewTextBoxColumn _Col_Material;

	[AccessedThroughProperty("Col_partnumber")]
	private DataGridViewTextBoxColumn _Col_partnumber;

	[AccessedThroughProperty("Col_Quantity")]
	private DataGridViewTextBoxColumn _Col_Quantity;

	[AccessedThroughProperty("Col_Path")]
	private DataGridViewTextBoxColumn _Col_Path;

	[AccessedThroughProperty("Col_Cfg")]
	private DataGridViewTextBoxColumn _Col_Cfg;

	[AccessedThroughProperty("Col_Weight")]
	private DataGridViewTextBoxColumn _Col_Weight;

	[AccessedThroughProperty("Col_bound")]
	private DataGridViewTextBoxColumn _Col_bound;

	[AccessedThroughProperty("Col_Level")]
	private DataGridViewTextBoxColumn _Col_Level;

	[AccessedThroughProperty("Col_CreationTime")]
	private DataGridViewTextBoxColumn _Col_CreationTime;

	[AccessedThroughProperty("Col_SaveTime")]
	private DataGridViewTextBoxColumn _Col_SaveTime;

	[AccessedThroughProperty("Col_Author")]
	private DataGridViewTextBoxColumn _Col_Author;

	[AccessedThroughProperty("Col_Keywords")]
	private DataGridViewTextBoxColumn _Col_Keywords;

	[AccessedThroughProperty("Col_Comment")]
	private DataGridViewTextBoxColumn _Col_Comment;

	[AccessedThroughProperty("Col_Title")]
	private DataGridViewTextBoxColumn _Col_Title;

	[AccessedThroughProperty("Col_Subject")]
	private DataGridViewTextBoxColumn _Col_Subject;

	[AccessedThroughProperty("tree_showselnode3")]
	private ToolStripMenuItem _tree_showselnode3;

	private int SelectedCol;

	private string oldcellval;

	private Color oldcellcolor;

	public List<string>[] FilterCollist;

	public List<int> HideCollist;

	public List<int> isolatedlist;

	private List<bool> FilterColReverse;

	[AccessedThroughProperty("Filter_list")]
	private ContextMenuStrip _Filter_list;

	[AccessedThroughProperty("Material_list")]
	private ContextMenuStrip _Material_list;

	[AccessedThroughProperty("CfgRename_list")]
	private ContextMenuStrip _CfgRename_list;

	[AccessedThroughProperty("Prop_Downlist")]
	private ContextMenuStrip _Prop_Downlist;

	[AccessedThroughProperty("DGV_Menulist")]
	private ContextMenuStrip _DGV_Menulist;

	[AccessedThroughProperty("write_list")]
	private ContextMenuStrip _write_list;

	[AccessedThroughProperty("PropSwitch")]
	private ToolStripButton _PropSwitch;

	[AccessedThroughProperty("AutoColumnsMode")]
	private ToolStripButton _AutoColumnsMode;

	[AccessedThroughProperty("HighLightRow")]
	private ToolStripButton _HighLightRow;

	[AccessedThroughProperty("PreviewSwitch1")]
	private ToolStripButton _PreviewSwitch1;

	[AccessedThroughProperty("partnumbersetting")]
	private ContextMenuStrip _partnumbersetting;

	private RibbonButton LastCustomFilterButton;

	private int selcount;

	private ToolStripSeparator sep;

	[AccessedThroughProperty("ComboBox1")]
	private CustomComboBox1 _ComboBox1;

	[AccessedThroughProperty("IsStop")]
	private ToolStripButton _IsStop;

	internal int sel_row;

	internal int sel_col;

	internal int preview_selrow;

	private string filename_inselitem;

	private string cfgname_inselitem;

	private int Preview_HotKey;

	private bool EnableDGVChangeEvent;

	private bool isloaded;

	internal int GetDataOption;

	private obj_copy obj_drw_copy;

	private checklic chl;

	private double dpixRatio;

	private List<int> rlist;

	private string openid;

	private RibbonButton _ConnectSW;

	internal RibbonSplitButtonGallery _SaveToSW;

	private RibbonCheckBox _mergecfg;

	private RibbonCheckBox _breakcfg;

	private RibbonCheckBox _Excludevirtual;

	private RibbonCheckBox _ExcludeLight;

	private RibbonCheckBox _GetByBom;

	private RibbonCheckBox _GetByVisible;

	private RibbonCheckBox _GetAll;

	private RibbonCheckBox _GetSelect;

	private RibbonCheckBox _GetFromFile;

	private RibbonButton _cmdButtonOptions;

	private RibbonButton _cmdButtonAboutMe;

	private RibbonButton _cmdButtonregister;

	private RibbonButton _cmdButtonExit;

	private RibbonButton _cmdButtonUnit;

	private RibbonButton _cmdButtonFilter;

	private RibbonButton _cmdButtonPropertyName;

	private RibbonButton _cmdButtonRename;

	internal RibbonSplitButtonGallery _ExportBom;

	private RibbonButton _BomOptions;

	private RibbonButton _BatchPrint;

	private RibbonButton _BatchExport;

	private RibbonButton _BatchReplace;

	private RibbonButton _BatchReplaceParts;

	private RibbonButton _SyncDrwName;

	private RibbonButton _cmdButtonLook;

	private RibbonButton _cmdButtonPrefix;

	private RibbonButton _cmdButtonSymbol;

	private RibbonButton _cmdButtonCopycol;

	private RibbonButton _cmdButtonFillcol;

	private RibbonButton _cmdButtonComparecol;

	private RibbonSpinner _cmdRowHeigh;

	internal RibbonDropDownGallery _cmdButtonHidecol;

	internal RibbonDropDownGallery _cmdButtonFreezecol;

	internal RibbonDropDownGallery _fastfilter;

	private RibbonCheckBox _Encheckbox;

	private RibbonButton _Selectrow;

	private RibbonButton _Readonlyitem;

	private RibbonButton _Modifieditem;

	private RibbonButton _Faileditem;

	private RibbonToggleButton _Ruletype;

	private RibbonButton _SplitColumn;

	private RibbonCheckBox _exportbyfilter;

	private RibbonCheckBox _exportbyrule;

	private RibbonSpinner _Quantityratio;

	private RibbonButton _ImportConfig;

	private RibbonButton _BackupConfig;

	private RibbonDropDownButton _CloseSwDoc;

	private RibbonButton _CloseSwDoc_Filter;

	private RibbonButton _CloseSwDoc_Sel;

	private RibbonButton _CloseSwDoc_All;

	private RibbonButton _CloseSwDoc_Allopen;

	private RibbonButton _checkupdate;

	private RibbonHelpButton _helpbutton;

	private RibbonButton _regist;

	private RibbonButton _copyswfile;

	private RibbonButton _help;

	private RibbonButton _namemapping;

	private RibbonButton _virtualitem;

	private RibbonToggleButton _useexcel;

	private RibbonToggleButton _usenpoi;

	private RibbonToggleButton _customsort;

	private RibbonToggleButton _exchangecolumn;

	private RibbonButton _mergepdf;

	private RibbonButton _IsBendState;

	private RibbonButton _IsWeldment;

	internal RibbonDropDownGallery _Markrepeat;

	private RibbonButton _ExcludeBom;

	internal RibbonCheckBox[] buttons1;

	internal RibbonCheckBox[] buttons2;

	internal RibbonCheckBox[] buttons3;

	internal RibbonButton[] buttons4;

	internal RibbonCheckBox[] buttons5;

	internal RibbonButton[] buttons6;

	internal RibbonCheckBox[] buttons7;

	private ToolTip tt;

	private bool previewing;

	private int R_row;

	private ToolStripControlHost usecolor;

	private Dictionary<string, Color> mlist;

	private ColorDialog ColorDialog;

	private TextBox newcfgname;

	private DataGridView dgv2;

	private ProgressBar progb;

	private TextBox partnumber_intable;

	private ComboBox partnumber_option;

	private code.BOMPartData bd;

	private string Cachedata_BOMPart;

	private object lastcolor;

	private ToolStripCheckedListBox Clb;

	private ToolStripControlHost tst;

	private int k1;

	internal string Cachedata_bom;

	internal string Cachedata_Feature;

	internal string Cachedata_pre;

	internal string Cachedata_Material;

	[AccessedThroughProperty("GetAsmBgWorker")]
	private BackgroundWorker _GetAsmBgWorker;

	[AccessedThroughProperty("SaveToSWBgWorker")]
	private BackgroundWorker _SaveToSWBgWorker;

	internal List<int> Rowlist_Savefailed;

	private Dictionary<int, int> myindexd;

	internal virtual ToolStripButton ToolStripButton1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripButton1 = value;
		}
	}

	internal virtual DataGridViewEX DGV1
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
			DataGridViewCellMouseEventHandler value2 = DGV1_CellMouseDoubleClick;
			DataGridViewCellMouseEventHandler value3 = DGV1_CellMouseDown;
			DataGridViewEditingControlShowingEventHandler value4 = DGV1_EditingControlShowing;
			PaintEventHandler value5 = DGV1_Paint;
			DataGridViewRowPostPaintEventHandler value6 = DGV1_RowPostPaint;
			DataGridViewCellMouseEventHandler value7 = DGV1_ColumnHeaderMouseClick;
			DataGridViewCellEventHandler value8 = DGV1_CellEnter;
			EventHandler value9 = DGV1_SelectionChanged;
			MouseEventHandler value10 = DGV1_MouseUp;
			MouseEventHandler value11 = DGV1_MouseDown;
			DataGridViewCellEventHandler value12 = DGV1_CellClick;
			DataGridViewCellEventHandler value13 = DGV1_CellEndEdit;
			DataGridViewDataErrorEventHandler value14 = DGV1_DataError;
			DataGridViewCellEventHandler value15 = DGV1_CellValueChanged;
			DataGridViewCellCancelEventHandler value16 = DGV1_CellBeginEdit;
			if (_DGV1 != null)
			{
				_DGV1.CellMouseDoubleClick -= value2;
				_DGV1.CellMouseDown -= value3;
				_DGV1.EditingControlShowing -= value4;
				_DGV1.Paint -= value5;
				_DGV1.RowPostPaint -= value6;
				_DGV1.ColumnHeaderMouseClick -= value7;
				_DGV1.CellEnter -= value8;
				_DGV1.SelectionChanged -= value9;
				_DGV1.MouseUp -= value10;
				_DGV1.MouseDown -= value11;
				_DGV1.CellClick -= value12;
				_DGV1.CellEndEdit -= value13;
				_DGV1.DataError -= value14;
				_DGV1.CellValueChanged -= value15;
				_DGV1.CellBeginEdit -= value16;
			}
			_DGV1 = value;
			if (_DGV1 != null)
			{
				_DGV1.CellMouseDoubleClick += value2;
				_DGV1.CellMouseDown += value3;
				_DGV1.EditingControlShowing += value4;
				_DGV1.Paint += value5;
				_DGV1.RowPostPaint += value6;
				_DGV1.ColumnHeaderMouseClick += value7;
				_DGV1.CellEnter += value8;
				_DGV1.SelectionChanged += value9;
				_DGV1.MouseUp += value10;
				_DGV1.MouseDown += value11;
				_DGV1.CellClick += value12;
				_DGV1.CellEndEdit += value13;
				_DGV1.DataError += value14;
				_DGV1.CellValueChanged += value15;
				_DGV1.CellBeginEdit += value16;
			}
		}
	}

	internal virtual ImageList ImageList1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ImageList1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ImageList1 = value;
		}
	}

	internal virtual System.Windows.Forms.Timer Timer1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Timer1 = value;
		}
	}

	internal virtual Ribbon _Ribbon
	{
		[DebuggerNonUserCode]
		get
		{
			return __Ribbon;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			__Ribbon = value;
		}
	}

	internal virtual StatusStrip StatusStrip1
	{
		[DebuggerNonUserCode]
		get
		{
			return _StatusStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_StatusStrip1 = value;
		}
	}

	internal virtual ToolStripStatusLabel StatusLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _StatusLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			PaintEventHandler value2 = StatusLabel1_Paint;
			EventHandler value3 = StatusLabel1_Click;
			if (_StatusLabel1 != null)
			{
				_StatusLabel1.Paint -= value2;
				_StatusLabel1.Click -= value3;
			}
			_StatusLabel1 = value;
			if (_StatusLabel1 != null)
			{
				_StatusLabel1.Paint += value2;
				_StatusLabel1.Click += value3;
			}
		}
	}

	internal virtual ToolStripStatusLabel StatusLabel2
	{
		[DebuggerNonUserCode]
		get
		{
			return _StatusLabel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_StatusLabel2 = value;
		}
	}

	internal virtual ToolStripProgressBar ToolStripProgressBar1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripProgressBar1 = value;
		}
	}

	internal virtual ToolStripStatusLabel PropSwitchLabel
	{
		[DebuggerNonUserCode]
		get
		{
			return _PropSwitchLabel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PropSwitchLabel = value;
		}
	}

	internal virtual MultiSelectTreeView TV1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TV1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			TreeViewEventHandler value2 = TV1_AfterSelect;
			MouseEventHandler value3 = TreeView1_MouseDown;
			if (_TV1 != null)
			{
				_TV1.AfterSelect -= value2;
				_TV1.MouseDown -= value3;
			}
			_TV1 = value;
			if (_TV1 != null)
			{
				_TV1.AfterSelect += value2;
				_TV1.MouseDown += value3;
			}
		}
	}

	internal virtual ContextMenuStrip treecmsp1
	{
		[DebuggerNonUserCode]
		get
		{
			return _treecmsp1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			CancelEventHandler value2 = treecmsp1_Opening;
			if (_treecmsp1 != null)
			{
				_treecmsp1.Opening -= value2;
			}
			_treecmsp1 = value;
			if (_treecmsp1 != null)
			{
				_treecmsp1.Opening += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_ExpandAll
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_ExpandAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_ExpandAll_Click;
			if (_tree_ExpandAll != null)
			{
				_tree_ExpandAll.Click -= value2;
			}
			_tree_ExpandAll = value;
			if (_tree_ExpandAll != null)
			{
				_tree_ExpandAll.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_CollapseAll
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_CollapseAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_CollapseAll_Click;
			if (_tree_CollapseAll != null)
			{
				_tree_CollapseAll.Click -= value2;
			}
			_tree_CollapseAll = value;
			if (_tree_CollapseAll != null)
			{
				_tree_CollapseAll.Click += value2;
			}
		}
	}

	internal virtual SplitContainerEx SplitContainerEx1
	{
		[DebuggerNonUserCode]
		get
		{
			return _SplitContainerEx1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_SplitContainerEx1 = value;
		}
	}

	internal virtual ToolStripMenuItem tree_openinsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_openinsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_openinsw_Click;
			if (_tree_openinsw != null)
			{
				_tree_openinsw.Click -= value2;
			}
			_tree_openinsw = value;
			if (_tree_openinsw != null)
			{
				_tree_openinsw.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_showselnode1
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_showselnode1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_showselnode1_Click;
			if (_tree_showselnode1 != null)
			{
				_tree_showselnode1.Click -= value2;
			}
			_tree_showselnode1 = value;
			if (_tree_showselnode1 != null)
			{
				_tree_showselnode1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_showselnode2
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_showselnode2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_showselnode2_Click;
			if (_tree_showselnode2 != null)
			{
				_tree_showselnode2.Click -= value2;
			}
			_tree_showselnode2 = value;
			if (_tree_showselnode2 != null)
			{
				_tree_showselnode2.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_selectinsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_selectinsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_selectinsw_Click;
			if (_tree_selectinsw != null)
			{
				_tree_selectinsw.Click -= value2;
			}
			_tree_selectinsw = value;
			if (_tree_selectinsw != null)
			{
				_tree_selectinsw.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator1 = value;
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator2 = value;
		}
	}

	internal virtual ToolStripMenuItem tree_suppress
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_suppress;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_suppress_Click;
			if (_tree_suppress != null)
			{
				_tree_suppress.Click -= value2;
			}
			_tree_suppress = value;
			if (_tree_suppress != null)
			{
				_tree_suppress.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_unsuppress
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_unsuppress;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_suppress_Click;
			if (_tree_unsuppress != null)
			{
				_tree_unsuppress.Click -= value2;
			}
			_tree_unsuppress = value;
			if (_tree_unsuppress != null)
			{
				_tree_unsuppress.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_excludebom
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_excludebom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_suppress_Click;
			if (_tree_excludebom != null)
			{
				_tree_excludebom.Click -= value2;
			}
			_tree_excludebom = value;
			if (_tree_excludebom != null)
			{
				_tree_excludebom.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_unexcludebom
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_unexcludebom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_suppress_Click;
			if (_tree_unexcludebom != null)
			{
				_tree_unexcludebom.Click -= value2;
			}
			_tree_unexcludebom = value;
			if (_tree_unexcludebom != null)
			{
				_tree_unexcludebom.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator4
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator4 = value;
		}
	}

	internal virtual ToolStripMenuItem tree_DisplayInBOM
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_DisplayInBOM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = tree_DisplayInBOM_DropDownItemClicked;
			if (_tree_DisplayInBOM != null)
			{
				_tree_DisplayInBOM.DropDownItemClicked -= value2;
			}
			_tree_DisplayInBOM = value;
			if (_tree_DisplayInBOM != null)
			{
				_tree_DisplayInBOM.DropDownItemClicked += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_DisplayInBOM_show
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_DisplayInBOM_show;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_tree_DisplayInBOM_show = value;
		}
	}

	internal virtual ToolStripMenuItem tree_DisplayInBOM_hide
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_DisplayInBOM_hide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_tree_DisplayInBOM_hide = value;
		}
	}

	internal virtual ToolStripMenuItem tree_DisplayInBOM_Promote
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_DisplayInBOM_Promote;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_tree_DisplayInBOM_Promote = value;
		}
	}

	internal virtual TreeGridColumn Column1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Column1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Column1 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Column2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Column2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Column2 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn1 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn2 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn3 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn4 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn5
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn5 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn6
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn6 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn7
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn7 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn8
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn8 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn9
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn9 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn10
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn10 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn11
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn11 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn12
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn12 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn13
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn13 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn14
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn14 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn15
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn15 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn16
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn16 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn17
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn17 = value;
		}
	}

	internal virtual ToolStripMenuItem Levelbom
	{
		[DebuggerNonUserCode]
		get
		{
			return _Levelbom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Levelbom_Click;
			if (_Levelbom != null)
			{
				_Levelbom.Click -= value2;
			}
			_Levelbom = value;
			if (_Levelbom != null)
			{
				_Levelbom.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator3 = value;
		}
	}

	internal virtual ToolStripMenuItem tree_hideselnode1
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_hideselnode1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_hideselnode1_Click;
			if (_tree_hideselnode1 != null)
			{
				_tree_hideselnode1.Click -= value2;
			}
			_tree_hideselnode1 = value;
			if (_tree_hideselnode1 != null)
			{
				_tree_hideselnode1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tree_hideselnode2
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_hideselnode2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_hideselnode2_Click;
			if (_tree_hideselnode2 != null)
			{
				_tree_hideselnode2.Click -= value2;
			}
			_tree_hideselnode2 = value;
			if (_tree_hideselnode2 != null)
			{
				_tree_hideselnode2.Click += value2;
			}
		}
	}

	internal virtual DataGridViewImageColumn Col_Preview
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Preview;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Preview = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn Col_Checkbox
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Checkbox;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Checkbox = value;
		}
	}

	internal virtual DataGridViewImageColumn Col_Extname
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Extname;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Extname = value;
		}
	}

	internal virtual DataGridViewImageColumn Col_Drw
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Drw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Drw = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Number
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Number;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Number = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_FileName
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_FileName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_FileName = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_NewFolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_NewFolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_NewFolder = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Material
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Material;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Material = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_partnumber
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_partnumber;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_partnumber = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Quantity
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Quantity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Quantity = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Path
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Path;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Path = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Cfg
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Cfg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Cfg = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Weight
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Weight;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Weight = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_bound
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_bound;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_bound = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Level
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Level;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Level = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_CreationTime
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_CreationTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_CreationTime = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_SaveTime
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_SaveTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_SaveTime = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Author
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Author;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Author = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Keywords
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Keywords;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Keywords = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Comment
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Comment;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Comment = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Title
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Title;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Title = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Col_Subject
	{
		[DebuggerNonUserCode]
		get
		{
			return _Col_Subject;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Col_Subject = value;
		}
	}

	internal virtual ToolStripMenuItem tree_showselnode3
	{
		[DebuggerNonUserCode]
		get
		{
			return _tree_showselnode3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = tree_showselnode3_Click;
			if (_tree_showselnode3 != null)
			{
				_tree_showselnode3.Click -= value2;
			}
			_tree_showselnode3 = value;
			if (_tree_showselnode3 != null)
			{
				_tree_showselnode3.Click += value2;
			}
		}
	}

	public virtual ContextMenuStrip Filter_list
	{
		[DebuggerNonUserCode]
		get
		{
			return _Filter_list;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = Filter_list_ItemClicked1;
			if (_Filter_list != null)
			{
				_Filter_list.ItemClicked -= value2;
			}
			_Filter_list = value;
			if (_Filter_list != null)
			{
				_Filter_list.ItemClicked += value2;
			}
		}
	}

	public virtual ContextMenuStrip Material_list
	{
		[DebuggerNonUserCode]
		get
		{
			return _Material_list;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = Material_list_ItemClicked;
			if (_Material_list != null)
			{
				_Material_list.ItemClicked -= value2;
			}
			_Material_list = value;
			if (_Material_list != null)
			{
				_Material_list.ItemClicked += value2;
			}
		}
	}

	public virtual ContextMenuStrip CfgRename_list
	{
		[DebuggerNonUserCode]
		get
		{
			return _CfgRename_list;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CfgRename_list = value;
		}
	}

	public virtual ContextMenuStrip Prop_Downlist
	{
		[DebuggerNonUserCode]
		get
		{
			return _Prop_Downlist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = Prop_Downlist_ItemClicked;
			if (_Prop_Downlist != null)
			{
				_Prop_Downlist.ItemClicked -= value2;
			}
			_Prop_Downlist = value;
			if (_Prop_Downlist != null)
			{
				_Prop_Downlist.ItemClicked += value2;
			}
		}
	}

	public virtual ContextMenuStrip DGV_Menulist
	{
		[DebuggerNonUserCode]
		get
		{
			return _DGV_Menulist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = DGV_Menulist_ItemClicked;
			if (_DGV_Menulist != null)
			{
				_DGV_Menulist.ItemClicked -= value2;
			}
			_DGV_Menulist = value;
			if (_DGV_Menulist != null)
			{
				_DGV_Menulist.ItemClicked += value2;
			}
		}
	}

	public virtual ContextMenuStrip write_list
	{
		[DebuggerNonUserCode]
		get
		{
			return _write_list;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_write_list = value;
		}
	}

	internal virtual ToolStripButton PropSwitch
	{
		[DebuggerNonUserCode]
		get
		{
			return _PropSwitch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = PropSwitch_Click;
			if (_PropSwitch != null)
			{
				_PropSwitch.Click -= value2;
			}
			_PropSwitch = value;
			if (_PropSwitch != null)
			{
				_PropSwitch.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton AutoColumnsMode
	{
		[DebuggerNonUserCode]
		get
		{
			return _AutoColumnsMode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AutoColumnsMode_Click;
			if (_AutoColumnsMode != null)
			{
				_AutoColumnsMode.Click -= value2;
			}
			_AutoColumnsMode = value;
			if (_AutoColumnsMode != null)
			{
				_AutoColumnsMode.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton HighLightRow
	{
		[DebuggerNonUserCode]
		get
		{
			return _HighLightRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_HighLightRow = value;
		}
	}

	internal virtual ToolStripButton PreviewSwitch1
	{
		[DebuggerNonUserCode]
		get
		{
			return _PreviewSwitch1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = PreviewSwitch1_Click;
			if (_PreviewSwitch1 != null)
			{
				_PreviewSwitch1.Click -= value2;
			}
			_PreviewSwitch1 = value;
			if (_PreviewSwitch1 != null)
			{
				_PreviewSwitch1.Click += value2;
			}
		}
	}

	internal virtual ContextMenuStrip partnumbersetting
	{
		[DebuggerNonUserCode]
		get
		{
			return _partnumbersetting;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_partnumbersetting = value;
		}
	}

	private CustomComboBox1 ComboBox1
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
			MouseEventHandler value2 = ComboBox1_MouseClick;
			if (_ComboBox1 != null)
			{
				_ComboBox1.MouseClick -= value2;
			}
			_ComboBox1 = value;
			if (_ComboBox1 != null)
			{
				_ComboBox1.MouseClick += value2;
			}
		}
	}

	internal virtual ToolStripButton IsStop
	{
		[DebuggerNonUserCode]
		get
		{
			return _IsStop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = IsStop_Click;
			if (_IsStop != null)
			{
				_IsStop.Click -= value2;
			}
			_IsStop = value;
			if (_IsStop != null)
			{
				_IsStop.Click += value2;
			}
		}
	}

	private BackgroundWorker GetAsmBgWorker
	{
		[DebuggerNonUserCode]
		get
		{
			return _GetAsmBgWorker;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RunWorkerCompletedEventHandler value2 = GetAsmBgWorker_RunWorkerCompleted;
			DoWorkEventHandler value3 = GetAsmBgWorker_DoWork;
			if (_GetAsmBgWorker != null)
			{
				_GetAsmBgWorker.RunWorkerCompleted -= value2;
				_GetAsmBgWorker.DoWork -= value3;
			}
			_GetAsmBgWorker = value;
			if (_GetAsmBgWorker != null)
			{
				_GetAsmBgWorker.RunWorkerCompleted += value2;
				_GetAsmBgWorker.DoWork += value3;
			}
		}
	}

	private BackgroundWorker SaveToSWBgWorker
	{
		[DebuggerNonUserCode]
		get
		{
			return _SaveToSWBgWorker;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RunWorkerCompletedEventHandler value2 = SaveToSWBgWorker_RunWorkerCompleted;
			DoWorkEventHandler value3 = SaveToSWBgWorker_DoWork;
			if (_SaveToSWBgWorker != null)
			{
				_SaveToSWBgWorker.RunWorkerCompleted -= value2;
				_SaveToSWBgWorker.DoWork -= value3;
			}
			_SaveToSWBgWorker = value;
			if (_SaveToSWBgWorker != null)
			{
				_SaveToSWBgWorker.RunWorkerCompleted += value2;
				_SaveToSWBgWorker.DoWork += value3;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.Frmmain));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.Timer1 = new System.Windows.Forms.Timer(this.components);
		this._Ribbon = new RibbonLib.Ribbon();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.StatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.PropSwitchLabel = new System.Windows.Forms.ToolStripStatusLabel();
		this.treecmsp1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tree_openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_selectinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.Levelbom = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.tree_showselnode1 = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_showselnode3 = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_showselnode2 = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_hideselnode1 = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_hideselnode2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.tree_ExpandAll = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.tree_suppress = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_unsuppress = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_excludebom = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_unexcludebom = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_DisplayInBOM = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_DisplayInBOM_show = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_DisplayInBOM_hide = new System.Windows.Forms.ToolStripMenuItem();
		this.tree_DisplayInBOM_Promote = new System.Windows.Forms.ToolStripMenuItem();
		this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column1 = new AdvancedDataGridView.TreeGridColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.SplitContainerEx1 = new ZTool.SplitContainerEx();
		this.TV1 = new ZTool.MultiSelectTreeView();
		this.DGV1 = new ZTool.DataGridViewEX();
		this.Col_Preview = new System.Windows.Forms.DataGridViewImageColumn();
		this.Col_Checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.Col_Extname = new System.Windows.Forms.DataGridViewImageColumn();
		this.Col_Drw = new System.Windows.Forms.DataGridViewImageColumn();
		this.Col_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_NewFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_partnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Cfg = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_bound = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_SaveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Keywords = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Col_Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.StatusStrip1.SuspendLayout();
		this.treecmsp1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainerEx1).BeginInit();
		this.SplitContainerEx1.Panel1.SuspendLayout();
		this.SplitContainerEx1.Panel2.SuspendLayout();
		this.SplitContainerEx1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		this.SuspendLayout();
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "sldasm.png");
		this.ImageList1.Images.SetKeyName(1, "sldprt.png");
		this.Timer1.Enabled = true;
		this.Timer1.Interval = 5000;
		this._Ribbon.BackColor = System.Drawing.SystemColors.Control;
		resources.ApplyResources(this._Ribbon, "_Ribbon");
		this._Ribbon.Minimized = false;
		this._Ribbon.Name = "_Ribbon";
		this._Ribbon.ResourceName = "ZTool.RibbonMarkup.ribbon";
		this._Ribbon.ShortcutTableResourceName = null;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.StatusLabel1, this.StatusLabel2, this.ToolStripProgressBar1, this.PropSwitchLabel });
		resources.ApplyResources(this.StatusStrip1, "StatusStrip1");
		this.StatusStrip1.Name = "StatusStrip1";
		this.StatusStrip1.ShowItemToolTips = true;
		resources.ApplyResources(this.StatusLabel1, "StatusLabel1");
		this.StatusLabel1.IsLink = true;
		this.StatusLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		System.Windows.Forms.ToolStripStatusLabel statusLabel = this.StatusLabel1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
		statusLabel.Margin = margin;
		this.StatusLabel1.Name = "StatusLabel1";
		resources.ApplyResources(this.StatusLabel2, "StatusLabel2");
		this.StatusLabel2.ForeColor = System.Drawing.Color.Green;
		this.StatusLabel2.Name = "StatusLabel2";
		resources.ApplyResources(this.ToolStripProgressBar1, "ToolStripProgressBar1");
		this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
		resources.ApplyResources(this.PropSwitchLabel, "PropSwitchLabel");
		this.PropSwitchLabel.Name = "PropSwitchLabel";
		this.treecmsp1.Items.AddRange(new System.Windows.Forms.ToolStripItem[19]
		{
			this.tree_openinsw, this.tree_selectinsw, this.ToolStripSeparator3, this.Levelbom, this.ToolStripSeparator1, this.tree_showselnode1, this.tree_showselnode3, this.tree_showselnode2, this.tree_hideselnode1, this.tree_hideselnode2,
			this.ToolStripSeparator2, this.tree_ExpandAll, this.tree_CollapseAll, this.ToolStripSeparator4, this.tree_suppress, this.tree_unsuppress, this.tree_excludebom, this.tree_unexcludebom, this.tree_DisplayInBOM
		});
		this.treecmsp1.Name = "ContextMenuStrip1";
		this.treecmsp1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		resources.ApplyResources(this.treecmsp1, "treecmsp1");
		this.tree_openinsw.Name = "tree_openinsw";
		resources.ApplyResources(this.tree_openinsw, "tree_openinsw");
		this.tree_selectinsw.Name = "tree_selectinsw";
		resources.ApplyResources(this.tree_selectinsw, "tree_selectinsw");
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		resources.ApplyResources(this.ToolStripSeparator3, "ToolStripSeparator3");
		resources.ApplyResources(this.Levelbom, "Levelbom");
		this.Levelbom.Name = "Levelbom";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		resources.ApplyResources(this.ToolStripSeparator1, "ToolStripSeparator1");
		this.tree_showselnode1.Name = "tree_showselnode1";
		resources.ApplyResources(this.tree_showselnode1, "tree_showselnode1");
		this.tree_showselnode3.Name = "tree_showselnode3";
		resources.ApplyResources(this.tree_showselnode3, "tree_showselnode3");
		this.tree_showselnode2.Name = "tree_showselnode2";
		resources.ApplyResources(this.tree_showselnode2, "tree_showselnode2");
		this.tree_hideselnode1.BackColor = System.Drawing.SystemColors.Control;
		this.tree_hideselnode1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.tree_hideselnode1.Name = "tree_hideselnode1";
		resources.ApplyResources(this.tree_hideselnode1, "tree_hideselnode1");
		this.tree_hideselnode2.Name = "tree_hideselnode2";
		resources.ApplyResources(this.tree_hideselnode2, "tree_hideselnode2");
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		resources.ApplyResources(this.ToolStripSeparator2, "ToolStripSeparator2");
		this.tree_ExpandAll.Name = "tree_ExpandAll";
		resources.ApplyResources(this.tree_ExpandAll, "tree_ExpandAll");
		this.tree_CollapseAll.Name = "tree_CollapseAll";
		resources.ApplyResources(this.tree_CollapseAll, "tree_CollapseAll");
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		resources.ApplyResources(this.ToolStripSeparator4, "ToolStripSeparator4");
		this.tree_suppress.Name = "tree_suppress";
		resources.ApplyResources(this.tree_suppress, "tree_suppress");
		this.tree_unsuppress.Name = "tree_unsuppress";
		resources.ApplyResources(this.tree_unsuppress, "tree_unsuppress");
		this.tree_excludebom.Name = "tree_excludebom";
		resources.ApplyResources(this.tree_excludebom, "tree_excludebom");
		this.tree_unexcludebom.Name = "tree_unexcludebom";
		resources.ApplyResources(this.tree_unexcludebom, "tree_unexcludebom");
		this.tree_DisplayInBOM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.tree_DisplayInBOM_show, this.tree_DisplayInBOM_hide, this.tree_DisplayInBOM_Promote });
		this.tree_DisplayInBOM.Name = "tree_DisplayInBOM";
		resources.ApplyResources(this.tree_DisplayInBOM, "tree_DisplayInBOM");
		this.tree_DisplayInBOM_show.Name = "tree_DisplayInBOM_show";
		resources.ApplyResources(this.tree_DisplayInBOM_show, "tree_DisplayInBOM_show");
		this.tree_DisplayInBOM_hide.Name = "tree_DisplayInBOM_hide";
		resources.ApplyResources(this.tree_DisplayInBOM_hide, "tree_DisplayInBOM_hide");
		this.tree_DisplayInBOM_Promote.Name = "tree_DisplayInBOM_Promote";
		resources.ApplyResources(this.tree_DisplayInBOM_Promote, "tree_DisplayInBOM_Promote");
		this.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle;
		resources.ApplyResources(this.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1");
		this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		this.DataGridViewTextBoxColumn1.ReadOnly = true;
		this.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		resources.ApplyResources(this.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2");
		this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		resources.ApplyResources(this.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3");
		this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		this.DataGridViewTextBoxColumn3.ReadOnly = true;
		resources.ApplyResources(this.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4");
		this.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		this.DataGridViewTextBoxColumn4.ReadOnly = true;
		this.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
		resources.ApplyResources(this.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5");
		this.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
		this.DataGridViewTextBoxColumn5.ReadOnly = true;
		dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
		resources.ApplyResources(this.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6");
		this.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
		this.DataGridViewTextBoxColumn6.ReadOnly = true;
		dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
		resources.ApplyResources(this.DataGridViewTextBoxColumn7, "DataGridViewTextBoxColumn7");
		this.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
		this.DataGridViewTextBoxColumn7.ReadOnly = true;
		dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle5;
		resources.ApplyResources(this.DataGridViewTextBoxColumn8, "DataGridViewTextBoxColumn8");
		this.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
		this.DataGridViewTextBoxColumn8.ReadOnly = true;
		dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle6;
		resources.ApplyResources(this.DataGridViewTextBoxColumn9, "DataGridViewTextBoxColumn9");
		this.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
		this.DataGridViewTextBoxColumn9.ReadOnly = true;
		dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle7;
		resources.ApplyResources(this.DataGridViewTextBoxColumn10, "DataGridViewTextBoxColumn10");
		this.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
		this.DataGridViewTextBoxColumn10.ReadOnly = true;
		dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle8;
		resources.ApplyResources(this.DataGridViewTextBoxColumn11, "DataGridViewTextBoxColumn11");
		this.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11";
		this.DataGridViewTextBoxColumn11.ReadOnly = true;
		dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.DataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle9;
		resources.ApplyResources(this.DataGridViewTextBoxColumn12, "DataGridViewTextBoxColumn12");
		this.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12";
		this.DataGridViewTextBoxColumn12.ReadOnly = true;
		resources.ApplyResources(this.DataGridViewTextBoxColumn13, "DataGridViewTextBoxColumn13");
		this.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13";
		resources.ApplyResources(this.DataGridViewTextBoxColumn14, "DataGridViewTextBoxColumn14");
		this.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14";
		resources.ApplyResources(this.DataGridViewTextBoxColumn15, "DataGridViewTextBoxColumn15");
		this.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15";
		resources.ApplyResources(this.DataGridViewTextBoxColumn16, "DataGridViewTextBoxColumn16");
		this.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16";
		resources.ApplyResources(this.DataGridViewTextBoxColumn17, "DataGridViewTextBoxColumn17");
		this.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17";
		this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column1.DefaultNodeImage = null;
		resources.ApplyResources(this.Column1, "Column1");
		this.Column1.Name = "Column1";
		this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		resources.ApplyResources(this.Column2, "Column2");
		this.Column2.Name = "Column2";
		this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.SplitContainerEx1.Cursor = System.Windows.Forms.Cursors.Default;
		resources.ApplyResources(this.SplitContainerEx1, "SplitContainerEx1");
		this.SplitContainerEx1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.SplitContainerEx1.Name = "SplitContainerEx1";
		this.SplitContainerEx1.Panel1.Controls.Add(this.TV1);
		this.SplitContainerEx1.Panel2.Controls.Add(this.DGV1);
		this.TV1.BackColor = System.Drawing.SystemColors.Control;
		this.TV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TV1.Cursor = System.Windows.Forms.Cursors.Default;
		resources.ApplyResources(this.TV1, "TV1");
		this.TV1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
		this.TV1.FullRowSelect = true;
		this.TV1.HideSelection = false;
		this.TV1.ImageList = this.ImageList1;
		this.TV1.Name = "TV1";
		this.TV1.ShowNodeToolTips = true;
		this.DGV1.AllowUserToAddRows = false;
		this.DGV1.AllowUserToDeleteRows = false;
		this.DGV1.AllowUserToOrderColumns = true;
		this.DGV1.AllowUserToResizeRows = false;
		this.DGV1.BackgroundColor = System.Drawing.Color.White;
		this.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.DGV1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		this.DGV1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10.5f);
		dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.DGV1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
		resources.ApplyResources(this.DGV1, "DGV1");
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		this.DGV1.Columns.AddRange(this.Col_Preview, this.Col_Checkbox, this.Col_Extname, this.Col_Drw, this.Col_Number, this.Col_FileName, this.Col_NewFolder, this.Col_Material, this.Col_partnumber, this.Col_Quantity, this.Col_Path, this.Col_Cfg, this.Col_Weight, this.Col_bound, this.Col_Level, this.Col_CreationTime, this.Col_SaveTime, this.Col_Author, this.Col_Keywords, this.Col_Comment, this.Col_Title, this.Col_Subject);
		this.DGV1.Cursor = System.Windows.Forms.Cursors.Default;
		dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
		dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 10.5f);
		dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.DGV1.DefaultCellStyle = dataGridViewCellStyle11;
		this.DGV1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		this.DGV1.EnableHeadersVisualStyles = false;
		this.DGV1.GridColor = System.Drawing.Color.DarkGray;
		this.DGV1.Name = "DGV1";
		this.DGV1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 10.5f);
		dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
		this.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.DGV1.RowsDefaultCellStyle = dataGridViewCellStyle13;
		this.DGV1.RowTemplate.Height = 23;
		this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.DGV1.ShowFilterButton = false;
		this.DGV1.SortedColumn = null;
		this.DGV1.SortOrder = System.Windows.Forms.SortOrder.None;
		this.DGV1.topcfgName = null;
		this.Col_Preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle14.NullValue = null;
		this.Col_Preview.DefaultCellStyle = dataGridViewCellStyle14;
		resources.ApplyResources(this.Col_Preview, "Col_Preview");
		this.Col_Preview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
		this.Col_Preview.Name = "Col_Preview";
		this.Col_Preview.ReadOnly = true;
		this.Col_Preview.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Col_Preview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.Col_Checkbox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		dataGridViewCellStyle15.NullValue = false;
		this.Col_Checkbox.DefaultCellStyle = dataGridViewCellStyle15;
		this.Col_Checkbox.FalseValue = "False";
		resources.ApplyResources(this.Col_Checkbox, "Col_Checkbox");
		this.Col_Checkbox.IndeterminateValue = "False";
		this.Col_Checkbox.Name = "Col_Checkbox";
		this.Col_Checkbox.ReadOnly = true;
		this.Col_Checkbox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Col_Checkbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.Col_Checkbox.TrueValue = "True";
		this.Col_Extname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		dataGridViewCellStyle16.NullValue = null;
		this.Col_Extname.DefaultCellStyle = dataGridViewCellStyle16;
		resources.ApplyResources(this.Col_Extname, "Col_Extname");
		this.Col_Extname.Name = "Col_Extname";
		this.Col_Extname.ReadOnly = true;
		this.Col_Extname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Col_Extname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.Col_Drw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Drw.DefaultCellStyle = dataGridViewCellStyle17;
		resources.ApplyResources(this.Col_Drw, "Col_Drw");
		this.Col_Drw.Name = "Col_Drw";
		this.Col_Drw.ReadOnly = true;
		this.Col_Drw.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Col_Drw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.Col_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Number.DefaultCellStyle = dataGridViewCellStyle18;
		resources.ApplyResources(this.Col_Number, "Col_Number");
		this.Col_Number.Name = "Col_Number";
		this.Col_Number.ReadOnly = true;
		this.Col_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		resources.ApplyResources(this.Col_FileName, "Col_FileName");
		this.Col_FileName.Name = "Col_FileName";
		resources.ApplyResources(this.Col_NewFolder, "Col_NewFolder");
		this.Col_NewFolder.Name = "Col_NewFolder";
		this.Col_NewFolder.ReadOnly = true;
		resources.ApplyResources(this.Col_Material, "Col_Material");
		this.Col_Material.Name = "Col_Material";
		this.Col_Material.ReadOnly = true;
		this.Col_Material.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_partnumber.DefaultCellStyle = dataGridViewCellStyle19;
		resources.ApplyResources(this.Col_partnumber, "Col_partnumber");
		this.Col_partnumber.Name = "Col_partnumber";
		this.Col_partnumber.ReadOnly = true;
		dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Quantity.DefaultCellStyle = dataGridViewCellStyle20;
		resources.ApplyResources(this.Col_Quantity, "Col_Quantity");
		this.Col_Quantity.Name = "Col_Quantity";
		this.Col_Quantity.ReadOnly = true;
		dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Path.DefaultCellStyle = dataGridViewCellStyle21;
		resources.ApplyResources(this.Col_Path, "Col_Path");
		this.Col_Path.Name = "Col_Path";
		this.Col_Path.ReadOnly = true;
		dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Cfg.DefaultCellStyle = dataGridViewCellStyle22;
		resources.ApplyResources(this.Col_Cfg, "Col_Cfg");
		this.Col_Cfg.Name = "Col_Cfg";
		this.Col_Cfg.ReadOnly = true;
		dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Weight.DefaultCellStyle = dataGridViewCellStyle23;
		resources.ApplyResources(this.Col_Weight, "Col_Weight");
		this.Col_Weight.Name = "Col_Weight";
		this.Col_Weight.ReadOnly = true;
		dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_bound.DefaultCellStyle = dataGridViewCellStyle24;
		resources.ApplyResources(this.Col_bound, "Col_bound");
		this.Col_bound.Name = "Col_bound";
		this.Col_bound.ReadOnly = true;
		dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_Level.DefaultCellStyle = dataGridViewCellStyle25;
		resources.ApplyResources(this.Col_Level, "Col_Level");
		this.Col_Level.Name = "Col_Level";
		this.Col_Level.ReadOnly = true;
		dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_CreationTime.DefaultCellStyle = dataGridViewCellStyle26;
		resources.ApplyResources(this.Col_CreationTime, "Col_CreationTime");
		this.Col_CreationTime.Name = "Col_CreationTime";
		this.Col_CreationTime.ReadOnly = true;
		dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(230, 233, 238);
		this.Col_SaveTime.DefaultCellStyle = dataGridViewCellStyle27;
		resources.ApplyResources(this.Col_SaveTime, "Col_SaveTime");
		this.Col_SaveTime.Name = "Col_SaveTime";
		this.Col_SaveTime.ReadOnly = true;
		resources.ApplyResources(this.Col_Author, "Col_Author");
		this.Col_Author.Name = "Col_Author";
		resources.ApplyResources(this.Col_Keywords, "Col_Keywords");
		this.Col_Keywords.Name = "Col_Keywords";
		resources.ApplyResources(this.Col_Comment, "Col_Comment");
		this.Col_Comment.Name = "Col_Comment";
		resources.ApplyResources(this.Col_Title, "Col_Title");
		this.Col_Title.Name = "Col_Title";
		resources.ApplyResources(this.Col_Subject, "Col_Subject");
		this.Col_Subject.Name = "Col_Subject";
		resources.ApplyResources(this, "$this");
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Control;
		this.Controls.Add(this.SplitContainerEx1);
		this.Controls.Add(this.StatusStrip1);
		this.Controls.Add(this._Ribbon);
		this.DoubleBuffered = true;
		this.ForeColor = System.Drawing.SystemColors.ControlText;
		this.KeyPreview = true;
		this.Name = "Frmmain";
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.treecmsp1.ResumeLayout(false);
		this.SplitContainerEx1.Panel1.ResumeLayout(false);
		this.SplitContainerEx1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainerEx1).EndInit();
		this.SplitContainerEx1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public void AddRibbon()
	{
		checked
		{
			try
			{
				_ConnectSW = new RibbonButton(_Ribbon, 1000u);
				_SaveToSW = new RibbonSplitButtonGallery(_Ribbon, 1001u);
				_mergecfg = new RibbonCheckBox(_Ribbon, 1003u);
				_breakcfg = new RibbonCheckBox(_Ribbon, 1002u);
				_Excludevirtual = new RibbonCheckBox(_Ribbon, 1004u);
				_ExcludeLight = new RibbonCheckBox(_Ribbon, 1005u);
				_GetByBom = new RibbonCheckBox(_Ribbon, 1006u);
				_GetByVisible = new RibbonCheckBox(_Ribbon, 1036u);
				_GetAll = new RibbonCheckBox(_Ribbon, 1007u);
				_GetSelect = new RibbonCheckBox(_Ribbon, 1008u);
				_GetFromFile = new RibbonCheckBox(_Ribbon, 1051u);
				_cmdButtonOptions = new RibbonButton(_Ribbon, 1009u);
				_cmdButtonAboutMe = new RibbonButton(_Ribbon, 1010u);
				_cmdButtonExit = new RibbonButton(_Ribbon, 1012u);
				_cmdButtonUnit = new RibbonButton(_Ribbon, 1017u);
				_cmdButtonRename = new RibbonButton(_Ribbon, 1020u);
				_SplitColumn = new RibbonButton(_Ribbon, 1045u);
				_cmdButtonFilter = new RibbonButton(_Ribbon, 1018u);
				_cmdButtonPropertyName = new RibbonButton(_Ribbon, 1019u);
				_ExportBom = new RibbonSplitButtonGallery(_Ribbon, 1021u);
				_BomOptions = new RibbonButton(_Ribbon, 1022u);
				_BatchPrint = new RibbonButton(_Ribbon, 1024u);
				_BatchExport = new RibbonButton(_Ribbon, 1023u);
				_BatchReplace = new RibbonButton(_Ribbon, 1025u);
				_BatchReplaceParts = new RibbonButton(_Ribbon, 1035u);
				_SyncDrwName = new RibbonButton(_Ribbon, 1043u);
				_cmdButtonLook = new RibbonButton(_Ribbon, 1026u);
				_cmdButtonPrefix = new RibbonButton(_Ribbon, 1027u);
				_cmdButtonSymbol = new RibbonButton(_Ribbon, 1028u);
				_cmdButtonCopycol = new RibbonButton(_Ribbon, 1029u);
				_cmdButtonFillcol = new RibbonButton(_Ribbon, 1030u);
				_cmdButtonComparecol = new RibbonButton(_Ribbon, 1031u);
				_cmdRowHeigh = new RibbonSpinner(_Ribbon, 1032u);
				_cmdButtonHidecol = new RibbonDropDownGallery(_Ribbon, 1033u);
				_cmdButtonFreezecol = new RibbonDropDownGallery(_Ribbon, 1034u);
				_fastfilter = new RibbonDropDownGallery(_Ribbon, 1037u);
				_Encheckbox = new RibbonCheckBox(_Ribbon, 1038u);
				_Selectrow = new RibbonButton(_Ribbon, 1039u);
				_Readonlyitem = new RibbonButton(_Ribbon, 1040u);
				_Modifieditem = new RibbonButton(_Ribbon, 1041u);
				_Ruletype = new RibbonToggleButton(_Ribbon, 1042u);
				_Faileditem = new RibbonButton(_Ribbon, 1044u);
				_IsBendState = new RibbonButton(_Ribbon, 1069u);
				_IsWeldment = new RibbonButton(_Ribbon, 1070u);
				_ExcludeBom = new RibbonButton(_Ribbon, 1072u);
				_exportbyfilter = new RibbonCheckBox(_Ribbon, 1046u);
				_exportbyrule = new RibbonCheckBox(_Ribbon, 1047u);
				_Quantityratio = new RibbonSpinner(_Ribbon, 1048u);
				_ImportConfig = new RibbonButton(_Ribbon, 1049u);
				_BackupConfig = new RibbonButton(_Ribbon, 1050u);
				_CloseSwDoc = new RibbonDropDownButton(_Ribbon, 1052u);
				_CloseSwDoc_Filter = new RibbonButton(_Ribbon, 1053u);
				_CloseSwDoc_Sel = new RibbonButton(_Ribbon, 1054u);
				_CloseSwDoc_All = new RibbonButton(_Ribbon, 1055u);
				_CloseSwDoc_Allopen = new RibbonButton(_Ribbon, 1056u);
				_checkupdate = new RibbonButton(_Ribbon, 1057u);
				_helpbutton = new RibbonHelpButton(_Ribbon, 1058u);
				_regist = new RibbonButton(_Ribbon, 1059u);
				_copyswfile = new RibbonButton(_Ribbon, 1060u);
				_help = new RibbonButton(_Ribbon, 1061u);
				_namemapping = new RibbonButton(_Ribbon, 1062u);
				_virtualitem = new RibbonButton(_Ribbon, 1063u);
				_useexcel = new RibbonToggleButton(_Ribbon, 1064u);
				_usenpoi = new RibbonToggleButton(_Ribbon, 1065u);
				_customsort = new RibbonToggleButton(_Ribbon, 1066u);
				_exchangecolumn = new RibbonToggleButton(_Ribbon, 1067u);
				_mergepdf = new RibbonButton(_Ribbon, 1068u);
				_Markrepeat = new RibbonDropDownGallery(_Ribbon, 1071u);
				_ConnectSW.ExecuteEvent += _ConnectSW_ExecuteEvent;
				_GetByBom.ExecuteEvent += _GetByBom_ExecuteEvent;
				_GetAll.ExecuteEvent += _GetAll_ExecuteEvent;
				_GetSelect.ExecuteEvent += _GetSelect_ExecuteEvent;
				_GetByVisible.ExecuteEvent += _GetByVisible_ExecuteEvent;
				_GetFromFile.ExecuteEvent += _GetFromFile_ExecuteEvent;
				_SaveToSW.ExecuteEvent += _SaveToSW_ExecuteEvent;
				_SaveToSW.ItemsSourceReady += _SaveToSW_ItemsSourceReady;
				_mergecfg.ExecuteEvent += _mergecfg_ExecuteEvent;
				_breakcfg.ExecuteEvent += _breakcfg_ExecuteEvent;
				_Excludevirtual.ExecuteEvent += _Excludevirtual_ExecuteEvent;
				_ExcludeLight.ExecuteEvent += _ExcludeLight_ExecuteEvent;
				_cmdButtonOptions.ExecuteEvent += _cmdButtonOptions_ExecuteEvent;
				_cmdButtonAboutMe.ExecuteEvent += _cmdButtonAboutMe_ExecuteEvent;
				_cmdButtonExit.ExecuteEvent += _cmdButtonExit_ExecuteEvent;
				_cmdButtonUnit.ExecuteEvent += _cmdButtonUnit_ExecuteEvent;
				_cmdButtonFilter.ExecuteEvent += _cmdButtonFilter_ExecuteEvent;
				_cmdButtonPropertyName.ExecuteEvent += _cmdButtonPropertyName_ExecuteEvent;
				_cmdButtonRename.ExecuteEvent += _cmdButtonRename_ExecuteEvent;
				_SplitColumn.ExecuteEvent += _SplitColumn_ExecuteEvent;
				_ExportBom.ItemsSourceReady += _ExportBom_ItemsSourceReady;
				_BomOptions.ExecuteEvent += _BomOptions_ExecuteEvent;
				_BatchPrint.ExecuteEvent += _BatchPrint_ExecuteEvent;
				_BatchExport.ExecuteEvent += _BatchExport_ExecuteEvent;
				_BatchReplace.ExecuteEvent += _BatchReplace_ExecuteEvent;
				_BatchReplaceParts.ExecuteEvent += _BatchReplaceParts_ExecuteEvent;
				_SyncDrwName.ExecuteEvent += _SyncDrwName_ExecuteEvent;
				_mergepdf.ExecuteEvent += _mergepdf_ExecuteEvent;
				_cmdButtonLook.ExecuteEvent += _cmdButtonLook_ExecuteEvent;
				_cmdButtonPrefix.ExecuteEvent += _cmdButtonPrefix_ExecuteEvent;
				_cmdButtonSymbol.ExecuteEvent += _cmdButtonSymbol_ExecuteEvent;
				_cmdButtonCopycol.ExecuteEvent += _cmdButtonCopycol_ExecuteEvent;
				_cmdButtonFillcol.ExecuteEvent += _cmdButtonFillcol_ExecuteEvent;
				_cmdButtonComparecol.ExecuteEvent += _cmdButtonComparecol_ExecuteEvent;
				_cmdRowHeigh.ExecuteEvent += _cmdRowHeigh_ExecuteEvent;
				_cmdButtonHidecol.ItemsSourceReady += _cmdButtonHidecol_ItemsSourceReady;
				_cmdButtonFreezecol.ItemsSourceReady += _cmdButtonFreezecol_ItemsSourceReady;
				_Markrepeat.ItemsSourceReady += _Markrepeat_ItemsSourceReady;
				_fastfilter.ItemsSourceReady += _fastfilter_ItemsSourceReady;
				_Encheckbox.ExecuteEvent += _Encheckbox_ExecuteEvent;
				_Selectrow.ExecuteEvent += _fastfilter_ExecuteEvent;
				_Readonlyitem.ExecuteEvent += _fastfilter_ExecuteEvent;
				_Modifieditem.ExecuteEvent += _fastfilter_ExecuteEvent;
				_Ruletype.ExecuteEvent += _Ruletype_ExecuteEvent;
				_Faileditem.ExecuteEvent += _fastfilter_ExecuteEvent;
				_Faileditem.ExecuteEvent += _fastfilter_ExecuteEvent;
				_virtualitem.ExecuteEvent += _fastfilter_ExecuteEvent;
				_IsBendState.ExecuteEvent += _fastfilter_ExecuteEvent;
				_IsWeldment.ExecuteEvent += _fastfilter_ExecuteEvent;
				_ExcludeBom.ExecuteEvent += _fastfilter_ExecuteEvent;
				_ImportConfig.ExecuteEvent += _ImportConfig_ExecuteEvent;
				_BackupConfig.ExecuteEvent += _BackupConfig_ExecuteEvent;
				_CloseSwDoc_Filter.ExecuteEvent += _CloseSwDoc_Filter_ExecuteEvent;
				_CloseSwDoc_Sel.ExecuteEvent += _CloseSwDoc_Filter_ExecuteEvent;
				_CloseSwDoc_All.ExecuteEvent += _CloseSwDoc_Filter_ExecuteEvent;
				_CloseSwDoc_Allopen.ExecuteEvent += _CloseSwDoc_Filter_ExecuteEvent;
				_checkupdate.ExecuteEvent += _checkupdate_ExecuteEvent;
				_regist.ExecuteEvent += _regist_ExecuteEvent;
				_copyswfile.ExecuteEvent += _copyswfile_ExecuteEvent;
				_helpbutton.ExecuteEvent += _helpbutton_ExecuteEvent;
				_help.ExecuteEvent += _helpbutton_ExecuteEvent;
				_namemapping.ExecuteEvent += _namemapping_ExecuteEvent;
				_useexcel.ExecuteEvent += _useexcel_ExecuteEvent;
				_usenpoi.ExecuteEvent += _usenpoi_ExecuteEvent;
				_customsort.ExecuteEvent += _customsort_ExecuteEvent;
				_exchangecolumn.ExecuteEvent += _exchangecolumn_ExecuteEvent;
				_SaveToSW.Enabled = false;
				_copyswfile.Enabled = false;
				_cmdRowHeigh.DecimalPlaces = 0u;
				_cmdRowHeigh.DecimalValue = 25m;
				_cmdRowHeigh.Increment = 1m;
				_cmdRowHeigh.FormatString = "";
				_cmdRowHeigh.RepresentativeString = "0000";
				_Quantityratio.DecimalPlaces = 0u;
				_Quantityratio.DecimalValue = 1m;
				_Quantityratio.MinValue = 1m;
				_Quantityratio.MaxValue = 1000m;
				_Quantityratio.Increment = 1m;
				_Quantityratio.FormatString = "";
				_Quantityratio.RepresentativeString = "0000";
				int num = buttons1.Count() - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						buttons1[num2] = new RibbonCheckBox(_Ribbon, (uint)(10000 + num2));
						buttons2[num2] = new RibbonCheckBox(_Ribbon, (uint)(11000 + num2));
						buttons3[num2] = new RibbonCheckBox(_Ribbon, (uint)(12000 + num2));
						buttons4[num2] = new RibbonButton(_Ribbon, (uint)(13000 + num2));
						buttons5[num2] = new RibbonCheckBox(_Ribbon, (uint)(14000 + num2));
						buttons6[num2] = new RibbonButton(_Ribbon, (uint)(15000 + num2));
						buttons7[num2] = new RibbonCheckBox(_Ribbon, (uint)(16000 + num2));
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
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void loadfrm()
	{
		try
		{
			if (Environment.Is64BitProcess)
			{
				Text = Application.ProductName + " " + Application.ProductVersion + "(x64)";
			}
			else
			{
				Text = Application.ProductName + " " + Application.ProductVersion + "(x86)";
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
		checked
		{
			try
			{
				Icon = Resources.ztool_11;
				Material_list.AutoClose = true;
				Filter_list.AutoClose = true;
				StatusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
				PropSwitchLabel.Alignment = ToolStripItemAlignment.Right;
				Size size = new Size((int)Math.Round(25.0 * dpixRatio), (int)Math.Round(20.0 * dpixRatio));
				Padding margin = new Padding((int)Math.Round(2.0 * dpixRatio), (int)Math.Round(1.5 * dpixRatio), (int)Math.Round(2.0 * dpixRatio), (int)Math.Round(1.0 * dpixRatio));
				StatusStrip1.Items.Insert(StatusStrip1.Items.Count - 1, IsStop);
				IsStop.Visible = false;
				IsStop.AutoSize = false;
				IsStop.Size = size;
				IsStop.Margin = margin;
				IsStop.Image = Resources.Stop_red_16;
				IsStop.ImageAlign = ContentAlignment.MiddleCenter;
				IsStop.ImageScaling = ToolStripItemImageScaling.SizeToFit;
				IsStop.Tag = "Остановить задачу";
				IsStop.MouseHover += ToolStripButton_MouseHover;
				IsStop.MouseLeave += _Lambda_0024__79;
				sep.Alignment = ToolStripItemAlignment.Right;
				StatusStrip1.Items.Insert(StatusStrip1.Items.Count, PropSwitch);
				PropSwitch.AutoSize = false;
				PropSwitch.Size = size;
				PropSwitch.Margin = margin;
				PropSwitch.Image = Resources.prop;
				PropSwitch.ImageAlign = ContentAlignment.MiddleCenter;
				PropSwitch.ImageScaling = ToolStripItemImageScaling.SizeToFit;
				PropSwitch.Tag = "Выражение свойства / вычисленное значение";
				PropSwitchLabel.Text = "Выражение свойства";
				PropSwitchLabel.BackColor = SystemColors.Control;
				PropSwitch.Alignment = ToolStripItemAlignment.Right;
				PropSwitch.MouseHover += ToolStripButton_MouseHover;
				PropSwitch.MouseLeave += _Lambda_0024__80;
				StatusStrip1.Items.Insert(StatusStrip1.Items.Count, AutoColumnsMode);
				AutoColumnsMode.AutoSize = false;
				AutoColumnsMode.Size = size;
				AutoColumnsMode.Margin = margin;
				AutoColumnsMode.Image = Resources.ColumnWidth;
				AutoColumnsMode.ImageAlign = ContentAlignment.MiddleCenter;
				AutoColumnsMode.ImageScaling = ToolStripItemImageScaling.SizeToFit;
				AutoColumnsMode.Tag = "Автоширина столбцов";
				AutoColumnsMode.Alignment = ToolStripItemAlignment.Right;
				AutoColumnsMode.MouseHover += ToolStripButton_MouseHover;
				AutoColumnsMode.MouseLeave += _Lambda_0024__81;
				StatusStrip1.Items.Insert(StatusStrip1.Items.Count, PreviewSwitch1);
				PreviewSwitch1.AutoSize = false;
				PreviewSwitch1.Size = size;
				PreviewSwitch1.Margin = margin;
				PreviewSwitch1.Image = Resources.thumbnail_16px;
				PreviewSwitch1.ImageAlign = ContentAlignment.MiddleCenter;
				PreviewSwitch1.ImageScaling = ToolStripItemImageScaling.SizeToFit;
				PreviewSwitch1.Tag = "Показать/скрыть эскизы";
				PreviewSwitch1.Alignment = ToolStripItemAlignment.Right;
				PreviewSwitch1.MouseHover += ToolStripButton_MouseHover;
				PreviewSwitch1.MouseLeave += _Lambda_0024__82;
				StatusStrip1.Items.Insert(StatusStrip1.Items.Count, sep);
				StatusStrip1.Items.Insert(1, new ToolStripSeparator());
				StatusStrip1.Items.Insert(3, new ToolStripSeparator());
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(this, ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				int num = DGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					DGV1.Columns[num2].Width = (int)Math.Round((double)DGV1.Columns[num2].Width * dpixRatio);
					num2++;
				}
				DGV1.ColumnHeadersHeight = (int)Math.Round((double)DGV1.ColumnHeadersHeight * dpixRatio);
				StatusLabel1.BackColor = SystemColors.Control;
				StatusLabel1.Width = (int)Math.Round((double)StatusLabel1.Width * dpixRatio);
				StatusLabel2.BackColor = SystemColors.Control;
				StatusLabel2.Width = (int)Math.Round((double)StatusLabel2.Width * dpixRatio);
				ToolStripProgressBar1.Width = (int)Math.Round((double)ToolStripProgressBar1.Width * dpixRatio);
				ToolStripProgressBar1.Height = (int)Math.Round((double)ToolStripProgressBar1.Height * dpixRatio);
				PropSwitchLabel.Width = (int)Math.Round((double)PropSwitchLabel.Width * dpixRatio);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ProjectData.ClearProjectError();
			}
			try
			{
				if (CConfigMng.Config.mainformsize.Width >= MinimumSize.Width)
				{
					Width = CConfigMng.Config.mainformsize.Width;
				}
				if (CConfigMng.Config.mainformsize.Height >= MinimumSize.Height)
				{
					Height = CConfigMng.Config.mainformsize.Height;
				}
				WindowState = unchecked((FormWindowState)Conversions.ToInteger(Interaction.IIf(CConfigMng.Config.mainformWindowState == 1, 0, CConfigMng.Config.mainformWindowState)));
				StartPosition = FormStartPosition.Manual;
				Location = CConfigMng.Config.mainformLocation;
				Rectangle workingArea = Screen.GetWorkingArea(this);
				if (((double)Left + (double)Width * 0.05 > (double)workingArea.Width || (double)Top + (double)Height * 0.05 > (double)workingArea.Height || (double)Left + (double)Width * 0.95 < 0.0 || (double)Top + (double)Height * 0.95 < 0.0) ? true : false)
				{
					Left = 0;
					Top = 0;
				}
				if ((double)Left + (double)Width * 0.05 > (double)workingArea.Width)
				{
					Left = workingArea.Width - Width;
				}
				if ((double)Left + (double)Width * 0.95 < 0.0)
				{
					Left = 0;
				}
				if ((double)Top + (double)Height * 0.05 > (double)workingArea.Height)
				{
					Top = workingArea.Height - Height;
				}
				if ((double)Top + (double)Height * 0.95 < 0.0)
				{
					Top = 0;
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ProjectData.ClearProjectError();
			}
			DGV1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
		}
	}

	public void ToolStripButton_MouseHover(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		ToolTip toolTip = tt;
		string obj = Convert.ToString(RuntimeHelpers.GetObjectValue(toolStripButton.Tag));
		StatusStrip statusStrip = StatusStrip1;
		Point point = new Point(toolStripButton.Bounds.Left, checked((int)Math.Round((double)toolStripButton.Bounds.Top - 1.1 * (double)toolStripButton.Bounds.Height)));
		toolTip.Show(obj, statusStrip, point);
	}

	public void ToolStripButton_MouseLeave()
	{
		tt.Hide(StatusStrip1);
	}

	public void loadcfg()
	{
		try
		{
			if (PropSwitch.Checked)
			{
				PropSwitch_Click(this, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			SelRowColor();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
			MessageBox.Show(this, ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			insetpropcol();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			logopathlist.WriteLog($"Тип исключения: {ex6.GetType().Name}\r\nСообщение: {ex6.Message}\r\nИнформация: {ex6.StackTrace}");
			MessageBox.Show(this, ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		LoadColumnInfo();
		try
		{
			RegHotKey();
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			logopathlist.WriteLog($"Тип исключения: {ex8.GetType().Name}\r\nСообщение: {ex8.Message}\r\nИнформация: {ex8.StackTrace}");
			MessageBox.Show(this, ex8.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			if (Conversions.ToDouble(_cmdButtonFreezecol.Keytip) == 1.0)
			{
				_cmdButtonFreezecol_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_cmdButtonHidecol.Keytip) == 1.0)
			{
				_cmdButtonHidecol_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_ExportBom.Keytip) == 1.0)
			{
				_ExportBom_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_SaveToSW.Keytip) == 1.0)
			{
				_SaveToSW_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_ExportBom.Keytip) == 1.0)
			{
				_ExportBom_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_fastfilter.Keytip) == 1.0)
			{
				_fastfilter_ItemsSourceReady(null, null);
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			logopathlist.WriteLog($"Тип исключения: {ex10.GetType().Name}\r\nСообщение: {ex10.Message}\r\nИнформация: {ex10.StackTrace}");
			MessageBox.Show(this, ex10.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			GetDataOption = CConfigMng.Config.GetDataOption;
			_breakcfg.BooleanValue = !CConfigMng.Config.togetherConfig;
			_mergecfg.BooleanValue = CConfigMng.Config.togetherConfig;
			_Excludevirtual.BooleanValue = CConfigMng.Config.Excludevirtual;
			_ExcludeLight.BooleanValue = CConfigMng.Config.ExcludeLight;
			_GetByBom.BooleanValue = Conversions.ToBoolean(Interaction.IIf(GetDataOption == 0, true, false));
			_GetAll.BooleanValue = Conversions.ToBoolean(Interaction.IIf(GetDataOption == 1, true, false));
			_GetSelect.BooleanValue = Conversions.ToBoolean(Interaction.IIf(GetDataOption == 2, true, false));
			_GetByVisible.BooleanValue = Conversions.ToBoolean(Interaction.IIf(GetDataOption == 3, true, false));
			_GetFromFile.BooleanValue = Conversions.ToBoolean(Interaction.IIf(GetDataOption == 4, true, false));
			_useexcel.BooleanValue = !CConfigMng.Config.usenpoi;
			_usenpoi.BooleanValue = CConfigMng.Config.usenpoi;
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception ex12 = ex11;
			logopathlist.WriteLog($"Тип исключения: {ex12.GetType().Name}\r\nСообщение: {ex12.Message}\r\nИнформация: {ex12.StackTrace}");
			MessageBox.Show(this, ex12.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			if ((!SplitContainerEx1.IsCollpased || CConfigMng.Config.IsCollpased) && 0 == 0 && ((!SplitContainerEx1.IsCollpased && CConfigMng.Config.IsCollpased) ? true : false))
			{
				SplitContainerEx1.CollpaseOrExpand();
			}
			SplitContainerEx1.SplitterDistance = CConfigMng.Config.Splitwidth;
		}
		catch (Exception ex13)
		{
			ProjectData.SetProjectError(ex13);
			Exception ex14 = ex13;
			ProjectData.ClearProjectError();
		}
		try
		{
			string quickAccessToolbarini = CConfigMng.Config.QuickAccessToolbarini;
			if (!Information.IsNothing(quickAccessToolbarini))
			{
				MemoryStream memoryStream = new MemoryStream();
				memoryStream = (MemoryStream)code.StrToStream(quickAccessToolbarini);
				if (!Information.IsNothing(memoryStream))
				{
					memoryStream.Position = 0L;
					_Ribbon.LoadSettingsFromStream(memoryStream);
				}
			}
			_cmdRowHeigh.MinValue = new decimal(20.0 * dpixRatio);
			_cmdRowHeigh.MaxValue = 1000m;
			if (decimal.Compare(new decimal(CConfigMng.Config.rowheight), _cmdRowHeigh.MinValue) < 0)
			{
				_cmdRowHeigh.DecimalValue = _cmdRowHeigh.MinValue;
				CConfigMng.Config.rowheight = Convert.ToInt32(_cmdRowHeigh.MinValue);
			}
			else
			{
				_cmdRowHeigh.DecimalValue = new decimal(CConfigMng.Config.rowheight);
			}
			foreach (DataGridViewRow item in (IEnumerable)DGV1.Rows)
			{
				item.Height = Convert.ToInt32(_cmdRowHeigh.DecimalValue);
			}
			_exportbyfilter.BooleanValue = CConfigMng.Config.ExportToBom_ByFilter1;
			_exportbyrule.BooleanValue = CConfigMng.Config.ExportToBom_ByFilter2;
			if (CConfigMng.Config.GetDataOption == 0)
			{
				_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_BOM);
				return;
			}
			if (CConfigMng.Config.GetDataOption == 1)
			{
				_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_ALL);
				return;
			}
			if (CConfigMng.Config.GetDataOption == 2)
			{
				_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_Sel);
				return;
			}
			if (CConfigMng.Config.GetDataOption == 3)
			{
				_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_Vis);
				return;
			}
			if (CConfigMng.Config.GetDataOption == 4)
			{
				_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_File);
				return;
			}
			CConfigMng.Config.GetDataOption = 0;
			CConfigMng.SaveConfig();
			_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_BOM);
		}
		catch (Exception ex15)
		{
			ProjectData.SetProjectError(ex15);
			Exception ex16 = ex15;
			logopathlist.WriteLog($"Тип исключения: {ex16.GetType().Name}\r\nСообщение: {ex16.Message}\r\nИнформация: {ex16.StackTrace}");
			MessageBox.Show(ex16.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public Frmmain()
	{
		base.Activated += Frmmain_Activated;
		base.Deactivate += Frmmain_Deactivate;
		base.LocationChanged += Frmmain_LocationChanged;
		base.FormClosed += Frmmain_FormClosed;
		base.KeyDown += Frmmain_KeyDown;
		base.Load += Frmmain_Load;
		__ENCAddToList(this);
		SelectedCol = 0;
		FilterCollist = new List<string>[1];
		HideCollist = new List<int>();
		isolatedlist = new List<int>();
		FilterColReverse = new List<bool>();
		Filter_list = new ContextMenuStrip();
		Material_list = new ContextMenuStrip();
		CfgRename_list = new ContextMenuStrip();
		Prop_Downlist = new ContextMenuStrip();
		DGV_Menulist = new ContextMenuStrip();
		write_list = new ContextMenuStrip();
		PropSwitch = new ToolStripButton();
		AutoColumnsMode = new ToolStripButton();
		HighLightRow = new ToolStripButton();
		PreviewSwitch1 = new ToolStripButton();
		partnumbersetting = new ContextMenuStrip();
		selcount = 0;
		sep = new ToolStripSeparator();
		ComboBox1 = new CustomComboBox1();
		IsStop = new ToolStripButton();
		filename_inselitem = "";
		cfgname_inselitem = "";
		EnableDGVChangeEvent = true;
		isloaded = false;
		dpixRatio = 1.0;
		rlist = new List<int>();
		buttons1 = new RibbonCheckBox[1000];
		buttons2 = new RibbonCheckBox[1000];
		buttons3 = new RibbonCheckBox[1000];
		buttons4 = new RibbonButton[1000];
		buttons5 = new RibbonCheckBox[1000];
		buttons6 = new RibbonButton[1000];
		buttons7 = new RibbonCheckBox[1000];
		tt = new ToolTip();
		previewing = false;
		mlist = new Dictionary<string, Color>();
		ColorDialog = new ColorDialog();
		bd = default(code.BOMPartData);
		Clb = new ToolStripCheckedListBox();
		k1 = 0;
		GetAsmBgWorker = new BackgroundWorker();
		SaveToSWBgWorker = new BackgroundWorker();
		Rowlist_Savefailed = new List<int>();
		myindexd = new Dictionary<int, int>();
		InitializeComponent();
		if (!code.HasShell("笨小孩。。。"))
		{
			Environment.Exit(0);
		}
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		CConfigMng.InitializeConfig();
		AddRibbon();
		loadfrm();
	}

	public void _ImportConfig_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;
			openFileDialog.SupportMultiDottedExtensions = false;
			openFileDialog.InitialDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
			openFileDialog.Filter = "Файл настроек (*.settings)|*.settings";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() != DialogResult.Cancel)
			{
				string fileName = openFileDialog.FileName;
				string configFileName = CConfigMng.ConfigFileName;
				if (!string.Equals(fileName, configFileName, StringComparison.OrdinalIgnoreCase))
				{
					File.Copy(fileName, configFileName, overwrite: true);
					CConfigMng.LoadConfig();
					loadcfg();
					refreshlist();
				}
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

	public void refreshlist()
	{
		try
		{
			if (Conversions.ToDouble(_cmdButtonFreezecol.Keytip) == 1.0)
			{
				_cmdButtonFreezecol_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_cmdButtonHidecol.Keytip) == 1.0)
			{
				_cmdButtonHidecol_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_Markrepeat.Keytip) == 1.0)
			{
				_Markrepeat_ItemsSourceReady(null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void _BackupConfig_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		try
		{
			if (PropSwitch.Checked)
			{
				PropSwitch_Click(this, null);
			}
			SaveColumnInfo();
			MemoryStream memoryStream = new MemoryStream();
			_Ribbon.SaveSettingsToStream(memoryStream);
			CConfigMng.Config.QuickAccessToolbarini = code.StreamToStr(memoryStream);
			CConfigMng.SaveConfig();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			string configFileName = CConfigMng.ConfigFileName;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = Path.GetExtension(code.SplitStr(configFileName, 5));
			saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
			saveFileDialog.FileName = "Резервная копия-" + DateTime.Now.ToString("yyyyMMdd");
			saveFileDialog.Filter = "Файл настроек (*.settings)|*.settings";
			saveFileDialog.ValidateNames = true;
			if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
			{
				string fileName = saveFileDialog.FileName;
				File.Copy(configFileName, fileName, overwrite: true);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void _CloseSwDoc_Filter_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		RibbonButton ribbonButton = (RibbonButton)sender;
		List<string> list = new List<string>();
		string text = StatusLabel1.Text;
		if (!code.RunSW(HideWindow: false, startnew: false))
		{
			return;
		}
		checked
		{
			try
			{
				if (ribbonButton.CommandID == _CloseSwDoc_Filter.CommandID)
				{
					int num = DGV1.RowCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							if (DGV1.Rows[num2].Visible)
							{
								list.Add(Conversions.ToString(DGV1[Col_Path.Index, num2].Value));
							}
							num2++;
							continue;
						}
						break;
					}
				}
				else if (ribbonButton.CommandID == _CloseSwDoc_Sel.CommandID)
				{
					if (DGV1.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
					{
						foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
						{
							list.Add(Conversions.ToString(DGV1[Col_Path.Index, selectedCell.RowIndex].Value));
						}
					}
					else
					{
						foreach (DataGridViewRow selectedRow in DGV1.SelectedRows)
						{
							list.Add(Conversions.ToString(DGV1[Col_Path.Index, selectedRow.Index].Value));
						}
					}
				}
				else if (ribbonButton.CommandID == _CloseSwDoc_All.CommandID)
				{
					int num5 = DGV1.RowCount - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 <= num4)
						{
							list.Add(Conversions.ToString(DGV1[Col_Path.Index, num6].Value));
							num6++;
							continue;
						}
						break;
					}
				}
				else if (ribbonButton.CommandID == _CloseSwDoc_Allopen.CommandID)
				{
					NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
					for (object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null)); objectValue != null; objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null)))
					{
						list.Add(Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null)));
					}
					NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
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
			finally
			{
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
			}
			try
			{
				if (list.Count <= 0)
				{
					return;
				}
				int num8 = unchecked((int)MessageBox.Show("Во избежание потери данных\r\nсохранить файл перед закрытием?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question));
				if (num8 == 2)
				{
					return;
				}
				StatusLabel1.Text = "Закрытие файла......";
				ToolStripProgressBar1.Maximum = list.Count - 1;
				ToolStripProgressBar1.Visible = true;
				int num9 = list.Count - 1;
				int num10 = 0;
				int num12 = default(int);
				int num13 = default(int);
				while (true)
				{
					int num11 = num10;
					int num4 = num9;
					if (num11 > num4)
					{
						break;
					}
					ToolStripProgressBar1.Value = num10;
					object[] array3;
					List<string> list2;
					int index;
					object[] array;
					bool[] array4;
					if (num8 == 6)
					{
						object swApp = code.swApp;
						array = new object[1];
						object[] array2 = array;
						list2 = list;
						List<string> list3 = list2;
						index = num10;
						array2[0] = list3[index];
						array3 = array;
						object[] arguments = array3;
						array4 = new bool[1] { true };
						object obj = NewLateBinding.LateGet(swApp, null, "GetOpenDocumentByName", arguments, null, null, array4);
						if (array4[0])
						{
							list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						}
						object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
						{
							object instance = objectValue2;
							array = new object[3] { 1, num12, num13 };
							object[] arguments2 = array;
							array4 = new bool[3] { false, true, true };
							NewLateBinding.LateCall(instance, null, "save3", arguments2, null, null, array4, IgnoreReturn: true);
							if (array4[1])
							{
								num12 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
							}
							if (array4[2])
							{
								num13 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(int));
							}
							objectValue2 = null;
						}
					}
					object swApp2 = code.swApp;
					array3 = new object[1];
					object[] array5 = array3;
					list2 = list;
					List<string> list4 = list2;
					index = num10;
					array5[0] = list4[index];
					array = array3;
					object[] arguments3 = array;
					array4 = new bool[1] { true };
					NewLateBinding.LateCall(swApp2, null, "CloseDoc", arguments3, null, null, array4, IgnoreReturn: true);
					if (array4[0])
					{
						list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					num10++;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				StatusLabel1.Text = text;
				ToolStripProgressBar1.Value = 0;
				ToolStripProgressBar1.Maximum = 0;
				ToolStripProgressBar1.Visible = false;
			}
		}
	}

	private void _checkupdate_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		// Vendor online update disabled (see Phase 3): ribbon button is inert.
	}

	private void _regist_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		code.startrg(this);
	}

	private void _copyswfile_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.frm_copyswfile.Visible)
		{
			MyProject.Forms.frm_copyswfile.Show(this);
		}
	}

	private void _helpbutton_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		try
		{
			if (File.Exists(code.helpfile))
			{
				Process.Start(code.helpfile);
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
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void _namemapping_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.Frmmapping.ShowDialog(this);
	}

	private void _useexcel_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_useexcel.BooleanValue)
		{
			_useexcel.BooleanValue = true;
		}
		_usenpoi.BooleanValue = false;
		CConfigMng.Config.usenpoi = false;
		CConfigMng.SaveConfig();
	}

	private void _usenpoi_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_usenpoi.BooleanValue)
		{
			_usenpoi.BooleanValue = true;
		}
		_useexcel.BooleanValue = false;
		CConfigMng.Config.usenpoi = true;
		CConfigMng.SaveConfig();
	}

	private void _exchangecolumn_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.Frmexchangecol.Visible)
		{
			MyProject.Forms.Frmexchangecol.Show(this);
		}
	}

	private void _customsort_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.Frmcustomsort.Visible)
		{
			MyProject.Forms.Frmcustomsort.Show(this);
		}
	}

	private void _ConnectSW_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		chl = new checklic();
		if (CConfigMng.Config.GetDataOption == 4)
		{
			GetFromFile();
		}
		else
		{
			GetAsm();
		}
		try
		{
			if (Conversions.ToDouble(_ExportBom.Keytip) == 1.0)
			{
				_ExportBom_ItemsSourceReady(null, null);
			}
			if (Conversions.ToDouble(_fastfilter.Keytip) == 1.0)
			{
				_fastfilter_ItemsSourceReady(null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void _GetByBom_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_GetByBom.BooleanValue)
		{
			_GetByBom.BooleanValue = true;
		}
		_GetByVisible.BooleanValue = false;
		_GetSelect.BooleanValue = false;
		_GetAll.BooleanValue = false;
		_GetFromFile.BooleanValue = false;
		CConfigMng.Config.GetDataOption = 0;
		CConfigMng.SaveConfig();
		_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_BOM);
	}

	private void _GetByVisible_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_GetByVisible.BooleanValue)
		{
			_GetByVisible.BooleanValue = true;
		}
		_GetByBom.BooleanValue = false;
		_GetSelect.BooleanValue = false;
		_GetAll.BooleanValue = false;
		_GetFromFile.BooleanValue = false;
		CConfigMng.Config.GetDataOption = 3;
		CConfigMng.SaveConfig();
		_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_Vis);
	}

	private void _GetFromFile_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_GetFromFile.BooleanValue)
		{
			_GetFromFile.BooleanValue = true;
		}
		_GetByBom.BooleanValue = false;
		_GetSelect.BooleanValue = false;
		_GetAll.BooleanValue = false;
		_GetByVisible.BooleanValue = false;
		CConfigMng.Config.GetDataOption = 4;
		CConfigMng.SaveConfig();
		_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_File);
	}

	private void _GetAll_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_GetAll.BooleanValue)
		{
			_GetAll.BooleanValue = true;
		}
		_GetByVisible.BooleanValue = false;
		_GetByBom.BooleanValue = false;
		_GetSelect.BooleanValue = false;
		_GetFromFile.BooleanValue = false;
		CConfigMng.Config.GetDataOption = 1;
		CConfigMng.SaveConfig();
		_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_ALL);
	}

	private void _GetSelect_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_GetSelect.BooleanValue)
		{
			_GetSelect.BooleanValue = true;
		}
		_GetByVisible.BooleanValue = false;
		_GetByBom.BooleanValue = false;
		_GetAll.BooleanValue = false;
		_GetFromFile.BooleanValue = false;
		GetDataOption = 2;
		CConfigMng.Config.GetDataOption = 2;
		CConfigMng.SaveConfig();
		_ConnectSW.LargeImage = _Ribbon.ConvertToUIImage(Resources.SW32_Sel);
	}

	private void _SaveToSW_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		chl = new checklic();
		if (DGV1.RowCount >= 1)
		{
			MyProject.Forms.FrmSaveOption.ShowDialog(this);
		}
	}

	internal void _SaveToSW_ItemsSourceReady(object sender, EventArgs e)
	{
		_SaveToSW.Keytip = Conversions.ToString(1);
		checked
		{
			try
			{
				IUICollection itemsSource = _SaveToSW.ItemsSource;
				itemsSource.Clear();
				IUICollection categories = _SaveToSW.Categories;
				categories.Clear();
				categories.Add(new GalleryItemPropertySet
				{
					Label = "Правило фильтрации",
					CategoryID = 1u
				});
				if (CConfigMng.Config.FilterRulesList.Count < 1)
				{
					buttons1[0].Label = "Нет";
					buttons1[0].Enabled = false;
					itemsSource.Add(new GalleryCommandPropertySet
					{
						CategoryID = 1u,
						CommandID = buttons1[0].CommandID,
						CommandType = CommandType.Boolean
					});
					return;
				}
				int num = CConfigMng.Config.FilterRulesList.Count - 1;
				int num2 = 0;
				_Closure_0024__39 closure_0024__ = default(_Closure_0024__39);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						closure_0024__ = new _Closure_0024__39(closure_0024__);
						if (num2 > 999)
						{
							break;
						}
						bool flag = false;
						closure_0024__._0024VB_0024Local_str = CConfigMng.Config.FilterRulesList[num2].name;
						if (!(string.IsNullOrEmpty(closure_0024__._0024VB_0024Local_str) | string.IsNullOrWhiteSpace(closure_0024__._0024VB_0024Local_str)))
						{
							flag = CConfigMng.Config.SaveToSWFilterRule.Exists(closure_0024__._Lambda_0024__83);
							buttons1[num2].Label = closure_0024__._0024VB_0024Local_str;
							buttons1[num2].BooleanValue = flag;
							buttons1[num2].ExecuteEvent -= button1_ExecuteEvent;
							buttons1[num2].ExecuteEvent += button1_ExecuteEvent;
							itemsSource.Add(new GalleryCommandPropertySet
							{
								CategoryID = 1u,
								CommandID = buttons1[num2].CommandID,
								CommandType = CommandType.Boolean
							});
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
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void _mergecfg_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_mergecfg.BooleanValue)
		{
			_mergecfg.BooleanValue = true;
		}
		_breakcfg.BooleanValue = false;
		CConfigMng.Config.togetherConfig = true;
		CConfigMng.SaveConfig();
	}

	private void _breakcfg_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!_breakcfg.BooleanValue)
		{
			_breakcfg.BooleanValue = true;
		}
		_mergecfg.BooleanValue = false;
		CConfigMng.Config.togetherConfig = false;
		CConfigMng.SaveConfig();
	}

	private void _Excludevirtual_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		CConfigMng.Config.Excludevirtual = _Excludevirtual.BooleanValue;
		CConfigMng.SaveConfig();
	}

	private void _ExcludeLight_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		CConfigMng.Config.ExcludeLight = _ExcludeLight.BooleanValue;
		CConfigMng.SaveConfig();
	}

	private void _cmdButtonOptions_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmOptions.ShowDialog(this);
	}

	private void _cmdButtonAboutMe_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmAbout.ShowDialog(this);
	}

	private void _cmdButtonExit_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		Application.Exit();
	}

	private void _cmdButtonUnit_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmSWUnit.ShowDialog(this);
	}

	private void _cmdButtonFilter_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmFilterrules.ShowDialog(this);
	}

	private void _cmdButtonPropertyName_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.Frmsetpropname.ShowDialog(this);
	}

	private void _cmdButtonRename_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.FrmRename.Visible)
		{
			MyProject.Forms.FrmRename.Show(this);
		}
	}

	private void _SplitColumn_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.FrmSplitcloumn.Visible)
		{
			MyProject.Forms.FrmSplitcloumn.Show(this);
		}
	}

	internal void _ExportBom_ItemsSourceReady(object sender, EventArgs e)
	{
		_ExportBom.Keytip = Conversions.ToString(1);
		checked
		{
			try
			{
				IUICollection itemsSource = _ExportBom.ItemsSource;
				itemsSource.Clear();
				if (CConfigMng.Config.bomsettings.Count < 1)
				{
					buttons4[0].Label = "Нет";
					buttons4[0].Enabled = false;
					itemsSource.Add(new GalleryCommandPropertySet
					{
						CommandID = buttons4[0].CommandID,
						CommandType = CommandType.Action
					});
					return;
				}
				int num = CConfigMng.Config.bomsettings.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4 || num2 > 999)
					{
						break;
					}
					buttons4[num2].Enabled = true;
					if ((CConfigMng.Config.bomsettings[num2].type != 0 && GetDataOption != 0 && GetDataOption != 1) ? true : false)
					{
						buttons4[num2].Enabled = false;
					}
					buttons4[num2].Label = CConfigMng.Config.bomsettings[num2].name;
					buttons4[num2].Keytip = Conversions.ToString(num2);
					buttons4[num2].ExecuteEvent -= button4_ExecuteEvent;
					buttons4[num2].ExecuteEvent += button4_ExecuteEvent;
					itemsSource.Add(new GalleryCommandPropertySet
					{
						CommandID = buttons4[num2].CommandID,
						CommandType = CommandType.Action
					});
					num2++;
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
	}

	private void _BomOptions_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.Frmexportbom.Visible)
		{
			MyProject.Forms.Frmexportbom.Show(this);
		}
	}

	private void _cmdButtonLook_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.FrmReplace.Visible)
		{
			MyProject.Forms.FrmReplace.Show(this);
		}
	}

	private void _cmdButtonPrefix_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.FrmSuffixes.Visible)
		{
			MyProject.Forms.FrmSuffixes.Show(this);
		}
	}

	private void _cmdButtonSymbol_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.Frmsymbol.Visible)
		{
			MyProject.Forms.Frmsymbol.Show(this);
		}
	}

	private void _cmdButtonCopycol_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.FrmCopy.Visible)
		{
			MyProject.Forms.FrmCopy.Show(this);
		}
	}

	private void _cmdButtonFillcol_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.FrmFilling.Visible)
		{
			MyProject.Forms.FrmFilling.Show(this);
		}
	}

	private void _cmdButtonComparecol_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		if (!MyProject.Forms.Frmcompare.Visible)
		{
			MyProject.Forms.Frmcompare.Show(this);
		}
	}

	private void _BatchPrint_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmPrintlist.Show();
	}

	private void _BatchExport_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmOutputlist.Show();
	}

	private void _BatchReplace_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmSetDrwlist.Show();
	}

	private void _BatchReplaceParts_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmReplacePartslist.Show();
	}

	private void _SyncDrwName_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.FrmSyncDrwName.Show();
	}

	private void _mergepdf_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		MyProject.Forms.Frmmerge_split_pdf.Show();
	}

	internal void _cmdButtonHidecol_ItemsSourceReady(object sender, EventArgs e)
	{
		_cmdButtonHidecol.Keytip = Conversions.ToString(1);
		checked
		{
			try
			{
				IUICollection itemsSource = _cmdButtonHidecol.ItemsSource;
				itemsSource.Clear();
				int num = 0;
				int num2 = DGV1.Columns.Count - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5 || num > 999)
					{
						break;
					}
					bool flag = false;
					if (!DGV1.Columns[num3].Name.Contains("PropResolvedVal_") & !DGV1.Columns[num3].Name.Contains("PropVal_") & (Operators.CompareString(DGV1.Columns[num3].HeaderText, "", TextCompare: false) != 0) & (num3 != Col_Preview.Index))
					{
						flag = true;
					}
					else if (DGV1.Columns[num3].Name.Contains("PropResolvedVal_") & PropSwitch.Checked)
					{
						flag = true;
					}
					else if (DGV1.Columns[num3].Name.Contains("PropVal_") & !PropSwitch.Checked)
					{
						flag = true;
					}
					if (flag)
					{
						num++;
						buttons2[num3].Label = DGV1.Columns[num3].HeaderText;
						buttons2[num3].BooleanValue = DGV1.Columns[num3].Visible;
						buttons2[num3].Keytip = Conversions.ToString(num3);
						buttons2[num3].ExecuteEvent -= button2_ExecuteEvent;
						buttons2[num3].ExecuteEvent += button2_ExecuteEvent;
						itemsSource.Add(new GalleryCommandPropertySet
						{
							CommandID = buttons2[num3].CommandID,
							CommandType = CommandType.Boolean
						});
					}
					num3++;
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
	}

	internal void _cmdButtonFreezecol_ItemsSourceReady(object sender, EventArgs e)
	{
		_cmdButtonFreezecol.Keytip = Conversions.ToString(1);
		checked
		{
			try
			{
				IUICollection itemsSource = _cmdButtonFreezecol.ItemsSource;
				itemsSource.Clear();
				int num = 0;
				int num2 = DGV1.Columns.Count - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5 || num > 999)
					{
						break;
					}
					bool flag = false;
					if (!DGV1.Columns[num3].Name.Contains("PropResolvedVal_") & !DGV1.Columns[num3].Name.Contains("PropVal_") & (Operators.CompareString(DGV1.Columns[num3].HeaderText, "", TextCompare: false) != 0))
					{
						flag = true;
					}
					else if (DGV1.Columns[num3].Name.Contains("PropResolvedVal_") & PropSwitch.Checked)
					{
						flag = true;
					}
					else if (DGV1.Columns[num3].Name.Contains("PropVal_") & !PropSwitch.Checked)
					{
						flag = true;
					}
					if (flag)
					{
						num++;
						buttons3[num3].Label = DGV1.Columns[num3].HeaderText;
						buttons3[num3].BooleanValue = Conversions.ToBoolean(Interaction.IIf(num3 == CConfigMng.Config.FrozenCol, true, false));
						buttons3[num3].Keytip = Conversions.ToString(num3);
						buttons3[num3].ExecuteEvent -= button3_ExecuteEvent;
						buttons3[num3].ExecuteEvent += button3_ExecuteEvent;
						itemsSource.Add(new GalleryCommandPropertySet
						{
							CommandID = buttons3[num3].CommandID,
							CommandType = CommandType.Boolean
						});
					}
					num3++;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				_cmdButtonFreezecol.ItemsSource.Clear();
				ProjectData.ClearProjectError();
			}
		}
	}

	internal void _Markrepeat_ItemsSourceReady(object sender, EventArgs e)
	{
		_Markrepeat.Keytip = Conversions.ToString(1);
		checked
		{
			try
			{
				IUICollection itemsSource = _Markrepeat.ItemsSource;
				itemsSource.Clear();
				int num = 0;
				int num2 = DGV1.Columns.Count - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5 || num > 999)
					{
						break;
					}
					bool flag = false;
					if (!DGV1.Columns[num3].ReadOnly || ((num3 == Col_partnumber.Index) ? true : false))
					{
						flag = true;
					}
					if (flag)
					{
						num++;
						buttons7[num3].Label = DGV1.Columns[num3].HeaderText;
						buttons7[num3].BooleanValue = Conversions.ToBoolean(Interaction.IIf(num3 == CConfigMng.Config.markrepeat, true, false));
						buttons7[num3].Keytip = Conversions.ToString(num3);
						buttons7[num3].ExecuteEvent -= button7_ExecuteEvent;
						buttons7[num3].ExecuteEvent += button7_ExecuteEvent;
						itemsSource.Add(new GalleryCommandPropertySet
						{
							CommandID = buttons7[num3].CommandID,
							CommandType = CommandType.Boolean
						});
					}
					num3++;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				_Markrepeat.ItemsSource.Clear();
				ProjectData.ClearProjectError();
			}
		}
	}

	internal void _fastfilter_ItemsSourceReady(object sender, EventArgs e)
	{
		_fastfilter.Keytip = Conversions.ToString(1);
		checked
		{
			try
			{
				IUICollection itemsSource = _fastfilter.ItemsSource;
				itemsSource.Clear();
				IUICollection categories = _fastfilter.Categories;
				categories.Clear();
				categories.Add(new GalleryItemPropertySet
				{
					Label = "Пользовательское правило",
					CategoryID = 1u
				});
				if (CConfigMng.Config.FilterRulesList.Count < 1)
				{
					buttons6[0].Label = "Нет";
					buttons6[0].Enabled = false;
					itemsSource.Add(new GalleryCommandPropertySet
					{
						CategoryID = 1u,
						CommandID = buttons6[0].CommandID,
						CommandType = CommandType.Boolean
					});
				}
				else
				{
					int num = CConfigMng.Config.FilterRulesList.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4 || num2 > 999)
						{
							break;
						}
						bool flag = false;
						string name = CConfigMng.Config.FilterRulesList[num2].name;
						if (!(string.IsNullOrEmpty(name) | string.IsNullOrWhiteSpace(name)))
						{
							buttons6[num2].Label = name;
							buttons6[num2].Enabled = true;
							buttons6[num2].ExecuteEvent -= _fastfilter_ExecuteEvent;
							buttons6[num2].ExecuteEvent += _fastfilter_ExecuteEvent;
							itemsSource.Add(new GalleryCommandPropertySet
							{
								CommandID = buttons6[num2].CommandID,
								CategoryID = 1u,
								CommandType = CommandType.Action
							});
						}
						num2++;
					}
				}
				_ExcludeBom.Enabled = Conversions.ToBoolean(Interaction.IIf(CConfigMng.Config.GetDataOption == 1, true, false));
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

	public void button1_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		CConfigMng.Config.SaveToSWFilterRule.Clear();
		checked
		{
			int num = buttons1.Length - 1;
			int num2 = 0;
			_Closure_0024__40 closure_0024__ = default(_Closure_0024__40);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__40(closure_0024__);
				closure_0024__._0024VB_0024Local_label = buttons1[num2].Label;
				if (Operators.CompareString(closure_0024__._0024VB_0024Local_label, "", TextCompare: false) != 0 && buttons1[num2].BooleanValue && !CConfigMng.Config.SaveToSWFilterRule.Exists(closure_0024__._Lambda_0024__84))
				{
					CConfigMng.Config.SaveToSWFilterRule.Add(buttons1[num2].Label);
				}
				num2++;
			}
			CConfigMng.SaveConfig();
			ReadonlyRowMark();
		}
	}

	public void button2_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		RibbonCheckBox ribbonCheckBox = (RibbonCheckBox)sender;
		int num = checked(DGV1.Columns.Count - 1);
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			int num4 = num;
			if (num3 > num4)
			{
				break;
			}
			if (Operators.CompareString(DGV1.Columns[num2].HeaderText, ribbonCheckBox.Label, TextCompare: false) == 0)
			{
				if (((uint)((!DGV1.Columns[num2].Name.Contains("PropResolvedVal_") && !DGV1.Columns[num2].Name.Contains("PropVal_")) ? 1 : 0) & ((Operators.CompareString(DGV1.Columns[num2].HeaderText, "", TextCompare: false) != 0) ? 1u : 0u)) != 0)
				{
					DGV1.Columns[num2].Visible = ribbonCheckBox.BooleanValue;
				}
				if (DGV1.Columns[num2].Name.Contains("PropResolvedVal_") || (DGV1.Columns[num2].Name.Contains("PropVal_") ? true : false))
				{
					DGV1.Columns[num2].Tag = ribbonCheckBox.BooleanValue.ToString();
				}
				if (ribbonCheckBox.BooleanValue)
				{
					if (((DGV1.Columns[num2].Name.Contains("PropResolvedVal_") && PropSwitch.Checked) || (DGV1.Columns[num2].Name.Contains("PropVal_") && !PropSwitch.Checked)) ? true : false)
					{
						DGV1.Columns[num2].Visible = ribbonCheckBox.BooleanValue;
					}
				}
				else if (DGV1.Columns[num2].Name.Contains("PropResolvedVal_") || (DGV1.Columns[num2].Name.Contains("PropVal_") ? true : false))
				{
					DGV1.Columns[num2].Visible = ribbonCheckBox.BooleanValue;
				}
			}
			num2 = checked(num2 + 1);
		}
		SaveColumnInfo();
	}

	public void button3_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		RibbonCheckBox ribbonCheckBox = (RibbonCheckBox)sender;
		checked
		{
			int num = DGV1.Columns.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				DGV1.Columns[num2].Frozen = false;
				num2++;
			}
			CConfigMng.Config.FrozenCol = -1;
			try
			{
				if (ribbonCheckBox.BooleanValue)
				{
					int num5 = buttons3.Count() - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						if (buttons3[num6].CommandID != ribbonCheckBox.CommandID)
						{
							buttons3[num6].BooleanValue = false;
						}
						num6++;
					}
					DGV1.Columns[Convert.ToInt32(ribbonCheckBox.Keytip)].Frozen = true;
					CConfigMng.Config.FrozenCol = Conversions.ToInteger(ribbonCheckBox.Keytip);
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
			CConfigMng.SaveConfig();
		}
	}

	public void button4_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		_Closure_0024__41 closure_0024__ = new _Closure_0024__41();
		closure_0024__._0024VB_0024Local_rcb = (RibbonButton)sender;
		try
		{
			bomsetting bst = CConfigMng.Config.bomsettings.Find(closure_0024__._Lambda_0024__85);
			if (GetDataOption == 0 || GetDataOption == 1)
			{
				if (CConfigMng.Config.usenpoi)
				{
					ExportBom_xls4(bst, (Treenode)TV1.SelectedNode);
				}
				else
				{
					ExportBom_xls2(bst, (Treenode)TV1.SelectedNode);
				}
			}
			else if (CConfigMng.Config.usenpoi)
			{
				ExportBom_xls3(bst);
			}
			else
			{
				ExportBom_xls1(bst);
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

	public void _Encheckbox_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		RibbonCheckBox ribbonCheckBox = (RibbonCheckBox)sender;
		DGV1.Columns[Col_Checkbox.Index].Visible = ribbonCheckBox.BooleanValue;
		DGV1.EndEdit();
		RemoveFilter(Col_Checkbox.Index);
	}

	public void _fastfilter_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		LastCustomFilterButton = (RibbonButton)sender;
		FastFilter();
	}

	public void FastFilter()
	{
		if (Information.IsNothing(LastCustomFilterButton))
		{
			return;
		}
		bool booleanValue = _Ruletype.BooleanValue;
		RemoveFilter(Col_Checkbox.Index);
		checked
		{
			if (LastCustomFilterButton.CommandID == _Selectrow.CommandID)
			{
				foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
				{
					if (selectedCell.ColumnIndex == sel_col)
					{
						DGV1[Col_Checkbox.Index, selectedCell.RowIndex].Value = true;
					}
				}
			}
			else if (LastCustomFilterButton.CommandID == _Readonlyitem.CommandID)
			{
				int num = DGV1.RowCount - 1;
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
						string text = Conversions.ToString(DGV1[Col_Path.Index, num2].Value);
						if (!string.IsNullOrEmpty(text) && code.IsReadOnly(text))
						{
							DGV1[Col_Checkbox.Index, num2].Value = true;
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
					num2++;
				}
			}
			else if (LastCustomFilterButton.CommandID == _Modifieditem.CommandID)
			{
				int num5 = DGV1.RowCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 <= num4)
					{
						Type typeFromHandle = typeof(Strings);
						object[] array = new object[1];
						object[] array2 = array;
						DataGridViewRow dataGridViewRow = DGV1.Rows[num6];
						array2[0] = RuntimeHelpers.GetObjectValue(dataGridViewRow.Tag);
						object[] array3 = array;
						object[] arguments = array3;
						bool[] array4 = new bool[1] { true };
						object left = NewLateBinding.LateGet(null, typeFromHandle, "UCase", arguments, null, null, array4);
						if (array4[0])
						{
							dataGridViewRow.Tag = RuntimeHelpers.GetObjectValue(array3[0]);
						}
						if (Operators.ConditionalCompareObjectEqual(left, "TRUE", TextCompare: false))
						{
							DGV1[Col_Checkbox.Index, num6].Value = true;
						}
						num6++;
						continue;
					}
					break;
				}
			}
			else if (LastCustomFilterButton.CommandID == _Faileditem.CommandID)
			{
				int num8 = DGV1.RowCount - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num4 = num8;
					if (num10 <= num4)
					{
						if (Operators.CompareString(DGV1.Rows[num9].ErrorText, "", TextCompare: false) != 0)
						{
							DGV1[Col_Checkbox.Index, num9].Value = true;
						}
						num9++;
						continue;
					}
					break;
				}
			}
			else if (LastCustomFilterButton.CommandID == _virtualitem.CommandID)
			{
				int num11 = DGV1.RowCount - 1;
				int num12 = 0;
				while (true)
				{
					int num13 = num12;
					int num4 = num11;
					if (num13 <= num4)
					{
						string str = Conversions.ToString(DGV1[Col_Path.Index, num12].Value);
						if (code.IsVirtual(str))
						{
							DGV1[Col_Checkbox.Index, num12].Value = true;
						}
						num12++;
						continue;
					}
					break;
				}
			}
			else if (LastCustomFilterButton.CommandID == _IsBendState.CommandID)
			{
				int num14 = DGV1.RowCount - 1;
				int num15 = 0;
				while (true)
				{
					int num16 = num15;
					int num4 = num14;
					if (num16 <= num4)
					{
						if (Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Number.Index, num15].Tag, 0, TextCompare: false))
						{
							DGV1[Col_Checkbox.Index, num15].Value = true;
						}
						num15++;
						continue;
					}
					break;
				}
			}
			else if (LastCustomFilterButton.CommandID == _IsWeldment.CommandID)
			{
				int num17 = DGV1.RowCount - 1;
				int num18 = 0;
				while (true)
				{
					int num19 = num18;
					int num4 = num17;
					if (num19 <= num4)
					{
						Type typeFromHandle2 = typeof(Strings);
						object[] array3 = new object[1];
						object[] array5 = array3;
						DataGridViewCell dataGridViewCell2 = DGV1[Col_Path.Index, num18];
						array5[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
						object[] array = array3;
						object[] arguments2 = array;
						bool[] array4 = new bool[1] { true };
						object left2 = NewLateBinding.LateGet(null, typeFromHandle2, "UCase", arguments2, null, null, array4);
						if (array4[0])
						{
							dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array[0]);
						}
						if (Operators.ConditionalCompareObjectEqual(left2, "TRUE", TextCompare: false))
						{
							DGV1[Col_Checkbox.Index, num18].Value = true;
						}
						num18++;
						continue;
					}
					break;
				}
			}
			else if (LastCustomFilterButton.CommandID == _ExcludeBom.CommandID)
			{
				if (!LastCustomFilterButton.Enabled)
				{
					return;
				}
				List<Treenode> list = new List<Treenode>();
				bomsetting bomsetting2 = new bomsetting();
				bomsetting2.type = 0;
				bomsetting2.includetop = true;
				bomsetting bst = bomsetting2;
				list = GetListFromTree((Treenode)TV1.TopNode, bst);
				if (list.Count > 0)
				{
					int num20 = DGV1.RowCount - 1;
					int num21 = 0;
					while (true)
					{
						int num22 = num21;
						int num4 = num20;
						if (num22 <= num4)
						{
							bool flag = false;
							if (code.togetherConfig)
							{
								_Closure_0024__42 closure_0024__ = new _Closure_0024__42();
								closure_0024__._0024VB_0024Local_Str = Conversions.ToString(DGV1[Col_Path.Index, num21].Value);
								flag = list.Exists(closure_0024__._Lambda_0024__86);
							}
							else
							{
								_Closure_0024__43 closure_0024__2 = new _Closure_0024__43();
								closure_0024__2._0024VB_0024Local_Str = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DGV1[Col_Path.Index, num21].Value, "\n"), DGV1[Col_Cfg.Index, num21].Value));
								flag = list.Exists(closure_0024__2._Lambda_0024__87);
							}
							if (!flag)
							{
								DGV1[Col_Checkbox.Index, num21].Value = true;
							}
							num21++;
							continue;
						}
						break;
					}
				}
			}
			else if (unchecked(((long)LastCustomFilterButton.CommandID >= 15000L) & ((long)LastCustomFilterButton.CommandID < 15999L)))
			{
				try
				{
					List<string> list2 = new List<string>();
					list2.Add(LastCustomFilterButton.Label);
					CustomFilter customFilter = new CustomFilter(list2);
					int num23 = DGV1.RowCount - 1;
					int num24 = 0;
					while (true)
					{
						int num25 = num24;
						int num4 = num23;
						if (num25 <= num4)
						{
							if (customFilter.FilterByRule(num24))
							{
								DGV1[Col_Checkbox.Index, num24].Value = true;
							}
							num24++;
							continue;
						}
						break;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
					MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					ProjectData.ClearProjectError();
				}
			}
			filter_checkbox(booleanValue);
		}
	}

	public void filter_checkbox(bool Excluded)
	{
		Clb = new ToolStripCheckedListBox();
		checked
		{
			try
			{
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (DGV1.Rows[num2].Visible)
					{
						string text = Conversions.ToString(DGV1[Col_Checkbox.Index, num2].Value);
						if (Strings.Len(text) == 0)
						{
							text = "";
						}
						bool flag = false;
						int num5 = Clb.Items.Count - 1;
						int num6 = 0;
						while (true)
						{
							int num7 = num6;
							num4 = num5;
							if (num7 > num4)
							{
								break;
							}
							if (string.Equals(Clb.Items[num6].ToString(), text, StringComparison.CurrentCultureIgnoreCase))
							{
								flag = true;
								break;
							}
							num6++;
						}
						if (!flag)
						{
							ToolStripCheckedListBox clb = Clb;
							object[] array = new object[2]
							{
								text,
								RuntimeHelpers.GetObjectValue(Interaction.IIf(string.Equals(text, true.ToString(), StringComparison.CurrentCultureIgnoreCase), true, false))
							};
							bool[] array2 = new bool[2] { true, false };
							NewLateBinding.LateCall(clb, null, "AddItem", array, null, null, array2, IgnoreReturn: true);
							if (array2[0])
							{
								text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
							}
						}
					}
					num2++;
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
			if (ColFilter(Excluded, Col_Checkbox.Index))
			{
				_Encheckbox.BooleanValue = true;
				DGV1.Columns[Col_Checkbox.Index].Visible = true;
			}
		}
	}

	private void _Ruletype_ExecuteEvent(object sender, EventArgs e)
	{
		_Ruletype.Label = Conversions.ToString(Interaction.IIf(_Ruletype.BooleanValue, "Исключить совпадающие", "Включить совпадающие"));
		_Ruletype.TooltipTitle = Conversions.ToString(Interaction.IIf(_Ruletype.BooleanValue, "Исключить совпадающие", "Включить совпадающие"));
		_Ruletype.TooltipDescription = Conversions.ToString(Interaction.IIf(_Ruletype.BooleanValue, "Исключить совпадающие", "Включить совпадающие"));
		_Ruletype.SmallImage = (IUIImage)Interaction.IIf(_Ruletype.BooleanValue, _Ribbon.ConvertToUIImage(Resources.exclude_32), _Ribbon.ConvertToUIImage(Resources.include_32));
	}

	private void _cmdRowHeigh_ExecuteEvent(object sender, EventArgs e)
	{
		try
		{
			int rowheight = CConfigMng.Config.rowheight;
			int value = DGV1.Columns[Col_Preview.Index].Width;
			int num = default(int);
			if (rowheight > 0)
			{
				num = Convert.ToInt32(decimal.Divide(decimal.Multiply(new decimal(value), _cmdRowHeigh.DecimalValue), new decimal(rowheight)));
			}
			if (Convert.ToDouble(decimal.Divide(new decimal(num), _cmdRowHeigh.DecimalValue)) != 1.3333333333333333)
			{
				num = Convert.ToInt32(decimal.Divide(decimal.Multiply(_cmdRowHeigh.DecimalValue, 4m), 3m));
			}
			CConfigMng.Config.rowheight = Convert.ToInt32(_cmdRowHeigh.DecimalValue);
			CConfigMng.SaveConfig();
			foreach (DataGridViewRow item in (IEnumerable)DGV1.Rows)
			{
				item.Height = CConfigMng.Config.rowheight;
			}
			if (num > DGV1.Columns[Col_Preview.Index].MinimumWidth)
			{
				DGV1.Columns[Col_Preview.Index].Width = num;
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

	public void button7_ExecuteEvent(object sender, ExecuteEventArgs e)
	{
		RibbonCheckBox ribbonCheckBox = (RibbonCheckBox)sender;
		unMarkrepeat();
		CConfigMng.Config.markrepeat = -1;
		checked
		{
			try
			{
				if (ribbonCheckBox.BooleanValue)
				{
					int num = buttons7.Count() - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (buttons7[num2].CommandID != ribbonCheckBox.CommandID)
						{
							buttons7[num2].BooleanValue = false;
						}
						num2++;
					}
					CConfigMng.Config.markrepeat = Conversions.ToInteger(ribbonCheckBox.Keytip);
					Markrepeat();
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
			CConfigMng.SaveConfig();
		}
	}

	private void Frmmain_Activated(object sender, EventArgs e)
	{
		RegHotKey();
	}

	private void Frmmain_Deactivate(object sender, EventArgs e)
	{
		UnRegHotKey();
	}

	private void Frmmain_LocationChanged(object sender, EventArgs e)
	{
		if ((isloaded && WindowState == FormWindowState.Normal) ? true : false)
		{
			CConfigMng.Config.mainformLocation = Location;
		}
	}

	private void Frmmain_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			GetAsmBgWorker.Dispose();
			SaveToSWBgWorker.Dispose();
			UnRegHotKey();
			if (PropSwitch.Checked)
			{
				PropSwitch_Click(this, null);
			}
			SaveColumnInfo();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		try
		{
			CConfigMng.Config.IsCollpased = SplitContainerEx1.IsCollpased;
			CConfigMng.Config.Splitwidth = SplitContainerEx1.SplitterDistance;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		try
		{
			CConfigMng.Config.mainformWindowState = Conversions.ToInteger(Interaction.IIf(WindowState == FormWindowState.Minimized, 0, WindowState));
			if (WindowState == FormWindowState.Normal)
			{
				CConfigMng.Config.mainformLocation = Location;
				CConfigMng.Config.mainformsize = Size;
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ProjectData.ClearProjectError();
		}
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			_Ribbon.SaveSettingsToStream(memoryStream);
			CConfigMng.Config.QuickAccessToolbarini = code.StreamToStr(memoryStream);
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			logopathlist.WriteLog($"Тип исключения: {ex8.GetType().Name}\r\nСообщение: {ex8.Message}\r\nИнформация: {ex8.StackTrace}");
			MessageBox.Show(ex8.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		CConfigMng.SaveConfig();
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void Frmmain_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			MyProject.Forms.FrmPreview.Close();
			return;
		}
		if ((e.KeyCode == Keys.V && e.Modifiers == Keys.Control) ? true : false)
		{
			try
			{
				code.PasteExcel(DGV1);
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
				return;
			}
		}
		if ((e.KeyCode == Keys.S) & (e.Modifiers == Keys.Control))
		{
			_SaveToSW_ExecuteEvent(null, null);
		}
		else if ((e.KeyCode == Keys.L) & (e.Modifiers == Keys.Control))
		{
			_ConnectSW_ExecuteEvent(null, null);
		}
		else if ((e.KeyCode == Keys.B) & (e.Modifiers == Keys.Control))
		{
			_BomOptions_ExecuteEvent(null, null);
		}
		else if ((e.KeyCode == Keys.P) & (e.Modifiers == Keys.Control))
		{
			_BatchPrint_ExecuteEvent(null, null);
		}
		else if ((e.KeyCode == Keys.O) & (e.Modifiers == Keys.Control))
		{
			_BatchExport_ExecuteEvent(null, null);
		}
		else if ((e.KeyCode == Keys.R) & (e.Modifiers == Keys.Control))
		{
			_BatchReplace_ExecuteEvent(null, null);
		}
	}

	private void Frmmain_Load(object sender, EventArgs e)
	{
		try
		{
			SR sR = new SR();
			if (!sR.Isme("冰雨。。。"))
			{
				Environment.Exit(0);
			}
			lockbutton();
			g_monitor();
			loadcfg();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
		try
		{
			sendhwndtosw();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		try
		{
			if (CConfigMng.Config.checkupdata)
			{
				Thread thread = new Thread(_Lambda_0024__88);
				thread.Start();
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ProjectData.ClearProjectError();
		}
		isloaded = true;
	}

	private void PreviewSwitch1_Click(object sender, EventArgs e)
	{
		PreviewSwitch1.Checked = !PreviewSwitch1.Checked;
		if (PreviewSwitch1.Checked)
		{
			if (!code.InsertPicBool)
			{
				code.InsertPic2();
			}
			else if (MessageBox.Show("Обновить эскиз?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				code.InsertPic2();
			}
			DGV1.Columns[Col_Preview.Index].Visible = true;
		}
		else
		{
			DGV1.Columns[Col_Preview.Index].Visible = false;
		}
		try
		{
			if (Conversions.ToDouble(_cmdButtonFreezecol.Keytip) == 1.0)
			{
				_cmdButtonFreezecol_ItemsSourceReady(_cmdButtonFreezecol, null);
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
		try
		{
			if (Conversions.ToDouble(_cmdButtonHidecol.Keytip) == 1.0)
			{
				_cmdButtonHidecol_ItemsSourceReady(_cmdButtonHidecol, null);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void StatusLabel1_Click(object sender, EventArgs e)
	{
		if (!MyProject.Forms.Frmtips.Visible && Operators.CompareString(StatusLabel1.Text.Trim(), "", TextCompare: false) != 0 && 0 == 0)
		{
			MyProject.Forms.Frmtips.Show(this);
		}
	}

	private void StatusLabel1_Paint(object sender, PaintEventArgs e)
	{
		if (Operators.CompareString(StatusLabel1.Text.Trim(), "", TextCompare: false) == 0)
		{
			StatusLabel1.IsLink = false;
		}
		else
		{
			StatusLabel1.IsLink = true;
		}
	}

	private void AutoColumnsMode_Click(object sender, EventArgs e)
	{
		AutoColumnsMode.Checked = !AutoColumnsMode.Checked;
		if (AutoColumnsMode.Checked)
		{
			DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		}
		else
		{
			DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		}
	}

	private void PropSwitch_Click(object sender, EventArgs e)
	{
		PropSwitch.Checked = !PropSwitch.Checked;
		if (PropSwitch.Checked)
		{
			PropSwitch.Image = Resources.propval;
			PropSwitchLabel.Text = "Вычисленное значение   ";
		}
		else
		{
			PropSwitch.Image = Resources.prop;
			PropSwitchLabel.Text = "Выражение свойства";
		}
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
						string columnName = "PropVal_" + Conversions.ToString(num2);
						string columnName2 = "PropResolvedVal_" + Conversions.ToString(num2);
						DGV1.Columns[columnName2].ReadOnly = true;
						DGV1.Columns[columnName2].DefaultCellStyle.BackColor = DGV1.ColumnHeadersDefaultCellStyle.BackColor;
						if (PropSwitch.Checked)
						{
							int displayIndex = DGV1.Columns[columnName].DisplayIndex;
							DGV1.Columns[columnName2].DisplayIndex = displayIndex;
						}
						else
						{
							int displayIndex2 = DGV1.Columns[columnName2].DisplayIndex;
							DGV1.Columns[columnName].DisplayIndex = displayIndex2;
						}
						if (DGV1.Columns[columnName].Visible | DGV1.Columns[columnName2].Visible)
						{
							DGV1.Columns[columnName].Visible = !PropSwitch.Checked;
							DGV1.Columns[columnName2].Visible = PropSwitch.Checked;
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
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void IsStop_Click(object sender, EventArgs e)
	{
		code.StartSwitch(status: false);
	}

	private void DGV1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		DGV1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		oldcellval = Conversions.ToString(DGV1[e.ColumnIndex, e.RowIndex].Value);
		oldcellcolor = DGV1[e.ColumnIndex, e.RowIndex].Style.ForeColor;
		try
		{
			if (((oldcellval.Contains("\n") && DGV1.Columns[sel_col].Name.Contains("PropVal_")) || sel_col == Col_Comment.Index) ? true : false)
			{
				DGV1[e.ColumnIndex, e.RowIndex].Style.WrapMode = DataGridViewTriState.True;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			DGV1[e.ColumnIndex, e.RowIndex].Style.WrapMode = DataGridViewTriState.NotSet;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (DGV1.RowCount >= 1 && code.EnadleCellEvent)
			{
				if ((e.RowIndex == -1 && e.ColumnIndex == -1) ? true : false)
				{
					DGV1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
				}
				else
				{
					DGV1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
				}
				if (e.ColumnIndex == -1)
				{
					DGV1.EditMode = DataGridViewEditMode.EditOnKeystroke;
					DGV1.EndEdit();
					DGV1.Rows[e.RowIndex].Selected = true;
				}
				if ((e.ColumnIndex == Col_Checkbox.Index) & (e.RowIndex > -1))
				{
					bool flag = Conversions.ToBoolean(DGV1[e.ColumnIndex, e.RowIndex].Value);
					DGV1[e.ColumnIndex, e.RowIndex].Value = !flag;
				}
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

	private void DGV1_MouseDown(object sender, MouseEventArgs e)
	{
		previewing = true;
		DGV1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
	}

	private void DGV1_MouseUp(object sender, MouseEventArgs e)
	{
		if (DGV1.SelectedRows.Count == 1 || DGV1.SelectedCells.Count == 1)
		{
			DGV1.EditMode = DataGridViewEditMode.EditOnEnter;
		}
		previewing = false;
		if (previewing)
		{
			return;
		}
		previewing = true;
		try
		{
			if (sel_row > -1 && ((CConfigMng.Config.RowFollowdisplay && Operators.CompareString(Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.FrmPreview.Tag)) + MyProject.Forms.FrmPreview.Text, filename_inselitem + cfgname_inselitem, TextCompare: false) != 0) ? true : false))
			{
				code.Preview2(CConfigMng.Config.DefaultDrw, filename_inselitem, cfgname_inselitem, this);
				preview_selrow = sel_row;
				Focus();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
		previewing = false;
	}

	private void DGV1_SelectionChanged(object sender, EventArgs e)
	{
		if (code.EnadleCellEvent && DGV1.RowCount >= 1 && (DGV1.SelectedRows.Count == 1 || DGV1.SelectedCells.Count == 1))
		{
			ReadonlyRowMark();
			if (CConfigMng.Config.RealTimeFilter)
			{
				Filter();
			}
		}
	}

	private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == Col_Preview.Index || ((e.ColumnIndex < 0) | (e.RowIndex < 0)))
		{
			return;
		}
		checked
		{
			if (code.EnadleCellEvent)
			{
				if ((code.EnadleMarkrepeat && e.ColumnIndex == CConfigMng.Config.markrepeat) ? true : false)
				{
					Markrepeat();
				}
				if ((!DGV1.Columns[e.ColumnIndex].ReadOnly && DGV1[e.ColumnIndex, e.RowIndex].Value == null) ? true : false)
				{
					DGV1[e.ColumnIndex, e.RowIndex].Value = "";
				}
				DGV1[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkOrange;
				if ((e.ColumnIndex != Col_Checkbox.Index && e.ColumnIndex != Col_Cfg.Index && e.ColumnIndex != Col_Preview.Index && e.ColumnIndex != Col_Path.Index && e.ColumnIndex != Col_Drw.Index) ? true : false)
				{
					DGV1.Rows[e.RowIndex].Tag = "true";
				}
				if (e.ColumnIndex == Col_FileName.Index)
				{
					if (code.checkfilename)
					{
						int num = isrepeat(Conversions.ToString(DGV1[e.ColumnIndex, e.RowIndex].Value), e.RowIndex);
						if (num > 0)
						{
							MessageBox.Show(this, "Имя уже существует, номер: " + Conversions.ToString(num), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							DGV1[e.ColumnIndex, e.RowIndex].Value = oldcellval;
							DGV1[e.ColumnIndex, e.RowIndex].Style.ForeColor = oldcellcolor;
						}
					}
					if (EnableDGVChangeEvent)
					{
						int num2 = DGV1.RowCount - 1;
						int num3 = 0;
						while (true)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							if (num3 != e.RowIndex && !Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Path.Index, num3].Value, DGV1[Col_Path.Index, e.RowIndex].Value, TextCompare: false) && Operators.ConditionalCompareObjectNotEqual(DGV1[e.ColumnIndex, num3].Value, DGV1[e.ColumnIndex, e.RowIndex].Value, TextCompare: false))
							{
								DGV1[e.ColumnIndex, num3].Value = RuntimeHelpers.GetObjectValue(DGV1[e.ColumnIndex, e.RowIndex].Value);
								DGV1[e.ColumnIndex, num3].Style.ForeColor = DGV1[e.ColumnIndex, e.RowIndex].Style.ForeColor;
							}
							num3++;
						}
					}
				}
			}
			DGV1.RefreshEdit();
		}
	}

	private void DGV1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		sel_row = e.RowIndex;
		sel_col = e.ColumnIndex;
		if (DGV1.RowCount < 1 || !code.EnadleCellEvent)
		{
			return;
		}
		if ((e.RowIndex == -1 && e.ColumnIndex == -1) ? true : false)
		{
			DGV1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		}
		else
		{
			DGV1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		}
		if (sel_row > -1)
		{
			filename_inselitem = Conversions.ToString(DGV1[Col_Path.Index, sel_row].Value);
			cfgname_inselitem = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
		}
		if (!previewing)
		{
			previewing = true;
			if (sel_row > -1 && ((CConfigMng.Config.RowFollowdisplay && Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(MyProject.Forms.FrmPreview.Tag, MyProject.Forms.FrmPreview.Text), filename_inselitem + cfgname_inselitem, TextCompare: false)) ? true : false))
			{
				code.Preview2(CConfigMng.Config.DefaultDrw, filename_inselitem, cfgname_inselitem, this);
				preview_selrow = sel_row;
				Focus();
			}
			previewing = false;
		}
	}

	private void DGV1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if ((e.ColumnIndex == Col_Preview.Index) | (e.ColumnIndex == Col_Number.Index))
		{
			return;
		}
		SelectedCol = e.ColumnIndex;
		Point mousePosition = Control.MousePosition;
		bool flag = false;
		if ((e.RowIndex == -1 && e.ColumnIndex > -1) ? true : false)
		{
			Rectangle cellDisplayRectangle = DGV1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, cutOverflow: true);
			if (((double)e.X >= (double)cellDisplayRectangle.Width - 16.0 * dpixRatio && e.X <= cellDisplayRectangle.Width && (double)e.Y >= (double)cellDisplayRectangle.Height - 16.0 * dpixRatio && e.Y <= cellDisplayRectangle.Height) ? true : false)
			{
				flag = true;
			}
		}
		if (flag)
		{
			DGV1.EndEdit();
			GetFilterStatus();
			Filter_list.Show(mousePosition);
			Filter_list.Items[3].AutoSize = false;
			Filter_list.Items[3].Width = Clb.Width;
		}
	}

	private void DGV1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
	{
		if (code.EnadleCellEvent)
		{
			try
			{
				ColorRow();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
			}
			GetSelRowCount();
		}
	}

	private void DGV1_Paint(object sender, PaintEventArgs e)
	{
		try
		{
			DGV1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		try
		{
			addctl();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		try
		{
			if (DGV1.Columns[Col_Preview.Index].Visible)
			{
				PreviewSwitch1.Checked = true;
			}
			else
			{
				PreviewSwitch1.Checked = false;
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ProjectData.ClearProjectError();
		}
		try
		{
			DGV1.Columns[Convert.ToInt32(CConfigMng.Config.FrozenCol)].Frozen = true;
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ProjectData.ClearProjectError();
		}
		try
		{
			if (((DGV1.CurrentRow.Index != preview_selrow) & !CConfigMng.Config.RowFollowdisplay) | (((IntPtr)code.previewformhwnd != Handle) & !CConfigMng.Config.RowFollowdisplay))
			{
				MyProject.Forms.FrmPreview.Close();
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ProjectData.ClearProjectError();
		}
	}

	private void DGV1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		e.Cancel = true;
	}

	private void ComboBox1_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left)
		{
			return;
		}
		Point mousePosition = Control.MousePosition;
		if (sel_col == Col_Material.Index)
		{
			GetMaterialName();
			Material_list.Show(ComboBox1, 0, ComboBox1.Height);
		}
		else if (DGV1.Columns[sel_col].Name.Contains("PropVal_") || ((sel_col == Col_Comment.Index) ? true : false))
		{
			setpropdownlist(Multiline: true);
			Prop_Downlist.Show(ComboBox1, 0, ComboBox1.Height);
		}
		else if ((sel_col == Col_Author.Index || sel_col == Col_Keywords.Index || sel_col == Col_Title.Index || sel_col == Col_Subject.Index) ? true : false)
		{
			setpropdownlist();
			Prop_Downlist.Show(ComboBox1, 0, ComboBox1.Height);
		}
		else if (sel_col == Col_Cfg.Index)
		{
			if (selcount == 1)
			{
				SetCfgRenamelist2();
			}
			else
			{
				SetCfgRenamelist();
			}
			CfgRename_list.Show(ComboBox1, 0, ComboBox1.Height);
		}
		else if (sel_col == Col_partnumber.Index)
		{
			setpartnumbersetting();
			partnumbersetting.Show(ComboBox1, 0, ComboBox1.Height);
		}
	}

	private void DGV1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		e.Control.ContextMenuStrip = DGV_Menulist;
	}

	private void DGV1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
	{
		try
		{
			if (code.EnablePreview && e.RowIndex >= 0 && e.ColumnIndex >= 0 && 0 == 0 && e.Button == MouseButtons.Right)
			{
				Point mousePosition = Control.MousePosition;
				DGV1.CurrentCell = DGV1[e.ColumnIndex, e.RowIndex];
				if (Setmenulist())
				{
					DGV_Menulist.Show(mousePosition);
				}
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

	private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex < 0)
		{
			return;
		}
		string text = filename_inselitem;
		string cfgname = cfgname_inselitem;
		string text2 = code.SplitStr(text, 3) + ".SLDDRW";
		if ((sel_col == Col_Extname.Index) & CConfigMng.Config.DClick_OpenInSw)
		{
			if (File.Exists(text))
			{
				Thread thread = new Thread(_Lambda_0024__89);
				thread.Start(text);
			}
		}
		else if ((sel_col == Col_Drw.Index) & CConfigMng.Config.DClick_OpenInSw)
		{
			if (File.Exists(text2))
			{
				Thread thread2 = new Thread(_Lambda_0024__90);
				thread2.Start(text2);
			}
			else if (MessageBox.Show(this, "Чертежа нет, создать?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				NewDrw(text, cfgname, text2);
			}
		}
		else if ((sel_col == Col_NewFolder.Index) & DGV1.Columns[sel_col].Visible)
		{
			MyProject.Forms.FrmSetNewFolder.ShowDialog(this);
		}
	}

	public bool Setmenulist()
	{
		DGV_Menulist.Items.Clear();
		string text = filename_inselitem;
		string cfgname = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
		string path = code.SplitStr(text, 3) + ".SLDDRW";
		string text2 = "";
		Image image = Resources.sldprt;
		if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			text2 = "Открыть сборку (&W)";
			image = Resources.sldasm;
		}
		else if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
		{
			text2 = "Открыть деталь (&W)";
			image = Resources.sldprt;
		}
		int displayInBOM = GetDisplayInBOM(text, cfgname);
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Скрыть");
		toolStripMenuItem.Checked = Conversions.ToBoolean(Interaction.IIf(displayInBOM == 1, true, false));
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Повысить");
		toolStripMenuItem2.Checked = Conversions.ToBoolean(Interaction.IIf(displayInBOM == 3, true, false));
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Показать");
		toolStripMenuItem3.Checked = Conversions.ToBoolean(Interaction.IIf(displayInBOM == 2, true, false));
		ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
		if (!code.RunSW())
		{
			return false;
		}
		bool visible = Conversions.ToBoolean(Interaction.IIf(Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Level.Index, sel_row].Value, 0, TextCompare: false), true, false));
		ToolStripMenuItem[] array = new ToolStripMenuItem[19]
		{
			new ToolStripMenuItem(text2),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		array[0].Image = image;
		array[1] = new ToolStripMenuItem("Открыть чертёж (&D)");
		array[1].Image = Resources.slddrw;
		array[1].Enabled = File.Exists(path);
		array[2] = new ToolStripMenuItem("Показать в папке (&F)");
		array[2].Image = Resources.folder_vertical_24px;
		array[3] = new ToolStripMenuItem("Выбрать в SolidWorks");
		array[3].Visible = Conversions.ToBoolean(Interaction.IIf((GetDataOption == 0 || GetDataOption == 1) ? true : false, true, false));
		array[4] = new ToolStripMenuItem("Создать чертёж (множественный выбор)");
		string expression = Conversions.ToString(NewLateBinding.LateGet(code.swApp, null, "GetUserPreferenceStringValue", new object[1] { 6 }, null, null, null));
		string[] array2 = Strings.Split(expression, ";");
		checked
		{
			if (array2.Length > 1)
			{
				int num = array2.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if ((Operators.CompareString(Strings.Right(array2[num2], 1), "\\", TextCompare: false) == 0) | (Operators.CompareString(Strings.Right(array2[num2], 1), "/", TextCompare: false) == 0))
					{
						array2[num2] = Strings.Left(array2[num2], Strings.Len(array2[num2]) - 1);
					}
					ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem(code.SplitStr(array2[num2], 1));
					List<string> list = new List<string>();
					code.SearchFiles(list, array2[num2] + "\\", "*.drwdot", @bool: false);
					if (list.Count >= 1)
					{
						int num5 = list.Count - 1;
						int num6 = 0;
						while (true)
						{
							int num7 = num6;
							num4 = num5;
							if (num7 > num4)
							{
								break;
							}
							ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(code.SplitStr(list[num6], 1));
							toolStripMenuItem5.Tag = list[num6];
							toolStripMenuItem4.DropDownItems.Add(toolStripMenuItem5);
							num6++;
						}
						toolStripMenuItem4.DropDownItemClicked += c_tsm_Click;
						array[4].DropDownItems.Add(toolStripMenuItem4);
					}
					num2++;
				}
			}
			else if (array2.Length == 1)
			{
				if ((Operators.CompareString(Strings.Right(array2[0], 1), "\\", TextCompare: false) == 0) | (Operators.CompareString(Strings.Right(array2[0], 1), "/", TextCompare: false) == 0))
				{
					array2[0] = Strings.Left(array2[0], Strings.Len(array2[0]) - 1);
				}
				List<string> list2 = new List<string>();
				code.SearchFiles(list2, array2[0] + "\\", "*.drwdot", @bool: false);
				if (list2.Count >= 1)
				{
					int num8 = list2.Count - 1;
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						int num4 = num8;
						if (num10 > num4)
						{
							break;
						}
						ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(code.SplitStr(list2[num9], 1));
						toolStripMenuItem6.Tag = list2[num9];
						array[4].DropDownItems.Add(toolStripMenuItem6);
						num9++;
					}
					array[4].DropDownItemClicked += c_tsm_Click;
				}
			}
			array[5] = new ToolStripMenuItem("Удалить чертёж (множественный выбор)");
			array[5].Enabled = File.Exists(path);
			array[6] = new ToolStripMenuItem("Копировать чертёж");
			array[6].Enabled = File.Exists(path);
			array[7] = new ToolStripMenuItem("Вставить чертёж");
			array[7].Enabled = File.Exists(obj_drw_copy.drwname);
			bool enabled = topdocisopen(Conversions.ToString(DGV1.Tag));
			array[8] = new ToolStripMenuItem("Погасить компоненты (&S)");
			array[8].ToolTipText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Сначала откройте", DGV1.Tag), " для активации"));
			array[8].Enabled = enabled;
			array[8].Visible = visible;
			array[9] = new ToolStripMenuItem("Высветить (&U)");
			array[9].ToolTipText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Сначала откройте", DGV1.Tag), " для активации"));
			array[9].Enabled = enabled;
			array[9].Visible = visible;
			array[10] = new ToolStripMenuItem("Исключить из спецификации (&E)");
			array[10].ToolTipText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Сначала откройте", DGV1.Tag), " для активации"));
			array[10].Enabled = enabled;
			array[10].Visible = visible;
			array[11] = new ToolStripMenuItem("Включить в спецификацию (&I)");
			array[11].ToolTipText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Сначала откройте", DGV1.Tag), " для активации"));
			array[11].Enabled = enabled;
			array[11].Visible = visible;
			array[12] = new ToolStripMenuItem("Отображение подкомпонентов при использовании в качестве подсборки");
			if (displayInBOM == 0)
			{
				array[12].ToolTipText = "Текущий элемент недоступен";
				array[12].Enabled = false;
			}
			array[12].DropDownItemClicked += mens11_DropDownItemClicked;
			array[12].Visible = Conversions.ToBoolean(Interaction.IIf(text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase), true, false));
			array[12].DropDownItems.Add(toolStripMenuItem3);
			array[12].DropDownItems.Add(toolStripMenuItem);
			array[12].DropDownItems.Add(toolStripMenuItem2);
			array[13] = new ToolStripMenuItem("Пакетное копирование (&C)");
			array[13].ToolTipText = "Только операции с одним столбцом";
			array[13].Visible = Conversions.ToBoolean(Interaction.IIf(DGV1.Columns[sel_col] is DataGridViewTextBoxColumn, true, false));
			array[14] = new ToolStripMenuItem("Пакетная вставка (&V)");
			array[14].ToolTipText = "Только операции с одним столбцом";
			array[14].Visible = Conversions.ToBoolean(Interaction.IIf((!DGV1.Columns[sel_col].ReadOnly && DGV1.Columns[sel_col] is DataGridViewTextBoxColumn) ? true : false, true, false));
			array[15] = new ToolStripMenuItem("Активировать и сохранить компонент (множественный выбор)");
			array[15].ToolTipText = "Подходит для компонентов без отображения эскиза или требующих сохранения";
			array[15].Image = Resources.save_24px;
			array[16] = new ToolStripMenuItem("Отметить связанные узлы (множественный выбор)");
			array[16].ToolTipText = "Отметить связанные узлы";
			array[16].Visible = Conversions.ToBoolean(Interaction.IIf((GetDataOption == 0 || GetDataOption == 1) ? true : false, true, false));
			array[17] = new ToolStripMenuItem("Выполнить макрос (множественный выбор)");
			array[17].ToolTipText = "Выполнить макрос SolidWorks для выбранных элементов";
			array[17].DropDownItemClicked += mens17_DropDownItemClicked;
			int num11 = CConfigMng.Config.macrolist.Count - 1;
			int num12 = 0;
			while (true)
			{
				int num13 = num12;
				int num4 = num11;
				if (num13 > num4)
				{
					break;
				}
				if (CConfigMng.Config.macrolist[num12].EndsWith(".swp", StringComparison.OrdinalIgnoreCase) || (CConfigMng.Config.macrolist[num12].EndsWith(".swb", StringComparison.OrdinalIgnoreCase) ? true : false))
				{
					ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem(code.SplitStr(CConfigMng.Config.macrolist[num12], 4));
					toolStripMenuItem7.Tag = CConfigMng.Config.macrolist[num12];
					array[17].DropDownItems.Add(toolStripMenuItem7);
				}
				num12++;
			}
			array[18] = new ToolStripMenuItem("Скрыть строки (множественный выбор) (&H)");
			DGV_Menulist.Items.AddRange(array);
			DGV_Menulist.Items.Insert(4, new ToolStripSeparator());
			DGV_Menulist.Items.Insert(9, new ToolStripSeparator());
			DGV_Menulist.Items.Insert(15, new ToolStripSeparator());
			DGV_Menulist.Items.Insert(18, new ToolStripSeparator());
			DGV_Menulist.Items.Insert(20, new ToolStripSeparator());
			return true;
		}
	}

	public void c_tsm_Click(object sender, ToolStripItemClickedEventArgs e)
	{
		string tempName = Conversions.ToString(e.ClickedItem.Tag);
		DGV_Menulist.Close();
		if (!code.RunSW())
		{
			return;
		}
		checked
		{
			try
			{
				Dictionary<int, string> dictionary = getselpathname();
				if (dictionary.Count > 1)
				{
					DGV1.Enabled = false;
					code.StartSwitch(status: true);
					StatusLabel1.Text = "Создание чертежа...";
					IsStop.Visible = true;
					ToolStripProgressBar1.Maximum = dictionary.Count - 1;
					ToolStripProgressBar1.Visible = true;
				}
				int num = dictionary.Count - 1;
				int num2 = 0;
				int num5 = default(int);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string value = dictionary.ElementAt(num2).Value;
					string text = code.SplitStr(value, 3) + ".SLDDRW";
					int key = dictionary.ElementAt(num2).Key;
					string cfgname = Conversions.ToString(DGV1[Col_Cfg.Index, key].Value);
					if (dictionary.Count > 1)
					{
						Application.DoEvents();
						if (code.Dostop)
						{
							break;
						}
						ToolStripProgressBar1.Value = num2;
						string err = "";
						NewDrw2(value, cfgname, text, tempName, ref err, num5);
						if (err.Length > 0)
						{
							MyProject.Forms.Frmtips.additem(num5, Conversions.ToString(DGV1[Col_Number.Index, key].Value), err, "Создать чертёж", value);
						}
					}
					else
					{
						NewDrw(value, cfgname, text, tempName);
					}
					if (File.Exists(text))
					{
						DGV1[Col_Drw.Index, key].Tag = "Есть";
						DGV1[Col_Drw.Index, key].Value = Resources.slddrw;
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
			finally
			{
				DGV1.Enabled = true;
				StatusLabel1.Text = "Всего сейчас" + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
				IsStop.Visible = false;
				ToolStripProgressBar1.Visible = false;
				ToolStripProgressBar1.Value = 0;
			}
		}
	}

	public void mens11_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		DGV_Menulist.Close();
		int val = 0;
		switch (e.ClickedItem.Text)
		{
		case "Показать":
			val = 2;
			break;
		case "Скрыть":
			val = 1;
			break;
		case "Повысить":
			val = 3;
			break;
		}
		string curModelName = filename_inselitem;
		string cfgname = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
		setdisplayinbom(curModelName, cfgname, val);
	}

	public void mens17_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		DGV_Menulist.Close();
		string text = Conversions.ToString(e.ClickedItem.Tag);
		if ((!text.EndsWith(".swb", StringComparison.OrdinalIgnoreCase) && !text.EndsWith(".swp", StringComparison.OrdinalIgnoreCase)) ? true : false)
		{
			MessageBox.Show(this, "Недопустимый файл макроса", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		if (!File.Exists(text))
		{
			MessageBox.Show(this, "Файл макроса " + text + " не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		checked
		{
			try
			{
				Dictionary<int, string> dictionary = getselpathname();
				if (dictionary.Count <= 0)
				{
					return;
				}
				DGV1.Enabled = false;
				code.StartSwitch(status: true);
				StatusLabel1.Text = "Выполнение макроса...";
				IsStop.Visible = true;
				ToolStripProgressBar1.Maximum = dictionary.Count - 1;
				ToolStripProgressBar1.Visible = true;
				int num = dictionary.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						Application.DoEvents();
						if (code.Dostop)
						{
							break;
						}
						ToolStripProgressBar1.Value = num2;
						code.executemacro(text, dictionary.ElementAt(num2).Value);
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
			finally
			{
				DGV1.Enabled = true;
				ToolStripProgressBar1.Visible = false;
				ToolStripProgressBar1.Value = 0;
				StatusLabel1.Text = "Всего сейчас" + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
				IsStop.Visible = false;
			}
		}
	}

	public int GetDisplayInBOM(string CurModelName, string cfgname)
	{
		int result = 0;
		try
		{
			if (!CurModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				return 0;
			}
			if (!code.RunSW())
			{
				return 0;
			}
			if (CurModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				int num = 1;
			}
			if (CurModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				int num = 2;
			}
			if (CurModelName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				int num = 3;
			}
			bool flag = false;
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetOpenDocument", new object[1] { DGV1.Tag.ToString() }, null, null, null));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				flag = true;
				objectValue = null;
			}
			object swApp = code.swApp;
			object[] array = new object[1] { CurModelName };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(swApp, null, "GetOpenDocument", arguments, null, null, array2);
			if (array2[0])
			{
				CurModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				return 0;
			}
			bool flag2 = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue2, null, "Visible", new object[0], null, null, null));
			object instance = objectValue2;
			object[] array3 = new object[1] { cfgname };
			object[] arguments2 = array3;
			array2 = new bool[1] { true };
			NewLateBinding.LateCall(instance, null, "ShowConfiguration2", arguments2, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object instance2 = objectValue2;
			array3 = new object[1] { cfgname };
			object[] arguments3 = array3;
			array2 = new bool[1] { true };
			object obj2 = NewLateBinding.LateGet(instance2, null, "GetConfigurationByName", arguments3, null, null, array2);
			if (array2[0])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object objectValue3 = RuntimeHelpers.GetObjectValue(obj2);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
			{
				result = Conversions.ToInteger(NewLateBinding.LateGet(objectValue3, null, "ChildComponentDisplayInBOM", new object[0], null, null, null));
			}
			objectValue2 = null;
			if (!flag2 && flag)
			{
				object swApp2 = code.swApp;
				array3 = new object[1] { CurModelName };
				object[] arguments4 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(swApp2, null, "closedoc", arguments4, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					CurModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
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
		return result;
	}

	private void DGV_Menulist_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		string text = filename_inselitem;
		string text2 = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
		string text3 = code.SplitStr(text, 3) + ".SLDDRW";
		int num = Conversions.ToInteger(DGV1[Col_Number.Index, sel_row].Value);
		int num2 = 0;
		if ((Operators.CompareString(e.ClickedItem.Text, "Открыть деталь (&W)", TextCompare: false) == 0) | (Operators.CompareString(e.ClickedItem.Text, "Открыть сборку (&W)", TextCompare: false) == 0))
		{
			if (File.Exists(text))
			{
				DGV_Menulist.Close();
				code.OpenDoc(text, text2);
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Открыть чертёж (&D)", TextCompare: false) == 0)
		{
			if (File.Exists(text3))
			{
				DGV_Menulist.Close();
				code.OpenDoc(text3);
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Показать в папке (&F)", TextCompare: false) == 0)
		{
			Interaction.Shell("explorer.exe /select," + text, AppWinStyle.NormalFocus);
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Выбрать в SolidWorks", TextCompare: false) == 0)
		{
			try
			{
				DGV_Menulist.Close();
				Treenode result = new Treenode();
				getnodebypath(TV1.Nodes, text, text2, ref result);
				string text4 = getnodidstring(result);
				if (Operators.CompareString(text4, "", TextCompare: false) != 0)
				{
					code.selectbyinstring(text4);
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
				return;
			}
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Создать чертёж (множественный выбор)", TextCompare: false) == 0)
		{
			return;
		}
		checked
		{
			if (Operators.CompareString(e.ClickedItem.Text, "Удалить чертёж (множественный выбор)", TextCompare: false) == 0)
			{
				DGV_Menulist.Close();
				Dictionary<int, string> dictionary = getselpathname();
				if ((dictionary.Count > 0 && MessageBox.Show(this, "Подтвердите удаление?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) ? true : false)
				{
					return;
				}
				int num3 = dictionary.Count - 1;
				int num4 = 0;
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					string file = code.SplitStr(dictionary.ElementAt(num4).Value, 3) + ".SLDDRW";
					try
					{
						MyProject.Computer.FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ProjectData.ClearProjectError();
					}
					num4++;
				}
				ReadonlyRowMark();
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Копировать чертёж", TextCompare: false) == 0)
			{
				obj_drw_copy.drwname = text3;
				obj_drw_copy.modelname = text;
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Вставить чертёж", TextCompare: false) == 0)
			{
				DGV_Menulist.Close();
				copydrw(text);
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Погасить компоненты (&S)", TextCompare: false) == 0)
			{
				Setcomponentstate(Conversions.ToString(DGV1.Tag), text, text2, 1);
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Высветить (&U)", TextCompare: false) == 0)
			{
				Setcomponentstate(Conversions.ToString(DGV1.Tag), text, text2, 2);
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Исключить из спецификации (&E)", TextCompare: false) == 0)
			{
				Setcomponentstate(Conversions.ToString(DGV1.Tag), text, text2, 3);
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Включить в спецификацию (&I)", TextCompare: false) == 0)
			{
				Setcomponentstate(Conversions.ToString(DGV1.Tag), text, text2, 4);
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Скрыть строки (множественный выбор) (&H)", TextCompare: false) == 0)
			{
				int num7 = DGV1.RowCount - 1;
				int num8 = 0;
				while (true)
				{
					int num9 = num8;
					int num6 = num7;
					if (num9 > num6)
					{
						break;
					}
					if (!DGV1.Rows[num8].Visible)
					{
						DGV1[Col_Checkbox.Index, num8].Value = true;
					}
					else
					{
						DGV1[Col_Checkbox.Index, num8].Value = false;
					}
					num8++;
				}
				if (DGV1.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
				{
					foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
					{
						DGV1[Col_Checkbox.Index, selectedCell.RowIndex].Value = true;
					}
				}
				else
				{
					foreach (DataGridViewRow selectedRow in DGV1.SelectedRows)
					{
						DGV1[Col_Checkbox.Index, selectedRow.Index].Value = true;
					}
				}
				filter_checkbox(Excluded: true);
				int rowCount = DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible);
				if (sel_row < rowCount)
				{
					int num10 = sel_row;
					int num11 = rowCount;
					int num12 = num10;
					while (true)
					{
						int num13 = num12;
						int num6 = num11;
						if (num13 <= num6)
						{
							if (DGV1.Rows[num12].Visible)
							{
								DGV1.Rows[num12].Selected = true;
								break;
							}
							num12++;
							continue;
						}
						break;
					}
					return;
				}
				int num14 = sel_row;
				while (true)
				{
					int num15 = num14;
					int num6 = 0;
					if (num15 >= num6)
					{
						if (DGV1.Rows[num14].Visible)
						{
							DGV1.Rows[num14].Selected = true;
							break;
						}
						num14 += -1;
						continue;
					}
					break;
				}
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Пакетное копирование (&C)", TextCompare: false) == 0)
			{
				DGV_Menulist.Close();
				copycell();
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Пакетная вставка (&V)", TextCompare: false) == 0)
			{
				DGV_Menulist.Close();
				code.PasteExcel(DGV1);
				return;
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Активировать и сохранить компонент (множественный выбор)", TextCompare: false) == 0)
			{
				DGV_Menulist.Close();
				try
				{
					Dictionary<int, string> dictionary2 = getselpathname();
					if (dictionary2.Count <= 0)
					{
						return;
					}
					code.StartSwitch(status: true);
					DGV1.Enabled = false;
					StatusLabel1.Text = "Активация и сохранение этого компонента...";
					IsStop.Visible = true;
					ToolStripProgressBar1.Maximum = dictionary2.Count - 1;
					ToolStripProgressBar1.Visible = true;
					int num16 = dictionary2.Count - 1;
					int num17 = 0;
					while (true)
					{
						int num18 = num17;
						int num6 = num16;
						if (num18 <= num6)
						{
							Application.DoEvents();
							if (code.Dostop)
							{
								break;
							}
							ToolStripProgressBar1.Value = num17;
							code.SaveDoc(dictionary2.ElementAt(num17).Value);
							code.RefreshPic(dictionary2.ElementAt(num17).Key);
							num17++;
							continue;
						}
						break;
					}
					return;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
					return;
				}
				finally
				{
					DGV1.Enabled = true;
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					StatusLabel1.Text = "Всего сейчас" + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
					IsStop.Visible = false;
				}
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Отметить связанные узлы (множественный выбор)", TextCompare: false) == 0)
			{
				DGV_Menulist.Close();
				try
				{
					TV1.BeginUpdate();
					TV1.CollapseAll();
					TV1.TopNode.Expand();
					TV1.SelectedNodes.Clear();
					foreach (DataGridViewCell selectedCell2 in DGV1.SelectedCells)
					{
						if (selectedCell2.ColumnIndex == sel_col)
						{
							string pathname = Conversions.ToString(DGV1[Col_Path.Index, selectedCell2.RowIndex].Value);
							string cfgname = Conversions.ToString(DGV1[Col_Cfg.Index, selectedCell2.RowIndex].Value);
							selectnode(TV1.Nodes, pathname, cfgname);
						}
					}
					TV1.EndUpdate();
					TV1.Invalidate();
					return;
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(e.ClickedItem.Text, "Выполнить макрос (множественный выбор)", TextCompare: false) != 0)
			{
			}
		}
	}

	public void copydrw(string ModelName)
	{
		checked
		{
			try
			{
				if (!File.Exists(obj_drw_copy.drwname))
				{
					MessageBox.Show(this, "Исходный чертёж не существует или нет доступа к его папке", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (!File.Exists(ModelName))
				{
					MessageBox.Show(this, "Текущая модель не существует или нет доступа к её папке", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				string text = code.SplitStr(ModelName, 3) + ".SLDDRW";
				bool flag = false;
				if (File.Exists(text))
				{
					flag = true;
					if (MessageBox.Show(this, "Чертёж уже существует, перезаписать?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						return;
					}
				}
				File.Copy(obj_drw_copy.drwname, text, overwrite: true);
				if (File.Exists(text))
				{
					File.SetAttributes(text, FileAttributes.Normal);
					if (!code.RunSW())
					{
						return;
					}
					object swApp = code.swApp;
					object[] array = new object[3] { text, obj_drw_copy.modelname, ModelName };
					bool[] array2 = new bool[3] { true, true, true };
					object value = NewLateBinding.LateGet(swApp, null, "ReplaceReferencedDocument", array, null, null, array2);
					if (array2[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					if (array2[1])
					{
						obj_drw_copy.modelname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
					}
					if (array2[2])
					{
						ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(string));
					}
					bool flag2 = Conversions.ToBoolean(value);
					code.swApp = null;
					if (!flag2)
					{
						MessageBox.Show(this, "Не удалось обновить ссылки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show(this, "Ошибка копирования! Проверьте наличие исходного файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						if (Operators.ConditionalCompareObjectEqual(DGV1[Col_Path.Index, num2].Value, ModelName, TextCompare: false))
						{
							DGV1[Col_Drw.Index, num2].Tag = "Есть";
							DGV1[Col_Drw.Index, num2].Value = Resources.slddrw;
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
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show("Ошибка при копировании чертежа:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void NewDrw(string ModelName, string cfgname, string DrwName, string TempName = "")
	{
		bool flag = true;
		try
		{
			if (File.Exists(DrwName))
			{
				flag = false;
				if (MessageBox.Show(this, "Чертёж уже существует, открыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					code.OpenDoc(DrwName);
					return;
				}
			}
			if (!code.RunSW())
			{
				return;
			}
			if (Operators.CompareString(TempName, "", TextCompare: false) == 0)
			{
				TempName = Conversions.ToString(NewLateBinding.LateGet(code.swApp, null, "GetUserPreferenceStringValue", new object[1] { 10 }, null, null, null));
				if (!File.Exists(TempName))
				{
					MessageBox.Show(this, "Сначала задайте шаблон чертежа по умолчанию в параметрах SolidWorks", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			bool flag2 = false;
			int num = default(int);
			if (ModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			if (ModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			if (ModelName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			object swApp = code.swApp;
			object[] array = new object[1] { ModelName };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(swApp, null, "GetOpenDocument", arguments, null, null, array2);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue = RuntimeHelpers.GetObjectValue(obj);
			object[] array3;
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				object swApp2 = code.swApp;
				int num2 = default(int);
				int num3 = default(int);
				array3 = new object[6] { ModelName, num, 1, cfgname, num2, num3 };
				object[] arguments2 = array3;
				array2 = new bool[6] { true, true, false, true, true, true };
				object obj2 = NewLateBinding.LateGet(swApp2, null, "OpenDoc6", arguments2, null, null, array2);
				if (array2[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				if (array2[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
				}
				if (array2[3])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
				}
				if (array2[4])
				{
					num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[4]), typeof(int));
				}
				if (array2[5])
				{
					num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[5]), typeof(int));
				}
				objectValue = RuntimeHelpers.GetObjectValue(obj2);
			}
			else
			{
				flag2 = true;
				object instance = objectValue;
				array3 = new object[1] { cfgname };
				object[] arguments3 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance, null, "ShowConfiguration2", arguments3, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				MessageBox.Show(this, "Не удаётся открыть текущую модель!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			code.SetForegroundWindow_Custom(RuntimeHelpers.GetObjectValue(code.swApp));
			object swApp3 = code.swApp;
			array3 = new object[4] { TempName, 12, 0, 0 };
			object[] arguments4 = array3;
			array2 = new bool[4] { true, false, false, false };
			object obj3 = NewLateBinding.LateGet(swApp3, null, "NewDocument", arguments4, null, null, array2);
			if (array2[0])
			{
				TempName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj3);
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				return;
			}
			NewLateBinding.LateCall(objectValue2, null, "SetTitle2", new object[1] { code.SplitStr(DrwName, 4) }, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 86, true }, null, null, null, IgnoreReturn: true);
			object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "GetCurrentSheet", new object[0], null, null, null));
			object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "getviews", new object[0], null, null, null));
			object objectValue6;
			object value2;
			object[] array10;
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "GetProperties2", new object[0], null, null, null));
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue5, new object[1] { 4 }, null), 1, TextCompare: false))
				{
					object instance2 = objectValue2;
					object[] array4 = new object[1] { ModelName };
					object[] arguments5 = array4;
					array2 = new bool[1] { true };
					NewLateBinding.LateCall(instance2, null, "Create1stAngleViews2", arguments5, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue5, new object[1] { 4 }, null), 0, TextCompare: false))
				{
					object instance3 = objectValue2;
					array3 = new object[1] { ModelName };
					object[] arguments6 = array3;
					array2 = new bool[1] { true };
					NewLateBinding.LateCall(instance3, null, "Create3rdAngleViews2", arguments6, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
					}
				}
				objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "getviews", new object[0], null, null, null));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
				{
					objectValue6 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue4, new object[1] { 0 }, null));
					object objectValue7 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue6, null, "ScaleRatio", new object[0], null, null, null));
					if (Conversions.ToBoolean(!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue7))))
					{
						array3 = new object[4];
						object[] array5 = array3;
						object[] array4 = new object[1];
						object[] array6 = array4;
						int num4 = 0;
						array6[0] = num4;
						array5[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue7, array4, null));
						object[] array7 = array3;
						array = new object[1];
						object[] array8 = array;
						int num5 = 1;
						array8[0] = num5;
						array7[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue7, array, null));
						array3[2] = false;
						array3[3] = false;
						object[] array9 = array3;
						array2 = new bool[4] { true, true, false, false };
						object value = NewLateBinding.LateGet(objectValue3, null, "SetScale", array9, null, null, array2);
						if (array2[0])
						{
							NewLateBinding.LateIndexSetComplex(objectValue7, new object[2]
							{
								num4,
								RuntimeHelpers.GetObjectValue(array9[0])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (array2[1])
						{
							NewLateBinding.LateIndexSetComplex(objectValue7, new object[2]
							{
								num5,
								RuntimeHelpers.GetObjectValue(array9[1])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (Conversions.ToBoolean(value))
						{
							value2 = true;
							goto IL_07b0;
						}
					}
					value2 = false;
					goto IL_07b0;
				}
			}
			else
			{
				object instance4 = objectValue2;
				array10 = new object[1] { ModelName };
				object[] arguments7 = array10;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance4, null, "InsertModelInPredefinedView", arguments7, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
				}
			}
			goto IL_083e;
			IL_083e:
			object instance5 = objectValue2;
			array10 = new object[1] { ModelName };
			object[] arguments8 = array10;
			array2 = new bool[1] { true };
			NewLateBinding.LateCall(instance5, null, "GenerateViewPaletteViews", arguments8, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
			}
			if (flag)
			{
				object instance6 = objectValue2;
				array10 = new object[3] { DrwName, 0, 5 };
				object[] arguments9 = array10;
				array2 = new bool[3] { true, false, false };
				NewLateBinding.LateCall(instance6, null, "SaveAs3", arguments9, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					DrwName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
				}
			}
			if (!flag2)
			{
				object swApp4 = code.swApp;
				array10 = new object[1] { ModelName };
				object[] arguments10 = array10;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(swApp4, null, "CloseDoc", arguments10, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
				}
			}
			objectValue2 = null;
			objectValue = null;
			return;
			IL_07b0:
			if (Conversions.ToBoolean(value2))
			{
				NewLateBinding.LateSet(objectValue6, null, "UseSheetScale", new object[1] { true }, null, null);
			}
			goto IL_083e;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show("Ошибка при создании чертежа:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			code.swApp = null;
			ProjectData.ClearProjectError();
		}
	}

	public void NewDrw2(string ModelName, string cfgname, string DrwName, string TempName, ref string err, int warn)
	{
		try
		{
			if (File.Exists(DrwName))
			{
				err = "Для текущей модели чертёж уже существует!";
				warn = 0;
				return;
			}
			if (Operators.CompareString(TempName, "", TextCompare: false) == 0)
			{
				TempName = Conversions.ToString(NewLateBinding.LateGet(code.swApp, null, "GetUserPreferenceStringValue", new object[1] { 10 }, null, null, null));
				if (!File.Exists(TempName))
				{
					err = "Шаблон чертежа не найден!";
					warn = 1;
					return;
				}
			}
			bool flag = false;
			int num = default(int);
			if (ModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			if (ModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			if (ModelName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			object swApp = code.swApp;
			object[] array = new object[1] { ModelName };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(swApp, null, "GetOpenDocument", arguments, null, null, array2);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue = RuntimeHelpers.GetObjectValue(obj);
			object[] array3;
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				object swApp2 = code.swApp;
				int num2 = default(int);
				int num3 = default(int);
				array3 = new object[6] { ModelName, num, 1, cfgname, num2, num3 };
				object[] arguments2 = array3;
				array2 = new bool[6] { true, true, false, true, true, true };
				object obj2 = NewLateBinding.LateGet(swApp2, null, "OpenDoc6", arguments2, null, null, array2);
				if (array2[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				if (array2[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
				}
				if (array2[3])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
				}
				if (array2[4])
				{
					num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[4]), typeof(int));
				}
				if (array2[5])
				{
					num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[5]), typeof(int));
				}
				objectValue = RuntimeHelpers.GetObjectValue(obj2);
			}
			else
			{
				flag = true;
				object instance = objectValue;
				array3 = new object[1] { cfgname };
				object[] arguments3 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance, null, "ShowConfiguration2", arguments3, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				err = "Не удаётся открыть текущую модель!";
				warn = 1;
				return;
			}
			object swApp3 = code.swApp;
			array3 = new object[4] { TempName, 12, 0, 0 };
			object[] arguments4 = array3;
			array2 = new bool[4] { true, false, false, false };
			object obj3 = NewLateBinding.LateGet(swApp3, null, "NewDocument", arguments4, null, null, array2);
			if (array2[0])
			{
				TempName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj3);
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				return;
			}
			NewLateBinding.LateCall(objectValue2, null, "SetTitle2", new object[1] { code.SplitStr(DrwName, 4) }, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(code.swApp, null, "SetUserPreferenceToggle", new object[2] { 86, true }, null, null, null, IgnoreReturn: true);
			object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "GetCurrentSheet", new object[0], null, null, null));
			object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "getviews", new object[0], null, null, null));
			object objectValue6;
			object value2;
			object[] array10;
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "GetProperties2", new object[0], null, null, null));
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue5, new object[1] { 4 }, null), 1, TextCompare: false))
				{
					object instance2 = objectValue2;
					object[] array4 = new object[1] { ModelName };
					object[] arguments5 = array4;
					array2 = new bool[1] { true };
					NewLateBinding.LateCall(instance2, null, "Create1stAngleViews2", arguments5, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue5, new object[1] { 4 }, null), 0, TextCompare: false))
				{
					object instance3 = objectValue2;
					array3 = new object[1] { ModelName };
					object[] arguments6 = array3;
					array2 = new bool[1] { true };
					NewLateBinding.LateCall(instance3, null, "Create3rdAngleViews2", arguments6, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
					}
				}
				objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "getviews", new object[0], null, null, null));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
				{
					objectValue6 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue4, new object[1] { 0 }, null));
					object objectValue7 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue6, null, "ScaleRatio", new object[0], null, null, null));
					if (Conversions.ToBoolean(!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue7))))
					{
						array3 = new object[4];
						object[] array5 = array3;
						object[] array4 = new object[1];
						object[] array6 = array4;
						int num4 = 0;
						array6[0] = num4;
						array5[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue7, array4, null));
						object[] array7 = array3;
						array = new object[1];
						object[] array8 = array;
						int num5 = 1;
						array8[0] = num5;
						array7[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue7, array, null));
						array3[2] = false;
						array3[3] = false;
						object[] array9 = array3;
						array2 = new bool[4] { true, true, false, false };
						object value = NewLateBinding.LateGet(objectValue3, null, "SetScale", array9, null, null, array2);
						if (array2[0])
						{
							NewLateBinding.LateIndexSetComplex(objectValue7, new object[2]
							{
								num4,
								RuntimeHelpers.GetObjectValue(array9[0])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (array2[1])
						{
							NewLateBinding.LateIndexSetComplex(objectValue7, new object[2]
							{
								num5,
								RuntimeHelpers.GetObjectValue(array9[1])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (Conversions.ToBoolean(value))
						{
							value2 = true;
							goto IL_0751;
						}
					}
					value2 = false;
					goto IL_0751;
				}
			}
			else
			{
				object instance4 = objectValue2;
				array10 = new object[1] { ModelName };
				object[] arguments7 = array10;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance4, null, "InsertModelInPredefinedView", arguments7, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
				}
			}
			goto IL_07df;
			IL_0751:
			if (Conversions.ToBoolean(value2))
			{
				NewLateBinding.LateSet(objectValue6, null, "UseSheetScale", new object[1] { true }, null, null);
			}
			goto IL_07df;
			IL_07df:
			object instance5 = objectValue2;
			array10 = new object[1] { ModelName };
			object[] arguments8 = array10;
			array2 = new bool[1] { true };
			NewLateBinding.LateCall(instance5, null, "GenerateViewPaletteViews", arguments8, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
			}
			object instance6 = objectValue2;
			array10 = new object[3] { DrwName, 0, 5 };
			object[] arguments9 = array10;
			array2 = new bool[3] { true, false, false };
			NewLateBinding.LateCall(instance6, null, "SaveAs3", arguments9, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				DrwName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
			}
			object swApp4 = code.swApp;
			array10 = new object[1] { DrwName };
			object[] arguments10 = array10;
			array2 = new bool[1] { true };
			NewLateBinding.LateCall(swApp4, null, "CloseDoc", arguments10, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				DrwName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
			}
			if (!flag)
			{
				object swApp5 = code.swApp;
				array10 = new object[1] { ModelName };
				object[] arguments11 = array10;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(swApp5, null, "CloseDoc", arguments11, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10[0]), typeof(string));
				}
			}
			objectValue2 = null;
			objectValue = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			err = ex2.Message;
			warn = 1;
			ProjectData.ClearProjectError();
		}
	}

	public bool topdocisopen(string topname)
	{
		if (!code.RunSW())
		{
			return false;
		}
		if (!topname.EndsWith("SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		object swApp = code.swApp;
		object[] array = new object[1] { topname };
		bool[] array2 = new bool[1] { true };
		object obj = NewLateBinding.LateGet(swApp, null, "GetOpenDocumentByName", array, null, null, array2);
		if (array2[0])
		{
			topname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
		}
		object objectValue = RuntimeHelpers.GetObjectValue(obj);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return false;
		}
		object objectValue2 = RuntimeHelpers.GetObjectValue(objectValue);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
		{
			return false;
		}
		return true;
	}

	public void Setcomponentstate(string topname, string Cname, string CfgName, int n)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
			stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
			stringBuilder.AppendLine(code.togetherConfig.ToString());
			stringBuilder.AppendLine(topname);
			stringBuilder.AppendLine(Cname);
			stringBuilder.AppendLine(CfgName);
			stringBuilder.AppendLine(Conversions.ToString(n));
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 40;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void setdisplayinbom(string CurModelName, string cfgname, int val)
	{
		try
		{
			if (!CurModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase) || !code.RunSW())
			{
				return;
			}
			int num = default(int);
			if (CurModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			if (CurModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			if (CurModelName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			bool flag = false;
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetOpenDocument", new object[1] { DGV1.Tag.ToString() }, null, null, null));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				flag = true;
			}
			object swApp = code.swApp;
			object[] array = new object[1] { CurModelName };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(swApp, null, "GetOpenDocument", arguments, null, null, array2);
			if (array2[0])
			{
				CurModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
			bool flag2;
			object[] array3;
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				flag2 = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue2, null, "Visible", new object[0], null, null, null));
			}
			else
			{
				object swApp2 = code.swApp;
				array3 = new object[2] { CurModelName, num };
				object[] arguments2 = array3;
				array2 = new bool[2] { true, true };
				object obj2 = NewLateBinding.LateGet(swApp2, null, "OpenDoc", arguments2, null, null, array2);
				if (array2[0])
				{
					CurModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				if (array2[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
				}
				objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
				flag2 = false;
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				return;
			}
			object instance = objectValue2;
			array3 = new object[1] { cfgname };
			object[] arguments3 = array3;
			array2 = new bool[1] { true };
			object obj3 = NewLateBinding.LateGet(instance, null, "GetConfigurationByName", arguments3, null, null, array2);
			if (array2[0])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object objectValue3 = RuntimeHelpers.GetObjectValue(obj3);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
			{
				NewLateBinding.LateSet(objectValue3, null, "ChildComponentDisplayInBOM", new object[1] { val }, null, null);
			}
			object instance2 = objectValue2;
			array3 = new object[3] { CurModelName, 0, 1 };
			object[] arguments4 = array3;
			array2 = new bool[3] { true, false, false };
			NewLateBinding.LateCall(instance2, null, "SaveAs3", arguments4, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				CurModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				NewLateBinding.LateCall(objectValue, null, "EditRebuild3", new object[0], null, null, null, IgnoreReturn: true);
				objectValue = null;
			}
			objectValue2 = null;
			if (!flag2 && flag)
			{
				object swApp3 = code.swApp;
				array3 = new object[1] { CurModelName };
				object[] arguments5 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(swApp3, null, "closedoc", arguments5, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					CurModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
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

	public Dictionary<int, string> getselpathname()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		try
		{
			if (DGV1.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
			{
				foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
				{
					string value = Conversions.ToString(DGV1[Col_Path.Index, selectedCell.RowIndex].Value);
					if ((!dictionary.ContainsValue(value) && selectedCell.Visible) ? true : false)
					{
						dictionary.Add(selectedCell.RowIndex, value);
					}
				}
			}
			else
			{
				foreach (DataGridViewRow selectedRow in DGV1.SelectedRows)
				{
					string value2 = Conversions.ToString(DGV1[Col_Path.Index, selectedRow.Index].Value);
					if ((!dictionary.ContainsValue(value2) && selectedRow.Visible) ? true : false)
					{
						dictionary.Add(selectedRow.Index, value2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return dictionary;
	}

	private void copycell()
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<string> list = new List<string>();
		if (DGV1.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
		{
			foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
			{
				if ((selectedCell.ColumnIndex == sel_col && selectedCell.Visible && DGV1.Columns[sel_col] is DataGridViewTextBoxColumn) ? true : false)
				{
					list.Add(Conversions.ToString(selectedCell.Value));
				}
			}
		}
		else
		{
			foreach (DataGridViewRow selectedRow in DGV1.SelectedRows)
			{
				if ((selectedRow.Visible && DGV1.Columns[sel_col] is DataGridViewTextBoxColumn) ? true : false)
				{
					list.Add(Conversions.ToString(DGV1[sel_col, selectedRow.Index].Value));
				}
			}
		}
		checked
		{
			int num = list.Count - 1;
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 < num3)
				{
					break;
				}
				stringBuilder.AppendLine(list[num]);
				num += -1;
			}
			Clipboard.SetDataObject(stringBuilder.ToString().Trim());
		}
	}

	private void TreeView1_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			Point pt = new Point(e.X, e.Y);
			Treenode treenode = (Treenode)TV1.GetNodeAt(pt);
			if (!Information.IsNothing(treenode))
			{
				TV1.SelectedNode = treenode;
				if (treenode.Level == 0)
				{
					tree_excludebom.Visible = false;
					tree_suppress.Visible = false;
					tree_unexcludebom.Visible = false;
					tree_unsuppress.Visible = false;
					tree_excludebom.Enabled = false;
					tree_suppress.Enabled = false;
					tree_unexcludebom.Enabled = false;
					tree_unsuppress.Enabled = false;
				}
				else
				{
					tree_excludebom.Visible = true;
					tree_suppress.Visible = true;
					tree_unexcludebom.Visible = true;
					tree_unsuppress.Visible = true;
					tree_excludebom.Enabled = true;
					tree_suppress.Enabled = true;
					tree_unexcludebom.Enabled = true;
					tree_unsuppress.Enabled = true;
				}
				if (treenode.PathName.EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase))
				{
					tree_DisplayInBOM.Visible = true;
					int displayInBOM = treenode.DisplayInBOM;
					tree_DisplayInBOM_hide.Checked = Conversions.ToBoolean(Interaction.IIf(displayInBOM == 1, true, false));
					tree_DisplayInBOM_Promote.Checked = Conversions.ToBoolean(Interaction.IIf(displayInBOM == 3, true, false));
					tree_DisplayInBOM_show.Checked = Conversions.ToBoolean(Interaction.IIf(displayInBOM == 2, true, false));
				}
				else if (treenode.PathName.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase))
				{
					tree_DisplayInBOM.Visible = false;
				}
				if (e.Button == MouseButtons.Right)
				{
					Point mousePosition = Control.MousePosition;
					treecmsp1.Show(mousePosition);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void TV1_AfterSelect(object sender, TreeViewEventArgs e)
	{
		try
		{
			Treenode treenode = (Treenode)e.Node;
			if (!Information.IsNothing(treenode) && !previewing)
			{
				previewing = true;
				if (Conversions.ToBoolean(Operators.AndObject(CConfigMng.Config.RowFollowdisplay, Operators.CompareObjectNotEqual(Operators.ConcatenateObject(MyProject.Forms.FrmPreview.Tag, MyProject.Forms.FrmPreview.Text), treenode.PathName + treenode.ConfigureName, TextCompare: false))))
				{
					code.Preview2(CConfigMng.Config.DefaultDrw, treenode.PathName, treenode.ConfigureName, this);
				}
				previewing = false;
				if (code.EnadleCellEvent)
				{
					int rowIndex = getrowindex(treenode);
					DGV1.CurrentCell = DGV1[sel_col, rowIndex];
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void tree_ExpandAll_Click(object sender, EventArgs e)
	{
		try
		{
			TV1.BeginUpdate();
			TV1.ExpandAll();
			TV1.EndUpdate();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void tree_CollapseAll_Click(object sender, EventArgs e)
	{
		try
		{
			TV1.CollapseAll();
			TV1.TopNode.Expand();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void tree_openinsw_Click(object sender, EventArgs e)
	{
		try
		{
			Treenode treenode = (Treenode)TV1.SelectedNode;
			if (!Information.IsNothing(treenode))
			{
				string pathName = treenode.PathName;
				Thread thread = new Thread(_Lambda_0024__91);
				thread.Start(pathName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void tree_showselnode1_Click(object sender, EventArgs e)
	{
		List<string> nodelist = new List<string>();
		try
		{
			Treenode treenode = (Treenode)TV1.SelectedNode;
			if (!Information.IsNothing(treenode))
			{
				getnodes(treenode, ref nodelist, onlytop: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (nodelist.Count < 1)
		{
			return;
		}
		RemoveFilter(Col_Checkbox.Index);
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__44 closure_0024__ = default(_Closure_0024__44);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__44(closure_0024__);
				closure_0024__._0024VB_0024Local_val = "";
				if (code.togetherConfig)
				{
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(DGV1[Col_Path.Index, num2].Value);
				}
				else
				{
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num2].Value, DGV1[Col_Cfg.Index, num2].Value));
				}
				if (nodelist.Exists(closure_0024__._Lambda_0024__92))
				{
					DGV1[Col_Checkbox.Index, num2].Value = true;
				}
				num2++;
			}
			filter_checkbox(Excluded: false);
		}
	}

	private void tree_showselnode2_Click(object sender, EventArgs e)
	{
		List<string> nodelist = new List<string>();
		try
		{
			Treenode treenode = (Treenode)TV1.SelectedNode;
			if (!Information.IsNothing(treenode))
			{
				getnodes(treenode, ref nodelist, onlytop: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (nodelist.Count < 1)
		{
			return;
		}
		RemoveFilter(Col_Checkbox.Index);
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__45 closure_0024__ = default(_Closure_0024__45);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__45(closure_0024__);
				closure_0024__._0024VB_0024Local_val = "";
				if (code.togetherConfig)
				{
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(DGV1[Col_Path.Index, num2].Value);
				}
				else
				{
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num2].Value, DGV1[Col_Cfg.Index, num2].Value));
				}
				if (nodelist.Exists(closure_0024__._Lambda_0024__93))
				{
					DGV1[Col_Checkbox.Index, num2].Value = true;
				}
				num2++;
			}
			filter_checkbox(Excluded: false);
		}
	}

	private void tree_showselnode3_Click(object sender, EventArgs e)
	{
		List<string> nodelist = new List<string>();
		try
		{
			Treenode treenode = (Treenode)TV1.SelectedNode;
			if (!Information.IsNothing(treenode))
			{
				getnodes2(treenode, ref nodelist);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (nodelist.Count < 1)
		{
			return;
		}
		RemoveFilter(Col_Checkbox.Index);
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__46 closure_0024__ = default(_Closure_0024__46);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__46(closure_0024__);
				closure_0024__._0024VB_0024Local_val = "";
				if (code.togetherConfig)
				{
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(DGV1[Col_Path.Index, num2].Value);
				}
				else
				{
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num2].Value, DGV1[Col_Cfg.Index, num2].Value));
				}
				if (nodelist.Exists(closure_0024__._Lambda_0024__94))
				{
					DGV1[Col_Checkbox.Index, num2].Value = true;
				}
				num2++;
			}
			filter_checkbox(Excluded: false);
		}
	}

	private void tree_hideselnode1_Click(object sender, EventArgs e)
	{
		HashSet<string> hashSet = new HashSet<string>();
		try
		{
			foreach (Treenode selectedNode in TV1.SelectedNodes)
			{
				if (!Information.IsNothing(selectedNode))
				{
					if (code.togetherConfig)
					{
						hashSet.Add(selectedNode.PathName);
					}
					else
					{
						hashSet.Add(selectedNode.PathName + selectedNode.ConfigureName);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (hashSet.Count < 1)
		{
			return;
		}
		int num = 0;
		checked
		{
			int num2 = DGV1.RowCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (!DGV1.Rows[num3].Visible)
				{
					DGV1[Col_Checkbox.Index, num3].Value = true;
				}
				else
				{
					DGV1[Col_Checkbox.Index, num3].Value = false;
					string text = "";
					text = ((!code.togetherConfig) ? Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num3].Value, DGV1[Col_Cfg.Index, num3].Value)) : Conversions.ToString(DGV1[Col_Path.Index, num3].Value));
					int num6 = hashSet.Count - 1;
					int num7 = 0;
					while (true)
					{
						int num8 = num7;
						num5 = num6;
						if (num8 > num5)
						{
							break;
						}
						if (hashSet.ElementAtOrDefault(num7).Equals(text, StringComparison.OrdinalIgnoreCase))
						{
							num++;
							DGV1[Col_Checkbox.Index, num3].Value = true;
							hashSet.Remove(text);
							break;
						}
						num7++;
					}
				}
				num3++;
			}
			if (num == 0)
			{
				return;
			}
			filter_checkbox(Excluded: true);
			int rowCount = DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible);
			if (sel_row < rowCount)
			{
				int num9 = sel_row;
				int num10 = rowCount;
				int num11 = num9;
				while (true)
				{
					int num12 = num11;
					int num5 = num10;
					if (num12 <= num5)
					{
						if (DGV1.Rows[num11].Visible)
						{
							DGV1.Rows[num11].Selected = true;
							break;
						}
						num11++;
						continue;
					}
					break;
				}
				return;
			}
			int num13 = sel_row;
			while (true)
			{
				int num14 = num13;
				int num5 = 0;
				if (num14 >= num5)
				{
					if (DGV1.Rows[num13].Visible)
					{
						DGV1.Rows[num13].Selected = true;
						break;
					}
					num13 += -1;
					continue;
				}
				break;
			}
		}
	}

	private void tree_hideselnode2_Click(object sender, EventArgs e)
	{
		List<string> nodelist = new List<string>();
		try
		{
			List<Treenode> selectedNodes = TV1.SelectedNodes;
			if (!Information.IsNothing(selectedNodes))
			{
				foreach (Treenode item in selectedNodes)
				{
					getnodes2(item, ref nodelist);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (nodelist.Count < 1)
		{
			return;
		}
		int num = 0;
		checked
		{
			int num2 = DGV1.RowCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (!DGV1.Rows[num3].Visible)
				{
					DGV1[Col_Checkbox.Index, num3].Value = true;
				}
				else
				{
					_Closure_0024__47 closure_0024__ = new _Closure_0024__47();
					DGV1[Col_Checkbox.Index, num3].Value = false;
					closure_0024__._0024VB_0024Local_val = "";
					if (code.togetherConfig)
					{
						closure_0024__._0024VB_0024Local_val = Conversions.ToString(DGV1[Col_Path.Index, num3].Value);
					}
					else
					{
						closure_0024__._0024VB_0024Local_val = Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num3].Value, DGV1[Col_Cfg.Index, num3].Value));
					}
					if (nodelist.Exists(closure_0024__._Lambda_0024__95))
					{
						num++;
						DGV1[Col_Checkbox.Index, num3].Value = true;
					}
				}
				num3++;
			}
			if (num == 0)
			{
				return;
			}
			filter_checkbox(Excluded: true);
			int rowCount = DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible);
			if (sel_row < rowCount)
			{
				int num6 = sel_row;
				int num7 = rowCount;
				int num8 = num6;
				while (true)
				{
					int num9 = num8;
					int num5 = num7;
					if (num9 <= num5)
					{
						if (DGV1.Rows[num8].Visible)
						{
							DGV1.Rows[num8].Selected = true;
							break;
						}
						num8++;
						continue;
					}
					break;
				}
				return;
			}
			int num10 = sel_row;
			while (true)
			{
				int num11 = num10;
				int num5 = 0;
				if (num11 >= num5)
				{
					if (DGV1.Rows[num10].Visible)
					{
						DGV1.Rows[num10].Selected = true;
						break;
					}
					num10 += -1;
					continue;
				}
				break;
			}
		}
	}

	private void tree_selectinsw_Click(object sender, EventArgs e)
	{
		try
		{
			treecmsp1.Close();
			HashSet<string> hashSet = new HashSet<string>();
			try
			{
				foreach (Treenode selectedNode in TV1.SelectedNodes)
				{
					if (!Information.IsNothing(selectedNode))
					{
						hashSet.Add(getnodidstring(selectedNode));
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (hashSet.Count >= 1)
			{
				code.selectbyinstring(string.Join("|", hashSet));
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
	}

	private void treecmsp1_Opening(object sender, CancelEventArgs e)
	{
		if (!code.canrun || (code.TMode ? true : false))
		{
			Levelbom.Enabled = false;
			Levelbom.ToolTipText = "Функция недоступна без лицензии";
		}
	}

	private void Levelbom_Click(object sender, EventArgs e)
	{
		if (code.TMode)
		{
			MessageBox.Show(this, "Не поддерживается в пробной версии!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		chl = new checklic();
		if (code.canrun)
		{
			Frmbom frmbom = new Frmbom();
			frmbom.Show();
		}
	}

	private void tree_suppress_Click(object sender, EventArgs e)
	{
		try
		{
			treecmsp1.Close();
			HashSet<string> hashSet = new HashSet<string>();
			try
			{
				foreach (Treenode selectedNode in TV1.SelectedNodes)
				{
					if (!Information.IsNothing(selectedNode))
					{
						hashSet.Add(getnodidstring(selectedNode));
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (hashSet.Count < 1)
			{
				return;
			}
			Treenode treenode = (Treenode)TV1.SelectedNode;
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			bool excludeFromBOM = treenode.ExcludeFromBOM;
			int num = Conversions.ToInteger(Interaction.IIf(treenode.IsSuppressed, 0, 2));
			string name = toolStripMenuItem.Name;
			if (Operators.CompareString(name, tree_suppress.Name, TextCompare: false) == 0)
			{
				num = 0;
			}
			else if (Operators.CompareString(name, tree_unsuppress.Name, TextCompare: false) == 0)
			{
				num = 2;
			}
			else if (Operators.CompareString(name, tree_excludebom.Name, TextCompare: false) == 0)
			{
				excludeFromBOM = true;
			}
			else if (Operators.CompareString(name, tree_unexcludebom.Name, TextCompare: false) == 0)
			{
				excludeFromBOM = false;
			}
			string sellist = string.Join("|", hashSet);
			if (!code.CompConfigProperties4(DGV1.Tag.ToString(), DGV1.topcfgName, sellist, excludeFromBOM, num))
			{
				return;
			}
			foreach (Treenode selectedNode2 in TV1.SelectedNodes)
			{
				selectedNode2.ExcludeFromBOM = excludeFromBOM;
				selectedNode2.IsSuppressed = Conversions.ToBoolean(Interaction.IIf(num == 0, true, false));
				if (selectedNode2.Level > 0)
				{
					TV1.BeginUpdate();
					setnodetext(selectedNode2, TV1.Nodes);
					TV1.EndUpdate();
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
	}

	private void tree_DisplayInBOM_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		treecmsp1.Close();
		Treenode treenode = (Treenode)TV1.SelectedNode;
		if (!Information.IsNothing(treenode))
		{
			int val = 0;
			switch (e.ClickedItem.Text)
			{
			case "Показать":
				val = 2;
				break;
			case "Скрыть":
				val = 1;
				break;
			case "Повысить":
				val = 3;
				break;
			}
			string pathName = treenode.PathName;
			string configureName = treenode.ConfigureName;
			setdisplayinbom(pathName, configureName, val);
			val = GetDisplayInBOM(pathName, configureName);
			treenode.DisplayInBOM = val;
			if (treenode.Level > 0)
			{
				setnodetext(treenode, TV1.Nodes);
			}
		}
	}

	public void getnodes(Treenode pnode, ref List<string> nodelist, bool onlytop, int Level = 0)
	{
		try
		{
			if (Information.IsNothing(pnode))
			{
				return;
			}
			_Closure_0024__48 closure_0024__ = new _Closure_0024__48();
			closure_0024__._0024VB_0024Local_result = Conversions.ToString(Interaction.IIf(code.togetherConfig, pnode.PathName, pnode.PathName + pnode.ConfigureName));
			if (!nodelist.Exists(closure_0024__._Lambda_0024__96) && (!onlytop || ((onlytop && Level > 0) ? true : false)))
			{
				nodelist.Add(closure_0024__._0024VB_0024Local_result);
			}
			if (Information.IsNothing(pnode.Nodes) || (onlytop && (!onlytop || Level != 0 || pnode.DisplayInBOM == 3) && (!onlytop || pnode.DisplayInBOM != 3)) || 1 == 0)
			{
				return;
			}
			foreach (Treenode node in pnode.Nodes)
			{
				getnodes(node, ref nodelist, onlytop, checked(Level + 1));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void getnodes2(Treenode pnode, ref List<string> nodelist, bool Includemyself = false, int Level = 0)
	{
		try
		{
			if (Information.IsNothing(pnode))
			{
				return;
			}
			_Closure_0024__49 closure_0024__ = new _Closure_0024__49();
			closure_0024__._0024VB_0024Local_result = Conversions.ToString(Interaction.IIf(code.togetherConfig, pnode.PathName, pnode.PathName + pnode.ConfigureName));
			if (!nodelist.Exists(closure_0024__._Lambda_0024__97) && (Includemyself || ((!Includemyself && Level > 0) ? true : false)))
			{
				nodelist.Add(closure_0024__._0024VB_0024Local_result);
			}
			if (Information.IsNothing(pnode.Nodes))
			{
				return;
			}
			foreach (Treenode node in pnode.Nodes)
			{
				getnodes(node, ref nodelist, Includemyself, checked(Level + 1));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void refreshnodecfg(TreeNodeCollection nodes, string pathname, string oldcfgname, string newcfgname)
	{
		if (Information.IsNothing(nodes))
		{
			return;
		}
		try
		{
			foreach (Treenode node in nodes)
			{
				string text = node.PathName + node.ConfigureName;
				if (text.Equals(pathname + oldcfgname, StringComparison.OrdinalIgnoreCase))
				{
					node.ConfigureName = newcfgname;
					node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ")";
					if ((node.DisplayInBOM == 3 && node.Level > 0) ? true : false)
					{
						node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (распустить в спецификации)";
					}
					else if ((node.DisplayInBOM == 1 && node.Level > 0) ? true : false)
					{
						node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (скрыть подэлементы в спецификации)";
					}
					if (node.ExcludeFromBOM)
					{
						node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (не включать в спецификацию)";
					}
				}
				if (node.Nodes.Count > 0)
				{
					refreshnodecfg(node.Nodes, pathname, oldcfgname, newcfgname);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void refreshnodename(TreeNodeCollection nodes, string oldpathname, string newpathname)
	{
		if (Information.IsNothing(nodes))
		{
			return;
		}
		try
		{
			foreach (Treenode node in nodes)
			{
				string pathName = node.PathName;
				string featureName = node.FeatureName;
				if (oldpathname.Equals(pathName, StringComparison.OrdinalIgnoreCase))
				{
					node.PathName = newpathname;
					node.FeatureName = code.SplitStr(newpathname, 1) + Strings.Mid(featureName, Strings.InStrRev(featureName, "-"));
					node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ")";
					if ((node.DisplayInBOM == 3 && node.Level > 0) ? true : false)
					{
						node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (распустить в спецификации)";
					}
					else if ((node.DisplayInBOM == 1 && node.Level > 0) ? true : false)
					{
						node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (скрыть подэлементы в спецификации)";
					}
					if (node.ExcludeFromBOM)
					{
						node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (не включать в спецификацию)";
					}
				}
				if (node.Nodes.Count > 0)
				{
					refreshnodename(node.Nodes, oldpathname, newpathname);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void selectnode(TreeNodeCollection nodes, string pathname, string cfgname)
	{
		if (Information.IsNothing(nodes))
		{
			return;
		}
		try
		{
			foreach (Treenode node in nodes)
			{
				string text = "";
				string text2 = "";
				if (code.togetherConfig)
				{
					text = node.PathName;
					text2 = pathname;
				}
				else
				{
					text = node.PathName + node.ConfigureName;
					text2 = pathname + cfgname;
				}
				if (text.Equals(text2, StringComparison.OrdinalIgnoreCase))
				{
					TV1.SelectedNodes.Add(node);
					Treenode treenode2 = (Treenode)node.Parent;
					while (!Information.IsNothing(treenode2))
					{
						treenode2.Expand();
						treenode2 = (Treenode)treenode2.Parent;
					}
				}
				if (node.Nodes.Count > 0)
				{
					selectnode(node.Nodes, pathname, cfgname);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void getnodebypath(TreeNodeCollection nodes, string pathname, string cfgname, ref Treenode result)
	{
		try
		{
			if (Information.IsNothing(nodes))
			{
				return;
			}
			foreach (Treenode node in nodes)
			{
				string text = node.PathName + node.ConfigureName;
				string value = pathname + cfgname;
				if (text.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					result = node;
				}
				if (node.Nodes.Count > 0)
				{
					getnodebypath(node.Nodes, pathname, cfgname, ref result);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void setnodetext(Treenode cnode, TreeNodeCollection nodes)
	{
		foreach (Treenode node in nodes)
		{
			if (Information.IsNothing(node))
			{
				continue;
			}
			string text = node.PathName + node.ConfigureName;
			if (text.Equals(cnode.PathName + cnode.ConfigureName, StringComparison.OrdinalIgnoreCase))
			{
				node.DisplayInBOM = cnode.DisplayInBOM;
			}
			if ((node.FeatureName.Equals(cnode.FeatureName, StringComparison.OrdinalIgnoreCase) && !node.FullPath.Equals(cnode.FullPath, StringComparison.OrdinalIgnoreCase)) ? true : false)
			{
				Treenode treenode2 = (Treenode)node.Parent;
				Treenode treenode3 = (Treenode)cnode.Parent;
				if (((!Information.IsNothing(treenode2) && !Information.IsNothing(treenode3)) ? true : false) && Operators.CompareString(treenode2.PathName + treenode2.ConfigureName, treenode3.PathName + treenode3.ConfigureName, TextCompare: false) == 0)
				{
					node.IsSuppressed = cnode.IsSuppressed;
					node.ExcludeFromBOM = cnode.ExcludeFromBOM;
				}
			}
			node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ")";
			if ((node.DisplayInBOM == 3 && node.Level > 0) ? true : false)
			{
				node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (распустить в спецификации)";
			}
			else if ((node.DisplayInBOM == 1 && node.Level > 0) ? true : false)
			{
				node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (скрыть подэлементы в спецификации)";
			}
			if (node.ExcludeFromBOM)
			{
				node.Text = code.SplitStr(node.PathName, 1) + " (" + node.ConfigureName + ") (не включать в спецификацию)";
			}
			if (node.IsSuppressed)
			{
				node.ForeColor = Color.Gray;
			}
			else
			{
				node.ForeColor = Control.DefaultForeColor;
			}
			if (string.Equals(code.SplitStr(node.PathName, 5), ".sldasm", StringComparison.OrdinalIgnoreCase))
			{
				node.ImageIndex = 0;
				node.SelectedImageIndex = 0;
			}
			else if (string.Equals(code.SplitStr(node.PathName, 5), ".sldprt", StringComparison.OrdinalIgnoreCase))
			{
				node.ImageIndex = 1;
				node.SelectedImageIndex = 1;
			}
			setnodetext(cnode, node.Nodes);
		}
	}

	public string getnodidstring(Treenode node)
	{
		string text = "";
		if (!Information.IsNothing(node))
		{
			Treenode treenode = (Treenode)node.Parent;
			string text2 = "";
			if (!Information.IsNothing(treenode))
			{
				text = node.FeatureName + "@" + code.SplitStr(treenode.PathName, 1);
				text2 = treenode.FeatureName;
				Treenode treenode2 = (Treenode)treenode.Parent;
				while (!Information.IsNothing(treenode2))
				{
					text = text2 + "@" + code.SplitStr(treenode2.PathName, 1) + "/" + text;
					text2 = treenode2.FeatureName;
					treenode2 = (Treenode)treenode2.Parent;
				}
			}
			else if (node.Level == 0)
			{
				text = node.FeatureName;
			}
		}
		return text;
	}

	private void GetMaterialName()
	{
		string text = "";
		XDocument xDocument = null;
		mlist.Clear();
		Material_list.Items.Clear();
		Material_list.AutoClose = true;
		Material_list.Items.Add("Удалить материал", Resources.del);
		Material_list.Items.Add("Сбросить цвет", Resources.clearcolor_32);
		Material_list.Items.Add("Задать цвет", Resources.setcolor_32);
		Material_list.Items.Add("Случайный цвет", Resources.Random_32);
		Material_list.Items.Add("Сбросить цвет");
		Material_list.Items.Add("Восстановить цвет материала");
		CheckBox checkBox = new CheckBox();
		checkBox.BackColor = Color.White;
		checkBox.Text = "Использовать цвет материала";
		checkBox.Checked = CConfigMng.Config.usematerialcolor;
		usecolor = new ToolStripControlHost(checkBox);
		checkBox.CheckedChanged += _Lambda_0024__98;
		Material_list.Items.Add(usecolor);
		string materialpath = CConfigMng.Config.materialpath;
		checked
		{
			try
			{
				if (File.Exists(materialpath))
				{
					Cachedata_Material = "";
					if (code.RunSW(HideWindow: false, startnew: false))
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
						stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
						stringBuilder.AppendLine(materialpath);
						stringBuilder.AppendLine(">");
						string text2 = stringBuilder.ToString().Trim();
						byte[] bytes = Encoding.Unicode.GetBytes(text2);
						int num = bytes.Length;
						int value = 70;
						code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
						ref IntPtr dwData = ref lParam.dwData;
						dwData = new IntPtr(value);
						lParam.cbData = num + 1;
						lParam.lpData = text2;
						code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
						xDocument = XDocument.Parse(Cachedata_Material);
					}
					else
					{
						xDocument = XDocument.Load(materialpath);
					}
				}
				if (!Information.IsNothing(xDocument))
				{
					Material_list.Items.Add(new ToolStripSeparator());
					IEnumerable<XElement> source = xDocument.Root.Elements("classification");
					ToolStripMenuItem[] array;
					if (CConfigMng.Config.ExpandMaterialList)
					{
						List<string> list = new List<string>();
						List<string> list2 = new List<string>();
						int num2 = source.Count() - 1;
						int num3 = 0;
						while (true)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							IEnumerable<XElement> source2 = source.ElementAtOrDefault(num3).Elements("material");
							int num6 = source2.Count() - 1;
							int num7 = 0;
							while (true)
							{
								int num8 = num7;
								num5 = num6;
								if (num8 > num5)
								{
									break;
								}
								list.Add(source2.ElementAtOrDefault(num7).Attribute("name").Value + "");
								IEnumerable<XElement> enumerable = source2.ElementAtOrDefault(num7).Elements("swatchcolor");
								string text3 = "FFFFFF";
								if (!Information.IsNothing(enumerable))
								{
									foreach (XElement item in enumerable)
									{
										text3 = item.Attribute("RGB").Value;
									}
								}
								list2.Add("#" + text3);
								num7++;
							}
							num3++;
						}
						array = new ToolStripMenuItem[list.Count - 1 + 1];
						int num9 = list.Count - 1;
						int num10 = 0;
						while (true)
						{
							int num11 = num10;
							int num5 = num9;
							if (num11 <= num5)
							{
								array[num10] = new ToolStripMenuItem(list[num10]);
								array[num10].BackColor = ColorTranslator.FromHtml(list2[num10]);
								if (!mlist.ContainsKey(list[num10]))
								{
									mlist.Add(list[num10], array[num10].BackColor);
								}
								num10++;
								continue;
							}
							break;
						}
					}
					else
					{
						array = new ToolStripMenuItem[source.Count() - 1 + 1];
						int num12 = source.Count() - 1;
						int num13 = 0;
						while (true)
						{
							int num14 = num13;
							int num5 = num12;
							if (num14 > num5)
							{
								break;
							}
							array[num13] = new ToolStripMenuItem(source.ElementAtOrDefault(num13).Attribute("name").Value);
							array[num13].DropDownItemClicked += mens_click;
							IEnumerable<XElement> source3 = source.ElementAtOrDefault(num13).Elements("material");
							int num15 = source3.Count() - 1;
							int num16 = 0;
							while (true)
							{
								int num17 = num16;
								num5 = num15;
								if (num17 > num5)
								{
									break;
								}
								string value2 = source3.ElementAtOrDefault(num16).Attribute("name").Value;
								array[num13].DropDownItems.Add(value2);
								IEnumerable<XElement> enumerable2 = source3.ElementAtOrDefault(num16).Elements("swatchcolor");
								string text4 = "FFFFFF";
								if (!Information.IsNothing(enumerable2))
								{
									foreach (XElement item2 in enumerable2)
									{
										text4 = item2.Attribute("RGB").Value;
									}
								}
								Color color = ColorTranslator.FromHtml("#" + text4);
								array[num13].DropDownItems[num16].BackColor = color;
								if (!mlist.ContainsKey(value2))
								{
									mlist.Add(value2, color);
								}
								if ((color.R < 120 || color.G < 120 || color.B < 120) ? true : false)
								{
									array[num13].DropDownItems[num16].ForeColor = Color.White;
								}
								else if ((color.R > 200 && color.G > 200 && color.B > 200) ? true : false)
								{
									array[num13].DropDownItems[num16].ForeColor = Color.Black;
								}
								num16++;
							}
							num13++;
						}
					}
					Material_list.Items.AddRange(array);
					xDocument = null;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				xDocument = null;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			Material_list.Items.Add(new ToolStripSeparator());
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Выбрать доступную базу материалов...");
			toolStripMenuItem.ForeColor = Color.Blue;
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Добавить базу материалов...");
			toolStripMenuItem2.ForeColor = Color.Blue;
			Material_list.Items.Add(toolStripMenuItem);
			Material_list.Items.Add(toolStripMenuItem2);
			int num18 = Material_list.Items.Count - 1;
			int num19 = 0;
			while (true)
			{
				int num20 = num19;
				int num5 = num18;
				if (num20 <= num5)
				{
					Material_list.Items[num19].MouseEnter += Downlist_MouseEnter;
					num19++;
					continue;
				}
				break;
			}
		}
	}

	private void Material_list_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		if (Operators.CompareString(e.ClickedItem.Text, "Удалить материал", TextCompare: false) == 0)
		{
			foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
			{
				if (selectedCell.ColumnIndex == selectedCell.ColumnIndex)
				{
					Type typeFromHandle = typeof(Strings);
					object[] array = new object[1];
					object[] array2 = array;
					DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell.RowIndex];
					array2[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
					object[] array3 = array;
					object[] arguments = array3;
					bool[] array4 = new bool[1] { true };
					object left = NewLateBinding.LateGet(null, typeFromHandle, "UCase", arguments, null, null, array4);
					if (array4[0])
					{
						dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array3[0]);
					}
					if (Operators.ConditionalCompareObjectEqual(left, "零件", TextCompare: false) && selectedCell.Visible)
					{
						goto IL_00f5;
					}
				}
				if (0 == 0)
				{
					continue;
				}
				goto IL_00f5;
				IL_00f5:
				selectedCell.Value = "";
				selectedCell.Style.BackColor = DGV1.DefaultCellStyle.BackColor;
				Color backColor = selectedCell.Style.BackColor;
				if ((backColor.R < 120 || backColor.G < 120 || backColor.B < 120) ? true : false)
				{
					selectedCell.Style.ForeColor = Color.White;
				}
				else if ((backColor.R > 200 && backColor.G > 200 && backColor.B > 200) ? true : false)
				{
					selectedCell.Style.ForeColor = Color.Black;
				}
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Сбросить цвет", TextCompare: false) == 0)
		{
			foreach (DataGridViewCell selectedCell2 in DGV1.SelectedCells)
			{
				if (selectedCell2.ColumnIndex == selectedCell2.ColumnIndex)
				{
					Type typeFromHandle2 = typeof(Strings);
					object[] array3 = new object[1];
					object[] array5 = array3;
					DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell2.RowIndex];
					array5[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
					object[] array = array3;
					object[] arguments2 = array;
					bool[] array4 = new bool[1] { true };
					object left2 = NewLateBinding.LateGet(null, typeFromHandle2, "UCase", arguments2, null, null, array4);
					if (array4[0])
					{
						dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array[0]);
					}
					if (Operators.ConditionalCompareObjectEqual(left2, "零件", TextCompare: false) && selectedCell2.Visible)
					{
						goto IL_02df;
					}
				}
				if (0 == 0)
				{
					continue;
				}
				goto IL_02df;
				IL_02df:
				selectedCell2.Style.BackColor = Color.FromArgb(203, 210, 239);
				Color backColor2 = selectedCell2.Style.BackColor;
				if ((backColor2.R < 120 || backColor2.G < 120 || backColor2.B < 120) ? true : false)
				{
					selectedCell2.Style.ForeColor = Color.White;
				}
				else if ((backColor2.R > 200 && backColor2.G > 200 && backColor2.B > 200) ? true : false)
				{
					selectedCell2.Style.ForeColor = Color.Black;
				}
				DGV1.Rows[selectedCell2.RowIndex].Tag = "true";
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Задать цвет", TextCompare: false) == 0)
		{
			Material_list.Close();
			try
			{
				ColorDialog.CustomColors = CConfigMng.Config.customcolors;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			ColorDialog.AllowFullOpen = true;
			ColorDialog.AnyColor = true;
			ColorDialog.FullOpen = true;
			if (ColorDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			try
			{
				CConfigMng.Config.customcolors = ColorDialog.CustomColors;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			{
				foreach (DataGridViewCell selectedCell3 in DGV1.SelectedCells)
				{
					if (selectedCell3.ColumnIndex == Col_Material.Index)
					{
						Type typeFromHandle3 = typeof(Strings);
						object[] array3 = new object[1];
						object[] array6 = array3;
						DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell3.RowIndex];
						array6[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
						object[] array = array3;
						object[] arguments3 = array;
						bool[] array4 = new bool[1] { true };
						object left3 = NewLateBinding.LateGet(null, typeFromHandle3, "UCase", arguments3, null, null, array4);
						if (array4[0])
						{
							dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array[0]);
						}
						if (Operators.ConditionalCompareObjectEqual(left3, "零件", TextCompare: false) && selectedCell3.Visible)
						{
							goto IL_058c;
						}
					}
					if (0 == 0)
					{
						continue;
					}
					goto IL_058c;
					IL_058c:
					selectedCell3.Style.BackColor = ColorDialog.Color;
					Color backColor3 = selectedCell3.Style.BackColor;
					if ((backColor3.R < 120 || backColor3.G < 120 || backColor3.B < 120) ? true : false)
					{
						selectedCell3.Style.ForeColor = Color.White;
					}
					else if ((backColor3.R > 200 && backColor3.G > 200 && backColor3.B > 200) ? true : false)
					{
						selectedCell3.Style.ForeColor = Color.Black;
					}
					DGV1.Rows[selectedCell3.RowIndex].Tag = "true";
				}
				return;
			}
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Случайный цвет", TextCompare: false) == 0)
		{
			foreach (DataGridViewCell selectedCell4 in DGV1.SelectedCells)
			{
				if (selectedCell4.ColumnIndex == Col_Material.Index)
				{
					Type typeFromHandle4 = typeof(Strings);
					object[] array3 = new object[1];
					object[] array7 = array3;
					DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell4.RowIndex];
					array7[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
					object[] array = array3;
					object[] arguments4 = array;
					bool[] array4 = new bool[1] { true };
					object left4 = NewLateBinding.LateGet(null, typeFromHandle4, "UCase", arguments4, null, null, array4);
					if (array4[0])
					{
						dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array[0]);
					}
					if (Operators.ConditionalCompareObjectEqual(left4, "零件", TextCompare: false) && selectedCell4.Visible)
					{
						goto IL_0795;
					}
				}
				if (0 == 0)
				{
					continue;
				}
				goto IL_0795;
				IL_0795:
				selectedCell4.Style.BackColor = RanDomColor(selectedCell4.RowIndex);
				Color backColor4 = selectedCell4.Style.BackColor;
				if ((backColor4.R < 120 || backColor4.G < 120 || backColor4.B < 120) ? true : false)
				{
					selectedCell4.Style.ForeColor = Color.White;
				}
				else if ((backColor4.R > 200 && backColor4.G > 200 && backColor4.B > 200) ? true : false)
				{
					selectedCell4.Style.ForeColor = Color.Black;
				}
				DGV1.Rows[selectedCell4.RowIndex].Tag = "true";
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Сбросить цвет", TextCompare: false) == 0)
		{
			Color color = default(Color);
			foreach (DataGridViewCell selectedCell5 in DGV1.SelectedCells)
			{
				if (selectedCell5.ColumnIndex == Col_Material.Index)
				{
					Type typeFromHandle5 = typeof(Strings);
					object[] array3 = new object[1];
					object[] array8 = array3;
					DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell5.RowIndex];
					array8[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
					object[] array = array3;
					object[] arguments5 = array;
					bool[] array4 = new bool[1] { true };
					object left5 = NewLateBinding.LateGet(null, typeFromHandle5, "UCase", arguments5, null, null, array4);
					if (array4[0])
					{
						dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array[0]);
					}
					if (Operators.ConditionalCompareObjectEqual(left5, "零件", TextCompare: false) && selectedCell5.Visible)
					{
						goto IL_09a0;
					}
				}
				if (0 == 0)
				{
					continue;
				}
				goto IL_09a0;
				IL_09a0:
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(selectedCell5.Tag)))
				{
					try
					{
						DataGridViewCellStyle style = selectedCell5.Style;
						object obj = NewLateBinding.LateIndexGet(selectedCell5.Tag, new object[1] { 0 }, null);
						style.BackColor = ((obj != null) ? ((Color)obj) : color);
						DataGridViewCellStyle style2 = selectedCell5.Style;
						object obj2 = NewLateBinding.LateIndexGet(selectedCell5.Tag, new object[1] { 1 }, null);
						style2.ForeColor = ((obj2 != null) ? ((Color)obj2) : color);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ProjectData.ClearProjectError();
					}
					DGV1.Rows[selectedCell5.RowIndex].Tag = "true";
				}
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Восстановить цвет материала", TextCompare: false) == 0)
		{
			foreach (DataGridViewCell selectedCell6 in DGV1.SelectedCells)
			{
				if (selectedCell6.ColumnIndex == Col_Material.Index)
				{
					Type typeFromHandle6 = typeof(Strings);
					object[] array9 = new object[1];
					object[] array10 = array9;
					DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell6.RowIndex];
					array10[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
					object[] array3 = array9;
					object[] arguments6 = array3;
					bool[] array4 = new bool[1] { true };
					object left6 = NewLateBinding.LateGet(null, typeFromHandle6, "UCase", arguments6, null, null, array4);
					if (array4[0])
					{
						dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array3[0]);
					}
					if (Operators.ConditionalCompareObjectEqual(left6, "零件", TextCompare: false) && selectedCell6.Visible)
					{
						goto IL_0baf;
					}
				}
				if (0 == 0)
				{
					continue;
				}
				goto IL_0baf;
				IL_0baf:
				if (mlist.TryGetValue(Conversions.ToString(selectedCell6.Value), out var value))
				{
					selectedCell6.Style.BackColor = value;
					if ((value.R < 120 || value.G < 120 || value.B < 120) ? true : false)
					{
						selectedCell6.Style.ForeColor = Color.White;
					}
					else if ((value.R > 200 && value.G > 200 && value.B > 200) ? true : false)
					{
						selectedCell6.Style.ForeColor = Color.Black;
					}
					selectedCell6.Tag = new object[2]
					{
						selectedCell6.Style.BackColor,
						selectedCell6.Style.ForeColor
					};
				}
			}
			return;
		}
		checked
		{
			if (Operators.CompareString(e.ClickedItem.Text, "Добавить базу материалов...", TextCompare: false) == 0)
			{
				MyProject.Forms.FrmOptions.TabControl1.SelectedIndex = 2;
				MyProject.Forms.FrmOptions.ShowDialog();
			}
			else if (Operators.CompareString(e.ClickedItem.Text, "Выбрать доступную базу материалов...", TextCompare: false) == 0)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;
				toolStripMenuItem.DropDownItemClicked += mens2_click;
				toolStripMenuItem.DropDownItems.Clear();
				List<string> list = code.getmateriallist();
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
						toolStripMenuItem.DropDownItems.Add(list[num2]).Select();
					}
					else
					{
						toolStripMenuItem.DropDownItems.Add(list[num2]);
					}
					num2++;
				}
				toolStripMenuItem.ShowDropDown();
			}
			else
			{
				if (!CConfigMng.Config.ExpandMaterialList)
				{
					return;
				}
				foreach (DataGridViewCell selectedCell7 in DGV1.SelectedCells)
				{
					if (selectedCell7.ColumnIndex == selectedCell7.ColumnIndex)
					{
						Type typeFromHandle7 = typeof(Strings);
						object[] array9 = new object[1];
						object[] array11 = array9;
						DataGridViewCell dataGridViewCell2 = DGV1[Col_Extname.Index, selectedCell7.RowIndex];
						array11[0] = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Tag);
						object[] array3 = array9;
						object[] arguments7 = array3;
						bool[] array4 = new bool[1] { true };
						object left7 = NewLateBinding.LateGet(null, typeFromHandle7, "UCase", arguments7, null, null, array4);
						if (array4[0])
						{
							dataGridViewCell2.Tag = RuntimeHelpers.GetObjectValue(array3[0]);
						}
						if (Operators.ConditionalCompareObjectEqual(left7, "零件", TextCompare: false) && selectedCell7.Visible)
						{
							goto IL_0ef2;
						}
					}
					if (0 == 0)
					{
						continue;
					}
					goto IL_0ef2;
					IL_0ef2:
					selectedCell7.Value = e.ClickedItem.Text;
					selectedCell7.Style.BackColor = e.ClickedItem.BackColor;
					Color backColor5 = selectedCell7.Style.BackColor;
					if ((backColor5.R < 120 || backColor5.G < 120 || backColor5.B < 120) ? true : false)
					{
						selectedCell7.Style.ForeColor = Color.White;
					}
					else if ((backColor5.R > 200 && backColor5.G > 200 && backColor5.B > 200) ? true : false)
					{
						selectedCell7.Style.ForeColor = Color.Black;
					}
					selectedCell7.Tag = new object[2]
					{
						selectedCell7.Style.BackColor,
						selectedCell7.Style.ForeColor
					};
				}
			}
		}
	}

	private Color RanDomColor(int seed)
	{
		Random random = new Random(checked(seed + DateTime.Now.Second));
		int red = random.Next(255);
		int green = random.Next(255);
		int blue = random.Next(255);
		return Color.FromArgb(red, green, blue);
	}

	private void mens2_click(object sender, ToolStripItemClickedEventArgs e)
	{
		CConfigMng.Config.materialpath = e.ClickedItem.Text;
		GetMaterialName();
		Material_list.Show(ComboBox1, 0, ComboBox1.Height);
	}

	private void mens_click(object sender, ToolStripItemClickedEventArgs e)
	{
		if (DGV1.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
		{
			{
				foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
				{
					if ((selectedCell.ColumnIndex == Col_Material.Index && Operators.ConditionalCompareObjectEqual(DGV1[Col_Extname.Index, selectedCell.RowIndex].Tag, "零件", TextCompare: false) && DGV1.Rows[selectedCell.RowIndex].Visible) ? true : false)
					{
						DGV1[sel_col, selectedCell.RowIndex].Value = e.ClickedItem.Text;
						if (CConfigMng.Config.usematerialcolor)
						{
							selectedCell.Style.BackColor = e.ClickedItem.BackColor;
						}
					}
				}
				return;
			}
		}
		foreach (DataGridViewRow selectedRow in DGV1.SelectedRows)
		{
			if ((Operators.ConditionalCompareObjectEqual(DGV1[Col_Extname.Index, selectedRow.Index].Tag, "零件", TextCompare: false) && selectedRow.Visible) ? true : false)
			{
				DGV1[sel_col, selectedRow.Index].Value = e.ClickedItem.Text;
				if (CConfigMng.Config.usematerialcolor)
				{
					DGV1[Col_Material.Index, selectedRow.Index].Style.BackColor = e.ClickedItem.BackColor;
				}
			}
		}
	}

	public void usecolor_CheckedChanged()
	{
		CConfigMng.Config.usematerialcolor = !CConfigMng.Config.usematerialcolor;
		CConfigMng.SaveConfig();
	}

	private void Prop_Downlist_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		if (Operators.CompareString(e.ClickedItem.Text, "Очистить содержимое", TextCompare: false) == 0)
		{
			foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
			{
				if (selectedCell.ColumnIndex != Col_FileName.Index && ((!selectedCell.ReadOnly && selectedCell.Visible) ? true : false))
				{
					selectedCell.Value = "";
				}
			}
			return;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Настроить меню...", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmOptions.TabControl1.SelectedIndex = 3;
			MyProject.Forms.FrmOptions.ShowDialog();
			return;
		}
		foreach (DataGridViewCell selectedCell2 in DGV1.SelectedCells)
		{
			if (selectedCell2.ColumnIndex == sel_col && selectedCell2.ColumnIndex != Col_FileName.Index && 0 == 0 && ((!selectedCell2.ReadOnly && selectedCell2.Visible) ? true : false) && Operators.ConditionalCompareObjectNotEqual(selectedCell2.Value, code.GetdownlistValue(e.ClickedItem.Text), TextCompare: false))
			{
				selectedCell2.Value = code.GetdownlistValue(e.ClickedItem.Text);
			}
		}
	}

	public void setpropdownlist(bool Multiline = false)
	{
		Prop_Downlist = new ContextMenuStrip();
		Prop_Downlist.AutoSize = true;
		TextBox textBox = new TextBox();
		textBox.Text = Conversions.ToString(DGV1[sel_col, sel_row].Value);
		textBox.Multiline = Multiline;
		Label label = new Label();
		textBox.Font = new Font(Prop_Downlist.Font.Name, Prop_Downlist.Font.Size, Prop_Downlist.Font.Style);
		label.FlatStyle = FlatStyle.Flat;
		label.AutoSize = false;
		Size size = new Size(18, 18);
		label.Size = size;
		label.Parent = textBox;
		label.Dock = DockStyle.Right;
		label.Image = Resources.write;
		ToolStripControlHost toolStripControlHost = new ToolStripControlHost(textBox);
		toolStripControlHost.AutoSize = false;
		checked
		{
			if (Multiline)
			{
				size = new Size((int)Math.Round(150.0 * dpixRatio), (int)Math.Round(50.0 * dpixRatio));
				toolStripControlHost.Size = size;
			}
			Prop_Downlist.Items.Add("Очистить содержимое", Resources.clear);
			Prop_Downlist.Items.Add(toolStripControlHost);
			Prop_Downlist.Items.Add(new ToolStripSeparator());
			bool flag = false;
			string[] array = null;
			if (CConfigMng.Config.Dropdownlist.Count > 0)
			{
				int num = CConfigMng.Config.Dropdownlist.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					array = Strings.Split(CConfigMng.Config.Dropdownlist[num2].ToString(), "\n");
					if (array.Length > 1 && ((Operators.CompareString(array[0], DGV1.Columns[sel_col].HeaderText, TextCompare: false) == 0) & (Operators.CompareString(array[1], "", TextCompare: false) != 0)))
					{
						flag = true;
						break;
					}
					num2++;
				}
			}
			ToolStripMenuItem[] array2;
			if (flag)
			{
				array2 = new ToolStripMenuItem[array.Length - 2 + 1];
				int num5 = array.Length - 2;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 <= num4)
					{
						array2[num6] = new ToolStripMenuItem(array[num6 + 1]);
						num6++;
						continue;
					}
					break;
				}
			}
			else
			{
				array2 = new ToolStripMenuItem[code.downlist.Length - 1 + 1];
				int num8 = code.downlist.Length - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num4 = num8;
					if (num10 > num4)
					{
						break;
					}
					array2[num9] = new ToolStripMenuItem(NewLateBinding.LateIndexGet(code.downlist, new object[1] { num9 }, null).ToString());
					num9++;
				}
			}
			Prop_Downlist.Items.AddRange(array2);
			Prop_Downlist.Items.Add(new ToolStripSeparator());
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Настроить меню...");
			toolStripMenuItem.ForeColor = Color.Blue;
			Prop_Downlist.Items.Add(toolStripMenuItem);
			Prop_Downlist.AutoSize = false;
			toolStripControlHost.Dock = DockStyle.Left;
			toolStripControlHost.Width = Prop_Downlist.Width - 20;
			Prop_Downlist.AutoSize = true;
			textBox.TextChanged += tb_TextChanged;
			int num11 = Prop_Downlist.Items.Count - 1;
			int num12 = 0;
			while (true)
			{
				int num13 = num12;
				int num4 = num11;
				if (num13 <= num4)
				{
					Prop_Downlist.Items[num12].MouseEnter += Downlist_MouseEnter;
					num12++;
					continue;
				}
				break;
			}
		}
	}

	private void tb_TextChanged(object sender, EventArgs e)
	{
		foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
		{
			if (selectedCell.ColumnIndex == sel_col && ((!selectedCell.ReadOnly && selectedCell.Visible) ? true : false))
			{
				selectedCell.Value = ((TextBox)sender).Text;
			}
		}
	}

	private void Downlist_MouseEnter(object sender, EventArgs e)
	{
		if (sender is ToolStripControlHost)
		{
			((ToolStripControlHost)sender).Select();
		}
		else if (sender is ToolStripMenuItem)
		{
			((ToolStripMenuItem)sender).Select();
		}
	}

	public void SetCfgRenamelist()
	{
		CfgRename_list = new ContextMenuStrip();
		Button button = new Button();
		progb = new ProgressBar();
		newcfgname = new TextBox();
		CfgRename_list.Items.Clear();
		CfgRename_list.ShowCheckMargin = false;
		CfgRename_list.ShowImageMargin = false;
		button.Text = "Подтвердить изменение";
		newcfgname.Font = new Font("微软雅黑", newcfgname.Font.Size, newcfgname.Font.Style);
		newcfgname.Text = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
		ToolStripControlHost toolStripControlHost = new ToolStripControlHost(newcfgname);
		ToolStripControlHost toolStripControlHost2 = new ToolStripControlHost(button);
		ToolStripControlHost toolStripControlHost3 = new ToolStripControlHost(progb);
		CfgRename_list.Items.Add(toolStripControlHost);
		CfgRename_list.Items.Add(toolStripControlHost3);
		CfgRename_list.Items.Add(toolStripControlHost2);
		toolStripControlHost2.Dock = DockStyle.Right;
		toolStripControlHost2.AutoSize = true;
		toolStripControlHost.AutoSize = false;
		checked
		{
			toolStripControlHost.Width = (int)Math.Round(200.0 * dpixRatio);
			toolStripControlHost.Height = (int)Math.Round(25.0 * dpixRatio);
			toolStripControlHost3.AutoSize = false;
			toolStripControlHost3.Height = (int)Math.Round(2.0 * dpixRatio);
			toolStripControlHost3.Width = (int)Math.Round(200.0 * dpixRatio);
			CfgRename_list.BackColor = progb.BackColor;
			CfgRename_list.AutoSize = false;
			CfgRename_list.Width = (int)Math.Round(215.0 * dpixRatio);
			button.Click += but1_click;
		}
	}

	public void SetCfgRenamelist2()
	{
		CfgRename_list = new ContextMenuStrip();
		progb = new ProgressBar();
		newcfgname = new TextBox();
		dgv2 = new DataGridView();
		Button button = new Button();
		CfgRename_list.Items.Clear();
		CfgRename_list.ShowCheckMargin = false;
		CfgRename_list.ShowImageMargin = false;
		dgv2.Columns.Clear();
		dgv2.Rows.Clear();
		dgv2.RowHeadersVisible = false;
		dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		dgv2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
		dgv2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgv2.AllowUserToOrderColumns = false;
		dgv2.AllowUserToResizeRows = false;
		dgv2.AllowUserToResizeColumns = true;
		dgv2.AllowUserToAddRows = false;
		dgv2.AllowUserToDeleteRows = false;
		dgv2.ScrollBars = ScrollBars.Both;
		dgv2.EnableHeadersVisualStyles = true;
		dgv2.EditMode = DataGridViewEditMode.EditOnEnter;
		dgv2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		dgv2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
		DoubleBuffer(dgv2);
		dgv2.AutoSize = false;
		dgv2.BackgroundColor = Color.White;
		dgv2.Columns.Add("col1", "Старое имя конфигурации");
		dgv2.Columns.Add("col2", "Новое имя конфигурации");
		dgv2.Columns["col1"].SortMode = DataGridViewColumnSortMode.NotSortable;
		dgv2.Columns["col2"].SortMode = DataGridViewColumnSortMode.NotSortable;
		checked
		{
			dgv2.Columns["col1"].Width = (int)Math.Round(130.0 * dpixRatio);
			dgv2.Columns["col1"].ReadOnly = true;
			dgv2.Columns["col1"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv2.Columns["col2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			if (!code.RunSW())
			{
				return;
			}
			string text = filename_inselitem;
			string text2 = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
			int num = default(int);
			if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			else if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			else if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			object swApp = code.swApp;
			object[] array = new object[2] { text, num };
			bool[] array2 = new bool[2] { true, true };
			object obj = NewLateBinding.LateGet(swApp, null, "OpenDoc", array, null, null, array2);
			if (array2[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			if (array2[1])
			{
				num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
			}
			object objectValue = RuntimeHelpers.GetObjectValue(obj);
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				MessageBox.Show(this, text + " не удалось открыть!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetConfigurationNames", new object[0], null, null, null));
			foreach (object item in (IEnumerable)objectValue2)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(item);
				dgv2.Rows.Add();
				dgv2[0, dgv2.Rows.Count - 1].Value = objectValue3.ToString();
				dgv2[1, dgv2.Rows.Count - 1].Value = objectValue3.ToString();
			}
			objectValue = null;
			code.swApp = null;
			progb.Maximum = dgv2.RowCount - 1;
			progb.Value = 0;
			progb.Style = ProgressBarStyle.Blocks;
			progb.Parent = dgv2;
			progb.Dock = DockStyle.Bottom;
			button.Text = "Подтвердить изменение";
			ToolStripControlHost toolStripControlHost = new ToolStripControlHost(button);
			ToolStripControlHost toolStripControlHost2 = new ToolStripControlHost(dgv2);
			CfgRename_list.Items.Add(toolStripControlHost2);
			CfgRename_list.Items.Add(toolStripControlHost);
			toolStripControlHost.AutoSize = true;
			toolStripControlHost.Dock = DockStyle.Right;
			toolStripControlHost2.AutoSize = false;
			toolStripControlHost2.Width = (int)Math.Round(300.0 * dpixRatio);
			toolStripControlHost2.Height = (int)Math.Round(200.0 * dpixRatio);
			dgv2.ClearSelection();
			progb.AutoSize = false;
			progb.Width = (int)Math.Round(300.0 * dpixRatio);
			progb.Height = (int)Math.Round(2.0 * dpixRatio);
			CfgRename_list.AutoSize = false;
			CfgRename_list.Width = (int)Math.Round(315.0 * dpixRatio);
			button.Click += but2_click;
		}
	}

	private void but2_click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				dgv2.EndEdit();
				if (!code.RunSW())
				{
					return;
				}
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
				object objectValue = RuntimeHelpers.GetObjectValue(new object());
				string text = filename_inselitem;
				int num = default(int);
				if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
				{
					num = 1;
				}
				else if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
				{
					num = 2;
				}
				else if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
				{
					num = 3;
				}
				object swApp = code.swApp;
				object[] array = new object[2] { text, num };
				object[] arguments = array;
				bool[] array2 = new bool[2] { true, true };
				object obj = NewLateBinding.LateGet(swApp, null, "OpenDoc", arguments, null, null, array2);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				if (array2[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				}
				objectValue = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				int num2 = dgv2.Rows.Count - 1;
				int num3 = 0;
				object[] array3;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string text2 = Conversions.ToString(dgv2[1, num3].Value);
					string text3 = Conversions.ToString(dgv2[0, num3].Value);
					progb.Value = num3;
					if (!string.Equals(text3, text2, StringComparison.OrdinalIgnoreCase))
					{
						object instance = objectValue;
						array3 = new object[5] { text3, text2, "", "", 36 };
						object[] arguments2 = array3;
						array2 = new bool[5] { true, true, false, false, false };
						object value = NewLateBinding.LateGet(instance, null, "EditConfiguration3", arguments2, null, null, array2);
						if (array2[0])
						{
							text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						}
						if (array2[1])
						{
							text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(string));
						}
						if (Conversions.ToBoolean(value))
						{
							int num6 = DGV1.Rows.Count - 1;
							int num7 = 0;
							while (true)
							{
								int num8 = num7;
								num5 = num6;
								if (num8 > num5)
								{
									break;
								}
								if (string.Equals(text, Conversions.ToString(DGV1[Col_Path.Index, num7].Value), StringComparison.OrdinalIgnoreCase) && Operators.ConditionalCompareObjectEqual(DGV1[Col_Cfg.Index, num7].Value, dgv2[0, num3].Value, TextCompare: false))
								{
									DGV1[Col_Cfg.Index, num7].Value = text2;
								}
								num7++;
							}
							dgv2[0, num3].Value = text2;
							refreshnodecfg(TV1.Nodes, text, text3, text2);
							if (!Information.IsNothing(FilterCollist[Col_Checkbox.Index]))
							{
								int num9 = FilterCollist[Col_Checkbox.Index].Count - 1;
								int num10 = 0;
								while (true)
								{
									int num11 = num10;
									num5 = num9;
									if (num11 > num5)
									{
										break;
									}
									if (FilterCollist[Col_Checkbox.Index][num10].Equals(text + text3, StringComparison.OrdinalIgnoreCase))
									{
										FilterCollist[Col_Checkbox.Index][num10] = text + text2;
										break;
									}
									num10++;
								}
							}
						}
					}
					num3++;
				}
				object instance2 = objectValue;
				array3 = new object[3] { text, 0, 1 };
				object[] arguments3 = array3;
				array2 = new bool[3] { true, false, false };
				NewLateBinding.LateCall(instance2, null, "SaveAs3", arguments3, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
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
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
				code.swApp = null;
			}
		}
	}

	private void but1_click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				if (!code.RunSW())
				{
					return;
				}
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
				int num = 0;
				progb.Maximum = DGV1.SelectedCells.Count;
				int num2 = default(int);
				foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
				{
					num++;
					progb.Value = num;
					if (selectedCell.ColumnIndex != Col_Cfg.Index || !DGV1.Rows[selectedCell.RowIndex].Visible)
					{
						continue;
					}
					string text = Conversions.ToString(DGV1[Col_Path.Index, selectedCell.RowIndex].Value);
					string text2 = Conversions.ToString(DGV1[Col_Cfg.Index, selectedCell.RowIndex].Value);
					if (string.Equals(text2, newcfgname.Text, StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
					{
						num2 = 1;
					}
					else if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						num2 = 2;
					}
					else if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
					{
						num2 = 3;
					}
					object swApp = code.swApp;
					object[] array = new object[2] { text, num2 };
					object[] arguments = array;
					bool[] array2 = new bool[2] { true, true };
					object obj = NewLateBinding.LateGet(swApp, null, "OpenDoc", arguments, null, null, array2);
					if (array2[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					if (array2[1])
					{
						num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					}
					object objectValue = RuntimeHelpers.GetObjectValue(obj);
					array = new object[5] { text2, null, null, null, null };
					object[] array3 = array;
					TextBox textBox = newcfgname;
					array3[1] = textBox.Text;
					array[2] = "";
					array[3] = "";
					array[4] = 36;
					object[] array4 = array;
					object[] arguments2 = array4;
					array2 = new bool[5] { true, true, false, false, false };
					object value = NewLateBinding.LateGet(objectValue, null, "EditConfiguration3", arguments2, null, null, array2);
					if (array2[0])
					{
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
					}
					if (array2[1])
					{
						textBox.Text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[1]), typeof(string));
					}
					if (Conversions.ToBoolean(value))
					{
						DGV1[Col_Cfg.Index, selectedCell.RowIndex].Value = newcfgname.Text;
					}
					refreshnodecfg(TV1.Nodes, text, text2, newcfgname.Text);
					if (Information.IsNothing(FilterCollist[Col_Checkbox.Index]))
					{
						continue;
					}
					int num3 = FilterCollist[Col_Checkbox.Index].Count - 1;
					int num4 = 0;
					while (true)
					{
						int num5 = num4;
						int num6 = num3;
						if (num5 > num6)
						{
							break;
						}
						if (FilterCollist[Col_Checkbox.Index][num4].Equals(text + text2, StringComparison.OrdinalIgnoreCase))
						{
							FilterCollist[Col_Checkbox.Index][num4] = text + newcfgname.Text;
							break;
						}
						num4++;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message);
				ProjectData.ClearProjectError();
			}
			finally
			{
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
				code.swApp = null;
			}
		}
	}

	public void setpartnumbersetting()
	{
		partnumbersetting = new ContextMenuStrip();
		partnumbersetting.Items.Clear();
		partnumbersetting.ShowCheckMargin = false;
		partnumbersetting.ShowImageMargin = false;
		checked
		{
			try
			{
				Cachedata_BOMPart = "";
				if (code.RunSW(HideWindow: false, startnew: false))
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
					stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
					stringBuilder.AppendLine(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Path.Index, sel_row].Value)));
					stringBuilder.AppendLine(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Cfg.Index, sel_row].Value)));
					stringBuilder.AppendLine(">");
					string text = stringBuilder.ToString().Trim();
					byte[] bytes = Encoding.Unicode.GetBytes(text);
					int num = bytes.Length;
					int value = 80;
					code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
					ref IntPtr dwData = ref lParam.dwData;
					dwData = new IntPtr(value);
					lParam.cbData = num + 1;
					lParam.lpData = text;
					code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			bd = default(code.BOMPartData);
			if (Operators.CompareString(Cachedata_BOMPart, "", TextCompare: false) != 0)
			{
				object obj = code.DeserializeObject_json(Cachedata_BOMPart, typeof(code.BOMPartData));
				code.BOMPartData bOMPartData = default(code.BOMPartData);
				bd = ((obj != null) ? ((code.BOMPartData)obj) : bOMPartData);
			}
			Label label = new Label();
			label.Text = "Номер детали, отображаемый в спецификации материалов:";
			Label c = label;
			Button button = new Button();
			button.Text = "Подтвердить изменение";
			Button button2 = button;
			progb = new ProgressBar();
			partnumber_intable = new TextBox
			{
				ReadOnly = Conversions.ToBoolean(Interaction.IIf(bd.BOMPartNoSource == 2, false, true))
			};
			partnumber_option = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			partnumber_intable.Font = new Font("微软雅黑", partnumber_intable.Font.Size, partnumber_intable.Font.Style);
			partnumber_intable.Text = bd.BOMPartNumber;
			partnumber_intable.PasswordChar = Conversions.ToChar(Interaction.IIf(selcount == 1, "", "*"));
			partnumber_option.Font = new Font("微软雅黑", partnumber_option.Font.Size, partnumber_option.Font.Style);
			if (selcount == 1)
			{
				if (Operators.CompareString(bd.ParentName, "", TextCompare: false) == 0)
				{
					partnumber_option.Items.AddRange(new object[3] { "Имя документа", "Имя конфигурации", "Имя, заданное пользователем" });
					switch (bd.BOMPartNoSource)
					{
					case 1:
						partnumber_option.SelectedIndex = 0;
						partnumber_intable.ReadOnly = true;
						break;
					case 2:
						partnumber_option.SelectedIndex = 1;
						partnumber_intable.ReadOnly = true;
						break;
					case 8:
						partnumber_option.SelectedIndex = 2;
						partnumber_intable.ReadOnly = false;
						break;
					}
				}
				else
				{
					partnumber_option.Items.AddRange(new object[4] { "Имя документа", "Имя конфигурации", "Имя, заданное пользователем", "Связать с родительской конфигурацией" });
					switch (bd.BOMPartNoSource)
					{
					case 1:
						partnumber_option.SelectedIndex = 0;
						partnumber_intable.ReadOnly = true;
						break;
					case 2:
						partnumber_option.SelectedIndex = 1;
						partnumber_intable.ReadOnly = true;
						break;
					case 4:
						partnumber_option.SelectedIndex = 3;
						partnumber_intable.ReadOnly = true;
						break;
					case 8:
						partnumber_option.SelectedIndex = 2;
						partnumber_intable.ReadOnly = false;
						break;
					}
				}
			}
			else
			{
				partnumber_option.Items.AddRange(new object[4] { "Имя документа", "Имя конфигурации", "Имя, заданное пользователем", "Связать с родительской конфигурацией" });
				partnumber_option.SelectedIndex = -1;
			}
			ToolStripControlHost toolStripControlHost = new ToolStripControlHost(partnumber_intable);
			ToolStripControlHost toolStripControlHost2 = new ToolStripControlHost(partnumber_option);
			ToolStripControlHost toolStripControlHost3 = new ToolStripControlHost(button2);
			ToolStripControlHost toolStripControlHost4 = new ToolStripControlHost(progb);
			ToolStripControlHost toolStripControlHost5 = new ToolStripControlHost(c);
			partnumbersetting.Items.Add(toolStripControlHost5);
			partnumbersetting.Items.Add(toolStripControlHost);
			partnumbersetting.Items.Add(toolStripControlHost2);
			partnumbersetting.Items.Add(toolStripControlHost4);
			partnumbersetting.Items.Add(new ToolStripControlHost(new Label
			{
				Text = ""
			}));
			partnumbersetting.Items.Add(new ToolStripControlHost(new Label
			{
				Text = ""
			}));
			partnumbersetting.Items.Add(new ToolStripControlHost(new Label
			{
				Text = ""
			}));
			partnumbersetting.Items.Add(toolStripControlHost3);
			toolStripControlHost5.AutoSize = false;
			toolStripControlHost5.Width = (int)Math.Round(250.0 * dpixRatio);
			toolStripControlHost5.Height = (int)Math.Round(18.0 * dpixRatio);
			toolStripControlHost3.Dock = DockStyle.Right;
			toolStripControlHost3.AutoSize = true;
			toolStripControlHost.AutoSize = false;
			toolStripControlHost.Width = (int)Math.Round(250.0 * dpixRatio);
			toolStripControlHost.Height = (int)Math.Round(25.0 * dpixRatio);
			toolStripControlHost2.AutoSize = false;
			toolStripControlHost2.Width = (int)Math.Round(250.0 * dpixRatio);
			toolStripControlHost2.Height = (int)Math.Round(25.0 * dpixRatio);
			toolStripControlHost4.AutoSize = false;
			toolStripControlHost4.Height = (int)Math.Round(2.0 * dpixRatio);
			toolStripControlHost4.Width = (int)Math.Round(250.0 * dpixRatio);
			partnumbersetting.BackColor = progb.BackColor;
			partnumbersetting.AutoSize = false;
			partnumbersetting.Width = (int)Math.Round(265.0 * dpixRatio);
			button2.Click += but3_click;
			partnumber_option.SelectedIndexChanged += SelectedIndexChanged1;
			partnumber_intable.TextChanged += textchange1;
		}
	}

	private void SelectedIndexChanged1(object sender, EventArgs e)
	{
		switch (partnumber_option.SelectedIndex)
		{
		case 0:
			partnumber_intable.ReadOnly = true;
			partnumber_intable.PasswordChar = Conversions.ToChar(Interaction.IIf(selcount == 1, "", "*"));
			partnumber_intable.Text = code.SplitStr(Conversions.ToString(DGV1[Col_Path.Index, sel_row].Value), 4);
			break;
		case 1:
			partnumber_intable.ReadOnly = true;
			partnumber_intable.PasswordChar = Conversions.ToChar(Interaction.IIf(selcount == 1, "", "*"));
			partnumber_intable.Text = Conversions.ToString(DGV1[Col_Cfg.Index, sel_row].Value);
			break;
		case 2:
			partnumber_intable.ReadOnly = false;
			partnumber_intable.PasswordChar = '\0';
			partnumber_intable.Text = bd.AlternateName;
			break;
		case 3:
			partnumber_intable.ReadOnly = true;
			partnumber_intable.PasswordChar = Conversions.ToChar(Interaction.IIf(selcount == 1, "", "*"));
			partnumber_intable.Text = bd.ParentName;
			break;
		}
	}

	private void but3_click(object sender, EventArgs e)
	{
		string value = "";
		int num = default(int);
		switch (partnumber_option.SelectedIndex)
		{
		case 0:
			num = 1;
			break;
		case 1:
			num = 2;
			break;
		case 2:
			num = 8;
			value = partnumber_intable.Text;
			break;
		case 3:
			num = 4;
			break;
		}
		checked
		{
			try
			{
				DGV1.Enabled = false;
				progb.Maximum = rlist.Count;
				int num2 = rlist.Count - 1;
				int num3 = 0;
				code.BOMPartData bOMPartData2 = default(code.BOMPartData);
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					progb.Value = num3 + 1;
					try
					{
						Cachedata_BOMPart = "";
						if (code.RunSW(HideWindow: false, startnew: false))
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
							stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
							stringBuilder.AppendLine(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Path.Index, rlist[num3]].Value)));
							stringBuilder.AppendLine(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Cfg.Index, rlist[num3]].Value)));
							stringBuilder.AppendLine(Conversions.ToString(num));
							stringBuilder.AppendLine(value);
							stringBuilder.AppendLine(">");
							string text = stringBuilder.ToString().Trim();
							byte[] bytes = Encoding.Unicode.GetBytes(text);
							int num6 = bytes.Length;
							int value2 = 81;
							code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
							ref IntPtr dwData = ref lParam.dwData;
							dwData = new IntPtr(value2);
							lParam.cbData = num6 + 1;
							lParam.lpData = text;
							code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					object obj = code.DeserializeObject_json(Cachedata_BOMPart, typeof(code.BOMPartData));
					code.BOMPartData bOMPartData = ((obj != null) ? ((code.BOMPartData)obj) : bOMPartData2);
					if (Operators.CompareString(bOMPartData.BOMPartNumber, "", TextCompare: false) != 0)
					{
						DGV1[Col_partnumber.Index, rlist[num3]].Value = bOMPartData.BOMPartNumber;
					}
					num3++;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			finally
			{
				partnumbersetting.Close();
				DGV1.Enabled = true;
			}
		}
	}

	private void textchange1(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (partnumber_option.SelectedIndex == 2)
		{
			bd.AlternateName = textBox.Text;
		}
	}

	private string DisplayDocumentKindForFilter(string value)
	{
		string text = (value ?? string.Empty).Trim();
		return string.Equals(text, "零件", StringComparison.OrdinalIgnoreCase) ? "Деталь" : text;
	}

	private string FilterDocumentKindFromDisplay(string value)
	{
		string text = (value ?? string.Empty).Trim();
		return string.Equals(text, "Деталь", StringComparison.OrdinalIgnoreCase) ? "零件" : text;
	}

	private void Filter_list_ItemClicked1(object sender, ToolStripItemClickedEventArgs e)
	{
		string text = DGV1.Columns[SelectedCol].HeaderText;
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			text = DGV1.Columns[SelectedCol].ToolTipText;
		}
		if (Operators.CompareString(e.ClickedItem.Text, "Сбросить фильтр", TextCompare: false) == 0)
		{
			ClearFilter();
			Filter_list.Close();
		}
		else if (Operators.CompareString(e.ClickedItem.Text, "Из «" + text + "» снять фильтр со столбца", TextCompare: false) == 0)
		{
			RemoveFilter(SelectedCol);
			if (SelectedCol == Col_Checkbox.Index)
			{
				LastCustomFilterButton = null;
			}
			Filter_list.Close();
		}
		else if (Operators.CompareString(e.ClickedItem.Text, "Фильтр", TextCompare: false) == 0)
		{
			lastcolor = null;
			ColFilter(invertbool: false, SelectedCol);
			Filter_list.Close();
		}
		else if (Operators.CompareString(e.ClickedItem.Text, "Фильтр (инверсия)", TextCompare: false) == 0)
		{
			lastcolor = null;
			ColFilter(invertbool: true, SelectedCol);
			Filter_list.Close();
		}
	}

	public bool ColFilter(bool invertbool, int columnindex)
	{
		bool flag = false;
		if (DGV1.RowCount <= 1)
		{
			return false;
		}
		FilterCollist[columnindex].Clear();
		checked
		{
			if (!invertbool)
			{
				if (columnindex == Col_Checkbox.Index)
				{
					int num = Clb.Items.Count - 1;
					int num2 = 1;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (Clb.GetItemCheckState(num2) == CheckState.Checked)
						{
							int num5 = DGV1.RowCount - 1;
							int num6 = 0;
							while (true)
							{
								int num7 = num6;
								num4 = num5;
								if (num7 > num4)
								{
									break;
								}
								if (Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Checkbox.Index, num6].Value)).Equals(Clb.Items[num2].ToString(), StringComparison.OrdinalIgnoreCase) && !FilterCollist[columnindex].Contains(Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num6].Value, DGV1[Col_Cfg.Index, num6].Value))))
								{
									FilterCollist[columnindex].Add(Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num6].Value, DGV1[Col_Cfg.Index, num6].Value)));
								}
								num6++;
							}
						}
						num2++;
					}
					if (FilterCollist[columnindex].Count == 0)
					{
						FilterCollist[columnindex].Add("");
					}
				}
				else if ((columnindex == Col_Material.Index && !Information.IsNothing(RuntimeHelpers.GetObjectValue(lastcolor))) ? true : false)
				{
					FilterCollist[columnindex].Add(lastcolor.ToString());
				}
				else
				{
					int num8 = Clb.Items.Count - 1;
					int num9 = 1;
					while (true)
					{
						int num10 = num9;
						int num4 = num8;
						if (num10 <= num4)
						{
							string item = (columnindex == Col_Extname.Index) ? FilterDocumentKindFromDisplay(Clb.Items[num9].ToString()) : Clb.Items[num9].ToString();
							if (Clb.GetItemCheckState(num9) == CheckState.Checked && !FilterCollist[columnindex].Contains(item))
							{
								FilterCollist[columnindex].Add(item);
							}
							num9++;
							continue;
						}
						break;
					}
				}
			}
			else
			{
				int num11 = DGV1.RowCount - 1;
				int num12 = 0;
				while (true)
				{
					int num13 = num12;
					int num4 = num11;
					if (num13 > num4)
					{
						break;
					}
					bool flag2 = false;
					string text = "";
					text = (((columnindex == Col_Extname.Index) | (columnindex == Col_Drw.Index)) ? Conversions.ToString(DGV1[columnindex, num12].Tag) : ((columnindex != Col_Checkbox.Index) ? Conversions.ToString(DGV1[columnindex, num12].Value) : Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num12].Value, DGV1[Col_Cfg.Index, num12].Value))));
					if (Strings.Len(text) == 0)
					{
						text = "";
					}
					if (columnindex == Col_Checkbox.Index)
					{
						int num14 = Clb.Items.Count - 1;
						int num15 = 1;
						while (true)
						{
							int num16 = num15;
							num4 = num14;
							if (num16 > num4)
							{
								break;
							}
							if (Clb.GetItemCheckState(num15) == CheckState.Checked)
							{
								int num17 = DGV1.RowCount - 1;
								int num18 = 0;
								while (true)
								{
									int num19 = num18;
									num4 = num17;
									if (num19 <= num4)
									{
										if (!Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Checkbox.Index, num18].Value)).Equals(Clb.Items[num15].ToString(), StringComparison.OrdinalIgnoreCase) && string.Equals(Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num18].Value, DGV1[Col_Cfg.Index, num18].Value)), text, StringComparison.CurrentCultureIgnoreCase))
										{
											flag2 = true;
											break;
										}
										num18++;
										continue;
									}
									break;
								}
								break;
							}
							num15++;
						}
						if (Clb.CheckedItems.Count == 1)
						{
							flag2 = true;
						}
					}
					else
					{
						int num20 = Clb.Items.Count - 1;
						int num21 = 1;
						while (true)
						{
							int num22 = num21;
							num4 = num20;
							if (num22 > num4)
							{
								break;
							}
							string item = (columnindex == Col_Extname.Index) ? FilterDocumentKindFromDisplay(Clb.Items[num21].ToString()) : Clb.Items[num21].ToString();
							if (Clb.GetItemCheckState(num21) != CheckState.Checked && string.Equals(item, text, StringComparison.CurrentCultureIgnoreCase))
							{
								flag2 = true;
								break;
							}
							num21++;
						}
					}
					if ((!flag2 && !FilterCollist[columnindex].Contains(text)) ? true : false)
					{
						FilterCollist[columnindex].Add(text);
					}
					num12++;
				}
			}
			FilterColReverse[columnindex] = invertbool;
			return Filter();
		}
	}

	public bool Filter()
	{
		code.EnadleCellEvent = false;
		DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		bool result = false;
		checked
		{
			try
			{
				if (FilterCollist.Count() < DGV1.ColumnCount)
				{
					ClearFilter();
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				string text = "";
				bool flag = false;
				List<int> list = new List<int>();
				int rowCount = DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible);
				int num4 = DGV1.RowCount - 1;
				num = 0;
				while (true)
				{
					int num5 = num;
					int num6 = num4;
					if (num5 > num6)
					{
						break;
					}
					bool expression = false;
					if (!Information.IsNothing(HideCollist))
					{
						expression = HideCollist.Contains(Conversions.ToInteger(DGV1[Col_Number.Index, num].Value));
					}
					bool flag2 = true;
					int num7 = DGV1.ColumnCount - 1;
					num2 = 0;
					while (true)
					{
						int num8 = num2;
						num6 = num7;
						if (num8 > num6)
						{
							break;
						}
						if (!Information.IsNothing(FilterCollist[num2]) && FilterCollist[num2].Count >= 1)
						{
							flag = false;
							text = ((num2 != Col_Extname.Index && (num2 != Col_Drw.Index || 1 == 0)) ? ((num2 == Col_Checkbox.Index) ? Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num].Value, DGV1[Col_Cfg.Index, num].Value)) : (((num2 != Col_Material.Index || Information.IsNothing(RuntimeHelpers.GetObjectValue(lastcolor))) && 0 == 0) ? Conversions.ToString(DGV1[num2, num].Value) : Conversions.ToString(DGV1[num2, num].Style.BackColor.ToArgb()))) : Conversions.ToString(DGV1[num2, num].Tag));
							if (Strings.Len(text) == 0)
							{
								text = "";
							}
							int num9 = FilterCollist[num2].Count - 1;
							num3 = 0;
							while (true)
							{
								int num10 = num3;
								num6 = num9;
								if (num10 > num6)
								{
									break;
								}
								if (string.Equals(text, FilterCollist[num2][num3], StringComparison.CurrentCultureIgnoreCase))
								{
									flag = true;
									break;
								}
								num3++;
							}
							if (flag == FilterColReverse[num2])
							{
								flag2 = false;
								if (!list.Contains(num2))
								{
									list.Add(num2);
								}
								break;
							}
						}
						num2++;
					}
					DGV1.Rows[num].Visible = Conversions.ToBoolean(Interaction.IIf(expression, false, flag2));
					num++;
				}
				int rowCount2 = DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible);
				if (rowCount != rowCount2)
				{
					if (rowCount2 != DGV1.RowCount)
					{
						StatusLabel1.Text = "В " + Conversions.ToString(DGV1.RowCount) + " записях найдено " + Conversions.ToString(rowCount2) + " шт.";
					}
					else
					{
						StatusLabel1.Text = "Всего " + Conversions.ToString(rowCount2) + " поз.";
					}
					int num11 = list.Count - 1;
					num = 0;
					while (true)
					{
						int num12 = num;
						int num6 = num11;
						if (num12 > num6)
						{
							break;
						}
						try
						{
							DGV1.Columns[list[num]].HeaderCell.Style.BackColor = Color.Tomato;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ProjectData.ClearProjectError();
						}
						num++;
					}
					result = true;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				code.EnadleCellEvent = true;
				if (AutoColumnsMode.Checked)
				{
					DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				}
			}
			return result;
		}
	}

	public void RemoveFilter(int col)
	{
		checked
		{
			try
			{
				FilterCollist[col].Clear();
				DGV1.Columns[col].HeaderCell.Style.BackColor = DGV1.ColumnHeadersDefaultCellStyle.BackColor;
				if (col == Col_Checkbox.Index)
				{
					int num = DGV1.RowCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							DGV1[Col_Checkbox.Index, num2].Value = false;
							num2++;
							continue;
						}
						break;
					}
				}
				else if (col == Col_Material.Index)
				{
					lastcolor = null;
				}
				Filter();
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

	public void ClearFilter()
	{
		checked
		{
			try
			{
				int num = 0;
				FilterCollist = new List<string>[DGV1.Columns.Count + 1];
				int num2 = DGV1.Columns.Count - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					FilterCollist[num3] = new List<string>();
					num3++;
				}
				HideCollist.Clear();
				FilterColReverse.Clear();
				int num6 = DGV1.Columns.Count - 1;
				num3 = 0;
				while (true)
				{
					int num7 = num3;
					int num5 = num6;
					if (num7 > num5)
					{
						break;
					}
					FilterColReverse.Add(item: false);
					num3++;
				}
				lastcolor = null;
				if (DGV1.RowCount >= 1)
				{
					int num8 = DGV1.RowCount - 1;
					num3 = 0;
					while (true)
					{
						int num9 = num3;
						int num5 = num8;
						if (num9 > num5)
						{
							break;
						}
						DGV1[Col_Checkbox.Index, num3].Value = false;
						if (!DGV1.Rows[num3].Visible)
						{
							DGV1.Rows[num3].Visible = true;
							num++;
						}
						num3++;
					}
				}
				int num10 = DGV1.ColumnCount - 1;
				num3 = 0;
				while (true)
				{
					int num11 = num3;
					int num5 = num10;
					if (num11 > num5)
					{
						break;
					}
					DGV1.Columns[num3].HeaderCell.Style.BackColor = DGV1.ColumnHeadersDefaultCellStyle.BackColor;
					num3++;
				}
				if (num > 0)
				{
					StatusLabel1.Text = "Всего " + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
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
	}

	public void tsm_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		try
		{
			lastcolor = e.ClickedItem.BackColor.ToArgb();
			ColFilter(invertbool: false, SelectedCol);
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

	public void GetFilterStatus()
	{
		string text = "";
		Filter_list = new ContextMenuStrip();
		string text2 = DGV1.Columns[SelectedCol].HeaderText;
		if (Operators.CompareString(text2, "", TextCompare: false) == 0)
		{
			text2 = DGV1.Columns[SelectedCol].ToolTipText;
		}
		Filter_list.Items.Add("Сбросить фильтр", Resources.Del_Filter);
		Filter_list.Items.Add("Из «" + text2 + "» снять фильтр со столбца", Resources.Del_Filter);
		if (DGV1.Columns[SelectedCol].HeaderCell.Style.BackColor != Color.Tomato)
		{
			Filter_list.Items[1].Enabled = false;
		}
		Filter_list.Items.Add(new ToolStripSeparator());
		SearchBox searchBox = new SearchBox();
		searchBox.AutoSize = false;
		checked
		{
			searchBox.Height = (int)Math.Round(23.0 * dpixRatio);
			tst = new ToolStripControlHost(searchBox);
			Clb = new ToolStripCheckedListBox();
			Filter_list.Items.Add(tst);
			Filter_list.Items.Add(new ToolStripSeparator());
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Фильтр по цвету");
			int num2;
			try
			{
				int num = DGV1.RowCount - 1;
				num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					addcolor(toolStripMenuItem, DGV1[SelectedCol, num2].Style.BackColor.ToArgb());
					markcolor(toolStripMenuItem);
					if (DGV1.Rows[num2].Visible)
					{
						text = ((SelectedCol != Col_Extname.Index && (SelectedCol != Col_Drw.Index || 1 == 0)) ? Conversions.ToString(DGV1[SelectedCol, num2].Value) : Conversions.ToString(DGV1[SelectedCol, num2].Tag));
						if (Strings.Len(text) == 0)
						{
							text = "";
						}
						if (SelectedCol == Col_Extname.Index)
						{
							text = DisplayDocumentKindForFilter(text);
						}
						Clb.AddItem(text, StringComparison.CurrentCultureIgnoreCase);
					}
					num2++;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
				return;
			}
			Filter_list.Items.Add(Clb);
			Filter_list.Items.Add("Фильтр", Resources.Filter);
			Filter_list.Items.Add("Фильтр (инверсия)", Resources.ReFilter);
			if (SelectedCol == Col_Material.Index)
			{
				toolStripMenuItem.DropDownItemClicked += tsm_DropDownItemClicked;
				Filter_list.Items.Add(toolStripMenuItem);
			}
			searchBox.TextChanged += tb2_TextChanged;
			searchBox.MouseEnter += tb2_MouseEnter;
			searchBox.KeyDown += tb2_Keydown;
			int num5 = Filter_list.Items.Count - 1;
			num2 = 0;
			while (true)
			{
				int num6 = num2;
				int num4 = num5;
				if (num6 <= num4)
				{
					Filter_list.Items[num2].MouseEnter += Downlist_MouseEnter;
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void addcolor(ToolStripMenuItem tsm, int argb)
	{
		if (Information.IsNothing(tsm))
		{
			return;
		}
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("             ");
		toolStripMenuItem.CheckOnClick = true;
		checked
		{
			toolStripMenuItem.Height = (int)Math.Round(20.0 * dpixRatio);
			toolStripMenuItem.BackColor = code.ARGBtoColor(argb);
			bool flag = false;
			int num = tsm.DropDownItems.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (tsm.DropDownItems[num2].BackColor.ToArgb() == argb)
				{
					flag = true;
					break;
				}
				num2++;
			}
			if (!flag)
			{
				tsm.DropDownItems.Add(toolStripMenuItem);
			}
		}
	}

	public void markcolor(ToolStripMenuItem tsm)
	{
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(lastcolor)))
		{
			return;
		}
		checked
		{
			int num = tsm.DropDownItems.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if ((double)tsm.DropDownItems[num2].BackColor.ToArgb() == Conversions.ToDouble(lastcolor.ToString()))
				{
					tsm.Checked = true;
					break;
				}
				num2++;
			}
			if (!tsm.Checked)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("             ");
				toolStripMenuItem.Height = (int)Math.Round(20.0 * dpixRatio);
				toolStripMenuItem.BackColor = code.ARGBtoColor(Conversions.ToInteger(lastcolor.ToString()));
				toolStripMenuItem.Checked = true;
				tsm.Checked = true;
				tsm.DropDownItems.Add(toolStripMenuItem);
			}
		}
	}

	private void tb2_MouseEnter(object sender, EventArgs e)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip((Control)sender, "Несколько условий разделяются «&» или «|»\n&: и\n|: или");
	}

	private void tb2_TextChanged(object sender, EventArgs e)
	{
		int num = 0;
		string text = ((TextBox)sender).Text;
		checked
		{
			try
			{
				if (Operators.CompareString(text, "", TextCompare: false) == 0)
				{
					int num2 = Clb.Items.Count - 1;
					int num3 = 1;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 <= num5)
						{
							Clb.SetItemState(num3, CheckState.Checked);
							num++;
							num3++;
							continue;
						}
						break;
					}
					return;
				}
				bool flag = false;
				string[] array;
				if (text.Contains("|"))
				{
					array = Strings.Split(text, "|");
					flag = false;
				}
				else
				{
					array = Strings.Split(text, "&");
					flag = true;
				}
				if (!flag)
				{
					int num6 = Clb.Items.Count - 1;
					int num7 = 1;
					while (true)
					{
						int num8 = num7;
						int num5 = num6;
						if (num8 > num5)
						{
							break;
						}
						bool flag2 = false;
						int num9 = array.Length - 1;
						int num10 = 0;
						while (true)
						{
							int num11 = num10;
							num5 = num9;
							if (num11 > num5)
							{
								break;
							}
							if (Operators.CompareString(array[num10], "", TextCompare: false) != 0 && Strings.InStr(Clb.Items[num7].ToString(), array[num10], CompareMethod.Text) > 0)
							{
								flag2 = true;
								break;
							}
							num10++;
						}
						if (flag2)
						{
							Clb.SetItemState(num7, CheckState.Checked);
							num++;
						}
						else
						{
							Clb.SetItemState(num7, CheckState.Unchecked);
						}
						num7++;
					}
					return;
				}
				int num12 = Clb.Items.Count - 1;
				int num13 = 1;
				while (true)
				{
					int num14 = num13;
					int num5 = num12;
					if (num14 > num5)
					{
						break;
					}
					bool flag3 = false;
					int num15 = array.Length - 1;
					int num16 = 0;
					while (true)
					{
						int num17 = num16;
						num5 = num15;
						if (num17 > num5)
						{
							break;
						}
						if (Operators.CompareString(array[num16], "", TextCompare: false) != 0 && Strings.InStr(Clb.Items[num13].ToString(), array[num16], CompareMethod.Text) <= 0)
						{
							flag3 = true;
							break;
						}
						num16++;
					}
					if (flag3)
					{
						Clb.SetItemState(num13, CheckState.Unchecked);
					}
					else
					{
						Clb.SetItemState(num13, CheckState.Checked);
						num++;
					}
					num13++;
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
	}

	private void tb2_Keydown(object sender, KeyEventArgs e)
	{
		if ((e.Control && e.KeyCode == Keys.V) ? true : false)
		{
			e.SuppressKeyPress = true;
			try
			{
				string text = Clipboard.GetText();
				string[] sourceArray = text.Split(new string[2] { "\r\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
				TextBox textBox = (TextBox)sender;
				textBox.SelectedText = Strings.Join(sourceArray, "|");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	public void clearrowerror()
	{
		checked
		{
			try
			{
				Rowlist_Savefailed.Clear();
				DGV1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
				DGV1.RowHeadersWidth = 20;
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						DGV1.Rows[num2].ErrorText = "";
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

	public void RegHotKey()
	{
		try
		{
			int num2 = default(int);
			int num3 = default(int);
			int num = 0 - ((0 - ((num2 == num3) ? 1 : 0) == 0) ? 1 : 0);
			int vk = 0;
			checked
			{
				int num4 = CConfigMng.Config.Preview_Hotkey.Count - 1;
				int num5 = 0;
				while (true)
				{
					int num6 = num5;
					int num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					string left = CConfigMng.Config.Preview_Hotkey[num5];
					if (Operators.CompareString(left, Conversions.ToString(17), TextCompare: false) == 0)
					{
						num = 2;
					}
					else if (Operators.CompareString(left, Conversions.ToString(16), TextCompare: false) == 0)
					{
						num2 = 4;
					}
					else if (Operators.CompareString(left, Conversions.ToString(18), TextCompare: false) == 0)
					{
						num3 = 1;
					}
					else if (Operators.CompareString(code.KeyCodeToStr((int)Math.Round(Conversion.Val(CConfigMng.Config.Preview_Hotkey[num5]))), "", TextCompare: false) != 0)
					{
						vk = (int)Math.Round(Conversion.Val(CConfigMng.Config.Preview_Hotkey[num5]));
					}
					num5++;
				}
				int fsModifiers = num + num2 + num3;
				code.UnRegisterHotKey(Handle, Preview_HotKey);
				code.RegisterHotKey(Handle, Preview_HotKey, fsModifiers, vk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void UnRegHotKey()
	{
		code.UnRegisterHotKey(Handle, Preview_HotKey);
	}

	public void DoubleBuffer(DataGridView DGV)
	{
		Type type = DGV.GetType();
		PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		property.SetValue(DGV, true, null);
	}

	public void insetpropcol()
	{
		try
		{
			DgvClear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		checked
		{
			try
			{
				int num = 0;
				int num2 = DGV1.Columns.Count - 1 - num;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 <= num5)
					{
						if (Strings.InStr(1, DGV1.Columns[num3 - num].Name, "Prop") > 0)
						{
							DGV1.Columns.RemoveAt(num3 - num);
							num++;
						}
						num3++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				int num6 = DGV1.Columns.Count - 1;
				int num7 = 0;
				while (true)
				{
					int num8 = num7;
					int num5 = num6;
					if (num8 <= num5)
					{
						DGV1.Columns[num7].Frozen = false;
						num7++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				logopathlist.WriteLog($"Тип исключения: {ex6.GetType().Name}\r\nСообщение: {ex6.Message}\r\nИнформация: {ex6.StackTrace}");
				MessageBox.Show(ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (CConfigMng.Config.propname.Count < 1)
				{
					return;
				}
				int num9 = CConfigMng.Config.propname.Count - 1;
				int num10 = 0;
				while (true)
				{
					int num11 = num10;
					int num5 = num9;
					if (num11 <= num5)
					{
						string headerText = CConfigMng.Config.propname[num10];
						string toolTipText = CConfigMng.Config.proptype[num10];
						string columnName = "PropVal_" + Conversions.ToString(num10);
						string columnName2 = "PropResolvedVal_" + Conversions.ToString(num10);
						DGV1.Columns.Add(columnName, headerText);
						DGV1.Columns[columnName].Visible = !PropSwitch.Checked;
						DGV1.Columns[columnName].ToolTipText = toolTipText;
						DGV1.Columns[columnName].DisplayIndex = Col_Material.DisplayIndex + 1 + num10 * 2;
						DGV1.Columns.Add(columnName2, headerText);
						DGV1.Columns[columnName2].Visible = PropSwitch.Checked;
						DGV1.Columns[columnName2].ReadOnly = true;
						DGV1.Columns[columnName2].DefaultCellStyle.BackColor = DGV1.ColumnHeadersDefaultCellStyle.BackColor;
						DGV1.Columns[columnName2].DisplayIndex = Col_Material.DisplayIndex + 1 + num10 * 2 + 1;
						DGV1.Columns[columnName].MinimumWidth = (int)Math.Round(20.0 * dpixRatio);
						DGV1.Columns[columnName2].MinimumWidth = (int)Math.Round(20.0 * dpixRatio);
						DGV1.Columns[columnName].Width = (int)Math.Round(100.0 * dpixRatio);
						DGV1.Columns[columnName2].Width = (int)Math.Round(100.0 * dpixRatio);
						num10++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				logopathlist.WriteLog($"Тип исключения: {ex8.GetType().Name}\r\nСообщение: {ex8.Message}\r\nИнформация: {ex8.StackTrace}");
				MessageBox.Show(ex8.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				ClearFilter();
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				logopathlist.WriteLog($"Тип исключения: {ex10.GetType().Name}\r\nСообщение: {ex10.Message}\r\nИнформация: {ex10.StackTrace}");
				MessageBox.Show(ex10.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				DGV1.Columns[Convert.ToInt32(CConfigMng.Config.FrozenCol)].Frozen = true;
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				CConfigMng.Config.FrozenCol = -1;
				ProjectData.ClearProjectError();
			}
		}
	}

	public void SelRowColor()
	{
		MyProject.Forms.FrmOptions.FrmOptions_Load(MyProject.Forms.FrmOptions, null);
		DGV1.DefaultCellStyle.SelectionForeColor = DGV1.DefaultCellStyle.ForeColor;
	}

	public void Markrepeat()
	{
		checked
		{
			try
			{
				if (DGV1.RowCount < 1 || DGV1.Columns[CConfigMng.Config.markrepeat].ReadOnly)
				{
					return;
				}
				Hashtable hashtable = new Hashtable();
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					DGV1.Rows[num2].Cells[CConfigMng.Config.markrepeat].Style.BackColor = DGV1.RowsDefaultCellStyle.BackColor;
					string text = Conversions.ToString(DGV1.Rows[num2].Cells[CConfigMng.Config.markrepeat].Value);
					if (Operators.CompareString(text, "", TextCompare: false) != 0)
					{
						if (!hashtable.ContainsKey(text))
						{
							hashtable.Add(text, num2);
						}
						else
						{
							DGV1.Rows[num2].Cells[CConfigMng.Config.markrepeat].Style.BackColor = Color.OrangeRed;
							int index = (int)hashtable[text];
							DGV1.Rows[index].Cells[CConfigMng.Config.markrepeat].Style.BackColor = Color.OrangeRed;
						}
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
		}
	}

	public void unMarkrepeat()
	{
		checked
		{
			try
			{
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						DGV1.Rows[num2].Cells[CConfigMng.Config.markrepeat].Style.BackColor = DGV1.RowsDefaultCellStyle.BackColor;
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
		}
	}

	public int isrepeat(string str, int rowindex)
	{
		int result = -1;
		string text = Conversions.ToString(DGV1[Col_Path.Index, rowindex].Value);
		checked
		{
			try
			{
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (num2 != rowindex)
					{
						string text2 = Conversions.ToString(DGV1[Col_Path.Index, num2].Value);
						object objectValue = RuntimeHelpers.GetObjectValue(DGV1[Col_FileName.Index, num2].Value);
						if (!string.Equals(text, text2, StringComparison.OrdinalIgnoreCase) && string.Equals(code.SplitStr(text, 5), code.SplitStr(text2, 5), StringComparison.OrdinalIgnoreCase) && 0 == 0 && (string.Equals(Conversions.ToString(objectValue), str, StringComparison.OrdinalIgnoreCase) || (string.Equals(code.SplitStr(text2, 1), str, StringComparison.OrdinalIgnoreCase) ? true : false)))
						{
							result = Conversions.ToInteger(DGV1[Col_Number.Index, num2].Value);
							break;
						}
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
			return result;
		}
	}

	public string LookupTopAsmName()
	{
		string text = "";
		return code.SplitStr(Conversions.ToString(DGV1.Tag), 1);
	}

	public void ReadonlyRowMark()
	{
		if (DGV1.RowCount < 1)
		{
			return;
		}
		CustomFilter customFilter = new CustomFilter(CConfigMng.Config.SaveToSWFilterRule);
		checked
		{
			int num = DGV1.RowCount - 1;
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 < num3)
				{
					break;
				}
				DGV1.Rows[num].HeaderCell.Style.BackColor = DGV1.RowHeadersDefaultCellStyle.BackColor;
				DGV1.Rows[num].HeaderCell.Style.SelectionBackColor = DGV1.RowHeadersDefaultCellStyle.BackColor;
				try
				{
					string text = Conversions.ToString(DGV1[Col_Path.Index, num].Value);
					string path = code.SplitStr(text, 3) + ".SLDDRW";
					if (File.Exists(path))
					{
						DGV1[Col_Drw.Index, num].Tag = "Есть";
						DGV1[Col_Drw.Index, num].Value = Resources.slddrw;
					}
					else
					{
						DGV1[Col_Drw.Index, num].Tag = "Нет";
						DGV1[Col_Drw.Index, num].Value = null;
					}
					if (!string.IsNullOrEmpty(text) && (customFilter.FilterByRule(num) || (code.IsReadOnly(text) ? true : false)))
					{
						DGV1.Rows[num].HeaderCell.Style.BackColor = CT.ReadOnlyRowColor;
						DGV1.Rows[num].HeaderCell.Style.SelectionBackColor = CT.ReadOnlyRowColor;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				num += -1;
			}
		}
	}

	public void addctl()
	{
		checked
		{
			try
			{
				if (!((sel_col < 0) | (sel_row < 0) | (sel_row > DGV1.RowCount - 1) | (sel_col > DGV1.ColumnCount - 1)))
				{
					if (((sel_col == Col_Material.Index && Operators.ConditionalCompareObjectEqual(DGV1[Col_Extname.Index, sel_row].Tag, "零件", TextCompare: false)) || DGV1.Columns[sel_col].Name.Contains("PropVal_") || sel_col == Col_Cfg.Index || sel_col == Col_Author.Index || sel_col == Col_Comment.Index || sel_col == Col_Keywords.Index || sel_col == Col_Subject.Index || sel_col == Col_Subject.Index || sel_col == Col_Title.Index || sel_col == Col_partnumber.Index) ? true : false)
					{
						Rectangle cellDisplayRectangle = DGV1.GetCellDisplayRectangle(sel_col, sel_row, cutOverflow: true);
						CustomComboBox1 comboBox = ComboBox1;
						Point location = new Point(Conversions.ToInteger(Interaction.IIf(DGV1.Right < cellDisplayRectangle.Right + ComboBox1.Width, cellDisplayRectangle.Right - ComboBox1.Width, cellDisplayRectangle.Right)), cellDisplayRectangle.Bottom - ComboBox1.Height);
						comboBox.Location = location;
						ComboBox1.Visible = true;
						ComboBox1.Refresh();
					}
					else
					{
						ComboBox1.Visible = false;
					}
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
	}

	public void DgvClear()
	{
		TV1.Nodes.Clear();
		DGV1.Rows.Clear();
		DGV1.Controls.Clear();
		DGV1.Controls.Add(ComboBox1);
		ComboBox1.Visible = false;
		StatusLabel1.Text = "";
	}

	public void ResetCol()
	{
		checked
		{
			try
			{
				int num = DGV1.Columns.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						DGV1.Columns[num2].Frozen = false;
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
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				Col_Preview.DisplayIndex = 0;
				Col_Checkbox.DisplayIndex = 1;
				Col_Extname.DisplayIndex = 2;
				Col_Drw.DisplayIndex = 3;
				Col_Number.DisplayIndex = 4;
				Col_FileName.DisplayIndex = 5;
				Col_NewFolder.DisplayIndex = 6;
				Col_Material.DisplayIndex = 7;
				Col_Quantity.DisplayIndex = 8;
				Col_Path.DisplayIndex = 9;
				Col_Cfg.DisplayIndex = 10;
				Col_Weight.DisplayIndex = 11;
				Col_bound.DisplayIndex = 12;
				Col_Level.DisplayIndex = 13;
				Col_CreationTime.DisplayIndex = 14;
				Col_SaveTime.DisplayIndex = 15;
				Col_Author.DisplayIndex = 16;
				Col_Keywords.DisplayIndex = 17;
				Col_Comment.DisplayIndex = 18;
				Col_Subject.DisplayIndex = 19;
				Col_Title.DisplayIndex = 20;
				foreach (DataGridViewColumn column in DGV1.Columns)
				{
					if (!((column.Index == Col_Preview.Index) | (column.Index == Col_Checkbox.Index)))
					{
						column.Visible = true;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void SetColIndex()
	{
		checked
		{
			try
			{
				int num = DGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					int num5 = CConfigMng.Config.ColIndex.Count - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						int num8 = Conversions.ToInteger(CConfigMng.Config.ColIndex[num6].Split('\n')[0]);
						int num9 = Conversions.ToInteger(CConfigMng.Config.ColIndex[num6].Split('\n')[1]);
						if ((num9 == num2 && num8 < DGV1.ColumnCount && num9 < DGV1.ColumnCount) ? true : false)
						{
							DGV1.Columns[num8].DisplayIndex = num9;
							break;
						}
						num6++;
					}
					num2++;
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

	public void LoadColumnInfo()
	{
		checked
		{
			try
			{
				if (CConfigMng.Config.columnInfolist.Count < 1)
				{
					SetColIndex();
					SetColWidth();
					SetColvisble();
					return;
				}
				int num = DGV1.ColumnCount - 1;
				int num2 = 0;
				_Closure_0024__50 closure_0024__ = default(_Closure_0024__50);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					closure_0024__ = new _Closure_0024__50(closure_0024__);
					closure_0024__._0024VB_0024Local_findstr = num2;
					ColumnInfo columnInfo = CConfigMng.Config.columnInfolist.Find(closure_0024__._Lambda_0024__99);
					if ((!Information.IsNothing(columnInfo) && columnInfo.index < DGV1.ColumnCount) ? true : false)
					{
						if (columnInfo.DisplayIndex < DGV1.ColumnCount)
						{
							DGV1.Columns[columnInfo.index].DisplayIndex = columnInfo.DisplayIndex;
						}
						if (columnInfo.Width > DGV1.Columns[columnInfo.index].MinimumWidth)
						{
							DGV1.Columns[columnInfo.index].Width = columnInfo.Width;
						}
						if (((columnInfo.index != Col_Preview.Index && columnInfo.index != Col_Checkbox.Index) ? true : false) && !DGV1.Columns[columnInfo.index].Name.Contains("PropResolvedVal_"))
						{
							DGV1.Columns[columnInfo.index].Visible = columnInfo.Visible;
						}
					}
					if (DGV1.Columns[num2].Name.Contains("PropResolvedVal_"))
					{
						DGV1.Columns[num2].Visible = false;
					}
					num2++;
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

	public void SaveColumnInfo()
	{
		checked
		{
			try
			{
				CConfigMng.Config.columnInfolist.Clear();
				int num = DGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					ColumnInfo columnInfo = new ColumnInfo();
					columnInfo.index = num2;
					columnInfo.DisplayIndex = DGV1.Columns[num2].DisplayIndex;
					columnInfo.Width = DGV1.Columns[num2].Width;
					columnInfo.Visible = DGV1.Columns[num2].Visible;
					CConfigMng.Config.columnInfolist.Add(columnInfo);
					num2++;
				}
				CConfigMng.SaveConfig();
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

	public void SetColWidth()
	{
		checked
		{
			try
			{
				int num = CConfigMng.Config.ColWidth.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string[] array = Strings.Split(CConfigMng.Config.ColWidth[num2], "\n");
					if (array.Length > 1)
					{
						int num5 = Conversions.ToInteger(array[0]);
						int num6 = Conversions.ToInteger(array[1]);
						if (DGV1.Columns[num5].AutoSizeMode != DataGridViewAutoSizeColumnMode.None && ((num5 < DGV1.ColumnCount) & (num6 > DGV1.Columns[num5].MinimumWidth)))
						{
							DGV1.Columns[num5].Width = num6;
						}
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
		}
	}

	public void SetColvisble()
	{
		checked
		{
			try
			{
				if (CConfigMng.Config.Colvisible.Count >= 1)
				{
					int num = CConfigMng.Config.Colvisible.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						string[] array = Strings.Split(CConfigMng.Config.Colvisible[num2], "\n");
						unchecked
						{
							if (array.Length == 2)
							{
								int num5 = Conversions.ToInteger(array[0]);
								bool flag = Conversions.ToBoolean(Interaction.IIf(Operators.CompareString(array[1], "", TextCompare: false) == 0, true, code.Cbool1(array[1])));
								if (((num5 < DGV1.ColumnCount) & (num5 != Col_Preview.Index) & (num5 != Col_Checkbox.Index)) && !DGV1.Columns[num5].Name.Contains("PropResolvedVal_") && !flag)
								{
									DGV1.Columns[num5].Visible = flag;
								}
							}
							else if (array.Length == 3)
							{
								int num6 = Conversions.ToInteger(array[0]);
								bool flag2 = Conversions.ToBoolean(Interaction.IIf(Operators.CompareString(array[2], "", TextCompare: false) == 0, true, code.Cbool1(array[2])));
								if (((num6 < DGV1.ColumnCount) & (num6 != Col_Preview.Index) & (num6 != Col_Checkbox.Index)) && !DGV1.Columns[num6].Name.Contains("PropResolvedVal_") && !flag2)
								{
									DGV1.Columns[num6].Visible = flag2;
								}
							}
						}
						num2++;
					}
				}
				int num7 = DGV1.ColumnCount - 1;
				int num8 = 0;
				while (true)
				{
					int num9 = num8;
					int num4 = num7;
					if (num9 <= num4)
					{
						if (DGV1.Columns[num8].Name.Contains("PropResolvedVal_"))
						{
							DGV1.Columns[num8].Visible = false;
						}
						num8++;
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
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ColorRow()
	{
		if (DGV1.DisplayedRowCount(includePartialRow: true) < 2)
		{
			return;
		}
		int num = 0;
		checked
		{
			int num2 = DGV1.RowCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (DGV1.Rows[num3].Visible)
				{
					if (!rlist.Contains(num3))
					{
						if (unchecked(num % 2) == 0)
						{
							DGV1.Rows[num3].DefaultCellStyle.BackColor = DGV1.RowsDefaultCellStyle.BackColor;
						}
						else
						{
							DGV1.Rows[num3].DefaultCellStyle.BackColor = Color.FromArgb(210, 225, 243);
						}
					}
					else
					{
						DGV1.Rows[num3].DefaultCellStyle.BackColor = Color.FromName(MyProject.Forms.FrmOptions.GetSelectedRowColorName());
					}
					num++;
				}
				num3++;
			}
		}
	}

	public void GetSelRowCount()
	{
		rlist.Clear();
		selcount = 0;
		checked
		{
			try
			{
				if (DGV1.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
				{
					foreach (DataGridViewCell selectedCell in DGV1.SelectedCells)
					{
						if (selectedCell.ColumnIndex == sel_col && DGV1.Rows[selectedCell.RowIndex].Visible)
						{
							selcount++;
							if (!rlist.Contains(selectedCell.RowIndex))
							{
								rlist.Add(selectedCell.RowIndex);
							}
						}
					}
				}
				else
				{
					foreach (DataGridViewRow selectedRow in DGV1.SelectedRows)
					{
						if (selectedRow.Visible)
						{
							selcount++;
						}
					}
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
			StatusLabel2.Text = Conversions.ToString(Interaction.IIf(selcount == 0, "", "Выбрано " + Conversions.ToString(selcount) + " строк"));
		}
	}

	public void lockbutton()
	{
		_ConnectSW.Enabled = false;
		_BatchExport.Enabled = false;
		_BatchPrint.Enabled = false;
		_BatchReplace.Enabled = false;
		_BatchReplaceParts.Enabled = false;
		_SyncDrwName.Enabled = false;
		_mergepdf.Enabled = false;
		code.canrun = false;
		KeyPreview = false;
	}

	public void Unlockbutton()
	{
		_ConnectSW.Enabled = true;
		_BatchExport.Enabled = true;
		_BatchPrint.Enabled = true;
		_BatchReplace.Enabled = true;
		_BatchReplaceParts.Enabled = true;
		_SyncDrwName.Enabled = true;
		_mergepdf.Enabled = true;
		code.canrun = true;
		KeyPreview = true;
	}

	public void test()
	{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		timer.Interval = 1000;
		timer.Enabled = true;
		Unlockbutton();
		timer.Tick += TestTime_Tick;
	}

	public void TestTime_Tick(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
				k1 = (int)Math.Round((double)k1 + (double)timer.Interval / 1000.0);
				code.UTTime = k1;
				if ((double)k1 <= (double)(int.Parse("C", NumberStyles.HexNumber) * int.Parse("F", NumberStyles.HexNumber)) / 3.0 + (double)(2 * int.Parse(code.TTime3, NumberStyles.HexNumber)))
				{
					foreach (Form openForm in Application.OpenForms)
					{
						if (openForm.Equals(this))
						{
							openForm.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(Application.ProductName + " ", Application.ProductVersion.ToString()), Interaction.IIf(Environment.Is64BitProcess, "(x64)", "(x86)")), Strings.Space(5)), "Пробный период... осталось"), (double)(int.Parse("C", NumberStyles.HexNumber) * int.Parse("F", NumberStyles.HexNumber)) / 3.0 + (double)(2 * int.Parse(code.TTime3, NumberStyles.HexNumber)) - (double)k1), "секунда"));
						}
						else if ((openForm.Equals(MyProject.Forms.FrmOutputlist) || openForm.Equals(MyProject.Forms.FrmPrintlist) || openForm.Equals(MyProject.Forms.FrmReplacePartslist) || openForm.Equals(MyProject.Forms.FrmSetDrwlist) || openForm.Equals(MyProject.Forms.FrmSyncDrwName) || openForm.Equals(MyProject.Forms.Frmmerge_split_pdf)) ? true : false)
						{
							openForm.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(openForm.Tag, Strings.Space(5)), "Пробный период... осталось"), (double)(int.Parse("C", NumberStyles.HexNumber) * int.Parse("F", NumberStyles.HexNumber)) / 3.0 + (double)(2 * int.Parse(code.TTime3, NumberStyles.HexNumber)) - (double)k1), "секунда"));
						}
					}
					return;
				}
				timer.Stop();
				lockbutton();
				code.MessageBoxTimeoutA(Application.OpenForms[0].Handle, "Пробный период истёк! Программа закроется через 10 секунд!", "Сообщение", 0, 0, 10000);
				Environment.Exit(0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				Environment.Exit(0);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void g_monitor()
	{
		System.Timers.Timer timer = new System.Timers.Timer();
		timer.Interval = 10.0;
		timer.Elapsed += tmr_Elapsed;
		code.g_trig = true;
		timer.Start();
	}

	public void tmr_Elapsed(object sender, EventArgs e)
	{
		System.Timers.Timer timer = (System.Timers.Timer)sender;
		try
		{
			if (!code.g_trig)
			{
				return;
			}
			code.g_trig = false;
			Prog1 prog = new Prog1();
			Prog2 prog2 = new Prog2();
			SR sR = new SR();
			if (!prog.exit_g() || !prog2.exit_g())
			{
				string text = "";
				string use_date = "";
				if (!sR.IsReg2("来生缘。。。", ref text, ref use_date))
				{
					goto IL_0068;
				}
			}
			if (false)
			{
				goto IL_0068;
			}
			ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__102);
			code.canrun = true;
			goto IL_00f3;
			IL_00f3:
			timer.Stop();
			timer.Dispose();
			return;
			IL_0068:
			if (!code.TMode)
			{
				ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__100);
				if (!code.TMode)
				{
					timer.Stop();
					timer.Dispose();
					Environment.Exit(0);
				}
			}
			else if (k1 == 0)
			{
				ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__101);
			}
			goto IL_00f3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
	}

	protected override void WndProc(ref Message m)
	{
		checked
		{
			try
			{
				if (m.Msg == 786)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(MyProject.Forms.FrmPreview.Tag, MyProject.Forms.FrmPreview.Text), filename_inselitem + cfgname_inselitem, TextCompare: false))
					{
						code.Preview2(CConfigMng.Config.DefaultDrw, filename_inselitem, cfgname_inselitem, this);
						preview_selrow = sel_row;
						Focus();
					}
				}
				else if (m.Msg == 74)
				{
					Type type = default(code.COPYDATASTRUCT).GetType();
					object lParam = m.GetLParam(type);
					code.COPYDATASTRUCT cOPYDATASTRUCT2 = default(code.COPYDATASTRUCT);
					code.COPYDATASTRUCT cOPYDATASTRUCT = ((lParam != null) ? ((code.COPYDATASTRUCT)lParam) : cOPYDATASTRUCT2);
					IntPtr dwData = cOPYDATASTRUCT.dwData;
					if (dwData == (IntPtr)0)
					{
						ToolStripProgressBar1.Maximum = (int)Math.Round(Conversion.Val(cOPYDATASTRUCT.lpData));
					}
					else if (dwData == (IntPtr)1)
					{
						StatusLabel1.Text = cOPYDATASTRUCT.lpData;
					}
					else if (dwData == (IntPtr)2)
					{
						if (Conversion.Val(cOPYDATASTRUCT.lpData) <= (double)ToolStripProgressBar1.Maximum)
						{
							ToolStripProgressBar1.Value = (int)Math.Round(Conversion.Val(cOPYDATASTRUCT.lpData));
						}
					}
					else if (dwData == (IntPtr)3)
					{
						Cachedata_bom = cOPYDATASTRUCT.lpData;
					}
					else if (dwData == (IntPtr)4)
					{
						Cachedata_pre = cOPYDATASTRUCT.lpData;
					}
					else if (dwData == (IntPtr)5)
					{
						_Closure_0024__51 closure_0024__ = new _Closure_0024__51();
						closure_0024__._0024VB_0024Local_str = Strings.Split(cOPYDATASTRUCT.lpData, "\r\n");
						if (closure_0024__._0024VB_0024Local_str.Length < 4)
						{
							return;
						}
						if (code.Cbool1(closure_0024__._0024VB_0024Local_str[0]))
						{
							int num = DGV1.RowCount - 1;
							int num2 = 0;
							while (true)
							{
								int num3 = num2;
								int num4 = num;
								if (num3 > num4)
								{
									break;
								}
								if (string.Equals(Conversions.ToString(DGV1[Col_Path.Index, num2].Value), closure_0024__._0024VB_0024Local_str[1], StringComparison.OrdinalIgnoreCase))
								{
									DGV1[Col_Path.Index, num2].Value = closure_0024__._0024VB_0024Local_str[2];
									if ((Operators.ConditionalCompareObjectEqual(DGV1[Col_Level.Index, num2].Value, 0, TextCompare: false) && Operators.ConditionalCompareObjectEqual(DGV1[Col_Number.Index, num2].Value, 1, TextCompare: false)) ? true : false)
									{
										DGV1.Tag = closure_0024__._0024VB_0024Local_str[2];
									}
								}
								num2++;
							}
							ListViewVR listView = MyProject.Forms.FrmFileList.ListView1;
							int num5 = listView.Items.Count - 1;
							int num6 = 0;
							while (true)
							{
								int num7 = num6;
								int num4 = num5;
								if (num7 > num4)
								{
									break;
								}
								string text = listView.Items[num6].SubItems[1].Text;
								if (text.Equals(closure_0024__._0024VB_0024Local_str[1], StringComparison.OrdinalIgnoreCase))
								{
									listView.Items[num6].SubItems[1].Text = closure_0024__._0024VB_0024Local_str[2];
								}
								num6++;
							}
							listView = null;
							refreshnodename(TV1.Nodes, closure_0024__._0024VB_0024Local_str[1], closure_0024__._0024VB_0024Local_str[2]);
						}
						int num8 = (int)Math.Round(Conversion.Val(closure_0024__._0024VB_0024Local_str[3]));
						if (closure_0024__._0024VB_0024Local_str.Length < 5)
						{
							return;
						}
						closure_0024__._0024VB_0024Local_str = closure_0024__._0024VB_0024Local_str.Where(closure_0024__._Lambda_0024__103).ToArray();
						if (closure_0024__._0024VB_0024Local_str.Length > 0)
						{
							Rowlist_Savefailed.Add(num8);
							if (Rowlist_Savefailed.Count == 1)
							{
								DGV1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
							}
							DGV1.Rows[num8].ErrorText = string.Join("\r\n", closure_0024__._0024VB_0024Local_str);
							MyProject.Forms.Frmtips.additem(1, Conversions.ToString(DGV1[Col_Number.Index, num8].Value), string.Join("；", closure_0024__._0024VB_0024Local_str), "Сохранить в SW", Conversions.ToString(DGV1[Col_Path.Index, num8].Value));
						}
					}
					else if (dwData == (IntPtr)6)
					{
						logopathlist.WriteLog(cOPYDATASTRUCT.lpData);
					}
					else if (dwData == (IntPtr)7)
					{
						Cachedata_Feature = cOPYDATASTRUCT.lpData;
					}
					else if (dwData == (IntPtr)8)
					{
						Cachedata_Material = cOPYDATASTRUCT.lpData;
					}
					else if (dwData == (IntPtr)9)
					{
						Cachedata_BOMPart = cOPYDATASTRUCT.lpData;
					}
					else if (dwData == (IntPtr)1000)
					{
						openid = cOPYDATASTRUCT.lpData;
						BeginInvoke(new VB_0024AnonymousDelegate_2(_Lambda_0024__104));
						IntPtr result = new IntPtr(1);
						m.Result = result;
						return;
					}
				}
				else if (m.Msg != 12)
				{
				}
				base.WndProc(ref m);
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

	private void BringToFrontSafely()
	{
		if (InvokeRequired)
		{
			BeginInvoke(new VB_0024AnonymousDelegate_2(_Lambda_0024__105));
			return;
		}
		Show();
		WindowState = FormWindowState.Normal;
		Form form = null;
		switch (openid)
		{
		case "1000":
			form = this;
			break;
		case "1001":
			form = MyProject.Forms.FrmOutputlist;
			break;
		case "1002":
			form = MyProject.Forms.FrmPrintlist;
			break;
		case "1003":
			form = MyProject.Forms.FrmSetDrwlist;
			break;
		case "1004":
			form = MyProject.Forms.FrmReplacePartslist;
			break;
		case "1005":
			form = MyProject.Forms.FrmSyncDrwName;
			break;
		case "1006":
			form = MyProject.Forms.Frmmerge_split_pdf;
			break;
		case "1120":
			form = MyProject.Forms.CheckUpdate;
			break;
		case "1130":
			form = MyProject.Forms.FrmAbout;
			break;
		}
		if (form != null && !form.IsDisposed && 0 == 0)
		{
			form.Show();
			if (form.WindowState == FormWindowState.Minimized)
			{
				form.WindowState = FormWindowState.Normal;
			}
			ActivateWindow(form.Handle);
		}
	}

	private void ActivateWindow(IntPtr hWnd)
	{
		if (!(hWnd == IntPtr.Zero))
		{
			code.ShowWindow((int)hWnd, 9);
			code.keybd_event(18, 0, 0u, UIntPtr.Zero);
			code.keybd_event(18, 0, 2u, UIntPtr.Zero);
			code.SetForegroundWindow(hWnd);
		}
	}

	public void GetAsm(bool specific = false)
	{
		if (SaveToSWBgWorker.IsBusy | GetAsmBgWorker.IsBusy)
		{
			return;
		}
		GetDataOption = CConfigMng.Config.GetDataOption;
		code.togetherConfig = CConfigMng.Config.togetherConfig;
		try
		{
			if (!code.RunSW())
			{
				return;
			}
			string a = "";
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "ActiveDoc", new object[0], null, null, null));
			if (objectValue != null)
			{
				a = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
			}
			if (DGV1.RowCount > 0)
			{
				if (specific)
				{
					if (!code.OpenTopAsm(Resolve: false))
					{
						return;
					}
				}
				else
				{
					DialogResult dialogResult = default(DialogResult);
					if (string.Equals(a, Conversions.ToString(DGV1.Tag), StringComparison.OrdinalIgnoreCase))
					{
						string text = "Получить данные заново?";
						dialogResult = MessageBox.Show(this, text, "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
					}
					else
					{
						dialogResult = MessageBoxEX.Show(this, "Получить данные заново?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, new string[3] { "Подключить предыдущий документ", "Подключить текущий документ", "Отмена" });
					}
					switch ((int)dialogResult)
					{
					case 6:
						if (!code.OpenTopAsm(Resolve: false))
						{
							return;
						}
						break;
					case 2:
						objectValue = null;
						return;
					}
				}
			}
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(code.swApp)))
			{
				objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "ActiveDoc", new object[0], null, null, null));
			}
			if (objectValue == null)
			{
				MessageBox.Show(this, "В SolidWorks нет открытых файлов, сначала откройте файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				code.swApp = null;
				return;
			}
			a = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
			if (Strings.Len(a) == 0)
			{
				MessageBox.Show(this, "Активный документ SolidWorks возможно не сохранён, сначала сохраните его", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				code.swApp = null;
				return;
			}
			string left = Strings.Right(Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null)), 7).ToUpper();
			if (Operators.CompareString(left, ".SLDPRT", TextCompare: false) == 0)
			{
				code.T.Restart();
				if ((GetDataOption != 0) | (GetDataOption != 1))
				{
					GetDataOption = 0;
				}
			}
			else
			{
				if (Operators.CompareString(left, ".SLDASM", TextCompare: false) != 0)
				{
					MessageBox.Show(this, "Текущий активный документ не поддерживается", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				code.T.Restart();
				if ((GetDataOption == 0) | (GetDataOption == 1))
				{
					if (!CConfigMng.Config.ExcludeLight)
					{
						code.ResolveAll(RuntimeHelpers.GetObjectValue(objectValue));
					}
				}
				else if (GetDataOption == 2)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "SelectionManager", new object[0], null, null, null));
					if (Operators.ConditionalCompareObjectLess(NewLateBinding.LateGet(objectValue2, null, "GetSelectedObjectCount", new object[0], null, null, null), 1, TextCompare: false))
					{
					}
					objectValue2 = null;
				}
				else if (GetDataOption != 3)
				{
				}
			}
			if (code.Receiver_hWnd == IntPtr.Zero)
			{
				M_FindWindow m_FindWindow = new M_FindWindow();
				code.Receiver_hWnd = m_FindWindow.FindChildHwnd(code.CurSWID, code.Receiver_Title);
				int num = 0;
				while (code.Receiver_hWnd == IntPtr.Zero)
				{
					Thread.Sleep(200);
					num = checked(num + 200);
					if (num > 600)
					{
						break;
					}
					code.Receiver_hWnd = m_FindWindow.FindChildHwnd(code.CurSWID, code.Receiver_Title);
				}
			}
			if (code.Receiver_hWnd == IntPtr.Zero)
			{
				MessageBox.Show(this, "Надстройка не запущена!");
				return;
			}
			objectValue = null;
			DgvClear();
			code.StartSwitch(status: true);
			clearrowerror();
			Cachedata_bom = "";
			Cachedata_Feature = "";
			code.SetSWUnit();
			lockbutton2();
			ToolStripProgressBar1.Style = ProgressBarStyle.Blocks;
			ToolStripProgressBar1.Visible = true;
			IsStop.Visible = true;
			code.EnadleCellEvent = false;
			DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			GetAsmBgWorker.WorkerSupportsCancellation = true;
			GetAsmBgWorker.WorkerReportsProgress = true;
			GetAsmBgWorker.RunWorkerAsync();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, "Ошибка при подготовке к чтению данных SW:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void lockbutton2()
	{
		_BatchExport.Enabled = false;
		_BatchPrint.Enabled = false;
		_BatchReplace.Enabled = false;
		_BatchReplaceParts.Enabled = false;
		_SyncDrwName.Enabled = false;
		_copyswfile.Enabled = false;
		_fastfilter.Enabled = false;
		_Ribbon.Enabled = false;
		PreviewSwitch1.Enabled = false;
		_CloseSwDoc.Enabled = false;
		DGV1.Enabled = false;
	}

	public void unlockbutton2()
	{
		_SaveToSW.Enabled = true;
		_BatchExport.Enabled = true;
		_BatchPrint.Enabled = true;
		_BatchReplace.Enabled = true;
		_BatchReplaceParts.Enabled = true;
		_SyncDrwName.Enabled = true;
		_copyswfile.Enabled = true;
		_fastfilter.Enabled = true;
		_Ribbon.Enabled = true;
		PreviewSwitch1.Enabled = true;
		_CloseSwDoc.Enabled = true;
		DGV1.Enabled = true;
	}

	public void GetFromFile()
	{
		if (GetAsmBgWorker.IsBusy)
		{
			return;
		}
		checked
		{
			try
			{
				GetDataOption = CConfigMng.Config.GetDataOption;
				if (MyProject.Forms.FrmFileList.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				StringBuilder stringBuilder = new StringBuilder();
				ListViewVR listView = MyProject.Forms.FrmFileList.ListView1;
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
					if ((code.TMode && num2 > 9) ? true : false)
					{
						MessageBox.Show(this, "Пробная версия поддерживает не более 10 файлов", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						break;
					}
					stringBuilder.AppendLine(listView.Items[num2].SubItems[1].Text);
					num2++;
				}
				ToolStripProgressBar1.Maximum = listView.Items.Count;
				listView = null;
				if (stringBuilder.Length > 0 && code.RunSW())
				{
					if (code.Receiver_hWnd == IntPtr.Zero)
					{
						MessageBox.Show(this, "Надстройка не запущена");
						return;
					}
					code.T.Restart();
					sendfilelist(stringBuilder.ToString().Trim());
					DgvClear();
					code.StartSwitch(status: true);
					clearrowerror();
					Cachedata_bom = "";
					Cachedata_Feature = "";
					code.SetSWUnit();
					lockbutton2();
					StatusLabel1.Text = "Открытие файла с диска";
					ToolStripProgressBar1.Style = ProgressBarStyle.Blocks;
					ToolStripProgressBar1.Visible = true;
					IsStop.Visible = true;
					code.EnadleCellEvent = false;
					DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
					GetAsmBgWorker.WorkerSupportsCancellation = true;
					GetAsmBgWorker.WorkerReportsProgress = true;
					GetAsmBgWorker.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void sendfilelist(string str)
	{
		try
		{
			byte[] bytes = Encoding.Unicode.GetBytes(str);
			int num = bytes.Length;
			int value = 15;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = str;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void GetAsmBgWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
			stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
			stringBuilder.AppendLine(Conversions.ToString(GetDataOption));
			stringBuilder.AppendLine(Conversions.ToString(code.togetherConfig));
			stringBuilder.AppendLine(Conversions.ToString(CConfigMng.Config.Excludevirtual));
			stringBuilder.AppendLine(Conversions.ToString(CConfigMng.Config.ExcludeLight));
			stringBuilder.AppendLine(Conversions.ToString(code.Cbool1(Conversions.ToString(CConfigMng.Config.GetAllconfigsbool))));
			stringBuilder.AppendLine(Conversions.ToString(code.Mass_Decimals));
			stringBuilder.AppendLine(code.ToHexString(string.Join("\n", CConfigMng.Config.propname)));
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 10;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, "Ошибка при чтении данных SW:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void GetAsmBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			loadfeaturetree(Cachedata_Feature);
			readstr(Cachedata_bom);
			Markrepeat();
			code.EnadleCellEvent = true;
			code.InsertPicBool = false;
			unlockbutton2();
			if (PreviewSwitch1.Checked)
			{
				code.InsertPic2();
			}
			if (CConfigMng.Config.ReConnectClearFilter != 0)
			{
				ClearFilter();
			}
			else
			{
				Filter();
			}
			ToolStripProgressBar1.Visible = false;
			ToolStripProgressBar1.Value = 0;
			IsStop.Visible = false;
			ReadonlyRowMark();
			if (AutoColumnsMode.Checked)
			{
				DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			}
			code.swApp = null;
			code.T.Stop();
			int rowCount = DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible);
			if (rowCount < DGV1.RowCount)
			{
				StatusLabel1.Text = "Подключение завершено, затрачено " + Strings.FormatNumber((double)code.T.ElapsedMilliseconds / 1000.0, 1) + " сек, всего " + Conversions.ToString(rowCount) + "/" + Conversions.ToString(DGV1.RowCount) + " поз.";
			}
			else
			{
				StatusLabel1.Text = "Подключение завершено, затрачено " + Strings.FormatNumber((double)code.T.ElapsedMilliseconds / 1000.0, 1) + " сек, всего " + Conversions.ToString(DGV1.RowCount) + " поз.";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, "Ошибка при загрузке данных:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	public void readstr(string str)
	{
		string text = "";
		string topcfgName = "";
		StringReader stringReader = null;
		checked
		{
			try
			{
				code.DataFromAsm = false;
				DGV1.Rows.Clear();
				int num = DGV1.RowCount;
				DGV1.Columns[Col_Drw.Index].DefaultCellStyle.NullValue = Resources.@null;
				DGV1.Columns[Col_Extname.Index].DefaultCellStyle.NullValue = Resources.sldprt;
				DGV1.Tag = "";
				DGV1.topcfgName = "";
				Tag = "";
				if (Strings.Len(str) > 0)
				{
					stringReader = new StringReader(str);
					while (stringReader.Peek() > -1)
					{
						string expression = stringReader.ReadLine();
						if (Strings.Len(expression) == 0)
						{
							continue;
						}
						string[] array = Strings.Split(expression, "\u001e\u001c");
						if ((Operators.CompareString(array[0], "PathFileName", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							text = array[1];
							DGV1.Rows.Add();
							DGV1.Rows[num].Tag = "False";
							DGV1.Rows[num].Height = CConfigMng.Config.rowheight;
							DGV1[Col_Path.Index, num].Value = text;
							DGV1[Col_FileName.Index, num].Value = code.SplitStr(text, 1);
							DGV1[Col_NewFolder.Index, num].Value = code.SplitStr(text, 6);
							if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
							{
								DGV1[Col_Extname.Index, num].Tag = "Сборка";
								DGV1[Col_Extname.Index, num].Value = Resources.sldasm;
							}
							else
							{
								DGV1[Col_Extname.Index, num].Tag = "零件";
							}
							DGV1[Col_Checkbox.Index, num].Value = false;
							DGV1[Col_Number.Index, num].Value = num + 1;
							DGV1[Col_Drw.Index, num].Tag = "Нет";
							if ((File.Exists(code.SplitStr(text, 3) + ".SLDDRW") && !text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase)) ? true : false)
							{
								DGV1[Col_Drw.Index, num].Value = Resources.slddrw;
								DGV1[Col_Drw.Index, num].Tag = "Есть";
							}
						}
						else if ((Operators.CompareString(array[0], "ConfigureName", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							topcfgName = array[1];
							DGV1[Col_Cfg.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "NLevel", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Level.Index, num].Value = Strings.Space((int)Math.Round(2.0 * Conversion.Val(array[1]))) + array[1];
							if ((Conversion.Val(array[1]) == 0.0 && num == 0) ? true : false)
							{
								DGV1.Tag = text;
								DGV1.topcfgName = topcfgName;
							}
						}
						else if ((Operators.CompareString(array[0], "DataFromAsm", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							code.DataFromAsm = code.Cbool1(array[1]);
						}
						else if ((Operators.CompareString(array[0], "isbendstate", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Number.Index, num].Tag = array[1];
						}
						else if ((Operators.CompareString(array[0], "isweldment", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Path.Index, num].Tag = array[1];
						}
						else if ((Operators.CompareString(array[0], "Quantity", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Quantity.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "weight", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Weight.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "Boundarysize", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_bound.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "CreationTime", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_CreationTime.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "SaveTime", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_SaveTime.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "Author", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Author.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "Comment", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Comment.Index, num].Value = code.FromHexString(array[1]);
						}
						else if ((Operators.CompareString(array[0], "Keywords", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Keywords.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "Subject", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Subject.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "Title", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_Title.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "material", TextCompare: false) == 0 && array.Length >= 3) ? true : false)
						{
							if (DGV1[Col_Extname.Index, num].Tag.ToString().EndsWith("零件"))
							{
								DGV1[Col_Material.Index, num].Value = array[1];
								Color backColor = ColorTranslator.FromWin32(Conversions.ToInteger(array[2]));
								DGV1[Col_Material.Index, num].Style.BackColor = backColor;
								if ((backColor.R < 120 || backColor.G < 120 || backColor.B < 120) ? true : false)
								{
									DGV1[Col_Material.Index, num].Style.ForeColor = Color.White;
								}
								DGV1[Col_Material.Index, num].Tag = new object[2]
								{
									DGV1[Col_Material.Index, num].Style.BackColor,
									DGV1[Col_Material.Index, num].Style.ForeColor
								};
							}
						}
						else if ((Operators.CompareString(array[0], "BOMPartNumber", TextCompare: false) == 0 && array.Length >= 2) ? true : false)
						{
							DGV1[Col_partnumber.Index, num].Value = array[1];
						}
						else if ((Operators.CompareString(array[0], "PropName", TextCompare: false) == 0 && array.Length >= 5) ? true : false)
						{
							int num2 = DGV1.Columns.Count - 1;
							int num3 = 0;
							while (true)
							{
								int num4 = num3;
								int num5 = num2;
								if (num4 > num5)
								{
									break;
								}
								if (string.Equals(DGV1.Columns[num3].HeaderText, array[1], StringComparison.OrdinalIgnoreCase))
								{
									if (DGV1.Columns[num3].Name.Contains("PropVal_"))
									{
										DGV1[num3, num].Value = code.FromHexString(array[2]);
										DGV1[num3, num].Tag = array[4];
									}
									else if (DGV1.Columns[num3].Name.Contains("PropResolvedVal_"))
									{
										DGV1[num3, num].Value = code.FromHexString(array[3]);
									}
								}
								num3++;
							}
						}
						else if (Operators.CompareString(array[0], ">", TextCompare: false) == 0)
						{
							num++;
						}
					}
				}
				else
				{
					logopathlist.WriteLog(string.Format("Сообщение об ошибке: {0}", "Не удалось прочитать корректные данные"));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					stringReader.Close();
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

	public void loadfeaturetree(string str)
	{
		try
		{
			if (Operators.CompareString(str.Trim(), "", TextCompare: false) != 0)
			{
				XmlDocument xmlDocument = new XmlDocument();
				TV1.Nodes.Clear();
				TV1.BeginUpdate();
				xmlDocument.LoadXml(str);
				RecursionTreeControl(xmlDocument.DocumentElement, TV1.Nodes);
				TV1.TopNode.Expand();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			TV1.EndUpdate();
		}
	}

	public void RecursionTreeControl(XmlNode xmlNode, TreeNodeCollection nodes, int level = 0)
	{
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (!Information.IsNothing(childNode))
			{
				Treenode treenode = new Treenode();
				treenode.PathName = code.FromHexString(childNode.Attributes["PathName"].Value);
				treenode.ConfigureName = code.FromHexString(childNode.Attributes["ConfigureName"].Value);
				treenode.ExcludeFromBOM = code.Cbool1(childNode.Attributes["ExcludeFromBOM"].Value);
				treenode.DisplayInBOM = Conversions.ToInteger(childNode.Attributes["DisplayInBOM"].Value);
				treenode.IsSuppressed = code.Cbool1(childNode.Attributes["IsSuppressed"].Value);
				treenode.FeatureName = code.FromHexString(childNode.Attributes["FeatureName"].Value);
				treenode.Text = code.SplitStr(treenode.PathName, 1) + " (" + treenode.ConfigureName + ")";
				if ((treenode.DisplayInBOM == 3 && level > 0) ? true : false)
				{
					treenode.Text = code.SplitStr(treenode.PathName, 1) + " (" + treenode.ConfigureName + ") (распустить в спецификации)";
				}
				else if ((treenode.DisplayInBOM == 1 && level > 0) ? true : false)
				{
					treenode.Text = code.SplitStr(treenode.PathName, 1) + " (" + treenode.ConfigureName + ") (скрыть подэлементы в спецификации)";
				}
				if (treenode.ExcludeFromBOM)
				{
					treenode.Text = code.SplitStr(treenode.PathName, 1) + " (" + treenode.ConfigureName + ") (не включать в спецификацию)";
				}
				if (treenode.IsSuppressed)
				{
					treenode.ForeColor = Color.Gray;
				}
				else
				{
					treenode.ForeColor = Control.DefaultForeColor;
				}
				if (string.Equals(code.SplitStr(treenode.PathName, 5), ".sldasm", StringComparison.OrdinalIgnoreCase))
				{
					treenode.ImageIndex = 0;
					treenode.SelectedImageIndex = 0;
				}
				else if (string.Equals(code.SplitStr(treenode.PathName, 5), ".sldprt", StringComparison.OrdinalIgnoreCase))
				{
					treenode.ImageIndex = 1;
					treenode.SelectedImageIndex = 1;
				}
				nodes.Add(treenode);
				RecursionTreeControl(childNode, treenode.Nodes, checked(level + 1));
			}
		}
	}

	public void SaveToSW()
	{
		if (!(SaveToSWBgWorker.IsBusy | GetAsmBgWorker.IsBusy) && (!code.DataFromAsm || code.OpenTopAsm()) && 0 == 0)
		{
			code.T.Restart();
			sendsaveoptions();
			sendunitdata();
			sendsavelist();
			clearrowerror();
			code.EnadleCellEvent = false;
			StatusLabel1.Text = "Сохранение файла";
			ToolStripProgressBar1.Visible = true;
			IsStop.Visible = true;
			lockbutton2();
			DGV1.Enabled = false;
			SaveToSWBgWorker.WorkerSupportsCancellation = true;
			SaveToSWBgWorker.WorkerReportsProgress = true;
			SaveToSWBgWorker.RunWorkerAsync();
		}
	}

	private void SaveToSWBgWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 34;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, "Ошибка при сохранении в SW:\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void SaveToSWBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		unlockbutton2();
		DGV1.Enabled = true;
		code.EnadleCellEvent = true;
		ToolStripProgressBar1.Visible = false;
		ToolStripProgressBar1.Value = 0;
		IsStop.Visible = false;
		code.swApp = null;
		code.T.Stop();
		StatusLabel1.Text = "Сохранение завершено, затрачено" + Strings.FormatNumber((double)code.T.ElapsedMilliseconds / 1000.0, 1) + "секунда";
		if (Rowlist_Savefailed.Count > 0)
		{
			MessageBox.Show(this, Conversions.ToString(Rowlist_Savefailed.Count) + "Не удалось сохранить элемент", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else if (MessageBox.Show(this, "Сохранение завершено, рекомендуется заново получить данные!", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
		{
			if (GetDataOption == 4)
			{
				GetFromFile();
			}
			else
			{
				GetAsm(specific: true);
			}
		}
	}

	public void sendsaveoptions()
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
			stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
			stringBuilder.AppendLine(code.propsaveplace.ToString());
			stringBuilder.AppendLine(code.keepnullvalue.ToString());
			stringBuilder.AppendLine(code.DelCurProp_OtherPosition.ToString());
			stringBuilder.AppendLine(code.DelCurProp_OtherPosition_place.ToString());
			stringBuilder.AppendLine(code.DelOtherProp.ToString());
			stringBuilder.AppendLine(code.DelOtherProp_place.ToString());
			stringBuilder.AppendLine(code.CanSetUnit.ToString());
			stringBuilder.AppendLine(code.SaveAfterModify.ToString());
			stringBuilder.AppendLine(code.overwrite.ToString());
			stringBuilder.AppendLine(Conversions.ToString(code.oldfile_moveto));
			stringBuilder.AppendLine(code.Updatereferencebool.ToString());
			stringBuilder.AppendLine(code.UpdatereferenceIncludesubfolders.ToString());
			stringBuilder.AppendLine(code.Updatereferencefolder);
			stringBuilder.AppendLine(CConfigMng.Config.materialpath);
			stringBuilder.AppendLine(code.targetpath);
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 31;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void sendunitdata()
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
			stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
			stringBuilder.AppendLine(Conversions.ToString(code.UnitsSystem));
			stringBuilder.AppendLine(Conversions.ToString(code.Basic_Length));
			stringBuilder.AppendLine(Conversions.ToString(code.Basic_Length_Decimals));
			stringBuilder.AppendLine(Conversions.ToString(code.Basic_DualDimension));
			stringBuilder.AppendLine(Conversions.ToString(code.Basic_DualDimension_Decimals));
			stringBuilder.AppendLine(Conversions.ToString(code.Basic_Angle));
			stringBuilder.AppendLine(Conversions.ToString(code.Basic_Angle_Decimals));
			stringBuilder.AppendLine(Conversions.ToString(code.Mass_Length));
			stringBuilder.AppendLine(Conversions.ToString(code.Mass_Mass));
			stringBuilder.AppendLine(Conversions.ToString(code.Mass_Volume));
			stringBuilder.AppendLine(Conversions.ToString(code.Mass_Decimals));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Time));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Force));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Power));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Energy));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Time_Decimal));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Force_Decimal));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Power_Decimal));
			stringBuilder.AppendLine(Conversions.ToString(code.Motion_Energy_Decimal));
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 32;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void sendsavelist()
	{
		checked
		{
			try
			{
				CustomFilter customFilter = new CustomFilter(CConfigMng.Config.SaveToSWFilterRule);
				bool flag = false;
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (code.Cbool1(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1.Rows[num2].Tag))))
					{
						flag = true;
						break;
					}
					num2++;
				}
				ToolStripProgressBar1.Maximum = 0;
				StringBuilder stringBuilder = new StringBuilder();
				int num5 = DGV1.RowCount;
				_Closure_0024__52 closure_0024__ = default(_Closure_0024__52);
				while (true)
				{
					int num6 = num5;
					int num4 = 1;
					if (num6 < num4)
					{
						break;
					}
					closure_0024__ = new _Closure_0024__52(closure_0024__);
					closure_0024__._0024VB_0024Me = this;
					closure_0024__._0024VB_0024Local_val = Conversions.ToString(num5);
					DataGridViewRow dataGridViewRow = DGV1.Rows.Cast<DataGridViewRow>().Where(closure_0024__._Lambda_0024__106).First();
					int index = dataGridViewRow.Index;
					if ((code.SkipReadOnly && code.IsReadOnly(Conversions.ToString(DGV1[Col_Path.Index, index].Value))) ? true : false)
					{
						MyProject.Forms.Frmtips.additem(0, Conversions.ToString(DGV1[Col_Number.Index, index].Value), "Пропускать элементы «только чтение»", "Сохранить в SW", Conversions.ToString(DGV1[Col_Path.Index, index].Value));
					}
					else
					{
						if ((code.DataFromAsm && Operators.ConditionalCompareObjectEqual(DGV1[Col_Level.Index, index].Value, 0, TextCompare: false)) ? true : false)
						{
							if ((code.SaveOptions == 1 && !flag) ? true : false)
							{
								MyProject.Forms.Frmtips.additem(0, Conversions.ToString(DGV1[Col_Number.Index, index].Value), "Пропускать неизменённые элементы", "Сохранить в SW", Conversions.ToString(DGV1[Col_Path.Index, index].Value));
								goto IL_0947;
							}
						}
						else
						{
							if ((code.SaveOptions == 1 && !code.Cbool1(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1.Rows[index].Tag)))) ? true : false)
							{
								MyProject.Forms.Frmtips.additem(0, Conversions.ToString(DGV1[Col_Number.Index, index].Value), "Пропускать неизменённые элементы", "Сохранить в SW", Conversions.ToString(DGV1[Col_Path.Index, index].Value));
								goto IL_0947;
							}
							if ((code.SaveOptions == 2 && Operators.CompareString(DGV1.Rows[index].ErrorText, "", TextCompare: false) == 0) ? true : false)
							{
								MyProject.Forms.Frmtips.additem(0, Conversions.ToString(DGV1[Col_Number.Index, index].Value), "Пропускать элементы без ошибок", "Сохранить в SW", Conversions.ToString(DGV1[Col_Path.Index, index].Value));
								goto IL_0947;
							}
							if (customFilter.FilterByRule(index))
							{
								MyProject.Forms.Frmtips.additem(0, Conversions.ToString(DGV1[Col_Number.Index, index].Value), "Пропускать отфильтрованные элементы", "Сохранить в SW", Conversions.ToString(DGV1[Col_Path.Index, index].Value));
								goto IL_0947;
							}
						}
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("CfgName\u001e\u001c", DGV1[Col_Cfg.Index, index].Value)));
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("NewMaterial\u001e\u001c", DGV1[Col_Material.Index, index].Value)));
						stringBuilder.AppendLine("ModelColor\u001e\u001c" + Conversions.ToString(ColorTranslator.ToWin32(DGV1[Col_Material.Index, index].Style.BackColor)));
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("Author\u001e\u001c", DGV1[Col_Author.Index, index].Value)));
						stringBuilder.AppendLine("Comment\u001e\u001c" + code.ToHexString(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[Col_Comment.Index, index].Value))));
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("Keywords\u001e\u001c", DGV1[Col_Keywords.Index, index].Value)));
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("Subject\u001e\u001c", DGV1[Col_Subject.Index, index].Value)));
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("Title\u001e\u001c", DGV1[Col_Title.Index, index].Value)));
						string text = "";
						string text2 = "";
						string text3 = "";
						string text4 = "";
						int num7 = DGV1.Columns.Count - 1;
						int num8 = 0;
						while (true)
						{
							int num9 = num8;
							num4 = num7;
							if (num9 > num4)
							{
								break;
							}
							if (Strings.InStr(1, DGV1.Columns[num8].Name, "PropVal_") > 0)
							{
								text2 = DGV1.Columns[num8].HeaderText;
								text3 = Conversions.ToString(code.GetFieldType(DGV1.Columns[num8].ToolTipText));
								text = ((Conversions.ToDouble(text3) != 11.0) ? code.ToHexString(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[num8, index].Value))) : code.ToHexString(code.YesOrNo(Conversions.ToString(DGV1[num8, index].Value))));
								text4 = Conversions.ToString(DGV1[num8, index].Tag);
								stringBuilder.AppendLine("PropName\u001e\u001c" + text2 + "\u001e\u001c" + text3 + "\u001e\u001c" + text + "\u001e\u001c" + text4);
							}
							num8++;
						}
						stringBuilder.AppendLine("RowNumber\u001e\u001c" + Conversions.ToString(index));
						if ((code.DataFromAsm && Operators.ConditionalCompareObjectEqual(DGV1[Col_Level.Index, index].Value, 0, TextCompare: false)) ? true : false)
						{
							stringBuilder.AppendLine("End\u001e\u001cTrue");
						}
						else
						{
							stringBuilder.AppendLine("End\u001e\u001cFalse");
						}
						stringBuilder.AppendLine("IsChanged\u001e\u001c" + Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1.Rows[index].Tag)));
						if (DGV1.Columns[Col_NewFolder.Index].Visible)
						{
							stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("NewPathName\u001e\u001c", DGV1[Col_NewFolder.Index, index].Value), "\\"), DGV1[Col_FileName.Index, index].Value), code.SplitStr(Conversions.ToString(DGV1[Col_Path.Index, index].Value), 5))));
						}
						else
						{
							stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("NewPathName\u001e\u001c" + code.SplitStr(Conversions.ToString(DGV1[Col_Path.Index, index].Value)), DGV1[Col_FileName.Index, index].Value), code.SplitStr(Conversions.ToString(DGV1[Col_Path.Index, index].Value), 5))));
						}
						stringBuilder.AppendLine(Conversions.ToString(Operators.ConcatenateObject("OldPathName\u001e\u001c", DGV1[Col_Path.Index, index].Value)));
						ToolStripProgressBar1.Maximum += 1;
					}
					goto IL_0947;
					IL_0947:
					num5 += -1;
				}
				string text5 = stringBuilder.ToString().Trim();
				byte[] bytes = Encoding.Unicode.GetBytes(text5);
				int num10 = bytes.Length;
				int value = 33;
				code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
				ref IntPtr dwData = ref lParam.dwData;
				dwData = new IntPtr(value);
				lParam.cbData = num10 + 1;
				lParam.lpData = text5;
				code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private string ResolveBomTemplateMappingName(int columnIndex)
	{
		string headerText = DGV1.Columns[columnIndex].HeaderText;
		string columnName = DGV1.Columns[columnIndex].Name;
		columnnamemapping columnnamemapping2 = CConfigMng.Config.namemappinglist.Find((columnnamemapping s) => string.Equals(s.text ?? "", headerText ?? "", StringComparison.OrdinalIgnoreCase) && (string.Equals(s.name ?? "", columnName ?? "", StringComparison.OrdinalIgnoreCase) || string.Equals(s.name2 ?? "", columnName ?? "", StringComparison.OrdinalIgnoreCase)));
		if (Information.IsNothing(columnnamemapping2))
		{
			columnnamemapping2 = CConfigMng.Config.namemappinglist.Find((columnnamemapping s) => string.Equals(s.name ?? "", columnName ?? "", StringComparison.OrdinalIgnoreCase) || string.Equals(s.name2 ?? "", columnName ?? "", StringComparison.OrdinalIgnoreCase));
		}
		if (!Information.IsNothing(columnnamemapping2) && Operators.CompareString(columnnamemapping2.mappingname, "", TextCompare: false) != 0)
		{
			return columnnamemapping2.mappingname;
		}
		return headerText;
	}

	public void ExportBom_xls1(bomsetting bst)
	{
		_Closure_0024__53 closure_0024__ = new _Closure_0024__53();
		if (DGV1.RowCount < 1 || DGV1.ColumnCount < 1 || false || DGV1.RowCount > 65536 || DGV1.ColumnCount > 255 || false || !code.canrun)
		{
			return;
		}
		string bomname = bst.bomname;
		if (!File.Exists(bomname))
		{
			MessageBox.Show(this, "Сначала задайте шаблон спецификации", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.DefaultExt = Path.GetExtension(bomname);
		saveFileDialog.FileName = LookupTopAsmName() + "-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
		string extension = Path.GetExtension(bomname);
		saveFileDialog.SupportMultiDottedExtensions = true;
		saveFileDialog.Filter = "Книга Excel (*" + extension + "）|*" + extension;
		saveFileDialog.ValidateNames = true;
		if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string text = saveFileDialog.FileName;
		if (Operators.CompareString(text.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		int num = 0;
		int num2 = bst.image_width;
		int num3 = bst.image_height;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		object objectValue2 = RuntimeHelpers.GetObjectValue(new object());
		object objectValue3 = RuntimeHelpers.GetObjectValue(new object());
		checked
		{
			try
			{
				StatusLabel1.Text = "Запуск Excel....";
				objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application"));
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				NewLateBinding.LateSet(objectValue, null, "Visible", new object[1] { false }, null, null);
				object instance = NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Application", new object[0], null, null, null), null, "Workbooks", new object[0], null, null, null);
				object[] array = new object[1] { bomname };
				object[] arguments = array;
				bool[] array2 = new bool[1] { true };
				object obj = NewLateBinding.LateGet(instance, null, "Add", arguments, null, null, array2);
				if (array2[0])
				{
					bomname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				objectValue2 = RuntimeHelpers.GetObjectValue(obj);
				objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "ActiveSheet", new object[0], null, null, null));
				StatusLabel1.Text = "Разбор файла шаблона....";
				int num4 = DGV1.ColumnCount - 1;
				int num5 = 0;
				int num8 = default(int);
				while (true)
				{
					int num6 = num5;
					int num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					try
					{
						_Closure_0024__53._Closure_0024__54 closure_0024__2 = new _Closure_0024__53._Closure_0024__54();
						closure_0024__2._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A36_2F = closure_0024__;
						if ((!DGV1.Columns[num5].Name.Contains("PropVal_") || !bst.Propertyvalue) && 0 == 0 && (!DGV1.Columns[num5].Name.Contains("PropResolvedVal_") || bst.Propertyvalue) && 0 == 0)
						{
							string text2 = ResolveBomTemplateMappingName(num5);
							object instance2 = objectValue2;
							object[] array3 = new object[1] { text2 };
							object[] arguments2 = array3;
							array2 = new bool[1] { true };
							object instance3 = NewLateBinding.LateGet(instance2, null, "Names", arguments2, null, null, array2);
							if (array2[0])
							{
								text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
							}
							num8 = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(instance3, null, "RefersToRange", new object[0], null, null, null), null, "Row", new object[0], null, null, null));
							object instance4 = objectValue2;
							array3 = new object[1] { text2 };
							object[] arguments3 = array3;
							array2 = new bool[1] { true };
							object instance5 = NewLateBinding.LateGet(instance4, null, "Names", arguments3, null, null, array2);
							if (array2[0])
							{
								text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
							}
							int item = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(instance5, null, "RefersToRange", new object[0], null, null, null), null, "Column", new object[0], null, null, null));
							list.Add(item);
							list2.Add(num5);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					num5++;
				}
				if (list.Count >= 1)
				{
					if ((bst.insertimagebool && !code.InsertPicBool) ? true : false)
					{
						StatusLabel1.Text = "Создание эскизов....";
						code.InsertPic2();
					}
					CustomFilter customFilter = null;
					if (bst.ByRuler)
					{
						customFilter = new CustomFilter(bst.RulesList);
					}
					StatusLabel1.Text = "Экспорт спецификации....";
					ToolStripProgressBar1.Maximum = DGV1.RowCount - 1;
					ToolStripProgressBar1.Visible = true;
					num = 1;
					int num9 = DGV1.RowCount - 1;
					int num10 = 0;
					while (true)
					{
						int num11 = num10;
						int num7 = num9;
						if (num11 > num7)
						{
							break;
						}
						if ((((!bst.ByRuler || Information.IsNothing(customFilter)) && 0 == 0) || customFilter.FilterByRule(num10)) && (!bst.ByFilter || DGV1.Rows[num10].Visible))
						{
							bool flag = false;
							int num12 = list.Count - 1;
							int num13 = 0;
							while (true)
							{
								int num14 = num13;
								num7 = num12;
								if (num14 > num7)
								{
									break;
								}
								if (list2[num13] == Col_Number.Index)
								{
									NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
									{
										num8 + num,
										list[num13],
										num
									}, null, null);
									flag = true;
								}
								else if ((list2[num13] == Col_Preview.Index && bst.insertimagebool) ? true : false)
								{
									if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[list2[num13], num10].Value)))
									{
										object instance6 = objectValue3;
										array = new object[2]
										{
											num8 + num,
											null
										};
										object[] array4 = array;
										List<int> list3 = list;
										int index = num13;
										array4[1] = list3[index];
										object[] array3 = array;
										object[] arguments4 = array3;
										array2 = new bool[2] { false, true };
										object obj2 = NewLateBinding.LateGet(instance6, null, "cells", arguments4, null, null, array2);
										if (array2[1])
										{
											list3[index] = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
										}
										object instance7 = obj2;
										NewLateBinding.LateSetComplex(instance7, null, "RowHeight", new object[1] { num3 + 2 }, null, null, OptimisticSet: false, RValueBase: true);
										NewLateBinding.LateSetComplex(instance7, null, "ColumnWidth", new object[1] { (double)num2 / 6.0 }, null, null, OptimisticSet: false, RValueBase: true);
										int num15 = Conversions.ToInteger(Operators.AddObject(NewLateBinding.LateGet(instance7, null, "Top", new object[0], null, null, null), 1));
										int num16 = Conversions.ToInteger(Operators.AddObject(NewLateBinding.LateGet(instance7, null, "Left", new object[0], null, null, null), 1));
										instance7 = null;
										Image image = new Bitmap((Image)DGV1[list2[num13], num10].Value, 256, 192);
										string text3 = logopathlist.PreviewFolder + code.SplitStr(Conversions.ToString(DGV1[Col_Path.Index, num10].Value), 1) + ".jpg";
										image.Save(text3, ImageFormat.Jpeg);
										object instance8 = NewLateBinding.LateGet(objectValue3, null, "Shapes", new object[0], null, null, null);
										array = new object[7] { text3, false, true, num16, num15, num2, num3 };
										object[] arguments5 = array;
										array2 = new bool[7] { true, false, false, true, true, true, true };
										NewLateBinding.LateCall(instance8, null, "AddPicture", arguments5, null, null, array2, IgnoreReturn: true);
										if (array2[0])
										{
											text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
										}
										if (array2[3])
										{
											num16 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[3]), typeof(int));
										}
										if (array2[4])
										{
											num15 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[4]), typeof(int));
										}
										if (array2[5])
										{
											num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[5]), typeof(int));
										}
										if (array2[6])
										{
											num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[6]), typeof(int));
										}
										File.Delete(text3);
										flag = true;
									}
								}
								else if (list2[num13] == Col_Quantity.Index)
								{
									NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
									{
										num8 + num,
										list[num13],
										Operators.MultiplyObject(_Quantityratio.DecimalValue, DGV1[list2[num13], num10].Value)
									}, null, null);
								}
								else if ((list2[num13] != Col_Number.Index && list2[num13] != Col_Preview.Index && list2[num13] != Col_Quantity.Index) ? true : false)
								{
									NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
									{
										num8 + num,
										list[num13],
										RuntimeHelpers.GetObjectValue(DGV1[list2[num13], num10].Value)
									}, null, null);
									flag = true;
								}
								num13++;
							}
							if (flag)
							{
								num++;
								NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, null, "rows", new object[1] { num8 + num + 1 }, null, null, null), null, "insert", new object[0], null, null, null, IgnoreReturn: true);
							}
							if (bst.marknodrw && Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Drw.Index, num10].Tag, "Есть", TextCompare: false))
							{
								NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, null, "rows", new object[1] { num8 + num - 1 }, null, null, null), null, "Interior", new object[0], null, null, null), null, "ColorIndex", new object[1] { 6 }, null, null, OptimisticSet: false, RValueBase: true);
							}
							ToolStripProgressBar1.Value = num10;
						}
						num10++;
					}
					if (bst.autocolumnwidth)
					{
						object instance9 = objectValue3;
						array = new object[1] { num8 };
						object[] arguments6 = array;
						array2 = new bool[1] { true };
						object instance10 = NewLateBinding.LateGet(instance9, null, "rows", arguments6, null, null, array2);
						if (array2[0])
						{
							num8 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
						}
						NewLateBinding.LateCall(NewLateBinding.LateGet(instance10, null, "EntireColumn", new object[0], null, null, null), null, "AutoFit", new object[0], null, null, null, IgnoreReturn: true);
					}
					object instance11 = objectValue2;
					array = new object[1] { text };
					object[] arguments7 = array;
					array2 = new bool[1] { true };
					NewLateBinding.LateCall(instance11, null, "SavecopyAs", arguments7, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					StatusLabel1.Text = "Экспорт выполнен";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					if (MessageBox.Show("Экспорт выполнен! Открыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Process.Start(text);
					}
				}
				else
				{
					MessageBox.Show(this, "Недопустимый шаблон", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show("Ошибка при экспорте спецификации:\n" + ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					StatusLabel1.Text = "Всего " + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					NewLateBinding.LateCall(objectValue2, null, "Close", new object[1] { false }, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(objectValue, null, "Quit", new object[0], null, null, null, IgnoreReturn: true);
					code.killxlapp(RuntimeHelpers.GetObjectValue(objectValue));
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void ExportBom_xls2(bomsetting bst, Treenode CurrentNode)
	{
		_Closure_0024__55 closure_0024__ = new _Closure_0024__55();
		if (DGV1.RowCount < 1 || DGV1.ColumnCount < 1 || false || DGV1.RowCount > 65536 || DGV1.ColumnCount > 255)
		{
			return;
		}
		chl = new checklic();
		string bomname = bst.bomname;
		if (!File.Exists(bomname))
		{
			MessageBox.Show(this, "Сначала задайте шаблон спецификации", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		if (Information.IsNothing(CurrentNode))
		{
			CurrentNode = (Treenode)TV1.TopNode;
		}
		if (Information.IsNothing(CurrentNode))
		{
			MessageBox.Show(this, "Не выбрано ни одного узла", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		List<Treenode> list = GetListFromTree(CurrentNode, bst);
		if (list.Count < 1)
		{
			MessageBox.Show(this, "Нет данных для экспорта", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		checked
		{
			if ((bst.type == 0 || bst.type == 2 || bst.type == 3) ? true : false)
			{
				_Closure_0024__55._Closure_0024__56 closure_0024__2 = new _Closure_0024__55._Closure_0024__56();
				closure_0024__2._0024VB_0024Local_arr = new List<string>();
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					closure_0024__2._0024VB_0024Local_arr.Add(Conversions.ToString(DGV1[Col_Path.Index, num2].Value));
					num2++;
				}
				list = list.OrderBy(closure_0024__2._Lambda_0024__109).ToList();
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = Path.GetExtension(bomname);
			saveFileDialog.FileName = code.SplitStr(CurrentNode.PathName, 1) + "-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
			string extension = Path.GetExtension(bomname);
			saveFileDialog.SupportMultiDottedExtensions = true;
			saveFileDialog.Filter = "Книга Excel (*" + extension + "）|*" + extension;
			saveFileDialog.ValidateNames = true;
			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			string text = saveFileDialog.FileName;
			if (Operators.CompareString(text.Trim(), "", TextCompare: false) == 0)
			{
				return;
			}
			int num5 = bst.image_width;
			int num6 = bst.image_height;
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			object objectValue = RuntimeHelpers.GetObjectValue(new object());
			object objectValue2 = RuntimeHelpers.GetObjectValue(new object());
			object objectValue3 = RuntimeHelpers.GetObjectValue(new object());
			try
			{
				StatusLabel1.Text = "Открытие Excel....";
				objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application"));
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				NewLateBinding.LateSet(objectValue, null, "Visible", new object[1] { false }, null, null);
				object instance = NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Application", new object[0], null, null, null), null, "Workbooks", new object[0], null, null, null);
				object[] array = new object[1] { bomname };
				object[] arguments = array;
				bool[] array2 = new bool[1] { true };
				object obj = NewLateBinding.LateGet(instance, null, "Add", arguments, null, null, array2);
				if (array2[0])
				{
					bomname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				objectValue2 = RuntimeHelpers.GetObjectValue(obj);
				objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "ActiveSheet", new object[0], null, null, null));
				StatusLabel1.Text = "Разбор файла шаблона....";
				int num7 = DGV1.ColumnCount - 1;
				int num8 = 0;
				int num10 = default(int);
				while (true)
				{
					int num9 = num8;
					int num4 = num7;
					if (num9 > num4)
					{
						break;
					}
					try
					{
						_Closure_0024__55._Closure_0024__57 closure_0024__3 = new _Closure_0024__55._Closure_0024__57();
						closure_0024__3._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1AE0_4E = closure_0024__;
						if ((!DGV1.Columns[num8].Name.Contains("PropVal_") || !bst.Propertyvalue) && 0 == 0 && (!DGV1.Columns[num8].Name.Contains("PropResolvedVal_") || bst.Propertyvalue) && 0 == 0)
						{
							string text2 = ResolveBomTemplateMappingName(num8);
							object instance2 = objectValue2;
							object[] array3 = new object[1] { text2 };
							object[] arguments2 = array3;
							array2 = new bool[1] { true };
							object instance3 = NewLateBinding.LateGet(instance2, null, "Names", arguments2, null, null, array2);
							if (array2[0])
							{
								text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
							}
							num10 = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(instance3, null, "RefersToRange", new object[0], null, null, null), null, "Row", new object[0], null, null, null));
							object instance4 = objectValue2;
							array3 = new object[1] { text2 };
							object[] arguments3 = array3;
							array2 = new bool[1] { true };
							object instance5 = NewLateBinding.LateGet(instance4, null, "Names", arguments3, null, null, array2);
							if (array2[0])
							{
								text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
							}
							int item = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(instance5, null, "RefersToRange", new object[0], null, null, null), null, "Column", new object[0], null, null, null));
							list2.Add(item);
							list3.Add(num8);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					num8++;
				}
				if ((bst.insertimagebool && !code.InsertPicBool) ? true : false)
				{
					StatusLabel1.Text = "Создание эскизов....";
					code.InsertPic2();
				}
				CustomFilter customFilter = null;
				if (bst.ByRuler)
				{
					customFilter = new CustomFilter(bst.RulesList);
				}
				if (list2.Count >= 1)
				{
					StatusLabel1.Text = "Экспорт спецификации....";
					ToolStripProgressBar1.Maximum = list.Count - 1;
					ToolStripProgressBar1.Visible = true;
					int num11 = 1;
					int num12 = list.Count - 1;
					int num13 = 0;
					while (true)
					{
						int num14 = num13;
						int num4 = num12;
						if (num14 > num4)
						{
							break;
						}
						int num15 = getrowindex(list[num13]);
						if (num15 != -1 && (((bst.type != 0 || !bst.ByRuler || Information.IsNothing(customFilter)) && 0 == 0) || customFilter.FilterByRule(num15)) && (((bst.type != 0 || !bst.ByFilter) && 0 == 0) || DGV1.Rows[num15].Visible))
						{
							bool flag = false;
							int num16 = list2.Count - 1;
							int num17 = 0;
							while (true)
							{
								int num18 = num17;
								num4 = num16;
								if (num18 > num4)
								{
									break;
								}
								if (list3[num17] == Col_Number.Index)
								{
									if (bst.type == 1)
									{
										NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
										{
											num10 + num11,
											list2[num17],
											list[num13].level_index
										}, null, null);
									}
									else
									{
										NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
										{
											num10 + num11,
											list2[num17],
											num11
										}, null, null);
									}
									flag = true;
								}
								else if ((list3[num17] == Col_Preview.Index && bst.insertimagebool) ? true : false)
								{
									if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[list3[num17], num15].Value)))
									{
										object instance6 = objectValue3;
										array = new object[2]
										{
											num10 + num11,
											null
										};
										object[] array4 = array;
										List<int> list4 = list2;
										int index = num17;
										array4[1] = list4[index];
										object[] array3 = array;
										object[] arguments4 = array3;
										array2 = new bool[2] { false, true };
										object obj2 = NewLateBinding.LateGet(instance6, null, "cells", arguments4, null, null, array2);
										if (array2[1])
										{
											list4[index] = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
										}
										object instance7 = obj2;
										NewLateBinding.LateSetComplex(instance7, null, "RowHeight", new object[1] { num6 + 2 }, null, null, OptimisticSet: false, RValueBase: true);
										NewLateBinding.LateSetComplex(instance7, null, "ColumnWidth", new object[1] { (double)num5 / 6.0 }, null, null, OptimisticSet: false, RValueBase: true);
										int num19 = Conversions.ToInteger(Operators.AddObject(NewLateBinding.LateGet(instance7, null, "Top", new object[0], null, null, null), 1));
										int num20 = Conversions.ToInteger(Operators.AddObject(NewLateBinding.LateGet(instance7, null, "Left", new object[0], null, null, null), 1));
										instance7 = null;
										Image image = new Bitmap((Image)DGV1[list3[num17], num15].Value, 256, 192);
										string text3 = logopathlist.PreviewFolder + code.SplitStr(Conversions.ToString(DGV1[Col_Path.Index, num15].Value), 1) + ".jpg";
										image.Save(text3, ImageFormat.Jpeg);
										object instance8 = NewLateBinding.LateGet(objectValue3, null, "Shapes", new object[0], null, null, null);
										array = new object[7] { text3, false, true, num20, num19, num5, num6 };
										object[] arguments5 = array;
										array2 = new bool[7] { true, false, false, true, true, true, true };
										NewLateBinding.LateCall(instance8, null, "AddPicture", arguments5, null, null, array2, IgnoreReturn: true);
										if (array2[0])
										{
											text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
										}
										if (array2[3])
										{
											num20 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[3]), typeof(int));
										}
										if (array2[4])
										{
											num19 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[4]), typeof(int));
										}
										if (array2[5])
										{
											num5 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[5]), typeof(int));
										}
										if (array2[6])
										{
											num6 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[6]), typeof(int));
										}
										File.Delete(text3);
										flag = true;
									}
								}
								else if (list3[num17] == Col_Quantity.Index)
								{
									if (bst.type == 1)
									{
										NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
										{
											num10 + num11,
											list2[num17],
											list[num13].realcount
										}, null, null);
									}
									else
									{
										NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
										{
											num10 + num11,
											list2[num17],
											decimal.Multiply(_Quantityratio.DecimalValue, new decimal(list[num13].realcount))
										}, null, null);
									}
								}
								else if (list3[num17] == Col_Level.Index)
								{
									NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
									{
										num10 + num11,
										list2[num17],
										list[num13].mylevel
									}, null, null);
									flag = true;
								}
								else if ((list3[num17] != Col_Number.Index && list3[num17] != Col_Preview.Index && list3[num17] != Col_Quantity.Index) ? true : false)
								{
									NewLateBinding.LateSet(objectValue3, null, "cells", new object[3]
									{
										num10 + num11,
										list2[num17],
										RuntimeHelpers.GetObjectValue(DGV1[list3[num17], num15].Value)
									}, null, null);
									flag = true;
								}
								num17++;
							}
							if (flag)
							{
								num11++;
								NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, null, "rows", new object[1] { num10 + num11 + 1 }, null, null, null), null, "insert", new object[0], null, null, null, IgnoreReturn: true);
							}
							if ((bst.marknodrw && Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Drw.Index, num15].Tag, "Есть", TextCompare: false)) ? true : false)
							{
								NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, null, "rows", new object[1] { num10 + num11 - 1 }, null, null, null), null, "Interior", new object[0], null, null, null), null, "ColorIndex", new object[1] { 6 }, null, null, OptimisticSet: false, RValueBase: true);
							}
							ToolStripProgressBar1.Value = num13;
						}
						num13++;
					}
					if (bst.autocolumnwidth)
					{
						object instance9 = objectValue3;
						array = new object[1] { num10 };
						object[] arguments6 = array;
						array2 = new bool[1] { true };
						object instance10 = NewLateBinding.LateGet(instance9, null, "rows", arguments6, null, null, array2);
						if (array2[0])
						{
							num10 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
						}
						NewLateBinding.LateCall(NewLateBinding.LateGet(instance10, null, "EntireColumn", new object[0], null, null, null), null, "AutoFit", new object[0], null, null, null, IgnoreReturn: true);
					}
					object instance11 = objectValue2;
					array = new object[1] { text };
					object[] arguments7 = array;
					array2 = new bool[1] { true };
					NewLateBinding.LateCall(instance11, null, "SavecopyAs", arguments7, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					StatusLabel1.Text = "Экспорт выполнен";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					if (MessageBox.Show("Экспорт выполнен! Открыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Process.Start(text);
					}
				}
				else
				{
					MessageBox.Show(this, "Недопустимый шаблон", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show("Ошибка при экспорте спецификации:\n" + ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					StatusLabel1.Text = "Всего " + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					NewLateBinding.LateCall(objectValue2, null, "Close", new object[1] { false }, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(objectValue, null, "Quit", new object[0], null, null, null, IgnoreReturn: true);
					code.killxlapp(RuntimeHelpers.GetObjectValue(objectValue));
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void ExportBom_xls3(bomsetting bst)
	{
		_Closure_0024__58 closure_0024__ = new _Closure_0024__58();
		if (DGV1.RowCount < 1 || DGV1.ColumnCount < 1 || false || DGV1.RowCount > 65536 || DGV1.ColumnCount > 255)
		{
			return;
		}
		chl = new checklic();
		if (!code.canrun)
		{
			return;
		}
		string bomname = bst.bomname;
		if (!File.Exists(bomname))
		{
			MessageBox.Show(this, "Сначала задайте шаблон спецификации", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.DefaultExt = Path.GetExtension(bomname);
		saveFileDialog.FileName = LookupTopAsmName() + "-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
		string extension = Path.GetExtension(bomname);
		saveFileDialog.SupportMultiDottedExtensions = true;
		saveFileDialog.Filter = "Книга Excel (*" + extension + "）|*" + extension;
		saveFileDialog.ValidateNames = true;
		if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string fileName = saveFileDialog.FileName;
		if (Operators.CompareString(fileName.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		int num = 0;
		int image_width = bst.image_width;
		int image_height = bst.image_height;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		IWorkbook workbook = null;
		ISheet sheet = null;
		bool flag = false;
		int col_exclude = -1;
		if (!code.canrun)
		{
			return;
		}
		checked
		{
			try
			{
				StatusLabel1.Text = "Открытие файла шаблона....";
				using (FileStream fileStream = new FileStream(bomname, FileMode.Open, FileAccess.Read))
				{
					if (bomname.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
					{
						workbook = new HSSFWorkbook(fileStream);
						flag = true;
					}
					else if (bomname.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
					{
						workbook = new XSSFWorkbook((Stream)fileStream);
						flag = false;
					}
				}
				if (Information.IsNothing(workbook))
				{
					return;
				}
				sheet = workbook.GetSheetAt(workbook.ActiveSheetIndex);
				StatusLabel1.Text = "Разбор файла шаблона....";
				int num2 = DGV1.ColumnCount - 1;
				int num3 = 0;
				int row = default(int);
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					try
					{
						_Closure_0024__58._Closure_0024__59 closure_0024__2 = new _Closure_0024__58._Closure_0024__59();
						closure_0024__2._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1BB6_2F = closure_0024__;
						if ((!DGV1.Columns[num3].Name.Contains("PropVal_") || !bst.Propertyvalue) && 0 == 0 && (!DGV1.Columns[num3].Name.Contains("PropResolvedVal_") || bst.Propertyvalue) && 0 == 0)
						{
							string text = ResolveBomTemplateMappingName(num3);
							IName name = workbook.GetName(text);
							if (!Information.IsNothing(name))
							{
								CellReference cellReference = new CellReference(name.RefersToFormula);
								if (!Information.IsNothing(cellReference))
								{
									row = cellReference.Row;
									int col = cellReference.Col;
									if ((col >= 0 && row >= 0) ? true : false)
									{
										list.Add(col);
										list2.Add(num3);
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					num3++;
				}
				IRow row2 = null;
				ICell cell = null;
				if (list.Count >= 1)
				{
					if ((bst.insertimagebool && !code.InsertPicBool) ? true : false)
					{
						StatusLabel1.Text = "Создание эскизов....";
						code.InsertPic2();
					}
					CustomFilter customFilter = null;
					if (bst.ByRuler)
					{
						customFilter = new CustomFilter(bst.RulesList);
					}
					StatusLabel1.Text = "Экспорт спецификации....";
					ToolStripProgressBar1.Maximum = DGV1.RowCount - 1;
					ToolStripProgressBar1.Visible = true;
					num = 1;
					ICellStyle cellStyle = workbook.CreateCellStyle();
					cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
					cellStyle.VerticalAlignment = VerticalAlignment.Center;
					int num6 = DGV1.RowCount - 1;
					int num7 = 0;
					NPOI.SS.UserModel.HorizontalAlignment alignment = default(NPOI.SS.UserModel.HorizontalAlignment);
					while (true)
					{
						int num8 = num7;
						int num5 = num6;
						if (num8 > num5)
						{
							break;
						}
						if ((((!bst.ByRuler || Information.IsNothing(customFilter)) && 0 == 0) || customFilter.FilterByRule(num7)) && (!bst.ByFilter || DGV1.Rows[num7].Visible))
						{
							bool flag2 = false;
							mynpoi.InsertRows(ref sheet, row + num, 1, list);
							row2 = sheet.GetRow(row + num);
							if (!Information.IsNothing(row2))
							{
								ICell cell2 = row2.GetCell(0);
								if (!Information.IsNothing(cell2))
								{
									alignment = row2.GetCell(0).CellStyle.Alignment;
								}
								int num9 = list.Count - 1;
								int num10 = 0;
								while (true)
								{
									int num11 = num10;
									num5 = num9;
									if (num11 > num5)
									{
										break;
									}
									cell = row2.GetCell(list[num10]);
									if (Information.IsNothing(cell))
									{
										cell = row2.CreateCell(list[num10]);
									}
									if (list2[num10] == Col_Number.Index)
									{
										cell.SetCellValue(num);
										flag2 = true;
									}
									else if ((list2[num10] == Col_Preview.Index && bst.insertimagebool) ? true : false)
									{
										col_exclude = list[num10];
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[list2[num10], num7].Value)))
										{
											row2.Height = (short)(image_height * 20);
											sheet.SetColumnWidth(list[num10], (int)Math.Round(((double)image_width / 6.0 + 0.56) * 256.0));
											Image image = new Bitmap((Image)DGV1[list2[num10], num7].Value, 256, 192);
											byte[] pictureData = ImageHelper.ImageToBytes(image);
											int pictureIndex = workbook.AddPicture(pictureData, PictureType.PNG);
											IClientAnchor clientAnchor = null;
											clientAnchor = ((!flag) ? ((IClientAnchor)new XSSFClientAnchor(9000, 9000, 0, 0, list[num10], row + num, list[num10] + 1, row + num + 1)) : ((IClientAnchor)new HSSFClientAnchor(20, 5, 1003, 250, list[num10], row + num, list[num10], row + num)));
											IPicture picture = sheet.CreateDrawingPatriarch().CreatePicture(clientAnchor, pictureIndex);
										}
										flag2 = true;
									}
									else if (list2[num10] == Col_Quantity.Index)
									{
										int num12 = Conversions.ToInteger(Operators.MultiplyObject(_Quantityratio.DecimalValue, DGV1[list2[num10], num7].Value));
										cell.SetCellValue(num12);
										flag2 = true;
									}
									else if ((list2[num10] != Col_Number.Index && list2[num10] != Col_Preview.Index && list2[num10] != Col_Quantity.Index) ? true : false)
									{
										string text2 = Conversions.ToString(DGV1[list2[num10], num7].Value);
										if (long.TryParse(text2, out var result))
										{
											cell.SetCellValue(result);
										}
										else
										{
											cell.SetCellValue(text2);
										}
										flag2 = true;
									}
									num10++;
								}
								if (flag2)
								{
									num++;
								}
								if ((bst.marknodrw && Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Drw.Index, num7].Tag, "Есть", TextCompare: false)) ? true : false)
								{
									if (flag)
									{
										cellStyle.CloneStyleFrom(row2.GetCell(0).CellStyle);
									}
									cellStyle.FillForegroundColor = 13;
									cellStyle.FillPattern = FillPattern.SolidForeground;
									cellStyle.Alignment = alignment;
									row2.GetCell(0).CellStyle = cellStyle;
								}
								ToolStripProgressBar1.Value = num7;
							}
						}
						num7++;
					}
					if (bst.autocolumnwidth)
					{
						mynpoi.AutoColumnWidth(sheet, row + 1, col_exclude);
					}
					using (FileStream stream = new FileStream(fileName, FileMode.Create))
					{
						workbook.Write(stream);
					}
					StatusLabel1.Text = "Экспорт выполнен";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					if (MessageBox.Show("Экспорт выполнен! Открыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Process.Start(fileName);
					}
				}
				else
				{
					MessageBox.Show(this, "Недопустимый шаблон", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show("Ошибка при экспорте спецификации:\n" + ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					StatusLabel1.Text = "Всего " + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void ExportBom_xls4(bomsetting bst, Treenode CurrentNode)
	{
		_Closure_0024__60 closure_0024__ = new _Closure_0024__60();
		if (DGV1.RowCount < 1 || DGV1.ColumnCount < 1 || false || DGV1.RowCount > 65536 || DGV1.ColumnCount > 255)
		{
			return;
		}
		chl = new checklic();
		string bomname = bst.bomname;
		if (!File.Exists(bomname))
		{
			MessageBox.Show(this, "Сначала задайте шаблон спецификации", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		if (Information.IsNothing(CurrentNode))
		{
			CurrentNode = (Treenode)TV1.TopNode;
		}
		if (Information.IsNothing(CurrentNode))
		{
			MessageBox.Show(this, "Не выбрано ни одного узла", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		List<Treenode> list = GetListFromTree(CurrentNode, bst);
		if (list.Count < 1)
		{
			MessageBox.Show(this, "Нет данных для экспорта", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		checked
		{
			if ((bst.type == 0 || bst.type == 2 || bst.type == 3) ? true : false)
			{
				_Closure_0024__60._Closure_0024__61 closure_0024__2 = new _Closure_0024__60._Closure_0024__61();
				closure_0024__2._0024VB_0024Local_arr = new List<string>();
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					closure_0024__2._0024VB_0024Local_arr.Add(Conversions.ToString(DGV1[Col_Path.Index, num2].Value));
					num2++;
				}
				list = list.OrderBy(closure_0024__2._Lambda_0024__114).ToList();
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = Path.GetExtension(bomname);
			saveFileDialog.FileName = code.SplitStr(CurrentNode.PathName, 1) + "-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
			string extension = Path.GetExtension(bomname);
			saveFileDialog.SupportMultiDottedExtensions = true;
			saveFileDialog.Filter = "Книга Excel (*" + extension + "）|*" + extension;
			saveFileDialog.ValidateNames = true;
			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			string fileName = saveFileDialog.FileName;
			if (Operators.CompareString(fileName.Trim(), "", TextCompare: false) == 0)
			{
				return;
			}
			int image_width = bst.image_width;
			int image_height = bst.image_height;
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			IWorkbook workbook = null;
			ISheet sheet = null;
			bool flag = false;
			int col_exclude = -1;
			if (!code.canrun)
			{
				return;
			}
			try
			{
				StatusLabel1.Text = "Открытие файла шаблона....";
				using (FileStream fileStream = new FileStream(bomname, FileMode.Open, FileAccess.Read))
				{
					if (bomname.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
					{
						workbook = new HSSFWorkbook(fileStream);
						flag = true;
					}
					else if (bomname.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
					{
						workbook = new XSSFWorkbook((Stream)fileStream);
						flag = false;
					}
				}
				if (Information.IsNothing(workbook))
				{
					return;
				}
				sheet = workbook.GetSheetAt(workbook.ActiveSheetIndex);
				StatusLabel1.Text = "Разбор файла шаблона....";
				int num5 = DGV1.ColumnCount - 1;
				int num6 = 0;
				int row = default(int);
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					try
					{
						_Closure_0024__60._Closure_0024__62 closure_0024__3 = new _Closure_0024__60._Closure_0024__62();
						closure_0024__3._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1C9C_4E = closure_0024__;
						if ((!DGV1.Columns[num6].Name.Contains("PropVal_") || !bst.Propertyvalue) && 0 == 0 && (!DGV1.Columns[num6].Name.Contains("PropResolvedVal_") || bst.Propertyvalue) && 0 == 0)
						{
							string text = ResolveBomTemplateMappingName(num6);
							IName name = workbook.GetName(text);
							if (!Information.IsNothing(name))
							{
								CellReference cellReference = new CellReference(name.RefersToFormula);
								if (!Information.IsNothing(cellReference))
								{
									row = cellReference.Row;
									int col = cellReference.Col;
									if ((col >= 0 && row >= 0) ? true : false)
									{
										list2.Add(col);
										list3.Add(num6);
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					num6++;
				}
				if (list2.Count >= 1)
				{
					IRow row2 = null;
					ICell cell = null;
					if ((bst.insertimagebool && !code.InsertPicBool) ? true : false)
					{
						StatusLabel1.Text = "Создание эскизов....";
						code.InsertPic2();
					}
					CustomFilter customFilter = null;
					if (bst.ByRuler)
					{
						customFilter = new CustomFilter(bst.RulesList);
					}
					StatusLabel1.Text = "Экспорт спецификации....";
					ToolStripProgressBar1.Maximum = list.Count - 1;
					ToolStripProgressBar1.Visible = true;
					int num8 = 1;
					ICellStyle cellStyle = workbook.CreateCellStyle();
					cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
					cellStyle.VerticalAlignment = VerticalAlignment.Center;
					int num9 = list.Count - 1;
					int num10 = 0;
					NPOI.SS.UserModel.HorizontalAlignment alignment = default(NPOI.SS.UserModel.HorizontalAlignment);
					while (true)
					{
						int num11 = num10;
						int num4 = num9;
						if (num11 > num4)
						{
							break;
						}
						int num12 = getrowindex(list[num10]);
						if (num12 != -1 && (((bst.type != 0 || !bst.ByRuler || Information.IsNothing(customFilter)) && 0 == 0) || customFilter.FilterByRule(num12)) && (((bst.type != 0 || !bst.ByFilter) && 0 == 0) || DGV1.Rows[num12].Visible))
						{
							bool flag2 = false;
							mynpoi.InsertRows(ref sheet, row + num8, 1, list2);
							row2 = sheet.GetRow(row + num8);
							if (!Information.IsNothing(row2))
							{
								ICell cell2 = row2.GetCell(0);
								if (!Information.IsNothing(cell2))
								{
									alignment = row2.GetCell(0).CellStyle.Alignment;
								}
								int num13 = list2.Count - 1;
								int num14 = 0;
								while (true)
								{
									int num15 = num14;
									num4 = num13;
									if (num15 > num4)
									{
										break;
									}
									cell = row2.GetCell(list2[num14]);
									if (Information.IsNothing(cell))
									{
										cell = row2.CreateCell(list2[num14]);
									}
									if (list3[num14] == Col_Number.Index)
									{
										if (bst.type == 1)
										{
											cell.SetCellValue(list[num10].level_index);
										}
										else
										{
											cell.SetCellValue(num8);
										}
										flag2 = true;
									}
									else if ((list3[num14] == Col_Preview.Index && bst.insertimagebool) ? true : false)
									{
										col_exclude = list2[num14];
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[list3[num14], num12].Value)))
										{
											row2.Height = (short)(image_height * 20);
											sheet.SetColumnWidth(list2[num14], (int)Math.Round(((double)image_width / 6.0 + 0.56) * 256.0));
											Image image = new Bitmap((Image)DGV1[list3[num14], num12].Value, 256, 192);
											byte[] pictureData = ImageHelper.ImageToBytes(image);
											int pictureIndex = workbook.AddPicture(pictureData, PictureType.PNG);
											if (flag)
											{
												HSSFPatriarch hSSFPatriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch();
												HSSFClientAnchor anchor = new HSSFClientAnchor(20, 5, 1003, 250, list2[num14], row + num8, list2[num14], row + num8);
												HSSFPicture hSSFPicture = (HSSFPicture)hSSFPatriarch.CreatePicture(anchor, pictureIndex);
											}
											else
											{
												XSSFDrawing xSSFDrawing = (XSSFDrawing)sheet.CreateDrawingPatriarch();
												XSSFClientAnchor anchor2 = new XSSFClientAnchor(9000, 9000, 0, 0, list2[num14], row + num8, list2[num14] + 1, row + num8 + 1);
												XSSFPicture xSSFPicture = (XSSFPicture)xSSFDrawing.CreatePicture(anchor2, pictureIndex);
											}
										}
										flag2 = true;
									}
									else if (list3[num14] == Col_Quantity.Index)
									{
										int num16 = Convert.ToInt32(decimal.Multiply(_Quantityratio.DecimalValue, new decimal(list[num10].realcount)));
										if (bst.type == 1)
										{
											cell.SetCellValue(list[num10].realcount);
										}
										else
										{
											cell.SetCellValue(num16);
										}
										flag2 = true;
									}
									else if (list3[num14] == Col_Level.Index)
									{
										cell.SetCellValue(list[num10].mylevel);
										flag2 = true;
									}
									else if ((list3[num14] != Col_Number.Index && list3[num14] != Col_Preview.Index && list3[num14] != Col_Quantity.Index) ? true : false)
									{
										string text2 = Conversions.ToString(DGV1[list3[num14], num12].Value);
										if (long.TryParse(text2, out var result))
										{
											cell.SetCellValue(result);
										}
										else
										{
											cell.SetCellValue(text2);
										}
										flag2 = true;
									}
									num14++;
								}
								if ((bst.marknodrw && Operators.ConditionalCompareObjectNotEqual(DGV1[Col_Drw.Index, num12].Tag, "Есть", TextCompare: false)) ? true : false)
								{
									if (flag)
									{
										cellStyle.CloneStyleFrom(row2.GetCell(0).CellStyle);
									}
									cellStyle.FillForegroundColor = 13;
									cellStyle.FillPattern = FillPattern.SolidForeground;
									cellStyle.Alignment = alignment;
									row2.GetCell(0).CellStyle = cellStyle;
								}
								if (flag2)
								{
									num8++;
								}
								ToolStripProgressBar1.Value = num10;
							}
						}
						num10++;
					}
					if (bst.autocolumnwidth)
					{
						mynpoi.AutoColumnWidth(sheet, row + 1, col_exclude);
					}
					using (FileStream stream = new FileStream(fileName, FileMode.Create))
					{
						workbook.Write(stream);
					}
					StatusLabel1.Text = "Экспорт выполнен";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
					if (MessageBox.Show("Экспорт выполнен! Открыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Process.Start(fileName);
					}
				}
				else
				{
					MessageBox.Show(this, "Недопустимый шаблон", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show("Ошибка при экспорте спецификации:\n" + ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					StatusLabel1.Text = "Всего " + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void ExportBom_txt(bomsetting bst)
	{
		if ((DGV1.RowCount < 1) | (DGV1.ColumnCount < 1))
		{
			return;
		}
		Treenode treenode = (Treenode)TV1.SelectedNode;
		if (Information.IsNothing(treenode))
		{
			return;
		}
		List<Treenode> list = GetListFromTree(treenode, bst);
		if (list.Count < 1)
		{
			MessageBox.Show(this, "Нет данных для экспорта", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		checked
		{
			if (bst.type == 0 || bst.type == 2)
			{
				_Closure_0024__63 closure_0024__ = new _Closure_0024__63();
				closure_0024__._0024VB_0024Local_arr = new List<string>();
				int num = DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					closure_0024__._0024VB_0024Local_arr.Add(Conversions.ToString(DGV1[Col_Path.Index, num2].Value));
					num2++;
				}
				list = list.OrderBy(closure_0024__._Lambda_0024__117).ToList();
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".txt";
			saveFileDialog.FileName = code.SplitStr(treenode.PathName, 1) + "-" + DateTime.Now.ToString("yyyyMMdd");
			saveFileDialog.Filter = "Данные спецификации (*.txt)|*.txt";
			saveFileDialog.ValidateNames = true;
			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			string fileName = saveFileDialog.FileName;
			try
			{
				StatusLabel1.Text = "Экспорт спецификации с отступами....";
				ToolStripProgressBar1.Maximum = list.Count - 1;
				ToolStripProgressBar1.Visible = true;
				List<int> list2 = new List<int>();
				StringBuilder stringBuilder = new StringBuilder();
				using (StreamWriter streamWriter = new StreamWriter(fileName, append: false, Encoding.UTF8))
				{
					stringBuilder.Append("Номер");
					int num5 = DGV1.ColumnCount - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						try
						{
							if (((DGV1.Columns[num6].Name.Contains("PropVal_") && !CConfigMng.Config.BomByVal) || (DGV1.Columns[num6].Name.Contains("PropResolvedVal_") && CConfigMng.Config.BomByVal) || num6 == Col_FileName.Index || num6 == Col_Cfg.Index) ? true : false)
							{
								stringBuilder.Append("\t" + DGV1.Columns[num6].HeaderText);
								list2.Add(num6);
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ProjectData.ClearProjectError();
						}
						num6++;
					}
					stringBuilder.Append("\tКоличество");
					streamWriter.WriteLine(stringBuilder);
					int num8 = list.Count - 1;
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						int num4 = num8;
						if (num10 > num4)
						{
							break;
						}
						StringBuilder stringBuilder2 = new StringBuilder();
						ToolStripProgressBar1.Value = num9;
						int num11 = getrowindex(list[num9]);
						if (num11 != -1)
						{
							stringBuilder2.Append(list[num9].level_index);
							int num12 = list2.Count - 1;
							int num13 = 0;
							while (true)
							{
								int num14 = num13;
								num4 = num12;
								if (num14 > num4)
								{
									break;
								}
								stringBuilder2.Append(Operators.ConcatenateObject("\t", DGV1[list2[num13], num11].Value));
								num13++;
							}
							stringBuilder2.Append("\t" + Conversions.ToString(list[num9].realcount));
							streamWriter.WriteLine(stringBuilder2);
						}
						num9++;
					}
				}
				StatusLabel1.Text = "Всего " + Conversions.ToString(DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
				Process.Start("NotePad.exe", fileName);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show("Ошибка при экспорте в txt:\n" + ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public int getrowindex(Treenode nodedoc)
	{
		int result = -1;
		string text = "";
		text = ((!code.togetherConfig) ? (nodedoc.PathName + nodedoc.ConfigureName) : nodedoc.PathName);
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string text2 = "";
				text2 = ((!code.togetherConfig) ? Conversions.ToString(Operators.ConcatenateObject(DGV1[Col_Path.Index, num2].Value, DGV1[Col_Cfg.Index, num2].Value)) : Conversions.ToString(DGV1[Col_Path.Index, num2].Value));
				if (text.Equals(text2, StringComparison.OrdinalIgnoreCase))
				{
					result = num2;
					break;
				}
				num2++;
			}
			return result;
		}
	}

	public List<Treenode> GetListFromTree(Treenode node, bomsetting bst)
	{
		List<Treenode> Rlist = new List<Treenode>();
		TreeView treeView = new TreeView();
		treeView.Nodes.Clear();
		if (bst.type == 0)
		{
			getnewtree2(node, treeView.Nodes);
		}
		else if (bst.type == 1)
		{
			getnewtree(node, treeView.Nodes);
		}
		else if (bst.type == 2)
		{
			getnewtree(node, treeView.Nodes, 0, onlytop: true);
		}
		else if (bst.type == 3)
		{
			getnewtree2(node, treeView.Nodes, 0, OnlyPart: true);
		}
		Traversaltree(treeView.Nodes, ref Rlist, bst.includetop);
		return Rlist;
	}

	public void getnewtree2(Treenode node, TreeNodeCollection newnodes, int level = 0, bool OnlyPart = false)
	{
		if (Information.IsNothing(node))
		{
			return;
		}
		Treenode treenode = new Treenode();
		treenode.Text = node.Text;
		treenode.ConfigureName = node.ConfigureName;
		treenode.PathName = node.PathName;
		treenode.FeatureName = node.FeatureName;
		treenode.DisplayInBOM = node.DisplayInBOM;
		treenode.IsSuppressed = node.IsSuppressed;
		treenode.ExcludeFromBOM = node.ExcludeFromBOM;
		if ((node.DisplayInBOM == 3 && level > 0) ? true : false)
		{
			foreach (Treenode node6 in node.Nodes)
			{
				getnewtree2(node6, newnodes, level, OnlyPart);
			}
			return;
		}
		if ((OnlyPart && node.DisplayInBOM == 2 && level > 0) ? true : false)
		{
			foreach (Treenode node7 in node.Nodes)
			{
				getnewtree2(node7, newnodes, level, OnlyPart);
			}
			return;
		}
		if ((node.DisplayInBOM == 1 && level > 0) ? true : false)
		{
			newnodes.Add(treenode);
		}
		else
		{
			if (((node.ExcludeFromBOM || node.IsSuppressed) && level > 0) ? true : false)
			{
				return;
			}
			newnodes.Add(treenode);
			if (level != 0)
			{
				{
					foreach (Treenode node8 in node.Nodes)
					{
						getnewtree2(node8, newnodes, level, OnlyPart);
					}
					return;
				}
			}
			foreach (Treenode node9 in node.Nodes)
			{
				getnewtree2(node9, treenode.Nodes, 1, OnlyPart);
			}
		}
	}

	public void getnewtree(Treenode node, TreeNodeCollection newnodes, int level = 0, bool onlytop = false)
	{
		if ((onlytop && level > 1) || false || Information.IsNothing(node))
		{
			return;
		}
		Treenode treenode = new Treenode();
		treenode.Text = node.Text;
		treenode.ConfigureName = node.ConfigureName;
		treenode.PathName = node.PathName;
		treenode.FeatureName = node.FeatureName;
		treenode.DisplayInBOM = node.DisplayInBOM;
		treenode.IsSuppressed = node.IsSuppressed;
		treenode.ExcludeFromBOM = node.ExcludeFromBOM;
		if (node.DisplayInBOM == 3 && level > 0)
		{
			foreach (Treenode node4 in node.Nodes)
			{
				getnewtree(node4, newnodes, level, onlytop);
			}
			return;
		}
		if (node.DisplayInBOM == 1 && level > 0)
		{
			newnodes.Add(treenode);
		}
		else
		{
			if (((node.ExcludeFromBOM || node.IsSuppressed) && level > 0) ? true : false)
			{
				return;
			}
			newnodes.Add(treenode);
			foreach (Treenode node5 in node.Nodes)
			{
				getnewtree(node5, treenode.Nodes, checked(level + 1), onlytop);
			}
		}
	}

	public void Traversaltree(TreeNodeCollection nodes, ref List<Treenode> Rlist, bool includetop, int level = 0)
	{
		if (Information.IsNothing(nodes))
		{
			return;
		}
		myindexd[level] = 0;
		checked
		{
			try
			{
				_Closure_0024__64 closure_0024__ = default(_Closure_0024__64);
				foreach (Treenode node in nodes)
				{
					closure_0024__ = new _Closure_0024__64(closure_0024__);
					closure_0024__._0024VB_0024Local_str = "";
					if (code.togetherConfig)
					{
						closure_0024__._0024VB_0024Local_str = Strings.Left(node.FullPath, Strings.InStrRev(node.FullPath, "\\")) + code.SplitStr(node.PathName, 4) + Conversions.ToString(node.DisplayInBOM);
					}
					else
					{
						closure_0024__._0024VB_0024Local_str = Strings.Left(node.FullPath, Strings.InStrRev(node.FullPath, "\\")) + code.SplitStr(node.PathName, 4) + node.ConfigureName + Conversions.ToString(node.DisplayInBOM);
					}
					Treenode treenode2 = Rlist.Find(closure_0024__._Lambda_0024__118);
					if (Information.IsNothing(treenode2))
					{
						if (node.Level > 0)
						{
							myindexd[level] += 1;
							Treenode treenode3 = (Treenode)node.Parent;
							if (!Information.IsNothing(treenode3))
							{
								if (Operators.CompareString(treenode3.level_index, "", TextCompare: false) == 0)
								{
									node.level_index = Conversions.ToString(myindexd[level]);
								}
								else
								{
									node.level_index = treenode3.level_index + "." + Conversions.ToString(myindexd[level]);
								}
							}
							Treenode treenode4 = new Treenode();
							treenode4.realpath = closure_0024__._0024VB_0024Local_str;
							treenode4.PathName = node.PathName;
							treenode4.ConfigureName = node.ConfigureName;
							treenode4.realcount = 1;
							treenode4.level_index = node.level_index;
							treenode4.mylevel = level;
							Rlist.Add(treenode4);
						}
						else if ((node.Level == 0 && includetop) ? true : false)
						{
							Treenode treenode5 = new Treenode();
							treenode5.realpath = closure_0024__._0024VB_0024Local_str;
							treenode5.PathName = node.PathName;
							treenode5.ConfigureName = node.ConfigureName;
							treenode5.realcount = 1;
							treenode5.level_index = Conversions.ToString(0);
							treenode5.mylevel = level;
							Rlist.Add(treenode5);
						}
						if (node.Nodes.Count > 0)
						{
							Traversaltree(node.Nodes, ref Rlist, includetop, level + 1);
						}
					}
					else
					{
						treenode2.realcount++;
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

	public bool haveupdate()
	{
		// Vendor online update probe disabled (see Phase 3): never reports an update,
		// so no startup "new version" notification and no fetch to the vendor endpoint.
		return false;
	}

	internal void sendhwndtosw()
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + code.Getpkt());
			stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 90;
			code.COPYDATASTRUCT lParam = default(code.COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private void _Lambda_0024__79(object a0, EventArgs a1)
	{
		ToolStripButton_MouseLeave();
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private void _Lambda_0024__80(object a0, EventArgs a1)
	{
		ToolStripButton_MouseLeave();
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private void _Lambda_0024__81(object a0, EventArgs a1)
	{
		ToolStripButton_MouseLeave();
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private void _Lambda_0024__82(object a0, EventArgs a1)
	{
		ToolStripButton_MouseLeave();
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private void _Lambda_0024__88()
	{
		haveupdate();
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private static void _Lambda_0024__89(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private static void _Lambda_0024__90(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private static void _Lambda_0024__91(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private void _Lambda_0024__98(object a0, EventArgs a1)
	{
		usecolor_CheckedChanged();
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__100()
	{
		lockbutton();
		MyProject.Forms.FrmRverify.Test.Enabled = true;
		MyProject.Forms.FrmRverify.Test.Visible = true;
		MyProject.Forms.FrmRverify.ShowDialog();
		if (code.TMode)
		{
			test();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__101()
	{
		test();
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__102()
	{
		Unlockbutton();
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__104()
	{
		BringToFrontSafely();
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__105()
	{
		BringToFrontSafely();
	}

	[SpecialName]
	[CompilerGenerated]
	private static void _Lambda_0024__119()
	{
		// Vendor online update disabled (see Phase 3): no update window is shown.
	}
}
