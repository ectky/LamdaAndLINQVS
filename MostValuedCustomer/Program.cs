using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostValuedCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, double>();
            string input = Console.ReadLine();
            while (input != "Shop is open")
            {
                List<string> list = input.Split(' ').ToList();
                products[list[0]] = double.Parse(list[1]);

                input = Console.ReadLine();
            }

            var customers = new Dictionary<string, Dictionary<string, double>>();
            input = Console.ReadLine();
            while (input != "Print")
            {
                if (input == "Discount")
                {
                    var discountedProducts = products
                         .OrderByDescending(pd => pd.Value)
                         .Take(3)
                         .Select(pd =>
                             new KeyValuePair<string, double>(pd.Key, pd.Value * 0.9));

                    foreach (var discountedProduct in discountedProducts)
                    {
                        products[discountedProduct.Key] = discountedProduct.Value;
                    }
                }
                else
                {
                    List<string> list = input.Split(new string[] { ": " },
 StringSplitOptions.RemoveEmptyEntries).ToList();
                    List<string> prods = list[1].Split(new string[] { ", " },
 StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (!customers.ContainsKey(list[0]))
                    {
                        customers.Add(list[0], new Dictionary<string, double>());
                    }

                    foreach (var product in prods)
                    {
                        if (products.ContainsKey(product))
                        {
                            customers[list[0]].Add(product, products[product]);
                        }
                    }

                }

                input = Console.ReadLine();
            }

            foreach (var pair in customers.OrderByDescending(kvp => kvp.Value.Sum(d => d.Value)).Take(1))
            {
                Console.WriteLine($"Biggest spender: {pair.Key}");
                Console.WriteLine("^Products bought:");
                foreach (var secPair in pair.Value.Distinct().OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"^^^{secPair.Key}:{secPair.Value:F2}");
                }
                Console.WriteLine($"Total: {pair.Value.Sum(d => d.Value)}");
            }

        }
    }
}
