using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{

    class Vector
    {
        private double[] array;
        int n;

        public int N
        {
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Введите размерность вектора");
                }
                else
                {
                    n = value;
                }
            }
            get { return n; }
        }


        public Vector(int n)
        {
            array = new double[n];
        }

        public Vector(Vector ob)
        {
            Vector vector = ob;
        }

        public Vector(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 5;
            }
        }

        public Vector(int n, double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {

            }
        }
    }
}
