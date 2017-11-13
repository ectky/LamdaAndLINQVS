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
            var phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                List<string> list = input.Split(' ').ToList();
                if (list[0] == "A")
                {
                    phonebook[list[1]] = list[2];
                }
                else if(list[0] == "S")
                {
                    if (phonebook.ContainsKey(list[1]))
                    {
                        Console.WriteLine($"{list[1]} -> {phonebook[list[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {list[1]} does not exist.");
                    }
                }
                else
                {
                    foreach (var pair in phonebook.OrderBy(n => n.Key))
                    {
                        Console.WriteLine($"{pair.Key} -> {pair.Value}");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
