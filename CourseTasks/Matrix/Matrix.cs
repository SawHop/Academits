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

        public Matrix(double[][] matrix)
        {
            if (matrix.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            else
            {
              
            }
        }

        public Matrix(Vector[] matrix)
        {
            if (matrix.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            else
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i] = new Vector(matrix.Length);
                }
                this.matrix = matrix;
            }
        }
    }
}
