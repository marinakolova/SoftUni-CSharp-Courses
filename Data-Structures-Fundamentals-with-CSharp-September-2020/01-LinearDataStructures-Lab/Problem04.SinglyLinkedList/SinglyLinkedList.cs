namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item)
            {
                Item = item,
                Next = this._head
            };

            this._head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            
            return this._head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var removedNode = this._head;
            this._head = this._head.Next;

            this.Count--;
            return removedNode.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            Node<T> current = this._head;
            Node<T> last = null;

            // Works when there is only 1 element in the list
            if (current.Next == null)
            {
                last = this._head;
                this._head = null;
            }
            else
            {
                while (current != null)
                {
                    // Works when there are more than 1 elements in the list
                    if (current.Next.Next == null)
                    {
                        last = current.Next;
                        current.Next = null;
                        break;
                    }

                    current = current.Next;
                }
            }

            this.Count--;
            return last.Item;
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