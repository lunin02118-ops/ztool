using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class Frmmapping : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__65
	{
		public string _0024VB_0024Local_mappingname;

		[DebuggerNonUserCode]
		public _Closure_0024__65(_Closure_0024__65 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_mappingname = other._0024VB_0024Local_mappingname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__65()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__120(columnnamemapping s)
		{
			return s.mappingname.Equals(_0024VB_0024Local_mappingname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__66
	{
		public string _0024VB_0024Local_colname;

		[DebuggerNonUserCode]
		public _Closure_0024__66(_Closure_0024__66 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_colname = other._0024VB_0024Local_colname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__66()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__121(columnnamemapping s)
		{
			return s.name.Equals(_0024VB_0024Local_colname, StringComparison.OrdinalIgnoreCase);
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

	[AccessedThroughProperty("Column3")]
	private DataGridViewTextBoxColumn _Column3;

	[AccessedThroughProperty("Column2")]
	private DataGridViewTextBoxColumn _Column2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	private double dpixRatio;

	private string oldval;

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
			DataGridViewCellCancelEventHandler value2 = DGV1_CellBeginEdit;
			DataGridViewDataErrorEventHandler value3 = DGV1_DataError;
			DataGridViewCellPaintingEventHandler value4 = DGV1_CellPainting;
			DataGridViewCellEventHandler value5 = dgv1_CellValueChanged;
			if (_DGV1 != null)
			{
				_DGV1.CellBeginEdit -= value2;
				_DGV1.DataError -= value3;
				_DGV1.CellPainting -= value4;
				_DGV1.CellValueChanged -= value5;
			}
			_DGV1 = value;
			if (_DGV1 != null)
			{
				_DGV1.CellBeginEdit += value2;
				_DGV1.DataError += value3;
				_DGV1.CellPainting += value4;
				_DGV1.CellValueChanged += value5;
			}
		}
	}

	internal virtual DataGridViewTextBoxColumn Column3
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.DGV1 = new System.Windows.Forms.DataGridView();
		this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Label1 = new System.Windows.Forms.Label();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(273, 348);
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
		this.DGV1.AllowUserToAddRows = false;
		this.DGV1.AllowUserToDeleteRows = false;
		this.DGV1.AllowUserToResizeRows = false;
		this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.DGV1.BackgroundColor = System.Drawing.SystemColors.Control;
		this.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DGV1.Columns.AddRange(this.Column3, this.Column2);
		this.DGV1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.DataGridView dGV = this.DGV1;
		location = new System.Drawing.Point(0, 0);
		dGV.Location = location;
		this.DGV1.MultiSelect = false;
		this.DGV1.Name = "DGV1";
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.DGV1.RowHeadersWidth = 20;
		this.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.DGV1.RowsDefaultCellStyle = dataGridViewCellStyle2;
		this.DGV1.RowTemplate.Height = 23;
		this.DGV1.ShowEditingIcon = false;
		System.Windows.Forms.DataGridView dGV2 = this.DGV1;
		size = new System.Drawing.Size(431, 264);
		dGV2.Size = size;
		this.DGV1.TabIndex = 20;
		this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
		this.Column3.FillWeight = 50f;
		this.Column3.HeaderText = "Заголовок столбца";
		this.Column3.Name = "Column3";
		this.Column3.ReadOnly = true;
		this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column3.Width = 200;
		this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
		this.Column2.FillWeight = 50f;
		this.Column2.HeaderText = "Имя сопоставления";
		this.Column2.Name = "Column2";
		this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Label1.AutoSize = true;
		this.Label1.ForeColor = System.Drawing.Color.Green;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(0, 272);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(402, 68);
		label2.Size = size;
		this.Label1.TabIndex = 21;
		this.Label1.Text = "-Если имя сопоставления пустое или совпадает с заголовком столбца, сопоставление для столбца не применяется;\r\n-Имя сопоставления должно совпадать с пользовательским именем в шаблоне Excel;\r\n-Сопоставление заголовков нужно в основном для решения проблем синтаксиса пользовательских имён в шаблоне Excel,\r\nа также путаницы в данных спецификации из-за повторяющихся заголовков столбцов;";
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(431, 385);
		this.ClientSize = size;
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.DGV1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "Frmmapping";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Сопоставление заголовков столбцов";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public Frmmapping()
	{
		base.Load += Frmmapping_Load;
		base.KeyPress += Frmmapping_KeyPress;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		mLinearColor1 = Color.FromArgb(240, 240, 240);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			DGV1.Columns[0].Width = (int)Math.Round((double)DGV1.Columns[0].Width * dpixRatio);
			DGV1.Columns[1].Width = (int)Math.Round((double)DGV1.Columns[1].Width * dpixRatio);
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		List<columnnamemapping> list = new List<columnnamemapping>();
		if (CConfigMng.Config.namemappinglist != null)
		{
			list.AddRange(CConfigMng.Config.namemappinglist);
		}
		CConfigMng.Config.namemappinglist.Clear();
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			_Closure_0024__65 closure_0024__ = default(_Closure_0024__65);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__65(closure_0024__);
				closure_0024__._0024VB_0024Local_mappingname = Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[1, num2].Value));
				columnnamemapping columnnamemapping2 = new columnnamemapping();
				columnnamemapping2.name = Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1.Rows[num2].Tag));
				columnnamemapping2.text = Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[0, num2].Value));
				columnnamemapping2.mappingname = closure_0024__._0024VB_0024Local_mappingname;
				if (columnnamemapping2.name.Contains("PropVal_"))
				{
					columnnamemapping2.name2 = "PropResolvedVal_" + Strings.Replace(columnnamemapping2.name, "PropVal_", "");
				}
				int num5 = CConfigMng.Config.namemappinglist.FindIndex(closure_0024__._Lambda_0024__120);
				if (num5 >= 0 && (((Operators.CompareString(CConfigMng.Config.namemappinglist[num5].name, columnnamemapping2.name, TextCompare: false) == 0 || Operators.CompareString(CConfigMng.Config.namemappinglist[num5].name2, columnnamemapping2.name2, TextCompare: false) == 0) && Operators.CompareString(CConfigMng.Config.namemappinglist[num5].text, columnnamemapping2.text, TextCompare: false) == 0) ? true : false))
				{
					CConfigMng.Config.namemappinglist[num5].mappingname = "";
				}
				CConfigMng.Config.namemappinglist.Add(columnnamemapping2);
				num2++;
			}
			foreach (columnnamemapping item in list)
			{
				if (item != null && CConfigMng.Config.namemappinglist.FindIndex((columnnamemapping s) => (!string.IsNullOrEmpty(item.name) && string.Equals(s.name ?? "", item.name, StringComparison.OrdinalIgnoreCase)) || (!string.IsNullOrEmpty(item.name2) && string.Equals(s.name2 ?? "", item.name2, StringComparison.OrdinalIgnoreCase))) < 0)
				{
					CConfigMng.Config.namemappinglist.Add(item);
				}
			}
			CConfigMng.SaveConfig();
			DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void Frmmapping_Load(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				DGV1.Rows.Clear();
				int num = 0;
				int num2 = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
				int num3 = 0;
				_Closure_0024__66 closure_0024__ = default(_Closure_0024__66);
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					closure_0024__ = new _Closure_0024__66(closure_0024__);
					string columnName = MyProject.Forms.Frmmain.DGV1.Columns[num3].Name;
					string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num3].HeaderText;
					bool flag = columnName.StartsWith("Col_", StringComparison.OrdinalIgnoreCase) && !columnName.Equals("Col_Checkbox", StringComparison.OrdinalIgnoreCase) && !columnName.Equals("Col_NewFolder", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(headerText);
					if (columnName.Contains("PropVal_") || flag)
					{
						closure_0024__._0024VB_0024Local_colname = columnName;
						string value = "";
						int num6 = CConfigMng.Config.namemappinglist.FindIndex(closure_0024__._Lambda_0024__121);
						if (num6 >= 0)
						{
							value = CConfigMng.Config.namemappinglist[num6].mappingname;
						}
						int num7 = DGV1.RowCount - 1;
						int num8 = 0;
						while (true)
						{
							int num9 = num8;
							num5 = num7;
							if (num9 > num5)
							{
								break;
							}
							if (Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[1, num8].Value)).Equals(value, StringComparison.OrdinalIgnoreCase))
							{
								DGV1[1, num8].Value = "";
								value = "";
							}
							num8++;
						}
						DGV1.Rows.Add();
						DGV1[0, num].Style.BackColor = Color.FromArgb(240, 240, 240);
						DGV1[0, num].Value = headerText;
						DGV1.Rows[num].Tag = closure_0024__._0024VB_0024Local_colname;
						DGV1[1, num].Value = value;
						num++;
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

	private void Frmmapping_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void DGV1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		oldval = Conversions.ToString(dataGridView[e.ColumnIndex, e.RowIndex].Value);
	}

	private void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		checked
		{
			try
			{
				if (e.RowIndex < 0 || e.ColumnIndex < 0)
				{
					return;
				}
				string text = Conversions.ToString(dataGridView[e.ColumnIndex, e.RowIndex].Value);
				if (Operators.CompareString(text, "", TextCompare: false) == 0 || e.ColumnIndex != 1)
				{
					return;
				}
				int num = dataGridView.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (num2 != e.RowIndex)
					{
						string value = Conversions.ToString(dataGridView[e.ColumnIndex, num2].Value);
						if (text.Equals(value, StringComparison.OrdinalIgnoreCase))
						{
							MessageBox.Show(this, "Повторяющееся имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							dataGridView[e.ColumnIndex, e.RowIndex].Value = oldval;
							dataGridView.CancelEdit();
							break;
						}
					}
					num2++;
				}
				int num5 = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 <= num4)
					{
						string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num6].HeaderText;
						if (text.Equals(headerText, StringComparison.OrdinalIgnoreCase))
						{
							MessageBox.Show(this, "Повторяющееся имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							dataGridView[e.ColumnIndex, e.RowIndex].Value = oldval;
							dataGridView.CancelEdit();
							break;
						}
						num6++;
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
		e.Cancel = false;
	}
}
