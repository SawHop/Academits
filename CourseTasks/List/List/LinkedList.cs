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
        Node<T> head;
        Node<T> tail;
        int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        //Получение длины списка
        public int GetLengthList()
        {
            return Count;
        }

        //Получения первого элемента списка
        public Node<T> GetFirstItem()
        {
            return head;
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
        public Node<T> SetItemByIndex(int indexInLinkeadList, T item)
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
                    var temp = node;
                    node.Data = item;
                    return temp;
                }
                node = node.Next;
            }
            return node;
        }

        //Удаление элемента по индексу
        public Node<T> RemoveItemByIndex(int indexInLinkeadList)
        {
            if (indexInLinkeadList < 0 || indexInLinkeadList >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> current = head;
            Node<T> previous = null;

            for (int i = 0; i < Count; i++)
            {
                if (i == indexInLinkeadList)
                {
                    var temp = current;
                    previous.Next = current.Next;
                    count--;
                    return temp;
                }
                previous = current;
                current = current.Next;
            }
            return current;
        }

        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;

            if (count == 0)
            {
                tail = head;
            }
            count++;
        }

        //Вставка элемента по индексу
        public void AddItemByIndex(int indexInLinkeadList, T item)
        {
            if (indexInLinkeadList < 0 || indexInLinkeadList >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node<T> node = head;
            Node<T> nodeElement = new Node<T>(item);

            if (indexInLinkeadList == 0)
            {
                nodeElement.Next = head;
                head = nodeElement;
            }

            for (int i = 0; i < Count; i++)
            {

                if (i == indexInLinkeadList - 1)
                {
                    nodeElement.Next = node.Next;
                    node.Next = nodeElement;

                    break;
                }
                node = node.Next;
            }
            count++;
        }

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;
            count++;
        }

        //Удаление первого элемента
        public Node<T> RemoveFirstElement()
        {
            while (head != null)
            {
                var temp = head;
                head = head.Next;

                if (head == null)
                {
                    tail = null;
                }
                count--;
                return temp;
            }
            return head;
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
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        //Разворот списка
        public void TurnLinkedList()
        {
            var node = head;

            while (node.Next != null)
            {
                var temp = node.Next;
                node.Next = temp.Next;
                temp.Next = head;
                head = temp;
            }
            tail = node;
        }

        //Копирования листа
        public void CopyLinkeadList()
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
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}