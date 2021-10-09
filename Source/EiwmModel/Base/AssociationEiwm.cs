using System;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the Association element of the EIWMObject.
    /// </summary>
    [Serializable]
    public class AssociationEiwm
    {
        #region Public Constructors

        public AssociationEiwm()
        {
        }

        public AssociationEiwm(string type)
        {
            Type = type;
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlElement(ElementName = "ClassID", IsNullable = false)]
        public string ClassId { get; set; }

        [XmlElement(ElementName = "Object")]
        public ObjectEiwm Object { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        #endregion Public Properties

        #region Public Methods

        public AssociationEiwm Clone()
        {
            return new AssociationEiwm(Type)
            {
                Object = Object?.Clone()
            };
        }

        #endregion Public Methods
    }
}