using System;
using System.Xml;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// Suppresses namespace declarations in all XML elements (including the root).
    /// Note, to suppress the "xmlns:xsi" and "xmlns:xsd" on the root element you must also use an XmlSerializerNamespaces instance with an empty default namespace.
    /// </summary>
    /// <remarks>
    /// Adapted from: https://stackoverflow.com/a/874344
    /// See also: https://stackoverflow.com/a/6659714
    /// </remarks>
    public class NamespaceSupressingXmlWriter : XmlWriterWrapper
    {
        public NamespaceSupressingXmlWriter(XmlWriter output)
            : base(XmlWriter.Create(output))
        {
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            // Do not in any circumstances write a prefix or namespace!
            base.WriteStartElement("", localName, "");
        }
    }
}
