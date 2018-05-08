using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using lab3.Persons;
using lab3.Serialization.JSON;
using lab3.Serialization.XML;

namespace lab3
{
    internal static class Program
    {
        public static void Main()
        {
            var mathematics = new ArrayList();
            var random = new Random();

            for (var i = 1; i <= 10; i++)
                mathematics.Add(new Mathematician(random.Next(0, 100)));

            mathematics.Sort();
            foreach (Mathematician math in mathematics)
                Console.WriteLine(math.ComputingSpeed);
            Console.WriteLine("-------------");

            var mathes = new Mathes(new List<Mathematician>
            {
                new Mathematician("FPM", "Dmytro", 1003, 32),
                new Mathematician("FTI", "Valera", 988, 56),
                new Mathematician("IASA", "Nikita", 1345, 45),
                new Mathematician("FL", "Polina", 456, 99),
                new Mathematician("FMM", "Dasha", 476, 89)
            });

            Xml.XmlSerialization(mathes.Mathematicians, Directory.GetCurrentDirectory() + "/../../data/file.xml");
            Json.JsonSerialization(mathes.Mathematicians, Directory.GetCurrentDirectory() + "/../../data/file.json");

            var mathes1 =
                Xml.XmlDeserialization<Mathematician>(Directory.GetCurrentDirectory() + "/../../data/file.xml");
            foreach (var math in mathes1)
                Console.WriteLine(math.Nickname + " " + math.Faculty);

            Console.WriteLine("----------------");

            var mathes2 =
                Json.JsonDeserialization<Mathematician>(Directory.GetCurrentDirectory() + "/../../data/file.json");
            foreach (var math in mathes2)
                Console.WriteLine(math.Nickname + " " + math.Faculty);
        }
    }
}