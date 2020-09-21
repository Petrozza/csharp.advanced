using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            while (true)
            {
                string[] lineIn = Console.ReadLine().ToLower().Split().ToArray();
                if (lineIn[0] == "end")
                {
                    break;
                }

                if (lineIn[0] == "add")
                {
                    stack.Push(int.Parse(lineIn[1]));
                    stack.Push(int.Parse(lineIn[2]));
                }

                if (lineIn[0] == "remove")
                {
                    if (stack.Count() < int.Parse(lineIn[1]))
                    {
                        continue;
                    }
                    for (int i = 1; i <= int.Parse(lineIn[1]); i++)
                    {
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}
