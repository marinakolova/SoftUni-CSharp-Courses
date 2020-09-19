using System;
using System.Collections.Generic;
using System.Text;

namespace CreateCustomDataStructures
{
    class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;

        public int Count { get; private set; } = 0;

        public CustomStack()
        {
            this.items = new int[initialCapacity];
        }

        public void Push(int element)
        {
            if (this.items.Length == this.Count)
            {
                Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Peek()
        {
            CheckIfEmpty();

            return this.items[this.Count - 1];
        }

        public int Pop()
        {
            CheckIfEmpty();

            this.Count--;

            int tempElement = this.items[Count];
            this.items[Count] = default;

            return tempElement;
        }

        

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            int[] tempArr = new int[this.items.Length * 2];

            this.items.CopyTo(tempArr, 0);
            this.items = tempArr;
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty.");
            }
        }
    }
}
