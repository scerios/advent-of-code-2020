using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day_7
{
    public class Node<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();

        public Node(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public void AddChildren(List<Node<T>> nodes) => Children.AddRange(nodes);
    }
}
