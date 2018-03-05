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
            double[] vector = ob.vector;
            this.vector = vector;
        }

        public Vector(double[] vector)
        {
            this.vector = vector;
        }

        public Vector(int n, double[] vector) : this(vector)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Vector dimension 0");
            }
            else
            {
                double[] vector1 = new double[n];

                if (vector.Length < n)
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        vector1[i] = vector[i];
                    }
                    this.vector = vector1;
                }
            }
        }

        public double GetSize()
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

        public override string ToString()
        {
            return string.Join(", ", vector);
        }
    }
}
