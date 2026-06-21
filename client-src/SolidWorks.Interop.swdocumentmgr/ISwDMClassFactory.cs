using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[Guid("BDF10361-1191-42F8-80D7-55B86EBC9EDD")]
[CompilerGenerated]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[TypeIdentifier]
public interface ISwDMClassFactory
{
	[return: MarshalAs(UnmanagedType.Interface)]
	SwDMApplication GetApplication([In][MarshalAs(UnmanagedType.BStr)] string LicKey);
}
