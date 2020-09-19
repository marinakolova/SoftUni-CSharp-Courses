using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ListyIterator
{
    public class ListyIterator<T>
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
    }
}
