using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : IShape
    {
        private double width;

        public Square(double width)
        {
            this.width = width;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return width;
        }

        public double GetArea()
        {
            return Math.Pow(width, 2);
        }

        public double GetPerimeter()
        {
            return (width * 4);
        }

        public override string ToString()
        {
            return "Square: width:" + width;
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

            Square s1 = (Square)obj;
            return (width == s1.width);
        }

        public override int GetHashCode()
        {
            return (int)width;
        }
    }
}
