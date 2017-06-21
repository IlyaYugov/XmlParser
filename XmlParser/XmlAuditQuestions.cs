
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlParser
{
    class XmlAuditDomainResult
    {
        //public List<VisitDetailDescription> VisitsDetails { get; set; }

        //public IEnumerable<SalePointTaskListResult> SalePointTasks { get; set; }

        //public IEnumerable<StockAnswerForAudit> Stocks { get; set; }

        public IEnumerable<XmlSection> Promo { get; set; }

        public IEnumerable<XmlSection> SalePoint { get; set; }

        public IEnumerable<XmlSectionSku> Sku { get; set; }

        public DateTime? AuditDate { get; set; }
    }

    public class XmlSection
    {
        public IEnumerable<XmlAuditQuestions> Questions { get; set; }

        public string GroupName { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }
    }

    public class XmlSectionSku
    {
        public IEnumerable<XmlAuditQuestions> Questions { get; set; }

        public string GroupName { get; set; }

        public bool? IsSelected { get; set; }

        public int? SkuPosition { get; set; }
    }

    public class XmlAuditQuestions
    {
        public int? QQFID { get; set; }

        public string QuestionName { get; set; }

        public IEnumerable<string> VisitsResults { get; set; }

        public int? ParentQQFID { get; set; }

        public IEnumerable<XmlAuditQuestions> ChildQuestions { get; set; }

        public object AuditResult { get; set; }

        public IEnumerable<QuestionSkedListForAudit> QuestionSkedList { get; set; }

        public int DataType { get; set; }

        public int? Position { get; set; }

        public static XmlAuditQuestions Create(XElement el, Dictionary<int, QuestionRefbook> quest, int? parrentId = null)
        {
            var qqfId = (int)el.Attribute("id");

            var qqf = quest.FirstOrDefault(s => s.Key == (int)el.Attribute("qid")).Value;

            return new XmlAuditQuestions
            {
                QQFID = qqfId,
                QuestionName = qqf.Name,
                VisitsResults =  el.Element("visit_value")?.Elements("kv").Select(s => (string)s.Attribute("value")),
                ParentQQFID = parrentId,
                ChildQuestions = el.Element("children")?.Elements("questionary_item").Select(s => Create(s, quest, qqfId)),
                AuditResult = el.Attribute("audit_value") != null ?
                qqf.OperandTypeId == (int)OperandTypes.Bool
                    ? (bool)el.Attribute("audit_value")
                    : qqf.OperandTypeId == (int)OperandTypes.DateTime
                        ? (DateTime)el.Attribute("audit_value")
                        : qqf.OperandTypeId == (int)OperandTypes.Float
                            ? (double)el.Attribute("audit_value")
                            : qqf.OperandTypeId == (int)OperandTypes.Int || qqf.OperandTypeId == (int)OperandTypes.List
                                ? (int?)el.Attribute("audit_value")
                                : qqf.OperandTypeId == (int)OperandTypes.String
                                    ? (string)el.Attribute("audit_value")
                                    : (object)null
                                    : null,
                QuestionSkedList = qqf.Sked?.Select(s => new QuestionSkedListForAudit
                {
                    ID = s.Key,
                    Name = s.Value
                }),
                Position = (int)el.Attribute("pos"),
                DataType = qqf.OperandTypeId
            };
        }
    }
    public class QuestionSkedListForAudit
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

    public enum OperandTypes
    {
        Int = 1,
        Bool = 2,
        String = 3,
        DateTime = 4,
        List = 5,
        Float = 6
    }
}
