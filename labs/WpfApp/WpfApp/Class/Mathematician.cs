using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Class
{
    // Для уведомления системы об изменениях свойств модель Mathematician
    // реализует интерфейс INotifyPropertyChanged
    public class Mathematician : INotifyPropertyChanged
    {
        private string _faculty = "FACULTY";
        private string _nickname = "Nickname";
        private int _computingSpeed;
        private int _attention;

        public Mathematician() { }

        private static bool IsAllUpper(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsUpper(str[i]))
                    return false;
            }
            return true;
        }

        public string Faculty
        {
            get => _faculty;
            set
            {
                if (IsAllUpper(value) && value.Length < 10)
                {
                    _faculty = value;
                    OnPropertyChanged("Faculty");
                }
            }
        }

        public string Nickname
        {
            get => _nickname;
            set
            {
                if (Char.IsUpper(value[0]) && value.Length <= 20)
                {
                    _nickname = value;
                    OnPropertyChanged("Nickname");
                }
            }
        }

        public int ComputingSpeed
        {
            get => _computingSpeed;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _computingSpeed = value;
                    OnPropertyChanged("ComputingSpeed");
                }
            }
        }

        public int Attention
        {
            get => _attention;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _attention = value;
                    OnPropertyChanged("Attention");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    // Collection of Mathematician objects
    // This class implements IEnumerable so that it can be used with ForEach syntax

    public class Mathes : IEnumerable
    {
        private readonly List<Mathematician> _mathematicians;

        public Mathes(List<Mathematician> mathematicians)
        {
            _mathematicians = mathematicians;
        }

        public List<Mathematician> Mathematicians => _mathematicians;

        public Mathematician this[int index] => _mathematicians[index];

        public Mathematician this[string name] => _mathematicians.Find(nm => nm.Nickname.Equals(name));

        public void Add(Mathematician mathematician) => _mathematicians.Add(mathematician);

        // Implementation for the GetEnumerator method
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private MathesEnum GetEnumerator()
        {
            return new MathesEnum(_mathematicians);
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