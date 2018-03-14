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
            double[] vector = new double[ob.vector.Length];
            Array.Copy(ob.vector, vector, ob.vector.Length);
            this.vector = vector;
        }

        public Vector(double[] vector)
        {
            if (vector.Length <= 0)
            {
                throw new ArgumentException("Vector dimension 0");
            }
            else
            {
                double[] vector1 = new double[vector.Length];
                Array.Copy(vector, vector1, vector.Length);
                this.vector = vector1;
            }
        }

        public Vector(int n, double[] vector)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Vector dimension 0");
            }
            else
            {
                this.vector = new double[n];
                Array.Copy(vector, this.vector, vector.Length);
            }
        }

        public double GetSize()
        {
            return vector.Length;
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", vector) + " }";
        }

        public double[] GetAddition(double[] vector1)
        {
            if (vector.Length >= vector1.Length)
            {
                for (int i = 0; i < vector1.Length; i++)
                {
                    vector[i] = vector[i] + vector1[i];
                }
                return vector;
            }
            else
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector1[i] = vector[i] + vector1[i];
                }
                return vector1;
            }
        }

        public double[] GetDifference(double[] vector1)
        {
            if (vector.Length >= vector1.Length)
            {
                for (int i = 0; i < vector1.Length; i++)
                {
                    vector[i] = vector[i] - vector1[i];
                }
                return vector;
            }
            else
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector1[i] = vector[i] - vector1[i];
                }
                return vector1;
            }
        }

        public double[] GetMultipliedByScalar(double scalar)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] * scalar;
            }
            return vector;
        }


        public double[] GetRotation()
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] * -1;
            }
            return vector;
        }

        public double GetLength()
        {
            double result = 0;
            foreach (int e in vector)
            {
                result = Math.Pow(e, 2) + result;

            }
            return Math.Sqrt(result);
        }

        public double GetIndex(int index)
        {
            return vector[index];
        }

        public void SetIndex(int index, double value)
        {
            vector[index] = value;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Vector vector1 = (Vector)obj;
            return (vector == vector1.vector);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            foreach (double e in vector)
            {
                hash = prime * hash + (int)e;
            }
            return hash;
        }

        public static double[] GetAdditionVectors(double[] vector, double[] vector1)
        {
            double[] result;
            if (vector.Length >= vector1.Length)
            {
                result = new double[vector.Length];
                Array.Copy(vector1, result, vector1.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = vector[i] + result[i];
                }
            }
            else
            {
                result = new double[vector1.Length];
                Array.Copy(vector, result, vector.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = result[i] + vector1[i];
                }
            }
            return result;
        }

        public static double[] GetDifferenceVectors(double[] vector, double[] vector1)
        {
            double[] result;
            if (vector.Length >= vector1.Length)
            {
                result = new double[vector.Length];
                Array.Copy(vector1, result, vector1.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = vector[i] - result[i];
                }
            }
            else
            {
                result = new double[vector1.Length];
                Array.Copy(vector, result, vector.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = result[i] - vector1[i];
                }
            }
            return result;
        }

        public static double[] GetVectorMultipliedByAnotherVector(double[] vector, double[] vector1)
        {
            double[] result = new double[vector1.Length];
            if (vector.Length >= vector1.Length)
            {
                result = new double[vector.Length];
                for (int i = 0; i < vector1.Length; i++)
                {
                    result[i] = vector[i] * vector1[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    result[i] = vector[i] * vector1[i];
                }
            }
            return result;
        }
    }
}
