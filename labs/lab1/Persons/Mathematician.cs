using System.Drawing;
using lab1.Kind_of_activity;

namespace lab1.Persons
{
    public sealed class Mathematician : Scientist
    {
        public Mathematician(int computingSpeed, int attention)
        {
            ComputingSpeed = computingSpeed;
            Attention = attention;
        }

        public Mathematician(string academicRank, string faculty, int computingSpeed, int attention) : base(
            academicRank, faculty)
        {
            ComputingSpeed = computingSpeed;
            Attention = attention;
        }

        public Mathematician(double weight, int age, string name, Image image, string academicRank, string faculty,
            int computingSpeed, int attention) : base(weight, age, name, image, academicRank, faculty)
        {
            ComputingSpeed = computingSpeed;
            Attention = attention;
        }

        public int ComputingSpeed { get; }

        public int Attention { get; }
    }
}