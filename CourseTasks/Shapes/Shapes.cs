using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }

    public class Shapes : IShape
    {
        protected double width;
        protected double height;

        public Shapes(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public virtual double GetWidth()
        {
            return width;
        }

        public virtual double GetHeight()
        {
            return height;
        }

        public virtual double GetArea()
        {
            return width * height;
        }

        public virtual double GetPerimeter()
        {
            return (width + height) * 2;
        }
    }

    public class Rectangle : Shapes
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {

        }
    }

    public class Square : Shapes
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
    }

    public class Triangle : Shapes
    {
        protected double x2;
        protected double y2;
        protected double x3;
        protected double y3;

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

        public override double GetPerimeter()
        {
            double lengthOfSideOfTriangle = Math.Sqrt(Math.Pow((x2 - width), 2) + Math.Pow((y2 - height), 2));
            double lengthOfSideOfTriangle2 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            double lengthOfSideOfTriangle3 = Math.Sqrt(Math.Pow((x3 - width), 2) + Math.Pow((y3 - height), 2));
            return lengthOfSideOfTriangle + lengthOfSideOfTriangle2 + lengthOfSideOfTriangle3;
        }
    }

    public class Circle : Shapes
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
    }
}

