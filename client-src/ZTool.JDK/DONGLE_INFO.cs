using System.Runtime.InteropServices;

namespace ZTool.JDK;

internal struct DONGLE_INFO
{
	public uint m_Ver_Hardware;

	public uint m_Ver_Firmware;

	public uint m_RealTime_UTC;

	public uint m_ProductID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] m_HardSN;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] m_BirthDay;
}
