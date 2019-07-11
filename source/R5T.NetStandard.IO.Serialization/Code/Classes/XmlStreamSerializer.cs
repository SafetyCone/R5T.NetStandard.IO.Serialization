using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace R5T.NetStandard.IO.Serialization
{
    public static class XmlStreamSerializer
    {
        public static T Deserialize<T>(Stream stream)
        {
            using (var reader = StreamReaderHelper.NewLeaveOpen(stream))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var output = (T)xmlSerializer.Deserialize(reader);
                return output;
            }
        }

        /// <summary>
        /// Deserialize XML with unqualified elements (elements not specifying their namespace) to an XML serialization object type that specifies a namespace for its XmlTypeAttribute.
        /// </summary>
        /// <remarks>
        /// Magic incantations adapted from here: https://stackoverflow.com/a/29776266
        /// </remarks>
        public static T Deserialize<T>(Stream stream, string defaultXmlNamespace)
        {
            var nameTable = new NameTable();

            var xmlNamespaceManager = new XmlNamespaceManager(nameTable);
            xmlNamespaceManager.AddNamespace(String.Empty, defaultXmlNamespace);

            var xmlParserContext = new XmlParserContext(nameTable, xmlNamespaceManager, null, XmlSpace.Default);

            var xmlReaderSettings = new XmlReaderSettings
            {
                ConformanceLevel = ConformanceLevel.Auto,
            };

            using (var reader = StreamReaderHelper.NewLeaveOpen(stream))
            using (var xmlReader = XmlReader.Create(reader, xmlReaderSettings, xmlParserContext))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var output = (T)xmlSerializer.Deserialize(xmlReader);
                return output;
            }
        }

        public static void Serialize<T>(Stream stream, T obj, XmlWriterSettings xmlWriterSettings, XmlSerializer xmlSerializer)
        {
            using (var xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, obj);
            }
        }

        public static void Serialize<T>(Stream stream, T obj, XmlWriterSettings xmlWriterSettings)
        {
            using (var xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                xmlSerializer.Serialize(xmlWriter, obj);
            }
        }

        public static void Serialize<T>(Stream stream, T obj)
        {
            using (var writer = StreamWriterHelper.NewLeaveOpen(stream))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                xmlSerializer.Serialize(writer, obj);
            }
        }
    }


    public class XmlStreamSerializer<T> : IStreamSerializer<T>
    {
        public T Deserialize(Stream stream)
        {
            var value = XmlStreamSerializer.Deserialize<T>(stream);
            return value;
        }

        public void Serialize(Stream stream, T value)
        {
            XmlStreamSerializer.Serialize(stream, value);
        }
    }
}
