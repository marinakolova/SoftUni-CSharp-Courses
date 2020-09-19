using System;
using System.Collections.Generic;
using System.Text;

namespace _05_GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> theBox;

        public Box()
        {
            theBox = new List<T>();
        }

        public void Add(T item)
        {
            theBox.Add(item);
        }

        public int Compare(T elementToCompare)
        {
            int count = 0;

            foreach (var item in theBox)
            {
                if (item.CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
