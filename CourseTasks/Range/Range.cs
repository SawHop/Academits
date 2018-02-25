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

        public Range[] GetConcatenationOfIntervals(Range r2)
        {
            if ((r2.From > To) || (From > r2.To))
            {
                Range[] arrayOfRanges = new Range[2];

                arrayOfRanges[0] = new Range(From, To);

                Range r3 = (Range)r2.MemberwiseClone();
                arrayOfRanges[1] = r3;

                return arrayOfRanges;
            }
            else
            {
                Range[] arrayOfRanges = new Range[1];

                if (From >= r2.From && To >= r2.To)
                {
                    arrayOfRanges[0] = new Range(From, r2.To);

                }
                else if (To <= r2.To && r2.From >= From)
                {
                    arrayOfRanges[0] = new Range(r2.From, To);
                }
                else if (From <= r2.From && To >= r2.To)
                {
                    arrayOfRanges[0] = new Range(r2.From, r2.To);
                }
                else if ((r2.From >= To) || (From >= r2.To))
                {
                    arrayOfRanges[0] = new Range(r2.From, To);
                }
                else if (From >= r2.To)
                {
                    arrayOfRanges[0] = new Range(From, r2.To);
                }
                else
                {
                    arrayOfRanges[0] = new Range(From, To);
                }
                return arrayOfRanges;
            }
        }
    }
}
