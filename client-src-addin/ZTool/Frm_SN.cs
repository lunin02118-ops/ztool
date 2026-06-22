using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;

namespace ZTool;

[DesignerGenerated]
public class Frm_SN : Form
{
	private IContainer f_127;

	[AccessedThroughProperty("prefix")]
	private ComboBox f_128;

	[AccessedThroughProperty("Label1")]
	private Label f_129;

	[AccessedThroughProperty("number")]
	private NumericUpDown f_130;

	[AccessedThroughProperty("digit")]
	private NumericUpDown f_131;

	[AccessedThroughProperty("Label2")]
	private Label f_132;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox f_133;

	[AccessedThroughProperty("Button1")]
	private Button f_134;

	[AccessedThroughProperty("Button2")]
	private Button f_135;

	[AccessedThroughProperty("Button4")]
	private Button f_136;

	[AccessedThroughProperty("Label3")]
	private Label f_137;

	[AccessedThroughProperty("Label5")]
	private Label f_138;

	[AccessedThroughProperty("pathname")]
	private TextBox f_139;

	[AccessedThroughProperty("Label4")]
	private Label f_140;

	[AccessedThroughProperty("SN")]
	private Label f_141;

	[AccessedThroughProperty("CheckBox2")]
	private CheckBox f_142;

	[AccessedThroughProperty("TB_FieldName")]
	private TextBox f_143;

	[AccessedThroughProperty("Label6")]
	private Label f_144;

	protected internal SldWorks swapp;

	internal virtual ComboBox p_27
	{
		get
		{
			return f_128;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_99;
			EventHandler value3 = m_103;
			EventHandler value4 = m_102;
			if (f_128 != null)
			{
				f_128.TextChanged -= value2;
				f_128.Validated -= value3;
				f_128.DropDown -= value4;
			}
			f_128 = value;
			if (f_128 != null)
			{
				f_128.TextChanged += value2;
				f_128.Validated += value3;
				f_128.DropDown += value4;
			}
		}
	}

	internal virtual Label p_28
	{
		get
		{
			return f_129;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_129 = value;
		}
	}

	internal virtual NumericUpDown p_29
	{
		get
		{
			return f_130;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_101;
			if (f_130 != null)
			{
				f_130.ValueChanged -= value2;
			}
			f_130 = value;
			if (f_130 != null)
			{
				f_130.ValueChanged += value2;
			}
		}
	}

	internal virtual NumericUpDown p_30
	{
		get
		{
			return f_131;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_131 = value;
		}
	}

	internal virtual Label p_31
	{
		get
		{
			return f_132;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_132 = value;
		}
	}

	internal virtual CheckBox p_32
	{
		get
		{
			return f_133;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_133 = value;
		}
	}

	internal virtual Button p_33
	{
		get
		{
			return f_134;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_97;
			if (f_134 != null)
			{
				f_134.Click -= value2;
			}
			f_134 = value;
			if (f_134 != null)
			{
				f_134.Click += value2;
			}
		}
	}

	internal virtual Button p_34
	{
		get
		{
			return f_135;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_100;
			if (f_135 != null)
			{
				f_135.Click -= value2;
			}
			f_135 = value;
			if (f_135 != null)
			{
				f_135.Click += value2;
			}
		}
	}

	internal virtual Button p_35
	{
		get
		{
			return f_136;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_98;
			if (f_136 != null)
			{
				f_136.Click -= value2;
			}
			f_136 = value;
			if (f_136 != null)
			{
				f_136.Click += value2;
			}
		}
	}

	internal virtual Label p_36
	{
		get
		{
			return f_137;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_137 = value;
		}
	}

	internal virtual Label p_37
	{
		get
		{
			return f_138;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_138 = value;
		}
	}

	internal virtual TextBox p_38
	{
		get
		{
			return f_139;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_139 = value;
		}
	}

	internal virtual Label p_39
	{
		get
		{
			return f_140;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_140 = value;
		}
	}

	internal virtual Label p_40
	{
		get
		{
			return f_141;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_141 = value;
		}
	}

	internal virtual CheckBox p_41
	{
		get
		{
			return f_142;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_142 = value;
		}
	}

	internal virtual TextBox p_42
	{
		get
		{
			return f_143;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_105;
			if (f_143 != null)
			{
				f_143.Validated -= value2;
			}
			f_143 = value;
			if (f_143 != null)
			{
				f_143.Validated += value2;
			}
		}
	}

	internal virtual Label p_43
	{
		get
		{
			return f_144;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_144 = value;
		}
	}

