using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camping
{
    class Program
    {
        static void Main(string[] args)
        {
            var campers = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                List<string> list = input.Split(' ').ToList();
                if (!campers.ContainsKey(list[0]))
                {
                    campers.Add(list[0], new Dictionary<string, int>());
                }

                if (!campers[list[0]].ContainsKey(list[1]))
                {
                    campers[list[0]].Add(list[1], int.Parse(list[2]));
                }

                input = Console.ReadLine();
            }

            foreach (var pair in campers
                .OrderByDescending(pair => campers[pair.Key].Count)
                .ThenBy(pair => pair.Key.Length))
            {
                Console.WriteLine($"{pair.Key}: {campers[pair.Key].Count}");

                foreach (var secPair in pair.Value)
                {
                    Console.WriteLine($"***{secPair.Key}");
                }

                Console.WriteLine($"Total stay: {campers[pair.Key].Sum(p => p.Value)} nights");
                
            }
        }
    }
}
