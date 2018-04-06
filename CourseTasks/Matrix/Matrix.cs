using System;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] rows;

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }
            this.rows = new Vector[rows];

            for (int i = 0; i < this.rows.Length; i++)
            {
                this.rows[i] = new Vector(columns);
            }
        }

        public Matrix(Matrix ob)
        {
            Vector[] matrix = new Vector[ob.rows.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new Vector(ob.rows[i]);
            }
            this.rows = matrix;
        }

        public Matrix(double[,] matrix1)
        {
            if (matrix1.Length <= 0)
            {
                throw new ArgumentException("Matrix dimension 0");
            }

            int rows = matrix1.GetLength(0);
            int colums = matrix1.GetLength(1);

            this.rows = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                double[] array = new double[colums];

                for (int j = 0; j < colums; j++)
                {
                    array[j] = matrix1[i, j];
                }
                this.rows[i] = new Vector(array);
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

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(maxLength);
                rows[i].GetAddition(vectors[i]);
            }
        }

        //Получение длины столбца
        public int GetRowsCount()
        {
            return rows.Length;
        }

        //Получение длины строки
        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        //Получение вектора строки по индексу
        public Vector GetRow(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");

            }
            return new Vector(rows[index]);
        }

        //Задание вектора по индексу
        public void SetRow(int index, Vector vector)
        {
            if (index <= 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary or vector length <= 0");
            }

            if (vector.GetSize() != GetColumnsCount())
            {
                throw new ArgumentException("Vector must be equal to the length of the string in the matrix");
            }
            rows[index] = new Vector(vector);
        }

        //Получение столбца по индексу
        public Vector GetVectorColumn(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }

            double[] array = new double[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                array[i] = rows[i].GetComponent(index);
            }
            return new Vector(array);
        }

        //Умножение матрицы на скаляр
        public void GetMultipliedByScalar(double scalar)
        {
            foreach (Vector e in rows)
            {
                e.GetMultipliedByScalar(scalar);
            }
        }

        //Транспонирование матрицы
        public void GetTranspose()
        {
            Vector[] matrix1 = new Vector[GetColumnsCount()];

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                matrix1[i] = GetVectorColumn(i);
            }
            rows = matrix1;
        }

        public double GetComponent(int rowIndex, int columnIndex)
        {
            if (rowIndex > GetColumnsCount() || columnIndex > GetRowsCount() || columnIndex < 0 || rowIndex < 0)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }
            return rows[rowIndex].GetComponent(columnIndex);
        }

        public void SetComponent(int rowIndex, int columnIndex, double number)
        {
            if (rowIndex > GetColumnsCount() || columnIndex > GetRowsCount() || columnIndex < 0 || rowIndex < 0)
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }
            rows[rowIndex].SetComponent(columnIndex, number);
        }


        //Получение определителя
        public double GetDeterminant()
        {
            if (GetRowsCount() != GetColumnsCount())
            {
                throw new ArgumentException("Determinant can't calculated");
            }

            if (rows.Length == 1)
            {
                return GetComponent(0, 0);
            }

            if (rows.Length == 2)
            {
                return ((GetComponent(0, 0) * GetComponent(1, 1)) - (GetComponent(0, 1) * GetComponent(1, 0)));
            }

            double result = 0;
            for (int i = 0; i < GetRowsCount(); ++i)
            {
                double[,] vector = new double[GetColumnsCount() - 1, GetRowsCount() - 1];
                Matrix matrix = new Matrix(vector);

                for (int j = 1; j < rows.Length; ++j)
                {
                    for (int e = 0; e < GetRowsCount(); ++e)
                    {
                        if (i > e)
                        {
                            matrix.SetComponent(j - 1, e, GetComponent(j, e));
                        }
                        else if (i < e)
                        {
                            matrix.SetComponent(j - 1, e - 1, GetComponent(j, e));
                        }
                    }
                }
                result += Math.Pow(-1, i) * GetComponent(0, i) * matrix.GetDeterminant();
            }
            return result;
        }

        //Переопределить ToString
        public override string ToString()
        {
            return "{ " + string.Join(", ", (object[])rows) + " }";
        }

        //Умножение матрицы на вектор
        public Vector GetMultiplied(Vector vector)
        {
            if (vector.GetSize() != GetColumnsCount())
            {
                throw new ArgumentException("Multiplied by vector can't calculated");
            }

            Vector row = new Vector(GetRowsCount());
            for (int i = 0; i < GetRowsCount(); ++i)
            {
                double result = Vector.GetVectorMultipliedByAnotherVector(rows[i], vector);
                row.SetComponent(i, result);
            }
            return row;
        }

        //Сложение матриц
        public Vector[] GetAddition(Matrix matrix)
        {
            if (GetColumnsCount() != matrix.GetColumnsCount() || GetRowsCount() != matrix.GetRowsCount())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            for (int i = 0; i < GetColumnsCount(); ++i)
            {
                rows[i].GetAddition(matrix.GetRow(i));
            }
            return rows;
        }

        //Вычитание матриц
        public Vector[] GetDifference(Matrix matrix)
        {
            if (GetColumnsCount() != matrix.GetColumnsCount() || GetRowsCount() != matrix.GetRowsCount())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            for (int i = 0; i < GetColumnsCount(); ++i)
            {
                rows[i].GetDifference(matrix.GetRow(i));
            }
            return rows;
        }

        //Статическое сложение матриц
        public static Vector[] GetAdditionMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetColumnsCount() != matrix1.GetColumnsCount() || matrix2.GetRowsCount() != matrix1.GetRowsCount())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }
            Matrix result = new Matrix(matrix1);
            return result.GetAddition(matrix2);
        }

        //Статическое вычитание матриц
        public static Vector[] GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetColumnsCount() != matrix1.GetColumnsCount() || matrix2.GetRowsCount() != matrix1.GetRowsCount())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }
            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическая функция умножения матриц
        public static Matrix GetMultipliedMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetColumnsCount() != matrix1.GetRowsCount() || matrix2.GetRowsCount() != matrix1.GetColumnsCount())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1.GetColumnsCount(), matrix1.GetRowsCount());
            matrix1.GetTranspose();

            for (int i = 0; i < matrix1.GetColumnsCount(); ++i)
            {
                result.rows[i] = matrix2.GetMultiplied(matrix1.rows[i]);
            }
            result.GetTranspose();
            return result;
        }
    }
}
