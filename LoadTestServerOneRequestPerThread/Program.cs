using System.Net;
using System.Net.Sockets;
var listenSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
listenSocket.Bind(new IPEndPoint(IPAddress.Any, 7777));
listenSocket.Listen(50);

while (true)
{
	var connection = listenSocket.Accept();
	var thread = new Thread(() =>
	{
		using var file = new FileStream(@"somefile.bin",
		   FileMode.Open, FileAccess.Read);
		var buffer = new byte[1024 * 1024];
		while (true)
		{
			int read = file.Read(buffer, 0, buffer.Length);
			if ((read) != 0)
			{
				connection.Send(
				  new ArraySegment<byte>(buffer, 0, read),
				  SocketFlags.None);
			}
			else
			{
				connection.Shutdown(SocketShutdown.Both);
				connection.Dispose();
				return;
			}
		}
	});
	thread.Start();
}