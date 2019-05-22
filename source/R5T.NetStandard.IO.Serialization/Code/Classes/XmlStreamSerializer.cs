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
