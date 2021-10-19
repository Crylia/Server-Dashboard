using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server_Dashboard_Socket.Protocol {

    /// <summary>
    /// Json serializer class
    /// </summary>
    public class JsonMessageProtocol : Protocol<JObject> {

        //The Json serializer and the settings
        private static readonly JsonSerializer serializer;

        /// <summary>
        /// Settings for the Json Serializer
        /// </summary>
        static JsonMessageProtocol() {
            //Set the settings
            JsonSerializerSettings settings = new JsonSerializerSettings {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new CamelCaseNamingStrategy {
                        ProcessDictionaryKeys = false
                    }
                }
            };
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            //Creates the serializer with the settings
            serializer = JsonSerializer.Create(settings);
        }

        //Decode the message, to Json
        protected override JObject Decode(byte[] message) => JObject.Parse(Encoding.UTF8.GetString(message));

        /// <summary>
        /// Encode the body from Json to bytes
        /// </summary>
        /// <typeparam name="T">The message type e.g. object or string</typeparam>
        /// <param name="message">The message to send</param>
        /// <returns>message as byte[]</returns>
        protected override byte[] EncodeBody<T>(T message) {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            serializer.Serialize(sw, message);
            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}