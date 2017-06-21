using System.Collections.Generic;

namespace XmlParser
{
    public class QuestionRefbook
    {
        public int OperandTypeId { get; set; }

        public string Name { get; set; }

        public Dictionary<int, string> Sked { get; set; }
    }
}
