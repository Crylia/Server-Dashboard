using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Dashboard_Socket {
    /// <summary>
    /// Generic Protocol class for Json and Xml serialization
    /// </summary>
    /// <typeparam name="TMessageType">JsonMessageProtocol or XmlMessageProtocol</typeparam>
    public abstract class Protocol<TMessageType> {
        //Header size is always 4
        const int HEADER_SIZE = 4;

        /// <summary>
        /// Gets the message and checks with the header if the message is valid or not
        /// important to defend against attacks with infinite long messages
        /// </summary>
        /// <param name="networkStream">A network stream</param>
        /// <returns>MessageType e.g. Json or Xml</returns>
        public async Task<TMessageType> ReceiveAsync(NetworkStream networkStream) {
            //Gets the body length
            int bodyLength = await ReadHeader(networkStream).ConfigureAwait(false);
            //Validates the length
            AssertValidMessageLength(bodyLength);
            //Returns the body message type
            return await Readbody(networkStream, bodyLength).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends data Async
        /// </summary>
        /// <typeparam name="T">Message type e.g. object or string</typeparam>
        /// <param name="networkStream">Network stream</param>
        /// <param name="message">The message</param>
        /// <returns></returns>
        public async Task SendAsync<T>(NetworkStream networkStream, T message) {
            //encodes the message to a header and body
            var (header, body) = Encode(message);
            //Sends the header
            await networkStream.WriteAsync(header, 0, header.Length).ConfigureAwait(false);
            //Sends the body
            await networkStream.WriteAsync(body, 0, body.Length).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads the header and converts it to an integer
        /// </summary>
        /// <param name="networkStream">A network stream</param>
        /// <returns>Header as Integer</returns>
        async Task<int> ReadHeader(NetworkStream networkStream) {
            byte[] headerBytes = await ReadAsync(networkStream, HEADER_SIZE).ConfigureAwait(false);
            return IPAddress.HostToNetworkOrder(BitConverter.ToInt32(headerBytes));
        }

        /// <summary>
        /// Reads the body and decodes it to a human readable string
        /// </summary>
        /// <param name="networkStream">A network stream</param>
        /// <param name="bodyLength">Length of the body</param>
        /// <returns>Decoded body</returns>
        async Task<TMessageType> Readbody(NetworkStream networkStream, int bodyLength) {
            //Reads the bytes from the stream into an array
            byte[] bodyBytes = await ReadAsync(networkStream, bodyLength).ConfigureAwait(false);
            //Decodes it and returns the string
            return Decode(bodyBytes);
        }

        /// <summary>
        /// Reads the network stream as long as something is readable
        /// </summary>
        /// <param name="networkStream">A network stream</param>
        /// <param name="bytesToRead">how many bytes there are to read</param>
        /// <returns>Every byte from the Stream</returns>
        async Task<byte[]> ReadAsync(NetworkStream networkStream, int bytesToRead) {
            //new buffer that is as big as the content(watch out for buffer overflows)
            byte[] buffer = new byte[bytesToRead];
            //keep acount of the bytes that are already read
            int bytesRead = 0;
            //White we still have something to read
            while(bytesRead < bytesToRead){
                //Read it from the stream
                var bytesReceived = await networkStream.ReadAsync(buffer, bytesRead, (bytesToRead - bytesRead)).ConfigureAwait(false);
                //If it happens to be 0 close the socket
                if (bytesReceived == 0)
                    throw new Exception("Socket Closed");
                bytesRead += bytesReceived;
            }
            return buffer;
        }

        /// <summary>
        /// Encode the message from human readable to bytes for the stream
        /// </summary>
        /// <typeparam name="T">The message as anything e.g. object or strng</typeparam>
        /// <param name="message">The message to be send</param>
        /// <returns>The Header and Body as bytes[]</returns>
        protected (byte[] header, byte[] body) Encode<T>(T message) {
            //Creates the body bytes
            var bodyBytes = EncodeBody(message);
            //Creates the header bytes
            var headerBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(bodyBytes.Length));
            return (headerBytes, bodyBytes);
        }

        /// <summary>
        /// Decode the message with the given type, json or xml
        /// </summary>
        /// <param name="message">The message to decode</param>
        /// <returns>Decoded message</returns>
        protected abstract TMessageType Decode(byte[] message);

        /// <summary>
        /// Validate the message length to combat attacks
        /// </summary>
        /// <param name="messageLength">The message length</param>
        protected virtual void AssertValidMessageLength(int messageLength) {
            //If its not 0 throw an exception
            if (messageLength < 1)
                throw new ArgumentOutOfRangeException("Invalid message length");
        }
        /// <summary>
        /// Encode the message so it can be send via the network stream
        /// </summary>
        /// <typeparam name="T">Message type e.g. object or string</typeparam>
        /// <param name="message">The message to be send</param>
        /// <returns></returns>
        protected abstract byte[] EncodeBody<T> (T message);
    }
}
