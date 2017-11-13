using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, string>>();
            var flattened = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] list = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (list[0] == "flatten")
                {
                    flattened.Add(list[1], new List<string>());
                    foreach (var pair in dict[list[1]])
                    {
                        string concatenated = pair.Key + pair.Value;
                        flattened[list[1]].Add(concatenated);
                    }
                    dict[list[1]] = new Dictionary<string, string>();
                }
                else
                {
                    string key = list[0];
                    string innerKey = list[1];
                    string innerValue = list[2];
                    if (dict.ContainsKey(key))
                    {
                        dict[key][innerKey] = innerValue;
                    }
                    else
                    {
                        dict.Add(key, new Dictionary<string, string>());
                        dict[key][innerKey] = innerValue;
                    }
                }
                input = Console.ReadLine();
            }

            int i = 0;
            foreach (var pair in dict.OrderByDescending(pair => pair.Key.Length))
            {
                i = 0;
                Console.WriteLine(pair.Key);
                foreach (var secPair in pair.Value.OrderBy(secPair => secPair.Key.Length))
                {
                    i++;
                    Console.WriteLine($"{i}. {secPair.Key} - {secPair.Value}");
                }

                if (flattened.ContainsKey(pair.Key))
                {
                    foreach (var abv in flattened[pair.Key])
                    {
                        i++;
                        Console.WriteLine($"{i}. {abv}");

                    }
                }

            }
        }
    }
}