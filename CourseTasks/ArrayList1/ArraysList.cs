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
        private T[] arrayList;
        private int length = 0;

        public ArrayList(T[] arrayList)
        {
            this.arrayList = arrayList;
            length = arrayList.Length;
        }

        public ArrayList()
        {
            arrayList = new T[length];
        }

        public ArrayList(int capacity)
        {
            arrayList = new T[capacity];
        }

        public int Count
        {
            get
            {
                return arrayList.Length;
            }
        }

        private void SetCount(int value)
        {
            if (value < 0)
            {
                throw new OverflowException("Count element in list < your numbers");
            }
            arrayList = new T[Count];
            length = value;
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
                return arrayList[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                arrayList[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(arrayList[i], item))
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
                return Count;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Value can't lees then Count");
                }

                T[] old = arrayList;
                arrayList = new T[value];
                Array.Copy(old, arrayList, length);
            }
        }

        public void TrimToSize()
        {
            if (Capacity != Count)
            {
                T[] old = arrayList;
                arrayList = new T[length];
                Array.Copy(old, 0, arrayList, 0, length);
            }

        }

        private void IncreaseCapacity()
        {
            T[] old = arrayList;
            arrayList = new T[old.Length * 2];
            Array.Copy(old, 0, arrayList, 0, old.Length);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= length + 1)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (Count <= length)
            {
                IncreaseCapacity();
            }

            int x = length;

            Array.Copy(arrayList, index, arrayList, index + 1, Count - index - 1);
            arrayList[index] = item;
            length++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            for (int i = 0; i < arrayList.Length - 1; i++)
            {
                if (i >= index)
                {
                    arrayList[i] = arrayList[i + 1];
                }
            }

            length--;
        }

        public void Add(T item)
        {
            if (Count <= length)
            {
                IncreaseCapacity();
            }

            arrayList[length] = item;
            length++;
        }

        public void Clear()
        {
            SetCount(0);
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null");
            }

            for (int i = 0; i < length; i++)
            {
                if (IndexOf(item) == i)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            int x = length;

            if (array.Length <= 0 || index >= length || index < 0)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (length - index > array.Length - index)
            {
                throw new ArgumentException("Index out of range");
            }

            for (int i = index; i < length; i++)
            {
                array[i] = arrayList[i];
            }
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) != -1)
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return arrayList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
