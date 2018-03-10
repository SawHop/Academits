using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private double[] vector;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Vector dimension 0");
            }
            else
            {
                double[] vector = new double[n];
                this.vector = vector;
            }
        }

        public Vector(Vector ob)
        {
            //TODO Конструктор копирования
            //TODO Проверка
            Vector ob1 = new Vector(1);
            ob1 = new Vector(ob.vector);
            this.vector = ob1.vector;
        }

        public Vector(double[] vector)
        {
            if (vector.Length <= 0)
            {
                throw new ArgumentException("Vector dimension 0");
            }
            else
            {
                this.vector = vector;
            }
        }

        public Vector(int n, double[] vector) : this(vector)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Vector dimension 0");
            }
            else
            {
                this.vector = new double[n];
                if (vector.Length < n)
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        this.vector[i] = vector[i];
                    }
                }
            }
        }

        public double GetVectorSize()
        {
            double result = 0;
            foreach (int e in vector)
            {
                result++;
            }
            return result;
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", vector) + " }";
        }

        public double[] GetSumVectors(double[] vector1)
        {
            double[] result;
            if (vector.Length > vector1.Length)
            {
                result = new double[vector.Length];
                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = vector1[i];
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    result[i] = result[i] + vector[i];
                }
            }
            else if (vector.Length < vector1.Length)
            {
                result = new double[vector1.Length];
                for (int i = 0; i < vector.Length; i++)
                {
                    result[i] = vector[i];
                }

                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = result[i] + vector1[i];
                }
            }
            else
            {
                result = new double[vector1.Length];
                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = vector[i] + vector1[i];
                }
            }
            return result;
        }

        public double[] GetDifferenceVectors(double[] vector1)
        {
            double[] result;
            if (vector.Length > vector1.Length)
            {
                result = new double[vector.Length];
                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = vector1[i];
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    result[i] = result[i] - vector[i];
                }
            }
            else if (vector.Length < vector1.Length)
            {
                result = new double[vector1.Length];
                for (int i = 0; i < vector.Length; i++)
                {
                    result[i] = vector[i];
                }

                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = result[i] - vector1[i];
                }
            }
            else
            {
                result = new double[vector1.Length];
                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = vector[i] - vector1[i];
                }
            }
            return result;
        }

        public double[] GetVectorMultipliedByScalar(double scalar)
        {
            double[] result = new double[vector.Length];

            for (int i = 0; i < vector.Length; i++)
            {
                result[i] = vector[i] * scalar;
            }
            return result;
        }


        public double[] GetRotationVector()
        {
            double[] result = new double[vector.Length];

            for (int i = 0; i < vector.Length; i++)
            {
                result[i] = vector[i] * -1;
            }
            return result;
        }

        public double GetLengthVector()
        {
            double result = 0;
            double sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum = Math.Pow(vector[i], 2);
                result += sum;
            }
            return Math.Sqrt(result);
        }
    }
}
