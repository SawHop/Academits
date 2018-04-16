using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;
        private int modChanges;

        public HashTable()
        {
            array = new List<T>[10];
        }

        public HashTable(int capacity)
        {
            array = new List<T>[capacity];
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly => false;

        private int GetIndex(object obj)
        {
            return Math.Abs(obj.GetHashCode() % array.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (array[index] == null)
            {
                array[index] = new List<T>() { item };
            }

            Count++;
            modChanges++;
        }

        public void Clear()
        {
            int counter = 0;

            foreach (List<T> element in array)
            {
                array[counter] = null;
                counter++;
            }

            Count = 0;
            modChanges++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item should not be null");
            }

            return array[GetIndex(item)].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the source this.array is greater than the available space from Index to the end of the destination array");
            }

            foreach (T element in this)
            {
                array[arrayIndex] = element;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = modChanges;

            foreach (List<T> element in array)
            {
                if (element == null)
                {
                    continue;
                }

                foreach (T array in element)
                {
                    if (modChanges != modCount)
                    {
                        throw new InvalidOperationException("Array had changed in Enumerator");
                    }

                    yield return array;
                }
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item should not be null");
            }

            int index = GetIndex(item);
            List<T> temp = new List<T> { item };
    
            if (array[index] == temp)
            {
                array[index].Remove(item);
                Count--;
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
