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
            if (n == 0)
            {
                throw new IllegalArgumentException("Vector dimension 0");
            }
            for (int i = 0; i < 10; i++)
            {
                n++;
            }
        }

        public Vector(double[] vector)
        {
            this.vector = vector;
        }

        public Vector(Vector ob)
        {
            vector = ob.vector;
        }

        public Vector(int n, double[] vector)
        {
            if (n == 0)
            {
                throw new IllegalArgumentException("n=0");
            }

            for (int i = 0; i < 10; i++)
            {
                n++;
            }

            double[] vector1 = new double[n];

            if (vector.Length < n)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector1[i] = vector[i];
                }
            }
            this.vector = vector1;
        }

        public double getSize()
        {
            double result = vector[vector.Length - 1] - vector[0];
            return result;
        }

        public string ToString()
        {
            return string.Join(", ", vector);
        }
    }
}
