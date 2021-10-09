using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace EiwmModel.Base
{
    /// <summary>
    /// This class handles the EIWMObject Root element.
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.aveva.com/VNET/eiwm")]
    [XmlRoot(Namespace = "http://www.aveva.com/VNET/List", ElementName = "VNETList", IsNullable = false)]
    public class RootEiwm : IRootEiwm
    {
        #region Public Constructors

        public RootEiwm()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        [XmlIgnore]
        public string Comment { get; set; }

        [XmlElement(ElementName = "Template")]
        public TemplateEiwm Template { get; set; } = new TemplateEiwm();

        #endregion Public Properties

        #region Public Methods

        public RootEiwm Clone()
        {
            return new RootEiwm
            {
                Comment = Comment,
                Template = Template?.Clone(),
            };
        }

        public void Serialize(Stream stream)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            using var output = new StreamWriter(stream, System.Text.Encoding.UTF8, 1024, true);
            Serialize(output);
        }

        public void Serialize(TextWriter output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            var nspaces = new Dictionary<string, string>
            {
                {"", "http://www.aveva.com/VNET/eiwm"},
                {"v1", "http://www.aveva.com/VNET/List"}
            };

            var settings = new XmlWriterSettings
            {
                Indent = true
            };

            using var xmlFile = XmlWriter.Create(output, settings);

            xmlFile.WriteStartDocument();
            if (!string.IsNullOrWhiteSpace(Comment))
                xmlFile.WriteComment(Comment);

            xmlFile.WriteStartElement("v1", "VNETList", nspaces["v1"]);
            xmlFile.WriteAttributeString("xmlns", "", null, nspaces[""]);
            xmlFile.WriteStartElement("Template");
            WriteObjectAttribute(xmlFile, "ID", Template.Id);

            foreach (var obj in Template.Objects)
                WriteObject(xmlFile, obj);

            xmlFile.WriteEndDocument();
            xmlFile.Flush();
        }

        #endregion Public Methods

        #region Private Methods

        [Obfuscation(Exclude = true, Feature = "renaming")]
        private static void WriteObjectAttribute(XmlWriter writer, string element, string value, bool keepIfNullOrEmpty = false)
        {
            if (string.IsNullOrEmpty(value) && keepIfNullOrEmpty)
            {
                writer.WriteStartElement(element);
                writer.WriteEndElement();
            }

            if (string.IsNullOrEmpty(value))
                return;

            writer.WriteStartElement(element);
            writer.WriteValue(value);
            writer.WriteEndElement();
        }

        [Obfuscation(Exclude = true, Feature = "renaming")]
        private void WriteObject(XmlWriter writer, ObjectEiwm eiwmObject, bool isAssoc = false)
        {
            if (eiwmObject is null)
                return;

            if (!isAssoc && eiwmObject.Omit)
                return;

            writer.WriteStartElement("Object");
            WriteObjectAttribute(writer, "ID", eiwmObject.Id);
            WriteObjectContext(writer, eiwmObject.Context);

            if (!isAssoc || !eiwmObject.OmitRevisionInAssociation)
                WriteObjectAttribute(writer, "Revision", eiwmObject.Revision);

            if (!isAssoc || !eiwmObject.OmitNameInAssociation)
                WriteObjectAttribute(writer, "Name", eiwmObject.Name);

            if (!isAssoc || !eiwmObject.OmitClassIdInAssociation)
                WriteObjectAttribute(writer, "ClassID", eiwmObject.ClassId);

            if (!isAssoc)
            {
                eiwmObject.Associations.ForEach(assoc =>
                {
                    writer.WriteStartElement("Association");
                    writer.WriteAttributeString("type", assoc.Type);

                    if (assoc.Type.Equals("is incidentally classified as", StringComparison.InvariantCultureIgnoreCase))
                        WriteObjectAttribute(writer, "ClassID", assoc.ClassId);
                    else
                        WriteObject(writer, assoc.Object, true);

                    writer.WriteEndElement();
                });

                eiwmObject.Characteristics.ForEach(chr =>
                {
                    writer.WriteStartElement("Characteristic");
                    WriteObjectAttribute(writer, "Name", chr.Name);
                    WriteObjectAttribute(writer, "Value", chr.Value, true);
                    writer.WriteEndElement();
                });

                eiwmObject.Properties.ForEach(prop =>
                {
                    writer.WriteStartElement("Property");
                    WriteObjectAttribute(writer, "Name", prop.Name);
                    WriteObjectAttribute(writer, "Value", prop.Value, true);
                    WriteObjectAttribute(writer, "Units", prop.Units);
                    writer.WriteEndElement();
                });
            }
            writer.WriteEndElement();
        }

        private void WriteObjectContext(XmlWriter writer, ContextEiwm context)
        {
            if (context is null)
                return;

            writer.WriteStartElement("Context");
            WriteObjectAttribute(writer, "ID", context.Id, true);
            WriteObjectContext(writer, context.Context);
            writer.WriteEndElement();
        }

        #endregion Private Methods
    }
}