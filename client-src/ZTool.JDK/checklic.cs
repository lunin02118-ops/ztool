using System;
using System.Timers;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool.JDK;

internal class checklic
{
	public checklic()
	{
		Timer timer = new Timer(10.0);
		timer.Elapsed += tmr_Elapsed;
		timer.AutoReset = false;
		timer.Enabled = true;
		code.g_trig = true;
	}

	public void tmr_Elapsed(object sender, EventArgs e)
	{
		Timer timer = (Timer)sender;
		try
		{
			if (!code.g_trig)
			{
				return;
			}
			code.g_trig = false;
			Prog1 prog = new Prog1();
			Prog2 prog2 = new Prog2();
			SR sR = new SR();
			if (!prog.exit_g() || !prog2.exit_g())
			{
				string text = "";
				string use_date = "";
				if (!sR.IsReg2("来生缘。。。", ref text, ref use_date))
				{
					goto IL_0068;
				}
			}
			if (false)
			{
				goto IL_0068;
			}
			code.canrun = true;
			goto IL_008f;
			IL_008f:
			timer.Stop();
			timer.Dispose();
			return;
			IL_0068:
			if (!code.TMode)
			{
				code.canrun = false;
			}
			else
			{
				code.canrun = true;
			}
			goto IL_008f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
	}
}
