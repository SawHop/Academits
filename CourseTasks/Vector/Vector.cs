using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{

    class Vector
    {
        private double[] vector;
        private int n;

        public Vector(int n)
        {
            n = 3;
        }

        public Vector(Vector ob)
        {
            Vector object1 = ob;
        }

        public Vector(double[] vector)
        {
            this.vector = vector;
        }

        public Vector(int n, double[] vector)
        {
            // TODO проверку n > 0
            /*
            try
            {
                for (int i = 0; i < n; i++)
                {
                    vector[i] = i;
                }
            }
            catch (IllegalArgumentException n) when (n <= 0)
            {
               
            }
            */


        }
        public double getSize()
        {
            double result = vector[n] - vector[0];
            return result;
        }

        public string ToString()
        {
            return string.Join(", ", vector);
        }
    }
}
