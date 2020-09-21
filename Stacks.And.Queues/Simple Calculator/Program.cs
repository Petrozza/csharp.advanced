using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int number1 = int.Parse(stack.Pop());
                string operand = stack.Pop();
                int number2 = int.Parse(stack.Pop());

                if (operand == "-")
                {
                    string result = (number1 - number2).ToString();
                    stack.Push(result.ToString());
                }
                if (operand == "+")
                {
                    string result = (number1 + number2).ToString();
                    stack.Push(result.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
