using System;
using System.IO;


namespace R5T.NetStandard.IO.Serialization
{
    public interface ITextSerializer<T>
    {
        T Deserialize(TextReader reader);

        void Serialize(TextWriter writer, T value);
    }
}
