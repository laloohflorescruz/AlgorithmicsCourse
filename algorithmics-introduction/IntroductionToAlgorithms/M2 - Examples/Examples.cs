using System;
using System.Collections.Generic;

namespace Module2Examples
{
    /// <summary>
    /// This class holds all the code examples from the Module 2 about compexity analysis.
    /// </summary>
    class Examples
    {
        /// <summary>
        /// Performs the number of iterations given by the input parameter.
        /// Complexity: Big-Theta(N)
        /// </summary>
        /// <param name="N">Number of loops</param>
        internal void Loop(int N)
        {
            var counter = 0;
            while(counter < N)
            {
                Console.WriteLine(counter);
                counter = counter + 1;
            }
        }

        /// <summary>
        /// Creates all pairs on the form:
        ///     0, 0
        ///     0, 1
        ///     0, 2
        ///     ...
        ///     N-1, N-1
        /// Complexity: Big-Theta(N*N)
        /// </summary>
        /// <param name="N">Number of different values per coordinate.</param>
        internal void CreateAllPairs(int N)
        {
            var x = 0;
            var y = 0;
            while (x < N)
            {
                while (y < N)
                {
                    Console.WriteLine("{0}, {1}", x, y);
                    y = y + 1;
                }
                x = x + 1;
            }
        }

        /// <summary>
        /// A search algorithm that scans though all items in a list.
        /// Complexity: O(N) where N is the number of elements in the haystack.
        /// </summary>
        /// <param name="needle">Value to look for.</param>
        /// <param name="haystack">The container holding the elements to search.</param>
        /// <returns></returns>
        internal bool ContainsNeedle(int needle, List<int> haystack)
        {
            foreach (var sample in haystack)
            {
                if (sample == needle)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Calculates the faculty of n (n!) which is n * (n-1) * (n-2) * ... * 3 * 2 * 1.
        /// Complexity: Big-Theta(n)
        /// </summary>
        /// <param name="n">Largest factor in the </param>
        /// <returns></returns>
        internal int Faculty(int n)
        {
            if (n == 1)
                return 1;
            return n * Faculty(n - 1);
        }

        /// <summary>
        /// A poorly performing recursive Fibonacci calculator.
        /// Complexity: Big-Theta(2^n)
        /// </summary>
        /// <param name="n">The n'th Fibonacci number to calculate.</param>
        /// <returns></returns>
        internal int Fibonacci(int n)
        {
            if (n <= 1) // throw error if n < 0
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// A much better performing non-recursive Fibonacci calculator.
        /// Complexity: Big-Theta(n)
        /// </summary>
        /// <param name="n">The n'th Fibonacci number to calculate.</param>
        /// <returns></returns>
        internal int Fibonacci2(int n)
        {
            int low = 1;
            int high = 1;
            for (int i = 0; i < n; i++)
            {
                var oldHigh = high;
                high = low + high;
                low = oldHigh;
            }
            return low;
        }

        /// <summary>
        /// A binary search algorithm that works on an ORDERED haystack,
        /// and finds the needle by iteratively cutting away half of the
        /// haystack that does not contain the needle.
        /// Complexity: O(log N) where N is the size of the haystack.
        /// </summary>
        /// <param name="haystack">The container holding the elements to search. Must be sorted.</param>
        /// <param name="needle">The value to search for</param>
        /// <param name="min">Initially, 0</param>
        /// <param name="max">Initially, the size of the haystack</param>
        /// <returns></returns>
        internal int? BinarySearch(List<int> haystack, int needle, int min, int max)
        {
            var midpoint = (max + min) / 2;
            if (haystack.Count > 0 && haystack[midpoint] == needle)
                return midpoint;
            if (min >= max)
                return null;
            if (haystack[midpoint] > needle)
                return BinarySearch(haystack, needle, min, midpoint - 1);
            return BinarySearch(haystack, needle, midpoint + 1, max);
        }

    }
}