using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Threeuple
{
    public class Threeuple<T, V, W>
    {
        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public W Item3 { get; set; }

        public Threeuple(T item1, V item2, W item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
