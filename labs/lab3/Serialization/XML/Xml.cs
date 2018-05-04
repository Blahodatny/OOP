using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace lab3.Serialization.XML
{
    public static class Xml
    {
        public static void XmlSerialization<T>(List<T> list, string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                new XmlSerializer(typeof(List<T>)).Serialize(fs, list);
                Console.WriteLine("Parameter has been serialized in XML!!!");
            }
        }

        public static List<T> XmlDeserialization<T>(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Console.WriteLine($"XML file {path} has been deserialized!!!");
                return (List<T>)new XmlSerializer(typeof(List<T>)).Deserialize(fs);
            }
        }
    }
}