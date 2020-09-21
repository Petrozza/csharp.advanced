using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int quantityForDay = int.Parse(Console.ReadLine());
            int[] orderQuantity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(orderQuantity);
            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                int currentOrder = orders.Peek();

                if (quantityForDay < currentOrder)
                {
                    break;
                }

                orders.Dequeue();
                quantityForDay -= currentOrder;

            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }


        }
    }
}
