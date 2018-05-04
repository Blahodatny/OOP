using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace lab3.Serialization.JSON
{
    public static class Json
    {
        public static void JsonSerialization<T>(List<T> list, string path)
        {
            // Create a stream to serialize the oblect to
            var ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(List<T>)).WriteObject(ms, list);
            var json = ms.ToArray();
            ms.Close();
            File.WriteAllText(path, Encoding.UTF8.GetString(json, 0, json.Length));
        }

        public static List<T> JsonDeserialization<T>(string path)
        {
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(path)));
            var obj = (List<T>) new DataContractJsonSerializer(typeof(List<T>)).ReadObject(ms);
            ms.Close();
            return obj;
        }
    }
}