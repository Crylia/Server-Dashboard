using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Server_Dashboard_Socket {
    /// <summary>
    /// Xml serialize class
    /// </summary>
    public class XmlMessageProtocol : Protocol<XDocument> {
        /// <summary>
        /// Decodes the message from byte[] to XDocument
        /// </summary>
        /// <param name="message">The message to decode</param>
        /// <returns>Message as XDocument</returns>
        protected override XDocument Decode(byte[] message) {
            //Reads the data as utf8 string
            var xmlData = Encoding.UTF8.GetString(message);
            //Creates a new reader
            var xmlReader = XmlReader.Create(new StringReader(xmlData), new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore });
            //Decodes the data to XDocument format
            return XDocument.Load(xmlReader);
        }

        /// <summary>
        /// Encode the XDocument to byte[]
        /// </summary>
        /// <typeparam name="T">Message type e.g. object or string</typeparam>
        /// <param name="message">The message to encode</param>
        /// <returns>Message as byte[]</returns>
        protected override byte[] EncodeBody<T>(T message) {
            //new string builder
            StringBuilder sb = new StringBuilder();
            //New string writer with the string builder
            StringWriter sw = new StringWriter(sb);
            //new xml serializer with the same type as the message
            XmlSerializer xs = new XmlSerializer(typeof(T));
            //Serialize the message to a regular string
            xs.Serialize(sw, message);
            //Return as UTF8 encoded byte array
            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
