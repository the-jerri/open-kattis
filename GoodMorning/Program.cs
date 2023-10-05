using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GoodMorning
{
    internal class Program
    {
        private static readonly Dictionary<int, bool> isValidMemoization = new Dictionary<int, bool>();
        private static readonly Dictionary<char, char[]> validNextDigit = new Dictionary<char, char[]>() {
            { '1', new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }},
            { '2', new[] { '2', '3', '5', '6', '8', '9', '0' }},
            { '3', new[] { '3', '6', '9' }},
            { '4', new[] { '4', '5', '6', '7', '8', '9', '0' }},
            { '5', new[] { '5', '6', '8', '9', '0' }},
            { '6', new[] { '6', '9' }},
            { '7', new[] { '7', '8', '9', '0' }},
            { '8', new[] { '8', '9', '0' }},
            { '9', new[] { '9' }},
            { '0', new[] { '0' }}
        };
        static void Main(string[] args)
        {
            Scanner sc = new();
            int cases = sc.NextInt();
            for (int testIndex = 0; testIndex < cases; testIndex++)
            {
                int caseToTest = sc.NextInt();
                if (CheckIsValid(caseToTest))
                    Console.WriteLine(caseToTest);
                else
                {
                    var numberStepsUp = 0;
                    var closestNumberUp = NumberOfStepsIncr(caseToTest, ref numberStepsUp);
                    var numberStepsDown = 0;
                    var closestNumberDown = NumberOfStepsDecr(caseToTest, ref numberStepsDown);
                    if (numberStepsUp >= numberStepsDown)
                        Console.WriteLine(closestNumberDown);
                    else
                        Console.WriteLine(closestNumberUp);
                }
            }
        }
        public static int NumberOfStepsIncr(int currentNumber, ref int steps)
        {
            if (CheckIsValid(currentNumber))
                return currentNumber;
            ++steps;
            return NumberOfStepsIncr(++currentNumber, ref steps);
        }
        public static int NumberOfStepsDecr(int currentNumber, ref int steps)
        {
            if (CheckIsValid(currentNumber))
                return currentNumber;
            ++steps;
            return NumberOfStepsDecr(--currentNumber, ref steps);
        }
        // Check if the current number is valid, I.E. if every digit 
        public static bool CheckIsValid(int number)
        {
            var isValid = true;
            if (isValidMemoization.ContainsKey(number))
                return isValidMemoization[number];
            if (number > 20)
            {
                var numberAsString = number.ToString();
                for (int i = 0; i < numberAsString.Length - 1; i++)
                    if (validNextDigit[numberAsString[i]].Contains(numberAsString[i + 1]) == false)
                        isValid = false;
            }
            isValidMemoization[number] = isValid;
            return isValid;
        }

        public class Tokenizer
        {
            string[] tokens = Array.Empty<string>();
            private int pos;
            readonly StreamReader reader;

            public Tokenizer()
            {
                reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            }

            private string PeekNext()
            {
                if (pos < 0)
                    return null;
                if (pos < tokens.Length)
                {
                    if (tokens[pos].Length == 0)
                    {
                        ++pos;
                        return PeekNext();
                    }
                    return tokens[pos];
                }
                string line = reader.ReadLine();
                if (line == null)
                {
                    // There is no more data to read
                    pos = -1;
                    return null;
                }
                // Split the line that was read on white space characters
                tokens = line.Split(null);
                pos = 0;
                return PeekNext();
            }

            public bool HasNext()
            {
                return PeekNext() != null;
            }

            public string Next()
            {
                string next = PeekNext() ?? throw new NoMoreTokensException();
                ++pos;
                return next;
            }
        }
        public class NoMoreTokensException : Exception { }
        public class Scanner : Tokenizer
        {
            public int NextInt()
            {
                return int.Parse(Next());
            }

            public long NextLong()
            {
                return long.Parse(Next());
            }

            public float NextFloat()
            {
                return float.Parse(Next());
            }

            public double NextDouble()
            {
                return double.Parse(Next());
            }
        }
    }
}