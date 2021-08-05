using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SocketServer {
    public class EchoServer {
        public void Start(int port = 9656) {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, SecurityProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(128);
            _ = Task.Run(() => DoEcho(socket));
        }
        private async Task DoEcho(Socket socket) {
            while (true) {
                Socket clientSocket = await Task.Factory.FromAsync(
                    new Func<AsyncCallback, object, IAsyncResult>(socket.BeginAccept), 
                    new Func<IAsyncResult, Socket>(socket.EndAccept), 
                    null).ConfigureAwait(false);
                using (NetworkStream nStream = new NetworkStream(clientSocket, true)) {
                    byte[] buffer = new byte[1024];
                    while (true) {
                        int bytesRead = await nStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                        if (bytesRead == 0)
                            break;
                        await nStream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
                    }
                }
            }
        }
    }
}
