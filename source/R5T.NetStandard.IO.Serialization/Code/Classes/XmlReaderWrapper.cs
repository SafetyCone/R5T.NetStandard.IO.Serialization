using System;
using System.Xml;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// Wraps an <see cref="System.Xml.XmlReader"/> while also implementing the abstract base class <see cref="System.Xml.XmlReader"/>.
    /// </summary>
    /// <remarks>
    /// Adapted from: https://stackoverflow.com/a/47043927
    /// See also:
    /// http://www.tkachenko.com/blog/archives/000585.html
    /// https://referencesource.microsoft.com/#System.Xml/System/Xml/Core/XmlWrappingReader.cs
    /// </remarks>
    public class XmlReaderWrapper : XmlReader
    {
        public XmlReader XmlReader { get; }

        public override int AttributeCount => this.XmlReader.AttributeCount;
        public override string BaseURI => this.XmlReader.BaseURI;
        public override int Depth => this.XmlReader.Depth;
        public override bool EOF => this.XmlReader.EOF;
        public override bool IsEmptyElement => this.XmlReader.IsEmptyElement;
        public override string LocalName => this.XmlReader.LocalName;
        public override string NamespaceURI => this.XmlReader.NamespaceURI;
        public override XmlNameTable NameTable => this.XmlReader.NameTable;
        public override XmlNodeType NodeType => this.XmlReader.NodeType;
        public override string Prefix => this.XmlReader.Prefix;
        public override ReadState ReadState => this.XmlReader.ReadState;
        public override string Value => this.XmlReader.Value;


        public XmlReaderWrapper(XmlReader xmlReader)
        {
            this.XmlReader = xmlReader;
        }

        public override string GetAttribute(int i)
        {
            var attribute = this.XmlReader.GetAttribute(i);
            return attribute;
        }

        public override string GetAttribute(string name)
        {
            var attribute = this.XmlReader.GetAttribute(name);
            return attribute;
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            var attribute = this.XmlReader.GetAttribute(name, namespaceURI);
            return attribute;
        }

        public override string LookupNamespace(string prefix)
        {
            var output = this.XmlReader.LookupNamespace(prefix);
            return output;
        }

        public override bool MoveToAttribute(string name)
        {
            var output = this.XmlReader.MoveToAttribute(name);
            return output;
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            var output = this.XmlReader.MoveToAttribute(name, ns);
            return output;
        }

        public override bool MoveToElement()
        {
            var output = this.XmlReader.MoveToElement();
            return output;
        }

        public override bool MoveToFirstAttribute()
        {
            var output = this.XmlReader.MoveToFirstAttribute();
            return output;
        }

        public override bool MoveToNextAttribute()
        {
            var output = this.XmlReader.MoveToNextAttribute();
            return output;
        }

        public override bool Read()
        {
            var output = this.XmlReader.Read();
            return output;
        }

        public override bool ReadAttributeValue()
        {
            var output = this.XmlReader.ReadAttributeValue();
            return output;
        }

        public override void ResolveEntity()
        {
            this.XmlReader.ResolveEntity();
        }
    }
}
