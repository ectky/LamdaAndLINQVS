using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecryption
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mAndN = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse)
                .Where(n => n >= 65 && n <= 90)
                .Skip(mAndN[0])
                .Take(mAndN[1])
                .ToArray();
            foreach (var num in array)
            {
                Console.Write((char)num);
            }
            Console.WriteLine();
        }
    }
}
