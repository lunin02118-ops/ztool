using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

internal class MyapplicationContext : ApplicationContext
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

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

	private void onFormClosed(object sender, EventArgs e)
	{
		if (Application.OpenForms.Count == 0)
		{
			ExitThread();
			Application.Exit();
		}
	}

	public MyapplicationContext()
	{
		__ENCAddToList(this);
		string startType = Program.StartType;
		if (Operators.CompareString(startType, Conversions.ToString(0), TextCompare: false) == 0)
		{
			MyProject.Forms.Frmmain.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(1), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmOutputlist.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(2), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmPrintlist.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(3), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmSetDrwlist.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(4), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmReplacePartslist.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(5), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmSyncDrwName.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(6), TextCompare: false) == 0)
		{
			MyProject.Forms.Frmmerge_split_pdf.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(110), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmRg.Show();
		}
		else if (Operators.CompareString(startType, Conversions.ToString(120), TextCompare: false) == 0)
		{
			// Vendor online update disabled (see Phase 3): the dedicated update
			// process must not open the vendor window; exit immediately instead.
			Environment.Exit(0);
		}
		else if (Operators.CompareString(startType, Conversions.ToString(130), TextCompare: false) == 0)
		{
			MyProject.Forms.FrmAbout.Show();
		}
		else
		{
			MyProject.Forms.Frmmain.Show();
		}
	}
}
