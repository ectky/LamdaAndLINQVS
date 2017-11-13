using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            var products = new Dictionary<string, decimal>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] list = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string product = list[0];
                decimal price = decimal.Parse(list[1]);
                if (products.ContainsKey(product))
                {
                    if (products[product] > price)
                    {
                        products[product] = price;
                    }
                }
                else
                {
                    products[product] = price;
                }
                input = Console.ReadLine();
            }

            if (products.Values.Sum() > budget)
            {
                Console.WriteLine("Need more money... Just buy banichka");
            }
            else
            {
                foreach (var pair in products.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key.Length))
                {
                    Console.WriteLine($"{pair.Key} costs {pair.Value:F2}");
                }
            }
        }
    }
}
