using System.Xml.Serialization;

namespace EiwmModel
{
    [XmlType]
    public class Association
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement]
        public Object Object { get; set; }
    }
}