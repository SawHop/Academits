using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class CompInv<T> : IComparer<T>
         where T : Rectangle
    {
        public int Compare(T x, T y)
        {
            if (x.GetArea() < y.GetArea())
                return 1;
            if (x.GetArea() > y.GetArea())
                return -1;
            else return 0;
        }
    }
}
