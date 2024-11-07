using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Abstracts
{
    [Serializable()]
    public abstract class XmlBase
    {
        public string ToXML(XmlSerializerNamespaces namespaces = null, bool indent = false)
        {
            return Encoding.UTF8.GetString(ToByteArray(namespaces, indent));
        }

        public byte[] ToByteArray(XmlSerializerNamespaces namespaces = null, bool indent = false)
        {
            var stream = ToStream(namespaces, indent);

            return stream.ToArray();            
        }

        public MemoryStream ToStream(XmlSerializerNamespaces namespaces = null, bool indent = false)
        {
            var xml = new XmlSerializer(this.GetType());

            var ms = new MemoryStream();
            xml.Serialize(ms, this, namespaces);

            ms.Position = 0;

            return ms;
        }
    }
}
