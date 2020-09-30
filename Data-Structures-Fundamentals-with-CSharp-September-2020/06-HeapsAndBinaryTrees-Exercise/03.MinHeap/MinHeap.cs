namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size
            => this._elements.Count;

        public T Dequeue()
        {
            var firstElement = this.Peek();

            this.Swap(0, this.Size - 1);

            this._elements.RemoveAt(this.Size - 1);

            this.HeapifyDown();

            return firstElement;
        }

        public void Add(T element)
        {
            this._elements.Add(element);

            this.HeapifyUp();
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._elements[0];
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Max heap is empty!");
            }
        }

        private void HeapifyUp()
        {
            int currentIndex = this.Size - 1;
            int parentIndex = this.GetParentIndex(currentIndex);

            while (currentIndex > 0
                && this.IsLess(currentIndex, parentIndex))
            {
                this.Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(currentIndex);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = this.GetLeftChildIndex(0);

            while (
                this.IndexIsValid(leftChildIndex)
                && this.IsGreater(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);

                if (this.IndexIsValid(rightChildIndex)
                    && this.IsGreater(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }

                this.Swap(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = this.GetLeftChildIndex(index);
            }
        }

        private bool IsGreater(int firstIndex, int secondIndex)
        {
            return this._elements[firstIndex]
                .CompareTo(this._elements[secondIndex]) > 0;
        }

        private bool IsLess(int firstIndex, int secondIndex)
        {
            return this._elements[firstIndex]
                .CompareTo(this._elements[secondIndex]) < 0;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private bool IndexIsValid(int index)
        {
            return index < this.Size;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = this._elements[firstIndex];
            this._elements[firstIndex] = this._elements[secondIndex];
            this._elements[secondIndex] = temp;
        }
    }
}
