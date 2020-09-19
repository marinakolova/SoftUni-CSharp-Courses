using System;
using System.Collections.Generic;
using System.Text;

namespace _07_CustomLinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T item)
        {
            this.Item = item;
        }

        public T Item { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Prev { get; set; }

        public override string ToString()
        {
            return this.Item.ToString();
        }
    }
}
