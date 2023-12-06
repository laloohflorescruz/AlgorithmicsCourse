using System;
using System.Collections.Generic;

namespace Module4Examples
{
    public class GraphTraversal<T>
    {
        Action<T, int> visit;
        HashSet<Node<T>> visited;

        public GraphTraversal(Action<T, int> visit)
        {
            this.visit = visit;
        }

        public void DFSRecursive(Node<T> node, int level = 0)
        {
            if (level == 0)
                visited = new HashSet<Node<T>>();

            if (visited.Contains(node))
                return;

            visited.Add(node);

            visit(node.Value, level); // Include visit() here if "preorder"

            foreach (var child in node.Children)
                DFSRecursive(child, level + 1);

            // visit(node.Value, level); // Include visit() here if "postorder"
        }

        public void Preorder(Node<T> node, int level = 0)
        {
            var indent = new String(' ', 3 * level);
            Console.WriteLine(indent + node.Value);

            foreach (var child in node.Children)
                Preorder(child, level + 1);
        }

        public void Postorder(Node<T> node, int level = 0)
        {
            foreach (var child in node.Children)
                Postorder(child, level + 1);

            var indent = new String(' ', 3 * level);
            Console.WriteLine(indent + node.Value);
        }

        public void DFSStack(Node<T> firstNode)
        {
            LinkedList<Tuple<Node<T>, int>> stack = new LinkedList<Tuple<Node<T>, int>>();
            visited = new HashSet<Node<T>>();

            stack.AddLast(new Tuple<Node<T>, int>(firstNode, 0));
            while (stack.Count > 0)
            {
                var latestTuple = stack.Last.Value;
                stack.RemoveLast();
                var node = latestTuple.Item1;
                var level = latestTuple.Item2;

                if (visited.Contains(node))
                    continue;

                visited.Add(node);

                visit(node.Value, level);

                foreach (var child in node.Children)
                    stack.AddLast(new Tuple<Node<T>, int>(child, level + 1));
            }
        }

        public void BFSQueue(Node<T> firstNode)
        {
            LinkedList<Tuple<Node<T>, int>> queue = new LinkedList<Tuple<Node<T>, int>>();
            visited = new HashSet<Node<T>>();

            queue.AddLast(new Tuple<Node<T>, int>(firstNode, 0));
            while (queue.Count > 0)
            {
                var firstTuple = queue.First.Value;
                queue.RemoveFirst();
                var node = firstTuple.Item1;
                var level = firstTuple.Item2;

                if (visited.Contains(node))
                    continue;

                visited.Add(node);

                visit(node.Value, level);

                foreach (var child in node.Children)
                    queue.AddLast(new Tuple<Node<T>, int>(child, level + 1));
            }
        }

    }
}
