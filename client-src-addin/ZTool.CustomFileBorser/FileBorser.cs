using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZTool.CustomFileBorser;

[Description("提供一个Vista样式的选择文件对话框")]
[Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
public class FileBorser : Component
{
	[ComImport]
	[Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
	private class Type_20
	{
	}

	[ComImport]
	[Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	private interface Type_21
	{
		[PreserveSig]
		uint Show([In] IntPtr parent);

		void SetFileTypes();

		void SetFileTypeIndex([In] uint iFileType);

		void GetFileTypeIndex(ref uint piFileType);

		void Advise();

		void Unadvise();

		void SetOptions([In] Type_24 fos);

		void GetOptions(ref Type_24 pfos);

		void SetDefaultFolder(Type_22 psi);

		void SetFolder(Type_22 psi);

		void GetFolder(ref Type_22 ppsi);

		void GetCurrentSelection(ref Type_22 ppsi);

		void SetFileName([In][MarshalAs(UnmanagedType.LPWStr)] string pszName);

		void GetFileName([MarshalAs(UnmanagedType.LPWStr)] ref string pszName);

		void SetTitle([In][MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		void SetOkButtonLabel([In][MarshalAs(UnmanagedType.LPWStr)] string pszText);

		void SetFileNameLabel([In][MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

		void GetResult(ref Type_22 ppsi);

		void AddPlace(Type_22 psi, int alignment);

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
	private interface Type_22
	{
		void BindToHandler();

		void GetParent();

		void GetDisplayName([In] Type_23 sigdnName, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszName);

		void GetAttributes();

		void Compare();
	}

	private enum Type_23 : uint
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
	private enum Type_24
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

	[CompilerGenerated]
	private string f_88;

	private const uint f_89 = 2147943623u;

	public string DirectoryPath
	{
		get
		{
			return f_88;
		}
		set
		{
			f_88 = value;
		}
	}

	public DialogResult ShowDialog(IWin32Window owner)
	{
		IntPtr parent = owner?.Handle ?? m_82();
		Type_21 type_ = (Type_21)new Type_20();
		try
		{
			Type_22 ppsi = null;
			if (!string.IsNullOrEmpty(DirectoryPath))
			{
				IntPtr intPtr = default(IntPtr);
				uint num = 0u;
				if (m_80(DirectoryPath, ref intPtr, ref num) == 0 && m_81(IntPtr.Zero, IntPtr.Zero, intPtr, ref ppsi) == 0)
				{
					type_.SetFolder(ppsi);
				}
			}
			type_.SetOptions(Type_24.FOS_FORCEFILESYSTEM | Type_24.FOS_PICKFOLDERS);
			uint num2 = type_.Show(parent);
			if (num2 == 2147943623u)
			{
				return DialogResult.Cancel;
			}
			if ((ulong)num2 != 0)
			{
				return DialogResult.Abort;
			}
			type_.GetResult(ref ppsi);
			string ppszName = null;
			ppsi.GetDisplayName(Type_23.SIGDN_FILESYSPATH, ref ppszName);
			DirectoryPath = ppszName;
			return DialogResult.OK;
		}
		finally
		{
			Marshal.ReleaseComObject(type_);
		}
	}

	[DllImport("shell32.dll", EntryPoint = "SHILCreateFromPath")]
	private static extern int m_80([MarshalAs(UnmanagedType.LPWStr)] string P_0, ref IntPtr P_1, ref uint P_2);

	[DllImport("shell32.dll", EntryPoint = "SHCreateShellItem")]
	private static extern int m_81(IntPtr P_0, IntPtr P_1, IntPtr P_2, ref Type_22 P_3);

	[DllImport("user32.dll", EntryPoint = "GetActiveWindow")]
	private static extern IntPtr m_82();
}
