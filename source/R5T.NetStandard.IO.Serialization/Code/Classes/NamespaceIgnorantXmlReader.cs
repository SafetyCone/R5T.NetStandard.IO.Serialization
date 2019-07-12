using System;
using System.Xml;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// Reads XML ignorant of all namespaces.
    /// </summary>
    /// <remarks>
    /// Adapted from: https://stackoverflow.com/a/873281
    /// </remarks>
    public class NamespaceIgnorantXmlReader : XmlReaderWrapper
    {
        public NamespaceIgnorantXmlReader(XmlReader xmlReader)
            : base(xmlReader)
        {
        }

        public override string NamespaceURI => String.Empty; // Return the empty string!
    }
}