	public Frm_SN()
	{
		base.Load += m_95;
		base.FormClosed += m_96;
		m_94();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_127 != null)
			{
				f_127.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_94()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Frm_SN));
		p_27 = new ComboBox();
		p_28 = new Label();
		p_29 = new NumericUpDown();
		p_30 = new NumericUpDown();
		p_31 = new Label();
		p_32 = new CheckBox();
		p_33 = new Button();
		p_34 = new Button();
		p_35 = new Button();
		p_36 = new Label();
		p_37 = new Label();
		p_38 = new TextBox();
		p_39 = new Label();
		p_40 = new Label();
		p_41 = new CheckBox();
		p_42 = new TextBox();
		p_43 = new Label();
		((ISupportInitialize)p_29).BeginInit();
		((ISupportInitialize)p_30).BeginInit();
		SuspendLayout();
		p_27.FormattingEnabled = true;
		ComboBox comboBox = p_27;
		Point location = new Point(48, 56);
		comboBox.Location = location;
		p_27.Name = "prefix";
		ComboBox comboBox2 = p_27;
		Size size = new Size(174, 25);
		comboBox2.Size = size;
		p_27.TabIndex = 3;
		p_28.AutoSize = true;
		Label label = p_28;
		location = new Point(232, 60);
		label.Location = location;
		p_28.Name = "Label1";
		Label label2 = p_28;
		size = new Size(13, 17);
		label2.Size = size;
		p_28.TabIndex = 1;
		p_28.Text = "-";
		NumericUpDown numericUpDown = p_29;
		location = new Point(256, 57);
		numericUpDown.Location = location;
		p_29.Name = "number";
		NumericUpDown numericUpDown2 = p_29;
		size = new Size(80, 23);
		numericUpDown2.Size = size;
		p_29.TabIndex = 4;
		NumericUpDown numericUpDown3 = p_29;
		decimal value = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown3.Value = value;
		NumericUpDown numericUpDown4 = p_30;
		location = new Point(256, 85);
		numericUpDown4.Location = location;
		value = (p_30.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 }));
		value = (p_30.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		p_30.Name = "digit";
		NumericUpDown numericUpDown5 = p_30;
		size = new Size(80, 23);
		numericUpDown5.Size = size;
		p_30.TabIndex = 5;
		value = (p_30.Value = new decimal(new int[4] { 3, 0, 0, 0 }));
		p_31.AutoSize = true;
		p_31.Font = new Font("微软雅黑", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
		Label label3 = p_31;
		location = new Point(8, 27);
		label3.Location = location;
		p_31.Name = "Label2";
		Label label4 = p_31;
		size = new Size(44, 17);
		label4.Size = size;
		p_31.TabIndex = 3;
		p_31.Text = "Номер:";
		p_32.AutoSize = true;
		CheckBox checkBox = p_32;
		location = new Point(8, 171);
		checkBox.Location = location;
		p_32.Name = "CheckBox1";
		CheckBox checkBox2 = p_32;
		size = new Size(75, 21);
		checkBox2.Size = size;
		p_32.TabIndex = 8;
		p_32.Text = "Автоприменение";
		p_32.UseVisualStyleBackColor = true;
		p_33.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button button = p_33;
		location = new Point(264, 245);
		button.Location = location;
		p_33.Name = "Button1";
		Button button2 = p_33;
		size = new Size(64, 23);
		button2.Size = size;
		p_33.TabIndex = 2;
		p_33.Text = "Отмена";
		p_33.UseVisualStyleBackColor = true;
		p_34.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button button3 = p_34;
		location = new Point(184, 245);
		button3.Location = location;
		p_34.Name = "Button2";
		Button button4 = p_34;
		size = new Size(64, 23);
		button4.Size = size;
		p_34.TabIndex = 0;
		p_34.Text = "Применить";
		p_34.UseVisualStyleBackColor = true;
		p_35.AutoSize = true;
		Button button5 = p_35;
		location = new Point(8, 195);
		button5.Location = location;
		p_35.Name = "Button4";
		Button button6 = p_35;
		size = new Size(78, 27);
		button6.Size = size;
		p_35.TabIndex = 9;
		p_35.Text = "Сбросить нумерацию";
		p_35.UseVisualStyleBackColor = true;
		p_36.AutoSize = true;
		Label label5 = p_36;
		location = new Point(208, 88);
		label5.Location = location;
		p_36.Name = "Label3";
		Label label6 = p_36;
		size = new Size(44, 17);
		label6.Size = size;
		p_36.TabIndex = 3;
		p_36.Text = "Разрядов:";
		p_37.AutoSize = true;
		p_37.ForeColor = Color.DarkOrange;
		Label label7 = p_37;
		location = new Point(88, 200);
		label7.Location = location;
		p_37.Name = "Label5";
		Label label8 = p_37;
		size = new Size(191, 17);
		label8.Size = size;
		p_37.TabIndex = 3;
		p_37.Text = "перезапуск solidworks также сбросит нумерацию";
		p_38.BackColor = SystemColors.Control;
		p_38.BorderStyle = BorderStyle.None;
		p_38.Dock = DockStyle.Top;
		TextBox textBox = p_38;
		location = new Point(0, 0);
		textBox.Location = location;
		p_38.Name = "pathname";
		p_38.ReadOnly = true;
		TextBox textBox2 = p_38;
		size = new Size(345, 16);
		textBox2.Size = size;
		p_38.TabIndex = 7;
		p_39.AutoSize = true;
		Label label9 = p_39;
		location = new Point(8, 59);
		label9.Location = location;
		p_39.Name = "Label4";
		Label label10 = p_39;
		size = new Size(44, 17);
		label10.Size = size;
		p_39.TabIndex = 3;
		p_39.Text = "Префикс:";
		p_40.AutoSize = true;
		p_40.ForeColor = Color.Blue;
		Label label11 = p_40;
		location = new Point(48, 27);
		label11.Location = location;
		p_40.Name = "SN";
		Label label12 = p_40;
		size = new Size(0, 17);
		label12.Size = size;
		p_40.TabIndex = 3;
		p_41.AutoSize = true;
		CheckBox checkBox3 = p_41;
		location = new Point(8, 147);
		checkBox3.Location = location;
		p_41.Name = "CheckBox2";
		CheckBox checkBox4 = p_41;
		size = new Size(75, 21);
		checkBox4.Size = size;
		p_41.TabIndex = 7;
		p_41.Text = "Автоскрытие";
		p_41.UseVisualStyleBackColor = true;
		TextBox textBox3 = p_42;
		location = new Point(88, 120);
		textBox3.Location = location;
		p_42.Name = "TB_FieldName";
		TextBox textBox4 = p_42;
		size = new Size(152, 23);
		textBox4.Size = size;
		p_42.TabIndex = 6;
		p_42.Text = "Временный номер";
		p_43.AutoSize = true;
		p_43.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		Label label13 = p_43;
		location = new Point(8, 123);
		label13.Location = location;
		p_43.Name = "Label6";
		Label label14 = p_43;
		size = new Size(80, 17);
		label14.Size = size;
		p_43.TabIndex = 3;
		p_43.Text = "Запись в свойство:";
		SizeF sizeF = new SizeF(96f, 96f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Dpi;
		size = new Size(345, 278);
		ClientSize = size;
		Controls.Add(p_42);
		Controls.Add(p_27);
		Controls.Add(p_38);
		Controls.Add(p_35);
		Controls.Add(p_34);
		Controls.Add(p_33);
		Controls.Add(p_41);
		Controls.Add(p_32);
		Controls.Add(p_37);
		Controls.Add(p_36);
		Controls.Add(p_39);
		Controls.Add(p_40);
		Controls.Add(p_43);
		Controls.Add(p_31);
		Controls.Add(p_30);
		Controls.Add(p_29);
		Controls.Add(p_28);
		Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "Frm_SN";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Временный номер";
		((ISupportInitialize)p_29).EndInit();
		((ISupportInitialize)p_30).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void m_95(object P_0, EventArgs P_1)
	{
		SwAddin.f_378 = this;
		p_42.Text = Type_16.m_63("Frm_SN", "FieldName");
		if (Operators.CompareString(p_42.Text, "", TextCompare: false) == 0)
		{
			p_42.Text = "Временный номер";
		}
		RefreshUI();
	}

	private void m_96(object P_0, FormClosedEventArgs P_1)
	{
		SwAddin.f_378 = null;
	}

	private void m_97(object P_0, EventArgs P_1)
	{
		Close();
	}

	private void m_98(object P_0, EventArgs P_1)
	{
		Type_16.f_56 = 0;
		Type_16.f_57.Clear();
		Type_16.f_61.Clear();
		Type_16.f_58 = "";
		p_29.Value = 0m;
		RefreshUI();
	}

	private void m_99(object P_0, EventArgs P_1)
	{
		p_40.Text = $"{p_27.Text}-{p_29.Value.ToString().PadLeft(Convert.ToInt32(p_30.Value), '0')}";
		Type_16.f_58 = p_27.Text;
	}

	private void m_100(object P_0, EventArgs P_1)
	{
		m_104();
	}

	private void m_101(object P_0, EventArgs P_1)
	{
		Type_16.f_56 = Convert.ToInt32(p_29.Value);
		p_40.Text = $"{p_27.Text}-{p_29.Value.ToString().PadLeft(Convert.ToInt32(p_30.Value), '0')}";
	}

	private void m_102(object P_0, EventArgs P_1)
	{
		p_27.DataSource = null;
		p_27.DataSource = Type_16.f_57;
	}

	private void m_103(object P_0, EventArgs P_1)
	{
		if (!Type_16.f_57.Contains(Type_16.f_58))
		{
			Type_16.f_57.Add(Type_16.f_58);
		}
	}

	public void RefreshUI()
	{
		p_27.Text = Type_16.f_58;
		if (!Information.IsNothing(Type_16.f_60))
		{
			string pathName = Type_16.f_60.GetPathName();
			p_38.Text = Type_16.m_53(pathName, 4);
			string value = "";
			if (Type_16.f_61.TryGetValue(p_38.Text, out value))
			{
				p_29.Value = new decimal(Conversion.Val(checked(value.Substring(value.LastIndexOf("-") + 1, value.Length - value.LastIndexOf("-") - 1))));
				p_27.Text = value.Substring(0, value.LastIndexOf("-"));
				p_38.Text = "  Повтор номера, замените деталь";
				p_38.BackColor = Color.OrangeRed;
				return;
			}
			p_38.BackColor = Color.DarkGreen;
			p_29.Value = new decimal(Type_16.f_56);
			if (p_32.Checked)
			{
				m_104();
			}
		}
		else
		{
			p_38.Text = "  Деталь не выбрана";
			p_38.BackColor = Color.Yellow;
		}
	}

	private void m_104()
	{
		if (Information.IsNothing(Type_16.f_60) || Type_16.f_61.ContainsKey(p_38.Text))
		{
			return;
		}
		Type_16.f_58 = p_27.Text;
		if (Type_16.f_58.Length != 0)
		{
			int suppression = Type_16.f_60.GetSuppression();
			string selectByIDString = Type_16.f_60.GetSelectByIDString();
			if (suppression == 0 || suppression == 1)
			{
				Type_16.f_60.SetSuppression2(3);
				Type_16.f_59.ClearSelection2(All: true);
				Type_16.f_59.Extension.SelectByID2(selectByIDString, "COMPONENT", 0.0, 0.0, 0.0, Append: true, 0, null, 0);
			}
			if (AddProp(Type_16.f_60, p_42.Text, p_40.Text))
			{
				Type_16.f_61.Add(p_38.Text, p_40.Text);
			}
			Type_16.f_56 = Convert.ToInt32(decimal.Add(p_29.Value, 1m));
			Type_16.f_60 = null;
		}
	}

	public bool AddProp(Component2 Comp, string FieldName, string FieldValue)
	{
		bool result = false;
		object obj = null;
		try
		{
			if (Operators.CompareString(FieldName, "", TextCompare: false) == 0 || Operators.CompareString(FieldValue, "", TextCompare: false) == 0)
			{
				return false;
			}
			ModelDoc2 modelDoc = (ModelDoc2)Comp.GetModelDoc2();
			if (Information.IsNothing(modelDoc))
			{
				return false;
			}
			ModelDocExtension extension = modelDoc.Extension;
			CustomPropertyManager customPropertyManager = ((IModelDocExtension)extension).get_CustomPropertyManager("");
			obj = RuntimeHelpers.GetObjectValue(modelDoc.GetConfigurationNames());
			if (Type_19.m_78(customPropertyManager, FieldName, Conversions.ToString(30), FieldValue) == 0)
			{
				result = true;
				foreach (object item in (IEnumerable)obj)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					customPropertyManager = ((IModelDocExtension)extension).get_CustomPropertyManager(Conversions.ToString(objectValue));
					int num = customPropertyManager.Delete(FieldName);
				}
			}
			if (p_41.Checked)
			{
				Comp.Visible = 0;
			}
			modelDoc.SetSaveFlag();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void m_105(object P_0, EventArgs P_1)
	{
		Type_16.m_62("Frm_SN", "FieldName", p_42.Text);
	}
}
