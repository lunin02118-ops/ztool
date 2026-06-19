using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[Guid("D428903C-729A-491d-910D-682A08FF2522")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IUIApplication
{
	[PreserveSig]
	HRESULT OnViewChanged(uint viewID, ViewType typeID, [In][MarshalAs(UnmanagedType.IUnknown)] object view, ViewVerb verb, int uReasonCode);

	[PreserveSig]
	HRESULT OnCreateUICommand(uint commandID, CommandType typeID, out IUICommandHandler commandHandler);

	[PreserveSig]
	HRESULT OnDestroyUICommand(uint commandID, CommandType typeID, [Optional][In] IUICommandHandler commandHandler);
}
