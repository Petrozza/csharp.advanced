using System;
using System.Linq;

namespace myStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            myStack<int> myStack = new myStack<int>();

            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                string[] commandArr = commandInput
                    .Split( new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandArr[0];

                if (command == "Push")
                {
                    foreach (var item in commandArr.Skip(1))
                    {
                        myStack.Push(int.Parse(item));
                    }
                }
                else if (command == "Pop")
                {
                    if (myStack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                        myStack.Pop();
                    }
                }

                commandInput = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

        }
    }
}
