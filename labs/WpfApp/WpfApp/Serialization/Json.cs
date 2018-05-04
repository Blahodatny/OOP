using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using WpfApp.Class;

namespace WpfApp.Serialization
{
    public class Json : IFileService<Mathematician>
    {
        public void Serialization<T>(List<T> list, string path)
        {
            // Create a stream to serialize the object to
            var ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(List<T>)).WriteObject(ms, list);
            var json = ms.ToArray();
            ms.Close();
            File.WriteAllText(path, Encoding.UTF8.GetString(json, 0, json.Length));
        }

        public List<T> Deserialization<T>(string path)
        {
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(path)));
            var obj = (List<T>)new DataContractJsonSerializer(typeof(List<T>)).ReadObject(ms);
            ms.Close();
            return obj;
        }
    }
}
