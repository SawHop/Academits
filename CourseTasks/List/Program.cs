using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 5, 7, 2, 12, 75 };
            List<int> list = new List<int>(array);

            Console.WriteLine("List size=" + list.GetSize());
            Console.WriteLine("First element in list=" + list.GetFirstElement());

            int index = 4;
            Console.WriteLine(list.GetElement(index));
            Console.WriteLine(list.SetElement(index, 17));

            list.AddElementInBegin(26);
            list.AddElementByIndex(index, 13);
            list.RemoveElementByIndex(index);
        }
    }
}
