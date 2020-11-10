namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;
        private Dictionary<T, Node<T>> elements = new Dictionary<T, Node<T>>();

        public Hierarchy(T root)
        {
            this.root = CreateNode(root);
        }

        public int Count { get => elements.Count; }

        public void Add(T element, T child)
        {
            ContainsItemOrThrowException(element);
            if (elements.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var node = CreateNode(child);
            node.Parent = elements[element];
            elements[element].Children.Add(node);
        }        

        public void Remove(T element)        {
                        
            if (this.root.Value.Equals(element))
            {
                throw new InvalidOperationException();
            }
            ContainsItemOrThrowException(element);

            DestroyElement(element);
        }        

        public IEnumerable<T> GetChildren(T element)
        {
            ContainsItemOrThrowException(element);
            
            return elements[element]
                .Children
                .Select(n => n.Value);
        }

        public T GetParent(T element)
        {
            ContainsItemOrThrowException(element);

            var node = elements[element];

            return node.Parent != null ? node.Parent.Value : default(T);
        }

        public bool Contains(T element)
        {
            return elements.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            foreach (var el in elements)
            {
                if (other.Contains(el.Value.Value))
                {
                    yield return el.Value.Value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(this.root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ContainsItemOrThrowException(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }
        }

        private Node<T> CreateNode(T element)
        {
            var node = new Node<T>(element);
            elements[element] = node;
            return node;
        }

        private void DestroyElement(T element)
        {
            var node = elements[element];
            node.Parent?.Children.Remove(node);

            if (node.Parent != null 
                && node.Children.Count > 0)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node.Parent;
                    node.Parent.Children.Add(child);
                }
            }

            elements.Remove(element);
        }
    }
}