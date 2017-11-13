using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] list = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string key = list[0];
                string value = list[1];
                dict[key] = value;
                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            foreach (var pair in dict.Where(pair => pair.Value != "null").OrderByDescending(pair => pair.Value.Length))
            {
                Console.WriteLine($"{pair.Key} <-> {pair.Value}");
            }

            foreach (var pair in dict.Where(pair => pair.Value == "null"))
            {
                Console.WriteLine($"{pair.Key} <-> {input}");
            }
        }
    }
}
