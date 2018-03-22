using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CSV
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader objReader = new StreamReader("C:\\Users\\SawHo\\Desktop\\Задание.csv");
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();

                if (sLine != null)
                {
                    arrText.Add(sLine);
                }
            }
            objReader.Close();

            StreamWriter sw = new StreamWriter("C:\\Users\\SawHo\\Desktop\\324.csv");
            sw.WriteLine("<table>");
            sw.WriteLine("\t<tr> ");

            foreach (string e in arrText)
            {
                sw.WriteLine("<td>" + e + "<td>");
            }

            sw.WriteLine("\t<tr> ");
            sw.WriteLine("<table>");

            sw.Close();
            Console.ReadLine();
        }
    }
}
