using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Hopper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sc = new Scanner();
            var n = sc.NextInt();
            var D = sc.NextInt();
            var M = sc.NextInt();
            var arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = sc.NextInt();
            int longestExplorationSequence = FindLongestExplorationSequence(n, D, M, arr);
            Console.WriteLine(longestExplorationSequence);
        }

        public static int FindLongestExplorationSequence(int n, int D, int M, int[] arr)
        {
            int[] dp = new int[n];

            for (int i = 0; i < n; ++i)
            {
                // Initialize dp with 1 as each point is a valid path by itself.
                dp[i] = 1;

                // Loop to check each preceding element within index distance 'D'
                for (int j = i - 1; j >= 0 && j >= i - D; --j)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= M)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }

                // Loop to check each succeeding element within index distance 'D'
                for (int j = i + 1; j < n && j <= i + D; ++j)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= M)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            // Find the maximum among all dp values.
            int maxSeq = 0;
            foreach (var x in dp)
            {
                maxSeq = Math.Max(maxSeq, x);
            }

            return maxSeq;
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