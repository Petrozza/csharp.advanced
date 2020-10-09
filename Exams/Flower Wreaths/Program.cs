using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rosesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> lilies = new Stack<int>(liliesInput);
            Queue<int> roses = new Queue<int>(rosesInput);
            int countWreaths = 0;
            int storedFlowers = 0;
            int leftWreaths = 0;

            while (lilies.Any() && roses.Any())
            {
                int liliesCount = lilies.Peek();
                int rosesCount = roses.Peek();

                if (liliesCount + rosesCount == 15)
                {
                    countWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }

                else if (liliesCount + rosesCount > 15)
                {
                    while (liliesCount + rosesCount > 15)
                    {
                        liliesCount -= 2;
                    }

                    if (liliesCount + rosesCount == 15)
                    {
                        countWreaths++;
                        lilies.Pop();
                        roses.Dequeue();
                    }

                    else if (liliesCount + rosesCount < 15)
                    {
                        storedFlowers += (liliesCount + rosesCount);
                        lilies.Pop();
                        roses.Dequeue();
                    }
                }

                else
                {
                    storedFlowers += (liliesCount + rosesCount);
                    lilies.Pop();
                    roses.Dequeue();
                }
            }
            if (storedFlowers >= 15)
            {
                leftWreaths = storedFlowers / 15;
            }

            if (leftWreaths + countWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {leftWreaths + countWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - (leftWreaths + countWreaths)} wreaths more!");
            }

        }
    }
}
