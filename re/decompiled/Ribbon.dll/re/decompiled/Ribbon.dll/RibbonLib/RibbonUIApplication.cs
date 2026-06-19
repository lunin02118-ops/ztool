using System.Runtime.InteropServices;
using System.Windows.Forms;
using RibbonLib.Interop;

namespace RibbonLib;

[ComVisible(true)]
[Guid("B13C3248-093D-4366-9832-A936610846FD")]
internal class RibbonUIApplication : IUIApplication
{
	private Ribbon _ribbon;

	private Ribbon _ribbonControl;

	public IUIRibbon UIRibbon { get; private set; }

	public RibbonUIApplication(Ribbon ribbon, Ribbon ribbonControl)
	{
		_ribbon = ribbon;
		_ribbonControl = ribbonControl;
	}

	public HRESULT OnViewChanged(uint viewId, ViewType typeID, object view, ViewVerb verb, int uReasonCode)
	{
		HRESULT hRESULT = HRESULT.E_FAIL;
		if (typeID == ViewType.Ribbon)
		{
			switch (verb)
			{
			case ViewVerb.Create:
				if (UIRibbon == null)
				{
					UIRibbon = view as IUIRibbon;
				}
				_ribbonControl.BeginInvoke(new MethodInvoker(_ribbonControl.RaiseViewCreated));
				hRESULT = HRESULT.S_OK;
				break;
			case ViewVerb.Size:
			{
				hRESULT = UIRibbon.GetHeight(out var cy);
				if (!NativeMethods.Failed(hRESULT))
				{
					_ribbonControl.Height = (int)cy;
				}
				break;
			}
			case ViewVerb.Destroy:
				UIRibbon = null;
				hRESULT = HRESULT.S_OK;
				break;
			}
		}
		return hRESULT;
	}

	public HRESULT OnCreateUICommand(uint commandId, CommandType typeID, out IUICommandHandler commandHandler)
	{
		commandHandler = _ribbon;
		return HRESULT.S_OK;
	}

	public HRESULT OnDestroyUICommand(uint commandId, CommandType typeID, IUICommandHandler commandHandler)
	{
		return HRESULT.S_OK;
	}
}
