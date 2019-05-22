using System;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// De/serializes an object to a file.
    /// </summary>
    /// <remarks>
    /// The details of what file format (BinaryFormatter, custom binary format, XML, text, etc.) are left unspecified.
    ///
    /// Note to implementers:
    /// * Upon reading, you can assume the file exists, and it doesn't throw an exception.
    /// * Upon writing, note that the optional overwrite argument default value is true.
    /// </remarks>
    public interface IFileSerializer<T>
    {
        /// <summary>
        /// Deserializes an object from a file.
        /// </summary>
        /// <param name="filePath">The rooted file path to use.</param>
        T Deserialize(string filePath);

        /// <summary>
        /// Serializes an object to a file.
        /// </summary>
        /// <param name="filePath">The rooted file path to use.</param>
        void Serialize(string filePath, T obj, bool overwrite = true);
    }
}
