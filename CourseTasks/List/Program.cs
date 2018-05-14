using System;
using System.Collections;
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
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Length of a simply connected linked list=" + linkedList.Count());
            Console.WriteLine("First item of a simply connected linked list=" + linkedList.GetFirstItem());
            Console.WriteLine("Getting item by index=" + linkedList.GetElementByIndex(2));
            Console.WriteLine("Setting item by index=" + linkedList.SetItemByIndex(0, null));
            Console.WriteLine("Remove item by index=" + linkedList.RemoveItemByIndex(1));
            linkedList.AddFirst("Timofey");
            linkedList.Turn();

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            linkedList.AddItemByIndex(4, "Arni");
            Console.WriteLine("Remove first element=" + linkedList.RemoveFirstElement());
            Console.WriteLine("Remove element by item=" + linkedList.RemoveByElement("Arni"));
            linkedList.Copy();
        }
    }
}
