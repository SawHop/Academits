using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace List
{
    class List<T>
    {
        private T data;
        private List<T> next;

        public List()
        {
        }

        public List(T data)
        {
            this.data = data;
        }

        public List(T data, List<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public T getData()
        {
            return data;
        }

        public void setData(T data)
        {
            this.data = data;
        }

        public List<T> getNext()
        {
            return next;
        }

        public void setNext(List<T> next)
        {
            this.next = next;
        }

    }
}


