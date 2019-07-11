using System;
using System.Xml;


namespace R5T.NetStandard.IO.Serialization
{
    /// <summary>
    /// An <see cref="XmlWriter"/> wrapper class that also implements the abstract <see cref="XmlWriter"/> base class.
    /// This allows for indirection to address any inconsistencies with the default implementation.
    /// </summary>
    /// <remarks>
    /// Adapted from: https://stackoverflow.com/a/874344
    /// </remarks>
    public class XmlWriterWrapper : XmlWriter
    {
        public override XmlWriterSettings Settings
        {
            get
            {
                return this.zWriter.Settings;
            }
        }

        protected XmlWriter zWriter;
        protected XmlWriter Writer
        {
            get
            {
                return this.zWriter;
            }
            set
            {
                this.zWriter = value;
            }
        }

        public override WriteState WriteState
        {
            get
            {
                return this.zWriter.WriteState;
            }
        }

        public override string XmlLang
        {
            get
            {
                return this.zWriter.XmlLang;
            }
        }

        public override XmlSpace XmlSpace
        {
            get
            {
                return this.zWriter.XmlSpace;
            }
        }


        public XmlWriterWrapper(XmlWriter baseWriter)
        {
            this.Writer = baseWriter;
        }

        public override void Close()
        {
            this.zWriter.Close();
        }

        protected override void Dispose(bool disposing)
        {
            (this.zWriter as IDisposable).Dispose();
        }

        public override void Flush()
        {
            this.zWriter.Flush();
        }

        public override string LookupPrefix(string ns)
        {
            return this.zWriter.LookupPrefix(ns);
        }

        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            this.zWriter.WriteBase64(buffer, index, count);
        }

        public override void WriteCData(string text)
        {
            this.zWriter.WriteCData(text);
        }

        public override void WriteCharEntity(char ch)
        {
            this.zWriter.WriteCharEntity(ch);
        }

        public override void WriteChars(char[] buffer, int index, int count)
        {
            this.zWriter.WriteChars(buffer, index, count);
        }

        public override void WriteComment(string text)
        {
            this.zWriter.WriteComment(text);
        }

        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            this.zWriter.WriteDocType(name, pubid, sysid, subset);
        }

        public override void WriteEndAttribute()
        {
            this.zWriter.WriteEndAttribute();
        }

        public override void WriteEndDocument()
        {
            this.zWriter.WriteEndDocument();
        }

        public override void WriteEndElement()
        {
            this.zWriter.WriteEndElement();
        }

        public override void WriteEntityRef(string name)
        {
            this.zWriter.WriteEntityRef(name);
        }

        public override void WriteFullEndElement()
        {
            this.zWriter.WriteFullEndElement();
        }

        public override void WriteProcessingInstruction(string name, string text)
        {
            this.zWriter.WriteProcessingInstruction(name, text);
        }

        public override void WriteRaw(string data)
        {
            this.zWriter.WriteRaw(data);
        }

        public override void WriteRaw(char[] buffer, int index, int count)
        {
            this.zWriter.WriteRaw(buffer, index, count);
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            this.zWriter.WriteStartAttribute(prefix, localName, ns);
        }

        public override void WriteStartDocument()
        {
            this.zWriter.WriteStartDocument();
        }

        public override void WriteStartDocument(bool standalone)
        {
            this.zWriter.WriteStartDocument(standalone);
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            this.zWriter.WriteStartElement(prefix, localName, ns);
        }

        public override void WriteString(string text)
        {
            this.zWriter.WriteString(text);
        }

        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            this.zWriter.WriteSurrogateCharEntity(lowChar, highChar);
        }

        public override void WriteValue(bool value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(DateTime value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(decimal value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(double value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(int value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(long value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(object value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(float value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteValue(string value)
        {
            this.zWriter.WriteValue(value);
        }

        public override void WriteWhitespace(string ws)
        {
            this.zWriter.WriteWhitespace(ws);
        }
    }
}
