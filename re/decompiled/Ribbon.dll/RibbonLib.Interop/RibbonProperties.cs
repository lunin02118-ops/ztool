using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

public static class RibbonProperties
{
	public static PropertyKey Enabled = CreateRibbonPropertyKey(1, VarEnum.VT_BOOL);

	public static PropertyKey LabelDescription = CreateRibbonPropertyKey(2, VarEnum.VT_LPWSTR);

	public static PropertyKey Keytip = CreateRibbonPropertyKey(3, VarEnum.VT_LPWSTR);

	public static PropertyKey Label = CreateRibbonPropertyKey(4, VarEnum.VT_LPWSTR);

	public static PropertyKey TooltipDescription = CreateRibbonPropertyKey(5, VarEnum.VT_LPWSTR);

	public static PropertyKey TooltipTitle = CreateRibbonPropertyKey(6, VarEnum.VT_LPWSTR);

	public static PropertyKey LargeImage = CreateRibbonPropertyKey(7, VarEnum.VT_UNKNOWN);

	public static PropertyKey LargeHighContrastImage = CreateRibbonPropertyKey(8, VarEnum.VT_UNKNOWN);

	public static PropertyKey SmallImage = CreateRibbonPropertyKey(9, VarEnum.VT_UNKNOWN);

	public static PropertyKey SmallHighContrastImage = CreateRibbonPropertyKey(10, VarEnum.VT_UNKNOWN);

	public static PropertyKey CommandID = CreateRibbonPropertyKey(100, VarEnum.VT_UI4);

	public static PropertyKey ItemsSource = CreateRibbonPropertyKey(101, VarEnum.VT_UNKNOWN);

	public static PropertyKey Categories = CreateRibbonPropertyKey(102, VarEnum.VT_UNKNOWN);

	public static PropertyKey CategoryID = CreateRibbonPropertyKey(103, VarEnum.VT_UI4);

	public static PropertyKey SelectedItem = CreateRibbonPropertyKey(104, VarEnum.VT_UI4);

	public static PropertyKey CommandType = CreateRibbonPropertyKey(105, VarEnum.VT_UI4);

	public static PropertyKey ItemImage = CreateRibbonPropertyKey(106, VarEnum.VT_UNKNOWN);

	public static PropertyKey BooleanValue = CreateRibbonPropertyKey(200, VarEnum.VT_BOOL);

	public static PropertyKey DecimalValue = CreateRibbonPropertyKey(201, VarEnum.VT_DECIMAL);

	public static PropertyKey StringValue = CreateRibbonPropertyKey(202, VarEnum.VT_LPWSTR);

	public static PropertyKey MaxValue = CreateRibbonPropertyKey(203, VarEnum.VT_DECIMAL);

	public static PropertyKey MinValue = CreateRibbonPropertyKey(204, VarEnum.VT_DECIMAL);

	public static PropertyKey Increment = CreateRibbonPropertyKey(205, VarEnum.VT_DECIMAL);

	public static PropertyKey DecimalPlaces = CreateRibbonPropertyKey(206, VarEnum.VT_UI4);

	public static PropertyKey FormatString = CreateRibbonPropertyKey(207, VarEnum.VT_LPWSTR);

	public static PropertyKey RepresentativeString = CreateRibbonPropertyKey(208, VarEnum.VT_LPWSTR);

	public static PropertyKey FontProperties = CreateRibbonPropertyKey(300, VarEnum.VT_UNKNOWN);

	public static PropertyKey FontProperties_Family = CreateRibbonPropertyKey(301, VarEnum.VT_LPWSTR);

	public static PropertyKey FontProperties_Size = CreateRibbonPropertyKey(302, VarEnum.VT_DECIMAL);

