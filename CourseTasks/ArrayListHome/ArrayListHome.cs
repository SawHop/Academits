using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            // Прочитать все строки из файла
            StreamReader objReader = new StreamReader("C:\\Users\\SawHo\\Desktop\\Задание.csv");
            string sLine = "";

            List<string> line = new List<string>();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();

                if (sLine != null)
                {
                    line.Add(sLine);
                }
            }
            objReader.Close();

            //Удалить из списка все четные числа
            List<int> numbers = new List<int>() { 4, 7, 2, 1, 9, 5, 4, 8, 2, 9 };

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine("{ " + string.Join(", ", numbers) + " }");

            //Создать новый список, где будут элементы первого списка в таком же порядке, но без повторений
            List<int> naturalNumbers = new List<int>() { 4, 7, 2, 1, 9, 5, 4, 8, 2, 9 };
            List<int> naturalNumbers1 = new List<int>();

            for (int i = 0; i < naturalNumbers.Count; i++)
            {
                if (naturalNumbers.Contains(naturalNumbers[i]))
                {
                    naturalNumbers1.Add(naturalNumbers[i]);
                }
            }
            Console.WriteLine("{ " + string.Join(", ", naturalNumbers1) + " }");
            Console.ReadLine();
        }
    }
}
