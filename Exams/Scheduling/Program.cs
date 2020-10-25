using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threadsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> task = new Stack<int>(taskInput);
            Queue<int> thread = new Queue<int>(threadsInput);

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentThread = thread.Peek();
                int currentTask = task.Peek();

                if (thread.Peek() >= task.Peek())
                {
                    thread.Dequeue();
                    task.Pop();

                }
                else if (thread.Peek() < task.Peek())
                {
                    thread.Dequeue();
                }

                if (task.Peek() == taskToBeKilled)
                {

                    Console.WriteLine($"Thread with value {thread.Peek()} killed task {taskToBeKilled}");
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", thread));
        }
    }
}
