using System.Drawing;

namespace lab2
{
    public abstract class BaseAbstractClass
    {
        protected double _weight;
        protected int _age;
        protected string _name;
        protected Image _image;

        protected abstract Image LoadImage(string filename);
        protected abstract void Error(string field);
        
        public abstract double Weight { get; set; }
        public abstract int Age { get; set; }
        public abstract string Name { get; set; }
        public abstract Image Image { get; set; }

        public abstract void ShowObject();
        public abstract void ShowObject(string line);
    }
}