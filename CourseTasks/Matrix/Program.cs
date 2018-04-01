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
            int colums = 4;
            int rows = 3;
            Matrix matrix = new Matrix(colums, rows);

            double[,] vector = new double[,] { { 7, 12, 5 }, { 2, 37, 8 }, { 44, 5, 31 } };
            Matrix matrix2 = new Matrix(vector);

            Matrix matrix1 = new Matrix(matrix2);

            Vector[] vector1 = new Vector[4];
            {
                double[] arrayOfVectors1 = { 21, 17, 33, 3, 6, 9 };
                vector1[0] = new Vector(arrayOfVectors1);

                double[] arrayOfVectors2 = { 2, 3, 5, 7, 9 };
                vector1[1] = new Vector(arrayOfVectors2);

                double[] arrayOfVectors3 = { 6, 3, 15, 67, 23, 21, 88 };
                vector1[2] = new Vector(arrayOfVectors3);

                double[] arrayOfVectors4 = { 7, 23, 21, 88, 33, 41, 2, 3 };
                vector1[3] = new Vector(arrayOfVectors4);
            }
            Matrix matrix3 = new Matrix(vector1);

            Console.WriteLine("Colums=" + matrix2.GetColumns());
            Console.WriteLine("Rows=" + matrix2.GetRow());
            Console.WriteLine();

            Console.WriteLine(matrix2.GetRow(2));

            double[] array = new double[] { 8, 3, 7 };
            Vector vector4 = new Vector(array);
            matrix2.SetRow(2, vector4);

            Console.WriteLine(matrix2.GetVectorColums(2));

            Console.WriteLine(matrix2);
            Console.WriteLine();

            double scalar = 2;
            matrix2.GetMultipliedByScalar(scalar);
            Console.WriteLine("\n");

            matrix2.GetTranspose();

            Console.WriteLine("\n");
            Console.WriteLine("Determinant=" + matrix2.GetDeterminant());

            Vector vector2 = new Vector(array);
            Console.Write("Multiplied matrix by vector=" + matrix2.GetMultiplied(vector2));
            Console.WriteLine("\n");

            double[,] vector3 = new double[,] { { 5, 2, 1 }, { 7, 4, 8 }, { 14, 15, 1 } };
            Matrix matrix5 = new Matrix(vector3);

            Console.Write("Sum of matrix=");
            foreach (var e in matrix2.GetAddition(matrix5))
            {
                Console.Write(e);
            }
            Console.WriteLine("\n");

            Console.Write("Difference of matrix = ");
            foreach (var e in matrix2.GetDifference(matrix5))
            {
                Console.Write(e);
            }
            Console.WriteLine("\n");

            Console.Write("Static sum of matrix=");
            foreach (var e in Matrix.GetAdditionMatrix(matrix2, matrix5))
            {
                Console.Write(e);
            }
            Console.WriteLine("\n");

            Console.Write("Static difference of matrix=");
            foreach (var e in Matrix.GetDifferenceMatrix(matrix2, matrix5))
            {
                Console.Write(e);
            }
            Console.WriteLine("\n");

            Console.Write("Static multiplied matrixs=");
            foreach (var e in Matrix.GetMultipliedMatrix(matrix2, matrix5))
            {
                Console.Write(e);
            }
            Console.Read();
        }
    }
}
