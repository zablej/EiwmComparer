using System;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the Characteristic element of the EIWMObject.
    /// </summary>
    [Serializable]
    public class CharacteristicEiwm
    {
        #region Public Constructors

        public CharacteristicEiwm()
        {
        }

        public CharacteristicEiwm(string name, string value)
        {
            Name = name;
            Value = value;
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }

        #endregion Public Properties

        #region Public Methods

        public virtual CharacteristicEiwm Clone() => new(Name, Value);

        #endregion Public Methods
    }
}