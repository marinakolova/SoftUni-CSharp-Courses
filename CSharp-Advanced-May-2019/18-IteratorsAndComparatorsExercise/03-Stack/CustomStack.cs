using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> theStack;

        public CustomStack()
        {
            this.theStack = new List<T>();
        }

        public void Push(params T[] elements)
        {
            foreach (var item in elements)
            {
                this.theStack.Add(item);
            }
        }

        public void Pop()
        {
            if (this.theStack.Count == 0)
            {
                Console.WriteLine("No elements");
            }

            else
            {
                this.theStack.RemoveAt(this.theStack.Count - 1);
            }
        }        

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.theStack.Count - 1; i >= 0; i--)
            {
                yield return this.theStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
