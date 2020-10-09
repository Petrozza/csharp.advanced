using System;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = Console.ReadLine().Split();

            Action<string> PrintName = name => Console.WriteLine($"Sir {name}");

            foreach (var item in name)
            {
                PrintName(item);
            }
        }
    }
}
