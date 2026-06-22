using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;
using ZTool.CustomFileBorser;

namespace ZTool;

[DesignerGenerated]
public class SplitConfig : Form
{
	[CompilerGenerated]
	internal class Type_34
	{
		public string f_369;

		public Type_34(Type_34 P_0)
		{
			if (P_0 != null)
			{
				f_369 = P_0.f_369;
			}
		}

		[CompilerGenerated]
		public bool m_162(string P_0)
		{
			return P_0.Equals(f_369, StringComparison.OrdinalIgnoreCase);
		}
	}

	private IContainer f_355;

	[AccessedThroughProperty("OK_Button")]
	private Button f_356;

	[AccessedThroughProperty("Label1")]
	private Label f_357;

	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar f_358;

	[AccessedThroughProperty("pathname")]
	private TextBox f_359;

	[AccessedThroughProperty("Label2")]
	private Label f_360;

	[AccessedThroughProperty("Button1")]
	private Button f_361;

	[AccessedThroughProperty("Button2")]
	private Button f_362;

	[AccessedThroughProperty("FieldNames")]
	private ComboBox f_363;

	[AccessedThroughProperty("filename")]
	private TextBox f_364;

	internal SldWorks f_365;

	private const string f_366 = "<磁盘文件名>";

	private const string f_367 = "<配置名称>";

	private double f_368;

	internal virtual Button p_110
	{
		get
		{
			return f_356;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_158;
			if (f_356 != null)
			{
				f_356.Click -= value2;
			}
			f_356 = value;
			if (f_356 != null)
			{
				f_356.Click += value2;
			}
		}
	}

	internal virtual Label p_111
	{
		get
		{
			return f_357;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_357 = value;
		}
	}

	internal virtual ProgressBar p_112
	{
		get
		{
			return f_358;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_358 = value;
		}
	}

	internal virtual TextBox p_113
	{
		get
		{
			return f_359;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = m_159;
			if (f_359 != null)
			{
				f_359.MouseDoubleClick -= value2;
			}
			f_359 = value;
			if (f_359 != null)
			{
				f_359.MouseDoubleClick += value2;
			}
		}
	}

	internal virtual Label p_114
	{
		get
		{
			return f_360;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_360 = value;
		}
	}

	internal virtual Button p_115
	{
		get
		{
			return f_361;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_159;
			if (f_361 != null)
			{
				f_361.Click -= value2;
			}
			f_361 = value;
			if (f_361 != null)
			{
				f_361.Click += value2;
			}
		}
	}

	internal virtual Button p_116
	{
		get
		{
			return f_362;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_160;
			if (f_362 != null)
			{
				f_362.Click -= value2;
			}
			f_362 = value;
			if (f_362 != null)
			{
				f_362.Click += value2;
			}
		}
	}

