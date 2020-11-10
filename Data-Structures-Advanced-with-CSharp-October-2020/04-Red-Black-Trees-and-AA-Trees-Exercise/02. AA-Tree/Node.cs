namespace _02._AA_Tree
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public Node(T element)
        {
            this.Value = element;
            this.Level = 1;
            this.Count = 1;
        }

        public T Value { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
        public int Level { get; set; }
        public int Count { get; set; }
    }
}