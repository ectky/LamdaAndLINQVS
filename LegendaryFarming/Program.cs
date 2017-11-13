using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keymaterials = new Dictionary<string, int>();
            var junkmaterials = new Dictionary<string, int>();
            keymaterials.Add("shards", 0); keymaterials.Add("motes", 0);
            keymaterials.Add("fragments", 0);
            
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                List<string> list = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int i = 0; i < list.Count; i+=2)
                {
                    string material = list[i + 1];
                    if (keymaterials.ContainsKey(material))
                    {
                        keymaterials[material] += int.Parse(list[i]);
                        if (keymaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "shrads":
                                    Console.WriteLine("Shadowmourne obtained!");break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!"); break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!"); break;
                                default:
                                    break;
                            }
                            keymaterials[material] -= 250;
                            PrintValues(keymaterials, junkmaterials);
                            return;
                        }
                    }
                    else
                    {
                        if (!junkmaterials.ContainsKey(material))
                        {
                            junkmaterials.Add(material, 0);

                        }
                        junkmaterials[material] += int.Parse(list[i]);
                    }
                }
            }
        }

        private static void PrintValues(Dictionary<string, int> keymaterials, Dictionary<string, int> junkmaterials)
        {
            foreach (var pair in keymaterials.OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            foreach (var pair in junkmaterials.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");

            }
        }
    }
}
