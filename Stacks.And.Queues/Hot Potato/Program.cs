using System;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childrens = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> que = new Queue<string>(childrens);
            int counter = 0;
            while (que.Count() > 1)
            {
                string nameToAdd = que.Dequeue(); 
                counter++;
                if (counter % n != 0)
                {
                    que.Enqueue(nameToAdd);
                }
                else
                {
                    Console.WriteLine($"Removed {nameToAdd}");
                }
            }
            Console.WriteLine($"Last is {que.Dequeue()}");
        }
    }
}
