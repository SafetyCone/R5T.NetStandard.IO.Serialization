using System;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// Instantiable stream-serializer (<see cref="IStreamSerializer{T}"/>) based file serializer.
    /// </summary>
    public class StreamFileSerializer<T> : IFileSerializer<T>
    {
        private IStreamSerializer<T> StreamSerializer { get; }


        public StreamFileSerializer(IStreamSerializer<T> streamSerializer)
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
