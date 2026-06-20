using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class CheckUpdate : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__24
	{
		public Exception _0024VB_0024Local_ex;

		public CheckUpdate _0024VB_0024Me;

		[DebuggerNonUserCode]
		public _Closure_0024__24()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__24(_Closure_0024__24 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_ex = other._0024VB_0024Local_ex;
				_0024VB_0024Me = other._0024VB_0024Me;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public void _Lambda_0024__53()
		{
			_0024VB_0024Me.Label1.Text = _0024VB_0024Local_ex.Message;
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__25
	{
		public DownloadProgressChangedEventArgs _0024VB_0024Local_e;

		public CheckUpdate _0024VB_0024Me;

		[DebuggerNonUserCode]
		public _Closure_0024__25()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__25(_Closure_0024__25 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_e = other._0024VB_0024Local_e;
				_0024VB_0024Me = other._0024VB_0024Me;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public void _Lambda_0024__58()
		{
			_0024VB_0024Me.Button2.Text = Conversions.ToString(_0024VB_0024Local_e.ProgressPercentage) + "%";
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	private code.updateInf RemoteInf;

	private code.updateInf LocalInf;

	private string updatezip;

	private bool findnew;

	private WebClient wc;

	private Thread th;

	internal virtual TextBox TextBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox1 = value;
		}
	}

	internal virtual Button Button2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button2_Click;
			if (_Button2 != null)
			{
				_Button2.Click -= value2;
			}
			_Button2 = value;
			if (_Button2 != null)
			{
				_Button2.Click += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label1 = value;
		}
	}

	internal virtual Panel Panel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel1 = value;
		}
	}

	internal virtual Label Label2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label2 = value;
		}
	}

	internal virtual Button Button1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Button1 = value;
		}
	}

	internal virtual LinkLabel LinkLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _LinkLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = LinkLabel1_LinkClicked;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.LinkClicked -= value2;
			}
			_LinkLabel1 = value;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.LinkClicked += value2;
			}
		}
	}

	public CheckUpdate()
	{
		base.Closed += CheckUpdate_Closed;
		base.Load += Updata_Load;
		__ENCAddToList(this);
		RemoteInf = default(code.updateInf);
		LocalInf = default(code.updateInf);
		updatezip = Path.Combine(logopathlist.rootpath, "update.zip");
		findnew = false;
		wc = new WebClient();
		th = new Thread(getinfo);
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	private static void __ENCAddToList(object value)
	{
		checked
		{
			lock (__ENCList)
			{
				if (__ENCList.Count == __ENCList.Capacity)
				{
					int num = 0;
					int num2 = __ENCList.Count - 1;
					int num3 = 0;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						WeakReference weakReference = __ENCList[num3];
						if (weakReference.IsAlive)
						{
							if (num3 != num)
							{
								__ENCList[num] = __ENCList[num3];
							}
							num++;
						}
						num3++;
					}
					__ENCList.RemoveRange(num, __ENCList.Count - num);
					__ENCList.Capacity = __ENCList.Count;
				}
				__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if ((disposing && components != null) ? true : false)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.CheckUpdate));
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Button2 = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Label2 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		this.TextBox1.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.TextBox1.ForeColor = System.Drawing.Color.Navy;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		System.Drawing.Point location = new System.Drawing.Point(20, 3);
		textBox.Location = location;
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		System.Drawing.Size size = new System.Drawing.Size(338, 194);
		textBox2.Size = size;
		this.TextBox1.TabIndex = 0;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button2.AutoSize = true;
		this.Button2.Enabled = false;
		System.Windows.Forms.Button button = this.Button2;
		location = new System.Drawing.Point(299, 306);
		button.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button2 = this.Button2;
		size = new System.Drawing.Size(66, 27);
		button2.Size = size;
		this.Button2.TabIndex = 2;
		this.Button2.Text = "Загрузить обновление";
		this.Button2.UseVisualStyleBackColor = true;
		this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Label1.Font = new System.Drawing.Font("楷体", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Label1.ForeColor = System.Drawing.Color.Navy;
		this.Label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(378, 95);
		label2.Size = size;
		this.Label1.TabIndex = 3;
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Panel1.Controls.Add(this.TextBox1);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(0, 95);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(20, 3, 20, 3);
		panel2.Padding = padding;
		System.Windows.Forms.Panel panel3 = this.Panel1;
		size = new System.Drawing.Size(378, 200);
		panel3.Size = size;
		this.Panel1.TabIndex = 4;
		this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Label2.AutoSize = true;
		this.Label2.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(6, 298);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(0, 17);
		label4.Size = size;
		this.Label2.TabIndex = 5;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Button1.AutoSize = true;
		this.Button1.Enabled = false;
		System.Windows.Forms.Button button3 = this.Button1;
		location = new System.Drawing.Point(208, 309);
		button3.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button4 = this.Button1;
		size = new System.Drawing.Size(66, 27);
		button4.Size = size;
		this.Button1.TabIndex = 2;
		this.Button1.Text = "Сетевые настройки";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button1.Visible = false;
		this.LinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.LinkLabel1.AutoSize = true;
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(6, 317);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(148, 17);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 6;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Tag = "www.z-tool.cn";
		this.LinkLabel1.Text = "Сайт загрузки: www.z-tool.cn";
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(378, 340);
		this.ClientSize = size;
		this.Controls.Add(this.LinkLabel1);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.Button2);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.Name = "CheckUpdate";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ZTool: проверка обновлений";
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void CheckUpdate_Closed(object sender, EventArgs e)
	{
		if (!Information.IsNothing(wc) && wc.IsBusy)
		{
			wc.CancelAsync();
			wc.Dispose();
		}
		th.Abort();
		th.DisableComObjectEagerCleanup();
		Dispose();
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void Updata_Load(object sender, EventArgs e)
	{
		Label1.Text = "Подключение к серверу...";
		TextBox1.Visible = false;
		Button2.Enabled = false;
		th.Start();
		try
		{
			MyProject.Forms.Frmmain.sendhwndtosw();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void getinfo()
	{
		try
		{
			SecurityCenter securityCenter = new SecurityCenter();
			RemoteInf = code.GetRemoteinf(securityCenter.DecriptStr("nqi0eG7sRrpI5it9+Thw8wMTW2TQ3vGpzWrnXLNu5zGHCE+ZpbKctzm3ae0j1CDtjKztEf3SNOtuB6aMxBo3Hw==", code.FromHexString("5a546f6f6c2d322e38")) + "AutoUpdate1.xml");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception _0024VB_0024Local_ex = ex;
			_Closure_0024__24 closure_0024__ = new _Closure_0024__24();
			closure_0024__._0024VB_0024Me = this;
			closure_0024__._0024VB_0024Local_ex = _0024VB_0024Local_ex;
			findnew = false;
			ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__._Lambda_0024__53);
			ProjectData.ClearProjectError();
			return;
		}
		if (Information.IsNothing(RemoteInf))
		{
			findnew = false;
			ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__54);
			return;
		}
		string left = Application.ProductVersion.Replace(".", "").PadRight(4, '0');
		string right = RemoteInf.latestversion.Replace(".", "").PadRight(4, '0');
		if (Operators.CompareString(left, right, TextCompare: false) >= 0)
		{
			findnew = false;
			ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__55);
			return;
		}
		findnew = true;
		ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__56);
		if ((File.Exists(updatezip) && Operators.CompareString(GetHash(updatezip), RemoteInf.md5, TextCompare: false) == 0) ? true : false)
		{
			ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__57);
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		if (!findnew)
		{
			return;
		}
		if ((Operators.CompareString(Button2.Text, "Установить обновление", TextCompare: false) == 0 && Operators.CompareString(RemoteInf.md5, GetHash(updatezip), TextCompare: false) == 0) ? true : false)
		{
			string text = "Установить обновление сейчас?\nВнимание: перед установкой будут закрыты основная программа и процессы SolidWorks, сохраните данные!";
			if (MessageBox.Show(text, "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				openupdater();
			}
		}
		else if (Operators.CompareString(Button2.Text, "Загрузить обновление", TextCompare: false) == 0)
		{
			updateprocess();
		}
	}

	private static code.updateInf GetLocalinf(string path)
	{
		code.updateInf result = default(code.updateInf);
		try
		{
			if (File.Exists(path))
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(path);
				result.changetime = xmlDocument.SelectSingleNode("/UpDateInfo/changetime").Attributes[0].Value.ToString();
				result.latestversion = xmlDocument.SelectSingleNode("/UpDateInfo/latestversion").Attributes[0].Value.ToString();
				result.downloadurl = xmlDocument.SelectSingleNode("/UpDateInfo/downloadurl").Attributes[0].Value.ToString();
				result.changelog = xmlDocument.SelectSingleNode("/UpDateInfo/changelog").Attributes[0].Value.ToString();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string GetHash(string filename)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			try
			{
				if (File.Exists(filename))
				{
					FileInfo fileInfo = new FileInfo(filename);
					using Stream inputStream = fileInfo.OpenRead();
					MD5 mD = new MD5CryptoServiceProvider();
					byte[] array = mD.ComputeHash(inputStream);
					int num = array.Length - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							stringBuilder.Append(array[num2].ToString("X2"));
							num2++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return stringBuilder.ToString();
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Type typeFromHandle = typeof(Process);
		object[] array = new object[1];
		LinkLabel linkLabel = LinkLabel1;
		array[0] = RuntimeHelpers.GetObjectValue(linkLabel.Tag);
		object[] array2 = array;
		bool[] array3 = new bool[1] { true };
		NewLateBinding.LateCall(null, typeFromHandle, "Start", array2, null, null, array3, IgnoreReturn: true);
		if (array3[0])
		{
			linkLabel.Tag = RuntimeHelpers.GetObjectValue(array2[0]);
		}
	}

	private void updateprocess()
	{
		try
		{
			if (!wc.IsBusy)
			{
				wc.Proxy = (IWebProxy)code.GetProxy();
				if (!RemoteFileExists(RemoteInf.downloadurl))
				{
					Label2.Text = "Доступных для загрузки ресурсов не найдено!";
					return;
				}
				wc.DownloadProgressChanged += wc_DownloadProgressChanged;
				wc.DownloadFileCompleted += wc_DownloadFileCompleted;
				wc.DownloadFileAsync(new Uri(RemoteInf.downloadurl), updatezip);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Label2.Text = "Ошибка загрузки: " + ex2.Message;
			ProjectData.ClearProjectError();
		}
	}

	private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
	{
		_Closure_0024__25 closure_0024__ = new _Closure_0024__25();
		closure_0024__._0024VB_0024Local_e = e;
		closure_0024__._0024VB_0024Me = this;
		try
		{
			ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__._Lambda_0024__58);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
	{
		if (!e.Cancelled && Operators.CompareString(GetHash(updatezip), RemoteInf.md5, TextCompare: false) == 0)
		{
			ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__59);
			string text = "Загрузка завершена! Установить обновление сейчас?\nВнимание: перед установкой будут закрыты основная программа и процессы SolidWorks, сохраните данные!";
			if (MessageBox.Show(text, "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				openupdater();
				Environment.Exit(0);
			}
		}
	}

	public void openupdater()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string text = Compress(baseDirectory, updatezip, "ZTool Updater\\.exe$");
		if (!text.Equals("Success!", StringComparison.OrdinalIgnoreCase))
		{
			MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		string[] array = null;
		if (Directory.Exists(baseDirectory))
		{
			array = Directory.GetFiles(baseDirectory, "*.exe");
		}
		bool flag = false;
		checked
		{
			int num2 = default(int);
			if (!Information.IsNothing(array))
			{
				int num = array.Length - 1;
				num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					try
					{
						Assembly assembly = Assembly.LoadFrom(array[num2]);
						if ((!Information.IsNothing(assembly) && assembly.GetName().Name.Equals("ZTool Updater", StringComparison.OrdinalIgnoreCase)) ? true : false)
						{
							flag = true;
							break;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					num2++;
				}
			}
			if (flag)
			{
				string processName = Process.GetCurrentProcess().ProcessName;
				Process process = new Process();
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.FileName = array[num2];
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.Arguments = code.ToHexString(updatezip) + Strings.Space(1) + code.ToHexString(Assembly.GetEntryAssembly().Location) + Strings.Space(1) + code.ToHexString(processName);
				process.Start();
				Environment.Exit(0);
			}
			else
			{
				MessageBox.Show("«ZTool Updater.exe» отсутствует! Не удаётся запустить программу обновления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private bool RemoteFileExists(string fileUrl)
	{
		HttpWebRequest httpWebRequest = null;
		HttpWebResponse httpWebResponse = null;
		bool result;
		try
		{
			httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(fileUrl));
			httpWebRequest.Method = "HEAD";
			httpWebRequest.Timeout = 1000;
			httpWebRequest.Proxy = (IWebProxy)code.GetProxy();
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			if (httpWebResponse.ContentLength != 0)
			{
				result = true;
				goto IL_00af;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00af;
		}
		finally
		{
			httpWebRequest?.Abort();
			httpWebResponse?.Close();
		}
		result = false;
		goto IL_00af;
		IL_00af:
		return result;
	}

	public string Compress(string DirPath, string ZipPath, string filter = "")
	{
		string text = "";
		try
		{
			if (File.Exists(ZipPath))
			{
				FastZip fastZip = new FastZip();
				fastZip.ExtractZip(ZipPath, DirPath, filter);
				text = "Success!";
			}
			else
			{
				text = "Пакет обновления не найден!";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			text = ex2.Message;
			ProjectData.ClearProjectError();
		}
		return text;
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__54()
	{
		Label1.Text = "Не удалось подключиться к серверу!";
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__55()
	{
		Label1.Text = "Установлена последняя версия!";
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__56()
	{
		Label1.Text = "Найдена новая версия!\r\n" + RemoteInf.latestversion;
		TextBox1.AppendText("Дата выпуска: " + RemoteInf.changetime + "\r\n");
		TextBox1.AppendText("\r\n");
		TextBox1.AppendText("Что нового:\r\n");
		TextBox1.AppendText(RemoteInf.changelog);
		TextBox1.Visible = true;
		Button2.Enabled = true;
		Button2.Text = "Загрузить обновление";
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__57()
	{
		Button2.Text = "Установить обновление";
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__59()
	{
		Button2.Text = "Установить обновление";
	}
}
