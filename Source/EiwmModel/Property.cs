using System.Xml.Serialization;

namespace EiwmModel
{
    [XmlType]
    public class Property : Characteristic
    {
        [XmlElement]
        public string Unit { get; set; }
    }
}