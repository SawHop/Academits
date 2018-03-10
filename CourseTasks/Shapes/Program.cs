using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(2, 3);

            Square s1 = new Square(7);

            Triangle t1 = new Triangle(2, 4, 4, 6, 5, 6);

            Circle c1 = new Circle(4);

            Circle c2 = new Circle(7);

            IShape[] notSortedObjects = new IShape[5];

            notSortedObjects[0] = r1;
            notSortedObjects[1] = s1;
            notSortedObjects[2] = t1;
            notSortedObjects[3] = c1;
            notSortedObjects[4] = c1;

            Array.Sort(notSortedObjects, new CompArea());
            Console.WriteLine("Max area=" + notSortedObjects[4].GetArea());

            Array.Sort(notSortedObjects, new CompPerimeter());
            Console.WriteLine("Second perimeter=" + notSortedObjects[3].GetPerimeter());
        }
    }
}
