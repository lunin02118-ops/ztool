using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

internal class CustomFilter
{
	[CompilerGenerated]
	internal class _Closure_0024__90
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__90(_Closure_0024__90 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__90()
		{
		}
	}

	private List<CustomRule> filterarr;

	public CustomFilter(List<string> filtername)
	{
		filterarr = null;
		checked
		{
			try
			{
				filterarr = new List<CustomRule>();
				int num = CConfigMng.Config.FilterRulesList.Count - 1;
				int num2 = 0;
				_Closure_0024__90 closure_0024__ = default(_Closure_0024__90);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						closure_0024__ = new _Closure_0024__90(closure_0024__);
						closure_0024__._0024VB_0024Local_str = CConfigMng.Config.FilterRulesList[num2].name;
						if (filtername.Exists(closure_0024__._Lambda_0024__148))
						{
							filterarr.Add(CConfigMng.Config.FilterRulesList[num2]);
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
			}
		}
	}

	public bool FilterByRule(int row)
	{
		List<bool> list = new List<bool>();
		bool flag = false;
		checked
		{
			try
			{
				if (filterarr.Count < 1)
				{
					return false;
				}
				int num = filterarr.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (!Information.IsNothing(filterarr[num2]))
					{
						list.Clear();
						bool type = filterarr[num2].type;
						int num5 = filterarr[num2].RuleList.Count - 1;
						int num6 = 0;
						while (true)
						{
							int num7 = num6;
							num4 = num5;
							if (num7 > num4)
							{
								break;
							}
							string[] array = Strings.Split(filterarr[num2].RuleList[num6], "\t|@#$%|");
							if (array.Length >= 3 && Operators.CompareString(array[0], "", TextCompare: false) != 0 && Operators.CompareString(array[1], "", TextCompare: false) != 0 && 0 == 0)
							{
								bool flag2 = false;
								int num8 = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
								int num9 = 0;
								while (true)
								{
									int num10 = num9;
									num4 = num8;
									if (num10 > num4)
									{
										break;
									}
									if (num9 != MyProject.Forms.Frmmain.Col_Preview.Index)
									{
										string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num9].HeaderText;
										string name = MyProject.Forms.Frmmain.DGV1.Columns[num9].Name;
										string text = "";
										text = ((!((num9 == MyProject.Forms.Frmmain.Col_Extname.Index) | (num9 == MyProject.Forms.Frmmain.Col_Drw.Index))) ? Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num9, row].Value)) : Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num9, row].Tag)));
										bool flag3 = false;
										if ((array[0].StartsWith("%") && array[0].EndsWith("%") && name.Contains("PropVal_")) ? true : false)
										{
											if (Operators.CompareString(array[0].TrimStart('%').TrimEnd('%'), headerText, TextCompare: false) == 0)
											{
												flag3 = true;
											}
										}
										else if ((array[0].StartsWith("$") && array[0].EndsWith("$") && name.Contains("PropResolvedVal_")) ? true : false)
										{
											if (Operators.CompareString(array[0].TrimStart('$').TrimEnd('$'), headerText, TextCompare: false) == 0)
											{
												flag3 = true;
											}
										}
										else if ((array[0].StartsWith("<") && array[0].EndsWith(">") && !name.Contains("PropResolvedVal_") && !name.Contains("PropVal_") && num9 != MyProject.Forms.Frmmain.Col_Extname.Index && num9 != MyProject.Forms.Frmmain.Col_Drw.Index) ? true : false)
										{
											if (Operators.CompareString(array[0].TrimStart('<').TrimEnd('>'), headerText, TextCompare: false) == 0)
											{
												flag3 = true;
											}
										}
										else if ((array[0].StartsWith("<") && array[0].EndsWith(">") && num9 == MyProject.Forms.Frmmain.Col_Extname.Index) ? true : false)
										{
											if (Operators.CompareString(array[0].TrimStart('<').TrimEnd('>'), "Тип файла", TextCompare: false) == 0)
											{
												flag3 = true;
											}
										}
										else
										{
											if ((!array[0].StartsWith("<") || !array[0].EndsWith(">") || num9 != MyProject.Forms.Frmmain.Col_Drw.Index) && 0 == 0)
											{
												goto IL_0827;
											}
											if (Operators.CompareString(array[0].TrimStart('<').TrimEnd('>'), "Наличие чертежа", TextCompare: false) == 0)
											{
												flag3 = true;
											}
										}
										if (flag3)
										{
											string[] array2 = array[2].Trim().Split(';');
											int num11 = array2.Length - 1;
											int num12 = 0;
											while (true)
											{
												int num13 = num12;
												num4 = num11;
												if (num13 > num4)
												{
													break;
												}
												switch (array[1])
												{
												case "Равно":
													if (text.Trim().Equals(array2[num12].Trim(), StringComparison.OrdinalIgnoreCase))
													{
														flag2 = true;
													}
													break;
												case "Не равно":
													if (!text.Trim().Equals(array2[num12].Trim(), StringComparison.OrdinalIgnoreCase))
													{
														flag2 = true;
													}
													break;
												case "Содержит":
													if (((Operators.CompareString(array2[num12].Trim(), "", TextCompare: false) != 0 && text.Trim().ToUpper().Contains(array2[num12].Trim().ToUpper())) || (Operators.CompareString(array2[num12].Trim(), "", TextCompare: false) == 0 && Operators.CompareString(text.Trim(), "", TextCompare: false) == 0)) ? true : false)
													{
														flag2 = true;
													}
													break;
												case "Не содержит":
													if (((Operators.CompareString(array2[num12].Trim(), "", TextCompare: false) != 0 && !text.Trim().ToUpper().Contains(array2[num12].Trim().ToUpper())) || (Operators.CompareString(array2[num12].Trim(), "", TextCompare: false) == 0 && Operators.CompareString(text.Trim(), "", TextCompare: false) != 0)) ? true : false)
													{
														flag2 = true;
													}
													break;
												case "Начинается с":
													if (text.Trim().StartsWith(array2[num12].Trim(), StringComparison.OrdinalIgnoreCase))
													{
														flag2 = true;
													}
													break;
												case "Не начинается с":
													if (!text.Trim().StartsWith(array2[num12].Trim(), StringComparison.OrdinalIgnoreCase))
													{
														flag2 = true;
													}
													break;
												case "Заканчивается на":
													if (text.Trim().EndsWith(array2[num12].Trim(), StringComparison.OrdinalIgnoreCase))
													{
														flag2 = true;
													}
													break;
												case "Не заканчивается на":
													if (!text.Trim().EndsWith(array2[num12].Trim(), StringComparison.OrdinalIgnoreCase))
													{
														flag2 = true;
													}
													break;
												}
												if (flag2)
												{
													break;
												}
												num12++;
											}
											if ((type && flag2) ? true : false)
											{
												return true;
											}
											if (!type)
											{
												list.Add(flag2);
											}
											break;
										}
									}
									goto IL_0827;
									IL_0827:
									num9++;
								}
							}
							num6++;
						}
						if ((!type && !list.Contains(item: false)) ? true : false)
						{
							return true;
						}
					}
					num2++;
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
			return false;
		}
	}
}
