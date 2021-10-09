using System;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the Property element of the EIWMObject.
    /// </summary>
    [Serializable]
    public class PropertyEiwm : CharacteristicEiwm
    {
        #region Public Constructors

        public PropertyEiwm()
        {
        }

        public PropertyEiwm(string name, string value, string units) : base(name, value)
        {
            Units = units;
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlElement(ElementName = "Units")]
        public string Units { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override PropertyEiwm Clone() => new(Name, Value, Units);

        #endregion Public Methods
    }
}