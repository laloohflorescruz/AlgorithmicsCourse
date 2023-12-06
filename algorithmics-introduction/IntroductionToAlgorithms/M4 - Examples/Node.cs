using System.Collections.Generic;

namespace Module4Examples
{ 
    /// <summary>
    /// A graph node
    /// </summary>
    /// <typeparam name="T">Type of the node "value"</typeparam>
    public class Node<T>
    {
        T value;
        List<Node<T>> nodes = new List<Node<T>>();

        public Node() { }

        public Node(T value)
        {
            this.value = value;
        }

        public T Value { get { return value; } }

        public void AddChild(Node<T> node)
        {
            nodes.Add(node);
        }

        public IList<Node<T>> Children { get { return nodes; } }
    }
}
