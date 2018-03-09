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
            if (vector.Length >= vector1.Length)
            {

            }








            return vector1;
        }
    }
}
