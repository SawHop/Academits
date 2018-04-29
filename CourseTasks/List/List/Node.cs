using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Node<T>
    {
        internal Node(T data)
        {
            Data = data;
        }

        internal T Data
        {
            get;
            set;
        }

        internal Node<T> Next
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (Data == null)
            {
                return "null";
            }
            return Data.ToString();
        }
    }
}
