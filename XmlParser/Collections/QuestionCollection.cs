using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XmlParser.Model;

namespace XmlParser.Collections
{
    [Serializable]
    [XmlRoot("refbook")]
    public class QuestionCollection
    {
        [XmlArray("question")]
        [XmlArrayItem("kv")]
        public List<QuestionElement> QuestionElements { get; set; }
    }
}
