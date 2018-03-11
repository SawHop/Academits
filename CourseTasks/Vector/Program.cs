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
            double[] arrayOfVectors = { 14, 21, 35, 4, 5, 8 };
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

            double[] arrayOfVectors1 = { 21, 17, 33, 41, 2, 3, 6, 9 };

            Console.WriteLine();
            foreach (int e in vector.GetAdditionVectors(arrayOfVectors1))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            foreach (int e in vector.GetDifferenceVectors(arrayOfVectors1))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            double scalar = 3;
            foreach (int e in vector.GetVectorMultipliedByScalar(scalar))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            foreach (int e in vector.GetRotationVector())
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Vector length=" + vector.GetLengthVector());

            Console.WriteLine(vector.GetIndex(2));
            vector.SetIndex(2, 4);

            Console.ReadKey();
        }
    }
}
