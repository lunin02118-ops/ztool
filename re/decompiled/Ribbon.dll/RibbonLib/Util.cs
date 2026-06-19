using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Xml.Serialization;

namespace RibbonLib;

internal static class Util
{
	private static bool _designMode;

	public static bool DesignMode => _designMode;

	static Util()
	{
		List<string> list = new List<string> { "devenv", "vcsexpress", "vbexpress", "vcexpress", "sharpdevelop" };
		string item = Process.GetCurrentProcess().ProcessName.ToLower();
		_designMode = list.Contains(item);
	}

	public static byte[] GetEmbeddedResource(string resourceName, Assembly assembly)
	{
		new ResourceManager(resourceName, assembly);
		using Stream stream = assembly.GetManifestResourceStream(resourceName);
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		return array;
	}

	public static T DeserializeEmbeddedResource<T>(string resourceName, Assembly assembly)
	{
		new ResourceManager(resourceName, assembly);
		using Stream stream = assembly.GetManifestResourceStream(resourceName);
		if (stream == null)
		{
			throw new ArgumentException($"resourceName is unknown '{resourceName}'");
		}
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		return (T)xmlSerializer.Deserialize(stream);
	}
}
