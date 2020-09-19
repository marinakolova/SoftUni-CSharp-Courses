using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02_Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] collection)
        {
            this.collection = new List<T>(collection);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                this.currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext() => this.currentIndex != this.collection.Count - 1;

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine($"{this.collection[currentIndex]}");
            }
        }

        public void PrintAll()
        {
            if (this.collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine($"{string.Join(" ", this.collection)}");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.HasNext())
            {
                yield return this.collection[currentIndex];
                var temp = this.Move();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}