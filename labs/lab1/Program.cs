using System;
using lab1.Persons;

namespace lab1
{
    internal static class Program
    {
        public static void Main()
        {
            // Checking class Human
            
            // Creating first object
            var human1 = new Human(52.56, 13, "Georgiy", "Zlatan.jpg");
            human1.ShowObject();
            
            // Creating second object
            var human2 = new Human
            {
                Weight = 67.45,
                Age = 78,
                Name = "Victoria"
            };
            human2.ShowObject("Hello, I am Dima!!!");
            
            // Checking static parameters of Human class
            Console.WriteLine(Human.Quantity);
            
            // Checking class Mathematician
            var math = new Mathematician(45, 56);
            Console.WriteLine("Attention: " + math.Attention + " Computing Speed: " + math.ComputingSpeed);
        }
    }
}