using System.IO;

namespace EiwmModel.Base
{
    public interface IRootEiwm
    {
        #region Public Properties

        string Comment { get; set; }

        TemplateEiwm Template { get; set; }

        #endregion Public Properties

        #region Public Methods

        RootEiwm Clone();

        void Serialize(TextWriter output);

        void Serialize(Stream stream);

        #endregion Public Methods
    }
}