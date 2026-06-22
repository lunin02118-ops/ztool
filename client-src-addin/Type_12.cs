using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;

[StandardModule]
[GeneratedCode("MyTemplate", "10.0.0.0")]
[HideModuleName]
internal sealed class Type_12
{
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class Type_13
	{
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object P_0)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(P_0));
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type m_42()
		{
			return typeof(Type_13);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T0 m_43<T0>(T0 P_0) where T0 : new()
		{
			if (P_0 == null)
			{
				return new T0();
			}
			return P_0;
		}

		[DebuggerHidden]
		private void m_44<T1>(ref T1 P_0)
		{
			P_0 = default(T1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public Type_13()
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class Type_14<T2> where T2 : new()
	{
		private readonly ContextValue<T2> f_45;

		internal T2 p_4
		{
			[DebuggerHidden]
			get
			{
				T2 val = f_45.Value;
				if (val == null)
				{
					val = new T2();
					f_45.Value = val;
				}
				return val;
			}
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Type_14()
		{
			f_45 = new ContextValue<T2>();
		}
	}

	private static readonly Type_14<Type_11> f_41 = new Type_14<Type_11>();

	private static readonly Type_14<Type_10> f_42 = new Type_14<Type_10>();

	private static readonly Type_14<User> f_43 = new Type_14<User>();

	private static readonly Type_14<Type_13> f_44 = new Type_14<Type_13>();

	[HelpKeyword("My.Computer")]
	internal static Type_11 p_0
	{
		[DebuggerHidden]
		get
		{
			return f_41.p_4;
		}
	}

	[HelpKeyword("My.Application")]
	internal static Type_10 p_1
	{
		[DebuggerHidden]
		get
		{
			return f_42.p_4;
		}
	}

	[HelpKeyword("My.User")]
	internal static User p_2
	{
		[DebuggerHidden]
		get
		{
			return f_43.p_4;
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static Type_13 p_3
	{
		[DebuggerHidden]
		get
		{
			return f_44.p_4;
		}
	}
}
