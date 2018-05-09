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
            new Person("Ivan", 30)
        };

            var sortedListByName = person.Select(n => n.Name).Distinct().ToList();
            sortedListByName.ForEach(n => Console.Write(n + ","));
            Console.WriteLine();

            var sortedListByAge = person.Select(n => n.Age).Where(n => n < 18).ToList();
            Console.WriteLine(sortedListByAge.Average());

            var sortedListByAge1 = person.Where(n => n.Age >= 20 && n.Age < 45).OrderByDescending(n => n.Age).ToList();
            sortedListByAge1.ForEach(n => Console.WriteLine(n.Name));

            Dictionary<string, double> personsByAgeAndName = person.GroupBy(p => p.Name, p => p.Age).ToDictionary(p => p.Key, p => p.Average());
        }
    }
}
