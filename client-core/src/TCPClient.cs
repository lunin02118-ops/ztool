using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool_rsa;

namespace ZTool;

public class TCPClient
{
	private enum Sendresult
	{
		无效注册码 = 1,
		注册码已被其它电脑使用,
		注册码已过期,
		注册失败,
		注册成功,
		注册信息错误,
		转出授权成功,
		转出授权失败,
		无需转出,
		此电脑没有转出权限,
		允许转出授权,
		注册确认,
		注册登记,
		此注册码没有转出权限,
		超时,
		注册申请失败,
		授权电脑数量已达上限,
		密码错误
	}

	public enum Sendtype
	{
		Apply_register = 128,
		Apply_Remove,
		register,
		verify_register,
		verify_Remove
	}

	private Thread th;

	private Socket socket;

	protected const string ip_address = "9980E50294D2322B02B2F7F187A6630409A7790DDCDB4EEA3CBC4A729C4407BC4D4F8418CF0E33E0C9C3B3A517FE91F6EDAB5067771AAD468D66F05BE7C990443160C467949DC510F91046FC10A7A556798AF6AFEAEA89A7A4BD41809E72F916FC92148CD6A188E7FC45F080955FA517C212E007BD5BD19A85F6E9D3067CD3F7";

	protected const string ip_port = "33F44F7205623349AE9068662220849D10BD6101F4DA33223ABA5214BDD5ED3B9269F0A1951AEB6561F5D2639DC1D367C712DED142F80D24C6F5B4714416BC2CC2ED1F1E65BD7002A974FC5F30AA450BD0041C1858DF0EB443951156A9EDBD2F52DD6B326E008E94C062FE6277EB1D978D77D6052138AE0501458D9488E60BEE";

	private const int H_length = 10;

	private const int L_length = 10;

	private const int MAX_RESPONSE_BODY = 10485760;

	private const int RESPONSE_READ_TIMEOUT_MS = 20000;

	internal bool isok;

	private readonly ManualResetEvent TimeoutObject;

	public TCPClient()
	{
		isok = true;
		TimeoutObject = new ManualResetEvent(initialState: false);
	}

	public void sendstring(Sendtype rgtype, string sendstring)
	{
		if (socket.Connected)
		{
			SecurityCenter securityCenter = new SecurityCenter();
			sendstring = securityCenter.EncriptStr(sendstring, Conversions.ToString((int)rgtype));
			socket.Send(getsendbuffer((int)rgtype, sendstring));
		}
	}

