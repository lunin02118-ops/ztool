using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
public sealed class ControlExtensions
{
	public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
	{
		try
		{
			if (!control.IsDisposed)
			{
				if (control.InvokeRequired)
				{
					control.Invoke(action);
				}
				else
				{
					action();
				}
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
