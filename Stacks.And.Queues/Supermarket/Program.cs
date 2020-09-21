using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customrers = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                else if (input == "Paid")
                {
                    while (customrers.Any())
                    {
                        Console.WriteLine(customrers.Dequeue());
                    }
                }

                else
                {
                    customrers.Enqueue(input);
                }
            }
            Console.WriteLine($"{customrers.Count} people remaining.");



        }
    }
}
