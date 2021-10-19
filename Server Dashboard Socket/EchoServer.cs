using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server_Dashboard_Socket {

    /// <summary>
    /// Basic echo server to test the socket connection
    /// </summary>
    public class EchoServer {

        /// <summary>
        /// Start the socket on 127.0.0.1:9000
        /// </summary>
        /// <param name="port">A port that is not already in use</param>
        public void Start(int port = 9000) {
            //Creates a new endpoint on 127.0.0.1 and the port 9000
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);
            //Creates a new Socket on the given endpoint
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //Bind the endpoint to the socket
            socket.Bind(endPoint);
            //Define how many Clients you want to have connected max
            socket.Listen(128);
            //Just run the Task forever
            _ = Task.Run(() => DoEcho(socket));
        }

        /// <summary>
        /// Listens for messages and sends them back asap
        /// </summary>
        /// <param name="socket">The socket to work with</param>
        /// <returns>poop</returns>
        private async Task DoEcho(Socket socket) {
            while (true) {
                //Listen for incoming connection requests and accept them
                Socket clientSocket = await Task.Factory.FromAsync(
                    new Func<AsyncCallback, object, IAsyncResult>(socket.BeginAccept),
                    new Func<IAsyncResult, Socket>(socket.EndAccept),
                    null).ConfigureAwait(false);
                //Create a network stream and make it the owner of the socket
                //This will close the socket if the stream is closed and vice verca
                await using NetworkStream stream = new NetworkStream(clientSocket, true);
                //New buffer for the message in bytes
                byte[] buffer = new byte[1024];
                while (true) {
                    //Read everything that comes in
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    //If its 0 just leave since its a obsolete connection
                    if (bytesRead == 0)
                        break;
                    //Send it back to the sender
                    await stream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
                }
            }
        }
    }
}