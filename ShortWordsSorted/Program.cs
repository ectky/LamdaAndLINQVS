using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = ".,:;()[]\"'\\/!? ".ToCharArray();
            List<string> list = Console.ReadLine().ToLower()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            list = list.Where(w => w.Length < 5).OrderBy(w => w).Distinct().ToList();
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
