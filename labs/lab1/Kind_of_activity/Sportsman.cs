using System;
using System.Drawing;

namespace lab1.Kind_of_activity
{
    public class Sportsman : Human
    {
        private readonly int _stamina;
        protected string kindOfSport;

        protected Sportsman() {}

        protected Sportsman(int stamina, string kindOfSport)
        {
            _stamina = stamina;
            this.kindOfSport = kindOfSport;
        }

        protected Sportsman(double weight, int age, string name, Image image, int stamina, string kindOfSport) : base(weight, age, name, image)
        {
            _stamina = stamina;
            this.kindOfSport = kindOfSport;
        }

        protected Sportsman(double weight, int age, string name, string fileName, int stamina, string kindOfSport) : base(weight, age, name, fileName)
        {
            _stamina = stamina;
            this.kindOfSport = kindOfSport;
        }

        public override void ShowObject()
        {
            Console.WriteLine("Sportsman: " + name + " has parameters: kind of sport " + kindOfSport + "; stamina " + _stamina);
        }
    }
}