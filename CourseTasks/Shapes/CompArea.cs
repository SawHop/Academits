using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class CompArea<T> : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x.GetArea() < y.GetArea())
            {
                return 1;
            }
            if (x.GetArea() > y.GetArea())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
