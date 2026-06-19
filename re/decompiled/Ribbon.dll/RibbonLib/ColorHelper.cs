using System;
using System.Drawing;

namespace RibbonLib;

internal static class ColorHelper
{
	public static Color HSL2RGB(HSL hsl)
	{
		double num = hsl.L;
		double num2 = hsl.L;
		double num3 = hsl.L;
		double num4 = ((hsl.L <= 0.5) ? (hsl.L * (1.0 + hsl.S)) : (hsl.L + hsl.S - hsl.L * hsl.S));
		if (num4 > 0.0)
		{
			double num5 = hsl.L + hsl.L - num4;
			double num6 = (num4 - num5) / num4;
			hsl.H *= 6.0;
			int num7 = (int)hsl.H;
			double num8 = hsl.H - (double)num7;
			double num9 = num4 * num6 * num8;
			double num10 = num5 + num9;
			double num11 = num4 - num9;
			switch (num7)
			{
			case 0:
				num = num4;
				num2 = num10;
				num3 = num5;
				break;
			case 1:
				num = num11;
				num2 = num4;
				num3 = num5;
				break;
			case 2:
				num = num5;
				num2 = num4;
				num3 = num10;
				break;
			case 3:
				num = num5;
				num2 = num11;
				num3 = num4;
				break;
			case 4:
				num = num10;
				num2 = num5;
				num3 = num4;
				break;
			case 5:
				num = num4;
				num2 = num5;
				num3 = num11;
				break;
			}
		}
		return Color.FromArgb(Convert.ToByte(num * 255.0), Convert.ToByte(num2 * 255.0), Convert.ToByte(num3 * 255.0));
	}

	public static HSL RGB2HSL(Color rgb)
	{
		double num = (double)(int)rgb.R / 255.0;
		double num2 = (double)(int)rgb.G / 255.0;
		double num3 = (double)(int)rgb.B / 255.0;
		HSL result = default(HSL);
		result.H = 0.0;
		result.S = 0.0;
		result.L = 0.0;
		double val = Math.Max(num, num2);
		val = Math.Max(val, num3);
		double val2 = Math.Min(num, num2);
		val2 = Math.Min(val2, num3);
		result.L = (val2 + val) / 2.0;
		if (result.L <= 0.0)
		{
			return result;
		}
		double num4 = (result.S = val - val2);
		if (result.S > 0.0)
		{
			result.S /= ((result.L <= 0.5) ? (val + val2) : (2.0 - val - val2));
			double num5 = (val - num) / num4;
			double num6 = (val - num2) / num4;
			double num7 = (val - num3) / num4;
			if (num == val)
			{
				result.H = ((num2 == val2) ? (5.0 + num7) : (1.0 - num6));
			}
			else if (num2 == val)
			{
				result.H = ((num3 == val2) ? (1.0 + num5) : (3.0 - num7));
			}
			else
			{
				result.H = ((num == val2) ? (3.0 + num6) : (5.0 - num5));
			}
			result.H /= 6.0;
			return result;
		}
		return result;
	}

	public static HSB HSL2HSB(HSL hsl)
	{
		HSB result = default(HSB);
		result.H = (byte)(255.0 * hsl.H);
		result.S = (byte)(255.0 * hsl.S);
		if (0.1793 <= hsl.L && hsl.L <= 0.9821)
		{
			result.B = (byte)(257.7 + 149.9 * Math.Log(hsl.L));
		}
		else
		{
			result.B = 0;
		}
		return result;
	}

	public static uint HSB2Uint(HSB hsb)
	{
		return (uint)(hsb.H | (hsb.S << 8) | (hsb.B << 16));
	}
}
