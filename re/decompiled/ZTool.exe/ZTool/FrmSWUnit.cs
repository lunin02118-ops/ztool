using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[DesignerGenerated]
public class FrmSWUnit : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Unit_MKS")]
	private RadioButton _Unit_MKS;

	[AccessedThroughProperty("Unit_Custom")]
	private RadioButton _Unit_Custom;

	[AccessedThroughProperty("Unit_IPS")]
	private RadioButton _Unit_IPS;

	[AccessedThroughProperty("Unit_MMGS")]
	private RadioButton _Unit_MMGS;

	[AccessedThroughProperty("Unit_CGS")]
	private RadioButton _Unit_CGS;

	[AccessedThroughProperty("Unit_MMKS")]
	private RadioButton _Unit_MMKS;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Basic_Length_Decimals")]
	private ComboBox _Basic_Length_Decimals;

	[AccessedThroughProperty("Basic_Angle_Decimals")]
	private ComboBox _Basic_Angle_Decimals;

	[AccessedThroughProperty("Basic_DualDimension_Decimals")]
	private ComboBox _Basic_DualDimension_Decimals;

	[AccessedThroughProperty("Basic_Angle")]
	private ComboBox _Basic_Angle;

	[AccessedThroughProperty("Basic_DualDimension")]
	private ComboBox _Basic_DualDimension;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("Mass_Decimals")]
	private ComboBox _Mass_Decimals;

	[AccessedThroughProperty("Mass_Volume")]
	private ComboBox _Mass_Volume;

	[AccessedThroughProperty("Mass_Mass")]
	private ComboBox _Mass_Mass;

	[AccessedThroughProperty("Mass_Length")]
	private ComboBox _Mass_Length;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("Label9")]
	private Label _Label9;

	[AccessedThroughProperty("Label10")]
	private Label _Label10;

	[AccessedThroughProperty("Label11")]
	private Label _Label11;

	[AccessedThroughProperty("Label12")]
	private Label _Label12;

	[AccessedThroughProperty("Basic_Length")]
	private ComboBox _Basic_Length;

	[AccessedThroughProperty("GroupBox4")]
	private GroupBox _GroupBox4;

	[AccessedThroughProperty("Motion_Time_Decimal")]
	private ComboBox _Motion_Time_Decimal;

	[AccessedThroughProperty("Motion_Power")]
	private ComboBox _Motion_Power;

	[AccessedThroughProperty("Motion_Force")]
	private ComboBox _Motion_Force;

	[AccessedThroughProperty("Motion_Time")]
	private ComboBox _Motion_Time;

	[AccessedThroughProperty("Label13")]
	private Label _Label13;

	[AccessedThroughProperty("Label14")]
	private Label _Label14;

	[AccessedThroughProperty("Label15")]
	private Label _Label15;

	[AccessedThroughProperty("Label16")]
	private Label _Label16;

	[AccessedThroughProperty("Label17")]
	private Label _Label17;

	[AccessedThroughProperty("Label18")]
	private Label _Label18;

	[AccessedThroughProperty("Motion_Energy")]
	private ComboBox _Motion_Energy;

	[AccessedThroughProperty("Label19")]
	private Label _Label19;

	[AccessedThroughProperty("Motion_Energy_Decimal")]
	private ComboBox _Motion_Energy_Decimal;

	[AccessedThroughProperty("Motion_Power_Decimal")]
	private ComboBox _Motion_Power_Decimal;

	[AccessedThroughProperty("Motion_Force_Decimal")]
	private ComboBox _Motion_Force_Decimal;

	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel1 = value;
		}
	}

	internal virtual Button OK_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _OK_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OK_Button_Click;
			if (_OK_Button != null)
			{
				_OK_Button.Click -= value2;
			}
			_OK_Button = value;
			if (_OK_Button != null)
			{
				_OK_Button.Click += value2;
			}
		}
	}

	internal virtual Button Cancel_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Cancel_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Cancel_Button_Click;
			if (_Cancel_Button != null)
			{
				_Cancel_Button.Click -= value2;
			}
			_Cancel_Button = value;
			if (_Cancel_Button != null)
			{
				_Cancel_Button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox1 = value;
		}
	}

	internal virtual RadioButton Unit_MKS
	{
		[DebuggerNonUserCode]
		get
		{
			return _Unit_MKS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = UnitSet;
			if (_Unit_MKS != null)
			{
				_Unit_MKS.CheckedChanged -= value2;
			}
			_Unit_MKS = value;
			if (_Unit_MKS != null)
			{
				_Unit_MKS.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton Unit_Custom
	{
		[DebuggerNonUserCode]
		get
		{
			return _Unit_Custom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = UnitSet;
			if (_Unit_Custom != null)
			{
				_Unit_Custom.CheckedChanged -= value2;
			}
			_Unit_Custom = value;
			if (_Unit_Custom != null)
			{
				_Unit_Custom.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton Unit_IPS
	{
		[DebuggerNonUserCode]
		get
		{
			return _Unit_IPS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = UnitSet;
			if (_Unit_IPS != null)
			{
				_Unit_IPS.CheckedChanged -= value2;
			}
			_Unit_IPS = value;
			if (_Unit_IPS != null)
			{
				_Unit_IPS.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton Unit_MMGS
	{
		[DebuggerNonUserCode]
		get
		{
			return _Unit_MMGS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = UnitSet;
			if (_Unit_MMGS != null)
			{
				_Unit_MMGS.CheckedChanged -= value2;
			}
			_Unit_MMGS = value;
			if (_Unit_MMGS != null)
			{
				_Unit_MMGS.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton Unit_CGS
	{
		[DebuggerNonUserCode]
		get
		{
			return _Unit_CGS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = UnitSet;
			if (_Unit_CGS != null)
			{
				_Unit_CGS.CheckedChanged -= value2;
			}
			_Unit_CGS = value;
			if (_Unit_CGS != null)
			{
				_Unit_CGS.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton Unit_MMKS
	{
		[DebuggerNonUserCode]
		get
		{
			return _Unit_MMKS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = UnitSet;
			if (_Unit_MMKS != null)
			{
				_Unit_MMKS.CheckedChanged -= value2;
			}
			_Unit_MMKS = value;
			if (_Unit_MMKS != null)
			{
				_Unit_MMKS.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox2 = value;
		}
	}

	internal virtual Label Label4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label4 = value;
		}
	}

	internal virtual Label Label3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label3 = value;
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

	internal virtual Label Label6
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label6 = value;
		}
	}

	internal virtual Label Label5
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label5 = value;
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

	internal virtual ComboBox Basic_Length_Decimals
	{
		[DebuggerNonUserCode]
		get
		{
			return _Basic_Length_Decimals;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Basic_Length_Decimals = value;
		}
	}

	internal virtual ComboBox Basic_Angle_Decimals
	{
		[DebuggerNonUserCode]
		get
		{
			return _Basic_Angle_Decimals;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Basic_Angle_Decimals = value;
		}
	}

	internal virtual ComboBox Basic_DualDimension_Decimals
	{
		[DebuggerNonUserCode]
		get
		{
			return _Basic_DualDimension_Decimals;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Basic_DualDimension_Decimals = value;
		}
	}

	internal virtual ComboBox Basic_Angle
	{
		[DebuggerNonUserCode]
		get
		{
			return _Basic_Angle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Basic_Angle = value;
		}
	}

	internal virtual ComboBox Basic_DualDimension
	{
		[DebuggerNonUserCode]
		get
		{
			return _Basic_DualDimension;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Basic_DualDimension = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox3 = value;
		}
	}

	internal virtual ComboBox Mass_Decimals
	{
		[DebuggerNonUserCode]
		get
		{
			return _Mass_Decimals;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Mass_Decimals = value;
		}
	}

	internal virtual ComboBox Mass_Volume
	{
		[DebuggerNonUserCode]
		get
		{
			return _Mass_Volume;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Mass_Volume = value;
		}
	}

	internal virtual ComboBox Mass_Mass
	{
		[DebuggerNonUserCode]
		get
		{
			return _Mass_Mass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Mass_Mass = value;
		}
	}

	internal virtual ComboBox Mass_Length
	{
		[DebuggerNonUserCode]
		get
		{
			return _Mass_Length;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Mass_Length = value;
		}
	}

	internal virtual Label Label7
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label7 = value;
		}
	}

	internal virtual Label Label8
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label8 = value;
		}
	}

	internal virtual Label Label9
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label9 = value;
		}
	}

	internal virtual Label Label10
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label10 = value;
		}
	}

	internal virtual Label Label11
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual Label Label12
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label12 = value;
		}
	}

	internal virtual ComboBox Basic_Length
	{
		[DebuggerNonUserCode]
		get
		{
			return _Basic_Length;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Basic_Length = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox4 = value;
		}
	}

	internal virtual ComboBox Motion_Time_Decimal
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Time_Decimal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Time_Decimal = value;
		}
	}

	internal virtual ComboBox Motion_Power
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Power;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Power = value;
		}
	}

	internal virtual ComboBox Motion_Force
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Force;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Force = value;
		}
	}

	internal virtual ComboBox Motion_Time
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Time;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Time = value;
		}
	}

	internal virtual Label Label13
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual Label Label14
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label14 = value;
		}
	}

	internal virtual Label Label15
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label15 = value;
		}
	}

	internal virtual Label Label16
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label16 = value;
		}
	}

	internal virtual Label Label17
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label17 = value;
		}
	}

	internal virtual Label Label18
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label18 = value;
		}
	}

	internal virtual ComboBox Motion_Energy
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Energy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Energy = value;
		}
	}

	internal virtual Label Label19
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label19 = value;
		}
	}

	internal virtual ComboBox Motion_Energy_Decimal
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Energy_Decimal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Energy_Decimal = value;
		}
	}

	internal virtual ComboBox Motion_Power_Decimal
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Power_Decimal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Power_Decimal = value;
		}
	}

	internal virtual ComboBox Motion_Force_Decimal
	{
		[DebuggerNonUserCode]
		get
		{
			return _Motion_Force_Decimal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Motion_Force_Decimal = value;
		}
	}

	[DebuggerNonUserCode]
	public FrmSWUnit()
	{
		base.Load += FrmSWUnit_Load;
		__ENCAddToList(this);
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
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Unit_Custom = new System.Windows.Forms.RadioButton();
		this.Unit_IPS = new System.Windows.Forms.RadioButton();
		this.Unit_MMGS = new System.Windows.Forms.RadioButton();
		this.Unit_CGS = new System.Windows.Forms.RadioButton();
		this.Unit_MMKS = new System.Windows.Forms.RadioButton();
		this.Unit_MKS = new System.Windows.Forms.RadioButton();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Basic_Angle_Decimals = new System.Windows.Forms.ComboBox();
		this.Basic_DualDimension_Decimals = new System.Windows.Forms.ComboBox();
		this.Basic_Length_Decimals = new System.Windows.Forms.ComboBox();
		this.Basic_Angle = new System.Windows.Forms.ComboBox();
		this.Basic_DualDimension = new System.Windows.Forms.ComboBox();
		this.Basic_Length = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.Mass_Decimals = new System.Windows.Forms.ComboBox();
		this.Mass_Volume = new System.Windows.Forms.ComboBox();
		this.Mass_Mass = new System.Windows.Forms.ComboBox();
		this.Mass_Length = new System.Windows.Forms.ComboBox();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label10 = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.Motion_Energy_Decimal = new System.Windows.Forms.ComboBox();
		this.Motion_Power_Decimal = new System.Windows.Forms.ComboBox();
		this.Motion_Force_Decimal = new System.Windows.Forms.ComboBox();
		this.Motion_Time_Decimal = new System.Windows.Forms.ComboBox();
		this.Motion_Energy = new System.Windows.Forms.ComboBox();
		this.Motion_Power = new System.Windows.Forms.ComboBox();
		this.Motion_Force = new System.Windows.Forms.ComboBox();
		this.Label19 = new System.Windows.Forms.Label();
		this.Motion_Time = new System.Windows.Forms.ComboBox();
		this.Label13 = new System.Windows.Forms.Label();
		this.Label14 = new System.Windows.Forms.Label();
		this.Label15 = new System.Windows.Forms.Label();
		this.Label16 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.Label18 = new System.Windows.Forms.Label();
		this.TableLayoutPanel1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(184, 536);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(184, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(12, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "ОК";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(104, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.GroupBox1.Controls.Add(this.Unit_Custom);
		this.GroupBox1.Controls.Add(this.Unit_IPS);
		this.GroupBox1.Controls.Add(this.Unit_MMGS);
		this.GroupBox1.Controls.Add(this.Unit_CGS);
		this.GroupBox1.Controls.Add(this.Unit_MMKS);
		this.GroupBox1.Controls.Add(this.Unit_MKS);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(13, 11);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(358, 96);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Система единиц";
		this.Unit_Custom.AutoSize = true;
		System.Windows.Forms.RadioButton unit_Custom = this.Unit_Custom;
		location = new System.Drawing.Point(200, 65);
		unit_Custom.Location = location;
		this.Unit_Custom.Name = "Unit_Custom";
		System.Windows.Forms.RadioButton unit_Custom2 = this.Unit_Custom;
		size = new System.Drawing.Size(62, 21);
		unit_Custom2.Size = size;
		this.Unit_Custom.TabIndex = 0;
		this.Unit_Custom.Text = "Пользовательское";
		this.Unit_Custom.UseVisualStyleBackColor = true;
		this.Unit_IPS.AutoSize = true;
		System.Windows.Forms.RadioButton unit_IPS = this.Unit_IPS;
		location = new System.Drawing.Point(200, 45);
		unit_IPS.Location = location;
		this.Unit_IPS.Name = "Unit_IPS";
		System.Windows.Forms.RadioButton unit_IPS2 = this.Unit_IPS;
		size = new System.Drawing.Size(124, 21);
		unit_IPS2.Size = size;
		this.Unit_IPS.TabIndex = 0;
		this.Unit_IPS.Text = "IPS (дюйм, фунт, с)";
		this.Unit_IPS.UseVisualStyleBackColor = true;
		this.Unit_MMGS.AutoSize = true;
		System.Windows.Forms.RadioButton unit_MMGS = this.Unit_MMGS;
		location = new System.Drawing.Point(200, 23);
		unit_MMGS.Location = location;
		this.Unit_MMGS.Name = "Unit_MMGS";
		System.Windows.Forms.RadioButton unit_MMGS2 = this.Unit_MMGS;
		size = new System.Drawing.Size(146, 21);
		unit_MMGS2.Size = size;
		this.Unit_MMGS.TabIndex = 0;
		this.Unit_MMGS.Text = "MMGS (мм, г, с)";
		this.Unit_MMGS.UseVisualStyleBackColor = true;
		this.Unit_CGS.AutoSize = true;
		System.Windows.Forms.RadioButton unit_CGS = this.Unit_CGS;
		location = new System.Drawing.Point(17, 65);
		unit_CGS.Location = location;
		this.Unit_CGS.Name = "Unit_CGS";
		System.Windows.Forms.RadioButton unit_CGS2 = this.Unit_CGS;
		size = new System.Drawing.Size(130, 21);
		unit_CGS2.Size = size;
		this.Unit_CGS.TabIndex = 0;
		this.Unit_CGS.Text = "CGS (см, г, с)";
		this.Unit_CGS.UseVisualStyleBackColor = true;
		this.Unit_MMKS.AutoSize = true;
		System.Windows.Forms.RadioButton unit_MMKS = this.Unit_MMKS;
		location = new System.Drawing.Point(17, 45);
		unit_MMKS.Location = location;
		this.Unit_MMKS.Name = "Unit_MMKS";
		System.Windows.Forms.RadioButton unit_MMKS2 = this.Unit_MMKS;
		size = new System.Drawing.Size(157, 21);
		unit_MMKS2.Size = size;
		this.Unit_MMKS.TabIndex = 0;
		this.Unit_MMKS.Text = "MMKS (мм, кг, с)";
		this.Unit_MMKS.UseVisualStyleBackColor = true;
		this.Unit_MKS.AutoSize = true;
		System.Windows.Forms.RadioButton unit_MKS = this.Unit_MKS;
		location = new System.Drawing.Point(17, 23);
		unit_MKS.Location = location;
		this.Unit_MKS.Name = "Unit_MKS";
		System.Windows.Forms.RadioButton unit_MKS2 = this.Unit_MKS;
		size = new System.Drawing.Size(133, 21);
		unit_MKS2.Size = size;
		this.Unit_MKS.TabIndex = 0;
		this.Unit_MKS.Text = "MKS (м, кг, с)";
		this.Unit_MKS.UseVisualStyleBackColor = true;
		this.GroupBox2.Controls.Add(this.Basic_Angle_Decimals);
		this.GroupBox2.Controls.Add(this.Basic_DualDimension_Decimals);
		this.GroupBox2.Controls.Add(this.Basic_Length_Decimals);
		this.GroupBox2.Controls.Add(this.Basic_Angle);
		this.GroupBox2.Controls.Add(this.Basic_DualDimension);
		this.GroupBox2.Controls.Add(this.Basic_Length);
		this.GroupBox2.Controls.Add(this.Label4);
		this.GroupBox2.Controls.Add(this.Label3);
		this.GroupBox2.Controls.Add(this.Label2);
		this.GroupBox2.Controls.Add(this.Label6);
		this.GroupBox2.Controls.Add(this.Label5);
		this.GroupBox2.Controls.Add(this.Label1);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(12, 116);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(359, 128);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Основные единицы";
		this.Basic_Angle_Decimals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Basic_Angle_Decimals.FormattingEnabled = true;
		System.Windows.Forms.ComboBox basic_Angle_Decimals = this.Basic_Angle_Decimals;
		location = new System.Drawing.Point(237, 96);
		basic_Angle_Decimals.Location = location;
		this.Basic_Angle_Decimals.Name = "Basic_Angle_Decimals";
		System.Windows.Forms.ComboBox basic_Angle_Decimals2 = this.Basic_Angle_Decimals;
		size = new System.Drawing.Size(101, 25);
		basic_Angle_Decimals2.Size = size;
		this.Basic_Angle_Decimals.TabIndex = 1;
		this.Basic_DualDimension_Decimals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Basic_DualDimension_Decimals.FormattingEnabled = true;
		System.Windows.Forms.ComboBox basic_DualDimension_Decimals = this.Basic_DualDimension_Decimals;
		location = new System.Drawing.Point(237, 72);
		basic_DualDimension_Decimals.Location = location;
		this.Basic_DualDimension_Decimals.Name = "Basic_DualDimension_Decimals";
		System.Windows.Forms.ComboBox basic_DualDimension_Decimals2 = this.Basic_DualDimension_Decimals;
		size = new System.Drawing.Size(101, 25);
		basic_DualDimension_Decimals2.Size = size;
		this.Basic_DualDimension_Decimals.TabIndex = 1;
		this.Basic_Length_Decimals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Basic_Length_Decimals.FormattingEnabled = true;
		System.Windows.Forms.ComboBox basic_Length_Decimals = this.Basic_Length_Decimals;
		location = new System.Drawing.Point(237, 48);
		basic_Length_Decimals.Location = location;
		this.Basic_Length_Decimals.Name = "Basic_Length_Decimals";
		System.Windows.Forms.ComboBox basic_Length_Decimals2 = this.Basic_Length_Decimals;
		size = new System.Drawing.Size(101, 25);
		basic_Length_Decimals2.Size = size;
		this.Basic_Length_Decimals.TabIndex = 1;
		this.Basic_Angle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Basic_Angle.FormattingEnabled = true;
		System.Windows.Forms.ComboBox basic_Angle = this.Basic_Angle;
		location = new System.Drawing.Point(123, 96);
		basic_Angle.Location = location;
		this.Basic_Angle.Name = "Basic_Angle";
		System.Windows.Forms.ComboBox basic_Angle2 = this.Basic_Angle;
		size = new System.Drawing.Size(101, 25);
		basic_Angle2.Size = size;
		this.Basic_Angle.TabIndex = 1;
		this.Basic_DualDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Basic_DualDimension.FormattingEnabled = true;
		System.Windows.Forms.ComboBox basic_DualDimension = this.Basic_DualDimension;
		location = new System.Drawing.Point(123, 72);
		basic_DualDimension.Location = location;
		this.Basic_DualDimension.Name = "Basic_DualDimension";
		System.Windows.Forms.ComboBox basic_DualDimension2 = this.Basic_DualDimension;
		size = new System.Drawing.Size(101, 25);
		basic_DualDimension2.Size = size;
		this.Basic_DualDimension.TabIndex = 1;
		this.Basic_Length.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Basic_Length.FormattingEnabled = true;
		System.Windows.Forms.ComboBox basic_Length = this.Basic_Length;
		location = new System.Drawing.Point(123, 48);
		basic_Length.Location = location;
		this.Basic_Length.Name = "Basic_Length";
		System.Windows.Forms.ComboBox basic_Length2 = this.Basic_Length;
		size = new System.Drawing.Size(101, 25);
		basic_Length2.Size = size;
		this.Basic_Length.TabIndex = 1;
		this.Label4.AutoSize = true;
		System.Windows.Forms.Label label = this.Label4;
		location = new System.Drawing.Point(16, 98);
		label.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label2 = this.Label4;
		size = new System.Drawing.Size(32, 17);
		label2.Size = size;
		this.Label4.TabIndex = 0;
		this.Label4.Text = "Угол";
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label3;
		location = new System.Drawing.Point(16, 74);
		label3.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label4 = this.Label3;
		size = new System.Drawing.Size(68, 17);
		label4.Size = size;
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Двойной размер";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label2;
		location = new System.Drawing.Point(16, 50);
		label5.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label6 = this.Label2;
		size = new System.Drawing.Size(32, 17);
		label6.Size = size;
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Длина";
		this.Label6.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label6;
		location = new System.Drawing.Point(237, 26);
		label7.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label8 = this.Label6;
		size = new System.Drawing.Size(32, 17);
		label8.Size = size;
		this.Label6.TabIndex = 0;
		this.Label6.Text = "Десятичные";
		this.Label5.AutoSize = true;
		System.Windows.Forms.Label label9 = this.Label5;
		location = new System.Drawing.Point(123, 26);
		label9.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label10 = this.Label5;
		size = new System.Drawing.Size(32, 17);
		label10.Size = size;
		this.Label5.TabIndex = 0;
		this.Label5.Text = "Единица";
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label11 = this.Label1;
		location = new System.Drawing.Point(16, 26);
		label11.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label12 = this.Label1;
		size = new System.Drawing.Size(32, 17);
		label12.Size = size;
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Тип";
		this.GroupBox3.Controls.Add(this.Mass_Decimals);
		this.GroupBox3.Controls.Add(this.Mass_Volume);
		this.GroupBox3.Controls.Add(this.Mass_Mass);
		this.GroupBox3.Controls.Add(this.Mass_Length);
		this.GroupBox3.Controls.Add(this.Label7);
		this.GroupBox3.Controls.Add(this.Label8);
		this.GroupBox3.Controls.Add(this.Label9);
		this.GroupBox3.Controls.Add(this.Label10);
		this.GroupBox3.Controls.Add(this.Label11);
		this.GroupBox3.Controls.Add(this.Label12);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox3;
		location = new System.Drawing.Point(13, 246);
		groupBox5.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox3;
		size = new System.Drawing.Size(358, 128);
		groupBox6.Size = size;
		this.GroupBox3.TabIndex = 1;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Масса/свойства сечения";
		this.Mass_Decimals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Mass_Decimals.FormattingEnabled = true;
		System.Windows.Forms.ComboBox mass_Decimals = this.Mass_Decimals;
		location = new System.Drawing.Point(238, 48);
		mass_Decimals.Location = location;
		this.Mass_Decimals.Name = "Mass_Decimals";
		System.Windows.Forms.ComboBox mass_Decimals2 = this.Mass_Decimals;
		size = new System.Drawing.Size(101, 25);
		mass_Decimals2.Size = size;
		this.Mass_Decimals.TabIndex = 1;
		this.Mass_Volume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Mass_Volume.FormattingEnabled = true;
		System.Windows.Forms.ComboBox mass_Volume = this.Mass_Volume;
		location = new System.Drawing.Point(123, 96);
		mass_Volume.Location = location;
		this.Mass_Volume.Name = "Mass_Volume";
		System.Windows.Forms.ComboBox mass_Volume2 = this.Mass_Volume;
		size = new System.Drawing.Size(101, 25);
		mass_Volume2.Size = size;
		this.Mass_Volume.TabIndex = 1;
		this.Mass_Mass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Mass_Mass.FormattingEnabled = true;
		System.Windows.Forms.ComboBox mass_Mass = this.Mass_Mass;
		location = new System.Drawing.Point(123, 72);
		mass_Mass.Location = location;
		this.Mass_Mass.Name = "Mass_Mass";
		System.Windows.Forms.ComboBox mass_Mass2 = this.Mass_Mass;
		size = new System.Drawing.Size(101, 25);
		mass_Mass2.Size = size;
		this.Mass_Mass.TabIndex = 1;
		this.Mass_Length.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Mass_Length.FormattingEnabled = true;
		System.Windows.Forms.ComboBox mass_Length = this.Mass_Length;
		location = new System.Drawing.Point(123, 48);
		mass_Length.Location = location;
		this.Mass_Length.Name = "Mass_Length";
		System.Windows.Forms.ComboBox mass_Length2 = this.Mass_Length;
		size = new System.Drawing.Size(101, 25);
		mass_Length2.Size = size;
		this.Mass_Length.TabIndex = 1;
		this.Label7.AutoSize = true;
		System.Windows.Forms.Label label13 = this.Label7;
		location = new System.Drawing.Point(16, 98);
		label13.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label14 = this.Label7;
		size = new System.Drawing.Size(56, 17);
		label14.Size = size;
		this.Label7.TabIndex = 0;
		this.Label7.Text = "Объём";
		this.Label8.AutoSize = true;
		System.Windows.Forms.Label label15 = this.Label8;
		location = new System.Drawing.Point(16, 74);
		label15.Location = location;
		this.Label8.Name = "Label8";
		System.Windows.Forms.Label label16 = this.Label8;
		size = new System.Drawing.Size(32, 17);
		label16.Size = size;
		this.Label8.TabIndex = 0;
		this.Label8.Text = "Масса";
		this.Label9.AutoSize = true;
		System.Windows.Forms.Label label17 = this.Label9;
		location = new System.Drawing.Point(16, 50);
		label17.Location = location;
		this.Label9.Name = "Label9";
		System.Windows.Forms.Label label18 = this.Label9;
		size = new System.Drawing.Size(32, 17);
		label18.Size = size;
		this.Label9.TabIndex = 0;
		this.Label9.Text = "Длина";
		this.Label10.AutoSize = true;
		System.Windows.Forms.Label label19 = this.Label10;
		location = new System.Drawing.Point(238, 26);
		label19.Location = location;
		this.Label10.Name = "Label10";
		System.Windows.Forms.Label label20 = this.Label10;
		size = new System.Drawing.Size(32, 17);
		label20.Size = size;
		this.Label10.TabIndex = 0;
		this.Label10.Text = "Десятичные";
		this.Label11.AutoSize = true;
		System.Windows.Forms.Label label21 = this.Label11;
		location = new System.Drawing.Point(123, 26);
		label21.Location = location;
		this.Label11.Name = "Label11";
		System.Windows.Forms.Label label22 = this.Label11;
		size = new System.Drawing.Size(32, 17);
		label22.Size = size;
		this.Label11.TabIndex = 0;
		this.Label11.Text = "Единица";
		this.Label12.AutoSize = true;
		System.Windows.Forms.Label label23 = this.Label12;
		location = new System.Drawing.Point(16, 26);
		label23.Location = location;
		this.Label12.Name = "Label12";
		System.Windows.Forms.Label label24 = this.Label12;
		size = new System.Drawing.Size(32, 17);
		label24.Size = size;
		this.Label12.TabIndex = 0;
		this.Label12.Text = "Тип";
		this.GroupBox4.Controls.Add(this.Motion_Energy_Decimal);
		this.GroupBox4.Controls.Add(this.Motion_Power_Decimal);
		this.GroupBox4.Controls.Add(this.Motion_Force_Decimal);
		this.GroupBox4.Controls.Add(this.Motion_Time_Decimal);
		this.GroupBox4.Controls.Add(this.Motion_Energy);
		this.GroupBox4.Controls.Add(this.Motion_Power);
		this.GroupBox4.Controls.Add(this.Motion_Force);
		this.GroupBox4.Controls.Add(this.Label19);
		this.GroupBox4.Controls.Add(this.Motion_Time);
		this.GroupBox4.Controls.Add(this.Label13);
		this.GroupBox4.Controls.Add(this.Label14);
		this.GroupBox4.Controls.Add(this.Label15);
		this.GroupBox4.Controls.Add(this.Label16);
		this.GroupBox4.Controls.Add(this.Label17);
		this.GroupBox4.Controls.Add(this.Label18);
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox4;
		location = new System.Drawing.Point(12, 376);
		groupBox7.Location = location;
		this.GroupBox4.Name = "GroupBox4";
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox4;
		size = new System.Drawing.Size(358, 152);
		groupBox8.Size = size;
		this.GroupBox4.TabIndex = 1;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Единицы движения";
		this.Motion_Energy_Decimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Energy_Decimal.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Energy_Decimal = this.Motion_Energy_Decimal;
		location = new System.Drawing.Point(238, 120);
		motion_Energy_Decimal.Location = location;
		this.Motion_Energy_Decimal.Name = "Motion_Energy_Decimal";
		System.Windows.Forms.ComboBox motion_Energy_Decimal2 = this.Motion_Energy_Decimal;
		size = new System.Drawing.Size(101, 25);
		motion_Energy_Decimal2.Size = size;
		this.Motion_Energy_Decimal.TabIndex = 1;
		this.Motion_Power_Decimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Power_Decimal.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Power_Decimal = this.Motion_Power_Decimal;
		location = new System.Drawing.Point(238, 96);
		motion_Power_Decimal.Location = location;
		this.Motion_Power_Decimal.Name = "Motion_Power_Decimal";
		System.Windows.Forms.ComboBox motion_Power_Decimal2 = this.Motion_Power_Decimal;
		size = new System.Drawing.Size(101, 25);
		motion_Power_Decimal2.Size = size;
		this.Motion_Power_Decimal.TabIndex = 1;
		this.Motion_Force_Decimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Force_Decimal.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Force_Decimal = this.Motion_Force_Decimal;
		location = new System.Drawing.Point(238, 72);
		motion_Force_Decimal.Location = location;
		this.Motion_Force_Decimal.Name = "Motion_Force_Decimal";
		System.Windows.Forms.ComboBox motion_Force_Decimal2 = this.Motion_Force_Decimal;
		size = new System.Drawing.Size(101, 25);
		motion_Force_Decimal2.Size = size;
		this.Motion_Force_Decimal.TabIndex = 1;
		this.Motion_Time_Decimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Time_Decimal.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Time_Decimal = this.Motion_Time_Decimal;
		location = new System.Drawing.Point(238, 48);
		motion_Time_Decimal.Location = location;
		this.Motion_Time_Decimal.Name = "Motion_Time_Decimal";
		System.Windows.Forms.ComboBox motion_Time_Decimal2 = this.Motion_Time_Decimal;
		size = new System.Drawing.Size(101, 25);
		motion_Time_Decimal2.Size = size;
		this.Motion_Time_Decimal.TabIndex = 1;
		this.Motion_Energy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Energy.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Energy = this.Motion_Energy;
		location = new System.Drawing.Point(123, 120);
		motion_Energy.Location = location;
		this.Motion_Energy.Name = "Motion_Energy";
		System.Windows.Forms.ComboBox motion_Energy2 = this.Motion_Energy;
		size = new System.Drawing.Size(101, 25);
		motion_Energy2.Size = size;
		this.Motion_Energy.TabIndex = 1;
		this.Motion_Power.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Power.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Power = this.Motion_Power;
		location = new System.Drawing.Point(123, 96);
		motion_Power.Location = location;
		this.Motion_Power.Name = "Motion_Power";
		System.Windows.Forms.ComboBox motion_Power2 = this.Motion_Power;
		size = new System.Drawing.Size(101, 25);
		motion_Power2.Size = size;
		this.Motion_Power.TabIndex = 1;
		this.Motion_Force.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Force.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Force = this.Motion_Force;
		location = new System.Drawing.Point(123, 72);
		motion_Force.Location = location;
		this.Motion_Force.Name = "Motion_Force";
		System.Windows.Forms.ComboBox motion_Force2 = this.Motion_Force;
		size = new System.Drawing.Size(101, 25);
		motion_Force2.Size = size;
		this.Motion_Force.TabIndex = 1;
		this.Label19.AutoSize = true;
		System.Windows.Forms.Label label25 = this.Label19;
		location = new System.Drawing.Point(16, 122);
		label25.Location = location;
		this.Label19.Name = "Label19";
		System.Windows.Forms.Label label26 = this.Label19;
		size = new System.Drawing.Size(32, 17);
		label26.Size = size;
		this.Label19.TabIndex = 0;
		this.Label19.Text = "Энергия";
		this.Motion_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.Motion_Time.FormattingEnabled = true;
		System.Windows.Forms.ComboBox motion_Time = this.Motion_Time;
		location = new System.Drawing.Point(123, 48);
		motion_Time.Location = location;
		this.Motion_Time.Name = "Motion_Time";
		System.Windows.Forms.ComboBox motion_Time2 = this.Motion_Time;
		size = new System.Drawing.Size(101, 25);
		motion_Time2.Size = size;
		this.Motion_Time.TabIndex = 1;
		this.Label13.AutoSize = true;
		System.Windows.Forms.Label label27 = this.Label13;
		location = new System.Drawing.Point(16, 98);
		label27.Location = location;
		this.Label13.Name = "Label13";
		System.Windows.Forms.Label label28 = this.Label13;
		size = new System.Drawing.Size(32, 17);
		label28.Size = size;
		this.Label13.TabIndex = 0;
		this.Label13.Text = "Сила";
		this.Label14.AutoSize = true;
		System.Windows.Forms.Label label29 = this.Label14;
		location = new System.Drawing.Point(16, 74);
		label29.Location = location;
		this.Label14.Name = "Label14";
		System.Windows.Forms.Label label30 = this.Label14;
		size = new System.Drawing.Size(20, 17);
		label30.Size = size;
		this.Label14.TabIndex = 0;
		this.Label14.Text = "Сила";
		this.Label15.AutoSize = true;
		System.Windows.Forms.Label label31 = this.Label15;
		location = new System.Drawing.Point(16, 50);
		label31.Location = location;
		this.Label15.Name = "Label15";
		System.Windows.Forms.Label label32 = this.Label15;
		size = new System.Drawing.Size(32, 17);
		label32.Size = size;
		this.Label15.TabIndex = 0;
		this.Label15.Text = "Время";
		this.Label16.AutoSize = true;
		System.Windows.Forms.Label label33 = this.Label16;
		location = new System.Drawing.Point(238, 26);
		label33.Location = location;
		this.Label16.Name = "Label16";
		System.Windows.Forms.Label label34 = this.Label16;
		size = new System.Drawing.Size(32, 17);
		label34.Size = size;
		this.Label16.TabIndex = 0;
		this.Label16.Text = "Десятичные";
		this.Label17.AutoSize = true;
		System.Windows.Forms.Label label35 = this.Label17;
		location = new System.Drawing.Point(123, 26);
		label35.Location = location;
		this.Label17.Name = "Label17";
		System.Windows.Forms.Label label36 = this.Label17;
		size = new System.Drawing.Size(32, 17);
		label36.Size = size;
		this.Label17.TabIndex = 0;
		this.Label17.Text = "Единица";
		this.Label18.AutoSize = true;
		System.Windows.Forms.Label label37 = this.Label18;
		location = new System.Drawing.Point(16, 26);
		label37.Location = location;
		this.Label18.Name = "Label18";
		System.Windows.Forms.Label label38 = this.Label18;
		size = new System.Drawing.Size(32, 17);
		label38.Size = size;
		this.Label18.TabIndex = 0;
		this.Label18.Text = "Тип";
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(380, 573);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox4);
		this.Controls.Add(this.GroupBox3);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmSWUnit";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Единица";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
		this.AutoScroll = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.ClientSize = new System.Drawing.Size(640, 650);
		this.MinimumSize = new System.Drawing.Size(640, 650);
		this.Controls.Find("GroupBox1", true)[0].Width = 600;
		this.Controls.Find("Unit_MMKS", true)[0].Width = 200;
		this.Controls.Find("Unit_MMKS", true)[0].Text = "MMKS (мм, кг, с)";
		this.Controls.Find("Unit_MMGS", true)[0].Left = 330;
		this.Controls.Find("Unit_MMGS", true)[0].Width = 150;
		this.Controls.Find("Unit_IPS", true)[0].Left = 330;
		this.Controls.Find("Unit_IPS", true)[0].Width = 180;
		this.Controls.Find("Unit_Custom", true)[0].Left = 330;
		this.Controls.Find("Unit_Custom", true)[0].Width = 180;
		this.Controls.Find("GroupBox2", true)[0].Width = 500;
		this.Controls.Find("GroupBox3", true)[0].Width = 500;
		this.Controls.Find("GroupBox4", true)[0].Width = 500;
		this.Controls.Find("Label3", true)[0].Width = 100;
		this.Controls.Find("Label3", true)[0].Text = "Двойной размер";
		this.Controls.Find("Label7", true)[0].Width = 80;
		this.Controls.Find("Label7", true)[0].Text = "Объём";
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Savecfg();
		Close();
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	public void FrmSWUnit_Load(object sender, EventArgs e)
	{
		Basic_Length.Items.Clear();
		Basic_Angle.Items.Clear();
		Basic_DualDimension.Items.Clear();
		Basic_Length_Decimals.Items.Clear();
		Basic_DualDimension_Decimals.Items.Clear();
		Basic_Angle_Decimals.Items.Clear();
		Mass_Length.Items.Clear();
		Mass_Mass.Items.Clear();
		Mass_Volume.Items.Clear();
		Mass_Decimals.Items.Clear();
		Motion_Time.Items.Clear();
		Motion_Force.Items.Clear();
		Motion_Power.Items.Clear();
		Motion_Energy.Items.Clear();
		Motion_Time_Decimal.Items.Clear();
		Motion_Force_Decimal.Items.Clear();
		Motion_Power_Decimal.Items.Clear();
		Motion_Energy_Decimal.Items.Clear();
		Basic_Length.Items.AddRange(new object[11]
		{
			"ангстрем", "нанометр", "микрометр", "миллиметр", "сантиметр", "метр", "тысячная дюйма", "мил", "дюйм", "фут",
			"футы и дюймы"
		});
		Basic_DualDimension.Items.AddRange(new object[11]
		{
			"ангстрем", "нанометр", "микрометр", "миллиметр", "сантиметр", "метр", "тысячная дюйма", "мил", "дюйм", "фут",
			"футы и дюймы"
		});
		Basic_Angle.Items.AddRange(new object[4] { "градус", "градус/минута", "градус/минута/секунда", "радиан" });
		Basic_Length_Decimals.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Basic_DualDimension_Decimals.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Basic_Angle_Decimals.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Mass_Length.Items.AddRange(new object[11]
		{
			"ангстрем", "нанометр", "микрометр", "миллиметр", "сантиметр", "метр", "тысячная дюйма", "мил", "дюйм", "фут",
			"футы и дюймы"
		});
		Mass_Mass.Items.AddRange(new object[4] { "миллиграмм", "грамм", "килограмм", "фунт" });
		Mass_Volume.Items.AddRange(new object[15]
		{
			"ангстрем³", "нанометр³", "микрометр³", "миллиметр³", "сантиметр³", "метр³", "тысячная дюйма³", "мил³", "дюйм³", "фут³",
			"микролитр", "миллилитр", "сантилитр", "децилитр", "литр"
		});
		Mass_Decimals.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Motion_Time.Items.AddRange(new object[6] { "секунда", "миллисекунда", "микросекунда", "наносекунда", "минута", "час" });
		Motion_Force.Items.AddRange(new object[8] { "дина", "миллиньютон", "ньютон", "килоньютон", "меганьютон", "фунт-сила", "килограмм-сила", "унция-сила" });
		Motion_Power.Items.AddRange(new object[3] { "ватт", "лошадиная сила", "киловатт" });
		Motion_Energy.Items.AddRange(new object[4] { "джоуль", "эрг", "BTU", "киловатт-час" });
		Motion_Time_Decimal.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Motion_Force_Decimal.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Motion_Power_Decimal.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Motion_Energy_Decimal.Items.AddRange(new object[9] { "Нет", ".1", ".12", ".123", ".1234", ".12345", ".123456", ".1234567", ".12345678" });
		Loadcfg();
		Motion_Force_Decimal.SelectedIndex = 2;
		Motion_Power_Decimal.SelectedIndex = 2;
		Motion_Energy_Decimal.SelectedIndex = 2;
		Motion_Force.Enabled = false;
		Motion_Power.Enabled = false;
		Motion_Energy.Enabled = false;
		Motion_Force_Decimal.Enabled = false;
		Motion_Power_Decimal.Enabled = false;
		Motion_Energy_Decimal.Enabled = false;
	}

	private void UnitSet(object sender, EventArgs e)
	{
		Basic_Length.Enabled = false;
		Mass_Length.Enabled = false;
		Mass_Mass.Enabled = false;
		Mass_Volume.Enabled = false;
		Motion_Time.Enabled = false;
		string name = ((RadioButton)sender).Name;
		if (Operators.CompareString(name, Unit_MKS.Name, TextCompare: false) == 0)
		{
			Basic_Length.SelectedIndex = 5;
			Mass_Length.SelectedIndex = 5;
			Mass_Mass.SelectedIndex = 2;
			Mass_Volume.SelectedIndex = 5;
			Motion_Time.SelectedIndex = 0;
			Motion_Force.SelectedIndex = 2;
			Motion_Power.SelectedIndex = 0;
			Motion_Energy.SelectedIndex = 0;
		}
		else if (Operators.CompareString(name, Unit_MMKS.Name, TextCompare: false) == 0)
		{
			Basic_Length.SelectedIndex = 3;
			Mass_Length.SelectedIndex = 3;
			Mass_Mass.SelectedIndex = 2;
			Mass_Volume.SelectedIndex = 3;
			Motion_Time.SelectedIndex = 0;
			Motion_Force.SelectedIndex = 2;
			Motion_Power.SelectedIndex = 0;
			Motion_Energy.SelectedIndex = 0;
		}
		else if (Operators.CompareString(name, Unit_CGS.Name, TextCompare: false) == 0)
		{
			Basic_Length.SelectedIndex = 4;
			Mass_Length.SelectedIndex = 4;
			Mass_Mass.SelectedIndex = 1;
			Mass_Volume.SelectedIndex = 4;
			Motion_Time.SelectedIndex = 0;
			Motion_Force.SelectedIndex = 0;
			Motion_Power.SelectedIndex = 1;
			Motion_Energy.SelectedIndex = 1;
		}
		else if (Operators.CompareString(name, Unit_MMGS.Name, TextCompare: false) == 0)
		{
			Basic_Length.SelectedIndex = 3;
			Mass_Length.SelectedIndex = 3;
			Mass_Mass.SelectedIndex = 1;
			Mass_Volume.SelectedIndex = 3;
			Motion_Time.SelectedIndex = 0;
			Motion_Force.SelectedIndex = 2;
			Motion_Power.SelectedIndex = 0;
			Motion_Energy.SelectedIndex = 0;
		}
		else if (Operators.CompareString(name, Unit_IPS.Name, TextCompare: false) == 0)
		{
			Basic_Length.SelectedIndex = 8;
			Mass_Length.SelectedIndex = 8;
			Mass_Mass.SelectedIndex = 3;
			Mass_Volume.SelectedIndex = 8;
			Motion_Time.SelectedIndex = 0;
			Motion_Force.SelectedIndex = 5;
			Motion_Power.SelectedIndex = 0;
			Motion_Energy.SelectedIndex = 2;
		}
		else if (Operators.CompareString(name, Unit_Custom.Name, TextCompare: false) == 0)
		{
			Basic_Length.Enabled = true;
			Mass_Length.Enabled = true;
			Mass_Mass.Enabled = true;
			Mass_Volume.Enabled = true;
			Motion_Time.Enabled = true;
		}
	}

	private void Savecfg()
	{
		CConfigMng.Config.Unitset.Clear();
		foreach (Control control in Controls)
		{
			FindctlToSave(control);
		}
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.Unitset.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.Unitset.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.Unitset.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.Unitset.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Control control = default(Control);
		Control control2 = default(Control);
		bool flag = default(bool);
		IEnumerator enumerator = default(IEnumerator);
		IEnumerator enumerator2 = default(IEnumerator);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000a;
				case 372:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000a;
						case 3:
							goto IL_000f;
						case 4:
							goto IL_002c;
						case 5:
							goto IL_0037;
						case 6:
							goto IL_0066;
						case 7:
							goto IL_008a;
						case 8:
							goto IL_009e;
						case 9:
							goto IL_00ae;
						case 10:
							goto IL_00bf;
						case 11:
						case 12:
							goto IL_00c6;
						case 13:
							goto IL_00f9;
						case 14:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 15:
						case 16:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_002c:
					num2 = 4;
					FindctlToLoad(control);
					goto IL_0037;
					IL_008a:
					num2 = 7;
					if (((RadioButton)control2).Checked)
					{
						goto IL_009e;
					}
					goto IL_00c6;
					IL_00f9:
					num2 = 13;
					if (flag)
					{
						goto end_IL_0001_3;
					}
					break;
					IL_009e:
					num2 = 8;
					((RadioButton)control2).Checked = false;
					goto IL_00ae;
					IL_000a:
					num2 = 2;
					flag = false;
					goto IL_000f;
					IL_000f:
					num2 = 3;
					enumerator = Controls.GetEnumerator();
					goto IL_003b;
					IL_003b:
					if (enumerator.MoveNext())
					{
						control = (Control)enumerator.Current;
						goto IL_002c;
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					goto IL_0066;
					IL_00ae:
					num2 = 9;
					((RadioButton)control2).Checked = true;
					goto IL_00bf;
					IL_00c6:
					num2 = 12;
					goto IL_00cb;
					IL_0066:
					num2 = 6;
					enumerator2 = GroupBox1.Controls.GetEnumerator();
					goto IL_00cb;
					IL_00cb:
					if (enumerator2.MoveNext())
					{
						control2 = (Control)enumerator2.Current;
						goto IL_008a;
					}
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
					goto IL_00f9;
					IL_00bf:
					num2 = 10;
					flag = true;
					goto IL_00c6;
					IL_0037:
					num2 = 5;
					goto IL_003b;
					end_IL_0001_2:
					break;
				}
				num2 = 14;
				Unit_MMKS.Checked = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 372;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void FindctlToLoad(Control parent)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string name = default(string);
		Control control = default(Control);
		IEnumerator enumerator = default(IEnumerator);
		int num5 = default(int);
		int num6 = default(int);
		string[] array = default(string[]);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					int num7;
					int num8;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000a;
					case 1844:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_000a;
							case 3:
								goto IL_002a;
							case 4:
								goto IL_0047;
							case 5:
								goto IL_0067;
							case 6:
								goto IL_0085;
							case 7:
								goto IL_0097;
							case 9:
								goto IL_00b3;
							case 10:
								goto IL_00c6;
							case 12:
								goto IL_00e0;
							case 13:
								goto IL_00f3;
							case 15:
								goto IL_0113;
							case 16:
								goto IL_0126;
							case 19:
							case 20:
								goto IL_0143;
							case 8:
							case 11:
							case 14:
							case 17:
							case 18:
							case 21:
								goto IL_0158;
							case 22:
								goto IL_016e;
							case 23:
								goto IL_0189;
							case 25:
							case 26:
								goto IL_019b;
							case 27:
								goto IL_01bc;
							case 29:
								goto IL_01d2;
							case 30:
								goto IL_01f3;
							case 32:
								goto IL_0209;
							case 33:
								goto IL_022a;
							case 35:
								goto IL_0240;
							case 36:
								goto IL_0261;
							case 38:
								goto IL_0277;
							case 39:
								goto IL_0298;
							case 41:
								goto IL_02ae;
							case 42:
								goto IL_02cf;
							case 44:
								goto IL_02e5;
							case 45:
								goto IL_0306;
							case 47:
								goto IL_031c;
							case 48:
								goto IL_033d;
							case 50:
								goto IL_0353;
							case 51:
								goto IL_0374;
							case 53:
								goto IL_038a;
							case 54:
								goto IL_03ab;
							case 56:
								goto IL_03c1;
							case 57:
								goto IL_03e2;
							case 59:
								goto IL_03f8;
							case 60:
								goto IL_0419;
							case 62:
								goto IL_042f;
							case 63:
								goto IL_0450;
							case 65:
								goto IL_0466;
							case 66:
								goto IL_0487;
							case 68:
								goto IL_049d;
							case 69:
								goto IL_04be;
							case 71:
								goto IL_04d4;
							case 72:
								goto IL_04f5;
							case 74:
								goto IL_0508;
							case 75:
								goto IL_0529;
							case 77:
								goto IL_053c;
							case 78:
								goto IL_055d;
							case 24:
							case 28:
							case 31:
							case 34:
							case 37:
							case 40:
							case 43:
							case 46:
							case 49:
							case 52:
							case 55:
							case 58:
							case 61:
							case 64:
							case 67:
							case 70:
							case 73:
							case 76:
							case 79:
							case 80:
							case 81:
							case 82:
								goto IL_0571;
							case 83:
								goto IL_0581;
							case 84:
							case 85:
								goto IL_058e;
							default:
								goto end_IL_0001;
							case 86:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_053c:
						num2 = 77;
						if (Operators.CompareString(name, Motion_Energy_Decimal.Name, TextCompare: false) == 0)
						{
							goto IL_055d;
						}
						goto IL_0571;
						IL_055d:
						num2 = 78;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_0529:
						num2 = 75;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_0571:
						num2 = 82;
						if (control.HasChildren)
						{
							goto IL_0581;
						}
						goto IL_058e;
						IL_000a:
						num2 = 2;
						enumerator = parent.Controls.GetEnumerator();
						goto IL_0593;
						IL_0593:
						if (enumerator.MoveNext())
						{
							control = (Control)enumerator.Current;
							goto IL_002a;
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto end_IL_0001_2;
						IL_0581:
						num2 = 83;
						FindctlToSave(control);
						goto IL_058e;
						IL_0143:
						num2 = 20;
						num5++;
						goto IL_014c;
						IL_058e:
						num2 = 85;
						goto IL_0593;
						IL_002a:
						num2 = 3;
						num6 = CConfigMng.Config.Unitset.Count - 1;
						num5 = 0;
						goto IL_014c;
						IL_014c:
						num7 = num5;
						num8 = num6;
						if (num7 <= num8)
						{
							goto IL_0047;
						}
						goto IL_0158;
						IL_0047:
						num2 = 4;
						array = Strings.Split(CConfigMng.Config.Unitset[num5], "\n");
						goto IL_0067;
						IL_0067:
						num2 = 5;
						if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_0085;
						}
						goto IL_0143;
						IL_0085:
						num2 = 6;
						if (control is CheckBox)
						{
							goto IL_0097;
						}
						goto IL_00b3;
						IL_0097:
						num2 = 7;
						((CheckBox)control).Checked = code.Cbool1(array[1]);
						goto IL_0158;
						IL_00b3:
						num2 = 9;
						if (control is TextBox)
						{
							goto IL_00c6;
						}
						goto IL_00e0;
						IL_00c6:
						num2 = 10;
						((TextBox)control).Text = array[1].ToString();
						goto IL_0158;
						IL_00e0:
						num2 = 12;
						if (control is ComboBox)
						{
							goto IL_00f3;
						}
						goto IL_0113;
						IL_00f3:
						num2 = 13;
						((ComboBox)control).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_0158;
						IL_0113:
						num2 = 15;
						if (control is RadioButton)
						{
							goto IL_0126;
						}
						goto IL_0158;
						IL_0126:
						num2 = 16;
						((RadioButton)control).Checked = code.Cbool1(array[1]);
						goto IL_0158;
						IL_0158:
						num2 = 21;
						if (control is ComboBox)
						{
							goto IL_016e;
						}
						goto IL_0571;
						IL_016e:
						num2 = 22;
						if (((ComboBox)control).SelectedItem == null)
						{
							goto IL_0189;
						}
						goto IL_0571;
						IL_0189:
						num2 = 23;
						name = ((ComboBox)control).Name;
						goto IL_019b;
						IL_019b:
						num2 = 26;
						if (Operators.CompareString(name, Basic_Length.Name, TextCompare: false) == 0)
						{
							goto IL_01bc;
						}
						goto IL_01d2;
						IL_01bc:
						num2 = 27;
						((ComboBox)control).SelectedIndex = 3;
						goto IL_0571;
						IL_01d2:
						num2 = 29;
						if (Operators.CompareString(name, Basic_DualDimension.Name, TextCompare: false) == 0)
						{
							goto IL_01f3;
						}
						goto IL_0209;
						IL_01f3:
						num2 = 30;
						((ComboBox)control).SelectedIndex = 3;
						goto IL_0571;
						IL_0209:
						num2 = 32;
						if (Operators.CompareString(name, Basic_Angle.Name, TextCompare: false) == 0)
						{
							goto IL_022a;
						}
						goto IL_0240;
						IL_022a:
						num2 = 33;
						((ComboBox)control).SelectedIndex = 0;
						goto IL_0571;
						IL_0240:
						num2 = 35;
						if (Operators.CompareString(name, Basic_Length_Decimals.Name, TextCompare: false) == 0)
						{
							goto IL_0261;
						}
						goto IL_0277;
						IL_0261:
						num2 = 36;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_0277:
						num2 = 38;
						if (Operators.CompareString(name, Basic_DualDimension_Decimals.Name, TextCompare: false) == 0)
						{
							goto IL_0298;
						}
						goto IL_02ae;
						IL_0298:
						num2 = 39;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_02ae:
						num2 = 41;
						if (Operators.CompareString(name, Basic_Angle_Decimals.Name, TextCompare: false) == 0)
						{
							goto IL_02cf;
						}
						goto IL_02e5;
						IL_02cf:
						num2 = 42;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_02e5:
						num2 = 44;
						if (Operators.CompareString(name, Mass_Length.Name, TextCompare: false) == 0)
						{
							goto IL_0306;
						}
						goto IL_031c;
						IL_0306:
						num2 = 45;
						((ComboBox)control).SelectedIndex = 3;
						goto IL_0571;
						IL_031c:
						num2 = 47;
						if (Operators.CompareString(name, Mass_Mass.Name, TextCompare: false) == 0)
						{
							goto IL_033d;
						}
						goto IL_0353;
						IL_033d:
						num2 = 48;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_0353:
						num2 = 50;
						if (Operators.CompareString(name, Mass_Volume.Name, TextCompare: false) == 0)
						{
							goto IL_0374;
						}
						goto IL_038a;
						IL_0374:
						num2 = 51;
						((ComboBox)control).SelectedIndex = 3;
						goto IL_0571;
						IL_038a:
						num2 = 53;
						if (Operators.CompareString(name, Mass_Decimals.Name, TextCompare: false) == 0)
						{
							goto IL_03ab;
						}
						goto IL_03c1;
						IL_03ab:
						num2 = 54;
						((ComboBox)control).SelectedIndex = 4;
						goto IL_0571;
						IL_03c1:
						num2 = 56;
						if (Operators.CompareString(name, Motion_Time.Name, TextCompare: false) == 0)
						{
							goto IL_03e2;
						}
						goto IL_03f8;
						IL_03e2:
						num2 = 57;
						((ComboBox)control).SelectedIndex = 0;
						goto IL_0571;
						IL_03f8:
						num2 = 59;
						if (Operators.CompareString(name, Motion_Force.Name, TextCompare: false) == 0)
						{
							goto IL_0419;
						}
						goto IL_042f;
						IL_0419:
						num2 = 60;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_042f:
						num2 = 62;
						if (Operators.CompareString(name, Motion_Power.Name, TextCompare: false) == 0)
						{
							goto IL_0450;
						}
						goto IL_0466;
						IL_0450:
						num2 = 63;
						((ComboBox)control).SelectedIndex = 0;
						goto IL_0571;
						IL_0466:
						num2 = 65;
						if (Operators.CompareString(name, Motion_Energy.Name, TextCompare: false) == 0)
						{
							goto IL_0487;
						}
						goto IL_049d;
						IL_0487:
						num2 = 66;
						((ComboBox)control).SelectedIndex = 0;
						goto IL_0571;
						IL_049d:
						num2 = 68;
						if (Operators.CompareString(name, Motion_Time_Decimal.Name, TextCompare: false) == 0)
						{
							goto IL_04be;
						}
						goto IL_04d4;
						IL_04be:
						num2 = 69;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_04d4:
						num2 = 71;
						if (Operators.CompareString(name, Motion_Force_Decimal.Name, TextCompare: false) == 0)
						{
							goto IL_04f5;
						}
						goto IL_0508;
						IL_04f5:
						num2 = 72;
						((ComboBox)control).SelectedIndex = 2;
						goto IL_0571;
						IL_0508:
						num2 = 74;
						if (Operators.CompareString(name, Motion_Power_Decimal.Name, TextCompare: false) == 0)
						{
							goto IL_0529;
						}
						goto IL_053c;
						end_IL_0001:
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1844;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_2:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}
}
