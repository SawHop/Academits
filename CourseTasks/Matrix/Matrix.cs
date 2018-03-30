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

        public Matrix(int rows, int colums)
        {
            if (rows <= 0 || colums <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            matrix = new Vector[rows];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new Vector(colums);
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

            int rows = matrix1.GetLength(0);
            int colums = matrix1.GetLength(1);

            matrix = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                double[] array = new double[colums];

                for (int j = 0; j < colums; j++)
                {
                    array[j] = matrix1[i, j];
                }
                matrix[i] = new Vector(array);
            }
        }

        public Matrix(Vector[] matrix1)
        {
            if (matrix1.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }

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

        //Получение длины столбца
        public int GetColums()
        {
            return matrix.Length;
        }

        //Получение длины строки
        public int GetRow()
        {
            return (int)matrix[0].GetSize();
        }

        //Получение вектора строки по индексу
        public Vector GetRow(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index beyound vector boundary");
            }
            return new Vector(matrix[index]);
        }

        //Задание вектора по индексу
        public void SetRow(int index, Vector vector)
        {
            if (index <= 0 || vector.GetSize() <= 0)
            {
                throw new ArgumentException("Index beyound vector boundary or vector length <= 0");
            }
            matrix[index] = new Vector(vector);
        }

        //Получение столбца по индексу
        public Vector GetVectorColums(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index beyound vector boundary");
            }

            double[] array = new double[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                array[i] = matrix[i].GetComponent(index);
            }
            return new Vector(array);
        }

        //Умножение матрицы на скаляр
        public void GetMultipliedByScalar(double scalar)
        {
            foreach (Vector e in matrix)
            {
                e.GetMultipliedByScalar(scalar);
            }

            Console.Write("Matrix multiplied by scalar=");
            foreach (Vector e in matrix)
            {
                Console.Write(e);
            }
        }

        //Транспонирование матрицы
        public void GetTranspose()
        {
            Vector[] matrix1 = new Vector[GetRow()];

            for (int i = 0; i < GetRow(); i++)
            {
                matrix1[i] = GetVectorColums(i);
            }
            matrix = matrix1;

            Console.Write("Transposed matrix=");
            foreach (var e in matrix)
            {
                Console.Write(e);
            }
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
        public Vector GetMultiplied(Vector vector)
        {
            if (vector.GetSize() != GetRow())
            {
                throw new ArgumentException("Multiplied by vector can't calculated");
            }

            double result = 0;
            Vector vector1 = new Vector(GetColums());
            for (int i = 0; i < GetColums(); ++i)
            {
                result = Vector.GetVectorMultipliedByAnotherVector(matrix[i], vector);
                vector1.SetComponent(i, result);
            }
            return vector1;
        }

        //Сложение матриц
        public Vector[] GetAddition(Matrix matrix1)
        {
            if (GetRow() != matrix1.GetRow() || GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Vector vectro1 = new Vector(GetRow());
            for (int i = 0; i < GetRow(); ++i)
            {
                matrix[i].GetAddition(matrix1.GetRow(i));
            }
            return matrix;
        }

        //Вычитание матриц
        public Vector[] GetDifference(Matrix matrix1)
        {
            if (GetRow() != matrix1.GetRow() || GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Vector vectro1 = new Vector(GetRow());
            for (int i = 0; i < GetRow(); ++i)
            {
                matrix[i].GetDifference(matrix1.GetRow(i));
            }
            return matrix;
        }

        //Статическое сложение матриц
        public static Vector[] GetAdditionMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetRow() != matrix1.GetRow() || matrix2.GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическое вычитание матриц
        public static Vector[] GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetRow() != matrix1.GetRow() || matrix2.GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическая функция умножения матриц
        public static Matrix GetMultipliedMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetRow() != matrix1.GetRow() || matrix2.GetColums() != matrix1.GetColums())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }
            Matrix result = new Matrix(matrix1);


            for (int i = 0; i < matrix1.GetRow(); ++i)
            {
               // result.GetRow(i) = matrix1.GetMultiplied(matrix2.GetRow(i));
            }
            return matrix1;
        }
    }
}
