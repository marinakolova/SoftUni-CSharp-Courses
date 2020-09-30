namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            // Create copy from root

            this.Copy(root);
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value 
            => this.Root.Value;

        public int Count 
            => this.Root.Count;

        public bool Contains(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            // Check if first added element is the root
            // Find where to add element (while)
            // If element exists return            

            var toInsert = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                var current = this.Root;
                Node<T> previous = null;

                while (current != null)
                {
                    current.Count++;
                    previous = current;
                    if (this.IsLess(element, current.Value))
                    {
                        current = current.LeftChild;
                    }
                    else if (this.IsGreater(element, current.Value))
                    {
                        current = current.RightChild;
                    }
                    else
                    {
                        return;
                    }
                }

                if (this.IsLess(element, previous.Value))
                {
                    previous.LeftChild = toInsert;

                    if (this.LeftChild == null)
                    {
                        this.LeftChild = toInsert;
                    }
                }
                else
                {
                    previous.RightChild = toInsert;

                    if (this.RightChild == null)
                    {
                        this.RightChild = toInsert;
                    }
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null && !this.AreEqual(element, current.Value))
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderDfs(this.Root, action);
        }        

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();
            var nodes = new Queue<Node<T>>();

            nodes.Enqueue(this.Root);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                if (this.IsLess(lower, current.Value)
                    && this.IsGreater(upper, current.Value))
                {
                    result.Add(current.Value);
                }
                else if (this.AreEqual(lower, current.Value)
                    || this.AreEqual(upper, current.Value))
                {
                    result.Add(current.Value);
                }

                if (current.LeftChild != null)
                {
                    nodes.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    nodes.Enqueue(current.RightChild);
                }
            }

            return result;
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
            
            var current = this.Root;
            Node<T> previous = null;

            if (this.Root.LeftChild == null)
            {
                this.Root = this.Root.RightChild;
            }
            else
            {
                while (current.LeftChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.LeftChild;
                }

                previous.LeftChild = current.RightChild;
            }
        }

        public void DeleteMax()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("Collection is empty!");
            }

            var current = this.Root;
            Node<T> previous = null;

            if (this.Root.RightChild == null)
            {
                this.Root = this.Root.LeftChild;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.RightChild;
                }

                previous.RightChild = current.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return this.GetRankDfs(this.Root, element);
        }        

        private bool IsLess(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) < 0;
        }

        private bool IsGreater(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) > 0;
        }

        private bool AreEqual(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) == 0;
        }

        private void Copy(Node<T> root)
        {
            // Copies Element in Pre Order

            if (root != null)
            {
                this.Insert(root.Value);
                this.Copy(root.LeftChild);
                this.Copy(root.RightChild);
            }
        }

        private void EachInOrderDfs(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                this.EachInOrderDfs(current.LeftChild, action);
                action.Invoke(current.Value);
                this.EachInOrderDfs(current.RightChild, action);
            }
        }

        private int GetRankDfs(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (this.IsLess(element, current.Value))
            {
                return this.GetRankDfs(current.LeftChild, element);
            }
            else if (this.AreEqual(element, current.Value))
            {
                return GetNodeCount(current);
            }

            return 
                GetNodeCount(current.LeftChild) 
                + 1 
                + this.GetRankDfs(current.RightChild, element);
        }

        private int GetNodeCount(Node<T> current)
        {
            return current == null ? 0 : current.Count;
        }
    }
}
