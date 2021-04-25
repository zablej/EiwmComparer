using EiwmModel;
using System;
using System.IO;
using System.Xml.Serialization;

namespace TestingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var eiwmPath = @"C:\Git\Github\EiwmComparer\Source\TestingProject\New folder\Centrifugal_Pumps_null.xml";
            var serializer = new XmlSerializer(typeof(EiwmRoot));
            object output;
            using(var reader = File.OpenRead(eiwmPath))
                output = serializer.Deserialize(reader);
        }
    }
}
