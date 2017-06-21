using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlParser.Model
{
    [Serializable]
    [XmlRoot("questionary_item")]
    public class QqfElement
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("qid")]
        public int QId { get; set; }

        [XmlAttribute("operand_type")]
        public string OperandTypeId { get; set; }

        [XmlAttribute("pos")]
        public int Position { get; set; }

        [XmlAttribute("audit_value")]
        public string AuditResult { get; set; }

        [XmlArray("visit_value")]
        [XmlArrayItem("kv")]
        public List<KeyValueElement> VisitResults { get; set; }

        [XmlArray("children")]
        [XmlArrayItem("questionary_item")]
        public List<QqfElement> ChildQqfElements { get; set; }
    }
}
