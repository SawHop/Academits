using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrayOfVectors = { 14, 21, 35, 4 };
            int n = 0;
            for (int i = 0; i < arrayOfVectors.Length; i++)
            {
                n++;
            }

            Vector vector = new Vector(arrayOfVectors);
            Vector vector1 = new Vector(vector);
            Vector vector2 = new Vector(n);
            Vector vector3 = new Vector(n, arrayOfVectors);

            Console.WriteLine("Vector size=" + vector1.GetVectorSize());
            Console.WriteLine(vector1.ToString());

            double[] arrayOfVectors1 = { 21, 17, 33, 41 };
            arrayOfVectors.GetSumVectors(arrayOfVectors1);
        }
    }
}
