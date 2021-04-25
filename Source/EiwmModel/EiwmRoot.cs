using System.Xml.Serialization;

namespace EiwmModel
{
    [XmlRoot("VNETList", Namespace = "http://www.aveva.com/VNET/List")]
    [XmlType(TypeName = "v1", Namespace = "http://www.aveva.com/VNET/eiwm")]
    public class EiwmRoot
    {
        [XmlElement]
        public Template Template { get; set; }
    }
}
