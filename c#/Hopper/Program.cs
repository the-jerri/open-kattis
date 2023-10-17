using System;
using System.IO;
using System.Collections.Generic;

namespace Hopper
{
    public class Program
    {
        // Store the graph representation as an adjacency list
        static readonly Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

        public static void Main(string[] args)
        {
            // Initialize scanner for reading input
            var scanner = new Scanner();

            // Read number of elements, max distance, and max difference
            int elementCount = scanner.NextInt();
            int maxDistance = scanner.NextInt();
            int maxDifference = scanner.NextInt();

            // Read and store the array elements
            int[] elements = new int[elementCount];
            for (int i = 0; i < elementCount; i++)
                elements[i] = scanner.NextInt();

            // Find the longest path the hopper can traverse
            int longestPath = FindLongestExplorationSequence(elementCount, maxDistance, maxDifference, elements);

            Console.WriteLine(longestPath);
        }

        /// <summary>
        /// Finds the longest exploration sequence in a given array, constrained by distance and value difference.
        /// </summary>
        /// <param name="elementCount">The number of elements in the array.</param>
        /// <param name="maxDistance">The maximum distance a jump can span in terms of array indices.</param>
        /// <param name="maxDifference">The maximum absolute difference between the values of the elements between which a jump can be made.</param>
        /// <param name="elements">The array of integers to explore.</param>
        /// <returns>The length of the longest sequence that can be explored given the constraints.</returns>

        public static int FindLongestExplorationSequence(int elementCount, int maxDistance, int maxDifference, int[] elements)
        {
            // Build adjacency list based on the constraints
            for (int i = 0; i < elementCount; i++)
            {
                adjacencyList[i] = new List<int>();
                for (int j = i - maxDistance; j <= i + maxDistance; j++)
                {
                    // Check boundaries and difference constraint
                    if (j >= 0 && j < elementCount && i != j && Math.Abs(elements[i] - elements[j]) <= maxDifference)
                    {
                        adjacencyList[i].Add(j);
                    }
                }
            }

            int longestPath = 0;

            // Calculate the longest path for each node
            for (int i = 0; i < elementCount; i++)
            {
                bool[] visited = new bool[elementCount];
                int[] memo = new int[elementCount];

                for (int j = 0; j < elementCount; j++)
                    memo[j] = -1;

                // Update longestPath with the max value found starting from node i
                longestPath = Math.Max(longestPath, DepthFirstSearch(i, memo, visited));
            }

            return longestPath;
        }

        /// <summary>
        /// Conducts a Depth-First Search (DFS) to find the longest path from a given node.
        /// </summary>
        /// <param name="currentNode">The node from which to start the DFS.</param>
        /// <param name="memo">Memoization table to store the longest path starting from each visited node.</param>
        /// <param name="visited">An array to keep track of visited nodes.</param>
        /// <returns>The length of the longest path starting from the current node.</returns>
        private static int DepthFirstSearch(int currentNode, int[] memo, bool[] visited)
        {
            // Return memoized value if present
            if (memo[currentNode] != -1)
                return memo[currentNode];

            // Mark the node as visited
            visited[currentNode] = true;

            int maxPathFromCurrent = 1;

            // Loop through adjacent nodes
            foreach (int neighbor in adjacencyList[currentNode])
            {
                if (!visited[neighbor])
                {
                    // Calculate longest path starting from neighbor and update maxPathFromCurrent
                    maxPathFromCurrent = Math.Max(maxPathFromCurrent, 1 + DepthFirstSearch(neighbor, memo, visited));
                }
            }

            // Mark the node as unvisited before returning to allow for other paths
            visited[currentNode] = false;

            // Memoize the result
            memo[currentNode] = maxPathFromCurrent;

            return maxPathFromCurrent;
        }

        /// <summary>
        /// Tokenizer class responsible for breaking down input into tokens.
        /// </summary>
        public class Tokenizer
        {
            /// <summary>
            /// Stores the tokens for the current line.
            /// </summary>
            private string[] tokens = Array.Empty<string>();

            /// <summary>
            /// Position in the tokens array.
            /// </summary>
            private int pos;

            /// <summary>
            /// Reader to read from the standard input.
            /// </summary>
            private readonly StreamReader reader;

            /// <summary>
            /// Initializes a new instance of the Tokenizer class.
            /// </summary>
            public Tokenizer()
            {
                // Initialize StreamReader with a BufferedStream for better performance.
                reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            }

            /// <summary>
            /// Peeks at the next token without consuming it.
            /// </summary>
            /// <returns>The next token as a string.</returns>
            private string? PeekNext()
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

                // Read a new line from the input
                string? line = reader.ReadLine();
                if (line == null)
                {
                    // No more data to read
                    pos = -1;
                    return null;
                }

                // Tokenize the line based on white spaces
                tokens = line.Split(null);
                pos = 0;

                return PeekNext();
            }

            /// <summary>
            /// Checks if there are any more tokens.
            /// </summary>
            /// <returns>True if there are more tokens, otherwise false.</returns>
            public bool HasNext()
            {
                return PeekNext() != null;
            }

            /// <summary>
            /// Gets the next token and consumes it.
            /// </summary>
            /// <returns>The next token as a string.</returns>
            /// <exception cref="NoMoreTokensException">Thrown when there are no more tokens.</exception>
            public string Next()
            {
                string next = PeekNext() ?? throw new NoMoreTokensException();
                ++pos;
                return next;
            }
        }

        /// <summary>
        /// Exception thrown when there are no more tokens to read.
        /// </summary>
        public class NoMoreTokensException : Exception { }

        /// <summary>
        /// Scanner class derived from Tokenizer for reading specific types.
        /// </summary>
        public class Scanner : Tokenizer
        {
            /// <summary>
            /// Reads the next token and converts it to an integer.
            /// </summary>
            /// <returns>The next token as an integer.</returns>
            public int NextInt()
            {
                return int.Parse(Next());
            }

            /// <summary>
            /// Reads the next token and converts it to a long integer.
            /// </summary>
            /// <returns>The next token as a long integer.</returns>
            public long NextLong()
            {
                return long.Parse(Next());
            }

            /// <summary>
            /// Reads the next token and converts it to a float.
            /// </summary>
            /// <returns>The next token as a float.</returns>
            public float NextFloat()
            {
                return float.Parse(Next());
            }

            /// <summary>
            /// Reads the next token and converts it to a double.
            /// </summary>
            /// <returns>The next token as a double.</returns>
            public double NextDouble()
            {
                return double.Parse(Next());
            }
        }
    }
}