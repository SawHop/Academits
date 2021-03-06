﻿using System;
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

            var node = head;

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

        public T GetElementByIndex(int index)
        {
            var node = GetItemByIndex(index);
            return node.Data;
        }

        //Изменение элемента по указанному индексу
        public T SetItemByIndex(int index, T item)
        {
            var node = GetItemByIndex(index);
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
                modChanges++;

                Count--;
                return head.Data;
            }

            var previous = GetItemByIndex(index - 1);
            var current = previous.Next;

            previous.Next = current.Next;

            modChanges++;
            Count--;

            return current.Data;
        }

        // добвление в начало
        public void AddFirst(T data)
        {
            var node = new Node<T>(data);
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
            var nodeElement = new Node<T>(item);

            if (index == 0)
            {
                nodeElement.Next = head;
                head = nodeElement;

                modChanges++;
                Count++;
            }
            else
            {
                var node = GetItemByIndex(index - 1);
                nodeElement.Next = node.Next;
                node.Next = nodeElement;

                modChanges++;
                Count++;
            }
        }

        // добавление элемента
        public void Add(T data)
        {
            AddItemByIndex(Count, data);
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
            var current = head;
            Node<T> previous = null;

            if (Equals(data, current.Data))
            {
                head = head.Next;
                modChanges++;
                Count--;
                return true;
            }

            while (current != null)
            {
                if (Equals(data, current.Data))
                {
                    previous.Next = current.Next;
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
            modChanges++;
        }

        //Копирования листа
        public LinkedList<T> Copy()
        {
            if (Count == 0)
            {
                var linkedList = new LinkedList<T>();
                return linkedList;
            }
            else
            {
                var linkedList = new LinkedList<T>();
                linkedList.head = new Node<T>(head.Data);

                var node = head;
                linkedList.Count++;

                for (int i = 1; i < Count; i++)
                {
                    node = node.Next;
                    var nodeElement = linkedList.GetItemByIndex(i - 1);

                    nodeElement.Next = new Node<T>(node.Data);
                    linkedList.Count++;
                }
                return linkedList;
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

            var current = head;
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