using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlParser.Model
{
    [Serializable]
    [XmlRoot("question")]
    public class QuestionElement : KeyValueElement
    {  
        [XmlArray("sked")]
        [XmlArrayItem("kv")]
        public List<KeyValueElement> SkedList { get; set; }
    }
}
