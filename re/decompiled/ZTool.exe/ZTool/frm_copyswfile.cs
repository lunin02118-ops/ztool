using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
public class frm_copyswfile : Form
{
	public struct swfile
	{
		public string oldname;

		public string newname;

		public int rowindex;
	}

	[CompilerGenerated]
	internal class _Closure_0024__7
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__7(_Closure_0024__7 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__7()
		{
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__8
	{
		public string _0024VB_0024Local_oldpathname;

		[DebuggerNonUserCode]
		public _Closure_0024__8(_Closure_0024__8 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_oldpathname = other._0024VB_0024Local_oldpathname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__8()
		{
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

	[AccessedThroughProperty("c_Browse")]
	private Button _c_Browse;

	[AccessedThroughProperty("c_folder")]
	private TextBox _c_folder;

	[AccessedThroughProperty("c_usefolder")]
	private CheckBox _c_usefolder;

	[AccessedThroughProperty("c_Includedrw")]
	private CheckBox _c_Includedrw;

	[AccessedThroughProperty("c_Includeother")]
	private CheckBox _c_Includeother;

	[AccessedThroughProperty("c_othername")]
	private TextBox _c_othername;

	[AccessedThroughProperty("c_addprefix")]
	private CheckBox _c_addprefix;

	[AccessedThroughProperty("c_prefix")]
	private TextBox _c_prefix;

	[AccessedThroughProperty("c_addsuffix")]
	private CheckBox _c_addsuffix;

	[AccessedThroughProperty("c_suffix")]
	private TextBox _c_suffix;

	[AccessedThroughProperty("c_overwrite")]
	private CheckBox _c_overwrite;

	[AccessedThroughProperty("error_box")]
	private TextBox _error_box;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("c_Include3d")]
	private CheckBox _c_Include3d;

	[AccessedThroughProperty("c_Includevirtual")]
	private CheckBox _c_Includevirtual;

	private Thread thread_PackAndGo;

	internal bool Abort;

	private List<string> suffixlist;

	private List<swfile> filelist;

	private bool overwrite;

	private double dpixRatio;

	private Size mediumsize;

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

	internal virtual Button c_Browse
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_Browse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_Browse_Click;
			if (_c_Browse != null)
			{
				_c_Browse.Click -= value2;
			}
			_c_Browse = value;
			if (_c_Browse != null)
			{
				_c_Browse.Click += value2;
			}
		}
	}

	internal virtual TextBox c_folder
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_folder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_c_folder = value;
		}
	}

