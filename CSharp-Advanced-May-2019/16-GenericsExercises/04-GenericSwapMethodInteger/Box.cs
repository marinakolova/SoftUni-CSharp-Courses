using System;
using System.Collections.Generic;
using System.Text;

namespace _04_GenericSwapMethodInteger
{
    public class Box<T>
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

        public void Swap(int firstIndex, int secondIndex)
        {
            var firsElement = theBox[firstIndex];
            var secondElement = theBox[secondIndex];

            theBox[secondIndex] = firsElement;
            theBox[firstIndex] = secondElement;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in theBox)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString();
        }
    }
}
