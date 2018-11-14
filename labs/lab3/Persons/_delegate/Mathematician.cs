using System;
using System.Collections.Generic;
using lab1.Kind_of_activity;
using lab3.Interfaces;

namespace lab3.Persons._delegate
{
    public class Mathematician : Scientist, IMathematicianProperties, IMathematicianOperations
    {
        private readonly Dictionary<string, OperationDelegate> _operations;

        public Mathematician(int computingSpeed, int attention)
        {
            ComputingSpeed = computingSpeed;
            Attention = attention;
            _operations = new Dictionary<string, OperationDelegate>
            {
                {"+", DoAddition}, {"-", DoSubtraction}, {"*", DoMultiplication}, {"/", DoDivision}
            };
        }

        public int ComputingSpeed { get; set; }
        public int Attention { get; set; }
        public double DoDivision(double x, double y) => x / y;
        public double DoMultiplication(double x, double y) => x * y;
        public double DoSubtraction(double x, double y) => x - y;
        public double DoAddition(double x, double y) => x + y;

        public double PerformOperation(string op, double x, double y)
        {
            if (!_operations.ContainsKey(op)) throw new ArgumentException($"Operation {op} is invalid!!!");
            return _operations[op](x, y);
        }
    }
}