using System;
using System.Drawing;

namespace lab1.Kind_of_activity
{
    public class Scientist : Human
    {
        private readonly string _academicRank;
        private readonly string _faculty;

        protected Scientist()
        {
            Console.WriteLine("Constructor Scientist() by default was called at {0}", DateTime.Now.ToLongTimeString());
        }

        protected Scientist(string academicRank, string faculty)
        {
            Console.WriteLine("Auto-generated constructor Scientist() was called at {0}", DateTime.Now.ToLongTimeString());
            _academicRank = academicRank;
            _faculty = faculty;
        }

        protected Scientist(double weight, int age, string name, Image image, string academicRank, string faculty) : base(weight, age, name, image)
        {
            Console.WriteLine("Redefined constructor Scientist() was called at {0}", DateTime.Now.ToLongTimeString());
            _academicRank = academicRank;
            _faculty = faculty;
        }
        
        // A private constructor is a special instance constructor.
        // It is generally used in classes that contain static members only.
        // If a class has one or more private constructors and no public constructors,
        // other classes (except nested (вкладені) classes) cannot create instances of this class.
        private Scientist(double weight, int age, string name, string fileName, string academicRank, string faculty) : base(weight, age, name, fileName)
        {
            Console.WriteLine("Private constructor Scientist() was called at {0}", DateTime.Now.ToLongTimeString());
            _academicRank = academicRank;
            _faculty = faculty;
        }

        public override void ShowObject()
        {
            Console.WriteLine("Scientist: " + name + " has parameters: academic rank " + _academicRank + "; faculty " + _faculty);
        }
    }
}