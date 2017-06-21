using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XmlParser.Model;

namespace XmlParser.Collections
{
    [Serializable]
    [XmlRoot("salepoint")]
    public class SalePoint
    {
        [XmlArray("salepoint")]
        [XmlArrayItem("group")]
        public List<Group> QqfElements { get; set; }
    }
}
