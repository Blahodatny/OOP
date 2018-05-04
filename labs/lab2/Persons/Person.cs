using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace lab2.Persons
{
    public class Person : BaseAbstractClass
    {
        protected override Image LoadImage(string fileName)
        {
            try
            {
                Console.WriteLine("Trying to load image from a file: " +
                                  Directory.GetCurrentDirectory() + "/Avatars/" + fileName + "...");
                return Image.FromFile(Directory.GetCurrentDirectory() + "/Avatars/" + fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        protected override void Error(string field)
        {
            throw new ArgumentException("The " + field + " is not valid!!!");
        }
        
        public override double Weight
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

        public override int Age
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

        public override string Name
        {
            get => _name;
            set
            {
                var nameRegEx = new Regex(@"^[A-Z]{1}[a-z]{1,30}$");
                if (nameRegEx.IsMatch(value))
                {
                    _name = value;
                }
                else
                {
                    Error("_name");
                    Console.Error.WriteLine("The value should begin with an uppercase letter and contain 30 symbols as maximum");
                }
            }
        }

        public override Image Image
        {
            get => _image;
            set => _image = value;
        }
        
        public override void ShowObject()
        {
            Console.WriteLine(_name + " has parameters: weight " + _weight + "; age " + _age);
        }
        
        public override void ShowObject(string line)
        {
            Console.WriteLine(_name + " has parameters: weight " + _weight + "; age " + _age + ". And your line is:\n" + line);
        }
    }
}