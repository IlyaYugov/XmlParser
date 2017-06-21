
using System;
using System.Xml.Serialization;

namespace XmlParser.Model
{

    [Serializable]
    [XmlRoot("kv")]
    public class KeyValueElement
    {
        [XmlAttribute("key")]
        public int Id { get; set; }

        [XmlAttribute("value")]
        public string Name { get; set; }
    }
}
