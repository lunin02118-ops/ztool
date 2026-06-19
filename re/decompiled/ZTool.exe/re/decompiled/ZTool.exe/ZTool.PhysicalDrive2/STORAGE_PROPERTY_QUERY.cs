using System.Runtime.InteropServices;

namespace ZTool.PhysicalDrive2;

internal struct STORAGE_PROPERTY_QUERY
{
	public uint PropertyId;

	public uint QueryType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public byte[] AdditionalParameters;
}
