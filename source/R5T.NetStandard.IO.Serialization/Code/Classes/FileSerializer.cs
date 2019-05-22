using System;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// Static stream-serializer (<see cref="IStreamSerializer{T}"/>) instance based file serializer.
    /// </summary>
    public static class FileSerializer
    {
        public static T Deserialize<T>(string filePath, IStreamSerializer<T> streamSerializer)
        {
            using (var fileStream = FileStreamHelper.NewRead(filePath))
            {
                var value = streamSerializer.Deserialize(fileStream);
                return value;
            }
        }

        public static void Serialize<T>(string filePath, T value, IStreamSerializer<T> streamSerializer, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(filePath, overwrite))
            {
                streamSerializer.Serialize(fileStream, value);
            }
        }
    }


    /// <summary>
    /// Instantiable stream-serializer (<see cref="IStreamSerializer{T}"/>) based file serializer.
    /// </summary>
    public class FileSerializer<T> : IFileSerializer<T>
    {
        private IStreamSerializer<T> StreamSerializer { get; }


        public FileSerializer(IStreamSerializer<T> streamSerializer)
        {
            this.StreamSerializer = streamSerializer;
        }

        public T Deserialize(string filePath)
        {
            var value = FileSerializer.Deserialize(filePath, this.StreamSerializer);
            return value;
        }

        public void Serialize(string filePath, T obj, bool overwrite = true)
        {
            FileSerializer.Serialize(filePath, obj, this.StreamSerializer, overwrite);
        }
    }
}
