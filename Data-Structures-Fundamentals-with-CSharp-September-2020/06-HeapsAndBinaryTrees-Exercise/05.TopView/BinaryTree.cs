namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var topView = new List<T>();

            topView.Add(this.Value);
            this.GetAllLeftChildren(topView);
            this.GetAllRightChildren(topView);

            return topView;
        }

        private void GetAllLeftChildren(List<T> list)
        {
            var current = this;

            while (current.LeftChild != null)
            {
                list.Add(current.LeftChild.Value);
                current = current.LeftChild;
            }
        }

        private void GetAllRightChildren(List<T> list)
        {
            var current = this;

            while (current.RightChild != null)
            {
                list.Add(current.RightChild.Value);
                current = current.RightChild;
            }
        }
    }
}
