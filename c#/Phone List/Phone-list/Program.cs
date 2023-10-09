using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phone_list
{
    public class Program
    {
        static void Main(string[] args)
        {
            Scanner sc = new Scanner();
            var processor = new PhoneListProcessor();
            int testCount = sc.NextInt();
            for (int testIndex = 0; testIndex < testCount; testIndex++)
            {
                int count = sc.NextInt();
                var numbers = Enumerable.Range(0, count).Select(_ => sc.Next());
                bool readToEnd = testIndex + 1 <= testCount;
                bool valid = processor.Process(numbers, readToEnd);
                Console.WriteLine(valid ? "YES" : "NO");
            }
        }
    }
    class PhoneListProcessor
    {
        const int MaxCount = 10000;
        const int MaxDigits = 10;
        Dictionary<int, bool> phoneNumberInfo = new Dictionary<int, bool>(MaxCount * MaxDigits);
        public bool Process(IEnumerable<string> phoneNumbers, bool readToEnd)
        {
            phoneNumberInfo.Clear();
            using (var e = phoneNumbers.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (Process(e.Current)) continue;
                    if (readToEnd)
                    {
                        while (e.MoveNext()) { }
                    }
                    return false;
                }
            }
            return true;
        }
        bool Process(string phoneNumber)
        {
            var phoneNumberInfo = this.phoneNumberInfo;
            int phoneCode = 0;
            int digitPos = 0;
            bool hasSuffix = true;
            while (true)
            {
                phoneCode = 11 * phoneCode + (phoneNumber[digitPos] - '0' + 1);
                bool isLastDigit = ++digitPos >= phoneNumber.Length;
                bool isPhoneNumber;
                if (hasSuffix && phoneNumberInfo.TryGetValue(phoneCode, out isPhoneNumber))
                {
                    if (isPhoneNumber || isLastDigit) return false;
                }
                else
                {
                    try
                    {
                        phoneNumberInfo.Add(phoneCode, isLastDigit);
                    }
                    catch (Exception)
                    {
                        return true;
                    }
                    if (isLastDigit) return true;
                    hasSuffix = false;
                }
            }
        }
    }
    public class NoMoreTokensException : Exception
    {
    }

    public class Tokenizer
    {
        string[] tokens = new string[0];
        private int pos;
        StreamReader reader;

        public Tokenizer(Stream inStream)
        {
            var bs = new BufferedStream(inStream);
            reader = new StreamReader(bs);
        }

        public Tokenizer() : this(Console.OpenStandardInput())
        {
            // Nothing more to do
        }

        private string PeekNext()
        {
            if (pos < 0)
                // pos < 0 indicates that there are no more tokens
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
            return (PeekNext() != null);
        }

        public string Next()
        {
            string next = PeekNext();
            if (next == null)
                throw new NoMoreTokensException();
            ++pos;
            return next;
        }
    }


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
    public class BufferedStdoutWriter : StreamWriter
    {
        public BufferedStdoutWriter() : base(new BufferedStream(Console.OpenStandardOutput()))
        {
        }
    }
}
