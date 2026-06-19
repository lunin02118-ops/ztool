using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class DataGridViewEX : DataGridView
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private double dpixRatio;

	private int col;

	private int row;

	private int _hoverColumnIndex;

	private bool _isOverFilterButton;

	private int _lastHoverColumnIndex;

	private bool _lastIsOverFilterButton;

	private Dictionary<Color, SolidBrush> _brushCache;

	private Dictionary<Color, Pen> _penCache;

	private Dictionary<string, LinearGradientBrush> _gradientBrushCache;

	private Dictionary<string, Point[]> _sortArrowPoints;

	private Color HoverHeaderColor
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string topcfgName
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool ShowFilterButton
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public new SortOrder SortOrder
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public new DataGridViewColumn SortedColumn
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
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

	public DataGridViewEX()
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		_hoverColumnIndex = -1;
		Color lightSteelBlue = Color.LightSteelBlue;
		HoverHeaderColor = lightSteelBlue;
		_isOverFilterButton = false;
		_lastHoverColumnIndex = -1;
		_lastIsOverFilterButton = false;
		_brushCache = new Dictionary<Color, SolidBrush>();
		_penCache = new Dictionary<Color, Pen>();
		_gradientBrushCache = new Dictionary<string, LinearGradientBrush>();
		_sortArrowPoints = new Dictionary<string, Point[]>();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		DoubleBuffer(this);
		PrecalculateGeometry();
	}

	private void PrecalculateGeometry()
	{
		Dictionary<string, Point[]> sortArrowPoints = _sortArrowPoints;
		Point[] array = new Point[3];
		ref Point reference = ref array[0];
		Point point = new Point(-4, 6);
		reference = point;
		ref Point reference2 = ref array[1];
		Point point2 = new Point(-12, 6);
		reference2 = point2;
		ref Point reference3 = ref array[2];
		Point point3 = new Point(-8, 2);
		reference3 = point3;
		sortArrowPoints["Ascending"] = array;
		Dictionary<string, Point[]> sortArrowPoints2 = _sortArrowPoints;
		array = new Point[3];
		ref Point reference4 = ref array[0];
		point3 = new Point(-4, 2);
		reference4 = point3;
		ref Point reference5 = ref array[1];
		point2 = new Point(-12, 2);
		reference5 = point2;
		ref Point reference6 = ref array[2];
		point = new Point(-8, 6);
		reference6 = point;
		sortArrowPoints2["Descending"] = array;
	}

	private SolidBrush GetCachedBrush(Color color)
	{
		if (!_brushCache.ContainsKey(color))
		{
			_brushCache[color] = new SolidBrush(color);
		}
		return _brushCache[color];
	}

	private Pen GetCachedPen(Color color)
	{
		if (!_penCache.ContainsKey(color))
		{
			_penCache[color] = new Pen(color, 1f);
		}
		return _penCache[color];
	}

	protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
	{
		base.OnCellPainting(e);
		if (e.RowIndex < -1 || e.ColumnIndex < -1)
		{
			return;
		}
		Rectangle rect = checked(new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1));
		try
		{
			switch (GetCellType(e.RowIndex, e.ColumnIndex))
			{
			case 0:
				DrawColumnHeader(e, rect);
				break;
			case 1:
				DrawRowHeader(e, rect);
				break;
			case 2:
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

	private int GetCellType(int rowIndex, int columnIndex)
	{
		if ((rowIndex == -1 && columnIndex == -1) ? true : false)
		{
			return -1;
		}
		if (rowIndex == -1)
		{
			return 0;
		}
		if (columnIndex == -1)
		{
			return 1;
		}
		return 2;
	}

	private void DrawColumnHeader(DataGridViewCellPaintingEventArgs e, Rectangle Rect)
	{
		SolidBrush cachedBrush = GetCachedBrush((_hoverColumnIndex == e.ColumnIndex) ? HoverHeaderColor : CT.LinearColor);
		e.Graphics.FillRectangle(cachedBrush, Rect);
		e.PaintContent(e.CellBounds);
		ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);
		if (col == e.ColumnIndex)
		{
			string key = ((SortOrder == SortOrder.Ascending) ? "Ascending" : "Descending");
			if (_sortArrowPoints.ContainsKey(key))
			{
				Point[] source = _sortArrowPoints[key];
				Point[] points = source.Select([SpecialName] (Point p) => checked(new Point((int)Math.Round((double)Rect.Right + (double)p.X * dpixRatio), (int)Math.Round((double)Rect.Top + (double)p.Y * dpixRatio)))).ToArray();
				e.Graphics.FillPolygon(GetCachedBrush(CT.HeaderBorder), points);
			}
		}
		string name = Columns[e.ColumnIndex].Name;
		if ((!name.Equals("Col_Preview", StringComparison.OrdinalIgnoreCase) && !name.Equals("Col_Number", StringComparison.OrdinalIgnoreCase)) ? true : false)
		{
			DrawFilterButton(e, Rect);
		}
		e.Handled = true;
	}

	private void DrawRowHeader(DataGridViewCellPaintingEventArgs e, Rectangle Rect)
	{
		if (Rows[e.RowIndex].HeaderCell.Style.BackColor == CT.ReadOnlyRowColor)
		{
			e.Graphics.FillRectangle(GetCachedBrush(CT.ReadOnlyRowColor), Rect);
			e.PaintContent(e.CellBounds);
			ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);
			e.Handled = true;
		}
	}

	private void DrawFilterButton(DataGridViewCellPaintingEventArgs e, Rectangle Rect)
	{
		checked
		{
			Rectangle rectangle = new Rectangle((int)Math.Round((double)Rect.Right - 16.0 * dpixRatio), (int)Math.Round((double)Rect.Bottom - 16.0 * dpixRatio), (int)Math.Round(16.0 * dpixRatio), (int)Math.Round(16.0 * dpixRatio));
			string key = $"{CT.ButtonHoverTop}-{CT.ButtonHoverBottom}";
			if (!_gradientBrushCache.ContainsKey(key))
			{
				_gradientBrushCache[key] = new LinearGradientBrush(rectangle, CT.ButtonHoverTop, CT.ButtonHoverBottom, 90f);
			}
			e.Graphics.FillRectangle(_gradientBrushCache[key], rectangle);
			Rectangle rectangle2 = rectangle;
			rectangle2.Width--;
			rectangle2.Height--;
			e.Graphics.DrawRectangle(GetCachedPen(CT.ButtonHoverBorder), rectangle2);
			if (Columns[e.ColumnIndex].HeaderCell.Style.BackColor == Color.Tomato)
			{
				DrawFilterStatusIcon(e, rectangle2);
			}
			else
			{
				DrawNormalFilterIcon(e, rectangle2);
			}
		}
	}

	private void DrawFilterStatusIcon(DataGridViewCellPaintingEventArgs e, Rectangle rectBorder)
	{
		Graphics graphics = e.Graphics;
		SolidBrush cachedBrush = GetCachedBrush(CT.filterstatus);
		Point[] array = new Point[3];
		ref Point reference = ref array[0];
		checked
		{
			Point point = new Point((int)Math.Round((double)rectBorder.Left + 3.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 10.0 * dpixRatio));
			reference = point;
			ref Point reference2 = ref array[1];
			Point point2 = new Point((int)Math.Round((double)rectBorder.Left + 8.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 10.0 * dpixRatio));
			reference2 = point2;
			ref Point reference3 = ref array[2];
			Point point3 = new Point((int)Math.Round((double)rectBorder.Left + 5.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 13.0 * dpixRatio));
			reference3 = point3;
			graphics.FillPolygon(cachedBrush, array);
			Graphics graphics2 = e.Graphics;
			SolidBrush cachedBrush2 = GetCachedBrush(CT.filterstatus);
			array = new Point[6];
			ref Point reference4 = ref array[0];
			point3 = new Point((int)Math.Round((double)rectBorder.Left + 6.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 5.0 * dpixRatio));
			reference4 = point3;
			ref Point reference5 = ref array[1];
			point2 = new Point((int)Math.Round((double)rectBorder.Left + 9.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 8.0 * dpixRatio));
			reference5 = point2;
			ref Point reference6 = ref array[2];
			point = new Point((int)Math.Round((double)rectBorder.Left + 9.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 13.0 * dpixRatio));
			reference6 = point;
			ref Point reference7 = ref array[3];
			Point point4 = new Point((int)Math.Round((double)rectBorder.Left + 11.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 13.0 * dpixRatio));
			reference7 = point4;
			ref Point reference8 = ref array[4];
			Point point5 = new Point((int)Math.Round((double)rectBorder.Left + 11.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 8.0 * dpixRatio));
			reference8 = point5;
			ref Point reference9 = ref array[5];
			Point point6 = new Point((int)Math.Round((double)rectBorder.Left + 14.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 5.0 * dpixRatio));
			reference9 = point6;
			graphics2.FillPolygon(cachedBrush2, array);
		}
	}

	private void DrawNormalFilterIcon(DataGridViewCellPaintingEventArgs e, Rectangle rectBorder)
	{
		Graphics graphics = e.Graphics;
		SolidBrush cachedBrush = GetCachedBrush(CT.ButtonBorder);
		Point[] array = new Point[3];
		ref Point reference = ref array[0];
		checked
		{
			Point point = new Point((int)Math.Round((double)rectBorder.Left + 5.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 7.0 * dpixRatio));
			reference = point;
			ref Point reference2 = ref array[1];
			Point point2 = new Point((int)Math.Round((double)rectBorder.Right - 4.0 * dpixRatio), (int)Math.Round((double)rectBorder.Top + 7.0 * dpixRatio));
			reference2 = point2;
			ref Point reference3 = ref array[2];
			Point point3 = new Point(rectBorder.Left + unchecked(rectBorder.Width / 2), (int)Math.Round((double)rectBorder.Bottom - 5.0 * dpixRatio));
			reference3 = point3;
			graphics.FillPolygon(cachedBrush, array);
		}
	}

	protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
	{
		col = e.ColumnIndex;
		row = e.RowIndex;
		Columns[col].SortMode = DataGridViewColumnSortMode.Programmatic;
		bool flag = false;
		string name = Columns[col].Name;
		if ((row == -1 && col > -1 && !name.Equals("Col_Preview", StringComparison.OrdinalIgnoreCase) && !name.Equals("Col_Number", StringComparison.OrdinalIgnoreCase)) ? true : false)
		{
			Rectangle cellDisplayRectangle = GetCellDisplayRectangle(col, row, cutOverflow: true);
			if (((double)e.X >= (double)cellDisplayRectangle.Width - 16.0 * dpixRatio && e.X <= cellDisplayRectangle.Width && (double)e.Y >= (double)cellDisplayRectangle.Height - 16.0 * dpixRatio && e.Y <= cellDisplayRectangle.Height) ? true : false)
			{
				flag = true;
			}
		}
		if (flag)
		{
			Cursor = Cursors.Default;
		}
		else
		{
			SortByColumn(Columns[col]);
		}
		base.OnColumnHeaderMouseClick(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (DesignMode || Columns.Count == 0)
		{
			return;
		}
		HitTestInfo hitTestInfo = HitTest(e.X, e.Y);
		int num = -1;
		bool flag = false;
		if ((hitTestInfo.Type == DataGridViewHitTestType.ColumnHeader && hitTestInfo.RowIndex == -1) ? true : false)
		{
			if ((hitTestInfo.ColumnIndex >= 0 && hitTestInfo.ColumnIndex < Columns.Count) ? true : false)
			{
				num = hitTestInfo.ColumnIndex;
			}
			string name = Columns[hitTestInfo.ColumnIndex].Name;
			if ((!name.Equals("Col_Preview", StringComparison.OrdinalIgnoreCase) && !name.Equals("Col_Number", StringComparison.OrdinalIgnoreCase)) ? true : false)
			{
				Rectangle cellDisplayRectangle = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: true);
				Rectangle rectangle = checked(new Rectangle((int)Math.Round((double)cellDisplayRectangle.Right - 16.0 * dpixRatio), (int)Math.Round((double)cellDisplayRectangle.Bottom - 16.0 * dpixRatio), (int)Math.Round(16.0 * dpixRatio), (int)Math.Round(16.0 * dpixRatio)));
				if ((e.X >= rectangle.Left && e.X <= rectangle.Right && e.Y >= rectangle.Top && e.Y <= rectangle.Bottom) ? true : false)
				{
					flag = true;
				}
			}
		}
		bool flag2 = false;
		if (_isOverFilterButton != flag)
		{
			flag2 = true;
			_isOverFilterButton = flag;
			Cursor = (_isOverFilterButton ? Cursors.Hand : Cursors.Default);
		}
		if (_hoverColumnIndex != num)
		{
			if ((_hoverColumnIndex != -1 && _hoverColumnIndex < Columns.Count) ? true : false)
			{
				InvalidateColumn(_hoverColumnIndex);
			}
			_hoverColumnIndex = num;
			if (_hoverColumnIndex != -1)
			{
				InvalidateColumn(_hoverColumnIndex);
			}
		}
		else if ((flag2 && _hoverColumnIndex != -1) ? true : false)
		{
			InvalidateColumn(_hoverColumnIndex);
		}
	}

	private void SortByColumn(DataGridViewColumn OwningColumn)
	{
		ListSortDirection listSortDirection = ListSortDirection.Ascending;
		if ((SortedColumn == OwningColumn && SortOrder == SortOrder.Ascending) ? true : false)
		{
			listSortDirection = ListSortDirection.Descending;
		}
		CustomComparer comparer = new CustomComparer(OwningColumn.Index, listSortDirection);
		Sort(comparer);
		SortedColumn = OwningColumn;
		SortOrder = (SortOrder)Conversions.ToInteger(Interaction.IIf(listSortDirection == ListSortDirection.Descending, SortOrder.Descending, SortOrder.Ascending));
	}

	protected override void OnScroll(ScrollEventArgs e)
	{
		base.OnScroll(e);
		try
		{
			EndEdit();
			EditMode = DataGridViewEditMode.EditOnKeystroke;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
	{
		base.OnColumnWidthChanged(e);
		if (!Columns[e.Column.Index].Name.Contains("PropResolvedVal_") & !Columns[e.Column.Index].Name.Contains("PropVal_"))
		{
			return;
		}
		int num = Columns[e.Column.Index].Width;
		checked
		{
			int num2 = ColumnCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 <= num5)
				{
					if (!(!Columns[num3].Name.Contains("PropResolvedVal_") & !Columns[num3].Name.Contains("PropVal_")) && ((Operators.CompareString(Columns[e.Column.Index].HeaderText, Columns[num3].HeaderText, TextCompare: false) == 0) & (num3 != e.Column.Index)))
					{
						Columns[num3].Width = num;
						break;
					}
					num3++;
					continue;
				}
				break;
			}
		}
	}

	protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
	{
		base.OnDataError(displayErrorDialogIfNoHandler, e);
		e.Cancel = false;
	}

	public void DoubleBuffer(DataGridView DGV)
	{
		Type type = DGV.GetType();
		PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		property.SetValue(DGV, true, null);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			foreach (SolidBrush value in _brushCache.Values)
			{
				value.Dispose();
			}
			_brushCache.Clear();
			foreach (Pen value2 in _penCache.Values)
			{
				value2.Dispose();
			}
			_penCache.Clear();
			foreach (LinearGradientBrush value3 in _gradientBrushCache.Values)
			{
				value3.Dispose();
			}
			_gradientBrushCache.Clear();
		}
		base.Dispose(disposing);
	}
}
