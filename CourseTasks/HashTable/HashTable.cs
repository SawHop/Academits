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
            if (obj == null)
            {
                return 0;
            }
            return Math.Abs(obj.GetHashCode() % array.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (array[index] == null)
            {
                array[index] = new List<T>() { item };
            }
            else
            {
                array[index].Add(item);
            }

            Count++;
            modChanges++;
        }

        public void Clear()
        {
            int length = array.Length;
            array = new List<T>[length];

            Count = 0;
            modChanges++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (item == null)
            {
                return false;
            }

            if (array[index] != null)
            {
                return array[index].Contains(item);
            }
            else
            {
                return false;
            }
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

            int index = arrayIndex;
            foreach (T element in this)
            {
                array[arrayIndex] = element;
                index++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = modChanges;

            foreach (List<T> list in array)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (T value in list)
                {
                    if (modChanges != modCount)
                    {
                        throw new InvalidOperationException("Collection had changed");
                    }

                    yield return value;
                }
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (item == null)
            {
                return false;
            }

            if (array[index] != null)
            {
                Count--;
                return array[index].Remove(item);
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