	internal virtual ComboBox p_117
	{
		get
		{
			return f_363;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_161;
			if (f_363 != null)
			{
				f_363.SelectedIndexChanged -= value2;
			}
			f_363 = value;
			if (f_363 != null)
			{
				f_363.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox p_118
	{
		get
		{
			return f_364;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_364 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_355 != null)
			{
				f_355.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_156()
	{
		p_110 = new Button();
		p_111 = new Label();
		p_112 = new ProgressBar();
		p_113 = new TextBox();
		p_114 = new Label();
		p_115 = new Button();
		p_116 = new Button();
		p_117 = new ComboBox();
		p_118 = new TextBox();
		SuspendLayout();
		p_110.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		p_110.AutoSize = true;
		Button button = p_110;
		Point location = new Point(334, 84);
		button.Location = location;
		p_110.Name = "OK_Button";
		Button button2 = p_110;
		Size size = new Size(72, 27);
		button2.Size = size;
		p_110.TabIndex = 0;
		p_110.Text = "ОК";
		p_111.AutoSize = true;
		Label label = p_111;
		location = new Point(12, 53);
		label.Location = location;
		p_111.Name = "Label1";
		Label label2 = p_111;
		size = new Size(44, 17);
		label2.Size = size;
		p_111.TabIndex = 2;
		p_111.Text = "Имя:";
		p_112.Dock = DockStyle.Bottom;
		ProgressBar progressBar = p_112;
		location = new Point(0, 120);
		progressBar.Location = location;
		p_112.Name = "ProgressBar1";
		ProgressBar progressBar2 = p_112;
		size = new Size(418, 8);
		progressBar2.Size = size;
		p_112.TabIndex = 3;
		p_113.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox textBox = p_113;
		location = new Point(64, 13);
		textBox.Location = location;
		p_113.Name = "pathname";
		TextBox textBox2 = p_113;
		size = new Size(342, 23);
		textBox2.Size = size;
		p_113.TabIndex = 1;
		p_114.AutoSize = true;
		Label label3 = p_114;
		location = new Point(12, 16);
		label3.Location = location;
		p_114.Name = "Label2";
		Label label4 = p_114;
		size = new Size(44, 17);
		label4.Size = size;
		p_114.TabIndex = 2;
		p_114.Text = "Путь:";
		p_115.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		p_115.AutoSize = true;
		Button button3 = p_115;
		location = new Point(64, 84);
		button3.Location = location;
		p_115.Name = "Button1";
		Button button4 = p_115;
		size = new Size(66, 27);
		button4.Size = size;
		p_115.TabIndex = 0;
		p_115.Text = "Указать путь";
		p_116.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		p_116.AutoSize = true;
		Button button5 = p_116;
		location = new Point(168, 84);
		button5.Location = location;
		p_116.Name = "Button2";
		Button button6 = p_116;
		size = new Size(66, 27);
		button6.Size = size;
		p_116.TabIndex = 0;
		p_116.Text = "Исходный путь";
		p_117.BackColor = SystemColors.Control;
		p_117.DropDownStyle = ComboBoxStyle.DropDownList;
		p_117.DropDownWidth = 400;
		p_117.Font = new Font("Microsoft YaHei UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
		p_117.FormattingEnabled = true;
		p_117.ItemHeight = 16;
		ComboBox comboBox = p_117;
		location = new Point(386, 50);
		comboBox.Location = location;
		p_117.Name = "FieldNames";
		ComboBox comboBox2 = p_117;
		size = new Size(20, 24);
		comboBox2.Size = size;
		p_117.TabIndex = 5;
		TextBox textBox3 = p_118;
		location = new Point(64, 50);
		textBox3.Location = location;
		p_118.Name = "filename";
		TextBox textBox4 = p_118;
		size = new Size(322, 23);
		textBox4.Size = size;
		p_118.TabIndex = 6;
		AcceptButton = p_110;
		SizeF sizeF = new SizeF(96f, 96f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Dpi;
		size = new Size(418, 128);
		ClientSize = size;
		Controls.Add(p_118);
		Controls.Add(p_112);
		Controls.Add(p_116);
		Controls.Add(p_115);
		Controls.Add(p_110);
		Controls.Add(p_114);
		Controls.Add(p_111);
		Controls.Add(p_113);
		Controls.Add(p_117);
		Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "SplitConfig";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Разделить конфигурации";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public SplitConfig()
	{
		base.Load += m_157;
		Type_16.m_52();
		m_156();
		using Graphics graphics = Graphics.FromHwnd(Handle);
		f_368 = graphics.DpiX / 96f;
	}

	private void m_157(object P_0, EventArgs P_1)
	{
		p_117.Items.Clear();
		p_117.Items.Add("<磁盘文件名>");
		p_117.Items.Add("<配置名称>");
		ModelDoc2 modelDoc = (ModelDoc2)f_365.ActiveDoc;
		if (Information.IsNothing(modelDoc))
		{
			return;
		}
		Tag = modelDoc.GetPathName();
		p_113.Text = Type_16.m_53(Conversions.ToString(Tag));
		string[] array = (string[])modelDoc.GetConfigurationNames();
		checked
		{
			array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
			array[Information.UBound(array)] = "";
			List<string> list = new List<string>();
			int num = Information.UBound(array);
			Type_34 type_ = default(Type_34);
			for (int i = 0; i <= num; i++)
			{
				string[] array2 = (string[])modelDoc.GetCustomInfoNames2(array[i]);
				if (Information.IsNothing(array2))
				{
					continue;
				}
				int num2 = Information.UBound(array2);
				for (int j = 0; j <= num2; j++)
				{
					type_ = new Type_34(type_);
					type_.f_369 = array2[j];
					if (!list.Exists(type_.m_162))
					{
						list.Add(array2[j]);
					}
				}
			}
			if (list.Count >= 1)
			{
				int num3 = list.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (Operators.CompareString(list[k].Trim(), "", TextCompare: false) != 0)
					{
						p_117.Items.Add("%" + list[k] + "%");
					}
				}
			}
			modelDoc = null;
		}
	}

	private void m_158(object P_0, EventArgs P_1)
	{
		ModelDoc2 modelDoc = (ModelDoc2)f_365.ActiveDoc;
		if (Information.IsNothing(modelDoc))
		{
			return;
		}
		string fullName = p_113.Text;
		if (!Directory.Exists(fullName))
		{
			if (MessageBox.Show(this, "Путь" + fullName + "не существует, создать?", "Запрос", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			fullName = Directory.CreateDirectory(p_113.Text).FullName;
		}
		SplitByConfig(fullName, p_118.Text, modelDoc);
		Close();
	}

	private void m_159(object P_0, EventArgs P_1)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(Type_16.m_60(f_365.GetProcessID())) == DialogResult.OK)
		{
			p_113.Text = fileBorser.DirectoryPath;
		}
	}

	private void m_160(object P_0, EventArgs P_1)
	{
		p_113.Text = Type_16.m_53(Conversions.ToString(Tag));
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public void SplitByConfig(string savepath, string Cfilename, ModelDoc2 swmodel)
	{
		checked
		{
			try
			{
				ModelDocExtension extension = swmodel.Extension;
				string pathName = swmodel.GetPathName();
				string text = Type_16.m_53(pathName, 1);
				string text2 = Type_16.m_53(pathName, 3) + ".SLDDRW";
				string[] array = (string[])swmodel.GetCustomInfoNames2("");
				int customInfoCount = swmodel.GetCustomInfoCount2("");
				string[] array2 = (string[])swmodel.GetConfigurationNames();
				p_112.Maximum = Information.UBound(array2);
				int num = Information.UBound(array2);
				for (int i = 0; i <= num; i++)
				{
					p_112.Value = i;
					string expression = Cfilename;
					expression = Strings.Replace(expression, "<磁盘文件名>", text);
					expression = Strings.Replace(expression, "<配置名称>", array2[i]);
					CustomPropertyManager customPropertyManager = ((IModelDocExtension)extension).get_CustomPropertyManager(array2[i]);
					string[] array3 = (string[])customPropertyManager.GetNames();
					int count = customPropertyManager.Count;
					int num2 = count - 1;
					for (int j = 0; j <= num2; j++)
					{
						string ValOut = "";
						string ResolvedValOut = "";
						customPropertyManager.Get4(array3[j], UseCached: false, out ValOut, out ResolvedValOut);
						expression = Strings.Replace(expression, "%" + array3[j] + "%", ResolvedValOut);
					}
					int num3 = customInfoCount - 1;
					for (int k = 0; k <= num3; k++)
					{
						if (!Type_16.m_72(array3, array[k], StringComparison.OrdinalIgnoreCase))
						{
							string ValOut2 = "";
							string ResolvedValOut2 = "";
							customPropertyManager.Get4(array[k], UseCached: false, out ValOut2, out ResolvedValOut2);
							expression = Strings.Replace(expression, "%" + array[k] + "%", ResolvedValOut2);
						}
					}
					if (Operators.CompareString(expression, "", TextCompare: false) == 0)
					{
						expression = text + "(" + array2[i] + ")";
					}
					string text3 = Path.Combine(savepath, DeleteInvalidFileNameChars(expression) + Type_16.m_53(pathName, 5));
					if (swmodel.SaveAs3(text3, 0, 2) != 0)
					{
						continue;
					}
					if (Operators.CompareString(FileSystem.Dir(text2), "", TextCompare: false) != 0)
					{
						string text4 = Type_16.m_53(text3, 3) + ".SLDDRW";
						File.Copy(text2, text4, overwrite: true);
						f_365.CloseDoc(text2);
						if (Operators.CompareString(FileSystem.Dir(text4), "", TextCompare: false) != 0)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(f_365.GetDocumentDependencies2(text4, Traverseflag: false, Searchflag: true, AddReadOnlyInfo: false));
							if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
							{
								string referencedDocument = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { 1 }, null));
								f_365.ReplaceReferencedDocument(text4, referencedDocument, text3);
							}
						}
					}
					ModelDoc2 modelDoc = (ModelDoc2)f_365.OpenDoc(text3, swmodel.GetType());
					if (modelDoc == null)
					{
						continue;
					}
					modelDoc.ShowConfiguration2(array2[i]);
					if (Strings.StrComp(Conversions.ToString(NewLateBinding.LateGet(modelDoc.GetActiveConfiguration(), null, "name", new object[0], null, null, null)), array2[i], CompareMethod.Text) == 0)
					{
						int num4 = Information.UBound(array2);
						for (int l = 0; l <= num4; l++)
						{
							if (Strings.StrComp(array2[l], array2[i], CompareMethod.Text) != 0)
							{
								modelDoc.DeleteConfiguration2(array2[l]);
							}
						}
						modelDoc.DeleteDesignTable();
						modelDoc.Save();
					}
					f_365.CloseDoc(text3);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				swmodel = null;
				f_365 = null;
			}
		}
	}

	public string DeleteInvalidFileNameChars(string filename)
	{
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		checked
		{
			int num = invalidFileNameChars.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				filename = filename.Replace(Conversions.ToString(invalidFileNameChars[i]), "");
			}
			return filename;
		}
	}

	public string DeleteInvalidPathChars(string pathname)
	{
		char[] invalidPathChars = Path.GetInvalidPathChars();
		checked
		{
			int num = invalidPathChars.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				pathname = pathname.Replace(Conversions.ToString(invalidPathChars[i]), "");
			}
			return pathname;
		}
	}

	private void m_161(object P_0, EventArgs P_1)
	{
		string text = p_118.Text;
		string text2 = ((ComboBox)P_0).Text;
		p_118.Focus();
		int selectionStart = p_118.SelectionStart;
		if (p_118.SelectionLength > 0)
		{
			text = Strings.Replace(text, p_118.SelectedText, text2);
		}
		else
		{
			text = text.Insert(selectionStart, text2);
			p_118.Text = text;
		}
		p_118.SelectionStart = checked(selectionStart + text2.Length);
		p_118.SelectionLength = 0;
	}
}
