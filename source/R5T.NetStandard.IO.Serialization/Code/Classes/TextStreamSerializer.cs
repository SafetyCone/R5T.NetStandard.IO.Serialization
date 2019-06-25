using System;
using System.IO;


namespace R5T.NetStandard.IO.Serialization
{
    public class TextStreamSerializer<T> : IStreamSerializer<T>
    {
        private ITextSerializer<T> TextSerializer { get; }


        public TextStreamSerializer(ITextSerializer<T> textSerializer)
        {
            this.TextSerializer = textSerializer;
        }

        public T Deserialize(Stream stream)
        {
            var value = StreamSerializer.Deserialize(stream, this.TextSerializer);
            return value;
        }

        public void Serialize(Stream stream, T value)
        {
            StreamSerializer.Serialize(stream, value, this.TextSerializer);
        }
    }
}
