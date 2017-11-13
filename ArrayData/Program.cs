using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayData
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            double avrg = array.Average();
            array = array.Where(n => n >= avrg).ToArray();

            string command = Console.ReadLine();
            switch (command)
            {
                case "Min":
                    Console.WriteLine(array.Min());break;
                case "Max":
                    Console.WriteLine(array.Max()); break;
                default:
                    Console.WriteLine(string.Join(" ", array.OrderBy(n => n)));
                    break;
            }
        }
    }
}
