using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, DateTime>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] list = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string user = list[0];
                DateTime date = DateTime.ParseExact(list[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                users[user] = date;
                input = Console.ReadLine();
            }

            foreach (var pair in users.Reverse().OrderByDescending(pair => pair.Value).Take(5))
            {
                Console.WriteLine(pair.Key);
            }
        }
    }
}
