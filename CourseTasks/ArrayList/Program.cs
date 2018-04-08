using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 5, 7, 2, 12, 75 };
            ArrayList<int> list = new ArrayList<int>(array);

            Console.Write("List before changes={ ");
            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");
            Console.WriteLine();

            list.Insert(6, 33);
            Console.Write("Add element in list by index={ ");

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");
            Console.WriteLine();

            list.Add(13);
            Console.Write("Add element in end list={ ");

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");
            Console.WriteLine();

            list.RemoveAt(7);
            Console.Write("Remove element in list by index={ ");

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");
            Console.WriteLine();


            int[] arrayTest = new int[] { 5, 9, 1, 5, 2, 9, 10, 41 };
            list.CopyTo(arrayTest, 5);

            list.Remove(2);
            Console.Write("Remove element in list={ ");

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");
            Console.WriteLine();

            list.Clear();
            Console.Write("Clear list={ ");

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");

            Console.ReadLine();
        }
    }
}
