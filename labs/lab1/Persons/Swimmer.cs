using System.Drawing;
using lab1.Kind_of_activity;

namespace lab1.Persons
{
    public sealed class Swimmer : Sportsman
    {
        public Swimmer(int breathingSpeed, double swimmedDistance)
        {
        }

        public Swimmer(int stamina, string kindOfSport, int breathingSpeed, double swimmedDistance) : base(stamina,
            kindOfSport)
        {
        }

        public Swimmer(double weight, int age, string name, Image image, int stamina, string kindOfSport,
            int breathingSpeed, double swimmedDistance) : base(weight, age, name, image, stamina, kindOfSport)
        {
        }

        public Swimmer(double weight, int age, string name, string fileName, int stamina, string kindOfSport,
            int breathingSpeed, double swimmedDistance) : base(weight, age, name, fileName, stamina, kindOfSport)
        {
        }
    }
}