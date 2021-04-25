using System.Xml.Serialization;

namespace EiwmModel
{
    [XmlType]
    public class Characteristic
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Value { get; set; }
    }
}