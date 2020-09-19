using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public Stack<string> TheStack { get; set; }

        public StackOfStrings()
        {
            this.TheStack = new Stack<string>();
        }

        public bool IsEmpty()
        {
            return this.TheStack.Count == 0;
        }

        public void AddRange(Stack<string> stackToAdd)
        {
            while (stackToAdd.Count > 0)
            {
                this.TheStack.Push(stackToAdd.Pop());
            }
        }
    }
}
