using System;
using System.Collections.Generic;

namespace Module2Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var examples = new Examples();

            // Executing the Fibonacci method:
            for(int i=0; i<50; i += 5)
                Console.WriteLine(examples.Fibonacci2(i));

            // Executing a binary search:
            var haystack = new List<int> { 2, 4, 4, 5, 7, 10, 23, 25, 64 };
            var pos = examples.BinarySearch(haystack, 64, 0, haystack.Count - 1);
            Console.WriteLine(pos == null ? "not found" : "Found at position: " + pos);
            Console.ReadLine();
        }
    }
}
