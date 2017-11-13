using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int k = list.Count() / 4;

            int[] left = list.Take(k).Reverse().ToArray();
            int[] right = list.Skip(3 * k).Take(k).Reverse().ToArray();
            int[] upper = left.Concat(right).ToArray();
            int[] lower = list.Skip(k).Take(2 * k).ToArray();

            for (int i = 0; i < upper.Length; i++)
            {
                upper[i] += lower[i];
            }

            Console.WriteLine(string.Join(" ", upper));
        }
    }
}
