using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[CompilerGenerated]
[Guid("E945D303-E8B5-4F3C-88C1-D10E17FA8271")]
[TypeIdentifier]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ISwDMComponent9 : ISwDMComponent8
{
	void _VtblGap1_1();

	[DispId(2)]
	string ConfigurationName
	{
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	void _VtblGap2_5();

	[DispId(8)]
	bool IsVirtual
	{
		get; [param: In]
		set;
	}

	void _VtblGap3_1();

	bool IsEnvelope();

	[DispId(11)]
	int ExcludeFromBOM
	{
		get; [param: In]
		set;
	}

	void _VtblGap4_1();

	[DispId(13)]
	string PathName
	{
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(14)]
	string SelectName
	{
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}
}
