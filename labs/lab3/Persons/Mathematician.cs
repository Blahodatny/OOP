using System;
using System.Collections;
using System.Collections.Generic;

namespace lab3.Persons
{
    public class Mathematician : IComparable
    {
        public Mathematician()
        {
        }

        public Mathematician(string faculty, string nickname, int computingSpeed, int attention)
        {
            Faculty = faculty;
            Nickname = nickname;
            ComputingSpeed = computingSpeed;
            Attention = attention;
        }

        public Mathematician(int computingSpeed)
        {
            ComputingSpeed = computingSpeed;
        }

        // Инкапсуляция поля (Encapsulate Field) - правило рефакторинга
        public string Faculty { get; set; }
        public string Nickname { get; set; }
        public int ComputingSpeed { get; set; }

        public int Attention { get; set; }
        // Спуск поля/метода (Push Down) - правило рефакторинга

        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case Mathematician math:
                    return ComputingSpeed.CompareTo(math.ComputingSpeed);
            }

            throw new ArgumentException("Object is not a Mathematician!!!");
        }
    }

    // Collection of Mathematician objects
    // This class implements IEnumerable so that it can be used with ForEach syntax

    public class Mathes : IEnumerable
    {
        public Mathes(List<Mathematician> mathematicians)
        {
            Mathematicians = mathematicians;
        }

        public List<Mathematician> Mathematicians { get; }

//        public int Count => _mathematicians.Count;

        public Mathematician this[int index] => Mathematicians[index];

        public Mathematician this[string name] => Mathematicians.Find(nm => nm.Nickname.Equals(name));

        // Если метод не вызывается в программе, то его следует удалить
        // Хранить мертвый код расточительно
        // Роберт Мартин "Чистый код" стр. 325
//        public void Add(Mathematician mathematician) => _mathematicians.Add(mathematician);

        // Implementation for the GetEnumerator method
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private MathesEnum GetEnumerator()
        {
            return new MathesEnum(Mathematicians);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator
    public class MathesEnum : IEnumerator
    {
        private readonly List<Mathematician> _mathematicians;

        // Enumerators are positioned before the first element until the first MoveNext() call.
        private int _position = -1;

        public MathesEnum(List<Mathematician> list)
        {
            _mathematicians = list;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _mathematicians.Count;
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => Current;

        private Mathematician Current
        {
            get
            {
                try
                {
                    return _mathematicians[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}