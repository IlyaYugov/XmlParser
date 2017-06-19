using System;
using System.Xml.Serialization;

namespace XmlParser
{
    [Serializable]
    public class Sku
    {
        [XmlAttribute("key")]
        public string Id { get; set; }

        [XmlAttribute("value")]
        public string Name { get; set; }
    }

    [Serializable]
    [XmlRoot("audit_result/refbook")]
    public class SkuCollection
    {
        //[XmlArrayItem("refbook")]
        [XmlArray("sku")]
        [XmlArrayItem("kv",typeof(Sku))]
        public Sku[] Sku { get; set; }
    }
}
