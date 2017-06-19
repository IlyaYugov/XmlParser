using System;
using System.Xml.Serialization;

namespace XmlParser
{

    [Serializable]
    class AuditResult
    {
    }

    [Serializable]
    [XmlRoot("audit_result")]
    public class CarCollection2
    {
        [XmlArray("refbook")]
        [XmlArrayItem("sku", typeof(Car))]
        public Sku[] Car { get; set; }
    }
}
