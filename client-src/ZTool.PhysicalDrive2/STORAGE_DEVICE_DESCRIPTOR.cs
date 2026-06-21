using System.Runtime.InteropServices;

namespace ZTool.PhysicalDrive2;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct STORAGE_DEVICE_DESCRIPTOR
{
	public uint Version;

	public uint size;

	public byte DeviceType;

	public byte DeviceTypeModifier;

	public byte RemovableMedia;

	public byte CommandQueueing;

	public uint VendorIdOffset;

	public uint ProductIdOffset;

	public uint ProductRevisionOffset;

	public uint SerialNumberOffset;

	public uint BusType;

	public uint RawPropertiesLength;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] RawDeviceProperties;
}
