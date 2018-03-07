using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Rectangle
    {
        public Circle(double radius)
            : base(radius, 0)
        {

        }

        public override double GetWidth()
        {
            return width * 2;
        }

        public override double GetHeight()
        {
            return width * 2;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(width, 2);
        }

        public override double GetPerimeter()
        {
            return width * 2 * Math.PI;
        }

        public override string ToString()
        {
            return "Radius: " + width;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Circle c1 = (Circle)obj;
            return (width == c1.width);
        }

        public override int GetHashCode()
        {
            return (int)width ^ (int)height;
        }
    }
}
