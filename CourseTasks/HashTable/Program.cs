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

            HashTable<double> hashTable1 = new HashTable<double>();
            hashTable1.Add(2.3);
            hashTable1.Add(23);
            hashTable1.Add(7);
            hashTable1.Add(6);
            hashTable1.Add(2);
            hashTable1.Add(1);
            Console.WriteLine(hashTable1.Contains(6));

            hashTable.Remove(72);

            hashTable.Clear();
        }
    }
}
