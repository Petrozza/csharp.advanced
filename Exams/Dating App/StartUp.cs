using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] malesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] femalesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(malesInput);
            Queue<int> females = new Queue<int>(femalesInput);

            int matchesCount = 0;
            while (males.Any() && females.Any())
            {
                if (males.Peek() <= 0 || females.Peek() <= 0)
                {
                    if (males.Peek() <= 0)
                    {
                        males.Pop();
                    }
                    if (females.Peek() <= 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }
                if (males.Peek() % 25 == 0 || females.Peek() % 25 == 0)
                {
                    if (males.Peek() % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }
                    if (females.Peek() % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                    continue;
                }

                if (males.Peek() == females.Peek())
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    int decrease2 = males.Peek() - 2;
                    males.Pop();
                    males.Push(decrease2);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }

        }
    }
}
