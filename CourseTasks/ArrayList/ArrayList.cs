using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] array;
        private int modChanges;

        public ArrayList(T[] array)
        {
            Count = array.Length;

            T[] copyArray = new T[array.Length];
            Array.Copy(array, copyArray, array.Length);

            this.array = copyArray;
        }

        public ArrayList()
        {
            array = new T[10];
        }

        public ArrayList(int capacity)
        {
            array = new T[capacity];
        }


        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return array[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                array[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(array[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Capacity
        {
            get
            {
                return array.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Value can't lees then Count");
                }

                Array.Resize(ref array, Count);
            }
        }

        public void TrimToSize()
        {
            if (Capacity != Count)
            {
                Array.Resize(ref array, Count);
            }

        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Capacity)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(array, index, array, index + 1, Count - index);
            array[index] = item;
            Count++;
            modChanges++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Array.Copy(array, index + 1, array, index, Count - index - 1);
            Count--;
            modChanges++;
        }

        public void Add(T item)
        {
            if (Capacity <= Count)
            {
                IncreaseCapacity();
            }

            array[Count] = item;
            Count++;
            modChanges++;
        }

        public void Clear()
        {
            Count = 0;
            modChanges++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }

            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (Count > array.Length - index)
            {
                throw new ArgumentException("The number of elements in the source this.array is greater than the available space from Index to the end of the destination array");
            }

            for (int i = index, j = 0; j < Count; i++, j++)
            {
                array[i] = this.array[j];
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = modChanges;

            for (int i = 0; i < Count; i++)
            {
                if (modChanges != modCount)
                {
                    throw new InvalidOperationException("Array had changed in Enumerator");
                }

                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
