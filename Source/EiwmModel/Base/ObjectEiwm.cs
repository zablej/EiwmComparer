using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the Object element of the EIWMObject.
    /// </summary>
    [Serializable]
    public class ObjectEiwm
    {
        #region Public Constructors

        public ObjectEiwm()
        {
            Associations = new List<AssociationEiwm>();
            Characteristics = new List<CharacteristicEiwm>();
            Properties = new List<PropertyEiwm>();
        }

        public ObjectEiwm(string id, string name = null, string classId = null, string revision = null)
        {
            Id = id;
            Name = name;
            ClassId = classId;
            Revision = revision;
            Associations = new List<AssociationEiwm>();
            Characteristics = new List<CharacteristicEiwm>();
            Properties = new List<PropertyEiwm>();
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlElement(ElementName = "Association")]
        public List<AssociationEiwm> Associations { get; set; }

        [XmlElement(ElementName = "Characteristic")]
        public List<CharacteristicEiwm> Characteristics { get; set; }

        [XmlElement(ElementName = "ClassID", IsNullable = false)]
        public string ClassId { get; set; }

        [XmlElement(ElementName = "Context")]
        public ContextEiwm Context { get; set; }

        [XmlElement(ElementName = "ID")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Omit this Object from outputing to EIWM file. Object will still be outputed in associations.
        /// </summary>
        [XmlIgnore]
        public bool Omit { get; set; }

        /// <summary>
        /// Flag for not including ClassId attribute in associated EIWM Object
        /// </summary>
        [XmlIgnore]
        public bool OmitClassIdInAssociation { get; set; }

        /// <summary>
        /// Flag for not including Name attribute in associated EIWM Object
        /// </summary>
        [XmlIgnore]
        public bool OmitNameInAssociation { get; set; }

        /// <summary>
        /// Flag for not including Revision attribute in associated EIWM Object
        /// </summary>
        [XmlIgnore]
        public bool OmitRevisionInAssociation { get; set; }

        [XmlElement(ElementName = "Property")]
        public List<PropertyEiwm> Properties { get; set; }

        [XmlElement(ElementName = "Revision", IsNullable = false)]
        public string Revision { get; set; }

        #endregion Public Properties

        #region Public Methods

        public ObjectEiwm Clone()
        {
            return new ObjectEiwm
            {
                Id = Id,
                Context = Context?.Clone(),
                Revision = Revision,
                Name = Name,
                ClassId = ClassId,
                Associations = Associations?.Select(item => item.Clone()).ToList(),
                Characteristics = Characteristics?.Select(item => item.Clone()).ToList(),
                Properties = Properties?.Select(item => item.Clone()).ToList(),
            };
        }

        #endregion Public Methods
    }
}