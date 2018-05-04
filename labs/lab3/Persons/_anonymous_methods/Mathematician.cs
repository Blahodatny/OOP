using System;
using System.Collections.Generic;
using lab1.Kind_of_activity;
using lab3.Interfaces;
using lab3.Persons._delegate;

namespace lab3.Persons._anonymous_methods
{
    public class Mathematician : Scientist, IMathematicianProperties
    {
        private readonly Dictionary<string, OperationDelegate> _operations;
        
        public Mathematician(int computingSpeed, int attention)
        {
            ComputingSpeed = computingSpeed;
            Attention = attention;
            _operations = new Dictionary<string, OperationDelegate>
            {
                { "+", delegate(double x, double y) { return x + y; } },
                { "-", delegate(double x, double y) { return x - y; } },
                { "*", delegate(double x, double y) { return x * y; } },
                { "/", delegate(double x, double y) { return x / y; } }
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
    }
}