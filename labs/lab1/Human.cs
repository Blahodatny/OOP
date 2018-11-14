using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace lab1
{
    public class Human
    {
        private double _weight;
        private int _age;
        protected string name;
        protected readonly Image Image;

        // A static constructor is used to initialize any static data,
        // or to perform a particular action that needs to be performed once only.
        // It is called automatically before the first instance is created or any static members are referenced. 
        static Human()
        {
            Console.WriteLine("Static constructor Human() was generated at {0}", DateTime.Now.ToLongTimeString());
            Quantity = 0;
        }

        // default constructor
        public Human()
        {
            Console.WriteLine("Constructor Human() by default was called at {0}", DateTime.Now.ToLongTimeString());
            Quantity++;
        }

        // auto-generated constructor
        protected Human(double weight, int age, string name, Image image)
        {
            Console.WriteLine("Auto-generated constructor was called at {0}", DateTime.Now.ToLongTimeString());
            _weight = weight;
            _age = age;
            this.name = name;
            Image = image;
            Quantity++;
        }

        private static Image LoadImage(string fileName)
        {
            try
            {
                Console.WriteLine("Trying to load image from a file: " + Directory.GetCurrentDirectory() + "/Avatars/" +
                                  fileName + "...");
                return Image.FromFile(Directory.GetCurrentDirectory() + "/Avatars/" + fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // redefined constructor
        public Human(double weight, int age, string name, string fileName)
        {
            Console.WriteLine("Redefined constructor was called at {0}", DateTime.Now.ToLongTimeString());
            _weight = weight;
            _age = age;
            this.name = name;
            Image = LoadImage(fileName);
            Quantity++;
        }

        private static void Error(string field) => throw new ArgumentException("The " + field + " is not valid!!!");

        public double Weight
        {
            get => _weight;
            set
            {
                if (value > 0 && value <= 500)
                {
                    _weight = value;
                }
                else
                {
                    Error("_weight");
                    Console.Error.WriteLine("The value should be [1;500]");
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value > 0 && value <= 200)
                {
                    _age = value;
                }
                else
                {
                    Error("_age");
                    Console.Error.WriteLine("The value should be [1;200]");
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                var nameRegEx = new Regex(@"^[A-Z]{1}[a-z]{1,30}$");
                if (nameRegEx.IsMatch(value))
                {
                    name = value;
                }
                else
                {
                    Error("name");
                    Console.Error.WriteLine(
                        "The value should begin with an uppercase letter and contain 30 symbols as maximum");
                }
            }
        }

        // Если член класса объявляется как static, то он становится доступным до создания любых объектов
        // своего класса и без ссылки на какой-нибудь объект.
        public static int Quantity { get; private set; }

        public virtual void ShowObject() =>
            Console.WriteLine(name + " has parameters: weight " + _weight + "; age " + _age);

        public void ShowObject(string line) =>
            Console.WriteLine(name + " has parameters: weight " + _weight + "; age " + _age + ". And your line is:\n" +
                              line);
    }
}