using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();

            while (input != "Revision")
            {
                

                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!stores.ContainsKey(shop))
                {
                    stores.Add(shop, new Dictionary<string, double>());
                }

                if (!stores[shop].ContainsKey(product))
                {
                    stores[shop].Add(product, price);
                }
                stores[shop][product] = price;

                input = Console.ReadLine();
            }
            
            foreach (var (shopname, products) in stores.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shopname}->");

                foreach (var kvp in products)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
