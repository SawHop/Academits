using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysList
{
    class ArraysList<T> : IList<T>
    {
        private T[] arrayList;
        private int length = 20;

        public ArraysList(T[] arrayList)
        {
            this.arrayList = arrayList;
            length = arrayList.Length;
        }

        public ArraysList()
        {
            arrayList = new T[length];
        }

        public ArraysList(int lengthInArray)
        {
            arrayList = new T[lengthInArray];
        }

        public int Count
        {
            get
            {
                return arrayList.Length;
            }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= arrayList.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return arrayList[index];
            }

            set
            {
                if (index < 0 || index >= arrayList.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                arrayList[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < arrayList.Length; i++)
            {
                if (Equals(arrayList[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int EnsureCapacity(int capacity)
        {
            if (capacity < 0 || capacity > arrayList.Length)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (capacity < this.length)
            {
                capacity *= capacity;
            }
            return capacity;
        }

        public void TrimToSize()
        {
            if (Count > arrayList.Length)
            {
                T[] old = arrayList;
                arrayList = new T[old.Length];
                Array.Copy(old, 0, arrayList, 0, old.Length);
            }

        }

        private void IncreaseCapacity()
        {
            T[] old = arrayList;
            arrayList = new T[old.Length + 1];
            Array.Copy(old, 0, arrayList, 0, old.Length);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (Count <= length)
            {
                IncreaseCapacity();
            }

            Array.Copy(arrayList, index, arrayList, index + 1, length - index);
            arrayList[index] = item;
            length++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            T[] old = arrayList;
            arrayList = new T[length - 1];

            Array.Copy(old, 0, arrayList, 0, index);
            Array.Copy(old, index + 1, arrayList, index, arrayList.Length - index);

            length--;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null");
            }

            if (Count <= length)
            {
                IncreaseCapacity();
            }

            Array.Copy(arrayList, 0, arrayList, 1, length);
            arrayList[0] = item;
            length++;
        }

        public void Clear()
        {
            Array.Clear(arrayList, 0, length);
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null");
            }

            foreach (T element in arrayList)
            {
                if (Equals(item, element))
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

            if (array.Length <= 0)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (length > array.Length)
            {
                T[] old = array;
                array = new T[length];
                Array.Copy(old, 0, array, 0, old.Length - 1);
            }

            for (int i = index; i < arrayList.Length; i++)
            {
                array[i] = arrayList[i];
            }
            Console.WriteLine("Copy elemnets of list in array=" + ("{ " + string.Join(", ", array) + " }"));
        }

        public bool Remove(T item)
        {
            int startLengthArray = length;
            RemoveAt(IndexOf(item));

            if (startLengthArray != length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in arrayList)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", arrayList) + " }";
        }
    }
}
