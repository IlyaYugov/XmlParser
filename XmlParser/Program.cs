using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlParser.Collections;
using XmlParser.Model;

namespace XmlParser
{
    class Program
    {
        private const string _filename =
            "D:\\MyProjects\\XmlParser\\XmlParser\\example.xml";

        private const string _filename3 =
            "D:\\MyProjects\\XmlParser\\XmlParser\\refbook.xml";

        static void Main(string[] args)
        {
            string path = _filename;

            var xml = XDocument.Parse(File.ReadAllText(path))?.Root;
            var refbookXml = xml?.Element("refbook");
            var questionXml = refbookXml?.Element("question")?.ToString();
            var skuXml = refbookXml?.Element("sku")?.ToString();

            if (refbookXml == null || questionXml == null)
                return;

            var auditDate = (DateTime?)xml.Attribute("audit_date");
            var visitIds = xml.Element("visits")?.Elements("visit").Attributes("id").Select(s => Guid.Parse(s.Value));

            if (visitIds != null)
                foreach (var visitId in visitIds)
                {
                
                }

            var questDict = XElement.Parse(questionXml)
                .Elements("kv")
                .ToDictionary(
                    el => (int) el.Attribute("key"),
                    el =>
                        new QuestionRefbook
                        {
                            Name = (string) el.Attribute("value"),
                            OperandTypeId = (int) el.Attribute("operand_type"),

                            Sked = el.HasElements
                                ? el.Element("sked").Elements("kv")
                                    .ToDictionary(s => (int) s.Attribute("key"), s => (string) s.Attribute("value"))
                                : null
                        });

            Dictionary<int,string> skuDict = XElement.Parse(skuXml)
                .Elements("kv")
                .ToDictionary(
                    el => (int) el.Attribute("key"),
                    el => (string) el.Attribute("value"));

            var salepoint = xml.Element("salepoint")?.Elements("group")
                .Select(s => new XmlSection
                {
                    GroupName = (string)s.Attribute("name"),
                    ValidFrom = (DateTime)s.Attribute("valid_from"),
                    ValidTo = (DateTime?)s.Attribute("valid_to"),
                    Questions = s.Elements("questionary_item").Select(q => XmlAuditQuestions.Create(q, questDict))
                });

            var sku = xml.Element("sku")?.Elements("group")
                        .Select(s => new XmlSectionSku
                        {
                            GroupName = skuDict.FirstOrDefault(sk => sk.Key == (int)s.Attribute("id")).Value,
                            IsSelected = (bool?)s.Attribute("is_selected"),
                            SkuPosition = (int?)s.Attribute("pos"),
                            Questions = s.Elements("questionary_item").Select(q => XmlAuditQuestions.Create(q, questDict))
                        });

            var promo = xml.Element("promo")?.Elements("group")
                .Select(s => new XmlSection
                {
                    GroupName = (string)s.Attribute("name"),
                    ValidFrom = (DateTime)s.Attribute("valid_from"),
                    ValidTo = (DateTime?)s.Attribute("valid_to"),
                    Questions = s.Elements("questionary_item").Select(q => XmlAuditQuestions.Create(q, questDict))
                });

            var result = new XmlAuditDomainResult
            {
                SalePoint = salepoint,
                Promo = promo,
                Sku = sku,
                AuditDate = auditDate
            };

            //Example XmlSerializer
            XmlSerializer questSerializer = new XmlSerializer(typeof(QuestionCollection));
            var readerTest = new StringReader(refbookXml.ToString());
            var question = (QuestionCollection) questSerializer.Deserialize(readerTest);
            readerTest.Close();
        }
    }
}
