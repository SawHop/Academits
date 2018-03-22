using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrayOfVectors = { 21, 17, 33, 41, 2, 3, 6, 9 };
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

            double[] arrayOfVectors1 = { 21, 17, 33, 41, 2, 3, 6, 9 };
            Vector vector4 = new Vector(arrayOfVectors1);
            Console.WriteLine("Equals=" + vector1.Equals(vector4));

            Console.WriteLine("Sum of vectors=" + vector1.GetAddition(vector4));
            Console.WriteLine("Difference of vecrotrs=" + vector.GetDifference(vector4));

            double scalar = 3;
            Console.WriteLine("Vector multiplied by scalar=" + vector.GetMultipliedByScalar(scalar));

            Console.WriteLine("Vector rotation=" + vector.GetRotation());
            Console.WriteLine("Vector length=" + vector.GetLength());

            Console.WriteLine(vector.GetComponent(2));
            vector.SetComponent(2, 4);

            Console.WriteLine("123123123adsasdasd"+vector1);
            Console.WriteLine("Static sum of vectors=" + Vector.GetAdditionVectors(vector1, vector4));
            Console.WriteLine("Static difference of vecrotrs=" + Vector.GetDifferenceVectors(vector1, vector4));
            Console.WriteLine("Scalar multiplied of vectors=" + Vector.GetVectorMultipliedByAnotherVector(vector1, vector4));
            Console.Read();
        }
    }
}
