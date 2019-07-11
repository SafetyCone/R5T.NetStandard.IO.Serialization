using System;
using System.Xml;


namespace R5T.NetStandard.IO.Serialization
{
    public class NamespaceSupressingXmlWriter : XmlWriterWrapper
    {
        //Provide as many contructors as you need
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
