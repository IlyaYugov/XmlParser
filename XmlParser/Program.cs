using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlParser
{
    class Program
    {
        private const String filename =
            "C:\\Users\\iiugov\\Documents\\Visual Studio 2015\\Projects\\XmlParser\\XmlParser\\items.xml";

        private const String filename2 =
            "C:\\Users\\iiugov\\Documents\\Visual Studio 2015\\Projects\\XmlParser\\XmlParser\\cars.xml";

        private const String filename3 =
            "C:\\Users\\iiugov\\Documents\\Visual Studio 2015\\Projects\\XmlParser\\XmlParser\\refbook.xml";

        static void Main(string[] args)
        {

            //CarCollection cars = null;
            //string path = filename2;

            //XmlSerializer serializer = new XmlSerializer(typeof(CarCollection));

            //StreamReader reader = new StreamReader(path);
            //cars = (CarCollection)serializer.Deserialize(reader);
            //reader.Close();


            SkuCollection sku = null;
            string path = filename3;

            XmlSerializer serializer = new XmlSerializer(typeof(SkuCollection));

            //StreamReader reader = new StreamReader(path);
            //sku = (SkuCollection)serializer.Deserialize(reader);
            //reader.Close();



            XDocument xml = XDocument.Parse(File.ReadAllText(path));



            var linqQoject = xml
                .Descendants();


            //XDocument xDoc = new XDocument(
            //    new XElement("Employees",
            //        new XElement("Employee",
            //            new XAttribute("type", "Programmer"),
            //            new XElement("FirstName", "Alex"),
            //            new XElement("LastName", "Erohin")),
            //        new XElement("Employee",
            //            new XAttribute("type", "Editor"),
            //            new XElement("FirstName", "Elena"),
            //            new XElement("LastName", "Volkova"))));

            //var r2 = xDoc.Descendants();
                    


            var parseSku =
                xml.Descendants()
                    .Where(s => s.Name.LocalName == "sku");

            var parseQuestion =
                xml.Descendants()
                    .Where(s => s.Name.LocalName == "question");
        }
    }
}
