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
            List<Person> person = new List<Person>()
            {
              new Person("Ivan", 10),
            new Person("Sergey", 15),
            new Person("Petr", 20),
            new Person("Petr", 25),
            new Person("Ivan", 25)
        };

            person.Distinct().Select(n => n.Name);



            int x = 2;




        }
    }
}
