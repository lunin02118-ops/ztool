using SolidWorks.Interop.sldworks;

namespace ZTool;

public class Page_RepairReference
{
	private SldWorks f_161;

	private SwAddin f_162;

	private PageHandler_RepairReference f_163;

	private PropertyManagerPage2 f_164;

	private PropertyManagerPageGroup f_165;

	private PropertyManagerPageGroup f_166;

	private PropertyManagerPageGroup f_167;

	internal PropertyManagerPageCheckbox f_168;

	internal PropertyManagerPageCheckbox f_169;

	internal PropertyManagerPageCheckbox f_170;

	private PropertyManagerPageLabel f_171;

	private PropertyManagerPageButton f_172;

	private PropertyManagerPageListbox f_173;

	private int f_174;

	private int f_175;

	private int f_176;

	private int f_177;

	private int f_178;

	private int f_179;

	private int f_180;

	private int f_181;

	private int f_182;

	public Page_RepairReference()
	{
		f_174 = 0;
		f_175 = 1;
		f_176 = 2;
		f_177 = 3;
		f_178 = 4;
		f_179 = 5;
		f_180 = 6;
		f_181 = 7;
		f_182 = 8;
	}

	public void Init(SldWorks sw, SwAddin addin)
	{
		f_161 = sw;
		f_162 = addin;
		CreatePage();
		AddControls();
	}

	public void Show()
	{
		f_168.Checked = Type_16.m_58(Type_16.m_63("Repair Reference", "includelightweight"));
		f_169.Checked = Type_16.m_58(Type_16.m_63("Repair Reference", "includesuppressed"));
		f_170.Checked = Type_16.m_58(Type_16.m_63("Repair Reference", "includehidden"));
		f_164.Show();
	}

	public void CreatePage()
	{
		f_163 = new PageHandler_RepairReference();
		f_163.Init(f_161, f_162, this);
		int options = 3;
		int Errors = default(int);
		f_164 = (PropertyManagerPage2)f_161.CreatePropertyManagerPage("Восстановить внешние ссылки", options, f_163, ref Errors);
	}

	public void AddControls()
	{
		f_165 = (PropertyManagerPageGroup)f_164.AddGroupBox(f_176, "Информация", 12);
		f_166 = (PropertyManagerPageGroup)f_164.AddGroupBox(f_174, "Опции", 12);
		int num = 1;
		int num2 = 1;
		int options = 3;
		checked
		{
			f_171 = (PropertyManagerPageLabel)f_165.AddControl(f_180, (short)num, "Восстановить потерянные внешние ссылки деталей в сборке", (short)num2, options, "");
			num = 2;
			num2 = 1;
			options = 3;
			f_168 = (PropertyManagerPageCheckbox)f_166.AddControl(f_177, (short)num, "Включая облегчённые", (short)num2, options, "");
			num = 2;
			num2 = 1;
			options = 3;
			f_169 = (PropertyManagerPageCheckbox)f_166.AddControl(f_178, (short)num, "Включая погашенные", (short)num2, options, "");
			num = 2;
			num2 = 1;
			options = 3;
			f_170 = (PropertyManagerPageCheckbox)f_166.AddControl(f_179, (short)num, "Включая скрытые", (short)num2, options, "");
		}
	}
}
