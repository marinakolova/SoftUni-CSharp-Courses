namespace _01.BSTOperations
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public int Count { get; set; }

        public Node(T value, Node<T> leftChild, Node<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            this.Count = 1;

            if (this.LeftChild != null)
            {
                this.Count++;
            }

            if (this.RightChild != null)
            {
                this.Count++;
            }
        }
    }
}
