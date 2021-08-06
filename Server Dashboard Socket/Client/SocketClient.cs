using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Server_Dashboard_Socket.Protocol;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Server_Dashboard_Socket {
    public class SocketClient {

        public SocketClient() {
            //Starts the echo server for testing purposes
            EchoServer echoServer = new EchoServer();
            echoServer.Start();
            //Start the Socket test
            Start();
        }

        private async void Start() {
            //Creates a new endpoint with the IP adress and port
            var endpoint = new IPEndPoint(IPAddress.Loopback, 9000);

            //Creates a new Channel for the Json protocol
            var channel = new ClientChannel<JsonMessageProtocol, JObject>();
            //Creates a new Channel for the XDocument protocol
            //var channel = new ClientChannel<XmlMessageProtocol, XDocument>();

            //Callback for the message
            channel.OnMessage(OnMessage);

            //Connect to the Socket
            await channel.ConnectAsync(endpoint).ConfigureAwait(false);

            //Test message
            var myMessage = new MyMessage {
                IntProperty = 404,
                StringProperty = "Hello World!"
            };
            //Send the test message
            await channel.SendAsync(myMessage).ConfigureAwait(false);
        }

        /// <summary>
        /// When it receives a message it gets converted from Json back to MyMessage
        /// </summary>
        /// <param name="jobject">The json to be converted back</param>
        /// <returns>Task completed</returns>
        static Task OnMessage(JObject jobject) {
            Console.WriteLine(Convert(jobject));
            return Task.CompletedTask;
        }
        /// <summary>
        /// When it receives a message it gets converted from XDocument back to MyMessage
        /// </summary>
        /// <param name="xDocument">The xml to be converted back</param>
        /// <returns>Task completed</returns>
        static Task OnMessage(XDocument xDocument) {
            Console.WriteLine(Convert(xDocument));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Converts json to MyMessage
        /// </summary>
        /// <param name="jObject">The json to be converted</param>
        /// <returns>MyMessage object</returns>
        static MyMessage Convert(JObject jObject) => jObject.ToObject(typeof(MyMessage)) as MyMessage;

        /// <summary>
        /// Converts XDocument to MyMessage
        /// </summary>
        /// <param name="xmlDocument">The xml to be converted</param>
        /// <returns>MyMessage object</returns>
        static MyMessage Convert(XDocument xmlDocument) => new XmlSerializer(typeof(MyMessage)).Deserialize(new StringReader(xmlDocument.ToString())) as MyMessage;
    }

    /// <summary>
    /// MyMessage test class
    /// Delete later when Sockets are finished
    /// </summary>
    public class MyMessage {
        public int IntProperty { get; set; }
        public string StringProperty { get; set; }
    }
}
