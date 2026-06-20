using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmPrintoptions : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__14
	{
		public string _0024VB_0024Local_cfg;

		[DebuggerNonUserCode]
		public _Closure_0024__14(_Closure_0024__14 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_cfg = other._0024VB_0024Local_cfg;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__14()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__26(string s)
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

	[AccessedThroughProperty("Print_Printername")]
	private ComboBox _Print_Printername;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("Print_HighQuality")]
	private CheckBox _Print_HighQuality;

	[AccessedThroughProperty("Print_Scale")]
	private RadioButton _Print_Scale;

	[AccessedThroughProperty("Print_ScaleToFit")]
	private RadioButton _Print_ScaleToFit;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Print_ScaleNum")]
	private NumericUpDown _Print_ScaleNum;

	[AccessedThroughProperty("Print_BlackAndWhite")]
	private RadioButton _Print_BlackAndWhite;

	[AccessedThroughProperty("Print_Color")]
	private RadioButton _Print_Color;

	[AccessedThroughProperty("Print_AutoColor")]
	private RadioButton _Print_AutoColor;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("Print_PrintToFile")]
	private CheckBox _Print_PrintToFile;

	[AccessedThroughProperty("Print_PrintToFilePath")]
	private TextBox _Print_PrintToFilePath;

	[AccessedThroughProperty("Print_PrintToFileBow")]
	private Button _Print_PrintToFileBow;

	[AccessedThroughProperty("DGV1")]
	private DataGridView _DGV1;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("Print_AutoRotation")]
	private CheckBox _Print_AutoRotation;

	[AccessedThroughProperty("Column1")]
	private DataGridViewTextBoxColumn _Column1;

	[AccessedThroughProperty("Column2")]
	private DataGridViewComboBoxColumn _Column2;

	[AccessedThroughProperty("Column3")]
	private DataGridViewCheckBoxColumn _Column3;

	[AccessedThroughProperty("HideSw1")]
	private CheckBox _HideSw1;

	[AccessedThroughProperty("forcurcfg")]
	private CheckBox _forcurcfg;

	[AccessedThroughProperty("Print_PrintCopies")]
	private NumericUpDown _Print_PrintCopies;

	private string FilePathName;

	private string FileName;

	private string FilePath;

	private string SavePath;

	private int swFileTYpe;

	private bool CanPrint;

	private string PrintFileName;

	private bool boolstatus;

	private int longstatus;

	private int longwarnings;

	private bool isstop;

	private string scr;

	private string cop;

	[AccessedThroughProperty("PrintBgWorker")]
	private BackgroundWorker _PrintBgWorker;

	private bool CallInProgress;

	private bool er;

	private List<string> filelist;

	private List<string> statuslist;

	private List<bool> Checklist;

	private List<int> indexlist;

	private List<string> cfglist;

	private bool overwrite;

	private double dpixRatio;

	private Color mLinearColor1;

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

	internal virtual ComboBox Print_Printername
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_Printername;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_Printername = value;
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

	internal virtual CheckBox Print_HighQuality
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_HighQuality;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_HighQuality = value;
		}
	}

	internal virtual RadioButton Print_Scale
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_Scale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_Scale = value;
		}
	}

	internal virtual RadioButton Print_ScaleToFit
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_ScaleToFit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Print_ScaleToFit_CheckedChanged;
			if (_Print_ScaleToFit != null)
			{
				_Print_ScaleToFit.CheckedChanged -= value2;
			}
			_Print_ScaleToFit = value;
			if (_Print_ScaleToFit != null)
			{
				_Print_ScaleToFit.CheckedChanged += value2;
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

	internal virtual NumericUpDown Print_ScaleNum
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_ScaleNum;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_ScaleNum = value;
		}
	}

	internal virtual RadioButton Print_BlackAndWhite
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_BlackAndWhite;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_BlackAndWhite = value;
		}
	}

	internal virtual RadioButton Print_Color
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_Color;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_Color = value;
		}
	}

	internal virtual RadioButton Print_AutoColor
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_AutoColor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_AutoColor = value;
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

	internal virtual CheckBox Print_PrintToFile
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_PrintToFile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Print_PrintToFile_CheckedChanged;
			if (_Print_PrintToFile != null)
			{
				_Print_PrintToFile.CheckedChanged -= value2;
			}
			_Print_PrintToFile = value;
			if (_Print_PrintToFile != null)
			{
				_Print_PrintToFile.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox Print_PrintToFilePath
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_PrintToFilePath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_PrintToFilePath = value;
		}
	}

	internal virtual Button Print_PrintToFileBow
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_PrintToFileBow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Print_PrintToFileBow_Click;
			if (_Print_PrintToFileBow != null)
			{
				_Print_PrintToFileBow.Click -= value2;
			}
			_Print_PrintToFileBow = value;
			if (_Print_PrintToFileBow != null)
			{
				_Print_PrintToFileBow.Click += value2;
			}
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
			DataGridViewCellEventHandler value2 = DGV1_CellEnter;
			DataGridViewDataErrorEventHandler value3 = DGV1_DataError;
			DataGridViewCellPaintingEventHandler value4 = DGV1_CellPainting;
			if (_DGV1 != null)
			{
				_DGV1.CellEnter -= value2;
				_DGV1.DataError -= value3;
				_DGV1.CellPainting -= value4;
			}
			_DGV1 = value;
			if (_DGV1 != null)
			{
				_DGV1.CellEnter += value2;
				_DGV1.DataError += value3;
				_DGV1.CellPainting += value4;
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

	internal virtual CheckBox Print_AutoRotation
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_AutoRotation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_AutoRotation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Column1
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

	internal virtual DataGridViewComboBoxColumn Column2
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

	internal virtual DataGridViewCheckBoxColumn Column3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Column3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Column3 = value;
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

	internal virtual NumericUpDown Print_PrintCopies
	{
		[DebuggerNonUserCode]
		get
		{
			return _Print_PrintCopies;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Print_PrintCopies = value;
		}
	}

	public virtual BackgroundWorker PrintBgWorker
	{
		[DebuggerNonUserCode]
		get
		{
			return _PrintBgWorker;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DoWorkEventHandler value2 = PrintBgWorker_DoWork;
			RunWorkerCompletedEventHandler value3 = PrintBgWorker_RunWorkerCompleted;
			ProgressChangedEventHandler value4 = PrintBgWorker_ProgressChanged;
			if (_PrintBgWorker != null)
			{
				_PrintBgWorker.DoWork -= value2;
				_PrintBgWorker.RunWorkerCompleted -= value3;
				_PrintBgWorker.ProgressChanged -= value4;
			}
			_PrintBgWorker = value;
			if (_PrintBgWorker != null)
			{
				_PrintBgWorker.DoWork += value2;
				_PrintBgWorker.RunWorkerCompleted += value3;
				_PrintBgWorker.ProgressChanged += value4;
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.Print_Printername = new System.Windows.Forms.ComboBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Label5 = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Print_ScaleNum = new System.Windows.Forms.NumericUpDown();
		this.Print_HighQuality = new System.Windows.Forms.CheckBox();
		this.Print_Scale = new System.Windows.Forms.RadioButton();
		this.Print_ScaleToFit = new System.Windows.Forms.RadioButton();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.Print_BlackAndWhite = new System.Windows.Forms.RadioButton();
		this.Print_Color = new System.Windows.Forms.RadioButton();
		this.Print_AutoColor = new System.Windows.Forms.RadioButton();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.DGV1 = new System.Windows.Forms.DataGridView();
		this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.forcurcfg = new System.Windows.Forms.CheckBox();
		this.Print_AutoRotation = new System.Windows.Forms.CheckBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Print_PrintToFile = new System.Windows.Forms.CheckBox();
		this.Print_PrintToFilePath = new System.Windows.Forms.TextBox();
		this.Print_PrintToFileBow = new System.Windows.Forms.Button();
		this.HideSw1 = new System.Windows.Forms.CheckBox();
		this.Print_PrintCopies = new System.Windows.Forms.NumericUpDown();
		this.TableLayoutPanel1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Print_ScaleNum).BeginInit();
		this.GroupBox3.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Print_PrintCopies).BeginInit();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		this.TableLayoutPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(454, 277);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(181, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(11, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "开始";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(102, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.Print_Printername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Print_Printername.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Print_Printername.FormattingEnabled = true;
		System.Windows.Forms.ComboBox print_Printername = this.Print_Printername;
		location = new System.Drawing.Point(58, 28);
		print_Printername.Location = location;
		this.Print_Printername.Name = "Print_Printername";
		System.Windows.Forms.ComboBox print_Printername2 = this.Print_Printername;
		size = new System.Drawing.Size(251, 25);
		print_Printername2.Size = size;
		this.Print_Printername.TabIndex = 1;
		this.GroupBox1.Controls.Add(this.Button1);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.Print_Printername);
		this.GroupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(12, 10);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(382, 68);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 2;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Принтер";
		this.Button1.AutoSize = true;
		this.Button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(315, 27);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(42, 27);
		button2.Size = size;
		this.Button1.TabIndex = 2;
		this.Button1.Text = "Свойства";
		this.Button1.UseVisualStyleBackColor = true;
		this.Label5.AutoSize = true;
		System.Windows.Forms.Label label = this.Label5;
		location = new System.Drawing.Point(11, 32);
		label.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label2 = this.Label5;
		size = new System.Drawing.Size(44, 17);
		label2.Size = size;
		this.Label5.TabIndex = 3;
		this.Label5.Text = "Название:";
		this.GroupBox2.Controls.Add(this.Label2);
		this.GroupBox2.Controls.Add(this.Print_ScaleNum);
		this.GroupBox2.Controls.Add(this.Print_HighQuality);
		this.GroupBox2.Controls.Add(this.Print_Scale);
		this.GroupBox2.Controls.Add(this.Print_ScaleToFit);
		this.GroupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(12, 179);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(216, 89);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 3;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Разрешение и масштаб";
		this.Label2.AutoSize = true;
		this.Label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(130, 52);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(21, 20);
		label4.Size = size;
		this.Label2.TabIndex = 3;
		this.Label2.Text = "%";
		System.Windows.Forms.NumericUpDown print_ScaleNum = this.Print_ScaleNum;
		location = new System.Drawing.Point(80, 51);
		print_ScaleNum.Location = location;
		System.Windows.Forms.NumericUpDown print_ScaleNum2 = this.Print_ScaleNum;
		decimal maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		print_ScaleNum2.Maximum = maximum;
		maximum = (this.Print_ScaleNum.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.Print_ScaleNum.Name = "Print_ScaleNum";
		System.Windows.Forms.NumericUpDown print_ScaleNum3 = this.Print_ScaleNum;
		size = new System.Drawing.Size(44, 23);
		print_ScaleNum3.Size = size;
		this.Print_ScaleNum.TabIndex = 2;
		maximum = (this.Print_ScaleNum.Value = new decimal(new int[4] { 100, 0, 0, 0 }));
		this.Print_HighQuality.AutoSize = true;
		System.Windows.Forms.CheckBox print_HighQuality = this.Print_HighQuality;
		location = new System.Drawing.Point(147, 22);
		print_HighQuality.Location = location;
		this.Print_HighQuality.Name = "Print_HighQuality";
		System.Windows.Forms.CheckBox print_HighQuality2 = this.Print_HighQuality;
		size = new System.Drawing.Size(63, 21);
		print_HighQuality2.Size = size;
		this.Print_HighQuality.TabIndex = 1;
		this.Print_HighQuality.Text = "Высокое качество";
		this.Print_HighQuality.UseVisualStyleBackColor = true;
		this.Print_Scale.AutoSize = true;
		System.Windows.Forms.RadioButton print_Scale = this.Print_Scale;
		location = new System.Drawing.Point(17, 52);
		print_Scale.Location = location;
		this.Print_Scale.Name = "Print_Scale";
		System.Windows.Forms.RadioButton print_Scale2 = this.Print_Scale;
		size = new System.Drawing.Size(62, 21);
		print_Scale2.Size = size;
		this.Print_Scale.TabIndex = 0;
		this.Print_Scale.Text = "Масштаб:";
		this.Print_Scale.UseVisualStyleBackColor = true;
		this.Print_ScaleToFit.AutoSize = true;
		this.Print_ScaleToFit.Checked = true;
		System.Windows.Forms.RadioButton print_ScaleToFit = this.Print_ScaleToFit;
		location = new System.Drawing.Point(17, 22);
		print_ScaleToFit.Location = location;
		this.Print_ScaleToFit.Name = "Print_ScaleToFit";
		System.Windows.Forms.RadioButton print_ScaleToFit2 = this.Print_ScaleToFit;
		size = new System.Drawing.Size(110, 21);
		print_ScaleToFit2.Size = size;
		this.Print_ScaleToFit.TabIndex = 0;
		this.Print_ScaleToFit.TabStop = true;
		this.Print_ScaleToFit.Text = "Подогнать масштаб по размеру";
		this.Print_ScaleToFit.UseVisualStyleBackColor = true;
		this.GroupBox3.Controls.Add(this.Print_BlackAndWhite);
		this.GroupBox3.Controls.Add(this.Print_Color);
		this.GroupBox3.Controls.Add(this.Print_AutoColor);
		this.GroupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox3;
		location = new System.Drawing.Point(240, 179);
		groupBox5.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox3;
		size = new System.Drawing.Size(154, 89);
		groupBox6.Size = size;
		this.GroupBox3.TabIndex = 4;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Цвет чертежа";
		this.Print_BlackAndWhite.AutoSize = true;
		this.Print_BlackAndWhite.Checked = true;
		System.Windows.Forms.RadioButton print_BlackAndWhite = this.Print_BlackAndWhite;
		location = new System.Drawing.Point(22, 66);
		print_BlackAndWhite.Location = location;
		this.Print_BlackAndWhite.Name = "Print_BlackAndWhite";
		System.Windows.Forms.RadioButton print_BlackAndWhite2 = this.Print_BlackAndWhite;
		size = new System.Drawing.Size(50, 21);
		print_BlackAndWhite2.Size = size;
		this.Print_BlackAndWhite.TabIndex = 0;
		this.Print_BlackAndWhite.TabStop = true;
		this.Print_BlackAndWhite.Text = "Чёрно-белый";
		this.Print_BlackAndWhite.UseVisualStyleBackColor = true;
		this.Print_Color.AutoSize = true;
		System.Windows.Forms.RadioButton print_Color = this.Print_Color;
		location = new System.Drawing.Point(22, 42);
		print_Color.Location = location;
		this.Print_Color.Name = "Print_Color";
		System.Windows.Forms.RadioButton print_Color2 = this.Print_Color;
		size = new System.Drawing.Size(91, 21);
		print_Color2.Size = size;
		this.Print_Color.TabIndex = 0;
		this.Print_Color.Text = "Цвет/оттенки серого";
		this.Print_Color.UseVisualStyleBackColor = true;
		this.Print_AutoColor.AutoSize = true;
		System.Windows.Forms.RadioButton print_AutoColor = this.Print_AutoColor;
		location = new System.Drawing.Point(22, 20);
		print_AutoColor.Location = location;
		this.Print_AutoColor.Name = "Print_AutoColor";
		System.Windows.Forms.RadioButton print_AutoColor2 = this.Print_AutoColor;
		size = new System.Drawing.Size(50, 21);
		print_AutoColor2.Size = size;
		this.Print_AutoColor.TabIndex = 0;
		this.Print_AutoColor.Text = "Авто";
		this.Print_AutoColor.UseVisualStyleBackColor = true;
		this.GroupBox4.Controls.Add(this.DGV1);
		this.GroupBox4.Controls.Add(this.forcurcfg);
		this.GroupBox4.Controls.Add(this.Print_AutoRotation);
		this.GroupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox4;
		location = new System.Drawing.Point(404, 9);
		groupBox7.Location = location;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox4;
		size = new System.Drawing.Size(231, 259);
		groupBox8.Size = size;
		this.GroupBox4.TabIndex = 5;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Настройка бумаги и диапазон печати";
		this.DGV1.AllowUserToAddRows = false;
		this.DGV1.AllowUserToDeleteRows = false;
		this.DGV1.AllowUserToResizeColumns = false;
		this.DGV1.AllowUserToResizeRows = false;
		this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.DGV1.BackgroundColor = System.Drawing.SystemColors.Control;
		this.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DGV1.Columns.AddRange(this.Column1, this.Column2, this.Column3);
		System.Windows.Forms.DataGridView dGV = this.DGV1;
		location = new System.Drawing.Point(10, 22);
		dGV.Location = location;
		this.DGV1.MultiSelect = false;
		this.DGV1.Name = "DGV1";
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.DGV1.RowHeadersVisible = false;
		this.DGV1.RowTemplate.Height = 23;
		System.Windows.Forms.DataGridView dGV2 = this.DGV1;
		size = new System.Drawing.Size(211, 174);
		dGV2.Size = size;
		this.DGV1.TabIndex = 0;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
		this.Column1.HeaderText = "Размер листа";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column1.Width = 65;
		this.Column2.FillWeight = 50f;
		this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.Column2.HeaderText = "Размер бумаги печати";
		this.Column2.Items.AddRange("A4", "A3", "A2", "A1", "A0");
		this.Column2.Name = "Column2";
		this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Column2.Width = 90;
		this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column3.FillWeight = 50f;
		this.Column3.HeaderText = "Печатать только";
		this.Column3.Name = "Column3";
		this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.forcurcfg.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox = this.forcurcfg;
		location = new System.Drawing.Point(10, 230);
		checkBox.Location = location;
		this.forcurcfg.Name = "forcurcfg";
		System.Windows.Forms.CheckBox checkBox2 = this.forcurcfg;
		size = new System.Drawing.Size(87, 21);
		checkBox2.Size = size;
		this.forcurcfg.TabIndex = 1;
		this.forcurcfg.Text = "Печать по конфигурации";
		this.forcurcfg.UseVisualStyleBackColor = true;
		this.Print_AutoRotation.AutoSize = true;
		this.Print_AutoRotation.Checked = true;
		this.Print_AutoRotation.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox print_AutoRotation = this.Print_AutoRotation;
		location = new System.Drawing.Point(10, 204);
		print_AutoRotation.Location = location;
		this.Print_AutoRotation.Name = "Print_AutoRotation";
		System.Windows.Forms.CheckBox print_AutoRotation2 = this.Print_AutoRotation;
		size = new System.Drawing.Size(123, 21);
		print_AutoRotation2.Size = size;
		this.Print_AutoRotation.TabIndex = 1;
		this.Print_AutoRotation.Text = "Автоповорот ориентации страницы";
		this.Print_AutoRotation.UseVisualStyleBackColor = true;
		this.Label4.AutoSize = true;
		this.Label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label5 = this.Label4;
		location = new System.Drawing.Point(10, 91);
		label5.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label6 = this.Label4;
		size = new System.Drawing.Size(68, 17);
		label6.Size = size;
		this.Label4.TabIndex = 6;
		this.Label4.Text = "Число копий:";
		this.Print_PrintToFile.AutoSize = true;
		this.Print_PrintToFile.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.CheckBox print_PrintToFile = this.Print_PrintToFile;
		location = new System.Drawing.Point(12, 123);
		print_PrintToFile.Location = location;
		this.Print_PrintToFile.Name = "Print_PrintToFile";
		System.Windows.Forms.CheckBox print_PrintToFile2 = this.Print_PrintToFile;
		size = new System.Drawing.Size(87, 21);
		print_PrintToFile2.Size = size;
		this.Print_PrintToFile.TabIndex = 7;
		this.Print_PrintToFile.Text = "Печать в файл";
		this.Print_PrintToFile.UseVisualStyleBackColor = true;
		this.Print_PrintToFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.TextBox print_PrintToFilePath = this.Print_PrintToFilePath;
		location = new System.Drawing.Point(12, 146);
		print_PrintToFilePath.Location = location;
		this.Print_PrintToFilePath.Name = "Print_PrintToFilePath";
		System.Windows.Forms.TextBox print_PrintToFilePath2 = this.Print_PrintToFilePath;
		size = new System.Drawing.Size(309, 23);
		print_PrintToFilePath2.Size = size;
		this.Print_PrintToFilePath.TabIndex = 8;
		this.Print_PrintToFileBow.AutoSize = true;
		this.Print_PrintToFileBow.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button print_PrintToFileBow = this.Print_PrintToFileBow;
		location = new System.Drawing.Point(327, 144);
		print_PrintToFileBow.Location = location;
		this.Print_PrintToFileBow.Name = "Print_PrintToFileBow";
		System.Windows.Forms.Button print_PrintToFileBow2 = this.Print_PrintToFileBow;
		size = new System.Drawing.Size(52, 27);
		print_PrintToFileBow2.Size = size;
		this.Print_PrintToFileBow.TabIndex = 9;
		this.Print_PrintToFileBow.Text = "Обзор";
		this.Print_PrintToFileBow.UseVisualStyleBackColor = true;
		this.HideSw1.AutoSize = true;
		this.HideSw1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.HideSw1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.CheckBox hideSw = this.HideSw1;
		location = new System.Drawing.Point(12, 289);
		hideSw.Location = location;
		this.HideSw1.Name = "HideSw1";
		System.Windows.Forms.CheckBox hideSw2 = this.HideSw1;
		size = new System.Drawing.Size(178, 21);
		hideSw2.Size = size;
		this.HideSw1.TabIndex = 14;
		this.HideSw1.Text = "Скрывать интерфейс SolidWorks во время работы";
		this.HideSw1.UseVisualStyleBackColor = true;
		this.Print_PrintCopies.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Print_PrintCopies.ForeColor = System.Drawing.SystemColors.WindowText;
		System.Windows.Forms.NumericUpDown print_PrintCopies = this.Print_PrintCopies;
		location = new System.Drawing.Point(92, 89);
		print_PrintCopies.Location = location;
		maximum = (this.Print_PrintCopies.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.Print_PrintCopies.Name = "Print_PrintCopies";
		System.Windows.Forms.NumericUpDown print_PrintCopies2 = this.Print_PrintCopies;
		size = new System.Drawing.Size(44, 23);
		print_PrintCopies2.Size = size;
		this.Print_PrintCopies.TabIndex = 2;
		maximum = (this.Print_PrintCopies.Value = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(647, 315);
		this.ClientSize = size;
		this.Controls.Add(this.HideSw1);
		this.Controls.Add(this.Print_PrintToFileBow);
		this.Controls.Add(this.Print_PrintToFilePath);
		this.Controls.Add(this.Print_PrintToFile);
		this.Controls.Add(this.Label4);
		this.Controls.Add(this.GroupBox4);
		this.Controls.Add(this.Print_PrintCopies);
		this.Controls.Add(this.GroupBox3);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmPrintoptions";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Параметры";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.Print_ScaleNum).EndInit();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Print_PrintCopies).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmPrintoptions()
	{
		base.Load += FrmPrintoptions_Load;
		__ENCAddToList(this);
		PrintBgWorker = new BackgroundWorker();
		CallInProgress = false;
		er = false;
		filelist = new List<string>();
		statuslist = new List<string>();
		Checklist = new List<bool>();
		indexlist = new List<int>();
		cfglist = new List<string>();
		overwrite = false;
		dpixRatio = 1.0;
		mLinearColor1 = Color.FromArgb(240, 240, 240);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			int num = DGV1.ColumnCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					DGV1.Columns[num2].Width = (int)Math.Round((double)DGV1.Columns[num2].Width * dpixRatio);
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void FrmPrintoptions_Load(object sender, EventArgs e)
	{
		DataGridView dGV = DGV1;
		dGV.RowCount = 6;
		dGV.Rows[0].Cells[0].Value = "A4";
		dGV.Rows[1].Cells[0].Value = "A3";
		dGV.Rows[2].Cells[0].Value = "A2";
		dGV.Rows[3].Cells[0].Value = "A1";
		dGV.Rows[4].Cells[0].Value = "A0";
		dGV.Rows[5].Cells[0].Value = "Other";
		dGV.Rows[0].Cells[1].Value = "A4";
		dGV.Rows[1].Cells[1].Value = "A3";
		dGV.Rows[2].Cells[1].Value = "A2";
		dGV.Rows[3].Cells[1].Value = "A1";
		dGV.Rows[4].Cells[1].Value = "A0";
		dGV.Rows[5].Cells[1].Value = "A4";
		dGV.Rows[0].Cells[2].Value = true;
		dGV.Rows[1].Cells[2].Value = true;
		dGV.ClearSelection();
		dGV = null;
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
		PrintDocument printDocument = new PrintDocument();
		string printerName = printDocument.PrinterSettings.PrinterName;
		Print_Printername.Items.Clear();
		checked
		{
			int num = PrinterSettings.InstalledPrinters.Count - 1;
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 < num3)
				{
					break;
				}
				string text = PrinterSettings.InstalledPrinters[num];
				Print_Printername.Items.Add(text);
				if (Operators.CompareString(printerName, text, TextCompare: false) == 0)
				{
					Print_Printername.SelectedIndex = Print_Printername.Items.IndexOf(printerName);
				}
				num += -1;
			}
			printDocument = null;
			ToolTip toolTip = new ToolTip();
			toolTip.SetToolTip(forcurcfg, "Действует только для чертежей, импортированных из главного окна, и чертежей выбранных элементов");
			Print_PrintToFilePath.Enabled = Print_PrintToFile.Checked;
			Print_PrintToFileBow.Enabled = Print_PrintToFile.Checked;
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		bool flag = false;
		checked
		{
			try
			{
				Savecfg();
				CConfigMng.Config.HideSw1 = HideSw1.Checked;
				CConfigMng.SaveConfig();
				if (MyProject.Forms.FrmPrintlist.ListView1.Items.Count == 0)
				{
					Interaction.MsgBox("В списке нет файлов", MsgBoxStyle.Information, "Информация");
					Close();
					return;
				}
				if (MyProject.Forms.FrmPrintlist.ListView1.GetCheckedItemsCount() == 0)
				{
					Interaction.MsgBox("Отметьте элементы для печати", MsgBoxStyle.Information, "Информация");
					Close();
					return;
				}
				DGV1.ClearSelection();
				bool flag2 = false;
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
					if (code.Cbool1(Conversions.ToString(DGV1[2, num2].Value)))
					{
						flag2 = true;
					}
					num2++;
				}
				if (!flag2)
				{
					Interaction.MsgBox("Выберите тип листов для печати", MsgBoxStyle.Information, "Информация");
					return;
				}
				Hide();
				ListViewVR listView = MyProject.Forms.FrmPrintlist.ListView1;
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
					if (Operators.CompareString(listView.Items[num6].SubItems[4].Text, "✔", TextCompare: false) == 0)
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
					num6++;
				}
				listView = null;
				filelist.Clear();
				statuslist.Clear();
				Checklist.Clear();
				indexlist.Clear();
				cfglist.Clear();
				ListViewVR listView2 = MyProject.Forms.FrmPrintlist.ListView1;
				int num8 = listView2.Items.Count - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num4 = num8;
					if (num10 > num4)
					{
						break;
					}
					if (!flag)
					{
						listView2.Items[num9].SubItems[4].Text = " ";
					}
					if (listView2.Items[num9].Checked)
					{
						statuslist.Add(listView2.Items[num9].SubItems[4].Text);
						filelist.Add(listView2.Items[num9].SubItems[2].Text);
						Checklist.Add(listView2.Items[num9].Checked);
						indexlist.Add(num9);
						cfglist.Add(listView2.Items[num9].SubItems[3].Text);
					}
					num9++;
				}
				listView2 = null;
				if (filelist.Count == 0)
				{
					Interaction.MsgBox("Нет элементов для печати", MsgBoxStyle.Information, "Информация");
					return;
				}
				MyProject.Forms.FrmPrintlist.ToolStripStatusLabel1.Text = "剩余" + Conversions.ToString(MyProject.Forms.FrmPrintlist.ListView1.GetCheckedItemsCount()) + "файлов";
				MyProject.Forms.FrmPrintlist.ListView1.MultiSelect = false;
				MyProject.Forms.FrmPrintlist.ListView1.Items[indexlist[0]].Selected = true;
				MyProject.Forms.FrmPrintlist.ToolStripProgressBar1.Maximum = MyProject.Forms.FrmPrintlist.ListView1.GetCheckedItemsCount();
				MyProject.Forms.FrmPrintlist.ToolStripProgressBar1.Visible = true;
				MyProject.Forms.FrmPrintlist.addfiles.Enabled = false;
				MyProject.Forms.FrmPrintlist.clearall.Enabled = false;
				MyProject.Forms.FrmPrintlist.clearsel.Enabled = false;
				MyProject.Forms.FrmPrintlist.openinsw.Enabled = false;
				code.EnablePreview = false;
				MyProject.Forms.FrmPrintlist.Switch(1);
				PrintBgWorker.WorkerSupportsCancellation = true;
				PrintBgWorker.WorkerReportsProgress = true;
				PrintBgWorker.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void PrintBgWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				er = false;
				if (!code.RunSW())
				{
					return;
				}
				int num = filelist.Count - 1;
				int num2 = 0;
				_Closure_0024__14 closure_0024__ = default(_Closure_0024__14);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (PrintBgWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					if (Operators.CompareString(statuslist[num2], "✔", TextCompare: false) != 0)
					{
						FilePathName = filelist[num2];
						FilePath = code.SplitStr(FilePathName);
						FileName = code.SplitStr(FilePathName, 1);
						if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
						{
							swFileTYpe = 1;
						}
						if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
						{
							swFileTYpe = 2;
						}
						if (FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
						{
							swFileTYpe = 3;
						}
						if (!code.RunSW(CConfigMng.Config.HideSw1))
						{
							return;
						}
						object obj = null;
						if (File.Exists(FilePathName))
						{
							NewLateBinding.LateCall(code.swApp, null, "SetCurrentWorkingDirectory", new object[1] { code.SplitStr(FilePathName) }, null, null, null, IgnoreReturn: true);
							object swApp = code.swApp;
							object[] array = new object[6] { FilePathName, swFileTYpe, 1, "", longstatus, longwarnings };
							object[] arguments = array;
							bool[] array2 = new bool[6] { true, true, false, false, true, true };
							object obj2 = NewLateBinding.LateGet(swApp, null, "OpenDoc6", arguments, null, null, array2);
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
							obj = RuntimeHelpers.GetObjectValue(obj2);
						}
						if (obj != null)
						{
							NewLateBinding.LateCall(obj, null, "EditRebuild3", new object[0], null, null, null, IgnoreReturn: true);
							NewLateBinding.LateCall(obj, null, "ViewZoomtofit2", new object[0], null, null, null, IgnoreReturn: true);
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetSheetNames", new object[0], null, null, null));
							int num5 = Information.UBound((Array)objectValue2);
							int num6 = 0;
							object[] array3;
							bool[] array2;
							while (true)
							{
								int num7 = num6;
								num4 = num5;
								if (num7 > num4)
								{
									break;
								}
								array3 = new object[1] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue2, new object[1] { num6 }, null)) };
								object[] arguments2 = array3;
								array2 = new bool[1] { true };
								object obj3 = NewLateBinding.LateGet(objectValue, null, "Sheet", arguments2, null, null, array2);
								if (array2[0])
								{
									NewLateBinding.LateIndexSetComplex(objectValue2, new object[2]
									{
										num6,
										RuntimeHelpers.GetObjectValue(array3[0])
									}, null, OptimisticSet: true, RValueBase: false);
								}
								object objectValue3 = RuntimeHelpers.GetObjectValue(obj3);
								object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "GetProperties", new object[0], null, null, null));
								List<string> modelcfgfromdrw = code.GetModelcfgfromdrw(RuntimeHelpers.GetObjectValue(objectValue3));
								if (forcurcfg.Checked & (Operators.CompareString(cfglist[num2], "", TextCompare: false) != 0))
								{
									string[] array4 = Strings.Split(cfglist[num2], "|\n");
									if ((cfglist.Count >= 1 && modelcfgfromdrw.Count > 0) ? true : false)
									{
										closure_0024__ = new _Closure_0024__14(closure_0024__);
										closure_0024__._0024VB_0024Local_cfg = modelcfgfromdrw[0];
										if (!Array.Exists(array4, closure_0024__._Lambda_0024__26))
										{
											goto IL_0dd1;
										}
									}
								}
								CanPrint = false;
								object left = NewLateBinding.LateIndexGet(objectValue4, new object[1] { 0 }, null);
								if (Operators.ConditionalCompareObjectEqual(left, 6, TextCompare: false))
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 0].Value));
								}
								else if (Operators.ConditionalCompareObjectEqual(left, 7, TextCompare: false))
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 0].Value));
								}
								else if (Operators.ConditionalCompareObjectEqual(left, 8, TextCompare: false))
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 1].Value));
								}
								else if (Operators.ConditionalCompareObjectEqual(left, 9, TextCompare: false))
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 2].Value));
								}
								else if (Operators.ConditionalCompareObjectEqual(left, 10, TextCompare: false))
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 3].Value));
								}
								else if (Operators.ConditionalCompareObjectEqual(left, 11, TextCompare: false))
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 4].Value));
								}
								else
								{
									CanPrint = code.Cbool1(Conversions.ToString(DGV1[2, 5].Value));
								}
								if (CanPrint)
								{
									NewLateBinding.LateSetComplex(NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null), null, "UsePageSetup", new object[1] { 2 }, null, null, OptimisticSet: false, RValueBase: true);
									object objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, null, "PageSetup", new object[0], null, null, null));
									if (Print_AutoRotation.Checked)
									{
										if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(objectValue4, new object[1] { 5 }, null), NewLateBinding.LateIndexGet(objectValue4, new object[1] { 6 }, null), TextCompare: false))
										{
											NewLateBinding.LateSet(objectValue5, null, "Orientation", new object[1] { 2 }, null, null);
										}
										else
										{
											NewLateBinding.LateSet(objectValue5, null, "Orientation", new object[1] { 1 }, null, null);
										}
									}
									NewLateBinding.LateSet(objectValue5, null, "ScaleToFit", new object[1] { Print_ScaleToFit.Checked }, null, null);
									if (Print_Scale.Checked)
									{
										NewLateBinding.LateSet(objectValue5, null, "ScaleToFit", new object[1] { false }, null, null);
										NewLateBinding.LateSet(objectValue5, null, "Scale2", new object[1] { Conversion.Val(Print_ScaleNum.Value) }, null, null);
									}
									NewLateBinding.LateSet(objectValue5, null, "HighQuality", new object[1] { Print_HighQuality.Checked }, null, null);
									if (Print_AutoColor.Checked)
									{
										NewLateBinding.LateSet(objectValue5, null, "DrawingColor", new object[1] { 1 }, null, null);
									}
									if (Print_Color.Checked)
									{
										NewLateBinding.LateSet(objectValue5, null, "DrawingColor", new object[1] { 2 }, null, null);
									}
									if (Print_BlackAndWhite.Checked)
									{
										NewLateBinding.LateSet(objectValue5, null, "DrawingColor", new object[1] { 3 }, null, null);
									}
									object left2 = NewLateBinding.LateIndexGet(objectValue4, new object[1] { 0 }, null);
									if (Operators.ConditionalCompareObjectEqual(left2, 6, TextCompare: false))
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 0].Value)) }, null, null);
									}
									else if (Operators.ConditionalCompareObjectEqual(left2, 7, TextCompare: false))
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 0].Value)) }, null, null);
									}
									else if (Operators.ConditionalCompareObjectEqual(left2, 8, TextCompare: false))
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 1].Value)) }, null, null);
									}
									else if (Operators.ConditionalCompareObjectEqual(left2, 9, TextCompare: false))
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 2].Value)) }, null, null);
									}
									else if (Operators.ConditionalCompareObjectEqual(left2, 10, TextCompare: false))
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 3].Value)) }, null, null);
									}
									else if (Operators.ConditionalCompareObjectEqual(left2, 11, TextCompare: false))
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 4].Value)) }, null, null);
									}
									else
									{
										NewLateBinding.LateSet(objectValue5, null, "PrinterPaperSize", new object[1] { code.GetPaperSize(Conversions.ToString(DGV1[1, 5].Value)) }, null, null);
									}
									if (Print_PrintToFile.Checked)
									{
										if (Operators.CompareString(Print_PrintToFilePath.Text, "", TextCompare: false) != 0)
										{
											SavePath = Print_PrintToFilePath.Text;
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
										if (Information.UBound((Array)objectValue2) == 0)
										{
											PrintFileName = SavePath + FileName + ".prn";
										}
										else
										{
											PrintFileName = SavePath + FileName + "-" + Conversions.ToString(num6) + ".prn";
										}
									}
									else
									{
										PrintFileName = "";
									}
									object obj4 = new int[2]
									{
										num6 + 1,
										num6 + 1
									};
									object instance = NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null);
									object[] array5 = new object[5]
									{
										RuntimeHelpers.GetObjectValue(obj4),
										null,
										null,
										null,
										null
									};
									object[] array6 = array5;
									NumericUpDown print_PrintCopies = Print_PrintCopies;
									array6[1] = print_PrintCopies.Value;
									array5[2] = true;
									object[] array7 = array5;
									ComboBox print_Printername = Print_Printername;
									array7[3] = print_Printername.Text;
									array5[4] = PrintFileName;
									array3 = array5;
									object[] arguments3 = array3;
									array2 = new bool[5] { false, true, false, true, true };
									NewLateBinding.LateCall(instance, null, "PrintOut2", arguments3, null, null, array2, IgnoreReturn: true);
									if (array2[1])
									{
										print_PrintCopies.Value = (decimal)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(decimal));
									}
									if (array2[3])
									{
										print_Printername.Text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
									}
									if (array2[4])
									{
										PrintFileName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[4]), typeof(string));
									}
								}
								goto IL_0dd1;
								IL_0dd1:
								num6++;
							}
							object swApp2 = code.swApp;
							array3 = new object[1] { FilePathName };
							object[] arguments4 = array3;
							array2 = new bool[1] { true };
							NewLateBinding.LateCall(swApp2, null, "CloseDoc", arguments4, null, null, array2, IgnoreReturn: true);
							if (array2[0])
							{
								FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
							}
							obj = null;
						}
						Thread.Sleep(5);
					}
					PrintBgWorker.ReportProgress(num2, CanPrint);
					num2++;
				}
				code.swApp = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				code.swApp = null;
				er = true;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void PrintBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		checked
		{
			try
			{
				if (!CallInProgress)
				{
					CallInProgress = true;
					if ((Operators.ConditionalCompareObjectEqual(e.UserState, true, TextCompare: false) && Checklist[e.ProgressPercentage]) ? true : false)
					{
						MyProject.Forms.FrmPrintlist.ListView1.Items[indexlist[e.ProgressPercentage]].SubItems[4].Text = "✔";
						MyProject.Forms.FrmPrintlist.ListView1.Items[indexlist[e.ProgressPercentage]].SubItems[4].ForeColor = Color.Blue;
					}
					MyProject.Forms.FrmPrintlist.ListView1.Items[indexlist[e.ProgressPercentage]].Selected = true;
					MyProject.Forms.FrmPrintlist.ListView1.Items[indexlist[e.ProgressPercentage]].EnsureVisible();
					MyProject.Forms.FrmPrintlist.ToolStripProgressBar1.Value = e.ProgressPercentage + 1;
					MyProject.Forms.FrmPrintlist.ToolStripStatusLabel1.Text = "剩余" + Conversions.ToString(MyProject.Forms.FrmPrintlist.ListView1.GetCheckedItemsCount() - 1 - e.ProgressPercentage) + "файлов";
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

	private void PrintBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			code.RunSW(HideWindow: false, startnew: false);
			MyProject.Forms.FrmPrintlist.addfiles.Enabled = true;
			MyProject.Forms.FrmPrintlist.clearall.Enabled = true;
			MyProject.Forms.FrmPrintlist.clearsel.Enabled = true;
			MyProject.Forms.FrmPrintlist.openinsw.Enabled = true;
			code.EnablePreview = true;
			MyProject.Forms.FrmPrintlist.ListView1.MultiSelect = true;
			MyProject.Forms.FrmPrintlist.ToolStripProgressBar1.Visible = false;
			MyProject.Forms.FrmPrintlist.ToolStripProgressBar1.Value = 0;
			if (er)
			{
				er = false;
				MyProject.Forms.FrmPrintlist.Switch(4);
			}
			else if (!e.Cancelled)
			{
				MyProject.Forms.FrmPrintlist.Switch(2);
			}
			else
			{
				MyProject.Forms.FrmPrintlist.Switch(3);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void DGV1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex == 1 && DGV1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) ? true : false)
		{
			SendKeys.Send("{F4}");
		}
	}

	private void Print_PrintToFile_CheckedChanged(object sender, EventArgs e)
	{
		Print_PrintToFilePath.Enabled = Print_PrintToFile.Checked;
		Print_PrintToFileBow.Enabled = Print_PrintToFile.Checked;
	}

	private void Print_ScaleToFit_CheckedChanged(object sender, EventArgs e)
	{
		Print_ScaleNum.Enabled = Print_Scale.Checked;
	}

	private void Print_PrintToFileBow_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			Print_PrintToFilePath.Text = fileBorser.DirectoryPath;
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Shell.Application"));
		foreach (object item in (IEnumerable)NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Namespace", new object[1] { 4 }, null, null, null), null, "Items", new object[0], null, null, null))
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(item);
			if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue2, null, "Name", new object[0], null, null, null), Print_Printername.Text, TextCompare: false))
			{
				continue;
			}
			foreach (object item2 in (IEnumerable)NewLateBinding.LateGet(objectValue2, null, "Verbs", new object[0], null, null, null))
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(item2);
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue3, null, "Name", new object[0], null, null, null), "打印首选项(&E)...", TextCompare: false))
				{
					NewLateBinding.LateCall(objectValue3, null, "doit", new object[0], null, null, null, IgnoreReturn: true);
				}
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
				ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);
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

	private void Savecfg()
	{
		CConfigMng.Config.printcfg.Clear();
		foreach (Control control in Controls)
		{
			FindctlToSave(control);
		}
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control ctl)
	{
		checked
		{
			if (ctl is CheckBox)
			{
				CConfigMng.Config.printcfg.Add(ctl.Name + "\n" + Conversions.ToString(((CheckBox)ctl).Checked));
			}
			else if ((ctl is TextBox && !(ctl.Parent is NumericUpDown)) ? true : false)
			{
				CConfigMng.Config.printcfg.Add(ctl.Name + "\n" + ((TextBox)ctl).Text);
			}
			else if (ctl is ComboBox)
			{
				CConfigMng.Config.printcfg.Add(ctl.Name + "\n" + Conversions.ToString(((ComboBox)ctl).SelectedIndex));
			}
			else if (ctl is RadioButton)
			{
				CConfigMng.Config.printcfg.Add(ctl.Name + "\n" + Conversions.ToString(((RadioButton)ctl).Checked));
			}
			else if (ctl is NumericUpDown)
			{
				CConfigMng.Config.printcfg.Add(ctl.Name + "\n" + Conversions.ToString(((NumericUpDown)ctl).Value));
			}
			else if (ctl is DataGridView)
			{
				StringBuilder stringBuilder = new StringBuilder();
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
					stringBuilder.AppendLine(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[1, num2].Value)) + "|" + Conversions.ToString(code.Cbool1(Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[2, num2].Value)))));
					num2++;
				}
				CConfigMng.Config.printcfg.Add(ctl.Name + "\n" + code.ToHexString(stringBuilder.ToString().Trim()));
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
	}

	private void Loadcfg()
	{
		foreach (Control control in Controls)
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
		int num5 = default(int);
		int num6 = default(int);
		string[] array = default(string[]);
		string[] array2 = default(string[]);
		int num9 = default(int);
		int num10 = default(int);
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
					int num11;
					int num8;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000a;
					case 871:
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
								goto IL_0027;
							case 4:
								goto IL_0047;
							case 6:
							case 7:
								goto IL_0061;
							case 8:
								goto IL_007f;
							case 9:
								goto IL_0091;
							case 11:
								goto IL_00ae;
							case 12:
								goto IL_00c1;
							case 14:
								goto IL_00d9;
							case 15:
								goto IL_00ec;
							case 17:
								goto IL_010f;
							case 18:
								goto IL_0122;
							case 20:
								goto IL_013f;
							case 21:
								goto IL_0152;
							case 23:
								goto IL_0175;
							case 24:
								goto IL_018b;
							case 25:
								goto IL_01a4;
							case 26:
								goto IL_01bb;
							case 27:
								goto IL_01ec;
							case 28:
								goto IL_021d;
							case 5:
							case 10:
							case 13:
							case 16:
							case 19:
							case 22:
							case 29:
							case 30:
							case 31:
								goto IL_0231;
							case 32:
								goto IL_0246;
							case 33:
								goto IL_0256;
							case 34:
								goto IL_0277;
							case 35:
								goto IL_0284;
							default:
								goto end_IL_0001;
							case 36:
							case 37:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_01a4:
						num2 = 25;
						num5 = DGV1.RowCount - 1;
						num6 = 0;
						goto IL_0226;
						IL_0226:
						num7 = num6;
						num8 = num5;
						if (num7 <= num8)
						{
							goto IL_01bb;
						}
						goto IL_0231;
						IL_018b:
						num2 = 24;
						array = Strings.Split(code.FromHexString(array2[1]), "\r\n");
						goto IL_01a4;
						IL_01bb:
						num2 = 26;
						DGV1[1, num6].Value = array[num6].Split('|')[0];
						goto IL_01ec;
						IL_000a:
						num2 = 2;
						num9 = CConfigMng.Config.printcfg.Count - 1;
						num10 = 0;
						goto IL_023a;
						IL_023a:
						num11 = num10;
						num8 = num9;
						if (num11 <= num8)
						{
							goto IL_0027;
						}
						goto IL_0246;
						IL_0246:
						num2 = 32;
						if (!ctl.HasChildren)
						{
							goto end_IL_0001_2;
						}
						goto IL_0256;
						IL_0256:
						num2 = 33;
						enumerator = ctl.Controls.GetEnumerator();
						goto IL_0289;
						IL_0289:
						if (enumerator.MoveNext())
						{
							ctl2 = (Control)enumerator.Current;
							goto IL_0277;
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto end_IL_0001_2;
						IL_01ec:
						num2 = 27;
						DGV1[2, num6].Value = array[num6].Split('|')[1];
						goto IL_021d;
						IL_0231:
						num2 = 31;
						num10++;
						goto IL_023a;
						IL_021d:
						num2 = 28;
						num6++;
						goto IL_0226;
						IL_0277:
						num2 = 34;
						FindctlToLoad(ctl2);
						goto IL_0284;
						IL_0284:
						num2 = 35;
						goto IL_0289;
						IL_0027:
						num2 = 3;
						array2 = Strings.Split(CConfigMng.Config.printcfg[num10], "\n");
						goto IL_0047;
						IL_0047:
						num2 = 4;
						if (array2.Count() == 2)
						{
							goto IL_0061;
						}
						goto IL_0231;
						IL_0061:
						num2 = 7;
						if (Operators.CompareString(ctl.Name, array2[0], TextCompare: false) == 0)
						{
							goto IL_007f;
						}
						goto IL_0231;
						IL_007f:
						num2 = 8;
						if (ctl is CheckBox)
						{
							goto IL_0091;
						}
						goto IL_00ae;
						IL_0091:
						num2 = 9;
						((CheckBox)ctl).Checked = code.Cbool1(array2[1]);
						goto IL_0231;
						IL_00ae:
						num2 = 11;
						if (ctl is TextBox)
						{
							goto IL_00c1;
						}
						goto IL_00d9;
						IL_00c1:
						num2 = 12;
						((TextBox)ctl).Text = array2[1];
						goto IL_0231;
						IL_00d9:
						num2 = 14;
						if (ctl is ComboBox)
						{
							goto IL_00ec;
						}
						goto IL_010f;
						IL_00ec:
						num2 = 15;
						((ComboBox)ctl).SelectedIndex = (int)Math.Round(Conversion.Val(array2[1]));
						goto IL_0231;
						IL_010f:
						num2 = 17;
						if (ctl is RadioButton)
						{
							goto IL_0122;
						}
						goto IL_013f;
						IL_0122:
						num2 = 18;
						((RadioButton)ctl).Checked = code.Cbool1(array2[1]);
						goto IL_0231;
						IL_013f:
						num2 = 20;
						if (ctl is NumericUpDown)
						{
							goto IL_0152;
						}
						goto IL_0175;
						IL_0152:
						num2 = 21;
						((NumericUpDown)ctl).Value = new decimal(Conversion.Val(array2[1]));
						goto IL_0231;
						IL_0175:
						num2 = 23;
						if (ctl is DataGridView)
						{
							goto IL_018b;
						}
						goto IL_0231;
						end_IL_0001:
						break;
					}
				}
			}
			catch (Exception obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 871;
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
