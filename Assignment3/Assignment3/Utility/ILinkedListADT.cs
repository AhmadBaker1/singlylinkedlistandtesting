using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
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
        void Join(SLL<T> otherList);
        Tuple<SLL<T>, SLL<T>> DivideAtIndex(int index);
    }

}
