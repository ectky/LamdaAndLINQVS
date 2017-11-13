using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            double count = 0;
            var logs = new List<KeyValuePair<string, int>>();
            string input = Console.ReadLine();

            while (input != "chop chop")
            {
                var list = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries).ToList();
                string log = list[0];
                int quantity = int.Parse(list[1]);
                count++;
                
                logs.Add(new KeyValuePair<string, int>(log, quantity));

                input = Console.ReadLine();
            }

            double avrg = Math.Round(logs.Sum(pair => pair.Value) / count, 2);
            Console.WriteLine($"Price per meter: ${avrg:F2}");

            input = Console.ReadLine();
            int height = int.Parse(Console.ReadLine());

            double usedLogs = logs
                .Where(pair => pair.Key == input && pair.Value >= height)
                .Sum(pair => pair.Value);
            double usedPrice = Math.Round(usedLogs * avrg, 2);
            Console.WriteLine($"Used logs price: ${usedPrice:F2}");

            double unusedLogs = logs
                .Where(pair => pair.Key != input || pair.Value < height)
                .Sum(pair => pair.Value);
            double unusedPrice = Math.Round(unusedLogs * avrg * 0.25, 2);
            Console.WriteLine($"Unused logs price: ${unusedPrice:F2}");
            Console.WriteLine($"CottageScraper subtotal: ${unusedPrice + usedPrice:F2}");

        }
    }
}
