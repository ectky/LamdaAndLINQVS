using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, SortedDictionary<string, List<int>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string type = input[0];
                string name = input[1];
                int damage = GetDamage(input[2]);
                int health = GetHealth(input[3]);
                int armour = GetArmour(input[4]);
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, List<int>>());
                }
                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new List<int>());
                }
                List<int> list = new List<int>() { damage, health, armour };
                dragons[type][name] = list;
            }

            foreach (var pair in dragons)
            {
                Console.WriteLine($"{pair.Key}::({pair.Value.Average(p => p.Value[0]):F2}" +
                    $"/{pair.Value.Average(p => p.Value[1]):F2}" +
                    $"/{pair.Value.Average(p => p.Value[2]):F2})");
                foreach (var secpair in pair.Value)
                {
                    Console.WriteLine($"-{secpair.Key} ->" +
                        $" damage: {secpair.Value[0]}," +
                        $" health: {secpair.Value[1]}," +
                        $" armor: {secpair.Value[2]}");
                }
            }
        }

        private static int GetDamage(string v)
        {
            switch (v)
            {
                case "null":
                    return 45;
                default:
                    return int.Parse(v);
            }


        }
        private static int GetHealth(string v)
        {
            switch (v)
            {
                case "null":
                    return 250;
                default:
                    return int.Parse(v);
            }
        }
        private static int GetArmour(string v)
        {
            switch (v)
            {
                case "null":
                    return 10;
                default:
                    return int.Parse(v);
            }
        }
    }
}
