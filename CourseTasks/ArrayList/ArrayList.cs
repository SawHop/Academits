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
            this.array = array;
        }

        public ArrayList()
        {

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
                if (Capacity < Count)
                {
                    throw new ArgumentOutOfRangeException("Value can't lees then Count");
                }

                T[] old = array;
                array = new T[value];
                Array.Copy(old, array, Count);
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
            Count = array.Length;
            Array.Resize(ref array, array.Length * 2);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Capacity)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (index > Count)
            {
                IncreaseCapacity();
            }

            Array.Copy(array, index, array, index + 1, Capacity - index - 1);
            array[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Array.Copy(array, index + 1, array, index, Count - index);
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
            if (IndexOf(item) == -1)
            {
                return false;
            }
            return true;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            int x = Count;

            if (array.Length < 0 || Count < 0 || index < 0)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (index >= Count || Count - index > array.Length - index)
            {
                throw new ArgumentException("Index out of range");
            }

            for (int i = index; i <= Count; i++)
            {
                array[i] = this.array[i];
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
            int CountBeforeEnumerator = Count;
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];

                if(Count!=CountBeforeEnumerator)
                {
                    throw new NotImplementedException("Count changed in Enumerator");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
