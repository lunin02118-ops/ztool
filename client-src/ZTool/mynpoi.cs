using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;

namespace ZTool;

[StandardModule]
public static class mynpoi
{
	public static void InsertRows(ref ISheet sheet, int fromRowIndex, int rowCount, List<int> collist)
	{
		checked
		{
			try
			{
				IRow row = sheet.GetRow(fromRowIndex);
				if (Information.IsNothing(row))
				{
					row = sheet.CreateRow(fromRowIndex);
					row.Height = sheet.DefaultRowHeight;
				}
				ICellStyle rowStyle = row.RowStyle;
				if (fromRowIndex + 1 > sheet.LastRowNum)
				{
					sheet.CreateRow(fromRowIndex + 1);
				}
				sheet.ShiftRows(fromRowIndex + 1, sheet.LastRowNum, rowCount, copyRowHeight: true, resetOriginalRowHeight: false);
				int num = fromRowIndex + 1;
				int num2 = fromRowIndex + rowCount;
				int num3 = num;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					IRow row2 = sheet.CreateRow(num3);
					if (!Information.IsNothing(row))
					{
						row2.Height = row.Height;
						if (!Information.IsNothing(rowStyle))
						{
							row2.RowStyle = rowStyle;
						}
						int num6 = row.LastCellNum - 1;
						int num7 = 0;
						while (true)
						{
							int num8 = num7;
							num5 = num6;
							if (num8 > num5)
							{
								break;
							}
							ICell cell = row.GetCell(num7);
							ICell cell2 = row2.CreateCell(num7);
							if (!Information.IsNothing(cell))
							{
								ICellStyle cellStyle = cell.CellStyle;
								if (!Information.IsNothing(cellStyle))
								{
									cell2.CellStyle = cell.CellStyle;
									string cellValue = Conversions.ToString(GetCellValue(cell));
									cell2.SetCellType(cell.CellType);
									try
									{
										if (cell2.CellType == CellType.Formula)
										{
											cell2.SetCellFormula(cell.CellFormula);
										}
										else if (!collist.Contains(num7))
										{
											cell2.SetCellValue(cellValue);
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
							num7++;
						}
					}
					num3++;
				}
				sheet.ForceFormulaRecalculation = true;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void AutoColumnWidth(this ISheet sheet, int srow, int col_exclude)
	{
		IRow row = sheet.GetRow(srow);
		if (Information.IsNothing(row))
		{
			return;
		}
		checked
		{
			try
			{
				int num = row.LastCellNum - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (num2 != col_exclude)
					{
						int num5 = (int)Math.Round((double)sheet.GetColumnWidth(num2) / 256.0);
						int num6 = sheet.LastRowNum - 1;
						int num7 = srow;
						while (true)
						{
							int num8 = num7;
							num4 = num6;
							if (num8 > num4)
							{
								break;
							}
							IRow row2 = sheet.GetRow(num7);
							ICell cell = row2.GetCell(num2);
							int num9 = Encoding.UTF8.GetBytes(Convert.ToString(cell)).Length;
							num5 = ((num5 < num9) ? num9 : num5);
							num7++;
						}
						sheet.SetColumnWidth(num2, num5 * 256 + 200);
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

	public static object GetCellValue(ICell item)
	{
		if (item == null)
		{
			return string.Empty;
		}
		switch ((int)item.CellType)
		{
		case 4:
			return item.BooleanCellValue;
		case 5:
			return ErrorEval.GetText(item.ErrorCellValue);
		case 2:
			switch ((int)item.CachedFormulaResultType)
			{
			case 4:
				return item.BooleanCellValue;
			case 5:
				return ErrorEval.GetText(item.ErrorCellValue);
			case 0:
				if (DateUtil.IsCellDateFormatted(item))
				{
					return item.DateCellValue.ToString("yyyy/MM/dd");
				}
				return item.NumericCellValue;
			case 1:
			{
				string stringCellValue = item.StringCellValue;
				if (!string.IsNullOrEmpty(stringCellValue))
				{
					return stringCellValue.ToString();
				}
				return string.Empty;
			}
			default:
				return string.Empty;
			}
		case 0:
			if (DateUtil.IsCellDateFormatted(item))
			{
				return item.DateCellValue.ToString("yyyy/MM/dd");
			}
			return item.NumericCellValue;
		case 1:
			return item.StringCellValue;
		default:
			return string.Empty;
		}
	}
}
