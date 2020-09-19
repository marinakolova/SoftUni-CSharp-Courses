namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public DoublyLinkedList()
        {
            this._head = this._tail = null;
            this.Count = 0;
        }

        public DoublyLinkedList(Node<T> head)
        {
            this._head = this._tail = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var nodeToInsert = new Node<T>
            {
                Item = item
            };

            if (this.Count == 0)
            {
                this._head = this._tail = nodeToInsert;
            }
            else
            {
                this._head.Previous = nodeToInsert;
                nodeToInsert.Next = this._head;
                this._head = nodeToInsert;                
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var nodeToInsert = new Node<T>
            {
                Item = item
            };

            if (this.Count == 0)
            {
                this._head = this._tail = nodeToInsert;
            }
            else
            {
                this._tail.Next = nodeToInsert;
                nodeToInsert.Previous = this._tail;
                this._tail = nodeToInsert;                
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this._head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            return this._tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var nodeToRemove = this._head;

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                this._head = this._head.Next;
                this._head.Previous = null;
            }

            this.Count--;
            return nodeToRemove.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            var nodeToRemove = this._tail;

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                this._tail = this._tail.Previous;
                this._tail.Next = null;
            }

            this.Count--;
            return nodeToRemove.Item;
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
                throw new InvalidOperationException("Linked List is empty!");
            }
        }
    }
}