namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Transactions;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }

        public Queue(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }
        
        public void Enqueue(T item)
        {
            var nodeToInsert = new Node<T>(item);

            if (this._head == null)
            {
                this._head = nodeToInsert;
            }
            else
            {
                var current = this._head;
                
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = nodeToInsert;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var removedNode = this._head;
            this._head = this._head.Next;

            this.Count--;
            return removedNode.Item;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._head.Item;
        }

        public bool Contains(T item)
        {
            this.EnsureNotEmpty();

            var current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}