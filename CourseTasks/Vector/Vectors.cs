using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    public class Vector
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
            else if (vector.Length > n)
            {
                this.vector = new double[n];
                Array.Copy(vector, this.vector, n);
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

        public Vector GetAddition(Vector vector1)
        {
            if (vector1.vector.Length > vector.Length)
            {
                double[] array = new double[vector1.vector.Length];
                Array.Copy(vector, array, vector.Length);

                vector = array;
            }

            int length = Math.Min(vector.Length, vector1.vector.Length);
            for (int i = 0; i < length; i++)
            {
                vector[i] += vector1.vector[i];
            }
            return this;
        }

        public Vector GetDifference(Vector vector1)
        {
            if (vector1.vector.Length > vector.Length)
            {
                double[] array = new double[vector1.vector.Length];
                Array.Copy(vector, array, vector.Length);

                vector = array;
            }

            int length = Math.Min(vector.Length, vector1.vector.Length);
            for (int i = 0; i < length; i++)
            {
                vector[i] -= vector1.vector[i];
            }
            return this;
        }

        public Vector GetMultipliedByScalar(double scalar)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] * scalar;
            }
            return this;
        }


        public Vector GetRotation()
        {
            return GetMultipliedByScalar(-1);
        }

        public double GetLength()
        {
            double result = 0;
            foreach (int e in vector)
            {
                result += Math.Pow(e, 2);

            }
            return Math.Sqrt(result);
        }

        public double GetComponent(int index)
        {
            return vector[index];
        }

        public void SetComponent(int index, double value)
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
            if (vector1.vector.Length != vector.Length)
            {
                return false;
            }
            for (int i = 0; i < vector.Length; ++i)
            {
                if (vector1.vector[i] != vector[i])
                {
                    return false;
                }
            }
            return true;
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

        public static Vector GetAdditionVectors(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            return result.GetAddition(vector2);
        }

        public static Vector GetDifferenceVectors(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            return result.GetDifference(vector2);
        }

        public static double GetVectorMultipliedByAnotherVector(Vector vector1, Vector vector2)
        {
            double result = 0;
            int length = Math.Min(vector1.vector.Length, vector2.vector.Length);

            for (int i = 0; i < length; i++)
            {
                result += vector1.vector[i] * vector2.vector[i];
            }
            return result;
        }
    }
}
