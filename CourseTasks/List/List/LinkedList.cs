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

        public LinkedList(int count)
        {
            Count = count;
        }

        public LinkedList()
        {
        }

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
        private Node<T> GetItemByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = head;

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    break;
                }
                node = node.Next;
            }
            return node;
        }

        public T GetItemByIndexPublic(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = head;

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    break;
                }
                node = node.Next;
            }
            return node.Data;
        }

        //Изменение элемента по указанному индексу
        public T SetItemByIndex(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = GetItemByIndex(index);
            var temp = node.Data;
            node.Data = item;

            modChanges++;
            return temp;
        }

        //Удаление элемента по индексу
        public T RemoveItemByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (index == 0)
            {
                head = head.Next;
                Count--;
                return head.Data;
            }

            Node<T> previous = GetItemByIndex(index - 1);
            Node<T> current = previous.Next;

            var temp = current;
            previous.Next = current.Next;

            modChanges++;
            Count--;

            return temp.Data;
        }

        // добвление в начало
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;

            modChanges++;
            Count++;
        }

        //Вставка элемента по индексу
        public void AddItemByIndex(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Node<T> nodeElement = new Node<T>(item);

            if (index == 0)
            {
                nodeElement.Next = head;
                head = nodeElement;

                modChanges++;
                Count++;
            }
            else
            {
                Node<T> node = GetItemByIndex(index - 1);
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
                Node<T> previous = GetItemByIndex(Count - 1);
                previous.Next = node;
            }
            modChanges++;
            Count++;
        }

        //Удаление первого элемента
        public T RemoveFirstElement()
        {
            if (head == null)
            {
                throw new ArgumentNullException("List is empty");
            }
            var temp = head;
            head = head.Next;

            modChanges++;
            Count--;
            return temp.Data;

        }

        // удаление элемента
        public bool RemoveByElement(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (current.Data.Equals(data))
            {
                modChanges++;
                Count--;
                return true;
            }

            if (data == null)
            {
                while (current != null)
                {
                    if (current.Data == null)
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

        //Изменение элемента по указанному индексу
        private Node<T> SetItemByIndexForCopy(int index, Node<T> item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (head == null)
            {
                head = item;
            }
            Node<T> node = head;

            modChanges++;
            return node;
        }

        //Копирования листа
        public void Copy()
        {
            var linkedList = new LinkedList<T>(Count);
            Node<T> node = head;

            linkedList.SetItemByIndexForCopy(0, node);
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