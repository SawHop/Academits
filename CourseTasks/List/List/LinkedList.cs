using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace List
{
    class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private int modChanges;

        //Получение длины списка
        public int Count
        {
            get;
            private set;
        }

        //Получения первого элемента списка
        public T GetFirstItem()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty");
            }
            return head.Data;
        }

        //Получение элемента по указанному индексу
        public Node<T> GetItemByIndex(int indexInLinkeadList)
        {
            if (indexInLinkeadList < 0 || indexInLinkeadList >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = head;

            for (int i = 0; i < Count; i++)
            {
                if (i == indexInLinkeadList)
                {
                    break;
                }
                node = node.Next;
            }
            return node;
        }

        //Изменение элемента по указанному индексу
        public T SetItemByIndex(int indexInLinkeadList, T item)
        {
            if (indexInLinkeadList < 0 || indexInLinkeadList >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = GetItemByIndex(indexInLinkeadList);
            var temp = node;
            node.Data = item;

            modChanges++;
            return temp.Data;
        }

        //Удаление элемента по индексу
        public T RemoveItemByIndex(int indexInLinkeadList)
        {
            if (indexInLinkeadList < 0 || indexInLinkeadList >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> previous = GetItemByIndex(indexInLinkeadList - 1);
            Node<T> current = previous.Next;

            var temp = current;
            previous.Next = current.Next;

            modChanges++;
            Count--;

            return temp.Data;
        }

        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;

            modChanges++;
            Count++;
        }

        //Вставка элемента по индексу
        public void AddItemByIndex(int indexInLinkeadList, T item)
        {
            if (indexInLinkeadList < 0 || indexInLinkeadList >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = GetItemByIndex(indexInLinkeadList);
            Node<T> nodeElement = new Node<T>(item);

            if (indexInLinkeadList == 0)
            {
                nodeElement.Next = head;
                head = nodeElement;

                modChanges++;
                Count++;
            }
            else
            {
                nodeElement.Next = node.Next;
                node.Next = nodeElement;

                modChanges++;
                Count++;
            }
        }

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> current = head;

            if (head == null)
            {
                head = node;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (i == Count - 1)
                    {
                        current.Next = node;
                    }
                    current = current.Next;
                }
            }

            modChanges++;
            Count++;
        }

        //Удаление первого элемента
        public T RemoveFirstElement()
        {
            while (head != null)
            {
                var temp = head;
                head = head.Next;

                modChanges++;
                Count--;
                return temp.Data;
            }
            return head.Data;
        }

        // удаление элемента
        public bool RemoveByElement(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }

                    modChanges++;
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        //Разворот списка
        public void Turn()
        {
            var node = head;

            while (node.Next != null)
            {
                var temp = node.Next;
                node.Next = temp.Next;
                temp.Next = head;
                head = temp;
            }
        }

        //Копирования листа
        public void Copy()
        {
            var linkedList = new LinkedList<T>();
            Node<T> node = head;

            for (int i = 0; i < Count; i++)
            {
                linkedList.Add(node.Data);
                node = node.Next;
            }
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = modChanges;

            Node<T> current = head;
            while (current != null)
            {
                if (modChanges != modCount)
                {
                    throw new InvalidOperationException("List had changed in Enumerator");
                }

                yield return current.Data;
                current = current.Next;
            }
        }
    }
}