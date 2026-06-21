using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[Guid("EC65A486-E0E8-42CD-BF7D-272911B2B9E0")]
[TypeIdentifier]
[CompilerGenerated]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ISwDMApplication
{
	[return: MarshalAs(UnmanagedType.Interface)]
	SwDMDocument GetDocument([In][MarshalAs(UnmanagedType.BStr)] string FullPathName, [In] SwDmDocumentType docType, [In] bool allowReadOnly, out SwDmDocumentOpenError result);
}
