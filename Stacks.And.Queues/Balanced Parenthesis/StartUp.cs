using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parenths = new Stack<char>();

            bool isValid = true;

            foreach (char skoba in input)
            {
                if (skoba == '{' || skoba == '[' || skoba == '(')
                {
                    parenths.Push(skoba);
                    continue;
                }

                if (!parenths.Any())
                {
                    isValid = false;
                    break;
                }

                if (parenths.Peek() == '{' && skoba == '}')
                {
                    parenths.Pop();
                }
                else if (parenths.Peek() == '[' && skoba == ']')
                {
                    parenths.Pop();
                }
                else if (parenths.Peek() == '(' && skoba == ')')
                {
                    parenths.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
