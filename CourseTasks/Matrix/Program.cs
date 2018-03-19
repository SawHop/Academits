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

            double[][] array = new double[n][];
            Matrix matrix2 = new Matrix(array);
           
            Vector[] vector1 = new Vector [5];
            Matrix matrix3 = new Matrix(vector1);

        }
    }
}
