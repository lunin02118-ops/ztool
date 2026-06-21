using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[TypeIdentifier]
[CompilerGenerated]
[Guid("3C4D792F-5C12-4C43-9EFF-FE7830728126")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ISwDMDocument14 : ISwDMDocument13
{
	new void _VtblGap1_4();

	[DispId(5)]
	new SwDMConfigurationMgr ConfigurationManager
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
