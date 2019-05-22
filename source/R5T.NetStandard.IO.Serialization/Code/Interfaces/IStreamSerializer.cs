using System;
using System.IO;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// Allows the behavior of stream de/serializing generic types to be encapsulated in an object instance.
    /// The details of what format (binary, XML, JSON, text, etc.) <typeparamref name="T"/> instances are serialized in is left unspecified.
    /// </summary>
    /// <remarks>
    /// Note to implementers: The input streams should be left open!
    /// </remarks>
    /// <typeparam name="T">The type to be de/serialized.</typeparam>
    public interface IStreamSerializer<T>
    {
        /// <summary>
        /// Deserializes a <typeparamref name="T"/> instance from a stream.
        /// </summary>
        T Deserialize(Stream stream);

        /// <summary>
        /// Serializes a <typeparamref name="T"/> instance to a stream.
        /// </summary>
        void Serialize(Stream stream, T value);
    }
}
