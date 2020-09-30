namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;            

            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstList = new List<BinaryTree<T>>();
            var secondList = new List<BinaryTree<T>>();

            this.FindNodeDfs(this, first, firstList);
            this.FindNodeDfs(this, second, secondList);

            var firstNode = firstList[0];
            var secondNode = secondList[0];

            T parentToLookFor = firstNode.Parent.Value;

            while (!parentToLookFor.Equals(firstNode.Value)
                || !parentToLookFor.Equals(secondNode.Value))
            {
                if (!parentToLookFor.Equals(firstNode.Value))
                {
                    firstNode = firstNode.Parent;
                }

                if (!parentToLookFor.Equals(secondNode.Value))
                {
                    secondNode = secondNode.Parent;
                }
            }

            return firstNode.Value;
        }

        private void FindNodeDfs(
            BinaryTree<T> current, 
            T lookupValue,
            List<BinaryTree<T>> list)
        {
            if (current == null)
            {
                return;
            }

            if (current.Value.Equals(lookupValue))
            {
                list.Add(current);
                return;
            }

            this.FindNodeDfs(current.LeftChild, lookupValue, list);
            this.FindNodeDfs(current.RightChild, lookupValue, list);
        }
    }
}
