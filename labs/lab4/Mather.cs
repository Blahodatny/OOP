using System;
using System.IO;
using System.Text;

namespace lab4
{
    public sealed class Mather : IDisposable
    {
        private const string Path = @"/home/dima/C#/labs/lab3/data/hello.txt";
        private bool _disposed; // to detect redundant calls
        private readonly Stream _stream;
        
        public Mather(string faculty, string nickname, int computingSpeed, int attention)
        {
            _stream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.None);
        }

        public void WriteHelloToConsole()
        {
            // Create Stream object via constructor of FileStream
            // FileMode.Open: Open file to read
            var bytes = new byte[10];
            var encoding = new UTF8Encoding(true);
            int len;
                
            // Read on stream and asign to temporary array
            // Returns the number of bytes read
            while ((len = _stream.Read(bytes, 0, bytes.Length)) > 0)
            {
                // Converts to string
                var s = encoding.GetString(bytes, 0, len);
                Console.WriteLine(s);
            }
            
            // Синтаксис C# также предлагает синонимичную конструкцию для автоматического вызова метод Dispose - конструкцию using
//            using (_stream = new FileStream(Path, FileMode.Open))
//            {
//                var bytes = new byte[10];
//                var encoding = new UTF8Encoding(true);
//                int len;
//                
//                // Read on stream and asign to temporary array
//                // Returns the number of bytes read
//                while ((len = _stream.Read(bytes, 0, bytes.Length)) > 0)
//                {
//                    // Converts to string
//                    var s = encoding.GetString(bytes, 0, len);
//                    Console.WriteLine(s);
//                }
//            }
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
                _stream?.Dispose();
            }
            // Освобождаем неуправляемые ресурсы
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}