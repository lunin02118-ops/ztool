using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class Frmsetpropname : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__68
	{
		public string _0024VB_0024Local_propname;

		[DebuggerNonUserCode]
		public _Closure_0024__68(_Closure_0024__68 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_propname = other._0024VB_0024Local_propname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__68()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__125(string s)
		{
			return s.Equals(_0024VB_0024Local_propname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__69
	{
		public string _0024VB_0024Local_propname;

		[DebuggerNonUserCode]
		public _Closure_0024__69(_Closure_0024__69 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_propname = other._0024VB_0024Local_propname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__69()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__126(string s)
		{
			return s.Equals(_0024VB_0024Local_propname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__70
	{
		public string _0024VB_0024Local_propname;

		[DebuggerNonUserCode]
		public _Closure_0024__70(_Closure_0024__70 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_propname = other._0024VB_0024Local_propname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__70()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__127(string s)
		{
			return s.Equals(_0024VB_0024Local_propname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__71
	{
		public string _0024VB_0024Local_propname;

		[DebuggerNonUserCode]
		public _Closure_0024__71(_Closure_0024__71 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_propname = other._0024VB_0024Local_propname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__71()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__128(string s)
		{
			return s.Equals(_0024VB_0024Local_propname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__72
	{
		public string _0024VB_0024Local_PropName;

		[DebuggerNonUserCode]
		public _Closure_0024__72()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__72(_Closure_0024__72 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_PropName = other._0024VB_0024Local_PropName;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__129(string s)
		{
			return s.Equals(_0024VB_0024Local_PropName, StringComparison.OrdinalIgnoreCase);
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

	[AccessedThroughProperty("DGV1")]
	private DataGridView _DGV1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("col_propname")]
	private DataGridViewTextBoxColumn _col_propname;

	[AccessedThroughProperty("col_proptype")]
	private DataGridViewComboBoxColumn _col_proptype;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Menu1")]
	private ContextMenuStrip _Menu1;

	[AccessedThroughProperty("AddPropertyNamesFromfile")]
	private ToolStripMenuItem _AddPropertyNamesFromfile;

	[AccessedThroughProperty("AddPropertyNamesFromFolder")]
	private ToolStripMenuItem _AddPropertyNamesFromFolder;

	[AccessedThroughProperty("AddPropertyNamesFromsw")]
	private ToolStripMenuItem _AddPropertyNamesFromsw;

	[AccessedThroughProperty("AddPropertyNamesFromprp")]
	private ToolStripMenuItem _AddPropertyNamesFromprp;

	private string oldval;

	private double dpixRatio;

	private Color mLinearColor1;

	private Color mLinearColor2;

	private int selectionIdx;

	public MySWDM MySWDM;

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
			DataGridViewCellEventHandler value3 = DGV1_CellValueChanged;
			DataGridViewRowsAddedEventHandler value4 = DGV1_RowsAdded;
			DataGridViewCellCancelEventHandler value5 = DGV1_CellBeginEdit;
			DragEventHandler value6 = DGV1_DragDrop;
			DataGridViewDataErrorEventHandler value7 = DGV1_DataError;
			DataGridViewCellMouseEventHandler value8 = DGV1_CellMouseMove;
			DragEventHandler value9 = DGV1_DragEnter;
			DataGridViewCellPaintingEventHandler value10 = DGV1_CellPainting;
			if (_DGV1 != null)
			{
				_DGV1.CellEnter -= value2;
				_DGV1.CellValueChanged -= value3;
				_DGV1.RowsAdded -= value4;
				_DGV1.CellBeginEdit -= value5;
				_DGV1.DragDrop -= value6;
				_DGV1.DataError -= value7;
				_DGV1.CellMouseMove -= value8;
				_DGV1.DragEnter -= value9;
				_DGV1.CellPainting -= value10;
			}
			_DGV1 = value;
			if (_DGV1 != null)
			{
				_DGV1.CellEnter += value2;
				_DGV1.CellValueChanged += value3;
				_DGV1.RowsAdded += value4;
				_DGV1.CellBeginEdit += value5;
				_DGV1.DragDrop += value6;
				_DGV1.DataError += value7;
				_DGV1.CellMouseMove += value8;
				_DGV1.DragEnter += value9;
				_DGV1.CellPainting += value10;
			}
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

	internal virtual DataGridViewTextBoxColumn col_propname
	{
		[DebuggerNonUserCode]
		get
		{
			return _col_propname;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_col_propname = value;
		}
	}

	internal virtual DataGridViewComboBoxColumn col_proptype
	{
		[DebuggerNonUserCode]
		get
		{
			return _col_proptype;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_col_proptype = value;
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

	internal virtual ContextMenuStrip Menu1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Menu1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Menu1 = value;
		}
	}

	internal virtual ToolStripMenuItem AddPropertyNamesFromfile
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddPropertyNamesFromfile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddPropertyNamesFromfile_Click;
			if (_AddPropertyNamesFromfile != null)
			{
				_AddPropertyNamesFromfile.Click -= value2;
			}
			_AddPropertyNamesFromfile = value;
			if (_AddPropertyNamesFromfile != null)
			{
				_AddPropertyNamesFromfile.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddPropertyNamesFromFolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddPropertyNamesFromFolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddPropertyNamesFromFolder_Click;
			if (_AddPropertyNamesFromFolder != null)
			{
				_AddPropertyNamesFromFolder.Click -= value2;
			}
			_AddPropertyNamesFromFolder = value;
			if (_AddPropertyNamesFromFolder != null)
			{
				_AddPropertyNamesFromFolder.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddPropertyNamesFromsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddPropertyNamesFromsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddPropertyNamesFromsw_Click;
			if (_AddPropertyNamesFromsw != null)
			{
				_AddPropertyNamesFromsw.Click -= value2;
			}
			_AddPropertyNamesFromsw = value;
			if (_AddPropertyNamesFromsw != null)
			{
				_AddPropertyNamesFromsw.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddPropertyNamesFromprp
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddPropertyNamesFromprp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddPropertyNamesFromprp_Click;
			if (_AddPropertyNamesFromprp != null)
			{
				_AddPropertyNamesFromprp.Click -= value2;
			}
			_AddPropertyNamesFromprp = value;
			if (_AddPropertyNamesFromprp != null)
			{
				_AddPropertyNamesFromprp.Click += value2;
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.DGV1 = new System.Windows.Forms.DataGridView();
		this.col_propname = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.col_proptype = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.Label1 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.Menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.AddPropertyNamesFromfile = new System.Windows.Forms.ToolStripMenuItem();
		this.AddPropertyNamesFromFolder = new System.Windows.Forms.ToolStripMenuItem();
		this.AddPropertyNamesFromsw = new System.Windows.Forms.ToolStripMenuItem();
		this.AddPropertyNamesFromprp = new System.Windows.Forms.ToolStripMenuItem();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		this.Menu1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.21212f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.78788f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(145, 365);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(165, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(8, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(68, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "ОК";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(90, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(68, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.DGV1.AllowDrop = true;
		this.DGV1.AllowUserToAddRows = false;
		this.DGV1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.DGV1.BackgroundColor = System.Drawing.SystemColors.Window;
		this.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.MenuText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.DGV1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		this.DGV1.Columns.AddRange(this.col_propname, this.col_proptype);
		this.DGV1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		System.Windows.Forms.DataGridView dGV = this.DGV1;
		location = new System.Drawing.Point(0, 0);
		dGV.Location = location;
		this.DGV1.Name = "DGV1";
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		this.DGV1.RowHeadersWidth = 30;
		this.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.DGV1.RowTemplate.Height = 23;
		this.DGV1.ShowEditingIcon = false;
		System.Windows.Forms.DataGridView dGV2 = this.DGV1;
		size = new System.Drawing.Size(324, 332);
		dGV2.Size = size;
		this.DGV1.TabIndex = 0;
		this.col_propname.Frozen = true;
		this.col_propname.HeaderText = "Имя свойства";
		this.col_propname.MinimumWidth = 180;
		this.col_propname.Name = "col_propname";
		this.col_propname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.col_propname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.col_propname.Width = 180;
		this.col_proptype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.col_proptype.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
		this.col_proptype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.col_proptype.HeaderText = "Тип";
		this.col_proptype.Items.AddRange("Текст", "Дата", "Число", "Да или нет");
		this.col_proptype.Name = "col_proptype";
		this.col_proptype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Label1.AutoSize = true;
		this.Label1.ForeColor = System.Drawing.Color.Green;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(2, 336);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(314, 17);
		label2.Size = size;
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Перетаскивайте заголовок строки для сортировки; выберите заголовок и нажмите Del для удаления всей строки.";
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button1.AutoSize = true;
		this.Button1.ContextMenuStrip = this.Menu1;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(8, 368);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(64, 27);
		button2.Size = size;
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Импорт...";
		this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.AddPropertyNamesFromfile, this.AddPropertyNamesFromFolder, this.AddPropertyNamesFromsw, this.AddPropertyNamesFromprp });
		this.Menu1.Name = "Menu1";
		this.Menu1.ShowImageMargin = false;
		System.Windows.Forms.ContextMenuStrip menu = this.Menu1;
		size = new System.Drawing.Size(259, 114);
		menu.Size = size;
		this.AddPropertyNamesFromfile.Name = "AddPropertyNamesFromfile";
		System.Windows.Forms.ToolStripMenuItem addPropertyNamesFromfile = this.AddPropertyNamesFromfile;
		size = new System.Drawing.Size(258, 22);
		addPropertyNamesFromfile.Size = size;
		this.AddPropertyNamesFromfile.Text = "Получить из файла";
		this.AddPropertyNamesFromFolder.Name = "AddPropertyNamesFromFolder";
		System.Windows.Forms.ToolStripMenuItem addPropertyNamesFromFolder = this.AddPropertyNamesFromFolder;
		size = new System.Drawing.Size(258, 22);
		addPropertyNamesFromFolder.Size = size;
		this.AddPropertyNamesFromFolder.Text = "Получить из папки";
		this.AddPropertyNamesFromsw.Name = "AddPropertyNamesFromsw";
		System.Windows.Forms.ToolStripMenuItem addPropertyNamesFromsw = this.AddPropertyNamesFromsw;
		size = new System.Drawing.Size(258, 22);
		addPropertyNamesFromsw.Size = size;
		this.AddPropertyNamesFromsw.Text = "Получить из открытых в SolidWorks компонентов";
		this.AddPropertyNamesFromprp.Name = "AddPropertyNamesFromprp";
		System.Windows.Forms.ToolStripMenuItem addPropertyNamesFromprp = this.AddPropertyNamesFromprp;
		size = new System.Drawing.Size(258, 22);
		addPropertyNamesFromprp.Size = size;
		this.AddPropertyNamesFromprp.Text = "Получить из шаблона свойств SolidWorks";
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(322, 402);
		this.ClientSize = size;
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.DGV1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "Frmsetpropname";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Задать имя свойства";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		this.Menu1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		SavePropName();
		MyProject.Forms.Frmmain.SaveColumnInfo();
		MyProject.Forms.Frmmain.insetpropcol();
		MyProject.Forms.Frmmain.LoadColumnInfo();
		MyProject.Forms.Frmmain.refreshlist();
		Close();
	}

	public void SavePropName()
	{
		checked
		{
			try
			{
				CConfigMng.Config.propname.Clear();
				CConfigMng.Config.proptype.Clear();
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
					string text = "";
					string text2 = "";
					text = Conversions.ToString(DGV1[col_propname.Index, num2].Value);
					text2 = Conversions.ToString(DGV1[col_proptype.Index, num2].Value);
					if (Operators.CompareString(text, "", TextCompare: false) != 0)
					{
						CConfigMng.Config.propname.Add(text);
						CConfigMng.Config.proptype.Add(text2);
					}
					num2++;
				}
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
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	public Frmsetpropname()
	{
		base.Load += Frmsetpropname_Load;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		mLinearColor1 = Color.FromArgb(240, 240, 240);
		mLinearColor2 = Color.FromArgb(240, 240, 240);
		selectionIdx = 0;
		MySWDM = new MySWDM();
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
				if (num3 > num4)
				{
					break;
				}
				DGV1.Columns[num2].Width = (int)Math.Round((double)DGV1.Columns[num2].Width * dpixRatio);
				num2++;
			}
			DGV1.RowHeadersWidth = (int)Math.Round((double)DGV1.RowHeadersWidth * dpixRatio);
			DGV1.ColumnHeadersHeight = (int)Math.Round((double)DGV1.ColumnHeadersHeight * dpixRatio);
		}
	}

	private void Frmsetpropname_Load(object sender, EventArgs e)
	{
		StartPosition = FormStartPosition.CenterScreen;
		DGV1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
		DGV1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
		DGV1.MultiSelect = true;
		DGV1.ShowEditingIcon = false;
		DGV1.AllowUserToOrderColumns = true;
		DGV1.AllowUserToResizeRows = false;
		DGV1.AllowUserToOrderColumns = true;
		DGV1.EnableHeadersVisualStyles = false;
		DGV1.RowHeadersVisible = true;
		checked
		{
			try
			{
				DGV1.AllowUserToAddRows = true;
				DGV1.Rows.Clear();
				DGV1.RowCount = 1;
				if (CConfigMng.Config.propname.Count < 1)
				{
					return;
				}
				int num = CConfigMng.Config.propname.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						string text = CConfigMng.Config.propname[num2];
						string str = CConfigMng.Config.proptype[num2];
						if (Operators.CompareString(text, "", TextCompare: false) != 0)
						{
							DGV1.Rows.Add();
							DGV1[col_propname.Index, num2].Value = text;
							DGV1[col_proptype.Index, num2].Value = Strings.Trim(str);
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
				return;
			}
			DGV1.ClearSelection();
		}
	}

	private void DGV1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
	{
		checked
		{
			Rectangle rect = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, mLinearColor1, mLinearColor2, LinearGradientMode.Vertical);
			try
			{
				if (e.RowIndex == -1)
				{
					e.Graphics.FillRectangle(linearGradientBrush, rect);
					e.PaintContent(e.CellBounds);
					ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);
					e.Handled = true;
				}
				if ((e.ColumnIndex < 0) & (e.RowIndex >= 0))
				{
					e.Graphics.FillRectangle(linearGradientBrush, rect);
					e.PaintContent(e.CellBounds);
					ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);
					Rectangle cellBounds = e.CellBounds;
					cellBounds.Inflate(-2, -2);
					TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, cellBounds, e.CellStyle.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
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
				linearGradientBrush?.Dispose();
			}
		}
	}

	private void DGV1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		if ((e.ColumnIndex == 1 && dataGridView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) ? true : false)
		{
			SendKeys.Send("{F4}");
		}
	}

	private void DGV1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		oldval = Conversions.ToString(DGV1[e.ColumnIndex, e.RowIndex].Value);
	}

	private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		checked
		{
			try
			{
				if (Operators.ConditionalCompareObjectNotEqual(DGV1[col_propname.Index, e.RowIndex].Value, "", TextCompare: false))
				{
					if (Operators.ConditionalCompareObjectEqual(DGV1[col_proptype.Index, e.RowIndex].Value, "", TextCompare: false))
					{
						DGV1[col_proptype.Index, e.RowIndex].Value = "Текст";
					}
				}
				else
				{
					DGV1[col_proptype.Index, e.RowIndex].Value = "";
				}
				string text = Conversions.ToString(DGV1[col_propname.Index, e.RowIndex].Value);
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
					string a = Conversions.ToString(DGV1[col_propname.Index, num2].Value);
					if (string.Equals(a, text, StringComparison.OrdinalIgnoreCase) & (num2 != e.RowIndex))
					{
						if (Operators.CompareString(text, "", TextCompare: false) != 0)
						{
							MessageBox.Show(this, "\"" + text + "» — повторяющееся имя свойства", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						DGV1[col_propname.Index, e.RowIndex].Value = oldval;
						DGV1.CancelEdit();
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
		}
	}

	private void DGV1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		e.Cancel = true;
	}

	private void DGV1_DragEnter(object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.Move;
	}

	private void DGV1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (((e.Clicks < 2) & (e.Button == MouseButtons.Left)) && ((e.ColumnIndex == -1) & (e.RowIndex > -1)))
		{
			DGV1.DoDragDrop(DGV1.Rows[e.RowIndex], DragDropEffects.Move);
		}
	}

	private void DGV1_DragDrop(object sender, DragEventArgs e)
	{
		int rowFromPoint = GetRowFromPoint(e.X, e.Y);
		if (rowFromPoint >= 0 && !Operators.ConditionalCompareObjectEqual(DGV1[col_propname.Index, rowFromPoint].Value, "", TextCompare: false) && e.Data.GetDataPresent(typeof(DataGridViewRow)))
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
			DGV1.Rows.Remove(dataGridViewRow);
			selectionIdx = rowFromPoint;
			DGV1.Rows.Insert(rowFromPoint, dataGridViewRow);
		}
	}

	public int GetRowFromPoint(int x, int y)
	{
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
				Rectangle rowDisplayRectangle = DGV1.GetRowDisplayRectangle(num2, cutOverflow: false);
				if (DGV1.RectangleToScreen(rowDisplayRectangle).Contains(x, y))
				{
					return num2;
				}
				num2++;
			}
			return -1;
		}
	}

	private void DGV1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		if (selectionIdx > -1)
		{
			DGV1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
			DGV1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
			DGV1.ClearSelection();
			DGV1.Rows[e.RowIndex].Selected = true;
		}
	}

	private void AddPropertyNamesFromfile_Click(object sender, EventArgs e)
	{
		if (!MySWDM.isok)
		{
			MessageBox.Show(MySWDM.err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		List<string> propertyNames = MySWDM.GetPropertyNames1();
		if (propertyNames.Count == 0 && Operators.CompareString(Strings.Trim(MySWDM.err), "", TextCompare: false) != 0)
		{
			MessageBox.Show(MySWDM.err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__68 closure_0024__ = default(_Closure_0024__68);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__68(closure_0024__);
				closure_0024__._0024VB_0024Local_propname = Conversions.ToString(DGV1[col_propname.Index, num2].Value);
				int num5 = propertyNames.FindIndex(closure_0024__._Lambda_0024__125);
				if (num5 >= 0)
				{
					propertyNames.RemoveAt(num5);
				}
				num2++;
			}
			int num6 = DGV1.RowCount - 1;
			int num7 = propertyNames.Count - 1;
			int num8 = 0;
			while (true)
			{
				int num9 = num8;
				int num4 = num7;
				if (num9 <= num4)
				{
					if (Operators.CompareString(propertyNames[num8], "", TextCompare: false) != 0)
					{
						DGV1.Rows.Add();
						DGV1[col_propname.Index, num6].Value = propertyNames[num8];
						DGV1[col_proptype.Index, num6].Value = "Текст";
						num6++;
					}
					num8++;
					continue;
				}
				break;
			}
		}
	}

	private void AddPropertyNamesFromFolder_Click(object sender, EventArgs e)
	{
		if (!MySWDM.isok)
		{
			MessageBox.Show(MySWDM.err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		List<string> propertyNames = MySWDM.GetPropertyNames2();
		if (propertyNames.Count == 0 && Operators.CompareString(Strings.Trim(MySWDM.err), "", TextCompare: false) != 0)
		{
			MessageBox.Show(MySWDM.err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__69 closure_0024__ = default(_Closure_0024__69);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__69(closure_0024__);
				closure_0024__._0024VB_0024Local_propname = Conversions.ToString(DGV1[col_propname.Index, num2].Value);
				int num5 = propertyNames.FindIndex(closure_0024__._Lambda_0024__126);
				if (num5 >= 0)
				{
					propertyNames.RemoveAt(num5);
				}
				num2++;
			}
			int num6 = DGV1.RowCount - 1;
			int num7 = propertyNames.Count - 1;
			int num8 = 0;
			while (true)
			{
				int num9 = num8;
				int num4 = num7;
				if (num9 <= num4)
				{
					if (Operators.CompareString(propertyNames[num8], "", TextCompare: false) != 0)
					{
						DGV1.Rows.Add();
						DGV1[col_propname.Index, num6].Value = propertyNames[num8];
						DGV1[col_proptype.Index, num6].Value = "Текст";
						num6++;
					}
					num8++;
					continue;
				}
				break;
			}
		}
	}

	private void AddPropertyNamesFromsw_Click(object sender, EventArgs e)
	{
		List<string> propertyNames = MySWDM.GetPropertyNames3();
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__70 closure_0024__ = default(_Closure_0024__70);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__70(closure_0024__);
				closure_0024__._0024VB_0024Local_propname = Conversions.ToString(DGV1[col_propname.Index, num2].Value);
				int num5 = propertyNames.FindIndex(closure_0024__._Lambda_0024__127);
				if (num5 >= 0)
				{
					propertyNames.RemoveAt(num5);
				}
				num2++;
			}
			int num6 = DGV1.RowCount - 1;
			int num7 = propertyNames.Count - 1;
			int num8 = 0;
			while (true)
			{
				int num9 = num8;
				int num4 = num7;
				if (num9 <= num4)
				{
					if (Operators.CompareString(propertyNames[num8], "", TextCompare: false) != 0)
					{
						DGV1.Rows.Add();
						DGV1[col_propname.Index, num6].Value = propertyNames[num8];
						DGV1[col_proptype.Index, num6].Value = "Текст";
						num6++;
					}
					num8++;
					continue;
				}
				break;
			}
		}
	}

	private void AddPropertyNamesFromprp_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Шаблон свойств (*.prtprp;*.asmprp)|*.prtprp;*.asmprp";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string fileName = openFileDialog.FileName;
		XDocument xDocument = null;
		if (File.Exists(fileName))
		{
			xDocument = XDocument.Load(fileName);
		}
		List<string> list = new List<string>();
		if (!Information.IsNothing(xDocument))
		{
			try
			{
				getproparr(xDocument.Root.Elements(), list);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			xDocument = null;
		}
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__71 closure_0024__ = default(_Closure_0024__71);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__71(closure_0024__);
				closure_0024__._0024VB_0024Local_propname = Conversions.ToString(DGV1[col_propname.Index, num2].Value);
				int num5 = list.FindIndex(closure_0024__._Lambda_0024__128);
				if (num5 >= 0)
				{
					list.RemoveAt(num5);
				}
				num2++;
			}
			int num6 = DGV1.RowCount - 1;
			int num7 = list.Count - 1;
			int num8 = 0;
			while (true)
			{
				int num9 = num8;
				int num4 = num7;
				if (num9 <= num4)
				{
					if (Operators.CompareString(list[num8], "", TextCompare: false) != 0)
					{
						DGV1.Rows.Add();
						DGV1[col_propname.Index, num6].Value = list[num8];
						DGV1[col_proptype.Index, num6].Value = "Текст";
						num6++;
					}
					num8++;
					continue;
				}
				break;
			}
		}
	}

	public void getproparr(IEnumerable<XElement> Elements, List<string> arr)
	{
		checked
		{
			int num = Elements.Count() - 1;
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
					if (Elements.ElementAtOrDefault(num2).Name.ToString().Equals("Control", StringComparison.OrdinalIgnoreCase))
					{
						_Closure_0024__72 closure_0024__ = new _Closure_0024__72();
						closure_0024__._0024VB_0024Local_PropName = Elements.ElementAtOrDefault(num2).Attribute("PropName").Value;
						if (Information.IsNothing(arr) || !arr.Exists(closure_0024__._Lambda_0024__129))
						{
							arr.Add(closure_0024__._0024VB_0024Local_PropName);
						}
					}
					else
					{
						getproparr(Elements.ElementAtOrDefault(num2).Elements(), arr);
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
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Menu1.Show(Button1, 0, Button1.Height);
	}
}
