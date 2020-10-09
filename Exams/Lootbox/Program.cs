using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxInput);
            Stack<int> secondBox = new Stack<int>(secondBoxInput);

            List<int> collection = new List<int>();

            while (firstBox.Any() && secondBox.Any())
            {
                int currentFirstItem = firstBox.Peek();
                int currentSecondItem = secondBox.Peek();
                int sum = currentFirstItem + currentSecondItem;

                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }

            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collection.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collection.Sum()}");
            }
        }
    }
}
