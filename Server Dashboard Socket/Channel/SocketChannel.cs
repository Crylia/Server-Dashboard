using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_Dashboard_Socket {

    /// <summary>
    /// Generic Channel class that handles the connection and message sending / receiving
    /// Inherits IDisposable to correctly cut the connection to the server
    /// </summary>
    /// <typeparam name="TProtocol">The Protocol type, either JsonMessageProtocol or XmlMessageProtocol</typeparam>
    /// <typeparam name="TMessageType">The message type, either JObject or XDocument</typeparam>
    public abstract class SocketChannel<TProtocol, TMessageType> : IDisposable
        where TProtocol : Protocol<TMessageType>, new() {
        protected bool isDisposable = false;
        private NetworkStream networkStream;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly TProtocol protocol = new TProtocol();

        private Func<TMessageType, Task> messageCallback;

        /// <summary>
        /// Attaches the socket to a network stream that owns the socket
        /// if the network stream goes down it takes the socket with it!
        /// </summary>
        /// <param name="socket">A Socket</param>
        public void Attach(Socket socket) {
            networkStream = new NetworkStream(socket, true);
            _ = Task.Run(ReceiveLoop, cancellationTokenSource.Token);
        }

        /// <summary>
        /// Takes a function with a message and sets the private member to the functions value
        /// </summary>
        /// <param name="callbackHandler"></param>
        public void OnMessage(Func<TMessageType, Task> callbackHandler) => messageCallback = callbackHandler;

        /// <summary>
        /// Makes sure to close the socket
        /// </summary>
        public void Close() {
            cancellationTokenSource.Cancel();
            networkStream?.Close();
        }

        /// <summary>
        /// Sends the message async
        /// </summary>
        /// <typeparam name="T">Anything as message, e.g. object or string</typeparam>
        /// <param name="message">The message</param>
        /// <returns></returns>
        public async Task SendAsync<T>(T message) => await protocol.SendAsync(networkStream, message).ConfigureAwait(false);

        /// <summary>
        /// Checks for received messages
        /// </summary>
        /// <returns>received message</returns>
        protected virtual async Task ReceiveLoop() {
            while (!cancellationTokenSource.Token.IsCancellationRequested) {
                var msg = await protocol.ReceiveAsync(networkStream).ConfigureAwait(false);
                await messageCallback(msg).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Deconstructor sets Dispose to false
        /// </summary>
        ~SocketChannel() => Dispose(false);

        /// <summary>
        /// Sets dispose to true
        /// </summary>
        public void Dispose() => Dispose(true);

        /// <summary>
        /// Disposes open sockets
        /// </summary>
        /// <param name="isDisposing">Is it currently disposing stuff?</param>
        protected void Dispose(bool isDisposing) {
            //If its not disposable
            if (!isDisposable) {
                //Set disposable to true
                isDisposable = true;
                //Close the socket
                Close();
                //If its closed, dispose it
                networkStream?.Dispose();
                //Wait with the garbage collection until the disposing is done
                if (isDisposing)
                    GC.SuppressFinalize(this);
            }
        }
    }
}