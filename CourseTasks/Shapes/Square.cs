using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Rectangle
    {
        public Square(double width)
            : base(width, 0)
        {

        }

        public override double GetHeight()
        {
            return width;
        }

        public override double GetArea()
        {
            return Math.Pow(width, 2);
        }

        public override double GetPerimeter()
        {
            return (width * 4);
        }

        public override string ToString()
        {
            return "width: " + width;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Square s1 = (Square)obj;
            return (width == s1.width);
        }

        public override int GetHashCode()
        {
            return (int)width ^ (int)height;
        }
    }
}
