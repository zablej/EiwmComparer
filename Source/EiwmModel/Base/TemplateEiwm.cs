using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the Template element of the EIWMObject.
    /// </summary>
    [Serializable]
    public class TemplateEiwm
    {
        #region Public Constructors

        public TemplateEiwm()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlElement(ElementName = "ID")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "Intent")]
        public string Intent { get; set; }

        [XmlElement(ElementName = "Object")]
        public List<ObjectEiwm> Objects { get; set; } = new List<ObjectEiwm>();

        #endregion Public Properties

        #region Public Methods

        public TemplateEiwm Clone()
        {
            return new TemplateEiwm
            {
                Id = Id,
                Intent = Intent,
                Objects = Objects.Select(obj => obj.Clone()).ToList(),
            };
        }

        #endregion Public Methods
    }
}