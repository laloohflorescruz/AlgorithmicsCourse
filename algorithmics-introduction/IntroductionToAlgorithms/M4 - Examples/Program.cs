using System;
using System.Collections.Generic;
using System.Linq;
using static Module4Examples.DynamicProgramming;
using static Module4Examples.GraphTraversalCalculator;

namespace Module4Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTreeTraversals();
            RunTreeCalculation();
            RunDivideAndConquerSort();
            RunDynamicProgrammingFibonacci();
            RunDynamicProgrammingKnapsack();
            RunBranchAndBoundAssignment();

            Console.WriteLine();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        static void RunTreeTraversals()
        {
            var graph = GetGroceryTree();
            var traversal = new GraphTraversal<string>((value, level) => PrintNode(value, level));
            traversal.DFSRecursive(graph);
            //traversal.DFSStack(graph);
            //traversal.BFSQueue(graph);
        }

        static void RunTreeCalculation()
        {
            var minus = new Minus();
            minus.Children.Add(new Value(15));
            minus.Children.Add(new Value(5));
            var plus = new Plus();
            plus.Children.Add(new Value(2));
            plus.Children.Add(new Value(4));
            plus.Children.Add(new Value(3));
            var negate = new Negate();
            negate.Children.Add(plus);
            var plus2 = new Plus();
            plus2.Children.Add(minus);
            plus2.Children.Add(negate);

            var result = plus2.Evaluate();
            Console.WriteLine("(15 - 5) + (-1 * (2 + 4 + 3)) = " + result);
        }

        static void RunDivideAndConquerSort()
        {
            var listToSort = new List<int> { 4, 1, 2, 6, 8, 10, 3, 5 };
            var sortedList = DivideAndConquer.Quicksort(listToSort);
            Console.WriteLine(string.Join(", ", sortedList));
        }

        static void RunDynamicProgrammingFibonacci()
        {
            var n = 80;
            var fibonacci = DynamicProgramming.Fibonacci(n);
            Console.WriteLine("Fibonacci({0}): {1}", n, fibonacci);
        }

        static void RunDynamicProgrammingKnapsack()
        {
            var items = new List<Item>()
            {
                new Item() { Label = "Flashlight", Weight = 2, Value = 3 },
                new Item() { Label = "Book", Weight = 2, Value = 1 },
                new Item() { Label = "Pencil", Weight = 1, Value = 3 }
            };
            var solutionValue = 0;
            var chosenItems = DynamicProgramming.ZeroOneKnapsack(4, items, out solutionValue);
            Console.WriteLine("Knapsack solution: {0}", string.Join(", ", chosenItems.Select(x => x.Label)));
        }

        static void RunBranchAndBoundAssignment()
        {
            var costMatrix = new int[4, 4]
            {
                { 3, 5, 9, 2},
                { 9, 3, 3, 4},
                { 1, 4, 2, 6},
                { 5, 3, 7, 2}
            };

            var solver = new BranchAndBound(costMatrix);
            var solutionCost = 0;
            var assignment = solver.FindAssignment(out solutionCost);

            Console.WriteLine("Assignment cost: {0}", solutionCost);
            for (var agent = 0; agent < assignment.Count; agent++)
                Console.WriteLine("   Agent {0}: Task {1}", agent, assignment[agent]);
        }

        static void PrintNode(string value, int level)
        {
            Console.WriteLine(new String(' ', 3 * level) + value);
        }

        static Node<string> GetGroceryTree()
        {
            var frozen = new Node<string>("frozen");
            frozen.AddChild(new Node<string>("peas"));
            frozen.AddChild(new Node<string>("beans"));
            frozen.AddChild(new Node<string>("spinach"));
            var vegetables = new Node<string>("vegetables");
            vegetables.AddChild(frozen);
            var meat = new Node<string>("meat");
            meat.AddChild(new Node<string>("chicken"));
            meat.AddChild(new Node<string>("beef"));
            var main = new Node<string>("main");
            main.AddChild(meat);
            main.AddChild(vegetables);

            frozen.AddChild(main); // Introduce a "cycle" (even though it is meaningless here)

            return main;
        }
    }
}
