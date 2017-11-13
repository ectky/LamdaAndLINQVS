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
            var users = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                List<string> name = input.Split(new string[] { " message" }
                , StringSplitOptions.RemoveEmptyEntries).ToList();
                string ip = name[0].Split(new string[] { "IP=" },
                    StringSplitOptions.RemoveEmptyEntries).ToList()[0];
                string username = input.Split(new string[] { "user=" },
                    StringSplitOptions.RemoveEmptyEntries).ToList()[1];

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }
                if (!users[username].ContainsKey(ip))
                {
                    users[username][ip] = 0;
                }
                users[username][ip] += 1;
                
                input = Console.ReadLine();
            }

            foreach (var pair in users.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{pair.Key}:");
                int i = 0;
                foreach (var secpair in pair.Value)
                {
                    Console.Write($"{secpair.Key} => {secpair.Value}");
                    i++;
                    if (i > 0 && i < pair.Value.Count)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(".");
                Console.WriteLine();
            }

        }
        
    }
}