	public void CloseClientSocket()
	{
		if (Information.IsNothing(socket) || !socket.Connected)
		{
			return;
		}
		try
		{
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
			th.Abort();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public bool Connect()
	{
		bool flag = false;
		isok = true;
		IPAddress address = IPAddress.Parse(RSAHelper.DecryptString("9980E50294D2322B02B2F7F187A6630409A7790DDCDB4EEA3CBC4A729C4407BC4D4F8418CF0E33E0C9C3B3A517FE91F6EDAB5067771AAD468D66F05BE7C990443160C467949DC510F91046FC10A7A556798AF6AFEAEA89A7A4BD41809E72F916FC92148CD6A188E7FC45F080955FA517C212E007BD5BD19A85F6E9D3067CD3F7", "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
		int port = Convert.ToInt32(RSAHelper.DecryptString("33F44F7205623349AE9068662220849D10BD6101F4DA33223ABA5214BDD5ED3B9269F0A1951AEB6561F5D2639DC1D367C712DED142F80D24C6F5B4714416BC2CC2ED1F1E65BD7002A974FC5F30AA450BD0041C1858DF0EB443951156A9EDBD2F52DD6B326E008E94C062FE6277EB1D978D77D6052138AE0501458D9488E60BEE", "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
		TimeoutObject.Reset();
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		try
		{
			socket.BeginConnect(address, port, CallBackMethod, socket);
			if (TimeoutObject.WaitOne(20000, exitContext: false))
			{
				if (socket.Connected)
				{
					flag = true;
					th = new Thread(SocketRecive);
					th.IsBackground = true;
					th.Start(socket);
				}
				else
				{
					flag = false;
					MessageBox.Show("Ошибка сети", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				socket.Close();
				flag = false;
				MessageBox.Show("Тайм-аут подключения к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			flag = false;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show("Ошибка подключения к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		isok = flag;
		return flag;
	}

	private void CallBackMethod(IAsyncResult asyncresult)
	{
		TimeoutObject.Set();
	}

	private void SocketRecive(object o)
	{
		try
		{
			Socket socket = o as Socket;
			while (socket.Connected)
			{
				string m_head = "";
				string receive = getreceive(socket, ref m_head);
				string left = m_head;
				if (Operators.CompareString(left, Conversions.ToString(1), TextCompare: false) == 0)
				{
					MessageBox.Show("Недопустимый регистрационный код", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(4), TextCompare: false) == 0)
				{
					MessageBox.Show("Регистрация не удалась", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(2), TextCompare: false) == 0)
				{
					MessageBox.Show("Регистрационный код уже используется на другом компьютере", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(3), TextCompare: false) == 0)
				{
					MessageBox.Show("Срок действия регистрационного кода истёк", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(6), TextCompare: false) == 0)
				{
					MessageBox.Show("Ошибка в сведениях о регистрации", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(16), TextCompare: false) == 0)
				{
					MessageBox.Show("Заявка на регистрацию не удалась", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(17), TextCompare: false) == 0)
				{
					MessageBox.Show("Достигнут предел числа лицензированных компьютеров", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(18), TextCompare: false) == 0)
				{
					MessageBox.Show("Неверный пароль", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				SR sR;
				if (Operators.CompareString(left, Conversions.ToString(13), TextCompare: false) == 0)
				{
					SecurityCenter securityCenter = new SecurityCenter();
					sR = new SR();
					if (sR.rg(receive))
					{
						string text = "";
						string use_date = "";
						if (sR.IsReg1("来生缘。。。", ref text, ref use_date))
						{
							goto IL_0240;
						}
					}
					if (0 == 0)
					{
						MessageBox.Show("Ошибка сохранения сведений о регистрации", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					}
					goto IL_0240;
				}
				if (Operators.CompareString(left, Conversions.ToString(12), TextCompare: false) == 0)
				{
					SR sR2 = new SR();
					sR2.rg(receive);
					string use_date = "";
					string text = "";
					if (sR2.IsReg2("来生缘。。。", ref use_date, ref text))
					{
						MessageBox.Show("Регистрация выполнена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Регистрация не удалась", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(11), TextCompare: false) == 0)
				{
					SR sR3 = new SR();
					if (sR3.outrg(receive))
					{
						sendstring(Sendtype.verify_Remove, sR3.get_rginfo());
						continue;
					}
					MessageBox.Show("Не удалось перенести лицензию", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				if (Operators.CompareString(left, Conversions.ToString(7), TextCompare: false) == 0)
				{
					MessageBox.Show("Лицензия успешно перенесена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (Operators.CompareString(left, Conversions.ToString(8), TextCompare: false) == 0)
				{
					MessageBox.Show("Не удалось перенести лицензию", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (Operators.CompareString(left, Conversions.ToString(9), TextCompare: false) == 0)
				{
					MessageBox.Show("Перенос не требуется", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (Operators.CompareString(left, Conversions.ToString(10), TextCompare: false) == 0)
				{
					MessageBox.Show("У этого компьютера нет прав на перенос", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (Operators.CompareString(left, Conversions.ToString(14), TextCompare: false) == 0)
				{
					MessageBox.Show("У этого кода нет прав на перенос", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				break;
				IL_0240:
				sendstring(Sendtype.verify_register, sR.get_rginfo());
			}
			isok = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			isok = false;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show("Ошибка связи с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public string getreceive(Socket s, ref string m_head)
	{
		s.ReceiveBufferSize = 1024;
		byte[] array = ReadExact(s, H_length, RESPONSE_READ_TIMEOUT_MS);
		m_head = Conversions.ToString(code.byte_to_Int(array));
		byte[] array2 = ReadExact(s, L_length, RESPONSE_READ_TIMEOUT_MS);
		int num2 = code.byte_to_Int(array2);
		if (num2 < 0 || num2 > MAX_RESPONSE_BODY)
		{
			throw new InvalidOperationException("Некорректный размер ответа сервера");
		}
		byte[] array3 = ReadExact(s, num2, RESPONSE_READ_TIMEOUT_MS);
		return Encoding.UTF8.GetString(array3, 0, array3.Length).Trim();
	}

	private static byte[] ReadExact(Socket s, int len, int timeoutMs)
	{
		if (len < 0)
		{
			throw new InvalidOperationException("Некорректный размер ответа сервера");
		}
		byte[] array = new byte[len];
		int offset = 0;
		int receiveTimeout = s.ReceiveTimeout;
		try
		{
			s.ReceiveTimeout = timeoutMs;
			while (offset < len)
			{
				int num = s.Receive(array, offset, len - offset, SocketFlags.None);
				if (num == 0)
				{
					throw new InvalidOperationException("Соединение с сервером закрыто");
				}
				offset = checked(offset + num);
			}
		}
		catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
		{
			throw new TimeoutException("Тайм-аут чтения ответа сервера", ex);
		}
		finally
		{
			s.ReceiveTimeout = receiveTimeout;
		}
		return array;
	}

	public byte[] getsendbuffer(int rgtype, string sendstring)
	{
		byte[] array = code.int_to_Byte(rgtype, 10);
		byte[] bytes = Encoding.UTF8.GetBytes(sendstring.Trim());
		byte[] array2 = code.int_to_Byte(bytes.Length, 10);
		checked
		{
			byte[] array3 = new byte[bytes.Length + array2.Length + array.Length - 1 + 1];
			array.CopyTo(array3, 0);
			array2.CopyTo(array3, array.Length);
			bytes.CopyTo(array3, array.Length + array2.Length);
			return array3;
		}
	}
}
