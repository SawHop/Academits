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

        public HashTable(T[] array)
        {
            if (array.Length <= 0)
            {
                throw new ArgumentException("Need array length more then 0");
            }
            Count = array.Length;

            List<T>[] copyArray = new List<T>[array.Length];
            Array.Copy(array, copyArray, array.Length);

            this.array = copyArray;
        }

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

        public int GetIndex(object obj)
        {
            return Math.Abs(obj.GetHashCode() % array.Length);
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null");
            }

            if (array[GetIndex(item)] == null)
            {
                array[GetIndex(item)] = new List<T>();
            }
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            return array[GetIndex(item)] != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }

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
            int modCount = Count;

            foreach (T element in this)
            {
                if (Count != modCount)
                {
                    throw new InvalidOperationException("Array had changed in Enumerator");
                }

                yield return element;
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);
            if (array[GetIndex(item)] != null)
            {
                array[index].Remove(item);
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
