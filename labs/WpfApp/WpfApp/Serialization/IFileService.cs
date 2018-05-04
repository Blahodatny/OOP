using System.Collections.Generic;
using WpfApp.Class;

namespace WpfApp.Serialization
{
    public interface IFileService<T> where T : Mathematician
    {
#pragma warning disable 693
        void Serialization<T>(List<T> list, string path);
#pragma warning restore 693
#pragma warning disable 693
        List<T> Deserialization<T>(string path);
#pragma warning restore 693
    }
}