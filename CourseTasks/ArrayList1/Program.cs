using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArraysList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 5, 7, 2, 12, 75 };
            ArraysList<int> list = new ArraysList<int>(array);
            Console.WriteLine("List before changes=" + list);

            list.Add(13);
            Console.WriteLine("Add element in beginig list=" + list);

            list.Insert(3, 17);
            Console.WriteLine("Add element in list by index=" + list);

            list.RemoveAt(2);
            Console.WriteLine("Remove element in list by index=" + list);

            int[] arrayTest = new int[] { 5, 9, 1, 5, 2 };
            list.CopyTo(arrayTest, 2);

            list.Remove(2);
            Console.WriteLine("Remove element in list" + list);

            list.Clear();
            Console.ReadLine();
        }
    }
}
