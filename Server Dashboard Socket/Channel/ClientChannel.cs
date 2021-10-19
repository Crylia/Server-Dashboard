using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Dashboard_Socket {

    /// <summary>
    /// Client Socket
    /// </summary>
    /// <typeparam name="TProtocol">The Protocol type, either JsonMessageProtocol or XmlMessageProtocol</typeparam>
    /// <typeparam name="TMessageType">The message type, either JObject or XDocument</typeparam>
    public class ClientChannel<TProtocol, TMessageType> : SocketChannel<TProtocol, TMessageType>
        where TProtocol : Protocol<TMessageType>, new() {

        /// <summary>
        /// Connect to the socket async
        /// </summary>
        /// <param name="endpoint">An endpoint with an IP address and port</param>
        /// <returns></returns>
        public async Task ConnectAsync(IPEndPoint endpoint) {
            //Creates a new Socket
            var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //Connects to the socket
            await socket.ConnectAsync(endpoint).ConfigureAwait(false);
            //Attach the socket to a network stream
            Attach(socket);
        }
    }
}