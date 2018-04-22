using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var ivan = new Person("Ivan", 10);
            var sergey = new Person("Sergey", 15);
            var petr = new Person("Petr", 20);
            var timofey = new Person("Timofey", 20);

            var person = new[] { ivan, sergey, petr, timofey };
            person.Distinct(p => p.Name);





        }
    }
}
