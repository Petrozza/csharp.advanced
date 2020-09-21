using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> que = new Queue<int>();

            int n = commands[0];
            int s = commands[1];
            int x = commands[2];

            for (int i = 0; i < n; i++)
            {
                que.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                if (que.Any())
                {
                    que.Dequeue();
                }
            }
            if (que.Any())
            {
                if (que.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(que.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }


        }
    }
}

