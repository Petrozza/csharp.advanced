using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsData);
            Stack<int> bottles = new Stack<int>(bottlesData);

            int wastedWater = 0;

            int currentCupValue = cups.Peek();
            
            while (cups.Any() && bottles.Any())
            {
                int currentBottleValue = bottles.Pop();

                if (currentBottleValue >= currentCupValue)
                {
                    wastedWater += (currentBottleValue - currentCupValue);

                    cups.Dequeue();

                    if (cups.Count > 0)
                    {
                        currentCupValue = cups.Peek();
                    }
                }
                else
                {
                    currentCupValue -= currentBottleValue;
                }
            }

            if (bottles.Count > 0 && cups.Count <= 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > 0 && bottles.Count <= 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}

