using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("A267ED50-CB6C-4C8A-8488-EC7D7616625F")]
[CompilerGenerated]
[TypeIdentifier]
public interface ISwDMConfiguration7 : ISwDMConfiguration6
{
	void _VtblGap1_21();

	[return: MarshalAs(UnmanagedType.Struct)]
	object GetComponents();
}
