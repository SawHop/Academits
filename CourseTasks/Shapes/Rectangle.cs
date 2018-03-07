﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IShape
    {
        protected double width;
        protected double height;

        public Rectangle(double width, double height)
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

        public override string ToString()
        {
            return "width: " + width + " height:" + height;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Rectangle r1 = (Rectangle)obj;
            return (width == r1.width) && (height == r1.height);
        }

        public override int GetHashCode()
        {
            return (int)width ^ (int)height;
        }
    }
}