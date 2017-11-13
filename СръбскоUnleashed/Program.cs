using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace СръбскоUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([A-za-z ]+) @([A-za-z ]+) ([0-9]+) ([0-9]+)");
            var venues = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string venue = match.Groups[2].Value;
                    int price = int.Parse(match.Groups[3].Value);
                    int count = int.Parse(match.Groups[4].Value);
                    if (!venues.ContainsKey(venue))
                    {
                        venues.Add(venue, new Dictionary<string, long>());
                    }
                    long money = price * count;
                    if (!venues[venue].ContainsKey(name))
                    {
                        venues[venue].Add(name, 0);
                    }
                    venues[venue][name] += money;
                }
                input = Console.ReadLine();
            }

            foreach (var pair in venues)
            {
                Console.WriteLine($"{pair.Key}");
                foreach (var secPair in pair.Value
                    .OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {secPair.Key} -> {secPair.Value}");
                }
            }

        }
    }
}
