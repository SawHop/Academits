using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x3, x1), x2) - Math.Min(Math.Min(x3, x1), x2);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y3, y1), y2) - Math.Min(Math.Min(y3, y1), y2);
        }

        public double GetArea()
        {
            return 0.5 * ((x1 - x3) * (y2 - y3) + (x2 - x3) * (y1 - y3));
        }

        private double GetLengthOfSideOfTriangle(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public double GetPerimeter()
        {
            double lengthOfSideOfTriangle = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double lengthOfSideOfTriangle2 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            double lengthOfSideOfTriangle3 = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
            return lengthOfSideOfTriangle + lengthOfSideOfTriangle2 + lengthOfSideOfTriangle3;
        }

        public override string ToString()
        {
            return "Triangle" + "x1: " + x1 + " y1:" + y1 + "x2: " + x2 + " y2:" + y2 + "x3: " + x3 + " y3:" + y3;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Triangle t1 = (Triangle)obj;
            return (x1 == t1.x1) && (y1 == t1.y1) && (x2 == t1.x2) && (y2 == t1.y2) && (x3 == t1.x3) && (y3 == t1.y3);
        }

        public override int GetHashCode()
        {
            return (int)x1 ^ (int)y1 ^ (int)x2 ^ (int)y2 ^ (int)x3 ^ (int)y3;
        }
    }
}
