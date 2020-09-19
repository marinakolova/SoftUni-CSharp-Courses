using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> TheBox { get; set; }

        public int Count
        {
            get
            {
                return TheBox.Count;
            }
        }

        public Box()
        {
            TheBox = new Stack<T>();
        }

        public void Add(T element)
        {
            TheBox.Push(element);
        }

        public T Remove()
        {
            return TheBox.Pop();
        }
    }
}
