using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool.CustomFileBorser1;

[Description("提供一个Vista样式的选择文件对话框")]
[Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
public class FileBorser : Component
{
	[ComImport]
	[Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
	private class FileOpenDialog
	{
	}

	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
	private interface IFileOpenDialog
	{
		[PreserveSig]
		uint Show([In] IntPtr parent);

		void SetFileTypes();

		void SetFileTypeIndex([In] uint iFileType);

		void GetFileTypeIndex(ref uint piFileType);

		void Advise();

		void Unadvise();

		void SetOptions([In] FOS fos);

		void GetOptions(ref FOS pfos);

		void SetDefaultFolder(IShellItem psi);

		void SetFolder(IShellItem psi);

		void GetFolder(ref IShellItem ppsi);

		void GetCurrentSelection(ref IShellItem ppsi);

		void SetFileName([In][MarshalAs(UnmanagedType.LPWStr)] string pszName);

		void GetFileName([MarshalAs(UnmanagedType.LPWStr)] ref string pszName);

		void SetTitle([In][MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		void SetOkButtonLabel([In][MarshalAs(UnmanagedType.LPWStr)] string pszText);

		void SetFileNameLabel([In][MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

		void GetResult(ref IShellItem ppsi);

		void AddPlace(IShellItem psi, int alignment);

		void SetDefaultExtension([In][MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

		void Close(int hr);

		void SetClientGuid();

		void ClearClientData();

		void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);

		void GetResults([MarshalAs(UnmanagedType.Interface)] ref IntPtr ppenum);

		void GetSelectedItems([MarshalAs(UnmanagedType.Interface)] ref IntPtr ppsai);
	}

	[ComImport]
	[Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	private interface IShellItem
	{
		void BindToHandler();

		void GetParent();

		void GetDisplayName([In] SIGDN sigdnName, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszName);

		void GetAttributes();

		void Compare();
	}

	private enum SIGDN : uint
	{
		SIGDN_DESKTOPABSOLUTEEDITING = 2147794944u,
		SIGDN_DESKTOPABSOLUTEPARSING = 2147647488u,
		SIGDN_FILESYSPATH = 2147844096u,
		SIGDN_NORMALDISPLAY = 0u,
		SIGDN_PARENTRELATIVE = 2148007937u,
		SIGDN_PARENTRELATIVEEDITING = 2147684353u,
		SIGDN_PARENTRELATIVEFORADDRESSBAR = 2147991553u,
		SIGDN_PARENTRELATIVEPARSING = 2147581953u,
		SIGDN_URL = 2147909632u
	}

	[Flags]
	private enum FOS
	{
		FOS_ALLNONSTORAGEITEMS = 0x80,
		FOS_ALLOWMULTISELECT = 0x200,
		FOS_CREATEPROMPT = 0x2000,
		FOS_DEFAULTNOMINIMODE = 0x20000000,
		FOS_DONTADDTORECENT = 0x2000000,
		FOS_FILEMUSTEXIST = 0x1000,
		FOS_FORCEFILESYSTEM = 0x40,
		FOS_FORCESHOWHIDDEN = 0x10000000,
		FOS_HIDEMRUPLACES = 0x20000,
		FOS_HIDEPINNEDPLACES = 0x40000,
		FOS_NOCHANGEDIR = 8,
		FOS_NODEREFERENCELINKS = 0x100000,
		FOS_NOREADONLYRETURN = 0x8000,
		FOS_NOTESTFILECREATE = 0x10000,
		FOS_NOVALIDATE = 0x100,
		FOS_OVERWRITEPROMPT = 2,
		FOS_PATHMUSTEXIST = 0x800,
		FOS_PICKFOLDERS = 0x20,
		FOS_SHAREAWARE = 0x4000,
		FOS_STRICTFILETYPES = 4
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private const uint ERROR_CANCELLED = 2147943623u;

	public string DirectoryPath
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public string Title
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

	public FileBorser()
	{
		__ENCAddToList(this);
	}

	public DialogResult ShowDialog(IWin32Window owner)
	{
		IntPtr parent = owner?.Handle ?? GetActiveWindow();
		IFileOpenDialog fileOpenDialog = (IFileOpenDialog)new FileOpenDialog();
		if (Operators.CompareString(Title, "", TextCompare: false) != 0)
		{
			fileOpenDialog.SetTitle(Title);
		}
		try
		{
			IShellItem ppsi = null;
			if (!string.IsNullOrEmpty(DirectoryPath))
			{
				IntPtr ppIdl = default(IntPtr);
				uint rgflnOut = 0u;
				if (SHILCreateFromPath(DirectoryPath, ref ppIdl, ref rgflnOut) == 0 && SHCreateShellItem(IntPtr.Zero, IntPtr.Zero, ppIdl, ref ppsi) == 0)
				{
					fileOpenDialog.SetFolder(ppsi);
				}
			}
			fileOpenDialog.SetOptions(FOS.FOS_FORCEFILESYSTEM | FOS.FOS_PICKFOLDERS);
			uint num = fileOpenDialog.Show(parent);
			if (num == 2147943623u)
			{
				return DialogResult.Cancel;
			}
			if ((ulong)num != 0)
			{
				return DialogResult.Abort;
			}
			fileOpenDialog.GetResult(ref ppsi);
			string ppszName = null;
			ppsi.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, ref ppszName);
			DirectoryPath = ppszName;
			return DialogResult.OK;
		}
		finally
		{
			Marshal.ReleaseComObject(fileOpenDialog);
		}
	}

	[DllImport("shell32.dll")]
	private static extern int SHILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath, ref IntPtr ppIdl, ref uint rgflnOut);

	[DllImport("shell32.dll")]
	private static extern int SHCreateShellItem(IntPtr pidlParent, IntPtr psfParent, IntPtr pidl, ref IShellItem ppsi);

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();
}
