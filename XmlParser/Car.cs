using System;
using System.Xml.Serialization;

namespace XmlParser
{
    [Serializable]
    public class Car
    {
        [XmlAttribute("StockNumber")]
        public string StockNumber { get; set; }

        [XmlAttribute("Make")]
        public string Make { get; set; }

        [XmlAttribute("Model")]
        public string Model { get; set; }
    }

    [Serializable]
    [XmlRoot("CarCollection")]
    public class CarCollection
    {
        [XmlArray("Cars")]
        [XmlArrayItem("Car", typeof(Car))]
        public Car[] Car { get; set; }
    }
}
