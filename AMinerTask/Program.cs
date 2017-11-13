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
            var resources = new Dictionary<string, int>();
            string resource = "a"; int i = 0;
            string input = Console.ReadLine();
            while (input != "stop")
            {
                i++;
                if (i % 2 == 1)
                {
                    resource = input;
                }
                else
                {
                    if (!resources.ContainsKey(resource))
                    {
                        resources[resource] = 0;
                    }
                    resources[resource] += int.Parse(input);
                }
                
                input = Console.ReadLine();
            }

            foreach (var pair in resources)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
