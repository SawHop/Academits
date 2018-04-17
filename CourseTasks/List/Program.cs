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
            Hashtable myHT = new Hashtable();
            myHT.Add("one", "The");
            myHT.Add("two", "quick");
            myHT.Add("three", "brown");
            myHT.Add("four", "fox");
            myHT.Add("five", "jumped");

            myHT.Clear();
        }
    }
}
