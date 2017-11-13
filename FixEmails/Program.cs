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
            var emails = new Dictionary<string, string>();
            string name = Console.ReadLine();
            while (name != "stop")
            {
                string email = Console.ReadLine();
                string em = email.ToLower();
                if (!(em.EndsWith(".uk") || em.EndsWith(".us")))
                {
                    emails[name] = em;
                }

                name = Console.ReadLine();
            }

            foreach (var pair in emails)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");

            }
        }
    }
}
