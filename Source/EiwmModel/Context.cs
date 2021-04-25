using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EiwmModel
{
    [XmlType]
    public class Context
    {
        [XmlElement(ElementName = "ID", Type = typeof(string))]
        public string Id { get; set; }
    }
}
