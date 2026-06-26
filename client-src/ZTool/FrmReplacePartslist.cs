using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using ZTool.CustomFileBorser1;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmReplacePartslist : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__15
	{
		[CompilerGenerated]
		internal class _Closure_0024__16
		{
			[CompilerGenerated]
			internal class _Closure_0024__17
			{
				public string _0024VB_0024Local_pathname;

				[DebuggerNonUserCode]
				public _Closure_0024__17(_Closure_0024__17 other)
				{
					if (other != null)
					{
						_0024VB_0024Local_pathname = other._0024VB_0024Local_pathname;
					}
				}

				[DebuggerNonUserCode]
				public _Closure_0024__17()
				{
				}

				[SpecialName]
				[CompilerGenerated]
				public bool _Lambda_0024__28(string s)
				{
					return s.Equals(_0024VB_0024Local_pathname, StringComparison.CurrentCultureIgnoreCase);
				}
			}

			[CompilerGenerated]
			internal class _Closure_0024__18
			{
				public string _0024VB_0024Local_pathname;

				[DebuggerNonUserCode]
				public _Closure_0024__18(_Closure_0024__18 other)
				{
					if (other != null)
					{
						_0024VB_0024Local_pathname = other._0024VB_0024Local_pathname;
					}
				}

				[DebuggerNonUserCode]
				public _Closure_0024__18()
				{
				}

				[SpecialName]
				[CompilerGenerated]
				public bool _Lambda_0024__29(string s)
				{
					return s.Equals(_0024VB_0024Local_pathname, StringComparison.CurrentCultureIgnoreCase);
				}
			}

			[CompilerGenerated]
			internal class _Closure_0024__19
			{
				public string _0024VB_0024Local_NewReference;

				public _Closure_0024__15 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A;

				[DebuggerNonUserCode]
				public _Closure_0024__19(_Closure_0024__19 other)
				{
					if (other != null)
					{
						_0024VB_0024Local_NewReference = other._0024VB_0024Local_NewReference;
					}
				}

				[DebuggerNonUserCode]
				public _Closure_0024__19()
				{
				}

				[SpecialName]
				[CompilerGenerated]
				public void _Lambda_0024__30()
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.lvi1[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Local_i].SubItems[1].Text = _0024VB_0024Local_NewReference;
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.lvi1[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Local_i].SubItems[4].Text = "Успешно";
				}

				[SpecialName]
				[CompilerGenerated]
				public bool _Lambda_0024__31(string s)
				{
					return s.Equals(_0024VB_0024Local_NewReference, StringComparison.CurrentCultureIgnoreCase);
				}

				[SpecialName]
				[CompilerGenerated]
				public void _Lambda_0024__32()
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ToolStripProgressBar1.Value = checked(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Local_i + 1);
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ListView1.Refreshview();
				}
			}

			public int _0024VB_0024Local_count;

			public _Closure_0024__15 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A;

			[DebuggerNonUserCode]
			public _Closure_0024__16()
			{
			}

			[DebuggerNonUserCode]
			public _Closure_0024__16(_Closure_0024__16 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_count = other._0024VB_0024Local_count;
				}
			}

			[SpecialName]
			[CompilerGenerated]
			public void _Lambda_0024__33()
			{
				checked
				{
					if (_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.Abort)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ToolStripStatusLabel1.Text = "Задача отменена";
					}
					else
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ToolStripStatusLabel1.Text = "Замена завершена";
						if (_0024VB_0024Local_count > 0)
						{
							_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ListView2.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.selrow].ForeColor = Color.Green;
							int num = 0;
							int num2 = _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ListView2.Items.Count - 1;
							int num3 = 0;
							while (true)
							{
								int num4 = num3;
								int num5 = num2;
								if (num4 > num5)
								{
									break;
								}
								if (!File.Exists(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ListView2.Items[num3 - num].SubItems[2].Text))
								{
									_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ListView2.DelSpecificItems(num3 - num);
									num++;
								}
								num3++;
							}
						}
					}
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.OK_Button.Text = "Старт";
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ToolStripProgressBar1.Value = 0;
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.ToolStripProgressBar1.Visible = false;
					_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A._0024VB_0024Me.Abort = true;
					code.EnablePreview = true;
					code.RunSW(HideWindow: false, startnew: false);
				}
			}
		}

		public int _0024VB_0024Local_i;

		public FrmReplacePartslist _0024VB_0024Me;

		[DebuggerNonUserCode]
		public _Closure_0024__15()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__15(_Closure_0024__15 other)
		{
			if (other != null)
			{
				_0024VB_0024Me = other._0024VB_0024Me;
				_0024VB_0024Local_i = other._0024VB_0024Local_i;
			}
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__20
	{
		public string _0024VB_0024Local_fullname;

		public string _0024VB_0024Local_name;

		[DebuggerNonUserCode]
		public _Closure_0024__20(_Closure_0024__20 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_name = other._0024VB_0024Local_name;
				_0024VB_0024Local_fullname = other._0024VB_0024Local_fullname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__20()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__34(string s)
		{
			return (s.EndsWith(_0024VB_0024Local_name, StringComparison.CurrentCultureIgnoreCase) && string.Compare(s, _0024VB_0024Local_fullname, ignoreCase: true) != 0) ? true : false;
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__21
	{
		public string _0024VB_0024Local_fullname;

		public string _0024VB_0024Local_name;

		[DebuggerNonUserCode]
		public _Closure_0024__21()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__21(_Closure_0024__21 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_fullname = other._0024VB_0024Local_fullname;
				_0024VB_0024Local_name = other._0024VB_0024Local_name;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__36(string s)
		{
			return (s.EndsWith(_0024VB_0024Local_name) && string.Compare(s, _0024VB_0024Local_fullname, ignoreCase: true) != 0) ? true : false;
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn1")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn1;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn2")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn2;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn3")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn3;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn4")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn4;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn5")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn5;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn6")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn6;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn7")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn7;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn8")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn8;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn9")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn9;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn10")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn10;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn11")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn11;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn12")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn12;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn13")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn13;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn14")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn14;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn15")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn15;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn16")]
	private DataGridViewCheckBoxColumn _DataGridViewCheckBoxColumn16;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	[AccessedThroughProperty("csmp1")]
	private ContextMenuStrip _csmp1;

	[AccessedThroughProperty("在solidworks中打开ToolStripMenuItem")]
	private ToolStripMenuItem _在solidworks中打开ToolStripMenuItem;

	[AccessedThroughProperty("在文件夹中打开ToolStripMenuItem")]
	private ToolStripMenuItem _在文件夹中打开ToolStripMenuItem;

	[AccessedThroughProperty("ListView1")]
	private ListViewVR _ListView1;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("ToolStripStatusLabel1")]
	private ToolStripStatusLabel _ToolStripStatusLabel1;

	[AccessedThroughProperty("ToolStripProgressBar1")]
	private ToolStripProgressBar _ToolStripProgressBar1;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("OK_Button")]
	private ToolStripButton _OK_Button;

	[AccessedThroughProperty("修改ToolStripMenuItem")]
	private ToolStripMenuItem _修改ToolStripMenuItem;

	[AccessedThroughProperty("ListView2")]
	private ListViewVR _ListView2;

	[AccessedThroughProperty("addfiles")]
	private ToolStripSplitButton _addfiles;

	[AccessedThroughProperty("addfilesformfolder1")]
	private ToolStripMenuItem _addfilesformfolder1;

	[AccessedThroughProperty("addfilesformfolder2")]
	private ToolStripMenuItem _addfilesformfolder2;

	[AccessedThroughProperty("addactiveasmformSW")]
	private ToolStripMenuItem _addactiveasmformSW;

	[AccessedThroughProperty("addasmformSW")]
	private ToolStripMenuItem _addasmformSW;

	[AccessedThroughProperty("clearsel")]
	private Button _clearsel;

	[AccessedThroughProperty("clearall")]
	private Button _clearall;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("RadioButton3")]
	private RadioButton _RadioButton3;

	[AccessedThroughProperty("RadioButton4")]
	private RadioButton _RadioButton4;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("csmp2")]
	private ContextMenuStrip _csmp2;

	[AccessedThroughProperty("openinsw")]
	private ToolStripMenuItem _openinsw;

	[AccessedThroughProperty("openinfolder")]
	private ToolStripMenuItem _openinfolder;

	[AccessedThroughProperty("GroupBox6")]
	private GroupBox _GroupBox6;

	[AccessedThroughProperty("GroupBox5")]
	private GroupBox _GroupBox5;

	[AccessedThroughProperty("Containssubfolders")]
	private CheckBox _Containssubfolders;

	[AccessedThroughProperty("ToSpecificFolder")]
	private RadioButton _ToSpecificFolder;

	[AccessedThroughProperty("MovetoRecycle")]
	private RadioButton _MovetoRecycle;

	[AccessedThroughProperty("UnMoveto")]
	private RadioButton _UnMoveto;

	[AccessedThroughProperty("Replacereference_SpecificFolder")]
	private TextBox _Replacereference_SpecificFolder;

	[AccessedThroughProperty("Replacereference_folderpath")]
	private TextBox _Replacereference_folderpath;

	[AccessedThroughProperty("SplitContainer1")]
	private SplitContainer _SplitContainer1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	private List<string> f;

	private string oldval1;

	private string oldval2;

	private List<ListViewItem> lvi1;

	private double dpixRatio;

	private Thread mythread;

	internal bool Abort;

	private string SpecificFolder;

	private int selrow;

	private int row;

	private int currow;

	private int curcol;

	private Array arr;

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn1
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn1 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn2
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn2 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn3
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn3 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn4
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn4 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn5
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn5 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn6
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn6 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn7
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn7 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn8
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn8 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn9
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn9 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn10
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn10 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn11
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn11 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn12
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn12 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn13
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn13 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn14
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn14 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn15
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn15 = value;
		}
	}

	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn16
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewCheckBoxColumn16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewCheckBoxColumn16 = value;
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

	internal virtual ContextMenuStrip csmp1
	{
		[DebuggerNonUserCode]
		get
		{
			return _csmp1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = csmp1_ItemClicked;
			if (_csmp1 != null)
			{
				_csmp1.ItemClicked -= value2;
			}
			_csmp1 = value;
			if (_csmp1 != null)
			{
				_csmp1.ItemClicked += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 在solidworks中打开ToolStripMenuItem
	{
		[DebuggerNonUserCode]
		get
		{
			return _在solidworks中打开ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_在solidworks中打开ToolStripMenuItem = value;
		}
	}

	internal virtual ToolStripMenuItem 在文件夹中打开ToolStripMenuItem
	{
		[DebuggerNonUserCode]
		get
		{
			return _在文件夹中打开ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_在文件夹中打开ToolStripMenuItem = value;
		}
	}

	internal virtual ListViewVR ListView1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ListView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = ListView1_MouseDown;
			EventHandler obj = ListView1_Resize;
			EventHandler obj2 = ListView1_Resize;
			EventHandler value3 = ListView1_Resize;
			ColumnWidthChangingEventHandler value4 = ListView1_ColumnWidthChanging;
			ListViewItemSelectionChangedEventHandler value5 = ListView1_ItemSelectionChanged;
			if (_ListView1 != null)
			{
				_ListView1.MouseDown -= value2;
				_ListView1.VScroll -= obj;
				_ListView1.HScroll -= obj2;
				_ListView1.Resize -= value3;
				_ListView1.ColumnWidthChanging -= value4;
				_ListView1.ItemSelectionChanged -= value5;
			}
			_ListView1 = value;
			if (_ListView1 != null)
			{
				_ListView1.MouseDown += value2;
				_ListView1.VScroll += obj;
				_ListView1.HScroll += obj2;
				_ListView1.Resize += value3;
				_ListView1.ColumnWidthChanging += value4;
				_ListView1.ItemSelectionChanged += value5;
			}
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

	internal virtual ToolStripStatusLabel ToolStripStatusLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripStatusLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripStatusLabel1 = value;
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
			PaintEventHandler value2 = ToolStrip1_Paint;
			if (_ToolStrip1 != null)
			{
				_ToolStrip1.Paint -= value2;
			}
			_ToolStrip1 = value;
			if (_ToolStrip1 != null)
			{
				_ToolStrip1.Paint += value2;
			}
		}
	}

	internal virtual ToolStripButton OK_Button
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
			EventHandler value2 = OK_Button_Click_1;
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

	internal virtual ToolStripMenuItem 修改ToolStripMenuItem
	{
		[DebuggerNonUserCode]
		get
		{
			return _修改ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_修改ToolStripMenuItem = value;
		}
	}

	internal virtual ListViewVR ListView2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ListView2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = ListView2_MouseDown;
			ListViewItemSelectionChangedEventHandler value3 = ListView2_ItemSelectionChanged;
			if (_ListView2 != null)
			{
				_ListView2.MouseUp -= value2;
				_ListView2.ItemSelectionChanged -= value3;
			}
			_ListView2 = value;
			if (_ListView2 != null)
			{
				_ListView2.MouseUp += value2;
				_ListView2.ItemSelectionChanged += value3;
			}
		}
	}

	internal virtual ToolStripSplitButton addfiles
	{
		[DebuggerNonUserCode]
		get
		{
			return _addfiles;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addfiles_Click;
			MouseEventHandler value3 = addfiles_MouseMove;
			if (_addfiles != null)
			{
				_addfiles.ButtonClick -= value2;
				_addfiles.MouseMove -= value3;
			}
			_addfiles = value;
			if (_addfiles != null)
			{
				_addfiles.ButtonClick += value2;
				_addfiles.MouseMove += value3;
			}
		}
	}

	internal virtual ToolStripMenuItem addfilesformfolder1
	{
		[DebuggerNonUserCode]
		get
		{
			return _addfilesformfolder1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addfilesformfolder_Click;
			if (_addfilesformfolder1 != null)
			{
				_addfilesformfolder1.Click -= value2;
			}
			_addfilesformfolder1 = value;
			if (_addfilesformfolder1 != null)
			{
				_addfilesformfolder1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addfilesformfolder2
	{
		[DebuggerNonUserCode]
		get
		{
			return _addfilesformfolder2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addfilesformfolder_Click;
			if (_addfilesformfolder2 != null)
			{
				_addfilesformfolder2.Click -= value2;
			}
			_addfilesformfolder2 = value;
			if (_addfilesformfolder2 != null)
			{
				_addfilesformfolder2.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addactiveasmformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _addactiveasmformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addactiveasmformSW_Click;
			if (_addactiveasmformSW != null)
			{
				_addactiveasmformSW.Click -= value2;
			}
			_addactiveasmformSW = value;
			if (_addactiveasmformSW != null)
			{
				_addactiveasmformSW.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addasmformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _addasmformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addasmformSW_Click;
			if (_addasmformSW != null)
			{
				_addasmformSW.Click -= value2;
			}
			_addasmformSW = value;
			if (_addasmformSW != null)
			{
				_addasmformSW.Click += value2;
			}
		}
	}

	internal virtual Button clearsel
	{
		[DebuggerNonUserCode]
		get
		{
			return _clearsel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = clearsel_Click;
			if (_clearsel != null)
			{
				_clearsel.Click -= value2;
			}
			_clearsel = value;
			if (_clearsel != null)
			{
				_clearsel.Click += value2;
			}
		}
	}

	internal virtual Button clearall
	{
		[DebuggerNonUserCode]
		get
		{
			return _clearall;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = clearall_Click;
			if (_clearall != null)
			{
				_clearall.Click -= value2;
			}
			_clearall = value;
			if (_clearall != null)
			{
				_clearall.Click += value2;
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
			EventHandler value2 = RadioButton4_CheckedChanged;
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
			_RadioButton4 = value;
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
			_RadioButton2 = value;
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

	internal virtual ContextMenuStrip csmp2
	{
		[DebuggerNonUserCode]
		get
		{
			return _csmp2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_csmp2 = value;
		}
	}

	internal virtual ToolStripMenuItem openinsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _openinsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = openinsw_Click;
			if (_openinsw != null)
			{
				_openinsw.Click -= value2;
			}
			_openinsw = value;
			if (_openinsw != null)
			{
				_openinsw.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem openinfolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _openinfolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = openinfolder_Click;
			if (_openinfolder != null)
			{
				_openinfolder.Click -= value2;
			}
			_openinfolder = value;
			if (_openinfolder != null)
			{
				_openinfolder.Click += value2;
			}
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

	internal virtual CheckBox Containssubfolders
	{
		[DebuggerNonUserCode]
		get
		{
			return _Containssubfolders;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Containssubfolders_CheckedChanged;
			if (_Containssubfolders != null)
			{
				_Containssubfolders.CheckedChanged -= value2;
			}
			_Containssubfolders = value;
			if (_Containssubfolders != null)
			{
				_Containssubfolders.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton ToSpecificFolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToSpecificFolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = MovetoRecycle_CheckedChanged;
			if (_ToSpecificFolder != null)
			{
				_ToSpecificFolder.CheckedChanged -= value2;
			}
			_ToSpecificFolder = value;
			if (_ToSpecificFolder != null)
			{
				_ToSpecificFolder.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton MovetoRecycle
	{
		[DebuggerNonUserCode]
		get
		{
			return _MovetoRecycle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = MovetoRecycle_CheckedChanged;
			if (_MovetoRecycle != null)
			{
				_MovetoRecycle.CheckedChanged -= value2;
			}
			_MovetoRecycle = value;
			if (_MovetoRecycle != null)
			{
				_MovetoRecycle.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton UnMoveto
	{
		[DebuggerNonUserCode]
		get
		{
			return _UnMoveto;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = MovetoRecycle_CheckedChanged;
			EventHandler value3 = MovetoRecycle_CheckedChanged;
			if (_UnMoveto != null)
			{
				_UnMoveto.CheckedChanged -= value2;
				_UnMoveto.CheckedChanged -= value3;
			}
			_UnMoveto = value;
			if (_UnMoveto != null)
			{
				_UnMoveto.CheckedChanged += value2;
				_UnMoveto.CheckedChanged += value3;
			}
		}
	}

	internal virtual TextBox Replacereference_SpecificFolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _Replacereference_SpecificFolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Replacereference_SpecificFolder = value;
		}
	}

	internal virtual TextBox Replacereference_folderpath
	{
		[DebuggerNonUserCode]
		get
		{
			return _Replacereference_folderpath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Replacereference_folderpath = value;
		}
	}

	internal virtual SplitContainer SplitContainer1
	{
		[DebuggerNonUserCode]
		get
		{
			return _SplitContainer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_SplitContainer1 = value;
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
			EventHandler value2 = Replacereference_SpecificFolder_btn_Click;
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
			EventHandler value2 = Replacereference_folderpath_btn_Click;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.FrmReplacePartslist));
		this.DataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn14 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn15 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.DataGridViewCheckBoxColumn16 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.csmp1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.在solidworks中打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.在文件夹中打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.GroupBox6 = new System.Windows.Forms.GroupBox();
		this.Button2 = new System.Windows.Forms.Button();
		this.Replacereference_SpecificFolder = new System.Windows.Forms.TextBox();
		this.ToSpecificFolder = new System.Windows.Forms.RadioButton();
		this.UnMoveto = new System.Windows.Forms.RadioButton();
		this.MovetoRecycle = new System.Windows.Forms.RadioButton();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Replacereference_folderpath = new System.Windows.Forms.TextBox();
		this.Containssubfolders = new System.Windows.Forms.CheckBox();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.addfiles = new System.Windows.Forms.ToolStripSplitButton();
		this.addfilesformfolder1 = new System.Windows.Forms.ToolStripMenuItem();
		this.addfilesformfolder2 = new System.Windows.Forms.ToolStripMenuItem();
		this.addactiveasmformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.addasmformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.OK_Button = new System.Windows.Forms.ToolStripButton();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.RadioButton3 = new System.Windows.Forms.RadioButton();
		this.RadioButton4 = new System.Windows.Forms.RadioButton();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.clearall = new System.Windows.Forms.Button();
		this.clearsel = new System.Windows.Forms.Button();
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.openinfolder = new System.Windows.Forms.ToolStripMenuItem();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
		this.Label1 = new System.Windows.Forms.Label();
		this.ListView2 = new ZTool.ListViewVR();
		this.ListView1 = new ZTool.ListViewVR();
		this.Label2 = new System.Windows.Forms.Label();
		this.csmp1.SuspendLayout();
		this.GroupBox6.SuspendLayout();
		this.GroupBox5.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.ToolStrip1.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.csmp2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
		this.SplitContainer1.Panel1.SuspendLayout();
		this.SplitContainer1.Panel2.SuspendLayout();
		this.SplitContainer1.SuspendLayout();
		this.SuspendLayout();
		this.DataGridViewCheckBoxColumn1.FalseValue = false;
		this.DataGridViewCheckBoxColumn1.HeaderText = "";
		this.DataGridViewCheckBoxColumn1.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1";
		this.DataGridViewCheckBoxColumn1.TrueValue = true;
		this.DataGridViewCheckBoxColumn1.Width = 25;
		this.DataGridViewCheckBoxColumn2.FalseValue = false;
		this.DataGridViewCheckBoxColumn2.HeaderText = "";
		this.DataGridViewCheckBoxColumn2.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2";
		this.DataGridViewCheckBoxColumn2.TrueValue = true;
		this.DataGridViewCheckBoxColumn2.Width = 25;
		this.DataGridViewCheckBoxColumn3.FalseValue = false;
		this.DataGridViewCheckBoxColumn3.HeaderText = "";
		this.DataGridViewCheckBoxColumn3.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3";
		this.DataGridViewCheckBoxColumn3.TrueValue = true;
		this.DataGridViewCheckBoxColumn3.Width = 25;
		this.DataGridViewCheckBoxColumn4.FalseValue = false;
		this.DataGridViewCheckBoxColumn4.HeaderText = "";
		this.DataGridViewCheckBoxColumn4.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4";
		this.DataGridViewCheckBoxColumn4.TrueValue = true;
		this.DataGridViewCheckBoxColumn4.Width = 25;
		this.DataGridViewCheckBoxColumn5.FalseValue = false;
		this.DataGridViewCheckBoxColumn5.HeaderText = "";
		this.DataGridViewCheckBoxColumn5.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5";
		this.DataGridViewCheckBoxColumn5.TrueValue = true;
		this.DataGridViewCheckBoxColumn5.Width = 25;
		this.DataGridViewCheckBoxColumn6.FalseValue = false;
		this.DataGridViewCheckBoxColumn6.HeaderText = "";
		this.DataGridViewCheckBoxColumn6.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn6.Name = "DataGridViewCheckBoxColumn6";
		this.DataGridViewCheckBoxColumn6.TrueValue = true;
		this.DataGridViewCheckBoxColumn6.Width = 25;
		this.DataGridViewCheckBoxColumn7.FalseValue = false;
		this.DataGridViewCheckBoxColumn7.HeaderText = "";
		this.DataGridViewCheckBoxColumn7.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn7.Name = "DataGridViewCheckBoxColumn7";
		this.DataGridViewCheckBoxColumn7.TrueValue = true;
		this.DataGridViewCheckBoxColumn7.Width = 25;
		this.DataGridViewCheckBoxColumn8.FalseValue = false;
		this.DataGridViewCheckBoxColumn8.HeaderText = "";
		this.DataGridViewCheckBoxColumn8.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn8.Name = "DataGridViewCheckBoxColumn8";
		this.DataGridViewCheckBoxColumn8.TrueValue = true;
		this.DataGridViewCheckBoxColumn8.Width = 25;
		this.DataGridViewCheckBoxColumn9.FalseValue = false;
		this.DataGridViewCheckBoxColumn9.HeaderText = "";
		this.DataGridViewCheckBoxColumn9.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn9.Name = "DataGridViewCheckBoxColumn9";
		this.DataGridViewCheckBoxColumn9.TrueValue = true;
		this.DataGridViewCheckBoxColumn9.Width = 25;
		this.DataGridViewCheckBoxColumn10.FalseValue = false;
		this.DataGridViewCheckBoxColumn10.HeaderText = "";
		this.DataGridViewCheckBoxColumn10.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn10.Name = "DataGridViewCheckBoxColumn10";
		this.DataGridViewCheckBoxColumn10.TrueValue = true;
		this.DataGridViewCheckBoxColumn10.Width = 25;
		this.DataGridViewCheckBoxColumn11.FalseValue = false;
		this.DataGridViewCheckBoxColumn11.HeaderText = "";
		this.DataGridViewCheckBoxColumn11.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn11.Name = "DataGridViewCheckBoxColumn11";
		this.DataGridViewCheckBoxColumn11.TrueValue = true;
		this.DataGridViewCheckBoxColumn11.Width = 25;
		this.DataGridViewCheckBoxColumn12.FalseValue = false;
		this.DataGridViewCheckBoxColumn12.HeaderText = "";
		this.DataGridViewCheckBoxColumn12.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn12.Name = "DataGridViewCheckBoxColumn12";
		this.DataGridViewCheckBoxColumn12.TrueValue = true;
		this.DataGridViewCheckBoxColumn12.Width = 25;
		this.DataGridViewCheckBoxColumn13.FalseValue = false;
		this.DataGridViewCheckBoxColumn13.HeaderText = "";
		this.DataGridViewCheckBoxColumn13.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn13.Name = "DataGridViewCheckBoxColumn13";
		this.DataGridViewCheckBoxColumn13.TrueValue = true;
		this.DataGridViewCheckBoxColumn13.Width = 25;
		this.DataGridViewCheckBoxColumn14.FalseValue = false;
		this.DataGridViewCheckBoxColumn14.HeaderText = "";
		this.DataGridViewCheckBoxColumn14.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn14.Name = "DataGridViewCheckBoxColumn14";
		this.DataGridViewCheckBoxColumn14.TrueValue = true;
		this.DataGridViewCheckBoxColumn14.Width = 25;
		this.DataGridViewCheckBoxColumn15.FalseValue = false;
		this.DataGridViewCheckBoxColumn15.HeaderText = "";
		this.DataGridViewCheckBoxColumn15.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn15.Name = "DataGridViewCheckBoxColumn15";
		this.DataGridViewCheckBoxColumn15.TrueValue = true;
		this.DataGridViewCheckBoxColumn15.Width = 25;
		this.DataGridViewCheckBoxColumn16.FalseValue = false;
		this.DataGridViewCheckBoxColumn16.HeaderText = "";
		this.DataGridViewCheckBoxColumn16.MinimumWidth = 25;
		this.DataGridViewCheckBoxColumn16.Name = "DataGridViewCheckBoxColumn16";
		this.DataGridViewCheckBoxColumn16.TrueValue = true;
		this.DataGridViewCheckBoxColumn16.Width = 25;
		this.csmp1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.在solidworks中打开ToolStripMenuItem, this.在文件夹中打开ToolStripMenuItem, this.修改ToolStripMenuItem });
		this.csmp1.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp1;
		System.Drawing.Size size = new System.Drawing.Size(188, 70);
		contextMenuStrip.Size = size;
		this.在solidworks中打开ToolStripMenuItem.Name = "在solidworks中打开ToolStripMenuItem";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.在solidworks中打开ToolStripMenuItem;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem.Size = size;
		this.在solidworks中打开ToolStripMenuItem.Text = "Открыть в SolidWorks";
		this.在文件夹中打开ToolStripMenuItem.Name = "在文件夹中打开ToolStripMenuItem";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.在文件夹中打开ToolStripMenuItem;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem2.Size = size;
		this.在文件夹中打开ToolStripMenuItem.Text = "Открыть в папке";
		this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.修改ToolStripMenuItem;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem3.Size = size;
		this.修改ToolStripMenuItem.Text = "Изменить";
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "sldasm.png");
		this.ImageList1.Images.SetKeyName(1, "sldprt.png");
		this.ImageList1.Images.SetKeyName(2, "slddrw.png");
		this.ImageList1.Images.SetKeyName(3, "FolderClose.png");
		this.GroupBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.GroupBox6.Controls.Add(this.Button2);
		this.GroupBox6.Controls.Add(this.Replacereference_SpecificFolder);
		this.GroupBox6.Controls.Add(this.ToSpecificFolder);
		this.GroupBox6.Controls.Add(this.UnMoveto);
		this.GroupBox6.Controls.Add(this.MovetoRecycle);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox6;
		System.Drawing.Point location = new System.Drawing.Point(448, 377);
		groupBox.Location = location;
		this.GroupBox6.Name = "GroupBox6";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox6;
		size = new System.Drawing.Size(450, 104);
		groupBox2.Size = size;
		this.GroupBox6.TabIndex = 1;
		this.GroupBox6.TabStop = false;
		this.GroupBox6.Text = "Заменённые компоненты переместить в";
		this.Button2.AutoSize = true;
		System.Windows.Forms.Button button = this.Button2;
		location = new System.Drawing.Point(405, 71);
		button.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button2 = this.Button2;
		size = new System.Drawing.Size(33, 27);
		button2.Size = size;
		this.Button2.TabIndex = 5;
		this.Button2.Text = "...";
		this.Button2.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox replacereference_SpecificFolder = this.Replacereference_SpecificFolder;
		location = new System.Drawing.Point(21, 73);
		replacereference_SpecificFolder.Location = location;
		this.Replacereference_SpecificFolder.Name = "Replacereference_SpecificFolder";
		this.Replacereference_SpecificFolder.ReadOnly = true;
		System.Windows.Forms.TextBox replacereference_SpecificFolder2 = this.Replacereference_SpecificFolder;
		size = new System.Drawing.Size(381, 23);
		replacereference_SpecificFolder2.Size = size;
		this.Replacereference_SpecificFolder.TabIndex = 4;
		this.ToSpecificFolder.AutoSize = true;
		System.Windows.Forms.RadioButton toSpecificFolder = this.ToSpecificFolder;
		location = new System.Drawing.Point(12, 48);
		toSpecificFolder.Location = location;
		this.ToSpecificFolder.Name = "ToSpecificFolder";
		System.Windows.Forms.RadioButton toSpecificFolder2 = this.ToSpecificFolder;
		size = new System.Drawing.Size(74, 21);
		toSpecificFolder2.Size = size;
		this.ToSpecificFolder.TabIndex = 3;
		this.ToSpecificFolder.Text = "Эта папка";
		this.ToSpecificFolder.UseVisualStyleBackColor = true;
		this.UnMoveto.AutoSize = true;
		this.UnMoveto.Checked = true;
		System.Windows.Forms.RadioButton unMoveto = this.UnMoveto;
		location = new System.Drawing.Point(175, 24);
		unMoveto.Location = location;
		this.UnMoveto.Name = "UnMoveto";
		System.Windows.Forms.RadioButton unMoveto2 = this.UnMoveto;
		size = new System.Drawing.Size(62, 21);
		unMoveto2.Size = size;
		this.UnMoveto.TabIndex = 2;
		this.UnMoveto.TabStop = true;
		this.UnMoveto.Text = "Не обрабатывать";
		this.UnMoveto.UseVisualStyleBackColor = true;
		this.MovetoRecycle.AutoSize = true;
		System.Windows.Forms.RadioButton movetoRecycle = this.MovetoRecycle;
		location = new System.Drawing.Point(12, 24);
		movetoRecycle.Location = location;
		this.MovetoRecycle.Name = "MovetoRecycle";
		System.Windows.Forms.RadioButton movetoRecycle2 = this.MovetoRecycle;
		size = new System.Drawing.Size(62, 21);
		movetoRecycle2.Size = size;
		this.MovetoRecycle.TabIndex = 2;
		this.MovetoRecycle.Text = "Корзина";
		this.MovetoRecycle.UseVisualStyleBackColor = true;
		this.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.GroupBox5.Controls.Add(this.Button1);
		this.GroupBox5.Controls.Add(this.Replacereference_folderpath);
		this.GroupBox5.Controls.Add(this.Containssubfolders);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox5;
		location = new System.Drawing.Point(11, 377);
		groupBox3.Location = location;
		this.GroupBox5.Name = "GroupBox5";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox5;
		size = new System.Drawing.Size(426, 104);
		groupBox4.Size = size;
		this.GroupBox5.TabIndex = 1;
		this.GroupBox5.TabStop = false;
		this.GroupBox5.Text = "Путь к новым ссылочным файлам";
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button3 = this.Button1;
		location = new System.Drawing.Point(380, 58);
		button3.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button4 = this.Button1;
		size = new System.Drawing.Size(33, 27);
		button4.Size = size;
		this.Button1.TabIndex = 3;
		this.Button1.Text = "...";
		this.Button1.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox replacereference_folderpath = this.Replacereference_folderpath;
		location = new System.Drawing.Point(10, 60);
		replacereference_folderpath.Location = location;
		this.Replacereference_folderpath.Name = "Replacereference_folderpath";
		this.Replacereference_folderpath.ReadOnly = true;
		System.Windows.Forms.TextBox replacereference_folderpath2 = this.Replacereference_folderpath;
		size = new System.Drawing.Size(367, 23);
		replacereference_folderpath2.Size = size;
		this.Replacereference_folderpath.TabIndex = 2;
		this.Containssubfolders.AutoSize = true;
		System.Windows.Forms.CheckBox containssubfolders = this.Containssubfolders;
		location = new System.Drawing.Point(12, 24);
		containssubfolders.Location = location;
		this.Containssubfolders.Name = "Containssubfolders";
		System.Windows.Forms.CheckBox containssubfolders2 = this.Containssubfolders;
		size = new System.Drawing.Size(87, 21);
		containssubfolders2.Size = size;
		this.Containssubfolders.TabIndex = 1;
		this.Containssubfolders.Text = "Включая подпапки";
		this.Containssubfolders.UseVisualStyleBackColor = true;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ToolStripStatusLabel1, this.ToolStripProgressBar1 });
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		location = new System.Drawing.Point(0, 539);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(1214, 22);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 17;
		this.StatusStrip1.Text = "StatusStrip1";
		this.ToolStripStatusLabel1.AutoSize = false;
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel = this.ToolStripStatusLabel1;
		size = new System.Drawing.Size(200, 17);
		toolStripStatusLabel.Size = size;
		this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
		System.Windows.Forms.ToolStripProgressBar toolStripProgressBar = this.ToolStripProgressBar1;
		size = new System.Drawing.Size(300, 16);
		toolStripProgressBar.Size = size;
		this.ToolStrip1.AutoSize = false;
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.addfiles, this.OK_Button });
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(2, 2, 2, 5);
		toolStrip2.Padding = padding;
		this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		System.Windows.Forms.ToolStrip toolStrip3 = this.ToolStrip1;
		size = new System.Drawing.Size(1214, 40);
		toolStrip3.Size = size;
		this.ToolStrip1.TabIndex = 16;
		this.ToolStrip1.Text = "ToolStrip1";
		this.addfiles.DropDownButtonWidth = 20;
		this.addfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.addfilesformfolder1, this.addfilesformfolder2, this.addactiveasmformSW, this.addasmformSW });
		this.addfiles.Image = (System.Drawing.Image)resources.GetObject("addfiles.Image");
		this.addfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripSplitButton toolStripSplitButton = this.addfiles;
		padding = new System.Windows.Forms.Padding(10, 1, 2, 2);
		toolStripSplitButton.Margin = padding;
		this.addfiles.Name = "addfiles";
		System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2 = this.addfiles;
		size = new System.Drawing.Size(97, 30);
		toolStripSplitButton2.Size = size;
		this.addfiles.Text = "Добавить файл";
		this.addfilesformfolder1.Image = (System.Drawing.Image)resources.GetObject("addfilesformfolder1.Image");
		this.addfilesformfolder1.Name = "addfilesformfolder1";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4 = this.addfilesformfolder1;
		size = new System.Drawing.Size(259, 22);
		toolStripMenuItem4.Size = size;
		this.addfilesformfolder1.Tag = "false";
		this.addfilesformfolder1.Text = "Добавить папку";
		this.addfilesformfolder2.Image = (System.Drawing.Image)resources.GetObject("addfilesformfolder2.Image");
		this.addfilesformfolder2.Name = "addfilesformfolder2";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5 = this.addfilesformfolder2;
		size = new System.Drawing.Size(259, 22);
		toolStripMenuItem5.Size = size;
		this.addfilesformfolder2.Tag = "true";
		this.addfilesformfolder2.Text = "Добавить папку (включая подпапки)";
		this.addactiveasmformSW.Image = (System.Drawing.Image)resources.GetObject("addactiveasmformSW.Image");
		this.addactiveasmformSW.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.addactiveasmformSW.Name = "addactiveasmformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6 = this.addactiveasmformSW;
		size = new System.Drawing.Size(259, 22);
		toolStripMenuItem6.Size = size;
		this.addactiveasmformSW.Text = "Загрузить активную сборку SolidWorks";
		this.addasmformSW.Image = (System.Drawing.Image)resources.GetObject("addasmformSW.Image");
		this.addasmformSW.Name = "addasmformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7 = this.addasmformSW;
		size = new System.Drawing.Size(259, 22);
		toolStripMenuItem7.Size = size;
		this.addasmformSW.Text = "Загрузить открытые в SolidWorks сборки";
		this.OK_Button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.OK_Button.Image = (System.Drawing.Image)resources.GetObject("OK_Button.Image");
		this.OK_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton oK_Button = this.OK_Button;
		padding = new System.Windows.Forms.Padding(0, 1, 20, 2);
		oK_Button.Margin = padding;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.ToolStripButton oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(52, 30);
		oK_Button2.Size = size;
		this.OK_Button.Text = "Старт";
		this.GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.GroupBox4.Controls.Add(this.RadioButton3);
		this.GroupBox4.Controls.Add(this.RadioButton4);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox4;
		location = new System.Drawing.Point(154, 411);
		groupBox5.Location = location;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox4;
		size = new System.Drawing.Size(133, 71);
		groupBox6.Size = size;
		this.GroupBox4.TabIndex = 2;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Правило чтения";
		this.RadioButton3.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton3;
		location = new System.Drawing.Point(16, 43);
		radioButton.Location = location;
		this.RadioButton3.Name = "RadioButton3";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton3;
		size = new System.Drawing.Size(86, 21);
		radioButton2.Size = size;
		this.RadioButton3.TabIndex = 1;
		this.RadioButton3.Text = "По последнему сохранению";
		this.RadioButton3.UseVisualStyleBackColor = true;
		this.RadioButton4.AutoSize = true;
		this.RadioButton4.Checked = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton4;
		location = new System.Drawing.Point(16, 21);
		radioButton3.Location = location;
		this.RadioButton4.Name = "RadioButton4";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton4;
		size = new System.Drawing.Size(86, 21);
		radioButton4.Size = size;
		this.RadioButton4.TabIndex = 0;
		this.RadioButton4.TabStop = true;
		this.RadioButton4.Text = "По правилу поиска";
		this.RadioButton4.UseVisualStyleBackColor = true;
		this.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.GroupBox3.Controls.Add(this.RadioButton2);
		this.GroupBox3.Controls.Add(this.RadioButton1);
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox3;
		location = new System.Drawing.Point(11, 411);
		groupBox7.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox3;
		size = new System.Drawing.Size(133, 71);
		groupBox8.Size = size;
		this.GroupBox3.TabIndex = 2;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Тип ссылки";
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton5 = this.RadioButton2;
		location = new System.Drawing.Point(16, 43);
		radioButton5.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton6 = this.RadioButton2;
		size = new System.Drawing.Size(86, 21);
		radioButton6.Size = size;
		this.RadioButton2.TabIndex = 1;
		this.RadioButton2.Text = "Сводка по компонентам";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton7 = this.RadioButton1;
		location = new System.Drawing.Point(16, 21);
		radioButton7.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton8 = this.RadioButton1;
		size = new System.Drawing.Size(74, 21);
		radioButton8.Size = size;
		this.RadioButton1.TabIndex = 0;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Только верхний уровень";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.clearall.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.clearall.AutoSize = true;
		System.Windows.Forms.Button button5 = this.clearall;
		location = new System.Drawing.Point(103, 367);
		button5.Location = location;
		this.clearall.Name = "clearall";
		System.Windows.Forms.Button button6 = this.clearall;
		size = new System.Drawing.Size(65, 27);
		button6.Size = size;
		this.clearall.TabIndex = 1;
		this.clearall.Text = "Очистить";
		this.clearall.UseVisualStyleBackColor = true;
		this.clearsel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.clearsel.AutoSize = true;
		System.Windows.Forms.Button button7 = this.clearsel;
		location = new System.Drawing.Point(11, 367);
		button7.Location = location;
		this.clearsel.Name = "clearsel";
		System.Windows.Forms.Button button8 = this.clearsel;
		size = new System.Drawing.Size(66, 27);
		button8.Size = size;
		this.clearsel.TabIndex = 1;
		this.clearsel.Text = "Удалить выбранное";
		this.clearsel.UseVisualStyleBackColor = true;
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openinsw, this.openinfolder });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip2 = this.csmp2;
		size = new System.Drawing.Size(188, 48);
		contextMenuStrip2.Size = size;
		this.openinsw.Image = ZTool.My.Resources.Resources.SW_32px;
		this.openinsw.Name = "openinsw";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8 = this.openinsw;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem8.Size = size;
		this.openinsw.Text = "Открыть в SolidWorks";
		this.openinfolder.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.openinfolder.Name = "openinfolder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9 = this.openinfolder;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem9.Size = size;
		this.openinfolder.Text = "Открыть в папке";
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(12, 20);
		textBox.Location = location;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		size = new System.Drawing.Size(280, 21);
		textBox2.Size = size;
		this.TextBox1.TabIndex = 3;
		this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.SplitContainer splitContainer = this.SplitContainer1;
		location = new System.Drawing.Point(0, 40);
		splitContainer.Location = location;
		this.SplitContainer1.Name = "SplitContainer1";
		this.SplitContainer1.Panel1.Controls.Add(this.Label1);
		this.SplitContainer1.Panel1.Controls.Add(this.ListView2);
		this.SplitContainer1.Panel1.Controls.Add(this.clearall);
		this.SplitContainer1.Panel1.Controls.Add(this.GroupBox4);
		this.SplitContainer1.Panel1.Controls.Add(this.clearsel);
		this.SplitContainer1.Panel1.Controls.Add(this.GroupBox3);
		System.Windows.Forms.SplitterPanel panel = this.SplitContainer1.Panel1;
		padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
		panel.Padding = padding;
		this.SplitContainer1.Panel2.Controls.Add(this.ListView1);
		this.SplitContainer1.Panel2.Controls.Add(this.GroupBox6);
		this.SplitContainer1.Panel2.Controls.Add(this.Label2);
		this.SplitContainer1.Panel2.Controls.Add(this.GroupBox5);
		System.Windows.Forms.SplitterPanel panel2 = this.SplitContainer1.Panel2;
		padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
		panel2.Padding = padding;
		System.Windows.Forms.SplitContainer splitContainer2 = this.SplitContainer1;
		size = new System.Drawing.Size(1214, 499);
		splitContainer2.Size = size;
		this.SplitContainer1.SplitterDistance = 294;
		this.SplitContainer1.TabIndex = 19;
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(6, 8);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(56, 17);
		label2.Size = size;
		this.Label1.TabIndex = 3;
		this.Label1.Text = "Список файлов";
		this.ListView2.AllowDrop = true;
		this.ListView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ListView2.ContextMenuStrip = this.csmp2;
		this.ListView2.FullRowSelect = true;
		this.ListView2.GridLines = true;
		ZTool.ListViewVR listView = this.ListView2;
		location = new System.Drawing.Point(3, 30);
		listView.Location = location;
		this.ListView2.Name = "ListView2";
		ZTool.ListViewVR listView2 = this.ListView2;
		size = new System.Drawing.Size(286, 329);
		listView2.Size = size;
		this.ListView2.TabIndex = 0;
		this.ListView2.UseCompatibleStateImageBehavior = false;
		this.ListView2.View = System.Windows.Forms.View.Details;
		this.ListView2.VirtualMode = true;
		this.ListView1.AllowDrop = true;
		this.ListView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		ZTool.ListViewVR listView3 = this.ListView1;
		location = new System.Drawing.Point(3, 30);
		listView3.Location = location;
		this.ListView1.Name = "ListView1";
		ZTool.ListViewVR listView4 = this.ListView1;
		size = new System.Drawing.Size(908, 329);
		listView4.Size = size;
		this.ListView1.SmallImageList = this.ImageList1;
		this.ListView1.TabIndex = 0;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.VirtualMode = true;
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(6, 8);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(56, 17);
		label4.Size = size;
		this.Label2.TabIndex = 19;
		this.Label2.Text = "Список замен";
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(1214, 561);
		this.ClientSize = size;
		this.Controls.Add(this.SplitContainer1);
		this.Controls.Add(this.ToolStrip1);
		this.Controls.Add(this.StatusStrip1);
		size = new System.Drawing.Size(800, 600);
		this.MinimumSize = size;
		this.Name = "FrmReplacePartslist";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Tag = "Заменить ссылочные файлы";
		this.Text = "Заменить ссылочные файлы";
		this.csmp1.ResumeLayout(false);
		this.GroupBox6.ResumeLayout(false);
		this.GroupBox6.PerformLayout();
		this.GroupBox5.ResumeLayout(false);
		this.GroupBox5.PerformLayout();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.csmp2.ResumeLayout(false);
		this.SplitContainer1.Panel1.ResumeLayout(false);
		this.SplitContainer1.Panel1.PerformLayout();
		this.SplitContainer1.Panel2.ResumeLayout(false);
		this.SplitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
		this.SplitContainer1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmReplacePartslist()
	{
		base.FormClosed += FrmReplacePartslist_FormClosed;
		base.FormClosing += FrmReplaceParts_FormClosing;
		base.Load += FrmReplaceParts_Load;
		__ENCAddToList(this);
		f = new List<string>();
		lvi1 = new List<ListViewItem>();
		dpixRatio = 1.0;
		Abort = true;
		selrow = -1;
		arr = new string[4] { "Открыть в SolidWorks", "Открыть в папке", "Очистить", "Изменить" };
		InitializeComponent();
		if (!code.HasShell("笨小孩。。。"))
		{
			Environment.Exit(0);
		}
		checked
		{
			try
			{
				using (Graphics graphics = Graphics.FromHwnd(Handle))
				{
					dpixRatio = graphics.DpiX / 96f;
				}
				ToolStripStatusLabel1.Width = (int)Math.Round((double)ToolStripStatusLabel1.Width * dpixRatio);
				int num = addfiles.DropDownItems.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						if (addfiles.DropDownItems[num2] is ToolStripMenuItem)
						{
							addfiles.DropDownItems[num2].AutoSize = false;
							addfiles.DropDownItems[num2].Height = (int)Math.Round(22.0 * dpixRatio);
							ToolStripItem toolStripItem = addfiles.DropDownItems[num2];
							Padding padding = new Padding((int)Math.Round(10.0 * dpixRatio), 0, 0, 0);
							toolStripItem.Padding = padding;
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
				ProjectData.ClearProjectError();
			}
		}
		ConfigureResponsiveLayout();
	}

	private int Dpi(int value)
	{
		return checked((int)Math.Round((double)value * dpixRatio));
	}

	private void ConfigureResponsiveLayout()
	{
		FormBorderStyle = FormBorderStyle.Sizable;
		MaximizeBox = true;
		MaximumSize = Size.Empty;
		MinimumSize = new Size(Dpi(1320), Dpi(640));
		SizeGripStyle = SizeGripStyle.Show;
		Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		SplitContainer1.Font = Font;
		ToolStrip1.Font = Font;
		StatusStrip1.Font = Font;
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.Panel1MinSize = Dpi(380);
		SplitContainer1.Panel2MinSize = Dpi(900);
		ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ListView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Replacereference_folderpath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Replacereference_SpecificFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		clearsel.AutoSize = false;
		clearall.AutoSize = false;
		clearsel.MinimumSize = new Size(Dpi(110), Dpi(27));
		clearall.MinimumSize = new Size(Dpi(84), Dpi(27));
		if (Size.Width < MinimumSize.Width || Size.Height < MinimumSize.Height)
		{
			Size = new Size(Math.Max(Size.Width, MinimumSize.Width), Math.Max(Size.Height, MinimumSize.Height));
		}
		SplitContainer1.Panel1.Resize += FrmReplacePartslist_ResponsiveResize;
		SplitContainer1.Panel2.Resize += FrmReplacePartslist_ResponsiveResize;
		base.Resize += FrmReplacePartslist_ResponsiveResize;
		ApplyResponsiveLayout();
	}

	private void FrmReplacePartslist_ResponsiveResize(object sender, EventArgs e)
	{
		ApplyResponsiveLayout();
	}

	private void ApplyResponsiveLayout()
	{
		if (SplitContainer1 == null || SplitContainer1.Panel1 == null || SplitContainer1.Panel2 == null)
		{
			return;
		}
		try
		{
			SplitContainer1.SuspendLayout();
			SplitContainer1.Panel1.SuspendLayout();
			SplitContainer1.Panel2.SuspendLayout();
			ApplyFileListPanelLayout();
			ApplyReplacementPanelLayout();
		}
		finally
		{
			SplitContainer1.Panel2.ResumeLayout(performLayout: true);
			SplitContainer1.Panel1.ResumeLayout(performLayout: true);
			SplitContainer1.ResumeLayout(performLayout: true);
		}
	}

	private void ApplyFileListPanelLayout()
	{
		int panelWidth = Math.Max(SplitContainer1.Panel1.ClientSize.Width, Dpi(360));
		int panelHeight = Math.Max(SplitContainer1.Panel1.ClientSize.Height, Dpi(440));
		int margin = Dpi(10);
		int gridTop = Dpi(30);
		int groupTop = panelHeight - Dpi(84);
		int actionTop = groupTop - Dpi(36);
		int gridBottom = actionTop - Dpi(8);
		ListView2.Location = new Point(Dpi(3), gridTop);
		ListView2.Size = new Size(Math.Max(Dpi(260), panelWidth - Dpi(6)), Math.Max(Dpi(180), gridBottom - gridTop));
		clearsel.Location = new Point(margin, actionTop);
		clearsel.Size = new Size(Dpi(112), Dpi(27));
		clearall.Location = new Point(clearsel.Right + Dpi(8), actionTop);
		clearall.Size = new Size(Dpi(86), Dpi(27));
		GroupBox3.Location = new Point(margin, groupTop);
		GroupBox3.Size = new Size(Dpi(170), Dpi(74));
		GroupBox4.Location = new Point(GroupBox3.Right + Dpi(10), groupTop);
		GroupBox4.Size = new Size(Math.Max(Dpi(190), panelWidth - GroupBox4.Left - margin), Dpi(74));
	}

	private void ApplyReplacementPanelLayout()
	{
		int panelWidth = Math.Max(SplitContainer1.Panel2.ClientSize.Width, Dpi(860));
		int panelHeight = Math.Max(SplitContainer1.Panel2.ClientSize.Height, Dpi(440));
		int margin = Dpi(10);
		int gridTop = Dpi(30);
		int groupTop = panelHeight - Dpi(114);
		int gridBottom = groupTop - Dpi(8);
		ListView1.Location = new Point(Dpi(3), gridTop);
		ListView1.Size = new Size(Math.Max(Dpi(760), panelWidth - Dpi(6)), Math.Max(Dpi(180), gridBottom - gridTop));
		int availableWidth = panelWidth - margin * 3;
		int leftWidth = Math.Max(Dpi(430), availableWidth / 2);
		int rightWidth = Math.Max(Dpi(450), availableWidth - leftWidth);
		GroupBox5.Location = new Point(margin, groupTop);
		GroupBox5.Size = new Size(leftWidth, Dpi(94));
		GroupBox6.Location = new Point(GroupBox5.Right + margin, groupTop);
		GroupBox6.Size = new Size(rightWidth, Dpi(94));
		Button1.Size = new Size(Dpi(33), Dpi(27));
		Button1.Location = new Point(GroupBox5.ClientSize.Width - Button1.Width - Dpi(10), Dpi(58));
		Replacereference_folderpath.Location = new Point(Dpi(10), Dpi(60));
		Replacereference_folderpath.Size = new Size(Math.Max(Dpi(280), Button1.Left - Dpi(20)), Dpi(23));
		Button2.Size = new Size(Dpi(33), Dpi(27));
		Button2.Location = new Point(GroupBox6.ClientSize.Width - Button2.Width - Dpi(10), Dpi(71));
		Replacereference_SpecificFolder.Location = new Point(Dpi(21), Dpi(73));
		Replacereference_SpecificFolder.Size = new Size(Math.Max(Dpi(300), Button2.Left - Dpi(31)), Dpi(23));
	}

	private void FrmReplacePartslist_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			Savecfg();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void FrmReplaceParts_FormClosing(object sender, FormClosingEventArgs e)
	{
		Abort = true;
	}

	private void FrmReplaceParts_Load(object sender, EventArgs e)
	{
		try
		{
			SR sR = new SR();
			if (!sR.Isme("冰雨。。。"))
			{
				Environment.Exit(0);
			}
			MyProject.Forms.Frmmain.g_monitor();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
		try
		{
			MyProject.Forms.Frmmain.sendhwndtosw();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		Icon = Resources.replace32;
		ListView1.View = View.Details;
		ListView1.AllowDrop = true;
		ListView1.GridLines = true;
		ListView1.MultiSelect = true;
		ListView1.Clear();
		ListView1.Items.Clear();
		checked
		{
			int num = (int)Math.Round(50.0 * dpixRatio);
			int num2 = (int)Math.Round(400.0 * dpixRatio);
			int num3 = (int)Math.Round(400.0 * dpixRatio);
			int num4 = (int)Math.Round(120.0 * dpixRatio);
			int num5 = (int)Math.Round(50.0 * dpixRatio);
			ListView1.Columns.Add("Номер", num, HorizontalAlignment.Left);
			ListView1.Columns.Add("Ссылочный файл", num2, HorizontalAlignment.Left);
			ListView1.Columns.Add("Заменить на", num3, HorizontalAlignment.Left);
			ListView1.Columns.Add("Примечание", num4, HorizontalAlignment.Left);
			ListView1.Columns.Add("Статус", num5, HorizontalAlignment.Left);
			ListView2.View = View.Details;
			ListView2.AllowDrop = true;
			ListView2.GridLines = true;
			ListView2.MultiSelect = false;
			ListView2.Clear();
			ListView2.Items.Clear();
			int num6 = (int)Math.Round(50.0 * dpixRatio);
			int num7 = (int)Math.Round(250.0 * dpixRatio);
			int num8 = (int)Math.Round(200.0 * dpixRatio);
			ListView2.Columns.Add("Номер", num6, HorizontalAlignment.Left);
			ListView2.Columns.Add("Имя файла", num7, HorizontalAlignment.Left);
			ListView2.Columns.Add("Путь", num8, HorizontalAlignment.Left);
			try
			{
				Loadcfg();
				if (!Directory.Exists(Replacereference_folderpath.Text))
				{
					Replacereference_folderpath.Text = "";
				}
				if (!Directory.Exists(Replacereference_SpecificFolder.Text))
				{
					Replacereference_SpecificFolder.Text = "";
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				logopathlist.WriteLog($"Тип исключения: {ex6.GetType().Name}\r\nСообщение: {ex6.Message}\r\nИнформация: {ex6.StackTrace}");
				ProjectData.ClearProjectError();
			}
			ToolStripProgressBar1.Value = 0;
			ToolStripProgressBar1.Visible = false;
		}
	}

	private void addfiles_MouseMove(object sender, MouseEventArgs e)
	{
		addfiles.ShowDropDown();
	}

	private void ToolStrip1_Paint(object sender, PaintEventArgs e)
	{
		if (ToolStrip1.RenderMode == ToolStripRenderMode.System)
		{
			Rectangle clip = checked(new Rectangle(0, 0, ToolStrip1.Width - 8, ToolStrip1.Height - 8));
			e.Graphics.SetClip(clip);
		}
	}

	private void OK_Button_Click_1(object sender, EventArgs e)
	{
		try
		{
			Savecfg();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		if (Operators.CompareString(OK_Button.Text, "Стоп", TextCompare: false) == 0)
		{
			Abort = true;
		}
		else
		{
			if (Operators.CompareString(OK_Button.Text, "Старт", TextCompare: false) != 0 || lvi1.Count < 1)
			{
				return;
			}
			if (ToSpecificFolder.Checked)
			{
				if (Operators.CompareString(Replacereference_SpecificFolder.Text, "", TextCompare: false) == 0)
				{
					Interaction.MsgBox("Укажите путь перемещения исходных файлов после замены", MsgBoxStyle.Information, "Информация");
					return;
				}
				if (!Directory.Exists(Replacereference_SpecificFolder.Text))
				{
					if (Interaction.MsgBox("Путь" + Replacereference_SpecificFolder.Text + "не существует, создать?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "Вопрос") != MsgBoxResult.Ok)
					{
						return;
					}
					SpecificFolder = Directory.CreateDirectory(Replacereference_SpecificFolder.Text).FullName;
					if (!SpecificFolder.EndsWith("\\"))
					{
						SpecificFolder += "\\";
					}
				}
			}
			if (!code.RunSW())
			{
				return;
			}
			if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(code.swApp, null, "GetDocumentCount", new object[0], null, null, null), 0, TextCompare: false))
			{
				if (MessageBox.Show(this, "Закройте все открытые в SolidWorks файлы!\n\nЗакрыть все открытые в SolidWorks файлы автоматически?", "Особое предупреждение!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
				{
					return;
				}
				NewLateBinding.LateCall(code.swApp, null, "CloseAllDocuments", new object[1] { true }, null, null, null, IgnoreReturn: true);
			}
			Abort = false;
			code.EnablePreview = false;
			OK_Button.Text = "Стоп";
			mythread = new Thread(ReplaceReference);
			mythread.Name = "ReplaceReference";
			mythread.Start();
			Thread.Sleep(100);
		}
	}

	public void ReplaceReference()
	{
		_Closure_0024__15 closure_0024__ = new _Closure_0024__15();
		closure_0024__._0024VB_0024Me = this;
		checked
		{
			try
			{
				_Closure_0024__15._Closure_0024__16 closure_0024__2 = new _Closure_0024__15._Closure_0024__16();
				closure_0024__2._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A = closure_0024__;
				if (!code.RunSW())
				{
					return;
				}
				ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__27);
				List<string> list = new List<string>();
				int num = ListView2.Items.Count - 1;
				closure_0024__._0024VB_0024Local_i = 0;
				_Closure_0024__15._Closure_0024__16._Closure_0024__17 closure_0024__3 = default(_Closure_0024__15._Closure_0024__16._Closure_0024__17);
				while (true)
				{
					int num2 = closure_0024__._0024VB_0024Local_i;
					int num3 = num;
					if (num2 > num3)
					{
						break;
					}
					closure_0024__3 = new _Closure_0024__15._Closure_0024__16._Closure_0024__17(closure_0024__3);
					closure_0024__3._0024VB_0024Local_pathname = ListView2.Items[closure_0024__._0024VB_0024Local_i].SubItems[2].Text;
					if (File.Exists(closure_0024__3._0024VB_0024Local_pathname) && list.FindIndex(closure_0024__3._Lambda_0024__28) < 0)
					{
						list.Add(closure_0024__3._0024VB_0024Local_pathname);
					}
					closure_0024__._0024VB_0024Local_i++;
				}
				int num4 = lvi1.Count - 1;
				closure_0024__._0024VB_0024Local_i = 0;
				_Closure_0024__15._Closure_0024__16._Closure_0024__18 closure_0024__4 = default(_Closure_0024__15._Closure_0024__16._Closure_0024__18);
				while (true)
				{
					int num5 = closure_0024__._0024VB_0024Local_i;
					int num3 = num4;
					if (num5 > num3)
					{
						break;
					}
					closure_0024__4 = new _Closure_0024__15._Closure_0024__16._Closure_0024__18(closure_0024__4);
					closure_0024__4._0024VB_0024Local_pathname = lvi1[closure_0024__._0024VB_0024Local_i].SubItems[1].Text;
					if (code.SplitStr(closure_0024__4._0024VB_0024Local_pathname).StartsWith(code.SplitStr(Conversions.ToString(ListView1.Tag))) && File.Exists(closure_0024__4._0024VB_0024Local_pathname) && list.FindIndex(closure_0024__4._Lambda_0024__29) < 0)
					{
						list.Add(closure_0024__4._0024VB_0024Local_pathname);
					}
					closure_0024__._0024VB_0024Local_i++;
				}
				closure_0024__2._0024VB_0024Local_count = 0;
				int num6 = lvi1.Count - 1;
				closure_0024__._0024VB_0024Local_i = 0;
				_Closure_0024__15._Closure_0024__16._Closure_0024__19 closure_0024__5 = default(_Closure_0024__15._Closure_0024__16._Closure_0024__19);
				while (true)
				{
					int num7 = closure_0024__._0024VB_0024Local_i;
					int num3 = num6;
					if (num7 > num3)
					{
						break;
					}
					closure_0024__5 = new _Closure_0024__15._Closure_0024__16._Closure_0024__19(closure_0024__5);
					closure_0024__5._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_B8_1A = closure_0024__;
					if (Abort)
					{
						break;
					}
					string text = lvi1[closure_0024__._0024VB_0024Local_i].SubItems[1].Text;
					closure_0024__5._0024VB_0024Local_NewReference = lvi1[closure_0024__._0024VB_0024Local_i].SubItems[2].Text;
					if (File.Exists(closure_0024__5._0024VB_0024Local_NewReference) && string.Compare(text, closure_0024__5._0024VB_0024Local_NewReference, ignoreCase: true) != 0)
					{
						bool flag = false;
						int num8 = list.Count - 1;
						int num9 = 0;
						while (true)
						{
							int num10 = num9;
							num3 = num8;
							if (num10 > num3)
							{
								break;
							}
							if (File.Exists(list[num9]))
							{
								object swApp = code.swApp;
								object[] array = new object[3];
								List<string> list2 = list;
								int index = num9;
								array[0] = list2[index];
								array[1] = text;
								array[2] = closure_0024__5._0024VB_0024Local_NewReference;
								object[] array2 = array;
								bool[] array3 = new bool[3] { true, true, true };
								object value = NewLateBinding.LateGet(swApp, null, "ReplaceReferencedDocument", array2, null, null, array3);
								if (array3[0])
								{
									list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								}
								if (array3[1])
								{
									text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								}
								if (array3[2])
								{
									closure_0024__5._0024VB_0024Local_NewReference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[2]), typeof(string));
								}
								if (Conversions.ToBoolean(value))
								{
									flag = true;
									closure_0024__2._0024VB_0024Local_count++;
								}
							}
							num9++;
						}
						if (flag)
						{
							ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__5._Lambda_0024__30);
							if (code.SplitStr(closure_0024__5._0024VB_0024Local_NewReference).StartsWith(code.SplitStr(Conversions.ToString(ListView1.Tag))) && list.FindIndex(closure_0024__5._Lambda_0024__31) < 0)
							{
								list.Add(closure_0024__5._0024VB_0024Local_NewReference);
							}
							try
							{
								if (File.Exists(text))
								{
									if (MovetoRecycle.Checked)
									{
										MyProject.Computer.FileSystem.DeleteFile(text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
										MyProject.Computer.FileSystem.DeleteFile(code.SplitStr(text, 3) + ".slddrw", UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
									}
									else if (!UnMoveto.Checked && ToSpecificFolder.Checked)
									{
										SpecificFolder = Directory.CreateDirectory(Replacereference_SpecificFolder.Text).FullName;
										if (!SpecificFolder.EndsWith("\\"))
										{
											SpecificFolder += "\\";
										}
										File.Move(text, SpecificFolder + code.SplitStr(text, 4));
										File.Move(code.SplitStr(text, 3) + ".slddrw", SpecificFolder + code.SplitStr(text, 4));
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
						ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__5._Lambda_0024__32);
					}
					closure_0024__._0024VB_0024Local_i++;
				}
				ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__2._Lambda_0024__33);
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

	public void loadview(List<string> f)
	{
		List<string> list = new List<string>();
		ListViewVR listView = ListView2;
		checked
		{
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
				list.Add(listView.Items[num2].SubItems[2].Text);
				num2++;
			}
			listView = null;
			int num5 = f.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				if (!list.Contains(f[num6]))
				{
					list.Add(f[num6]);
				}
				num6++;
			}
			if (list.Count == 0)
			{
				return;
			}
			List<ListViewItem> list2 = new List<ListViewItem>();
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
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems[0].Text = Conversions.ToString(num9 + 1);
				listViewItem.SubItems.Add(code.SplitStr(list[num9], 4));
				listViewItem.SubItems.Add(list[num9]);
				listViewItem.SubItems.Add("");
				list2.Add(listViewItem);
				num9++;
			}
			ListView2.AddData(list2);
		}
	}

	private void addfiles_Click(object sender, EventArgs e)
	{
		addfiles.HideDropDown();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Сборка (*.SLDASM)|*.SLDASM";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		object fileNames = openFileDialog.FileNames;
		List<string> list = new List<string>();
		int num = Information.LBound((Array)fileNames);
		int num2 = Information.UBound((Array)fileNames);
		int num3 = num;
		while (true)
		{
			int num4 = num3;
			int num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			list.Add(Conversions.ToString(NewLateBinding.LateIndexGet(fileNames, new object[1] { num3 }, null)));
			num3 = checked(num3 + 1);
		}
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
			if (ListView2.Items.Count > 0)
			{
				ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView2.Items.Count) + " файлов";
			}
			else
			{
				ToolStripStatusLabel1.Text = "";
			}
		}
	}

	private void addfilesformfolder_Click(object sender, EventArgs e)
	{
		string text = "";
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			text = fileBorser.DirectoryPath;
		}
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		string pattern = "|*.SLDASM";
		List<string> list = new List<string>();
		if (Operators.ConditionalCompareObjectEqual(((ToolStripMenuItem)sender).Tag, "true", TextCompare: false))
		{
			code.SearchFiles(list, text, pattern);
		}
		else
		{
			code.SearchFiles(list, text, pattern, @bool: false);
		}
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
			if (ListView2.Items.Count > 0)
			{
				ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView2.Items.Count) + " файлов";
			}
			else
			{
				ToolStripStatusLabel1.Text = "";
			}
		}
	}

	private void addactiveasmformSW_Click(object sender, EventArgs e)
	{
		try
		{
			if (!code.RunSW())
			{
				return;
			}
			List<string> list = new List<string>();
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "activedoc", new object[0], null, null, null));
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				return;
			}
			string text = NewLateBinding.LateGet(objectValue, null, "Getpathname", new object[0], null, null, null).ToString();
			if (text.EndsWith(".SLDASM", StringComparison.CurrentCultureIgnoreCase))
			{
				list.Add(text);
			}
			if (list.Count != 0)
			{
				loadview(list);
				if (ListView2.Items.Count > 0)
				{
					ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView2.Items.Count) + " файлов";
				}
				else
				{
					ToolStripStatusLabel1.Text = "";
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

	private void addasmformSW_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		List<string> list = new List<string>();
		object objectValue;
		for (objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null)); objectValue != null; objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null)))
		{
			string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
			if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				list.Add(text);
			}
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (list.Count == 0)
		{
			Interaction.MsgBox("Нет открытых документов", MsgBoxStyle.Information, "Информация");
			return;
		}
		loadview(list);
		if (ListView2.Items.Count > 0)
		{
			ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView2.Items.Count) + " файлов";
		}
		else
		{
			ToolStripStatusLabel1.Text = "";
		}
		objectValue = null;
	}

	private void ListView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		try
		{
			selrow = ListView2.SelectedIndices[0];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
			return;
		}
		checked
		{
			int num = ListView2.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (ListView2.Items[num2].Selected)
				{
					ListView2.Items[num2].Selected = false;
					ListView2.Items[num2].BackColor = SystemColors.MenuHighlight;
				}
				else
				{
					ListView2.Items[num2].BackColor = SystemColors.Window;
				}
				num2++;
			}
			try
			{
				string text = ListView2.Items[selrow].SubItems[2].Text;
				if (!File.Exists(text))
				{
					ListView2.DelSpecificItems(selrow);
					return;
				}
				if (CConfigMng.Config.Previewfortool)
				{
					MyProject.Forms.FrmPreview.ChangePre = false;
					code.Preview2(Conversions.ToBoolean(Interaction.IIf(string.Equals(code.SplitStr(text, 5), ".slddrw", StringComparison.CurrentCultureIgnoreCase), true, false)), text, "", this);
				}
				if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ListView1.Tag, text, TextCompare: false))))
				{
					ListView1.Tag = text;
					Refreshview();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ListView2_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			string text = ListView2.Items[selrow].SubItems[2].Text;
			if (!File.Exists(text))
			{
				ListView2.DelSpecificItems(selrow);
				return;
			}
			if (CConfigMng.Config.Previewfortool)
			{
				MyProject.Forms.FrmPreview.ChangePre = false;
				code.Preview2(Conversions.ToBoolean(Interaction.IIf(string.Equals(code.SplitStr(text, 5), ".slddrw", StringComparison.CurrentCultureIgnoreCase), true, false)), text, "", this);
			}
			if (string.Compare(Conversions.ToString(ListView1.Tag), text, ignoreCase: true) != 0)
			{
				ListView1.Tag = text;
				Refreshview();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void clearall_Click(object sender, EventArgs e)
	{
		if (ListView2.Items.Count != 0 && Interaction.MsgBox("Точно очистить список?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "Вопрос") == MsgBoxResult.Ok)
		{
			ListView2.DelAllItems();
			ToolStripStatusLabel1.Text = "";
		}
	}

	private void clearsel_Click(object sender, EventArgs e)
	{
		ListView2.DelSpecificItems(selrow);
		if (ListView2.Items.Count > 0)
		{
			ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView2.Items.Count) + " файлов";
		}
		else
		{
			ToolStripStatusLabel1.Text = "";
		}
	}

	private void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
		if (!File.Exists(Conversions.ToString(ListView1.Tag)))
		{
			ListView2.DelSpecificItems(selrow);
		}
		else
		{
			Refreshview();
		}
	}

	private void RadioButton4_CheckedChanged(object sender, EventArgs e)
	{
		if (!File.Exists(Conversions.ToString(ListView1.Tag)))
		{
			ListView2.DelSpecificItems(selrow);
		}
		else
		{
			Refreshview();
		}
	}

	private void Refreshview()
	{
		if (File.Exists(Conversions.ToString(ListView1.Tag)))
		{
			if (Strings.Len(Replacereference_folderpath.Text) == 0)
			{
				MessageBox.Show(this, "Сначала укажите путь ссылок", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (!Directory.Exists(Replacereference_folderpath.Text))
			{
				MessageBox.Show(this, "Ссылочный путь " + Replacereference_folderpath.Text + " не существует, задайте заново", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			ToolStripStatusLabel1.Text = "Загрузка данных, подождите...";
			code.T.Restart();
			f.Clear();
			getfileformsw();
			lookup();
			code.T.Stop();
			ToolStripStatusLabel1.Text = "Загрузка завершена, затрачено " + Strings.FormatNumber((double)code.T.ElapsedMilliseconds / 1000.0, 1) + " с";
		}
	}

	public void getfileformsw()
	{
		if (!code.RunSW())
		{
			return;
		}
		if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(code.swApp, null, "GetDocumentCount", new object[0], null, null, null), 0, TextCompare: false) && MessageBox.Show(this, "Закройте все открытые в SolidWorks файлы во избежание ошибок чтения!\n\nЗакрыть все открытые в SolidWorks файлы автоматически?", "Особое предупреждение!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
		{
			NewLateBinding.LateCall(code.swApp, null, "CloseAllDocuments", new object[1] { true }, null, null, null, IgnoreReturn: true);
		}
		lvi1.Clear();
		ListView1.Refreshview();
		ListView1.Controls.Clear();
		row = 0;
		object swApp = code.swApp;
		object[] array = new object[4];
		object[] array2 = array;
		ListViewVR listView = ListView1;
		array2[0] = RuntimeHelpers.GetObjectValue(listView.Tag);
		object[] array3 = array;
		RadioButton radioButton = RadioButton2;
		array3[1] = radioButton.Checked;
		object[] array4 = array;
		RadioButton radioButton2 = RadioButton4;
		array4[2] = radioButton2.Checked;
		array[3] = false;
		object[] array5 = array;
		object[] arguments = array5;
		bool[] array6 = new bool[4] { true, true, true, false };
		object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array6);
		if (array6[0])
		{
			listView.Tag = RuntimeHelpers.GetObjectValue(array5[0]);
		}
		if (array6[1])
		{
			radioButton.Checked = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array5[1]), typeof(bool));
		}
		if (array6[2])
		{
			radioButton2.Checked = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array5[2]), typeof(bool));
		}
		object objectValue = RuntimeHelpers.GetObjectValue(obj);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return;
		}
		int num = Information.UBound((Array)objectValue);
		int num2 = 0;
		checked
		{
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string text = NewLateBinding.LateIndexGet(objectValue, new object[1] { num2 + 1 }, null).ToString();
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems[0].Text = Conversions.ToString(row + 1);
				listViewItem.SubItems.Add(text);
				listViewItem.SubItems.Add("");
				listViewItem.SubItems.Add("");
				listViewItem.SubItems.Add("");
				if (!File.Exists(text))
				{
					listViewItem.SubItems[1].ForeColor = Color.DarkGray;
					listViewItem.UseItemStyleForSubItems = false;
				}
				if (text.EndsWith(".sldasm", StringComparison.CurrentCultureIgnoreCase))
				{
					listViewItem.ImageIndex = 0;
				}
				else if (text.EndsWith(".sldprt", StringComparison.CurrentCultureIgnoreCase))
				{
					listViewItem.ImageIndex = 1;
				}
				lvi1.Add(listViewItem);
				row++;
				num2 += 2;
			}
			ListView1.AddData(lvi1);
		}
	}

	public void lookup()
	{
		if (f.Count < 1)
		{
			code.SearchFiles(f, Replacereference_folderpath.Text, "*.SLDPRT|*.SLDASM", Containssubfolders.Checked);
		}
		if (f.Count < 1 || ListView1.Items.Count < 1)
		{
			return;
		}
		checked
		{
			int num = lvi1.Count - 1;
			int num2 = 0;
			_Closure_0024__20 closure_0024__ = default(_Closure_0024__20);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__20(closure_0024__);
				lvi1[num2].SubItems[2].Text = "";
				lvi1[num2].SubItems[3].Text = "";
				lvi1[num2].SubItems[4].Text = "";
				closure_0024__._0024VB_0024Local_fullname = lvi1[num2].SubItems[1].Text;
				closure_0024__._0024VB_0024Local_name = code.SplitStr(closure_0024__._0024VB_0024Local_fullname, 4);
				List<string> list = f.FindAll(closure_0024__._Lambda_0024__34);
				if (list.Count >= 1)
				{
					lvi1[num2].SubItems[2].Text = list[0];
					if (list.Count > 1)
					{
						lvi1[num2].SubItems[3].Text = "Есть " + Conversions.ToString(list.Count) + " файлов с тем же именем";
						lvi1[num2].SubItems[3].ForeColor = Color.Blue;
						lvi1[num2].UseItemStyleForSubItems = false;
					}
				}
				num2++;
			}
			ListView1.Refreshview();
		}
	}

	private void openinsw_Click(object sender, EventArgs e)
	{
		try
		{
			string text = ListView2.Items[selrow].SubItems[2].Text;
			if (File.Exists(text))
			{
				Thread thread = new Thread(_Lambda_0024__35);
				thread.Start(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void openinfolder_Click(object sender, EventArgs e)
	{
		try
		{
			string text = ListView2.Items[selrow].SubItems[2].Text;
			if (File.Exists(text))
			{
				Interaction.Shell("explorer.exe /select," + text, AppWinStyle.NormalFocus);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Replacereference_folderpath_btn_Click(object sender, EventArgs e)
	{
		string strB = Replacereference_folderpath.Text;
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			Replacereference_folderpath.Text = fileBorser.DirectoryPath;
			if (string.Compare(Replacereference_folderpath.Text, strB, ignoreCase: true) != 0)
			{
				f.Clear();
				Refreshview();
			}
		}
	}

	private void Containssubfolders_CheckedChanged(object sender, EventArgs e)
	{
		if (Directory.Exists(Replacereference_folderpath.Text))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Replacereference_folderpath.Text);
			if (directoryInfo.GetDirectories().Length > 0)
			{
				f.Clear();
				Refreshview();
			}
		}
	}

	private void Replacereference_SpecificFolder_btn_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			Replacereference_SpecificFolder.Text = fileBorser.DirectoryPath;
		}
	}

	private void MovetoRecycle_CheckedChanged(object sender, EventArgs e)
	{
		if (sender.Equals(MovetoRecycle) | sender.Equals(UnMoveto))
		{
			Replacereference_SpecificFolder.Enabled = false;
		}
		else
		{
			Replacereference_SpecificFolder.Enabled = true;
		}
	}

	public void cmb_Click(object sender, MouseEventArgs e)
	{
		Point mousePosition = Control.MousePosition;
		setdownlist();
		csmp1.Show(mousePosition);
	}

	public void setdownlist()
	{
		csmp1.Items.Clear();
		csmp1.AutoSize = true;
		checked
		{
			if (curcol == 1)
			{
				csmp1.Items.Add(Conversions.ToString(NewLateBinding.LateIndexGet(arr, new object[1] { 0 }, null)), Resources.SW_32px);
				csmp1.Items.Add(Conversions.ToString(NewLateBinding.LateIndexGet(arr, new object[1] { 1 }, null)), Resources.Folder_24px);
			}
			else
			{
				if (curcol != 2)
				{
					return;
				}
				_Closure_0024__21 closure_0024__ = new _Closure_0024__21();
				csmp1.Items.Add(Conversions.ToString(NewLateBinding.LateIndexGet(arr, new object[1] { 0 }, null)), Resources.SW_32px);
				csmp1.Items.Add(Conversions.ToString(NewLateBinding.LateIndexGet(arr, new object[1] { 1 }, null)), Resources.Folder_24px);
				csmp1.Items.Add(Conversions.ToString(NewLateBinding.LateIndexGet(arr, new object[1] { 2 }, null)), Resources.clear);
				csmp1.Items.Add(Conversions.ToString(NewLateBinding.LateIndexGet(arr, new object[1] { 3 }, null)), Resources.write);
				closure_0024__._0024VB_0024Local_fullname = lvi1[currow].SubItems[1].Text;
				closure_0024__._0024VB_0024Local_name = code.SplitStr(closure_0024__._0024VB_0024Local_fullname, 4);
				List<string> list = f.FindAll(closure_0024__._Lambda_0024__36);
				if (list.Count <= 0)
				{
					return;
				}
				csmp1.Items.Add(new ToolStripSeparator());
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						csmp1.Items.Add(list[num2]);
						num2++;
						continue;
					}
					break;
				}
			}
		}
	}

	private void csmp1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		try
		{
			if (Operators.ConditionalCompareObjectEqual(e.ClickedItem.Text, NewLateBinding.LateIndexGet(arr, new object[1] { 0 }, null), TextCompare: false))
			{
				string text = ListView1.Items[currow].SubItems[curcol].Text;
				if (File.Exists(text))
				{
					Thread thread = new Thread(_Lambda_0024__37);
					thread.Start(text);
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(e.ClickedItem.Text, NewLateBinding.LateIndexGet(arr, new object[1] { 1 }, null), TextCompare: false))
			{
				string text2 = ListView1.Items[currow].SubItems[curcol].Text;
				if (File.Exists(text2))
				{
					Interaction.Shell("explorer.exe /select," + text2, AppWinStyle.NormalFocus);
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(e.ClickedItem.Text, NewLateBinding.LateIndexGet(arr, new object[1] { 2 }, null), TextCompare: false))
			{
				ListView1.Items[currow].SubItems[curcol].Text = "";
				ListView1.Refreshview();
			}
			else if (Operators.ConditionalCompareObjectEqual(e.ClickedItem.Text, NewLateBinding.LateIndexGet(arr, new object[1] { 3 }, null), TextCompare: false))
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = false;
				openFileDialog.SupportMultiDottedExtensions = true;
				openFileDialog.Filter = "Деталь (*.SLDPRT)|*.SLDPRT|Сборка (*.SLDASM)|*.SLDASM";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					ListView1.Items[currow].SubItems[curcol].Text = openFileDialog.FileName;
					ListView1.Refreshview();
				}
			}
			else
			{
				ListView1.Items[currow].SubItems[curcol].Text = e.ClickedItem.Text;
				ListView1.Refreshview();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void ListView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
	{
		ListView1.Controls.Clear();
	}

	private void ListView1_Resize(object sender, EventArgs e)
	{
		ListView1.Controls.Clear();
	}

	private void ListView1_MouseDown(object sender, MouseEventArgs e)
	{
		ListViewItem listViewItem = (ListViewItem)ListView1.GetItemAt(e.X, e.Y);
		if (!Information.IsNothing(listViewItem))
		{
			currow = listViewItem.Index;
			curcol = listViewItem.SubItems.IndexOf(listViewItem.GetSubItemAt(e.X, e.Y));
		}
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		checked
		{
			try
			{
				ListView1.Controls.Clear();
				currow = ListView1.SelectedIndices[0];
				ListViewItem listViewItem = (ListViewItem)ListView1.Items[currow];
				Point location = listViewItem.SubItems[curcol].Bounds.Location;
				Size size = listViewItem.SubItems[curcol].Bounds.Size;
				CustomComboBox1 customComboBox = new CustomComboBox1();
				customComboBox.Click += _Lambda_0024__38;
				customComboBox.Height = size.Height;
				customComboBox.Width = customComboBox.Height;
				Point location2 = new Point(location.X + size.Width - customComboBox.Width, location.Y);
				customComboBox.Location = location2;
				int num = ListView1.Items.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					ListView1.Items[num2].SubItems[1].BackColor = SystemColors.Window;
					ListView1.Items[num2].SubItems[2].BackColor = SystemColors.Window;
					ListView1.Items[num2].Selected = false;
					num2++;
				}
				if ((curcol == 1) | (curcol == 2))
				{
					ListView1.Controls.Add(customComboBox);
					ListView1.Items[currow].UseItemStyleForSubItems = false;
					ListView1.Items[currow].SubItems[curcol].BackColor = SystemColors.Highlight;
				}
				string text = ListView1.Items[currow].SubItems[curcol].Text;
				if (CConfigMng.Config.Previewfortool)
				{
					MyProject.Forms.FrmPreview.ChangePre = false;
					code.Preview2(Conversions.ToBoolean(Interaction.IIf(string.Equals(code.SplitStr(text, 5), ".slddrw", StringComparison.CurrentCultureIgnoreCase), true, false)), text, "", this);
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

	private void Savecfg()
	{
		CConfigMng.Config.Replacereferencecfg.Clear();
		foreach (Control control in Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + Conversions.ToString((control as CheckBox).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + (control as TextBox).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + Conversions.ToString((control as ComboBox).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + Conversions.ToString((control as RadioButton).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + Conversions.ToString((control as CheckBox).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + (control as TextBox).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + Conversions.ToString((control as ComboBox).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.Replacereferencecfg.Add(control.Name + "\n" + Conversions.ToString((control as RadioButton).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		checked
		{
			foreach (Control control in Controls)
			{
				int num = CConfigMng.Config.Replacereferencecfg.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string[] array = Strings.Split(CConfigMng.Config.Replacereferencecfg[num2], "\n");
					if (array.Count() == 2 && Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
					{
						if (control is CheckBox)
						{
							(control as CheckBox).Checked = code.Cbool1(array[1]);
						}
						else if (control is TextBox)
						{
							(control as TextBox).Text = array[1];
						}
						else if (control is ComboBox)
						{
							(control as ComboBox).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						}
						else if (control is RadioButton)
						{
							(control as RadioButton).Checked = code.Cbool1(array[1]);
						}
					}
					num2++;
				}
				if (control.HasChildren)
				{
					FindctlToLoad(control);
				}
			}
		}
	}

	private void FindctlToLoad(Control parent)
	{
		checked
		{
			foreach (Control control in parent.Controls)
			{
				int num = CConfigMng.Config.Replacereferencecfg.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string[] array = Strings.Split(CConfigMng.Config.Replacereferencecfg[num2], "\n");
					if (array.Count() == 2 && Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
					{
						if (control is CheckBox)
						{
							(control as CheckBox).Checked = code.Cbool1(array[1]);
						}
						else if (control is TextBox)
						{
							(control as TextBox).Text = array[1].ToString();
						}
						else if (control is ComboBox)
						{
							(control as ComboBox).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						}
						else if (control is RadioButton)
						{
							(control as RadioButton).Checked = code.Cbool1(array[1]);
						}
					}
					num2++;
				}
				if (control.HasChildren)
				{
					FindctlToLoad(control);
				}
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__27()
	{
		ToolStripStatusLabel1.Text = "Замена ссылок...";
		ToolStripProgressBar1.Value = 0;
		ToolStripProgressBar1.Maximum = lvi1.Count;
		ToolStripProgressBar1.Visible = true;
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private static void _Lambda_0024__35(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private static void _Lambda_0024__37(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private void _Lambda_0024__38(object a0, EventArgs a1)
	{
		cmb_Click(RuntimeHelpers.GetObjectValue(a0), (MouseEventArgs)a1);
	}
}
