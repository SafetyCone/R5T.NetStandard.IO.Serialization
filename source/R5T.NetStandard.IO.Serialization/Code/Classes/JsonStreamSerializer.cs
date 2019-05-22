using System;
using System.IO;

using Newtonsoft.Json;


namespace R5T.NetStandard.IO.Serialization
{
    public static class JsonStreamSerializer
    {
        public static T Deserialize<T>(Stream stream)
        {
            using (var textReader = StreamReaderHelper.NewLeaveOpen(stream))
            using (var jsonReader = new JsonTextReader(textReader))
            {
                var jsonSerializer = new JsonSerializer();

                var output = jsonSerializer.Deserialize<T>(jsonReader);
                return output;
            }
        }

        public static void Serialize<T>(Stream stream, T obj)
        {
            using (var writer = StreamWriterHelper.NewLeaveOpen(stream))
            {
                var serializer = new JsonSerializer();

                serializer.Serialize(writer, obj);
            }
        }
    }

    public class JsonStreamSerializer<T> : IStreamSerializer<T>
    {
        public T Deserialize(Stream stream)
        {
            var value = JsonStreamSerializer.Deserialize<T>(stream);
            return value;
        }

        public void Serialize(Stream stream, T value)
        {
            JsonStreamSerializer.Serialize(stream, value);
        }
    }
}
