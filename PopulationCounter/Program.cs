using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "report")
            {
                List<string> list = input.Split('|').ToList();
                string country = list[1];
                string city = list[0];
                long population = long.Parse(list[2]);

                if (!counter.ContainsKey(country))
                {
                    counter.Add(country, new Dictionary<string, long>());
                }
                if (!counter[country].ContainsKey(city))
                {
                    counter[country][city] = 0;
                }
                counter[country][city] += population;

                input = Console.ReadLine();
            }

            foreach (var pair in counter.OrderByDescending(p => p.Value.Sum(n => n.Value)))
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value.Sum(n => n.Value)})");
                foreach (var secpair in pair.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"=>{secpair.Key}: {secpair.Value}");
                }
            }

        }

    }
}
