using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
public class FrmSetDrwOption : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[AccessedThroughProperty("CheckBox2")]
	private CheckBox _CheckBox2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("TextBox2")]
	private TextBox _TextBox2;

	[AccessedThroughProperty("DGV1")]
	private DataGridView _DGV1;

	[AccessedThroughProperty("Column1")]
	private DataGridViewTextBoxColumn _Column1;

	[AccessedThroughProperty("Column2")]
	private DataGridViewComboBoxColumn _Column2;

	[AccessedThroughProperty("CheckBox3")]
	private CheckBox _CheckBox3;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("HideSw1")]
	private CheckBox _HideSw1;

	[AccessedThroughProperty("CheckBox4")]
	private CheckBox _CheckBox4;

	[AccessedThroughProperty("TabControl1")]
	private TabControl _TabControl1;

	[AccessedThroughProperty("TabPage1")]
	private TabPage _TabPage1;

	[AccessedThroughProperty("TabPage3")]
	private TabPage _TabPage3;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("RadioButton3")]
	private RadioButton _RadioButton3;

	[AccessedThroughProperty("RadioButton4")]
	private RadioButton _RadioButton4;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("TabPage2")]
	private TabPage _TabPage2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	[AccessedThroughProperty("TextBox4")]
	private TextBox _TextBox4;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("TextBox3")]
	private TextBox _TextBox3;

	private string FilePathName;

	private string FileName;

	private string FilePath;

	private string Drwformatname;

	private string Drwformatpath;

	private string Drwstandardfile;

	private string prtstandardfile;

	private string asmstandardfile;

	private string[] newtemplate;

	private int swFileTYpe;

	private bool boolstatus;

	private int longstatus;

	private int longwarnings;

	[AccessedThroughProperty("SetDrwBgWorker")]
	private BackgroundWorker _SetDrwBgWorker;

	private bool CallInProgress;

	private bool er;

	private List<string> filelist;

	private List<string> Statelist;

	private double dpixRatio;

	private bool isloaded;

	private StringBuilder sb;

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
			EventHandler value2 = CheckBox1_CheckedChanged;
			if (_CheckBox1 != null)
			{
				_CheckBox1.CheckedChanged -= value2;
			}
			_CheckBox1 = value;
			if (_CheckBox1 != null)
			{
				_CheckBox1.CheckedChanged += value2;
			}
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
			EventHandler value2 = CheckBox2_CheckedChanged;
			if (_CheckBox2 != null)
			{
				_CheckBox2.CheckedChanged -= value2;
			}
			_CheckBox2 = value;
			if (_CheckBox2 != null)
			{
				_CheckBox2.CheckedChanged += value2;
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
			EventHandler value2 = TextBox2_TextChanged;
			if (_TextBox2 != null)
			{
				_TextBox2.TextChanged -= value2;
			}
			_TextBox2 = value;
			if (_TextBox2 != null)
			{
				_TextBox2.TextChanged += value2;
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
			EventHandler value2 = CheckBox2_CheckedChanged;
			if (_CheckBox3 != null)
			{
				_CheckBox3.CheckedChanged -= value2;
			}
			_CheckBox3 = value;
			if (_CheckBox3 != null)
			{
				_CheckBox3.CheckedChanged += value2;
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
			EventHandler value2 = CheckBox2_CheckedChanged;
			if (_CheckBox4 != null)
			{
				_CheckBox4.CheckedChanged -= value2;
			}
			_CheckBox4 = value;
			if (_CheckBox4 != null)
			{
				_CheckBox4.CheckedChanged += value2;
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
			_RadioButton3 = value;
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
			_RadioButton1 = value;
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
			EventHandler value2 = Button1_Click;
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

	internal virtual TextBox TextBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox4 = value;
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
			EventHandler value2 = Button1_Click;
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
			_TextBox3 = value;
		}
	}

	public virtual BackgroundWorker SetDrwBgWorker
	{
		[DebuggerNonUserCode]
		get
		{
			return _SetDrwBgWorker;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RunWorkerCompletedEventHandler value2 = SetDrwBgWorker_RunWorkerCompleted;
			ProgressChangedEventHandler value3 = SetDrwBgWorker_ProgressChanged;
			DoWorkEventHandler value4 = SetDrwBgWorker_DoWork;
			if (_SetDrwBgWorker != null)
			{
				_SetDrwBgWorker.RunWorkerCompleted -= value2;
				_SetDrwBgWorker.ProgressChanged -= value3;
				_SetDrwBgWorker.DoWork -= value4;
			}
			_SetDrwBgWorker = value;
			if (_SetDrwBgWorker != null)
			{
				_SetDrwBgWorker.RunWorkerCompleted += value2;
				_SetDrwBgWorker.ProgressChanged += value3;
				_SetDrwBgWorker.DoWork += value4;
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
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Button4 = new System.Windows.Forms.Button();
		this.TextBox4 = new System.Windows.Forms.TextBox();
		this.Button3 = new System.Windows.Forms.Button();
		this.TextBox3 = new System.Windows.Forms.TextBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.DGV1 = new System.Windows.Forms.DataGridView();
		this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.Button2 = new System.Windows.Forms.Button();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.CheckBox2 = new System.Windows.Forms.CheckBox();
		this.CheckBox3 = new System.Windows.Forms.CheckBox();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.CheckBox4 = new System.Windows.Forms.CheckBox();
		this.HideSw1 = new System.Windows.Forms.CheckBox();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.RadioButton3 = new System.Windows.Forms.RadioButton();
		this.RadioButton4 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.TableLayoutPanel1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		this.GroupBox3.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.TabPage2.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(226, 391);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(151, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(4, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "Старт";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(79, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Button4);
		this.GroupBox1.Controls.Add(this.TextBox4);
		this.GroupBox1.Controls.Add(this.Button3);
		this.GroupBox1.Controls.Add(this.TextBox3);
		this.GroupBox1.Controls.Add(this.Button1);
		this.GroupBox1.Controls.Add(this.TextBox1);
		this.GroupBox1.Controls.Add(this.CheckBox1);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(12, 8);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(350, 224);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Стандарт оформления";
		this.Label4.AutoSize = true;
		System.Windows.Forms.Label label = this.Label4;
		location = new System.Drawing.Point(9, 158);
		label.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label2 = this.Label4;
		size = new System.Drawing.Size(128, 17);
		label2.Size = size;
		this.Label4.TabIndex = 3;
		this.Label4.Text = "Стандарт оформления (сборка):";
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label3;
		location = new System.Drawing.Point(9, 102);
		label3.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label4 = this.Label3;
		size = new System.Drawing.Size(116, 17);
		label4.Size = size;
		this.Label3.TabIndex = 3;
		this.Label3.Text = "Стандарт оформления (деталь):";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label2;
		location = new System.Drawing.Point(10, 52);
		label5.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label6 = this.Label2;
		size = new System.Drawing.Size(128, 17);
		label6.Size = size;
		this.Label2.TabIndex = 3;
		this.Label2.Text = "Стандарт оформления (чертёж):";
		this.Button4.AutoSize = true;
		System.Windows.Forms.Button button = this.Button4;
		location = new System.Drawing.Point(280, 176);
		button.Location = location;
		this.Button4.Name = "Button4";
		System.Windows.Forms.Button button2 = this.Button4;
		size = new System.Drawing.Size(58, 27);
		button2.Size = size;
		this.Button4.TabIndex = 2;
		this.Button4.Text = "Обзор...";
		this.Button4.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox = this.TextBox4;
		location = new System.Drawing.Point(9, 178);
		textBox.Location = location;
		this.TextBox4.Name = "TextBox4";
		System.Windows.Forms.TextBox textBox2 = this.TextBox4;
		size = new System.Drawing.Size(265, 23);
		textBox2.Size = size;
		this.TextBox4.TabIndex = 1;
		this.Button3.AutoSize = true;
		System.Windows.Forms.Button button3 = this.Button3;
		location = new System.Drawing.Point(280, 120);
		button3.Location = location;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button4 = this.Button3;
		size = new System.Drawing.Size(58, 27);
		button4.Size = size;
		this.Button3.TabIndex = 2;
		this.Button3.Text = "Обзор...";
		this.Button3.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox3 = this.TextBox3;
		location = new System.Drawing.Point(9, 122);
		textBox3.Location = location;
		this.TextBox3.Name = "TextBox3";
		System.Windows.Forms.TextBox textBox4 = this.TextBox3;
		size = new System.Drawing.Size(265, 23);
		textBox4.Size = size;
		this.TextBox3.TabIndex = 1;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button5 = this.Button1;
		location = new System.Drawing.Point(281, 70);
		button5.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button6 = this.Button1;
		size = new System.Drawing.Size(58, 27);
		button6.Size = size;
		this.Button1.TabIndex = 2;
		this.Button1.Text = "Обзор...";
		this.Button1.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox5 = this.TextBox1;
		location = new System.Drawing.Point(10, 72);
		textBox5.Location = location;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox6 = this.TextBox1;
		size = new System.Drawing.Size(265, 23);
		textBox6.Size = size;
		this.TextBox1.TabIndex = 1;
		this.CheckBox1.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox = this.CheckBox1;
		location = new System.Drawing.Point(10, 20);
		checkBox.Location = location;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox2 = this.CheckBox1;
		size = new System.Drawing.Size(109, 21);
		checkBox2.Size = size;
		this.CheckBox1.TabIndex = 0;
		this.CheckBox1.Text = "Заменить «стандарт оформления»";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.GroupBox2.Controls.Add(this.Label1);
		this.GroupBox2.Controls.Add(this.DGV1);
		this.GroupBox2.Controls.Add(this.Button2);
		this.GroupBox2.Controls.Add(this.TextBox2);
		this.GroupBox2.Controls.Add(this.CheckBox2);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(12, 8);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(350, 320);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Формат листа";
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label1;
		location = new System.Drawing.Point(8, 48);
		label7.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label8 = this.Label1;
		size = new System.Drawing.Size(128, 17);
		label8.Size = size;
		this.Label1.TabIndex = 5;
		this.Label1.Text = "Папка с форматами листа:";
		this.DGV1.AllowUserToAddRows = false;
		this.DGV1.AllowUserToDeleteRows = false;
		this.DGV1.AllowUserToResizeColumns = false;
		this.DGV1.AllowUserToResizeRows = false;
		this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.DGV1.BackgroundColor = System.Drawing.SystemColors.Control;
		this.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DGV1.Columns.AddRange(this.Column1, this.Column2);
		System.Windows.Forms.DataGridView dGV = this.DGV1;
		location = new System.Drawing.Point(10, 112);
		dGV.Location = location;
		this.DGV1.MultiSelect = false;
		this.DGV1.Name = "DGV1";
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.DGV1.RowHeadersVisible = false;
		this.DGV1.RowTemplate.Height = 23;
		System.Windows.Forms.DataGridView dGV2 = this.DGV1;
		size = new System.Drawing.Size(221, 188);
		dGV2.Size = size;
		this.DGV1.TabIndex = 4;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
		this.Column1.HeaderText = "Исходный размер листа";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column1.Width = 65;
		this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column2.FillWeight = 50f;
		this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.Column2.HeaderText = "Новый формат листа";
		this.Column2.Name = "Column2";
		this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Button2.AutoSize = true;
		System.Windows.Forms.Button button7 = this.Button2;
		location = new System.Drawing.Point(281, 70);
		button7.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button8 = this.Button2;
		size = new System.Drawing.Size(58, 27);
		button8.Size = size;
		this.Button2.TabIndex = 2;
		this.Button2.Text = "Обзор...";
		this.Button2.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox7 = this.TextBox2;
		location = new System.Drawing.Point(8, 72);
		textBox7.Location = location;
		this.TextBox2.Name = "TextBox2";
		System.Windows.Forms.TextBox textBox8 = this.TextBox2;
		size = new System.Drawing.Size(265, 23);
		textBox8.Size = size;
		this.TextBox2.TabIndex = 1;
		this.CheckBox2.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox3 = this.CheckBox2;
		location = new System.Drawing.Point(10, 20);
		checkBox3.Location = location;
		this.CheckBox2.Name = "CheckBox2";
		System.Windows.Forms.CheckBox checkBox4 = this.CheckBox2;
		size = new System.Drawing.Size(109, 21);
		checkBox4.Size = size;
		this.CheckBox2.TabIndex = 0;
		this.CheckBox2.Text = "Заменить «формат листа»";
		this.CheckBox2.UseVisualStyleBackColor = true;
		this.CheckBox3.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox5 = this.CheckBox3;
		location = new System.Drawing.Point(12, 24);
		checkBox5.Location = location;
		this.CheckBox3.Name = "CheckBox3";
		System.Windows.Forms.CheckBox checkBox6 = this.CheckBox3;
		size = new System.Drawing.Size(135, 21);
		checkBox6.Size = size;
		this.CheckBox3.TabIndex = 0;
		this.CheckBox3.Text = "Скрывать висячие аннотации и размеры";
		this.CheckBox3.UseVisualStyleBackColor = true;
		this.GroupBox3.Controls.Add(this.CheckBox4);
		this.GroupBox3.Controls.Add(this.CheckBox3);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox3;
		location = new System.Drawing.Point(12, 10);
		groupBox5.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox3;
		size = new System.Drawing.Size(350, 55);
		groupBox6.Size = size;
		this.GroupBox3.TabIndex = 1;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Висячие аннотации";
		this.CheckBox4.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox7 = this.CheckBox4;
		location = new System.Drawing.Point(177, 24);
		checkBox7.Location = location;
		this.CheckBox4.Name = "CheckBox4";
		System.Windows.Forms.CheckBox checkBox8 = this.CheckBox4;
		size = new System.Drawing.Size(135, 21);
		checkBox8.Size = size;
		this.CheckBox4.TabIndex = 0;
		this.CheckBox4.Text = "Удалять висячие аннотации и размеры";
		this.CheckBox4.UseVisualStyleBackColor = true;
		this.HideSw1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.HideSw1.AutoSize = true;
		this.HideSw1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.CheckBox hideSw = this.HideSw1;
		location = new System.Drawing.Point(10, 399);
		hideSw.Location = location;
		this.HideSw1.Name = "HideSw1";
		System.Windows.Forms.CheckBox hideSw2 = this.HideSw1;
		size = new System.Drawing.Size(178, 21);
		hideSw2.Size = size;
		this.HideSw1.TabIndex = 15;
		this.HideSw1.Text = "Скрывать интерфейс SolidWorks во время работы";
		this.HideSw1.UseVisualStyleBackColor = true;
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TabControl tabControl = this.TabControl1;
		location = new System.Drawing.Point(0, 0);
		tabControl.Location = location;
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		System.Windows.Forms.TabControl tabControl2 = this.TabControl1;
		size = new System.Drawing.Size(389, 384);
		tabControl2.Size = size;
		this.TabControl1.TabIndex = 16;
		this.TabPage1.Controls.Add(this.GroupBox1);
		System.Windows.Forms.TabPage tabPage = this.TabPage1;
		location = new System.Drawing.Point(4, 26);
		tabPage.Location = location;
		this.TabPage1.Name = "TabPage1";
		System.Windows.Forms.TabPage tabPage2 = this.TabPage1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(3);
		tabPage2.Padding = padding;
		System.Windows.Forms.TabPage tabPage3 = this.TabPage1;
		size = new System.Drawing.Size(381, 354);
		tabPage3.Size = size;
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Стандарт оформления";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.TabPage2.Controls.Add(this.GroupBox2);
		System.Windows.Forms.TabPage tabPage4 = this.TabPage2;
		location = new System.Drawing.Point(4, 26);
		tabPage4.Location = location;
		this.TabPage2.Name = "TabPage2";
		System.Windows.Forms.TabPage tabPage5 = this.TabPage2;
		padding = new System.Windows.Forms.Padding(3);
		tabPage5.Padding = padding;
		System.Windows.Forms.TabPage tabPage6 = this.TabPage2;
		size = new System.Drawing.Size(381, 354);
		tabPage6.Size = size;
		this.TabPage2.TabIndex = 2;
		this.TabPage2.Text = "Формат листа";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.TabPage3.Controls.Add(this.GroupBox4);
		this.TabPage3.Controls.Add(this.GroupBox3);
		System.Windows.Forms.TabPage tabPage7 = this.TabPage3;
		location = new System.Drawing.Point(4, 26);
		tabPage7.Location = location;
		this.TabPage3.Name = "TabPage3";
		System.Windows.Forms.TabPage tabPage8 = this.TabPage3;
		padding = new System.Windows.Forms.Padding(3);
		tabPage8.Padding = padding;
		System.Windows.Forms.TabPage tabPage9 = this.TabPage3;
		size = new System.Drawing.Size(381, 354);
		tabPage9.Size = size;
		this.TabPage3.TabIndex = 1;
		this.TabPage3.Text = "Прочее";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.GroupBox4.Controls.Add(this.RadioButton3);
		this.GroupBox4.Controls.Add(this.RadioButton4);
		this.GroupBox4.Controls.Add(this.RadioButton2);
		this.GroupBox4.Controls.Add(this.RadioButton1);
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox4;
		location = new System.Drawing.Point(12, 71);
		groupBox7.Location = location;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox4;
		size = new System.Drawing.Size(350, 81);
		groupBox8.Size = size;
		this.GroupBox4.TabIndex = 2;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Начало координат области листа";
		this.RadioButton3.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton3;
		location = new System.Drawing.Point(15, 53);
		radioButton.Location = location;
		this.RadioButton3.Name = "RadioButton3";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton3;
		size = new System.Drawing.Size(50, 21);
		radioButton2.Size = size;
		this.RadioButton3.TabIndex = 0;
		this.RadioButton3.TabStop = true;
		this.RadioButton3.Text = "Снизу слева";
		this.RadioButton3.UseVisualStyleBackColor = true;
		this.RadioButton4.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton4;
		location = new System.Drawing.Point(177, 53);
		radioButton3.Location = location;
		this.RadioButton4.Name = "RadioButton4";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton4;
		size = new System.Drawing.Size(50, 21);
		radioButton4.Size = size;
		this.RadioButton4.TabIndex = 0;
		this.RadioButton4.TabStop = true;
		this.RadioButton4.Text = "Снизу справа";
		this.RadioButton4.UseVisualStyleBackColor = true;
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton5 = this.RadioButton2;
		location = new System.Drawing.Point(177, 26);
		radioButton5.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton6 = this.RadioButton2;
		size = new System.Drawing.Size(50, 21);
		radioButton6.Size = size;
		this.RadioButton2.TabIndex = 0;
		this.RadioButton2.Text = "Сверху справа";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton7 = this.RadioButton1;
		location = new System.Drawing.Point(15, 26);
		radioButton7.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton8 = this.RadioButton1;
		size = new System.Drawing.Size(50, 21);
		radioButton8.Size = size;
		this.RadioButton1.TabIndex = 0;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Сверху слева";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(389, 429);
		this.ClientSize = size;
		this.Controls.Add(this.TabControl1);
		this.Controls.Add(this.HideSw1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmSetDrwOption";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Параметры";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage2.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
		this.AutoScroll = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.MinimumSize = new System.Drawing.Size(389, 429);
	}

	public FrmSetDrwOption()
	{
		base.Load += FrmSetDrwOption_Load;
		base.FormClosed += FrmSetDrwOption_FormClosed;
		__ENCAddToList(this);
		newtemplate = new string[7];
		SetDrwBgWorker = new BackgroundWorker();
		CallInProgress = false;
		er = false;
		filelist = new List<string>();
		Statelist = new List<string>();
		dpixRatio = 1.0;
		isloaded = false;
		sb = new StringBuilder();
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

	private void FrmSetDrwOption_FormClosed(object sender, FormClosedEventArgs e)
	{
		isloaded = false;
	}

	private void FrmSetDrwOption_Load(object sender, EventArgs e)
	{
		isloaded = false;
		TextBox1.Enabled = CheckBox1.Checked;
		Button1.Enabled = CheckBox1.Checked;
		TextBox3.Enabled = CheckBox1.Checked;
		Button3.Enabled = CheckBox1.Checked;
		TextBox4.Enabled = CheckBox1.Checked;
		Button4.Enabled = CheckBox1.Checked;
		TextBox2.Enabled = CheckBox2.Checked;
		Button2.Enabled = CheckBox2.Checked;
		DGV1.Enabled = CheckBox2.Checked;
		DataGridView dGV = DGV1;
		dGV.RowCount = 7;
		dGV.Rows[0].Cells[0].Value = "A4 альбомная";
		dGV.Rows[1].Cells[0].Value = "A4 книжная";
		dGV.Rows[2].Cells[0].Value = "A3";
		dGV.Rows[3].Cells[0].Value = "A2";
		dGV.Rows[4].Cells[0].Value = "A1";
		dGV.Rows[5].Cells[0].Value = "A0";
		dGV.Rows[6].Cells[0].Value = "Other";
		dGV.ClearSelection();
		dGV = null;
		Loadcfg();
		isloaded = true;
	}

	private void DGV1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex != 1 || !(DGV1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) || 1 == 0)
		{
			return;
		}
		SendKeys.Send("{F4}");
		DataGridViewComboBoxColumn dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)DGV1.Columns[e.ColumnIndex];
		if (dataGridViewComboBoxColumn.Items.Count <= 1)
		{
			switch (getfiles())
			{
			case 0:
				MessageBox.Show(this, "\"" + TextBox2.Text + "\" в папке не найдено файлов формата листа с расширением «.slddrt»", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				break;
			case 2:
				MessageBox.Show(this, "\"" + TextBox2.Text + "\" папка не существует!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				break;
			case 3:
				MessageBox.Show(this, "Сначала укажите папку с форматами листа", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				break;
			}
		}
	}

	private void DGV1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		e.Cancel = true;
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

	private void Button1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Файл стандарта оформления (*.sldstd)|*.sldstd";
		if (openFileDialog.ShowDialog() != DialogResult.Cancel)
		{
			Button button = (Button)sender;
			string name = button.Name;
			if (Operators.CompareString(name, Button1.Name, TextCompare: false) == 0)
			{
				TextBox1.Text = openFileDialog.FileName;
			}
			else if (Operators.CompareString(name, Button3.Name, TextCompare: false) == 0)
			{
				TextBox3.Text = openFileDialog.FileName;
			}
			else if (Operators.CompareString(name, Button4.Name, TextCompare: false) == 0)
			{
				TextBox4.Text = openFileDialog.FileName;
			}
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			TextBox2.Text = fileBorser.DirectoryPath;
		}
	}

	private void TextBox2_TextChanged(object sender, EventArgs e)
	{
		if (isloaded)
		{
			getfiles();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public int getfiles()
	{
		DataGridViewComboBoxColumn dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)DGV1.Columns[1];
		dataGridViewComboBoxColumn.Items.Clear();
		dataGridViewComboBoxColumn.Items.Add("");
		if (Operators.CompareString(TextBox2.Text.Trim(), "", TextCompare: false) == 0)
		{
			return 3;
		}
		string text = (Strings.RTrim(TextBox2.Text).EndsWith("\\") ? TextBox2.Text : (TextBox2.Text + "\\"));
		if (!Directory.Exists(text))
		{
			return 2;
		}
		string text2 = FileSystem.Dir(text + "*.slddrt");
		while (Operators.CompareString(text2, "", TextCompare: false) != 0)
		{
			dataGridViewComboBoxColumn.Items.Add(text2);
			text2 = FileSystem.Dir();
		}
		if (dataGridViewComboBoxColumn.Items.Count > 1)
		{
			return 1;
		}
		return 0;
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		TextBox1.Enabled = CheckBox1.Checked;
		Button1.Enabled = CheckBox1.Checked;
		TextBox3.Enabled = CheckBox1.Checked;
		Button3.Enabled = CheckBox1.Checked;
		TextBox4.Enabled = CheckBox1.Checked;
		Button4.Enabled = CheckBox1.Checked;
	}

	private void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		TextBox2.Enabled = CheckBox2.Checked;
		Button2.Enabled = CheckBox2.Checked;
		DGV1.Enabled = CheckBox2.Checked;
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
				if (!Strings.RTrim(TextBox2.Text).EndsWith("\\"))
				{
					Drwformatpath = TextBox2.Text + "\\";
				}
				else
				{
					Drwformatpath = TextBox2.Text;
				}
				Drwstandardfile = TextBox1.Text;
				prtstandardfile = TextBox3.Text;
				asmstandardfile = TextBox4.Text;
				if (MyProject.Forms.FrmSetDrwlist.ListView1.Items.Count == 0)
				{
					Interaction.MsgBox("В списке нет файлов", MsgBoxStyle.Information, "Информация");
					Close();
					return;
				}
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				DGV1.EndEdit();
				bool flag5 = true;
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
					newtemplate[num2] = Conversions.ToString(DGV1[1, num2].Value);
					if (Operators.CompareString(newtemplate[num2], "", TextCompare: false) != 0)
					{
						flag5 = false;
					}
					num2++;
				}
				ListViewVR listView = MyProject.Forms.FrmSetDrwlist.ListView1;
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
					if (Operators.CompareString(listView.Items[num6].SubItems[3].Text, "✔", TextCompare: false) == 0)
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
				Statelist.Clear();
				ListViewVR listView2 = MyProject.Forms.FrmSetDrwlist.ListView1;
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
						listView2.Items[num9].SubItems[3].Text = " ";
					}
					Statelist.Add(listView2.Items[num9].SubItems[3].Text);
					filelist.Add(listView2.Items[num9].SubItems[2].Text);
					num9++;
				}
				listView2 = null;
				if (filelist.Count == 0)
				{
					Interaction.MsgBox("Нет файлов для обработки", MsgBoxStyle.Information, "Информация");
					return;
				}
				if ((CheckBox2.Checked && !Directory.Exists(Drwformatpath)) ? true : false)
				{
					Interaction.MsgBox("Путь к формату листа не существует, задайте заново", MsgBoxStyle.Information, "Информация");
					return;
				}
				if ((CheckBox2.Checked && flag5 && filelist.Exists([SpecialName] (string s) => s.EndsWith(".slddrw", StringComparison.OrdinalIgnoreCase))) ? true : false)
				{
					Interaction.MsgBox("Укажите формат листа", MsgBoxStyle.Information, "Информация");
					return;
				}
				if (CheckBox1.Checked)
				{
					if (filelist.Exists([SpecialName] (string s) => s.EndsWith(".slddrw", StringComparison.OrdinalIgnoreCase)))
					{
						if (Operators.CompareString(Drwstandardfile, "", TextCompare: false) == 0)
						{
							Interaction.MsgBox("Укажите стандарт оформления", MsgBoxStyle.Information, "Информация");
							return;
						}
						if (!File.Exists(Drwstandardfile))
						{
							Interaction.MsgBox("Файл стандарта оформления \"" + TextBox1.Text + "\" не найдено", MsgBoxStyle.Information, "Информация");
							return;
						}
					}
					if (filelist.Exists([SpecialName] (string s) => s.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase)))
					{
						if (Operators.CompareString(prtstandardfile, "", TextCompare: false) == 0)
						{
							Interaction.MsgBox("Укажите стандарт оформления", MsgBoxStyle.Information, "Информация");
							return;
						}
						if (!File.Exists(prtstandardfile))
						{
							Interaction.MsgBox("Файл стандарта оформления \"" + TextBox3.Text + "\" не найдено", MsgBoxStyle.Information, "Информация");
							return;
						}
					}
					if (filelist.Exists([SpecialName] (string s) => s.EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase)))
					{
						if (Operators.CompareString(asmstandardfile, "", TextCompare: false) == 0)
						{
							Interaction.MsgBox("Укажите стандарт оформления", MsgBoxStyle.Information, "Информация");
							return;
						}
						if (!File.Exists(asmstandardfile))
						{
							Interaction.MsgBox("Файл стандарта оформления \"" + TextBox4.Text + "\" не найдено", MsgBoxStyle.Information, "Информация");
							return;
						}
					}
				}
				if (((!CheckBox1.Checked && !CheckBox2.Checked && !filelist.Exists([SpecialName] (string s) => s.EndsWith(".slddrw", StringComparison.OrdinalIgnoreCase))) ? true : false) && filelist.Count > 0)
				{
					Interaction.MsgBox("Нет файлов для обработки!", MsgBoxStyle.Information, "Информация");
					return;
				}
				Hide();
				MyProject.Forms.FrmSetDrwlist.ToolStripStatusLabel1.Text = "Осталось" + Conversions.ToString(MyProject.Forms.FrmSetDrwlist.ListView1.Items.Count) + "файлов";
				MyProject.Forms.FrmSetDrwlist.ListView1.MultiSelect = false;
				MyProject.Forms.FrmSetDrwlist.ListView1.Items[0].Selected = true;
				MyProject.Forms.FrmSetDrwlist.ToolStripProgressBar1.Maximum = MyProject.Forms.FrmSetDrwlist.ListView1.Items.Count;
				MyProject.Forms.FrmSetDrwlist.ToolStripProgressBar1.Visible = true;
				MyProject.Forms.FrmSetDrwlist.addfiles.Enabled = false;
				MyProject.Forms.FrmSetDrwlist.clearall.Enabled = false;
				MyProject.Forms.FrmSetDrwlist.clearsel.Enabled = false;
				code.EnablePreview = false;
				MyProject.Forms.FrmSetDrwlist.Switch(1);
				SetDrwBgWorker.WorkerSupportsCancellation = true;
				SetDrwBgWorker.WorkerReportsProgress = true;
				SetDrwBgWorker.RunWorkerAsync();
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

	public void SetDrwBgWorker_DoWork(object sender, DoWorkEventArgs e)
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
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					bool flag = false;
					bool flag2 = false;
					if (SetDrwBgWorker.CancellationPending)
					{
						e.Cancel = true;
						break;
					}
					if (Operators.CompareString(Statelist[num2], "✔", TextCompare: false) != 0)
					{
						Thread.Sleep(5);
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
						if ((swFileTYpe != 3) & !CheckBox1.Checked)
						{
							goto IL_11df;
						}
						if (!code.RunSW(CConfigMng.Config.HideSw1))
						{
							break;
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
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
						{
							object[] array15;
							bool[] array2;
							if (swFileTYpe == 3)
							{
								object instance = NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null);
								object[] array = new object[3] { 154, 0, null };
								object[] array3 = array;
								CheckBox checkBox = CheckBox3;
								array3[2] = checkBox.Checked;
								object[] array4 = array;
								object[] arguments2 = array4;
								array2 = new bool[3] { false, false, true };
								object value = NewLateBinding.LateGet(instance, null, "SetUserPreferenceToggle", arguments2, null, null, array2);
								if (array2[2])
								{
									checkBox.Checked = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[2]), typeof(bool));
								}
								flag2 = Conversions.ToBoolean(value);
								if (flag2)
								{
									flag = true;
								}
								if (RadioButton1.Checked)
								{
									flag2 = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null), null, "SetUserPreferenceInteger", new object[3] { 529, 0, 0 }, null, null, null));
								}
								else if (RadioButton2.Checked)
								{
									flag2 = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null), null, "SetUserPreferenceInteger", new object[3] { 529, 0, 1 }, null, null, null));
								}
								else if (RadioButton3.Checked)
								{
									flag2 = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null), null, "SetUserPreferenceInteger", new object[3] { 529, 0, 2 }, null, null, null));
								}
								else if (RadioButton4.Checked)
								{
									flag2 = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null), null, "SetUserPreferenceInteger", new object[3] { 529, 0, 3 }, null, null, null));
								}
								if (flag2)
								{
									flag = true;
								}
								object obj3 = null;
								obj3 = RuntimeHelpers.GetObjectValue(obj);
								if ((!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj3)) && (CheckBox2.Checked || CheckBox4.Checked)) ? true : false)
								{
									object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, null, "GetSheetNames", new object[0], null, null, null));
									int num5 = Information.UBound((Array)objectValue);
									int num6 = 0;
									int num14;
									while (true)
									{
										int num7 = num6;
										num4 = num5;
										if (num7 > num4)
										{
											break;
										}
										object instance2 = obj3;
										object[] array5 = new object[1] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { num6 }, null)) };
										object[] arguments3 = array5;
										array2 = new bool[1] { true };
										NewLateBinding.LateCall(instance2, null, "ActivateSheet", arguments3, null, null, array2, IgnoreReturn: true);
										if (array2[0])
										{
											NewLateBinding.LateIndexSetComplex(objectValue, new object[2]
											{
												num6,
												RuntimeHelpers.GetObjectValue(array5[0])
											}, null, OptimisticSet: true, RValueBase: false);
										}
										object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, null, "GetCurrentSheet", new object[0], null, null, null));
										if (!Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(objectValue2, null, "IsLoaded", new object[0], null, null, null))))
										{
											object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "GetProperties", new object[0], null, null, null));
											if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
											{
												object left = NewLateBinding.LateIndexGet(objectValue3, new object[1] { 0 }, null);
												if (Operators.ConditionalCompareObjectEqual(left, 6, TextCompare: false))
												{
													Drwformatname = Drwformatpath + newtemplate[0];
												}
												else if (Operators.ConditionalCompareObjectEqual(left, 7, TextCompare: false))
												{
													Drwformatname = Drwformatpath + newtemplate[1];
												}
												else if (Operators.ConditionalCompareObjectEqual(left, 8, TextCompare: false))
												{
													Drwformatname = Drwformatpath + newtemplate[2];
												}
												else if (Operators.ConditionalCompareObjectEqual(left, 9, TextCompare: false))
												{
													Drwformatname = Drwformatpath + newtemplate[3];
												}
												else if (Operators.ConditionalCompareObjectEqual(left, 10, TextCompare: false))
												{
													Drwformatname = Drwformatpath + newtemplate[4];
												}
												else if (Operators.ConditionalCompareObjectEqual(left, 11, TextCompare: false))
												{
													Drwformatname = Drwformatpath + newtemplate[5];
												}
												else
												{
													Drwformatname = Drwformatpath + newtemplate[6];
												}
												if ((File.Exists(Drwformatname) && CheckBox2.Checked) ? true : false)
												{
													NewLateBinding.LateCall(objectValue2, null, "SetTemplateName", new object[1] { code.SplitStr(Drwformatname, 3) + "-1" + code.SplitStr(Drwformatname, 5) }, null, null, null, IgnoreReturn: true);
													object instance3 = obj3;
													object[] array6 = new object[11]
													{
														RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { num6 }, null)),
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
													array5 = new object[1];
													object[] array7 = array5;
													int num8 = 0;
													array7[0] = num8;
													array6[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array5, null));
													array = new object[1];
													object[] array8 = array;
													int num9 = 1;
													array8[0] = num9;
													array6[2] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array, null));
													array4 = new object[1];
													object[] array9 = array4;
													int num10 = 2;
													array9[0] = num10;
													array6[3] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array4, null));
													object[] array10 = new object[1];
													int num11 = 3;
													array10[0] = num11;
													array6[4] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array10, null));
													object[] array11 = new object[1];
													int num12 = 4;
													array11[0] = num12;
													array6[5] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array11, null));
													array6[6] = Drwformatname;
													object[] array12 = new object[1];
													int num13 = 5;
													array12[0] = num13;
													array6[7] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array12, null));
													object[] array13 = new object[1];
													num14 = 6;
													array13[0] = num14;
													array6[8] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue3, array13, null));
													array6[9] = "";
													array6[10] = true;
													object[] array14 = array6;
													array2 = new bool[11]
													{
														true, true, true, true, true, true, true, true, true, false,
														false
													};
													object value2 = NewLateBinding.LateGet(instance3, null, "SetupSheet5", array14, null, null, array2);
													if (array2[0])
													{
														NewLateBinding.LateIndexSetComplex(objectValue, new object[2]
														{
															num6,
															RuntimeHelpers.GetObjectValue(array14[0])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[1])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num8,
															RuntimeHelpers.GetObjectValue(array14[1])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[2])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num9,
															RuntimeHelpers.GetObjectValue(array14[2])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[3])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num10,
															RuntimeHelpers.GetObjectValue(array14[3])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[4])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num11,
															RuntimeHelpers.GetObjectValue(array14[4])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[5])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num12,
															RuntimeHelpers.GetObjectValue(array14[5])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[6])
													{
														Drwformatname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array14[6]), typeof(string));
													}
													if (array2[7])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num13,
															RuntimeHelpers.GetObjectValue(array14[7])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (array2[8])
													{
														NewLateBinding.LateIndexSetComplex(objectValue3, new object[2]
														{
															num14,
															RuntimeHelpers.GetObjectValue(array14[8])
														}, null, OptimisticSet: true, RValueBase: false);
													}
													if (Conversions.ToBoolean(value2))
													{
														flag = true;
													}
													string text = Conversions.ToString(NewLateBinding.LateGet(code.swApp, null, "RevisionNumber", new object[0], null, null, null));
													int num15 = Convert.ToInt32(text.Split('.')[0]);
													if ((num15 >= 24 && NewLateBinding.LateGet(objectValue2, null, "GetTemplateName", new object[0], null, null, null).ToString().Equals(Drwformatname, StringComparison.OrdinalIgnoreCase)) ? true : false)
													{
														NewLateBinding.LateCall(objectValue2, null, "ReloadTemplate", new object[1] { false }, null, null, null, IgnoreReturn: true);
													}
												}
											}
											if (CheckBox4.Checked)
											{
												SelectDanglingAnnotation(RuntimeHelpers.GetObjectValue(obj), RuntimeHelpers.GetObjectValue(objectValue2));
											}
											NewLateBinding.LateCall(obj, null, "ViewZoomtofit2", new object[0], null, null, null, IgnoreReturn: true);
										}
										num6++;
									}
									object instance4 = obj3;
									array15 = new object[1];
									object[] array16 = array15;
									object[] array17 = new object[1];
									object[] array18 = array17;
									num14 = 0;
									array18[0] = num14;
									array16[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, array17, null));
									object[] array19 = array15;
									object[] arguments4 = array19;
									array2 = new bool[1] { true };
									NewLateBinding.LateCall(instance4, null, "ActivateSheet", arguments4, null, null, array2, IgnoreReturn: true);
									if (array2[0])
									{
										NewLateBinding.LateIndexSetComplex(objectValue, new object[2]
										{
											num14,
											RuntimeHelpers.GetObjectValue(array19[0])
										}, null, OptimisticSet: true, RValueBase: false);
									}
								}
							}
							if ((CheckBox1.Checked && swFileTYpe == 3 && File.Exists(Drwstandardfile)) ? true : false)
							{
								object instance5 = NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null);
								array15 = new object[1] { Drwstandardfile };
								object[] arguments5 = array15;
								array2 = new bool[1] { true };
								object value3 = NewLateBinding.LateGet(instance5, null, "LoadDraftingStandard", arguments5, null, null, array2);
								if (array2[0])
								{
									Drwstandardfile = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array15[0]), typeof(string));
								}
								if (Conversions.ToBoolean(value3))
								{
									flag = true;
								}
							}
							else if ((CheckBox1.Checked && swFileTYpe == 1 && File.Exists(prtstandardfile)) ? true : false)
							{
								object instance6 = NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null);
								array15 = new object[1] { prtstandardfile };
								object[] arguments6 = array15;
								array2 = new bool[1] { true };
								object value4 = NewLateBinding.LateGet(instance6, null, "LoadDraftingStandard", arguments6, null, null, array2);
								if (array2[0])
								{
									prtstandardfile = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array15[0]), typeof(string));
								}
								if (Conversions.ToBoolean(value4))
								{
									flag = true;
								}
							}
							else if ((CheckBox1.Checked && swFileTYpe == 2 && File.Exists(asmstandardfile)) ? true : false)
							{
								object instance7 = NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null);
								array15 = new object[1] { asmstandardfile };
								object[] arguments7 = array15;
								array2 = new bool[1] { true };
								object value5 = NewLateBinding.LateGet(instance7, null, "LoadDraftingStandard", arguments7, null, null, array2);
								if (array2[0])
								{
									asmstandardfile = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array15[0]), typeof(string));
								}
								if (Conversions.ToBoolean(value5))
								{
									flag = true;
								}
							}
							NewLateBinding.LateCall(obj, null, "SetFeatureManagerWidth", new object[1] { Operators.DivideObject(NewLateBinding.LateGet(code.swApp, null, "FrameWidth", new object[0], null, null, null), 5) }, null, null, null, IgnoreReturn: true);
							NewLateBinding.LateCall(obj, null, "ForceRebuild3", new object[1] { false }, null, null, null, IgnoreReturn: true);
							object instance8 = obj;
							array15 = new object[3] { 1, longstatus, longwarnings };
							object[] arguments8 = array15;
							array2 = new bool[3] { false, true, true };
							NewLateBinding.LateCall(instance8, null, "Save3", arguments8, null, null, array2, IgnoreReturn: true);
							if (array2[1])
							{
								longstatus = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array15[1]), typeof(int));
							}
							if (array2[2])
							{
								longwarnings = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array15[2]), typeof(int));
							}
							object swApp2 = code.swApp;
							array15 = new object[1] { FilePathName };
							object[] arguments9 = array15;
							array2 = new bool[1] { true };
							NewLateBinding.LateCall(swApp2, null, "CloseDoc", arguments9, null, null, array2, IgnoreReturn: true);
							if (array2[0])
							{
								FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array15[0]), typeof(string));
							}
							obj = null;
						}
					}
					SetDrwBgWorker.ReportProgress(num2, flag);
					goto IL_11df;
					IL_11df:
					num2++;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				er = true;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void SetDrwBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
						MyProject.Forms.FrmSetDrwlist.ListView1.Items[e.ProgressPercentage].SubItems[3].Text = "✔";
						MyProject.Forms.FrmSetDrwlist.ListView1.Items[e.ProgressPercentage].SubItems[3].ForeColor = Color.Blue;
					}
					MyProject.Forms.FrmSetDrwlist.ListView1.Items[e.ProgressPercentage].Selected = true;
					MyProject.Forms.FrmSetDrwlist.ListView1.Items[e.ProgressPercentage].EnsureVisible();
					MyProject.Forms.FrmSetDrwlist.ToolStripProgressBar1.Value = e.ProgressPercentage + 1;
					MyProject.Forms.FrmSetDrwlist.ToolStripStatusLabel1.Text = "Осталось" + Conversions.ToString(MyProject.Forms.FrmSetDrwlist.ListView1.Items.Count - 1 - e.ProgressPercentage) + "файлов";
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

	private void SetDrwBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			code.RunSW(HideWindow: false, startnew: false);
			MyProject.Forms.FrmSetDrwlist.addfiles.Enabled = true;
			MyProject.Forms.FrmSetDrwlist.clearall.Enabled = true;
			MyProject.Forms.FrmSetDrwlist.clearsel.Enabled = true;
			code.EnablePreview = true;
			MyProject.Forms.FrmSetDrwlist.ListView1.MultiSelect = true;
			MyProject.Forms.FrmSetDrwlist.ToolStripProgressBar1.Visible = false;
			MyProject.Forms.FrmSetDrwlist.ToolStripProgressBar1.Value = 0;
			if (er)
			{
				er = false;
				MyProject.Forms.FrmSetDrwlist.Switch(4);
			}
			else if (!e.Cancelled)
			{
				MyProject.Forms.FrmSetDrwlist.Switch(2);
			}
			else
			{
				MyProject.Forms.FrmSetDrwlist.Switch(3);
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

	public void Modifyunit(object swModelDocExt)
	{
		try
		{
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", new object[3] { 263, 0, 5 }, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", new object[3] { 263, 0, 4 }, null, null, null, IgnoreReturn: true);
			object[] array = new object[3]
			{
				47,
				0,
				code.Basic_Length
			};
			object[] arguments = array;
			bool[] array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Basic_Length = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(int));
			}
			object[] array3 = new object[3]
			{
				49,
				0,
				code.Basic_Length_Decimals
			};
			object[] arguments2 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments2, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Basic_Length_Decimals = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				254,
				0,
				code.Basic_DualDimension
			};
			object[] arguments3 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments3, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Basic_DualDimension = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				256,
				0,
				code.Basic_DualDimension_Decimals
			};
			object[] arguments4 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments4, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Basic_DualDimension_Decimals = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				51,
				0,
				code.Basic_Angle
			};
			object[] arguments5 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments5, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Basic_Angle = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				52,
				0,
				code.Basic_Angle_Decimals
			};
			object[] arguments6 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments6, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Basic_Angle_Decimals = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				258,
				0,
				code.Mass_Length
			};
			object[] arguments7 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments7, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Mass_Length = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				259,
				0,
				code.Mass_Mass
			};
			object[] arguments8 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments8, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Mass_Mass = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				260,
				0,
				code.Mass_Volume
			};
			object[] arguments9 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments9, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Mass_Volume = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				261,
				0,
				code.Mass_Decimals
			};
			object[] arguments10 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments10, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Mass_Decimals = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				337,
				0,
				code.Motion_Time
			};
			object[] arguments11 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments11, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Time = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				262,
				0,
				code.Motion_Force
			};
			object[] arguments12 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments12, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Force = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				335,
				0,
				code.Motion_Power
			};
			object[] arguments13 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments13, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Power = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				333,
				0,
				code.Motion_Energy
			};
			object[] arguments14 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments14, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Energy = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				338,
				0,
				code.Motion_Time_Decimal
			};
			object[] arguments15 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments15, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Time_Decimal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				332,
				0,
				code.Motion_Force_Decimal
			};
			object[] arguments16 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments16, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Force_Decimal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				336,
				0,
				code.Motion_Power_Decimal
			};
			object[] arguments17 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments17, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Power_Decimal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				334,
				0,
				code.Motion_Energy_Decimal
			};
			object[] arguments18 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments18, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.Motion_Energy_Decimal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			array3 = new object[3]
			{
				263,
				0,
				code.UnitsSystem
			};
			object[] arguments19 = array3;
			array2 = new bool[3] { false, false, true };
			NewLateBinding.LateCall(swModelDocExt, null, "SetUserPreferenceInteger", arguments19, null, null, array2, IgnoreReturn: true);
			if (array2[2])
			{
				code.UnitsSystem = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public bool SelectDanglingAnnotation(object swDoc, object swsheet)
	{
		bool result;
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(swsheet)) || (Information.IsNothing(RuntimeHelpers.GetObjectValue(swsheet)) ? true : false))
		{
			result = false;
		}
		else
		{
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swsheet, null, "GetViews", new object[0], null, null, null));
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				result = false;
			}
			else
			{
				NewLateBinding.LateCall(swDoc, null, "ClearSelection", new object[0], null, null, null, IgnoreReturn: true);
				try
				{
					foreach (object item in (IEnumerable)objectValue)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(item);
						object objectValue3 = RuntimeHelpers.GetObjectValue(objectValue2);
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
						{
							continue;
						}
						object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "GetFirstDisplayDimension5", new object[0], null, null, null));
						while (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
						{
							object objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue4, null, "GetAnnotation", new object[0], null, null, null));
							if (Conversions.ToBoolean((!Conversions.ToBoolean(!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue5))) || !Conversions.ToBoolean(NewLateBinding.LateGet(objectValue5, null, "IsDangling", new object[0], null, null, null))) ? ((object)false) : ((object)true)))
							{
								NewLateBinding.LateCall(objectValue5, null, "Select2", new object[2] { true, -1 }, null, null, null, IgnoreReturn: true);
							}
							objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue4, null, "GetNext3", new object[0], null, null, null));
						}
					}
					NewLateBinding.LateCall(swDoc, null, "EditDelete", new object[0], null, null, null, IgnoreReturn: true);
					result = true;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					result = false;
					ProjectData.ClearProjectError();
				}
			}
		}
		return result;
	}

	private void Savecfg()
	{
		try
		{
			CConfigMng.Config.SetDrwCfg.Clear();
			foreach (Control control in Controls)
			{
				FindctlToSave(control);
			}
			CConfigMng.Config.DrawPaperOther = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 6].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 6].Value)));
			CConfigMng.Config.DrawPaperA0 = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 5].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 5].Value)));
			CConfigMng.Config.DrawPaperA1 = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 4].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 4].Value)));
			CConfigMng.Config.DrawPaperA2 = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 3].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 3].Value)));
			CConfigMng.Config.DrawPaperA3 = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 2].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 2].Value)));
			CConfigMng.Config.DrawPaperA4V = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 1].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 1].Value)));
			CConfigMng.Config.DrawPaperA4H = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DGV1[1, 0].Value)), "", RuntimeHelpers.GetObjectValue(DGV1[1, 0].Value)));
			CConfigMng.Config.HideSw1 = HideSw1.Checked;
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
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.SetDrwCfg.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.SetDrwCfg.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.SetDrwCfg.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.SetDrwCfg.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		try
		{
			foreach (Control control in Controls)
			{
				FindctlToLoad(control);
			}
			if (!File.Exists(TextBox1.Text))
			{
				TextBox1.Clear();
			}
			if (!Directory.Exists(TextBox2.Text))
			{
				TextBox2.Clear();
			}
			else
			{
				getfiles();
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperOther))
				{
					DGV1[1, 6].Value = CConfigMng.Config.DrawPaperOther;
				}
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperA0))
				{
					DGV1[1, 5].Value = CConfigMng.Config.DrawPaperA0;
				}
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperA1))
				{
					DGV1[1, 4].Value = CConfigMng.Config.DrawPaperA1;
				}
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperA2))
				{
					DGV1[1, 3].Value = CConfigMng.Config.DrawPaperA2;
				}
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperA3))
				{
					DGV1[1, 2].Value = CConfigMng.Config.DrawPaperA3;
				}
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperA4V))
				{
					DGV1[1, 1].Value = CConfigMng.Config.DrawPaperA4V;
				}
				if (File.Exists(TextBox2.Text + "\\" + CConfigMng.Config.DrawPaperA4H))
				{
					DGV1[1, 0].Value = CConfigMng.Config.DrawPaperA4H;
				}
				DGV1.Refresh();
			}
			HideSw1.Checked = CConfigMng.Config.HideSw1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
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
				int num7;
				int num8;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000a;
				case 545:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
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
							goto IL_00db;
						case 13:
							goto IL_00ee;
						case 15:
							goto IL_0114;
						case 16:
							goto IL_0127;
						case 8:
						case 11:
						case 14:
						case 17:
						case 18:
						case 19:
							goto IL_0141;
						case 20:
							goto IL_0156;
						case 21:
							goto IL_0166;
						case 22:
						case 23:
							goto IL_0173;
						default:
							goto end_IL_0001;
						case 24:
							goto end_IL_0001_2;
						}
						goto default;
					}
					IL_00c6:
					num2 = 10;
					((TextBox)control).Text = array[1];
					goto IL_0141;
					IL_00db:
					num2 = 12;
					if (control is ComboBox)
					{
						goto IL_00ee;
					}
					goto IL_0114;
					IL_00b3:
					num2 = 9;
					if (control is TextBox)
					{
						goto IL_00c6;
					}
					goto IL_00db;
					IL_00ee:
					num2 = 13;
					((ComboBox)control).SelectedIndex = Conversions.ToInteger(newtemplate[Conversions.ToInteger(array[1])]);
					goto IL_0141;
					IL_000a:
					num2 = 2;
					enumerator = parent.Controls.GetEnumerator();
					goto IL_0178;
					IL_0178:
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
					IL_0114:
					num2 = 15;
					if (control is RadioButton)
					{
						goto IL_0127;
					}
					goto IL_0141;
					IL_0141:
					num2 = 19;
					num5 = checked(num5 + 1);
					goto IL_014a;
					IL_0127:
					num2 = 16;
					((RadioButton)control).Checked = code.Cbool1(array[1]);
					goto IL_0141;
					IL_002a:
					num2 = 3;
					num6 = checked(CConfigMng.Config.SetDrwCfg.Count - 1);
					num5 = 0;
					goto IL_014a;
					IL_014a:
					num7 = num5;
					num8 = num6;
					if (num7 <= num8)
					{
						goto IL_0047;
					}
					goto IL_0156;
					IL_0156:
					num2 = 20;
					if (control.HasChildren)
					{
						goto IL_0166;
					}
					goto IL_0173;
					IL_0166:
					num2 = 21;
					FindctlToLoad(control);
					goto IL_0173;
					IL_0173:
					num2 = 23;
					goto IL_0178;
					IL_0047:
					num2 = 4;
					array = Strings.Split(CConfigMng.Config.SetDrwCfg[num5], "\n");
					goto IL_0067;
					IL_0067:
					num2 = 5;
					if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
					{
						goto IL_0085;
					}
					goto IL_0141;
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
					goto IL_0141;
					end_IL_0001:
					break;
				}
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 545;
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
