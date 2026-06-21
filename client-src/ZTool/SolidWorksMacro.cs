using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class SolidWorksMacro
{
	[DebuggerNonUserCode]
	public SolidWorksMacro()
	{
	}

	[DllImport("ole32.dll")]
	private static extern int CreateItemMoniker([MarshalAs(UnmanagedType.LPWStr)] string lpszDelim, [MarshalAs(UnmanagedType.LPWStr)] string lpszItem, ref IMoniker ppmk);

	[DllImport("ole32.dll")]
	private static extern int GetRunningObjectTable(uint reserved, ref IRunningObjectTable pprot);

	public bool RunSW_ByID(int SWAppID)
	{
		bool result;
		try
		{
			Process processById = Process.GetProcessById(SWAppID);
			IRunningObjectTable pprot = null;
			IMoniker ppmk = null;
			CreateItemMoniker(null, "SolidWorks_PID_" + processById.Id, ref ppmk);
			GetRunningObjectTable(0u, ref pprot);
			code.swApp = null;
			pprot.GetObject(ppmk, out code.swApp);
			result = code.swApp != null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Process[] GetProcessesInfo(string ProcessName)
	{
		Process[] result = null;
		try
		{
			result = Process.GetProcessesByName(ProcessName);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
