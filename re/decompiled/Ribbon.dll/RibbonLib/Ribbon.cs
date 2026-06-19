using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using RibbonLib.Interop;

namespace RibbonLib;

public class Ribbon : Control, IUICommandHandler
{
	private const string DefaultResourceName = "APPLICATION_RIBBON";

	private IUIImageFromBitmap _imageFromBitmap;

	private RibbonUIApplication _application;

	private Dictionary<uint, IRibbonControl> _mapRibbonControls = new Dictionary<uint, IRibbonControl>();

	private IntPtr _loadedDllHandle = IntPtr.Zero;

	private RibbonShortcutTable _ribbonShortcutTable;

	private string _shortcutTableResourceName;

	private Form _form;

	private FormWindowState _previousWindowState;

	private int _previousNormalHeight;

	private int _preserveHeight;

	private string _resourceName;

	private string _tempDllFilename;

	public string ShortcutTableResourceName
	{
		get
		{
			return _shortcutTableResourceName;
		}
		set
		{
			_shortcutTableResourceName = value;
			CheckInitialize();
		}
	}

	[DefaultValue(typeof(DockStyle), "Top")]
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	public string ResourceName
	{
		get
		{
			return _resourceName;
		}
		set
		{
			_resourceName = value;
			CheckInitialize();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IntPtr WindowHandle
	{
		get
		{
			Form form = base.Parent as Form;
			return form.Handle;
		}
	}

	public bool Initalized => Framework != null;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IUIFramework Framework { get; private set; }

	public bool Minimized
	{
		get
		{
			if (!Initalized)
			{
				return false;
			}
			IPropertyStore propertyStore = _application.UIRibbon as IPropertyStore;
			propertyStore.GetValue(ref RibbonProperties.Minimized, out var pv);
			return (bool)pv.Value;
		}
		set
		{
			if (Initalized)
			{
				IPropertyStore propertyStore = _application.UIRibbon as IPropertyStore;
				PropVariant pv = PropVariant.FromObject(value);
				propertyStore.SetValue(ref RibbonProperties.Minimized, ref pv);
				propertyStore.Commit();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Viewable
	{
		get
		{
			if (!Initalized)
			{
				return false;
			}
			IPropertyStore propertyStore = _application.UIRibbon as IPropertyStore;
			propertyStore.GetValue(ref RibbonProperties.Viewable, out var pv);
			return (bool)pv.Value;
		}
		set
		{
			if (Initalized)
			{
				IPropertyStore propertyStore = _application.UIRibbon as IPropertyStore;
				PropVariant pv = PropVariant.FromObject(value);
				propertyStore.SetValue(ref RibbonProperties.Viewable, ref pv);
				propertyStore.Commit();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ControlDock QuickAccessToolbarDock
	{
		get
		{
			if (!Initalized)
			{
				return ControlDock.Top;
			}
			IPropertyStore propertyStore = _application.UIRibbon as IPropertyStore;
			propertyStore.GetValue(ref RibbonProperties.QuickAccessToolbarDock, out var pv);
			return (ControlDock)(uint)pv.Value;
		}
		set
		{
			if (Initalized)
			{
				IPropertyStore propertyStore = _application.UIRibbon as IPropertyStore;
				PropVariant pv = PropVariant.FromObject((uint)value);
				propertyStore.SetValue(ref RibbonProperties.QuickAccessToolbarDock, ref pv);
				propertyStore.Commit();
			}
		}
	}

	public event EventHandler ViewCreated;

	private void TryCreateShortcutTable(Assembly assembly)
	{
		_ribbonShortcutTable = null;
		if (!string.IsNullOrEmpty(ShortcutTableResourceName))
		{
			_ribbonShortcutTable = Util.DeserializeEmbeddedResource<RibbonShortcutTable>(ShortcutTableResourceName, assembly);
			Form form = FindForm();
			form.KeyPreview = true;
			form.KeyUp += form_KeyUp;
		}
	}

	private void form_KeyUp(object sender, KeyEventArgs e)
	{
		if (_ribbonShortcutTable != null)
		{
			uint num = _ribbonShortcutTable.HitTest(e.KeyData);
			if (num != 0)
			{
				Execute(num, ExecutionVerb.Execute, null, null, null);
				e.SuppressKeyPress = false;
				e.Handled = true;
			}
		}
	}

	public Ribbon()
	{
		base.Dock = DockStyle.Top;
		if (!Util.DesignMode)
		{
			SetStyle(ControlStyles.UserPaint, value: false);
			SetStyle(ControlStyles.Opaque, value: true);
			base.ParentChanged += Ribbon_ParentChanged;
			base.HandleCreated += RibbonControl_HandleCreated;
			base.HandleDestroyed += Ribbon_HandleDestroyed;
		}
	}

	private void Ribbon_ParentChanged(object sender, EventArgs e)
	{
		Control control = base.Parent;
		if (control == null)
		{
			RegisterForm(null);
			return;
		}
		if (!(control is Form form))
		{
			throw new ApplicationException("Parent of Ribbon does not derive from Form class.");
		}
		RegisterForm(form);
	}

	private void RegisterForm(Form form)
	{
		if (_form != null)
		{
			_form.SizeChanged -= _form_SizeChanged;
		}
		_form = form;
		if (_form != null)
		{
			_form.SizeChanged += _form_SizeChanged;
		}
	}

	private void _form_SizeChanged(object sender, EventArgs e)
	{
		if (_previousWindowState != FormWindowState.Normal && _form.WindowState == FormWindowState.Normal && _previousNormalHeight != 0)
		{
			_preserveHeight = _previousNormalHeight;
			_form.BeginInvoke(new MethodInvoker(RestoreHeight));
		}
		if (_form.WindowState == FormWindowState.Normal)
		{
			_previousNormalHeight = _form.Height;
		}
		_previousWindowState = _form.WindowState;
	}

	private void RestoreHeight()
	{
		_form.Height = _preserveHeight;
	}

	private void Ribbon_HandleDestroyed(object sender, EventArgs e)
	{
		DestroyFramework();
	}

	private void RibbonControl_HandleCreated(object sender, EventArgs e)
	{
		CheckInitialize();
	}

	private void CheckInitialize()
	{
		if (!Util.DesignMode && !Initalized && !string.IsNullOrEmpty(ResourceName) && base.Parent is Form { IsHandleCreated: not false } form)
		{
			Assembly assembly = form.GetType().Assembly;
			InitFramework(ResourceName, assembly);
			TryCreateShortcutTable(assembly);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		ControlPaint.DrawContainerGrabHandle(e.Graphics, base.ClientRectangle);
	}

	private byte[] GetLocalizedRibbon(string ribbonResource, Assembly ribbonAssembly)
	{
		byte[] data = null;
		bool flag = false;
		CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
		Assembly satelliteAssembly = null;
		TryGetSatelliteAssembly(currentUICulture, ribbonAssembly, ref satelliteAssembly);
		if (TryGetRibbon(ribbonResource, satelliteAssembly, ref data))
		{
			return data;
		}
		Assembly satelliteAssembly2 = null;
		if (currentUICulture.Parent != null)
		{
			TryGetSatelliteAssembly(currentUICulture.Parent, ribbonAssembly, ref satelliteAssembly2);
		}
		if (TryGetRibbon(ribbonResource, satelliteAssembly2, ref data))
		{
			return data;
		}
		if (!TryGetRibbon(ribbonResource, ribbonAssembly, ref data))
		{
			throw new ArgumentException($"Ribbon resource '{ribbonResource}' not found in assembly '{ribbonAssembly.Location}'.");
		}
		return data;
	}

	private bool TryGetSatelliteAssembly(CultureInfo culture, Assembly mainAssembly, ref Assembly satelliteAssembly)
	{
		try
		{
			satelliteAssembly = mainAssembly.GetSatelliteAssembly(culture);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private bool TryGetRibbon(string ribbonResource, Assembly assembly, ref byte[] data)
	{
		try
		{
			byte[] embeddedResource = Util.GetEmbeddedResource(ribbonResource, assembly);
			data = embeddedResource;
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void InitFramework(string ribbonResource, Assembly ribbonAssembly)
	{
		string path = Path.Combine(Path.GetTempPath(), "RibbonDlls");
		_tempDllFilename = Path.Combine(path, Path.GetTempFileName());
		byte[] localizedRibbon = GetLocalizedRibbon(ribbonResource, ribbonAssembly);
		File.WriteAllBytes(_tempDllFilename, localizedRibbon);
		if (File.Exists(_tempDllFilename))
		{
			InitFramework("APPLICATION_RIBBON", _tempDllFilename);
		}
	}

	private void InitFramework(string resourceName, string ribbonDllName)
	{
		_loadedDllHandle = NativeMethods.LoadLibraryEx(ribbonDllName, IntPtr.Zero, 51u);
		if (_loadedDllHandle == IntPtr.Zero)
		{
			throw new ApplicationException("Ribbon resource DLL exists but could not be loaded.");
		}
		InitFramework(resourceName, _loadedDllHandle);
	}

	private void InitFramework(string resourceName, IntPtr hInstance)
	{
		Framework = CreateRibbonFramework();
		_imageFromBitmap = CreateImageFromBitmapFactory();
		_application = new RibbonUIApplication(this, this);
		HRESULT hRESULT = Framework.Initialize(WindowHandle, _application);
		if (NativeMethods.Failed(hRESULT))
		{
			Marshal.ThrowExceptionForHR((int)hRESULT);
		}
		hRESULT = Framework.LoadUI(hInstance, resourceName);
		if (NativeMethods.Failed(hRESULT))
		{
			Marshal.ThrowExceptionForHR((int)hRESULT);
		}
	}

	private void DestroyFramework()
	{
		if (Initalized)
		{
			Framework.Destroy();
			Marshal.ReleaseComObject(Framework);
			Framework = null;
		}
		RegisterForm(null);
		if (_loadedDllHandle != IntPtr.Zero)
		{
			NativeMethods.FreeLibrary(_loadedDllHandle);
			_loadedDllHandle = IntPtr.Zero;
		}
		if (_imageFromBitmap != null)
		{
			_imageFromBitmap = null;
		}
		if (_application != null)
		{
			_application = null;
		}
		_mapRibbonControls.Clear();
		if (!string.IsNullOrEmpty(_tempDllFilename))
		{
			try
			{
				File.Delete(_tempDllFilename);
				_tempDllFilename = null;
			}
			catch
			{
			}
		}
	}

	public void SetColors(Color background, Color highlight, Color text)
	{
		if (Initalized)
		{
			uint num = ColorHelper.HSB2Uint(ColorHelper.HSL2HSB(ColorHelper.RGB2HSL(background)));
			uint num2 = ColorHelper.HSB2Uint(ColorHelper.HSL2HSB(ColorHelper.RGB2HSL(highlight)));
			uint num3 = ColorHelper.HSB2Uint(ColorHelper.HSL2HSB(ColorHelper.RGB2HSL(text)));
			IPropertyStore propertyStore = (IPropertyStore)Framework;
			PropVariant pv = PropVariant.FromObject(num);
			PropVariant pv2 = PropVariant.FromObject(num2);
			PropVariant pv3 = PropVariant.FromObject(num3);
			propertyStore.SetValue(ref RibbonProperties.GlobalBackgroundColor, ref pv);
			propertyStore.SetValue(ref RibbonProperties.GlobalHighlightColor, ref pv2);
			propertyStore.SetValue(ref RibbonProperties.GlobalTextColor, ref pv3);
			propertyStore.Commit();
		}
	}

	public IUIImage ConvertToUIImage(Bitmap bitmap)
	{
		if (_imageFromBitmap == null)
		{
			return null;
		}
		_imageFromBitmap.CreateImage(bitmap.GetHbitmap(), Ownership.Transfer, out var image);
		return image;
	}

	public void SetModes(params byte[] modesArray)
	{
		if (!Initalized)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < modesArray.Length; i++)
		{
			if (modesArray[i] >= 32)
			{
				throw new ArgumentException("Modes should range between 0 to 31.");
			}
			num |= 1 << (int)modesArray[i];
		}
		Framework.SetModes(num);
	}

	public void ShowContextPopup(uint contextPopupID, int x, int y)
	{
		if (Initalized)
		{
			Guid riid = new Guid("EEA11F37-7C46-437c-8E55-B52122B29293");
			object ppv;
			HRESULT view = Framework.GetView(contextPopupID, ref riid, out ppv);
			if (NativeMethods.Succeeded(view))
			{
				IUIContextualUI iUIContextualUI = ppv as IUIContextualUI;
				iUIContextualUI.ShowAtLocation(x, y);
				Marshal.ReleaseComObject(iUIContextualUI);
			}
			else
			{
				Marshal.ThrowExceptionForHR((int)view);
			}
		}
	}

	public void SaveSettingsToStream(Stream stream)
	{
		if (Initalized)
		{
			StreamAdapter pStream = new StreamAdapter(stream);
			_application.UIRibbon.SaveSettingsToStream(pStream);
		}
	}

	public void LoadSettingsFromStream(Stream stream)
	{
		if (Initalized)
		{
			StreamAdapter pStream = new StreamAdapter(stream);
			_application.UIRibbon.LoadSettingsFromStream(pStream);
		}
	}

	private static IUIFramework CreateRibbonFramework()
	{
		try
		{
			return new UIRibbonFramework() as IUIFramework;
		}
		catch (COMException inner)
		{
			throw new PlatformNotSupportedException("The ribbon framework couldn't be found on this system.", inner);
		}
	}

	private static IUIImageFromBitmap CreateImageFromBitmapFactory()
	{
		return new UIRibbonImageFromBitmapFactory() as IUIImageFromBitmap;
	}

	private string GenerateDefaultRibbonDllName()
	{
		return Path.ChangeExtension(new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath, ".ribbon.dll");
	}

	internal void AddRibbonControl(IRibbonControl ribbonControl)
	{
		_mapRibbonControls.Add(ribbonControl.CommandID, ribbonControl);
	}

	public virtual HRESULT Execute(uint commandID, ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		if (_mapRibbonControls.ContainsKey(commandID))
		{
			return _mapRibbonControls[commandID].Execute(verb, key, currentValue, commandExecutionProperties);
		}
		return HRESULT.S_OK;
	}

	public virtual HRESULT UpdateProperty(uint commandID, ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (_mapRibbonControls.ContainsKey(commandID))
		{
			return _mapRibbonControls[commandID].UpdateProperty(ref key, currentValue, ref newValue);
		}
		return HRESULT.S_OK;
	}

	internal void RaiseViewCreated()
	{
		if (this.ViewCreated != null)
		{
			this.ViewCreated(this, EventArgs.Empty);
		}
	}
}
