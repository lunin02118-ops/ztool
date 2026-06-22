using Microsoft.VisualBasic;
using SolidWorks.Interop.sldworks;

namespace ZTool;

public class Page_randomcolor
{
	private SldWorks f_147;

	private SwAddin f_148;

	private PageHandler_randomcolor f_149;

	private PropertyManagerPage2 f_150;

	internal PropertyManagerPageGroup f_151;

	internal PropertyManagerPageGroup f_152;

	internal PropertyManagerPageCheckbox f_153;

	internal PropertyManagerPageOption f_154;

	internal PropertyManagerPageOption f_155;

	private int f_156;

	private int f_157;

	private int f_158;

	private int f_159;

	private int f_160;

	public Page_randomcolor()
	{
		f_156 = 0;
		f_157 = 1;
		f_158 = 2;
		f_159 = 3;
		f_160 = 4;
	}

	public void Init(SldWorks sw, SwAddin addin)
	{
		f_147 = sw;
		f_148 = addin;
		CreatePage();
		AddControls();
	}

	public void Show()
	{
		f_155.Checked = Type_16.m_58(Type_16.m_63("randomcolor", "forpart"));
		f_154.Checked = !f_155.Checked;
		ModelDoc2 modelDoc = (ModelDoc2)f_147.ActiveDoc;
		if (!Information.IsNothing(modelDoc))
		{
			if (modelDoc.GetType() == 1)
			{
				f_151.Visible = false;
				f_149.randomcolor();
				return;
			}
			if (modelDoc.GetType() == 2)
			{
				f_151.Visible = true;
			}
		}
		f_150.Show();
	}

	public void CreatePage()
	{
		f_149 = new PageHandler_randomcolor();
		f_149.Init(f_147, f_148, this);
		int options = 3;
		int Errors = default(int);
		f_150 = (PropertyManagerPage2)f_147.CreatePropertyManagerPage("Случайная окраска", options, f_149, ref Errors);
	}

	public void AddControls()
	{
		f_151 = (PropertyManagerPageGroup)f_150.AddGroupBox(f_156, "Операция", 12);
		int num = 4;
		int num2 = 1;
		int options = 3;
		checked
		{
			f_154 = (PropertyManagerPageOption)f_151.AddControl(f_159, (short)num, "Применить на уровне детали", (short)num2, options, "");
			num = 4;
			num2 = 1;
			options = 3;
			f_155 = (PropertyManagerPageOption)f_151.AddControl(f_160, (short)num, "Применить на уровне документа детали", (short)num2, options, "");
		}
	}
}
