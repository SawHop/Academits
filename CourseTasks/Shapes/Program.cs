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
            Console.WriteLine(r1.ToString());

            List<IShape> notSortedObjects = new List<IShape>();

            notSortedObjects.Add(s1);
            notSortedObjects.Add(r1);
            notSortedObjects.Add(t1);
            notSortedObjects.Add(c1);
            notSortedObjects.Add(c2);

            CompArea sortedObjects = new CompArea();
            notSortedObjects.Sort(sortedObjects);

            CompPerimeter sortedObjects1 = new CompPerimeter();
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
            Console.ReadKey();
        }
    }
}
