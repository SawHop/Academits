using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 4;
            int n = 5;
            Matrix matrix = new Matrix(n, m);
            Matrix matrix1 = new Matrix(matrix);

            double[,] vector = new double[4, 3] { { 7, 12, 5 }, { 2, 37, 8 }, { 44, 5, 31 }, { 7, 11, 17 } };
            Matrix matrix2 = new Matrix(vector);

            Vector[] vector1 = new Vector[2];
            {
                double[] arrayOfVectors1 = { 21, 17, 33, 41, 2, 3, 6, 9 };
                vector1[0] = new Vector(arrayOfVectors1);
                double[] arrayOfVectors2 = { 2, 3, 5, 7, 9 };
                vector1[1] = new Vector(arrayOfVectors2);
            }
            Matrix matrix3 = new Matrix(vector1);

            Console.Write("Matrix size=");
            foreach (int e in matrix2.GetSize())
            {
                Console.Write(e + ",");
            }
            Console.WriteLine();

            Console.WriteLine(matrix2.GetVector1(2));

            double[] array = new double[] { 1, 2, 3, 4 };
            matrix2.SetVector2(2, array);

            Console.WriteLine(matrix2.GetVector3(2));

            Console.WriteLine(matrix2);

            double scalar = 2;
            Console.WriteLine("Matrix multiplied by scalar=" + matrix2.GetMultipliedByScalar1(scalar));
        }
    }
}
