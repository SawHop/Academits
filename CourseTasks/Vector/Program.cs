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
            double[] arrayOfVectors = { 14, 21, 35, 4, 5, 8, 3, 2, 1, 2 };
            int n = 0;
            for (int i = 0; i < arrayOfVectors.Length; i++)
            {
                n++;
            }

            Vector vector = new Vector(arrayOfVectors);
            Vector vector1 = new Vector(vector);
            Vector vector2 = new Vector(n);
            Vector vector3 = new Vector(n, arrayOfVectors);

            Console.WriteLine("Vector size=" + vector1.GetSize());
            Console.WriteLine(vector1.ToString());

            double[] arrayOfVectors1 = { 21, 17, 33, 41, 2, 3, 6, 9 };

            Console.WriteLine();
            foreach (int e in vector.GetAddition(arrayOfVectors1))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            foreach (int e in vector.GetDifference(arrayOfVectors1))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            double scalar = 3;
            foreach (int e in vector.GetMultipliedByScalar(scalar))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            foreach (int e in vector.GetRotation())
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Vector length=" + vector.GetLength());

            Console.WriteLine(vector.GetIndex(2));
            vector.SetIndex(2, 4);

            double[] arrayOfVectors2 = { 14, 21, 35, 4, 5, 8, 3, 2, 1, 2, 2, 5};
            double[] arrayOfVectors3 = { 21, 17, 33, 41, 2, 3, 6, 9, 2, 4, 7, 2, 7 };

            foreach (int e in Vector.GetAdditionVectors(arrayOfVectors2, arrayOfVectors3))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            foreach (int e in Vector.GetDifferenceVectors(arrayOfVectors2, arrayOfVectors3))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            foreach (int e in Vector.GetVectorMultipliedByAnotherVector(arrayOfVectors2, arrayOfVectors3))
            {
                Console.Write(e + " ");
            }

            Console.ReadKey();
        }
    }
}