	internal virtual CheckBox c_usefolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_usefolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_usefolder_CheckStateChanged;
			if (_c_usefolder != null)
			{
				_c_usefolder.CheckStateChanged -= value2;
			}
			_c_usefolder = value;
			if (_c_usefolder != null)
			{
				_c_usefolder.CheckStateChanged += value2;
			}
		}
	}

	internal virtual CheckBox c_Includedrw
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_Includedrw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_c_Includedrw = value;
		}
	}

	internal virtual CheckBox c_Includeother
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_Includeother;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_Includeother_CheckStateChanged;
			if (_c_Includeother != null)
			{
				_c_Includeother.CheckStateChanged -= value2;
			}
			_c_Includeother = value;
			if (_c_Includeother != null)
			{
				_c_Includeother.CheckStateChanged += value2;
			}
		}
	}

	internal virtual TextBox c_othername
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_othername;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_c_othername = value;
		}
	}

	internal virtual CheckBox c_addprefix
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_addprefix;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_addprefix_CheckStateChanged;
			if (_c_addprefix != null)
			{
				_c_addprefix.CheckStateChanged -= value2;
			}
			_c_addprefix = value;
			if (_c_addprefix != null)
			{
				_c_addprefix.CheckStateChanged += value2;
			}
		}
	}

	internal virtual TextBox c_prefix
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_prefix;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_prefix_TextChanged;
			if (_c_prefix != null)
			{
				_c_prefix.TextChanged -= value2;
			}
			_c_prefix = value;
			if (_c_prefix != null)
			{
				_c_prefix.TextChanged += value2;
			}
		}
	}

	internal virtual CheckBox c_addsuffix
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_addsuffix;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_addsuffix_CheckStateChanged;
			if (_c_addsuffix != null)
			{
				_c_addsuffix.CheckStateChanged -= value2;
			}
			_c_addsuffix = value;
			if (_c_addsuffix != null)
			{
				_c_addsuffix.CheckStateChanged += value2;
			}
		}
	}

	internal virtual TextBox c_suffix
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_suffix;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = c_prefix_TextChanged;
			if (_c_suffix != null)
			{
				_c_suffix.TextChanged -= value2;
			}
			_c_suffix = value;
			if (_c_suffix != null)
			{
				_c_suffix.TextChanged += value2;
			}
		}
	}

	internal virtual CheckBox c_overwrite
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_overwrite;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_c_overwrite = value;
		}
	}

	internal virtual TextBox error_box
	{
		[DebuggerNonUserCode]
		get
		{
			return _error_box;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_error_box = value;
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

	internal virtual CheckBox c_Include3d
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_Include3d;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_c_Include3d = value;
		}
	}

	internal virtual CheckBox c_Includevirtual
	{
		[DebuggerNonUserCode]
		get
		{
			return _c_Includevirtual;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_c_Includevirtual = value;
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
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.c_Browse = new System.Windows.Forms.Button();
		this.c_folder = new System.Windows.Forms.TextBox();
		this.c_usefolder = new System.Windows.Forms.CheckBox();
		this.c_Includedrw = new System.Windows.Forms.CheckBox();
		this.c_Includeother = new System.Windows.Forms.CheckBox();
		this.c_othername = new System.Windows.Forms.TextBox();
		this.c_addprefix = new System.Windows.Forms.CheckBox();
		this.c_prefix = new System.Windows.Forms.TextBox();
		this.c_addsuffix = new System.Windows.Forms.CheckBox();
		this.c_suffix = new System.Windows.Forms.TextBox();
		this.c_overwrite = new System.Windows.Forms.CheckBox();
		this.error_box = new System.Windows.Forms.TextBox();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.c_Includevirtual = new System.Windows.Forms.CheckBox();
		this.c_Include3d = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel1.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(240, 236);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(146, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(3, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "ОК";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(76, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.c_Browse.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button button = this.c_Browse;
		location = new System.Drawing.Point(360, 39);
		button.Location = location;
		System.Windows.Forms.Button button2 = this.c_Browse;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(2);
		button2.Margin = margin;
		this.c_Browse.Name = "c_Browse";
		System.Windows.Forms.Button button3 = this.c_Browse;
		size = new System.Drawing.Size(27, 25);
		button3.Size = size;
		this.c_Browse.TabIndex = 7;
		this.c_Browse.Text = "...";
		this.c_Browse.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox = this.c_folder;
		location = new System.Drawing.Point(16, 40);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.c_folder;
		margin = new System.Windows.Forms.Padding(2);
		textBox2.Margin = margin;
		this.c_folder.Name = "c_folder";
		System.Windows.Forms.TextBox textBox3 = this.c_folder;
		size = new System.Drawing.Size(344, 23);
		textBox3.Size = size;
		this.c_folder.TabIndex = 6;
		this.c_usefolder.Checked = true;
		this.c_usefolder.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox = this.c_usefolder;
		location = new System.Drawing.Point(16, 16);
		checkBox.Location = location;
		System.Windows.Forms.CheckBox checkBox2 = this.c_usefolder;
		margin = new System.Windows.Forms.Padding(2);
		checkBox2.Margin = margin;
		this.c_usefolder.Name = "c_usefolder";
		System.Windows.Forms.CheckBox checkBox3 = this.c_usefolder;
		size = new System.Drawing.Size(159, 21);
		checkBox3.Size = size;
		this.c_usefolder.TabIndex = 5;
		this.c_usefolder.Text = "Сохранять всё в одну папку";
		this.c_usefolder.UseVisualStyleBackColor = true;
		this.c_Includedrw.AutoSize = true;
		this.c_Includedrw.Checked = true;
		this.c_Includedrw.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox4 = this.c_Includedrw;
		location = new System.Drawing.Point(200, 112);
		checkBox4.Location = location;
		this.c_Includedrw.Name = "c_Includedrw";
		System.Windows.Forms.CheckBox checkBox5 = this.c_Includedrw;
		size = new System.Drawing.Size(87, 21);
		checkBox5.Size = size;
		this.c_Includedrw.TabIndex = 8;
		this.c_Includedrw.Text = "Включая чертежи";
		this.c_Includedrw.UseVisualStyleBackColor = true;
		this.c_Includeother.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox6 = this.c_Includeother;
		location = new System.Drawing.Point(16, 160);
		checkBox6.Location = location;
		this.c_Includeother.Name = "c_Includeother";
		System.Windows.Forms.CheckBox checkBox7 = this.c_Includeother;
		size = new System.Drawing.Size(345, 21);
		checkBox7.Size = size;
		this.c_Includeother.TabIndex = 9;
		this.c_Includeother.Text = "Включая другие файлы с тем же именем (несколько элементов через точку с запятой, напр.: .pdf;.dwg)";
		this.c_Includeother.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox4 = this.c_othername;
		location = new System.Drawing.Point(16, 181);
		textBox4.Location = location;
		System.Windows.Forms.TextBox textBox5 = this.c_othername;
		margin = new System.Windows.Forms.Padding(2);
		textBox5.Margin = margin;
		this.c_othername.Name = "c_othername";
		System.Windows.Forms.TextBox textBox6 = this.c_othername;
		size = new System.Drawing.Size(368, 23);
		textBox6.Size = size;
		this.c_othername.TabIndex = 10;
		this.c_othername.Text = ".pdf;.dwg;.dxf";
		this.c_addprefix.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox8 = this.c_addprefix;
		location = new System.Drawing.Point(16, 76);
		checkBox8.Location = location;
		this.c_addprefix.Name = "c_addprefix";
		System.Windows.Forms.CheckBox checkBox9 = this.c_addprefix;
		size = new System.Drawing.Size(78, 21);
		checkBox9.Size = size;
		this.c_addprefix.TabIndex = 11;
		this.c_addprefix.Text = "Добавить префикс:";
		this.c_addprefix.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox7 = this.c_prefix;
		location = new System.Drawing.Point(96, 75);
		textBox7.Location = location;
		System.Windows.Forms.TextBox textBox8 = this.c_prefix;
		margin = new System.Windows.Forms.Padding(2);
		textBox8.Margin = margin;
		this.c_prefix.Name = "c_prefix";
		System.Windows.Forms.TextBox textBox9 = this.c_prefix;
		size = new System.Drawing.Size(100, 23);
		textBox9.Size = size;
		this.c_prefix.TabIndex = 12;
		this.c_addsuffix.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox10 = this.c_addsuffix;
		location = new System.Drawing.Point(200, 76);
		checkBox10.Location = location;
		this.c_addsuffix.Name = "c_addsuffix";
		System.Windows.Forms.CheckBox checkBox11 = this.c_addsuffix;
		size = new System.Drawing.Size(78, 21);
		checkBox11.Size = size;
		this.c_addsuffix.TabIndex = 13;
		this.c_addsuffix.Text = "Добавить суффикс:";
		this.c_addsuffix.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox10 = this.c_suffix;
		location = new System.Drawing.Point(280, 75);
		textBox10.Location = location;
		System.Windows.Forms.TextBox textBox11 = this.c_suffix;
		margin = new System.Windows.Forms.Padding(2);
		textBox11.Margin = margin;
		this.c_suffix.Name = "c_suffix";
		System.Windows.Forms.TextBox textBox12 = this.c_suffix;
		size = new System.Drawing.Size(100, 23);
		textBox12.Size = size;
		this.c_suffix.TabIndex = 14;
		this.c_overwrite.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox12 = this.c_overwrite;
		location = new System.Drawing.Point(16, 216);
		checkBox12.Location = location;
		this.c_overwrite.Name = "c_overwrite";
		System.Windows.Forms.CheckBox checkBox13 = this.c_overwrite;
		size = new System.Drawing.Size(99, 21);
		checkBox13.Size = size;
		this.c_overwrite.TabIndex = 8;
		this.c_overwrite.Text = "Перезаписывать файлы с тем же именем";
		this.c_overwrite.UseVisualStyleBackColor = true;
		this.error_box.Dock = System.Windows.Forms.DockStyle.Fill;
		this.error_box.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.TextBox textBox13 = this.error_box;
		location = new System.Drawing.Point(0, 276);
		textBox13.Location = location;
		this.error_box.Multiline = true;
		this.error_box.Name = "error_box";
		this.error_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		System.Windows.Forms.TextBox textBox14 = this.error_box;
		size = new System.Drawing.Size(394, 0);
		textBox14.Size = size;
		this.error_box.TabIndex = 15;
		this.StatusStrip1.AutoSize = false;
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		location = new System.Drawing.Point(0, 271);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(394, 0);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 16;
		this.StatusStrip1.Text = "StatusStrip1";
		this.Panel1.Controls.Add(this.c_usefolder);
		this.Panel1.Controls.Add(this.c_folder);
		this.Panel1.Controls.Add(this.c_Browse);
		this.Panel1.Controls.Add(this.TableLayoutPanel1);
		this.Panel1.Controls.Add(this.c_othername);
		this.Panel1.Controls.Add(this.c_suffix);
		this.Panel1.Controls.Add(this.c_Includeother);
		this.Panel1.Controls.Add(this.c_Includevirtual);
		this.Panel1.Controls.Add(this.c_overwrite);
		this.Panel1.Controls.Add(this.c_Include3d);
		this.Panel1.Controls.Add(this.c_Includedrw);
		this.Panel1.Controls.Add(this.c_addsuffix);
		this.Panel1.Controls.Add(this.c_addprefix);
		this.Panel1.Controls.Add(this.c_prefix);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(0, 0);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		size = new System.Drawing.Size(394, 276);
		panel2.Size = size;
		this.Panel1.TabIndex = 17;
		this.c_Includevirtual.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox14 = this.c_Includevirtual;
		location = new System.Drawing.Point(16, 136);
		checkBox14.Location = location;
		this.c_Includevirtual.Name = "c_Includevirtual";
		System.Windows.Forms.CheckBox checkBox15 = this.c_Includevirtual;
		size = new System.Drawing.Size(291, 21);
		checkBox15.Size = size;
		this.c_Includevirtual.TabIndex = 8;
		this.c_Includevirtual.Text = "Включая виртуальные детали (этот параметр сохранит виртуальные детали наружу)";
		this.c_Includevirtual.UseVisualStyleBackColor = true;
		this.c_Include3d.AutoSize = true;
		this.c_Include3d.Checked = true;
		this.c_Include3d.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox16 = this.c_Include3d;
		location = new System.Drawing.Point(16, 112);
		checkBox16.Location = location;
		this.c_Include3d.Name = "c_Include3d";
		System.Windows.Forms.CheckBox checkBox17 = this.c_Include3d;
		size = new System.Drawing.Size(103, 21);
		checkBox17.Size = size;
		this.c_Include3d.TabIndex = 8;
		this.c_Include3d.Text = "Включая 3D-компоненты";
		this.c_Include3d.UseVisualStyleBackColor = true;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(394, 271);
		this.ClientSize = size;
		this.Controls.Add(this.error_box);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.StatusStrip1);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		size = new System.Drawing.Size(410, 310);
		this.MinimumSize = size;
		this.Name = "frm_copyswfile";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Копировать резервную копию";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public frm_copyswfile()
	{
		base.FormClosed += frm_copyswfile_FormClosed;
		base.FormClosing += frm_copyswfile_FormClosing;
		base.Load += frm_copyswfile_Load;
		__ENCAddToList(this);
		Abort = true;
		suffixlist = new List<string>();
		filelist = new List<swfile>();
		dpixRatio = 1.0;
		ref Size reference = ref mediumsize;
		reference = new Size(410, 620);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			MinimumSize = (Size = new Size((int)Math.Round(410.0 * dpixRatio), (int)Math.Round(310.0 * dpixRatio)));
			ref Size reference2 = ref mediumsize;
			reference2 = new Size((int)Math.Round(410.0 * dpixRatio), (int)Math.Round(620.0 * dpixRatio));
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		suffixlist.Clear();
		filelist.Clear();
		checked
		{
			if (code.TMode)
			{
				MessageBox.Show(this, "Не поддерживается в пробной версии!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				if (!code.canrun)
				{
					return;
				}
				if (c_usefolder.Checked)
				{
					if (Operators.CompareString(c_folder.Text, "", TextCompare: false) == 0)
					{
						MessageBox.Show(this, "Укажите путь вывода", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					if (!Directory.Exists(c_folder.Text))
					{
						if (MessageBox.Show(this, "Путь \"" + c_folder.Text + "\" не существует, создать?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
						{
							return;
						}
						c_folder.Text = Directory.CreateDirectory(c_folder.Text).FullName;
					}
				}
				string left = Conversions.ToString(Interaction.IIf(c_addprefix.Checked, c_prefix.Text, ""));
				string right = Conversions.ToString(Interaction.IIf(c_addsuffix.Checked, c_suffix.Text, ""));
				overwrite = c_overwrite.Checked;
				if (c_Includedrw.Checked)
				{
					suffixlist.Add(".slddrw");
				}
				if (c_Includeother.Checked)
				{
					string[] array = c_othername.Text.Split(';');
					int num = array.Length - 1;
					int num2 = 0;
					_Closure_0024__7 closure_0024__ = default(_Closure_0024__7);
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						closure_0024__ = new _Closure_0024__7(closure_0024__);
						closure_0024__._0024VB_0024Local_str = array[num2];
						if ((closure_0024__._0024VB_0024Local_str.StartsWith(".") && !suffixlist.Exists(closure_0024__._Lambda_0024__9)) ? true : false)
						{
							suffixlist.Add(closure_0024__._0024VB_0024Local_str);
						}
						num2++;
					}
				}
				int num5 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num6 = 0;
				_Closure_0024__8 closure_0024__2 = default(_Closure_0024__8);
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					closure_0024__2 = new _Closure_0024__8(closure_0024__2);
					if (MyProject.Forms.Frmmain.DGV1.Rows[num6].Visible)
					{
						if (!c_Includevirtual.Checked)
						{
							string str = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num6].Value);
							if (code.IsVirtual(str))
							{
								goto IL_04ae;
							}
						}
						string path = Conversions.ToString(Interaction.IIf(c_usefolder.Checked, c_folder.Text, RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, num6].Value)));
						closure_0024__2._0024VB_0024Local_oldpathname = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num6].Value);
						string path2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(left, MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_FileName.Index, num6].Value), right), code.SplitStr(closure_0024__2._0024VB_0024Local_oldpathname, 5)));
						string text = Path.Combine(path, path2);
						int rowindex = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, num6].Value);
						if (((File.Exists(closure_0024__2._0024VB_0024Local_oldpathname) && !closure_0024__2._0024VB_0024Local_oldpathname.Equals(text, StringComparison.OrdinalIgnoreCase)) ? true : false) && !filelist.Exists(closure_0024__2._Lambda_0024__10))
						{
							filelist.Add(new swfile
							{
								newname = text,
								oldname = closure_0024__2._0024VB_0024Local_oldpathname,
								rowindex = rowindex
							});
						}
					}
					goto IL_04ae;
					IL_04ae:
					num6++;
				}
				if (filelist.Count < 1)
				{
					MessageBox.Show(this, "Нет данных для резервного копирования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if ((Information.IsNothing(thread_PackAndGo) || !thread_PackAndGo.IsAlive) && 0 == 0)
				{
					Abort = false;
					OK_Button.Enabled = false;
					thread_PackAndGo = new Thread(PackAndGo);
					thread_PackAndGo.Name = "PackAndGo";
					thread_PackAndGo.Start();
					Thread.Sleep(100);
				}
			}
		}
	}

	public void PackAndGo()
	{
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder();
		code.Dostop = false;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Restart();
		ControlExtensions.InvokeOnUiThreadIfRequired(this, [SpecialName] () =>
		{
			MyProject.Forms.Frmmain.StatusLabel1.Text = "Копирование файлов...";
			MyProject.Forms.Frmmain.IsStop.Visible = true;
			MyProject.Forms.Frmmain.ToolStripProgressBar1.Visible = true;
			MyProject.Forms.Frmmain.ToolStripProgressBar1.Maximum = filelist.Count;
		});
		checked
		{
			int num = filelist.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4 || code.Dostop || Abort)
				{
					break;
				}
				ControlExtensions.InvokeOnUiThreadIfRequired(this, [SpecialName] () =>
				{
					MyProject.Forms.Frmmain.ToolStripProgressBar1.Value = num2 + 1;
				});
				try
				{
					if (c_Include3d.Checked)
					{
						File.Copy(filelist[num2].oldname, filelist[num2].newname, overwrite);
						if (File.Exists(filelist[num2].newname))
						{
							File.SetAttributes(filelist[num2].newname, FileAttributes.Normal);
						}
					}
					int num5 = suffixlist.Count - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						if (File.Exists(code.SplitStr(filelist[num2].oldname, 3) + suffixlist[num6]))
						{
							File.Copy(code.SplitStr(filelist[num2].oldname, 3) + suffixlist[num6], code.SplitStr(filelist[num2].newname, 3) + suffixlist[num6], overwrite);
							if (File.Exists(code.SplitStr(filelist[num2].newname, 3) + suffixlist[num6]))
							{
								File.SetAttributes(code.SplitStr(filelist[num2].newname, 3) + suffixlist[num6], FileAttributes.Normal);
							}
						}
						num6++;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					stringBuilder.AppendLine(ex2.Message);
					ProjectData.ClearProjectError();
				}
				num2++;
			}
			ControlExtensions.InvokeOnUiThreadIfRequired(this, [SpecialName] () =>
			{
				MyProject.Forms.Frmmain.StatusLabel1.Text = "Обновление ссылок...";
				MyProject.Forms.Frmmain.ToolStripProgressBar1.Maximum = filelist.Count;
			});
			try
			{
				if (!code.RunSW())
				{
					return;
				}
				code.EnablePreview = false;
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
				int num8 = filelist.Count - 1;
				num2 = 0;
				while (true)
				{
					int num9 = num2;
					int num4 = num8;
					if (num9 > num4)
					{
						break;
					}
					ControlExtensions.InvokeOnUiThreadIfRequired(this, [SpecialName] () =>
					{
						MyProject.Forms.Frmmain.ToolStripProgressBar1.Value = num2 + 1;
					});
					if (code.Dostop || Abort)
					{
						break;
					}
					if (File.Exists(filelist[num2].newname))
					{
						string text = code.SplitStr(filelist[num2].newname, 3) + ".slddrw";
						if (File.Exists(text))
						{
							object swApp = code.swApp;
							object[] array = new object[3]
							{
								text,
								filelist[num2].oldname,
								filelist[num2].newname
							};
							object[] arguments = array;
							bool[] array2 = new bool[3] { true, false, false };
							object value = NewLateBinding.LateGet(swApp, null, "ReplaceReferencedDocument", arguments, null, null, array2);
							if (array2[0])
							{
								text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
							}
							if (!Conversions.ToBoolean(value))
							{
								stringBuilder.AppendLine("\"" + text + "\" не удалось обновить ссылки!");
							}
						}
						object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetDocumentDependencies2", new object[4]
						{
							filelist[num2].newname,
							false,
							true,
							false
						}, null, null, null));
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
						{
							int num10 = Information.UBound((Array)objectValue);
							int num11 = 0;
							while (true)
							{
								int num12 = num11;
								num4 = num10;
								if (num12 > num4)
								{
									break;
								}
								string text2 = NewLateBinding.LateIndexGet(objectValue, new object[1] { num11 + 1 }, null).ToString();
								int num13 = filelist.Count - 1;
								int num6 = 0;
								while (true)
								{
									int num14 = num6;
									num4 = num13;
									if (num14 > num4)
									{
										break;
									}
									if (text2.Equals(filelist[num6].oldname, StringComparison.OrdinalIgnoreCase))
									{
										if (!Conversions.ToBoolean(NewLateBinding.LateGet(code.swApp, null, "ReplaceReferencedDocument", new object[3]
										{
											filelist[num2].newname,
											filelist[num6].oldname,
											filelist[num6].newname
										}, null, null, null)))
										{
											stringBuilder.AppendLine("\"" + filelist[num2].newname + "\" не удалось обновить ссылки!");
										}
										break;
									}
									num6++;
								}
								num11 += 2;
							}
						}
					}
					num2++;
				}
				stopwatch.Stop();
				string text3 = Conversions.ToString(Interaction.IIf((code.Dostop || Abort) ? true : false, "Резервное копирование отменено", "Резервное копирование завершено, затрачено" + Conversions.ToString((double)stopwatch.ElapsedMilliseconds / 1000.0) + "сек, всего" + Conversions.ToString(filelist.Count) + "поз."));
				MessageBox.Show(this, text3, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				stringBuilder.AppendLine(ex4.Message);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
					code.EnablePreview = true;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
			ControlExtensions.InvokeOnUiThreadIfRequired(this, [SpecialName] () =>
			{
				reset();
			});
			error_box.Clear();
			if (Operators.CompareString(stringBuilder.ToString().Trim(), "", TextCompare: false) != 0)
			{
				error_box.Text = stringBuilder.ToString();
				if (Height < mediumsize.Height)
				{
					Size = mediumsize;
				}
			}
			else
			{
				Size = MinimumSize;
			}
		}
	}

	public void reset()
	{
		OK_Button.Enabled = true;
		MyProject.Forms.Frmmain.ToolStripProgressBar1.Visible = false;
		MyProject.Forms.Frmmain.IsStop.Visible = false;
		MyProject.Forms.Frmmain.ToolStripProgressBar1.Value = 0;
		MyProject.Forms.Frmmain.StatusLabel1.Text = "Всего сейчас" + Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + "поз.";
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void c_Browse_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		fileBorser.Title = "Упаковать в папку";
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			c_folder.Text = fileBorser.DirectoryPath;
		}
	}

	private void c_prefix_TextChanged(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		string text = textBox.Text;
		checked
		{
			int num = text.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					string text2 = Conversions.ToString(text[num2]);
					if (invalidFileNameChars.Contains(Conversions.ToChar(text2)))
					{
						textBox.Text = text.Replace(text2, "");
						break;
					}
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void c_usefolder_CheckStateChanged(object sender, EventArgs e)
	{
		c_folder.Enabled = c_usefolder.Checked;
		c_Browse.Enabled = c_usefolder.Checked;
	}

	private void c_addprefix_CheckStateChanged(object sender, EventArgs e)
	{
		c_prefix.Enabled = c_addprefix.Checked;
	}

	private void c_addsuffix_CheckStateChanged(object sender, EventArgs e)
	{
		c_suffix.Enabled = c_addsuffix.Checked;
	}

	private void c_Includeother_CheckStateChanged(object sender, EventArgs e)
	{
		c_othername.Enabled = c_Includeother.Checked;
	}

	private void frm_copyswfile_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			error_box.Clear();
			Savecfg();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	private void frm_copyswfile_FormClosing(object sender, FormClosingEventArgs e)
	{
		Abort = true;
		reset();
	}

	private void frm_copyswfile_Load(object sender, EventArgs e)
	{
		try
		{
			Loadcfg();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		c_folder.Enabled = c_usefolder.Checked;
		c_Browse.Enabled = c_usefolder.Checked;
		c_prefix.Enabled = c_addprefix.Checked;
		c_suffix.Enabled = c_addsuffix.Checked;
		c_othername.Enabled = c_Includeother.Checked;
		error_box.Clear();
	}

	private void Savecfg()
	{
		CConfigMng.Config.copyswfilecfg.Clear();
		FindctlToSave(this);
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.copyswfilecfg.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.copyswfilecfg.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.copyswfilecfg.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.copyswfilecfg.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		FindctlToLoad(this);
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
					case 599:
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
								goto IL_00e3;
							case 13:
								goto IL_00f6;
							case 15:
								goto IL_0116;
							case 16:
								goto IL_0129;
							case 18:
								goto IL_0143;
							case 19:
								goto IL_0156;
							case 8:
							case 11:
							case 14:
							case 17:
							case 20:
							case 21:
							case 22:
								goto IL_016b;
							case 23:
								goto IL_0180;
							case 24:
								goto IL_0190;
							case 25:
							case 26:
								goto IL_019d;
							default:
								goto end_IL_0001;
							case 27:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_00f6:
						num2 = 13;
						((ComboBox)control).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_016b;
						IL_0116:
						num2 = 15;
						if (control is RadioButton)
						{
							goto IL_0129;
						}
						goto IL_0143;
						IL_00e3:
						num2 = 12;
						if (control is ComboBox)
						{
							goto IL_00f6;
						}
						goto IL_0116;
						IL_0129:
						num2 = 16;
						((RadioButton)control).Checked = code.Cbool1(array[1]);
						goto IL_016b;
						IL_000a:
						num2 = 2;
						enumerator = parent.Controls.GetEnumerator();
						goto IL_01a2;
						IL_01a2:
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
						IL_0143:
						num2 = 18;
						if (control is LinkLabel)
						{
							goto IL_0156;
						}
						goto IL_016b;
						IL_016b:
						num2 = 22;
						num5++;
						goto IL_0174;
						IL_0156:
						num2 = 19;
						((LinkLabel)control).Text = array[1];
						goto IL_016b;
						IL_002a:
						num2 = 3;
						num6 = CConfigMng.Config.copyswfilecfg.Count - 1;
						num5 = 0;
						goto IL_0174;
						IL_0174:
						num7 = num5;
						num8 = num6;
						if (num7 <= num8)
						{
							goto IL_0047;
						}
						goto IL_0180;
						IL_0180:
						num2 = 23;
						if (control.HasChildren)
						{
							goto IL_0190;
						}
						goto IL_019d;
						IL_0190:
						num2 = 24;
						FindctlToLoad(control);
						goto IL_019d;
						IL_019d:
						num2 = 26;
						goto IL_01a2;
						IL_0047:
						num2 = 4;
						array = Strings.Split(CConfigMng.Config.copyswfilecfg[num5], "\n");
						goto IL_0067;
						IL_0067:
						num2 = 5;
						if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_0085;
						}
						goto IL_016b;
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
						goto IL_016b;
						IL_00b3:
						num2 = 9;
						if (control is TextBox)
						{
							goto IL_00c6;
						}
						goto IL_00e3;
						IL_00c6:
						num2 = 10;
						((TextBox)control).Text = array[1].ToString();
						goto IL_016b;
						end_IL_0001:
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 599;
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
