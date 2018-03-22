using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] matrix;
        private int n;
        private int m;

        public Matrix(int n, int m)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            else
            {
                Vector[] matrix1 = new Vector[m];

                for (int i = 0; i < matrix1.Length; i++)
                {
                    matrix1[i] = new Vector(n);
                }
                this.matrix = matrix1;
            }
        }

        public Matrix(Matrix ob)
        {
            Vector[] matrix = new Vector[ob.matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new Vector(ob.matrix.Length);
            }
            this.matrix = matrix;
        }

        public Matrix(double[,] matrix1)
        {
            if (matrix1.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            else
            {
                this.n = matrix1.GetLength(0);
                this.m = matrix1.GetLength(1);
                matrix = new Vector[n];

                for (int i = 0; i < n; i++)
                {
                    double[] array = new double[m];

                    for (int j = 0; j < m; j++)
                    {
                        array[j] = matrix1[i, j];
                    }
                    matrix[i] = new Vector(array);
                }
            }
        }

        public Matrix(Vector[] matrix1)
        {
            if (matrix1.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            else
            {
                int count = 0;
                foreach (Vector e in matrix1)
                {
                    count++;
                    matrix = new Vector[count];
                }

                for (int i = 0; i < matrix1.Length; i++)
                {
                    matrix[i] = matrix1[i];
                }
            }
        }

        public double[] GetSize()
        {
            double[] matrix1 = new double[2] { n, m };
            return matrix1;
        }

        public Vector GetVector1(int index)
        {
            Vector vector = new Vector(matrix.Length);
            return vector = matrix[index];
        }

        public void SetVector2(int index, double[] array)
        {
            matrix[index] = new Vector(array);
        }

        public Vector GetVector3(int index)
        {
            Vector vector = new Vector(matrix.Length);
            return vector = matrix[index];
        }

        /*public override string ToString()
        {
            return "{ " + string.Join("{ ", matrix, " }") + " }";
        }*/

        public Vector[] GetMultipliedByScalar1(double scalar)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = matrix[i].GetMultipliedByScalar(scalar);
            }
            return matrix;
        }

    }
}
