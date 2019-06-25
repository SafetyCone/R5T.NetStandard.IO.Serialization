using System;
using System.IO;


namespace R5T.NetStandard.IO.Serialization
{
    public static class StreamSerializer
    {
        public static T Deserialize<T>(Stream stream, ITextSerializer<T> textSerializer)
        {
            using (var textReader = StreamReaderHelper.NewLeaveOpen(stream))
            {
                var value = textSerializer.Deserialize(textReader);
                return value;
            }
        }

        public static void Serialize<T>(Stream stream, T value, ITextSerializer<T> textSerializer)
        {
            using (var textWriter = StreamWriterHelper.NewLeaveOpen(stream))
            {
                textSerializer.Serialize(textWriter, value);
            }
        }
    }
}
