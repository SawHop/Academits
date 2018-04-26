using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>();
            hashTable.Add(31);
            hashTable.Add(72);
            hashTable.Add(17);
            hashTable.Add(3);
            hashTable.Add(8);
            hashTable.Add(14);

            Console.Write("HashTable before changes={ ");
            foreach (int element in hashTable)
            {
                Console.Write(element + " ");
            }
            Console.Write(" }");
            Console.WriteLine();

            HashTable<string> hashTable1 = new HashTable<string>();
            hashTable1.Add("a");
            hashTable1.Add("b");
            hashTable1.Add("c");
            hashTable1.Add("de");
            hashTable1.Add("e");

            Console.WriteLine(hashTable1.Contains(null));
            Console.WriteLine(hashTable1.Remove(null));


            hashTable1.Clear();
        }
    }
}
