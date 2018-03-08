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
            t1.GetLengthOfSideOfTriangle(1, 2, 3, 4);

            Circle c1 = new Circle(4);

            Circle c2 = new Circle(7);

            List<IShape> notSortedObjects = new List<IShape>();

            notSortedObjects.Add(s1);
            notSortedObjects.Add(r1);
            notSortedObjects.Add(t1);
            notSortedObjects.Add(c1);
            notSortedObjects.Add(c2);

            CompInv<IShape> sortedObjects = new CompInv<IShape>();
            notSortedObjects.Sort(sortedObjects);

            CompInv1<IShape> sortedObjects1 = new CompInv1<IShape>();
            notSortedObjects.Sort(sortedObjects1);

            for (int i = 0; i < notSortedObjects.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Max area=" + notSortedObjects[i].GetArea());
                }
                else if (i == 1)
                {
                    Console.WriteLine("Second perimeter=" + notSortedObjects[i].GetPerimeter());
                }
            }
            Console.ReadLine();
        }
    }
}
