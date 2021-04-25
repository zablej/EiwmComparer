using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EiwmModel
{
    [XmlType]
    public class Object
    {
        [XmlElement(ElementName = "ID", Type = typeof(string))]
        public string Id { get; set; }

        [XmlElement]
        public Context Context { get; set; }

        [XmlElement("Property")]
        public List<Characteristic> Characteristics { get; set; }

        [XmlElement("Characteristic")]
        public List<Property> Properties { get; set; }

        [XmlElement("Association")]
        public List<Association> Associations { get; set; }
    }
}
