using System;
using System.Collections.Generic;

namespace Symmetric_Order
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line;
            var input = new List<string>();
            while ((line = Console.ReadLine()) != null)
                input.Add(line);
            var set = 1;
            for (int i = 0; i < input.Count; i++)
            {
                int c;
                do
                {
                    c = int.Parse(input[i++]);
                    var sortedArray = new string[c + 1];
                    if (c != 0)
                        sortedArray[0] = "SET " + set++;
                    int k = 1;
                    int l = 0;
                    for (int j = 1; j <= c; j++)
                    {
                        var namn = input[i++];
                        if (j % 2 != 0)
                            sortedArray[k++] = namn;
                        else
                            sortedArray[c - l++] = namn;
                    }
                    foreach (var item in sortedArray)
                    {
                        Console.WriteLine(item);
                    }
                } while (c != 0);
            }
        }
    }
}