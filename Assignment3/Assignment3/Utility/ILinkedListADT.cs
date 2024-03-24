using System;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    public interface ILinkedListADT<T>
    {
        void Prepend(T item);
        void Append(T item);
        void RemoveAtIndex(int index);
        void RemoveFirst();
        void RemoveLast();
        void InsertAtIndex(int index, T item);
        void Replace(int index, T item);
        T GetAtIndex(int index);
        int GetIndex(T item);
        bool Contains(T item);
        void Clear();
        int GetSize();
        void Reverse();
        void Sort();
        T[] ToArray();
        // Redesigned Join method to accept any implementation of ILinkedListADT
        ILinkedListADT<T> Join(ILinkedListADT<T> otherList);
        // Redesigned Divide method to return a custom class/struct
        DividedLists<T> DivideAtIndex(int index);
        int Count();
        T GetValue(int index);

    }

    // Custom class/struct to encapsulate two lists returned by DivideAtIndex method
    public class DividedLists<T>
    {
        public ILinkedListADT<T> FirstPart { get; set; }
        public ILinkedListADT<T> SecondPart { get; set; }

        public DividedLists(ILinkedListADT<T> firstPart, ILinkedListADT<T> secondPart)
        {
            FirstPart = firstPart;
            SecondPart = secondPart;
        }
    }
}