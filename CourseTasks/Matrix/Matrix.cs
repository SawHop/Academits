using System;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] vectors;

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            vectors = new Vector[rows];

            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] = new Vector(columns);
            }

        }

        public Matrix(Matrix ob)
        {
            Vector[] matrix = new Vector[ob.vectors.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new Vector(ob.vectors[i]);
            }
            this.vectors = matrix;
        }

        public Matrix(double[,] matrix1)
        {
            if (matrix1.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }

            int rows = matrix1.GetLength(0);
            int colums = matrix1.GetLength(1);

            vectors = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                double[] array = new double[colums];

                for (int j = 0; j < colums; j++)
                {
                    array[j] = matrix1[i, j];
                }
                vectors[i] = new Vector(array);
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }

            int maxLength = vectors[0].GetSize();

            for (int i = 1; i < vectors.Length; i++)
            {
                if (maxLength < vectors[i].GetSize())
                {
                    maxLength = vectors[i].GetSize();
                }
            }

            this.vectors = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                this.vectors[i] = new Vector(maxLength);
                this.vectors[i].GetAddition(vectors[i]);
            }
        }

        //Получение длины столбца
        public int GetVerticalRow()
        {
            return vectors.Length;
        }

        //Получение длины строки
        public int GetHorizontalRow()
        {
            return vectors[0].GetSize();
        }

        //Получение вектора строки по индексу
        public Vector GetRow(int index)
        {
            if (index < 0 || index >= vectors.Length)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");

            }
            return new Vector(vectors[index]);
        }

        //Задание вектора по индексу
        public void SetRow(int index, Vector vector)
        {
            if (index <= 0 || vector.GetSize() <= 0 || index >= vectors.Length)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary or vector length <= 0");
            }
            vectors[index] = new Vector(vector);
        }

        //Получение столбца по индексу
        public Vector GetVectorColumn(int index)
        {
            if (index < 0 || index >= vectors.Length)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }

            double[] array = new double[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                array[i] = vectors[i].GetComponent(index);
            }
            return new Vector(array);
        }

        //Умножение матрицы на скаляр
        public void GetMultipliedByScalar(double scalar)
        {
            foreach (Vector e in vectors)
            {
                e.GetMultipliedByScalar(scalar);
            }
        }

        //Транспонирование матрицы
        public void GetTranspose()
        {
            Vector[] matrix1 = new Vector[GetHorizontalRow()];

            for (int i = 0; i < GetHorizontalRow(); i++)
            {
                matrix1[i] = GetVectorColumn(i);
            }
            vectors = matrix1;
        }

        private double GetComponent(int rowIndex, int columnIndex)
        {
            if ((rowIndex > GetHorizontalRow()) || (columnIndex > GetVerticalRow()))
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }
            return vectors[rowIndex].GetComponent(columnIndex);
        }

        private void SetComponent(int rowIndex, int columnIndex, double number)
        {
            if ((rowIndex > GetHorizontalRow()) || (columnIndex > GetVerticalRow()))
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }
            vectors[rowIndex].SetComponent(columnIndex, number);
        }


        //Получение определителя
        public double GetDeterminant()
        {
            if (GetVerticalRow() != GetHorizontalRow())
            {
                throw new ArgumentException("Determinant can't calculated");
            }

            if (vectors.Length == 2)
            {
                return ((GetComponent(0, 0) * GetComponent(1, 1)) - (GetComponent(0, 1) * GetComponent(1, 0)));
            }

            double result = 0;
            for (int i = 0; i < GetVerticalRow(); ++i)
            {
                double[,] vector = new double[GetHorizontalRow() - 1, GetVerticalRow() - 1];
                Matrix matrix1 = new Matrix(vector);

                for (int j = 1; j < vectors.Length; ++j)
                {
                    for (int e = 0; e < GetVerticalRow(); ++e)
                    {
                        if (i > e)
                        {
                            matrix1.SetComponent(j - 1, e, GetComponent(j, e));
                        }
                        else if (i < e)
                        {
                            matrix1.SetComponent(j - 1, e - 1, GetComponent(j, e));
                        }
                    }
                }
                result += Math.Pow(-1, i) * GetComponent(0, i) * matrix1.GetDeterminant();
            }
            return result;
        }

        //Переопределить ToString
        public override string ToString()
        {
            return "{ " + string.Join(", ", (object[])vectors) + " }";
        }

        //Умножение матрицы на вектор
        public Vector GetMultiplied(Vector vector)
        {
            if (vector.GetSize() != GetHorizontalRow())
            {
                throw new ArgumentException("Multiplied by vector can't calculated");
            }

            double result = 0;
            Vector vector1 = new Vector(GetVerticalRow());
            for (int i = 0; i < GetVerticalRow(); ++i)
            {
                result = Vector.GetVectorMultipliedByAnotherVector(vectors[i], vector);
                vector1.SetComponent(i, result);
            }
            return vector1;
        }

        //Сложение матриц
        public Vector[] GetAddition(Matrix matrix1)
        {
            if (GetHorizontalRow() != matrix1.GetHorizontalRow() || GetVerticalRow() != matrix1.GetVerticalRow())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            for (int i = 0; i < GetHorizontalRow(); ++i)
            {
                vectors[i].GetAddition(matrix1.GetRow(i));
            }
            return vectors;
        }

        //Вычитание матриц
        public Vector[] GetDifference(Matrix matrix1)
        {
            if (GetHorizontalRow() != matrix1.GetHorizontalRow() || GetVerticalRow() != matrix1.GetVerticalRow())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            for (int i = 0; i < GetHorizontalRow(); ++i)
            {
                vectors[i].GetDifference(matrix1.GetRow(i));
            }
            return vectors;
        }

        //Статическое сложение матриц
        public static Vector[] GetAdditionMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetHorizontalRow() != matrix1.GetHorizontalRow() || matrix2.GetVerticalRow() != matrix1.GetVerticalRow())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическое вычитание матриц
        public static Vector[] GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetHorizontalRow() != matrix1.GetHorizontalRow() || matrix2.GetVerticalRow() != matrix1.GetVerticalRow())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическая функция умножения матриц
        public static Matrix GetMultipliedMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetHorizontalRow() != matrix1.GetVerticalRow() || matrix2.GetVerticalRow() != matrix1.GetHorizontalRow())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }
            Matrix result = new Matrix(matrix1.GetHorizontalRow(), matrix1.GetVerticalRow());

            for (int i = 0; i < matrix1.GetHorizontalRow(); ++i)
            {
                result.vectors[i] = matrix1.GetMultiplied(matrix2.vectors[i]);
            }
            return result;
        }
    }
}
