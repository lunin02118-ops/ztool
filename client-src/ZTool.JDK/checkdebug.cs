using System;
using System.Diagnostics;
using System.Timers;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool.JDK;

internal class checkdebug
{
	private string na;

	public checkdebug()
	{
		na = "";
		Timer timer = new Timer(5000.0);
		timer.Elapsed += tmr_Elapsed;
		timer.Start();
	}

	public void tmr_Elapsed(object sender, EventArgs e)
	{
		Timer timer = (Timer)sender;
		try
		{
			if (Operators.CompareString(na, "", TextCompare: false) == 0)
			{
				na = code.Parent(Process.GetCurrentProcess()).ProcessName;
			}
			if (na.Equals("dnSpy", StringComparison.OrdinalIgnoreCase))
			{
				logopathlist.WriteLog("Сведения об ошибке: обнаружен недопустимый запуск dnSpy");
				Environment.Exit(0);
			}
			timer.Stop();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
