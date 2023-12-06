using System;
using System.Collections.Generic;

namespace Module4Examples
{
    class DivideAndConquer
    {
        static Random random = new Random();

        public static List<T> Quicksort<T>(List<T> elements)
             where T : IComparable
        {
            // Just return trivially sized collections:
            if (elements.Count <= 1)
                return elements;

            // Divide phase: pick a random pivot element, and spilt into
            // "smaller than" and "larger than" collections:
            var pivotPosition = random.Next(elements.Count);
            var less = new List<T>();
            var larger = new List<T>();
            for(var i = 0; i < elements.Count; i++)
            {
                if (i == pivotPosition)
                    continue;
                if (elements[i].CompareTo(elements[pivotPosition]) < 0)
                    less.Add(elements[i]);
                else
                    larger.Add(elements[i]);
            }

            // Call recursively, and assemble solution from sub-results:
            var mergedSolution = Quicksort(less);
            mergedSolution.Add(elements[pivotPosition]);
            mergedSolution.AddRange(Quicksort(larger));

            return mergedSolution;
        }
    }
}
