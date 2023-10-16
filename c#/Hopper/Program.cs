using System;
using System.IO;
using System.Collections.Generic;

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
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            // Build the graph
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                for (int j = i - D; j <= i + D; j++)
                {
                    if (j >= 0 && j < n && i != j && Math.Abs(arr[i] - arr[j]) <= M)
                    {
                        graph[i].Add(j);
                    }
                }
            }

            int maxPath = 0;

            int DFS(int node, int[] memo, bool[] visited)
            {
                if (memo[node] != -1)
                {
                    return memo[node];
                }

                visited[node] = true;

                int maxLength = 1;

                foreach (int neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        maxLength = Math.Max(maxLength, 1 + DFS(neighbor, memo, visited));
                    }
                }

                visited[node] = false;
                memo[node] = maxLength;

                return maxLength;
            }

            for (int i = 0; i < n; i++)
            {
                bool[] visited = new bool[n];
                int[] memo = new int[n];
                for (int j = 0; j < n; j++)
                {
                    memo[j] = -1;
                }
                maxPath = Math.Max(maxPath, DFS(i, memo, visited));
            }

            return maxPath;
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