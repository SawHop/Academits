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

        public ArrayList(T[] array)
        {
            if (array.Length < 0)
            {
                throw new ArgumentException("Need array length more then 0");
            }
            Count = array.Length;

            T[] copyArray = new T[array.Length];
            Array.Copy(array, copyArray, array.Length);

            this.array = copyArray;
        }

        public ArrayList()
        {
            array = new T[10];
            Count = 10;
        }

        public ArrayList(int capacity)
        {
            array = new T[capacity];
            Count = capacity;
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
                if (value > Count)
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
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Array.Copy(array, index + 1, array, index, Count - index - 1);
            Count--;
        }

        public void Add(T item)
        {
            if (Capacity <= Count)
            {
                IncreaseCapacity();
            }

            array[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
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

            if (index < 0 || index > array.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
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
            T[] copyArray = new T[Count];
            Array.Copy(array, 0, copyArray, 0, Count);

            for (int i = 0; i < Count; i++)
            {
                if (Equals(array[i], copyArray[i]))
                {
                    yield return array[i];
                }
                else
                {
                    throw new NotImplementedException("Array had changed in Enumerator");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
