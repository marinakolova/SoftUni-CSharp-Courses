using System;
using System.Collections.Generic;
using System.Text;

namespace CreateCustomDataStructures
{
    public class CustomList
    {
        private const int initialCapacity = 2;

        private int[] items;

        public int Count { get; private set; } = 0;

        public CustomList()
        {
            this.items = new int[initialCapacity];
        }

        public CustomList(int size)
        {
            this.items = new int[size];
        }

        public int this[int index]
        {
            get
            {
                CheckIndexRange(index);

                return items[index];
            }
            set
            {
                CheckIndexRange(index);

                items[index] = value;
            }
        }

        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }        

        public int RemoveAt(int index)
        {
            CheckIndexRange(index);

            var item = this.items[index];

            this.items[index] = default(int);
            this.Shift(index);

            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }        

        public void Insert(int index, int element)
        {
            CheckIndexRange(index);

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            bool result = false;

            for (int i = 0; i < this.Count; i++)            
            {
                if (this.items[i] == element)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexRange(firstIndex);
            CheckIndexRange(secondIndex);

            int tempElement = this.items[firstIndex];

            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempElement;
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
        }        

        private void ShiftToRight(int index)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            for (int i = Count - 1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }

            this.items[index] = default;
        }

        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
