using System.Collections;
using System.Collections.Generic;

namespace Donjon
{
    class LimitedList<T> : IEnumerable<T>
    {
        private T[] elements;
        public int Capacity { get; }
        public int Count { get; private set; }

        public LimitedList(int capacity)
        {
            Capacity = capacity;
            elements = new T[capacity];
        }

        public bool Add(T item)
        {
            if (Count >= Capacity) return false;
            elements[Count] = item;
            Count++;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[i];
            }
        }    
    }
}
