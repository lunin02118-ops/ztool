using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class DataGridViewWithCheckBox : DataGridView
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private DataGridViewCheckBoxColumn col;

	private CheckBox ckBox;

	private bool can;

	private bool @bool;

	public bool @checked => ckBox.Checked;

	public bool EnDoubleClick
	{
		get
		{
			return @bool;
		}
		set
		{
			@bool = value;
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

	public DataGridViewWithCheckBox()
	{
		base.Paint += DataGridViewWithCheckBox_Paint;
		base.CellMouseDoubleClick += DataGridViewWithCheckBox_CellMouseDoubleClick;
		base.CellValueChanged += DataGridViewWithCheckBox_CellValueChanged;
		base.CurrentCellDirtyStateChanged += DataGridViewWithCheckBox_CurrentCellDirtyStateChanged;
		__ENCAddToList(this);
		col = new DataGridViewCheckBoxColumn();
		ckBox = new CheckBox();
		can = false;
		@bool = false;
		col.ThreeState = false;
		col.Width = 25;
		col.Resizable = DataGridViewTriState.NotSet;
		col.HeaderText = "";
		col.TrueValue = true;
		col.FalseValue = false;
		Columns.Clear();
		RowHeadersVisible = true;
		EditMode = DataGridViewEditMode.EditOnEnter;
		SelectionMode = DataGridViewSelectionMode.CellSelect;
		Columns.Add(col);
		ckBox.ThreeState = false;
		ckBox.Text = "";
		ckBox.Checked = false;
		Rectangle cellDisplayRectangle = GetCellDisplayRectangle(0, -1, cutOverflow: true);
		CheckBox checkBox = ckBox;
		Size size = new Size(13, 13);
		checkBox.Size = size;
		CheckBox checkBox2 = ckBox;
		checked
		{
			Point location = new Point(cellDisplayRectangle.Location.X + unchecked(Columns[0].Width / 2) - 6 + 1, cellDisplayRectangle.Location.Y + 7);
			checkBox2.Location = location;
			ckBox.CheckedChanged += ckBox_CheckedChanged;
			Controls.Add(ckBox);
			Columns[0].MinimumWidth = 25;
		}
	}

	private void ckBox_CheckedChanged(object sender, EventArgs e)
	{
		can = true;
		if (((CheckBox)sender).CheckState == CheckState.Indeterminate)
		{
			return;
		}
		checked
		{
			int num = Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				Rows[num2].Cells[col.Name].Value = ((CheckBox)sender).Checked;
				num2++;
			}
			RefreshEdit();
			can = false;
		}
	}

	private void DataGridViewWithCheckBox_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (@bool)
		{
			this[col.Index, e.RowIndex].Value = Operators.NotObject(this[col.Index, e.RowIndex].Value);
		}
	}

	private void DataGridViewWithCheckBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (can)
		{
			return;
		}
		int num = 0;
		checked
		{
			int num2 = RowCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5 || num3 > RowCount - 1)
				{
					break;
				}
				if (Operators.ConditionalCompareObjectEqual(Rows[num3].Cells[col.Name].Value, false, TextCompare: false))
				{
					num++;
				}
				num3++;
			}
			if (num == 0)
			{
				ckBox.CheckState = CheckState.Checked;
			}
			else if (num == RowCount)
			{
				ckBox.CheckState = CheckState.Unchecked;
			}
			else
			{
				ckBox.CheckState = CheckState.Indeterminate;
			}
		}
	}

	private void DataGridViewWithCheckBox_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (IsCurrentCellDirty)
		{
			CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void DataGridViewWithCheckBox_Paint(object sender, PaintEventArgs e)
	{
		Rectangle cellDisplayRectangle = GetCellDisplayRectangle(0, -1, cutOverflow: false);
		CheckBox checkBox = ckBox;
		Size size = new Size(13, 13);
		checkBox.Size = size;
		CheckBox checkBox2 = ckBox;
		checked
		{
			Point location = new Point(cellDisplayRectangle.Location.X + unchecked(Columns[0].Width / 2) - 6 + 1, cellDisplayRectangle.Location.Y + 7);
			checkBox2.Location = location;
			ckBox.Refresh();
		}
	}
}
