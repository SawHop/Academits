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

        public Matrix(int columns, int rows)
        {
            if (columns <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            else
            {
                Vector[] matrix1 = new Vector[rows];

                for (int i = 0; i < matrix1.Length; i++)
                {
                    matrix1[i] = new Vector(columns);
                }
            }
        }

        public Matrix(Matrix ob)
        {
            Vector[] matrix = new Vector[ob.matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new Vector(ob.matrix[i]);
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
                int colums = matrix1.GetLength(0);
                int rows = matrix1.GetLength(1);

                matrix = new Vector[colums];

                for (int i = 0; i < colums; i++)
                {
                    double[] array = new double[rows];

                    for (int j = 0; j < rows; j++)
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

        //Получение длины столбца
        public double GetColums()
        {
            return matrix.Length;
        }

        //Получение длины строки
        public double GetRows()
        {
            return matrix[0].GetSize();
        }

        //Получение вектора строки по индексу
        public Vector GetVectorRows(int index)
        {
            return new Vector(matrix[index]);
        }

        //Задание вектора по индексу
        public void SetVectorRows(int index, double[] array)
        {
            matrix[index] = new Vector(array);
        }

        //Получение столбца по индексу
        public Vector GetVectorColums(int index)
        {
            double[] array = new double[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                array[i] = matrix[i].GetComponent(index);
            }
            return new Vector(array);
        }

        //Умножение матрицы на скаляр
        public Vector[] GetMultipliedByScalar(double scalar)
        {
            foreach (Vector e in matrix)
            {
                e.GetMultipliedByScalar(scalar);
            }
            return matrix;
        }

        //Транспонирование матрицы
        public Vector[] GetTranspose()
        {
            double rows = (int)GetRows();
            Vector[] matrix1 = new Vector[(int)rows];

            for (int i = 0; i < rows; i++)
            {
                matrix1[i] = GetVectorColums(i);
            }
            return matrix1;
        }

        //Получение определителя
        /* public double GetDeterminant()
         {
             if (GetColums() != GetRows())
             {
                 throw new ArgumentException("Determinant can't calculated");
             }
             else
             {

                 return 2;
             }
         }*/

        //Переопределить ToString
        public override string ToString()
        {
            return "{ " + string.Join(", ", (object[])matrix) + " }";
        }

        //Умножение матрицы на вектор
        public double GetMultiplied(Vector vector)
        {

            if (vector.GetSize() != GetRows())
            {
                throw new ArgumentException("Multiplied by vector can't calculated");
            }

            double result = 0;
            int rows = (int)GetRows();
            Vector vectro1 = new Vector(rows);
            for (int i = 0; i < rows; ++i)
            {
                result += Vector.GetVectorMultipliedByAnotherVector(matrix[i], vector);
            }
            return result;
        }

        //Сложение матриц
        public Vector[] GetAddition(Matrix matrix1)
        {
            if (GetRows() != matrix1.GetRows() && GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            int rows = (int)GetRows();
            Vector vectro1 = new Vector(rows);
            for (int i = 0; i < rows; ++i)
            {
                matrix[i].GetAddition(matrix1.GetVectorRows(i));
            }
            return matrix;
        }

        //Вычитание матриц
        public Vector[] GetDifference(Matrix matrix1)
        {
            if (GetRows() != matrix1.GetRows() && GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            int rows = (int)GetRows();
            Vector vectro1 = new Vector(rows);
            for (int i = 0; i < rows; ++i)
            {
                matrix[i].GetDifference(matrix1.GetVectorRows(i));
            }
            return matrix;
        }

        //Статическое сложение матриц
        public static Vector[] GetAdditionMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetRows() != matrix1.GetRows() && matrix2.GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическое вычитание матриц
        public static Vector[] GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetRows() != matrix1.GetRows() && matrix2.GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическая функция умножения матриц
        public static double GetMultipliedMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetRows() != matrix1.GetRows() && matrix2.GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            double result = 0;
            int rows = (int)matrix1.GetRows();

            for (int i = 0; i < rows; ++i)
            {
                result += matrix1.GetMultiplied(matrix2.GetVectorRows(i));
            }
            return result;
        }
    }
}
