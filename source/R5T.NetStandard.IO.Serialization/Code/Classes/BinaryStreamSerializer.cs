using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace R5T.NetStandard.IO.Serialization
{
    public static class BinaryStreamSerializer
    {
        public static T Deserialize<T>(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var output = (T)formatter.Deserialize(stream);
            return output;
        }

        public static void Serialize<T>(Stream stream, T obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
        }
    }


    public class BinaryStreamSerializer<T> : IStreamSerializer<T>
    {
        public T Deserialize(Stream stream)
        {
            var value = BinaryStreamSerializer.Deserialize<T>(stream);
            return value;
        }

        public void Serialize(Stream stream, T value)
        {
            BinaryStreamSerializer.Serialize(stream, value);
        }
    }
}
