using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlParser
{
    [XmlRoot]
    public class EventInput
    {

        private string group;

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        private Event[] events;

        public Event[] Events
        {
            get { return events; }
            set { events = value; }
        }
    }

    public class Event
    {
        private int id;

        [XmlAttribute]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
