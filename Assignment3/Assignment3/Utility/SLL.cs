using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(SLL<User>))]
    public class SLL<T> : ILinkedListADT<T>
    {
        private Node<T> head;
        private int size;

        // Implement the methods defined in the ILinkedListADT interface here
        // You can refer to the previous C# implementation provided in my previous message

        // Example method implementation:
        public void Prepend(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void Append(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node<T> prev = null;
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    prev = current;
                    current = current.Next;
                }
                prev.Next = current.Next;
            }
            size--;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node<T> prev = null;
                Node<T> current = head;
                while (current.Next != null)
                {
                    prev = current;
                    current = current.Next;
                }
                prev.Next = null;
            }
            size--;
        }

        public void InsertAtIndex(int index, T item)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (index == 0)
            {
                Prepend(item);
            }
            else if (index == size)
            {
                Append(item);
            }
            else
            {
                Node<T> newNode = new Node<T>(item);
                Node<T> prev = null;
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    prev = current;
                    current = current.Next;
                }
                newNode.Next = current;
                prev.Next = newNode;
                size++;
            }
        }

        public void Replace(int index, T item)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = item;
        }

        public T GetAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int GetIndex(T item)
        {
            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            throw new InvalidOperationException("Item not found");
        }

        public bool Contains(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public int GetSize()
        {
            return size;
        }

        public void Reverse()
        {
            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        public void Sort()
        {
            throw new NotImplementedException(); // Placeholder for sorting implementation
        }

        public T[] ToArray()
        {
            T[] array = new T[size];
            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }

        public ILinkedListADT<T> Join(ILinkedListADT<T> otherList)
        {
            // Create a new linked list to store the joined list
            SLL<T> joinedList = new SLL<T>();

            // Add elements from the current list
            Node<T> current = head;
            while (current != null)
            {
                joinedList.Append(current.Data);
                current = current.Next;
            }

            // Add elements from the other list
            current = ((SLL<T>)otherList).head;
            while (current != null)
            {
                joinedList.Append(current.Data);
                current = current.Next;
            }

            return joinedList;
        }

        public DividedLists<T> DivideAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            SLL<T> firstPart = new SLL<T>();
            SLL<T> secondPart = new SLL<T>();

            Node<T> current = head;
            int count = 0;
            while (current != null)
            {
                if (count < index)
                {
                    firstPart.Append(current.Data);
                }
                else
                {
                    secondPart.Append(current.Data);
                }
                current = current.Next;
                count++;
            }

            return new DividedLists<T>(firstPart, secondPart);
        }
        public T GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int Count()
        {
            return size;
        }

    }
}
