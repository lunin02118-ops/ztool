using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

namespace ZTool;

public class MyShellLink
{
	[ComImport]
	[Guid("00021401-0000-0000-C000-000000000046")]
	internal class ShellLink
	{
	}

	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("000214F9-0000-0000-C000-000000000046")]
	internal interface IShellLink
	{
		void GetPath([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, ref IntPtr pfd, int fFlags);

		void GetIDList(ref IntPtr ppidl);

		void SetIDList(IntPtr pidl);

		void GetDescription([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);

		void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		void GetWorkingDirectory([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

		void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

		void GetArguments([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

		void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

		void GetHotkey(ref short pwHotkey);

		void SetHotkey(short wHotkey);

		void GetShowCmd(ref int piShowCmd);

		void SetShowCmd(int iShowCmd);

		void GetIconLocation([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, ref int piIcon);

		void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

		void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);

		void Resolve(IntPtr hwnd, int fFlags);

		void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
	}

	[DebuggerNonUserCode]
	public MyShellLink()
	{
	}

	public void creatShortcut()
	{
		IShellLink shellLink = (IShellLink)new ShellLink();
		shellLink.SetDescription("Эффективный помощник для SolidWorks\nПакетное переименование, редактирование свойств, печать, конвертация чертежей, создание спецификаций и т. д.");
		shellLink.SetPath(Application.ExecutablePath);
		shellLink.SetWorkingDirectory(Application.StartupPath);
		IPersistFile persistFile = (IPersistFile)shellLink;
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string text = Path.Combine(folderPath, "SWTools.lnk");
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		persistFile.Save(text, fRemember: false);
	}
}
