using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int toEnqueue = commands[0];
            int toDequeue = commands[1];
            int toLookFor = commands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            Queue<int> elements = new Queue<int>();

            for (int i = 0; i < toEnqueue; i++)
            {
                elements.Enqueue(numbers[i]);
            }

            for (int k = 0; k < toDequeue; k++)
            {
                elements.Dequeue();
            }

            if (elements.Any())
            {
                if (elements.Contains(toLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    List<int> remaining = new List<int>(elements.ToList());
                    Console.WriteLine(remaining.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
            
        }
    }
}