	public static PropertyKey FontProperties_Bold = CreateRibbonPropertyKey(303, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_Italic = CreateRibbonPropertyKey(304, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_Underline = CreateRibbonPropertyKey(305, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_Strikethrough = CreateRibbonPropertyKey(306, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_VerticalPositioning = CreateRibbonPropertyKey(307, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_ForegroundColor = CreateRibbonPropertyKey(308, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_BackgroundColor = CreateRibbonPropertyKey(309, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_ForegroundColorType = CreateRibbonPropertyKey(310, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_BackgroundColorType = CreateRibbonPropertyKey(311, VarEnum.VT_UI4);

	public static PropertyKey FontProperties_ChangedProperties = CreateRibbonPropertyKey(312, VarEnum.VT_UNKNOWN);

	public static PropertyKey FontProperties_DeltaSize = CreateRibbonPropertyKey(313, VarEnum.VT_UINT);

	public static PropertyKey RecentItems = CreateRibbonPropertyKey(350, (VarEnum)8205);

	public static PropertyKey Pinned = CreateRibbonPropertyKey(351, VarEnum.VT_BOOL);

	public static PropertyKey Color = CreateRibbonPropertyKey(400, VarEnum.VT_UI4);

	public static PropertyKey ColorType = CreateRibbonPropertyKey(401, VarEnum.VT_UI4);

	public static PropertyKey ColorMode = CreateRibbonPropertyKey(402, VarEnum.VT_UI4);

	public static PropertyKey ThemeColorsCategoryLabel = CreateRibbonPropertyKey(403, VarEnum.VT_LPWSTR);

	public static PropertyKey StandardColorsCategoryLabel = CreateRibbonPropertyKey(404, VarEnum.VT_LPWSTR);

	public static PropertyKey RecentColorsCategoryLabel = CreateRibbonPropertyKey(405, VarEnum.VT_LPWSTR);

	public static PropertyKey AutomaticColorLabel = CreateRibbonPropertyKey(406, VarEnum.VT_LPWSTR);

	public static PropertyKey NoColorLabel = CreateRibbonPropertyKey(407, VarEnum.VT_LPWSTR);

	public static PropertyKey MoreColorsLabel = CreateRibbonPropertyKey(408, VarEnum.VT_LPWSTR);

	public static PropertyKey ThemeColors = CreateRibbonPropertyKey(409, (VarEnum)4115);

	public static PropertyKey StandardColors = CreateRibbonPropertyKey(400, (VarEnum)4115);

	public static PropertyKey ThemeColorsTooltips = CreateRibbonPropertyKey(411, (VarEnum)4127);

	public static PropertyKey StandardColorsTooltips = CreateRibbonPropertyKey(412, (VarEnum)4127);

	public static PropertyKey Viewable = CreateRibbonPropertyKey(1000, VarEnum.VT_BOOL);

	public static PropertyKey Minimized = CreateRibbonPropertyKey(1001, VarEnum.VT_BOOL);

	public static PropertyKey QuickAccessToolbarDock = CreateRibbonPropertyKey(1002, VarEnum.VT_UI4);

	public static PropertyKey ContextAvailable = CreateRibbonPropertyKey(1100, VarEnum.VT_UI4);

	public static PropertyKey GlobalBackgroundColor = CreateRibbonPropertyKey(2000, VarEnum.VT_UI4);

	public static PropertyKey GlobalHighlightColor = CreateRibbonPropertyKey(2001, VarEnum.VT_UI4);

	public static PropertyKey GlobalTextColor = CreateRibbonPropertyKey(2002, VarEnum.VT_UI4);

	public static PropertyKey CreateRibbonPropertyKey(int index, VarEnum id)
	{
		return new PropertyKey(new Guid(index, 29539, 26990, new byte[8] { 132, 65, 121, 138, 207, 90, 235, 183 }), (uint)id);
	}

	public static string GetPropertyKeyName(ref PropertyKey propertyKey)
	{
		FieldInfo[] fields = typeof(RibbonProperties).GetFields();
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			if (fieldInfo.FieldType == typeof(PropertyKey) && ((PropertyKey)fieldInfo.GetValue(null)).FormatId == propertyKey.FormatId)
			{
				return fieldInfo.Name;
			}
		}
		return string.Empty;
	}
}
