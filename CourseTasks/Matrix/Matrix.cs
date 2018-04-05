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
        public int GetQuantityRows()
        {
            return rows.Length;
        }

        //Получение длины строки
        public int GetQuantityColumns()
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

            if (vector.GetSize() != GetQuantityColumns())
            {
                throw new ArgumentException("");
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
            Vector[] matrix1 = new Vector[GetQuantityColumns()];

            for (int i = 0; i < GetQuantityColumns(); i++)
            {
                matrix1[i] = GetVectorColumn(i);
            }
            rows = matrix1;
        }

        private double GetComponent(int rowIndex, int columnIndex)
        {
            if ((rowIndex > GetQuantityColumns()) || (columnIndex > GetQuantityRows()))
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }
            return rows[rowIndex].GetComponent(columnIndex);
        }

        private void SetComponent(int rowIndex, int columnIndex, double number)
        {
            if ((rowIndex > GetQuantityColumns()) || (columnIndex > GetQuantityRows()))
            {
                throw new IndexOutOfRangeException("Index beyound vector boundary");
            }
            rows[rowIndex].SetComponent(columnIndex, number);
        }


        //Получение определителя
        public double GetDeterminant()
        {
            if (GetQuantityRows() != GetQuantityColumns())
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
            for (int i = 0; i < GetQuantityRows(); ++i)
            {
                double[,] vector = new double[GetQuantityColumns() - 1, GetQuantityRows() - 1];
                Matrix matrix1 = new Matrix(vector);

                for (int j = 1; j < rows.Length; ++j)
                {
                    for (int e = 0; e < GetQuantityRows(); ++e)
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
            return "{ " + string.Join(", ", (object[])rows) + " }";
        }

        //Умножение матрицы на вектор
        public Vector GetMultiplied(Vector vector)
        {
            if (vector.GetSize() != GetQuantityColumns())
            {
                throw new ArgumentException("Multiplied by vector can't calculated");
            }

            Vector vector1 = new Vector(GetQuantityRows());
            for (int i = 0; i < GetQuantityRows(); ++i)
            {
                double result = Vector.GetVectorMultipliedByAnotherVector(rows[i], vector);
                vector1.SetComponent(i, result);
            }
            return vector1;
        }

        //Сложение матриц
        public Vector[] GetAddition(Matrix matrix1)
        {
            if (GetQuantityColumns() != matrix1.GetQuantityColumns() || GetQuantityRows() != matrix1.GetQuantityRows())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            for (int i = 0; i < GetQuantityColumns(); ++i)
            {
                rows[i].GetAddition(matrix1.GetRow(i));
            }
            return rows;
        }

        //Вычитание матриц
        public Vector[] GetDifference(Matrix matrix1)
        {
            if (GetQuantityColumns() != matrix1.GetQuantityColumns() || GetQuantityRows() != matrix1.GetQuantityRows())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            for (int i = 0; i < GetQuantityColumns(); ++i)
            {
                rows[i].GetDifference(matrix1.GetRow(i));
            }
            return rows;
        }

        //Статическое сложение матриц
        public static Vector[] GetAdditionMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetQuantityColumns() != matrix1.GetQuantityColumns() || matrix2.GetQuantityRows() != matrix1.GetQuantityRows())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetAddition(matrix2);
        }

        //Статическое вычитание матриц
        public static Vector[] GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetQuantityColumns() != matrix1.GetQuantityColumns() || matrix2.GetQuantityRows() != matrix1.GetQuantityRows())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1);
            return result.GetDifference(matrix2);
        }

        //Статическая функция умножения матриц
        public static Matrix GetMultipliedMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2.GetQuantityColumns() != matrix1.GetQuantityRows() || matrix2.GetQuantityRows() != matrix1.GetQuantityColumns())
            {
                throw new ArgumentException("Can't calculated matrixs");
            }

            Matrix result = new Matrix(matrix1.GetQuantityColumns(), matrix1.GetQuantityRows());
            //TODO  в проверку get rows

            for (int i = 0; i < matrix1.GetQuantityColumns(); ++i)
            {
                result.rows[i] = matrix2.GetMultiplied(matrix1.rows[i]);
            }
            return result;
        }
    }
}
