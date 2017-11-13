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
            var hands = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                List<string> name = input.Split(new string[] { ": " }
                ,StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> list = name[1].Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!hands.ContainsKey(name[0]))
                {
                    hands.Add(name[0], new Dictionary<string, int>());
                }

                for (int i = 0; i < list.Count; i++)
                {
                    int value = 0;
                    if (list[i].Length > 2)
                    {
                        value = 10 * GetManipulation(list[i][2]);
                    }
                    else
                    {
                        value = GetPower(list[i][0]) * GetManipulation(list[i][1]);
                    }
                    hands[name[0]][list[i]] = value;
                }
                input = Console.ReadLine();
            }

            foreach (var pair in hands)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Sum(p => p.Value)}");
            }
            
        }

        private static int GetManipulation(char v)
        {
            int pow = 0;
            switch (v)
            {
                case 'S':
                    pow = 4; break;
                case 'H':
                    pow = 3; break;
                case 'D':
                    pow = 2; break;
                case 'C':
                    pow = 1; break;
            }
            return pow;
        }

        static int GetPower(char card)
        {
            int pow = 0;
            switch (card)
            {
                case 'J':
                    pow = 11; break;
                case 'Q':
                    pow = 12; break;
                case 'K':
                    pow = 13; break;
                case 'A':
                    pow = 14; break;
                default:
                    pow = int.Parse(card.ToString()); break;
            }
            return pow;
        }
    }
}
