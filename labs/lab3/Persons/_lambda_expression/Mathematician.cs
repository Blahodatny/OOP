using System;
using System.Collections.Generic;
using lab1.Kind_of_activity;
using lab3.Interfaces;

namespace lab3.Persons._lambda_expression
{
    public class Mathematician : Scientist, IMathematicianProperties
    {
        private readonly Dictionary<string, Func<double, double, double>> _operations;
        private readonly Dictionary<string, Action<string>> _exclamations;

        public Mathematician(int computingSpeed, int attention)
        {
            ComputingSpeed = computingSpeed;
            Attention = attention;
            _operations = new Dictionary<string, Func<double, double, double>>
            {
                {"+", (x, y) => x + y},
                {"-", (x, y) => x - y},
                {"*", (x, y) => x * y},
                {"/", (x, y) => x / y}
            };

            _exclamations = new Dictionary<string, Action<string>>
            {
                {"Say", Console.WriteLine},
                {"Shout", s => Console.WriteLine(s.ToUpper() + "!!!")},
                {"Whist", s => Console.WriteLine($"I am mute, but I will try to say this {s} later...")}
            };
        }

        public int ComputingSpeed { get; set; }
        public int Attention { get; set; }

        public double PerformOperation(string op, double x, double y)
        {
            if (!_operations.ContainsKey(op))
                throw new ArgumentException($"Operation {op} is invalid!!!");
            return _operations[op](x, y);
        }

        public void PerformExclamation(string op, string exclamation)
        {
            if (!_exclamations.ContainsKey(op))
                throw new ArgumentException($"Action to say {op} is invalid!!!");
            _exclamations[op](exclamation);
        }

        public void DefineOperation(string op, Func<double, double, double> body)
        {
            if (_operations.ContainsKey(op))
                throw new ArgumentException($"Operation {op} already exists!!!", nameof(op));
            _operations.Add(op, body);
        }
    }
}