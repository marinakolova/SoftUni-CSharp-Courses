namespace _02._AA_Tree
{
    using System;
    using System.Runtime.CompilerServices;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        Node<T> root;

        public int CountNodes()
        {
            return this.root != null ? this.root.Count : 0;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            root = Insert(this.root, element);
        }        

        public bool Search(T element)
        {
            return Search(this.root, element);
        }

        // Left Root Right
        public void InOrder(Action<T> action)
        {
            VisitInOrder(this.root, action);
        }

        // Root Left Right
        public void PreOrder(Action<T> action)
        {
            VisitPreOrder(this.root, action);
        }

        // Left Right Root
        public void PostOrder(Action<T> action)
        {
            VisitPostOrder(this.root, action);
        }

        private Node<T> Insert(Node<T> node, T element)
        {
            if (node == null)
            {
                return new Node<T>(element);
            }

            var cmp = element.CompareTo(node.Value);

            if (cmp > 0)
            {
                node.Right = Insert(node.Right, element);
            }
            if (cmp < 0)
            {
                node.Left = Insert(node.Left, element);
            }

            node = Skew(node);
            node = Split(node);

            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
            
            return node;
        }        

        private Node<T> Skew(Node<T> node)
        {
            if (node.Level == node.Left?.Level)
            {
                var temp = node.Left;
                node.Left = temp.Right;
                temp.Right = node;

                node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

                return temp;
            }
            else
            {
                return node;
            }
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Level == node.Right?.Right?.Level)
            {
                var temp = node.Right;
                node.Right = temp.Left;
                temp.Left = node;
                temp.Level = node.Level + 1;

                node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

                return temp;

            }
            else
            {
                return node;
            }
        }

        private int GetCount(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }   

        private bool Search(Node<T> node, T element)
        {
            if (node == null)
            {
                return false;
            }

            var comp = element.CompareTo(node.Value);
            if (comp > 0)
            {
                return Search(node.Right, element);
            }
            if (comp < 0)
            {
                return Search(node.Left, element);
            }

            return true;
        }

        // Left Root Right        
        private void VisitInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            VisitInOrder(node.Left, action);
            action(node.Value);
            VisitInOrder(node.Right, action);
        }

        // Root Left Right
        private void VisitPreOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Value);
            VisitPreOrder(node.Left, action);
            VisitPreOrder(node.Right, action);
        }

        // Left Right Root
        private void VisitPostOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            VisitPostOrder(node.Left, action);
            VisitPostOrder(node.Right, action);
            action(node.Value);
        }
    }
}