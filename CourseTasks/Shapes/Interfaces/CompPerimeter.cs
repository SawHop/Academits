using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class CompPerimeter : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return y.GetPerimeter().CompareTo(x.GetPerimeter());
        }
    }
}
