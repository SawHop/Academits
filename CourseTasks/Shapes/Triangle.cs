using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Rectangle
    {
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
            : base(x1, y1)
        {
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public override double GetWidth()
        {
            if ((width >= x2) & (width >= x3))
            {
                return width;
            }
            else if ((x3 >= x2) & (width <= x3))
            {
                return x3;
            }
            else
            {
                return x2;
            }
        }

        public override double GetHeight()
        {
            if ((height >= x2) & (height >= x3))
            {
                return height;
            }
            else if ((x3 >= x2) & (height <= x3))
            {
                return y3;
            }
            else
            {
                return y2;
            }
        }

        public override double GetArea()
        {
            return 0.5 * ((width - x3) * (y2 - y3) + (x2 - x3) * (height - y3));
        }

        public double GetLengthOfSideOfTriangle(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public override double GetPerimeter()
        {
            double lengthOfSideOfTriangle = Math.Sqrt(Math.Pow((x2 - width), 2) + Math.Pow((y2 - height), 2));
            double lengthOfSideOfTriangle2 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            double lengthOfSideOfTriangle3 = Math.Sqrt(Math.Pow((x3 - width), 2) + Math.Pow((y3 - height), 2));
            return lengthOfSideOfTriangle + lengthOfSideOfTriangle2 + lengthOfSideOfTriangle3;
        }

        public override string ToString()
        {
            return "x1: " + width + " y1:" + height + "x2: " + x2 + " y2:" + y2 + "x3: " + x3 + " y3:" + y3;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Triangle t1 = (Triangle)obj;
            return (width == t1.width) && (height == t1.height);
        }

        public override int GetHashCode()
        {
            return (int)width ^ (int)height;
        }
    }
}
