using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

internal class DataGridViewRowComparer : IComparer
{
	public int sortOrderModifier1
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int sortOrderModifier2
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string colname1
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string colname2
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public DataGridViewRowComparer(string col1, SortOrder sortOrder1, string col2, SortOrder sortOrder2)
	{
		int num = 1;
		sortOrderModifier1 = num;
		num = 1;
		sortOrderModifier2 = num;
		sortOrderModifier1 = Conversions.ToInteger(Interaction.IIf(sortOrder1 == SortOrder.Descending, -1, 1));
		sortOrderModifier2 = Conversions.ToInteger(Interaction.IIf(sortOrder2 == SortOrder.Descending, -1, 1));
		colname1 = col1;
		colname2 = col2;
	}

	public int Compare(object x, object y)
	{
		DataGridViewRow dataGridViewRow = (DataGridViewRow)x;
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		double result4 = 0.0;
		int num = default(int);
		int num2 = default(int);
		try
		{
			if (Operators.CompareString(colname1, "", TextCompare: false) != 0)
			{
				text = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[colname1].Value));
				text2 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells[colname1].Value));
				DateTime result5;
				DateTime result6;
				if ((double.TryParse(text, out result) && double.TryParse(text2, out result2)) ? true : false)
				{
					num = result.CompareTo(result2);
				}
				else if ((DateTime.TryParse(text, out result5) && DateTime.TryParse(text2, out result6)) ? true : false)
				{
					num2 = result5.CompareTo(result6);
				}
				else
				{
					num = text.CompareTo(text2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		try
		{
			if ((num == 0 && Operators.CompareString(colname2, "", TextCompare: false) != 0) ? true : false)
			{
				text3 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[colname2].Value));
				text4 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells[colname2].Value));
				DateTime result8 = default(DateTime);
				num2 = (((!double.TryParse(text3, out result3) || !double.TryParse(text4, out result4)) && 0 == 0) ? (((!DateTime.TryParse(text3, out var result7) || !DateTime.TryParse(text4, out result8)) && 0 == 0) ? text3.CompareTo(text4) : result7.CompareTo(result8)) : result3.CompareTo(result4));
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		checked
		{
			if (num == 0)
			{
				if (num2 == 0)
				{
					return -1;
				}
				return num2 * sortOrderModifier2;
			}
			return num * sortOrderModifier1;
		}
	}

	int IComparer.Compare(object x, object y)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Compare
		return this.Compare(x, y);
	}
}
