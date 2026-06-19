using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace RibbonLib.Interop;

public class StreamAdapter : IStream
{
	private Stream _stream;

	public StreamAdapter(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		_stream = stream;
	}

	public void Clone(out IStream streamCopy)
	{
		streamCopy = null;
		throw new NotSupportedException();
	}

	public void Commit(int flags)
	{
		throw new NotSupportedException();
	}

	public void CopyTo(IStream targetStream, long bufferSize, IntPtr buffer, IntPtr bytesWrittenPtr)
	{
		throw new NotSupportedException();
	}

	public void LockRegion(long offset, long byteCount, int lockType)
	{
		throw new NotSupportedException();
	}

	public void Read(byte[] buffer, int bufferSize, IntPtr bytesReadPtr)
	{
		int val = _stream.Read(buffer, 0, bufferSize);
		if (bytesReadPtr != IntPtr.Zero)
		{
			Marshal.WriteInt32(bytesReadPtr, val);
		}
	}

	public void Revert()
	{
		throw new NotSupportedException();
	}

	public void Seek(long offset, int origin, IntPtr newPositionPtr)
	{
		SeekOrigin origin2 = origin switch
		{
			0 => SeekOrigin.Begin, 
			1 => SeekOrigin.Current, 
			2 => SeekOrigin.End, 
			_ => throw new ArgumentOutOfRangeException("origin"), 
		};
		long val = _stream.Seek(offset, origin2);
		if (newPositionPtr != IntPtr.Zero)
		{
			Marshal.WriteInt64(newPositionPtr, val);
		}
	}

	public void SetSize(long libNewSize)
	{
		_stream.SetLength(libNewSize);
	}

	public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG streamStats, int grfStatFlag)
	{
		streamStats = default(System.Runtime.InteropServices.ComTypes.STATSTG);
		streamStats.type = 2;
		streamStats.cbSize = _stream.Length;
		streamStats.grfMode = 0;
		if (_stream.CanRead && _stream.CanWrite)
		{
			streamStats.grfMode |= 2;
		}
		else if (!_stream.CanRead)
		{
			if (!_stream.CanWrite)
			{
				throw new IOException("StreamObjectDisposed");
			}
			streamStats.grfMode |= 1;
		}
	}

	public void UnlockRegion(long offset, long byteCount, int lockType)
	{
		throw new NotSupportedException();
	}

	public void Write(byte[] buffer, int bufferSize, IntPtr bytesWrittenPtr)
	{
		_stream.Write(buffer, 0, bufferSize);
		if (bytesWrittenPtr != IntPtr.Zero)
		{
			Marshal.WriteInt32(bytesWrittenPtr, bufferSize);
		}
	}
}
