using System;
using System.Drawing;
using lab1.Kind_of_activity;

namespace lab1.Persons
{
    public sealed class Kicker : Sportsman
    {
        public Kicker(int impactForce, double speed)
        {
        }

        public Kicker(int stamina, string kindOfSport, int impactForce, double speed) : base(stamina, kindOfSport)
        {
        }

        public Kicker(double weight, int age, string name, Image image, int stamina, string kindOfSport, int impactForce, double speed) : base(weight, age, name, image, stamina, kindOfSport)
        {
        }

        public Kicker(double weight, int age, string name, string fileName, int stamina, string kindOfSport, int impactForce, double speed) : base(weight, age, name, fileName, stamina, kindOfSport)
        {
        }

        public void BestKicker()
        {
            Console.WriteLine("The best kicker " + name + " is a face of " + kindOfSport + " kind of sport, has those {0} height and {1} width of picture.", Image.Height, Image.Width);
        }
    }
}