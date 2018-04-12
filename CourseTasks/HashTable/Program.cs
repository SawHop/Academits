using System;
using System.Collections;
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
            HashTable<int> hashTable = new HashTable<int>() { 12, 6, 8, 13, 9 };
            hashTable.Add(31);
            hashTable.Add(71);
            hashTable.Add(17);
            hashTable.Add(3);
            hashTable.Add(7);
            hashTable.Add(11);

           Console.WriteLine(hashTable.Contains(7));

            hashTable.Clear();
        }
    }
}
