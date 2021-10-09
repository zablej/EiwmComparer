using System;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the Context element of the EIWMObject.
    /// </summary>
    [Serializable]
    public class ContextEiwm
    {
        #region Public Constructors

        public ContextEiwm()
        {
        }

        public ContextEiwm(string id)
        {
            Id = id;
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlElement(ElementName = "Context")]
        public ContextEiwm Context { get; set; }

        [XmlElement(ElementName = "ID")]
        public string Id { get; set; }

        #endregion Public Properties

        #region Public Methods

        public ContextEiwm Clone()
        {
            return new ContextEiwm
            {
                Id = Id,
                Context = Context?.Clone(),
            };
        }

        public override string ToString()
        {
            if (Context != null)
                return Id + "|" + Context;

            return Id;
        }

        #endregion Public Methods
    }
}