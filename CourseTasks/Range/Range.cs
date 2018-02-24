using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double Length
        {
            get { return To - From; }
        }

        public bool IsInside(double numberInRange)
        {
            return From <= numberInRange && To >= numberInRange;
        }

        public Range GetGeneral(Range r2)
        {
            if ((r2.From >= To) || (From >= r2.To))
            {
                return null;
            }
            else
            {
                if (From >= r2.From && To >= r2.To)
                {
                    return new Range(From, r2.To);
                }
                else if (To <= r2.To && r2.From >= From)
                {
                    return new Range(r2.From, To);
                }
                else if (From <= r2.From && To >= r2.To)
                {
                    return new Range(r2.From, r2.To);
                }
                else
                {
                    return new Range(From, To);
                }
            }
        }

        public Range[] GetArrayOfObject(Range r2)
        {

            int x;
            if ((r2.From >= To) || (From >= r2.To))
            {
                x = 2;
            }
            else
            {
                x = 1;
            }

            Range[] arrayOfRanges = new Range[x];

            if (x == 2)
            {
                Range r = new Range(From, To);
                arrayOfRanges[0] = r;
                arrayOfRanges[1] = r2;
            }
            else
            {
                if (From >= r2.From && To >= r2.To)
                {
                    Range r = new Range(From, r2.To);
                    arrayOfRanges[0] = r;
                }
                else if (To <= r2.To && r2.From >= From)
                {
                    Range r = new Range(r2.From, To);
                    arrayOfRanges[0] = r;
                }
                else if (From <= r2.From && To >= r2.To)
                {
                    Range r = new Range(r2.From, r2.To);
                    arrayOfRanges[0] = r;
                }
                else
                {
                    Range r = new Range(From, To);
                    arrayOfRanges[0] = r;
                }
            }
            return arrayOfRanges;
        }
    }
}
