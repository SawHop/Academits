using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace List
{
    class List<T>
    {
        private T[] arrayList;
        private int length = 0;

        public List(T[] arrayList)
        {
            this.arrayList = arrayList;
        }

        public int GetSize()
        {
            return length = arrayList.Length;
        }

        public T GetFirstElement()
        {
            return arrayList[0];
        }

        public T GetElement(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            return arrayList[index];
        }

        public T SetElement(int index, T value)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            T element = arrayList[index];
            arrayList[index] = value;

            return element;
        }

        public void AddElementInBegin(T element)
        {
            T[] old = arrayList;
            arrayList = new T[old.Length + 1];

            Array.Copy(old, 0, arrayList, 1, old.Length);
            length++;

            Console.Write("Element at beginning of list=" , arrayList[0] = element);
        }

        public void AddElementByIndex(int index, T element)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            T[] old = arrayList;
            arrayList = new T[old.Length + 1];

            Array.Copy(old, 0, arrayList, 0, length-index+1);
            arrayList[index] = element;

            Array.Copy(old, index, arrayList, index+1, length - index);
            length++;

            Console.WriteLine(arrayList[0] = element);
        }

        public void RemoveElementByIndex(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            T[] old = arrayList;
            arrayList = new T[old.Length - 1];
            T temp = old[index];

            Array.Copy(old, index + 1, old, index, length - index - 1);
            Array.Copy(old, 0, arrayList, 0, old.Length - 1);

            --length;
            Console.WriteLine("RemoveElementByIndex element=" + temp);
        }
    }
}

