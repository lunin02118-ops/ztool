using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

internal class CustomComparer : IComparer
{
	public int columnIndex
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int sortOrderModifier
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public CustomComparer(int columnIndex, ListSortDirection sortDirection)
	{
		sortOrderModifier = Conversions.ToInteger(Interaction.IIf(sortDirection == ListSortDirection.Descending, -1, 1));
		this.columnIndex = columnIndex;
	}

	public int Compare(object x, object y)
	{
		DataGridViewRow dataGridViewRow = (DataGridViewRow)x;
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;
		string text = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[columnIndex].Value));
		string text2 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells[columnIndex].Value));
		double result;
		double result2 = default(double);
		DateTime result3;
		DateTime result4 = default(DateTime);
		int num = (((!double.TryParse(text, out result) || !double.TryParse(text2, out result2)) && 0 == 0) ? (((!DateTime.TryParse(text, out result3) || !DateTime.TryParse(text2, out result4)) && 0 == 0) ? text.CompareTo(text2) : result3.CompareTo(result4)) : result.CompareTo(result2));
		return Conversions.ToInteger(Interaction.IIf(num == 0, -1, checked(num * sortOrderModifier)));
	}

	int IComparer.Compare(object x, object y)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Compare
		return this.Compare(x, y);
	}
}
