using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetWidth()
        {
            return radius * 2;
        }

        public double GetHeight()
        {
            return radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetPerimeter()
        {
            return radius * 2 * Math.PI;
        }

        public override string ToString()
        {
            return "Circle: Radius:" + radius;
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
            Circle c1 = (Circle)obj;
            return (radius == c1.radius);
        }

        public override int GetHashCode()
        {
            return (int)radius;
        }
    }
}
