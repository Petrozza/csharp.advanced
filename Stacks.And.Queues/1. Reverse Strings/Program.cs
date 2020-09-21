using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);
            }
            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();

        }
    }
}