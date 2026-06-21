using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmOutputlist : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__10
	{
		public string[] _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__10(_Closure_0024__10 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__10()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__16(string s)
		{
			return s.Equals(_0024VB_0024Local_str[0], StringComparison.CurrentCultureIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("addfiles")]
	private ToolStripSplitButton _addfiles;

	[AccessedThroughProperty("addfilesformfolder1")]
	private ToolStripMenuItem _addfilesformfolder1;

	[AccessedThroughProperty("adddrawformSW")]
	private ToolStripMenuItem _adddrawformSW;

	[AccessedThroughProperty("addprtformSW")]
	private ToolStripMenuItem _addprtformSW;

	[AccessedThroughProperty("addallformSW")]
	private ToolStripMenuItem _addallformSW;

	[AccessedThroughProperty("addselformSW")]
	private ToolStripMenuItem _addselformSW;

	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator _ToolStripSeparator2;

	[AccessedThroughProperty("clearsel")]
	private ToolStripButton _clearsel;

	[AccessedThroughProperty("clearall")]
	private ToolStripButton _clearall;

	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator _ToolStripSeparator1;

	[AccessedThroughProperty("nextstep")]
	private ToolStripButton _nextstep;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("ToolStripStatusLabel1")]
	private ToolStripStatusLabel _ToolStripStatusLabel1;

	[AccessedThroughProperty("ToolStripProgressBar1")]
	private ToolStripProgressBar _ToolStripProgressBar1;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("adddrawformPrt")]
	private ToolStripMenuItem _adddrawformPrt;

	[AccessedThroughProperty("adddrwformsel")]
	private ToolStripMenuItem _adddrwformsel;

	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("AddFromMain")]
	private ToolStripMenuItem _AddFromMain;

	[AccessedThroughProperty("ListView1")]
	private ListViewVR _ListView1;

	[AccessedThroughProperty("csmp2")]
	private ContextMenuStrip _csmp2;

	[AccessedThroughProperty("openinsw")]
	private ToolStripMenuItem _openinsw;

	[AccessedThroughProperty("openinfolder")]
	private ToolStripMenuItem _openinfolder;

	[AccessedThroughProperty("adddrwformactive")]
	private ToolStripMenuItem _adddrwformactive;

	[AccessedThroughProperty("addprtfromcurasm")]
	private ToolStripMenuItem _addprtfromcurasm;

	[AccessedThroughProperty("adddrwfromprtincurasm")]
	private ToolStripMenuItem _adddrwfromprtincurasm;

	[AccessedThroughProperty("ToolStripSeparator5")]
	private ToolStripSeparator _ToolStripSeparator5;

	[AccessedThroughProperty("ToolStripSeparator6")]
	private ToolStripSeparator _ToolStripSeparator6;

	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator _ToolStripSeparator3;

	[AccessedThroughProperty("addprtanddrwfromprtincurasm")]
	private ToolStripMenuItem _addprtanddrwfromprtincurasm;

	[AccessedThroughProperty("ToolStripSeparator4")]
	private ToolStripSeparator _ToolStripSeparator4;

	[AccessedThroughProperty("addprtfromspeasm")]
	private ToolStripMenuItem _addprtfromspeasm;

	[AccessedThroughProperty("adddrwfromprtinspeasm")]
	private ToolStripMenuItem _adddrwfromprtinspeasm;

	[AccessedThroughProperty("addprtanddrwfromprtinspeasm")]
	private ToolStripMenuItem _addprtanddrwfromprtinspeasm;

	[AccessedThroughProperty("ToolStripSeparator7")]
	private ToolStripSeparator _ToolStripSeparator7;

	[AccessedThroughProperty("addprtanddrwformsel")]
	private ToolStripMenuItem _addprtanddrwformsel;

	[AccessedThroughProperty("ToolStripSeparator8")]
	private ToolStripSeparator _ToolStripSeparator8;

	[AccessedThroughProperty("addprtfromcurasm2")]
	private ToolStripMenuItem _addprtfromcurasm2;

	[AccessedThroughProperty("addprtfromspeasm2")]
	private ToolStripMenuItem _addprtfromspeasm2;

	[AccessedThroughProperty("copyitem")]
	private ToolStripButton _copyitem;

	[AccessedThroughProperty("pasteitem")]
	private ToolStripButton _pasteitem;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	private double dpixRatio;

	private int selrow;

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

	internal virtual ToolStripMenuItem adddrawformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrawformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrawformSW_Click;
			if (_adddrawformSW != null)
			{
				_adddrawformSW.Click -= value2;
			}
			_adddrawformSW = value;
			if (_adddrawformSW != null)
			{
				_adddrawformSW.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addprtformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtformSW_Click;
			if (_addprtformSW != null)
			{
				_addprtformSW.Click -= value2;
			}
			_addprtformSW = value;
			if (_addprtformSW != null)
			{
				_addprtformSW.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addallformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _addallformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addallformSW_Click;
			if (_addallformSW != null)
			{
				_addallformSW.Click -= value2;
			}
			_addallformSW = value;
			if (_addallformSW != null)
			{
				_addallformSW.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addselformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _addselformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addselformSW_Click;
			if (_addselformSW != null)
			{
				_addselformSW.Click -= value2;
			}
			_addselformSW = value;
			if (_addselformSW != null)
			{
				_addselformSW.Click += value2;
			}
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

	internal virtual ToolStripButton clearsel
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

	internal virtual ToolStripButton clearall
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

	internal virtual ToolStripButton nextstep
	{
		[DebuggerNonUserCode]
		get
		{
			return _nextstep;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = nextstep_Click;
			if (_nextstep != null)
			{
				_nextstep.Click -= value2;
			}
			_nextstep = value;
			if (_nextstep != null)
			{
				_nextstep.Click += value2;
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

	internal virtual ToolStripMenuItem adddrawformPrt
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrawformPrt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrawformPrt_Click;
			if (_adddrawformPrt != null)
			{
				_adddrawformPrt.Click -= value2;
			}
			_adddrawformPrt = value;
			if (_adddrawformPrt != null)
			{
				_adddrawformPrt.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem adddrwformsel
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrwformsel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrwformsel_Click;
			if (_adddrwformsel != null)
			{
				_adddrwformsel.Click -= value2;
			}
			_adddrwformsel = value;
			if (_adddrwformsel != null)
			{
				_adddrwformsel.Click += value2;
			}
		}
	}

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
			EventHandler value2 = ToolStripButton1_Click;
			if (_ToolStripButton1 != null)
			{
				_ToolStripButton1.Click -= value2;
			}
			_ToolStripButton1 = value;
			if (_ToolStripButton1 != null)
			{
				_ToolStripButton1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddFromMain
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddFromMain;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddFromMain_Click;
			if (_AddFromMain != null)
			{
				_AddFromMain.Click -= value2;
			}
			_AddFromMain = value;
			if (_AddFromMain != null)
			{
				_AddFromMain.Click += value2;
			}
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
			DragEventHandler value2 = ListView1_DragEnter;
			ListViewItemSelectionChangedEventHandler value3 = ListView1_ItemSelectionChanged;
			DragEventHandler value4 = ListView1_DragDrop;
			if (_ListView1 != null)
			{
				_ListView1.DragEnter -= value2;
				_ListView1.ItemSelectionChanged -= value3;
				_ListView1.DragDrop -= value4;
			}
			_ListView1 = value;
			if (_ListView1 != null)
			{
				_ListView1.DragEnter += value2;
				_ListView1.ItemSelectionChanged += value3;
				_ListView1.DragDrop += value4;
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

	internal virtual ToolStripMenuItem adddrwformactive
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrwformactive;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrwformactive_Click;
			if (_adddrwformactive != null)
			{
				_adddrwformactive.Click -= value2;
			}
			_adddrwformactive = value;
			if (_adddrwformactive != null)
			{
				_adddrwformactive.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addprtfromcurasm
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtfromcurasm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtfromcurasm_Click;
			if (_addprtfromcurasm != null)
			{
				_addprtfromcurasm.Click -= value2;
			}
			_addprtfromcurasm = value;
			if (_addprtfromcurasm != null)
			{
				_addprtfromcurasm.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem adddrwfromprtincurasm
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrwfromprtincurasm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrwfromprtincurasm_Click;
			if (_adddrwfromprtincurasm != null)
			{
				_adddrwfromprtincurasm.Click -= value2;
			}
			_adddrwfromprtincurasm = value;
			if (_adddrwfromprtincurasm != null)
			{
				_adddrwfromprtincurasm.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator5
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator5 = value;
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator6
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator6 = value;
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

	internal virtual ToolStripMenuItem addprtanddrwfromprtincurasm
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtanddrwfromprtincurasm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtanddrwfromprtincurasm_Click;
			if (_addprtanddrwfromprtincurasm != null)
			{
				_addprtanddrwfromprtincurasm.Click -= value2;
			}
			_addprtanddrwfromprtincurasm = value;
			if (_addprtanddrwfromprtincurasm != null)
			{
				_addprtanddrwfromprtincurasm.Click += value2;
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

	internal virtual ToolStripMenuItem addprtfromspeasm
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtfromspeasm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtfromspeasm_Click;
			if (_addprtfromspeasm != null)
			{
				_addprtfromspeasm.Click -= value2;
			}
			_addprtfromspeasm = value;
			if (_addprtfromspeasm != null)
			{
				_addprtfromspeasm.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem adddrwfromprtinspeasm
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrwfromprtinspeasm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrwfromprtinspeasm_Click;
			if (_adddrwfromprtinspeasm != null)
			{
				_adddrwfromprtinspeasm.Click -= value2;
			}
			_adddrwfromprtinspeasm = value;
			if (_adddrwfromprtinspeasm != null)
			{
				_adddrwfromprtinspeasm.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addprtanddrwfromprtinspeasm
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtanddrwfromprtinspeasm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtanddrwfromprtinspeasm_Click;
			if (_addprtanddrwfromprtinspeasm != null)
			{
				_addprtanddrwfromprtinspeasm.Click -= value2;
			}
			_addprtanddrwfromprtinspeasm = value;
			if (_addprtanddrwfromprtinspeasm != null)
			{
				_addprtanddrwfromprtinspeasm.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator7
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator7 = value;
		}
	}

	internal virtual ToolStripMenuItem addprtanddrwformsel
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtanddrwformsel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtanddrwformsel_Click;
			if (_addprtanddrwformsel != null)
			{
				_addprtanddrwformsel.Click -= value2;
			}
			_addprtanddrwformsel = value;
			if (_addprtanddrwformsel != null)
			{
				_addprtanddrwformsel.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator8
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator8 = value;
		}
	}

	internal virtual ToolStripMenuItem addprtfromcurasm2
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtfromcurasm2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtfromcurasm2_Click;
			if (_addprtfromcurasm2 != null)
			{
				_addprtfromcurasm2.Click -= value2;
			}
			_addprtfromcurasm2 = value;
			if (_addprtfromcurasm2 != null)
			{
				_addprtfromcurasm2.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addprtfromspeasm2
	{
		[DebuggerNonUserCode]
		get
		{
			return _addprtfromspeasm2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addprtfromspeasm2_Click;
			if (_addprtfromspeasm2 != null)
			{
				_addprtfromspeasm2.Click -= value2;
			}
			_addprtfromspeasm2 = value;
			if (_addprtfromspeasm2 != null)
			{
				_addprtfromspeasm2.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton copyitem
	{
		[DebuggerNonUserCode]
		get
		{
			return _copyitem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = copyitem_Click;
			if (_copyitem != null)
			{
				_copyitem.Click -= value2;
			}
			_copyitem = value;
			if (_copyitem != null)
			{
				_copyitem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton pasteitem
	{
		[DebuggerNonUserCode]
		get
		{
			return _pasteitem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = pasteitem_Click;
			if (_pasteitem != null)
			{
				_pasteitem.Click -= value2;
			}
			_pasteitem = value;
			if (_pasteitem != null)
			{
				_pasteitem.Click += value2;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.FrmOutputlist));
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.addfiles = new System.Windows.Forms.ToolStripSplitButton();
		this.addfilesformfolder1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this.AddFromMain = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		this.adddrawformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrawformPrt = new System.Windows.Forms.ToolStripMenuItem();
		this.addprtformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.addallformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.addselformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrwformsel = new System.Windows.Forms.ToolStripMenuItem();
		this.addprtanddrwformsel = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
		this.addprtfromcurasm = new System.Windows.Forms.ToolStripMenuItem();
		this.addprtfromcurasm2 = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrwfromprtincurasm = new System.Windows.Forms.ToolStripMenuItem();
		this.addprtanddrwfromprtincurasm = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.addprtfromspeasm = new System.Windows.Forms.ToolStripMenuItem();
		this.addprtfromspeasm2 = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrwfromprtinspeasm = new System.Windows.Forms.ToolStripMenuItem();
		this.addprtanddrwfromprtinspeasm = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
		this.adddrwformactive = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.clearsel = new System.Windows.Forms.ToolStripButton();
		this.clearall = new System.Windows.Forms.ToolStripButton();
		this.copyitem = new System.Windows.Forms.ToolStripButton();
		this.pasteitem = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.nextstep = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ListView1 = new ZTool.ListViewVR();
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.openinfolder = new System.Windows.Forms.ToolStripMenuItem();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.ToolStrip1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.csmp2.SuspendLayout();
		this.SuspendLayout();
		this.ToolStrip1.AutoSize = false;
		this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.addfiles, this.ToolStripSeparator2, this.clearsel, this.clearall, this.copyitem, this.pasteitem, this.ToolStripSeparator1, this.nextstep, this.ToolStripButton1 });
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(2, 2, 2, 5);
		toolStrip2.Padding = padding;
		this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		System.Windows.Forms.ToolStrip toolStrip3 = this.ToolStrip1;
		System.Drawing.Size size = new System.Drawing.Size(684, 40);
		toolStrip3.Size = size;
		this.ToolStrip1.TabIndex = 13;
		this.ToolStrip1.Text = "ToolStrip1";
		this.addfiles.DropDownButtonWidth = 20;
		this.addfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[24]
		{
			this.addfilesformfolder1, this.ToolStripSeparator5, this.AddFromMain, this.ToolStripSeparator6, this.adddrawformSW, this.adddrawformPrt, this.addprtformSW, this.addallformSW, this.ToolStripSeparator3, this.addselformSW,
			this.adddrwformsel, this.addprtanddrwformsel, this.ToolStripSeparator8, this.addprtfromcurasm, this.addprtfromcurasm2, this.adddrwfromprtincurasm, this.addprtanddrwfromprtincurasm, this.ToolStripSeparator4, this.addprtfromspeasm, this.addprtfromspeasm2,
			this.adddrwfromprtinspeasm, this.addprtanddrwfromprtinspeasm, this.ToolStripSeparator7, this.adddrwformactive
		});
		this.addfiles.Image = ZTool.My.Resources.Resources.slddialogresu_291;
		this.addfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripSplitButton toolStripSplitButton = this.addfiles;
		padding = new System.Windows.Forms.Padding(10, 1, 2, 2);
		toolStripSplitButton.Margin = padding;
		this.addfiles.Name = "addfiles";
		System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2 = this.addfiles;
		size = new System.Drawing.Size(97, 30);
		toolStripSplitButton2.Size = size;
		this.addfiles.Text = "Добавить файл";
		this.addfilesformfolder1.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.addfilesformfolder1.Name = "addfilesformfolder1";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.addfilesformfolder1;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem.Size = size;
		this.addfilesformfolder1.Tag = "false";
		this.addfilesformfolder1.Text = "Добавить папку";
		this.ToolStripSeparator5.Name = "ToolStripSeparator5";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator = this.ToolStripSeparator5;
		size = new System.Drawing.Size(289, 6);
		toolStripSeparator.Size = size;
		this.AddFromMain.Image = ZTool.My.Resources.Resources.arrow_16px;
		this.AddFromMain.Name = "AddFromMain";
		System.Windows.Forms.ToolStripMenuItem addFromMain = this.AddFromMain;
		size = new System.Drawing.Size(292, 22);
		addFromMain.Size = size;
		this.AddFromMain.Text = "Загрузить данные главного окна";
		this.ToolStripSeparator6.Name = "ToolStripSeparator6";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator2 = this.ToolStripSeparator6;
		size = new System.Drawing.Size(289, 6);
		toolStripSeparator2.Size = size;
		this.adddrawformSW.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrawformSW.Name = "adddrawformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.adddrawformSW;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem2.Size = size;
		this.adddrawformSW.Text = "Загрузить открытые в SolidWorks чертежи";
		this.adddrawformPrt.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrawformPrt.Name = "adddrawformPrt";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.adddrawformPrt;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem3.Size = size;
		this.adddrawformPrt.Text = "Загрузить чертежи открытых в SolidWorks деталей";
		this.addprtformSW.Image = ZTool.My.Resources.Resources.sldprt;
		this.addprtformSW.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.addprtformSW.Name = "addprtformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4 = this.addprtformSW;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem4.Size = size;
		this.addprtformSW.Text = "Загрузить открытые в SolidWorks детали";
		this.addallformSW.Image = ZTool.My.Resources.Resources.slddialogresu_291;
		this.addallformSW.Name = "addallformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5 = this.addallformSW;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem5.Size = size;
		this.addallformSW.Text = "Загрузить все открытые в SolidWorks файлы";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = this.ToolStripSeparator3;
		size = new System.Drawing.Size(289, 6);
		toolStripSeparator3.Size = size;
		this.addselformSW.Image = ZTool.My.Resources.Resources.sldasm;
		this.addselformSW.Name = "addselformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6 = this.addselformSW;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem6.Size = size;
		this.addselformSW.Text = "Загрузить выбранные элементы текущей сборки";
		this.adddrwformsel.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrwformsel.Name = "adddrwformsel";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7 = this.adddrwformsel;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem7.Size = size;
		this.adddrwformsel.Text = "Загрузить чертежи выбранных элементов текущей сборки";
		this.addprtanddrwformsel.Name = "addprtanddrwformsel";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8 = this.addprtanddrwformsel;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem8.Size = size;
		this.addprtanddrwformsel.Text = "Загрузить выбранные элементы текущей сборки и их чертежи";
		this.ToolStripSeparator8.Name = "ToolStripSeparator8";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = this.ToolStripSeparator8;
		size = new System.Drawing.Size(289, 6);
		toolStripSeparator4.Size = size;
		this.addprtfromcurasm.Image = ZTool.My.Resources.Resources.sldprt;
		this.addprtfromcurasm.Name = "addprtfromcurasm";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9 = this.addprtfromcurasm;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem9.Size = size;
		this.addprtfromcurasm.Text = "Загрузить все детали текущей сборки";
		this.addprtfromcurasm2.Image = ZTool.My.Resources.Resources.sldprt;
		this.addprtfromcurasm2.Name = "addprtfromcurasm2";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10 = this.addprtfromcurasm2;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem10.Size = size;
		this.addprtfromcurasm2.Text = "Загрузить детали текущей сборки, имеющие чертежи";
		this.adddrwfromprtincurasm.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrwfromprtincurasm.Name = "adddrwfromprtincurasm";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11 = this.adddrwfromprtincurasm;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem11.Size = size;
		this.adddrwfromprtincurasm.Text = "Загрузить чертежи всех деталей текущей сборки";
		this.addprtanddrwfromprtincurasm.Image = ZTool.My.Resources.Resources.prtanddrw_x24;
		this.addprtanddrwfromprtincurasm.Name = "addprtanddrwfromprtincurasm";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12 = this.addprtanddrwfromprtincurasm;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem12.Size = size;
		this.addprtanddrwfromprtincurasm.Text = "Загрузить все детали текущей сборки и их чертежи";
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator5 = this.ToolStripSeparator4;
		size = new System.Drawing.Size(289, 6);
		toolStripSeparator5.Size = size;
		this.addprtfromspeasm.Image = ZTool.My.Resources.Resources.sldprt;
		this.addprtfromspeasm.Name = "addprtfromspeasm";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13 = this.addprtfromspeasm;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem13.Size = size;
		this.addprtfromspeasm.Text = "Загрузить все детали указанной сборки";
		this.addprtfromspeasm2.Image = ZTool.My.Resources.Resources.sldprt;
		this.addprtfromspeasm2.Name = "addprtfromspeasm2";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14 = this.addprtfromspeasm2;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem14.Size = size;
		this.addprtfromspeasm2.Text = "Загрузить детали указанной сборки, имеющие чертежи";
		this.adddrwfromprtinspeasm.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrwfromprtinspeasm.Name = "adddrwfromprtinspeasm";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15 = this.adddrwfromprtinspeasm;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem15.Size = size;
		this.adddrwfromprtinspeasm.Text = "Загрузить чертежи всех деталей указанной сборки";
		this.addprtanddrwfromprtinspeasm.Image = ZTool.My.Resources.Resources.prtanddrw_x24;
		this.addprtanddrwfromprtinspeasm.Name = "addprtanddrwfromprtinspeasm";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16 = this.addprtanddrwfromprtinspeasm;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem16.Size = size;
		this.addprtanddrwfromprtinspeasm.Text = "Загрузить все детали указанной сборки и их чертежи";
		this.ToolStripSeparator7.Name = "ToolStripSeparator7";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator6 = this.ToolStripSeparator7;
		size = new System.Drawing.Size(289, 6);
		toolStripSeparator6.Size = size;
		this.adddrwformactive.Name = "adddrwformactive";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17 = this.adddrwformactive;
		size = new System.Drawing.Size(292, 22);
		toolStripMenuItem17.Size = size;
		this.adddrwformactive.Text = "Загрузить текущий элемент SolidWorks и его чертёж";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator7 = this.ToolStripSeparator2;
		padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		toolStripSeparator7.Margin = padding;
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator8 = this.ToolStripSeparator2;
		size = new System.Drawing.Size(6, 33);
		toolStripSeparator8.Size = size;
		this.clearsel.Image = ZTool.My.Resources.Resources.delsel;
		this.clearsel.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton = this.clearsel;
		padding = new System.Windows.Forms.Padding(5, 1, 0, 2);
		toolStripButton.Margin = padding;
		this.clearsel.Name = "clearsel";
		System.Windows.Forms.ToolStripButton toolStripButton2 = this.clearsel;
		size = new System.Drawing.Size(76, 30);
		toolStripButton2.Size = size;
		this.clearsel.Text = "Удалить выбранное";
		this.clearall.Image = ZTool.My.Resources.Resources.del;
		this.clearall.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.clearall.Name = "clearall";
		System.Windows.Forms.ToolStripButton toolStripButton3 = this.clearall;
		size = new System.Drawing.Size(52, 30);
		toolStripButton3.Size = size;
		this.clearall.Text = "Очистить";
		this.copyitem.Image = ZTool.My.Resources.Resources.copy_32;
		this.copyitem.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.copyitem.Name = "copyitem";
		System.Windows.Forms.ToolStripButton toolStripButton4 = this.copyitem;
		size = new System.Drawing.Size(76, 30);
		toolStripButton4.Size = size;
		this.copyitem.Text = "Копировать таблицу";
		this.pasteitem.Image = ZTool.My.Resources.Resources.Paste_32;
		this.pasteitem.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.pasteitem.Name = "pasteitem";
		System.Windows.Forms.ToolStripButton toolStripButton5 = this.pasteitem;
		size = new System.Drawing.Size(52, 30);
		toolStripButton5.Size = size;
		this.pasteitem.Text = "Вставить";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator9 = this.ToolStripSeparator1;
		padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		toolStripSeparator9.Margin = padding;
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator10 = this.ToolStripSeparator1;
		size = new System.Drawing.Size(6, 33);
		toolStripSeparator10.Size = size;
		this.nextstep.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.nextstep.Image = ZTool.My.Resources.Resources.Start_24x;
		this.nextstep.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton6 = this.nextstep;
		padding = new System.Windows.Forms.Padding(0, 1, 20, 2);
		toolStripButton6.Margin = padding;
		this.nextstep.Name = "nextstep";
		System.Windows.Forms.ToolStripButton toolStripButton7 = this.nextstep;
		size = new System.Drawing.Size(64, 30);
		toolStripButton7.Size = size;
		this.nextstep.Text = "Далее";
		this.ToolStripButton1.Image = ZTool.My.Resources.Resources.Folder_24px;
		this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton1.Name = "ToolStripButton1";
		System.Windows.Forms.ToolStripButton toolStripButton8 = this.ToolStripButton1;
		size = new System.Drawing.Size(148, 30);
		toolStripButton8.Size = size;
		this.ToolStripButton1.Text = "Открыть последнюю папку конвертации";
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ToolStripStatusLabel1, this.ToolStripProgressBar1 });
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		location = new System.Drawing.Point(0, 429);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(684, 22);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 14;
		this.StatusStrip1.Text = "StatusStrip1";
		this.ToolStripStatusLabel1.AutoSize = false;
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel = this.ToolStripStatusLabel1;
		size = new System.Drawing.Size(134, 17);
		toolStripStatusLabel.Size = size;
		this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
		System.Windows.Forms.ToolStripProgressBar toolStripProgressBar = this.ToolStripProgressBar1;
		size = new System.Drawing.Size(300, 16);
		toolStripProgressBar.Size = size;
		this.GroupBox1.Controls.Add(this.ListView1);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(0, 40);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		padding = new System.Windows.Forms.Padding(12, 6, 12, 12);
		groupBox2.Padding = padding;
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		size = new System.Drawing.Size(684, 389);
		groupBox3.Size = size;
		this.GroupBox1.TabIndex = 15;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Список файлов (можно перетаскивать файлы или папки прямо в список)";
		this.ListView1.AllowDrop = true;
		this.ListView1.ContextMenuStrip = this.csmp2;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		this.ListView1.LargeImageList = this.ImageList1;
		ZTool.ListViewVR listView = this.ListView1;
		location = new System.Drawing.Point(12, 22);
		listView.Location = location;
		this.ListView1.Name = "ListView1";
		ZTool.ListViewVR listView2 = this.ListView1;
		size = new System.Drawing.Size(660, 355);
		listView2.Size = size;
		this.ListView1.TabIndex = 0;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.VirtualMode = true;
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openinsw, this.openinfolder });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp2;
		size = new System.Drawing.Size(188, 48);
		contextMenuStrip.Size = size;
		this.openinsw.Image = ZTool.My.Resources.Resources.SW_32px;
		this.openinsw.Name = "openinsw";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18 = this.openinsw;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem18.Size = size;
		this.openinsw.Text = "Открыть в SolidWorks";
		this.openinfolder.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.openinfolder.Name = "openinfolder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19 = this.openinfolder;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem19.Size = size;
		this.openinfolder.Text = "Открыть в папке";
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "sldasm.png");
		this.ImageList1.Images.SetKeyName(1, "sldprt.png");
		this.AllowDrop = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(684, 451);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.ToolStrip1);
		this.Controls.Add(this.StatusStrip1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Icon = ZTool.My.Resources.Resources.ztool_11;
		size = new System.Drawing.Size(700, 490);
		this.MinimumSize = size;
		this.Name = "FrmOutputlist";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Tag = " Пакетное преобразование формата";
		this.Text = " Пакетное преобразование формата";
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.csmp2.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmOutputlist()
	{
		base.FormClosed += FrmOutputlist_FormClosed;
		base.Load += FrmOutputlist_Load;
		__ENCAddToList(this);
		dpixRatio = 1.0;
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
	}

	private void FrmOutputlist_FormClosed(object sender, FormClosedEventArgs e)
	{
		Switch(0);
		List<string> list = new List<string>();
		ListViewVR listView = ListView1;
		checked
		{
			if (listView.Items.Count > 0)
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
					list.Add(listView.Items[num2].SubItems[2].Text + "\n" + listView.Items[num2].SubItems[3].Text);
					logopathlist.WriteLog(listView.Items[num2].SubItems[2].Text + "\n" + listView.Items[num2].SubItems[3].Text, logopathlist.LastRecord1);
					num2++;
				}
			}
			listView = null;
			MyProject.Forms.FrmOutputoptions.OutBgWorker.Dispose();
			Dispose();
			MyProject.Forms.FrmOutputoptions.Dispose();
			if (Application.OpenForms.Count == 0)
			{
				Application.Exit();
			}
		}
	}

	private void FrmOutputlist_Load(object sender, EventArgs e)
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
		MyProject.Forms.Frmmain.sendhwndtosw();
		Icon = Resources.ico_dwg;
		ListView1.View = View.Details;
		ListView1.AllowDrop = true;
		ListView1.GridLines = true;
		ListView1.MultiSelect = true;
		ListView1.Clear();
		ListView1.Items.Clear();
		checked
		{
			int num = (int)Math.Round(50.0 * dpixRatio);
			int num2 = (int)Math.Round(250.0 * dpixRatio);
			int num3 = (int)Math.Round(200.0 * dpixRatio);
			int num4 = (int)Math.Round(80.0 * dpixRatio);
			int num5 = (int)Math.Round(50.0 * dpixRatio);
			ListView1.Columns.Add("Номер", num, HorizontalAlignment.Left);
			ListView1.Columns.Add("Имя файла", num2, HorizontalAlignment.Left);
			ListView1.Columns.Add("Путь", num3, HorizontalAlignment.Left);
			ListView1.Columns.Add("Конфигурация детали", num4, HorizontalAlignment.Left);
			ListView1.Columns.Add("Статус", num5, HorizontalAlignment.Left);
			ToolStripProgressBar1.Visible = false;
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
		}
	}

	private void addfiles_MouseMove(object sender, MouseEventArgs e)
	{
		addfiles.ShowDropDown();
	}

	public void loadview(List<string> f)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		int num = 0;
		ListViewVR listView = ListView1;
		checked
		{
			int num2 = listView.Items.Count - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				list.Add(listView.Items[num3].SubItems[2].Text);
				list2.Add(listView.Items[num3].SubItems[3].Text);
				list3.Add(listView.Items[num3].SubItems[4].Text);
				num3++;
			}
			listView = null;
			int num6 = f.Count - 1;
			int num7 = 0;
			_Closure_0024__10 closure_0024__ = default(_Closure_0024__10);
			while (true)
			{
				int num8 = num7;
				int num5 = num6;
				if (num8 > num5)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__10(closure_0024__);
				closure_0024__._0024VB_0024Local_str = Strings.Split(f[num7], "\n");
				int num9 = list.FindIndex(closure_0024__._Lambda_0024__16);
				if (closure_0024__._0024VB_0024Local_str.Count() == 2)
				{
					if (num9 >= 0)
					{
						list2[num9] = Conversions.ToString(Interaction.IIf(Operators.CompareString(list2[num9], "", TextCompare: false) == 0, "", list2[num9] + "|\n" + closure_0024__._0024VB_0024Local_str[1]));
						HashSet<string> values = new HashSet<string>(Strings.Split(list2[num9], "|\n").ToList());
						list2[num9] = string.Join("|\n", values);
					}
					else
					{
						list.Add(closure_0024__._0024VB_0024Local_str[0]);
						list2.Add(closure_0024__._0024VB_0024Local_str[1]);
						list3.Add("");
					}
				}
				else if (closure_0024__._0024VB_0024Local_str.Count() == 1)
				{
					if (num9 >= 0)
					{
						list2[num9] = "";
					}
					else
					{
						list.Add(closure_0024__._0024VB_0024Local_str[0]);
						list2.Add("");
						list3.Add("");
					}
				}
				num7++;
			}
			if (list.Count == 0)
			{
				return;
			}
			List<ListViewItem> list4 = new List<ListViewItem>();
			int num10 = list.Count - 1;
			int num11 = 0;
			while (true)
			{
				int num12 = num11;
				int num5 = num10;
				if (num12 > num5)
				{
					break;
				}
				num++;
				if ((code.TMode && num > 10) ? true : false)
				{
					MessageBox.Show(this, "Пробная версия поддерживает не более 10 файлов", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.ImageIndex = 0;
				listViewItem.Checked = true;
				listViewItem.SubItems[0].Text = Conversions.ToString(num11 + 1);
				listViewItem.SubItems.Add(code.SplitStr(list[num11], 4));
				listViewItem.SubItems.Add(list[num11]);
				listViewItem.SubItems.Add(list2[num11]);
				listViewItem.SubItems.Add(list3[num11]);
				list4.Add(listViewItem);
				num11++;
			}
			ListView1.AddData(list4);
			if (ListView1.Items.Count > 0)
			{
				ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView1.Items.Count) + " файлов";
			}
			else
			{
				ToolStripStatusLabel1.Text = "";
			}
		}
	}

	private void copyitem_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		ListViewVR listView = ListView1;
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
				list.Add(listView.Items[num2].SubItems[2].Text + "\n" + listView.Items[num2].SubItems[3].Text);
				num2++;
			}
			listView = null;
			if (list.Count > 0)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, list);
				Clipboard.SetData(DataFormats.Serializable, memoryStream);
				Clipboard.SetAudio(memoryStream);
				MessageBox.Show("Успешно скопировано " + Conversions.ToString(list.Count) + " поз.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private void pasteitem_Click(object sender, EventArgs e)
	{
		if (!Clipboard.ContainsAudio())
		{
			return;
		}
		MemoryStream serializationStream = Clipboard.GetAudioStream() as MemoryStream;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		List<string> list = binaryFormatter.Deserialize(serializationStream) as List<string>;
		if (list.Count <= 0)
		{
			return;
		}
		List<string> list2 = new List<string>();
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
				string[] array = list[num2].Split('\n');
				string text = "";
				if (array.Count() == 2)
				{
					text = array[1];
				}
				if (File.Exists(array[0]) && ((array[0].EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase) || array[0].EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase) || array[0].EndsWith(".slddrw", StringComparison.OrdinalIgnoreCase)) ? true : false))
				{
					list2.Add(array[0] + "\n" + text);
				}
				num2++;
			}
			if (list2.Count > 0)
			{
				loadview(list2);
			}
		}
	}

	private void addfiles_Click(object sender, EventArgs e)
	{
		addfiles.HideDropDown();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Чертёж (*.SLDDRW)|*.SLDDRW|Деталь (*.SLDPRT)|*.SLDPRT|Сборка (*.SLDASM)|*.SLDASM|Файлы SOLIDWORKS (*.SLDPRT;*.SLDASM;*.SLDDRW)|*.SLDPRT;*.SLDASM;*.SLDDRW";
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
		}
	}

	private void adddrawformSW_Click(object sender, EventArgs e)
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
			if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				list.Add(text);
			}
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (list.Count == 0)
		{
			Interaction.MsgBox("Чертёж не открыт", MsgBoxStyle.Information, "Информация");
			return;
		}
		loadview(list);
		objectValue = null;
	}

	private void adddrawformPrt_Click(object sender, EventArgs e)
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
			string text2 = code.SplitStr(text, 3) + ".SLDDRW";
			if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase) && File.Exists(text2))
			{
				list.Add(text2);
			}
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (list.Count == 0)
		{
			Interaction.MsgBox("Чертёж не найден", MsgBoxStyle.Information, "Информация");
			return;
		}
		loadview(list);
		objectValue = null;
	}

	private void addprtformSW_Click(object sender, EventArgs e)
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
			if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
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
		objectValue = null;
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
		MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Visible = true;
		MyProject.Forms.FrmSelType2.Includesubfolders.Visible = true;
		if (MyProject.Forms.FrmSelType2.ShowDialog() != DialogResult.Cancel)
		{
			string text2 = "";
			bool flag = false;
			bool flag2 = false;
			if (MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Checked)
			{
				text2 += "|*.SLDDRW";
			}
			if (MyProject.Forms.FrmSelType2.TYPE_SLDPRT.Checked)
			{
				text2 += "|*.SLDPRT";
			}
			if (MyProject.Forms.FrmSelType2.TYPE_SLDASM.Checked)
			{
				text2 += "|*.SLDASM";
			}
			flag = MyProject.Forms.FrmSelType2.Includesubfolders.Checked;
			flag2 = MyProject.Forms.FrmSelType2.Onlyhasdrw.Checked;
			List<string> list = new List<string>();
			code.SearchFiles(list, text, flag2, text2, flag);
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
			}
		}
	}

	private void addallformSW_Click(object sender, EventArgs e)
	{
		if (code.RunSW())
		{
			List<string> list = new List<string>();
			object objectValue = RuntimeHelpers.GetObjectValue(new object());
			NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
			for (objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null)); objectValue != null; objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null)))
			{
				list.Add(Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null)));
			}
			NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
			if (list.Count == 0)
			{
				Interaction.MsgBox("Нет открытых документов", MsgBoxStyle.Information, "Информация");
				return;
			}
			loadview(list);
			objectValue = null;
		}
	}

	private void addselformSW_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "ActiveDoc", new object[0], null, null, null));
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return;
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		List<string> list = new List<string>();
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "SelectionManager", new object[0], null, null, null));
		int num = Conversions.ToInteger(NewLateBinding.LateGet(objectValue2, null, "GetSelectedObjectCount2", new object[1] { -1 }, null, null, null));
		int num2 = num;
		int num3 = 1;
		while (true)
		{
			int num4 = num3;
			int num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			object instance = objectValue2;
			object[] array = new object[2] { num3, -1 };
			object[] arguments = array;
			bool[] array2 = new bool[2] { true, false };
			object obj = NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", arguments, null, null, array2);
			if (array2[0])
			{
				num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
			}
			object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
			{
				string right = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "ReferencedConfiguration", new object[0], null, null, null));
				list.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(NewLateBinding.LateGet(objectValue3, null, "GetPathName", new object[0], null, null, null), "\n"), right)));
			}
			num3 = checked(num3 + 1);
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
			objectValue = null;
			objectValue2 = null;
		}
	}

	private void adddrwformsel_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "ActiveDoc", new object[0], null, null, null));
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return;
		}
		List<string> list = new List<string>();
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "SelectionManager", new object[0], null, null, null));
		int num = Conversions.ToInteger(NewLateBinding.LateGet(objectValue2, null, "GetSelectedObjectCount2", new object[1] { -1 }, null, null, null));
		int num2 = num;
		int num3 = 1;
		while (true)
		{
			int num4 = num3;
			int num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			object instance = objectValue2;
			object[] array = new object[2] { num3, -1 };
			object[] arguments = array;
			bool[] array2 = new bool[2] { true, false };
			object obj = NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", arguments, null, null, array2);
			if (array2[0])
			{
				num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
			}
			object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
			{
				string str = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "GetPathName", new object[0], null, null, null));
				string text = code.SplitStr(str, 3) + ".SLDDRW";
				string text2 = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "ReferencedConfiguration", new object[0], null, null, null));
				if (File.Exists(text))
				{
					list.Add(text + "\n" + text2);
				}
			}
			num3 = checked(num3 + 1);
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
			objectValue = null;
			objectValue2 = null;
		}
	}

	private void addprtanddrwformsel_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "ActiveDoc", new object[0], null, null, null));
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return;
		}
		List<string> list = new List<string>();
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "SelectionManager", new object[0], null, null, null));
		int num = Conversions.ToInteger(NewLateBinding.LateGet(objectValue2, null, "GetSelectedObjectCount2", new object[1] { -1 }, null, null, null));
		int num2 = num;
		int num3 = 1;
		while (true)
		{
			int num4 = num3;
			int num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			object instance = objectValue2;
			object[] array = new object[2] { num3, -1 };
			object[] arguments = array;
			bool[] array2 = new bool[2] { true, false };
			object obj = NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", arguments, null, null, array2);
			if (array2[0])
			{
				num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
			}
			object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
			{
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "GetPathName", new object[0], null, null, null));
				string text2 = code.SplitStr(text, 3) + ".SLDDRW";
				string text3 = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "ReferencedConfiguration", new object[0], null, null, null));
				list.Add(text + "\n" + text3);
				if (File.Exists(text2))
				{
					list.Add(text2 + "\n" + text3);
				}
			}
			num3 = checked(num3 + 1);
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
			objectValue = null;
			objectValue2 = null;
		}
	}

	private void ListView1_DragDrop(object sender, DragEventArgs e)
	{
		bool flag = false;
		string text = "";
		bool flag2 = false;
		bool onlyhasdrw = false;
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			return;
		}
		List<string> list = new List<string>();
		string[] array = null;
		array = (string[])e.Data.GetData(DataFormats.FileDrop);
		checked
		{
			int num = array.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if ((array[num2].EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase) || array[num2].EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase) || array[num2].EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					list.Add(array[num2]);
				}
				else if (Directory.Exists(array[num2]))
				{
					if (!flag)
					{
						MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Visible = true;
						MyProject.Forms.FrmSelType2.Includesubfolders.Visible = true;
						if (MyProject.Forms.FrmSelType2.ShowDialog() == DialogResult.Cancel)
						{
							goto IL_01c4;
						}
						if (MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Checked)
						{
							text += "|*.SLDDRW";
						}
						if (MyProject.Forms.FrmSelType2.TYPE_SLDPRT.Checked)
						{
							text += "|*.SLDPRT";
						}
						if (MyProject.Forms.FrmSelType2.TYPE_SLDASM.Checked)
						{
							text += "|*.SLDASM";
						}
						flag2 = MyProject.Forms.FrmSelType2.Includesubfolders.Checked;
						onlyhasdrw = MyProject.Forms.FrmSelType2.Onlyhasdrw.Checked;
					}
					code.SearchFiles(list, array[num2], onlyhasdrw, text, flag2);
					flag = true;
				}
				goto IL_01c4;
				IL_01c4:
				num2++;
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
			}
		}
	}

	private void ListView1_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.All;
		}
	}

	private void AddFromMain_Click(object sender, EventArgs e)
	{
		if (MyProject.Forms.Frmmain.DGV1.RowCount > 0)
		{
			addformMainform();
		}
	}

	private void addformMainform()
	{
		List<string> list = new List<string>();
		string text = "";
		string text2 = "";
		if (MyProject.Forms.FrmSelType.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		checked
		{
			int num = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				text2 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Cfg.Index, num2].Value);
				text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num2].Value);
				if (MyProject.Forms.Frmmain.DGV1.Rows[num2].Visible)
				{
					if (MyProject.Forms.FrmSelType.TYPE_SLDASM.Checked & text.EndsWith("SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						list.Add(text + "\n" + text2);
					}
					if (MyProject.Forms.FrmSelType.TYPE_SLDPRT.Checked & text.EndsWith("SLDPRT", StringComparison.OrdinalIgnoreCase))
					{
						list.Add(text + "\n" + text2);
					}
					if (File.Exists(code.SplitStr(text, 3) + ".SLDDRW") & MyProject.Forms.FrmSelType.TYPE_SLDDRW.Checked)
					{
						list.Add(code.SplitStr(text, 3) + ".SLDDRW\n" + text2);
					}
				}
				num2++;
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
			}
		}
	}

	private void nextstep_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(nextstep.Text, "Далее", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmOutputoptions.ShowDialog(this);
		}
		else
		{
			Switch(0);
		}
	}

	public void Switch(int @int)
	{
		MyProject.Forms.FrmOutputoptions.OutBgWorker.WorkerSupportsCancellation = true;
		switch (@int)
		{
		case 0:
			MyProject.Forms.FrmOutputoptions.OutBgWorker.CancelAsync();
			ToolStripStatusLabel1.Text = "Задача останавливается";
			break;
		case 1:
			nextstep.Text = "Стоп";
			nextstep.Image = Resources.Stop_24x;
			break;
		case 2:
			ToolStripStatusLabel1.Text = "Задача завершена";
			nextstep.Text = "Далее";
			nextstep.Image = Resources.Start_24x;
			break;
		case 3:
			ToolStripStatusLabel1.Text = "Задача остановлена";
			nextstep.Text = "Далее";
			nextstep.Image = Resources.Start_24x;
			break;
		case 4:
			ToolStripStatusLabel1.Text = "Задача остановлена";
			nextstep.Text = "Далее";
			nextstep.Image = Resources.Start_24x;
			MessageBox.Show(this, "Текущая задача прервана; нажмите «Далее» ➜ «Старт», чтобы продолжить", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			break;
		}
	}

	private void clearall_Click(object sender, EventArgs e)
	{
		if (ListView1.Items.Count != 0 && Interaction.MsgBox("Точно очистить список?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "Вопрос") == MsgBoxResult.Ok)
		{
			ListView1.DelAllItems();
			ToolStripStatusLabel1.Text = "";
		}
	}

	private void clearsel_Click(object sender, EventArgs e)
	{
		ListView1.DelSelectItems();
		if (ListView1.Items.Count > 0)
		{
			ToolStripStatusLabel1.Text = "Всего " + Conversions.ToString(ListView1.Items.Count) + " файлов";
		}
		else
		{
			ToolStripStatusLabel1.Text = "";
		}
	}

	private void ToolStrip1_Paint(object sender, PaintEventArgs e)
	{
		if (ToolStrip1.RenderMode == ToolStripRenderMode.System)
		{
			Rectangle clip = checked(new Rectangle(0, 0, ToolStrip1.Width - 8, ToolStrip1.Height - 8));
			e.Graphics.SetClip(clip);
		}
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		try
		{
			selrow = ListView1.SelectedIndices[0];
			string text = ListView1.Items[selrow].SubItems[2].Text;
			if (CConfigMng.Config.Previewfortool)
			{
				MyProject.Forms.FrmPreview.ChangePre = false;
				code.Preview2(Conversions.ToBoolean(Interaction.IIf(text.EndsWith(".slddrw", StringComparison.OrdinalIgnoreCase), true, false)), text, "", this);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void openinsw_Click(object sender, EventArgs e)
	{
		try
		{
			string text = ListView1.Items[selrow].SubItems[2].Text;
			if (File.Exists(text))
			{
				Thread thread = new Thread(_Lambda_0024__17);
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
			string text = ListView1.Items[selrow].SubItems[2].Text;
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

	private void ToolStripButton1_Click(object sender, EventArgs e)
	{
		if (!code.OpenFolderWithEX(CConfigMng.Config.OutSaveFolder))
		{
			MessageBox.Show(this, "Папка не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void addprtfromcurasm_Click(object sender, EventArgs e)
	{
		checked
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
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Getpathname", new object[0], null, null, null));
				if (!File.Exists(text))
				{
					return;
				}
				object swApp = code.swApp;
				object[] array = new object[4] { text, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue2);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text2 = NewLateBinding.LateIndexGet(objectValue2, new object[1] { num2 + 1 }, null).ToString();
					if (text2.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase) && File.Exists(text2))
					{
						list.Add(text2);
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void addprtfromcurasm2_Click(object sender, EventArgs e)
	{
		checked
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
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Getpathname", new object[0], null, null, null));
				if (!File.Exists(text))
				{
					return;
				}
				object swApp = code.swApp;
				object[] array = new object[4] { text, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue2);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text2 = NewLateBinding.LateIndexGet(objectValue2, new object[1] { num2 + 1 }, null).ToString();
					if (text2.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase) && ((File.Exists(text2) && File.Exists(code.SplitStr(text2, 3) + ".SLDDRW")) ? true : false))
					{
						list.Add(text2);
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void adddrwfromprtincurasm_Click(object sender, EventArgs e)
	{
		checked
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
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Getpathname", new object[0], null, null, null));
				if (!File.Exists(text))
				{
					return;
				}
				object swApp = code.swApp;
				object[] array = new object[4] { text, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue2);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text2 = NewLateBinding.LateIndexGet(objectValue2, new object[1] { num2 + 1 }, null).ToString();
					if (text2.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase))
					{
						string text3 = code.SplitStr(text2, 3) + ".SLDDRW";
						if (File.Exists(text3))
						{
							list.Add(text3);
						}
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void addprtanddrwfromprtincurasm_Click(object sender, EventArgs e)
	{
		checked
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
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Getpathname", new object[0], null, null, null));
				if (!File.Exists(text))
				{
					return;
				}
				object swApp = code.swApp;
				object[] array = new object[4] { text, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue2);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text2 = NewLateBinding.LateIndexGet(objectValue2, new object[1] { num2 + 1 }, null).ToString();
					if (text2.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase))
					{
						string text3 = code.SplitStr(text2, 3) + ".SLDDRW";
						if (File.Exists(text3))
						{
							list.Add(text3);
						}
						if (File.Exists(text2))
						{
							list.Add(text2);
						}
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void addprtfromspeasm_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				addfiles.HideDropDown();
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = false;
				openFileDialog.SupportMultiDottedExtensions = true;
				openFileDialog.Filter = "Сборка (*.SLDASM)|*.SLDASM";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				string fileName = openFileDialog.FileName;
				if (!File.Exists(fileName) || !code.RunSW())
				{
					return;
				}
				List<string> list = new List<string>();
				object swApp = code.swApp;
				object[] array = new object[4] { fileName, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					fileName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text = NewLateBinding.LateIndexGet(objectValue, new object[1] { num2 + 1 }, null).ToString();
					if (text.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase) && File.Exists(text))
					{
						list.Add(text);
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void addprtfromspeasm2_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				addfiles.HideDropDown();
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = false;
				openFileDialog.SupportMultiDottedExtensions = true;
				openFileDialog.Filter = "Сборка (*.SLDASM)|*.SLDASM";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				string fileName = openFileDialog.FileName;
				if (!File.Exists(fileName) || !code.RunSW())
				{
					return;
				}
				List<string> list = new List<string>();
				object swApp = code.swApp;
				object[] array = new object[4] { fileName, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					fileName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text = NewLateBinding.LateIndexGet(objectValue, new object[1] { num2 + 1 }, null).ToString();
					if (text.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase) && ((File.Exists(text) && File.Exists(code.SplitStr(text, 3) + ".SLDDRW")) ? true : false))
					{
						list.Add(text);
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void adddrwfromprtinspeasm_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				addfiles.HideDropDown();
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = false;
				openFileDialog.SupportMultiDottedExtensions = true;
				openFileDialog.Filter = "Сборка (*.SLDASM)|*.SLDASM";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				string fileName = openFileDialog.FileName;
				if (!File.Exists(fileName) || !code.RunSW())
				{
					return;
				}
				List<string> list = new List<string>();
				object swApp = code.swApp;
				object[] array = new object[4] { fileName, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					fileName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text = NewLateBinding.LateIndexGet(objectValue, new object[1] { num2 + 1 }, null).ToString();
					if (text.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase))
					{
						string text2 = code.SplitStr(text, 3) + ".SLDDRW";
						if (File.Exists(text2))
						{
							list.Add(text2);
						}
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void addprtanddrwfromprtinspeasm_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				addfiles.HideDropDown();
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = false;
				openFileDialog.SupportMultiDottedExtensions = true;
				openFileDialog.Filter = "Сборка (*.SLDASM)|*.SLDASM";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				string fileName = openFileDialog.FileName;
				if (!File.Exists(fileName) || !code.RunSW())
				{
					return;
				}
				List<string> list = new List<string>();
				object swApp = code.swApp;
				object[] array = new object[4] { fileName, true, true, false };
				object[] arguments = array;
				bool[] array2 = new bool[4] { true, false, false, false };
				object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
				if (array2[0])
				{
					fileName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return;
				}
				int num = Information.UBound((Array)objectValue);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text = NewLateBinding.LateIndexGet(objectValue, new object[1] { num2 + 1 }, null).ToString();
					if (text.EndsWith("sldprt", StringComparison.OrdinalIgnoreCase))
					{
						string text2 = code.SplitStr(text, 3) + ".SLDDRW";
						if (File.Exists(text2))
						{
							list.Add(text2);
						}
						if (File.Exists(text))
						{
							list.Add(text);
						}
					}
					num2 += 2;
				}
				if (list.Count != 0)
				{
					loadview(list);
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

	private void adddrwformactive_Click(object sender, EventArgs e)
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
			if (File.Exists(text))
			{
				list.Add(text);
			}
			if (text.EndsWith(".SLDPRT", StringComparison.CurrentCultureIgnoreCase) | text.EndsWith(".SLDASM", StringComparison.CurrentCultureIgnoreCase))
			{
				if (File.Exists(text))
				{
					list.Add(text);
				}
				string text2 = code.SplitStr(text, 3) + ".SLDDRW";
				if (File.Exists(text2))
				{
					list.Add(text2);
				}
			}
			if (list.Count != 0)
			{
				loadview(list);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private static void _Lambda_0024__17(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}
}
