using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniBeerPong
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "stop the game")
            {
                string[] list = input.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string player = list[0];
                string team = list[1];
                int points = int.Parse(list[2]);
                if (teams.ContainsKey(team))
                {
                    if (teams[team].Count < 3)
                    {
                        teams[team][player] = points;
                    }
                }
                else
                {
                    teams.Add(team, new Dictionary<string, int>());
                    teams[team][player] = points;
                }

                input = Console.ReadLine();
            }

            int i = 0;
            foreach (var pair in teams.Where(pair => pair.Value.Count == 3).OrderByDescending(pair => pair.Value.Values.Sum()))
            {
                i++;
                Console.WriteLine($"{i}. {pair.Key}; Players:");
                foreach (var secPair in pair.Value.OrderByDescending(secPair => secPair.Value))
                {
                    Console.WriteLine($"###{secPair.Key}: {secPair.Value}");
                }
            }
        }
    }
}
