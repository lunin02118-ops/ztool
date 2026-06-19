using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6502AE91-A14D-44b5-BBD0-62AACC581D52")]
public interface IUICollectionChangedEvent
{
	[PreserveSig]
	HRESULT OnChanged(CollectionChange action, uint oldIndex, [Optional][In][MarshalAs(UnmanagedType.IUnknown)] object oldItem, uint newIndex, [Optional][In][MarshalAs(UnmanagedType.IUnknown)] object newItem);
}
