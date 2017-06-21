using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlParser.Model
{
    [Serializable]
    [XmlRoot("group")]
    public class Group
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("valid_from")]
        public DateTime ValidFrom { get; set; }

        [XmlAttribute("valid_to")]
        public DateTime ValidTo { get; set; }

        [XmlArray("group")]
        [XmlArrayItem("questionary_item")]
        public List<QqfElement> QqfElements { get; set; }
    }
}
