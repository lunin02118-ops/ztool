using System.Diagnostics;

namespace ZTool.JDK;

internal class JDKEY_DEFINE
{
	public const uint DONGLE_SUCCESS = 0u;

	public const uint DONGLE_NOT_FOUND = 2147483649u;

	public const uint DONGLE_NOT_OPEN = 2147483650u;

	public const uint DONGLE_INVALID_PARAMETER = 2147483651u;

	public const uint DONGLE_FAILED = 2147483652u;

	public const uint DONGLE_NOT_SUPPORT = 2147483653u;

	public const uint DONGLE_RUN_APP_ERROR = 2147483654u;

	public const uint DONGLE_SESSIONKEY_FAILED = 2147483655u;

	public const uint DONGLE_SESSIONKEY_NOT_GEN = 2147483656u;

	public const uint DONGLE_SESSIONKEY_FULL = 2147483657u;

	public const uint DONGLE_ADMINPIN_NOT_CHECK = 2147483658u;

	public const uint DONGLE_USERPIN_NOT_CHECK = 2147483659u;

	public const uint DONGLE_PIN_BLOCKED = 2147483660u;

	public const uint DONGLE_INCORRECT_PIN = 2147483661u;

	public const uint DONGLE_FILE_EXIST = 2147483662u;

	public const uint DONGLE_FILE_NOT_FOUND = 2147483663u;

	public const uint DONGLE_FILE_READ_ERROR = 2147483664u;

	public const uint DONGLE_FILE_WRITE_ERROR = 2147483665u;

	public const uint DONGLE_COMM_ERROR = 2147483666u;

	public const uint DONGLE_ERROR_UNKNOWN = uint.MaxValue;

	[DebuggerNonUserCode]
	public JDKEY_DEFINE()
	{
	}
}
