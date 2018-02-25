using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range r1 = new Range(23, 32);

            double numberInRange = 8;
            r1.IsInside(numberInRange);

            Range r2 = new Range(28, 35);

            if (r1.GetGeneral(r2) != null)
            {
                Range r3;
                r3 = r1.GetGeneral(r2);
                Console.WriteLine("General Interval:" + " " + r3.From + " " + r3.To);
            }
            else
            {
                Console.WriteLine("Null");
            }

            Range[] arrayResult;
            arrayResult = r1.GetConcatenationOfIntervals(r2);

            for (int i = 0; i < arrayResult.Length; i++)
            {
                Console.WriteLine("Begin: " + arrayResult[i].From + " End: " + arrayResult[i].To);
            }

        }
    }
}
