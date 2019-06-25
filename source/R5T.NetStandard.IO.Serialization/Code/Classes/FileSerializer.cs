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

        public static T Deserialize<T>(string filePath, ITextSerializer<T> textSerializer)
        {
            var streamSerializer = new TextStreamSerializer<T>(textSerializer);

            var value = FileSerializer.Deserialize<T>(filePath, streamSerializer);
            return value;
        }

        public static void Serialize<T>(string filePath, T value, ITextSerializer<T> textSerializer, bool overwrite = true)
        {
            var streamSerializer = new TextStreamSerializer<T>(textSerializer);

            FileSerializer.Serialize(filePath, value, streamSerializer, overwrite);
        }
    }
}
