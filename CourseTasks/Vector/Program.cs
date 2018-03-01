using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 1, 2, 3, 4 };
            Vector vector = new Vector(array);

            Console.WriteLine(vector.getSize());
            Console.WriteLine(vector.ToString());
        }
    }
}
